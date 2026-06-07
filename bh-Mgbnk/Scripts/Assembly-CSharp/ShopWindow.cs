using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
	public GameObject shopContainerPrefab;

	public Transform contentParent;

	public TabGridNavigation navigation;

	public Button btnBack;

	public ShopFooter shopFooter;

	public MyButtonNormal btnBuy;

	public MyButtonNormal btnRefund;

	public TextMeshProUGUI t_buy;

	public TextMeshProUGUI t_refund;

	private List<ShopContainer> shopContainers;

	public static Action<ShopContainer> A_LevelChanged;

	public ShopContainer currentContainer { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void Buy()
	{
	}

	public void Refund()
	{
	}

	private void RefreshPrices()
	{
	}

	private void OnShopClicked(ShopContainer shopContainerClicked)
	{
	}

	public void OnShopSelect(ShopContainer shopContainerClicked)
	{
	}
}
