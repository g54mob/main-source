namespace Google.Protobuf.Reflection
{
	internal sealed class PackageDescriptor : IDescriptor
	{
		public string Name { get; }

		public string FullName { get; }

		public FileDescriptor File { get; }

		internal PackageDescriptor(string name, string fullName, FileDescriptor file)
		{
		}
	}
}
