using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

internal abstract class CcGgbpntamtnacmabegPksrcgakT : IPrefetch
{
	protected struct SngFPGiFSNRQDdUtntlDROkQQRttA : IEquatable<SngFPGiFSNRQDdUtntlDROkQQRttA>
	{
		public KeyedGlyph ymPAbTHTpGfSWXdoAUFzwrRxqghR;

		public int YrexIqIdfQDlUWwieDIrGfJzClSLA;

		public SngFPGiFSNRQDdUtntlDROkQQRttA(KeyedGlyph P_0, int P_1)
		{
			ymPAbTHTpGfSWXdoAUFzwrRxqghR = P_0;
			YrexIqIdfQDlUWwieDIrGfJzClSLA = P_1;
		}

		public bool PHPgyrMcbWQEIpIrlCbjrsYQoAbS(object P_0)
		{
			if (!(P_0 is SngFPGiFSNRQDdUtntlDROkQQRttA sngFPGiFSNRQDdUtntlDROkQQRttA))
			{
				return false;
			}
			if (sngFPGiFSNRQDdUtntlDROkQQRttA.ymPAbTHTpGfSWXdoAUFzwrRxqghR == ymPAbTHTpGfSWXdoAUFzwrRxqghR)
			{
				return sngFPGiFSNRQDdUtntlDROkQQRttA.YrexIqIdfQDlUWwieDIrGfJzClSLA == YrexIqIdfQDlUWwieDIrGfJzClSLA;
			}
			return false;
		}

		public int ATwQoxwBXnBjjjROWkbwfoEDIychB()
		{
			return (17 * 29 + ymPAbTHTpGfSWXdoAUFzwrRxqghR.GetHashCode()) * 29 + YrexIqIdfQDlUWwieDIrGfJzClSLA.GetHashCode();
		}

		public bool Equals(SngFPGiFSNRQDdUtntlDROkQQRttA other)
		{
			if (ymPAbTHTpGfSWXdoAUFzwrRxqghR == other.ymPAbTHTpGfSWXdoAUFzwrRxqghR)
			{
				return YrexIqIdfQDlUWwieDIrGfJzClSLA == other.YrexIqIdfQDlUWwieDIrGfJzClSLA;
			}
			return false;
		}

		bool IEquatable<SngFPGiFSNRQDdUtntlDROkQQRttA>.Equals(SngFPGiFSNRQDdUtntlDROkQQRttA other)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Equals
			return this.Equals(other);
		}

		[SpecialName]
		public static bool sckUpWsRaJkRXfhDjjduGdrBdmGDb(SngFPGiFSNRQDdUtntlDROkQQRttA P_0, SngFPGiFSNRQDdUtntlDROkQQRttA P_1)
		{
			return P_0.Equals(P_1);
		}

		[SpecialName]
		public static bool WapUeBcQGYTVsvbVNoakXhDKofZb(SngFPGiFSNRQDdUtntlDROkQQRttA P_0, SngFPGiFSNRQDdUtntlDROkQQRttA P_1)
		{
			return !P_0.Equals(P_1);
		}
	}

	private IkNokIafnDXAZobQNzBQDEduXYfJ ESqpSfqEQUmfLaxoNUufQFkHCbxB;

	protected readonly KeyedGlyph MninviTzVnRKFNfQLVVgWmdnAoOy;

	private Id yIbegCxVnyDnMfDLyxsuvpCZPYnI;

	private readonly Dictionary<int, List<SngFPGiFSNRQDdUtntlDROkQQRttA>> qGaclZyakeGOxdPLWaLugPMdFRWe;

	private bool WyiOcZadbLplGjVDLVsHjwFxmfab;

	protected bool ySHaCBnHtJmvKaXECDTaZasgjIlI => WyiOcZadbLplGjVDLVsHjwFxmfab;

	public abstract object ITvJcTdLSwZWFxvxmcUsUPCUdqCh { get; }

	public abstract string BDdjaOSiBsDOcTLxjYvPPGeVYraO { get; }

	protected CcGgbpntamtnacmabegPksrcgakT()
	{
		MninviTzVnRKFNfQLVVgWmdnAoOy = new KeyedGlyph();
		qGaclZyakeGOxdPLWaLugPMdFRWe = new Dictionary<int, List<SngFPGiFSNRQDdUtntlDROkQQRttA>>();
	}

	protected CcGgbpntamtnacmabegPksrcgakT(IkNokIafnDXAZobQNzBQDEduXYfJ P_0)
		: this()
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		ESqpSfqEQUmfLaxoNUufQFkHCbxB = P_0;
	}

	public void CrecaAwIQUxrscBNzONghtrreGhJ()
	{
		FcncTSBCwiNnXDcFSOkJhPhDZZOH();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			oRVHAZrlknBMDEcGKbVwMQQatoQe();
		}
	}

	protected virtual void FcncTSBCwiNnXDcFSOkJhPhDZZOH()
	{
		IdERhFjOUbXUgdMSijcjxSURGINg();
		rTBXWbwPnflrRcupkkgNEEmXswWs();
		GlyphManager.Add(this, ref yIbegCxVnyDnMfDLyxsuvpCZPYnI);
		WyiOcZadbLplGjVDLVsHjwFxmfab = true;
	}

	public virtual void IdERhFjOUbXUgdMSijcjxSURGINg()
	{
		ennyvtcJFXqxgKPuPbwKahdNmfOA();
		GlyphManager.Remove(ref yIbegCxVnyDnMfDLyxsuvpCZPYnI);
		WyiOcZadbLplGjVDLVsHjwFxmfab = false;
	}

	public virtual void NgvSmCyfgtkxZQxmcuFMzgwRamCM(IkNokIafnDXAZobQNzBQDEduXYfJ P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (P_0 != ESqpSfqEQUmfLaxoNUufQFkHCbxB)
		{
			if (ESqpSfqEQUmfLaxoNUufQFkHCbxB != null)
			{
				ennyvtcJFXqxgKPuPbwKahdNmfOA();
			}
			ESqpSfqEQUmfLaxoNUufQFkHCbxB = P_0;
			CrecaAwIQUxrscBNzONghtrreGhJ();
		}
	}

	public virtual void wCmNcQAZDUjwxibJrcPsyYorMKWG()
	{
		MninviTzVnRKFNfQLVVgWmdnAoOy.Clear();
	}

	public virtual bool vJkPAvTOHaVyfZbkDySJwPQgsDUF(CcGgbpntamtnacmabegPksrcgakT P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!object.Equals(GetType(), P_0.GetType()))
		{
			return false;
		}
		if (ESqpSfqEQUmfLaxoNUufQFkHCbxB == null != (P_0.ESqpSfqEQUmfLaxoNUufQFkHCbxB == null))
		{
			return false;
		}
		if (ESqpSfqEQUmfLaxoNUufQFkHCbxB != null && (!string.Equals(ESqpSfqEQUmfLaxoNUufQFkHCbxB.keyCategory, P_0.ESqpSfqEQUmfLaxoNUufQFkHCbxB.keyCategory, StringComparison.Ordinal) || !string.Equals(ESqpSfqEQUmfLaxoNUufQFkHCbxB.key, P_0.ESqpSfqEQUmfLaxoNUufQFkHCbxB.key, StringComparison.Ordinal)))
		{
			return false;
		}
		return true;
	}

	protected virtual void ennyvtcJFXqxgKPuPbwKahdNmfOA()
	{
		MninviTzVnRKFNfQLVVgWmdnAoOy.Clear();
		qGaclZyakeGOxdPLWaLugPMdFRWe.Clear();
	}

	protected IkNokIafnDXAZobQNzBQDEduXYfJ fReLfzPhSCfLTAzobjWfyqjTDxEt()
	{
		return ESqpSfqEQUmfLaxoNUufQFkHCbxB;
	}

	protected virtual void oRVHAZrlknBMDEcGKbVwMQQatoQe()
	{
		_ = ITvJcTdLSwZWFxvxmcUsUPCUdqCh;
	}

	void IPrefetch.Prefetch()
	{
		oRVHAZrlknBMDEcGKbVwMQQatoQe();
	}

	protected virtual void bZxCisrXsZvjOLUJGBVOKDBOCrlT(int P_0)
	{
	}

	protected virtual void rTBXWbwPnflrRcupkkgNEEmXswWs()
	{
	}

	protected virtual void yDRfdccunXmqJdleFupgSUzbJDcMc(int P_0, SngFPGiFSNRQDdUtntlDROkQQRttA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) != 0)
			{
				if (!qGaclZyakeGOxdPLWaLugPMdFRWe.TryGetValue(num, out var value))
				{
					value = new List<SngFPGiFSNRQDdUtntlDROkQQRttA>();
					qGaclZyakeGOxdPLWaLugPMdFRWe[num] = value;
				}
				if (!value.Contains(P_1))
				{
					value.Add(P_1);
				}
			}
		}
	}

	protected virtual void WmmhxBRyaXEfGrnqqanDeifJjpok(int P_0, SngFPGiFSNRQDdUtntlDROkQQRttA P_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !qGaclZyakeGOxdPLWaLugPMdFRWe.TryGetValue(num, out var value))
			{
				continue;
			}
			for (int num2 = value.Count - 1; num2 >= 0; num2--)
			{
				if (SngFPGiFSNRQDdUtntlDROkQQRttA.sckUpWsRaJkRXfhDjjduGdrBdmGDb(value[num2], P_1))
				{
					value.RemoveAt(num2);
				}
			}
		}
	}

	protected virtual void ZijjNbcjtNDoOooGWeXrwQkaSDnl(int P_0)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((P_0 & num) == 0 || !qGaclZyakeGOxdPLWaLugPMdFRWe.TryGetValue(num, out var value))
			{
				continue;
			}
			int count = value.Count;
			for (int j = 0; j < count; j++)
			{
				if (value[j].YrexIqIdfQDlUWwieDIrGfJzClSLA != 0)
				{
					bZxCisrXsZvjOLUJGBVOKDBOCrlT(value[j].YrexIqIdfQDlUWwieDIrGfJzClSLA);
				}
				if (value[j].ymPAbTHTpGfSWXdoAUFzwrRxqghR != null)
				{
					value[j].ymPAbTHTpGfSWXdoAUFzwrRxqghR.Clear();
				}
			}
		}
	}
}
