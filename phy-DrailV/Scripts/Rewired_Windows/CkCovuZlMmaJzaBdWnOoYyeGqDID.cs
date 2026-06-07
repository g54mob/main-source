using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class CkCovuZlMmaJzaBdWnOoYyeGqDID : SzizGYtbqDGyBVWXpOQsugoYHRlc
{
	private readonly Dictionary<Guid, NgvblDfZtqBnBNgXUxbxbKHmyZNDA> FlsVfyAHPoCuwqUOAEmklOrZzsT = new Dictionary<Guid, NgvblDfZtqBnBNgXUxbxbKHmyZNDA>();

	private static readonly Dictionary<Type, List<Type>> pwBJywrDASCKRHwIGrIrbiUQocdu = new Dictionary<Type, List<Type>>();

	private IntPtr QJnzBhYKGwUbXzFDJHHxImSkOsaeA;

	[CompilerGenerated]
	private IntPtr[] fGscwZsfOSDJTcYhXvcPsbVHewqP;

	public IntPtr[] BhZCMTzUrVQoBlDqBgQfkqXtOYBjA
	{
		[CompilerGenerated]
		get
		{
			return fGscwZsfOSDJTcYhXvcPsbVHewqP;
		}
		[CompilerGenerated]
		private set
		{
			fGscwZsfOSDJTcYhXvcPsbVHewqP = array;
		}
	}

	public void sXJldihOTtQuAobmFasPIcWImTtk(zLxGyabwgKWeZOaYjSslgieLtxhFA P_0)
	{
		P_0.XtnJxhAIDnOKHmxIjoDOyaaUfSYL = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (pwBJywrDASCKRHwIGrIrbiUQocdu)
		{
			if (!pwBJywrDASCKRHwIGrIrbiUQocdu.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				pwBJywrDASCKRHwIGrIrbiUQocdu.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (gvVQFmJturpxtceohXTlYrdXbFRv.fVLHNuxQpNlIbohWMFEGfxYENFfO(type2) == null)
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
		NgvblDfZtqBnBNgXUxbxbKHmyZNDA ngvblDfZtqBnBNgXUxbxbKHmyZNDA = null;
		foreach (Type item2 in value)
		{
			NgvblDfZtqBnBNgXUxbxbKHmyZNDA ngvblDfZtqBnBNgXUxbxbKHmyZNDA2 = (NgvblDfZtqBnBNgXUxbxbKHmyZNDA)Activator.CreateInstance(gvVQFmJturpxtceohXTlYrdXbFRv.fVLHNuxQpNlIbohWMFEGfxYENFfO(item2).dTqvRoWTYLcyxOCegaoAeiVZAPTAb);
			ngvblDfZtqBnBNgXUxbxbKHmyZNDA2.sXJldihOTtQuAobmFasPIcWImTtk(P_0);
			if (ngvblDfZtqBnBNgXUxbxbKHmyZNDA == null)
			{
				ngvblDfZtqBnBNgXUxbxbKHmyZNDA = ngvblDfZtqBnBNgXUxbxbKHmyZNDA2;
				FlsVfyAHPoCuwqUOAEmklOrZzsT.Add(nxuTthEcOXrDAnMTlDTsetjyhxRMA.gTxBfRHNXNpASJeIGgdPvNzDxoIm, ngvblDfZtqBnBNgXUxbxbKHmyZNDA);
			}
			FlsVfyAHPoCuwqUOAEmklOrZzsT.Add(egeTdzIGHudlgfKlEvWOdRMMLrIl.MMUchFkNOMFZSbRMSdFqHiBiqhDxA(item2), ngvblDfZtqBnBNgXUxbxbKHmyZNDA2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (gvVQFmJturpxtceohXTlYrdXbFRv.fVLHNuxQpNlIbohWMFEGfxYENFfO(type3) != null)
				{
					FlsVfyAHPoCuwqUOAEmklOrZzsT.Add(egeTdzIGHudlgfKlEvWOdRMMLrIl.MMUchFkNOMFZSbRMSdFqHiBiqhDxA(type3), ngvblDfZtqBnBNgXUxbxbKHmyZNDA2);
				}
			}
		}
	}

	internal IntPtr guJPZPzmvydITgrIPqsqrdiQdTke(Type P_0)
	{
		return guJPZPzmvydITgrIPqsqrdiQdTke(egeTdzIGHudlgfKlEvWOdRMMLrIl.MMUchFkNOMFZSbRMSdFqHiBiqhDxA(P_0));
	}

	internal IntPtr guJPZPzmvydITgrIPqsqrdiQdTke(Guid P_0)
	{
		return vhCoRxuFrPTOayfCtPzmxQqkgvUj(P_0)?.GMaPHoiZAJyngdXeSoVFwLOeWHKm ?? IntPtr.Zero;
	}

	internal NgvblDfZtqBnBNgXUxbxbKHmyZNDA vhCoRxuFrPTOayfCtPzmxQqkgvUj(Guid P_0)
	{
		FlsVfyAHPoCuwqUOAEmklOrZzsT.TryGetValue(P_0, out var value);
		return value;
	}

	protected override void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (NgvblDfZtqBnBNgXUxbxbKHmyZNDA value in FlsVfyAHPoCuwqUOAEmklOrZzsT.Values)
		{
			value.Dispose();
		}
		FlsVfyAHPoCuwqUOAEmklOrZzsT.Clear();
		if (QJnzBhYKGwUbXzFDJHHxImSkOsaeA != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(QJnzBhYKGwUbXzFDJHHxImSkOsaeA);
			QJnzBhYKGwUbXzFDJHHxImSkOsaeA = IntPtr.Zero;
		}
	}
}
