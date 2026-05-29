namespace MyBox
{
	public static class MyReflection
	{
		public static bool HasMethod(this object target, string methodName)
		{
			return false;
		}

		public static bool HasField(this object target, string fieldName)
		{
			return false;
		}

		public static bool HasProperty(this object target, string propertyName)
		{
			return false;
		}
	}
}
