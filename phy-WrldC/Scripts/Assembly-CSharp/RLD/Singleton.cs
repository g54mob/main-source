namespace RLD
{
	public abstract class Singleton<T> where T : class, new()
	{
		private static T _instance = new T();

		public static T Get => _instance;
	}
}
