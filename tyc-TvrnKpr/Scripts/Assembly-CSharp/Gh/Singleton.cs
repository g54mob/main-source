namespace Gh
{
	public static class Singleton<T> where T : class
	{
		public static readonly T Instance;

		static Singleton()
		{
		}
	}
}
