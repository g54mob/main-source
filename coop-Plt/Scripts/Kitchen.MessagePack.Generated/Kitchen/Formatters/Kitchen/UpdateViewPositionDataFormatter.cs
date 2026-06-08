using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class UpdateViewPositionDataFormatter : IMessagePackFormatter<UpdateViewPositionData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, UpdateViewPositionData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(5);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.Position, options);
			resolver.GetFormatterWithVerify<Quaternion>().Serialize(ref writer, value.Rotation, options);
			writer.Write(value.Force);
			resolver.GetFormatterWithVerify<ViewMode>().Serialize(ref writer, value.Mode, options);
			writer.Write(value.GameTime);
		}

		public UpdateViewPositionData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			UpdateViewPositionData result = default(UpdateViewPositionData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Position = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Rotation = resolver.GetFormatterWithVerify<Quaternion>().Deserialize(ref reader, options);
					break;
				case 2:
					result.Force = reader.ReadBoolean();
					break;
				case 3:
					result.Mode = resolver.GetFormatterWithVerify<ViewMode>().Deserialize(ref reader, options);
					break;
				case 4:
					result.GameTime = reader.ReadSingle();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
