using DV.CabControls;
using DV.HUD;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class ControlImplBaseStep : ALocoControlStep
	{
		private ControlImplBase control;

		public float MinValue { get; private set; }

		public float MaxValue { get; private set; }

		public ControlImplBaseStep(float min, float max, InteriorControlsManager.ControlType controlType, TrainCar loco, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			MinValue = min;
			MaxValue = max;
			if (loco.interior.GetComponentInChildren<InteriorControlsManager>().TryGetControl(controlType, out var reference))
			{
				control = reference.controlImplBase;
			}
			else
			{
				control = null;
			}
		}

		public ControlImplBaseStep(float min, float max, ControlImplBase control, TrainCar loco, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, InteriorControlsManager.ControlType.None, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			MinValue = min;
			MaxValue = max;
			this.control = control;
		}

		protected override bool InternalCheck()
		{
			float num = ((control != null) ? control.Value : float.MinValue);
			if (num == float.MinValue)
			{
				return true;
			}
			if (num >= MinValue)
			{
				return num <= MaxValue;
			}
			return false;
		}
	}
}
