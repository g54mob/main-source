using UnityEngine;

namespace Kitchen.Components
{
	public class MusicController : MonoBehaviour
	{
		public MusicSource Source;

		public bool IsPlayingNight;

		private void Update()
		{
			if (GameInfo.CurrentScene != SceneType.Kitchen)
			{
				if (GameInfo.CurrentScene != SceneType.Null)
				{
					Source.Stop();
				}
			}
			else if (GameInfo.IsPreparationTime != IsPlayingNight)
			{
				IsPlayingNight = GameInfo.IsPreparationTime;
				if (IsPlayingNight)
				{
					Source.RequestOutro();
				}
				else
				{
					Source.PlayNewTrack();
				}
			}
		}
	}
}
