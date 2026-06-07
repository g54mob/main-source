using System;
using System.Collections.Generic;
using System.Linq;
using Simulator.CustomSettings;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_QualityOption
	{
		[SerializeField]
		private TMP_Dropdown m_qualityDropdown;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_vsync;

		[SerializeField]
		private UI_DropdownPlayerPrefEnumOptions<MSAASamples> m_antialiasing;

		public void Awake()
		{
			m_vsync.Init(GraphicsApplicationOptions.QualityOptions.VSync);
			m_vsync.Awake();
			m_antialiasing.Init(GraphicsApplicationOptions.QualityOptions.Antialiasing);
			m_antialiasing.Awake();
			FillDropDownQuality();
		}

		public void OnEnable()
		{
			DropdownSelectCurrentQuality();
			m_qualityDropdown.onValueChanged.AddListener(SetQuality);
			m_vsync.OnEnable();
			m_vsync.OnValueChanged += OnVsyncValueChanged_UpdateOverallQuality;
			m_antialiasing.OnEnable();
			m_antialiasing.OnValueChanged += OnAntialiasingValueChanged_UpdateOverallQuality;
		}

		public void OnDisable()
		{
			m_qualityDropdown.onValueChanged.RemoveListener(SetQuality);
			m_vsync.OnDisable();
			m_vsync.OnValueChanged -= OnVsyncValueChanged_UpdateOverallQuality;
			m_antialiasing.OnDisable();
			m_antialiasing.OnValueChanged -= OnAntialiasingValueChanged_UpdateOverallQuality;
		}

		private void FillDropDownQuality()
		{
			m_qualityDropdown.ClearOptions();
			List<string> options = QualitySettings.names.ToList();
			m_qualityDropdown.AddOptions(options);
		}

		private void DropdownSelectCurrentQuality()
		{
			m_qualityDropdown.SetValueWithoutNotify(QualitySettings.GetQualityLevel());
		}

		public void SetQuality(int index)
		{
			QualitySettings.SetQualityLevel(index);
			UpdateOverallQuality();
		}

		private void OnVsyncValueChanged_UpdateOverallQuality(bool _)
		{
			UpdateOverallQuality();
		}

		private void OnAntialiasingValueChanged_UpdateOverallQuality(MSAASamples _)
		{
			UpdateOverallQuality();
		}

		private void UpdateOverallQuality()
		{
			GraphicsApplicationOptions.QualityOptions.Update();
		}
	}
}
