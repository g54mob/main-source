namespace Simulation
{
	public struct RowInfo_t
	{
		public const int ROW_NORMAL = 0;

		public const int ROW_CONST = 1;

		public const int ROW_EQUAL = 2;

		public int nodeEq;

		public int type;

		public int mapCol;

		public int mapRow;

		public double value;

		public bool rsChanges;

		public bool lsChanges;

		public bool dropRow;
	}
}
