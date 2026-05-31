using System;
using System.Collections;
using UnityEngine;

namespace PolyAndCode.UI
{
	public abstract class RecyclingSystem
	{
		public IRecyclableScrollRectDataSource DataSource;

		protected RectTransform Viewport;

		protected RectTransform Content;

		protected RectTransform PrototypeCell;

		protected bool IsGrid;

		protected float MinPoolCoverage;

		protected int MinPoolSize;

		protected float RecyclingThreshold;

		public abstract IEnumerator InitCoroutine(Action onInitialized = null);

		public abstract Vector2 OnValueChangedListener(Vector2 direction);
	}
}
