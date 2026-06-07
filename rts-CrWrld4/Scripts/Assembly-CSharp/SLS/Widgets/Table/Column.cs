using System;
using UnityEngine;

namespace SLS.Widgets.Table
{
	public class Column
	{
		public enum ColumnType
		{
			TEXT = 0,
			IMAGE = 1
		}

		public enum DataType
		{
			TEXT = 0,
			NUMERIC = 1,
			DATETIME = 2,
			IMAGE = 3
		}

		public enum HorAlignment
		{
			LEFT = 0,
			CENTER = 1,
			RIGHT = 2
		}

		private int _idx;

		private Color? _headerTextColorOverride;

		protected DataType _dataType;

		public float? rawWidth;

		public HorAlignment horAlignment;

		protected ColumnType _columnType;

		protected float _minWidth;

		protected float _maxWidth;

		public float? measuredMinWidth;

		public float? measuredMaxWidth;

		public int headerFontSize;

		public int footerFontSize;

		private float _imageWidth;

		private float _imageHeight;

		private bool _isInput;

		public Action<Datum, Column, string, string> inputChangeCallback;

		private Datum headerDatum;

		private Datum footerDatum;

		private string _headerIcon;

		private Color? _headerIconColor;

		private Table table;

		public int idx => 0;

		public Color headerTextColorOverride
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public DataType dataType
		{
			get
			{
				return default(DataType);
			}
			set
			{
			}
		}

		public float safeWidth => 0f;

		public ColumnType columnType => default(ColumnType);

		public float minWidth => 0f;

		public float maxWidth => 0f;

		public float imageWidth => 0f;

		public float imageHeight => 0f;

		public bool isInput => false;

		public string headerValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string headerIcon
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color? headerIconColor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string footerValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void ClearMeasure()
		{
		}

		public float CheckWidth(float w)
		{
			return 0f;
		}

		public static Column ImageColumn(Table table, int idx, float imageWidth, float imageHeight, Datum headerDatum, Datum footerDatum)
		{
			return null;
		}

		public static Column TextColumn(Table table, int idx, float minWidth, float maxWidth, Datum headerDatum, Datum footerDatum, bool isInput)
		{
			return null;
		}

		protected Column(Table table, int idx, Datum headerDatum, Datum footerDatum)
		{
		}

		public int CalcFont(bool isHeader, bool isFooter)
		{
			return 0;
		}

		public int CalcFont(Datum d)
		{
			return 0;
		}
	}
}
