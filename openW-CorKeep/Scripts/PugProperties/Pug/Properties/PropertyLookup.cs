using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Pug.Properties
{
	public struct PropertyLookup : IDisposable, IEnumerable<PropertyLookup.Entry>, IEnumerable
	{
		public class Enumerator : IEnumerator<Entry>, IEnumerator, IDisposable
		{
			private BlobAssetReference<PropertyLookupBlob> _propertyLookupBlob;

			private int _objectIndex;

			private int _propertyIndex;

			public Entry Current => new Entry
			{
				Index = _objectIndex,
				Property = _propertyLookupBlob.Value.Objects[_objectIndex].Properties[_propertyIndex].PropertyId
			};

			object IEnumerator.Current => Current;

			public Enumerator(PropertyLookup propertyLookup)
			{
				_propertyLookupBlob = propertyLookup._propertyLookupBlob;
				_objectIndex = (_propertyIndex = -1);
			}

			public bool MoveNext()
			{
				while (true)
				{
					if (_objectIndex >= _propertyLookupBlob.Value.Objects.Length)
					{
						return false;
					}
					_propertyIndex++;
					if (_objectIndex != -1 && _propertyIndex < _propertyLookupBlob.Value.Objects[_objectIndex].Properties.Length)
					{
						break;
					}
					_objectIndex++;
					_propertyIndex = -1;
				}
				return true;
			}

			public void Reset()
			{
				_objectIndex = (_propertyIndex = -1);
			}

			public void Dispose()
			{
			}
		}

		private class PropertyCollection : IEnumerable<Entry>, IEnumerable
		{
			private readonly PropertyLookup _propertyLookup;

			private readonly int _propertyId;

			public PropertyCollection(PropertyLookup propertyLookup, int propertyId)
			{
				_propertyLookup = propertyLookup;
				_propertyId = propertyId;
			}

			public IEnumerator<Entry> GetEnumerator()
			{
				return new PropertyCollectionEnumerator(_propertyLookup, _propertyId);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private class PropertyCollectionEnumerator : IEnumerator<Entry>, IEnumerator, IDisposable
		{
			private readonly Enumerator _baseEnumerator;

			private readonly int _propertyId;

			public Entry Current => _baseEnumerator.Current;

			object IEnumerator.Current => Current;

			public PropertyCollectionEnumerator(PropertyLookup propertyLookup, int propertyId)
			{
				_baseEnumerator = new Enumerator(propertyLookup);
				_propertyId = propertyId;
			}

			public bool MoveNext()
			{
				while (_baseEnumerator.MoveNext())
				{
					if (_baseEnumerator.Current.Property == _propertyId)
					{
						return true;
					}
				}
				return false;
			}

			public void Reset()
			{
				_baseEnumerator.Reset();
			}

			public void Dispose()
			{
				_baseEnumerator.Dispose();
			}
		}

		public class Enum<T> : IEnumerable<Enum<T>.Entry>, IEnumerable where T : struct, Enum
		{
			public class Enumerator : IEnumerator<Entry>, IEnumerator, IDisposable
			{
				private IEnumerator<PropertyLookup.Entry> _enumerator;

				public Entry Current
				{
					get
					{
						PropertyLookup.Entry current = _enumerator.Current;
						return new Entry
						{
							Index = UnsafeUtility.As<int, T>(ref current.Index),
							Property = current.Property
						};
					}
				}

				object IEnumerator.Current => Current;

				public Enumerator(IEnumerator<PropertyLookup.Entry> enumerator)
				{
					_enumerator = enumerator;
				}

				public bool MoveNext()
				{
					return _enumerator.MoveNext();
				}

				public void Reset()
				{
					_enumerator.Reset();
				}

				public void Dispose()
				{
					_enumerator.Dispose();
				}
			}

			public struct Entry
			{
				public T Index;

				public int Property;
			}

			private PropertyLookup _propertyLookup;

			public PropertyLookup BasePropertyLookup => _propertyLookup;

			internal Enum(PropertyLookup propertyLookup)
			{
				_propertyLookup = propertyLookup;
			}

			public bool HasProperty(T index, string property)
			{
				return _propertyLookup.HasProperty(UnsafeUtility.As<T, int>(ref index), Property.StringToHash(property));
			}

			public bool HasProperty(T index, int property)
			{
				return _propertyLookup.HasProperty(UnsafeUtility.As<T, int>(ref index), property);
			}

			public TU GetProperty<TU>(T index, string property) where TU : unmanaged
			{
				return _propertyLookup.GetProperty<TU>(UnsafeUtility.As<T, int>(ref index), property);
			}

			public TU GetProperty<TU>(T index, int property) where TU : unmanaged
			{
				return _propertyLookup.GetProperty<TU>(UnsafeUtility.As<T, int>(ref index), property);
			}

			public string GetPropertyString(T index, string property)
			{
				return _propertyLookup.GetPropertyString(UnsafeUtility.As<T, int>(ref index), property);
			}

			public string GetPropertyString(T index, int property)
			{
				return _propertyLookup.GetPropertyString(UnsafeUtility.As<T, int>(ref index), property);
			}

			public bool TryGetProperty<TU>(T index, string property, out TU value) where TU : unmanaged
			{
				return _propertyLookup.TryGetProperty<TU>(UnsafeUtility.As<T, int>(ref index), Property.StringToHash(property), out value);
			}

			public bool TryGetProperty<TU>(T index, int property, out TU value) where TU : unmanaged
			{
				return _propertyLookup.TryGetProperty<TU>(UnsafeUtility.As<T, int>(ref index), property, out value);
			}

			public bool TryGetPropertyString(T index, string property, out string value)
			{
				return _propertyLookup.TryGetPropertyString(UnsafeUtility.As<T, int>(ref index), Property.StringToHash(property), out value);
			}

			public bool TryGetPropertyString(T index, int property, out string value)
			{
				return _propertyLookup.TryGetPropertyString(UnsafeUtility.As<T, int>(ref index), property, out value);
			}

			public IEnumerator<Entry> GetEnumerator()
			{
				return new Enumerator(_propertyLookup.GetEnumerator());
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public struct Entry
		{
			public int Index;

			public int Property;
		}

		private BlobAssetReference<PropertyLookupBlob> _propertyLookupBlob;

		public bool IsCreated => _propertyLookupBlob.IsCreated;

		public BlobAssetReference<PropertyLookupBlob> GetPropertyLookup()
		{
			return _propertyLookupBlob;
		}

		public PropertyLookup(BlobAssetReference<PropertyLookupBlob> blob)
		{
			_propertyLookupBlob = blob;
		}

		public void Dispose()
		{
			if (_propertyLookupBlob.IsCreated)
			{
				_propertyLookupBlob.Dispose();
				_propertyLookupBlob = default(BlobAssetReference<PropertyLookupBlob>);
			}
		}

		public bool HasProperty(int index, string property)
		{
			return HasProperty(index, Property.StringToHash(property));
		}

		public bool HasProperty(int index, int property)
		{
			return _propertyLookupBlob.Value.Has(index, property);
		}

		public T GetProperty<T>(int index, string property) where T : unmanaged
		{
			if (!TryGetProperty<T>(index, Property.StringToHash(property), out var value))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public T GetProperty<T>(int index, int property) where T : unmanaged
		{
			if (!TryGetProperty<T>(index, property, out var value))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public bool TryGetProperty<T>(int index, string property, out T value) where T : unmanaged
		{
			return TryGetProperty<T>(index, Property.StringToHash(property), out value);
		}

		public bool TryGetProperty<T>(int index, int property, out T value) where T : unmanaged
		{
			return _propertyLookupBlob.Value.TryGet<T>(index, property, out value);
		}

		public NativeArray<T> GetPropertyList<T>(int index, string property, Allocator allocator) where T : unmanaged
		{
			if (!TryGetPropertyList(index, Property.StringToHash(property), out NativeArray<T> value, allocator))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public NativeArray<T> GetPropertyString<T>(int index, int property, Allocator allocator) where T : unmanaged
		{
			if (!TryGetPropertyList(index, property, out NativeArray<T> value, allocator))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public bool TryGetPropertyList<T>(int index, string property, out NativeArray<T> value, Allocator allocator) where T : unmanaged
		{
			return TryGetPropertyList(index, Property.StringToHash(property), out value, allocator);
		}

		public bool TryGetPropertyList<T>(int index, int property, out NativeArray<T> value, Allocator allocator) where T : unmanaged
		{
			if (!_propertyLookupBlob.Value.TryGetList(index, property, out value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				value = default(NativeArray<T>);
				return false;
			}
			return true;
		}

		public string GetPropertyString(int index, string property)
		{
			if (!TryGetPropertyString(index, Property.StringToHash(property), out var value))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public string GetPropertyString(int index, int property)
		{
			if (!TryGetPropertyString(index, property, out var value))
			{
				throw new InvalidOperationException("property doesn't exist");
			}
			return value;
		}

		public bool TryGetPropertyString(int index, string property, out string value)
		{
			return TryGetPropertyString(index, Property.StringToHash(property), out value);
		}

		public unsafe bool TryGetPropertyString(int index, int property, out string value)
		{
			if (!_propertyLookupBlob.Value.TryGetList(index, property, out NativeArray<char> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				value = null;
				return false;
			}
			value = new string((char*)value2.GetUnsafeReadOnlyPtr(), 0, value2.Length);
			value2.Dispose();
			return true;
		}

		public NativeArray<int> GetProperties(int index, Allocator allocator)
		{
			if (index >= _propertyLookupBlob.Value.Objects.Length)
			{
				return new NativeArray<int>(0, allocator);
			}
			NativeArray<int> result = new NativeArray<int>(_propertyLookupBlob.Value.Objects[index].Properties.Length, allocator);
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = _propertyLookupBlob.Value.Objects[index].Properties[i].PropertyId;
			}
			return result;
		}

		internal ref PropertyData GetPropertyData(int oldObjectId, int property)
		{
			return ref _propertyLookupBlob.Value.Objects[oldObjectId].Get(property);
		}

		public IEnumerator<Entry> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Enum<T> AsEnum<T>() where T : struct, Enum
		{
			return new Enum<T>(this);
		}

		public IEnumerable<Entry> GetProperties(int propertyId)
		{
			return new PropertyCollection(this, propertyId);
		}
	}
}
