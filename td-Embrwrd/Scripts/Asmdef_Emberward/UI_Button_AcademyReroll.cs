using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button_AcademyReroll : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image_Icon_Normal;

	[SerializeField]
	private Image image_Icon_Disabled;

	[SerializeField]
	private TMP_Text text_ButtonText;

	[SerializeField]
	private TMP_Text text_RerollCount;

	public Action OnRerollButtonClicked;

	private bool isInfiniteReroll;

	public Button Button => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(int rerollCount)
	{
	}

	private void OnAcademyRerollCountChanged(int count)
	{
	}

	private void UpdateButton(int value)
	{
	}

	private void UpdateText(int value)
	{
	}

	public void SwitchButtonText_RerollAll()
	{
	}

	public void SwitchButtonText_RerollRelic()
	{
	}

	private void OnClickButton()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
