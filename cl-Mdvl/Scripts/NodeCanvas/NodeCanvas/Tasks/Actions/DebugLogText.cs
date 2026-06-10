using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Debug Log", 0)]
	[Category("✫ Utility")]
	[Description("Display a UI label on the agent's position if seconds to run is not 0 and also logs the message, which can also be mapped to any variable.")]
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
		public BBParameter<string> log = "Hello World";

		public float labelYOffset;

		public float secondsToRun = 1f;

		public VerboseMode verboseMode;

		public LogMode logMode;

		public CompactStatus finishStatus = CompactStatus.Success;

		protected override string info => "Log " + log.ToString() + ((secondsToRun > 0f) ? (" for " + secondsToRun + " sec.") : "");

		protected override void OnExecute()
		{
			if (verboseMode == VerboseMode.LogAndDisplayLabel || verboseMode == VerboseMode.LogOnly)
			{
				_ = $"(<b>{base.agent.gameObject.name}</b>) {log.value}";
				_ = logMode;
				_ = logMode;
				_ = 1;
				_ = logMode;
				_ = 2;
			}
			if ((verboseMode == VerboseMode.LogAndDisplayLabel || verboseMode == VerboseMode.DisplayLabelOnly) && secondsToRun > 0f)
			{
				MonoManager.current.onGUI += OnGUI;
			}
		}

		protected override void OnStop()
		{
			if ((verboseMode == VerboseMode.LogAndDisplayLabel || verboseMode == VerboseMode.DisplayLabelOnly) && secondsToRun > 0f)
			{
				MonoManager.current.onGUI -= OnGUI;
			}
		}

		protected override void OnUpdate()
		{
			if (base.elapsedTime >= secondsToRun)
			{
				EndAction(finishStatus == CompactStatus.Success);
			}
		}

		private void OnGUI()
		{
			if (!(Camera.main == null))
			{
				Vector3 vector = Camera.main.WorldToScreenPoint(base.agent.position + new Vector3(0f, labelYOffset, 0f));
				Vector2 vector2 = GUI.skin.label.CalcSize(new GUIContent(log.value));
				Rect position = new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y, vector2.x + 10f, vector2.y);
				GUI.color = Color.white.WithAlpha(0.5f);
				GUI.DrawTexture(position, Texture2D.whiteTexture);
				GUI.color = new Color(0.2f, 0.2f, 0.2f);
				position.x += 4f;
				GUI.Label(position, log.value);
				GUI.color = Color.white;
			}
		}
	}
}
