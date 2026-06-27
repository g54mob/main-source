using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class NpVUlmiMnxFiEjNvHeMKeeZURneab<_0001> : HUyUVYKMFBcVfJDnCCVUrIzoNbUR, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::tvLBShbBMuaQsfAsBzAASHwotIeHc<_0001>, global::upQYuCAUBEKqdxPszhpElUpjDPyu<_0001> where _0001 : MvNnXAnbTYBdIWBGeeyNCUoIuYFN
{
	public struct pXMeaJTQRUMXitKkNrLxMBJZZpfj : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::NpVUlmiMnxFiEjNvHeMKeeZURneab<_0001> xVZZfpAaCAusFzVwhWiqJelNBXGe;

		private int GSdeAhzdbXnuqjiSxvuxRRAcfVGL;

		private _0001 JTBxoaYwCdWttECYToQlCPNTXNxN;

		_0001 IEnumerator<_0001>.Current => JTBxoaYwCdWttECYToQlCPNTXNxN;

		object IEnumerator.Current
		{
			get
			{
				if (GSdeAhzdbXnuqjiSxvuxRRAcfVGL == 0 || GSdeAhzdbXnuqjiSxvuxRRAcfVGL == xVZZfpAaCAusFzVwhWiqJelNBXGe.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal pXMeaJTQRUMXitKkNrLxMBJZZpfj(global::NpVUlmiMnxFiEjNvHeMKeeZURneab<_0001> P_0)
		{
			xVZZfpAaCAusFzVwhWiqJelNBXGe = P_0;
			GSdeAhzdbXnuqjiSxvuxRRAcfVGL = 0;
			JTBxoaYwCdWttECYToQlCPNTXNxN = default(_0001);
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			global::NpVUlmiMnxFiEjNvHeMKeeZURneab<_0001> npVUlmiMnxFiEjNvHeMKeeZURneab = xVZZfpAaCAusFzVwhWiqJelNBXGe;
			if ((uint)GSdeAhzdbXnuqjiSxvuxRRAcfVGL < (uint)npVUlmiMnxFiEjNvHeMKeeZURneab.Count)
			{
				JTBxoaYwCdWttECYToQlCPNTXNxN = npVUlmiMnxFiEjNvHeMKeeZURneab.zkLQanmKyXosPSrwDfVTjUHbrlTv(GSdeAhzdbXnuqjiSxvuxRRAcfVGL);
				GSdeAhzdbXnuqjiSxvuxRRAcfVGL++;
				return true;
			}
			return eDFiVMXLXTcgWFRPkuKcmvmhBIMD();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool eDFiVMXLXTcgWFRPkuKcmvmhBIMD()
		{
			GSdeAhzdbXnuqjiSxvuxRRAcfVGL = xVZZfpAaCAusFzVwhWiqJelNBXGe.Count + 1;
			JTBxoaYwCdWttECYToQlCPNTXNxN = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			GSdeAhzdbXnuqjiSxvuxRRAcfVGL = 0;
			JTBxoaYwCdWttECYToQlCPNTXNxN = default(_0001);
		}
	}

	private Func<IntPtr, uint> EVWtsVxGbVDNVlwMpcrbaGenrHOzA;

	private Func<IntPtr, uint, _0001> RPoAblXNmjPydZrzFsPjufOKhIoy;

	int global::upQYuCAUBEKqdxPszhpElUpjDPyu<_0001>.Count
	{
		get
		{
			if (!wetImTnjpzvkTpqpyaKbdaOdycwFA.FqXdMpGbBFOCxYSvjqmDtzXwOwQn)
			{
				return 0;
			}
			return (int)EVWtsVxGbVDNVlwMpcrbaGenrHOzA(wetImTnjpzvkTpqpyaKbdaOdycwFA.IVwGTAkbCDrqCJgedViExkDOBvSbA);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::tvLBShbBMuaQsfAsBzAASHwotIeHc<_0001>.BDZnBdTEkqdWiAQhWnbxIRhouJlL
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!wetImTnjpzvkTpqpyaKbdaOdycwFA.FqXdMpGbBFOCxYSvjqmDtzXwOwQn)
			{
				return default(_0001);
			}
			return RPoAblXNmjPydZrzFsPjufOKhIoy(wetImTnjpzvkTpqpyaKbdaOdycwFA.IVwGTAkbCDrqCJgedViExkDOBvSbA, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public NpVUlmiMnxFiEjNvHeMKeeZURneab(rekqjQgbBOUmnTjvFUbAgMkjAMAK P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		EVWtsVxGbVDNVlwMpcrbaGenrHOzA = P_1;
		RPoAblXNmjPydZrzFsPjufOKhIoy = P_2;
	}

	public int AfCoPaIShpyvmhjAPCcKdhCoGJkG(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.zkLQanmKyXosPSrwDfVTjUHbrlTv(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.hnNeDQdohWAYWTOrNrhFVpxBDDHlA();
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

	void ICollection<_0001>.Add(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(item);
	}

	public void Clear()
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	void ICollection<_0001>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	public bool Contains(_0001 item)
	{
		return AfCoPaIShpyvmhjAPCcKdhCoGJkG(item) >= 0;
	}

	bool ICollection<_0001>.Contains(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(item);
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
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			array[i + arrayIndex] = this.zkLQanmKyXosPSrwDfVTjUHbrlTv(i);
		}
	}

	void ICollection<_0001>.CopyTo(_0001[] array, int arrayIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CopyTo
		this.CopyTo(array, arrayIndex);
	}

	public bool Remove(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	bool ICollection<_0001>.Remove(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(item);
	}

	public IEnumerator<_0001> GetEnumerator()
	{
		return new pXMeaJTQRUMXitKkNrLxMBJZZpfj(this);
	}

	IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void xhplfaPnPwdyLiTtFDmjcCRKoBGIA(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void GIIGMswQikfTwoLolxHwbngTBbBhA(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
