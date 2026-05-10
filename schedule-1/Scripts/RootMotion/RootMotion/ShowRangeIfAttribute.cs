using System;

namespace RootMotion
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class ShowRangeIfAttribute : ShowIfAttribute
	{
		public float min { get; private set; }

		public float max { get; private set; }

		public ShowRangeIfAttribute(float min, float max, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden)
			: base(null, null, null, indent: false, default(ShowIfMode))
		{
		}
	}
}
