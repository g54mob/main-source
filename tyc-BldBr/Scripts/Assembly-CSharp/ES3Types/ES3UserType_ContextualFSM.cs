using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<CurrentState>k__BackingField" })]
	public class ES3UserType_ContextualFSM : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_ContextualFSM()
			: base(typeof(ContextualFSM))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			ContextualFSM objectContainingField = (ContextualFSM)obj;
			writer.WritePrivateField("<CurrentState>k__BackingField", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			_ = (ContextualFSM)obj;
		}
	}
}
