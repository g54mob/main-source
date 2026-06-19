using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pug.Properties;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

namespace Pug.Conversion
{
	[Preserve]
	[RequireDerived]
	public abstract class Converter : IDisposable
	{
		public ConversionManager ConversionManager { private get; set; }

		public Entity PrimaryEntity { protected get; set; }

		public PropertyLookupBuilder PropertiesBuilder { protected get; set; }

		public int ObjectIndex { protected get; set; }

		public int UniqueObjectIndex { protected get; set; }

		protected BlobAssetStore BlobAssetStore => ConversionManager.BlobAssetStore;

		protected bool UseHardModeSettings => ConversionManager.UseHardModeSettings;

		protected bool UseCasualModeSettings => ConversionManager.UseCasualModeSettings;

		protected bool IsServer => ConversionManager.IsServer;

		public virtual Type RequireComponentTypeToRun => null;

		public virtual void Dispose()
		{
		}

		public abstract void Convert(GameObject authoring);

		public Entity GetPrefabDependency(GameObject prefab)
		{
			return ConversionManager.GetPrefabEntity(prefab);
		}

		public void EnsureHasComponent<TComponent>() where TComponent : unmanaged, IComponentData
		{
			EnsureHasComponent<TComponent>(PrimaryEntity);
		}

		public void EnsureHasComponent<TComponent>(bool componentIsEnabled) where TComponent : unmanaged, IComponentData, IEnableableComponent
		{
			EnsureHasComponent<TComponent>(PrimaryEntity);
			ConversionManager.SetComponentEnabled<TComponent>(PrimaryEntity, componentIsEnabled);
		}

		public void EnsureHasComponent<TComponent>(Entity entity) where TComponent : unmanaged, IComponentData
		{
			ConversionManager.EnsureHasComponent<TComponent>(entity);
		}

		public void EnsureHasChunkComponent<TComponent>() where TComponent : unmanaged, IComponentData
		{
			EnsureHasChunkComponent<TComponent>(PrimaryEntity);
		}

		public void EnsureHasChunkComponent<TComponent>(Entity entity) where TComponent : unmanaged, IComponentData
		{
			ConversionManager.EnsureHasChunkComponent<TComponent>(entity);
		}

		public void AddComponentData<TComponent>(TComponent component) where TComponent : unmanaged, IComponentData
		{
			AddComponentData(PrimaryEntity, component);
		}

		public void AddComponentData<TComponent>(TComponent component, bool componentIsEnabled) where TComponent : unmanaged, IComponentData, IEnableableComponent
		{
			AddComponentData(PrimaryEntity, component, componentIsEnabled);
		}

		public void AddComponentObject(object component)
		{
			AddComponentObject(PrimaryEntity, component);
		}

		public void AddComponentData<TComponent>(Entity entity, TComponent component) where TComponent : unmanaged, IComponentData
		{
			ConversionManager.AddComponent(entity, component);
		}

		public void AddComponentData<TComponent>(Entity entity, TComponent component, bool componentIsEnabled) where TComponent : unmanaged, IComponentData, IEnableableComponent
		{
			AddComponentData(entity, component);
			ConversionManager.SetComponentEnabled<TComponent>(entity, componentIsEnabled);
		}

		public void AddComponentObject(Entity entity, object o)
		{
			if (ConversionManager.EntityManager.HasComponent(entity, o.GetType()))
			{
				UnityEngine.Debug.LogError(string.Format("Another converter has already added a component of type {0} to {1}. Result would depend on converter order, which is non-deterministic. For tag components, use {2}({3}) instead.", o.GetType(), ConversionManager.EntityDebugName(entity), "EnsureHasComponent", "entity"));
			}
			else
			{
				ConversionManager.EntityManager.AddComponentObject(entity, o);
			}
		}

		public void AddSharedComponentData<TComponent>(TComponent component) where TComponent : unmanaged, ISharedComponentData
		{
			AddSharedComponentData(PrimaryEntity, component);
		}

		public void AddSharedComponentData<TComponent>(Entity entity, TComponent component) where TComponent : unmanaged, ISharedComponentData
		{
			ConversionManager.AddSharedComponent(entity, component);
		}

		public int EnsureHasBuffer<TElement>() where TElement : unmanaged, IBufferElementData
		{
			return EnsureHasBuffer<TElement>(PrimaryEntity);
		}

		public int EnsureHasBuffer<TElement>(Entity entity) where TElement : unmanaged, IBufferElementData
		{
			return ConversionManager.EnsureHasBuffer<TElement>(entity);
		}

		public int AddToBuffer<TElement>(TElement elementData) where TElement : unmanaged, IBufferElementData
		{
			return AddToBuffer(PrimaryEntity, elementData);
		}

		public int AddToBuffer<TElement>(Entity entity, TElement elementData) where TElement : unmanaged, IBufferElementData
		{
			if (!ConversionManager.HasComponent<TElement>(entity))
			{
				UnityEngine.Debug.LogError(string.Format("{0} does not have a buffer of type {1}. Call {2}<{3}>({4}) first.", ConversionManager.EntityDebugName(entity), typeof(TElement), "EnsureHasBuffer", "TElement", "entity"));
				return -1;
			}
			return ConversionManager.AppendToBuffer(entity, elementData);
		}

		public int AddToBuffer<TElementBuffer, TElement>(IEnumerable<TElement> elementData) where TElementBuffer : unmanaged, IBufferElementData where TElement : unmanaged
		{
			return AddToBuffer<TElementBuffer, TElement>(PrimaryEntity, elementData);
		}

		public int AddToBuffer<TElementBuffer, TElement>(Entity entity, IEnumerable<TElement> elementData) where TElementBuffer : unmanaged, IBufferElementData where TElement : unmanaged
		{
			if (!ConversionManager.HasComponent<TElementBuffer>(entity))
			{
				UnityEngine.Debug.LogError(string.Format("{0} does not have a buffer of type {1}. Call {2}<{3}>({4}) first.", ConversionManager.EntityDebugName(entity), typeof(TElementBuffer), "EnsureHasBuffer", "TElementBuffer", "entity"));
				return -1;
			}
			int result = -1;
			foreach (TElement elementDatum in elementData)
			{
				TElement from = elementDatum;
				result = ConversionManager.AppendToBuffer(entity, UnsafeUtility.As<TElement, TElementBuffer>(ref from));
			}
			return result;
		}

		public Entity CreateAdditionalEntity()
		{
			return CreateAdditionalEntity(PrimaryEntity);
		}

		public Entity CreateAdditionalEntity(Entity parent)
		{
			Entity entity = ConversionManager.EntityManager.CreateEntity();
			if (ConversionManager.EntityManager.HasComponent<Prefab>(parent))
			{
				ConversionManager.EntityManager.AddComponent(entity, new ComponentTypeSet(typeof(Prefab), typeof(LinkedEntityGroup)));
			}
			bool num = !ConversionManager.EntityManager.AddComponent<LinkedEntityGroup>(parent);
			DynamicBuffer<LinkedEntityGroup> buffer = ConversionManager.EntityManager.GetBuffer<LinkedEntityGroup>(parent);
			if (!num)
			{
				buffer.Add(parent);
			}
			buffer.Add(entity);
			return entity;
		}

		public void SetName(string name)
		{
			SetName(PrimaryEntity, name);
		}

		public void SetName(Entity entity, string name)
		{
			if (name.Length > 61)
			{
				ConversionManager.EntityManager.SetName(entity, name.Substring(0, 61));
			}
			else
			{
				ConversionManager.EntityManager.SetName(entity, name);
			}
		}

		[Conditional("UNITY_EDITOR")]
		public void RegisterConvertedType<T>() where T : MonoBehaviour
		{
		}

		public bool TryGetActiveComponent<T>(MonoBehaviour authoring, out T component) where T : MonoBehaviour
		{
			return TryGetActiveComponent<T>(authoring.gameObject, out component);
		}

		public bool TryGetActiveComponent<T>(GameObject authoring, out T component) where T : MonoBehaviour
		{
			if (!authoring.TryGetComponent<T>(out component))
			{
				return false;
			}
			if (!component.enabled)
			{
				component = null;
				return false;
			}
			return true;
		}

		[PropertyIDGenerator(0)]
		public void SetProperty(string property)
		{
			ConversionManager.PropertyBuilder.SetProperty(UniqueObjectIndex, property);
		}

		[PropertyIDGenerator(0)]
		public void SetProperty<T>(string property, T value) where T : unmanaged
		{
			ConversionManager.PropertyBuilder.SetProperty(UniqueObjectIndex, property, value);
		}

		[PropertyIDGenerator(0)]
		public void SetPropertyList<T>(string property, T[] values) where T : unmanaged
		{
			ConversionManager.PropertyBuilder.SetPropertyList(UniqueObjectIndex, property, values);
		}

		[PropertyIDGenerator(0)]
		public void SetPropertyString(string property, string value)
		{
			ConversionManager.PropertyBuilder.SetPropertyString(UniqueObjectIndex, property, value);
		}

		public BlobAssetReference<T> CreateAndAddSimpleBlobAsset<T>(T data) where T : unmanaged
		{
			int chunkSize = UnsafeUtility.SizeOf<T>();
			using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, chunkSize);
			blobBuilder.ConstructRoot<T>() = data;
			BlobAssetReference<T> blobAsset = blobBuilder.CreateBlobAssetReference<T>(Allocator.Persistent);
			BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}

		public BlobAssetReference<BlobArray<T>> CreateAndAddSimpleBlobArrayAsset<T>(ICollection<T> data) where T : unmanaged
		{
			return CreateAndAddSimpleBlobArrayAsset(data, (T x) => x);
		}

		public BlobAssetReference<BlobArray<T>> CreateAndAddSimpleBlobArrayAsset<T, D>(ICollection<D> data, Func<D, T> mapping) where T : unmanaged
		{
			int chunkSize = data.Count * UnsafeUtility.SizeOf<T>() + UnsafeUtility.SizeOf<BlobArray<T>>();
			using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, chunkSize);
			BlobBuilderArray<T> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<T>>(), data.Count);
			int num = 0;
			foreach (D datum in data)
			{
				blobBuilderArray[num] = mapping(datum);
				num++;
			}
			BlobAssetReference<BlobArray<T>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<T>>(Allocator.Persistent);
			BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}
	}
}
