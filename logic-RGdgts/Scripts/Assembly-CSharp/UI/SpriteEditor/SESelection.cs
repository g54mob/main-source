using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SpriteEditor
{
	public class SESelection : MonoBehaviour
	{
		private Color transparent;

		private Color selectionColor;

		private RawImage rImage;

		private Texture2D gridTexture;

		private int width;

		private int height;

		[HideInInspector]
		public int[] gridValues;

		[HideInInspector]
		public SEGridSize currentGridSize;

		public void Init(int w, int h)
		{
		}

		public void ColorPixels(int[] indexes)
		{
		}

		public void SetTransparent()
		{
		}
	}
}
