using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SpriteEditor
{
	public class DrawGrid : MonoBehaviour
	{
		protected Color transparent;

		public Color gridColor;

		protected RawImage rImage;

		protected Texture2D gridTexture;

		protected int width;

		protected int height;

		[HideInInspector]
		public int sizeX;

		[HideInInspector]
		public int sizeY;

		[HideInInspector]
		public List<Vector2Int> coordsTLVertex;

		private List<int> coloredPixels;

		protected Action<Vector2Int> OnGridChange;

		public Color defaultColor;

		public virtual void Init(int w, int h, Action<Vector2Int> OnGridChange = null)
		{
		}

		public virtual void SetColor(Color? color = null)
		{
		}

		public virtual void SetAlpha(float alpha)
		{
		}

		protected virtual void ColorPixels(int[] index)
		{
		}

		public virtual void SetTransparent()
		{
		}

		public virtual void SetGrid2(int sizeX, int sizeY, Color? color, bool show = false)
		{
		}

		public virtual void SetGrid3(int sizeX, int sizeY, Color? color, bool show = false)
		{
		}

		public virtual void SetGrid(int sizeX, int sizeY, Color? color, bool findTL = true)
		{
		}
	}
}
