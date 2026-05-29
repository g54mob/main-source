using UnityEngine;
using UnityEngine.UI;

public class ShopContainer : MonoBehaviour
{
	public RawImage icon;

	public Transform levelsParent;

	public GameObject backgroundLocked;

	public GameObject backgroundUnlocked;

	public GameObject alert;

	public ShopItemData data { get; private set; }

	private void Awake()
	{
	}

	private void OnButtonSelect(ShopContainer shopBtn)
	{
	}

	private void OnDestroy()
	{
	}

	public void Set(ShopItemData shopItemData)
	{
	}

	private void Update()
	{
	}

	private void RefreshLevel(bool isUnlocked)
	{
	}

	private void OnShopItemLevelChanged(ShopContainer shopContainer)
	{
	}
}
