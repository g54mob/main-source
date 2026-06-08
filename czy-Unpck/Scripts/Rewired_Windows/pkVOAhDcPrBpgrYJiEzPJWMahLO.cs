using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class pkVOAhDcPrBpgrYJiEzPJWMahLO
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int JjKmmFdBLQNbSedDScwSxiDuXjS(void* deviceInstance, IntPtr data);

	private readonly IntPtr tkIGqgtIwxjuCkXnyDpVvseOkZD;

	private readonly JjKmmFdBLQNbSedDScwSxiDuXjS fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	[CompilerGenerated]
	private List<JgrAyYzRNsNStAtAQACKYutyEqZ> aKDStMJNrOzsStCohQzAMlmFjZW;

	public IntPtr NativePointer => tkIGqgtIwxjuCkXnyDpVvseOkZD;

	public List<JgrAyYzRNsNStAtAQACKYutyEqZ> Objects
	{
		[CompilerGenerated]
		get
		{
			return aKDStMJNrOzsStCohQzAMlmFjZW;
		}
		[CompilerGenerated]
		private set
		{
			aKDStMJNrOzsStCohQzAMlmFjZW = value;
		}
	}

	public unsafe pkVOAhDcPrBpgrYJiEzPJWMahLO()
	{
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = hikAfMueFJFVrixAUevNPczJVjm;
		tkIGqgtIwxjuCkXnyDpVvseOkZD = Marshal.GetFunctionPointerForDelegate((Delegate)fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		Objects = new List<JgrAyYzRNsNStAtAQACKYutyEqZ>();
	}

	[MonoPInvokeCallback(typeof(JjKmmFdBLQNbSedDScwSxiDuXjS))]
	private unsafe static int hikAfMueFJFVrixAUevNPczJVjm(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<pkVOAhDcPrBpgrYJiEzPJWMahLO>(instanceId, out var instance))
		{
			return 1;
		}
		JgrAyYzRNsNStAtAQACKYutyEqZ jgrAyYzRNsNStAtAQACKYutyEqZ = new JgrAyYzRNsNStAtAQACKYutyEqZ();
		jgrAyYzRNsNStAtAQACKYutyEqZ.ZXWljcfhlKeirbwwnVKxodNeLfEH(ref *(JgrAyYzRNsNStAtAQACKYutyEqZ.jBziDbkpJjmrRaaCJEemdsEaZkza*)P_0);
		instance.Objects.Add(jgrAyYzRNsNStAtAQACKYutyEqZ);
		return 1;
	}
}
