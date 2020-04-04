using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public bool Win = false;

    public GameObject winText;
    public GameObject deadText;
    public GameObject winEffect;
    public GameObject deadEffect;


    void FixedUpdate()
    {
        float movCam = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, movCam);

        float rotateCam = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateCam = rotateCam - 3;
            
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rotateCam = rotateCam + 3;
        }

        transform.Rotate(0, rotateCam, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TREASURE"))
        {
            Win = true;
        }
        //Debug.Log("Collider Reacted.");
        StartCoroutine(EndHandle());
        
    }

    IEnumerator EndHandle()
    {
        if(Win == true)
        {
            StartCoroutine(Victory());
        }
        else
        {
            StartCoroutine(Lose());
        }

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("ARGameScene");
    }

    IEnumerator Victory()
    {
        winEffect.SetActive(true);

        yield return new WaitForSeconds(2f);

        winText.SetActive(true);
    }
    IEnumerator Lose()
    {
        deadEffect.SetActive(true);

        yield return new WaitForSeconds(2f);

        deadText.SetActive(true);
    }
}
