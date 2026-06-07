using System;
using System.Collections.Generic;

internal struct vuzXMYecOGiuMhWRGOQncNYZfgYT<_0001> : IDisposable
{
	private CnRkjRzvVUfVkELzTkafBxihEHxy LxmTisYamjFujdfUhMxCdIOSDHkA;

	private _0001 GXZARikZxtGwRPjRRAMKOqFWQktQ;

	private IEnumerator<global::VCqUZCyaYTsazOpMFNjppETIZevr<_0001>> IrFSbLryuUsktZxJqRjOTcIMAWwl;

	private bool pflBBfMrHZVyaoVnhBaOpDGfZbFW;

	public CnRkjRzvVUfVkELzTkafBxihEHxy YXhWzPkrTguKMmVRTJXBkQMJlZng => LxmTisYamjFujdfUhMxCdIOSDHkA;

	public _0001 BpQgPoFlIiGOiFzVJRUbxaMJjBMQ => GXZARikZxtGwRPjRRAMKOqFWQktQ;

	public vuzXMYecOGiuMhWRGOQncNYZfgYT(IEnumerable<global::VCqUZCyaYTsazOpMFNjppETIZevr<_0001>> P_0)
	{
		LxmTisYamjFujdfUhMxCdIOSDHkA = CnRkjRzvVUfVkELzTkafBxihEHxy.Idle;
		GXZARikZxtGwRPjRRAMKOqFWQktQ = default(_0001);
		IrFSbLryuUsktZxJqRjOTcIMAWwl = P_0.GetEnumerator();
		pflBBfMrHZVyaoVnhBaOpDGfZbFW = false;
	}

	public bool WlcCwjHiliVyialxSXDRkbflOaHKA()
	{
		if (!IrFSbLryuUsktZxJqRjOTcIMAWwl.MoveNext())
		{
			return true;
		}
		global::VCqUZCyaYTsazOpMFNjppETIZevr<_0001> current = IrFSbLryuUsktZxJqRjOTcIMAWwl.Current;
		LxmTisYamjFujdfUhMxCdIOSDHkA = current.fMVZCIxljAnZfoohUkZsvTLbcLtB;
		GXZARikZxtGwRPjRRAMKOqFWQktQ = current.GwqnKCKdXYmhakkJhtrNnZNjHFPE;
		return false;
	}

	public void Dispose()
	{
		sLZEbQoIXiaUhzmpncEIeLEsKarl(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void sLZEbQoIXiaUhzmpncEIeLEsKarl(bool P_0)
	{
		if (!pflBBfMrHZVyaoVnhBaOpDGfZbFW)
		{
			pflBBfMrHZVyaoVnhBaOpDGfZbFW = true;
		}
	}
}
