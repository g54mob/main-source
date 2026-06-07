using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public class SubPulseModule : PulseModule, IGATPulseClient
	{
		public enum PeriodMode
		{
			SubdivideParent = 0,
			RatioOfParent = 1,
			AbsolutePeriod = 2,
			Hyper = 3
		}

		[SerializeField]
		private PulseModule _ParentPulse;

		private float[] _Ratios = new float[3] { 0.25f, 0.25f, 0.25f };

		private float _RatioOffset;

		private int _variablePeriodIndex;

		[SerializeField]
		protected PeriodMode _SubPulseMode;

		[SerializeField]
		protected int _RatioOfParentPeriod;

		[SerializeField]
		protected bool _RandomBypassParentPulse;

		[SerializeField]
		protected float _ParentPulseBypassChance;

		[SerializeField]
		protected bool[] _SubscribedSteps = new bool[0];

		protected bool _shouldUpdatePeriod;

		private bool _doSubPulse;

		private bool _oneShot;

		private double nextPos;

		private double nextRatio;

		private bool nextSkip;

		private bool waiting;

		public static string LogText1;

		public static string LogText2;

		public static string LogText3;

		public static string LogText4;

		public override PulseModule ParentPulse
		{
			get
			{
				return _ParentPulse;
			}
			set
			{
				if (_ParentPulse == value)
				{
					return;
				}
				if (_ParentPulse != null)
				{
					_ParentPulse.UnsubscribeToPulse(this);
				}
				if (value != null)
				{
					value.SubscribeToPulse(this);
					if (_SubPulseMode != PeriodMode.AbsolutePeriod)
					{
						_shouldUpdatePeriod = true;
					}
					_SubscribedSteps = new bool[value.Steps.Length];
					value.Steps.CopyTo(_SubscribedSteps, 0);
				}
				else
				{
					_SubscribedSteps = new bool[0];
				}
				_ParentPulse = value;
			}
		}

		public override bool[] Steps
		{
			get
			{
				return _Steps;
			}
			set
			{
				if (value.Length != _Steps.Length)
				{
					_shouldUpdatePeriod = true;
					base.Steps = value;
				}
			}
		}

		public float[] Ratios
		{
			get
			{
				return _Ratios;
			}
			set
			{
				if (value != _Ratios)
				{
					_Ratios = value;
				}
			}
		}

		public float RatioOffset
		{
			get
			{
				return _RatioOffset;
			}
			set
			{
				_RatioOffset = value;
				PrepOffset(wait: true);
			}
		}

		public PeriodMode SubPulseMode
		{
			get
			{
				return _SubPulseMode;
			}
			set
			{
				if (_SubPulseMode != value)
				{
					_SubPulseMode = value;
					_shouldUpdatePeriod = true;
				}
			}
		}

		public int RatioOfParentPeriod
		{
			get
			{
				return _RatioOfParentPeriod;
			}
			set
			{
				if (_RatioOfParentPeriod != value)
				{
					_RatioOfParentPeriod = value;
					if (_SubPulseMode == PeriodMode.RatioOfParent || _SubPulseMode == PeriodMode.Hyper)
					{
						_shouldUpdatePeriod = true;
					}
				}
			}
		}

		public bool RandomBypassParentPulse
		{
			get
			{
				return _RandomBypassParentPulse;
			}
			set
			{
				if (_RandomBypassParentPulse != value)
				{
					_RandomBypassParentPulse = value;
				}
			}
		}

		public float ParentPulseBypassChance
		{
			get
			{
				return _ParentPulseBypassChance;
			}
			set
			{
				if (_ParentPulseBypassChance != value)
				{
					_ParentPulseBypassChance = value;
				}
			}
		}

		public bool[] SubscribedSteps => _SubscribedSteps;

		public override IGATPulseInfo MasterPulseInfo
		{
			get
			{
				PulseModule parentPulse = _ParentPulse;
				while (parentPulse.ParentPulse != null)
				{
					parentPulse = parentPulse.ParentPulse;
				}
				return parentPulse.MasterPulseInfo;
			}
		}

		public MasterPulseModule RootPulse
		{
			get
			{
				PulseModule parentPulse = _ParentPulse;
				while (parentPulse.ParentPulse != null)
				{
					parentPulse = parentPulse.ParentPulse;
				}
				return parentPulse as MasterPulseModule;
			}
		}

		public void PrepOffset(bool wait = false)
		{
			waiting = wait;
			if (!Mathf.Approximately(_RatioOffset, 0f))
			{
				nextRatio = _RatioOffset;
				_variablePeriodIndex = -1;
				nextPos = 0.0;
				nextSkip = true;
			}
		}

		public void OnPulse(IGATPulseInfo pulseInfo)
		{
			if (_SubPulseMode != PeriodMode.AbsolutePeriod && (pulseInfo.PulseDidChange || _shouldUpdatePeriod))
			{
				UpdatePeriod();
			}
			bool flag = _Bypass;
			if (!flag)
			{
				if (!_SubscribedSteps[pulseInfo.StepIndex])
				{
					flag = true;
				}
				else if (!_oneShot && _RandomBypassParentPulse && Random.value < _ParentPulseBypassChance)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				_pulseInfo.SetStart(pulseInfo.PulseDspTime, 0);
				_doSubPulse = true;
			}
		}

		void IGATPulseClient.PulseStepsDidChange(bool[] newSteps)
		{
			bool[] subscribedSteps = _SubscribedSteps;
			_SubscribedSteps = new bool[newSteps.Length];
			int num = ((newSteps.Length > subscribedSteps.Length) ? subscribedSteps.Length : newSteps.Length);
			for (int i = 0; i < num; i++)
			{
				_SubscribedSteps[i] = subscribedSteps[i];
			}
		}

		public void OneShotNextStep()
		{
			_oneShot = true;
			_Bypass = false;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_ParentPulse != null)
			{
				_ParentPulse.SubscribeToPulse(this);
			}
			_pulseInfo.Init(_Period, _Steps.Length);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (_ParentPulse != null)
			{
				_ParentPulse.UnsubscribeToPulse(this);
			}
		}

		protected void UpdatePeriod()
		{
			_Period = _SubPulseMode switch
			{
				PeriodMode.SubdivideParent => _ParentPulse.Period / (double)_Steps.Length, 
				PeriodMode.RatioOfParent => _ParentPulse.Period / (double)_RatioOfParentPeriod, 
				PeriodMode.AbsolutePeriod => _Period, 
				_ => 1.0, 
			};
			_shouldUpdatePeriod = false;
		}

		private void UpdateVariablePeriodPulse()
		{
			if (_SubPulseMode != PeriodMode.Hyper)
			{
				return;
			}
			if (waiting)
			{
				base.Bypass = true;
				_Period = _ParentPulse.Period;
				return;
			}
			double num = ((nextRatio > 0.0) ? nextRatio : ((double)_Ratios[_variablePeriodIndex % _Ratios.Length]));
			base.Bypass = nextSkip;
			nextPos += num;
			if (nextPos >= 0.999 && nextPos < 1.001)
			{
				nextPos = 0.0;
			}
			nextSkip = false;
			nextRatio = 0.0;
			if (nextPos > 1.0)
			{
				num -= (nextRatio = nextPos - 1.0);
				nextPos = 0.0;
				nextSkip = true;
			}
			else
			{
				_variablePeriodIndex++;
			}
			_Period = _ParentPulse.Period * num;
		}

		private void Update()
		{
			if (!_doSubPulse)
			{
				return;
			}
			while (AudioSettings.dspTime + GATInfo.PulseLatency > _pulseInfo.NextPulseDspTime)
			{
				UpdateVariablePeriodPulse();
				Pulse();
				if (_pulseInfo.NextStepIndex == 0)
				{
					if (SubPulseMode != PeriodMode.Hyper)
					{
						_doSubPulse = false;
					}
					if (_oneShot)
					{
						_Bypass = true;
						_oneShot = false;
					}
				}
			}
		}
	}
}
