using System.Collections.Generic;
using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_StationStocksVisualManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_StationStocksVisualManager()
			: base(typeof(StationStocksVisualManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			StationStocksVisualManager objectContainingField = (StationStocksVisualManager)obj;
			writer.WritePrivateField("_stationStocks", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			StationStocksVisualManager objectContainingField = (StationStocksVisualManager)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_stationStocks")
				{
					reader.SetPrivateField("_stationStocks", reader.Read<HashSet<StationStock>>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
