using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class LHevvpZKezmLvCyYQeaczQDfBFuV : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr kqheOdIRDhMloRCIWUtJuPJLlEDBb(int nCode, IntPtr wParam, IntPtr lParam);

	private struct dKUpvBuhMhRolXBgpwVbDerSPndW
	{
		public IntPtr iPGjzfRAexFJJiJEQRRCGsljpAzMA;

		public IntPtr WlHiqFXmDysmXcicsUcRPcSNefqN;

		public uint spSGoRjomwvmqZUikaCgfNhLLnnfA;

		public IntPtr CdfTaLGGqzKtnxxNfhFHHvZvOPGj;
	}

	private const int ljTDAjSHvCQNxVEttDnAIqQkkMQyA = 4;

	private static LHevvpZKezmLvCyYQeaczQDfBFuV DsYBDFSvBVgnTIxIavHPvKkAqTCU;

	private IntPtr NCNPNzLKIOBUATPbTPOLZhKQhJdE = IntPtr.Zero;

	private kqheOdIRDhMloRCIWUtJuPJLlEDBb utWECQuDfRIqaDwFGcPnEakNwDZf;

	private Action<VlOqbYYlMVgoDFABcShgseyUBQQC, UXQgNkKlFfsqcUANDOwHwGUYTczaA, uint, IntPtr> RjdyteVKlxoLbqHEWAwbhqsDdkdg;

	private byte[] VLovtmoXtDUjJLUVYbkNWisqyCHP;

	private readonly bool NbYubdCKmJVAqpvAZNhFZzHrHBdS;

	private dKUpvBuhMhRolXBgpwVbDerSPndW CbNKdVtJpeATRcMjjLoCUuudjScAb;

	private bool FubYzpajNQyOcXXYKfwNxLgArFLi;

	public LHevvpZKezmLvCyYQeaczQDfBFuV()
	{
		if (DsYBDFSvBVgnTIxIavHPvKkAqTCU != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		DsYBDFSvBVgnTIxIavHPvKkAqTCU = this;
		NbYubdCKmJVAqpvAZNhFZzHrHBdS = IntPtr.Size == 8;
		VLovtmoXtDUjJLUVYbkNWisqyCHP = new byte[IntPtr.Size * 3 + 4];
	}

	public void CNJqFCBEtDXzTzteiWufGpoEJZhQ(Action<VlOqbYYlMVgoDFABcShgseyUBQQC, UXQgNkKlFfsqcUANDOwHwGUYTczaA, uint, IntPtr> P_0, bool P_1)
	{
		RjdyteVKlxoLbqHEWAwbhqsDdkdg = P_0;
		utWECQuDfRIqaDwFGcPnEakNwDZf = rXLMPAhOGORwVwWNGJeTffaFjEEN;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		NCNPNzLKIOBUATPbTPOLZhKQhJdE = vUQzCcPFfQpMNvsXtULlMvJVOdnd(4, utWECQuDfRIqaDwFGcPnEakNwDZf, IntPtr.Zero, num);
		if (NCNPNzLKIOBUATPbTPOLZhKQhJdE == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void wXGpJkozFYPcIbbaavIllbEiMcnO()
	{
		if (!(NCNPNzLKIOBUATPbTPOLZhKQhJdE == IntPtr.Zero))
		{
			if (!iWzuREWazsnWYWRNOAIaBGfTCfKw(NCNPNzLKIOBUATPbTPOLZhKQhJdE))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				NCNPNzLKIOBUATPbTPOLZhKQhJdE = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(kqheOdIRDhMloRCIWUtJuPJLlEDBb))]
	private static IntPtr rXLMPAhOGORwVwWNGJeTffaFjEEN(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, 0, DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP.Length);
		int num = 0;
		DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.iPGjzfRAexFJJiJEQRRCGsljpAzMA = VlOqbYYlMVgoDFABcShgseyUBQQC.bketUuzRqFUGrUwyPHTMBUWsXHHl(VlOqbYYlMVgoDFABcShgseyUBQQC.uawQiqxErXaNEUEwUkuCCGHMgrsC(DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, num));
		num += VlOqbYYlMVgoDFABcShgseyUBQQC.FFblJLGQUflXbDfeuFvdblQiUKtN;
		DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.WlHiqFXmDysmXcicsUcRPcSNefqN = UXQgNkKlFfsqcUANDOwHwGUYTczaA.knMDqWEJKzaOjaUpFKlKHWjCCoUpA(UXQgNkKlFfsqcUANDOwHwGUYTczaA.RLZwCcahxXJslXtGHATRenBOBeCU(DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, num));
		num += UXQgNkKlFfsqcUANDOwHwGUYTczaA.sstadPYhCcjNxwsDhfZnzBBaiuAe;
		DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.spSGoRjomwvmqZUikaCgfNhLLnnfA = BitConverter.ToUInt32(DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, num);
		num += 4;
		if (DsYBDFSvBVgnTIxIavHPvKkAqTCU.NbYubdCKmJVAqpvAZNhFZzHrHBdS)
		{
			DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.CdfTaLGGqzKtnxxNfhFHHvZvOPGj = new IntPtr(BitConverter.ToInt32(DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, num + 4));
		}
		else
		{
			DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.CdfTaLGGqzKtnxxNfhFHHvZvOPGj = new IntPtr(BitConverter.ToInt32(DsYBDFSvBVgnTIxIavHPvKkAqTCU.VLovtmoXtDUjJLUVYbkNWisqyCHP, num));
		}
		if (P_0 >= 0)
		{
			DsYBDFSvBVgnTIxIavHPvKkAqTCU.RjdyteVKlxoLbqHEWAwbhqsDdkdg(VlOqbYYlMVgoDFABcShgseyUBQQC.jLPbiFivmKbvXOxvwPAqEFEvGgWZ(DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.iPGjzfRAexFJJiJEQRRCGsljpAzMA), UXQgNkKlFfsqcUANDOwHwGUYTczaA.NDfIYuJQiOOcwVHgPHfSbtkgcyLCA(DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.WlHiqFXmDysmXcicsUcRPcSNefqN), DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.spSGoRjomwvmqZUikaCgfNhLLnnfA, DsYBDFSvBVgnTIxIavHPvKkAqTCU.CbNKdVtJpeATRcMjjLoCUuudjScAb.CdfTaLGGqzKtnxxNfhFHHvZvOPGj);
		}
		return PGcADDhAQRiRneEtMXpJgydDhBnvb(DsYBDFSvBVgnTIxIavHPvKkAqTCU.NCNPNzLKIOBUATPbTPOLZhKQhJdE, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		TrMniAnGGHBBEjjcGvMFLiOVnvRkA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void gYJcnMIqBSsLRWwwNjohwiOhGTVgA()
	{
		try
		{
			TrMniAnGGHBBEjjcGvMFLiOVnvRkA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void TrMniAnGGHBBEjjcGvMFLiOVnvRkA(bool P_0)
	{
		if (!FubYzpajNQyOcXXYKfwNxLgArFLi)
		{
			wXGpJkozFYPcIbbaavIllbEiMcnO();
			if (DsYBDFSvBVgnTIxIavHPvKkAqTCU == this)
			{
				DsYBDFSvBVgnTIxIavHPvKkAqTCU = null;
			}
			FubYzpajNQyOcXXYKfwNxLgArFLi = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr vUQzCcPFfQpMNvsXtULlMvJVOdnd(int P_0, kqheOdIRDhMloRCIWUtJuPJLlEDBb P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool iWzuREWazsnWYWRNOAIaBGfTCfKw(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr PGcADDhAQRiRneEtMXpJgydDhBnvb(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
