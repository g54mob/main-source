using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_UpgradeTowerButton_V3 : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Image image_Background;

	[SerializeField]
	private Image image_DemoDarkTint;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private GameObject node_Cost;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Sprite sprite_BG_UpgradeA;

	[SerializeField]
	private Sprite sprite_BG_UpgradeB;

	[SerializeField]
	private GameObject node_ConnectLine;

	[SerializeField]
	private GameObject node_ConnectLine_Upgraded;

	private ABaseTower.eUpgradeType upgradeType;

	public Action<ABaseTower.eUpgradeType> OnClickButton;

	public Action<ABaseTower.eUpgradeType> OnMouseEnter;

	public Action<ABaseTower.eUpgradeType> OnMouseExit;

	private Color text_UpgradeCostNormalColor;

	public ABaseTower.eUpgradeType UpgradeType => default(ABaseTower.eUpgradeType);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClick()
	{
	}

	public void ResetAnimation()
	{
	}

	public void Toggle(bool isOn, bool isImmediate)
	{
	}

	public void ToggleShowPrice(bool isShow)
	{
	}

	public void SetupContent(ABaseTower.eUpgradeType upgradeType, string description, int cost)
	{
	}

	public void PlayShakeAnimation()
	{
	}

	public bool SetBuyable(bool isBuyable)
	{
		return false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetIsUpgraded(bool isUpgraded)
	{
	}
}
