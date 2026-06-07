using UnityEngine;

namespace SLS.Widgets.Table
{
	public class Element
	{
		private string _value;

		private Color? _color;

		private Color? _backgroundColor;

		public float? measuredWidth;

		public float? measuredHeight;

		public Datum datum { get; private set; }

		public int idx { get; private set; }

		public string tooltip { get; set; }

		public string value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color? color
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color? backgroundColor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Element(Datum d, string value, int idx = -1)
		{
		}

		public void ClearMeasure()
		{
		}
	}
}
