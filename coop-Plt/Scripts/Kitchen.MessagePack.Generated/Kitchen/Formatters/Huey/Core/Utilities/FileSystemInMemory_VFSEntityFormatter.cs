using Huey.Core.Utilities;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Huey.Core.Utilities
{
	public sealed class FileSystemInMemory_VFSEntityFormatter : IMessagePackFormatter<FileSystemInMemory.VFSEntity>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, FileSystemInMemory.VFSEntity value, MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(6);
			resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value._fullPath, options);
			writer.Write(value._data);
			writer.WriteNil();
			writer.Write(value.LastWriteTime);
			writer.Write(value.LastAccessTime);
			writer.Write(value.CreationTime);
		}

		public FileSystemInMemory.VFSEntity Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			FileSystemInMemory.VFSEntity vFSEntity = new FileSystemInMemory.VFSEntity();
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					vFSEntity._fullPath = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
					break;
				case 1:
					vFSEntity._data = CodeGenHelpers.GetArrayFromNullableSequence(reader.ReadBytes());
					break;
				case 3:
					vFSEntity.LastWriteTime = reader.ReadInt64();
					break;
				case 4:
					vFSEntity.LastAccessTime = reader.ReadInt64();
					break;
				case 5:
					vFSEntity.CreationTime = reader.ReadInt64();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return vFSEntity;
		}
	}
}
