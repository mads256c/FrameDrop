﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fpsManager : MonoBehaviour {

    public Text fpsText;

    public int startingFps = 300;

    public int lagSpikeChance = 5000;
    public int lagSpikeDuration = 5;

    bool lagSpike = false;
    double deltaTime = 0.0f;
    double fps = 0.0f;
    int times = 0;
	
	// Update is called once per frame
	void FixedUpdate () {

        // Generate a random number, if the random number is 0 then Lagspike
        if ((Random.Range(0, lagSpikeChance) == 0) && !lagSpike)
        {
            // Set the bool lagspike to true
            lagSpike = true;

            // Invoke the function "lagSpikeSet" after "lagSpikeDuration"
            Invoke("lagSpikeSet", lagSpikeDuration);
        }

        // Check if targetFramerate is bigger than 1
        if (Application.targetFrameRate > 1 && !lagSpike)
        {
            // Sets the targetFrameRate to 288 - maxX
            Application.targetFrameRate = (300 - ((int)scoreManager.maxX / 2));
        }

        // If "lagSpike" is true
        if (lagSpike)
        {
            // Set the framerate to a random framerate (lagspike like)
            Application.targetFrameRate = Random.Range(1, 5);
        }
	}

	// Update is called 60 times per secound
    void Update()
    {
		// Using this to only call it 15 times per secound
        times += 1;
        if (times >= 4)
        {
            // Deltatime is the time between the frames
            deltaTime += Time.deltaTime;

			// Divide the deltaTime in two
            deltaTime /= 2.0;

			// Set the fps to 1 divided by deltaTime
            fps = 1.0 / deltaTime;

			// Set the fps to an intiger
            fps = (int)fps;

			// Set the fps text to the fps
            fpsText.text = fps.ToString();

			// Set the times to 0 to reset it
            times = 0;
        }
    }

	// Lag spike set function
    void lagSpikeSet ()
    {
		// Set lagSpike to false
        lagSpike = false;
    }
}
