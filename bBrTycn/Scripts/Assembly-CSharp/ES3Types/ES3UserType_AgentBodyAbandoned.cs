using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_isBaged" })]
	public class ES3UserType_AgentBodyAbandoned : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentBodyAbandoned()
			: base(typeof(AgentBodyAbandoned))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			AgentBodyAbandoned objectContainingField = (AgentBodyAbandoned)obj;
			writer.WritePrivateField("_isBaged", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			AgentBodyAbandoned objectContainingField = (AgentBodyAbandoned)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_isBaged")
				{
					objectContainingField = (AgentBodyAbandoned)reader.SetPrivateField("_isBaged", reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
