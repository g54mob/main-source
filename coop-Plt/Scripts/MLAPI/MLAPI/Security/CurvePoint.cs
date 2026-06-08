namespace MLAPI.Security
{
	internal class CurvePoint
	{
		public static readonly CurvePoint POINT_AT_INFINITY = new CurvePoint();

		private readonly bool pai;

		public BigInteger X { get; private set; }

		public BigInteger Y { get; private set; }

		public CurvePoint(BigInteger x, BigInteger y)
		{
			X = x;
			Y = y;
		}

		private CurvePoint()
		{
			pai = true;
		}

		public override string ToString()
		{
			if (!pai)
			{
				return string.Concat("(", X, ", ", Y, ")");
			}
			return "(POINT_AT_INFINITY)";
		}
	}
}
