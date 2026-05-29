using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsSerializer
	{
		internal class fsLazyCycleDefinitionWriter
		{
			private Dictionary<int, fsData> _pendingDefinitions;

			private HashSet<int> _references;

			public void WriteDefinition(int id, fsData data)
			{
			}

			public void WriteReference(int id, Dictionary<string, fsData> dict)
			{
			}

			public void Clear()
			{
			}
		}

		public const string KEY_OBJECT_REFERENCE = "$ref";

		public const string KEY_OBJECT_DEFINITION = "$id";

		public const string KEY_INSTANCE_TYPE = "$type";

		public const string KEY_VERSION = "$version";

		public const string KEY_CONTENT = "$content";

		private Dictionary<Type, fsBaseConverter> _cachedOverrideConverterInstances;

		private Dictionary<Type, fsBaseConverter> _cachedConverters;

		private readonly List<fsConverter> _availableConverters;

		private readonly Dictionary<Type, fsDirectConverter> _availableDirectConverters;

		private readonly List<fsObjectProcessor> _processors;

		private Dictionary<Type, List<fsObjectProcessor>> _cachedProcessors;

		private fsCyclicReferenceManager _references;

		private fsLazyCycleDefinitionWriter _lazyReferenceWriter;

		private Stack<ISerializationCollector> _collectors;

		private int _collectableDepth;

		public List<UnityEngine.Object> ReferencesDatabase { get; set; }

		public bool IgnoreSerializeCycleReferences { get; set; }

		public event Action<object> onBeforeObjectSerialized
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<object, fsData> onAfterObjectSerialized
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsReservedKeyword(string key)
		{
			return false;
		}

		public static void RemoveMetaData(ref fsData data)
		{
		}

		private static void EnsureDictionary(ref fsData data)
		{
		}

		private static bool IsObjectReference(fsData data)
		{
			return false;
		}

		private static bool IsObjectDefinition(fsData data)
		{
			return false;
		}

		private static bool IsVersioned(fsData data)
		{
			return false;
		}

		private static bool IsTypeSpecified(fsData data)
		{
			return false;
		}

		private static bool IsWrappedData(fsData data)
		{
			return false;
		}

		private static void Invoke_OnBeforeSerialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
		}

		private static void Invoke_OnAfterSerialize(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
		}

		private static void Invoke_OnBeforeDeserialize(List<fsObjectProcessor> processors, Type storageType, ref fsData data)
		{
		}

		private static void Invoke_OnBeforeDeserializeAfterInstanceCreation(List<fsObjectProcessor> processors, Type storageType, object instance, ref fsData data)
		{
		}

		private static void Invoke_OnAfterDeserialize(List<fsObjectProcessor> processors, Type storageType, object instance)
		{
		}

		public void PurgeTemporaryData()
		{
		}

		private List<fsObjectProcessor> GetProcessors(Type type)
		{
			return null;
		}

		public void AddConverter(fsBaseConverter converter)
		{
		}

		private fsBaseConverter GetConverter(Type type, Type overrideConverterType)
		{
			return null;
		}

		public fsResult TrySerialize(Type storageType, object instance, out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		public fsResult TrySerialize(Type storageType, object instance, out fsData data, Type overrideConverterType)
		{
			data = null;
			return default(fsResult);
		}

		private fsResult Internal_Serialize(Type storageType, object instance, out fsData data, Type overrideConverterType)
		{
			data = null;
			return default(fsResult);
		}

		public fsResult TryDeserialize(fsData data, Type storageType, ref object result)
		{
			return default(fsResult);
		}

		public fsResult TryDeserialize(fsData data, Type storageType, ref object result, Type overrideConverterType)
		{
			return default(fsResult);
		}

		private fsResult Internal_Deserialize(fsData data, Type storageType, ref object result, Type overrideConverterType)
		{
			return default(fsResult);
		}

		private void TryPush(object o)
		{
		}

		private void TryPop(object o)
		{
		}

		private void TrySerializeVersioning(object currentInstance, ref fsData data)
		{
		}

		private void TryDeserializeVersioning(ref object currentInstance, ref fsData currentData)
		{
		}

		private void TryDeserializeMigration(ref object currentInstance, ref fsData currentData, Type previousType, object previousInstance)
		{
		}
	}
}
