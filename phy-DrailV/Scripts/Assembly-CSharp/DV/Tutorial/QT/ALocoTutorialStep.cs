using DV.CabControls.Spec;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class ALocoTutorialStep : AQuickTutorialStep
	{
		public TrainCar Loco { get; private set; }

		public ControlSpec Control { get; private set; }

		public QTSemantic Semantic { get; private set; }

		public ALocoTutorialStep(TrainCar loco, AQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			Loco = loco;
			Semantic = semantic;
		}

		protected override Transform ProcessAttentionPoint(Transform attentionPoint)
		{
			if (attentionPoint == null)
			{
				return null;
			}
			Control = attentionPoint.GetComponent<ControlSpec>();
			if (Control is Lever lever && lever.interactionPoint != null)
			{
				return lever.interactionPoint;
			}
			return attentionPoint;
		}
	}
}
