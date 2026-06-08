using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public abstract class ScrollableLayout : LayoutDynamic
	{
		public ScrollRect scrollRect;

		public float margin;

		public float removeMargin;

		public float startPadding;

		public float endPadding;

		public Vector2Int range;

		protected float contentStart;

		protected float contentEnd;

		protected float viewportStart;

		protected float viewportEnd;

		protected IsPointerHolding isPointerHolding;

		private bool lastHolding;

		private float topStartTime;

		public List<LayoutItem> items { get; }

		public bool willRefresh { get; private set; }

		public event Action onReachStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onReachEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onRefresh
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected abstract bool GetInvertedScroll();

		protected abstract float GetStart(LayoutItem item);

		protected abstract float GetEnd(LayoutItem item);

		protected abstract float GetAxis(Vector2 vector);

		protected abstract float GetCrossAxis(Vector2 vector);

		protected abstract Vector2 GetVector(float axis, float crossAxis);

		protected abstract void SetupItem(LayoutItem item, LayoutItem nextItem, LayoutItem previousItem);

		protected float GetAxis(Rect rect)
		{
			return 0f;
		}

		protected float GetCrossAxis(Rect rect)
		{
			return 0f;
		}

		protected virtual float GetContentStart(LayoutItem item)
		{
			return 0f;
		}

		protected virtual float GetContentEnd(LayoutItem item)
		{
			return 0f;
		}

		protected virtual float GetExtraMargin()
		{
			return 0f;
		}

		private void Awake()
		{
		}

		private void Reset()
		{
		}

		protected override Transform GetContainer()
		{
			return null;
		}

		protected override void BuildLayout()
		{
		}

		private bool ResetContentStart(LayoutItem item, float value)
		{
			return false;
		}

		private bool ResetContentEnd(LayoutItem item, float value)
		{
			return false;
		}

		protected virtual void MoveAll(float value)
		{
		}

		private bool ResetContent(float value)
		{
			return false;
		}

		public float GetItemsStart()
		{
			return 0f;
		}

		public float GetItemsEnd()
		{
			return 0f;
		}

		public override void Clear()
		{
		}

		protected bool IsValidIndex(int index)
		{
			return false;
		}

		protected bool IsViewportVisible(LayoutItem e)
		{
			return false;
		}

		protected bool IsViewportInside(LayoutItem e)
		{
			return false;
		}

		protected bool IsContentVisible(LayoutItem e)
		{
			return false;
		}

		protected bool IsContentInside(LayoutItem e)
		{
			return false;
		}
	}
}
