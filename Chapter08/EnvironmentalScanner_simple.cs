using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class EnvironmentalScanner : MonoBehaviour
{
    public NeuralNet net;
    public List<DataSet> dataSets;
    
    private float min = float.MaxValue;    
    private float[] inputs;
    private double[] output;
    private double temp;
    private bool warning;
    private AudioSource audioSource;
    private double lastTimestamp;

    public void Awake()
    {        
        int numInputs, numHiddenLayers, numOutputs;
        numInputs = 1; numHiddenLayers = 4; numOutputs = 1;
        net = new NeuralNet(numInputs, numHiddenLayers, numOutputs);
        dataSets = new List<DataSet>();
    }

    // Use this for initialization
    void Start()
    {        
        dataSets.Add(new DataSet(new double[]{ 1,.1,0.0}, new double[] { 0.0,1.0,1.0 } ));
        net.Train(dataSets, .001);
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (warning)
        {            
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

        // Do not update if ARCore is not tracking.
        if (Frame.TrackingState != FrameTrackingState.Tracking)
        {
            return;
        }

        min = float.MaxValue;
        //enough points to test
        PointCloud pointCloud = Frame.PointCloud;
        if (pointCloud.PointCount > 0 && pointCloud.Timestamp > lastTimestamp)
        {
            lastTimestamp = pointCloud.Timestamp;
            //find min
            for (int i = 0; i < pointCloud.PointCount; i++)
            {
                var rng = Mathf.Clamp01((pointCloud.GetPoint(i)-transform.parent.parent.transform.position).magnitude);
                min = Mathf.Min(rng, min);                
            }

            //normalize data
            //min = Mathf.Clamp01(min / maxRange);

            //compute output
            output = net.Compute(new double[] { (double)min });
            
            if(output.Length > 0)
            {                
                warning = output[0] > .001;
            }
            else
            {
                warning = false;
            }
        }
    }
}
