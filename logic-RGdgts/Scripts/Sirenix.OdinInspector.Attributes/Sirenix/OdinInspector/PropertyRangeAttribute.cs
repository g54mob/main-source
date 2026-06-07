using System;

namespace Sirenix.OdinInspector
{
	public sealed class PropertyRangeAttribute : Attribute
	{
		public double Min;

		public double Max;

		public string MinGetter;

		public string MaxGetter;

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

		public PropertyRangeAttribute(double min, double max)
		{
		}

		public PropertyRangeAttribute(string minGetter, double max)
		{
		}

		public PropertyRangeAttribute(double min, string maxGetter)
		{
		}

		public PropertyRangeAttribute(string minGetter, string maxGetter)
		{
		}
	}
}
