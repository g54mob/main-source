using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Digit : MonoBehaviour
{
	private static readonly string[] DECIMAL_VALUES = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

	private int valueIndexCurrent;

	[SerializeField]
	private GameObject TopStaticGo;

	[SerializeField]
	private GameObject TopRotatingGo;

	[SerializeField]
	private GameObject BottomStaticGo;

	[SerializeField]
	private GameObject BottomRotatingGo;

	[SerializeField]
	private TextMeshProUGUI TopStaticText;

	[SerializeField]
	private TextMeshProUGUI TopRotatingText;

	[SerializeField]
	private TextMeshProUGUI BottomStaticText;

	[SerializeField]
	private TextMeshProUGUI BottomRotatingText;

	private TextMeshProUGUI[] texts;

	private Coroutine rotationCoroutine;

	[NonSerialized]
	public bool preventColorReset;

	private int steps;

	private bool isIncrementing;

	public int CurrentDigitValue => valueIndexCurrent;

	public bool IsRotating { get; private set; }

	private string ValueStringPrevious => DECIMAL_VALUES[(valueIndexCurrent + DECIMAL_VALUES.Length - 1) % DECIMAL_VALUES.Length];

	private string ValueStringCurrent => DECIMAL_VALUES[valueIndexCurrent];

	private string ValueStringNext => DECIMAL_VALUES[(valueIndexCurrent + 1) % DECIMAL_VALUES.Length];

	private void Awake()
	{
		texts = new TextMeshProUGUI[4] { TopStaticText, TopRotatingText, BottomStaticText, BottomRotatingText };
	}

	public void StartRotationTo(int targetValue, float timePerRotation, bool isOverallIncrement, bool force = false)
	{
		CalculateSteps(targetValue);
		if (rotationCoroutine != null)
		{
			if (!force || steps == 0)
			{
				return;
			}
			StopCoroutine(rotationCoroutine);
		}
		rotationCoroutine = StartCoroutine(RotateTo(targetValue, timePerRotation, isOverallIncrement));
	}

	private void CalculateSteps(int targetValue)
	{
		int num = (targetValue - valueIndexCurrent + DECIMAL_VALUES.Length) % DECIMAL_VALUES.Length;
		int num2 = (valueIndexCurrent - targetValue + DECIMAL_VALUES.Length) % DECIMAL_VALUES.Length;
		isIncrementing = num <= num2;
		steps = (isIncrementing ? num : num2);
	}

	private IEnumerator RotateTo(int targetValue, float timePerRotation, bool isOverallIncrement)
	{
		IsRotating = true;
		for (int i = 0; i < steps; i++)
		{
			if (isOverallIncrement)
			{
				SetTextsColor(Color.green);
			}
			else
			{
				SetTextsColor(Color.red);
			}
			yield return RotateDigit(isIncrementing, timePerRotation);
		}
		if (!preventColorReset)
		{
			SetTextsColor(Color.white);
		}
		else
		{
			SetTextsColor(Color.red);
		}
		IsRotating = false;
		rotationCoroutine = null;
	}

	private IEnumerator RotateDigit(bool isIncrementing, float time)
	{
		if (isIncrementing)
		{
			yield return RotateFlapCoroutine(TopRotatingGo, TopStaticText, TopRotatingText, 0f, -90f, ValueStringNext, ValueStringCurrent, time, isTopFlap: true);
			yield return RotateFlapCoroutine(BottomRotatingGo, BottomStaticText, BottomRotatingText, -90f, 0f, ValueStringCurrent, ValueStringNext, time, isTopFlap: false);
			IncrementValueIndex();
		}
		else
		{
			yield return RotateFlapCoroutine(BottomRotatingGo, BottomStaticText, BottomRotatingText, 0f, -90f, ValueStringPrevious, ValueStringCurrent, time, isTopFlap: false);
			yield return RotateFlapCoroutine(TopRotatingGo, TopStaticText, TopRotatingText, -90f, 0f, ValueStringCurrent, ValueStringPrevious, time, isTopFlap: true);
			DecrementValueIndex();
		}
	}

	private IEnumerator RotateFlapCoroutine(GameObject rotatingGo, TextMeshProUGUI staticText, TextMeshProUGUI rotatingText, float fromAngle, float toAngle, string staticTextValue, string rotatingTextValue, float time, bool isTopFlap)
	{
		rotatingGo.transform.localRotation = Quaternion.Euler(fromAngle, 0f, 0f);
		staticText.text = staticTextValue;
		rotatingText.text = rotatingTextValue;
		float elapsed = 0f;
		while (elapsed < time / 2f)
		{
			float t = elapsed / (time / 2f);
			float x = Mathf.Lerp(fromAngle, toAngle, t);
			rotatingGo.transform.localRotation = Quaternion.Euler(x, 0f, 0f);
			elapsed += Time.unscaledDeltaTime;
			yield return null;
		}
		rotatingGo.transform.localRotation = Quaternion.Euler(toAngle, 0f, 0f);
	}

	private void IncrementValueIndex()
	{
		valueIndexCurrent = (valueIndexCurrent + 1) % DECIMAL_VALUES.Length;
	}

	private void DecrementValueIndex()
	{
		valueIndexCurrent = (valueIndexCurrent + DECIMAL_VALUES.Length - 1) % DECIMAL_VALUES.Length;
	}

	private void SetTextsColor(Color color)
	{
		TextMeshProUGUI[] array = texts;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = color;
		}
	}

	public void StopRotating()
	{
		if (rotationCoroutine != null)
		{
			StopCoroutine(rotationCoroutine);
			rotationCoroutine = null;
		}
		IsRotating = false;
	}
}
