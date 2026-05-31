using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_parent" })]
	public class ES3UserType_BarVisualObject : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BarVisualObject()
			: base(typeof(BarVisualObject))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			_ = (BarVisualObject)obj;
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			_ = (BarVisualObject)obj;
			foreach (string property in reader.Properties)
			{
				_ = property;
				reader.Skip();
			}
		}
	}
}
