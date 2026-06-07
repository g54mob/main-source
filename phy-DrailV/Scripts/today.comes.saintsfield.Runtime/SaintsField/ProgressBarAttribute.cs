using System.Diagnostics;
using SaintsField.Interfaces;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public class ProgressBarAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly float Min;

		public readonly string MinCallback;

		public readonly float Max;

		public readonly string MaxCallback;

		public readonly float Step;

		public readonly EColor Color;

		public readonly string ColorCallback;

		public readonly EColor BackgroundColor;

		public readonly string BackgroundColorCallback;

		public readonly string TitleCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Field;

		public string GroupBy => "__LABEL_FIELD__";

		public ProgressBarAttribute()
			: this(0f, 100f, -1f, EColor.OceanicSlate, EColor.CharcoalGray, null, null, null)
		{
		}

		public ProgressBarAttribute(EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null)
			: this(0f, 100f, -1f, color, backgroundColor, colorCallback, backgroundColorCallback)
		{
		}

		public ProgressBarAttribute(float max)
			: this(0f, max, -1f, EColor.OceanicSlate, EColor.CharcoalGray, null, null, null)
		{
		}

		public ProgressBarAttribute(float max, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null)
			: this(0f, max, -1f, color, backgroundColor, colorCallback, backgroundColorCallback)
		{
		}

		public ProgressBarAttribute(float max, float step)
			: this(0f, max, step)
		{
		}

		public ProgressBarAttribute(string maxCallback)
			: this(0f, maxCallback)
		{
		}

		public ProgressBarAttribute(string maxCallback, float step)
			: this(0f, maxCallback, step)
		{
		}

		public ProgressBarAttribute(string maxCallback = null, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null)
			: this(0f, maxCallback, step, color, backgroundColor, colorCallback, backgroundColorCallback)
		{
		}

		public ProgressBarAttribute(float max = 100f, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null)
			: this(0f, max, step, color, backgroundColor, colorCallback, backgroundColorCallback)
		{
		}

		public ProgressBarAttribute(float min = 0f, float max = 100f, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null, string titleCallback = null)
		{
			Min = min;
			MinCallback = null;
			Max = max;
			MaxCallback = null;
			Step = step;
			Color = color;
			ColorCallback = colorCallback;
			BackgroundColor = backgroundColor;
			BackgroundColorCallback = backgroundColorCallback;
			TitleCallback = titleCallback;
		}

		public ProgressBarAttribute(float min = 0f, string maxCallback = null, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null, string titleCallback = null)
		{
			Min = min;
			MinCallback = null;
			MaxCallback = maxCallback;
			Step = step;
			Color = color;
			ColorCallback = colorCallback;
			BackgroundColor = backgroundColor;
			BackgroundColorCallback = backgroundColorCallback;
			TitleCallback = titleCallback;
		}

		public ProgressBarAttribute(string minCallback = null, float max = 100f, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null, string titleCallback = null)
		{
			MinCallback = minCallback;
			Max = max;
			MaxCallback = null;
			Step = step;
			Color = color;
			ColorCallback = colorCallback;
			BackgroundColor = backgroundColor;
			BackgroundColorCallback = backgroundColorCallback;
			TitleCallback = titleCallback;
		}

		public ProgressBarAttribute(string minCallback = null, string maxCallback = null, float step = -1f, EColor color = EColor.OceanicSlate, EColor backgroundColor = EColor.CharcoalGray, string colorCallback = null, string backgroundColorCallback = null, string titleCallback = null)
		{
			MinCallback = minCallback;
			MaxCallback = maxCallback;
			Step = step;
			Color = color;
			ColorCallback = colorCallback;
			BackgroundColor = backgroundColor;
			BackgroundColorCallback = backgroundColorCallback;
			TitleCallback = titleCallback;
		}
	}
}
