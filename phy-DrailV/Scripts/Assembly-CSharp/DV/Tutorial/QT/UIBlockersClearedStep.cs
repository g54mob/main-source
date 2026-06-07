using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class UIBlockersClearedStep : AQuickTutorialStep
	{
		public UIBlockersClearedStep(string message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			AttentionOnGUI = true;
		}

		protected override bool InternalCheck()
		{
			return !SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.Blockers);
		}
	}
}
