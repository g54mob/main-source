using System.Diagnostics;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class Try
	{
		[DebuggerHidden]
		public static bool Failure<T>(out T result)
		{
			result = default(T);
			return false;
		}

		[DebuggerHidden]
		public static bool Success<T>(out T result, T value)
		{
			result = value;
			return true;
		}
	}
}
