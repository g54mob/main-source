using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class DebugLogText : ActionTask<Transform>
	{
		public enum LogMode
		{
			Log = 0,
			Warning = 1,
			Error = 2
		}

		public enum VerboseMode
		{
			LogAndDisplayLabel = 0,
			LogOnly = 1,
			DisplayLabelOnly = 2
		}

		[RequiredField]
		public BBParameter<string> log;

		public float labelYOffset;

		public float secondsToRun;

		public VerboseMode verboseMode;

		public LogMode logMode;

		public CompactStatus finishStatus;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnStop()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void OnGUI()
		{
		}
	}
}
