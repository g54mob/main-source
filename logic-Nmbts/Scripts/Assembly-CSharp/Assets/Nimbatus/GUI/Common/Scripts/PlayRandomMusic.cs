using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class PlayRandomMusic : MonoBehaviour
	{
		public string[] MusicTitles;

		public static string CurrentMusic;

		public void Start()
		{
			int num = Random.Range(0, MusicTitles.Length);
			CurrentMusic = MusicTitles[num];
		}

		public void Update()
		{
			if (!RuntimeGlobals.IsGameLoading && !string.IsNullOrEmpty(CurrentMusic) && !AudioController.IsPlaying(CurrentMusic))
			{
				AudioController.PlayMusic(CurrentMusic);
			}
		}
	}
}
