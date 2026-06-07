using System;
using FishNet.Serializing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;

namespace ScheduleOne.Clothing
{
	[Serializable]
	public class ClothingInstance : StorableItemInstance
	{
		public EClothingColor Color;

		public override string Name => null;

		public ClothingInstance(ItemDefinition definition, int quantity, EClothingColor color)
			: base(null, 0)
		{
		}

		public override ItemInstance GetCopy(int overrideQuantity = -1)
		{
			return null;
		}

		public override ItemData GetItemData()
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
