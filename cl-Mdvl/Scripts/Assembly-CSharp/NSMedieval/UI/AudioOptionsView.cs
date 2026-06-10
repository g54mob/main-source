using NSEipix.Base;
using NSEipix.View.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AudioOptionsView : OptionsView
	{
		[SerializeField]
		private Slider[] audioControls;

		[SerializeField]
		private CustomToggle playlistPauseToggle;

		private void Start()
		{
			for (int i = 0; i < audioControls.Length; i++)
			{
				switch (i)
				{
				case 0:
					audioControls[i].onValueChanged.AddListener(delegate(float value)
					{
						MonoSingleton<OptionsController>.Instance.SetMasterVolume(value);
					});
					break;
				case 1:
					audioControls[i].onValueChanged.AddListener(delegate(float value)
					{
						MonoSingleton<OptionsController>.Instance.SetMusicVolume(value);
					});
					break;
				case 2:
					audioControls[i].onValueChanged.AddListener(delegate(float value)
					{
						MonoSingleton<OptionsController>.Instance.SetSfxVolume(value);
					});
					break;
				case 3:
					audioControls[i].onValueChanged.AddListener(delegate(float value)
					{
						MonoSingleton<OptionsController>.Instance.SetAmbienceVolume(value);
					});
					break;
				}
			}
			playlistPauseToggle.onValueChanged.AddListener(delegate(bool value)
			{
				MonoSingleton<OptionsController>.Instance.SetPlaylistPause(value);
			});
		}

		public override void Show()
		{
			base.Show();
			SetupAudioControls();
		}

		private void SetupAudioControls()
		{
			for (int i = 0; i < audioControls.Length; i++)
			{
				switch (i)
				{
				case 0:
					audioControls[i].value = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.MasterVolume;
					break;
				case 1:
					audioControls[i].value = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.MusicVolume;
					break;
				case 2:
					audioControls[i].value = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SfxVolume;
					break;
				case 3:
					audioControls[i].value = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.AmbienceVolume;
					break;
				}
			}
			playlistPauseToggle.isOn = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.PlaylistPause;
		}
	}
}
