namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	public static class MemberDescriptor
	{
		public static bool HasAllFlags(this MemberDescriptorAccess access, MemberDescriptorAccess flag)
		{
			return false;
		}

		public static bool CanRead(this IMemberDescriptor desc)
		{
			return false;
		}

		public static bool CanWrite(this IMemberDescriptor desc)
		{
			return false;
		}

		public static bool CanExecute(this IMemberDescriptor desc)
		{
			return false;
		}

		public static DynValue GetGetterCallbackAsDynValue(this IMemberDescriptor desc, Script script, object obj)
		{
			return null;
		}

		public static IMemberDescriptor WithAccessOrNull(this IMemberDescriptor desc, MemberDescriptorAccess access)
		{
			return null;
		}

		public static void CheckAccess(this IMemberDescriptor desc, MemberDescriptorAccess access, object obj)
		{
		}
	}
}
