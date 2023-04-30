using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerControl : MonoBehaviour
{
    public AudioMenager audioMenager;
    public UIMenager uIMenager;
    public GameObject cam;
    public GameObject VectorForward;
    public GameObject VectorBack;
    float forwardSpeed = 10;
    Touch touch;
    Rigidbody rb;
    public float speed;
    bool speedBallForward = false;
    bool firtTouchControl = false;
    int soundlimitCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Variables.firstTouch == 1 && speedBallForward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            VectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            VectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !firtTouchControl)
                    {
                        Variables.firstTouch = 1;
                        firtTouchControl = true;
                    }

                    break;
                case TouchPhase.Moved:
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        rb.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y, touch.deltaPosition.y * speed * Time.deltaTime);
                        if (!firtTouchControl)
                        {
                            Variables.firstTouch = 1;
                            firtTouchControl = true;
                        }
                    }

                    break;
                case (TouchPhase.Ended):
                    rb.velocity = Vector3.zero;
                    break;
            }
        }
    }
    public GameObject[] FracturesItems;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacles"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            audioMenager.BanchSound();
            foreach (var item in FracturesItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(TimeScaleControl());
        }
        if (col.gameObject.CompareTag("Untagged"))
        {
            soundlimitCount++;
            if (col.gameObject.CompareTag("Untagged") && soundlimitCount % 5 == 0)
            {
                audioMenager.HitObjSound();
            }
        }
    }
    public IEnumerator TimeScaleControl()
    {
        speedBallForward = true;
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = .4f;
        yield return new WaitForSecondsRealtime(.5f);
        uIMenager.RestartSceneActive();
    }
}

