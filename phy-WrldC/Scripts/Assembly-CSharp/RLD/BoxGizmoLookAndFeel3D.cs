using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class BoxGizmoLookAndFeel3D : Settings
	{
		[SerializeField]
		private Color _boxWireColor = new Color(1f, 1f, 1f, RTSystemValues.AxisAlpha);

		[SerializeField]
		private GizmoCap2DLookAndFeel[] _tickLookAndFeel = new GizmoCap2DLookAndFeel[6];

		public Color BoxWireColor => _boxWireColor;

		public Color XTickColor => GetTickLookAndFeel(0, AxisSign.Positive).Color;

		public Color YTickColor => GetTickLookAndFeel(1, AxisSign.Positive).Color;

		public Color ZTickColor => GetTickLookAndFeel(2, AxisSign.Positive).Color;

		public Color TickBorderColor => GetTickLookAndFeel(0, AxisSign.Positive).BorderColor;

		public Color TickHoveredColor => GetTickLookAndFeel(0, AxisSign.Positive).HoveredColor;

		public Color TickHoveredBorderColor => GetTickLookAndFeel(0, AxisSign.Positive).HoveredBorderColor;

		public GizmoCap2DType TickType => GetTickLookAndFeel(0, AxisSign.Positive).CapType;

		public float TickQuadWidth => GetTickLookAndFeel(0, AxisSign.Positive).QuadWidth;

		public float TickQuadHeight => GetTickLookAndFeel(0, AxisSign.Positive).QuadHeight;

		public float TickCircleRadius => GetTickLookAndFeel(0, AxisSign.Positive).CircleRadius;

		public BoxGizmoLookAndFeel3D()
		{
			for (int i = 0; i < _tickLookAndFeel.Length; i++)
			{
				_tickLookAndFeel[i] = new GizmoCap2DLookAndFeel();
			}
			SetAxisTickColor(0, RTSystemValues.XAxisColor);
			SetAxisTickColor(1, RTSystemValues.YAxisColor);
			SetAxisTickColor(2, RTSystemValues.ZAxisColor);
			SetTickHoveredColor(RTSystemValues.HoveredAxisColor);
			SetTickBorderColor(Color.black.KeepAllButAlpha(0f));
			SetTickHoveredBorderColor(Color.black.KeepAllButAlpha(0f));
			SetTickQuadWidth(10f);
			SetTickQuadHeight(10f);
			SetTickCircleRadius(6f);
			SetTickType(GizmoCap2DType.Quad);
		}

		public List<Enum> GetAllowedTickTypes()
		{
			return new List<Enum>
			{
				GizmoCap2DType.Circle,
				GizmoCap2DType.Quad
			};
		}

		public bool IsTickTypeAllowed(GizmoCap2DType tickType)
		{
			if (tickType != GizmoCap2DType.Circle)
			{
				return tickType == GizmoCap2DType.Quad;
			}
			return true;
		}

		public void SetBoxWireColor(Color color)
		{
			_boxWireColor = color;
		}

		public void SetAxisTickColor(int axisIndex, Color color)
		{
			GetTickLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetTickLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
		}

		public void SetTickBorderColor(Color color)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].BorderColor = color;
			}
		}

		public void SetTickHoveredColor(Color color)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].HoveredColor = color;
			}
		}

		public void SetTickHoveredBorderColor(Color color)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].HoveredBorderColor = color;
			}
		}

		public void SetTickType(GizmoCap2DType tickType)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].CapType = tickType;
			}
		}

		public void SetTickQuadWidth(float width)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].QuadWidth = width;
			}
		}

		public void SetTickQuadHeight(float height)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].QuadHeight = height;
			}
		}

		public void SetTickCircleRadius(float radius)
		{
			GizmoCap2DLookAndFeel[] tickLookAndFeel = _tickLookAndFeel;
			for (int i = 0; i < tickLookAndFeel.Length; i++)
			{
				tickLookAndFeel[i].CircleRadius = radius;
			}
		}

		public void ConnectTickLookAndFeel(GizmoCap2D tick, int axisIndex, AxisSign axisSign)
		{
			tick.SharedLookAndFeel = GetTickLookAndFeel(axisIndex, axisSign);
		}

		private GizmoCap2DLookAndFeel GetTickLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _tickLookAndFeel[axisIndex];
			}
			return _tickLookAndFeel[axisIndex + 3];
		}
	}
}
