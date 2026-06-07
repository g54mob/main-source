using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wintellect.PowerCollections
{
	[Serializable]
	internal class Hash<T> : IEnumerable<T>, IEnumerable, ISerializable, IDeserializationCallback
	{
		private struct Slot
		{
			private uint hash_collision;

			public T item;

			public int HashValue
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public bool Empty => false;

			public bool Collision
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public void Clear()
			{
			}
		}

		private IEqualityComparer<T> equalityComparer;

		private int count;

		private int usedSlots;

		private int totalSlots;

		private float loadFactor;

		private int thresholdGrow;

		private int thresholdShrink;

		private int hashMask;

		private int secondaryShift;

		private Slot[] table;

		private int changeStamp;

		private const int MINSIZE = 16;

		private SerializationInfo serializationInfo;

		public int ElementCount => 0;

		internal int SlotCount => 0;

		public float LoadFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Hash(IEqualityComparer<T> equalityComparer)
		{
		}

		internal int GetEnumerationStamp()
		{
			return 0;
		}

		internal void StopEnumerations()
		{
		}

		internal void CheckEnumerationStamp(int startStamp)
		{
		}

		private int GetFullHash(T item)
		{
			return 0;
		}

		private void GetHashValuesFromFullHash(int hash, out int initialBucket, out int skip)
		{
			initialBucket = default(int);
			skip = default(int);
		}

		private int GetHashValues(T item, out int initialBucket, out int skip)
		{
			initialBucket = default(int);
			skip = default(int);
			return 0;
		}

		private void EnsureEnoughSlots(int additionalItems)
		{
		}

		private void ShrinkIfNeeded()
		{
		}

		private static int GetSecondaryShift(int newSize)
		{
			return 0;
		}

		private void ResizeTable(int newSize)
		{
		}

		public bool Insert(T item, bool replaceOnDuplicate, out T previous)
		{
			previous = default(T);
			return false;
		}

		public bool Delete(T item, out T itemDeleted)
		{
			itemDeleted = default(T);
			return false;
		}

		public bool Find(T find, bool replace, out T item)
		{
			item = default(T);
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public Hash<T> Clone(Converter<T, T> cloneItem)
		{
			return null;
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		protected Hash(SerializationInfo serInfo, StreamingContext context)
		{
		}

		void IDeserializationCallback.OnDeserialization(object sender)
		{
		}
	}
}
