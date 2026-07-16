using TMPro;
using UnityEngine;

public class FPSCount : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelCounter;

	private int lastFrameIndex;

	private float[] frameDeltaTimeArray;

	private static FPSCount instance;

	private void Awake()
	{
		frameDeltaTimeArray = new float[50];
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Hide();
	}

	public static bool IsVisible()
	{
		return instance.labelCounter.gameObject.activeInHierarchy;
	}

	public static void Show()
	{
		instance.labelCounter.gameObject.SetActive(value: true);
	}

	public static void Hide()
	{
		instance.labelCounter.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (IsVisible())
		{
			frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
			lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;
			labelCounter.text = "FPS: " + Mathf.RoundToInt(CalculateFPS());
		}
	}

	private float CalculateFPS()
	{
		float num = 0f;
		float[] array = frameDeltaTimeArray;
		foreach (float num2 in array)
		{
			num += num2;
		}
		return (float)frameDeltaTimeArray.Length / num;
	}
}
