using UnityEngine;

public class ClockHands : MonoBehaviour
{
	[SerializeField]
	private float timeLeft;

	private float startTime;

	[SerializeField]
	private GameObject movingClockHand;

	private void Start()
	{
		startTime = timeLeft;
	}

	private void Update()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			timeLeft -= Time.deltaTime;
		}
	}

	private void FixedUpdate()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && !GameManager.Singleton.hasTimerElapsed_IsNighttime)
		{
			float z = Mathf.Lerp(0f, 360f, timeLeft / startTime);
			movingClockHand.transform.localEulerAngles = new Vector3(0f, 0f, z);
		}
	}
}
