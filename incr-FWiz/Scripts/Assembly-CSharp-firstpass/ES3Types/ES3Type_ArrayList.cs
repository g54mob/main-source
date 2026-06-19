using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_items", "_size", "_version" })]
	public class ES3Type_ArrayList : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3Type_ArrayList()
			: base(null)
		{
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			return null;
		}
	}
}
