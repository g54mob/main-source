using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_currentAction" })]
	public class ES3UserType_CustomerActionPlayer : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerActionPlayer()
			: base(typeof(CustomerActionPlayer))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CustomerActionPlayer objectContainingField = (CustomerActionPlayer)obj;
			writer.WritePrivateField("_currentAction", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CustomerActionPlayer objectContainingField = (CustomerActionPlayer)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_currentAction")
				{
					objectContainingField = (CustomerActionPlayer)reader.SetPrivateField("_currentAction", reader.Read<AgentAction>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
