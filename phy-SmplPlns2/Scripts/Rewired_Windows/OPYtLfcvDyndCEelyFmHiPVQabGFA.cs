using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class OPYtLfcvDyndCEelyFmHiPVQabGFA<_0001> : EolNNXUldOrjlEUzhlQRbdbcrggj, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::olYBCyHLohgLoJXsOmsJBkmbLKUN<_0001>, global::rtJaWDGgnZpajsGcQhTHnFpnuTOS<_0001> where _0001 : DICzhVxXzJrYSJbKBMUIAYqOWFbI
{
	public struct wKZzyEBcvFXPmidamCRgEULDVXXSA : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::OPYtLfcvDyndCEelyFmHiPVQabGFA<_0001> oEYDBuUuWPudXilNWOkbLukHsXkn;

		private int RjkOGkjXKQjOguYqKIosLYcwdCgF;

		private _0001 KkKiMrApksuPtRRGwqnuOgVDNbNi;

		_0001 IEnumerator<_0001>.Current => KkKiMrApksuPtRRGwqnuOgVDNbNi;

		object IEnumerator.Current
		{
			get
			{
				if (RjkOGkjXKQjOguYqKIosLYcwdCgF == 0 || RjkOGkjXKQjOguYqKIosLYcwdCgF == oEYDBuUuWPudXilNWOkbLukHsXkn.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal wKZzyEBcvFXPmidamCRgEULDVXXSA(global::OPYtLfcvDyndCEelyFmHiPVQabGFA<_0001> P_0)
		{
			oEYDBuUuWPudXilNWOkbLukHsXkn = P_0;
			RjkOGkjXKQjOguYqKIosLYcwdCgF = 0;
			KkKiMrApksuPtRRGwqnuOgVDNbNi = default(_0001);
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
			global::OPYtLfcvDyndCEelyFmHiPVQabGFA<_0001> oPYtLfcvDyndCEelyFmHiPVQabGFA = oEYDBuUuWPudXilNWOkbLukHsXkn;
			if ((uint)RjkOGkjXKQjOguYqKIosLYcwdCgF < (uint)oPYtLfcvDyndCEelyFmHiPVQabGFA.Count)
			{
				KkKiMrApksuPtRRGwqnuOgVDNbNi = oPYtLfcvDyndCEelyFmHiPVQabGFA.wXWssswImAvVvNgcopfSnLClpTtd(RjkOGkjXKQjOguYqKIosLYcwdCgF);
				RjkOGkjXKQjOguYqKIosLYcwdCgF++;
				return true;
			}
			return jDQtyZJHzKfjSCiJLxKvyHrlNTwn();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool jDQtyZJHzKfjSCiJLxKvyHrlNTwn()
		{
			RjkOGkjXKQjOguYqKIosLYcwdCgF = oEYDBuUuWPudXilNWOkbLukHsXkn.Count + 1;
			KkKiMrApksuPtRRGwqnuOgVDNbNi = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			RjkOGkjXKQjOguYqKIosLYcwdCgF = 0;
			KkKiMrApksuPtRRGwqnuOgVDNbNi = default(_0001);
		}
	}

	private Func<IntPtr, uint> BJFkFYpVLQORLaGOWHfiKdiphXiM;

	private Func<IntPtr, uint, _0001> EPldzmZoUcYlfYbtypWoaBIWDSWgA;

	int global::rtJaWDGgnZpajsGcQhTHnFpnuTOS<_0001>.Count
	{
		get
		{
			if (!pbcySBxNwulDQebgFksXiKhpiEmb.MpSAYmASfEwDrIJnSTQGGdFgjiumA)
			{
				return 0;
			}
			return (int)BJFkFYpVLQORLaGOWHfiKdiphXiM(pbcySBxNwulDQebgFksXiKhpiEmb.HfnJHIiwZKhCLCscEMXBlPUMboob);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::olYBCyHLohgLoJXsOmsJBkmbLKUN<_0001>.MDMspkPWWjSayVZnnMLcKDbauyNp
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!pbcySBxNwulDQebgFksXiKhpiEmb.MpSAYmASfEwDrIJnSTQGGdFgjiumA)
			{
				return default(_0001);
			}
			return EPldzmZoUcYlfYbtypWoaBIWDSWgA(pbcySBxNwulDQebgFksXiKhpiEmb.HfnJHIiwZKhCLCscEMXBlPUMboob, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public OPYtLfcvDyndCEelyFmHiPVQabGFA(wXdOkBsjtVnNnIDvwJcZyTyveGyS P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		BJFkFYpVLQORLaGOWHfiKdiphXiM = P_1;
		EPldzmZoUcYlfYbtypWoaBIWDSWgA = P_2;
	}

	public int JcNusvSLsqTxeiQhcJoPnpAmPQAn(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.wXWssswImAvVvNgcopfSnLClpTtd(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.kxWZtZeCLFJBGPBhigTOedpPNXxzA();
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
		return JcNusvSLsqTxeiQhcJoPnpAmPQAn(item) >= 0;
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
			array[i + arrayIndex] = this.wXWssswImAvVvNgcopfSnLClpTtd(i);
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
		return new wKZzyEBcvFXPmidamCRgEULDVXXSA(this);
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

	public void cbubCtXurrpOTbVvwGJsYANWZSam(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void RtVQtycAsvWycxmwMjnnvavRhxPb(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
