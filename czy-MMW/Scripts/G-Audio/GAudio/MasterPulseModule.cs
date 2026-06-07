using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public class MasterPulseModule : PulseModule
	{
		[SerializeField]
		protected bool _StartPulseAuto = true;

		[SerializeField]
		protected double _StartDelay = 1.0;

		protected bool _isPulsing;

		private double _newPeriod;

		private bool _newPeriodPending;

		public bool StartPulseAuto
		{
			get
			{
				return _StartPulseAuto;
			}
			set
			{
				if (_StartPulseAuto != value)
				{
					_StartPulseAuto = value;
				}
			}
		}

		public double StartDelay
		{
			get
			{
				return _StartDelay;
			}
			set
			{
				if (_StartDelay != value)
				{
					_StartDelay = value;
				}
			}
		}

		public bool IsPulsing => _isPulsing;

		public override IGATPulseInfo MasterPulseInfo => _pulseInfo;

		public double NewPeriod
		{
			get
			{
				return _newPeriod;
			}
			set
			{
				_newPeriod = value;
				_newPeriodPending = !Mathf.Approximately((float)_newPeriod, (float)base.Period);
			}
		}

		public void StartPulsing(int stepIndex, double dspTime = 0.0)
		{
			if (!_isPulsing)
			{
				if (dspTime > AudioSettings.dspTime)
				{
					_pulseInfo.SetStart(dspTime, stepIndex);
				}
				else
				{
					_pulseInfo.SetStart(AudioSettings.dspTime + GATInfo.PulseLatency, stepIndex);
				}
				_isPulsing = true;
			}
		}

		public void Stop()
		{
			_isPulsing = false;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_pulseInfo.Init(_Period, _Steps.Length);
			if (_isPulsing)
			{
				Stop();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (_isPulsing)
			{
				Stop();
			}
		}

		private void Start()
		{
			if (_StartPulseAuto)
			{
				StartPulsing(0, GATInfo.SyncDspTime + _StartDelay);
			}
		}

		private void Update()
		{
			if (!_isPulsing)
			{
				return;
			}
			while (AudioSettings.dspTime + GATInfo.PulseLatency > _pulseInfo.NextPulseDspTime)
			{
				if (_newPeriodPending)
				{
					base.Period = NewPeriod;
					_newPeriodPending = false;
				}
				Pulse();
			}
		}
	}
}
