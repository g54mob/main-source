using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class HaKjPHKeVCeghEhfZCVsahBHoakL
{
	[CompilerGenerated]
	private IjkegEPrDSfSQxHJscncTBxwdrY IovCZqdcvVmXaWYgShgWWQiFNEF;

	[CompilerGenerated]
	private int YVRxIQHCHjnieKIpcfrrhJsThzei;

	[CompilerGenerated]
	private jzYvqdeZPTOwnnDgtSlmjPWqvod eaPSDeNcUYdyQbWqwlwobvLIkXd;

	private IjkegEPrDSfSQxHJscncTBxwdrY Device
	{
		[CompilerGenerated]
		get
		{
			return IovCZqdcvVmXaWYgShgWWQiFNEF;
		}
		[CompilerGenerated]
		set
		{
			IovCZqdcvVmXaWYgShgWWQiFNEF = value;
		}
	}

	private int ObjectCode
	{
		[CompilerGenerated]
		get
		{
			return YVRxIQHCHjnieKIpcfrrhJsThzei;
		}
		[CompilerGenerated]
		set
		{
			YVRxIQHCHjnieKIpcfrrhJsThzei = value;
		}
	}

	private jzYvqdeZPTOwnnDgtSlmjPWqvod PropertyType
	{
		[CompilerGenerated]
		get
		{
			return eaPSDeNcUYdyQbWqwlwobvLIkXd;
		}
		[CompilerGenerated]
		set
		{
			eaPSDeNcUYdyQbWqwlwobvLIkXd = value;
		}
	}

	internal HaKjPHKeVCeghEhfZCVsahBHoakL(IjkegEPrDSfSQxHJscncTBxwdrY device, int code, jzYvqdeZPTOwnnDgtSlmjPWqvod propertyType)
	{
		Device = device;
		ObjectCode = code;
		PropertyType = propertyType;
	}

	internal HaKjPHKeVCeghEhfZCVsahBHoakL(IjkegEPrDSfSQxHJscncTBxwdrY device, string name, Type dataFormat)
	{
		Device = device;
		ObjectCode = Marshal.OffsetOf(dataFormat, name).ToInt32();
		PropertyType = jzYvqdeZPTOwnnDgtSlmjPWqvod.sqcAafdpPUdHnnrFnigZhitKTGP;
	}

	protected unsafe object PJkgaWmxtkZOAzEPPjNyFBxjeYNw(IntPtr P_0)
	{
		EbeZbeIfyredtzzZqQToyBTVqSm ebeZbeIfyredtzzZqQToyBTVqSm = default(EbeZbeIfyredtzzZqQToyBTVqSm);
		AZIRjDmlwHNDshjQLQQksWGExag<EbeZbeIfyredtzzZqQToyBTVqSm>(ref ebeZbeIfyredtzzZqQToyBTVqSm.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		IntPtr zero = IntPtr.Zero;
		ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs = new IntPtr(&zero);
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&ebeZbeIfyredtzzZqQToyBTVqSm));
		if (ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs.ToInt64() == -1)
		{
			return null;
		}
		GCHandle gCHandle = GCHandle.FromIntPtr(ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs);
		if (!gCHandle.IsAllocated)
		{
			return null;
		}
		return gCHandle.Target;
	}

	protected unsafe void fvNdavvkKOcZphbhbwYLfxSbeAsx(IntPtr P_0, object P_1)
	{
		EbeZbeIfyredtzzZqQToyBTVqSm ebeZbeIfyredtzzZqQToyBTVqSm = default(EbeZbeIfyredtzzZqQToyBTVqSm);
		AZIRjDmlwHNDshjQLQQksWGExag<EbeZbeIfyredtzzZqQToyBTVqSm>(ref ebeZbeIfyredtzzZqQToyBTVqSm.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		IntPtr zero = IntPtr.Zero;
		ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs = new IntPtr(&zero);
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&ebeZbeIfyredtzzZqQToyBTVqSm));
		if (ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs.ToInt64() != -1)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs);
			if (gCHandle.IsAllocated)
			{
				gCHandle.Free();
			}
		}
		ebeZbeIfyredtzzZqQToyBTVqSm.gkSLMNIyLcKlncULGDGOWrfGLDs = GCHandle.Alloc(P_1, GCHandleType.Pinned).AddrOfPinnedObject();
		Device.zzWgbWavhIFAvnPHQExAcXILdPQ(P_0, new IntPtr(&ebeZbeIfyredtzzZqQToyBTVqSm));
	}

	protected int HDwiXDMdEekSRzjdUDbNzIGFYVF(IntPtr P_0)
	{
		return HDwiXDMdEekSRzjdUDbNzIGFYVF(P_0, ObjectCode);
	}

	protected unsafe int HDwiXDMdEekSRzjdUDbNzIGFYVF(IntPtr P_0, int P_1)
	{
		ifSXRONfgjjLWoJpxMWZvVGAFzu ifSXRONfgjjLWoJpxMWZvVGAFzu2 = default(ifSXRONfgjjLWoJpxMWZvVGAFzu);
		AZIRjDmlwHNDshjQLQQksWGExag<ifSXRONfgjjLWoJpxMWZvVGAFzu>(ref ifSXRONfgjjLWoJpxMWZvVGAFzu2.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		ifSXRONfgjjLWoJpxMWZvVGAFzu2.uKgrmzWDMXdahjyvrfNpOFIMDQxc.kDIMMdxmcixAUfpzeaqMvfDAwEK = P_1;
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&ifSXRONfgjjLWoJpxMWZvVGAFzu2));
		return ifSXRONfgjjLWoJpxMWZvVGAFzu2.gkSLMNIyLcKlncULGDGOWrfGLDs;
	}

	protected unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(IntPtr P_0, int P_1)
	{
		ifSXRONfgjjLWoJpxMWZvVGAFzu ifSXRONfgjjLWoJpxMWZvVGAFzu2 = default(ifSXRONfgjjLWoJpxMWZvVGAFzu);
		AZIRjDmlwHNDshjQLQQksWGExag<ifSXRONfgjjLWoJpxMWZvVGAFzu>(ref ifSXRONfgjjLWoJpxMWZvVGAFzu2.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		ifSXRONfgjjLWoJpxMWZvVGAFzu2.gkSLMNIyLcKlncULGDGOWrfGLDs = P_1;
		Device.zzWgbWavhIFAvnPHQExAcXILdPQ(P_0, new IntPtr(&ifSXRONfgjjLWoJpxMWZvVGAFzu2));
	}

	protected unsafe Guid YaTAODoJMmeHsIGOzkNQGNfNhXAa(IntPtr P_0)
	{
		rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC cMOIOQONGOLWBfXMWTdWIIYjXGC = default(rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC);
		AZIRjDmlwHNDshjQLQQksWGExag<rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC>(ref cMOIOQONGOLWBfXMWTdWIIYjXGC.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&cMOIOQONGOLWBfXMWTdWIIYjXGC));
		return cMOIOQONGOLWBfXMWTdWIIYjXGC.YjuhxqRnXaWCLvkZYbNELiPnVoh;
	}

	protected unsafe string RKBMMYGMkoPEMjmOOWQOxwxbAiM(IntPtr P_0)
	{
		rITjSPfCwElKFnHbTaQebVuopzhg rITjSPfCwElKFnHbTaQebVuopzhg2 = default(rITjSPfCwElKFnHbTaQebVuopzhg);
		rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC cMOIOQONGOLWBfXMWTdWIIYjXGC = default(rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC);
		AZIRjDmlwHNDshjQLQQksWGExag<rITjSPfCwElKFnHbTaQebVuopzhg.cMOIOQONGOLWBfXMWTdWIIYjXGC>(ref cMOIOQONGOLWBfXMWTdWIIYjXGC.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&cMOIOQONGOLWBfXMWTdWIIYjXGC));
		rITjSPfCwElKFnHbTaQebVuopzhg2.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref cMOIOQONGOLWBfXMWTdWIIYjXGC);
		return rITjSPfCwElKFnHbTaQebVuopzhg2.dkOYsGfcBqjJtKGpPrHEqVMHAXL;
	}

	protected string GSMgyajYxzwIoyZdcGlhbDbFRgj(IntPtr P_0)
	{
		return GSMgyajYxzwIoyZdcGlhbDbFRgj(P_0, ObjectCode);
	}

	protected unsafe string GSMgyajYxzwIoyZdcGlhbDbFRgj(IntPtr P_0, int P_1)
	{
		aPnaIuCewFiUYvmVHrOoLOjjxcE aPnaIuCewFiUYvmVHrOoLOjjxcE2 = default(aPnaIuCewFiUYvmVHrOoLOjjxcE);
		aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA lwUSejjwwzWfPIKmmjGazAOOYBA = default(aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA);
		AZIRjDmlwHNDshjQLQQksWGExag<aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA>(ref lwUSejjwwzWfPIKmmjGazAOOYBA.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		lwUSejjwwzWfPIKmmjGazAOOYBA.uKgrmzWDMXdahjyvrfNpOFIMDQxc.kDIMMdxmcixAUfpzeaqMvfDAwEK = P_1;
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&lwUSejjwwzWfPIKmmjGazAOOYBA));
		aPnaIuCewFiUYvmVHrOoLOjjxcE2.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref lwUSejjwwzWfPIKmmjGazAOOYBA);
		return aPnaIuCewFiUYvmVHrOoLOjjxcE2.nqyjVlKBsyllSRWCkSEbvjHHHcc;
	}

	protected unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(IntPtr P_0, string P_1)
	{
		aPnaIuCewFiUYvmVHrOoLOjjxcE aPnaIuCewFiUYvmVHrOoLOjjxcE2 = new aPnaIuCewFiUYvmVHrOoLOjjxcE
		{
			nqyjVlKBsyllSRWCkSEbvjHHHcc = P_1
		};
		aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA lwUSejjwwzWfPIKmmjGazAOOYBA = default(aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA);
		aPnaIuCewFiUYvmVHrOoLOjjxcE2.ZOrqRDWidYwRgwHrRQtkXoMvWTT(ref lwUSejjwwzWfPIKmmjGazAOOYBA);
		AZIRjDmlwHNDshjQLQQksWGExag<aPnaIuCewFiUYvmVHrOoLOjjxcE.lwUSejjwwzWfPIKmmjGazAOOYBA>(ref lwUSejjwwzWfPIKmmjGazAOOYBA.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		Device.zzWgbWavhIFAvnPHQExAcXILdPQ(P_0, new IntPtr(&lwUSejjwwzWfPIKmmjGazAOOYBA));
	}

	protected unsafe LORDAuECNFpRPQHKhdIzDKYopLmA QfVFwrHcaqzKIcGTzhglkeTBMCZs(IntPtr P_0)
	{
		XVLTskwOufoUNHDuBBYNhnCSrlB range = default(XVLTskwOufoUNHDuBBYNhnCSrlB);
		AZIRjDmlwHNDshjQLQQksWGExag<XVLTskwOufoUNHDuBBYNhnCSrlB>(ref range.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		Device.EVshOHJzUdCktioBXNABsymhUmR(P_0, new IntPtr(&range));
		return new LORDAuECNFpRPQHKhdIzDKYopLmA(range);
	}

	protected unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(IntPtr P_0, LORDAuECNFpRPQHKhdIzDKYopLmA P_1)
	{
		XVLTskwOufoUNHDuBBYNhnCSrlB xVLTskwOufoUNHDuBBYNhnCSrlB = default(XVLTskwOufoUNHDuBBYNhnCSrlB);
		AZIRjDmlwHNDshjQLQQksWGExag<XVLTskwOufoUNHDuBBYNhnCSrlB>(ref xVLTskwOufoUNHDuBBYNhnCSrlB.uKgrmzWDMXdahjyvrfNpOFIMDQxc);
		P_1.ryMNHgtDQgtiTLPrKNZKuPzxuYp(ref xVLTskwOufoUNHDuBBYNhnCSrlB);
		Device.zzWgbWavhIFAvnPHQExAcXILdPQ(P_0, new IntPtr(&xVLTskwOufoUNHDuBBYNhnCSrlB));
	}

	internal unsafe void AZIRjDmlwHNDshjQLQQksWGExag<T>(ref zMdVNxfZlWEmmvJQjcWVbJMCunD P_0) where T : struct
	{
		P_0.MSHCgcyCMthFnRTIrchleRuEuVD = QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<T>();
		P_0.DMUAIdPnMaEgrRDyQKhZajoHzhA = sizeof(zMdVNxfZlWEmmvJQjcWVbJMCunD);
		P_0.HSgsKXENkcvZsdtDvNAJblnfTHZ = PropertyType;
		P_0.kDIMMdxmcixAUfpzeaqMvfDAwEK = ObjectCode;
	}
}
