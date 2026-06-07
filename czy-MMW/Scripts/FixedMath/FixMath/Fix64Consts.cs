namespace FixMath
{
	public static class Fix64Consts
	{
		public static readonly decimal Precision = Fix64.Precision;

		public static readonly Fix64 MaxValue = Fix64.MaxValue;

		public static readonly Fix64 MinValue = Fix64.MinValue;

		public static readonly Fix64 One = Fix64.One;

		public static readonly Fix64 Zero = Fix64.Zero;

		public static readonly Fix64 Pi = Fix64.Pi;

		public static readonly Fix64 PiOver2 = Fix64.PiOver2;

		public static readonly Fix64 PiTimes2 = Fix64.PiTimes2;

		public static readonly Fix64 PiInv = Fix64.PiInv;

		public static readonly Fix64 PiOver2Inv = Fix64.PiOver2Inv;

		public static readonly Fix64 Two = (Fix64)2f;

		public static readonly Fix64 OneHalf = One / Two;

		public static readonly Fix64 SqrtTwo = (Fix64)1.4142135f;

		public static readonly Fix64 Epsilon = Fix64.FromRaw(128L);

		public static readonly Fix64 DegreesToRadians = Pi / (Fix64)180L;

		public static readonly Fix64 RadiansToDegrees = (Fix64)180L / Pi;
	}
}
