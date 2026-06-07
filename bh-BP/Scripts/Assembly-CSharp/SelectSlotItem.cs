using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectSlotItem : MonoBehaviour
{
	public int SlotIdx;

	public RectTransform Xfm;

	public GameObject WrapperEmpty;

	public CoolButton BtnEmpty;

	public GameObject WrapperFull;

	public Image[] ImgProgress;

	public TextMeshProUGUI TxtSlotNum;

	public TextMeshProUGUI TxtLastPlayed;

	public TextMeshProUGUI TxtPlayTime;

	public CoolButton BtnFull;

	public CoolButton BtnDeleteSlot;

	private void Awake()
	{
	}

	public void FillData(int slot)
	{
	}

	public void KnitNav(SelectSlotItem prev)
	{
	}

	private void OnEmptyClicked()
	{
	}

	private void OnFullClicked()
	{
	}

	private void OnDeleteClicked()
	{
	}

	private void ConfirmDelete()
	{
	}

	private void OnSelected()
	{
	}
}
