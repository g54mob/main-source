using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class UvefrXFsiiTVfStaasvXluBtyHj : global::slgsKTDRGmBruGFKLTFOPLqJxXF<xTwGSLqUVZlevLitXxYKVMuDiUm, XEoBfzVrALPXyXfPJRwYkltOwzz>
{
	private static readonly List<nZzcNYUOUyZqpeVNDWwJlaIJYit> KvVAjYiMRoaKRezPJHWKBqQBVsc;

	[CompilerGenerated]
	private List<nZzcNYUOUyZqpeVNDWwJlaIJYit> egbqJSBAvuBUkCBzdaabMzASQjq;

	public List<nZzcNYUOUyZqpeVNDWwJlaIJYit> AllKeys => KvVAjYiMRoaKRezPJHWKBqQBVsc;

	public List<nZzcNYUOUyZqpeVNDWwJlaIJYit> PressedKeys
	{
		[CompilerGenerated]
		get
		{
			return egbqJSBAvuBUkCBzdaabMzASQjq;
		}
		[CompilerGenerated]
		private set
		{
			egbqJSBAvuBUkCBzdaabMzASQjq = value;
		}
	}

	static UvefrXFsiiTVfStaasvXluBtyHj()
	{
		KvVAjYiMRoaKRezPJHWKBqQBVsc = new List<nZzcNYUOUyZqpeVNDWwJlaIJYit>(256);
		foreach (object value in Enum.GetValues(typeof(nZzcNYUOUyZqpeVNDWwJlaIJYit)))
		{
			KvVAjYiMRoaKRezPJHWKBqQBVsc.Add((nZzcNYUOUyZqpeVNDWwJlaIJYit)value);
		}
	}

	public UvefrXFsiiTVfStaasvXluBtyHj()
	{
		PressedKeys = new List<nZzcNYUOUyZqpeVNDWwJlaIJYit>(16);
	}

	public bool IBDiQvZQCOakJmCLiCcZbHuspZWV(nZzcNYUOUyZqpeVNDWwJlaIJYit P_0)
	{
		return PressedKeys.Contains(P_0);
	}

	public void CWncwVbJhTWISMonvIVEimpDcKXc(XEoBfzVrALPXyXfPJRwYkltOwzz P_0)
	{
		if (P_0.Key != nZzcNYUOUyZqpeVNDWwJlaIJYit.yoCwpETGhcNpYyDgYCzBcMvXnwF)
		{
			bool flag = IBDiQvZQCOakJmCLiCcZbHuspZWV(P_0.Key);
			if (P_0.IsPressed && !flag)
			{
				PressedKeys.Add(P_0.Key);
			}
			else if (P_0.IsReleased && flag)
			{
				PressedKeys.Remove(P_0.Key);
			}
		}
	}

	void global::slgsKTDRGmBruGFKLTFOPLqJxXF<xTwGSLqUVZlevLitXxYKVMuDiUm, XEoBfzVrALPXyXfPJRwYkltOwzz>.CWncwVbJhTWISMonvIVEimpDcKXc(XEoBfzVrALPXyXfPJRwYkltOwzz P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CWncwVbJhTWISMonvIVEimpDcKXc
		this.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
	}

	public unsafe void jgUKJdlhVlbmjmcGcqukHIxicKDF(IntPtr P_0)
	{
		PressedKeys.Clear();
		xTwGSLqUVZlevLitXxYKVMuDiUm* ptr = (xTwGSLqUVZlevLitXxYKVMuDiUm*)(void*)P_0;
		XEoBfzVrALPXyXfPJRwYkltOwzz xEoBfzVrALPXyXfPJRwYkltOwzz = default(XEoBfzVrALPXyXfPJRwYkltOwzz);
		byte* ptr2 = &ptr->SlwDlYTgfhHreYNYsTHRWmdxsce.MzStxVGCYZEAgKgwPnOzQeApbyTd;
		for (int i = 0; i < 256; i++)
		{
			xEoBfzVrALPXyXfPJRwYkltOwzz.bAPYEfeboQPbkVOmgynwqcsDhlg = i;
			xEoBfzVrALPXyXfPJRwYkltOwzz.JeBDgqwIOBAWAOXsVJTHPwQwGVe = ptr2[i];
			if (xEoBfzVrALPXyXfPJRwYkltOwzz.IsPressed)
			{
				PressedKeys.Add(xEoBfzVrALPXyXfPJRwYkltOwzz.Key);
			}
		}
	}

	void global::slgsKTDRGmBruGFKLTFOPLqJxXF<xTwGSLqUVZlevLitXxYKVMuDiUm, XEoBfzVrALPXyXfPJRwYkltOwzz>.jgUKJdlhVlbmjmcGcqukHIxicKDF(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in jgUKJdlhVlbmjmcGcqukHIxicKDF
		this.jgUKJdlhVlbmjmcGcqukHIxicKDF(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { QvyMHYIdbHWMtWGQBjyLybggaNAi.TrOgnwDXldYAiczZEbzuYfkxxbo(",", PressedKeys) });
	}
}
