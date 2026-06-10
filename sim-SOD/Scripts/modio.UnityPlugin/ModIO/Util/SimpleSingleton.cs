namespace ModIO.Util
{
	public class SimpleSingleton<T> where T : new()
	{
		private static T _instance;

		public static T Instance
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}
	}
}
