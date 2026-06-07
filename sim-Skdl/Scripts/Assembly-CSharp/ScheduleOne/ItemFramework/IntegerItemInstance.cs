using FishNet.Serializing;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;

namespace ScheduleOne.ItemFramework
{
	public class IntegerItemInstance : StorableItemInstance
	{
		public int Value;

		public IntegerItemInstance(ItemDefinition definition, int quantity, int value)
			: base(null, 0)
		{
		}

		public override ItemInstance GetCopy(int overrideQuantity = -1)
		{
			return null;
		}

		public void ChangeValue(int change)
		{
		}

		public void SetValue(int value)
		{
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
