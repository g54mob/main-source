using OUSystems.Basics.DataStructures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageStackUI : MonoBehaviour
{
	[SerializeField]
	private Image _itemIcon;

	[SerializeField]
	private TextMeshProUGUI _countText;

	[SerializeField]
	private TextMeshProUGUI _capacityText;

	public ItemStack ItemStack;

	public int Capacity;

	[SerializeField]
	private ItemStackAnimator animator;

	[SerializeField]
	private ItemTooltipTrigger _tooltipTrigger;

	public bool HideOnEmpty;

	public void Set(ItemStack itemStack)
	{
	}

	private void OnDestroy()
	{
	}

	public void Clear()
	{
	}

	public void SetCapacity(int capacity)
	{
	}

	public void OnChange(ValueUpdateData<int> update)
	{
	}

	public void UpdateCount()
	{
	}
}
