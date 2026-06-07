namespace RLD
{
	public class AxisDescriptor
	{
		private AxisSign _sign;

		private int _index;

		public AxisSign Sign => _sign;

		public int Index => _index;

		public bool IsPositive => _sign == AxisSign.Positive;

		public bool IsNegative => _sign == AxisSign.Negative;

		public AxisDescriptor(int axisIndex, AxisSign axisSign)
		{
			_sign = axisSign;
			_index = axisIndex;
		}

		public AxisDescriptor(int axisIndex, bool isNegative)
		{
			_sign = (isNegative ? AxisSign.Negative : AxisSign.Positive);
			_index = axisIndex;
		}

		public BoxFace GetAssociatedBoxFace()
		{
			if (_sign == AxisSign.Negative)
			{
				if (_index == 0)
				{
					return BoxFace.Left;
				}
				if (_index == 1)
				{
					return BoxFace.Bottom;
				}
				return BoxFace.Front;
			}
			if (_index == 0)
			{
				return BoxFace.Right;
			}
			if (_index == 1)
			{
				return BoxFace.Top;
			}
			return BoxFace.Back;
		}
	}
}
