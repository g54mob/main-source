using FullInspector;

namespace TH20
{
	public static class SharedInstanceExtension
	{
		public static bool IsNull<T>(this SharedInstance<T> instance)
		{
			if (!(instance == null))
			{
				return instance.Instance == null;
			}
			return true;
		}

		public static bool NotNull<T>(this SharedInstance<T> instance)
		{
			if (instance != null)
			{
				return instance.Instance != null;
			}
			return false;
		}
	}
}
