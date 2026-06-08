namespace Jobberwocky.GeometryAlgorithms.Source.Core
{
	public struct EdgeInt
	{
		private int _003CX_003Ek__BackingField;

		private int _003CY_003Ek__BackingField;

		public int X
		{
			get
			{
				return _003CX_003Ek__BackingField;
			}
			set
			{
				_003CX_003Ek__BackingField = value;
			}
		}

		public int Y
		{
			get
			{
				return _003CY_003Ek__BackingField;
			}
			set
			{
				_003CY_003Ek__BackingField = value;
			}
		}

		public EdgeInt(int x, int y)
		{
			X = x;
			Y = y;
		}

		public string GetKey()
		{
			if (X < Y)
			{
				return Y.ToString() + X;
			}
			return X.ToString() + Y;
		}
	}
}
