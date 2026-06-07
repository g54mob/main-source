using System;
using ModApi.Craft;
using ModApi.Settings;
using ModApi.Settings.Core.Events;

namespace Assets.Scripts.Craft
{
	public abstract class WaterPhysics<T> : IWaterPhysics<T> where T : IWaterPhysics<T>
	{
		protected enum WaterState
		{
			Enter = 0,
			Exit = 1,
			Stay = 2,
			Out = 3
		}

		private bool _disposed;

		private PrecisionModeType _precisionMode = PrecisionModeType.High;

		private float _underWaterAmount;

		public abstract IBodyScript BodyScript { get; }

		public float DisplacedVolume { get; protected set; }

		public float DisplacedVolumeScaled { get; protected set; }

		public bool IsFullySubmerged { get; private set; }

		public bool IsInWater { get; private set; }

		public virtual PrecisionModeType PrecisionMode
		{
			get
			{
				return _precisionMode;
			}
			set
			{
				_precisionMode = value;
			}
		}

		public float TotalDisplacementVolume { get; protected set; }

		public float TotalDisplacementVolumeScaled { get; protected set; }

		public virtual float UnderWaterAmount
		{
			get
			{
				return _underWaterAmount;
			}
			protected set
			{
				_underWaterAmount = value;
				IsInWater = value > 0f;
				IsFullySubmerged = value == 1f;
				DisplacedVolume = TotalDisplacementVolume * value;
			}
		}

		public virtual event WaterPhysicsHandler<T> WaterEntered
		{
			add
			{
				_waterEntered += value;
			}
			remove
			{
				_waterEntered -= value;
			}
		}

		public virtual event WaterPhysicsHandler<T> WaterExited
		{
			add
			{
				_waterExited += value;
			}
			remove
			{
				_waterExited -= value;
			}
		}

		public virtual event WaterPhysicsHandler<T> WaterStay
		{
			add
			{
				_waterStay += value;
			}
			remove
			{
				_waterStay -= value;
			}
		}

		protected event WaterPhysicsHandler<T> _waterEntered;

		protected event WaterPhysicsHandler<T> _waterExited;

		protected event WaterPhysicsHandler<T> _waterStay;

		~WaterPhysics()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public abstract void Update();

		protected static WaterState GetState(bool isCurrentlyInWater, bool previouslyInWater)
		{
			if (isCurrentlyInWater)
			{
				if (!previouslyInWater)
				{
					return WaterState.Enter;
				}
				return WaterState.Stay;
			}
			if (previouslyInWater)
			{
				return WaterState.Exit;
			}
			return WaterState.Out;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				Game.Instance.QualitySettings.Physics.WaterPhysics.Changed -= OnQualityChanged;
				_disposed = true;
			}
		}

		protected void InitializeBase()
		{
			Game.Instance.QualitySettings.Physics.WaterPhysics.Changed += OnQualityChanged;
			SetQuality(Game.Instance.QualitySettings.Physics.WaterPhysics);
		}

		protected virtual void OnQualityChanged(object sender, SettingChangedEventArgs<PhysicsQualitySettings.WaterPhysicsQuality> e)
		{
			SetQuality(e.Setting);
		}

		protected void SendEvents(WaterState state, T source)
		{
			switch (state)
			{
			case WaterState.Exit:
				this._waterExited?.Invoke(source);
				break;
			case WaterState.Enter:
				this._waterEntered?.Invoke(source);
				break;
			case WaterState.Stay:
				this._waterStay?.Invoke(source);
				break;
			case WaterState.Out:
				break;
			}
		}

		protected virtual void SetQuality(PhysicsQualitySettings.WaterPhysicsQuality newQuality)
		{
			if (PrecisionMode != PrecisionModeType.NotifyOnly)
			{
				switch (newQuality)
				{
				case PhysicsQualitySettings.WaterPhysicsQuality.Low:
					PrecisionMode = PrecisionModeType.Low;
					break;
				case PhysicsQualitySettings.WaterPhysicsQuality.Medium:
					PrecisionMode = PrecisionModeType.Med;
					break;
				case PhysicsQualitySettings.WaterPhysicsQuality.High:
					PrecisionMode = PrecisionModeType.High;
					break;
				}
			}
		}
	}
}
