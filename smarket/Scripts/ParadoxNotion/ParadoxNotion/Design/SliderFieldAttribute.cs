using System;

namespace ParadoxNotion.Design
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SliderFieldAttribute : DrawerAttribute
	{
		public readonly float min;

		public readonly float max;

		public SliderFieldAttribute(float min, float max)
		{
		}

		public SliderFieldAttribute(int min, int max)
		{
		}
	}
}
