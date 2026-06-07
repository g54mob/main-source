using System;
using FishNet.Serializing;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.ItemFramework
{
	[Serializable]
	public abstract class ItemInstance : BaseItemInstance
	{
		public ItemDefinition Definition => null;

		public virtual Equippable Equippable => null;

		public ItemInstance(ItemDefinition definition, int quantity)
			: base(null, 0)
		{
		}

		public virtual bool CanStackWith(ItemInstance other, bool checkQuantities = true)
		{
			return false;
		}

		public abstract ItemInstance GetCopy(int overrideQuantity = -1);

		public virtual ItemData GetItemData()
		{
			return null;
		}

		public virtual void Write(Writer writer)
		{
		}

		public virtual void Read(Reader reader)
		{
		}

		public static ItemInstance CreateInstanceAndRead(Reader reader)
		{
			return null;
		}
	}
}
