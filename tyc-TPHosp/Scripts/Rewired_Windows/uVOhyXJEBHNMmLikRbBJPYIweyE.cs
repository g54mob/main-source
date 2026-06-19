using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class uVOhyXJEBHNMmLikRbBJPYIweyE : yZksxhdUTylzOicveacdfsGcJWH
{
	private readonly Dictionary<Guid, ngzGskRWZJYrKPHiTCFoPljOBNT> xyzEgUyxzkdUpNpbJoglnLgNrkg = new Dictionary<Guid, ngzGskRWZJYrKPHiTCFoPljOBNT>();

	private static readonly Dictionary<Type, List<Type>> DlVgbJIbmvbfUgyvEZmwNugNegdx = new Dictionary<Type, List<Type>>();

	private IntPtr eWvPKYMcyTAYKiAyKcvkVnmEqewL;

	[CompilerGenerated]
	private IntPtr[] PygnWgayRhwESHMDMDKWrpLlqAy;

	public IntPtr[] Guids
	{
		[CompilerGenerated]
		get
		{
			return PygnWgayRhwESHMDMDKWrpLlqAy;
		}
		[CompilerGenerated]
		private set
		{
			PygnWgayRhwESHMDMDKWrpLlqAy = value;
		}
	}

	public void EhDmNHbdNOhARNgJSMpMFgeqbsn(NUrIhTgICtFHYBDdcvQoxuOfGlt P_0)
	{
		P_0.Shadow = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (DlVgbJIbmvbfUgyvEZmwNugNegdx)
		{
			if (!DlVgbJIbmvbfUgyvEZmwNugNegdx.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				DlVgbJIbmvbfUgyvEZmwNugNegdx.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					QKBzCZLoMQwWwNuNulvgXARpxTH qKBzCZLoMQwWwNuNulvgXARpxTH = QKBzCZLoMQwWwNuNulvgXARpxTH.RKDIoTrFWiGBiTdsPoHVwcVsFYl(type2);
					if (qKBzCZLoMQwWwNuNulvgXARpxTH == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					Type[] array2 = interfaces2;
					foreach (Type item in array2)
					{
						value.Remove(item);
					}
				}
			}
		}
		ngzGskRWZJYrKPHiTCFoPljOBNT ngzGskRWZJYrKPHiTCFoPljOBNT2 = null;
		foreach (Type item2 in value)
		{
			QKBzCZLoMQwWwNuNulvgXARpxTH qKBzCZLoMQwWwNuNulvgXARpxTH2 = QKBzCZLoMQwWwNuNulvgXARpxTH.RKDIoTrFWiGBiTdsPoHVwcVsFYl(item2);
			ngzGskRWZJYrKPHiTCFoPljOBNT ngzGskRWZJYrKPHiTCFoPljOBNT3 = (ngzGskRWZJYrKPHiTCFoPljOBNT)Activator.CreateInstance(qKBzCZLoMQwWwNuNulvgXARpxTH2.Type);
			ngzGskRWZJYrKPHiTCFoPljOBNT3.EhDmNHbdNOhARNgJSMpMFgeqbsn(P_0);
			if (ngzGskRWZJYrKPHiTCFoPljOBNT2 == null)
			{
				ngzGskRWZJYrKPHiTCFoPljOBNT2 = ngzGskRWZJYrKPHiTCFoPljOBNT3;
				xyzEgUyxzkdUpNpbJoglnLgNrkg.Add(DHyomQWjauMcPIkowDdfDsBSAhHg.UgtIyyVpSqKTXudfFJnYkHnhzJE, ngzGskRWZJYrKPHiTCFoPljOBNT2);
			}
			xyzEgUyxzkdUpNpbJoglnLgNrkg.Add(QvyMHYIdbHWMtWGQBjyLybggaNAi.wuSqkwcojnsLLKdCXbfAflWUpDa(item2), ngzGskRWZJYrKPHiTCFoPljOBNT3);
			Type[] interfaces3 = item2.GetInterfaces();
			Type[] array3 = interfaces3;
			foreach (Type type3 in array3)
			{
				QKBzCZLoMQwWwNuNulvgXARpxTH qKBzCZLoMQwWwNuNulvgXARpxTH3 = QKBzCZLoMQwWwNuNulvgXARpxTH.RKDIoTrFWiGBiTdsPoHVwcVsFYl(type3);
				if (qKBzCZLoMQwWwNuNulvgXARpxTH3 != null)
				{
					xyzEgUyxzkdUpNpbJoglnLgNrkg.Add(QvyMHYIdbHWMtWGQBjyLybggaNAi.wuSqkwcojnsLLKdCXbfAflWUpDa(type3), ngzGskRWZJYrKPHiTCFoPljOBNT3);
				}
			}
		}
	}

	internal IntPtr SnXWYarLWHAxUNNKUUfbiwNydPi(Type P_0)
	{
		return SnXWYarLWHAxUNNKUUfbiwNydPi(QvyMHYIdbHWMtWGQBjyLybggaNAi.wuSqkwcojnsLLKdCXbfAflWUpDa(P_0));
	}

	internal IntPtr SnXWYarLWHAxUNNKUUfbiwNydPi(Guid P_0)
	{
		return NtGjyQqnNakEjDefwGjxitGKgsA(P_0)?.NativePointer ?? IntPtr.Zero;
	}

	internal ngzGskRWZJYrKPHiTCFoPljOBNT NtGjyQqnNakEjDefwGjxitGKgsA(Guid P_0)
	{
		xyzEgUyxzkdUpNpbJoglnLgNrkg.TryGetValue(P_0, out var value);
		return value;
	}

	protected override void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (ngzGskRWZJYrKPHiTCFoPljOBNT value in xyzEgUyxzkdUpNpbJoglnLgNrkg.Values)
		{
			value.Dispose();
		}
		xyzEgUyxzkdUpNpbJoglnLgNrkg.Clear();
		if (eWvPKYMcyTAYKiAyKcvkVnmEqewL != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(eWvPKYMcyTAYKiAyKcvkVnmEqewL);
			eWvPKYMcyTAYKiAyKcvkVnmEqewL = IntPtr.Zero;
		}
	}
}
