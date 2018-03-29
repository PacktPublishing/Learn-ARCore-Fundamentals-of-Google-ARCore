namespace Packt.ARCoreDesign
{
    using UnityEngine;
    using UnityEngine.Rendering;
    using GoogleARCore;

    /// <summary>
    /// A component that automatically adjust lighting settings for the scene
    /// to be inline with those estimated by ARCore.
    /// </summary>
    [ExecuteInEditMode]
    public class AREnvironmentalLight : MonoBehaviour
    {
        public GameObject SceneCamera;
        public GameObject SceneLight;
        public float lightDirectionDecay = .99998f;
        private float maxGlobal = float.MinValue;
        private Vector3 maxLightDirection;
        /// <summary>
        /// Unity update method that sets global light estimation shader constant to match
        /// ARCore's calculated values.
        /// </summary>
        public void Update()
        {
#if UNITY_EDITOR
            
            // Set _GlobalLightEstimation to 1 in editor, if the value is not set, all materials
            // using light estimation shaders will be black.
            Shader.SetGlobalFloat("_GlobalLightEstimation", 1.0f);
#else
            // Check that motion tracking is tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            // Use the following function to compute color scale:
            // * linear growth from (0.0, 0.0) to (1.0, LinearRampThreshold)
            // * slow growth from (1.0, LinearRampThreshold)
            const float LinearRampThreshold = 0.8f;
            const float MiddleGray = .10f;
            const float Inclination = 0.4f;

            var pi = Frame.LightEstimate.PixelIntensity;
            maxGlobal *= lightDirectionDecay;
            if (pi > maxGlobal)
            {
                maxGlobal = pi;
                SceneLight.transform.rotation = Quaternion.LookRotation(-SceneCamera.transform.forward);                
            }

            float normalizedIntensity = Frame.LightEstimate.PixelIntensity / MiddleGray;
            float colorScale = 1.0f;

            if (normalizedIntensity < 1.0f)
            {
                colorScale = normalizedIntensity * LinearRampThreshold;
            }
            else
            {
                float b = LinearRampThreshold / Inclination - 1.0f;
                float a = (b + 1.0f) / b * LinearRampThreshold;
                colorScale = a * (1.0f - (1.0f / (b * normalizedIntensity + 1.0f)));
            }

            Shader.SetGlobalFloat("_GlobalLightEstimation", colorScale);
#endif
        }
    }
}
