using System.IO;
using NSMedieval.DebugEvents;

namespace NSMedieval
{
	public interface IDebugEvent
	{
		byte TypeId { get; }

		DebugEventCategory Category { get; }

		void WriteBytes(BinaryWriter writer);

		void ReadBytes(BinaryReader reader);

		string GetEventName(DebugEventWindowContext context);

		string GetEventDescription(DebugEventWindowContext context);

		void DrawGizmos(DebugEventWindowContext context);

		void OnDoubleClick(DebugEventWindowContext context);

		void Apply(DebugEventWindowModelContext context)
		{
			ApplyState(context);
			if (Category.HasFlag(DebugEventCategory.Event))
			{
				context.InputEvents.Add(new DebugEventWithTime
				{
					TimeMinutes = (int)context.StateSnapshot.TimeMinutes,
					TimeStamp = context.StateSnapshot.TimeDisplayText,
					DebugEvent = this
				});
			}
		}

		void ApplyState(DebugEventWindowModelContext context)
		{
		}
	}
}
