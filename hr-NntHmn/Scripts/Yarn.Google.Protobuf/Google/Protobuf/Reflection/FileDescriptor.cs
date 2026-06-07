using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class FileDescriptor : IDescriptor
	{
		private readonly Lazy<Dictionary<IDescriptor, DescriptorDeclaration>> declarations;

		internal FileDescriptorProto Proto { get; }

		public Syntax Syntax { get; }

		public string Name => null;

		public string Package => null;

		public IList<MessageDescriptor> MessageTypes { get; }

		public IList<EnumDescriptor> EnumTypes { get; }

		public IList<ServiceDescriptor> Services { get; }

		public ExtensionCollection Extensions { get; }

		public IList<FileDescriptor> Dependencies { get; }

		public IList<FileDescriptor> PublicDependencies { get; }

		public ByteString SerializedData { get; }

		string IDescriptor.FullName => null;

		FileDescriptor IDescriptor.File => null;

		internal DescriptorPool DescriptorPool { get; }

		public static FileDescriptor DescriptorProtoFileDescriptor => null;

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		static FileDescriptor()
		{
		}

		private FileDescriptor(ByteString descriptorData, FileDescriptorProto proto, IEnumerable<FileDescriptor> dependencies, DescriptorPool pool, bool allowUnknownDependencies, GeneratedClrTypeInfo generatedCodeInfo)
		{
		}

		private Dictionary<IDescriptor, DescriptorDeclaration> CreateDeclarationMap()
		{
			return null;
		}

		private IDescriptor FindDescriptorForPath(IList<int> path)
		{
			return null;
		}

		private DescriptorBase GetDescriptorFromList(IReadOnlyList<DescriptorBase> list, int index)
		{
			return null;
		}

		private IReadOnlyList<DescriptorBase> GetNestedDescriptorListForField(int fieldNumber)
		{
			return null;
		}

		internal DescriptorDeclaration GetDeclaration(IDescriptor descriptor)
		{
			return null;
		}

		internal string ComputeFullName(MessageDescriptor parent, string name)
		{
			return null;
		}

		private static IList<FileDescriptor> DeterminePublicDependencies(FileDescriptor @this, FileDescriptorProto proto, IEnumerable<FileDescriptor> dependencies, bool allowUnknownDependencies)
		{
			return null;
		}

		public FileDescriptorProto ToProto()
		{
			return null;
		}

		public T FindTypeByName<T>(string name) where T : class, IDescriptor
		{
			return null;
		}

		private static FileDescriptor BuildFrom(ByteString descriptorData, FileDescriptorProto proto, FileDescriptor[] dependencies, bool allowUnknownDependencies, GeneratedClrTypeInfo generatedCodeInfo)
		{
			return null;
		}

		private void CrossLink()
		{
		}

		public static FileDescriptor FromGeneratedCode(byte[] descriptorData, FileDescriptor[] dependencies, GeneratedClrTypeInfo generatedCodeInfo)
		{
			return null;
		}

		private static IEnumerable<Extension> GetAllExtensions(FileDescriptor[] dependencies, GeneratedClrTypeInfo generatedInfo)
		{
			return null;
		}

		private static IEnumerable<Extension> GetAllGeneratedExtensions(GeneratedClrTypeInfo generated)
		{
			return null;
		}

		private static IEnumerable<Extension> GetAllDependedExtensions(FileDescriptor descriptor)
		{
			return null;
		}

		private static IEnumerable<Extension> GetAllDependedExtensionsFromMessage(MessageDescriptor descriptor)
		{
			return null;
		}

		public static IReadOnlyList<FileDescriptor> BuildFromByteStrings(IEnumerable<ByteString> descriptorData, ExtensionRegistry registry)
		{
			return null;
		}

		public static IReadOnlyList<FileDescriptor> BuildFromByteStrings(IEnumerable<ByteString> descriptorData)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public FileOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<FileOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<FileOptions, T> extension)
		{
			return null;
		}

		public static void ForceReflectionInitialization<T>()
		{
		}
	}
}
