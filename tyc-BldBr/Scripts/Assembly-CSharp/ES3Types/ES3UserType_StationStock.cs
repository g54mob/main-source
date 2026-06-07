using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_StationStock : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_StationStock()
			: base(typeof(StationStock))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			_ = (StationStock)obj;
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			_ = (StationStock)obj;
			foreach (string property in reader.Properties)
			{
				_ = property;
				reader.Skip();
			}
		}
	}
}
