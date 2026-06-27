using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class voPxlEsSriHhplbyGzobCZFgJPag
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int yrmRbVZZmxhJmHOCYHZeSHseOZus(void* deviceInstance, IntPtr data);

	private readonly IntPtr thGSYZsnClEKmPYMFYRlTlTlExSC;

	private readonly yrmRbVZZmxhJmHOCYHZeSHseOZus NlIfhvLlHfgnwksdtjLXbcLgYBFrB;

	[CompilerGenerated]
	private List<HsbCfKqHbpzFEYtVzGqxwISXgpakA> jNYSmTrAKfYDSfuHpBWHCGJedVPw;

	public IntPtr TrTbaGGlaKZHUJcuNSwolnKqyCdQ => thGSYZsnClEKmPYMFYRlTlTlExSC;

	public List<HsbCfKqHbpzFEYtVzGqxwISXgpakA> aAbaxcCtGxIqWVJBlqpBMkrasnlH
	{
		[CompilerGenerated]
		get
		{
			return jNYSmTrAKfYDSfuHpBWHCGJedVPw;
		}
		[CompilerGenerated]
		private set
		{
			jNYSmTrAKfYDSfuHpBWHCGJedVPw = list;
		}
	}

	public unsafe voPxlEsSriHhplbyGzobCZFgJPag()
	{
		NlIfhvLlHfgnwksdtjLXbcLgYBFrB = gOBzujpbpHhNisqaKVojKmwSLiYI;
		thGSYZsnClEKmPYMFYRlTlTlExSC = Marshal.GetFunctionPointerForDelegate(NlIfhvLlHfgnwksdtjLXbcLgYBFrB);
		aAbaxcCtGxIqWVJBlqpBMkrasnlH = new List<HsbCfKqHbpzFEYtVzGqxwISXgpakA>();
	}

	[MonoPInvokeCallback(typeof(yrmRbVZZmxhJmHOCYHZeSHseOZus))]
	private unsafe static int gOBzujpbpHhNisqaKVojKmwSLiYI(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<voPxlEsSriHhplbyGzobCZFgJPag>(instanceId, out var instance))
		{
			return 1;
		}
		HsbCfKqHbpzFEYtVzGqxwISXgpakA hsbCfKqHbpzFEYtVzGqxwISXgpakA = new HsbCfKqHbpzFEYtVzGqxwISXgpakA();
		hsbCfKqHbpzFEYtVzGqxwISXgpakA.cHXukhMBbHkRcxJFbHzflhifVbtD(ref *(HsbCfKqHbpzFEYtVzGqxwISXgpakA.IRFqVuZbmzyTESAttYKZsXIoMHrg*)P_0);
		instance.aAbaxcCtGxIqWVJBlqpBMkrasnlH.Add(hsbCfKqHbpzFEYtVzGqxwISXgpakA);
		return 1;
	}
}
