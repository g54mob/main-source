using UnityEngine.UI;

namespace Rhizomatic.ImUI
{
	public class ImageView : ImUIView<ImageViewState>
	{
		public Image image;

		public RawImage rawImage;

		public AspectRatioFitter ratioFitter;

		protected override void LoadState(ImageViewState state)
		{
		}
	}
}
