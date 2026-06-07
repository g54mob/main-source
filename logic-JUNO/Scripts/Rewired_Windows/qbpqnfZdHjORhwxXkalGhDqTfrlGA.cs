using System;
using System.Runtime.InteropServices;

internal class qbpqnfZdHjORhwxXkalGhDqTfrlGA : IDisposable
{
	public struct GJGGKFQLaSHCwkRPFjLKHUxadXvo
	{
		private byte irzjUMSNbCeLRNxnIHfRIjdWmuGY;

		private uint uIyCXFZvpBcFLGKVZrqZAxHOqliNA;

		private int jLjeMhiiWgZaUaFHkHVbvfPBkYkbb;

		private static GJGGKFQLaSHCwkRPFjLKHUxadXvo grMXePTMYQVkTymwMXatGyleCVmW;

		public byte KOZqLigvYhIXfnPclSOflXuwtxnv => irzjUMSNbCeLRNxnIHfRIjdWmuGY;

		public uint VugVLbxHCzOEPlNMYEreiheAvwwr => uIyCXFZvpBcFLGKVZrqZAxHOqliNA;

		public int GAFuKktkJuLmRFurYFMaUPTOPSbg => jLjeMhiiWgZaUaFHkHVbvfPBkYkbb;

		public static GJGGKFQLaSHCwkRPFjLKHUxadXvo gxBpuldTGzjRnRWKQNmVVbQSxaTC => grMXePTMYQVkTymwMXatGyleCVmW;

		public GJGGKFQLaSHCwkRPFjLKHUxadXvo(byte P_0, uint P_1, int P_2)
		{
			irzjUMSNbCeLRNxnIHfRIjdWmuGY = P_0;
			uIyCXFZvpBcFLGKVZrqZAxHOqliNA = P_1;
			jLjeMhiiWgZaUaFHkHVbvfPBkYkbb = P_2;
			if (jLjeMhiiWgZaUaFHkHVbvfPBkYkbb < 0)
			{
				jLjeMhiiWgZaUaFHkHVbvfPBkYkbb = 0;
			}
		}
	}

	private const byte lWIRouUvzFHOTErgXbflAydGsuDG = 254;

	private uint eAqbOTxYtpqkNVmJKNKrPdpGFNaE;

	private int PHockyeTsiZzrKiMVoRZYluEMxJF;

	private unsafe byte* KXbUiIqTHLMTRtoIqNmDafucJnUo;

	private byte QLjOtOyZGsZgJhgOUarfamLrxBCP;

	private bool ECosEgnMSvgeLAZcOLZEZvqNvdLc;

	private bool QXigbkBlVYLEEjrobSSDMZjzzBKzb;

	public int RsVDFYzAPqMvEznvRJXiWMCRqWTR => PHockyeTsiZzrKiMVoRZYluEMxJF;

	public unsafe qbpqnfZdHjORhwxXkalGhDqTfrlGA(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		PHockyeTsiZzrKiMVoRZYluEMxJF = P_0;
		eAqbOTxYtpqkNVmJKNKrPdpGFNaE = 0u;
		KXbUiIqTHLMTRtoIqNmDafucJnUo = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool rekVkTXmsUAvyIkTMvateEXeZEme(IntPtr P_0, int P_1, out GJGGKFQLaSHCwkRPFjLKHUxadXvo P_2)
	{
		if (KXbUiIqTHLMTRtoIqNmDafucJnUo == null || P_1 <= 0)
		{
			P_2 = default(GJGGKFQLaSHCwkRPFjLKHUxadXvo);
			return false;
		}
		if (P_1 > PHockyeTsiZzrKiMVoRZYluEMxJF)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)eAqbOTxYtpqkNVmJKNKrPdpGFNaE + P_1) >= PHockyeTsiZzrKiMVoRZYluEMxJF)
		{
			eAqbOTxYtpqkNVmJKNKrPdpGFNaE = 0u;
			if (QLjOtOyZGsZgJhgOUarfamLrxBCP == 254)
			{
				QLjOtOyZGsZgJhgOUarfamLrxBCP = 0;
				ECosEgnMSvgeLAZcOLZEZvqNvdLc = true;
			}
			else
			{
				QLjOtOyZGsZgJhgOUarfamLrxBCP++;
			}
		}
		FTdbbIUhAgYSHUHmiEJUirkRZXhf.aMfjHZcaRTEaGMgEyfEfYMWsIJAN(KXbUiIqTHLMTRtoIqNmDafucJnUo + eAqbOTxYtpqkNVmJKNKrPdpGFNaE, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new GJGGKFQLaSHCwkRPFjLKHUxadXvo(QLjOtOyZGsZgJhgOUarfamLrxBCP, eAqbOTxYtpqkNVmJKNKrPdpGFNaE, P_1);
		eAqbOTxYtpqkNVmJKNKrPdpGFNaE += (uint)P_1;
		return true;
	}

	public int ssvBLbFncpczGOKPCIGVErDuKXWEA(GJGGKFQLaSHCwkRPFjLKHUxadXvo P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!IJjqiHpaXDVZgTSoPmQkhdFWTYzF(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(RzyjqyjZUUeGzwTHeLvCEFTjkoHS(P_0), P_1, 0, P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg);
		return P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg;
	}

	public unsafe int VzGgXWcfYagwZdXVhtCVwRnvAwWw(GJGGKFQLaSHCwkRPFjLKHUxadXvo P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!IJjqiHpaXDVZgTSoPmQkhdFWTYzF(ref P_0))
		{
			return -1;
		}
		FTdbbIUhAgYSHUHmiEJUirkRZXhf.aMfjHZcaRTEaGMgEyfEfYMWsIJAN((void*)P_1, KXbUiIqTHLMTRtoIqNmDafucJnUo, new UIntPtr((uint)P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg));
		return P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg;
	}

	public unsafe IntPtr RzyjqyjZUUeGzwTHeLvCEFTjkoHS(GJGGKFQLaSHCwkRPFjLKHUxadXvo P_0)
	{
		if (KXbUiIqTHLMTRtoIqNmDafucJnUo == null || !IJjqiHpaXDVZgTSoPmQkhdFWTYzF(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(KXbUiIqTHLMTRtoIqNmDafucJnUo + P_0.VugVLbxHCzOEPlNMYEreiheAvwwr);
	}

	public unsafe bool DSYaxjHOklAfGcSAINkDiBZJjODwB(GJGGKFQLaSHCwkRPFjLKHUxadXvo P_0, out IntPtr P_1)
	{
		if (KXbUiIqTHLMTRtoIqNmDafucJnUo == null || !IJjqiHpaXDVZgTSoPmQkhdFWTYzF(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(KXbUiIqTHLMTRtoIqNmDafucJnUo + P_0.VugVLbxHCzOEPlNMYEreiheAvwwr);
		return true;
	}

	private bool IJjqiHpaXDVZgTSoPmQkhdFWTYzF(ref GJGGKFQLaSHCwkRPFjLKHUxadXvo P_0)
	{
		int num = P_0.GAFuKktkJuLmRFurYFMaUPTOPSbg;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.KOZqLigvYhIXfnPclSOflXuwtxnv;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != QLjOtOyZGsZgJhgOUarfamLrxBCP)
		{
			if (!ECosEgnMSvgeLAZcOLZEZvqNvdLc)
			{
				if (num2 + 1 != QLjOtOyZGsZgJhgOUarfamLrxBCP)
				{
					return false;
				}
			}
			else if (num2 > QLjOtOyZGsZgJhgOUarfamLrxBCP)
			{
				if (QLjOtOyZGsZgJhgOUarfamLrxBCP != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != QLjOtOyZGsZgJhgOUarfamLrxBCP)
			{
				return false;
			}
			if (P_0.VugVLbxHCzOEPlNMYEreiheAvwwr < eAqbOTxYtpqkNVmJKNKrPdpGFNaE)
			{
				return false;
			}
		}
		else if (P_0.VugVLbxHCzOEPlNMYEreiheAvwwr + num > eAqbOTxYtpqkNVmJKNKrPdpGFNaE)
		{
			return false;
		}
		if (P_0.VugVLbxHCzOEPlNMYEreiheAvwwr + num > PHockyeTsiZzrKiMVoRZYluEMxJF)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		mQyZduofWQEdMFYfdeULFXHgqbuoB(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void eipmdiEBPRMnOthpmaMVkGNypPeGb()
	{
		try
		{
			mQyZduofWQEdMFYfdeULFXHgqbuoB(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void mQyZduofWQEdMFYfdeULFXHgqbuoB(bool P_0)
	{
		if (!QXigbkBlVYLEEjrobSSDMZjzzBKzb)
		{
			if (KXbUiIqTHLMTRtoIqNmDafucJnUo != null)
			{
				Marshal.FreeHGlobal((IntPtr)KXbUiIqTHLMTRtoIqNmDafucJnUo);
			}
			QXigbkBlVYLEEjrobSSDMZjzzBKzb = true;
		}
	}
}
