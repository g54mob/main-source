using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ii<a> : IEnumerable<a>, IEnumerable where a : struct, IEquatable<a>
{
	private readonly ig<a> qcm;

	public int wyf
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 0;
		}
	}

	public int wyg
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 0;
		}
	}

	public ii(ig<a> a)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool epc(a a)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IEnumerator<a> GetEnumerator()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private IEnumerator epd()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in epd
		return this.epd();
	}
}
