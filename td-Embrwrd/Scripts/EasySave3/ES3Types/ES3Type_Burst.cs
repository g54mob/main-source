using UnityEngine.Scripting;

namespace ES3Types
{
	[ES3Properties(new string[] { "time", "count", "minCount", "maxCount", "cycleCount", "repeatInterval", "probability" })]
	[Preserve]
	public class ES3Type_Burst : ES3Type
	{
		public static ES3Type Instance;

		public ES3Type_Burst()
			: base(null)
		{
		}

		public override void Write(object obj, ES3Writer writer)
		{
		}

		public override object Read<T>(ES3Reader reader)
		{
			return null;
		}
	}
}
