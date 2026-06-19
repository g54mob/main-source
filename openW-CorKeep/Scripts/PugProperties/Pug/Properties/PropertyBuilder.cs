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
	public class PropertyBuilder : IEnumerable<int>, IEnumerable
	{
		private struct AddedProperty : IEquatable<AddedProperty>
		{
			public int PropertyID;

			public byte[] Data;

			public int Count;

			public override string ToString()
			{
				return PropertyID.ToString() ?? "";
			}

			public override int GetHashCode()
			{
				return PropertyID;
			}

			public bool Equals(AddedProperty other)
			{
				return PropertyID == other.PropertyID;
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

		private readonly HashSet<AddedProperty> _objectProperties = new HashSet<AddedProperty>();

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

		public PropertyBlob Create(BlobAssetStore blobAssetStore)
		{
			if (_objectProperties.Count == 0)
			{
				return new PropertyBlob
				{
					ObjectData = BlobAssetReference<ObjectData>.Null
				};
			}
			int chunkSize = ((_objectProperties.Count == 0) ? 16 : 512);
			using BlobBuilder builder = new BlobBuilder(Allocator.Temp, chunkSize);
			BlobBuilderArray<PropertyData> blobBuilderArray = builder.Allocate(ref builder.ConstructRoot<ObjectData>().Properties, _objectProperties.Count);
			int num = 0;
			foreach (AddedProperty objectProperty in _objectProperties)
			{
				BuildProperty(objectProperty.PropertyID, objectProperty.Count, objectProperty.Data, builder, ref blobBuilderArray[num++]);
			}
			BlobAssetReference<ObjectData> blobAsset = builder.CreateBlobAssetReference<ObjectData>(Allocator.Persistent);
			blobAssetStore.TryAdd(ref blobAsset);
			return new PropertyBlob
			{
				ObjectData = blobAsset
			};
		}

		[PropertyIDGenerator(0)]
		public void SetProperty(string property)
		{
			AddedProperty item = new AddedProperty
			{
				PropertyID = Property.StringToHash(property)
			};
			_objectProperties.Add(item);
		}

		[PropertyIDGenerator(0)]
		public unsafe void SetProperty<T>(string property, T value) where T : unmanaged
		{
			AddedProperty item = new AddedProperty
			{
				PropertyID = Property.StringToHash(property)
			};
			item.Data = new byte[UnsafeUtility.SizeOf<T>()];
			item.Count = 1;
			fixed (byte* data = item.Data)
			{
				UnsafeUtility.CopyStructureToPtr(ref value, data);
			}
			if (!_objectProperties.Add(item))
			{
				Debug.Log("replacing " + property);
				_objectProperties.Remove(item);
				_objectProperties.Add(item);
			}
		}

		public bool HasProperty(string property)
		{
			AddedProperty item = new AddedProperty
			{
				PropertyID = Property.StringToHash(property)
			};
			return _objectProperties.Contains(item);
		}

		[PropertyIDGenerator(0)]
		public unsafe void SetPropertyList<T>(string property, T[] values) where T : unmanaged
		{
			AddedProperty item = new AddedProperty
			{
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
			if (!_objectProperties.Add(item))
			{
				Debug.Log("replacing " + property);
				_objectProperties.Remove(item);
				_objectProperties.Add(item);
			}
		}

		[PropertyIDGenerator(0)]
		public void SetPropertyString(int index, string property, string value)
		{
			SetPropertyList(property, value.ToCharArray());
		}

		public void RemoveProperty(string property)
		{
			AddedProperty item = new AddedProperty
			{
				PropertyID = Property.StringToHash(property)
			};
			if (!_objectProperties.Contains(item))
			{
				Debug.LogError("trying to remove property " + property + ": no such property on object");
			}
			else
			{
				_objectProperties.Remove(item);
			}
		}

		public IEnumerator<int> GetEnumerator()
		{
			return _objectProperties.Select((AddedProperty x) => x.PropertyID).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
