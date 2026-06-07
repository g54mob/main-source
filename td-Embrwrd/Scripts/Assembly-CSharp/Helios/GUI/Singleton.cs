namespace Helios.GUI
{
	public class Singleton<T> where T : new()
	{
		private static T _instance;

		public static T Instance => default(T);
	}
}
