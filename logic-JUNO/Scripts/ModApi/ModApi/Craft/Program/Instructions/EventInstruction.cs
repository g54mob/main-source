using System;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class EventInstruction : ProgramInstruction
	{
		[ProgramNodeProperty]
		private ProgramEventType _event = ProgramEventType.FlightStart;

		public ProgramEventType EventType => _event;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			return base.Execute(context);
		}
	}
}
