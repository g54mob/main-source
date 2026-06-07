using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class JafGYKBUtGCxFdpBbFrZYEAqUMuwb : VMGAKXIBdMsPTuSmeIglvnLsfUom
{
	[CompilerGenerated]
	private lPUKNVnROEZFkdkZfoddUMNAxYJe[] LFjbkcGKuSbavYRIgRAntYBPSpTy;

	public lPUKNVnROEZFkdkZfoddUMNAxYJe[] MymROKKMvWmxeNGMsJvyutdVnflq
	{
		[CompilerGenerated]
		get
		{
			return LFjbkcGKuSbavYRIgRAntYBPSpTy;
		}
		[CompilerGenerated]
		set
		{
			LFjbkcGKuSbavYRIgRAntYBPSpTy = lFjbkcGKuSbavYRIgRAntYBPSpTy;
		}
	}

	unsafe int VMGAKXIBdMsPTuSmeIglvnLsfUom.zZHfXGvkFZGpmLEYkBXqWnicdKKv
	{
		get
		{
			if (MymROKKMvWmxeNGMsJvyutdVnflq == null)
			{
				return 0;
			}
			return MymROKKMvWmxeNGMsJvyutdVnflq.Length * sizeof(lPUKNVnROEZFkdkZfoddUMNAxYJe);
		}
	}

	protected unsafe virtual VMGAKXIBdMsPTuSmeIglvnLsfUom ulrfkHJvGMzzfeVmEPNzmPjCbYVX(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(lPUKNVnROEZFkdkZfoddUMNAxYJe) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(lPUKNVnROEZFkdkZfoddUMNAxYJe);
		MymROKKMvWmxeNGMsJvyutdVnflq = new lPUKNVnROEZFkdkZfoddUMNAxYJe[num];
		fixed (lPUKNVnROEZFkdkZfoddUMNAxYJe* ptr = MymROKKMvWmxeNGMsJvyutdVnflq)
		{
			luYaFPaftNInTWGPWfCvgYuDUqDyA.JJGgrpAvfYRUJflNOROgzAByeTGgb((IntPtr)ptr, P_1, luYaFPaftNInTWGPWfCvgYuDUqDyA.glwGxVPzunhdOUxGIRKtVKPYTQvO<lPUKNVnROEZFkdkZfoddUMNAxYJe>() * MymROKKMvWmxeNGMsJvyutdVnflq.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr lQkWPRghUpAjeISkKLcLxARNHVeTA()
	{
		if (zZHfXGvkFZGpmLEYkBXqWnicdKKv == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(zZHfXGvkFZGpmLEYkBXqWnicdKKv);
		fixed (lPUKNVnROEZFkdkZfoddUMNAxYJe* ptr = MymROKKMvWmxeNGMsJvyutdVnflq)
		{
			luYaFPaftNInTWGPWfCvgYuDUqDyA.JJGgrpAvfYRUJflNOROgzAByeTGgb(intPtr, (IntPtr)ptr, luYaFPaftNInTWGPWfCvgYuDUqDyA.glwGxVPzunhdOUxGIRKtVKPYTQvO<lPUKNVnROEZFkdkZfoddUMNAxYJe>() * MymROKKMvWmxeNGMsJvyutdVnflq.Length);
		}
		return intPtr;
	}
}
