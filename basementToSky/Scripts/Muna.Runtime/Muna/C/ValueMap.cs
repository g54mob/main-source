using System;
using System.Text;

namespace Muna.C
{
	public sealed class ValueMap : IDisposable
	{
		private readonly IntPtr map;

		public Value this[string key]
		{
			get
			{
				return GetValue(key);
			}
			set
			{
				map.SetValueMapValue(key, value).Throw();
			}
		}

		public int size
		{
			get
			{
				if (map.GetValueMapSize(out var result).Throw() != Function.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public ValueMap()
			: this((Function.CreateValueMap(out var intPtr).Throw() == Function.Status.Ok) ? intPtr : ((IntPtr)0))
		{
		}

		public string GetKey(int index)
		{
			StringBuilder stringBuilder = new StringBuilder(2048);
			map.GetValueMapKey(index, stringBuilder, stringBuilder.Capacity).Throw();
			return stringBuilder.ToString();
		}

		public Value GetValue(string key)
		{
			map.GetValueMapValue(key, out var value).Throw();
			return new Value(value);
		}

		public void Dispose()
		{
			map.ReleaseValueMap();
		}

		internal ValueMap(IntPtr map)
		{
			this.map = map;
		}

		public static implicit operator IntPtr(ValueMap map)
		{
			return map.map;
		}
	}
}
