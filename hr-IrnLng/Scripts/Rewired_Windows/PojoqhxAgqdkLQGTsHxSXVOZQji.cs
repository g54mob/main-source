using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class PojoqhxAgqdkLQGTsHxSXVOZQji
{
	private readonly List<Delegate> LSXzQgWEFvAfNJJVIhOXrKQRruia;

	private readonly IntPtr eVyvpVKtHeHVGmALtabItrprIzr;

	public IntPtr Pointer => eVyvpVKtHeHVGmALtabItrprIzr;

	public PojoqhxAgqdkLQGTsHxSXVOZQji(int numberOfCallbackMethods)
	{
		eVyvpVKtHeHVGmALtabItrprIzr = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
		LSXzQgWEFvAfNJJVIhOXrKQRruia = new List<Delegate>();
	}

	public unsafe void nvNNNfyOPYahlcBQwANdYJXICvzR(Delegate P_0)
	{
		int count = LSXzQgWEFvAfNJJVIhOXrKQRruia.Count;
		LSXzQgWEFvAfNJJVIhOXrKQRruia.Add(P_0);
		((IntPtr*)(void*)eVyvpVKtHeHVGmALtabItrprIzr)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
