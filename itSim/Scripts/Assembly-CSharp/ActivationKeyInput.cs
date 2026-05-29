using TMPro;
using UnityEngine;

public class ActivationKeyInput : MonoBehaviour
{
	public TMP_InputField inputField;

	private bool isUpdating;

	private const int MaxRawLength = 16;

	private const string ActivationKeyPattern = "^\\d{4}-\\d{4}-\\d{4}-\\d{4}$";

	private void Start()
	{
	}

	private char ValidateChar(string text, int charIndex, char addedChar)
	{
		return '\0';
	}

	private void FormatInput(string value)
	{
	}

	private void ValidateInput(string value)
	{
	}
}
