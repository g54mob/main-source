using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_currentLevel", "_haemas", "CurrentMoney" })]
	public class ES3UserType_MoneyHandler : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MoneyHandler()
			: base(typeof(MoneyHandler))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MoneyHandler moneyHandler = (MoneyHandler)obj;
			writer.WritePrivateField("_currentLevel", moneyHandler);
			writer.WritePrivateField("_haemas", moneyHandler);
			writer.WritePrivateProperty("CurrentMoney", moneyHandler);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MoneyHandler moneyHandler = (MoneyHandler)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_currentLevel":
					moneyHandler = (MoneyHandler)reader.SetPrivateField("_currentLevel", reader.Read<int>(), moneyHandler);
					break;
				case "_haemas":
					moneyHandler = (MoneyHandler)reader.SetPrivateField("_haemas", reader.Read<int>(), moneyHandler);
					break;
				case "CurrentMoney":
					moneyHandler = (MoneyHandler)reader.SetPrivateProperty("CurrentMoney", reader.Read<int>(), moneyHandler);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
