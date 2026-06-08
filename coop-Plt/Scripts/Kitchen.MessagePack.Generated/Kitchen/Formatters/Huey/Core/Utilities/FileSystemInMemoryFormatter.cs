using System.Collections.Generic;
using Huey.Core.Utilities;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Huey.Core.Utilities
{
	public sealed class FileSystemInMemoryFormatter : IMessagePackFormatter<FileSystemInMemory>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FileSystemInMemory value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(2);
			resolver.GetFormatterWithVerify<List<FileSystemInMemory.VFSEntity>>().Serialize(ref writer, value._files, options);
			resolver.GetFormatterWithVerify<List<string>>().Serialize(ref writer, value._directories, options);
		}

		public FileSystemInMemory Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			FileSystemInMemory fileSystemInMemory = new FileSystemInMemory();
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					fileSystemInMemory._files = resolver.GetFormatterWithVerify<List<FileSystemInMemory.VFSEntity>>().Deserialize(ref reader, options);
					break;
				case 1:
					fileSystemInMemory._directories = resolver.GetFormatterWithVerify<List<string>>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return fileSystemInMemory;
		}
	}
}
