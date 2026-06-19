using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FullInspector.Internal.Preserve;
using FullInspector.Serializers.FullSerializer;
using FullSerializer;
using FullSerializer.Internal;
using UnityEngine;

namespace FullInspector
{
	[Preserve]
	public class FullSerializerSerializer : BaseSerializer
	{
		[ThreadStatic]
		private static fsSerializer _serializer;

		private static readonly List<fsSerializer> _serializers;

		private static readonly List<Type> _converters;

		private static readonly List<Type> _processors;

		private static fsSerializer Serializer
		{
			get
			{
				if (_serializer == null)
				{
					lock (typeof(FullSerializerSerializer))
					{
						_serializer = new fsSerializer();
						_serializers.Add(_serializer);
						_serializer.RemoveProcessor<fsSerializationCallbackReceiverProcessor>();
						foreach (Type converter in _converters)
						{
							_serializer.AddConverter((fsConverter)Activator.CreateInstance(converter));
						}
						foreach (Type processor in _processors)
						{
							_serializer.AddProcessor((fsObjectProcessor)Activator.CreateInstance(processor));
						}
					}
				}
				return _serializer;
			}
		}

		public override bool SupportsMultithreading => true;

		public static fsSerializer SerializerInstance => Serializer;

		public static void AddConverter<TConverter>() where TConverter : fsConverter, new()
		{
			lock (typeof(FullSerializerSerializer))
			{
				_converters.Add(typeof(TConverter));
				foreach (fsSerializer serializer in _serializers)
				{
					serializer.AddConverter(new TConverter());
				}
			}
		}

		public static void AddProcessor<TProcessor>() where TProcessor : fsObjectProcessor, new()
		{
			lock (typeof(FullSerializerSerializer))
			{
				_processors.Add(typeof(TProcessor));
				foreach (fsSerializer serializer in _serializers)
				{
					serializer.AddProcessor(new TProcessor());
				}
			}
		}

		static FullSerializerSerializer()
		{
			_serializers = new List<fsSerializer>();
			_converters = new List<Type>();
			_processors = new List<Type>();
			AddConverter<UnityObjectConverter>();
			AddProcessor<SerializationCallbackReceiverObjectProcessor>();
		}

		public override string Serialize(MemberInfo storageType, object value, ISerializationOperator serializationOperator)
		{
			Serializer.Context.Set(serializationOperator);
			if (EmitFailWarning(Serializer.TrySerialize(BaseSerializer.GetStorageType(storageType), null, value, out var data)))
			{
				return null;
			}
			if (fiSettings.PrettyPrintSerializedJson)
			{
				return fsJsonPrinter.PrettyJson(data);
			}
			return fsJsonPrinter.CompressedJson(data);
		}

		public override object Deserialize(MemberInfo storageType, string serializedState, ISerializationOperator serializationOperator)
		{
			if (EmitFailWarning(fsJsonParser.Parse(serializedState, out var data)))
			{
				return null;
			}
			Serializer.Context.Set(serializationOperator);
			object result = null;
			if (EmitFailWarning(Serializer.TryDeserialize(data, BaseSerializer.GetStorageType(storageType), null, ref result)))
			{
				return null;
			}
			return result;
		}

		private static bool EmitFailWarning(fsResult result)
		{
			if (fiSettings.EmitWarnings && result.RawMessages.Any())
			{
				Debug.LogWarning(result.FormattedMessages);
			}
			return result.Failed;
		}
	}
}
