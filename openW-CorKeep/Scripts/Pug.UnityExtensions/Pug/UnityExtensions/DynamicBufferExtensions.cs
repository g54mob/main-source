using Unity.Entities;

namespace Pug.UnityExtensions
{
	public static class DynamicBufferExtensions
	{
		public static bool Contains<T>(this DynamicBuffer<T> buffer, T value) where T : unmanaged
		{
			foreach (T item in buffer)
			{
				if (item.Equals(value))
				{
					return true;
				}
			}
			return false;
		}
	}
}
