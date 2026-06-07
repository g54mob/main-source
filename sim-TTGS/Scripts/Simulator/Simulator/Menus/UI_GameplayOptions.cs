using Simulator.CustomSettings;
using UnityEngine;

namespace Simulator.Menus
{
	public class UI_GameplayOptions : MonoBehaviour
	{
		[SerializeField]
		private UI_LanguageOption m_languageOptionUI;

		[SerializeField]
		private UI_DropdownPlayerPrefEnumOptions<GameplayApplicationOptions.ECurrency> m_currencyOptionsUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_automaticSaveFrequencyOptionsUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_automaticSaveLimitOptionsUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_sensitivityMouseOptionsUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_sensitivityGamepadOptionsUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_cameraInvertPitchUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_cameraInvertYawUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_cashRegisterLockMovementOptionsUI;

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_delayBetweenPiecesPlugInUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_tutorialOptionsUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_headBobbingOptionsUI;

		private void Awake()
		{
			m_languageOptionUI.Awake();
			m_currencyOptionsUI.Init(GameplayApplicationOptions.Currency);
			m_currencyOptionsUI.Awake();
			m_automaticSaveFrequencyOptionsUI.Init(GameplayApplicationOptions.AutomaticSaveFrequency);
			m_automaticSaveFrequencyOptionsUI.Awake();
			m_automaticSaveLimitOptionsUI.Init(GameplayApplicationOptions.AutomaticSaveLimit);
			m_automaticSaveLimitOptionsUI.Awake();
			m_sensitivityMouseOptionsUI.Init(GameplayApplicationOptions.SensitivityMouse);
			m_sensitivityMouseOptionsUI.Awake();
			m_sensitivityGamepadOptionsUI.Init(GameplayApplicationOptions.SensitivityGamepad);
			m_sensitivityGamepadOptionsUI.Awake();
			m_cameraInvertPitchUI.Init(GameplayApplicationOptions.CameraInvertPitch);
			m_cameraInvertPitchUI.Awake();
			m_cameraInvertYawUI.Init(GameplayApplicationOptions.CameraInvertYaw);
			m_cameraInvertYawUI.Awake();
			m_cashRegisterLockMovementOptionsUI.Init(GameplayApplicationOptions.CashRegisterLockMovement);
			m_cashRegisterLockMovementOptionsUI.Awake();
			m_delayBetweenPiecesPlugInUI.Init(GameplayApplicationOptions.DelayBetweenPiecesPlugIn);
			m_delayBetweenPiecesPlugInUI.Awake();
			m_tutorialOptionsUI.Init(GameplayApplicationOptions.Tutorial);
			m_tutorialOptionsUI.Awake();
			m_headBobbingOptionsUI.Init(GameplayApplicationOptions.HeadBobbing);
			m_headBobbingOptionsUI.Awake();
		}

		private void OnEnable()
		{
			m_languageOptionUI.OnEnable();
			m_currencyOptionsUI.OnEnable();
			m_automaticSaveFrequencyOptionsUI.OnEnable();
			m_automaticSaveLimitOptionsUI.OnEnable();
			m_sensitivityMouseOptionsUI.OnEnable();
			m_sensitivityGamepadOptionsUI.OnEnable();
			m_cameraInvertPitchUI.OnEnable();
			m_cameraInvertYawUI.OnEnable();
			m_cashRegisterLockMovementOptionsUI.OnEnable();
			m_delayBetweenPiecesPlugInUI.OnEnable();
			m_tutorialOptionsUI.OnEnable();
			m_headBobbingOptionsUI.OnEnable();
		}

		private void OnDisable()
		{
			m_languageOptionUI.OnDisable();
			m_currencyOptionsUI.OnDisable();
			m_automaticSaveFrequencyOptionsUI.OnDisable();
			m_automaticSaveLimitOptionsUI.OnDisable();
			m_sensitivityMouseOptionsUI.OnDisable();
			m_sensitivityGamepadOptionsUI.OnDisable();
			m_cameraInvertPitchUI.OnDisable();
			m_cameraInvertYawUI.OnDisable();
			m_cashRegisterLockMovementOptionsUI.OnDisable();
			m_delayBetweenPiecesPlugInUI.OnDisable();
			m_tutorialOptionsUI.OnDisable();
			m_headBobbingOptionsUI.OnDisable();
		}
	}
}
