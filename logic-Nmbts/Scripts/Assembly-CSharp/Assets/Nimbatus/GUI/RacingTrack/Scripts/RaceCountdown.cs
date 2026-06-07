using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.RacingTrack.Scripts
{
	public class RaceCountdown : MonoBehaviour
	{
		public string MusicCountdown;

		public UILabel CountdownLabel;

		[HideInInspector]
		public bool CountdownPlayed;

		private AudioObject _music;

		public void Update()
		{
			if (_music != null)
			{
				_music.pitch = RuntimeGlobals.TimeScale;
			}
		}

		public void StartCountdown()
		{
			base.gameObject.SetActive(true);
		}

		public void SetStringOfCountdownLabel(string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				CountdownLabel.text = LocalizationManager.GetTermTranslation(text);
			}
			else
			{
				CountdownLabel.text = "";
			}
		}

		public void SetLastStringOfCountdownLabel(string text)
		{
			if (!string.IsNullOrEmpty(text))
			{
				CountdownLabel.text = LocalizationManager.GetTermTranslation(text);
			}
			else
			{
				CountdownLabel.text = "";
			}
			CountdownPlayed = true;
		}

		public void HideCountdown()
		{
			base.gameObject.SetActive(false);
		}

		public void StartCountdownMusic()
		{
			if (!string.IsNullOrEmpty(MusicCountdown))
			{
				_music = AudioController.PlayMusic(MusicCountdown);
			}
		}
	}
}
