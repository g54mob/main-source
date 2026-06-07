using Assets.Scripts.Flight.Combat.Predictor;
using Jundroo.Common.Events;
using Jundroo.Common.Platform;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class PhysicsQualitySettings : SettingsCategory<PhysicsQualitySettings>
	{
		public enum PhysicsQualityLevel
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		public enum PredictorQualityLevel
		{
			Off = 0,
			Low = 1,
			Medium = 2,
			High = 3
		}

		private class PhysicsSettingsApplicator
		{
			private readonly PhysicsQualitySettings _quality;

			private bool IsReady
			{
				get
				{
					if (!Game.Instance.XRDeviceManager.HmdActive)
					{
						return true;
					}
					return Game.Instance.XRDeviceManager.GetPrimaryDisplayRefreshRate() > 0f;
				}
			}

			public PhysicsSettingsApplicator(PhysicsQualitySettings quality)
			{
				_quality = quality;
			}

			public bool Apply()
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					bool flag = false;
					if (IsReady)
					{
						ApplyPhysicsSettings();
						flag = true;
					}
					return !flag;
				});
				return IsReady;
			}

			private void ApplyPhysicsSettings()
			{
				if (Device.IsMobileBuild)
				{
					if ((PhysicsQualityLevel)_quality.PhysicsQuality == PhysicsQualityLevel.Low)
					{
						Physics.defaultSolverIterations = 7;
						Time.fixedDeltaTime = GetMobileFixedDeltaTime(0.02f);
					}
					else if ((PhysicsQualityLevel)_quality.PhysicsQuality == PhysicsQualityLevel.Medium)
					{
						Physics.defaultSolverIterations = 10;
						Time.fixedDeltaTime = GetMobileFixedDeltaTime(0.01f);
					}
					else
					{
						Physics.defaultSolverIterations = 15;
						Time.fixedDeltaTime = GetMobileFixedDeltaTime(0.01f);
					}
				}
				else
				{
					if ((PhysicsQualityLevel)_quality.PhysicsQuality == PhysicsQualityLevel.Low)
					{
						Physics.defaultSolverIterations = 15;
					}
					else if ((PhysicsQualityLevel)_quality.PhysicsQuality == PhysicsQualityLevel.Medium)
					{
						Physics.defaultSolverIterations = 20;
					}
					else
					{
						Physics.defaultSolverIterations = 25;
					}
					Time.fixedDeltaTime = GetDesktopFixedDeltaTime(0.01f);
				}
				_quality.FixedDeltaTime = Time.fixedDeltaTime;
				PredictorSettings.ApplySettings(_quality, recalculate: false);
			}

			private float GetDesktopFixedDeltaTime(float nonVrFixedDeltaTime)
			{
				float fixedDeltaTime;
				if (Game.Instance.XRDeviceManager.HmdActive)
				{
					float primaryDisplayRefreshRate = Game.Instance.XRDeviceManager.GetPrimaryDisplayRefreshRate();
					fixedDeltaTime = 1f / primaryDisplayRefreshRate;
				}
				else
				{
					fixedDeltaTime = nonVrFixedDeltaTime;
				}
				return VerifyFixedDeltaTime(fixedDeltaTime);
			}

			private float GetMobileFixedDeltaTime(float nonVrFixedDeltaTime)
			{
				float fixedDeltaTime;
				if (Game.Instance.Device.IsAndroidVRBuild)
				{
					float primaryDisplayRefreshRate = Game.Instance.XRDeviceManager.GetPrimaryDisplayRefreshRate();
					fixedDeltaTime = 1f / primaryDisplayRefreshRate;
					if (!Utilities.CompareFloats(primaryDisplayRefreshRate, 72f))
					{
						Debug.LogWarning($"Unexpected Quest refresh rate: {primaryDisplayRefreshRate}");
					}
				}
				else
				{
					fixedDeltaTime = nonVrFixedDeltaTime;
				}
				return VerifyFixedDeltaTime(fixedDeltaTime);
			}

			private float VerifyFixedDeltaTime(float fixedDeltaTime)
			{
				if (fixedDeltaTime > 0.02f)
				{
					Debug.LogError($"XR Physics Framerate Syc Failure: fixedDeltaTime verification failed: {fixedDeltaTime} > MaxFixedDeltaTime ({0.02f}).  Physics rate would be {1f / fixedDeltaTime}fps.");
					fixedDeltaTime = 0.02f;
				}
				return fixedDeltaTime;
			}
		}

		public float FixedDeltaTime { get; private set; }

		public EnumSetting<PhysicsQualityLevel> PhysicsQuality { get; private set; }

		public EnumSetting<PredictorQualityLevel> PredictorQuality { get; private set; }

		public PhysicsQualitySettings()
			: base("Physics")
		{
		}

		public void ApplyUnityPhysicsSettings()
		{
			new PhysicsSettingsApplicator(this).Apply();
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			if (preset != SettingsCategoryPreset.Custom)
			{
				_ = preset - 3;
				_ = 4;
			}
		}

		protected override void InitializeSettings()
		{
			PhysicsQuality = CreateEnum<PhysicsQualityLevel>("Physics").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("Adjusts the quality of the physics simulation. Lower quality levels can improve performance in CPU limited situations. At lower quality levels some craft may become unstable, resulting in vibrations, oscillations, bouncing, exploding, and other forms of chaos.").SetDefault(PhysicsQualityLevel.High)
				.SetState(SettingState.Hidden);
			PredictorQuality = CreateEnum<PredictorQualityLevel>("Predictor").SetRaiseChangedEventOnlyWhenCommitted(value: false).SetDescription("The precision and quality of the visual bomb trajectory predictor").SetDefault(PredictorQualityLevel.High)
				.SetState(SettingState.Hidden);
		}

		protected override void OnInitializationComplete()
		{
			base.OnInitializationComplete();
			PhysicsQuality.Changed += delegate
			{
				ApplyUnityPhysicsSettings();
			};
			PhysicsQuality.RaiseSettingChangedEvent();
			PredictorQuality.Changed += delegate
			{
				ApplyPredictorSettings();
			};
			PredictorQuality.RaiseSettingChangedEvent();
		}

		private void ApplyPredictorSettings()
		{
			PredictorSettings.ApplySettings(this);
		}
	}
}
