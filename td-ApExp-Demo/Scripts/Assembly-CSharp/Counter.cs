using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
	private Digit[] digits;

	[SerializeField]
	private CounterTypes counterType;

	private float timePerRotation = 0.2f;

	private int currentTargetValue;

	private int pendingTargetValue;

	private bool isRotating;

	private Coroutine rotationCoroutine;

	private bool isScrambled;

	public int TargetValue { get; protected set; }

	private void Awake()
	{
		digits = GetComponentsInChildren<Digit>();
		currentTargetValue = GetCurrentValue();
		pendingTargetValue = currentTargetValue;
		EnemyManager.Instance.OnScramble += delegate
		{
			Scramble();
		};
	}

	private void Update()
	{
		if ((!isScrambled || counterType == CounterTypes.Cores) && TargetValue != pendingTargetValue)
		{
			pendingTargetValue = TargetValue;
			if (!isRotating)
			{
				rotationCoroutine = StartCoroutine(RotateDigitsToTarget(pendingTargetValue));
			}
		}
	}

	public void Randomize()
	{
		for (int i = 0; i < digits.Length; i++)
		{
			digits[i].StartRotationTo(Random.Range(0, 10), Random.Range(0.1f, 1f), Random.Range(0, 2) > 0);
		}
	}

	public void SetTargetValue(float newTarget)
	{
		TargetValue = (pendingTargetValue = Mathf.FloorToInt(newTarget));
		if (rotationCoroutine != null)
		{
			StopCoroutine(rotationCoroutine);
			rotationCoroutine = null;
		}
		isRotating = false;
		rotationCoroutine = StartCoroutine(RotateDigitsToTarget(pendingTargetValue, force: true));
	}

	private int GetCurrentValue()
	{
		int num = 0;
		int num2 = 1;
		for (int num3 = digits.Length - 1; num3 >= 0; num3--)
		{
			num += digits[num3].CurrentDigitValue * num2;
			num2 *= 10;
		}
		return num;
	}

	private IEnumerator RotateDigitsToTarget(int targetValue, bool force = false)
	{
		isRotating = true;
		bool isOverallIncrement = targetValue > currentTargetValue;
		currentTargetValue = targetValue;
		string text = targetValue.ToString().PadLeft(digits.Length, '0');
		for (int i = 0; i < digits.Length; i++)
		{
			int targetValue2 = int.Parse(text[i].ToString());
			digits[i].StartRotationTo(targetValue2, timePerRotation, isOverallIncrement, force);
		}
		yield return new WaitUntil(() => !IsAnyDigitRotating());
		isRotating = false;
		if (pendingTargetValue != currentTargetValue)
		{
			rotationCoroutine = StartCoroutine(RotateDigitsToTarget(pendingTargetValue));
		}
	}

	private bool IsAnyDigitRotating()
	{
		Digit[] array = digits;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsRotating)
			{
				return true;
			}
		}
		return false;
	}

	private void Scramble()
	{
		isScrambled = true;
		if (rotationCoroutine != null)
		{
			StopCoroutine(rotationCoroutine);
			rotationCoroutine = null;
		}
		isRotating = false;
		Digit[] array = digits;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].StopRotating();
		}
	}

	public void Unscramble(float value)
	{
		isScrambled = false;
		if (counterType != CounterTypes.Cores)
		{
			StartCoroutine(UnscrambleCoroutine());
		}
	}

	private IEnumerator UnscrambleCoroutine()
	{
		yield return new WaitForSecondsRealtime(1f);
		SetTargetValue(pendingTargetValue);
	}
}
