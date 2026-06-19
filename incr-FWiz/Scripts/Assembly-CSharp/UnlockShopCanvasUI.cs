using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

public class UnlockShopCanvasUI : MonoBehaviour
{
	[SerializeField]
	private UnlockShopUIItem _shopUIItemPrefab;

	[SerializeField]
	private UnlockShopUILockedItem _shopUILockedItemPrefab;

	[SerializeField]
	private ClickListener _clearButtonPrefab;

	[SerializeField]
	private Transform _shopListParent;

	private ClickListener _clearButton;

	private List<AbstractUnlockShopUIItem> _shopUIItems;

	[SerializeField]
	private OnPressOutsideListener _pressOutsideListener;

	public EventReference OpenSound;

	public EventReference CloseSound;

	[SerializeField]
	private GameObject _noBuildingsMessage;

	public bool Shown { get; private set; }

	public event Action AnnounceEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<ShopItem> AnnounceSelection
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Show(List<ShopItem> shopItems, ShopItem currentSelection)
	{
	}

	private void Hide()
	{
	}

	public void Clear()
	{
	}

	public void Select(ShopItem buildingAsset)
	{
	}

	public void ClearSelection()
	{
	}

	public void End()
	{
	}
}
