using DV.HUD;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class AutomaticLubricatorStep : ALocoControlStep
	{
		private Indicator transmissionOil;

		public AutomaticLubricatorStep(TrainCar loco, InteriorControlsManager.ControlType controlType, Indicator transmissionOil, AQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.transmissionOil = transmissionOil;
		}

		protected override bool InternalCheck()
		{
			return transmissionOil.Value >= 0.99f;
		}
	}
}
