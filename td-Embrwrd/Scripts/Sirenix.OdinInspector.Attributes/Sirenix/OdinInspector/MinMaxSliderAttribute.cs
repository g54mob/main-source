using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class MinMaxSliderAttribute : Attribute
	{
		public float MinValue;

		public float MaxValue;

		public string MinValueGetter;

		public string MaxValueGetter;

		public string MinMaxValueGetter;

		public bool ShowFields;

		[Obsolete("Use the MinValueGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use the MaxValueGetter member instead.", false)]
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

		[Obsolete("Use the MinMaxValueGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MinMaxMember
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MinMaxSliderAttribute(float minValue, float maxValue, bool showFields = false)
		{
		}

		public MinMaxSliderAttribute(string minValueGetter, float maxValue, bool showFields = false)
		{
		}

		public MinMaxSliderAttribute(float minValue, string maxValueGetter, bool showFields = false)
		{
		}

		public MinMaxSliderAttribute(string minValueGetter, string maxValueGetter, bool showFields = false)
		{
		}

		public MinMaxSliderAttribute(string minMaxValueGetter, bool showFields = false)
		{
		}
	}
}
