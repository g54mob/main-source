using UnityEngine;

namespace Rhizomatic.ImUI
{
	public class ImageViewState : ImUIViewState
	{
		public Sprite sprite;

		public Texture texture;

		public float aspectRatio;

		public ImageViewState(Sprite sprite)
		{
		}

		public ImageViewState(Texture texture)
		{
		}
	}
}
