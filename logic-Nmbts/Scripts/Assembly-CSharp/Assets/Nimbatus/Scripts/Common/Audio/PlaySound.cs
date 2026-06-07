using System.Linq;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Audio
{
	public class PlaySound : MonoBehaviour
	{
		public string SoundName;

		public bool PlayOnClick;

		public bool PlayOnMouseOver;

		public void Start()
		{
			if (!PlayOnClick && !PlayOnMouseOver)
			{
				AudioController.Play(SoundName, base.gameObject.transform);
			}
		}

		public void Update()
		{
			if (!PlayOnClick && !PlayOnMouseOver && AudioController.GetPlayingAudioObjects(SoundName).All((AudioObject ao) => ao.transform.parent != base.gameObject.transform))
			{
				AudioController.Play(SoundName, base.gameObject.transform);
			}
		}

		public void OnClick()
		{
			if (PlayOnClick)
			{
				AudioController.Play(SoundName);
			}
		}

		public void OnHover(bool isOver)
		{
			if (isOver && PlayOnMouseOver)
			{
				AudioController.Play(SoundName);
			}
		}
	}
}
