using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "name" })]
	public class ES3UserType_ScriptableObject : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_ScriptableObject()
			: base(null)
		{
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
		}
	}
}
