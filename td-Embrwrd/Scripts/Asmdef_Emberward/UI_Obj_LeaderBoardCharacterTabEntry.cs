using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_LeaderBoardCharacterTabEntry : MonoBehaviour
{
	[SerializeField]
	private Image image_BG;

	[SerializeField]
	private Image image_CharacterIcon;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image_Selected;

	[SerializeField]
	private Image image_BlackTint;

	private Action<eCharacterType> onClickCallback;

	private eCharacterType characterType;

	public Button Button => null;

	public eCharacterType CharacterType => default(eCharacterType);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(eCharacterType characterType, Action<eCharacterType> onClickCallback)
	{
	}

	public void SetClickable(bool isClickable)
	{
	}

	private void OnButtonClick()
	{
	}

	public void ToggleSelected(bool isSelected)
	{
	}
}
