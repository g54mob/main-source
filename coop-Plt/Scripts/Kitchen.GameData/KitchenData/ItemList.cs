using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;

namespace KitchenData
{
	[Serializable]
	[MessagePackObject(false)]
	[MessagePackFormatter(typeof(ItemListFormatter))]
	public struct ItemList
	{
		public struct ItemComponentEnumerator : IEnumerator<int>, IEnumerator, IDisposable
		{
			private int Index;

			private FixedListInt64 Components;

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

			public ItemComponentEnumerator(FixedListInt64 data)
			{
				Components = data;
				Index = -1;
				Size = data.Length;
			}

			public void Initialise(FixedListInt64 data)
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

		private class ItemListFormatter : IMessagePackFormatter<ItemList>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, ItemList value, MessagePackSerializerOptions options)
			{
				int[] array = new int[value.Count];
				for (int i = 0; i < value.Count; i++)
				{
					array[i] = value[i];
				}
				options.Resolver.GetFormatterWithVerify<int[]>().Serialize(ref writer, array, options);
			}

			public ItemList Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				int[] array = options.Resolver.GetFormatterWithVerify<int[]>().Deserialize(ref reader, options);
				ItemList result = default(ItemList);
				int[] array2 = array;
				foreach (int a in array2)
				{
					result.Add(a);
				}
				return result;
			}
		}

		[Key(0)]
		private FixedListInt64 Data;

		[IgnoreMember]
		private int[] Items => Data.ToArray();

		[IgnoreMember]
		public int Primary
		{
			get
			{
				if (Data.Length <= 0)
				{
					return 0;
				}
				return this[0];
			}
		}

		[IgnoreMember]
		public int Count => Data.Length;

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

		[IgnoreMember]
		public bool IsValid
		{
			get
			{
				if (Data.Length != 0)
				{
					return Primary != 0;
				}
				return false;
			}
		}

		[IgnoreMember]
		public bool IsNonGroup
		{
			get
			{
				if (Data.Length == 1)
				{
					return Primary != 0;
				}
				return false;
			}
		}

		public int[] AsArray()
		{
			return Data.ToArray();
		}

		[SerializationConstructor]
		public ItemList(FixedListInt64 data)
		{
			Data = data;
		}

		public ItemList(List<int> data)
		{
			Data = default(FixedListInt64);
			foreach (int datum in data)
			{
				int item = datum;
				Data.Add(in item);
			}
		}

		public ItemList(int a)
		{
			Data = default(FixedListInt64);
			Data.Add(in a);
		}

		public ItemList(int a, int b)
		{
			Data = default(FixedListInt64);
			Data.Add(in a);
			Data.Add(in b);
		}

		public void Add(int a)
		{
			Data.Add(in a);
		}

		public void RemoveAt(int index)
		{
			Data.RemoveAt(index);
		}

		[Pure]
		public bool IsEquivalent(int id)
		{
			if (Data.Length == 1)
			{
				return id == Primary;
			}
			return false;
		}

		[Pure]
		public bool IsEquivalent(ItemList other, bool require_first_match = false)
		{
			if (other.Count != Count)
			{
				return false;
			}
			if (require_first_match && other.Primary != Primary)
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
						other[i] = 0;
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

		[Pure]
		public ItemList Without(int exclude_item, int max_exclusions = -1)
		{
			ItemList result = default(ItemList);
			int num = 0;
			foreach (int datum in Data)
			{
				if ((max_exclusions < 0 || num < max_exclusions) && datum == exclude_item)
				{
					num++;
				}
				else
				{
					result.Add(datum);
				}
			}
			return result;
		}

		[Pure]
		public bool Contains(int id)
		{
			foreach (int datum in Data)
			{
				if (datum == id)
				{
					return true;
				}
			}
			return false;
		}

		public static ItemList operator +(ItemList a, ItemList b)
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
			return new ItemList(data);
		}

		public static ItemList operator +(int a, ItemList b)
		{
			FixedListInt64 data = new FixedListInt64 { in a };
			foreach (int item in b)
			{
				data.Add(item);
			}
			return new ItemList(data);
		}

		public static ItemList operator +(ItemList a, int b)
		{
			FixedListInt64 data = default(FixedListInt64);
			foreach (int item in a)
			{
				data.Add(item);
			}
			data.Add(in b);
			return new ItemList(data);
		}

		public ItemComponentEnumerator GetEnumerator()
		{
			return new ItemComponentEnumerator(Data);
		}
	}
}
