namespace Aura2API
{
	public static class GenericExtensions
	{
		public static T[] Append<T>(this T[] array, T[] appendedArray)
		{
			T[] array2 = new T[array.Length + appendedArray.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = array[i];
			}
			for (int j = 0; j < appendedArray.Length; j++)
			{
				array2[array.Length + j] = appendedArray[j];
			}
			return array2;
		}
	}
}
