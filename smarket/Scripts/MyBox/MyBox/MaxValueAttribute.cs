using MyBox.Internal;

namespace MyBox
{
	public class MaxValueAttribute : AttributeBase
	{
		private readonly float _x;

		private readonly float _y;

		private readonly float _z;

		private readonly bool _vectorValuesSet;

		public MaxValueAttribute(float value)
		{
		}

		public MaxValueAttribute(float x, float y, float z)
		{
		}
	}
}
