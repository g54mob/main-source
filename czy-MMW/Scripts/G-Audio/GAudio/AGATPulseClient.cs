using UnityEngine;

namespace GAudio
{
	public abstract class AGATPulseClient : MonoBehaviour, IGATPulseClient
	{
		[SerializeField]
		protected PulseModule _pulse;

		[SerializeField]
		protected bool[] _subscribedSteps = new bool[0];

		private bool _isSubscribed;

		public PulseModule Pulse
		{
			get
			{
				return _pulse;
			}
			set
			{
				if (!(_pulse == value))
				{
					UnsubscribeToPulse();
					_pulse = value;
					if (value != null)
					{
						UpdateSubscribedSteps(value.Steps);
						SubscribeToPulseIfNeeded();
					}
				}
			}
		}

		public bool[] SubscribedSteps => _subscribedSteps;

		public abstract void OnPulse(IGATPulseInfo pulseInfo);

		protected virtual void Awake()
		{
			if (_pulse == null)
			{
				_pulse = base.gameObject.GetComponent<PulseModule>();
			}
		}

		protected virtual void OnEnable()
		{
			_isSubscribed = false;
			SubscribeToPulseIfNeeded();
		}

		protected virtual void OnDisable()
		{
			UnsubscribeToPulse();
		}

		protected virtual bool CanSubscribeToPulse()
		{
			if (!_isSubscribed)
			{
				return _pulse != null;
			}
			return false;
		}

		protected void SubscribeToPulseIfNeeded()
		{
			if (CanSubscribeToPulse())
			{
				_pulse.SubscribeToPulse(this);
				_isSubscribed = true;
			}
		}

		protected void UnsubscribeToPulse()
		{
			if (_isSubscribed && !(_pulse == null))
			{
				_pulse.UnsubscribeToPulse(this);
				_isSubscribed = false;
			}
		}

		protected virtual bool NewPulseStepShouldStartChecked(int stepIndex)
		{
			return true;
		}

		void IGATPulseClient.PulseStepsDidChange(bool[] newSteps)
		{
			UpdateSubscribedSteps(newSteps);
		}

		private void UpdateSubscribedSteps(bool[] newSteps)
		{
			bool[] subscribedSteps = _subscribedSteps;
			_subscribedSteps = new bool[newSteps.Length];
			int num = ((newSteps.Length > subscribedSteps.Length) ? subscribedSteps.Length : newSteps.Length);
			for (int i = 0; i < num; i++)
			{
				_subscribedSteps[i] = subscribedSteps[i];
			}
			if (num < newSteps.Length)
			{
				for (int i = num; i < newSteps.Length; i++)
				{
					_subscribedSteps[i] = NewPulseStepShouldStartChecked(i);
				}
			}
		}
	}
}
