using System;
using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	[Description("Logs the value of a variable in the console")]
	[Obsolete("Use Debug Log Text")]
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
