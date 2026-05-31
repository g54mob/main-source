using CTS.Core;

namespace CTS
{
	public class WorkerRoomAssignationsButton : CTSBehaviour
	{
		public void SetCurrentMode(RoomAssignationsTool.EMode mode)
		{
			CTSSingleton<RoomAssignationsTool>.Instance.SetCurrentMode(mode);
		}
	}
}
