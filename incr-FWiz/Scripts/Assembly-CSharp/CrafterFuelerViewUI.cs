using System.Collections.Generic;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class CrafterFuelerViewUI : MonoBehaviour
{
	[SerializeField]
	private CrafterFuelerItemUI _fuelerItemUIPrefab;

	[SerializeField]
	private Transform _fuelerItemUIParent;

	private List<CrafterFuelerItemUI> _itemUIs;

	private CrafterFueler _fueler;

	[SerializeField]
	private GameObject _needFuelMessage;

	private CrafterFuelerItemUI _primary => null;

	public void Initiate(CrafterFueler fueler)
	{
	}

	private void Clear()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddFuelItem(ItemType item)
	{
	}

	public void OnSpendItem(ItemType itemType)
	{
	}

	private void OnEmptyValueChange(bool empty)
	{
	}

	public void UpdateSpentAmount(ValueUpdateData<float> f)
	{
	}

	public void UpdateSpentAmount(float spent)
	{
	}
}
