using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_EmberRecoverItem : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image_DisableOverlay;

	[SerializeField]
	private Image image_SelectedBorder;

	[SerializeField]
	private UI_EmberRecover_Popup.eEmberRecoverItemType emberRecoverItemType;

	[SerializeField]
	private TMP_Text text_ItemName;

	[SerializeField]
	private TMP_Text text_ItemDescription;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private Transform node_Cost;

	private int cost;

	private Action<UI_EmberRecover_Popup.eEmberRecoverItemType> onClickCallback;

	public Button Button => null;

	public UI_EmberRecover_Popup.eEmberRecoverItemType EmberRecoverItemType => default(UI_EmberRecover_Popup.eEmberRecoverItemType);

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

	private void OnGemChanged(int value)
	{
	}

	public void Setup(int cost, Action<UI_EmberRecover_Popup.eEmberRecoverItemType> callback)
	{
	}

	public void ToggleBuyAble(bool isBuyAble)
	{
	}

	private void UpdateCostText(int cost)
	{
	}

	private void OnClickButton()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void TriggerPurchaseAnim()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
