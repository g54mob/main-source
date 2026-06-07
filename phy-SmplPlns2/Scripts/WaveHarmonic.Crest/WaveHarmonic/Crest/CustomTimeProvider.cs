using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Time/Crest Custom Time Provider")]
	public sealed class CustomTimeProvider : TimeProvider
	{
		[Tooltip("Freeze progression of time. Only works properly in Play mode.")]
		[SerializeField]
		private bool _Paused;

		[Tooltip("Whether to override the water simulation time.")]
		[SerializeField]
		private bool _OverrideTime;

		[Tooltip("The time override value.")]
		[SerializeField]
		private float _Time;

		[Tooltip("Whether to override the water simulation time.\n\nThis in particular affects dynamic elements of the simulation like the foam simulation and the ripple simulation.")]
		[SerializeField]
		private bool _OverrideDeltaTime;

		[Tooltip("The delta time override value.")]
		[SerializeField]
		private float _DeltaTime;

		private readonly DefaultTimeProvider _DefaultTimeProvider = new DefaultTimeProvider();

		private float _TimeInternal;

		private bool _FirstUpdate = true;

		public float DeltaTime
		{
			get
			{
				return _DeltaTime;
			}
			set
			{
				_DeltaTime = value;
			}
		}

		public bool OverrideDeltaTime
		{
			get
			{
				return _OverrideDeltaTime;
			}
			set
			{
				_OverrideDeltaTime = value;
			}
		}

		public bool OverrideTime
		{
			get
			{
				return _OverrideTime;
			}
			set
			{
				_OverrideTime = value;
			}
		}

		public bool Paused
		{
			get
			{
				return _Paused;
			}
			set
			{
				_Paused = value;
			}
		}

		public float TimeOverride
		{
			get
			{
				return _Time;
			}
			set
			{
				_Time = value;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		public override float Time
		{
			get
			{
				if (!base.isActiveAndEnabled)
				{
					return _DefaultTimeProvider.Time;
				}
				if (_OverrideTime)
				{
					return _Time;
				}
				return _TimeInternal;
			}
		}

		public override float Delta
		{
			get
			{
				if (!base.isActiveAndEnabled)
				{
					return _DefaultTimeProvider.Delta;
				}
				if (_Paused)
				{
					return 0f;
				}
				if (_OverrideDeltaTime)
				{
					return _DeltaTime;
				}
				return _DefaultTimeProvider.Delta;
			}
		}

		private protected override void Initialize()
		{
			base.Initialize();
			_FirstUpdate = true;
		}

		private void OnUpdate(WaterRenderer water)
		{
			if (_FirstUpdate)
			{
				_TimeInternal = _DefaultTimeProvider.Time;
				_FirstUpdate = false;
			}
			else if (!_Paused)
			{
				_TimeInternal += _DefaultTimeProvider.Delta;
			}
		}
	}
}
