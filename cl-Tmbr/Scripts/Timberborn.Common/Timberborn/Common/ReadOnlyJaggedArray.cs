namespace Timberborn.Common
{
	public readonly struct ReadOnlyJaggedArray<T>
	{
		private readonly T[][] _array;

		public ReadOnlyJaggedArray(T[][] array)
		{
			_array = array;
		}

		public ref readonly T Get(int row, int column)
		{
			return ref _array[row][column];
		}
	}
}
