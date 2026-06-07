using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Sharing
{
	public class ScreenshotListItemScript : WidgetScript
	{
		private RawImageWidget _rawImage;

		public override bool HandleChildEvents => false;

		public Texture2D Texture
		{
			get
			{
				return _rawImage.Image.texture as Texture2D;
			}
			set
			{
				_rawImage.Image.texture = value;
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_rawImage = GetComponentInChildren<RawImageWidget>();
		}
	}
}
