using UnityEngine;
using UnityEngine.UI;

namespace JSAM.Example.LoopPoints
{
	public class LoopPointExample : MonoBehaviour
	{
		[SerializeField]
		private MusicFileObject music;

		[SerializeField]
		private MusicPlayer player;

		[SerializeField]
		private Slider progressSlider;

		[SerializeField]
		private Text buttonText;

		private AudioSource sourceToTrack;

		public void CheckTheFile()
		{
		}

		public void Update()
		{
			if (sourceToTrack != null)
			{
				if (Input.GetKeyDown(KeyCode.LeftArrow))
				{
					sourceToTrack.time = Mathf.Clamp(sourceToTrack.time - 5f, 0f, sourceToTrack.clip.length - 0.01f);
				}
				else if (Input.GetKeyDown(KeyCode.RightArrow))
				{
					sourceToTrack.time = Mathf.Clamp(sourceToTrack.time + 5f, 0f, sourceToTrack.clip.length - 0.01f);
				}
				progressSlider.value = sourceToTrack.time / sourceToTrack.clip.length;
			}
			else if ((bool)player.MusicHelper)
			{
				sourceToTrack = player.MusicHelper.AudioSource;
			}
		}
	}
}
