namespace Sirenix.OdinInspector
{
	public struct ColumnSize
	{
		public ColumnType ColumnType;

		public float Value;

		public static ColumnSize Auto => default(ColumnSize);

		public ColumnSize(ColumnType columnType, float value)
		{
			ColumnType = default(ColumnType);
			Value = 0f;
		}

		public static ColumnSize Percent(float percentage)
		{
			return default(ColumnSize);
		}

		public static ColumnSize Pixel(float pixels)
		{
			return default(ColumnSize);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
