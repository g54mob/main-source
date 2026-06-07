using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct BlUbRLRhVZtFjqdJocRYnrNVRTEu : IEquatable<BlUbRLRhVZtFjqdJocRYnrNVRTEu>, IFormattable
{
	public static readonly int rnricrbcHjaxgyaulXsyuhExYijj = Marshal.SizeOf(typeof(BlUbRLRhVZtFjqdJocRYnrNVRTEu));

	public static readonly BlUbRLRhVZtFjqdJocRYnrNVRTEu RHehBwDLhoBlJseolcvUnZfDCgeS = default(BlUbRLRhVZtFjqdJocRYnrNVRTEu);

	public static readonly BlUbRLRhVZtFjqdJocRYnrNVRTEu yztPRrAVTviOJmPtoMfxdANjoOVi = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(1f, 0f);

	public static readonly BlUbRLRhVZtFjqdJocRYnrNVRTEu LRztKHhoNbuxddBkQHTpeguHlByrA = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(0f, 1f);

	public static readonly BlUbRLRhVZtFjqdJocRYnrNVRTEu zkvMtkpSlweTgUJmIxVgMuEMFgsi = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(1f, 1f);

	public float XHAcjfYHxobupnkeqiFjdRtqsftl;

	public float hOOUxyzjPSHmCugYimIocEeoCnOZ;

	public bool XuYGPsojxHxqOpqIOCVgDHhKTnlJ => rlbdYkFceDqoAzgGWbJzBvjOegujb.ntyFDpbBkBvWGtdeMjzxoxxpnGNo(XHAcjfYHxobupnkeqiFjdRtqsftl * XHAcjfYHxobupnkeqiFjdRtqsftl + hOOUxyzjPSHmCugYimIocEeoCnOZ * hOOUxyzjPSHmCugYimIocEeoCnOZ);

	public bool bVHYyCaIdSBdbqMrrqVHtsqsKsAG
	{
		get
		{
			if (XHAcjfYHxobupnkeqiFjdRtqsftl == 0f)
			{
				return hOOUxyzjPSHmCugYimIocEeoCnOZ == 0f;
			}
			return false;
		}
	}

	public float uYZQJGUmbMuICFZWSqJprRCobGI
	{
		get
		{
			switch (P_0)
			{
			case 0:
				return XHAcjfYHxobupnkeqiFjdRtqsftl;
			case 1:
				return hOOUxyzjPSHmCugYimIocEeoCnOZ;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
		set
		{
			switch (num)
			{
			case 0:
				XHAcjfYHxobupnkeqiFjdRtqsftl = xHAcjfYHxobupnkeqiFjdRtqsftl;
				break;
			case 1:
				hOOUxyzjPSHmCugYimIocEeoCnOZ = xHAcjfYHxobupnkeqiFjdRtqsftl;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public BlUbRLRhVZtFjqdJocRYnrNVRTEu(float P_0)
	{
		XHAcjfYHxobupnkeqiFjdRtqsftl = P_0;
		hOOUxyzjPSHmCugYimIocEeoCnOZ = P_0;
	}

	public BlUbRLRhVZtFjqdJocRYnrNVRTEu(float P_0, float P_1)
	{
		XHAcjfYHxobupnkeqiFjdRtqsftl = P_0;
		hOOUxyzjPSHmCugYimIocEeoCnOZ = P_1;
	}

	public BlUbRLRhVZtFjqdJocRYnrNVRTEu(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		XHAcjfYHxobupnkeqiFjdRtqsftl = P_0[0];
		hOOUxyzjPSHmCugYimIocEeoCnOZ = P_0[1];
	}

	public float yIVYFnpBLClvFaTdWwokHpQgDIPu()
	{
		return (float)Math.Sqrt(XHAcjfYHxobupnkeqiFjdRtqsftl * XHAcjfYHxobupnkeqiFjdRtqsftl + hOOUxyzjPSHmCugYimIocEeoCnOZ * hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public float sDGtBfFfbFFJVeFePSntkluAcERSA()
	{
		return XHAcjfYHxobupnkeqiFjdRtqsftl * XHAcjfYHxobupnkeqiFjdRtqsftl + hOOUxyzjPSHmCugYimIocEeoCnOZ * hOOUxyzjPSHmCugYimIocEeoCnOZ;
	}

	public void aeGiPXYDGedOoKzMRKoWqEuxTDfKA()
	{
		float num = yIVYFnpBLClvFaTdWwokHpQgDIPu();
		if (!rlbdYkFceDqoAzgGWbJzBvjOegujb.bVHYyCaIdSBdbqMrrqVHtsqsKsAG(num))
		{
			float num2 = 1f / num;
			XHAcjfYHxobupnkeqiFjdRtqsftl *= num2;
			hOOUxyzjPSHmCugYimIocEeoCnOZ *= num2;
		}
	}

	public float[] RzFCRGETplbXGkVolnjEfGkELmyL()
	{
		return new float[2] { XHAcjfYHxobupnkeqiFjdRtqsftl, hOOUxyzjPSHmCugYimIocEeoCnOZ };
	}

	public static void UHMgDAszduWgLVRxVeFjzYmZObjK(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu UHMgDAszduWgLVRxVeFjzYmZObjK(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void UHMgDAszduWgLVRxVeFjzYmZObjK(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref float P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu UHMgDAszduWgLVRxVeFjzYmZObjK(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1);
	}

	public static void hjKeybieHOvPmPEBLGSjLRDXlRxu(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu hjKeybieHOvPmPEBLGSjLRDXlRxu(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void hjKeybieHOvPmPEBLGSjLRDXlRxu(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref float P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu hjKeybieHOvPmPEBLGSjLRDXlRxu(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1);
	}

	public static void hjKeybieHOvPmPEBLGSjLRDXlRxu(ref float P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu hjKeybieHOvPmPEBLGSjLRDXlRxu(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void ZasbkJFAeQCKRFtQNMuSwePUaLcv(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu ZasbkJFAeQCKRFtQNMuSwePUaLcv(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1);
	}

	public static void ZasbkJFAeQCKRFtQNMuSwePUaLcv(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu ZasbkJFAeQCKRFtQNMuSwePUaLcv(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void RYFgVMGNKyyKqDMyXBvZUqybFSXrA(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl / P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ / P_1);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu RYFgVMGNKyyKqDMyXBvZUqybFSXrA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl / P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ / P_1);
	}

	public static void RYFgVMGNKyyKqDMyXBvZUqybFSXrA(float P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 / P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 / P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu RYFgVMGNKyyKqDMyXBvZUqybFSXrA(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 / P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 / P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void meQIGAGuphVNkWpTutoxadbVlRBoA(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		P_1 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(0f - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl, 0f - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu meQIGAGuphVNkWpTutoxadbVlRBoA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(0f - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl, 0f - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static void UNGVqRLiPCbDTCvaCAMmhMFGbZzAb(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, float P_3, float P_4, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_5)
	{
		P_5 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_3 * (P_1.XHAcjfYHxobupnkeqiFjdRtqsftl - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl) + P_4 * (P_2.XHAcjfYHxobupnkeqiFjdRtqsftl - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl), P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_3 * (P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ) + P_4 * (P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ));
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu UNGVqRLiPCbDTCvaCAMmhMFGbZzAb(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, float P_3, float P_4)
	{
		UNGVqRLiPCbDTCvaCAMmhMFGbZzAb(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void OqFQVnvGyHCpJRlrPqDycaEnGbGl(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3)
	{
		float xHAcjfYHxobupnkeqiFjdRtqsftl = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl;
		xHAcjfYHxobupnkeqiFjdRtqsftl = ((xHAcjfYHxobupnkeqiFjdRtqsftl > P_2.XHAcjfYHxobupnkeqiFjdRtqsftl) ? P_2.XHAcjfYHxobupnkeqiFjdRtqsftl : xHAcjfYHxobupnkeqiFjdRtqsftl);
		xHAcjfYHxobupnkeqiFjdRtqsftl = ((xHAcjfYHxobupnkeqiFjdRtqsftl < P_1.XHAcjfYHxobupnkeqiFjdRtqsftl) ? P_1.XHAcjfYHxobupnkeqiFjdRtqsftl : xHAcjfYHxobupnkeqiFjdRtqsftl);
		float num = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		num = ((num > P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ) ? P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ : num);
		num = ((num < P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ) ? P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ : num);
		P_3 = new BlUbRLRhVZtFjqdJocRYnrNVRTEu(xHAcjfYHxobupnkeqiFjdRtqsftl, num);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu OqFQVnvGyHCpJRlrPqDycaEnGbGl(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		OqFQVnvGyHCpJRlrPqDycaEnGbGl(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void WjTSNcCvbuOuRrfIOKHqtRyrnrKh()
	{
		XHAcjfYHxobupnkeqiFjdRtqsftl = ((XHAcjfYHxobupnkeqiFjdRtqsftl < 0f) ? 0f : ((XHAcjfYHxobupnkeqiFjdRtqsftl > 1f) ? 1f : XHAcjfYHxobupnkeqiFjdRtqsftl));
		hOOUxyzjPSHmCugYimIocEeoCnOZ = ((hOOUxyzjPSHmCugYimIocEeoCnOZ < 0f) ? 0f : ((hOOUxyzjPSHmCugYimIocEeoCnOZ > 1f) ? 1f : hOOUxyzjPSHmCugYimIocEeoCnOZ));
	}

	public static void XPcoawmizlJMSACtXgvsWvpJHvvW(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out float P_2)
	{
		float num = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		float num2 = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float XPcoawmizlJMSACtXgvsWvpJHvvW(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		float num = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		float num2 = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void iElADgmVsyXsRJYKqCKeTZrWPEaw(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out float P_2)
	{
		float num = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		float num2 = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		P_2 = num * num + num2 * num2;
	}

	public static float iElADgmVsyXsRJYKqCKeTZrWPEaw(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		float num = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		float num2 = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		return num * num + num2 * num2;
	}

	public static void uGNNtXgianXnLCOZLLWmmjXFpiDw(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out float P_2)
	{
		P_2 = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl + P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
	}

	public static float uGNNtXgianXnLCOZLLWmmjXFpiDw(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl + P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
	}

	public static void aeGiPXYDGedOoKzMRKoWqEuxTDfKA(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		P_1 = P_0;
		P_1.aeGiPXYDGedOoKzMRKoWqEuxTDfKA();
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu aeGiPXYDGedOoKzMRKoWqEuxTDfKA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0)
	{
		P_0.aeGiPXYDGedOoKzMRKoWqEuxTDfKA();
		return P_0;
	}

	public static void UzFgBwLZowNfbsoFiTklGhdksSjf(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, float P_2, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3)
	{
		P_3.XHAcjfYHxobupnkeqiFjdRtqsftl = rlbdYkFceDqoAzgGWbJzBvjOegujb.UzFgBwLZowNfbsoFiTklGhdksSjf(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl, P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_2);
		P_3.hOOUxyzjPSHmCugYimIocEeoCnOZ = rlbdYkFceDqoAzgGWbJzBvjOegujb.UzFgBwLZowNfbsoFiTklGhdksSjf(P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ, P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ, P_2);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu UzFgBwLZowNfbsoFiTklGhdksSjf(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, float P_2)
	{
		UzFgBwLZowNfbsoFiTklGhdksSjf(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void OaKwnBbLvDRekONeOqEutgaQHJFDA(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, float P_2, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3)
	{
		P_2 = rlbdYkFceDqoAzgGWbJzBvjOegujb.OaKwnBbLvDRekONeOqEutgaQHJFDA(P_2);
		UzFgBwLZowNfbsoFiTklGhdksSjf(ref P_0, ref P_1, P_2, out P_3);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu OaKwnBbLvDRekONeOqEutgaQHJFDA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, float P_2)
	{
		OaKwnBbLvDRekONeOqEutgaQHJFDA(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void KZxaDIZaolwxTkgCElkdLWvaRbPO(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3, float P_4, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.XHAcjfYHxobupnkeqiFjdRtqsftl = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * num3 + P_2.XHAcjfYHxobupnkeqiFjdRtqsftl * num4 + P_1.XHAcjfYHxobupnkeqiFjdRtqsftl * num5 + P_3.XHAcjfYHxobupnkeqiFjdRtqsftl * num6;
		P_5.hOOUxyzjPSHmCugYimIocEeoCnOZ = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * num3 + P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ * num4 + P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ * num5 + P_3.hOOUxyzjPSHmCugYimIocEeoCnOZ * num6;
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu KZxaDIZaolwxTkgCElkdLWvaRbPO(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3, float P_4)
	{
		KZxaDIZaolwxTkgCElkdLWvaRbPO(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void ZWNZrZrdIBJuoxwHVDjBipFChxxz(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3, float P_4, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.XHAcjfYHxobupnkeqiFjdRtqsftl = 0.5f * (2f * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl + (0f - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_2.XHAcjfYHxobupnkeqiFjdRtqsftl) * P_4 + (2f * P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - 5f * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl + 4f * P_2.XHAcjfYHxobupnkeqiFjdRtqsftl - P_3.XHAcjfYHxobupnkeqiFjdRtqsftl) * num + (0f - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + 3f * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl - 3f * P_2.XHAcjfYHxobupnkeqiFjdRtqsftl + P_3.XHAcjfYHxobupnkeqiFjdRtqsftl) * num2);
		P_5.hOOUxyzjPSHmCugYimIocEeoCnOZ = 0.5f * (2f * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ + (0f - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ) * P_4 + (2f * P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - 5f * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ + 4f * P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_3.hOOUxyzjPSHmCugYimIocEeoCnOZ) * num + (0f - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + 3f * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ - 3f * P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_3.hOOUxyzjPSHmCugYimIocEeoCnOZ) * num2);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu ZWNZrZrdIBJuoxwHVDjBipFChxxz(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_3, float P_4)
	{
		ZWNZrZrdIBJuoxwHVDjBipFChxxz(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void FLKPEiqRhdZLvTWILWotYlGHkfoL(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2.XHAcjfYHxobupnkeqiFjdRtqsftl = ((P_0.XHAcjfYHxobupnkeqiFjdRtqsftl > P_1.XHAcjfYHxobupnkeqiFjdRtqsftl) ? P_0.XHAcjfYHxobupnkeqiFjdRtqsftl : P_1.XHAcjfYHxobupnkeqiFjdRtqsftl);
		P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ = ((P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ > P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ) ? P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ : P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu FLKPEiqRhdZLvTWILWotYlGHkfoL(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		FLKPEiqRhdZLvTWILWotYlGHkfoL(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void MalJIMkoBdfGWeiIVVnBPwQlHYqy(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		P_2.XHAcjfYHxobupnkeqiFjdRtqsftl = ((P_0.XHAcjfYHxobupnkeqiFjdRtqsftl < P_1.XHAcjfYHxobupnkeqiFjdRtqsftl) ? P_0.XHAcjfYHxobupnkeqiFjdRtqsftl : P_1.XHAcjfYHxobupnkeqiFjdRtqsftl);
		P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ = ((P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ < P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ) ? P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ : P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu MalJIMkoBdfGWeiIVVnBPwQlHYqy(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		MalJIMkoBdfGWeiIVVnBPwQlHYqy(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void eYYGayqXaWEOyEzjIrQJPPzkpTLMA(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1, out BlUbRLRhVZtFjqdJocRYnrNVRTEu P_2)
	{
		float num = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl + P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
		P_2.XHAcjfYHxobupnkeqiFjdRtqsftl = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - 2f * num * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl;
		P_2.hOOUxyzjPSHmCugYimIocEeoCnOZ = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - 2f * num * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ;
	}

	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu eYYGayqXaWEOyEzjIrQJPPzkpTLMA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		eYYGayqXaWEOyEzjIrQJPPzkpTLMA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void vPcYLtuHrefnMgBPlOEZbwdVGvBM(BlUbRLRhVZtFjqdJocRYnrNVRTEu[] P_0, params BlUbRLRhVZtFjqdJocRYnrNVRTEu[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			BlUbRLRhVZtFjqdJocRYnrNVRTEu blUbRLRhVZtFjqdJocRYnrNVRTEu = P_1[i];
			for (int j = 0; j < i; j++)
			{
				blUbRLRhVZtFjqdJocRYnrNVRTEu = rtCdTimGXhcOyJOWpuaRCGOKbkBJA(blUbRLRhVZtFjqdJocRYnrNVRTEu, wbIgBbeginlXzLHvEqrftDxIyfuVA(uGNNtXgianXnLCOZLLWmmjXFpiDw(P_0[j], blUbRLRhVZtFjqdJocRYnrNVRTEu) / uGNNtXgianXnLCOZLLWmmjXFpiDw(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = blUbRLRhVZtFjqdJocRYnrNVRTEu;
		}
	}

	public static void cRXyinLqHkYvQVvuLOVHWMBZRSCh(BlUbRLRhVZtFjqdJocRYnrNVRTEu[] P_0, params BlUbRLRhVZtFjqdJocRYnrNVRTEu[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			BlUbRLRhVZtFjqdJocRYnrNVRTEu blUbRLRhVZtFjqdJocRYnrNVRTEu = P_1[i];
			for (int j = 0; j < i; j++)
			{
				blUbRLRhVZtFjqdJocRYnrNVRTEu = rtCdTimGXhcOyJOWpuaRCGOKbkBJA(blUbRLRhVZtFjqdJocRYnrNVRTEu, wbIgBbeginlXzLHvEqrftDxIyfuVA(uGNNtXgianXnLCOZLLWmmjXFpiDw(P_0[j], blUbRLRhVZtFjqdJocRYnrNVRTEu), P_0[j]));
			}
			blUbRLRhVZtFjqdJocRYnrNVRTEu.aeGiPXYDGedOoKzMRKoWqEuxTDfKA();
			P_0[i] = blUbRLRhVZtFjqdJocRYnrNVRTEu;
		}
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu KwIRhVhpzyoxRHRhxcdWbbBMdnpZ(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wbIgBbeginlXzLHvEqrftDxIyfuVA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu JBscfrSLsGdomCGyRiEiPfGvIQBT(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu rtCdTimGXhcOyJOWpuaRCGOKbkBJA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu GkbkLXzBcgPSEwxQXhSQRlSvmOkp(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(0f - P_0.XHAcjfYHxobupnkeqiFjdRtqsftl, 0f - P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wbIgBbeginlXzLHvEqrftDxIyfuVA(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_1.XHAcjfYHxobupnkeqiFjdRtqsftl * P_0, P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_0);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wbIgBbeginlXzLHvEqrftDxIyfuVA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl * P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ * P_1);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wYffayBCTrWYbRyqXGOejxMabWaab(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl / P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ / P_1);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wYffayBCTrWYbRyqXGOejxMabWaab(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 / P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 / P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu wYffayBCTrWYbRyqXGOejxMabWaab(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl / P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ / P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu KwIRhVhpzyoxRHRhxcdWbbBMdnpZ(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl + P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ + P_1);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu KwIRhVhpzyoxRHRhxcdWbbBMdnpZ(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 + P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 + P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu rtCdTimGXhcOyJOWpuaRCGOKbkBJA(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, float P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl - P_1, P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ - P_1);
	}

	[SpecialName]
	public static BlUbRLRhVZtFjqdJocRYnrNVRTEu rtCdTimGXhcOyJOWpuaRCGOKbkBJA(float P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return new BlUbRLRhVZtFjqdJocRYnrNVRTEu(P_0 - P_1.XHAcjfYHxobupnkeqiFjdRtqsftl, P_0 - P_1.hOOUxyzjPSHmCugYimIocEeoCnOZ);
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return P_0.JRxBWnhQlwwPGktFTDexAbegXFrzB(ref P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0, BlUbRLRhVZtFjqdJocRYnrNVRTEu P_1)
	{
		return !P_0.JRxBWnhQlwwPGktFTDexAbegXFrzB(ref P_1);
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { XHAcjfYHxobupnkeqiFjdRtqsftl, hOOUxyzjPSHmCugYimIocEeoCnOZ });
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			XHAcjfYHxobupnkeqiFjdRtqsftl.ToString(P_0, CultureInfo.CurrentCulture),
			hOOUxyzjPSHmCugYimIocEeoCnOZ.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { XHAcjfYHxobupnkeqiFjdRtqsftl, hOOUxyzjPSHmCugYimIocEeoCnOZ });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			GvNCmPFePpgwRPnXVCmFehxNQKcDb(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			XHAcjfYHxobupnkeqiFjdRtqsftl.ToString(format, formatProvider),
			hOOUxyzjPSHmCugYimIocEeoCnOZ.ToString(format, formatProvider)
		});
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return (XHAcjfYHxobupnkeqiFjdRtqsftl.GetHashCode() * 397) ^ hOOUxyzjPSHmCugYimIocEeoCnOZ.GetHashCode();
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(ref BlUbRLRhVZtFjqdJocRYnrNVRTEu P_0)
	{
		if (rlbdYkFceDqoAzgGWbJzBvjOegujb.NIYWKOoTvlXaeIxoMZMnBneCeJZH(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl, XHAcjfYHxobupnkeqiFjdRtqsftl))
		{
			return rlbdYkFceDqoAzgGWbJzBvjOegujb.NIYWKOoTvlXaeIxoMZMnBneCeJZH(P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ, hOOUxyzjPSHmCugYimIocEeoCnOZ);
		}
		return false;
	}

	public bool Equals(BlUbRLRhVZtFjqdJocRYnrNVRTEu other)
	{
		return JRxBWnhQlwwPGktFTDexAbegXFrzB(ref other);
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (!(P_0 is BlUbRLRhVZtFjqdJocRYnrNVRTEu blUbRLRhVZtFjqdJocRYnrNVRTEu))
		{
			return false;
		}
		return JRxBWnhQlwwPGktFTDexAbegXFrzB(ref blUbRLRhVZtFjqdJocRYnrNVRTEu);
	}
}
