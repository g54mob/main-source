using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_AgentAutonomyCalculator : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentAutonomyCalculator()
			: base(typeof(AgentAutonomyCalculator))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			AgentAutonomyCalculator objectContainingField = (AgentAutonomyCalculator)obj;
			writer.WritePrivateField("_paused", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			AgentAutonomyCalculator objectContainingField = (AgentAutonomyCalculator)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_paused")
				{
					reader.SetPrivateField("_paused", reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
