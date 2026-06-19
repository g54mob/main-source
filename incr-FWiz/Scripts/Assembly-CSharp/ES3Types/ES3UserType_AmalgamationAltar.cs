using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "Level" })]
	public class ES3UserType_AmalgamationAltar : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AmalgamationAltar()
			: base(null)
		{
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
		}
	}
}
