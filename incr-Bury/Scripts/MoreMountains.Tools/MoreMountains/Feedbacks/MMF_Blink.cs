using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you trigger a blink on an MMBlink object.")]
	[FeedbackPath("Renderer/MMBlink")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	public class MMF_Blink : MMF_Feedback
	{
		public enum BlinkModes
		{
			Toggle = 0,
			Start = 1,
			Stop = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Blink", true, 61, true, false)]
		[Tooltip("the target object to blink")]
		public MMBlink TargetBlink;

		[Tooltip("an optional list of extra target objects to blink")]
		public List<MMBlink> ExtraTargetBlinks;

		[Tooltip("the selected mode for this feedback")]
		public BlinkModes BlinkMode;

		[Tooltip("the duration of the blink. You can set it manually, or you can press the GrabDurationFromBlink button to automatically compute it. For performance reasons, this isn't updated unless you press the button, make sure you do so if you change the blink's duration.")]
		public float Duration;

		public MMF_Button GrabDurationFromBlinkButton;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetBlink = FindAutomatedTarget<MMBlink>();
		}

		public override void InitializeCustomAttributes()
		{
			GrabDurationFromBlinkButton = new MMF_Button("Grab Duration From Blink Component", GrabDurationFromBlink);
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || TargetBlink == null)
			{
				return;
			}
			HandleBlink(TargetBlink);
			foreach (MMBlink extraTargetBlink in ExtraTargetBlinks)
			{
				HandleBlink(extraTargetBlink);
			}
		}

		protected virtual void HandleBlink(MMBlink target)
		{
			target.TimescaleMode = ComputedTimescaleMode;
			switch (BlinkMode)
			{
			case BlinkModes.Toggle:
				target.ToggleBlinking();
				break;
			case BlinkModes.Start:
				target.StartBlinking();
				break;
			case BlinkModes.Stop:
				target.StopBlinking();
				break;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			TargetBlink.StopBlinking();
			foreach (MMBlink extraTargetBlink in ExtraTargetBlinks)
			{
				extraTargetBlink.StopBlinking();
			}
		}

		public virtual void GrabDurationFromBlink()
		{
			if (TargetBlink != null)
			{
				Duration = TargetBlink.Duration;
			}
		}
	}
}
