using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "haveMet" })]
	public class ES3UserType_ShopNPC : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_ShopNPC()
			: base(typeof(ShopNPC))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			ShopNPC shopNPC = (ShopNPC)obj;
			writer.WriteProperty("haveMet", shopNPC.haveMet, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			ShopNPC shopNPC = (ShopNPC)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "haveMet")
				{
					shopNPC.haveMet = reader.Read<bool>(ES3Type_bool.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
