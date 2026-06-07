using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public abstract class TutorialNotificationTriggerBase
	{
		[SerializeField]
		private TutorialID _id;

		public TutorialID ID => _id;

		public bool WasTriggered { get; protected set; }

		public virtual void Initialize(bool wasTriggered = false)
		{
			WasTriggered = wasTriggered;
		}

		public virtual void Update()
		{
		}

		protected bool Trigger()
		{
			if (WasTriggered)
			{
				return false;
			}
			TutorialEvent.Dispatch(GameEventType.TutorialNotification, _id);
			WasTriggered = true;
			return true;
		}

		public void SetTriggered(bool triggered)
		{
			WasTriggered = triggered;
		}
	}
}
