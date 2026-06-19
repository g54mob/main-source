using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class pjyjkmlRplMHEigaLnjWvGDxOEE
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ctznXhjHxlhKqcIVQIyWuEainiv(void* deviceInstance, IntPtr data);

	private readonly IntPtr gBbLrXrPAfTbPiLRobgphErqzjOU;

	private readonly ctznXhjHxlhKqcIVQIyWuEainiv iWJLmGxRkATRajaGxiTgAzQvcIb;

	[CompilerGenerated]
	private List<szcuYyKpWAfOqbznZElsQSRJNWF> EPrKxemdGGwOdlJMNhjuJokYmjT;

	public IntPtr NativePointer => gBbLrXrPAfTbPiLRobgphErqzjOU;

	public List<szcuYyKpWAfOqbznZElsQSRJNWF> EffectsInFile
	{
		[CompilerGenerated]
		get
		{
			return EPrKxemdGGwOdlJMNhjuJokYmjT;
		}
		[CompilerGenerated]
		private set
		{
			EPrKxemdGGwOdlJMNhjuJokYmjT = value;
		}
	}

	public unsafe pjyjkmlRplMHEigaLnjWvGDxOEE()
	{
		iWJLmGxRkATRajaGxiTgAzQvcIb = ADELsSkVbQjsNWuuMLzQiVwehic;
		gBbLrXrPAfTbPiLRobgphErqzjOU = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		EffectsInFile = new List<szcuYyKpWAfOqbznZElsQSRJNWF>();
	}

	[MonoPInvokeCallback(typeof(ctznXhjHxlhKqcIVQIyWuEainiv))]
	private unsafe static int ADELsSkVbQjsNWuuMLzQiVwehic(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<pjyjkmlRplMHEigaLnjWvGDxOEE>(instanceId, out var instance))
		{
			return 1;
		}
		szcuYyKpWAfOqbznZElsQSRJNWF szcuYyKpWAfOqbznZElsQSRJNWF2 = new szcuYyKpWAfOqbznZElsQSRJNWF();
		szcuYyKpWAfOqbznZElsQSRJNWF2.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref *(szcuYyKpWAfOqbznZElsQSRJNWF.kIfaYJoAheGvpTVTURDLHJhWCXXb*)P_0);
		instance.EffectsInFile.Add(szcuYyKpWAfOqbznZElsQSRJNWF2);
		return 1;
	}
}
