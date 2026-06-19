namespace System.Reflection
{
	public static class ReflectionExtensions
	{
		public static bool IsConstructedGenericType(this TypeInfo type)
		{
			return type.IsConstructedGenericType;
		}
	}
}
