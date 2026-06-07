using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class AnimatedImage : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private float frameDelay;

		private List<Sprite> _frames;

		private int _currentFrame;

		private float _time;

		private bool _isPause;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void PlayGif(string fileName)
		{
		}

		public void Pause()
		{
		}

		public static void ReadGif(string path, out List<Sprite> frames)
		{
			frames = null;
		}

		public static bool ExistsGif(string path)
		{
			return false;
		}

		private static Sprite Texture2DtoSprite(Texture2D tex)
		{
			return null;
		}
	}
}
