using NSMedieval.Tools;

namespace NSMedieval.DebugEvents
{
	public class DebugEventWindowContext
	{
		public Vec3Int MapSize;

		private const string GizmoId = "DebugEventsWindow.SelectedEvent";

		public string GizmoGroupId => "DebugEventsWindow.SelectedEvent";

		public Vec3Int NodeIndexTo3D(int nodeIndex)
		{
			return GridDataIndexTools.To3DIndex(nodeIndex, in MapSize);
		}
	}
}
