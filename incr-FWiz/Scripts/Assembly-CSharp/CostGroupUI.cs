using System.Collections.Generic;
using UnityEngine;

public class CostGroupUI : MonoBehaviour
{
	[SerializeField]
	private ItemStackUI _uiCostGridItem;

	[SerializeField]
	private Transform _uiCostGridParent;

	private List<ItemStackUI> _uiCostStacks;

	public void Initiate(List<CostStack> costStacks)
	{
	}

	public void Clear()
	{
	}
}
