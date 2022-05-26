## [Get this title for $10 on Packt's Spring Sale](https://www.packt.com/B09547?utm_source=github&utm_medium=packt-github-repo&utm_campaign=spring_10_dollar_2022)
-----
For a limited period, all eBooks and Videos are only $10. All the practical content you need \- by developers, for developers

# Learn ARCore - Fundamentals of Google ARCore
This is the code repository for [Learn ARCore - Fundamentals of Google ARCore](https://www.packtpub.com/application-development/learn-arcore-fundamentals-google-arcore?utm_source=github&utm_medium=repository&utm_campaign=9781788830409), published by [Packt](https://www.packtpub.com/?utm_source=github). It contains all the supporting project files necessary to work through the book from start to finish.
## About the Book
Are you a mobile developer or web developer who wants to create immersive and cool Augmented Reality apps with the latest Google ARCore platform? If so, this book will help you jump right into developing with ARCore and will help you create a step by step AR app easily.

This book will teach you how to implement the core features of ARCore starting from the fundamentals of 3D rendering to more advanced concepts such as lighting, shaders, Machine Learning, and others.

We’ll begin with the basics of building a project on three platforms: web, Android, and Unity. Next, we’ll go through the ARCore concepts of motion tracking, environmental understanding, and light estimation. For each core concept, you’ll work on a practical project to use and extend the ARCore feature, from learning the basics of 3D rendering and lighting to exploring more advanced concepts.

You’ll write custom shaders to light virtual objects in AR, then build a neural network to recognize the environment and explore even grander applications by using ARCore in mixed reality. At the end of the book, you’ll see how to implement motion tracking and environment learning, create animations and sounds, generate virtual characters, and simulate them on your screen.

## Instructions and Navigation
All of the code is organized into folders. Each folder starts with a number followed by the application name. For example, Chapter02.



The code will look like the following:
```
void main() {
   float t = length(a_Position)/u_FurthestPoint;
   v_Color = vec4(t, 1.0-t,t,1.0);
   gl_Position = u_ModelViewProjection * vec4(a_Position.xyz, 1.0);
   gl_PointSize = u_PointSize;
}
```

These are the things to be remembered in order to use this book to the fullest:

The reader will need to be proficient in one of the following programming languages: JavaScript, Java, or C#
A memory of high-school mathematics
An Android device that supports ARCore; the following is the link to check the list: https://developers.google.com/ar/discover/
A desktop machine that will run Android Studio and Unity; a dedicated 3D graphics card is not explicitly required

## Related Products
* [Augmented Reality for Developers](https://www.packtpub.com/web-development/augmented-reality-developers?utm_source=github&utm_medium=repository&utm_campaign=9781787286436)

* [Augmented Reality Game Development](https://www.packtpub.com/application-development/augmented-reality-game-development?utm_source=github&utm_medium=repository&utm_campaign=9781787122888)

* [Unity 2017 Game AI programming - Third Edition](https://www.packtpub.com/game-development/unity-2017-game-ai-programming-third-edition?utm_source=github&utm_medium=repository&utm_campaign=9781788477901)
