using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Flotsam/Composited Flotsam Properties")]
public class CompositedFlotsamProperties : FlotsamProperties
{
	[Header("Description")]
	[Tooltip("Localized name of the flotsam to display in-game.")]
	public LocalizedString LocalizedName = "";

	[Tooltip("Localized description of the flotsam to display in-game.")]
	public LocalizedString LocalizedDescription = "";

	[Header("Items")]
	[SerializeField]
	[Tooltip("Items that make up the composition of this flotsam.")]
	private CountedItemProperty[] _composition;

	public CountedItemProperty[] Composition => _composition;

	public float ReturnCompositionMatch(List<CountedItemProperty> countedItems)
	{
		int num = 0;
		int num2 = 0;
		CountedItemProperty[] composition = Composition;
		foreach (CountedItemProperty countedItemProperty in composition)
		{
			num += countedItemProperty.Amount;
			foreach (CountedItemProperty countedItem in countedItems)
			{
				if (countedItemProperty.ItemProperties == countedItem.ItemProperties)
				{
					num2 = ((countedItem.Amount >= countedItemProperty.Amount) ? (num2 + countedItemProperty.Amount) : (num2 + countedItem.Amount));
				}
			}
		}
		return (num > 0) ? (num2 / num) : 0;
	}

	public bool Contains(FlotsamProperties properties)
	{
		CountedItemProperty[] composition = _composition;
		for (int i = 0; i < composition.Length; i++)
		{
			if (composition[i].ItemProperties.FlotsamProperties == properties)
			{
				return true;
			}
		}
		return false;
	}
}
