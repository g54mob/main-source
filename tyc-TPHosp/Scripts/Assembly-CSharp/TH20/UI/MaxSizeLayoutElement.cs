using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("Layout/Max Size Layout Element", 141)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public class MaxSizeLayoutElement : UIBehaviour, IMaxSizeLayoutElement
	{
		[SerializeField]
		private int _layoutPriority = 1;

		[SerializeField]
		private float _maxWidth = -1f;

		[SerializeField]
		private float _maxHeight = -1f;

		public float maxWidth
		{
			get
			{
				return _maxWidth;
			}
			set
			{
				_maxWidth = value;
				SetDirty();
			}
		}

		public float maxHeight
		{
			get
			{
				return _maxHeight;
			}
			set
			{
				_maxHeight = value;
				SetDirty();
			}
		}

		public virtual int layoutPriority
		{
			get
			{
				return _layoutPriority;
			}
			set
			{
				_layoutPriority = value;
				SetDirty();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetDirty();
		}

		protected override void OnTransformParentChanged()
		{
			SetDirty();
		}

		protected override void OnDisable()
		{
			SetDirty();
			base.OnDisable();
		}

		protected override void OnDidApplyAnimationProperties()
		{
			SetDirty();
		}

		protected override void OnBeforeTransformParentChanged()
		{
			SetDirty();
		}

		protected void SetDirty()
		{
			if (IsActive())
			{
				LayoutRebuilder.MarkLayoutForRebuild(base.transform as RectTransform);
			}
		}
	}
}
