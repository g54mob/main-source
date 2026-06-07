namespace GameCreator.Runtime.Common
{
	public static class Settings
	{
		public static T From<T>() where T : class, IRepository, new()
		{
			return TRepository<T>.Get;
		}
	}
}
