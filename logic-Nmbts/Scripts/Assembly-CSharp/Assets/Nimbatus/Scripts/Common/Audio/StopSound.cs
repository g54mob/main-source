using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Audio
{
	public class StopSound : MonoBehaviour
	{
		public string SoundName;

		public float FadeoutTime;

		public bool StopOnClick;

		public bool StopOnMouseOver;

		public void Start()
		{
			if (!StopOnClick && !StopOnMouseOver)
			{
				AudioController.Stop(SoundName, FadeoutTime);
			}
		}

		public void OnClick()
		{
			if (StopOnClick)
			{
				AudioController.Stop(SoundName, FadeoutTime);
			}
		}

		public void OnHover(bool isOver)
		{
			if (isOver && StopOnMouseOver)
			{
				AudioController.Stop(SoundName, FadeoutTime);
			}
		}
	}
}
