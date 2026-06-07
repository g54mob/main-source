using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_MonsterDetailNameCard : MonoBehaviour
{
	[SerializeField]
	private Image image_BG;

	[SerializeField]
	private Image image_SelectedBorder;

	[SerializeField]
	private Image image_MonsterSprite;

	[SerializeField]
	private TMP_Text text_Name;

	[SerializeField]
	private Button button;

	private eMonsterType monsterType;

	private Action<eMonsterType> OnClickCallback;

	public Button Button => null;

	public eMonsterType MonsterType => default(eMonsterType);

	private void OnEnable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClick()
	{
	}

	public void Setup(string name, Color bgColor, eMonsterType monsterType, Sprite monsterSprite)
	{
	}

	public void RegisterCallback(Action<eMonsterType> callback)
	{
	}

	public void SetSelected(bool isSelected)
	{
	}
}
