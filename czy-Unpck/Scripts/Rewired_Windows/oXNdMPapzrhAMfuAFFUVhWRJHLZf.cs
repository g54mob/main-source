using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class oXNdMPapzrhAMfuAFFUVhWRJHLZf
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int qEIUpCpdjXNdjELDlujUIXjqDxG(void* deviceInstance, IntPtr data);

	private readonly IntPtr tkIGqgtIwxjuCkXnyDpVvseOkZD;

	private readonly qEIUpCpdjXNdjELDlujUIXjqDxG fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	[CompilerGenerated]
	private List<zyLrABMiyUbhjbOXJbBSprMtAmY> FsUIEFkgcWeOspyiHCsKTFjeEaM;

	public IntPtr NativePointer => tkIGqgtIwxjuCkXnyDpVvseOkZD;

	public List<zyLrABMiyUbhjbOXJbBSprMtAmY> EffectsInFile
	{
		[CompilerGenerated]
		get
		{
			return FsUIEFkgcWeOspyiHCsKTFjeEaM;
		}
		[CompilerGenerated]
		private set
		{
			FsUIEFkgcWeOspyiHCsKTFjeEaM = value;
		}
	}

	public unsafe oXNdMPapzrhAMfuAFFUVhWRJHLZf()
	{
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = XKpZLteVHEkBSSNAQYGgXadCpup;
		tkIGqgtIwxjuCkXnyDpVvseOkZD = Marshal.GetFunctionPointerForDelegate((Delegate)fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		EffectsInFile = new List<zyLrABMiyUbhjbOXJbBSprMtAmY>();
	}

	[MonoPInvokeCallback(typeof(qEIUpCpdjXNdjELDlujUIXjqDxG))]
	private unsafe static int XKpZLteVHEkBSSNAQYGgXadCpup(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<oXNdMPapzrhAMfuAFFUVhWRJHLZf>(instanceId, out var instance))
		{
			return 1;
		}
		zyLrABMiyUbhjbOXJbBSprMtAmY zyLrABMiyUbhjbOXJbBSprMtAmY2 = new zyLrABMiyUbhjbOXJbBSprMtAmY();
		zyLrABMiyUbhjbOXJbBSprMtAmY2.ZXWljcfhlKeirbwwnVKxodNeLfEH(ref *(zyLrABMiyUbhjbOXJbBSprMtAmY.kfSsyuXhRncSBmyaaEcCptGSqif*)P_0);
		instance.EffectsInFile.Add(zyLrABMiyUbhjbOXJbBSprMtAmY2);
		return 1;
	}
}
