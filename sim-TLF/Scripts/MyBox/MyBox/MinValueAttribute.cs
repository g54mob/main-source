using MyBox.Internal;

namespace MyBox
{
	public class MinValueAttribute : AttributeBase
	{
		private readonly float _x;

		private readonly float _y;

		private readonly float _z;

		private readonly bool _vectorValuesSet;

		public MinValueAttribute(float value)
		{
			_x = value;
		}

		public MinValueAttribute(float x, float y, float z)
		{
			_x = x;
			_y = y;
			_z = z;
			_vectorValuesSet = true;
		}
	}
}
