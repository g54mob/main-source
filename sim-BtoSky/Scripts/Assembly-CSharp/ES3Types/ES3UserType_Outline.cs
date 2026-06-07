using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "enabled" })]
	public class ES3UserType_Outline : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Outline()
			: base(typeof(Outline))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Outline outline = (Outline)obj;
			writer.WriteProperty("enabled", outline.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Outline outline = (Outline)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "enabled")
				{
					outline.enabled = reader.Read<bool>(ES3Type_bool.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
