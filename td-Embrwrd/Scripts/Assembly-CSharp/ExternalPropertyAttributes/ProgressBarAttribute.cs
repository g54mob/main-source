using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ProgressBarAttribute : DrawerAttribute
	{
		public string Name { get; private set; }

		public float MaxValue { get; set; }

		public string MaxValueName { get; private set; }

		public EColor Color { get; private set; }

		public ProgressBarAttribute(string name, int maxValue, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(string name, string maxValueName, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(int maxValue, EColor color = EColor.Blue)
		{
		}

		public ProgressBarAttribute(string maxValueName, EColor color = EColor.Blue)
		{
		}
	}
}
