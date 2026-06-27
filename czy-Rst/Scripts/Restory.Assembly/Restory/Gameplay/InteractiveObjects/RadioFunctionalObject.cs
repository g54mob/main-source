using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class RadioFunctionalObject : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private MusicVfxPlayer musicVfxPlayer;

		[SerializeField]
		private GameObject radioMusicSoundSource;

		private RadioMusicSwitcher radioMusicSwitcher;

		public bool IsPlaying { get; set; }

		public GameObject RadioMusicSoundSource => radioMusicSoundSource;

		[Inject]
		private void Constructor(RadioMusicSwitcher radioMusicSwitcher)
		{
			this.radioMusicSwitcher = radioMusicSwitcher;
			interactiveObject.IsActivatable = true;
		}

		private void OnEnable()
		{
			interactiveObject.OnInitialized += CheckIfObjectChanged;
			interactiveObject.OnActivated += ToggleRadio;
			CheckIfObjectChanged();
		}

		private void OnDisable()
		{
			interactiveObject.OnInitialized += CheckIfObjectChanged;
			interactiveObject.OnActivated -= ToggleRadio;
		}

		private void CheckIfObjectChanged()
		{
			if (IsPlaying != interactiveObject.HasChanged)
			{
				ToggleRadio();
			}
		}

		private void ToggleRadio()
		{
			IsPlaying = !IsPlaying;
			if (IsPlaying)
			{
				musicVfxPlayer.Play();
			}
			else
			{
				musicVfxPlayer.Stop();
			}
			radioMusicSwitcher.ToggleRadioSounds(IsPlaying, radioMusicSoundSource);
			interactiveObject.HasChanged = IsPlaying;
		}
	}
}
