using System;
using Unity.Collections;

public class gx<a, b> : IDisposable where a : struct, IEquatable<a> where b : struct
{
	private NativeHashMap<a, b> qam;

	public gx(NativeHashMap<a, b> a)
	{
	}

	public void Dispose()
	{
	}
}
