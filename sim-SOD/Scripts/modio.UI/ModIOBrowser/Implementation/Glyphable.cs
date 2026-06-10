using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class Glyphable : MonoBehaviour
	{
		public Image image;

		public GlyphSetting config;

		private SimpleMessageUnsubscribeToken subToken;

		public void OnValidate()
		{
		}

		private void Start()
		{
		}

		public void UpdateGlyphs()
		{
		}

		private Sprite GetGlyphFromDisplayType()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
