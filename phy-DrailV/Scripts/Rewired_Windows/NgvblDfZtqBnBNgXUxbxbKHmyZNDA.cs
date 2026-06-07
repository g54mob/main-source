using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class NgvblDfZtqBnBNgXUxbxbKHmyZNDA : smdlHgFEnVUfuvIJNRWGkYWGIudo
{
	[CompilerGenerated]
	private zLxGyabwgKWeZOaYjSslgieLtxhFA lxHHCaVZhydnwSDJAlefGmAHhWfBA;

	public zLxGyabwgKWeZOaYjSslgieLtxhFA zqRNvdyJkTTCWaenLefaGExqzkhsA
	{
		[CompilerGenerated]
		get
		{
			return lxHHCaVZhydnwSDJAlefGmAHhWfBA;
		}
		[CompilerGenerated]
		private set
		{
			lxHHCaVZhydnwSDJAlefGmAHhWfBA = zLxGyabwgKWeZOaYjSslgieLtxhFA2;
		}
	}

	protected abstract qeIrFXesmQYupZfgKItubwFenviX hOMbvjhllkPjOGDmTbSxbSXNlQNJ { get; }

	public unsafe virtual void sXJldihOTtQuAobmFasPIcWImTtk(zLxGyabwgKWeZOaYjSslgieLtxhFA P_0)
	{
		zqRNvdyJkTTCWaenLefaGExqzkhsA = P_0;
		base.GMaPHoiZAJyngdXeSoVFwLOeWHKm = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.GMaPHoiZAJyngdXeSoVFwLOeWHKm, hOMbvjhllkPjOGDmTbSxbSXNlQNJ.eRuooOpUXUMNyxAVfhJQXVsDGDql);
		((IntPtr*)(void*)base.GMaPHoiZAJyngdXeSoVFwLOeWHKm)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (base.GMaPHoiZAJyngdXeSoVFwLOeWHKm != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.GMaPHoiZAJyngdXeSoVFwLOeWHKm)[1]).Free();
			Marshal.FreeHGlobal(base.GMaPHoiZAJyngdXeSoVFwLOeWHKm);
			base.GMaPHoiZAJyngdXeSoVFwLOeWHKm = IntPtr.Zero;
		}
		zqRNvdyJkTTCWaenLefaGExqzkhsA = null;
		base.vCBFvIdHsbAnKBZkroQOsRrLIAyV(P_0);
	}

	internal unsafe static _0001 YaddHfyqctrOUHuBmaxdreALoIzU<_0001>(IntPtr P_0) where _0001 : NgvblDfZtqBnBNgXUxbxbKHmyZNDA
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
