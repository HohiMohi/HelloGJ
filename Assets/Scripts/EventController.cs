using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent EventBegin;
    public UnityEvent EventEnd;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(pauseAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator pauseAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f + Random.Range(10, 15));
            Debug.Log("Pause event");

            Time.timeScale = 0;
            EventBegin.Invoke();
            yield return new WaitForSecondsRealtime(3f);
            Time.timeScale = 1;
            EventEnd.Invoke();
        }
        
    }

    
     



}
