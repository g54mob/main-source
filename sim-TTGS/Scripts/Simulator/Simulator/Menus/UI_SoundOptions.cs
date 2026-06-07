using Dhs5.Utility.Settings;
using Simulator.CustomSettings;
using UnityEngine;

namespace Simulator.Menus
{
	public class UI_SoundOptions : MonoBehaviour
	{
		[SerializeField]
		private UI_VolumeOption m_audioOptionUI;

		[SerializeField]
		private UI_TogglePlayerPrefBoolOptions m_soundInBackgroundUI;

		private void Awake()
		{
			m_audioOptionUI.Awake();
			m_soundInBackgroundUI.Init(AudioApplicationOptions.SoundInBackground);
			m_soundInBackgroundUI.Awake();
		}

		private void OnEnable()
		{
			m_audioOptionUI.OnEnable();
			m_soundInBackgroundUI.OnEnable();
			m_soundInBackgroundUI.OnValueChanged += OnSoundInBackgroundUIChanged;
		}

		private void OnDisable()
		{
			m_audioOptionUI.OnDisable();
			m_soundInBackgroundUI.OnDisable();
			m_soundInBackgroundUI.OnValueChanged -= OnSoundInBackgroundUIChanged;
		}

		private void OnSoundInBackgroundUIChanged(bool value)
		{
			CustomSettings<AudioApplicationOptions>.I.Update();
		}
	}
}
