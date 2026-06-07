using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionLookAndFeel : Settings
	{
		[SerializeField]
		private bool _drawHighlight = true;

		[SerializeField]
		private SelectionBoxBorderStyle _selectionBoxBorderStyle = SelectionBoxBorderStyle.WireCorners;

		[SerializeField]
		private float _wireCornerLinePercentage = 0.5f;

		[SerializeField]
		private SelectionBoxRenderMode _selectionBoxRenderMode = SelectionBoxRenderMode.FromParentToBottom;

		[SerializeField]
		private Color _selectionBoxBorderColor = Color.green;

		[SerializeField]
		private float _selectionBoxInflateAmount = 0.005f;

		[SerializeField]
		private Color _selectionRectBorderColor = Color.white;

		[SerializeField]
		private Color _selectionRectFillColor = ColorEx.FromByteValues(95, 109, 130, 128);

		public bool DrawHighlight
		{
			get
			{
				return _drawHighlight;
			}
			set
			{
				_drawHighlight = value;
			}
		}

		public SelectionBoxBorderStyle SelBoxBorderStyle
		{
			get
			{
				return _selectionBoxBorderStyle;
			}
			set
			{
				_selectionBoxBorderStyle = value;
			}
		}

		public float WireCornerLinePercentage
		{
			get
			{
				return _wireCornerLinePercentage;
			}
			set
			{
				_wireCornerLinePercentage = Mathf.Clamp(value, 0.01f, 1f);
			}
		}

		public SelectionBoxRenderMode SelBoxRenderMode
		{
			get
			{
				return _selectionBoxRenderMode;
			}
			set
			{
				_selectionBoxRenderMode = value;
			}
		}

		public Color SelectionBoxBorderColor
		{
			get
			{
				return _selectionBoxBorderColor;
			}
			set
			{
				_selectionBoxBorderColor = value;
			}
		}

		public float SelectionBoxInflateAmount
		{
			get
			{
				return _selectionBoxInflateAmount;
			}
			set
			{
				_selectionBoxInflateAmount = Mathf.Max(value, 0f);
			}
		}

		public Color SelectionRectBorderColor
		{
			get
			{
				return _selectionRectBorderColor;
			}
			set
			{
				_selectionRectBorderColor = value;
			}
		}

		public Color SelectionRectFillColor
		{
			get
			{
				return _selectionRectFillColor;
			}
			set
			{
				_selectionRectFillColor = value;
			}
		}
	}
}
