using Simulator.CustomSettings;
using UnityEngine;

namespace Simulator.Menus
{
	public class UI_GraphicsOptions : MonoBehaviour
	{
		[SerializeField]
		private UI_QualityOption m_uiQualityOptionUI = new UI_QualityOption();

		[SerializeField]
		private UI_ResolutionOption m_resolutionOptionUI = new UI_ResolutionOption();

		[SerializeField]
		private UI_FramerateOption m_framerateOptionUI = new UI_FramerateOption();

		[SerializeField]
		private UI_ScreenModeOption m_screenModeOptionUI = new UI_ScreenModeOption();

		[SerializeField]
		private UI_SliderPlayerPrefFloatOptions m_fieldOfViewUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_crosshairUI;

		public UI_SliderPlayerPrefFloatOptions FieldOfViewUI => m_fieldOfViewUI;

		public UI_TogglePlayerPrefBoolOptions CrosshairUI => m_crosshairUI;

		private void Awake()
		{
			m_uiQualityOptionUI.Awake();
			m_framerateOptionUI.Awake();
			m_screenModeOptionUI.Awake();
			m_fieldOfViewUI.Init(GraphicsApplicationOptions.FieldOfView);
			m_fieldOfViewUI.Awake();
			m_crosshairUI.Init(GraphicsApplicationOptions.Crosshair);
			m_crosshairUI.Awake();
		}

		private void OnEnable()
		{
			m_resolutionOptionUI.OnEnable();
			m_uiQualityOptionUI.OnEnable();
			m_screenModeOptionUI.OnEnable();
			m_framerateOptionUI.OnEnable();
			m_fieldOfViewUI.OnEnable();
			m_crosshairUI.OnEnable();
		}

		private void OnDisable()
		{
			m_resolutionOptionUI.OnDisable();
			m_uiQualityOptionUI.OnDisable();
			m_screenModeOptionUI.OnDisable();
			m_framerateOptionUI.OnDisable();
			m_fieldOfViewUI.OnDisable();
			m_crosshairUI.OnDisable();
		}
	}
}
