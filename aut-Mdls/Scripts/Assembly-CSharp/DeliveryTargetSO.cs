using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Create Delivery Target")]
public class DeliveryTargetSO : ScriptableObject
{
	[SerializeField]
	private List<ObjectiveTargetCategorySO> _categories;

	public IReadOnlyList<ObjectiveTargetCategorySO> Categories => _categories;

	[Button("Generate All Targets Data", EButtonEnableMode.Always)]
	public void GenerateAllTargetsData()
	{
		if (Categories == null)
		{
			return;
		}
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			if (category != null)
			{
				category.GenerateTargetsData();
			}
		}
	}

	[Button("Generate All Amount Start Offsets", EButtonEnableMode.Always)]
	public void GenerateAllStartOffsets()
	{
		if (Categories == null)
		{
			return;
		}
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			if (category != null)
			{
				category.GenerateAmountOffsets();
			}
		}
	}
}
