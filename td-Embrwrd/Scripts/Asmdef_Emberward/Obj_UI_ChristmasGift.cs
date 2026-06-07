using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_ChristmasGift : MonoBehaviour
{
	[Serializable]
	private class GiftPack
	{
		[SerializeField]
		private GameObject node_Gift;

		[SerializeField]
		private List<Image> list_Gifts;

		public void ToggleGifts(bool isOn)
		{
		}

		public void TriggerGiftAnimation()
		{
		}

		public void RandomizeGiftSprites(List<Sprite> giftSprites)
		{
		}
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private Image image_CharBG;

	[SerializeField]
	private Image image_CharIcon;

	[SerializeField]
	private Image image_BoardColor;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private List<GiftPack> list_GiftPacks;

	[SerializeField]
	private List<Sprite> list_GiftSprites;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_SelectEffect;

	private eCharacterType characterType;

	private Action<eCharacterType> onClickCallback;

	private int index;

	private bool isClicked;

	public Button Button => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void ToggleSelectedEffect(bool isOn)
	{
	}

	public void Setup(int index, eCharacterType characterType, Action<eCharacterType> onClick)
	{
	}

	public void Toggle(bool isOn)
	{
	}

	private void OnClickButton()
	{
	}
}
