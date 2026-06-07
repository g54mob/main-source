namespace UI.Utilities
{
	public class Singleton<T> where T : new()
	{
		private static T _instance;

		public static T I => default(T);
	}
}
