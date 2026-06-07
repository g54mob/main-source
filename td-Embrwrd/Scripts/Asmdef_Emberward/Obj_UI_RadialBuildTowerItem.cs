using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_RadialBuildTowerItem : MonoBehaviour
{
	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private Transform node_Icon;

	[SerializeField]
	private Image image_BG_Front;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_Banned;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private GameObject node_BuildLimit;

	[SerializeField]
	private TMP_Text text_BuildLimit;

	[SerializeField]
	private Image image_NotUseableTint;

	[SerializeField]
	private Image image_SelectedTint;

	[SerializeField]
	private Image image_SelectedTint_Red;

	private int index;

	private eItemType towerType;

	private bool isHaveData;

	private bool isBanned;

	private bool isHaveEnoughCoin;

	private bool isReachBuildLimit;

	private bool isAvailable;

	public eItemType TowerType => default(eItemType);

	public void Setup(eItemType towerType, int index)
	{
	}

	public void UpdateContent()
	{
	}

	public void SetSelected(bool isSelected, Transform tooltipAnchor = null)
	{
	}

	public void SetBanned(bool isBanned)
	{
	}

	public void SetAvailable(bool isAvailable)
	{
	}

	public void SetNoData()
	{
	}

	public void InitiateTowerPlacement()
	{
	}
}
