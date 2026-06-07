using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectGridSnapLookAndFeel : Settings
	{
		[SerializeField]
		private PivotPointShapeType _pivotShapeType = PivotPointShapeType.Circle;

		[SerializeField]
		private Color _pivotPointFillColor = Color.green;

		[SerializeField]
		private Color _pivotPointBorderColor = Color.black;

		[SerializeField]
		private float _pivotCircleRadius = 5f;

		[SerializeField]
		private float _pivotSquareSideLength = 10f;

		[SerializeField]
		private bool _drawPivotBorder = true;

		[SerializeField]
		private Color _boxLineColor = Color.yellow;

		[SerializeField]
		private bool _drawBoxes = true;

		public PivotPointShapeType PivotShapeType
		{
			get
			{
				return _pivotShapeType;
			}
			set
			{
				_pivotShapeType = value;
			}
		}

		public Color PivotPointFillColor
		{
			get
			{
				return _pivotPointFillColor;
			}
			set
			{
				_pivotPointFillColor = value;
			}
		}

		public Color PivotPointBorderColor
		{
			get
			{
				return _pivotPointBorderColor;
			}
			set
			{
				_pivotPointBorderColor = value;
			}
		}

		public float PivotCircleRadius
		{
			get
			{
				return _pivotCircleRadius;
			}
			set
			{
				_pivotCircleRadius = Mathf.Max(2f, value);
			}
		}

		public float PivotSquareSideLength
		{
			get
			{
				return _pivotSquareSideLength;
			}
			set
			{
				_pivotSquareSideLength = Mathf.Max(2f, value);
			}
		}

		public bool DrawPivotBorder
		{
			get
			{
				return _drawPivotBorder;
			}
			set
			{
				_drawPivotBorder = value;
			}
		}

		public Color BoxLineColor
		{
			get
			{
				return _boxLineColor;
			}
			set
			{
				_boxLineColor = value;
			}
		}

		public bool DrawBoxes
		{
			get
			{
				return _drawBoxes;
			}
			set
			{
				_drawBoxes = value;
			}
		}
	}
}
