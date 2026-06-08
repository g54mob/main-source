using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CRTSettings : MonoBehaviour
{
	public enum DropdownValue
	{
		Strong = 0,
		Medium = 1,
		Light = 2,
		None = 3
	}

	public class SettingFields
	{
		public bool crtEnabled;

		public int chromaticAbberationIndex;

		public int scanLineIndex;

		public SettingFields(bool crtEnabled, int chromaticAbberationIndex, int scanLineIndex)
		{
			this.crtEnabled = crtEnabled;
			this.chromaticAbberationIndex = chromaticAbberationIndex;
			this.scanLineIndex = scanLineIndex;
		}

		public SettingFields(SettingFields other)
		{
			crtEnabled = other.crtEnabled;
			chromaticAbberationIndex = other.chromaticAbberationIndex;
			scanLineIndex = other.scanLineIndex;
		}

		public bool Equals(SettingFields other)
		{
			if (!crtEnabled && !other.crtEnabled)
			{
				return true;
			}
			if (crtEnabled == other.crtEnabled && chromaticAbberationIndex == other.chromaticAbberationIndex)
			{
				return scanLineIndex == other.scanLineIndex;
			}
			return false;
		}
	}

	[SerializeField]
	private Settings settings;

	[SerializeField]
	private Toggle enableCRT;

	[SerializeField]
	private TMP_Dropdown caDropdown;

	[SerializeField]
	private TMP_Dropdown slDropdown;

	[SerializeField]
	private UniversalRendererData rendererData;

	private static readonly string CHROMATIC_ABBERATION_FIELD = "_Intensity";

	private static readonly string SCAN_LINES_FIELD = "_Scan_Lines";

	private Material crtMaterial;

	private Material chromaticAbberMaterial;

	private void Start()
	{
		enableCRT.isOn = IsCrtEnabled();
		SoundEffectUtils.GetNotificationPlayer().AddToggleListener(enableCRT);
		if (enableCRT.isOn)
		{
			caDropdown.value = GetSavedChromaticValue();
			slDropdown.value = GetSavedScanLinesValue();
		}
	}

	public void SetRendererFeatureActive(bool active)
	{
		foreach (ScriptableRendererFeature rendererFeature in rendererData.rendererFeatures)
		{
			Material passMaterial = ((FullScreenPassRendererFeature)rendererFeature).passMaterial;
			if (passMaterial != null)
			{
				if (passMaterial.HasProperty(SCAN_LINES_FIELD))
				{
					crtMaterial = passMaterial;
				}
				if (passMaterial.HasProperty(CHROMATIC_ABBERATION_FIELD))
				{
					chromaticAbberMaterial = passMaterial;
				}
			}
			rendererFeature.SetActive(active);
		}
	}

	public bool SetCrtEnablement()
	{
		bool crtEnablement = GetCrtEnablement();
		SetRendererFeatureActive(crtEnablement);
		return crtEnablement;
	}

	public void SetSubOptionsInteractable()
	{
		slDropdown.interactable = enableCRT.isOn;
		caDropdown.interactable = enableCRT.isOn;
	}

	public IEnumerator LoadChromaticAbberation()
	{
		yield return null;
		caDropdown.value = GetSavedChromaticValue();
		DropdownValue value = (DropdownValue)caDropdown.value;
		SetChromaticAbberation(chromaticAbberMaterial, value);
	}

	public void SetChromaticAbberation()
	{
		DropdownValue value = (DropdownValue)caDropdown.value;
		SetChromaticAbberation(chromaticAbberMaterial, value);
	}

	public static void SetChromaticAbberation(Material crt, DropdownValue dropdownValue)
	{
		switch (dropdownValue)
		{
		case DropdownValue.Strong:
			crt.SetFloat(CHROMATIC_ABBERATION_FIELD, 0.002f);
			break;
		case DropdownValue.Medium:
			crt.SetFloat(CHROMATIC_ABBERATION_FIELD, 0.0015f);
			break;
		case DropdownValue.Light:
			crt.SetFloat(CHROMATIC_ABBERATION_FIELD, 0.001f);
			break;
		default:
			crt.SetFloat(CHROMATIC_ABBERATION_FIELD, 0f);
			break;
		}
	}

	public static void SetScanLines(Material crt, DropdownValue dropdownValue)
	{
		switch (dropdownValue)
		{
		case DropdownValue.Strong:
			crt.SetFloat(SCAN_LINES_FIELD, 200f);
			break;
		case DropdownValue.Medium:
			crt.SetFloat(SCAN_LINES_FIELD, 250f);
			break;
		case DropdownValue.Light:
			crt.SetFloat(SCAN_LINES_FIELD, 300f);
			break;
		default:
			crt.SetFloat(SCAN_LINES_FIELD, 0f);
			break;
		}
	}

	public IEnumerator LoadScanLines()
	{
		yield return null;
		slDropdown.value = GetSavedScanLinesValue();
		DropdownValue value = (DropdownValue)slDropdown.value;
		SetScanLines(crtMaterial, value);
	}

	public void SetScanLines()
	{
		DropdownValue value = (DropdownValue)slDropdown.value;
		SetScanLines(crtMaterial, value);
	}

	public float GetScanLines()
	{
		return crtMaterial.GetFloat(SCAN_LINES_FIELD);
	}

	public bool InitalizeCrtSettings()
	{
		bool flag = IsCrtEnabled();
		SetRendererFeatureActive(flag);
		return flag;
	}

	public bool GetCrtEnablement()
	{
		return enableCRT.isOn;
	}

	public static int GetSavedChromaticValue()
	{
		return PlayerPrefs.GetInt(PlayerPrefsManager.CRT_CA_INDEX, 2);
	}

	public static int GetSavedScanLinesValue()
	{
		return PlayerPrefs.GetInt(PlayerPrefsManager.CRT_SL_INDEX, 2);
	}

	public static bool IsCrtEnabled()
	{
		return PlayerPrefsManager.GetBool(PlayerPrefsManager.CRT_ENABLEMENT, defaultValue: true);
	}

	public void SaveSettings()
	{
		PlayerPrefsManager.SetBool(PlayerPrefsManager.CRT_ENABLEMENT, enableCRT.isOn);
		PlayerPrefs.SetInt(PlayerPrefsManager.CRT_CA_INDEX, caDropdown.value);
		PlayerPrefs.SetInt(PlayerPrefsManager.CRT_SL_INDEX, slDropdown.value);
	}

	public int GetChromaticAbberationIndex()
	{
		return caDropdown.value;
	}

	public int GetScanLineIndex()
	{
		return slDropdown.value;
	}
}
