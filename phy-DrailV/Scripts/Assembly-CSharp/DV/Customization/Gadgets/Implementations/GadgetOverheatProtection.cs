using System;
using DV.HUD;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetOverheatProtection : ExternallySwitchableGadget
	{
		private const string KEY_MODE = "mode";

		private const string KEY_CUT = "cut";

		[SerializeField]
		private float[] limits = new float[9] { 120f, 115f, 110f, 105f, 100f, 95f, 90f, 85f, 80f };

		[SerializeField]
		private float actionInterval = 0.5f;

		[SerializeField]
		private float resetTime = 2f;

		public bool cutEngine;

		private bool hasReachedLimit;

		private int modeIndex;

		private float actionTimer;

		private int throttleReduction;

		private int dynBrakeReduction;

		private float ignoreThrottleChange;

		private float ignoreDynBrakeChange;

		public int ModeCount => limits.Length;

		public float CurrentLimit => limits[modeIndex];

		public bool HasReachedLimit
		{
			get
			{
				return hasReachedLimit;
			}
			private set
			{
				if (hasReachedLimit != value)
				{
					hasReachedLimit = value;
					this.HasReachedLimitChanged?.Invoke();
				}
			}
		}

		public int ModeIndex
		{
			get
			{
				return modeIndex;
			}
			set
			{
				modeIndex = Mathf.Clamp(value, 0, limits.Length - 1);
			}
		}

		private bool IsThrottleReduced => throttleReduction > 0;

		private bool IsDynBrakeReduced => dynBrakeReduction > 0;

		public event Action HasReachedLimitChanged;

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			if ((bool)base.Controls)
			{
				if (base.Controls.Throttle != null)
				{
					base.Controls.Throttle.ControlUpdated += OnThrottleUpdated;
				}
				if (base.Controls.DynamicBrake != null)
				{
					base.Controls.DynamicBrake.ControlUpdated += OnDynBrakeUpdated;
				}
			}
		}

		protected override void OnBeforeUnlinked()
		{
			base.OnBeforeUnlinked();
			if ((bool)base.Controls)
			{
				if (base.Controls.Throttle != null)
				{
					base.Controls.Throttle.ControlUpdated -= OnThrottleUpdated;
				}
				if (base.Controls.DynamicBrake != null)
				{
					base.Controls.DynamicBrake.ControlUpdated -= OnDynBrakeUpdated;
				}
			}
		}

		private void Update()
		{
			if (!base.PowerState || !base.ArePlacementRequirementsMet)
			{
				return;
			}
			TryReadPort(STDSimPort.Temperature, out var value);
			HasReachedLimit = value >= CurrentLimit;
			if (cutEngine)
			{
				if (base.Controls.PowerOff != null && HasReachedLimit)
				{
					base.Controls.PowerOff.Set(1f);
				}
				return;
			}
			actionTimer -= Time.deltaTime;
			if (ignoreThrottleChange > 0f && IsThrottleReduced)
			{
				ignoreThrottleChange -= Time.deltaTime;
			}
			if (ignoreDynBrakeChange > 0f && IsDynBrakeReduced)
			{
				ignoreDynBrakeChange -= Time.deltaTime;
			}
			float num = actionInterval * 0.5f;
			if (!(actionTimer < 0f))
			{
				return;
			}
			actionTimer += actionInterval;
			if (HasReachedLimit)
			{
				InteriorControlsManager component = null;
				if (base.TrainCar.loadedInterior != null)
				{
					base.TrainCar.loadedInterior.TryGetComponent<InteriorControlsManager>(out component);
				}
				if ((base.Controls.Throttle?.Value ?? 0f) > 0f)
				{
					if (component != null)
					{
						component.TryUnhandControl(InteriorControlsManager.ControlType.Throttle);
					}
					ignoreThrottleChange = num;
					base.Controls.Throttle.Move(-1f);
					throttleReduction++;
				}
				else if ((base.Controls.DynamicBrake?.Value ?? 0f) > 0f)
				{
					if (component != null)
					{
						component.TryUnhandControl(InteriorControlsManager.ControlType.DynamicBrake);
					}
					ignoreDynBrakeChange = num;
					base.Controls.DynamicBrake.Move(-1f);
					dynBrakeReduction++;
				}
			}
			else
			{
				if (IsThrottleReduced)
				{
					ignoreThrottleChange = num;
					base.Controls.Throttle.Move(1f);
					throttleReduction--;
				}
				if (IsDynBrakeReduced)
				{
					ignoreDynBrakeChange = num;
					base.Controls.DynamicBrake.Move(1f);
					dynBrakeReduction--;
				}
			}
		}

		private void OnDynBrakeUpdated(float val)
		{
			if (IsDynBrakeReduced && ignoreDynBrakeChange <= 0f)
			{
				dynBrakeReduction = 0;
				actionTimer = Mathf.Max(actionTimer, resetTime);
			}
		}

		private void OnThrottleUpdated(float val)
		{
			if (IsThrottleReduced && ignoreThrottleChange <= 0f)
			{
				throttleReduction = 0;
				actionTimer = Mathf.Max(actionTimer, resetTime);
			}
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("mode", modeIndex);
			dst.SetBool("cut", cutEngine);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			ModeIndex = src.GetInt("mode") ?? 0;
			cutEngine = src.GetBool("cut") ?? false;
		}
	}
}
