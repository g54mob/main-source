using UnityEngine;

namespace SLS.Widgets.Table
{
	public class Datum
	{
		public Color? extraTextBoxColor;

		public Color? extraTextColor;

		public Table table;

		public bool isEvenRow;

		public decimal animationStartTime;

		private bool _isDirty;

		public float? measuredVertPos;

		private float? _measuredCellHeight;

		private float? _measuredHeight;

		private float? _lastSafeHeightResult;

		private bool _isHeader;

		private bool _isFooter;

		public string uid { get; set; }

		public object rawObject { get; set; }

		public string tooltip { get; set; }

		public DatumElementList elements { get; set; }

		public Element extraText { get; set; }

		public decimal revision { get; protected set; }

		public bool isDirty
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isHeader => false;

		public bool isFooter => false;

		public void ClearMeasure()
		{
		}

		public float SafeExtraTextHeight()
		{
			return 0f;
		}

		public float SafeCellHeight()
		{
			return 0f;
		}

		public float SafeHeight()
		{
			return 0f;
		}

		public static Datum Body(string uid)
		{
			return null;
		}

		public static Datum Header()
		{
			return null;
		}

		public static Datum Footer()
		{
			return null;
		}

		private Datum(string uid)
		{
		}
	}
}
