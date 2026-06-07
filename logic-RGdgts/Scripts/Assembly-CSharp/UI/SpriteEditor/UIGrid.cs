using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SpriteEditor
{
	public class UIGrid : MonoBehaviour
	{
		public int width;

		public int height;

		protected UIGridRenderer gridRenderer;

		[NonSerialized]
		[HideInInspector]
		public int sizeX;

		[NonSerialized]
		[HideInInspector]
		public int sizeY;

		[NonSerialized]
		[HideInInspector]
		public List<Vector2Int> coordsTLVertex;

		protected Action<Vector2Int> OnGridChange;

		public Color defaultColor;

		[NonSerialized]
		[HideInInspector]
		public Color gridColor;

		private Material gridMaterial;

		[SerializeField]
		private Image bottomBar;

		[SerializeField]
		private Image leftBar;

		public virtual void Init(int w, int h, Action<Vector2Int> OnGridChange = null, Color? defaultColor = null)
		{
		}

		public virtual List<Vector2Int> GetTLVertexNoBorder()
		{
			return null;
		}

		public (Vector2Int, int) GetCellNumber(Vector2 coords)
		{
			return default((Vector2Int, int));
		}

		public float PitagoraDistance(Vector2 start, Vector2 end)
		{
			return 0f;
		}

		public virtual void SetGridShaderParameters(int x, int y, Color? color = null, Vector2Int? off = null)
		{
		}

		public virtual void ResetGridParameters(int x, int y, Color? color = null, Vector2Int? off = null)
		{
		}

		public virtual void SetColor(Color color)
		{
		}

		public virtual void SaveColor(Color color)
		{
		}

		public virtual void SetColorNoAlpha(Color color)
		{
		}

		public virtual void ResetDefaultColor()
		{
		}

		public virtual void SetAlpha(float alpha)
		{
		}
	}
}
