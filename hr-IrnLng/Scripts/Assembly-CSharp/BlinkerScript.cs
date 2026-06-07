using UnityEngine;

public class BlinkerScript : MonoBehaviour
{
	public float MyDelay;

	private float SpeedTimer;

	public Material OnMat;

	public Material OffMat;

	[HideInInspector]
	public bool BlinkState;

	public bool DoingBlink;

	private Renderer Rend;

	public AudioSource BlinkSound;

	private void Start()
	{
		Rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		SpeedTimer += Time.deltaTime;
		if (SpeedTimer >= MyDelay)
		{
			UpdateBlinkState(!BlinkState);
			SpeedTimer = 0f;
		}
		if (!DoingBlink)
		{
			BlinkState = false;
		}
		if (BlinkState)
		{
			Rend.material = OnMat;
		}
		else
		{
			Rend.material = OffMat;
		}
	}

	public void UpdateBlinkState(bool b)
	{
		BlinkState = b;
		if (b && DoingBlink)
		{
			BlinkSound.Play();
		}
	}
}
