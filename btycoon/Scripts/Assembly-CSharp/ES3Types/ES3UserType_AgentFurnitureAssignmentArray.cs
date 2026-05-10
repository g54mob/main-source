using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_AgentFurnitureAssignmentArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentFurnitureAssignmentArray()
			: base(typeof(AgentFurnitureAssignment[]), ES3UserType_AgentFurnitureAssignment.Instance)
		{
			Instance = this;
		}
	}
}
