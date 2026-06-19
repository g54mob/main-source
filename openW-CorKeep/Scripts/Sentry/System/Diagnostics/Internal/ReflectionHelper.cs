namespace System.Diagnostics.Internal
{
	internal static class ReflectionHelper
	{
		public static bool IsValueTuple(this Type type)
		{
			if (type.Namespace == "System")
			{
				return type.Name.Contains("ValueTuple`");
			}
			return false;
		}
	}
}
