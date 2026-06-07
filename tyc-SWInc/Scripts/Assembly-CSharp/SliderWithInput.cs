using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithInput : MonoBehaviour
{
	public InputField Input;

	public Slider Slider;

	public int Wait;

	[NonSerialized]
	private bool _disableEdit;

	public void ShowInput()
	{
		_disableEdit = true;
		Input.gameObject.SetActive(true);
		Input.text = Slider.value.ToString();
		Input.ActivateInputField();
		_disableEdit = false;
		Wait = 2;
	}

	private void Update()
	{
		if (Wait > 0)
		{
			Wait--;
		}
		else if (Input.gameObject.activeSelf && !Input.isFocused)
		{
			Input.gameObject.SetActive(false);
		}
	}

	public void OnEndEdit()
	{
		if (!_disableEdit)
		{
			Slider.value = Input.text.ConvertToFloatDef(Slider.value);
		}
	}
}
