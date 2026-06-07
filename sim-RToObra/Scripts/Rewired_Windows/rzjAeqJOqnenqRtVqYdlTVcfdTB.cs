using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class rzjAeqJOqnenqRtVqYdlTVcfdTB : TypeSpecificParameters
{
	[CompilerGenerated]
	private int RxOMczerrySOwIPFADLBCLcoJxV;

	[CompilerGenerated]
	private int eQEqqdzjMkunUlMGdXcHMCunXQb;

	[CompilerGenerated]
	private int OXyOkWdPsDoUNzEWehqJbjronaV;

	[CompilerGenerated]
	private int[] sDQrVzNbVsDOpfEMxzXZKvAJWixE;

	public int ChannelCount
	{
		[CompilerGenerated]
		get
		{
			return RxOMczerrySOwIPFADLBCLcoJxV;
		}
		[CompilerGenerated]
		set
		{
			RxOMczerrySOwIPFADLBCLcoJxV = value;
		}
	}

	public int SamplePeriod
	{
		[CompilerGenerated]
		get
		{
			return eQEqqdzjMkunUlMGdXcHMCunXQb;
		}
		[CompilerGenerated]
		set
		{
			eQEqqdzjMkunUlMGdXcHMCunXQb = value;
		}
	}

	public int SampleCount
	{
		[CompilerGenerated]
		get
		{
			return OXyOkWdPsDoUNzEWehqJbjronaV;
		}
		[CompilerGenerated]
		set
		{
			OXyOkWdPsDoUNzEWehqJbjronaV = value;
		}
	}

	public int[] ForceData
	{
		[CompilerGenerated]
		get
		{
			return sDQrVzNbVsDOpfEMxzXZKvAJWixE;
		}
		[CompilerGenerated]
		set
		{
			sDQrVzNbVsDOpfEMxzXZKvAJWixE = value;
		}
	}

	public override int Size
	{
		get
		{
			return WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<XwDLVkgoDuBhKAayFoNhPUxedSD>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(XwDLVkgoDuBhKAayFoNhPUxedSD))
		{
			return null;
		}
		ChannelCount = ((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)P_1)->aaJsJSpuUrEZkffMlVkiwwrAFGp;
		SamplePeriod = ((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)P_1)->BeUBzPomAFKhqFoAdjbwSwMLhVr;
		SampleCount = ((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)P_1)->WjMmqmeoSXuGxfMSCYEVvYuWdWR;
		ForceData = new int[SampleCount];
		fixed (int* forceData = ForceData)
		{
			WISJwItoxlmpVJIyUeIxBJGahMp.paUzUKGciuAmJnjIrFfoiXQPbNEU((IntPtr)forceData, ((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)P_1)->wDzzGynrKQvFjjDhYYOTjfvEkyJ, ForceData.Length * sizeof(XwDLVkgoDuBhKAayFoNhPUxedSD));
		}
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)intPtr)->aaJsJSpuUrEZkffMlVkiwwrAFGp = ChannelCount;
		((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)intPtr)->BeUBzPomAFKhqFoAdjbwSwMLhVr = SamplePeriod;
		((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)intPtr)->WjMmqmeoSXuGxfMSCYEVvYuWdWR = SampleCount;
		IntPtr intPtr2 = Marshal.AllocHGlobal(ForceData.Length * 4);
		((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)intPtr)->wDzzGynrKQvFjjDhYYOTjfvEkyJ = intPtr2;
		fixed (int* forceData = ForceData)
		{
			WISJwItoxlmpVJIyUeIxBJGahMp.paUzUKGciuAmJnjIrFfoiXQPbNEU(intPtr2, (IntPtr)forceData, ForceData.Length * 4);
		}
		return intPtr;
	}

	internal unsafe override void MarshalFree(IntPtr P_0)
	{
		base.MarshalFree(P_0);
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((XwDLVkgoDuBhKAayFoNhPUxedSD*)(void*)P_0)->wDzzGynrKQvFjjDhYYOTjfvEkyJ);
		}
	}
}
