using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_QuestBoard : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Image image_Frame_Selected;

	[SerializeField]
	private Button button;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Image image_Reward_Gem;

	[SerializeField]
	private Image image_Reward_Exp;

	[SerializeField]
	private Image image_Reward_Reroll;

	[SerializeField]
	private TMP_Text text_Reward_Value;

	[SerializeField]
	private UI_Obj_ShopCard rewardItemCard;

	private int index;

	private Action<int> OnClickCallback;

	private QuestData questData;

	public Button Button => null;

	public void Setup(int index, QuestData questData, Action<int> OnClickCallback)
	{
	}

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

	private void OnClickButton()
	{
	}

	public void PlaySelectedAnim()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
