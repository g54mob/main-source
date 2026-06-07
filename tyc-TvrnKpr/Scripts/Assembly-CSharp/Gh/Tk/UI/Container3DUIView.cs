using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class Container3DUIView : MonoBehaviour
	{
		public float margin;

		public float width;

		public float height;

		public LayoutDirection direction;

		public bool rightToLeft;

		public bool requireEnabledCollider;

		public bool ignoreNonLayoutChildren;

		private RectTransform _rectTransform;

		[SerializeField]
		private Vector3 _localOffset;

		[SerializeField]
		private bool _alignToCenterHorizontally;

		[SerializeField]
		private bool _alignToCenterVertically;

		public bool ignoreHorizontalAlignment;

		public bool ignoreVerticalAlignment;

		private bool _dirty;

		[SerializeField]
		protected bool _handbackChildrenToObjectPool;

		public bool includeOffsetInCachedSize;

		private UIAnimationControl _uiAnimationControl;

		public Vector3 LocalOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector2 CachedTotalSize { get; private set; }

		public event EventHandler LayoutUpdated
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

		protected void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateLayout()
		{
		}

		public void UpdateLayoutImmediate()
		{
		}

		private bool GetSizeAndOffset(Transform child, out Vector3 size, out Vector3 offset, out BoxCollider childCollider)
		{
			size = default(Vector3);
			offset = default(Vector3);
			childCollider = null;
			return false;
		}

		private void Align(List<Transform> currentList, LayoutDirection direction)
		{
		}

		public void Add(GameObject child)
		{
		}

		public void Add(Transform child)
		{
		}

		public virtual void Clear()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public void MarkDirty()
		{
		}

		private void LateUpdate()
		{
		}

		public UIAnimationControl UpdateAndTweenPositions(Ease ease = Ease.InOutCubic, float duration = 0.15f)
		{
			return null;
		}
	}
}
