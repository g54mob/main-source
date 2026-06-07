using DV.UIFramework;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class SubmenuSelectedStep : AQuickTutorialStep
	{
		private UIMenuController controller;

		private Transform regularTarget;

		private string regularMessage;

		private string backMessage;

		private int baseValue = -1;

		private int previousValue = -1;

		private int targetValue;

		private bool done;

		public SubmenuSelectedStep(UIMenuController controller, int baseMenu, int targetMenu, string message, string backMessage, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			AttentionOnGUI = true;
			this.controller = controller;
			regularMessage = message;
			regularTarget = attentionPoint;
			this.backMessage = backMessage;
			targetValue = targetMenu;
			baseValue = baseMenu;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			previousValue = controller.ActiveIndex;
			done = previousValue == targetValue;
		}

		protected override bool InternalCheck()
		{
			int activeIndex = controller.ActiveIndex;
			if (previousValue != activeIndex)
			{
				if (activeIndex == baseValue)
				{
					Message = regularMessage;
					AttentionPoint = regularTarget;
					ShowVisual();
				}
				else
				{
					Message = backMessage;
					AttentionPoint = null;
					ShowVisual();
				}
				previousValue = activeIndex;
			}
			if (activeIndex == targetValue)
			{
				done = true;
			}
			return done;
		}
	}
}
