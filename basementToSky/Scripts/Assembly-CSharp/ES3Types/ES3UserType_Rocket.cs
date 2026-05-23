using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "guid" })]
	public class ES3UserType_Rocket : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Rocket()
			: base(typeof(Rocket))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Rocket rocket = (Rocket)obj;
			writer.WriteProperty("guid", rocket.guid, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Rocket rocket = (Rocket)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "guid")
				{
					rocket.guid = reader.Read<string>(ES3Type_string.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
