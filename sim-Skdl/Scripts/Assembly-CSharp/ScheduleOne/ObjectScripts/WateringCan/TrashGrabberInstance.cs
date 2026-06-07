using System;
using System.Collections.Generic;
using FishNet.Serializing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using ScheduleOne.Trash;

namespace ScheduleOne.ObjectScripts.WateringCan
{
	[Serializable]
	public class TrashGrabberInstance : StorableItemInstance
	{
		public const int TRASH_CAPACITY = 20;

		private TrashContent Content;

		public TrashGrabberInstance(ItemDefinition definition, int quantity)
			: base(null, 0)
		{
		}

		public override ItemInstance GetCopy(int overrideQuantity = -1)
		{
			return null;
		}

		public void LoadContentData(TrashContentData content)
		{
		}

		public override ItemData GetItemData()
		{
			return null;
		}

		public void AddTrash(string id, int quantity)
		{
		}

		public void RemoveTrash(string id, int quantity)
		{
		}

		public void ClearTrash()
		{
		}

		public int GetTotalSize()
		{
			return 0;
		}

		public List<string> GetTrashIDs()
		{
			return null;
		}

		public List<int> GetTrashQuantities()
		{
			return null;
		}

		public List<ushort> GetTrashUshortQuantities()
		{
			return null;
		}

		public override void Write(Writer writer)
		{
		}

		public override void Read(Reader reader)
		{
		}
	}
}
