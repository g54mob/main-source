using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

internal static class qUbotaSLZASADLtRbuWjzvVhFURA
{
	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern void* XfTBMlBJxIWOfqZoKbkjBVzMyclvA(void* P_0, void* P_1, UIntPtr P_2);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "memset")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern void* turNfOwWJBeOgNYipCaNPMOgnmvS(void* P_0, int P_1, UIntPtr P_2);

	private unsafe static void* LcaEYeAdvayPwpGOFBoudhPaVNWK(void* P_0, void* P_1, int P_2)
	{
		return XfTBMlBJxIWOfqZoKbkjBVzMyclvA(P_0, P_1, new UIntPtr((uint)P_2));
	}

	private unsafe static void* bBhBbEgavWWgnpHBmJzXHnoNLbokA(void* P_0, byte P_1, int P_2)
	{
		return turNfOwWJBeOgNYipCaNPMOgnmvS(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public unsafe static void NsKFffFPSKzDQTlXyLHVFzjeGUrUA(IntPtr P_0, IntPtr P_1, int P_2)
	{
		LcaEYeAdvayPwpGOFBoudhPaVNWK((void*)P_0, (void*)P_1, P_2);
	}

	public unsafe static bool oZDGHyQmPusfYhIeufelujIhielg(IntPtr P_0, IntPtr P_1, int P_2)
	{
		byte* ptr = (byte*)(void*)P_0;
		byte* ptr2 = (byte*)(void*)P_1;
		for (int num = P_2 >> 3; num > 0; num--)
		{
			if (*(long*)ptr != *(long*)ptr2)
			{
				return false;
			}
			ptr += 8;
			ptr2 += 8;
		}
		for (int num = P_2 & 7; num > 0; num--)
		{
			if (*ptr != *ptr2)
			{
				return false;
			}
			ptr++;
			ptr2++;
		}
		return true;
	}

	public unsafe static void aAIBvUlLCvwFSDMtQqNDoKNEgklT(IntPtr P_0, byte P_1, int P_2)
	{
		bBhBbEgavWWgnpHBmJzXHnoNLbokA((void*)P_0, P_1, P_2);
	}

	public static int xffaaffqlCQliyJdHalcXbRJNUcV<_0001>() where _0001 : struct
	{
		return Marshal.SizeOf(typeof(_0001));
	}

	public static int xffaaffqlCQliyJdHalcXbRJNUcV<_0001>(_0001[] P_0) where _0001 : struct
	{
		if (P_0 != null)
		{
			return P_0.Length * Marshal.SizeOf(typeof(_0001));
		}
		return 0;
	}

	public static void qIKtTitANZTazFDzrqgkjmZQkBkK<_0001>(ref _0001 P_0, Action<IntPtr> P_1) where _0001 : struct
	{
		GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
		P_1(gCHandle.AddrOfPinnedObject());
		GC.KeepAlive(gCHandle);
		gCHandle.Free();
	}

	public static void qIKtTitANZTazFDzrqgkjmZQkBkK<_0001>(_0001[] P_0, Action<IntPtr> P_1) where _0001 : struct
	{
		if (P_0 == null)
		{
			P_1(IntPtr.Zero);
			return;
		}
		GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
		P_1(gCHandle.AddrOfPinnedObject());
		GC.KeepAlive(gCHandle);
		gCHandle.Free();
	}

	public static Guid KDoWHLWCCjugqVGQZGzwmhkpsfVv(Type P_0)
	{
		return P_0.GUID;
	}

	public unsafe static string xwsFDWFmUkkzxgHJpAYFooiOAlrmA(IntPtr P_0, int P_1)
	{
		byte* ptr = (byte*)(void*)P_0;
		for (int i = 0; i < P_1; i++)
		{
			if (*(ptr++) == 0)
			{
				return new string((sbyte*)(void*)P_0);
			}
		}
		return new string((sbyte*)(void*)P_0, 0, P_1);
	}

	public unsafe static string PIGCegoLvpccajrFFSnhalCVwFBz(IntPtr P_0, int P_1)
	{
		char* ptr = (char*)(void*)P_0;
		for (int i = 0; i < P_1; i++)
		{
			if (*(ptr++) == '\0')
			{
				return new string((char*)(void*)P_0);
			}
		}
		return new string((char*)(void*)P_0, 0, P_1);
	}

	public static IntPtr ZlVlDQZItomhmjgDVWrcoBVwErxJA(string P_0)
	{
		return Marshal.StringToHGlobalUni(P_0);
	}

	public static string tZoSuFzNBjWbBxKsAtWzHuoGlimg<_0001>(string P_0, _0001[] P_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (P_1 != null)
		{
			for (int i = 0; i < P_1.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(P_0);
				}
				stringBuilder.Append(P_1[i]);
			}
		}
		return stringBuilder.ToString();
	}

	public static string tZoSuFzNBjWbBxKsAtWzHuoGlimg(string P_0, IEnumerable P_1)
	{
		List<string> list = new List<string>();
		foreach (object item in P_1)
		{
			list.Add(item.ToString());
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			string value = list[i];
			if (i > 0)
			{
				stringBuilder.Append(P_0);
			}
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	public static string tZoSuFzNBjWbBxKsAtWzHuoGlimg(string P_0, IEnumerator P_1)
	{
		List<string> list = new List<string>();
		while (P_1.MoveNext())
		{
			list.Add(P_1.Current.ToString());
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			string value = list[i];
			if (i > 0)
			{
				stringBuilder.Append(P_0);
			}
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	public static bool fLbMQTbfkPenELgFfQPqYhDBuCOB(Type P_0)
	{
		return P_0.IsEnum;
	}

	public static bool ZVHdirbuJOeSiYOKrsImRxISXpGz(Type P_0)
	{
		return P_0.IsValueType;
	}
}
