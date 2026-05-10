using CTS;

namespace ES3Types
{
	public class ES3UserType_WorkerRoomAssignationsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerRoomAssignationsArray()
			: base(typeof(RoomAssignations[]), ES3UserType_WorkerRoomAssignations.Instance)
		{
			Instance = this;
		}
	}
}
