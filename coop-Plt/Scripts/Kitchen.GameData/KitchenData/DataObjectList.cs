using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace KitchenData
{
	[Serializable]
	[MessagePackObject(false)]
	[MessagePackFormatter(typeof(CardListFormatter))]
	public struct DataObjectList
	{
		public struct ItemComponentEnumerator : IEnumerator<int>, IEnumerator, IDisposable
		{
			private int Index;

			private FixedListInt512 Components;

			private int Size;

			public int Current
			{
				get
				{
					if (Size > Index)
					{
						return Components[Index];
					}
					return 0;
				}
			}

			object IEnumerator.Current => Current;

			public ItemComponentEnumerator(FixedListInt512 data)
			{
				Components = data;
				Index = -1;
				Size = data.Length;
			}

			public void Initialise(FixedListInt512 data)
			{
				Components = data;
				Index = -1;
				Size = data.Length;
			}

			public bool MoveNext()
			{
				Index++;
				return Index < Size;
			}

			public void Reset()
			{
				Index = -1;
			}

			public void Dispose()
			{
			}
		}

		private class CardListFormatter : IMessagePackFormatter<DataObjectList>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, DataObjectList value, MessagePackSerializerOptions options)
			{
				int[] array = new int[value.Count];
				for (int i = 0; i < value.Count; i++)
				{
					array[i] = value[i];
				}
				options.Resolver.GetFormatterWithVerify<int[]>().Serialize(ref writer, array, options);
			}

			public DataObjectList Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				int[] array = options.Resolver.GetFormatterWithVerify<int[]>().Deserialize(ref reader, options);
				DataObjectList result = default(DataObjectList);
				int[] array2 = array;
				foreach (int a in array2)
				{
					result.Add(a);
				}
				return result;
			}
		}

		[Key(0)]
		private FixedListInt512 Data;

		[IgnoreMember]
		private int[] Items => Data.ToArray();

		[IgnoreMember]
		public int Count => Data.Length;

		[IgnoreMember]
		public static DataObjectList Empty { get; }

		[IgnoreMember]
		public int this[int index]
		{
			get
			{
				if (Data.Length <= index)
				{
					return 0;
				}
				return Data[index];
			}
			set
			{
				if (index == Data.Length)
				{
					Data.Add(in value);
				}
				else
				{
					Data[index] = value;
				}
			}
		}

		public bool Contains(int value)
		{
			return Data.Contains(value);
		}

		[SerializationConstructor]
		public DataObjectList(FixedListInt64 data)
		{
			Data = data;
		}

		public DataObjectList(int a)
		{
			Data = default(FixedListInt64);
			Data.Add(in a);
		}

		public DataObjectList(int a, int b)
		{
			Data = default(FixedListInt64);
			Data.Add(in a);
			Data.Add(in b);
		}

		public static DataObjectList FromList<T>(List<T> list, Func<T, int> map)
		{
			DataObjectList result = default(DataObjectList);
			foreach (T item in list)
			{
				result.Add(map(item));
			}
			return result;
		}

		public void Add(int a)
		{
			Data.Add(in a);
		}

		public void Remove(int value)
		{
			for (int num = Data.Length - 1; num >= 0; num--)
			{
				if (Data[num] == value)
				{
					Data.RemoveAt(num);
				}
			}
		}

		public void RemoveAt(int index)
		{
			Data.RemoveAt(index);
		}

		public bool IsEquivalent(DataObjectList other)
		{
			if (other.Count != Count)
			{
				return false;
			}
			int num = 0;
			foreach (int datum in Data)
			{
				bool flag = false;
				for (int i = 0; i < other.Count; i++)
				{
					if (other[i] == datum)
					{
						num++;
						other[i] = -1;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return num == Count;
		}

		public static DataObjectList operator +(DataObjectList a, DataObjectList b)
		{
			FixedListInt64 data = default(FixedListInt64);
			foreach (int item in a)
			{
				data.Add(item);
			}
			foreach (int item2 in b)
			{
				data.Add(item2);
			}
			return new DataObjectList(data);
		}

		public static DataObjectList operator +(int a, DataObjectList b)
		{
			FixedListInt64 data = new FixedListInt64 { in a };
			foreach (int item in b)
			{
				data.Add(item);
			}
			return new DataObjectList(data);
		}

		public static DataObjectList operator +(DataObjectList a, int b)
		{
			FixedListInt64 data = default(FixedListInt64);
			foreach (int item in a)
			{
				data.Add(item);
			}
			data.Add(in b);
			return new DataObjectList(data);
		}

		public ItemComponentEnumerator GetEnumerator()
		{
			return new ItemComponentEnumerator(Data);
		}

		public override int GetHashCode()
		{
			return Data.GetHashCode();
		}
	}
}
