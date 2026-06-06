using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class PnuWjkoeetEMonxoxcsYvtpFirSM<_0001> : DsDCyYOWCLtMDdgeyjpScoLvBfmLA, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::rhghmrJlNqgnYqvSPuhOSjOqQNCi<_0001>, global::oxbFvKEGUKdYFLTbNsNEmiTyaRGGA<_0001> where _0001 : MLaBYQnsAWepqgqDKCGHZLGDlIbCA
{
	public struct poxBFNCZUYccIDXfHlFzxNdCKVPKc : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::PnuWjkoeetEMonxoxcsYvtpFirSM<_0001> fCoqybApbMaIlVvITRwqKKOMBWiL;

		private int KgGbGjbkuLYEQBzPDGWjILmnzHyl;

		private _0001 TOccFsUuRtCJJePRjEyrTRrUEVTCA;

		_0001 IEnumerator<_0001>.Current => TOccFsUuRtCJJePRjEyrTRrUEVTCA;

		object IEnumerator.Current
		{
			get
			{
				if (KgGbGjbkuLYEQBzPDGWjILmnzHyl == 0 || KgGbGjbkuLYEQBzPDGWjILmnzHyl == fCoqybApbMaIlVvITRwqKKOMBWiL.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		internal poxBFNCZUYccIDXfHlFzxNdCKVPKc(global::PnuWjkoeetEMonxoxcsYvtpFirSM<_0001> P_0)
		{
			fCoqybApbMaIlVvITRwqKKOMBWiL = P_0;
			KgGbGjbkuLYEQBzPDGWjILmnzHyl = 0;
			TOccFsUuRtCJJePRjEyrTRrUEVTCA = default(_0001);
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
			global::PnuWjkoeetEMonxoxcsYvtpFirSM<_0001> pnuWjkoeetEMonxoxcsYvtpFirSM = fCoqybApbMaIlVvITRwqKKOMBWiL;
			if ((uint)KgGbGjbkuLYEQBzPDGWjILmnzHyl < (uint)pnuWjkoeetEMonxoxcsYvtpFirSM.Count)
			{
				TOccFsUuRtCJJePRjEyrTRrUEVTCA = pnuWjkoeetEMonxoxcsYvtpFirSM.duyVhfalfXOOnmrsrrUNojGmvMpe(KgGbGjbkuLYEQBzPDGWjILmnzHyl);
				KgGbGjbkuLYEQBzPDGWjILmnzHyl++;
				return true;
			}
			return sFahBSTzEPROshwSOmWmbsVoHJiS();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool sFahBSTzEPROshwSOmWmbsVoHJiS()
		{
			KgGbGjbkuLYEQBzPDGWjILmnzHyl = fCoqybApbMaIlVvITRwqKKOMBWiL.Count + 1;
			TOccFsUuRtCJJePRjEyrTRrUEVTCA = default(_0001);
			return false;
		}

		void IEnumerator.Reset()
		{
			KgGbGjbkuLYEQBzPDGWjILmnzHyl = 0;
			TOccFsUuRtCJJePRjEyrTRrUEVTCA = default(_0001);
		}
	}

	private Func<IntPtr, uint> WGbbBPhNqNHxdDtRZLJxFjEaXXiQ;

	private Func<IntPtr, uint, _0001> FsPySxNpfdxQFlPixTIxnlmNlYKt;

	int ICollection<_0001>.Count
	{
		get
		{
			if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				return 0;
			}
			return (int)WGbbBPhNqNHxdDtRZLJxFjEaXXiQ(gZUHPXbdgzGWrVFeGoixjvyyaZGJ.IjFwUCwhTVEzsfqrNMwYeEhZlxaH);
		}
	}

	bool ICollection<_0001>.IsReadOnly => true;

	_0001 global::rhghmrJlNqgnYqvSPuhOSjOqQNCi<_0001>.FgwFSlZmbmBuIgiqwkVfVKVjvcPQ
	{
		get
		{
			if (P_0 < 0 || P_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				return default(_0001);
			}
			return FsPySxNpfdxQFlPixTIxnlmNlYKt(gZUHPXbdgzGWrVFeGoixjvyyaZGJ.IjFwUCwhTVEzsfqrNMwYeEhZlxaH, (uint)P_0);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	public PnuWjkoeetEMonxoxcsYvtpFirSM(ptLEJWqNKYGsBloabxqKfrAoMUgn P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		WGbbBPhNqNHxdDtRZLJxFjEaXXiQ = P_1;
		FsPySxNpfdxQFlPixTIxnlmNlYKt = P_2;
	}

	public int EExHByKHFbbOGZPunxaWaZkbJCSS(_0001 P_0)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 x = this.duyVhfalfXOOnmrsrrUNojGmvMpe(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.ftegaMeUwYaicakwpFDRaQBWDKzE();
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
		return EExHByKHFbbOGZPunxaWaZkbJCSS(item) >= 0;
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
			array[i + arrayIndex] = this.duyVhfalfXOOnmrsrrUNojGmvMpe(i);
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
		return new poxBFNCZUYccIDXfHlFzxNdCKVPKc(this);
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

	public void ndEAcwJQlmYrlEmlrGvnFfYNNuzB(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void KqrzuuwpmabfAUnTTfCeafKAzDbl(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
