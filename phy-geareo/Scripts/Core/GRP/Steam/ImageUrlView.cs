using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.UI;

namespace GRP.Steam
{
	public class ImageUrlView : View<ImageUrlViewable>
	{
		public RawImage image;

		public AspectRatioFitter ratioFitter;

		public GameObject loading;

		protected override void OnViewOpen()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
