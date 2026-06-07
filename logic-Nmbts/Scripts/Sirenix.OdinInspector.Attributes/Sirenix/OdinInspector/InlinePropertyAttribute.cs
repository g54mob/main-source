using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, Inherited = false)]
	public class InlinePropertyAttribute : Attribute
	{
		public int LabelWidth;
	}
}
