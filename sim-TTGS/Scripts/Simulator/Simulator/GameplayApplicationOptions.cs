using System.Globalization;
using Dhs5.Utility.Settings;
using I2.Loc;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Settings("Application Settings/Gameplay", Scope.Project)]
	public class GameplayApplicationOptions : CustomApplicationOptions<GameplayApplicationOptions>
	{
		public enum ECurrency
		{
			DOLLAR = 0,
			EURO = 1
		}

		[SerializeField]
		private PlayerPrefEnum<ECurrency> m_currency;

		[SerializeField]
		private PlayerPrefFloat m_automaticSaveFrequency;

		[SerializeField]
		private PlayerPrefFloat m_automaticSaveLimit;

		[SerializeField]
		private PlayerPrefFloat m_sensitivityMouse;

		[SerializeField]
		private PlayerPrefFloat m_sensitivityGamepad;

		[SerializeField]
		private PlayerPrefBool m_cameraInvertPitch;

		[SerializeField]
		private PlayerPrefBool m_cameraInvertYaw;

		[SerializeField]
		private PlayerPrefBool m_cashRegisterLockMovement;

		[SerializeField]
		private PlayerPrefFloat m_delayBetweenPiecesPlugIn;

		[SerializeField]
		private PlayerPrefBool m_tutorial;

		[SerializeField]
		private PlayerPrefBool m_headBobbing;

		[Header("Sensitivity")]
		[SerializeField]
		private EnumValues<EPOVCameraInputProvider, float> m_sensitivityByProvider;

		public static PlayerPrefEnum<ECurrency> Currency => CustomSettings<GameplayApplicationOptions>.I.m_currency;

		public static PlayerPrefFloat AutomaticSaveFrequency => CustomSettings<GameplayApplicationOptions>.I.m_automaticSaveFrequency;

		public static PlayerPrefFloat AutomaticSaveLimit => CustomSettings<GameplayApplicationOptions>.I.m_automaticSaveLimit;

		public static PlayerPrefFloat SensitivityMouse => CustomSettings<GameplayApplicationOptions>.I.m_sensitivityMouse;

		public static PlayerPrefFloat SensitivityGamepad => CustomSettings<GameplayApplicationOptions>.I.m_sensitivityGamepad;

		public static PlayerPrefFloat Sensitivity
		{
			get
			{
				if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.KEYBOARD)
				{
					return SensitivityGamepad;
				}
				return SensitivityMouse;
			}
		}

		public static PlayerPrefBool CameraInvertPitch => CustomSettings<GameplayApplicationOptions>.I.m_cameraInvertPitch;

		public static PlayerPrefBool CameraInvertYaw => CustomSettings<GameplayApplicationOptions>.I.m_cameraInvertYaw;

		public static PlayerPrefBool CashRegisterLockMovement => CustomSettings<GameplayApplicationOptions>.I.m_cashRegisterLockMovement;

		public static PlayerPrefFloat DelayBetweenPiecesPlugIn => CustomSettings<GameplayApplicationOptions>.I.m_delayBetweenPiecesPlugIn;

		public static PlayerPrefBool Tutorial => CustomSettings<GameplayApplicationOptions>.I.m_tutorial;

		public static PlayerPrefBool HeadBobbing => CustomSettings<GameplayApplicationOptions>.I.m_headBobbing;

		public float GetSensitivityByProvider(EPOVCameraInputProvider cameraInputProvider)
		{
			return m_sensitivityByProvider[cameraInputProvider];
		}

		public void SetLanguage(string language)
		{
			LocalizationManager.CurrentLanguage = language;
		}

		public override void Load()
		{
			m_currency.Load();
			m_automaticSaveFrequency.Load();
			m_automaticSaveLimit.Load();
			m_sensitivityMouse.Load();
			m_sensitivityGamepad.Load();
			m_cameraInvertPitch.Load();
			m_cameraInvertYaw.Load();
			m_cashRegisterLockMovement.Load();
			m_delayBetweenPiecesPlugIn.Load();
			m_tutorial.Load();
			m_headBobbing.Load();
		}

		public override void ResetSettings()
		{
			SetLanguage(LocalizationManager.GetCurrentDeviceLanguage());
			m_currency.Reset();
			m_automaticSaveFrequency.Reset();
			m_automaticSaveLimit.Reset();
			m_sensitivityMouse.Reset();
			m_sensitivityGamepad.Reset();
			m_cameraInvertPitch.Reset();
			m_cameraInvertYaw.Reset();
			m_cashRegisterLockMovement.Reset();
			m_delayBetweenPiecesPlugIn.Reset();
			m_tutorial.Reset();
			m_headBobbing.Reset();
		}

		public static string GetCurrencySymbol()
		{
			return ((Currency.Value == ECurrency.DOLLAR) ? new CultureInfo("en-US") : new CultureInfo("fr-FR")).NumberFormat.CurrencySymbol;
		}
	}
}
