using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "ItemData", "CurrentCount", "RequiredCount" })]
	public class ES3UserType_MissionItemCapacity : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_MissionItemCapacity()
			: base(typeof(MissionBasket.MissionItemCapacity))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			MissionBasket.MissionItemCapacity missionItemCapacity = (MissionBasket.MissionItemCapacity)obj;
			writer.WriteProperty("Items", missionItemCapacity.ItemStack);
			writer.WriteProperty("RequiredCount", missionItemCapacity.RequiredCount, ES3Type_int.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			MissionBasket.MissionItemCapacity missionItemCapacity = default(MissionBasket.MissionItemCapacity);
			StockStack itemStack = default(StockStack);
			while (true)
			{
				switch (reader.ReadPropertyName())
				{
				case "Items":
					itemStack = reader.Read<StockStack>();
					break;
				case "ItemData":
					itemStack = new StockStack(reader.ReadAssetReference<StockItemSO>(), itemStack.StackCount, 1f);
					break;
				case "CurrentCount":
					itemStack = new StockStack(itemStack.ItemData, reader.Read<int>(ES3Type_int.Instance), 1f);
					break;
				case "RequiredCount":
					missionItemCapacity.RequiredCount = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				case null:
					missionItemCapacity.ItemStack = itemStack;
					return missionItemCapacity;
				}
			}
		}
	}
}
