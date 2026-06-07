using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSO", menuName = "Scriptable Objects/SettingsSO")]
public class SettingsSO : ScriptableObject
{
	public float m_MasterVolume = 1f;

	public float m_SFXVolume = 1f;

	public float m_BGVolume = 1f;

	public bool m_VHSToggle = true;

	public bool m_GlitchToggle = true;

	public bool m_NoiseToggle = true;
}
