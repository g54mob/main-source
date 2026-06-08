using System;
using Timberborn.Automation;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.DuplicationSystem;
using Timberborn.Persistence;
using Timberborn.TickSystem;
using Timberborn.WaterSystem;
using Timberborn.WorldPersistence;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public class Valve : TickableComponent, IAwakableComponent, IFinishedStateListener, IUnfinishedStateListener, IPersistentEntity, IDuplicable<Valve>, IDuplicable, ITerminal
	{
		public static readonly float ReactionSpeedMin = 0.01f;

		public static readonly float ReactionSpeedMax = 1f;

		private static readonly ComponentKey ComponentKey = new ComponentKey("Valve");

		private static readonly PropertyKey<bool> IsSynchronizedKey = new PropertyKey<bool>("IsSynchronized");

		private static readonly PropertyKey<bool> OutflowLimitEnabledKey = new PropertyKey<bool>("OutflowLimitEnabled");

		private static readonly PropertyKey<float> OutflowLimitKey = new PropertyKey<float>("OutflowLimit");

		private static readonly PropertyKey<bool> AutomationOutflowLimitEnabledKey = new PropertyKey<bool>("AutomationOutflowLimitEnabled");

		private static readonly PropertyKey<float> AutomationOutflowLimitKey = new PropertyKey<float>("AutomationOutflowLimit");

		private static readonly PropertyKey<float> ReactionSpeedKey = new PropertyKey<float>("ReactionSpeed");

		private static readonly PropertyKey<float> CurrentOutflowLimitKey = new PropertyKey<float>("CurrentOutflowLimit");

		private static readonly PropertyKey<int> LastSignKey = new PropertyKey<int>("LastSign");

		private static readonly PropertyKey<int> TicksWithCurrentSignKey = new PropertyKey<int>("TicksWithCurrentSign");

		private readonly IWaterService _waterService;

		private readonly ValveSynchronizer _valveSynchronizer;

		private BlockObject _blockObject;

		private Automatable _automatable;

		private ValveSpec _valveSpec;

		private WaterObstacleController _waterObstacleController;

		private int _lastSign;

		private int _ticksWithCurrentSign;

		public bool IsSynchronized { get; private set; } = true;

		public bool OutflowLimitEnabled { get; private set; }

		public float OutflowLimit { get; private set; }

		public bool AutomationOutflowLimitEnabled { get; private set; }

		public float AutomationOutflowLimit { get; private set; }

		public float ReactionSpeed { get; private set; }

		public float? CurrentOutflowLimit { get; private set; }

		public float MaxOutflowLimit => _valveSpec.MaxOutflowLimit;

		public float OutflowLimitStep => _valveSpec.OutflowLimitStep;

		public float ReactionSpeedStep => _valveSpec.ReactionSpeedStep;

		public bool IsAutomated => _automatable.IsAutomated;

		public bool IsInputOn => _automatable.State == ConnectionState.On;

		public ValveState? State
		{
			get
			{
				if (base.Enabled && _automatable.IsAutomated)
				{
					float num = GetTargetOutflowLimit() ?? float.PositiveInfinity;
					float num2 = CurrentOutflowLimit ?? float.PositiveInfinity;
					if (num.Equals(num2))
					{
						return ValveState.Idle;
					}
					if (num > num2)
					{
						return ValveState.Opening;
					}
					if (num < num2)
					{
						return ValveState.Closing;
					}
				}
				return null;
			}
		}

		private float EffectiveReactionSpeed
		{
			get
			{
				if (!_automatable.IsAutomated)
				{
					return 1f;
				}
				return ReactionSpeed;
			}
		}

		internal Valve(IWaterService waterService, ValveSynchronizer valveSynchronizer)
		{
			_waterService = waterService;
			_valveSynchronizer = valveSynchronizer;
		}

		public void Awake()
		{
			_blockObject = GetComponent<BlockObject>();
			_automatable = GetComponent<Automatable>();
			_valveSpec = GetComponent<ValveSpec>();
			_waterObstacleController = GetComponent<WaterObstacleController>();
			OutflowLimitEnabled = _valveSpec.DefaultOutflowLimitEnabled;
			OutflowLimit = _valveSpec.DefaultOutflowLimit;
			AutomationOutflowLimitEnabled = _valveSpec.DefaultAutomationOutflowLimitEnabled;
			AutomationOutflowLimit = _valveSpec.DefaultAutomationOutflowLimit;
			ReactionSpeed = 1f;
			DisableComponent();
			_automatable.InputReconnected += OnAutomatableInputReconnected;
		}

		public void Save(IEntitySaver entitySaver)
		{
			IObjectSaver component = entitySaver.GetComponent(ComponentKey);
			component.Set(IsSynchronizedKey, IsSynchronized);
			component.Set(OutflowLimitEnabledKey, OutflowLimitEnabled);
			component.Set(OutflowLimitKey, OutflowLimit);
			component.Set(AutomationOutflowLimitEnabledKey, AutomationOutflowLimitEnabled);
			component.Set(AutomationOutflowLimitKey, AutomationOutflowLimit);
			if (CurrentOutflowLimit.HasValue)
			{
				component.Set(CurrentOutflowLimitKey, CurrentOutflowLimit.Value);
			}
			component.Set(ReactionSpeedKey, ReactionSpeed);
			component.Set(LastSignKey, _lastSign);
			component.Set(TicksWithCurrentSignKey, _ticksWithCurrentSign);
		}

		[BackwardCompatible(2026, 2, 6, Compatibility.Save)]
		public void Load(IEntityLoader entityLoader)
		{
			IObjectLoader component = entityLoader.GetComponent(ComponentKey);
			IsSynchronized = component.Get(IsSynchronizedKey);
			SetOutflowLimitEnabled(component.Has(OutflowLimitEnabledKey) && component.Get(OutflowLimitEnabledKey));
			SetOutflowLimit(component.Has(OutflowLimitKey) ? component.Get(OutflowLimitKey) : 0f);
			SetAutomationOutflowLimitEnabled(component.Has(AutomationOutflowLimitEnabledKey) && component.Get(AutomationOutflowLimitEnabledKey));
			SetAutomationOutflowLimit(component.Has(AutomationOutflowLimitKey) ? component.Get(AutomationOutflowLimitKey) : 0f);
			SetReactionSpeed(component.Has(ReactionSpeedKey) ? component.Get(ReactionSpeedKey) : ReactionSpeedMax);
			CurrentOutflowLimit = (component.Has(CurrentOutflowLimitKey) ? new float?(component.Get(CurrentOutflowLimitKey)) : ((float?)null));
			_lastSign = (component.Has(LastSignKey) ? component.Get(LastSignKey) : 0);
			_ticksWithCurrentSign = (component.Has(TicksWithCurrentSignKey) ? component.Get(TicksWithCurrentSignKey) : 0);
		}

		public void DuplicateFrom(Valve source)
		{
			IsSynchronized = source.IsSynchronized;
			SetOutflowLimit(source.OutflowLimit);
			SetOutflowLimitEnabled(source.OutflowLimitEnabled);
			SetAutomationOutflowLimit(source.AutomationOutflowLimit);
			SetAutomationOutflowLimitEnabled(source.AutomationOutflowLimitEnabled);
			SetReactionSpeed(source.ReactionSpeed);
			SynchronizeNeighbors();
		}

		public void OnEnterUnfinishedState()
		{
			_valveSynchronizer.SynchronizeWithUnfinishedNeighbors(this);
		}

		public void OnExitUnfinishedState()
		{
		}

		public void OnEnterFinishedState()
		{
			EnableComponent();
			_waterService.AddDirectionLimiter(_blockObject.Coordinates, _blockObject.Orientation.ToFlowDirection());
		}

		public void OnExitFinishedState()
		{
			DisableComponent();
			ClearLimit();
			_waterService.RemoveDirectionLimiter(_blockObject.Coordinates);
		}

		public override void Tick()
		{
			TickCurrentOutflowLimit();
			ApplyCurrentOutflowLimit();
		}

		public void SetOutflowLimitEnabledAndSynchronize(bool value)
		{
			SetOutflowLimitEnabled(value);
			SynchronizeNeighbors();
		}

		public void SetOutflowLimitEnabled(bool value)
		{
			OutflowLimitEnabled = value;
		}

		public void SetOutflowLimitAndSynchronize(float value)
		{
			SetOutflowLimit(value);
			SynchronizeNeighbors();
		}

		public void SetOutflowLimit(float value)
		{
			OutflowLimit = value;
		}

		public void SetAutomationOutflowLimitEnabledAndSynchronize(bool value)
		{
			SetAutomationOutflowLimitEnabled(value);
			SynchronizeNeighbors();
		}

		public void SetAutomationOutflowLimitEnabled(bool value)
		{
			AutomationOutflowLimitEnabled = value;
		}

		public void SetAutomationOutflowLimitAndSynchronize(float value)
		{
			SetAutomationOutflowLimit(value);
			SynchronizeNeighbors();
		}

		public void SetAutomationOutflowLimit(float value)
		{
			AutomationOutflowLimit = value;
		}

		public void SetReactionSpeedAndSynchronize(float value)
		{
			SetReactionSpeed(value);
			SynchronizeNeighbors();
		}

		public void SetReactionSpeed(float value)
		{
			ReactionSpeed = Mathf.Clamp(value, ReactionSpeedMin, ReactionSpeedMax);
		}

		public void ToggleSynchronization(bool value)
		{
			IsSynchronized = value;
			_valveSynchronizer.SynchronizeWithAllNeighbors(this);
		}

		public void Evaluate()
		{
		}

		private void OnAutomatableInputReconnected(object sender, EventArgs e)
		{
			if (IsSynchronized)
			{
				SynchronizeNeighbors();
			}
		}

		private void TickCurrentOutflowLimit()
		{
			float? targetOutflowLimit = GetTargetOutflowLimit();
			UpdateTicksWithCurrentSign(targetOutflowLimit);
			if (!CurrentOutflowLimit.Equals(targetOutflowLimit))
			{
				float num = targetOutflowLimit ?? float.PositiveInfinity;
				float? currentOutflowLimit = CurrentOutflowLimit;
				float valueOrDefault = currentOutflowLimit.GetValueOrDefault();
				if (!currentOutflowLimit.HasValue)
				{
					valueOrDefault = MaxOutflowLimit;
					float? currentOutflowLimit2 = valueOrDefault;
					CurrentOutflowLimit = currentOutflowLimit2;
				}
				if (CurrentOutflowLimit < num)
				{
					CurrentOutflowLimit = Mathf.Min(CurrentOutflowLimit.Value + RateOfChange(), num);
				}
				else if (CurrentOutflowLimit > num)
				{
					CurrentOutflowLimit = Mathf.Max(CurrentOutflowLimit.Value - RateOfChange(), num);
				}
				if (CurrentOutflowLimit > MaxOutflowLimit)
				{
					CurrentOutflowLimit = null;
				}
			}
		}

		private void ClearLimit()
		{
			CurrentOutflowLimit = null;
			ApplyCurrentOutflowLimit();
		}

		private void ApplyCurrentOutflowLimit()
		{
			_waterObstacleController.UpdateState(CurrentOutflowLimit == 0f);
			if (CurrentOutflowLimit.HasValue)
			{
				_waterService.SetInflowLimit(_blockObject.Coordinates, CurrentOutflowLimit.Value);
			}
			else
			{
				_waterService.RemoveInflowLimit(_blockObject.Coordinates);
			}
		}

		private float? GetTargetOutflowLimit()
		{
			if (base.Enabled)
			{
				if (_automatable.IsAutomated && _automatable.State == ConnectionState.On)
				{
					if (!AutomationOutflowLimitEnabled)
					{
						return null;
					}
					return Mathf.Min(AutomationOutflowLimit, MaxOutflowLimit);
				}
				if (!OutflowLimitEnabled)
				{
					return null;
				}
				return Mathf.Min(OutflowLimit, MaxOutflowLimit);
			}
			return null;
		}

		private void UpdateTicksWithCurrentSign(float? targetOutflowLimit)
		{
			float num = targetOutflowLimit ?? float.PositiveInfinity;
			int num2 = (CurrentOutflowLimit.HasValue ? Math.Sign(num - CurrentOutflowLimit.Value) : (targetOutflowLimit.HasValue ? (-1) : 0));
			if (num2 != _lastSign)
			{
				_lastSign = num2;
				_ticksWithCurrentSign = 0;
			}
			else
			{
				_ticksWithCurrentSign++;
			}
		}

		private float RateOfChange()
		{
			float t = Mathf.Pow(EffectiveReactionSpeed, _valveSpec.ReactionSpeedExponent);
			float a = Mathf.Lerp(_valveSpec.RateOfChangeLowPrimary, _valveSpec.RateOfChangeHighPrimary, t);
			float b = Mathf.Lerp(_valveSpec.RateOfChangeLowSecondary, _valveSpec.RateOfChangeHighSecondary, t);
			return Mathf.Lerp(a, b, (float)(_ticksWithCurrentSign - _valveSpec.RateOfChangePrimaryTicks) / (float)_valveSpec.RateOfChangePrimaryToSecondaryTicks);
		}

		private void SynchronizeNeighbors()
		{
			_valveSynchronizer.SynchronizeAllNeighbors(this);
		}
	}
}
