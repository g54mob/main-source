using Google.Protobuf.Reflection;

namespace Google.Protobuf.WellKnownTypes
{
	public static class EmptyReflection
	{
		private static FileDescriptor descriptor;

		public static FileDescriptor Descriptor => null;

		static EmptyReflection()
		{
		}
	}
}
