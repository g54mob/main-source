using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;
using Rewired.Utils.Attributes;

internal class QXMSgcVznodSmSMxPAPQfqnygfQgA : hXhxJeoUValOiOciSCKQeMuVNQjcb
{
	private static bool QeADFxzKUifWyENPfraPLmgRKfIT;

	private static PidVid[] XuPjONYAZMrGWkMakITtqeJzekip;

	[CompilerGenerated]
	private static Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> m_sgdkqZWNIgaKgJEbXmPRcOlymjLk;

	[CompilerGenerated]
	private static Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> m_OrxHPCjuQjiKejKghvXVmjuPVeZE;

	private static PidVid[] dQqgEhqAPQBXlliBxxCwrlATWgoJ
	{
		get
		{
			if (XuPjONYAZMrGWkMakITtqeJzekip == null)
			{
				List<PidVid> list = new List<PidVid>
				{
					new PidVid(8201, 1406)
				};
				for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
				{
					list.Add(Consts.pidVids_sony_dualShock4[i]);
				}
				for (int j = 0; j < Consts.pidVids_sony_dualSense.Count; j++)
				{
					list.Add(Consts.pidVids_sony_dualSense[j]);
				}
				XuPjONYAZMrGWkMakITtqeJzekip = list.ToArray();
			}
			return XuPjONYAZMrGWkMakITtqeJzekip;
		}
	}

	public kmfvAbnsAlybBleITzlofpcycRap kdigdVjwyxdGuxCNaKKmXnrzbBCVA
	{
		get
		{
			kmfvAbnsAlybBleITzlofpcycRap result = default(kmfvAbnsAlybBleITzlofpcycRap);
			if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				return result;
			}
			tsCBxloSjtavBHHVzKUqIGsQvsPTA.JTDMqvEDHyjAncrkayfBjjXOIJDab(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(gZUHPXbdgzGWrVFeGoixjvyyaZGJ), ref result);
			return result;
		}
		set
		{
			if (gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.YaIsbeqMJrDLTnmdUEWywNLQIRAP(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(gZUHPXbdgzGWrVFeGoixjvyyaZGJ), kmfvAbnsAlybBleITzlofpcycRap2);
			}
		}
	}

	public IMzcsxDiCghYscFleZayNqwPSeREc SAxKeXyowFTADHijaMdGnloMuIpd
	{
		get
		{
			if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				return null;
			}
			return tsCBxloSjtavBHHVzKUqIGsQvsPTA.JoIZPaMychYWPYlhFlRLJuVwwBTf(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(gZUHPXbdgzGWrVFeGoixjvyyaZGJ));
		}
	}

	public static event Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> sgdkqZWNIgaKgJEbXmPRcOlymjLk
	{
		[CompilerGenerated]
		add
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action = QXMSgcVznodSmSMxPAPQfqnygfQgA.m_sgdkqZWNIgaKgJEbXmPRcOlymjLk;
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action2;
			do
			{
				action2 = action;
				Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> value2 = (Action<QXMSgcVznodSmSMxPAPQfqnygfQgA>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref QXMSgcVznodSmSMxPAPQfqnygfQgA.m_sgdkqZWNIgaKgJEbXmPRcOlymjLk, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action = QXMSgcVznodSmSMxPAPQfqnygfQgA.m_sgdkqZWNIgaKgJEbXmPRcOlymjLk;
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action2;
			do
			{
				action2 = action;
				Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> value2 = (Action<QXMSgcVznodSmSMxPAPQfqnygfQgA>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref QXMSgcVznodSmSMxPAPQfqnygfQgA.m_sgdkqZWNIgaKgJEbXmPRcOlymjLk, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static event Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> OrxHPCjuQjiKejKghvXVmjuPVeZE
	{
		[CompilerGenerated]
		add
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action = QXMSgcVznodSmSMxPAPQfqnygfQgA.m_OrxHPCjuQjiKejKghvXVmjuPVeZE;
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action2;
			do
			{
				action2 = action;
				Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> value2 = (Action<QXMSgcVznodSmSMxPAPQfqnygfQgA>)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref QXMSgcVznodSmSMxPAPQfqnygfQgA.m_OrxHPCjuQjiKejKghvXVmjuPVeZE, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action = QXMSgcVznodSmSMxPAPQfqnygfQgA.m_OrxHPCjuQjiKejKghvXVmjuPVeZE;
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action2;
			do
			{
				action2 = action;
				Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> value2 = (Action<QXMSgcVznodSmSMxPAPQfqnygfQgA>)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref QXMSgcVznodSmSMxPAPQfqnygfQgA.m_OrxHPCjuQjiKejKghvXVmjuPVeZE, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static void VnmaAhhlbuAvAWieWUkwqPMXUuuV()
	{
		if (QeADFxzKUifWyENPfraPLmgRKfIT)
		{
			throw new Exception(typeof(QXMSgcVznodSmSMxPAPQfqnygfQgA)?.ToString() + " already initialized.");
		}
		try
		{
			tsCBxloSjtavBHHVzKUqIGsQvsPTA.OzUCfpKHdrmqELHpRenQYmDjeVZd(ldRJqilSKoiuctjvdYzkWSsVcorP);
			tsCBxloSjtavBHHVzKUqIGsQvsPTA.zWEmxGcNgLkcyMPNidfZsxZeiWsb(AqKSKpIKJIfwzFWBPmNtMWOJCfztA);
			tsCBxloSjtavBHHVzKUqIGsQvsPTA.tgKoRNCntYDMahKELRqAyEWedItcb();
		}
		catch (Exception)
		{
			try
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.OoRbrqHjojYLlGHNTokNFILivkpfc();
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.OzUCfpKHdrmqELHpRenQYmDjeVZd(null);
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.zWEmxGcNgLkcyMPNidfZsxZeiWsb(null);
			}
			catch
			{
			}
			throw;
		}
		QeADFxzKUifWyENPfraPLmgRKfIT = true;
	}

	public static void hxvVJeNTfCkOfsqYRHGNCciaFkOL()
	{
		if (QeADFxzKUifWyENPfraPLmgRKfIT)
		{
			QXMSgcVznodSmSMxPAPQfqnygfQgA.sgdkqZWNIgaKgJEbXmPRcOlymjLk = null;
			QXMSgcVznodSmSMxPAPQfqnygfQgA.OrxHPCjuQjiKejKghvXVmjuPVeZE = null;
			try
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.OoRbrqHjojYLlGHNTokNFILivkpfc();
			}
			catch (Exception)
			{
			}
			try
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.OzUCfpKHdrmqELHpRenQYmDjeVZd(null);
			}
			catch (Exception)
			{
			}
			try
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.zWEmxGcNgLkcyMPNidfZsxZeiWsb(null);
			}
			catch (Exception)
			{
			}
			QeADFxzKUifWyENPfraPLmgRKfIT = false;
		}
	}

	public static void YJsLioqLwcYOSblyAGcyipPqfURdb(List<QXMSgcVznodSmSMxPAPQfqnygfQgA> P_0)
	{
		P_0.Clear();
		ptLEJWqNKYGsBloabxqKfrAoMUgn ptLEJWqNKYGsBloabxqKfrAoMUgn2 = new ptLEJWqNKYGsBloabxqKfrAoMUgn(tsCBxloSjtavBHHVzKUqIGsQvsPTA.MUunaBPlOYIZBnRYpgepKfaBdMLcb());
		if (ptLEJWqNKYGsBloabxqKfrAoMUgn2.XswVhxUAOPikJowiTXELsplpsiwP)
		{
			int num = (int)tsCBxloSjtavBHHVzKUqIGsQvsPTA.RlLIFFBoRWWadmltKMnScpNEQzqI(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(ptLEJWqNKYGsBloabxqKfrAoMUgn2));
			for (int i = 0; i < num; i++)
			{
				ptLEJWqNKYGsBloabxqKfrAoMUgn ptLEJWqNKYGsBloabxqKfrAoMUgn3 = new ptLEJWqNKYGsBloabxqKfrAoMUgn(tsCBxloSjtavBHHVzKUqIGsQvsPTA.EIivHDnAeezZrCIrKuKYpiXhOSxq(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(ptLEJWqNKYGsBloabxqKfrAoMUgn2), (uint)i));
				if (!ptLEJWqNKYGsBloabxqKfrAoMUgn3.XswVhxUAOPikJowiTXELsplpsiwP)
				{
					continue;
				}
				QXMSgcVznodSmSMxPAPQfqnygfQgA qXMSgcVznodSmSMxPAPQfqnygfQgA = new QXMSgcVznodSmSMxPAPQfqnygfQgA(ptLEJWqNKYGsBloabxqKfrAoMUgn3);
				YZqlbTwsTOtIXDoHALtlkvzVQSjl yZqlbTwsTOtIXDoHALtlkvzVQSjl = YZqlbTwsTOtIXDoHALtlkvzVQSjl.yajPKVFdORPcZglPMshYLAkCHAhkA(qXMSgcVznodSmSMxPAPQfqnygfQgA);
				if (yZqlbTwsTOtIXDoHALtlkvzVQSjl != null)
				{
					PidVid value = new PidVid(yZqlbTwsTOtIXDoHALtlkvzVQSjl.GWmvcmLZPqCBUOgpjbJdbfCpzvDI, yZqlbTwsTOtIXDoHALtlkvzVQSjl.wsBJIMNGmjXPTLIYItMGayUrQIrI);
					yZqlbTwsTOtIXDoHALtlkvzVQSjl.ftegaMeUwYaicakwpFDRaQBWDKzE();
					if (dQqgEhqAPQBXlliBxxCwrlATWgoJ.Contains(value))
					{
						qXMSgcVznodSmSMxPAPQfqnygfQgA.ftegaMeUwYaicakwpFDRaQBWDKzE();
						continue;
					}
				}
				P_0.Add(qXMSgcVznodSmSMxPAPQfqnygfQgA);
			}
		}
		ptLEJWqNKYGsBloabxqKfrAoMUgn2.vFuHGivmniALoFFZgGVLtrkClKKQ();
	}

	public static bool GzlLsbVsgiwhCpQQIlqucVVHahXK(ushort P_0, ushort P_1)
	{
		if (dQqgEhqAPQBXlliBxxCwrlATWgoJ.Contains(new PidVid(P_1, P_0)))
		{
			return false;
		}
		ptLEJWqNKYGsBloabxqKfrAoMUgn ptLEJWqNKYGsBloabxqKfrAoMUgn2 = new ptLEJWqNKYGsBloabxqKfrAoMUgn(tsCBxloSjtavBHHVzKUqIGsQvsPTA.MUunaBPlOYIZBnRYpgepKfaBdMLcb());
		if (!ptLEJWqNKYGsBloabxqKfrAoMUgn2.XswVhxUAOPikJowiTXELsplpsiwP)
		{
			return false;
		}
		int num = (int)tsCBxloSjtavBHHVzKUqIGsQvsPTA.RlLIFFBoRWWadmltKMnScpNEQzqI(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(ptLEJWqNKYGsBloabxqKfrAoMUgn2));
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			ptLEJWqNKYGsBloabxqKfrAoMUgn ptLEJWqNKYGsBloabxqKfrAoMUgn3 = new ptLEJWqNKYGsBloabxqKfrAoMUgn(tsCBxloSjtavBHHVzKUqIGsQvsPTA.EIivHDnAeezZrCIrKuKYpiXhOSxq(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(ptLEJWqNKYGsBloabxqKfrAoMUgn2), (uint)i));
			if (ptLEJWqNKYGsBloabxqKfrAoMUgn3.XswVhxUAOPikJowiTXELsplpsiwP)
			{
				YZqlbTwsTOtIXDoHALtlkvzVQSjl yZqlbTwsTOtIXDoHALtlkvzVQSjl = YZqlbTwsTOtIXDoHALtlkvzVQSjl.yajPKVFdORPcZglPMshYLAkCHAhkA(new QXMSgcVznodSmSMxPAPQfqnygfQgA(ptLEJWqNKYGsBloabxqKfrAoMUgn3));
				if (yZqlbTwsTOtIXDoHALtlkvzVQSjl.UaINhsNizVRwfnFZcRDXPUOkRCmJ)
				{
					flag = VQhzmCaCsdfmfhXkewKGbCkxmDeg(P_0, P_1, yZqlbTwsTOtIXDoHALtlkvzVQSjl);
					yZqlbTwsTOtIXDoHALtlkvzVQSjl.ftegaMeUwYaicakwpFDRaQBWDKzE();
				}
				ptLEJWqNKYGsBloabxqKfrAoMUgn3.vFuHGivmniALoFFZgGVLtrkClKKQ();
				if (flag)
				{
					break;
				}
			}
		}
		ptLEJWqNKYGsBloabxqKfrAoMUgn2.vFuHGivmniALoFFZgGVLtrkClKKQ();
		return flag;
	}

	private static bool VQhzmCaCsdfmfhXkewKGbCkxmDeg(ushort P_0, ushort P_1, YZqlbTwsTOtIXDoHALtlkvzVQSjl P_2)
	{
		if (vbMgcVfvjmlkZaeWIVhMHdIJjanhA(P_0, P_1, P_2.wsBJIMNGmjXPTLIYItMGayUrQIrI, P_2.GWmvcmLZPqCBUOgpjbJdbfCpzvDI))
		{
			return true;
		}
		if (P_2.psRTFbcHSUPpNkYjXQaWQwXkaRye(out var pidVid) && vbMgcVfvjmlkZaeWIVhMHdIJjanhA(P_0, P_1, pidVid.vendorId, pidVid.productId))
		{
			return true;
		}
		return false;
	}

	private static bool vbMgcVfvjmlkZaeWIVhMHdIJjanhA(ushort P_0, ushort P_1, ushort P_2, ushort P_3)
	{
		if (P_0 != P_2)
		{
			return false;
		}
		if (P_1 == P_3)
		{
			return true;
		}
		if (P_0 == 1118 && P_3 == 0)
		{
			return true;
		}
		return false;
	}

	public static QXMSgcVznodSmSMxPAPQfqnygfQgA wXsZJLbXzyoqzfIMBpmpuJiaUAu(hXhxJeoUValOiOciSCKQeMuVNQjcb P_0)
	{
		try
		{
			YEddRxIQmgTYEowryWdPAJlNvhwRA yEddRxIQmgTYEowryWdPAJlNvhwRA = tsCBxloSjtavBHHVzKUqIGsQvsPTA.ZafdXUuvSRsFmcOfRHGIFKWTxMfjA(P_0.sXczNLmFeSxKDHIlPHXKYjMMmyBb);
			if (!yEddRxIQmgTYEowryWdPAJlNvhwRA.RujSyaCXnNwcghkhrmbssZbXSmdA)
			{
				return null;
			}
			return new QXMSgcVznodSmSMxPAPQfqnygfQgA(new ptLEJWqNKYGsBloabxqKfrAoMUgn(yEddRxIQmgTYEowryWdPAJlNvhwRA));
		}
		catch (Exception)
		{
			return null;
		}
	}

	private static void RChnijNVaSRrFFRicsYpfyoCPZbs()
	{
		if (!QeADFxzKUifWyENPfraPLmgRKfIT)
		{
			throw new Exception(typeof(QXMSgcVznodSmSMxPAPQfqnygfQgA)?.ToString() + " not initialized.");
		}
	}

	[MonoPInvokeCallback(typeof(tsCBxloSjtavBHHVzKUqIGsQvsPTA.JQMCZJgwIVzxozIVtFuQMRjRhOHGA))]
	private static void ldRJqilSKoiuctjvdYzkWSsVcorP(YEddRxIQmgTYEowryWdPAJlNvhwRA P_0)
	{
		if (P_0.RujSyaCXnNwcghkhrmbssZbXSmdA)
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> action = QXMSgcVznodSmSMxPAPQfqnygfQgA.sgdkqZWNIgaKgJEbXmPRcOlymjLk;
			if (action != null)
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.JwpNGbcnRwGybIZugmhEnaaBeYut(P_0.yINGamblibFxfaelkmgDTpWGVRqM);
				action(new QXMSgcVznodSmSMxPAPQfqnygfQgA(new ptLEJWqNKYGsBloabxqKfrAoMUgn(P_0)));
			}
		}
	}

	[MonoPInvokeCallback(typeof(tsCBxloSjtavBHHVzKUqIGsQvsPTA.kGSehjbzGCuqPLWMpPmTRqfhvGrD))]
	private static void AqKSKpIKJIfwzFWBPmNtMWOJCfztA(YEddRxIQmgTYEowryWdPAJlNvhwRA P_0)
	{
		if (P_0.RujSyaCXnNwcghkhrmbssZbXSmdA)
		{
			Action<QXMSgcVznodSmSMxPAPQfqnygfQgA> orxHPCjuQjiKejKghvXVmjuPVeZE = QXMSgcVznodSmSMxPAPQfqnygfQgA.OrxHPCjuQjiKejKghvXVmjuPVeZE;
			if (orxHPCjuQjiKejKghvXVmjuPVeZE != null)
			{
				tsCBxloSjtavBHHVzKUqIGsQvsPTA.JwpNGbcnRwGybIZugmhEnaaBeYut(P_0.yINGamblibFxfaelkmgDTpWGVRqM);
				orxHPCjuQjiKejKghvXVmjuPVeZE(new QXMSgcVznodSmSMxPAPQfqnygfQgA(new ptLEJWqNKYGsBloabxqKfrAoMUgn(P_0)));
			}
		}
	}

	public QXMSgcVznodSmSMxPAPQfqnygfQgA(ptLEJWqNKYGsBloabxqKfrAoMUgn P_0)
		: base(P_0)
	{
	}

	public tvQgtDzBXDagmkAWojrVhCYhBEWs NgiFEgjJKvFEsUNiJOOgwuViTWjRA()
	{
		tvQgtDzBXDagmkAWojrVhCYhBEWs result = default(tvQgtDzBXDagmkAWojrVhCYhBEWs);
		if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
		{
			return result;
		}
		tsCBxloSjtavBHHVzKUqIGsQvsPTA.bEAIWdLLtvJtLzhkiMrbRrLeAlMKA(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(gZUHPXbdgzGWrVFeGoixjvyyaZGJ), ref result);
		return result;
	}

	public IBaNvcwPYiqrcPkMbchCPFZQrDpr GVMmLArmBuIqRwBCbZQpAtCTlHXs(GamepadButtons P_0)
	{
		if (!gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
		{
			return IBaNvcwPYiqrcPkMbchCPFZQrDpr.None;
		}
		return tsCBxloSjtavBHHVzKUqIGsQvsPTA.amfaZIcBcWKbXDxoALwaBoSQhohzB(ptLEJWqNKYGsBloabxqKfrAoMUgn.UjjASFShffxbnKNsywDaWCubBiVD(gZUHPXbdgzGWrVFeGoixjvyyaZGJ), P_0);
	}

	public virtual bool ckTplLqieTbALFApExXRPeVfzjsq(object P_0)
	{
		QXMSgcVznodSmSMxPAPQfqnygfQgA qXMSgcVznodSmSMxPAPQfqnygfQgA = P_0 as QXMSgcVznodSmSMxPAPQfqnygfQgA;
		if (UEjIAJCUaukCefmHeLVGEReUOMtOb(qXMSgcVznodSmSMxPAPQfqnygfQgA, null))
		{
			return false;
		}
		return ptLEJWqNKYGsBloabxqKfrAoMUgn.QfIffuSpTqAqCgpeEIbhJtujazqH(gZUHPXbdgzGWrVFeGoixjvyyaZGJ, qXMSgcVznodSmSMxPAPQfqnygfQgA.gZUHPXbdgzGWrVFeGoixjvyyaZGJ);
	}

	public virtual int nxwMuwPkSjDxKYxninbHdQPerXjj()
	{
		return base.GetHashCode();
	}

	public bool zEJpnoNyMGxksEAwmTwxFRepOqTy(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0)
	{
		if (UEjIAJCUaukCefmHeLVGEReUOMtOb(P_0, null) || !P_0.gZUHPXbdgzGWrVFeGoixjvyyaZGJ.XswVhxUAOPikJowiTXELsplpsiwP)
		{
			return false;
		}
		return gZUHPXbdgzGWrVFeGoixjvyyaZGJ.IjFwUCwhTVEzsfqrNMwYeEhZlxaH == P_0.gZUHPXbdgzGWrVFeGoixjvyyaZGJ.IjFwUCwhTVEzsfqrNMwYeEhZlxaH;
	}

	[SpecialName]
	public static bool UEjIAJCUaukCefmHeLVGEReUOMtOb(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		return P_0?.zEJpnoNyMGxksEAwmTwxFRepOqTy(P_1) ?? (P_1 == null);
	}

	[SpecialName]
	public static bool BrJgWArHmFwNUjRDaGdibklXFlaQ(QXMSgcVznodSmSMxPAPQfqnygfQgA P_0, QXMSgcVznodSmSMxPAPQfqnygfQgA P_1)
	{
		if (P_0 == null)
		{
			return P_1 != null;
		}
		return !P_0.zEJpnoNyMGxksEAwmTwxFRepOqTy(P_1);
	}
}
