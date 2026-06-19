using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;

namespace Pug.Properties
{
	public class PropertyLookupBuilder : IEnumerable<PropertyLookupBuilder.Entry>, IEnumerable
	{
		private struct AddedProperty : IEquatable<AddedProperty>
		{
			public int LookupIndex;

			public int PropertyID;

			public byte[] Data;

			public int Count;

			public override string ToString()
			{
				return LookupIndex + ":" + PropertyID;
			}

			public override int GetHashCode()
			{
				return (LookupIndex * 397) ^ PropertyID;
			}

			public bool Equals(AddedProperty other)
			{
				if (LookupIndex == other.LookupIndex)
				{
					return PropertyID == other.PropertyID;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is AddedProperty other)
				{
					return Equals(other);
				}
				return false;
			}

			public static bool operator ==(AddedProperty left, AddedProperty right)
			{
				return left.Equals(right);
			}

			public static bool operator !=(AddedProperty left, AddedProperty right)
			{
				return !left.Equals(right);
			}
		}

		public struct Entry
		{
			public int Index;

			public int Property;
		}

		public class Enum<T> : IEnumerable<Enum<T>.Entry>, IEnumerable where T : struct, Enum
		{
			public struct Entry
			{
				public T Index;

				public int Property;
			}

			private PropertyLookupBuilder _builder;

			internal Enum(PropertyLookupBuilder builder)
			{
				_builder = builder;
			}

			public PropertyLookup CreateLookup(BlobAssetStore blobAssetStore)
			{
				return _builder.CreateLookup(blobAssetStore);
			}

			public void SetProperty(T index, string property)
			{
				_builder.SetProperty(UnsafeUtility.As<T, int>(ref index), property);
			}

			public void SetProperty<TU>(T index, string property, TU value) where TU : unmanaged
			{
				_builder.SetProperty(UnsafeUtility.As<T, int>(ref index), property, value);
			}

			public void SetPropertyString(T index, string property, string value)
			{
				_builder.SetPropertyString(UnsafeUtility.As<T, int>(ref index), property, value);
			}

			public void SetPropertyList<TU>(T index, string property, TU[] values) where TU : unmanaged
			{
				_builder.SetPropertyList(UnsafeUtility.As<T, int>(ref index), property, values);
			}

			public void RemoveProperty(T index, string property)
			{
				_builder.RemoveProperty(UnsafeUtility.As<T, int>(ref index), property);
			}

			public IEnumerator<Entry> GetEnumerator()
			{
				return _builder._propertySet.Select((AddedProperty x) => new Entry
				{
					Index = UnsafeUtility.As<int, T>(ref x.LookupIndex),
					Property = x.PropertyID
				}).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private readonly HashSet<AddedProperty> _propertySet = new HashSet<AddedProperty>();

		private readonly List<AddedProperty> _objectPropertiesCache = new List<AddedProperty>();

		private HashSet<AddedProperty> GetPropertySet()
		{
			return _propertySet;
		}

		private unsafe void BuildProperty(int propertyId, int count, byte[] data, BlobBuilder builder, ref PropertyData property)
		{
			property.PropertyId = propertyId;
			property.Count = count;
			if (data != null)
			{
				BlobBuilderArray<byte> blobBuilderArray = builder.Allocate(ref property.Data, data.Length);
				fixed (byte* source = data)
				{
					UnsafeUtility.MemCpy(blobBuilderArray.GetUnsafePtr(), source, data.Length);
				}
			}
		}

		public unsafe PropertyLookup CreateLookup(BlobAssetStore blobAssetStore)
		{
			HashSet<AddedProperty> propertySet = GetPropertySet();
			using BlobBuilder builder = new BlobBuilder(Allocator.Temp);
			ref PropertyLookupBlob reference = ref builder.ConstructRoot<PropertyLookupBlob>();
			int num = 0;
			foreach (AddedProperty item in propertySet)
			{
				num = Mathf.Max(item.LookupIndex, num);
			}
			BlobBuilderArray<ObjectData> blobBuilderArray = builder.Allocate(ref reference.Objects, num + 1);
			NativeArray<int> nativeArray = new NativeArray<int>(blobBuilderArray.Length, Allocator.Temp);
			foreach (AddedProperty item2 in propertySet)
			{
				nativeArray[item2.LookupIndex]++;
			}
			BlobBuilderArray<PropertyData>* ptr = (BlobBuilderArray<PropertyData>*)UnsafeUtility.Malloc(sizeof(BlobBuilderArray<PropertyData>) * (num + 1), 0, Allocator.Persistent);
			if (ptr == null)
			{
				throw new OutOfMemoryException("couldn't allocate property arrays");
			}
			try
			{
				for (int i = 0; i < blobBuilderArray.Length; i++)
				{
					ptr[i] = builder.Allocate(ref blobBuilderArray[i].Properties, nativeArray[i]);
					nativeArray[i] = 0;
				}
				foreach (AddedProperty item3 in propertySet)
				{
					int lookupIndex = item3.LookupIndex;
					ref PropertyData property = ref ptr[lookupIndex][nativeArray[lookupIndex]];
					nativeArray[lookupIndex]++;
					BuildProperty(item3.PropertyID, item3.Count, item3.Data, builder, ref property);
				}
			}
			finally
			{
				UnsafeUtility.Free(ptr, Allocator.Persistent);
			}
			BlobAssetReference<PropertyLookupBlob> blobAsset = builder.CreateBlobAssetReference<PropertyLookupBlob>(Allocator.Persistent);
			blobAssetStore.TryAdd(ref blobAsset);
			return new PropertyLookup(blobAsset);
		}

		public ObjectPropertiesCD CreateObjectPropertiesComponent(int index, BlobAssetStore blobAssetStore)
		{
			_objectPropertiesCache.Clear();
			foreach (AddedProperty item in _propertySet)
			{
				if (item.LookupIndex == index)
				{
					_objectPropertiesCache.Add(item);
				}
			}
			int chunkSize = ((_objectPropertiesCache.Count == 0) ? 16 : 512);
			using BlobBuilder builder = new BlobBuilder(Allocator.Temp, chunkSize);
			BlobBuilderArray<PropertyData> blobBuilderArray = builder.Allocate(ref builder.ConstructRoot<ObjectData>().Properties, _objectPropertiesCache.Count);
			for (int i = 0; i < blobBuilderArray.Length; i++)
			{
				AddedProperty addedProperty = _objectPropertiesCache[i];
				BuildProperty(addedProperty.PropertyID, addedProperty.Count, addedProperty.Data, builder, ref blobBuilderArray[i]);
			}
			BlobAssetReference<ObjectData> blobAsset = builder.CreateBlobAssetReference<ObjectData>(Allocator.Persistent);
			blobAssetStore.TryAdd(ref blobAsset);
			return new ObjectPropertiesCD
			{
				ObjectData = blobAsset
			};
		}

		[PropertyIDGenerator(1)]
		public void SetProperty(int index, string property)
		{
			if (index < 0)
			{
				throw new InvalidOperationException("got negative index");
			}
			HashSet<AddedProperty> propertySet = GetPropertySet();
			AddedProperty item = new AddedProperty
			{
				LookupIndex = index,
				PropertyID = Property.StringToHash(property)
			};
			propertySet.Add(item);
		}

		[PropertyIDGenerator(1)]
		public unsafe void SetProperty<T>(int index, string property, T value) where T : unmanaged
		{
			if (index < 0)
			{
				throw new InvalidOperationException("got negative index");
			}
			HashSet<AddedProperty> propertySet = GetPropertySet();
			AddedProperty item = new AddedProperty
			{
				LookupIndex = index,
				PropertyID = Property.StringToHash(property)
			};
			item.Data = new byte[UnsafeUtility.SizeOf<T>()];
			item.Count = 1;
			fixed (byte* data = item.Data)
			{
				UnsafeUtility.CopyStructureToPtr(ref value, data);
			}
			if (!propertySet.Add(item))
			{
				Debug.Log($"replacing {property} at index {index}");
				propertySet.Remove(item);
				propertySet.Add(item);
			}
		}

		public bool HasProperty(int index, string property)
		{
			if (index < 0)
			{
				throw new InvalidOperationException("got negative index");
			}
			HashSet<AddedProperty> propertySet = GetPropertySet();
			AddedProperty item = new AddedProperty
			{
				LookupIndex = index,
				PropertyID = Property.StringToHash(property)
			};
			return propertySet.Contains(item);
		}

		[PropertyIDGenerator(1)]
		public unsafe void SetPropertyList<T>(int index, string property, T[] values) where T : unmanaged
		{
			if (index < 0)
			{
				throw new InvalidOperationException("got negative index");
			}
			HashSet<AddedProperty> propertySet = GetPropertySet();
			AddedProperty item = new AddedProperty
			{
				LookupIndex = index,
				PropertyID = Property.StringToHash(property)
			};
			item.Data = new byte[UnsafeUtility.SizeOf<T>() * values.Length];
			item.Count = values.Length;
			fixed (byte* data = item.Data)
			{
				fixed (T* source = values)
				{
					UnsafeUtility.MemCpy(data, source, item.Data.Length);
				}
			}
			if (!propertySet.Add(item))
			{
				Debug.Log($"replacing {property} at index {index}");
				propertySet.Remove(item);
				propertySet.Add(item);
			}
		}

		[PropertyIDGenerator(1)]
		public void SetPropertyString(int index, string property, string value)
		{
			SetPropertyList(index, property, value.ToCharArray());
		}

		public void RemoveProperty(int index, string property)
		{
			HashSet<AddedProperty> propertySet = GetPropertySet();
			AddedProperty item = new AddedProperty
			{
				LookupIndex = index,
				PropertyID = Property.StringToHash(property)
			};
			if (!propertySet.Contains(item))
			{
				Debug.LogError($"trying to remove property {property} from {index}: no such property on object");
			}
			else
			{
				propertySet.Remove(item);
			}
		}

		public void Add(PropertyLookup previousObjects, int oldIndex, int newIndex)
		{
			using NativeArray<int> nativeArray = previousObjects.GetProperties(oldIndex, Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				SetPropertyData(newIndex, ref previousObjects.GetPropertyData(oldIndex, nativeArray[i]));
			}
		}

		internal void SetPropertyData(int lookupIndex, ref PropertyData propertyData)
		{
			_propertySet.Add(new AddedProperty
			{
				LookupIndex = lookupIndex,
				PropertyID = propertyData.PropertyId,
				Data = propertyData.Data.ToArray(),
				Count = propertyData.Count
			});
		}

		public Enum<T> AsEnum<T>() where T : struct, Enum
		{
			return new Enum<T>(this);
		}

		public IEnumerator<Entry> GetEnumerator()
		{
			return _propertySet.Select((AddedProperty x) => new Entry
			{
				Index = x.LookupIndex,
				Property = x.PropertyID
			}).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
