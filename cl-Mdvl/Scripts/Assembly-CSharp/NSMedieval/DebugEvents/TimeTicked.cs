using System.IO;
using System.Runtime.InteropServices;

namespace NSMedieval.DebugEvents
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TimeTicked : IDebugEvent
	{
		public const int IntervalMinutes = 1;

		public byte TypeId => 0;

		public DebugEventCategory Category => DebugEventCategory.StateChange;

		public void WriteBytes(BinaryWriter writer)
		{
		}

		public void ReadBytes(BinaryReader reader)
		{
		}

		public string GetEventName(DebugEventWindowContext context)
		{
			return "Time Tick";
		}

		public string GetEventDescription(DebugEventWindowContext context)
		{
			return "Time Tick";
		}

		public void DrawGizmos(DebugEventWindowContext context)
		{
		}

		public void OnDoubleClick(DebugEventWindowContext context)
		{
		}
	}
}
