using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public abstract class ACommsRadioStep<T> : AQuickTutorialStep where T : ICommsRadioMode
	{
		protected ACommsRadioStep(string message, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
		}

		protected CommsRadioController GetComms()
		{
			for (int i = 0; i < 2; i++)
			{
				if (SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItems[i] != null)
				{
					CommsRadioController componentInChildren = SingletonBehaviour<TutorialHelper>.Instance.GrabbedInventoryItems[i].GetComponentInChildren<CommsRadioController>();
					if (componentInChildren != null)
					{
						return componentInChildren;
					}
				}
			}
			return null;
		}

		protected T GetModeController()
		{
			CommsRadioController comms = GetComms();
			if (comms == null)
			{
				return default(T);
			}
			ICommsRadioMode currentActiveMode;
			if ((currentActiveMode = comms.CurrentActiveMode) is T)
			{
				return (T)currentActiveMode;
			}
			return default(T);
		}
	}
}
