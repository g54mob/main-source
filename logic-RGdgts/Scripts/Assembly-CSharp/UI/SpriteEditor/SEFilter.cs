using System.Collections.Generic;
using UI.Common;
using UI.Utilities;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SEFilter
	{
		private int[] filterValues;

		public SEFilterSize size;

		public int shift;

		public Vector2Int tlPosition;

		public List<Vector2Int> coordsTLVertex;

		public PitagoraD deltaWithRespectToSnapGrid;

		public Color defaultColor;

		public void Init()
		{
		}

		public void SetFilter(SEFilterSize gridMin)
		{
		}

		public void SetToZero()
		{
		}

		public bool IncreaseFilterSize()
		{
			return false;
		}

		public bool DecreaseFilterSize()
		{
			return false;
		}

		public virtual void SetTLVertex(int imageWidth, int imageHeight)
		{
		}
	}
}
