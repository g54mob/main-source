using JetBrains.Annotations;
using UnityEngine;

namespace Restory.Data.Microstories
{
	[CreateAssetMenu(menuName = "Restory/NPC Visits and Work Orders/NpcCustomizationGroupsList", fileName = "NPC Customization Groups")]
	public class NpcCustomizationGroupsList : ScriptableObject
	{
		[SerializeField]
		private NpcCustomizationOptionsGroup[] customizationGroups = new NpcCustomizationOptionsGroup[0];

		public NpcCustomizationOptionsGroup[] CustomizationGroups => customizationGroups;

		[UsedImplicitly]
		private bool CheckOverlappingFlags()
		{
			NpcCustomizationOptionsGroup[] array = customizationGroups;
			foreach (NpcCustomizationOptionsGroup npcCustomizationOptionsGroup in array)
			{
				NpcCustomizationOptionsGroup[] array2 = customizationGroups;
				foreach (NpcCustomizationOptionsGroup npcCustomizationOptionsGroup2 in array2)
				{
					if (npcCustomizationOptionsGroup != npcCustomizationOptionsGroup2 && (npcCustomizationOptionsGroup.AllOptionsInGroup & npcCustomizationOptionsGroup2.AllOptionsInGroup) != NpcCustomizationOptions.None)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
