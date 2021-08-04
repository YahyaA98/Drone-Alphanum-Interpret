# Drone Alphanumeric Interpreter
A drone is to be used to detect ground alphanumeric markings to meet the design requirements of the [IMechE UAS Challenge 2020](https://www.imeche.org/events/challenges/uas-challenge/team-resources/challenge-document-library). This repository details the necessary requirements of the challenge, the methodology used and solution obtained.

## Relevant Requirements
As per the competition specification:
```
3.1.8 Camera / Imagine System
  The UA should carry a camera system and image recognition capability to undertake the Ground Marker search,
  location and identification exercise set out in the Mission, see Annex A.3.

A.3.1.2 Ground Marker Identification
  Four ground markers as defined at A.6 are placed. These are coloured squares with an Alphanumeric character.
  During the mission the UAS (Unmanned Aircraft System), shall automatically identify all four Ground markers,
  and for each report the GPS co-ordinates, colour of the inner square and the Alphanumeric character. This 
  shall be interpreted on the UA and relayed automatically to the base station during the flight.

A.6
  The ground marker shown below is a coloured 1 m x 1 m central square, incorporating an alphanumeric code 
  in white, approximately 0.75 m high, within the square. To help identifaction of the ground marker, a 
  2 m x 2m  white square will surround the central area.The alphanumeric will be restricted to a set of 
  35 characters including numbers 1-9 and Upper Case (capital) letters.
```
Ground Marker Illustration given from specification:
<p align="center">
  <img width="500" height="500" src="https://user-images.githubusercontent.com/87501079/128209127-1d0f9567-28b4-4caf-8640-39ed9cdfa50a.png">
</p>

## Methodology
These set of requirements are split into 3 distinct areas.
1. Identify the location of the ground marker.
2. Identify the alphanumeric of the ground marker.
3. Identify the background colour of the ground marker

This repositry is a part of a larger project where all these aspects are covered and this particular part covers the identification of the alphanumeric (2). So it is assumed that the location of the ground marker has already been obtained via OpenCV filtering and the drone consists of a gimbal controlled camera capable of obtaining a visual feed of the marker to a few degrees of accuracy.

This specification is met in this repository through the use of a Deep learning model using TensorFlow.

A common practice is to obtain the dataset is through the modelling of a virtual environment. This can be cheaply and quickly done using Unity. The environment generates the 35 classes with 300, 250px x 250px images per class with the camera location, camera orientation, lighting conditions, text background colour, fontstyle and vegetation conditions are randomised. 

Examples of dataset generated:
<p align="center">
  <img width="250" height="250" src="https://user-images.githubusercontent.com/87501079/128212103-af4b61f6-f2d1-47ec-805e-160234b46621.png">
  <img width="250" height="250" src="https://user-images.githubusercontent.com/87501079/128213104-65f13efd-b639-4d43-935a-717508630c2b.png">
  <img width="250" height="250" src="https://user-images.githubusercontent.com/87501079/128213178-7c09a79c-313c-456c-83a6-7ec7f045236b.png">
</p>

This resulted in about 2Gb of data generated.

Next the data is preprocessed, the CNN is built, model is trained and hyperparameters are tuned.

## Results
The validation and testing dataset shows that the model built can classify to a categorical accuracy of about 80% which is 30x better than randomly guessing. This is sufficent for a project of this scale however could be improved methods such as but not limited to increasing the model complexity, model tuning or using further data generation techniques.

## Future Work
- Increase accuracy of classification
- Implementation of model into drone
- Testing of identifier in REAL conditions

