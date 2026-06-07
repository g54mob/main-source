using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_RouletteItem : MonoBehaviour
{
	[SerializeField]
	private Transform node_Items;

	[SerializeField]
	private Transform node_Miss;

	[SerializeField]
	private TMP_Text text_ItemName;

	[SerializeField]
	private TMP_Text text_Miss;

	[SerializeField]
	private Image image_Icon_Tower;

	[SerializeField]
	private Image image_Icon_Relic;

	[SerializeField]
	private Image image_Icon_Reroll;

	[SerializeField]
	private Image image_Icon_Miss;

	private UI_Circus_Popup.eCircusRewardType currentRewardType;

	public void Setup(UI_Circus_Popup.eCircusRewardType rewardType)
	{
	}

	private string GetItemName(UI_Circus_Popup.eCircusRewardType rewardType)
	{
		return null;
	}

	public Image GetIcon()
	{
		return null;
	}
}
