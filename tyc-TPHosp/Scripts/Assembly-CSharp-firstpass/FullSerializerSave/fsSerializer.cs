using System;
using System.Collections.Generic;
using FullSerializerSave.Internal;

namespace FullSerializerSave
{
	public class fsSerializer
	{
		internal class fsLazyCycleDefinitionWriter
		{
			private Dictionary<int, fsData> _pendingDefinitions = new Dictionary<int, fsData>();

			private HashSet<int> _references = new HashSet<int>();

			public void WriteDefinition(int id, fsData data)
			{
				if (_references.Contains(id))
				{
					EnsureDictionary(data);
					data.AsDictionary[Key_ObjectDefinition] = new fsData(id.ToString());
				}
				else
				{
					_pendingDefinitions[id] = data;
				}
			}

			public void WriteReference(int id, Dictionary<string, fsData> dict)
			{
				if (_pendingDefinitions.ContainsKey(id))
				{
					fsData obj = _pendingDefinitions[id];
					EnsureDictionary(obj);
					obj.AsDictionary[Key_ObjectDefinition] = new fsData(id.ToString());
					_pendingDefinitions.Remove(id);
				}
				else
				{
					_references.Add(id);
				}
				dict[Key_ObjectReference] = new fsData(id.ToString());
			}

			public void Clear()
			{
				_pendingDefinitions.Clear();
				_references.Clear();
			}
		}

		private static HashSet<string> _reservedKeywords;

		private static readonly string Key_ObjectReference;

		private static readonly string Key_ObjectDefinition;

		private static readonly string Key_InstanceType;

		private static readonly string Key_Version;

		private static readonly string Key_Content;

		private Dictionary<Type, fsBaseConverter> _cachedConverterTypeInstances;

		private Dictionary<Type, fsBaseConverter> _cachedConverters;

		private Dictionary<Type, List<fsObjectProcessor>> _cachedProcessors;

		private readonly List<fsConverter> _availableConverters;

		private readonly Dictionary<Type, fsDirectConverter> _availableDirectConverters;

		private readonly List<fsObjectProcessor> _processors;

		private readonly fsCyclicReferenceManager _references;

		private readonly fsLazyCycleDefinitionWriter _lazyReferenceWriter;

		private readonly Dictionary<Type, Type> _abstractTypeRemap;

		public fsContext Context;

		public fsConfig Config;

		static fsSerializer()
		{
			Key_ObjectReference = $"{fsGlobalConfig.InternalFieldPrefix}ref";
			Key_ObjectDefinition = $"{fsGlobalConfig.InternalFieldPrefix}id";
			Key_InstanceType = $"{fsGlobalConfig.InternalFieldPrefix}type";
			Key_Version = $"{fsGlobalConfig.InternalFieldPrefix}version";
			Key_Content = $"{fsGlobalConfig.InternalFieldPrefix}content";
			_reservedKeywords = new HashSet<string> { Key_ObjectReference, Key_ObjectDefinition, Key_InstanceType, Key_Version, Key_Content };
		}

		public static bool IsReservedKeyword(string key)
		{
			return _reservedKeywords.Contains(key);
		}

		private static bool IsObjectReference(fsData data)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			return data.AsDictionary.ContainsKey(Key_ObjectReference);
		}

		private static bool IsObjectDefinition(fsData data)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			return data.AsDictionary.ContainsKey(Key_ObjectDefinition);
		}

		private static bool IsVersioned(fsData data, fsConfig config)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			if (config.VersionAllClasses)
			{
				return true;
			}
			return data.AsDictionary.ContainsKey(Key_Version);
		}

		private static bool IsTypeSpecified(fsData data)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			return data.AsDictionary.ContainsKey(Key_InstanceType);
		}

		private static bool IsWrappedData(fsData data)
		{
			if (!data.IsDictionary)
			{
				return false;
			}
			return data.AsDictionary.ContainsKey(Key_Content);
		}

		public static void StripDeserializationMetadata(ref fsData data)
		{
			if (data.IsDictionary && data.AsDictionary.ContainsKey(Key_Content))
			{
				data = data.AsDictionary[Key_Content];
			}
			if (data.IsDictionary)
			{
				Dictionary<string, fsData> asDictionary = data.AsDictionary;
				asDictionary.Remove(Key_ObjectReference);
				asDictionary.Remove(Key_ObjectDefinition);
				asDictionary.Remove(Key_InstanceType);
				asDictionary.Remove(Key_Version);
			}
		}

		private static void ConvertLegacyData(ref fsData data)
		{
			if (!data.IsDictionary)
			{
				return;
			}
			Dictionary<string, fsData> asDictionary = data.AsDictionary;
			if (asDictionary.Count <= 2)
			{
				string key = "ReferenceId";
				string key2 = "SourceId";
				string key3 = "Data";
				string key4 = "Type";
				string key5 = "Data";
				if (asDictionary.Count == 2 && asDictionary.ContainsKey(key4) && asDictionary.ContainsKey(key5))
				{
					data = asDictionary[key5];
					EnsureDictionary(data);
					ConvertLegacyData(ref data);
					data.AsDictionary[Key_InstanceType] = asDictionary[key4];
				}
				else if (asDictionary.Count == 2 && asDictionary.ContainsKey(key2) && asDictionary.ContainsKey(key3))
				{
					data = asDictionary[key3];
					EnsureDictionary(data);
					ConvertLegacyData(ref data);
					data.AsDictionary[Key_ObjectDefinition] = asDictionary[key2];
				}
				else if (asDictionary.Count == 1 && asDictionary.ContainsKey(key))
				{
					data = fsData.CreateDictionary();
					data.AsDictionary[Key_ObjectReference] = asDictionary[key];
				}
			}
		}

		private static void Invoke_OnBeforeSerialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeSerialize(storageType, instance);
			}
		}

		private static void Invoke_OnBeforeSerializeInstance(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeSerializeInstance(storageType, instance);
			}
		}

		private static void Invoke_OnAfterSerialize(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int num = processors.Count - 1; num >= 0; num--)
			{
				processors[num].OnAfterSerialize(storageType, instance, ref data);
			}
		}

		private static void Invoke_OnAfterSerializeInstance(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int num = processors.Count - 1; num >= 0; num--)
			{
				processors[num].OnAfterSerializeInstance(storageType, instance, ref data);
			}
		}

		private static void Invoke_OnBeforeDeserialize(List<fsObjectProcessor> processors, Type storageType, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserialize(storageType, ref data);
			}
		}

		private static void Invoke_OnBeforeDeserializeAfterInstanceCreation(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
			for (int i = 0; i < processors.Count; i++)
			{
				processors[i].OnBeforeDeserializeAfterInstanceCreation(storageType, instance, ref data);
			}
		}

		private static void Invoke_OnAfterDeserialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int num = processors.Count - 1; num >= 0; num--)
			{
				processors[num].OnAfterDeserialize(storageType, instance);
			}
		}

		private static void Invoke_OnAfterDeserializeInstance(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
			for (int num = processors.Count - 1; num >= 0; num--)
			{
				processors[num].OnAfterDeserializeInstance(storageType, instance);
			}
		}

		private static void EnsureDictionary(fsData data)
		{
			if (!data.IsDictionary)
			{
				fsData value = data.Clone();
				data.BecomeDictionary();
				data.AsDictionary[Key_Content] = value;
			}
		}

		private void RemapAbstractStorageTypeToDefaultType(ref Type storageType)
		{
			if (!storageType.IsInterface() && !storageType.IsAbstract())
			{
				return;
			}
			Type value2;
			if (storageType.IsGenericType())
			{
				if (_abstractTypeRemap.TryGetValue(storageType.GetGenericTypeDefinition(), out var value))
				{
					Type[] genericArguments = storageType.GetGenericArguments();
					storageType = value.MakeGenericType(genericArguments);
				}
			}
			else if (_abstractTypeRemap.TryGetValue(storageType, out value2))
			{
				storageType = value2;
			}
		}

		public fsSerializer()
		{
			_cachedConverterTypeInstances = new Dictionary<Type, fsBaseConverter>();
			_cachedConverters = new Dictionary<Type, fsBaseConverter>();
			_cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
			_references = new fsCyclicReferenceManager();
			_lazyReferenceWriter = new fsLazyCycleDefinitionWriter();
			_availableConverters = new List<fsConverter>
			{
				new fsNullableConverter
				{
					Serializer = this
				},
				new fsGuidConverter
				{
					Serializer = this
				},
				new fsTypeConverter
				{
					Serializer = this
				},
				new fsDateConverter
				{
					Serializer = this
				},
				new fsEnumConverter
				{
					Serializer = this
				},
				new fsPrimitiveConverter
				{
					Serializer = this
				},
				new fsArrayConverter
				{
					Serializer = this
				},
				new fs2DArrayConverter
				{
					Serializer = this
				},
				new fsDictionaryConverter
				{
					Serializer = this
				},
				new fsIEnumerableConverter
				{
					Serializer = this
				},
				new fsKeyValuePairConverter
				{
					Serializer = this
				},
				new fsWeakReferenceConverter
				{
					Serializer = this
				},
				new fsReflectedConverter
				{
					Serializer = this
				}
			};
			_availableDirectConverters = new Dictionary<Type, fsDirectConverter>();
			_processors = new List<fsObjectProcessor>
			{
				new fsSerializationCallbackProcessor()
			};
			_processors.Add(new fsSerializationCallbackReceiverProcessor());
			_abstractTypeRemap = new Dictionary<Type, Type>();
			SetDefaultStorageType(typeof(ICollection<>), typeof(List<>));
			SetDefaultStorageType(typeof(IList<>), typeof(List<>));
			SetDefaultStorageType(typeof(IDictionary<, >), typeof(Dictionary<, >));
			Context = new fsContext();
			Config = new fsConfig();
			foreach (Type converter in fsConverterRegistrar.Converters)
			{
				AddConverter((fsBaseConverter)Activator.CreateInstance(converter));
			}
		}

		public void AddProcessor(fsObjectProcessor processor)
		{
			_processors.Add(processor);
			_cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		public void RemoveProcessor<TProcessor>()
		{
			int num = 0;
			while (num < _processors.Count)
			{
				if (_processors[num] is TProcessor)
				{
					_processors.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			_cachedProcessors = new Dictionary<Type, List<fsObjectProcessor>>();
		}

		public void SetDefaultStorageType(Type abstractType, Type defaultStorageType)
		{
			if (!abstractType.IsInterface() && !abstractType.IsAbstract())
			{
				throw new ArgumentException("|abstractType| must be an interface or abstract type");
			}
			_abstractTypeRemap[abstractType] = defaultStorageType;
		}

		private List<fsObjectProcessor> GetProcessors(Type type)
		{
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			List<fsObjectProcessor> value;
			if (attribute != null && attribute.Processor != null)
			{
				fsObjectProcessor item = (fsObjectProcessor)Activator.CreateInstance(attribute.Processor);
				value = new List<fsObjectProcessor>();
				value.Add(item);
				_cachedProcessors[type] = value;
			}
			else if (!_cachedProcessors.TryGetValue(type, out value))
			{
				value = new List<fsObjectProcessor>();
				for (int i = 0; i < _processors.Count; i++)
				{
					fsObjectProcessor fsObjectProcessor2 = _processors[i];
					if (fsObjectProcessor2.CanProcess(type))
					{
						value.Add(fsObjectProcessor2);
					}
				}
				_cachedProcessors[type] = value;
			}
			return value;
		}

		public void AddConverter(fsBaseConverter converter)
		{
			if (converter.Serializer != null)
			{
				throw new InvalidOperationException("Cannot add a single converter instance to multiple fsConverters -- please construct a new instance for " + converter);
			}
			if (converter is fsDirectConverter)
			{
				fsDirectConverter fsDirectConverter2 = (fsDirectConverter)converter;
				_availableDirectConverters[fsDirectConverter2.ModelType] = fsDirectConverter2;
			}
			else
			{
				if (!(converter is fsConverter))
				{
					throw new InvalidOperationException("Unable to add converter " + converter?.ToString() + "; the type association strategy is unknown. Please use either fsDirectConverter or fsConverter as your base type.");
				}
				_availableConverters.Insert(0, (fsConverter)converter);
			}
			converter.Serializer = this;
			_cachedConverters = new Dictionary<Type, fsBaseConverter>();
		}

		private fsBaseConverter GetConverter(Type type, Type overrideConverterType)
		{
			if (overrideConverterType != null)
			{
				if (!_cachedConverterTypeInstances.TryGetValue(overrideConverterType, out var value))
				{
					value = (fsBaseConverter)Activator.CreateInstance(overrideConverterType);
					value.Serializer = this;
					_cachedConverterTypeInstances[overrideConverterType] = value;
				}
				return value;
			}
			if (_cachedConverters.TryGetValue(type, out var value2))
			{
				return value2;
			}
			fsObjectAttribute attribute = fsPortableReflection.GetAttribute<fsObjectAttribute>(type);
			if (attribute != null && attribute.Converter != null)
			{
				value2 = (fsBaseConverter)Activator.CreateInstance(attribute.Converter);
				value2.Serializer = this;
				return _cachedConverters[type] = value2;
			}
			fsForwardAttribute attribute2 = fsPortableReflection.GetAttribute<fsForwardAttribute>(type);
			if (attribute2 != null)
			{
				value2 = new fsForwardConverter(attribute2);
				value2.Serializer = this;
				return _cachedConverters[type] = value2;
			}
			if (!_cachedConverters.TryGetValue(type, out value2))
			{
				if (_availableDirectConverters.ContainsKey(type))
				{
					value2 = _availableDirectConverters[type];
					return _cachedConverters[type] = value2;
				}
				for (int i = 0; i < _availableConverters.Count; i++)
				{
					if (_availableConverters[i].CanProcess(type))
					{
						value2 = _availableConverters[i];
						return _cachedConverters[type] = value2;
					}
				}
			}
			throw new InvalidOperationException("Internal error -- could not find a converter for " + type);
		}

		public void AddExternallyStoredReferenceWithId(int id, object reference)
		{
			_references.AddExternallyStoredReferenceWithId(id, reference);
		}

		public void SetIDObjectMapping(Dictionary<int, object> idObjectMapping, Dictionary<object, int> objectIdMapping)
		{
			_references.SetIDObjectMapping(idObjectMapping, objectIdMapping);
		}

		public fsResult TrySerialize<T>(T instance, out fsData data)
		{
			return TrySerialize(typeof(T), null, instance, out data);
		}

		public fsResult TrySerialize(Type storageType, object instance, out fsData data)
		{
			return TrySerialize(storageType, null, instance, out data);
		}

		public fsResult TrySerialize(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			try
			{
				List<fsObjectProcessor> processors = GetProcessors((instance == null) ? storageType : instance.GetType());
				Invoke_OnBeforeSerialize(processors, storageType, instance);
				if (instance == null)
				{
					data = new fsData();
					Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
					return fsResult.Success;
				}
				fsResult result;
				try
				{
					_references.Enter();
					if (!GetConverter(instance.GetType(), overrideConverterType).RequestCycleSupport(instance.GetType()))
					{
						result = InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
					}
					else if (_references.IsReference(instance))
					{
						data = fsData.CreateDictionary();
						int referenceId = _references.GetReferenceId(instance);
						_lazyReferenceWriter.WriteReference(referenceId, data.AsDictionary);
						result = fsResult.Success;
					}
					else
					{
						_references.MarkSerialized(instance);
						result = InternalSerialize_2_Inheritance(storageType, overrideConverterType, instance, out data);
						if (!result.Failed)
						{
							int referenceId2 = _references.GetReferenceId(instance);
							_lazyReferenceWriter.WriteDefinition(referenceId2, data);
						}
					}
				}
				finally
				{
					if (_references.Exit())
					{
						_lazyReferenceWriter.Clear();
					}
				}
				Invoke_OnAfterSerialize(processors, storageType, instance, ref data);
				return result;
			}
			catch (Exception ex)
			{
				data = null;
				return fsResult.Fail($"Failed serializing {instance.ToString()} of type {storageType}. Exception: {ex.ToString()}");
			}
		}

		private fsResult InternalSerialize_2_Inheritance(Type storageType, Type overrideConverterType, object instance, out fsData data)
		{
			List<fsObjectProcessor> processors = GetProcessors((instance == null) ? storageType : instance.GetType());
			Invoke_OnBeforeSerializeInstance(processors, storageType, instance);
			fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(instance.GetType());
			fsResult result;
			if (versionedType.HasValue)
			{
				fsVersionedType value = versionedType.Value;
				Type type = instance.GetType();
				result = GetConverter(type, overrideConverterType).TrySerialize(instance, out data, type);
				if (!result.Failed)
				{
					EnsureDictionary(data);
					data.AsDictionary[Key_Version] = new fsData(value.VersionString);
				}
			}
			else
			{
				Type type2 = instance.GetType();
				result = GetConverter(type2, overrideConverterType).TrySerialize(instance, out data, type2);
			}
			if (result.Failed)
			{
				return result;
			}
			if (storageType != instance.GetType() && GetConverter(storageType, overrideConverterType).RequestInheritanceSupport(storageType))
			{
				EnsureDictionary(data);
				data.AsDictionary[Key_InstanceType] = new fsData(instance.GetType().FullName);
			}
			Invoke_OnAfterSerializeInstance(processors, storageType, instance, ref data);
			return result;
		}

		public fsResult TryDeserialize<T>(fsData data, ref T instance)
		{
			object result = instance;
			fsResult result2 = TryDeserialize(data, typeof(T), null, ref result);
			instance = (T)result;
			return result2;
		}

		public fsResult TryDeserialize(fsData data, Type storageType, ref object result)
		{
			return TryDeserialize(data, storageType, null, ref result);
		}

		public fsResult TryDeserialize(fsData data, Type storageType, Type overrideConverterType, ref object result)
		{
			if (data.IsNull)
			{
				result = null;
				List<fsObjectProcessor> processors = GetProcessors(storageType);
				Invoke_OnBeforeDeserialize(processors, storageType, ref data);
				Invoke_OnAfterDeserialize(processors, storageType, null);
				return fsResult.Success;
			}
			ConvertLegacyData(ref data);
			try
			{
				_references.Enter();
				List<fsObjectProcessor> processors2;
				fsResult result2;
				if (IsObjectReference(data))
				{
					int id = int.Parse(data.AsDictionary[Key_ObjectReference].AsString);
					result = _references.GetReferenceObject(id, Config);
					if (Config.DeserializeMissingNegativeObjectIDsAsNull && result == null)
					{
						processors2 = new List<fsObjectProcessor>();
						result2 = fsResult.Warn("ID missing; deserializing as null: " + id);
					}
					else
					{
						processors2 = GetProcessors(result.GetType());
						result2 = fsResult.Success;
					}
				}
				else
				{
					result2 = InternalDeserialize_2_Version(overrideConverterType, data, storageType, ref result, out processors2);
					if (result2.Succeeded)
					{
						Invoke_OnAfterDeserializeInstance(processors2, storageType, result);
					}
				}
				if (result2.Succeeded)
				{
					Invoke_OnAfterDeserialize(processors2, storageType, result);
				}
				return result2;
			}
			finally
			{
				_references.Exit();
			}
		}

		private fsResult InternalDeserialize_2_Version(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			if (IsVersioned(data, Config))
			{
				Dictionary<string, fsData> asDictionary = data.AsDictionary;
				fsData value;
				string text = ((!asDictionary.TryGetValue(Key_Version, out value)) ? Config.VersionForAllUnspecifiedVersionClasses : value.AsString);
				fsOption<fsVersionedType> versionedType = fsVersionManager.GetVersionedType(storageType);
				if (versionedType.HasValue && versionedType.Value.VersionString != text)
				{
					fsResult success = fsResult.Success;
					success += fsVersionManager.GetVersionImportPath(text, versionedType.Value, out var path);
					if (success.Failed)
					{
						processors = GetProcessors(storageType);
						return success;
					}
					success += InternalDeserialize_3_Inheritance(overrideConverterType, data, path[0].ModelType, ref result, out processors);
					if (success.Failed)
					{
						return success;
					}
					for (int i = 1; i < path.Count; i++)
					{
						result = path[i].Migrate(result);
					}
					if (IsObjectDefinition(data))
					{
						int id = int.Parse(asDictionary[Key_ObjectDefinition].AsString);
						_references.AddReferenceWithId(id, result);
					}
					processors = GetProcessors(success.GetType());
					return success;
				}
			}
			return InternalDeserialize_3_Inheritance(overrideConverterType, data, storageType, ref result, out processors);
		}

		private fsResult InternalDeserialize_3_Inheritance(Type overrideConverterType, fsData data, Type storageType, ref object result, out List<fsObjectProcessor> processors)
		{
			fsResult success = fsResult.Success;
			Type storageType2 = storageType;
			if (IsTypeSpecified(data))
			{
				fsData fsData2 = data.AsDictionary[Key_InstanceType];
				if (!fsData2.IsString)
				{
					success.AddMessage(Key_InstanceType + " value must be a string (in " + data?.ToString() + ")");
				}
				else
				{
					string asString = fsData2.AsString;
					Type type = fsTypeCache.GetType(asString);
					if (type == null)
					{
						success += fsResult.Fail("Unable to locate specified type \"" + asString + "\"");
					}
					else if (!storageType.IsAssignableFrom(type))
					{
						success.AddMessage("Ignoring type specifier; a field/property of type " + storageType?.ToString() + " cannot hold an instance of " + type);
					}
					else
					{
						storageType2 = type;
					}
				}
			}
			RemapAbstractStorageTypeToDefaultType(ref storageType2);
			processors = GetProcessors(storageType2);
			if (success.Failed)
			{
				return success;
			}
			Invoke_OnBeforeDeserialize(processors, storageType, ref data);
			if (result == null || result.GetType() != storageType2)
			{
				result = GetConverter(storageType2, overrideConverterType).CreateInstance(data, storageType2);
			}
			Invoke_OnBeforeDeserializeAfterInstanceCreation(processors, storageType, result, ref data);
			if (IsObjectDefinition(data))
			{
				int id = int.Parse(data.AsDictionary[Key_ObjectDefinition].AsString);
				_references.AddReferenceWithId(id, result);
			}
			if (IsWrappedData(data))
			{
				data = data.AsDictionary[Key_Content];
			}
			return success += GetConverter(storageType2, overrideConverterType).TryDeserialize(data, ref result, storageType2);
		}
	}
}
