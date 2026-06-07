using System;
using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Actions
{
	[Obsolete]
	public class DebugLogVariable : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<object> log;

		public BBParameter<string> prefix;

		public float secondsToRun;

		public CompactStatus finishStatus;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
