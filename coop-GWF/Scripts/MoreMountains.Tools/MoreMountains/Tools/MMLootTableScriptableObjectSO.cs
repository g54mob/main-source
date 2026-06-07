using UnityEngine;

namespace MoreMountains.Tools
{
	[CreateAssetMenu(fileName = "ScriptableObjectLootDefinition", menuName = "MoreMountains/ScriptableObject Loot Definition")]
	public class MMLootTableScriptableObjectSO : ScriptableObject
	{
		public MMLootTableScriptableObject LootTable;

		public virtual ScriptableObject GetLoot()
		{
			return LootTable.GetLoot()?.Loot;
		}

		public virtual void ComputeWeights()
		{
			LootTable.ComputeWeights();
		}

		protected virtual void OnValidate()
		{
			ComputeWeights();
		}
	}
}
