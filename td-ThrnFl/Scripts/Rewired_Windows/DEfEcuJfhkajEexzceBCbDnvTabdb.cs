using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class DEfEcuJfhkajEexzceBCbDnvTabdb<_0001> : VcCmMKdsLKFzjxHppOECKWHBbiPp, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::fXhMNdmEUzMDkivmQOBQezAANtlk<_0001>, global::eksknGlMJBcljZHmKTqUGnFKjUtDA<_0001> where _0001 : WfzoKJUFPMECeUYJazFxjUrcFYAA
{
	public struct riKlVqoNJFDkTRucgwvlrbqWCqkA : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::DEfEcuJfhkajEexzceBCbDnvTabdb<_0001> bqfWRhfWoBzkZLDTGBfeghCeSEZL;

		private int KYHtDbQOzOHvqTkYKjtxsJuVbmDAA;

		private _0001 ZAnmrmtpAuPyxsSEeEPjrPjycAsQ;

		_0001 IEnumerator<_0001>.Current => ZAnmrmtpAuPyxsSEeEPjrPjycAsQ;

		object IEnumerator.Current
		{
			get
			{
				if (KYHtDbQOzOHvqTkYKjtxsJuVbmDAA == 0 || KYHtDbQOzOHvqTkYKjtxsJuVbmDAA == bqfWRhfWoBzkZLDTGBfeghCeSEZL.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal riKlVqoNJFDkTRucgwvlrbqWCqkA(global::DEfEcuJfhkajEexzceBCbDnvTabdb<_0001> P_0)
		{
			bqfWRhfWoBzkZLDTGBfeghCeSEZL = P_0;
			KYHtDbQOzOHvqTkYKjtxsJuVbmDAA = 0;
			ZAnmrmtpAuPyxsSEeEPjrPjycAsQ = default(_0001);
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
			global::DEfEcuJfhkajEexzceBCbDnvTabdb<_0001> dEfEcuJfhkajEexzceBCbDnvTabdb = bqfWRhfWoBzkZLDTGBfeghCeSEZL;
			if ((uint)KYHtDbQOzOHvqTkYKjtxsJuVbmDAA < (uint)dEfEcuJfhkajEexzceBCbDnvTabdb.Count)
			{
				ZAnmrmtpAuPyxsSEeEPjrPjycAsQ = dEfEcuJfhkajEexzceBCbDnvTabdb.dQjfrhdXaUvdRCqkkcILlCbAvqIFA(KYHtDbQOzOHvqTkYKjtxsJuVbmDAA);
				KYHtDbQOzOHvqTkYKjtxsJuVbmDAA++;
				return true;
			}
			return govfWGmiNKcbWzkJDsteLnJEBOJO();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool govfWGmiNKcbWzkJDsteLnJEBOJO()
		{
			KYHtDbQOzOHvqTkYKjtxsJuVbmDAA = bqfWRhfWoBzkZLDTGBfeghCeSEZL.Count + 1;
			ZAnmrmtpAuPyxsSEeEPjrPjycAsQ = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			KYHtDbQOzOHvqTkYKjtxsJuVbmDAA = 0;
			ZAnmrmtpAuPyxsSEeEPjrPjycAsQ = default(_0001);
		}
	}

	private Func<IntPtr, uint> OymDvBMEhIhGBDXOAOsvkvGEnURYA;

	private Func<IntPtr, uint, _0001> NXCsppeaXgfAvnGfivRhLjctNbbL;

	int global::eksknGlMJBcljZHmKTqUGnFKjUtDA<_0001>.Count
	{
		get
		{
			if (!gvXXlHCfvccjDfFlPXJnrReAMlvcA.TZpFdntJSKFGtmbvGljVGKdVlmJf)
			{
				return 0;
			}
			return (int)OymDvBMEhIhGBDXOAOsvkvGEnURYA(gvXXlHCfvccjDfFlPXJnrReAMlvcA.AWMxAQRiIGWxMhpkQjxSYktlmrVK);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::fXhMNdmEUzMDkivmQOBQezAANtlk<_0001>.JQtaGpsgmdbigoEfpbgtKbZBYrepA
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!gvXXlHCfvccjDfFlPXJnrReAMlvcA.TZpFdntJSKFGtmbvGljVGKdVlmJf)
			{
				return default(_0001);
			}
			return NXCsppeaXgfAvnGfivRhLjctNbbL(gvXXlHCfvccjDfFlPXJnrReAMlvcA.AWMxAQRiIGWxMhpkQjxSYktlmrVK, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public DEfEcuJfhkajEexzceBCbDnvTabdb(viEpNAHHRHFFfjbvgOVCPmMEQDNR P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		OymDvBMEhIhGBDXOAOsvkvGEnURYA = P_1;
		NXCsppeaXgfAvnGfivRhLjctNbbL = P_2;
	}

	public int EpydSgdeYovtkPGpcEPYAsyNdVno(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.dQjfrhdXaUvdRCqkkcILlCbAvqIFA(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.lnlMCCHLhFMJKoetugaLbIDmCUULA();
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
		return EpydSgdeYovtkPGpcEPYAsyNdVno(item) >= 0;
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
			array[i + arrayIndex] = this.dQjfrhdXaUvdRCqkkcILlCbAvqIFA(i);
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
		return new riKlVqoNJFDkTRucgwvlrbqWCqkA(this);
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

	public void xqRCkwIwNngjDoIlochnqjxfHSVjA(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void IliSVqFMgpAtuUUoAGraAIWequEk(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
