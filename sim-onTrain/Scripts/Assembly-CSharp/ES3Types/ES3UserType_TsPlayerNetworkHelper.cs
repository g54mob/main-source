using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "steamID", "playerLastSelectedSlot" })]
	public class ES3UserType_TsPlayerNetworkHelper : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TsPlayerNetworkHelper()
			: base(typeof(TsPlayerNetworkHelper))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TsPlayerNetworkHelper tsPlayerNetworkHelper = (TsPlayerNetworkHelper)obj;
			writer.WriteProperty("steamID", tsPlayerNetworkHelper.steamID, ES3Type_string.Instance);
			writer.WriteProperty("playerLastSelectedSlot", tsPlayerNetworkHelper.playerLastSelectedSlot, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TsPlayerNetworkHelper tsPlayerNetworkHelper = (TsPlayerNetworkHelper)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "steamID"))
				{
					if (property == "playerLastSelectedSlot")
					{
						tsPlayerNetworkHelper.playerLastSelectedSlot = reader.Read<int>(ES3Type_int.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					tsPlayerNetworkHelper.NetworksteamID = reader.Read<string>(ES3Type_string.Instance);
				}
			}
		}
	}
}
