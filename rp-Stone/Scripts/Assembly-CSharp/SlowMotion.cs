using UnityEngine;

public class SlowMotion : MonoBehaviour
{
	public float recoveryVelocity = 0.5f;

	public float minimumScale = -5f;

	private float timeScale;

	public static SlowMotion singleton { get; private set; }

	private void Update()
	{
		timeScale += recoveryVelocity;
		timeScale = Mathf.Clamp(timeScale, minimumScale, 1f);
		Time.timeScale = Mathf.Clamp01(timeScale);
	}

	public void Add(float amount)
	{
		timeScale -= amount;
		Time.timeScale = Mathf.Clamp01(timeScale);
	}

	private void Awake()
	{
		singleton = this;
	}
}
