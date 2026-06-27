using System;
using UnityEngine;

namespace Restory.Data.Elements.Condition
{
	[CreateAssetMenu(menuName = "Restory/Elements/Condition/ElementConditionsMaterialsTable", fileName = "ElementConditionsMaterialsTable")]
	public class ElementConditionsMaterialsTable : ScriptableObject
	{
		[Serializable]
		private struct InnerEntry
		{
			public ElementConditionBase Condition;

			public Material Material;
		}

		[Serializable]
		private class OuterEntry
		{
			public InnerEntry[] Entries = new InnerEntry[0];
		}

		[SerializeField]
		private OuterEntry[] entries = new OuterEntry[0];

		public bool TryGetCorrespondingMaterial(Material materialToCheck, ElementConditionBase elementCondition, out Material foundMaterial)
		{
			OuterEntry outerEntry = null;
			OuterEntry[] array = entries;
			foreach (OuterEntry outerEntry2 in array)
			{
				InnerEntry[] array2 = outerEntry2.Entries;
				for (int j = 0; j < array2.Length; j++)
				{
					InnerEntry innerEntry = array2[j];
					if (innerEntry.Material == materialToCheck)
					{
						if (innerEntry.Condition == elementCondition)
						{
							foundMaterial = innerEntry.Material;
							return true;
						}
						outerEntry = outerEntry2;
						break;
					}
				}
				if (outerEntry == null)
				{
					continue;
				}
				array2 = outerEntry.Entries;
				for (int j = 0; j < array2.Length; j++)
				{
					InnerEntry innerEntry2 = array2[j];
					if (innerEntry2.Condition == elementCondition)
					{
						foundMaterial = innerEntry2.Material;
						return true;
					}
				}
				break;
			}
			foundMaterial = null;
			return false;
		}
	}
}
