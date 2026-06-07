using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_JournalEntry : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_BGImage;

	[SerializeField]
	private Image image_Border;

	[SerializeField]
	private Image image_Selected;

	[SerializeField]
	private TMP_Text text_Name;

	[SerializeField]
	private Button button;

	private eMonsterType monsterType;

	private eTutorialType tutorialType;

	private Action<eMonsterType> onMonsterClickCallback;

	private Action<eTutorialType> onTutorialClickCallback;

	public Button Button => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClickButton()
	{
	}

	public void ToggleSelected(bool isSelected)
	{
	}

	public void Setup(eMonsterType type, Sprite icon, Sprite bgImage, string name, Action<eMonsterType> onClick)
	{
	}

	public void Setup(eTutorialType type, Sprite icon, Sprite bgImage, string name, Action<eTutorialType> onClick)
	{
	}

	public void SetBorderColor(Color color)
	{
	}

	public eMonsterType GetMonsterType()
	{
		return default(eMonsterType);
	}

	public eTutorialType GetTutorialType()
	{
		return default(eTutorialType);
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}
}
