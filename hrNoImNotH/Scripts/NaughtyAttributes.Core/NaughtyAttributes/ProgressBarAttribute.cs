using System;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ProgressBarAttribute : DrawerAttribute
	{
		public string Name { get; private set; }

		public float MaxValue { get; set; }

		public string MaxValueName { get; private set; }

		public EColor Color { get; private set; }

		public ProgressBarAttribute(string name, float maxValue, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(string name, string maxValueName, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(float maxValue, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(string maxValueName, EColor color = EColor.Blue)
		{
		}
	}
}
