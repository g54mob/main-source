using System;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	public sealed class ProgressBarAttribute : Attribute
	{
		public double Min;

		public double Max;

		public string MinGetter;

		public string MaxGetter;

		public float R;

		public float G;

		public float B;

		public int Height;

		public string ColorGetter;

		public string BackgroundColorGetter;

		public bool Segmented;

		public string CustomValueStringGetter;

		private bool drawValueLabel;

		private TextAlignment valueLabelAlignment;

		[Obsolete]
		public string MinMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public string MaxMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public string ColorMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public string BackgroundColorMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public string CustomValueStringMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool DrawValueLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DrawValueLabelHasValue { get; private set; }

		public TextAlignment ValueLabelAlignment
		{
			get
			{
				return default(TextAlignment);
			}
			set
			{
			}
		}

		public bool ValueLabelAlignmentHasValue { get; private set; }

		public Color Color => default(Color);

		public ProgressBarAttribute(double min, double max, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
		}

		public ProgressBarAttribute(string minGetter, double max, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
		}

		public ProgressBarAttribute(double min, string maxGetter, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
		}

		public ProgressBarAttribute(string minGetter, string maxGetter, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
		}
	}
}
