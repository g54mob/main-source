using DV.HUD;
using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoControlOverrideStep : ALocoControlStep
	{
		protected OverridableBaseControl control;

		protected bool started;

		protected float startTime;

		public float MinValue { get; private set; }

		public float MaxValue { get; private set; }

		protected float Timeout { get; private set; }

		public LocoControlOverrideStep(float min, float max, TrainCar loco, InteriorControlsManager.ControlType controlType, OverridableBaseControl control, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true, float timeout = 0f)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			MinValue = min;
			MaxValue = max;
			Timeout = timeout;
			this.control = control;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			startTime = Time.time;
		}

		protected override bool InternalCheck()
		{
			float value = control.Value;
			if (value == float.MinValue)
			{
				return true;
			}
			if (!started && value > 0f)
			{
				started = true;
				startTime = Time.time;
			}
			if (Timeout > 0f && MinValue >= 0f && MaxValue > 0f && started && Time.time > startTime + Timeout)
			{
				return true;
			}
			if (value >= MinValue)
			{
				return value <= MaxValue;
			}
			return false;
		}
	}
}
