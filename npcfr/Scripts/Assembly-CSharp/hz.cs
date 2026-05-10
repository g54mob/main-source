using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class hz<a, b> : IEnumerable<KeyValuePair<a, b>>, IEnumerable where a : struct, IEquatable<a> where b : struct
{
	private readonly hx<a, b> qbt;

	public int wxl
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 0;
		}
	}

	public int wxm
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 0;
		}
	}

	public b this[a key]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return default(b);
		}
	}

	public hz(hx<a, b> a)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool emk(a a)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool eml(a a, out b b)
	{
		b = default(b);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IEnumerator<KeyValuePair<a, b>> GetEnumerator()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private IEnumerator emm()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in emm
		return this.emm();
	}
}
