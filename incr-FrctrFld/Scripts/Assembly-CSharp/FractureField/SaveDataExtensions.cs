namespace FractureField
{
	public static class SaveDataExtensions
	{
		public static T ReserializeAs<T>(this IConvertableSaveData saveData)
		{
			return default(T);
		}
	}
}
