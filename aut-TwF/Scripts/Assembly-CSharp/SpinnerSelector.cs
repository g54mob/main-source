using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerSelector : MonoBehaviour
{
	[SerializeField]
	private Button leftArrowButton;

	[SerializeField]
	private Button rightArrowButton;

	[SerializeField]
	private TextMeshProUGUI valueText;

	[SerializeField]
	private string[] options;

	private int currentSelectedIndex;

	public event Action<int> onValueChanged;

	private void Reset()
	{
		Button[] componentsInChildren = GetComponentsInChildren<Button>();
		if (leftArrowButton == null && componentsInChildren.Length != 0)
		{
			leftArrowButton = componentsInChildren[0];
		}
		if (rightArrowButton == null && componentsInChildren.Length > 1)
		{
			rightArrowButton = componentsInChildren[1];
		}
		options = new string[3] { "Option A", "Option B", "Option C" };
		if (valueText == null)
		{
			valueText = GetComponentInChildren<TextMeshProUGUI>();
			if (valueText != null)
			{
				valueText.text = options[0];
			}
		}
	}

	private void Awake()
	{
		BindEvents();
		SetValue(0);
	}

	private void BindEvents()
	{
		leftArrowButton?.onClick.AddListener(delegate
		{
			OnButtonPressed(left: true);
		});
		rightArrowButton?.onClick.AddListener(delegate
		{
			OnButtonPressed(left: false);
		});
	}

	public void SetOptions(ICollection newOptions)
	{
		options = new string[newOptions.Count];
		newOptions.CopyTo(options, 0);
	}

	public void SetValue(int valueIndex)
	{
		currentSelectedIndex = Mathf.Clamp(valueIndex, 0, options.Length - 1);
		if (options.Length != 0)
		{
			valueText.text = options[currentSelectedIndex];
		}
		this.onValueChanged?.Invoke(currentSelectedIndex);
	}

	public int GetValue()
	{
		return currentSelectedIndex;
	}

	public void ShowArrows(bool show)
	{
		leftArrowButton?.gameObject.SetActive(show);
		rightArrowButton?.gameObject.SetActive(show);
	}

	private void OnButtonPressed(bool left)
	{
		if (left)
		{
			SetValue((int)Mathf.Repeat(currentSelectedIndex - 1, options.Length));
		}
		else
		{
			SetValue((int)Mathf.Repeat(currentSelectedIndex + 1, options.Length));
		}
	}
}
