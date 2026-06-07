using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CommsRadioModeStep<T> : AQuickTutorialStep where T : ICommsRadioMode
	{
		public CommsRadioModeStep(string message, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
		}

		private bool CheckMode(InventoryItemSpec spec)
		{
			if (spec == null)
			{
				return false;
			}
			CommsRadioController componentInChildren = spec.GetComponentInChildren<CommsRadioController>();
			if (componentInChildren == null)
			{
				return false;
			}
			return componentInChildren.CurrentActiveMode is T;
		}

		protected override bool InternalCheck()
		{
			if (!CheckMode(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemLeftHand))
			{
				return CheckMode(SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItemRightHand);
			}
			return true;
		}
	}
}
