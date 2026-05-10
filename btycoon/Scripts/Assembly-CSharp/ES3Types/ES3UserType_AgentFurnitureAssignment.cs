using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentSeat" })]
	public class ES3UserType_AgentFurnitureAssignment : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentFurnitureAssignment()
			: base(typeof(AgentFurnitureAssignment))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			AgentFurnitureAssignment objectContainingProperty = (AgentFurnitureAssignment)obj;
			writer.WritePrivatePropertyByRef("CurrentSeat", objectContainingProperty);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			AgentFurnitureAssignment objectContainingProperty = (AgentFurnitureAssignment)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "CurrentSeat")
				{
					objectContainingProperty = (AgentFurnitureAssignment)reader.SetPrivateProperty("CurrentSeat", reader.Read<Seat>(), objectContainingProperty);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
