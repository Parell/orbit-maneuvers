using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public double universalTime;
    public bool timeScaleKeys = true;
    public int timeScale;
    public int maxTimeScale;
    public int frameRateLimit;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log($"Cant have more then one Instance on {gameObject.name}.");
        }
    }

    private void Start()
    {
        Application.targetFrameRate = frameRateLimit;
    }

    private void Update()
    {
        if (timeScaleKeys)
        {
            if (Input.GetKeyUp(KeyCode.Period))
            {
                timeScale /= 2;
            }
            else if (Input.GetKeyUp(KeyCode.Comma))
            {
                timeScale *= 2;

                if (timeScale == 0)
                {
                    timeScale = 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Slash))
            {
                timeScale = 0;
            }

            if (timeScale >= maxTimeScale)
            {
                timeScale = maxTimeScale;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < timeScale; i++)
        {
            universalTime += Time.fixedDeltaTime;
        }
    }
}
