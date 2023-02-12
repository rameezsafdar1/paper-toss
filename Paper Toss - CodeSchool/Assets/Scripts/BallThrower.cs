using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallThrower : MonoBehaviour
{
    public Transform startpt;
    public Rigidbody[] balls;
    private int currentball;
    public bool forcecalcstart;
    public float maxForce, speedincrement;
    [SerializeField] private float force;
    public bool ready;
    public Image fillImage;
    public Color dangercolor, safecolor;
    public TextMeshProUGUI throwstext;
    private int totalthrows;

    private void Update()
    {
        if (ready)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                forcecalcstart = true;

                force += Input.GetAxis("Mouse Y") * speedincrement * Time.deltaTime;
                force = Mathf.Clamp(force, 0, maxForce);
                fillImage.fillAmount = force / maxForce;

                if (force >= 15.8f && force <= 16.5f)
                {
                    fillImage.color = safecolor;
                }
                else
                {
                    fillImage.color = dangercolor;
                }
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                totalthrows++;
                throwstext.text = "Throws: " + totalthrows.ToString();
                balls[currentball].isKinematic = false;
                balls[currentball].AddForce(transform.forward * force, ForceMode.Impulse);
                balls[currentball].GetComponent<Ball>().TurnMeOff();
                ready = false;
                force = 0;
                StartCoroutine(wait());
            }
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        fillImage.fillAmount = 0;
        currentball++;

        if (currentball >= balls.Length)
        {
            currentball = 0;
        }
        balls[currentball].velocity = Vector3.zero;
        balls[currentball].isKinematic = true;
        balls[currentball].transform.position = startpt.position;
        balls[currentball].gameObject.SetActive(true);
        ready = true;
    }
}
