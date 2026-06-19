using TMPro;
using UnityEngine;

public class StartGraphic : MonoBehaviour
{
	public float holdRate = 1f;

	public float flashRate = 0.25f;

	private float holdDecayLimiter = 0.75f;

	private float flashDecayLimiter = 0.75f;

	private float currentCount;

	private bool isVisible = true;

	private TextMeshPro textRef;

	private void Start()
	{
		textRef = GetComponent<TextMeshPro>();
	}

	private void Update()
	{
		Flash();
	}

	private void Flash()
	{
		if (isVisible)
		{
			float num = currentCount;
			if (currentCount <= holdRate * holdDecayLimiter)
			{
				num = 0f;
			}
			float a = Mathf.Max((holdRate - num) / holdRate, 0f);
			textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, a);
			if (currentCount >= holdRate)
			{
				StartFlash();
			}
		}
		else if (!isVisible)
		{
			float num = currentCount;
			if (currentCount <= flashRate * flashDecayLimiter)
			{
				num = 0f;
			}
			float a = Mathf.Max((flashRate - num) / flashRate, 0f);
			textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, a);
			if (currentCount >= flashRate)
			{
				StartHold();
			}
		}
		currentCount += Time.deltaTime;
	}

	private void StartFlash()
	{
		currentCount = 0f;
		isVisible = false;
		textRef.enabled = false;
	}

	private void StartHold()
	{
		currentCount = 0f;
		isVisible = true;
		textRef.enabled = true;
	}
}
