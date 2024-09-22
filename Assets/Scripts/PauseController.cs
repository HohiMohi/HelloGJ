using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;
    private bool _isPaused;
    [SerializeField]
    private bool _isPauseAvailable = true;
    public float pauseTime = 3f;
    public float pauseCooldown = 5f;
    [SerializeField] private float cooldownTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (_isPaused == false && _isPauseAvailable == true)
            {
                _isPaused = true;
                StartCoroutine(PauseGame());
            }
        }
        
            CheckCooldown();
    }
    
    public IEnumerator PauseGame()
    {
        _isPauseAvailable = false;
        cooldownTimer = pauseCooldown;
        Time.timeScale = 0;
        GamePaused.Invoke();
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
        GameResumed.Invoke();
        _isPaused = false;
    }

    public void CheckCooldown()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            cooldownTimer = 0;
            _isPauseAvailable = true;
        }
    }
}
