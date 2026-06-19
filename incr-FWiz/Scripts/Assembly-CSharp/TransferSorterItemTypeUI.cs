using OUSystems.Basics.DataStructures;
using UnityEngine;
using UnityEngine.UI;

public class TransferSorterItemTypeUI : MonoBehaviour
{
	private ItemStack _filterItemStack;

	[SerializeField]
	private Image _itemIcon;

	public void Set(ItemStack filterItemStack)
	{
	}

	private void OnDestroy()
	{
	}

	public void Clear()
	{
	}

	public void OnChange(ValueUpdateData<int> update)
	{
	}

	public void UpdateGraphic()
	{
	}
}
