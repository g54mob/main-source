using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ScriptHelpers
{
	public struct SaveableStructArray<T> : ISaveableArray, IEnumerable<T>, IEnumerable where T : struct
	{
		public T[] array;

		public bool IsNull => array == null;

		public bool IsEmpty => array.Length < 1;

		public int Length => array.Length;

		public T this[int index] => array[index];

		public SaveableStructArray(ICollection<T> collection)
		{
			array = collection.ToArray();
		}

		public static SaveableStructArray<T> Empty()
		{
			return new SaveableStructArray<T>
			{
				array = Array.Empty<T>()
			};
		}

		public bool HasData()
		{
			if (!IsNull)
			{
				return !IsEmpty;
			}
			return false;
		}

		public JArray SaveState()
		{
			JArray result = new JArray();
			if (array == null)
			{
				return result;
			}
			return JArray.FromObject(array);
		}

		public void LoadState(JArray jArray)
		{
			array = jArray.ToObject<T[]>();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return array.ToList().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
