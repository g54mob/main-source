namespace Pathfinding.Util
{
	public static class ObjectPool<T> where T : class, IAstarPooledObject, new()
	{
		public static T Claim()
		{
			return null;
		}

		public static void Release(ref T obj)
		{
		}
	}
}
