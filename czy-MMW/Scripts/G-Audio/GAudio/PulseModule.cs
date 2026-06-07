using System;
using UnityEngine;

namespace GAudio
{
	public abstract class PulseModule : MonoBehaviour, IGATPulseSender
	{
		public delegate void OnPulseHandler(IGATPulseInfo pulseInfo);

		public delegate void OnStepsDidChangeHandler(bool[] newSteps);

		protected class GATPulseInfo : IGATPulseInfo
		{
			private double _pulseDuration;

			public double PulseDspTime { get; private set; }

			public double PulseDuration => _pulseDuration;

			public int StepIndex { get; private set; }

			public int NbOfSteps { get; set; }

			public bool PulseDidChange { get; set; }

			public IGATPulseSender PulseSender { get; private set; }

			public double NextPulseDspTime { get; set; }

			public int NextStepIndex { get; set; }

			public GATPulseInfo(IGATPulseSender sender)
			{
				PulseSender = sender;
				PulseDidChange = true;
			}

			public void Init(double period, int nbOfSteps)
			{
				_pulseDuration = period;
				PulseDidChange = true;
				NbOfSteps = nbOfSteps;
			}

			public void SetStart(double dspTime, int stepIndex)
			{
				NextPulseDspTime = dspTime;
				NextStepIndex = stepIndex;
			}

			public void WillPulse(double period)
			{
				if (period != _pulseDuration)
				{
					PulseDidChange = true;
					_pulseDuration = period;
				}
				PulseDspTime = NextPulseDspTime;
				StepIndex = NextStepIndex;
				NextPulseDspTime += _pulseDuration;
				NextStepIndex = (NextStepIndex + 1) % NbOfSteps;
			}

			public void DidPulse()
			{
				PulseDidChange = false;
			}
		}

		public OnPulseHandler onWillPulse;

		[SerializeField]
		protected bool _Bypass;

		[SerializeField]
		protected double _Period = 1.0;

		[SerializeField]
		protected bool[] _Steps = new bool[4] { true, true, true, true };

		[SerializeField]
		protected bool _RandomBypassStep;

		[SerializeField]
		protected float _StepBypassChance;

		protected GATPulseInfo _pulseInfo;

		protected OnPulseHandler _onPulse;

		protected OnPulseHandler _onPulseControl;

		protected OnStepsDidChangeHandler _onStepsDidChange;

		public bool Bypass
		{
			get
			{
				return _Bypass;
			}
			set
			{
				if (_Bypass != value)
				{
					_Bypass = value;
				}
			}
		}

		public double Period
		{
			get
			{
				return _Period;
			}
			set
			{
				if (_Period != value)
				{
					_Period = value;
				}
			}
		}

		public virtual bool[] Steps
		{
			get
			{
				return _Steps;
			}
			set
			{
				if (_Steps.Length != value.Length)
				{
					if (_pulseInfo != null && _pulseInfo.NextStepIndex >= value.Length)
					{
						_pulseInfo.NextStepIndex = 0;
					}
					_pulseInfo.NbOfSteps = value.Length;
					_Steps = value;
					_onStepsDidChange?.Invoke(_Steps);
				}
			}
		}

		public virtual PulseModule ParentPulse
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool RandomBypassStep
		{
			get
			{
				return _RandomBypassStep;
			}
			set
			{
				if (_RandomBypassStep != value)
				{
					_RandomBypassStep = value;
				}
			}
		}

		public float StepBypassChance
		{
			get
			{
				return _StepBypassChance;
			}
			set
			{
				if (_StepBypassChance != value)
				{
					_StepBypassChance = value;
				}
			}
		}

		public IGATPulseInfo PulseInfo => _pulseInfo;

		public abstract IGATPulseInfo MasterPulseInfo { get; }

		public void SubscribeToPulse(IGATPulseClient client)
		{
			_onPulse = (OnPulseHandler)Delegate.Combine(_onPulse, new OnPulseHandler(client.OnPulse));
			_onStepsDidChange = (OnStepsDidChangeHandler)Delegate.Combine(_onStepsDidChange, new OnStepsDidChangeHandler(client.PulseStepsDidChange));
		}

		public void UnsubscribeToPulse(IGATPulseClient client)
		{
			_onPulse = (OnPulseHandler)Delegate.Remove(_onPulse, new OnPulseHandler(client.OnPulse));
			_onStepsDidChange = (OnStepsDidChangeHandler)Delegate.Remove(_onStepsDidChange, new OnStepsDidChangeHandler(client.PulseStepsDidChange));
		}

		public bool RegisterPulseController(IGATPulseController controller)
		{
			if (_onPulseControl != null)
			{
				return false;
			}
			_onPulseControl = controller.OnPulseControl;
			return true;
		}

		public void UnregisterPulseController(IGATPulseController controller)
		{
			if (!(new OnPulseHandler(controller.OnPulseControl) != _onPulseControl))
			{
				_onPulseControl = null;
			}
		}

		protected virtual void Awake()
		{
			_pulseInfo = new GATPulseInfo(this);
			if (_Steps.Length == 0)
			{
				base.enabled = false;
			}
		}

		protected virtual void OnEnable()
		{
			if (_pulseInfo == null)
			{
				_pulseInfo = new GATPulseInfo(this);
			}
		}

		protected virtual void OnDisable()
		{
		}

		protected void Pulse()
		{
			_onPulseControl?.Invoke(_pulseInfo);
			_pulseInfo.WillPulse(_Period);
			onWillPulse?.Invoke(_pulseInfo);
			if (_onPulse == null)
			{
				_pulseInfo.DidPulse();
				return;
			}
			bool flag = _Bypass;
			if (!_Steps[_pulseInfo.StepIndex])
			{
				flag = true;
			}
			if (!flag && _RandomBypassStep)
			{
				flag = UnityEngine.Random.value < _StepBypassChance;
			}
			if (!flag)
			{
				_onPulse(_pulseInfo);
			}
			_pulseInfo.DidPulse();
		}

		public void PulseOneShot(int stepIndex)
		{
			if (_pulseInfo != null)
			{
				_pulseInfo.NextStepIndex = stepIndex;
				_pulseInfo.NextPulseDspTime = AudioSettings.dspTime + GATInfo.PulseLatency;
				_pulseInfo.WillPulse(_Period);
				if (_onPulse != null)
				{
					_onPulse(_pulseInfo);
				}
				_pulseInfo.DidPulse();
			}
		}
	}
}
