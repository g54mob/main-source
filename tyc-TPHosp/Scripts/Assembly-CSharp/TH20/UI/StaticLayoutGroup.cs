using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[ExecuteInEditMode]
	[AddComponentMenu("Layout/Static Layout Group", 106)]
	[RequireComponent(typeof(RectTransform))]
	public class StaticLayoutGroup : ElementLayoutController, ILayoutGroup, ILayoutController
	{
		[Serializable]
		private class Element
		{
			public bool UseWeight = true;

			public float Fraction = 0.2f;

			public float Weight = 1f;
		}

		public enum Mode
		{
			HorizontalLeft = 0,
			HorizontalCenter = 1,
			HorizontalRight = 2,
			VerticalBottom = 10,
			VerticalCenter = 11,
			VerticalTop = 12
		}

		[SerializeField]
		private Mode _mode = Mode.HorizontalCenter;

		[SerializeField]
		private List<Element> _elements = new List<Element>();

		[Range(0f, 0.1f)]
		[SerializeField]
		private float _marginFraction;

		[Range(0f, 0.1f)]
		[SerializeField]
		private float _paddingFraction;

		public bool IsHorizontal
		{
			get
			{
				if (_mode >= Mode.HorizontalLeft)
				{
					return _mode <= Mode.HorizontalRight;
				}
				return false;
			}
		}

		public bool IsVertical
		{
			get
			{
				if (_mode >= Mode.VerticalBottom)
				{
					return _mode <= Mode.VerticalTop;
				}
				return false;
			}
		}

		[Conditional("UNITY_EDITOR")]
		private void InEditorSetDirty()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		protected override void OnCanvasHierarchyChanged()
		{
		}

		void ILayoutController.SetLayoutHorizontal()
		{
			SetLayout(RectTransform.Axis.Horizontal);
		}

		void ILayoutController.SetLayoutVertical()
		{
			SetLayout(RectTransform.Axis.Vertical);
		}

		private void SetLayout(RectTransform.Axis axis)
		{
		}
	}
}
