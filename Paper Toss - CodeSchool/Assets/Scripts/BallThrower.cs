using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallThrower : MonoBehaviour
{
    // Variables

    // A transform is basically a component which is mutual between all gameobjects
    // transform holds information of a gameobject in 3D space such as position and rotation
    public Transform startpt;
    // An array of rigidbodies which will have all balls
    public Rigidbody[] balls;
    // An index of current ball
    private int currentball;
    // Basic variables to determine maximum speed with which we can throw a ball and 
    // how rapidly we can achieve maximum speed with our input 
    public float maxForce, speedincrement;
    // Temporary variable that remains between 0 and maxForce
    [SerializeField] private float force;
    // Bool to determine if we are ready to throw again after last throw
    public bool ready;
    // Reference to image on the side of screen to display the force meter
    public Image fillImage;
    // Colos which force meter adopt to depending on the force
    public Color dangercolor, safecolor;
    // Reference to UI elemetnt where we will represent total number of throws we made
    public TextMeshProUGUI throwstext;
    // A counter to calculate total throws in a game
    private int totalthrows;


    // Update is called every frame, for crucial game loop such as input, we should alawys use update
    private void Update()
    {

        // If we are ready to throw the ball 
        if (ready)
        {
            // If left mouse click is being detected
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // We increase the force value depending on how far we move our cursor up

                force += Input.GetAxis("Mouse Y") * speedincrement * Time.deltaTime;

                // Making sure force is never below 0 and never above the maxForce
                force = Mathf.Clamp(force, 0, maxForce);

                // Updating the forcemeter on runtime, it fills up completely is force = maxForce and empties out when force is 0
                fillImage.fillAmount = force / maxForce;

                // A check to change color of force meter
                if (force >= 15.8f && force <= 16.5f)
                {
                    fillImage.color = safecolor;
                }
                else
                {
                    fillImage.color = dangercolor;
                }
            }

            // Detecting if left click was lifted, meaning user tried the throw
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {

                // We count it a throw and add to the last number of throws so if throws were 0, now they are 1, if throws were 1, now they are 2 etc
                totalthrows++;

                // Updating the UI to display how many throws have been don
                throwstext.text = "Throws: " + totalthrows.ToString();

                // Enabling the physics calculation on the ball
                balls[currentball].isKinematic = false;

                // Adding force to the ball
                balls[currentball].AddForce(transform.forward * force, ForceMode.Impulse);

                // Calling the function from Ball script on ball to turn it off after some time - More detail in Ball.cs
                balls[currentball].GetComponent<Ball>().TurnMeOff();

                // We tell system that we just throwed a ball and now we are not ready to throw right away
                ready = false;

                // We make sure our throw force is back to 0 and we must build it up again for next throw
                force = 0;

                // We call wait method to do (as the name suggests) some wait
                StartCoroutine(wait());
            }
        }
    }

    private IEnumerator wait()
    {
        // We wait for 1 second after a throw is done
        yield return new WaitForSeconds(1f);

        // We reset the force meter
        fillImage.fillAmount = 0;
        // We bring in next ball from the array (pool)
        currentball++;

        // If there are no more balls in the array, we reset the balls index and get the first ball from array
        if (currentball >= balls.Length)
        {
            currentball = 0;
        }

        // We make sure that there is no remaining energy in the ball
        balls[currentball].velocity = Vector3.zero;
        // Making sure that physics is not calculated such as gravity 
        balls[currentball].isKinematic = true;
        // Setting the ball to the position where we throw it from 
        balls[currentball].transform.position = startpt.position;
        // Turning on the ball
        balls[currentball].gameObject.SetActive(true);
        // Since we have the ball in place, everything is reset once again, we are ready to throw again
        ready = true;
    }
}
