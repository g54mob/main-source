using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Pug.Properties;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Profiling;
using UnityEngine;

namespace Pug.Conversion
{
	public class ConversionManager : IDisposable
	{
		private class NoGhostConfigOverride : IGhostConfigOverride
		{
			public void OverrideGhostConfig(GameObject authoring, EntityManager entityManager, Entity entity, ref GhostPrefabCreation.Config config)
			{
				UnityEngine.Debug.LogError("No Ghost config override specified for project. Importance and OptimizationMode fields are hidden in inspector and not configured.");
			}
		}

		private enum State
		{
			Initialized = 0,
			Converting = 1,
			PostConverting = 2,
			Finished = 3
		}

		public struct ConversionParameters
		{
			public World TargetWorld;

			public BlobAssetStore BlobAssetStore;

			public PropertyLookupBuilder PropertyBuilder;

			public IGhostConfigOverride GhostConfigOverride;

			public int ReservedObjectIndices;

			public bool UseHardModeSettings;

			public bool UseCasualModeSettings;

			public bool IsServer;
		}

		private struct ConversionEntry : IComparable<ConversionEntry>
		{
			public long Hash;

			public GameObject GameObject;

			public int CompareTo(ConversionEntry other)
			{
				return Hash.CompareTo(other.Hash);
			}
		}

		private static ProfilerMarker _reflectionMarker = new ProfilerMarker("ConversionManager.Reflection");

		private static ProfilerMarker _convertMarker = new ProfilerMarker("ConversionManager.ConvertGameObjectHierarchy");

		private static ProfilerMarker _convertObjectMarker = new ProfilerMarker("ConversionManager.ConvertGameObject");

		private World _stagingWorld;

		private World _targetWorld;

		private List<Converter> _converters;

		private List<PostConverter> _stagingWorldPostConverters;

		private List<PostConverter> _finalWorldPostConverters;

		private List<MonoBehaviour> _reusableComponentsList = new List<MonoBehaviour>();

		private List<int> _convertersToAlwaysRun;

		private Dictionary<Type, List<int>> _convertersByRequiredType;

		private Dictionary<GameObject, Entity> _convertedObjects;

		private List<GameObject> _rootObjects;

		private Queue<GameObject> _conversionQueue;

		private PropertyLookupBuilder _objectIdPropertyBuilder;

		private int _nextUnusedObjectIndex;

		private State _state;

		private BatchedArchetypeChangeECB _archetypeChangeBatch;

		private readonly IGhostConfigOverride _ghostConfigOverride;

		public PropertyLookupBuilder PropertyBuilder;

		public EntityManager EntityManager { get; private set; }

		public BlobAssetStore BlobAssetStore { get; }

		public bool UseHardModeSettings { get; }

		public bool UseCasualModeSettings { get; }

		public bool IsServer { get; }

		public ConversionManager(ConversionParameters parameters, List<Type> converterTypes = null)
		{
			_stagingWorld = new World("StagingWorld", WorldFlags.Staging);
			_targetWorld = parameters.TargetWorld;
			EntityManager = _stagingWorld.EntityManager;
			_convertedObjects = new Dictionary<GameObject, Entity>();
			_rootObjects = new List<GameObject>();
			_conversionQueue = new Queue<GameObject>();
			_converters = new List<Converter>();
			_convertersToAlwaysRun = new List<int>();
			_convertersByRequiredType = new Dictionary<Type, List<int>>();
			_stagingWorldPostConverters = new List<PostConverter>();
			_finalWorldPostConverters = new List<PostConverter>();
			_nextUnusedObjectIndex = parameters.ReservedObjectIndices;
			_objectIdPropertyBuilder = parameters.PropertyBuilder;
			PropertyBuilder = new PropertyLookupBuilder();
			BlobAssetStore = parameters.BlobAssetStore;
			UseHardModeSettings = parameters.UseHardModeSettings;
			UseCasualModeSettings = parameters.UseCasualModeSettings;
			IsServer = parameters.IsServer;
			_ghostConfigOverride = parameters.GhostConfigOverride ?? new NoGhostConfigOverride();
			InstantiateAndAddConverters(converterTypes ?? FindAllConvertersInCurrentAssembly());
			_state = State.Initialized;
		}

		public static List<Type> FindAllConvertersInCurrentAssembly()
		{
			using (_reflectionMarker.Auto())
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = Assembly.GetExecutingAssembly().GetName().Name;
				List<Type> list = new List<Type>();
				FindAllConverters(executingAssembly, list);
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (ReferencesAssembly(assembly, name))
					{
						FindAllConverters(assembly, list);
					}
				}
				return list;
			}
		}

		private static void FindAllConverters(Assembly assembly, List<Type> converterTypes)
		{
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Converter)))
				{
					converterTypes.Add(type);
				}
			}
		}

		private static bool ReferencesAssembly(Assembly assembly, string referencedAssemblyName)
		{
			AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
			for (int i = 0; i < referencedAssemblies.Length; i++)
			{
				if (referencedAssemblies[i].FullName.Contains(referencedAssemblyName))
				{
					return true;
				}
			}
			return false;
		}

		private void CheckState(State expectedState)
		{
			if (_state != expectedState)
			{
				throw new InvalidOperationException($"Operation only allowed in state {expectedState}, currently {_state}");
			}
		}

		private void InstantiateAndAddConverters(List<Type> converterTypes)
		{
			foreach (Type converterType in converterTypes)
			{
				Converter converter = Activator.CreateInstance(converterType) as Converter;
				AddConverter(converter);
			}
		}

		private void AddConverter(Converter converter)
		{
			converter.ConversionManager = this;
			Type requireComponentTypeToRun = converter.RequireComponentTypeToRun;
			int count = _converters.Count;
			_converters.Add(converter);
			if (requireComponentTypeToRun == null)
			{
				_convertersToAlwaysRun.Add(count);
				return;
			}
			if (!_convertersByRequiredType.TryGetValue(requireComponentTypeToRun, out var value))
			{
				value = new List<int>();
				_convertersByRequiredType[requireComponentTypeToRun] = value;
			}
			value.Add(count);
		}

		public void AddPostConverter(PostConverter postConverter)
		{
			CheckState(State.Initialized);
			postConverter.ConversionManager = this;
			(postConverter.CanRunInStagingWorld ? _stagingWorldPostConverters : _finalWorldPostConverters).Add(postConverter);
		}

		public void Dispose()
		{
			foreach (Converter converter in _converters)
			{
				converter.Dispose();
			}
			_stagingWorld.Dispose();
		}

		public void EnqueueGameObjectHierarchy(GameObject root)
		{
			CheckState(State.Initialized);
			_rootObjects.Add(root);
			Entity root2 = CreateAndEnqueue(root);
			for (int i = 0; i < root.transform.childCount; i++)
			{
				EnqueueGameObjectHierarchy(root.transform.GetChild(i).gameObject, root2);
			}
		}

		public void ConvertEnqueuedObjectsImmediately(bool runPostConverters = true)
		{
			WallClockTimer frameWorkloadTimer = new WallClockTimer(TimeSpan.FromSeconds(100.0));
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			IEnumerator enumerator = ConvertEnqueuedObjects(tokenSource, frameWorkloadTimer, runPostConverters);
			while (enumerator.MoveNext())
			{
			}
		}

		public IEnumerator ConvertEnqueuedObjects(CancellationTokenSource tokenSource, WallClockTimer frameWorkloadTimer, bool runPostConverters = true)
		{
			CheckState(State.Initialized);
			UnityEngine.Debug.Log($"Converting {_rootObjects.Count} root objects for {_targetWorld.Name} with " + $"{_converters.Count} converters, " + $"{_stagingWorldPostConverters.Count} post-converters in staging world, and " + $"{_finalWorldPostConverters.Count} post-converters in final world.");
			_state = State.Converting;
			IEnumerator finishConversionQueue = FinishConversionQueue(tokenSource, frameWorkloadTimer);
			while (finishConversionQueue.MoveNext())
			{
				yield return finishConversionQueue.Current;
			}
			if (tokenSource != null && tokenSource.IsCancellationRequested)
			{
				yield return Entity.Null;
				yield break;
			}
			_state = State.PostConverting;
			if (runPostConverters)
			{
				IEnumerator postConversion = RunPostConverters(_stagingWorldPostConverters, tokenSource, frameWorkloadTimer);
				while (postConversion.MoveNext())
				{
					yield return postConversion.Current;
				}
				if (tokenSource != null && tokenSource.IsCancellationRequested)
				{
					yield return Entity.Null;
					yield break;
				}
			}
			ConsolidateLinkedEntitiesToRoot();
			MoveEntities(_stagingWorld.EntityManager, _targetWorld.EntityManager);
			EntityManager = _targetWorld.EntityManager;
			if (runPostConverters)
			{
				IEnumerator postConversion = RunPostConverters(_finalWorldPostConverters, tokenSource, frameWorkloadTimer);
				while (postConversion.MoveNext())
				{
					yield return postConversion.Current;
				}
				if (tokenSource != null && tokenSource.IsCancellationRequested)
				{
					yield return Entity.Null;
					yield break;
				}
				IEnumerator finalize = FinalizeProperties(tokenSource, frameWorkloadTimer);
				while (finalize.MoveNext())
				{
					yield return finalize.Current;
				}
			}
			_state = State.Finished;
		}

		public Entity GetEntity(GameObject gameObject)
		{
			CheckState(State.Finished);
			if (!_convertedObjects.TryGetValue(gameObject, out var value))
			{
				throw new ArgumentException($"GameObject {gameObject} has not been converted.");
			}
			return value;
		}

		private void MoveEntities(EntityManager source, EntityManager target)
		{
			NativeArray<EntityRemapUtility.EntityRemapInfo> remapping = source.CreateEntityRemapArray(Allocator.Persistent);
			target.MoveEntitiesFrom(source, source.UniversalQuery, remapping);
			foreach (GameObject item in new List<GameObject>(_convertedObjects.Keys))
			{
				Entity source2 = _convertedObjects[item];
				Entity value = EntityRemapUtility.RemapEntity(ref remapping, source2);
				_convertedObjects[item] = value;
			}
			remapping.Dispose();
		}

		private void EnqueueGameObjectHierarchy(GameObject child, Entity root)
		{
			Entity entity = CreateAndEnqueue(child);
			EntityManager.GetBuffer<LinkedEntityGroup>(root).Add(entity);
			for (int i = 0; i < child.transform.childCount; i++)
			{
				EnqueueGameObjectHierarchy(child.transform.GetChild(i).gameObject, root);
			}
		}

		private void ConsolidateLinkedEntitiesToRoot()
		{
			foreach (GameObject rootObject in _rootObjects)
			{
				Entity root = _convertedObjects[rootObject];
				for (int i = 0; i < rootObject.transform.childCount; i++)
				{
					ConsolidateLinkedEntitiesToRoot(rootObject.transform.GetChild(i).gameObject, root);
				}
			}
		}

		private void ConsolidateLinkedEntitiesToRoot(GameObject child, Entity root)
		{
			Entity entity = _convertedObjects[child];
			if (EntityManager.HasComponent<LinkedEntityGroup>(entity))
			{
				using NativeArray<LinkedEntityGroup> nativeArray = EntityManager.GetBuffer<LinkedEntityGroup>(entity).ToNativeArray(Allocator.Temp);
				for (int i = 1; i < nativeArray.Length; i++)
				{
					EntityManager.GetBuffer<LinkedEntityGroup>(root).Add(nativeArray[i]);
				}
				EntityManager.RemoveComponent<LinkedEntityGroup>(entity);
			}
			for (int j = 0; j < child.transform.childCount; j++)
			{
				ConsolidateLinkedEntitiesToRoot(child.transform.GetChild(j).gameObject, root);
			}
		}

		public void GetGhostConfig(GameObject authoring, Entity entity, out GhostPrefabCreation.Config config)
		{
			if (!authoring.TryGetComponent<GhostAuthoringComponent>(out var component))
			{
				UnityEngine.Debug.LogError("GameObject " + authoring.name + " does not have a GhostAuthoringComponent. Cannot create ghost config.");
				config = default(GhostPrefabCreation.Config);
				return;
			}
			config = new GhostPrefabCreation.Config
			{
				Importance = component.Importance,
				SupportedGhostModes = component.SupportedGhostModes,
				DefaultGhostMode = component.DefaultGhostMode,
				OptimizationMode = component.OptimizationMode,
				UsePreSerialization = component.UsePreSerialization
			};
			FixedStringMethods.CopyFromTruncated(ref config.Name, authoring.name);
			_ghostConfigOverride.OverrideGhostConfig(authoring, EntityManager, entity, ref config);
		}

		public Entity GetPrefabEntity(GameObject prefab)
		{
			return CreateAndEnqueue(prefab);
		}

		public Entity GetPrefabEntityPostConvert(GameObject prefab)
		{
			if (!_convertedObjects.TryGetValue(prefab, out var value))
			{
				return Entity.Null;
			}
			return value;
		}

		[Conditional("UNITY_EDITOR")]
		internal void RegisterConvertedType<T>() where T : MonoBehaviour
		{
		}

		internal string EntityDebugName(Entity entity)
		{
			return entity.ToString();
		}

		private Entity CreateAndEnqueue(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return Entity.Null;
			}
			if (_convertedObjects.TryGetValue(gameObject, out var value))
			{
				return value;
			}
			value = EntityManager.CreateEntity();
			if (!gameObject.scene.IsValid())
			{
				EntityManager.AddComponent(value, new ComponentTypeSet(typeof(Prefab), typeof(LinkedEntityGroup)));
				EntityManager.GetBuffer<LinkedEntityGroup>(value).Add(value);
			}
			_convertedObjects[gameObject] = value;
			_conversionQueue.Enqueue(gameObject);
			return value;
		}

		private IEnumerator FinishConversionQueue(CancellationTokenSource tokenSource, WallClockTimer frameWorkloadTimer)
		{
			WaitForEndOfFrame wait = new WaitForEndOfFrame();
			_reusableComponentsList.Clear();
			_archetypeChangeBatch = new BatchedArchetypeChangeECB(EntityManager, Allocator.Persistent);
			while (_conversionQueue.Count != 0)
			{
				try
				{
					GameObject gameObject = _conversionQueue.Dequeue();
					Entity entity = _convertedObjects[gameObject];
					int uniqueIndex = GetUniqueIndex(gameObject);
					IPreferredObjectIndex component = gameObject.GetComponent<IPreferredObjectIndex>();
					if (component == null || !component.TryGetPreferredObjectIndex(out var objectIndex))
					{
						objectIndex = _nextUnusedObjectIndex++;
					}
					RunConverters(_convertersToAlwaysRun, gameObject, objectIndex, uniqueIndex, entity);
					gameObject.GetComponents(_reusableComponentsList);
					foreach (MonoBehaviour reusableComponents in _reusableComponentsList)
					{
						if (!(reusableComponents == null) && _convertersByRequiredType.TryGetValue(reusableComponents.GetType(), out var value))
						{
							RunConverters(value, gameObject, objectIndex, uniqueIndex, entity);
						}
					}
					_reusableComponentsList.Clear();
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
					tokenSource.Cancel();
					break;
				}
				if (frameWorkloadTimer.HasElapsed)
				{
					TimeSpan timeElapsed = frameWorkloadTimer.TimeElapsed;
					if (timeElapsed >= TimeSpan.FromSeconds(1.0))
					{
						UnityEngine.Debug.LogWarning($"Conversion interrupt after {timeElapsed.Milliseconds} ms. Xbox won't like it and will crash if the user manages to suspend during this time!");
					}
					yield return wait;
					frameWorkloadTimer.Restart();
				}
			}
			_archetypeChangeBatch.Playback(EntityManager);
			_archetypeChangeBatch.Dispose();
		}

		private void RunConverters(List<int> converterIndices, GameObject gameObject, int objectIndex, int uniqueObjectIndex, Entity entity)
		{
			foreach (int converterIndex in converterIndices)
			{
				Converter converter = _converters[converterIndex];
				converter.PropertiesBuilder = _objectIdPropertyBuilder;
				converter.ObjectIndex = objectIndex;
				converter.UniqueObjectIndex = uniqueObjectIndex;
				converter.PrimaryEntity = entity;
				converter.Convert(gameObject);
			}
		}

		private IEnumerator RunPostConverters(List<PostConverter> postConverters, CancellationTokenSource tokenSource, WallClockTimer frameWorkloadTimer)
		{
			WaitForEndOfFrame wait = new WaitForEndOfFrame();
			foreach (GameObject gameObject in _convertedObjects.Keys)
			{
				foreach (PostConverter postConverter in postConverters)
				{
					if (tokenSource != null && tokenSource.IsCancellationRequested)
					{
						yield break;
					}
					postConverter.PostConvert(gameObject);
					if (frameWorkloadTimer.HasElapsed)
					{
						TimeSpan timeElapsed = frameWorkloadTimer.TimeElapsed;
						if (timeElapsed >= TimeSpan.FromSeconds(1.0))
						{
							UnityEngine.Debug.LogWarning($"Conversion interrupt after {timeElapsed.Milliseconds} ms. Xbox won't like it and will crash if the user manages to suspend during this time!");
						}
						yield return wait;
						frameWorkloadTimer.Restart();
					}
				}
			}
		}

		private IEnumerator FinalizeProperties(CancellationTokenSource cancellationTokenSource, WallClockTimer frameWorkloadTimer)
		{
			WaitForEndOfFrame wait = new WaitForEndOfFrame();
			foreach (KeyValuePair<GameObject, Entity> convertedObject in _convertedObjects)
			{
				if (cancellationTokenSource != null && cancellationTokenSource.IsCancellationRequested)
				{
					yield break;
				}
				int uniqueIndex = GetUniqueIndex(convertedObject.Key);
				Entity value = convertedObject.Value;
				ObjectPropertiesCD componentData = PropertyBuilder.CreateObjectPropertiesComponent(uniqueIndex, BlobAssetStore);
				EntityManager.SetComponentData(value, componentData);
				if (frameWorkloadTimer.HasElapsed)
				{
					TimeSpan timeElapsed = frameWorkloadTimer.TimeElapsed;
					if (timeElapsed >= TimeSpan.FromSeconds(1.0))
					{
						UnityEngine.Debug.LogWarning($"Conversion interrupt after {timeElapsed.Milliseconds} ms. Xbox won't like it and will crash if the user manages to suspend during this time!");
					}
					yield return wait;
					frameWorkloadTimer.Restart();
				}
			}
			using EntityQuery entityQuery = EntityManager.CreateEntityQuery(typeof(DatabaseCD));
			EntityManager.DestroyEntity(entityQuery);
			Entity entity = EntityManager.CreateEntity(typeof(DatabaseCD));
			EntityManager.SetComponentData(entity, new DatabaseCD
			{
				ObjectPropertyLookup = _objectIdPropertyBuilder.CreateLookup(BlobAssetStore)
			});
		}

		private int GetUniqueIndex(GameObject gameObject)
		{
			int instanceID = gameObject.GetInstanceID();
			if (instanceID < 0)
			{
				return int.MaxValue + instanceID;
			}
			return instanceID;
		}

		internal void EnsureHasComponent<T>(Entity entity) where T : unmanaged, IComponentData
		{
			_archetypeChangeBatch.AddComponent<T>(entity);
		}

		internal void EnsureHasChunkComponent<T>(Entity entity) where T : unmanaged, IComponentData
		{
			_archetypeChangeBatch.AddChunkComponent<T>(entity);
		}

		internal void AddComponent<T>(Entity entity, T component) where T : unmanaged, IComponentData
		{
			_archetypeChangeBatch.AddComponent(entity, component);
		}

		internal void SetComponentEnabled<T>(Entity entity, bool enabled) where T : unmanaged, IComponentData, IEnableableComponent
		{
			_archetypeChangeBatch.SetComponentEnabled<T>(entity, enabled);
		}

		internal void AddSharedComponent<T>(Entity entity, T component) where T : unmanaged, ISharedComponentData
		{
			_archetypeChangeBatch.AddSharedComponent(entity, component);
		}

		internal int EnsureHasBuffer<T>(Entity entity) where T : unmanaged, IBufferElementData
		{
			return _archetypeChangeBatch.EnsureHasBuffer<T>(entity);
		}

		internal int AppendToBuffer<T>(Entity entity, T element) where T : unmanaged, IBufferElementData
		{
			return _archetypeChangeBatch.AppendToBuffer(entity, element);
		}

		public bool HasComponent<T>(Entity entity)
		{
			return _archetypeChangeBatch.HasComponent<T>(entity);
		}
	}
}
