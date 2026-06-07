using System;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class ZoomImageGrid : UIGrid
	{
		public override void Init(int w, int h, Action<Vector2Int> OnGridChange = null, Color? defaultColor = null)
		{
		}

		public void SetGridFromFilter(Vector2Int filterSize)
		{
		}

		public override void ResetGridParameters(int sizeX, int sizeY, Color? color = null, Vector2Int? off = null)
		{
		}

		public override void SetColor(Color color)
		{
		}

		public override void SaveColor(Color color)
		{
		}

		public override void SetAlpha(float alpha)
		{
		}

		public int SizeX()
		{
			return 0;
		}

		public int SizeY()
		{
			return 0;
		}
	}
}
