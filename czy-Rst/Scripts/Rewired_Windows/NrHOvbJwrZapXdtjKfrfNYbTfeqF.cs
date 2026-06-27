using System;
using Rewired.Utils.Classes.Data;

internal class NrHOvbJwrZapXdtjKfrfNYbTfeqF : QAOlVgyStIKpRmoWAGbpIzIYHZwjA
{
	public enum RniBICdtHlkUssfYMpLuHEIKDvjJb
	{
		Default = 0,
		Custom = 1
	}

	public int zWsePkJmjvZoiGZvNQSEGSTcosyy;

	public double UqTbToJsfQCqXqdVRVYlvYpxqpmM;

	public readonly int FxgKWWyuVnmkUtNrzHdtTJpVgHVu;

	public readonly int osfPwwHpKNQEBmdBDErGuDMLrUhH;

	public readonly RniBICdtHlkUssfYMpLuHEIKDvjJb AtiXwLqCfFCJTHfJYdFANrRNsbSAA;

	private Func<int, int> KFEszrBAXWdEWpxZfSbcKJeVTKjG;

	public NrHOvbJwrZapXdtjKfrfNYbTfeqF(byte P_0, HIDInfo P_1, RniBICdtHlkUssfYMpLuHEIKDvjJb P_2)
		: base(P_0, P_1)
	{
		AtiXwLqCfFCJTHfJYdFANrRNsbSAA = P_2;
		FxgKWWyuVnmkUtNrzHdtTJpVgHVu = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		osfPwwHpKNQEBmdBDErGuDMLrUhH = P_1.dataIndex;
	}

	public NrHOvbJwrZapXdtjKfrfNYbTfeqF(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, RniBICdtHlkUssfYMpLuHEIKDvjJb.Custom)
	{
		KFEszrBAXWdEWpxZfSbcKJeVTKjG = P_2;
	}

	public virtual void iwDTQfshatRsKveGjEIxyredEYas(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != gijfZOkdrxcTAgIIOZwUzEqukUux)
		{
			return;
		}
		UqTbToJsfQCqXqdVRVYlvYpxqpmM = P_1;
		if (FxgKWWyuVnmkUtNrzHdtTJpVgHVu == 1)
		{
			zWsePkJmjvZoiGZvNQSEGSTcosyy = P_0[osfPwwHpKNQEBmdBDErGuDMLrUhH];
		}
		else
		{
			zWsePkJmjvZoiGZvNQSEGSTcosyy = 0;
			for (int i = 0; i < FxgKWWyuVnmkUtNrzHdtTJpVgHVu; i++)
			{
				zWsePkJmjvZoiGZvNQSEGSTcosyy |= P_0[osfPwwHpKNQEBmdBDErGuDMLrUhH + i] << 8 * i;
			}
		}
		if (AtiXwLqCfFCJTHfJYdFANrRNsbSAA == RniBICdtHlkUssfYMpLuHEIKDvjJb.Custom && KFEszrBAXWdEWpxZfSbcKJeVTKjG != null)
		{
			zWsePkJmjvZoiGZvNQSEGSTcosyy = KFEszrBAXWdEWpxZfSbcKJeVTKjG(zWsePkJmjvZoiGZvNQSEGSTcosyy);
		}
	}
}
