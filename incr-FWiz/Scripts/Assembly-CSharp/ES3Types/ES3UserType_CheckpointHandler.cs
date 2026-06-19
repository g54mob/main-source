using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CheckpointsUnlocked" })]
	public class ES3UserType_CheckpointHandler : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CheckpointHandler()
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
