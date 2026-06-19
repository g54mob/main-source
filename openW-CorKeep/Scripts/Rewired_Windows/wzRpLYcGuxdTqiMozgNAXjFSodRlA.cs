using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class wzRpLYcGuxdTqiMozgNAXjFSodRlA<_0001> : yIupvmOvCRePPYlmwhUIsObsIpzM, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::YtJIuBLbPotnEHRhBgNADOkrtETeA<_0001>, global::LoSLUsUoMAiBPaLnDawEskndlPXW<_0001> where _0001 : lcJPvkbHASkCcVITCezFJGwMpGaS
{
	public struct QZUWDxTMOEvBOmCpzgfvDCZNHLUv : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::wzRpLYcGuxdTqiMozgNAXjFSodRlA<_0001> ALHjlTMExEHThiTWRHHsUVwZbNxq;

		private int dwxGyPbUkRxFAaSFPHtnDWSuphtCA;

		private _0001 ekRNOOOaHvDGNDLHlMFzZVVTJHQbb;

		_0001 IEnumerator<_0001>.Current => ekRNOOOaHvDGNDLHlMFzZVVTJHQbb;

		object IEnumerator.Current
		{
			get
			{
				if (dwxGyPbUkRxFAaSFPHtnDWSuphtCA == 0 || dwxGyPbUkRxFAaSFPHtnDWSuphtCA == ALHjlTMExEHThiTWRHHsUVwZbNxq.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal QZUWDxTMOEvBOmCpzgfvDCZNHLUv(global::wzRpLYcGuxdTqiMozgNAXjFSodRlA<_0001> P_0)
		{
			ALHjlTMExEHThiTWRHHsUVwZbNxq = P_0;
			dwxGyPbUkRxFAaSFPHtnDWSuphtCA = 0;
			ekRNOOOaHvDGNDLHlMFzZVVTJHQbb = default(_0001);
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
			global::wzRpLYcGuxdTqiMozgNAXjFSodRlA<_0001> aLHjlTMExEHThiTWRHHsUVwZbNxq = ALHjlTMExEHThiTWRHHsUVwZbNxq;
			if ((uint)dwxGyPbUkRxFAaSFPHtnDWSuphtCA < (uint)aLHjlTMExEHThiTWRHHsUVwZbNxq.Count)
			{
				ekRNOOOaHvDGNDLHlMFzZVVTJHQbb = aLHjlTMExEHThiTWRHHsUVwZbNxq.KePwABmtfTLDbHPdxECFmoPfmtqX(dwxGyPbUkRxFAaSFPHtnDWSuphtCA);
				dwxGyPbUkRxFAaSFPHtnDWSuphtCA++;
				return true;
			}
			return TTBSvwNuCFLceIeUMdhgtdhdsJdq();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool TTBSvwNuCFLceIeUMdhgtdhdsJdq()
		{
			dwxGyPbUkRxFAaSFPHtnDWSuphtCA = ALHjlTMExEHThiTWRHHsUVwZbNxq.Count + 1;
			ekRNOOOaHvDGNDLHlMFzZVVTJHQbb = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			dwxGyPbUkRxFAaSFPHtnDWSuphtCA = 0;
			ekRNOOOaHvDGNDLHlMFzZVVTJHQbb = default(_0001);
		}
	}

	private Func<IntPtr, uint> ftCRSfjPgBzytuxHNehnNOovHWzG;

	private Func<IntPtr, uint, _0001> oHqTPmZfGhTTeUyBrfgfrIjEYrFE;

	int global::LoSLUsUoMAiBPaLnDawEskndlPXW<_0001>.Count
	{
		get
		{
			if (!RzzBKxfvitmPxfmsESBlFlUOjkJjc.sJgiHNECDVjZrXwXmxDenNiggdEA)
			{
				return 0;
			}
			return (int)ftCRSfjPgBzytuxHNehnNOovHWzG(RzzBKxfvitmPxfmsESBlFlUOjkJjc.xRmDrgbaZFtDmQWvPurKCgZAtrvY);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::YtJIuBLbPotnEHRhBgNADOkrtETeA<_0001>.wDVXbJHhxmGSIXGaigmdEZveVyQkA
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!RzzBKxfvitmPxfmsESBlFlUOjkJjc.sJgiHNECDVjZrXwXmxDenNiggdEA)
			{
				return default(_0001);
			}
			return oHqTPmZfGhTTeUyBrfgfrIjEYrFE(RzzBKxfvitmPxfmsESBlFlUOjkJjc.xRmDrgbaZFtDmQWvPurKCgZAtrvY, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public wzRpLYcGuxdTqiMozgNAXjFSodRlA(GtkUkygTUOvyDIbobZpOxuepAbdi P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		ftCRSfjPgBzytuxHNehnNOovHWzG = P_1;
		oHqTPmZfGhTTeUyBrfgfrIjEYrFE = P_2;
	}

	public int fSWQzKWtVdRfWgWapTlYunAiGvJj(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.KePwABmtfTLDbHPdxECFmoPfmtqX(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.YqPgfquagCvtuXgqdzmPqbfJNTyO();
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
		return fSWQzKWtVdRfWgWapTlYunAiGvJj(item) >= 0;
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
			array[i + arrayIndex] = this.KePwABmtfTLDbHPdxECFmoPfmtqX(i);
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
		return new QZUWDxTMOEvBOmCpzgfvDCZNHLUv(this);
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

	public void UxvzFMLEIuiJzdWyjblnkXHWfRbqA(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void lwUdkUwudgIgYHvzVjOicicPSfeib(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
