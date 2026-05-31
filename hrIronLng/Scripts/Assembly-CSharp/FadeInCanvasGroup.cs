using UnityEngine;

public class FadeInCanvasGroup : MonoBehaviour
{
	public float FadeSpeed;

	public float InitialPause;

	private float PauseTimer;

	private CanvasGroup MyGroup;

	private void Start()
	{
		MyGroup = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		if (PauseTimer < InitialPause)
		{
			PauseTimer += Time.deltaTime;
		}
		else if (MyGroup.alpha > 0f)
		{
			MyGroup.alpha -= Time.deltaTime * FadeSpeed;
		}
	}

	public void ResetThis()
	{
		PauseTimer = 0f;
		MyGroup.alpha = 1f;
	}
}
