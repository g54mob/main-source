using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private const float m_SlideTime = 0.1f;

	public bool isOn;

	public Action<bool> onValueChanged;

	[SerializeField]
	private Slider m_toggleSlider;

	[SerializeField]
	private Button m_handle;

	[SerializeField]
	private Color m_OnColor;

	[SerializeField]
	private Color m_OffColor;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnClick()
	{
	}

	public void SwitchSlider(bool _isOn)
	{
	}

	public void SetSlider(bool _isOn)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
