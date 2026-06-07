using System;
using System.Collections;
using System.Collections.Generic;

internal class ZGuZfNPqfRgjbnNBoDysCJxTgCLcb<_0001> : BELhTlGtVzMbILpFpqteaGLGhYjjB, IEnumerable<_0001>, uLxgsfihVaAnYXRYUIZsFGPfsoZBB<_0001>, tYmuMMqjQIuRXkXSUugioNMkCjZn<_0001>, ICollection<_0001>, IEnumerable where _0001 : MRcfhzKWHsEVtgrgTIJjhcSTJjwN
{
	public struct putgkeqgVsAVDVVIsQHTpIfOdcIX : IEnumerator<_0001>, IDisposable, IEnumerator
	{
		private ZGuZfNPqfRgjbnNBoDysCJxTgCLcb<_0001> NGLyKwOpNGcyOvXHVCeKEkCvjMbqA;

		private int OMtaLVqQlSrbHcASmdJijPcULVhA;

		private _0001 BkOPFuJPuwwYFxfFTaZXlqNCSHtU;

		public _0001 Current => BkOPFuJPuwwYFxfFTaZXlqNCSHtU;

		object IEnumerator.Current
		{
			get
			{
				if (OMtaLVqQlSrbHcASmdJijPcULVhA == 0 || OMtaLVqQlSrbHcASmdJijPcULVhA == NGLyKwOpNGcyOvXHVCeKEkCvjMbqA.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return Current;
			}
		}

		internal putgkeqgVsAVDVVIsQHTpIfOdcIX(ZGuZfNPqfRgjbnNBoDysCJxTgCLcb<_0001> P_0)
		{
			NGLyKwOpNGcyOvXHVCeKEkCvjMbqA = P_0;
			OMtaLVqQlSrbHcASmdJijPcULVhA = 0;
			BkOPFuJPuwwYFxfFTaZXlqNCSHtU = default(_0001);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			ZGuZfNPqfRgjbnNBoDysCJxTgCLcb<_0001> nGLyKwOpNGcyOvXHVCeKEkCvjMbqA = NGLyKwOpNGcyOvXHVCeKEkCvjMbqA;
			if ((uint)OMtaLVqQlSrbHcASmdJijPcULVhA < (uint)nGLyKwOpNGcyOvXHVCeKEkCvjMbqA.Count)
			{
				BkOPFuJPuwwYFxfFTaZXlqNCSHtU = nGLyKwOpNGcyOvXHVCeKEkCvjMbqA[OMtaLVqQlSrbHcASmdJijPcULVhA];
				OMtaLVqQlSrbHcASmdJijPcULVhA++;
				return true;
			}
			return QOvljmokDmXRpGUSLecBoacQgJAFA();
		}

		private bool QOvljmokDmXRpGUSLecBoacQgJAFA()
		{
			OMtaLVqQlSrbHcASmdJijPcULVhA = NGLyKwOpNGcyOvXHVCeKEkCvjMbqA.Count + 1;
			BkOPFuJPuwwYFxfFTaZXlqNCSHtU = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			OMtaLVqQlSrbHcASmdJijPcULVhA = 0;
			BkOPFuJPuwwYFxfFTaZXlqNCSHtU = default(_0001);
		}
	}

	private Func<IntPtr, uint> JhAWTzgaPIDOnLtQavnZtcmPXFuX;

	private Func<IntPtr, uint, _0001> ghtJbiOdghXXcSGNaZVyKYiZKORh;

	public int Count
	{
		get
		{
			if (!ogYALaznNLQhDnTsEfBTemdgcFJA.LOAKUriHGZEbByAroDTyQAHhOjqU)
			{
				return 0;
			}
			return (int)JhAWTzgaPIDOnLtQavnZtcmPXFuX(ogYALaznNLQhDnTsEfBTemdgcFJA.gpRRWpNgaNJmzGbrEaNwChwYyxtY);
		}
	}

	public bool IsReadOnly => true;

	public _0001 this[int P_0]
	{
		get
		{
			if (P_0 < 0 || P_0 >= Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!ogYALaznNLQhDnTsEfBTemdgcFJA.LOAKUriHGZEbByAroDTyQAHhOjqU)
			{
				return default(_0001);
			}
			return ghtJbiOdghXXcSGNaZVyKYiZKORh(ogYALaznNLQhDnTsEfBTemdgcFJA.gpRRWpNgaNJmzGbrEaNwChwYyxtY, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public ZGuZfNPqfRgjbnNBoDysCJxTgCLcb(fTdetHoZcdRUbkTwkogFXUoufns P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		JhAWTzgaPIDOnLtQavnZtcmPXFuX = P_1;
		ghtJbiOdghXXcSGNaZVyKYiZKORh = P_2;
	}

	public int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(_0001 P_0)
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this[i];
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.hldVlmZiYtOAMBUhZgNvxGgZETbs();
			if (num)
			{
				return i;
			}
		}
		return -1;
	}

	public void Add(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void Clear()
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public bool Contains(_0001 item)
	{
		return oIZRqqhhcNLckNTOGNWcXEsLzPfQ(item) >= 0;
	}

	public void CopyTo(_0001[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			array[i + arrayIndex] = this[i];
		}
	}

	public bool Remove(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public IEnumerator<_0001> GetEnumerator()
	{
		return new putgkeqgVsAVDVVIsQHTpIfOdcIX(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void QlAcDtYBLLEHUmXpXHxYHAkLGFuGb(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void WcOHowhbUcOGUjNfDRwijiqZBXxbA(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
