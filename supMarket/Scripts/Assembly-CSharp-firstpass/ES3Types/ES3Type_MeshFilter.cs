using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "sharedMesh" })]
	public class ES3Type_MeshFilter : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3Type_MeshFilter()
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
