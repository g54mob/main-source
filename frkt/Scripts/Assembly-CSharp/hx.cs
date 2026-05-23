using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

public class hx<a, b> : hw<a, b>, IDisposable, IEnumerable<KeyValuePair<a, b>>, IEnumerable where a : struct, IEquatable<a> where b : struct
{
	private readonly hw<a, b> qbs;

	public int wxg
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return 0;
		}
	}

	public int wxh
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
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
		}
	}

	public hx(int a, Allocator b)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool elr(a a, b b)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool els(a a)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool elt(a a, out b b)
	{
		b = default(b);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool elu(a a)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void elv()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public IEnumerator<KeyValuePair<a, b>> GetEnumerator()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private IEnumerator elw()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in elw
		return this.elw();
	}
}
