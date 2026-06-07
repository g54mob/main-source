using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	public class DelayedTutorialTriggerAction : TutorialNotificationTriggerBase
	{
		[SerializeField]
		private float _delay;

		[SerializeField]
		private bool _useUnscaledTime;

		private float _delayTime;

		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			_delayTime = 0f;
		}

		public override void Update()
		{
			if (!base.WasTriggered)
			{
				_delayTime += (_useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
				if (_delay <= _delayTime)
				{
					Trigger();
				}
			}
		}
	}
}
