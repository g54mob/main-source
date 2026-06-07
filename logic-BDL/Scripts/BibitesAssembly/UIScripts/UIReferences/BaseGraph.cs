using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public abstract class BaseGraph : MonoBehaviour
	{
		protected RectTransform rt;

		public GameObject xLinePrefab;

		public HorizontalLayoutGroup xLineHolder;

		public GameObject yLinePrefab;

		public VerticalLayoutGroup yLineHolder;

		protected ItemPool<GraphBackgroundLineLabel> xLines;

		protected ItemPool<GraphBackgroundLineLabel> yLines;

		public RectTransform graphRect;

		public int nY = 11;

		public int nX = 26;

		protected bool hasInit;

		protected Vector2 defaultMin = Vector2.zero;

		protected Vector2 defaultMax = Vector2.zero;

		protected Vector2 min;

		protected Vector2 max;

		public virtual void InitGraph()
		{
			if (!hasInit)
			{
				hasInit = true;
				rt = GetComponent<RectTransform>();
				xLines = new ItemPool<GraphBackgroundLineLabel>(xLinePrefab, xLineHolder.transform, 100);
				yLines = new ItemPool<GraphBackgroundLineLabel>(yLinePrefab, yLineHolder.transform, 100);
				xLinePrefab.SetActive(value: false);
				yLinePrefab.SetActive(value: false);
				SetGraduationLinesCount(nX, nY);
			}
		}

		protected virtual void OnShow()
		{
			if (!hasInit)
			{
				InitGraph();
			}
			OnGraphHolderDimensionChanged();
		}

		private void OnEnable()
		{
			OnShow();
		}

		public void SetMinMax(Vector2? minBounds = null, Vector2? maxBounds = null)
		{
			if (minBounds.HasValue)
			{
				defaultMin = minBounds.Value;
			}
			if (maxBounds.HasValue)
			{
				defaultMax = maxBounds.Value;
			}
		}

		public Vector2 RectPosToValue(Vector2 pos)
		{
			Rect rect = graphRect.rect;
			Vector2 vector = (pos - rect.min) / rect.size;
			return min + vector * (max - min);
		}

		public Vector2 ValueToRectPos(Vector2 pos)
		{
			Rect rect = graphRect.rect;
			return (pos - min) / (max - min) * rect.size;
		}

		public abstract void UpdateGraphData();

		public void SetGraduationLinesCount(int nLinesX, int nLinesY)
		{
			nX = nLinesX;
			nY = nLinesY;
			if (hasInit)
			{
				if (nX < xLines.activeCount)
				{
					xLines.RetireLasts(xLines.activeCount - nX);
				}
				else if (nX > xLines.activeCount)
				{
					xLines.WakeUpItems(nX - xLines.activeCount);
				}
				if (nY < yLines.activeCount)
				{
					yLines.RetireLasts(yLines.activeCount - nY);
				}
				else if (nY > yLines.activeCount)
				{
					yLines.WakeUpItems(nY - yLines.activeCount);
				}
				OnGraphHolderDimensionChanged();
			}
		}

		public virtual void OnGraphHolderDimensionChanged()
		{
			if (hasInit)
			{
				Rect rect = graphRect.rect;
				for (int i = 0; i < nX; i++)
				{
					xLines.activeItems[i].UpdateLineLength(rect.height);
				}
				xLineHolder.spacing = (rect.width - (float)xLineHolder.padding.horizontal) / (float)(nX - 1);
				for (int j = 0; j < nY; j++)
				{
					yLines.activeItems[j].UpdateLineLength(rect.width);
				}
				yLineHolder.spacing = rect.height / (float)(nY - 1);
				if (base.isActiveAndEnabled)
				{
					UpdateGraphData();
				}
			}
		}
	}
}
