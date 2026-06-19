using UnityEngine;

namespace JSAM.Example
{
	public class CrossFadeExample : MonoBehaviour
	{
		private bool pitched;

		public void UseCrossFade()
		{
			pitched = !pitched;
			float time = AudioManager.FadeMainMusicOut(5f).AudioSource.time;
			if (pitched)
			{
				AudioManager.FadeMusicIn(DynamicMusicMusic.MenuPitched, 5f, isMainmusic: true).AudioSource.time = time;
			}
			else
			{
				AudioManager.FadeMusicIn(DynamicMusicMusic.Menu, 5f, isMainmusic: true).AudioSource.time = time;
			}
		}
	}
}
