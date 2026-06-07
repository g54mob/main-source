using System;
using System.Runtime.InteropServices;

internal class xwyMJAYdGGiXpXbUjyEbEkjqjcC : IDisposable
{
	public struct JMFLDpXBItRTreXjZfBHxGenwyI
	{
		private byte iuBSGEeiHysQEHwYJJmxUDxqIwD;

		private uint ywWxJVMJWXaMLbgUsTcQJUIRbVga;

		private int vtIobczDotOpllyixsFUaAwldJS;

		private static JMFLDpXBItRTreXjZfBHxGenwyI qAZHlwAaDRFVayDtbeshlFShcUHT;

		public byte pass => iuBSGEeiHysQEHwYJJmxUDxqIwD;

		public uint offset => ywWxJVMJWXaMLbgUsTcQJUIRbVga;

		public int length => vtIobczDotOpllyixsFUaAwldJS;

		public static JMFLDpXBItRTreXjZfBHxGenwyI Invalid => qAZHlwAaDRFVayDtbeshlFShcUHT;

		public JMFLDpXBItRTreXjZfBHxGenwyI(byte pass, uint offset, int length)
		{
			iuBSGEeiHysQEHwYJJmxUDxqIwD = pass;
			ywWxJVMJWXaMLbgUsTcQJUIRbVga = offset;
			vtIobczDotOpllyixsFUaAwldJS = length;
			if (vtIobczDotOpllyixsFUaAwldJS < 0)
			{
				vtIobczDotOpllyixsFUaAwldJS = 0;
			}
		}
	}

	private const byte sWVzejqeUecgzJdzODXgNccZlKgX = 254;

	private uint MRlCVeROGVBAkaIxvxFuFkuNEeD;

	private int KxoaQduWpmsRutbbJilXLlDiBUs;

	private unsafe byte* lbVcopKEyzdwBOyXpqOVjHfDuKTh;

	private byte iuBSGEeiHysQEHwYJJmxUDxqIwD;

	private bool kCzQsvrLoSQeTRoGVnTtJLZvwPZ;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public int size => KxoaQduWpmsRutbbJilXLlDiBUs;

	public unsafe xwyMJAYdGGiXpXbUjyEbEkjqjcC(int size)
	{
		if (size <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		KxoaQduWpmsRutbbJilXLlDiBUs = size;
		MRlCVeROGVBAkaIxvxFuFkuNEeD = 0u;
		lbVcopKEyzdwBOyXpqOVjHfDuKTh = (byte*)(void*)Marshal.AllocHGlobal(size);
	}

	public unsafe bool xwyOTGiXUEnQReUfdMBlfOwNgvM(IntPtr P_0, int P_1, out JMFLDpXBItRTreXjZfBHxGenwyI P_2)
	{
		if (lbVcopKEyzdwBOyXpqOVjHfDuKTh == null || P_1 <= 0)
		{
			P_2 = default(JMFLDpXBItRTreXjZfBHxGenwyI);
			return false;
		}
		if (P_1 > KxoaQduWpmsRutbbJilXLlDiBUs)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		uint num = MRlCVeROGVBAkaIxvxFuFkuNEeD + (uint)P_1;
		if (num >= KxoaQduWpmsRutbbJilXLlDiBUs)
		{
			MRlCVeROGVBAkaIxvxFuFkuNEeD = 0u;
			if (iuBSGEeiHysQEHwYJJmxUDxqIwD == 254)
			{
				iuBSGEeiHysQEHwYJJmxUDxqIwD = 0;
				kCzQsvrLoSQeTRoGVnTtJLZvwPZ = true;
			}
			else
			{
				iuBSGEeiHysQEHwYJJmxUDxqIwD++;
			}
		}
		AewjMoBLyBolnnNMhBXWHRooNZC.iWdjIApMtbjmqUSnoOlIDKbObPO(lbVcopKEyzdwBOyXpqOVjHfDuKTh + (int)MRlCVeROGVBAkaIxvxFuFkuNEeD, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new JMFLDpXBItRTreXjZfBHxGenwyI(iuBSGEeiHysQEHwYJJmxUDxqIwD, MRlCVeROGVBAkaIxvxFuFkuNEeD, P_1);
		MRlCVeROGVBAkaIxvxFuFkuNEeD += (uint)P_1;
		return true;
	}

	public int OyoZWUuiamgvSVRBhbJZhjZZxdr(JMFLDpXBItRTreXjZfBHxGenwyI P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!PoxFwvoGgLiVYjTBZGAoxGmdQyR(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(oODJxsuFfuLbfIsUzNqqJojaBPVf(P_0), P_1, 0, P_0.length);
		return P_0.length;
	}

	public unsafe int OyoZWUuiamgvSVRBhbJZhjZZxdr(JMFLDpXBItRTreXjZfBHxGenwyI P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.length)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!PoxFwvoGgLiVYjTBZGAoxGmdQyR(ref P_0))
		{
			return -1;
		}
		AewjMoBLyBolnnNMhBXWHRooNZC.iWdjIApMtbjmqUSnoOlIDKbObPO((void*)P_1, lbVcopKEyzdwBOyXpqOVjHfDuKTh, new UIntPtr((uint)P_0.length));
		return P_0.length;
	}

	public unsafe IntPtr oODJxsuFfuLbfIsUzNqqJojaBPVf(JMFLDpXBItRTreXjZfBHxGenwyI P_0)
	{
		if (lbVcopKEyzdwBOyXpqOVjHfDuKTh == null || !PoxFwvoGgLiVYjTBZGAoxGmdQyR(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(lbVcopKEyzdwBOyXpqOVjHfDuKTh + (int)P_0.offset);
	}

	public unsafe bool aHpJbVnrjQWSdjnHzDeElqXYAKGe(JMFLDpXBItRTreXjZfBHxGenwyI P_0, out IntPtr P_1)
	{
		if (lbVcopKEyzdwBOyXpqOVjHfDuKTh == null || !PoxFwvoGgLiVYjTBZGAoxGmdQyR(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(lbVcopKEyzdwBOyXpqOVjHfDuKTh + (int)P_0.offset);
		return true;
	}

	private bool PoxFwvoGgLiVYjTBZGAoxGmdQyR(ref JMFLDpXBItRTreXjZfBHxGenwyI P_0)
	{
		int length = P_0.length;
		if (length <= 0)
		{
			return false;
		}
		uint pass = P_0.pass;
		if (pass > 254)
		{
			return false;
		}
		if (pass != iuBSGEeiHysQEHwYJJmxUDxqIwD)
		{
			if (!kCzQsvrLoSQeTRoGVnTtJLZvwPZ)
			{
				if (pass + 1 != iuBSGEeiHysQEHwYJJmxUDxqIwD)
				{
					return false;
				}
			}
			else if (pass > iuBSGEeiHysQEHwYJJmxUDxqIwD)
			{
				if (iuBSGEeiHysQEHwYJJmxUDxqIwD != 0 || pass != 254)
				{
					return false;
				}
			}
			else if (pass + 1 != iuBSGEeiHysQEHwYJJmxUDxqIwD)
			{
				return false;
			}
			if (P_0.offset < MRlCVeROGVBAkaIxvxFuFkuNEeD)
			{
				return false;
			}
		}
		else if (P_0.offset + length > MRlCVeROGVBAkaIxvxFuFkuNEeD)
		{
			return false;
		}
		if (P_0.offset + length > KxoaQduWpmsRutbbJilXLlDiBUs)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~xwyMJAYdGGiXpXbUjyEbEkjqjcC()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected unsafe virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			if (lbVcopKEyzdwBOyXpqOVjHfDuKTh != null)
			{
				Marshal.FreeHGlobal((IntPtr)lbVcopKEyzdwBOyXpqOVjHfDuKTh);
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}
}
