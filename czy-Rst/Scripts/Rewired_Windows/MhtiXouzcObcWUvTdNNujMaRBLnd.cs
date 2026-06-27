using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MhtiXouzcObcWUvTdNNujMaRBLnd : WNBjgzUjlnPGavciWqTGDYCLcoqE
{
	private readonly Dictionary<Guid, TnUwvwyctKuogGDzbURVnwjdMkoR> TjrAcoeubLfeACOoNSLWCnxKKhPab = new Dictionary<Guid, TnUwvwyctKuogGDzbURVnwjdMkoR>();

	private static readonly Dictionary<Type, List<Type>> BiBKjbJqzYOAyzOwVvSkYDkNlpIm = new Dictionary<Type, List<Type>>();

	private IntPtr AMfPfeSuzhnLXLVFuAKrxrNESzqe;

	[CompilerGenerated]
	private IntPtr[] VZDEdFPevYeXIusYGDRndNSCOudd;

	public IntPtr[] ZXBjLtvNhUBhxcnGxctAyAykUmSh
	{
		[CompilerGenerated]
		get
		{
			return VZDEdFPevYeXIusYGDRndNSCOudd;
		}
		[CompilerGenerated]
		private set
		{
			VZDEdFPevYeXIusYGDRndNSCOudd = vZDEdFPevYeXIusYGDRndNSCOudd;
		}
	}

	public void oEkfVICUviBYPOlYLwUqnQsrRqDuA(zpYzeFToaqafecYyGAUFmHUClIYGb P_0)
	{
		P_0.ykQvfTlAKLEXiYicnQbzApgdhPgW = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (BiBKjbJqzYOAyzOwVvSkYDkNlpIm)
		{
			if (!BiBKjbJqzYOAyzOwVvSkYDkNlpIm.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				BiBKjbJqzYOAyzOwVvSkYDkNlpIm.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (qwghLPuxwFelOCYIMzYBpuHSwLiI.fCzIrLaCQcTngrxBLErIIfRNdPfd(type2) == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					foreach (Type item in interfaces2)
					{
						value.Remove(item);
					}
				}
			}
		}
		TnUwvwyctKuogGDzbURVnwjdMkoR tnUwvwyctKuogGDzbURVnwjdMkoR = null;
		foreach (Type item2 in value)
		{
			TnUwvwyctKuogGDzbURVnwjdMkoR tnUwvwyctKuogGDzbURVnwjdMkoR2 = (TnUwvwyctKuogGDzbURVnwjdMkoR)Activator.CreateInstance(qwghLPuxwFelOCYIMzYBpuHSwLiI.fCzIrLaCQcTngrxBLErIIfRNdPfd(item2).JytUzyJugWYqPdDUgnUUaYufabRE);
			tnUwvwyctKuogGDzbURVnwjdMkoR2.jQLFcMcSXlPzHTrQQyvERdGsupuU(P_0);
			if (tnUwvwyctKuogGDzbURVnwjdMkoR == null)
			{
				tnUwvwyctKuogGDzbURVnwjdMkoR = tnUwvwyctKuogGDzbURVnwjdMkoR2;
				TjrAcoeubLfeACOoNSLWCnxKKhPab.Add(fDZDlQHnIrFWxSZtYWzQYxPniKcO.SwZCQkvDzrFvRzVMbZfhEFMAFjciA, tnUwvwyctKuogGDzbURVnwjdMkoR);
			}
			TjrAcoeubLfeACOoNSLWCnxKKhPab.Add(klLdHAhsLOLqXXQXtowmGbeHymvN.dtejMjPPjIkytsMVCPbMSwWitAop(item2), tnUwvwyctKuogGDzbURVnwjdMkoR2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (qwghLPuxwFelOCYIMzYBpuHSwLiI.fCzIrLaCQcTngrxBLErIIfRNdPfd(type3) != null)
				{
					TjrAcoeubLfeACOoNSLWCnxKKhPab.Add(klLdHAhsLOLqXXQXtowmGbeHymvN.dtejMjPPjIkytsMVCPbMSwWitAop(type3), tnUwvwyctKuogGDzbURVnwjdMkoR2);
				}
			}
		}
	}

	internal IntPtr aGFsNHEWVNAKEXWFiemWyUlExDE(Type P_0)
	{
		return czifkeASSCiRnbMASSmijHvJbwGe(klLdHAhsLOLqXXQXtowmGbeHymvN.dtejMjPPjIkytsMVCPbMSwWitAop(P_0));
	}

	internal IntPtr czifkeASSCiRnbMASSmijHvJbwGe(Guid P_0)
	{
		return LvhcWxjSzlbdmhKBafgeYSgOFsW(P_0)?.wkJiNziQVZeKUDzpAUZiJMbAGjgE ?? IntPtr.Zero;
	}

	internal TnUwvwyctKuogGDzbURVnwjdMkoR LvhcWxjSzlbdmhKBafgeYSgOFsW(Guid P_0)
	{
		TjrAcoeubLfeACOoNSLWCnxKKhPab.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void WdYpNgUNESslgbHkTTVDJVNAEmSH(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (TnUwvwyctKuogGDzbURVnwjdMkoR value in TjrAcoeubLfeACOoNSLWCnxKKhPab.Values)
		{
			value.Dispose();
		}
		TjrAcoeubLfeACOoNSLWCnxKKhPab.Clear();
		if (AMfPfeSuzhnLXLVFuAKrxrNESzqe != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(AMfPfeSuzhnLXLVFuAKrxrNESzqe);
			AMfPfeSuzhnLXLVFuAKrxrNESzqe = IntPtr.Zero;
		}
	}
}
