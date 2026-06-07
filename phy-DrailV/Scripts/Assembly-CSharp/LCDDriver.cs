using System.Collections.Generic;
using UnityEngine;

public class LCDDriver : MonoBehaviour
{
	public string displayedString = "";

	public GameObject digitModelPrefab;

	public int numDigits = 17;

	public float spacing = -1.4f;

	private LCDDigit[] digits = new LCDDigit[0];

	[InspectorButton("SetupDigits", true, true)]
	public bool setupDigits;

	[InspectorButton("InspectorDisplay", true, true)]
	public bool display;

	[InspectorButton("Clear", true, true)]
	public bool clear;

	private void Awake()
	{
		SetupDigits();
	}

	private void SetupDigits()
	{
		DeleteDigits();
		List<LCDDigit> list = new List<LCDDigit>();
		for (int i = 0; i < numDigits; i++)
		{
			GameObject gameObject = Object.Instantiate(digitModelPrefab, base.transform);
			gameObject.name = "Digit " + i;
			gameObject.transform.localPosition = new Vector3(spacing * (float)i, 0f, 0f);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			LCDDigit lCDDigit = gameObject.AddComponent<LCDDigit>();
			if (lCDDigit == null)
			{
				lCDDigit = gameObject.AddComponent<LCDDigit>();
			}
			list.Add(lCDDigit);
		}
		digits = list.ToArray();
	}

	private void DeleteDigits()
	{
		LCDDigit[] componentsInChildren = GetComponentsInChildren<LCDDigit>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Object.Destroy(componentsInChildren[i].gameObject);
		}
	}

	private void InspectorDisplay()
	{
		Display(displayedString);
	}

	public void Display(string s)
	{
		string text = s.Replace(".", "").Replace(":", "");
		int num = s.Length - text.Length;
		s = s.ToUpper().PadRight(Mathf.Max(numDigits, s.Length + num), ' ');
		int num2 = 0;
		for (int i = 0; i < digits.Length; i++)
		{
			if (num2 >= s.Length)
			{
				break;
			}
			if (s[num2] == '.' || s[num2] == ':')
			{
				i--;
				digits[i].displayDot = s[num2] == '.';
				digits[i].displayColon = s[num2] == ':';
			}
			else
			{
				digits[i].displayDot = (digits[i].displayColon = false);
				digits[i].displayedChar = s[num2];
			}
			num2++;
		}
	}

	public void Clear()
	{
		LCDDigit[] array = digits;
		foreach (LCDDigit obj in array)
		{
			obj.displayedChar = ' ';
			obj.displayDot = (obj.displayColon = false);
		}
	}
}
