using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "StackCount", "ItemData", "Quality" })]
	public class ES3UserType_StockStack : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_StockStack()
			: base(typeof(StockStack))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			StockStack stockStack = (StockStack)obj;
			writer.WritePrivateProperty("StackCount", stockStack);
			writer.WriteAssetReference("ItemData", stockStack.ItemData);
			writer.WritePrivateProperty("Quality", stockStack);
		}

		public override object Read<T>(ES3Reader reader)
		{
			StockStack stockStack = default(StockStack);
			while (true)
			{
				switch (reader.ReadPropertyName())
				{
				case "StackCount":
					stockStack = (StockStack)reader.SetPrivateProperty("StackCount", reader.Read<int>(), stockStack);
					break;
				case "ItemData":
					stockStack = (StockStack)reader.SetPrivateProperty("ItemData", reader.ReadAssetReference<StockItemSO>(), stockStack);
					break;
				case "Quality":
					stockStack = (StockStack)reader.SetPrivateProperty("Quality", reader.Read<float>(), stockStack);
					break;
				default:
					reader.Skip();
					break;
				case null:
					return stockStack;
				}
			}
		}
	}
}
