using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Level Item Blacklist", order = 1115)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelItemBlacklist : BaseScriptableObject
	{
		public SharedInstance<RoomItemDefinition>[] BlacklistedItems;

		public bool ContainsRoomItem(IRoomItemDefinition item)
		{
			SharedInstance<RoomItemDefinition>[] blacklistedItems = BlacklistedItems;
			for (int i = 0; i < blacklistedItems.Length; i++)
			{
				if (blacklistedItems[i].Instance == item)
				{
					return true;
				}
			}
			return false;
		}
	}
}
