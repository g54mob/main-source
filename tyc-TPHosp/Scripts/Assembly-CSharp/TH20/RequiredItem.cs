using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RequiredItem
	{
		public string GroupName;

		public SharedInstance<RoomItemDefinition>[] Items;

		public bool Contains(IRoomItemDefinition definition)
		{
			SharedInstance<RoomItemDefinition>[] items = Items;
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].Instance == definition)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsType(RoomItemDefinition.Type type)
		{
			SharedInstance<RoomItemDefinition>[] items = Items;
			for (int i = 0; i < items.Length; i++)
			{
				if (items[i].Instance.ItemType == type)
				{
					return true;
				}
			}
			return false;
		}

		public List<RoomItemDefinition> GetValidItems(WorldState worldState)
		{
			List<RoomItemDefinition> list = new List<RoomItemDefinition>();
			SharedInstance<RoomItemDefinition>[] items = Items;
			foreach (SharedInstance<RoomItemDefinition> sharedInstance in items)
			{
				if (worldState.AvailableRoomItems.Contains(sharedInstance.Instance))
				{
					list.Add(sharedInstance.Instance);
				}
			}
			return list;
		}
	}
}
