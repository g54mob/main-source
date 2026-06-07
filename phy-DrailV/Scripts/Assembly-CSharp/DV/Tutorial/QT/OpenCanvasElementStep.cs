using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class OpenCanvasElementStep : AQuickTutorialStep
	{
		private CanvasController.ElementType elementType;

		public OpenCanvasElementStep(CanvasController.ElementType elementType, string message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			AttentionOnGUI = true;
			this.elementType = elementType;
		}

		protected override bool InternalCheck()
		{
			return SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(elementType);
		}
	}
}
