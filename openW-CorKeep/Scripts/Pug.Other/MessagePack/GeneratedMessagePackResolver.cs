using System;
using System.Collections.Generic;
using MessagePack.Formatters;
using MessagePack.Internal;
using Pug.UnityExtensions;
using UnityEngine;

namespace MessagePack
{
	internal class GeneratedMessagePackResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			internal static readonly IMessagePackFormatter<T> Formatter;

			static FormatterCache()
			{
				object formatter = GeneratedMessagePackResolverGetFormatterHelper.GetFormatter(typeof(T));
				if (formatter != null)
				{
					Formatter = (IMessagePackFormatter<T>)formatter;
				}
			}
		}

		private static class GeneratedMessagePackResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, int> closedTypeLookup = new Dictionary<Type, int>(5)
			{
				{
					typeof(SerializableDictionary<Vector2Int, MapPartSerialized>),
					0
				},
				{
					typeof(KeyValuePair<Vector2Int, MapPartSerialized>),
					1
				},
				{
					typeof(MapFile),
					2
				},
				{
					typeof(MapPartSerialized),
					3
				},
				{
					typeof(MapTimestampHash),
					4
				}
			};

			internal static object GetFormatter(Type t)
			{
				if (closedTypeLookup.TryGetValue(t, out var value))
				{
					return value switch
					{
						0 => new GenericCollectionFormatter<KeyValuePair<Vector2Int, MapPartSerialized>, SerializableDictionary<Vector2Int, MapPartSerialized>>(), 
						1 => new KeyValuePairFormatter<Vector2Int, MapPartSerialized>(), 
						2 => new MapFileFormatter(), 
						3 => new MapPartSerializedFormatter(), 
						4 => new MapTimestampHashFormatter(), 
						_ => null, 
					};
				}
				return null;
			}
		}

		internal sealed class MapFileFormatter : IMessagePackFormatter<MapFile>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, MapFile value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(1);
				resolver.GetFormatterWithVerify<SerializableDictionary<Vector2Int, MapPartSerialized>>().Serialize(ref writer, value.mapParts, options);
			}

			public MapFile Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				MapFile mapFile = new MapFile();
				for (int i = 0; i < num; i++)
				{
					if (i == 0)
					{
						mapFile.mapParts = resolver.GetFormatterWithVerify<SerializableDictionary<Vector2Int, MapPartSerialized>>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
				reader.Depth--;
				return mapFile;
			}
		}

		internal sealed class MapPartSerializedFormatter : IMessagePackFormatter<MapPartSerialized>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, MapPartSerialized value, MessagePackSerializerOptions options)
			{
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(3);
				writer.Write(value.png);
				writer.Write(value.timestampPng);
				resolver.GetFormatterWithVerify<MapTimestampHash>().Serialize(ref writer, value.TimestampHash, options);
			}

			public MapPartSerialized Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					throw new InvalidOperationException("typecode is null, struct not supported");
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				MapTimestampHash timestampHash = default(MapTimestampHash);
				byte[] png = null;
				byte[] timestampPng = null;
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						png = CodeGenHelpers.GetArrayFromNullableSequence(reader.ReadBytes());
						break;
					case 1:
						timestampPng = CodeGenHelpers.GetArrayFromNullableSequence(reader.ReadBytes());
						break;
					case 2:
						timestampHash = resolver.GetFormatterWithVerify<MapTimestampHash>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				MapPartSerialized result = new MapPartSerialized(png, timestampPng, timestampHash);
				reader.Depth--;
				return result;
			}
		}

		internal sealed class MapTimestampHashFormatter : IMessagePackFormatter<MapTimestampHash>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, MapTimestampHash value, MessagePackSerializerOptions options)
			{
				writer.WriteArrayHeader(2);
				writer.Write(value.H1);
				writer.Write(value.H2);
			}

			public MapTimestampHash Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					throw new InvalidOperationException("typecode is null, struct not supported");
				}
				options.Security.DepthStep(ref reader);
				int num = reader.ReadArrayHeader();
				ulong h = 0uL;
				ulong h2 = 0uL;
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						h = reader.ReadUInt64();
						break;
					case 1:
						h2 = reader.ReadUInt64();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				MapTimestampHash result = new MapTimestampHash(h, h2);
				reader.Depth--;
				return result;
			}
		}

		public static readonly IFormatterResolver Instance = new GeneratedMessagePackResolver();

		private GeneratedMessagePackResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}
	}
}
