using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk
{
	public class ContentResizerUIView : ContentSizeFitter
	{
		private RectTransform _ourRect;

		public bool forceExpandToParentSize;

		protected override void OnEnable()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}
	}
}
