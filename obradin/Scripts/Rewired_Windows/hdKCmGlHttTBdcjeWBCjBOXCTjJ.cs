using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.HID;
using Rewired.Utils;

internal class hdKCmGlHttTBdcjeWBCjBOXCTjJ : IDisposable, DHWnNpDFmdbjWxSotOMmAjnxIWX
{
	protected delegate VOwBPRSIcgMbwNNxsMOAWsKZwrz cpiKKHkkSdeftmWiFLeNYHlhFVH(int timeout);

	protected delegate cIsqeClJDjClFdJDnHdnzuXgkan LknZpWtGpBDgGtobTWVYkHLQnzz(int timeout);

	private delegate bool HgrCmqaRDkXcHqtcBytLfuzPtHq(byte[] data, int timeout);

	private delegate bool tZJcEsCaOsQBmdggHnajxtCfwDfx(byte[] data, int timeout, bool setOutputReportDirectly);

	private delegate bool riAySsKzpSVxYGEqECzeNGVHyGL(cIsqeClJDjClFdJDnHdnzuXgkan report, int timeout);

	public const int YLIQOOuNjDIZatqhJAWluFhNHNzA = 255;

	private const int TgHBWyomGbyaXVPLQRWCpDsragw = 250;

	private CVZaCqDOTpbbCvnGjtgsWvbZvoz fSVgTvcTnxbZTpwTcIWPmiegINYd;

	private NGxEWsoDQchsffJtOvulqVzQfUzs JOWjpaIWLqFYaxmyqgNPqkAGGnd;

	private readonly string eWUHHxYZZZRykauFSqpCyvANlDB;

	private readonly string iufetWAkfsCRoMgLqadxMkhwFLWm;

	private readonly string mrVqELiWgARrEiJbGdqXkNSFPWi;

	private readonly string QWVdvsKoWWfEvuBabBDZBWElfvU;

	private readonly atMUBsjqMZcztvgByyqIWUONwcH FCdNkUIFdLEbZeitMOXssrUgkRk;

	private readonly string IGwBqVihXInEfQfSMYaccExvhmS;

	private readonly int uoOXKtHQKtrLXkSCezltCCvfyiv;

	private readonly int zZpPwiaDFDcBLcdAHiWOIzPOSBe;

	private readonly bool oUOyfEydZGCKTiyYNrBHeTrXupe;

	private readonly string WyfijsRMQqmTZOCXCiFxChTQbXk;

	private readonly WRmWIdgRNTmJYmlFGkqlcOyQAuac ZuHfqjwMLCwtfxJOubKGNtEdxth;

	private readonly fVWXbOYCdWeFCJUBVXNatWMsbvp[] HNfCjaHajpavJgMKpwEStoDkvcyr;

	private readonly MFUrcluqOBPEvSbzhRQjzcrDggKC[] TxxrjCADZkqeqQlwLhCHogOBTiJ;

	private rTzbEMDvKHZoPAqwvPfaoLyrXgi EaVbpQCQLRmcoCxtXqVaTWrpFfEe;

	private rTzbEMDvKHZoPAqwvPfaoLyrXgi VrxiVfUWivGsbUhSLcXsOQKIROd;

	private readonly SiZtOefRmLzgXdKfHZdgFVMafmw ayujohCDXUEiFjcVoYbBGjAOgpN;

	private bool OenbCAjkGAAFERiMFUNIkjkQqb;

	private byte[] cEYnsvdZEgpKUOcsxEpoXmVeOaF;

	private FAybFIUyhQQoIUWFiuSraaiMBJE.uMDGCDVqhCpkSZqAjCaSmJeGbpP plKwCTrbKnaCcOCEtDiFctwsJyq;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	[CompilerGenerated]
	private IntPtr DQwmlIHVvSSbflvmgPuNqcnQPgq;

	[CompilerGenerated]
	private bool SePfqxHlkWBIMiGQftcjEHltlsJ;

	public IntPtr Handle
	{
		[CompilerGenerated]
		get
		{
			return DQwmlIHVvSSbflvmgPuNqcnQPgq;
		}
		[CompilerGenerated]
		private set
		{
			DQwmlIHVvSSbflvmgPuNqcnQPgq = value;
		}
	}

	public bool IsOpen
	{
		[CompilerGenerated]
		get
		{
			return SePfqxHlkWBIMiGQftcjEHltlsJ;
		}
		[CompilerGenerated]
		private set
		{
			SePfqxHlkWBIMiGQftcjEHltlsJ = value;
		}
	}

	public bool IsConnected
	{
		get
		{
			return qRcrmPWSlvohNRTlmCdEtNVJlYH.bxkbtDHUhtfxsVpGHlQtNwqQzBh(iufetWAkfsCRoMgLqadxMkhwFLWm);
		}
	}

	public string Description
	{
		get
		{
			return eWUHHxYZZZRykauFSqpCyvANlDB;
		}
	}

	public WRmWIdgRNTmJYmlFGkqlcOyQAuac Capabilities
	{
		get
		{
			return ZuHfqjwMLCwtfxJOubKGNtEdxth;
		}
	}

	public fVWXbOYCdWeFCJUBVXNatWMsbvp[] ButtonCapabilities
	{
		get
		{
			return HNfCjaHajpavJgMKpwEStoDkvcyr;
		}
	}

	public MFUrcluqOBPEvSbzhRQjzcrDggKC[] ValueCapabilities
	{
		get
		{
			return TxxrjCADZkqeqQlwLhCHogOBTiJ;
		}
	}

	public atMUBsjqMZcztvgByyqIWUONwcH Attributes
	{
		get
		{
			return FCdNkUIFdLEbZeitMOXssrUgkRk;
		}
	}

	public string DevicePath
	{
		get
		{
			return iufetWAkfsCRoMgLqadxMkhwFLWm;
		}
	}

	public string DevicePathStripped
	{
		get
		{
			return mrVqELiWgARrEiJbGdqXkNSFPWi;
		}
	}

	public string InstanceId
	{
		get
		{
			return QWVdvsKoWWfEvuBabBDZBWElfvU;
		}
	}

	public string Manufacturer
	{
		get
		{
			return IGwBqVihXInEfQfSMYaccExvhmS;
		}
	}

	public int HubId
	{
		get
		{
			return uoOXKtHQKtrLXkSCezltCCvfyiv;
		}
	}

	public int PortId
	{
		get
		{
			return zZpPwiaDFDcBLcdAHiWOIzPOSBe;
		}
	}

	public bool IsBluetoothDevice
	{
		get
		{
			return oUOyfEydZGCKTiyYNrBHeTrXupe;
		}
	}

	public string BluetoothDeviceName
	{
		get
		{
			return WyfijsRMQqmTZOCXCiFxChTQbXk;
		}
	}

	public bool HasLocationInfo
	{
		get
		{
			if (zZpPwiaDFDcBLcdAHiWOIzPOSBe >= 0)
			{
				return uoOXKtHQKtrLXkSCezltCCvfyiv >= 0;
			}
			return false;
		}
	}

	public bool MonitorDeviceEvents
	{
		get
		{
			return OenbCAjkGAAFERiMFUNIkjkQqb;
		}
		set
		{
			if (value & !OenbCAjkGAAFERiMFUNIkjkQqb)
			{
				ayujohCDXUEiFjcVoYbBGjAOgpN.qbpCLNKEvBOJKYdlcpNePfobhLw();
			}
			OenbCAjkGAAFERiMFUNIkjkQqb = value;
		}
	}

	public event CVZaCqDOTpbbCvnGjtgsWvbZvoz Inserted
	{
		add
		{
			CVZaCqDOTpbbCvnGjtgsWvbZvoz cVZaCqDOTpbbCvnGjtgsWvbZvoz = fSVgTvcTnxbZTpwTcIWPmiegINYd;
			CVZaCqDOTpbbCvnGjtgsWvbZvoz cVZaCqDOTpbbCvnGjtgsWvbZvoz2;
			do
			{
				cVZaCqDOTpbbCvnGjtgsWvbZvoz2 = cVZaCqDOTpbbCvnGjtgsWvbZvoz;
				CVZaCqDOTpbbCvnGjtgsWvbZvoz value2 = (CVZaCqDOTpbbCvnGjtgsWvbZvoz)Delegate.Combine(cVZaCqDOTpbbCvnGjtgsWvbZvoz2, value);
				cVZaCqDOTpbbCvnGjtgsWvbZvoz = Interlocked.CompareExchange(ref fSVgTvcTnxbZTpwTcIWPmiegINYd, value2, cVZaCqDOTpbbCvnGjtgsWvbZvoz2);
			}
			while ((object)cVZaCqDOTpbbCvnGjtgsWvbZvoz != cVZaCqDOTpbbCvnGjtgsWvbZvoz2);
		}
		remove
		{
			CVZaCqDOTpbbCvnGjtgsWvbZvoz cVZaCqDOTpbbCvnGjtgsWvbZvoz = fSVgTvcTnxbZTpwTcIWPmiegINYd;
			CVZaCqDOTpbbCvnGjtgsWvbZvoz cVZaCqDOTpbbCvnGjtgsWvbZvoz2;
			do
			{
				cVZaCqDOTpbbCvnGjtgsWvbZvoz2 = cVZaCqDOTpbbCvnGjtgsWvbZvoz;
				CVZaCqDOTpbbCvnGjtgsWvbZvoz value2 = (CVZaCqDOTpbbCvnGjtgsWvbZvoz)Delegate.Remove(cVZaCqDOTpbbCvnGjtgsWvbZvoz2, value);
				cVZaCqDOTpbbCvnGjtgsWvbZvoz = Interlocked.CompareExchange(ref fSVgTvcTnxbZTpwTcIWPmiegINYd, value2, cVZaCqDOTpbbCvnGjtgsWvbZvoz2);
			}
			while ((object)cVZaCqDOTpbbCvnGjtgsWvbZvoz != cVZaCqDOTpbbCvnGjtgsWvbZvoz2);
		}
	}

	public event NGxEWsoDQchsffJtOvulqVzQfUzs Removed
	{
		add
		{
			NGxEWsoDQchsffJtOvulqVzQfUzs nGxEWsoDQchsffJtOvulqVzQfUzs = JOWjpaIWLqFYaxmyqgNPqkAGGnd;
			NGxEWsoDQchsffJtOvulqVzQfUzs nGxEWsoDQchsffJtOvulqVzQfUzs2;
			do
			{
				nGxEWsoDQchsffJtOvulqVzQfUzs2 = nGxEWsoDQchsffJtOvulqVzQfUzs;
				NGxEWsoDQchsffJtOvulqVzQfUzs value2 = (NGxEWsoDQchsffJtOvulqVzQfUzs)Delegate.Combine(nGxEWsoDQchsffJtOvulqVzQfUzs2, value);
				nGxEWsoDQchsffJtOvulqVzQfUzs = Interlocked.CompareExchange(ref JOWjpaIWLqFYaxmyqgNPqkAGGnd, value2, nGxEWsoDQchsffJtOvulqVzQfUzs2);
			}
			while ((object)nGxEWsoDQchsffJtOvulqVzQfUzs != nGxEWsoDQchsffJtOvulqVzQfUzs2);
		}
		remove
		{
			NGxEWsoDQchsffJtOvulqVzQfUzs nGxEWsoDQchsffJtOvulqVzQfUzs = JOWjpaIWLqFYaxmyqgNPqkAGGnd;
			NGxEWsoDQchsffJtOvulqVzQfUzs nGxEWsoDQchsffJtOvulqVzQfUzs2;
			do
			{
				nGxEWsoDQchsffJtOvulqVzQfUzs2 = nGxEWsoDQchsffJtOvulqVzQfUzs;
				NGxEWsoDQchsffJtOvulqVzQfUzs value2 = (NGxEWsoDQchsffJtOvulqVzQfUzs)Delegate.Remove(nGxEWsoDQchsffJtOvulqVzQfUzs2, value);
				nGxEWsoDQchsffJtOvulqVzQfUzs = Interlocked.CompareExchange(ref JOWjpaIWLqFYaxmyqgNPqkAGGnd, value2, nGxEWsoDQchsffJtOvulqVzQfUzs2);
			}
			while ((object)nGxEWsoDQchsffJtOvulqVzQfUzs != nGxEWsoDQchsffJtOvulqVzQfUzs2);
		}
	}

	[CustomObfuscation(rename = false)]
	internal hdKCmGlHttTBdcjeWBCjBOXCTjJ(string devicePath, string instanceId, string description, string manufacturer, int hubId, int portId, bool isBluetoothDevice, string bluetoothDeviceName)
	{
		ayujohCDXUEiFjcVoYbBGjAOgpN = new SiZtOefRmLzgXdKfHZdgFVMafmw(this);
		ayujohCDXUEiFjcVoYbBGjAOgpN.Inserted += UWpaVViNLfuwzpIJUeRTdaWyPgzO;
		ayujohCDXUEiFjcVoYbBGjAOgpN.Removed += tqracJkLXlJzWDLWlbByurYtOegb;
		iufetWAkfsCRoMgLqadxMkhwFLWm = devicePath;
		mrVqELiWgARrEiJbGdqXkNSFPWi = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(devicePath);
		QWVdvsKoWWfEvuBabBDZBWElfvU = instanceId;
		eWUHHxYZZZRykauFSqpCyvANlDB = StringTools.SanitizeDeviceString(description);
		IGwBqVihXInEfQfSMYaccExvhmS = StringTools.SanitizeDeviceString(manufacturer);
		uoOXKtHQKtrLXkSCezltCCvfyiv = hubId;
		zZpPwiaDFDcBLcdAHiWOIzPOSBe = portId;
		oUOyfEydZGCKTiyYNrBHeTrXupe = isBluetoothDevice;
		WyfijsRMQqmTZOCXCiFxChTQbXk = StringTools.SanitizeDeviceString(bluetoothDeviceName);
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u);
			FCdNkUIFdLEbZeitMOXssrUgkRk = bSXGqWVEHRhIfcbfdsDduOfUoxu(intPtr);
			ZuHfqjwMLCwtfxJOubKGNtEdxth = hzzRZCRvrUlctPxUbwHsbmFtIfM(intPtr);
			HNfCjaHajpavJgMKpwEStoDkvcyr = XJgmOpfFZmkymXDVcgzheTCnUVMB(intPtr, 0, ZuHfqjwMLCwtfxJOubKGNtEdxth.NumberInputButtonCaps);
			TxxrjCADZkqeqQlwLhCHogOBTiJ = kzNgqMHsFmqUECCpDtsZeDOFywY(intPtr, 0, ZuHfqjwMLCwtfxJOubKGNtEdxth.NumberInputValueCaps);
			BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			intPtr = IntPtr.Zero;
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format("Error querying HID device \"{0}\" at location {1}.\nException Message: {2}\nStack Trace: {3}", devicePath, intPtr, ex.Message, ex.StackTrace), ex);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
				}
				catch
				{
				}
			}
		}
	}

	private hdKCmGlHttTBdcjeWBCjBOXCTjJ(atMUBsjqMZcztvgByyqIWUONwcH attributes, WRmWIdgRNTmJYmlFGkqlcOyQAuac capabilities, fVWXbOYCdWeFCJUBVXNatWMsbvp[] buttonCapabilities, MFUrcluqOBPEvSbzhRQjzcrDggKC[] valueCapabilities)
	{
		string text = "SIMULATED DEVICE";
		string text2 = "MANUFACTURER";
		string text3 = "SIMULATED";
		string qWVdvsKoWWfEvuBabBDZBWElfvU = "SIMULATED";
		iufetWAkfsCRoMgLqadxMkhwFLWm = text3;
		mrVqELiWgARrEiJbGdqXkNSFPWi = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(text3);
		QWVdvsKoWWfEvuBabBDZBWElfvU = qWVdvsKoWWfEvuBabBDZBWElfvU;
		eWUHHxYZZZRykauFSqpCyvANlDB = StringTools.SanitizeDeviceString(text);
		IGwBqVihXInEfQfSMYaccExvhmS = StringTools.SanitizeDeviceString(text2);
		uoOXKtHQKtrLXkSCezltCCvfyiv = 0;
		zZpPwiaDFDcBLcdAHiWOIzPOSBe = 0;
		oUOyfEydZGCKTiyYNrBHeTrXupe = false;
		WyfijsRMQqmTZOCXCiFxChTQbXk = StringTools.SanitizeDeviceString(text);
		IntPtr zero = IntPtr.Zero;
		FCdNkUIFdLEbZeitMOXssrUgkRk = attributes;
		ZuHfqjwMLCwtfxJOubKGNtEdxth = capabilities;
		HNfCjaHajpavJgMKpwEStoDkvcyr = buttonCapabilities;
		TxxrjCADZkqeqQlwLhCHogOBTiJ = valueCapabilities;
	}

	public override string ToString()
	{
		return string.Format("VendorID={0}, ProductID={1}, Version={2}, DevicePath={3}", FCdNkUIFdLEbZeitMOXssrUgkRk.VendorHexId, FCdNkUIFdLEbZeitMOXssrUgkRk.ProductHexId, FCdNkUIFdLEbZeitMOXssrUgkRk.Version, iufetWAkfsCRoMgLqadxMkhwFLWm);
	}

	public void OpenDevice()
	{
		OpenDevice(rTzbEMDvKHZoPAqwvPfaoLyrXgi.zsEAbCQXtFYLJJvlswkmsKaYOfS, rTzbEMDvKHZoPAqwvPfaoLyrXgi.zsEAbCQXtFYLJJvlswkmsKaYOfS, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
	}

	public void OpenDevice(rTzbEMDvKHZoPAqwvPfaoLyrXgi P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi P_1, utFNrkhqcRYjcoBIIPDdjrIEcTu P_2)
	{
		if (!IsOpen)
		{
			EaVbpQCQLRmcoCxtXqVaTWrpFfEe = P_0;
			VrxiVfUWivGsbUhSLcXsOQKIROd = P_1;
			try
			{
				Handle = CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, P_0, 3221225472u, P_2);
			}
			catch (Exception innerException)
			{
				IsOpen = false;
				throw new Exception("Error opening HID device.", innerException);
			}
			IsOpen = Handle.ToInt32() != -1;
		}
	}

	public void CloseDevice()
	{
		if (IsOpen)
		{
			BJCdvwujENgVreNoJVqDsUboZvX(Handle);
			IsOpen = false;
		}
	}

	public VOwBPRSIcgMbwNNxsMOAWsKZwrz Read()
	{
		return Read(0);
	}

	public VOwBPRSIcgMbwNNxsMOAWsKZwrz Read(int P_0)
	{
		if (IsConnected)
		{
			if (!IsOpen)
			{
				OpenDevice();
			}
			try
			{
				return HWyEhBDHGvcsfWqrWuRaPNiVuDsJ(P_0);
			}
			catch
			{
				return new VOwBPRSIcgMbwNNxsMOAWsKZwrz(VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU);
			}
		}
		return new VOwBPRSIcgMbwNNxsMOAWsKZwrz(VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.uBSigLCuKoBIYXzqmuxuXvfZDRcD);
	}

	public void Read(ZsrhWscIBTTQvYkimImKbqahmXwy P_0)
	{
		NanoMDSNERLILwGbZOVIzaIWByQA(P_0, 0);
	}

	public void NanoMDSNERLILwGbZOVIzaIWByQA(ZsrhWscIBTTQvYkimImKbqahmXwy P_0, int P_1)
	{
		cpiKKHkkSdeftmWiFLeNYHlhFVH cpiKKHkkSdeftmWiFLeNYHlhFVH2 = Read;
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = new JcTaaCReZXBAcxRlmFIjgpMUjFyx(cpiKKHkkSdeftmWiFLeNYHlhFVH2, P_0);
		cpiKKHkkSdeftmWiFLeNYHlhFVH2.BeginInvoke(P_1, zXhepMHsZaygvYSMTFFxzfAfFKK, jcTaaCReZXBAcxRlmFIjgpMUjFyx);
	}

	public cIsqeClJDjClFdJDnHdnzuXgkan ReadReport()
	{
		return ReadReport(0);
	}

	public cIsqeClJDjClFdJDnHdnzuXgkan ReadReport(int P_0)
	{
		return new cIsqeClJDjClFdJDnHdnzuXgkan(Capabilities.InputReportByteLength, Read(P_0));
	}

	public void ReadReport(lhrcwhENCtysZszruincwhYnpPmg P_0)
	{
		rivHBuklHiCiCJQimpPwvOiogpOK(P_0, 0);
	}

	public void rivHBuklHiCiCJQimpPwvOiogpOK(lhrcwhENCtysZszruincwhYnpPmg P_0, int P_1)
	{
		LknZpWtGpBDgGtobTWVYkHLQnzz lknZpWtGpBDgGtobTWVYkHLQnzz = ReadReport;
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = new JcTaaCReZXBAcxRlmFIjgpMUjFyx(lknZpWtGpBDgGtobTWVYkHLQnzz, P_0);
		lknZpWtGpBDgGtobTWVYkHLQnzz.BeginInvoke(P_1, ImRmAQYFHNXMpvXtMOakzaXUBgo, jcTaaCReZXBAcxRlmFIjgpMUjFyx);
	}

	public bool ReadFeatureData(out byte[] P_0, byte P_1 = 0)
	{
		if (ZuHfqjwMLCwtfxJOubKGNtEdxth.FeatureReportByteLength <= 0)
		{
			P_0 = new byte[0];
			return false;
		}
		P_0 = new byte[ZuHfqjwMLCwtfxJOubKGNtEdxth.FeatureReportByteLength];
		byte[] array = mPGIHwtOEHsUhceFgPJMFNcEqp();
		array[0] = P_1;
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			flag = FAybFIUyhQQoIUWFiuSraaiMBJE.UPYwOdCbKbDCdEgczpPJxfwabeD(intPtr, array, array.Length);
			if (flag)
			{
				Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, ZuHfqjwMLCwtfxJOubKGNtEdxth.FeatureReportByteLength));
			}
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
		return flag;
	}

	public string ReadProductName()
	{
		try
		{
			byte[] bytes;
			if (!ReadProductName(out bytes))
			{
				return string.Empty;
			}
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	public unsafe bool ReadProductName(out byte[] P_0)
	{
		P_0 = new byte[255];
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			fixed (IntPtr* ptr = P_0)
			{
				return FAybFIUyhQQoIUWFiuSraaiMBJE.XCWurGvCGYmbTfFTRENLZzyHcVH(intPtr, (IntPtr)ptr, P_0.Length);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
	}

	public string ReadManufacturer()
	{
		byte[] bytes;
		ReadManufacturer(out bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public bool ReadManufacturer(out byte[] P_0)
	{
		P_0 = new byte[255];
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
			flag = FAybFIUyhQQoIUWFiuSraaiMBJE.VFjnwsIqeJnkTNpqhdyIMGUIaFjI(intPtr, gCHandle.AddrOfPinnedObject(), P_0.Length);
			GC.KeepAlive(gCHandle);
			gCHandle.Free();
			return flag;
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
	}

	public string ReadSerialNumber()
	{
		byte[] bytes;
		ReadSerialNumber(out bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public bool ReadSerialNumber(out byte[] P_0)
	{
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			return IxpzKJSEkRAicNJjHalSOrWLwuN(intPtr, out P_0);
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
	}

	public static bool IxpzKJSEkRAicNJjHalSOrWLwuN(IntPtr P_0, out byte[] P_1)
	{
		P_1 = new byte[255];
		string empty = string.Empty;
		bool flag = false;
		GCHandle gCHandle = GCHandle.Alloc(P_1, GCHandleType.Pinned);
		try
		{
			flag = FAybFIUyhQQoIUWFiuSraaiMBJE.JlnECSGmnukFAcbyTtpibsfdJynY(P_0, gCHandle.AddrOfPinnedObject(), P_1.Length);
			GC.KeepAlive(gCHandle);
			if (flag)
			{
				StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(P_1));
			}
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device at handle '{0}'.", P_0), innerException);
		}
		finally
		{
			gCHandle.Free();
		}
		return flag;
	}

	public static string IxpzKJSEkRAicNJjHalSOrWLwuN(IntPtr P_0)
	{
		byte[] bytes;
		IxpzKJSEkRAicNJjHalSOrWLwuN(P_0, out bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public static bool IxpzKJSEkRAicNJjHalSOrWLwuN(IntPtr P_0, IntPtr P_1, int P_2)
	{
		if (P_2 < 255)
		{
			throw new Exception("Buffer length must be at least " + 255 + " bytes!");
		}
		try
		{
			return FAybFIUyhQQoIUWFiuSraaiMBJE.JlnECSGmnukFAcbyTtpibsfdJynY(P_0, P_1, P_2);
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device at handle '{0}'.", P_0), innerException);
		}
	}

	public string ReadPhysicalDescriptor()
	{
		byte[] bytes;
		ReadPhysicalDescriptor(out bytes);
		return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
	}

	public bool ReadPhysicalDescriptor(out byte[] P_0)
	{
		P_0 = new byte[255];
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
			flag = FAybFIUyhQQoIUWFiuSraaiMBJE.HuePcgFktxDSmKoXdKvBsTXuVfM(intPtr, gCHandle.AddrOfPinnedObject(), (uint)P_0.Length);
			GC.KeepAlive(gCHandle);
			gCHandle.Free();
			return flag;
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
	}

	public bool Write(byte[] P_0)
	{
		return Write(P_0, 0);
	}

	public bool Write(byte[] P_0, int P_1)
	{
		if (IsConnected)
		{
			if (!IsOpen)
			{
				OpenDevice();
			}
			try
			{
				return KljHlyiYJavHtMAAaDKKHwIwFbq(P_0, P_1);
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public void Write(byte[] P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1)
	{
		mszIJNECfxEuJZasPAYwzZDCgpx(P_0, P_1, 0);
	}

	public void mszIJNECfxEuJZasPAYwzZDCgpx(byte[] P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1, int P_2)
	{
		HgrCmqaRDkXcHqtcBytLfuzPtHq hgrCmqaRDkXcHqtcBytLfuzPtHq = Write;
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = new JcTaaCReZXBAcxRlmFIjgpMUjFyx(hgrCmqaRDkXcHqtcBytLfuzPtHq, P_1);
		hgrCmqaRDkXcHqtcBytLfuzPtHq.BeginInvoke(P_0, P_2, ggJiIYXuYScrUfrPpTqkjUpcFMO, jcTaaCReZXBAcxRlmFIjgpMUjFyx);
	}

	public bool CEPHoICJTpvBcaKQEZxqBoQoXgq(IntPtr P_0, int P_1, int P_2, OutputReportOptions P_3)
	{
		if (IsConnected)
		{
			bool flag = false;
			try
			{
				if (!IsOpen)
				{
					OpenDevice();
					if (IsOpen)
					{
						flag = true;
					}
				}
				if (!IsOpen)
				{
					return false;
				}
				return zNNCKSqLMdBmuiJPNanjBDRYzCXL(P_0, P_1, P_2, P_3);
			}
			catch
			{
			}
			finally
			{
				if (flag)
				{
					try
					{
						CloseDevice();
					}
					catch
					{
					}
				}
			}
		}
		return false;
	}

	public bool CEPHoICJTpvBcaKQEZxqBoQoXgq(OutputReport P_0)
	{
		return CEPHoICJTpvBcaKQEZxqBoQoXgq(P_0.buffer, P_0.reportLength, 0, P_0.options);
	}

	public bool WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0)
	{
		return WriteReport(P_0, 0);
	}

	public bool WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0, int P_1)
	{
		return Write(P_0.WiuwVYgxrLUyClHYNlttEtIUrde(), P_1);
	}

	public void WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1)
	{
		eQPVTgBhghzpEUvcKovthFEKvA(P_0, P_1, 0);
	}

	public void eQPVTgBhghzpEUvcKovthFEKvA(cIsqeClJDjClFdJDnHdnzuXgkan P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1, int P_2)
	{
		riAySsKzpSVxYGEqECzeNGVHyGL riAySsKzpSVxYGEqECzeNGVHyGL2 = WriteReport;
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = new JcTaaCReZXBAcxRlmFIjgpMUjFyx(riAySsKzpSVxYGEqECzeNGVHyGL2, P_1);
		riAySsKzpSVxYGEqECzeNGVHyGL2.BeginInvoke(P_0, P_2, jwVSEJFbilguuzzRNyTbwgcLMka, jcTaaCReZXBAcxRlmFIjgpMUjFyx);
	}

	public cIsqeClJDjClFdJDnHdnzuXgkan CreateReport()
	{
		return new cIsqeClJDjClFdJDnHdnzuXgkan(Capabilities.OutputReportByteLength);
	}

	public bool WriteFeatureData(byte[] P_0)
	{
		if (ZuHfqjwMLCwtfxJOubKGNtEdxth.FeatureReportByteLength <= 0)
		{
			return false;
		}
		byte[] array = mPGIHwtOEHsUhceFgPJMFNcEqp();
		Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, ZuHfqjwMLCwtfxJOubKGNtEdxth.FeatureReportByteLength));
		IntPtr intPtr = IntPtr.Zero;
		bool flag = false;
		try
		{
			intPtr = ((!IsOpen) ? CqgWnCWASUhKAQiZNHUBaEsvjsQ(iufetWAkfsCRoMgLqadxMkhwFLWm, 0u) : Handle);
			return FAybFIUyhQQoIUWFiuSraaiMBJE.wdjqkgiAYtxDOZlnZdDthTtQRzQ(intPtr, array, array.Length);
		}
		catch (Exception innerException)
		{
			throw new Exception(string.Format("Error accessing HID device '{0}'.", iufetWAkfsCRoMgLqadxMkhwFLWm), innerException);
		}
		finally
		{
			if (intPtr != IntPtr.Zero && intPtr != Handle)
			{
				BJCdvwujENgVreNoJVqDsUboZvX(intPtr);
			}
		}
	}

	protected static void zXhepMHsZaygvYSMTFFxzfAfFKK(IAsyncResult P_0)
	{
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = (JcTaaCReZXBAcxRlmFIjgpMUjFyx)P_0.AsyncState;
		cpiKKHkkSdeftmWiFLeNYHlhFVH cpiKKHkkSdeftmWiFLeNYHlhFVH2 = (cpiKKHkkSdeftmWiFLeNYHlhFVH)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallerDelegate;
		ZsrhWscIBTTQvYkimImKbqahmXwy zsrhWscIBTTQvYkimImKbqahmXwy = (ZsrhWscIBTTQvYkimImKbqahmXwy)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallbackDelegate;
		VOwBPRSIcgMbwNNxsMOAWsKZwrz data = cpiKKHkkSdeftmWiFLeNYHlhFVH2.EndInvoke(P_0);
		if (zsrhWscIBTTQvYkimImKbqahmXwy != null)
		{
			zsrhWscIBTTQvYkimImKbqahmXwy(data);
		}
	}

	protected static void ImRmAQYFHNXMpvXtMOakzaXUBgo(IAsyncResult P_0)
	{
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = (JcTaaCReZXBAcxRlmFIjgpMUjFyx)P_0.AsyncState;
		LknZpWtGpBDgGtobTWVYkHLQnzz lknZpWtGpBDgGtobTWVYkHLQnzz = (LknZpWtGpBDgGtobTWVYkHLQnzz)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallerDelegate;
		lhrcwhENCtysZszruincwhYnpPmg lhrcwhENCtysZszruincwhYnpPmg2 = (lhrcwhENCtysZszruincwhYnpPmg)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallbackDelegate;
		cIsqeClJDjClFdJDnHdnzuXgkan report = lknZpWtGpBDgGtobTWVYkHLQnzz.EndInvoke(P_0);
		if (lhrcwhENCtysZszruincwhYnpPmg2 != null)
		{
			lhrcwhENCtysZszruincwhYnpPmg2(report);
		}
	}

	private static void ggJiIYXuYScrUfrPpTqkjUpcFMO(IAsyncResult P_0)
	{
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = (JcTaaCReZXBAcxRlmFIjgpMUjFyx)P_0.AsyncState;
		HgrCmqaRDkXcHqtcBytLfuzPtHq hgrCmqaRDkXcHqtcBytLfuzPtHq = (HgrCmqaRDkXcHqtcBytLfuzPtHq)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallerDelegate;
		GkgTxnlHJswlBwyCGeckGLbbQIG gkgTxnlHJswlBwyCGeckGLbbQIG = (GkgTxnlHJswlBwyCGeckGLbbQIG)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallbackDelegate;
		bool success = hgrCmqaRDkXcHqtcBytLfuzPtHq.EndInvoke(P_0);
		if (gkgTxnlHJswlBwyCGeckGLbbQIG != null)
		{
			gkgTxnlHJswlBwyCGeckGLbbQIG(success);
		}
	}

	private static void tTPOdnELlBgaPaeoNmuTmJKgBaMt(IAsyncResult P_0)
	{
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = (JcTaaCReZXBAcxRlmFIjgpMUjFyx)P_0.AsyncState;
		tZJcEsCaOsQBmdggHnajxtCfwDfx tZJcEsCaOsQBmdggHnajxtCfwDfx2 = (tZJcEsCaOsQBmdggHnajxtCfwDfx)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallerDelegate;
		Action<bool> action = (Action<bool>)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallbackDelegate;
		bool obj = tZJcEsCaOsQBmdggHnajxtCfwDfx2.EndInvoke(P_0);
		if (action != null)
		{
			action(obj);
		}
	}

	private static void jwVSEJFbilguuzzRNyTbwgcLMka(IAsyncResult P_0)
	{
		JcTaaCReZXBAcxRlmFIjgpMUjFyx jcTaaCReZXBAcxRlmFIjgpMUjFyx = (JcTaaCReZXBAcxRlmFIjgpMUjFyx)P_0.AsyncState;
		riAySsKzpSVxYGEqECzeNGVHyGL riAySsKzpSVxYGEqECzeNGVHyGL2 = (riAySsKzpSVxYGEqECzeNGVHyGL)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallerDelegate;
		GkgTxnlHJswlBwyCGeckGLbbQIG gkgTxnlHJswlBwyCGeckGLbbQIG = (GkgTxnlHJswlBwyCGeckGLbbQIG)jcTaaCReZXBAcxRlmFIjgpMUjFyx.CallbackDelegate;
		bool success = riAySsKzpSVxYGEqECzeNGVHyGL2.EndInvoke(P_0);
		if (gkgTxnlHJswlBwyCGeckGLbbQIG != null)
		{
			gkgTxnlHJswlBwyCGeckGLbbQIG(success);
		}
	}

	private byte[] gvtTHunxebKnpOyHStNSMkoRKwG()
	{
		int num = Capabilities.InputReportByteLength;
		if (num < 0)
		{
			num = 0;
		}
		return cEYnsvdZEgpKUOcsxEpoXmVeOaF ?? (cEYnsvdZEgpKUOcsxEpoXmVeOaF = new byte[num]);
	}

	private byte[] rcLCooIlFndPmmQxrAWeBFMIQmTC()
	{
		return FEaHLvJjKmUKLVfKAwZZMtaGgmHh(Capabilities.InputReportByteLength - 1);
	}

	private byte[] EWetomzpqHKMfYMbEIkecDRAfPp()
	{
		return FEaHLvJjKmUKLVfKAwZZMtaGgmHh(Capabilities.OutputReportByteLength - 1);
	}

	private byte[] mPGIHwtOEHsUhceFgPJMFNcEqp()
	{
		return FEaHLvJjKmUKLVfKAwZZMtaGgmHh(Capabilities.FeatureReportByteLength - 1);
	}

	private static byte[] FEaHLvJjKmUKLVfKAwZZMtaGgmHh(int P_0)
	{
		byte[] array = null;
		Array.Resize(ref array, P_0 + 1);
		return array;
	}

	public static atMUBsjqMZcztvgByyqIWUONwcH bSXGqWVEHRhIfcbfdsDduOfUoxu(IntPtr P_0)
	{
		FAybFIUyhQQoIUWFiuSraaiMBJE.mfdGbaaYiFKGnlvzEqDaNsOmZeh mfdGbaaYiFKGnlvzEqDaNsOmZeh = default(FAybFIUyhQQoIUWFiuSraaiMBJE.mfdGbaaYiFKGnlvzEqDaNsOmZeh);
		mfdGbaaYiFKGnlvzEqDaNsOmZeh.URbjicLEKLuQBOXogMwFHYSSvns = Marshal.SizeOf(mfdGbaaYiFKGnlvzEqDaNsOmZeh);
		FAybFIUyhQQoIUWFiuSraaiMBJE.wzuChVvWLqLjcYGPbpdeVOqNsJr(P_0, ref mfdGbaaYiFKGnlvzEqDaNsOmZeh);
		return new atMUBsjqMZcztvgByyqIWUONwcH(mfdGbaaYiFKGnlvzEqDaNsOmZeh);
	}

	public static WRmWIdgRNTmJYmlFGkqlcOyQAuac hzzRZCRvrUlctPxUbwHsbmFtIfM(IntPtr P_0)
	{
		FAybFIUyhQQoIUWFiuSraaiMBJE.fJzRFsumvSErDwirHhoVmJbpGrSe capabilities = default(FAybFIUyhQQoIUWFiuSraaiMBJE.fJzRFsumvSErDwirHhoVmJbpGrSe);
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (FAybFIUyhQQoIUWFiuSraaiMBJE.zwYXVSHIfbnsGPfxXkDdaXUCAXl(P_0, ref zero))
			{
				FAybFIUyhQQoIUWFiuSraaiMBJE.EEvOsMbpEtOzBbzRiLeYACzohiu(zero, ref capabilities);
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					FAybFIUyhQQoIUWFiuSraaiMBJE.CngHnxLyuMqQMFfhhgXnOFOsrAY(zero);
				}
			}
			catch
			{
			}
		}
		return new WRmWIdgRNTmJYmlFGkqlcOyQAuac(capabilities);
	}

	public static fVWXbOYCdWeFCJUBVXNatWMsbvp[] XJgmOpfFZmkymXDVcgzheTCnUVMB(IntPtr P_0, short P_1, short P_2)
	{
		fVWXbOYCdWeFCJUBVXNatWMsbvp[] array = new fVWXbOYCdWeFCJUBVXNatWMsbvp[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (FAybFIUyhQQoIUWFiuSraaiMBJE.zwYXVSHIfbnsGPfxXkDdaXUCAXl(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					FAybFIUyhQQoIUWFiuSraaiMBJE.bbrQWAOwwDZbNcDNmgmqieiiIiKd(intPtr, num2);
					FAybFIUyhQQoIUWFiuSraaiMBJE.mKRxNTHIGjEPPjfvRJldYXQaXpY(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ[] array2 = new FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ)Marshal.PtrToStructure(intPtr2, typeof(FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new fVWXbOYCdWeFCJUBVXNatWMsbvp(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					FAybFIUyhQQoIUWFiuSraaiMBJE.CngHnxLyuMqQMFfhhgXnOFOsrAY(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}

	public static MFUrcluqOBPEvSbzhRQjzcrDggKC[] kzNgqMHsFmqUECCpDtsZeDOFywY(IntPtr P_0, short P_1, short P_2)
	{
		MFUrcluqOBPEvSbzhRQjzcrDggKC[] array = new MFUrcluqOBPEvSbzhRQjzcrDggKC[P_2];
		if (P_2 <= 0)
		{
			return array;
		}
		short num = P_2;
		IntPtr zero = IntPtr.Zero;
		try
		{
			if (FAybFIUyhQQoIUWFiuSraaiMBJE.zwYXVSHIfbnsGPfxXkDdaXUCAXl(P_0, ref zero))
			{
				int num2 = 72 * P_2;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					intPtr = Marshal.AllocHGlobal(num2);
					IntPtr intPtr2 = intPtr;
					FAybFIUyhQQoIUWFiuSraaiMBJE.bbrQWAOwwDZbNcDNmgmqieiiIiKd(intPtr, num2);
					FAybFIUyhQQoIUWFiuSraaiMBJE.CPCzCPhEGiCpuFzaiNyXXFTHfRT(P_1, intPtr, ref num, zero);
					if (num > 0)
					{
						FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav[] array2 = new FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav[num];
						for (int i = 0; i < num; i++)
						{
							array2[i] = (FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav)Marshal.PtrToStructure(intPtr2, typeof(FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav));
							intPtr2 = NativeTools.OffsetIntPtr(intPtr2, 72);
							array[i] = new MFUrcluqOBPEvSbzhRQjzcrDggKC(array2[i]);
						}
					}
				}
				catch
				{
					throw;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (zero != IntPtr.Zero)
				{
					FAybFIUyhQQoIUWFiuSraaiMBJE.CngHnxLyuMqQMFfhhgXnOFOsrAY(zero);
				}
			}
			catch
			{
			}
		}
		for (int j = 0; j < P_2; j++)
		{
			if (array[j] == null)
			{
				array[j] = null;
			}
		}
		return array;
	}

	private bool KljHlyiYJavHtMAAaDKKHwIwFbq(byte[] P_0, int P_1)
	{
		if (ZuHfqjwMLCwtfxJOubKGNtEdxth.OutputReportByteLength <= 0)
		{
			return false;
		}
		byte[] array = EWetomzpqHKMfYMbEIkecDRAfPp();
		uint num = 0u;
		Array.Copy(P_0, 0, array, 0, Math.Min(P_0.Length, ZuHfqjwMLCwtfxJOubKGNtEdxth.OutputReportByteLength));
		if (VrxiVfUWivGsbUhSLcXsOQKIROd == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr iJRYQsFsGwgSmBgDlQYdDpUHPxr = default(FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr);
			NativeOverlapped nativeOverlapped = default(NativeOverlapped);
			int num2 = ((P_1 <= 0) ? 65535 : P_1);
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.RFbftrjvnoloiCZEkIyFgveDutgK = IntPtr.Zero;
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.oVAcgCcIadaSZnKrbKxKCzbuVViy = true;
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.FwjdyNSogEAyCynRfgRXCwxfiHk = Marshal.SizeOf(iJRYQsFsGwgSmBgDlQYdDpUHPxr);
			nativeOverlapped.OffsetLow = 0;
			nativeOverlapped.OffsetHigh = 0;
			nativeOverlapped.EventHandle = FAybFIUyhQQoIUWFiuSraaiMBJE.wFOVTJrnkHoGNMucOcWvZcYulBT(ref iJRYQsFsGwgSmBgDlQYdDpUHPxr, Convert.ToInt32(false), Convert.ToInt32(true), "");
			try
			{
				FAybFIUyhQQoIUWFiuSraaiMBJE.lnNsosQqRkChpBdnxHfqSHAjeimG(Handle, array, (uint)array.Length, out num, ref nativeOverlapped);
			}
			catch
			{
				return false;
			}
			switch (FAybFIUyhQQoIUWFiuSraaiMBJE.rLrjZJZfBbgOxmVXHHejjzRfvNM(nativeOverlapped.EventHandle, num2))
			{
			case 0u:
				return true;
			case 258u:
				return false;
			case uint.MaxValue:
				return false;
			default:
				return false;
			}
		}
		try
		{
			NativeOverlapped nativeOverlapped2 = default(NativeOverlapped);
			return FAybFIUyhQQoIUWFiuSraaiMBJE.lnNsosQqRkChpBdnxHfqSHAjeimG(Handle, array, (uint)array.Length, out num, ref nativeOverlapped2);
		}
		catch
		{
			return false;
		}
	}

	private bool zNNCKSqLMdBmuiJPNanjBDRYzCXL(IntPtr P_0, int P_1, int P_2, OutputReportOptions P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		uint num = 0u;
		if (VrxiVfUWivGsbUhSLcXsOQKIROd == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr iJRYQsFsGwgSmBgDlQYdDpUHPxr = default(FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr);
			NativeOverlapped nativeOverlapped = default(NativeOverlapped);
			int num2 = ((P_2 <= 0) ? 65535 : P_2);
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.RFbftrjvnoloiCZEkIyFgveDutgK = IntPtr.Zero;
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.oVAcgCcIadaSZnKrbKxKCzbuVViy = true;
			iJRYQsFsGwgSmBgDlQYdDpUHPxr.FwjdyNSogEAyCynRfgRXCwxfiHk = Marshal.SizeOf(iJRYQsFsGwgSmBgDlQYdDpUHPxr);
			nativeOverlapped.OffsetLow = 0;
			nativeOverlapped.OffsetHigh = 0;
			nativeOverlapped.EventHandle = FAybFIUyhQQoIUWFiuSraaiMBJE.wFOVTJrnkHoGNMucOcWvZcYulBT(ref iJRYQsFsGwgSmBgDlQYdDpUHPxr, Convert.ToInt32(false), Convert.ToInt32(true), "");
			try
			{
				if ((P_3 & OutputReportOptions.iTJdYGHWgyKEolybYDyTnKjmMCoD) != OutputReportOptions.TCGihQKDgeeGtvEXifcuojmabzj)
				{
					return FAybFIUyhQQoIUWFiuSraaiMBJE.RISXIJoJJRfTMdxUAgtmLNawvkuS(Handle, P_0, P_1);
				}
				FAybFIUyhQQoIUWFiuSraaiMBJE.lnNsosQqRkChpBdnxHfqSHAjeimG(Handle, P_0, (uint)P_1, out num, ref nativeOverlapped);
			}
			catch
			{
				return false;
			}
			switch (FAybFIUyhQQoIUWFiuSraaiMBJE.rLrjZJZfBbgOxmVXHHejjzRfvNM(nativeOverlapped.EventHandle, num2))
			{
			case 0u:
				return true;
			case 258u:
				return false;
			case uint.MaxValue:
				return false;
			default:
				return false;
			}
		}
		try
		{
			if ((P_3 & OutputReportOptions.iTJdYGHWgyKEolybYDyTnKjmMCoD) != OutputReportOptions.TCGihQKDgeeGtvEXifcuojmabzj)
			{
				return FAybFIUyhQQoIUWFiuSraaiMBJE.RISXIJoJJRfTMdxUAgtmLNawvkuS(Handle, P_0, P_1);
			}
			NativeOverlapped nativeOverlapped2 = default(NativeOverlapped);
			return FAybFIUyhQQoIUWFiuSraaiMBJE.lnNsosQqRkChpBdnxHfqSHAjeimG(Handle, P_0, (uint)P_1, out num, ref nativeOverlapped2);
		}
		catch
		{
			return false;
		}
	}

	protected VOwBPRSIcgMbwNNxsMOAWsKZwrz HWyEhBDHGvcsfWqrWuRaPNiVuDsJ(int P_0)
	{
		VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.JzItyLsmVexnfzwnhcFcMfKawOD;
		byte[] array = rcLCooIlFndPmmQxrAWeBFMIQmTC();
		if (ZuHfqjwMLCwtfxJOubKGNtEdxth.InputReportByteLength > 0)
		{
			uint num = 0u;
			if (EaVbpQCQLRmcoCxtXqVaTWrpFfEe == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
			{
				FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr iJRYQsFsGwgSmBgDlQYdDpUHPxr = default(FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr);
				NativeOverlapped nativeOverlapped = default(NativeOverlapped);
				int num2 = ((P_0 <= 0) ? 65535 : P_0);
				iJRYQsFsGwgSmBgDlQYdDpUHPxr.RFbftrjvnoloiCZEkIyFgveDutgK = IntPtr.Zero;
				iJRYQsFsGwgSmBgDlQYdDpUHPxr.oVAcgCcIadaSZnKrbKxKCzbuVViy = true;
				iJRYQsFsGwgSmBgDlQYdDpUHPxr.FwjdyNSogEAyCynRfgRXCwxfiHk = Marshal.SizeOf(iJRYQsFsGwgSmBgDlQYdDpUHPxr);
				nativeOverlapped.OffsetLow = 0;
				nativeOverlapped.OffsetHigh = 0;
				nativeOverlapped.EventHandle = FAybFIUyhQQoIUWFiuSraaiMBJE.wFOVTJrnkHoGNMucOcWvZcYulBT(ref iJRYQsFsGwgSmBgDlQYdDpUHPxr, Convert.ToInt32(false), Convert.ToInt32(true), string.Empty);
				try
				{
					FAybFIUyhQQoIUWFiuSraaiMBJE.QVsEFmgWYzXVVTMNugekESaHpdto(Handle, array, (uint)array.Length, out num, ref nativeOverlapped);
					switch (FAybFIUyhQQoIUWFiuSraaiMBJE.rLrjZJZfBbgOxmVXHHejjzRfvNM(nativeOverlapped.EventHandle, num2))
					{
					case 0u:
						status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.mmVARMJeNgPzFhCEbPdQSlTtUNt;
						break;
					case 258u:
						status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.moEmLqRIFXEDgCdwGldCxZGLUkmR;
						array = new byte[0];
						break;
					case uint.MaxValue:
						status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.YoCkNWilNGtewrFYATviElhyGfu;
						array = new byte[0];
						break;
					default:
						status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.JzItyLsmVexnfzwnhcFcMfKawOD;
						array = new byte[0];
						break;
					}
				}
				catch
				{
					status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
				}
				finally
				{
					BJCdvwujENgVreNoJVqDsUboZvX(nativeOverlapped.EventHandle);
				}
			}
			else
			{
				try
				{
					NativeOverlapped nativeOverlapped2 = default(NativeOverlapped);
					FAybFIUyhQQoIUWFiuSraaiMBJE.QVsEFmgWYzXVVTMNugekESaHpdto(Handle, array, (uint)array.Length, out num, ref nativeOverlapped2);
					status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.mmVARMJeNgPzFhCEbPdQSlTtUNt;
				}
				catch
				{
					status = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
				}
			}
		}
		return new VOwBPRSIcgMbwNNxsMOAWsKZwrz(array, status);
	}

	public bool bcaziKRkLrnMrCpkqgKOxjmkhgZ()
	{
		try
		{
			return IsConnected && IsOpen && EaVbpQCQLRmcoCxtXqVaTWrpFfEe == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc;
		}
		catch
		{
		}
		return false;
	}

	public bool ASDMwqFkcgCOfzsoKweXQCPIrqY()
	{
		try
		{
			if (IsConnected)
			{
				if (IsOpen && EaVbpQCQLRmcoCxtXqVaTWrpFfEe != rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
				{
					CloseDevice();
				}
				if (!IsOpen)
				{
					OpenDevice(rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc, rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
					if (!IsOpen)
					{
						return false;
					}
				}
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	public VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO MYrtbyGeMpJPwFVNYMcEOLEExLl(out byte[] P_0)
	{
		P_0 = null;
		try
		{
			if (IsConnected)
			{
				if (IsOpen && EaVbpQCQLRmcoCxtXqVaTWrpFfEe != rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
				{
					CloseDevice();
				}
				if (!IsOpen)
				{
					OpenDevice(rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc, rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
					if (!IsOpen)
					{
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
					}
				}
				return WaQBFJknQuRSkTAvlWsBtGdPyNM(out P_0);
			}
			return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.uBSigLCuKoBIYXzqmuxuXvfZDRcD;
		}
		catch
		{
		}
		return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
	}

	protected unsafe VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO WaQBFJknQuRSkTAvlWsBtGdPyNM(out byte[] P_0)
	{
		VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO result = VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.JzItyLsmVexnfzwnhcFcMfKawOD;
		P_0 = gvtTHunxebKnpOyHStNSMkoRKwG();
		Array.Clear(P_0, 0, P_0.Length);
		if (ZuHfqjwMLCwtfxJOubKGNtEdxth.InputReportByteLength <= 0)
		{
			return result;
		}
		uint num = 0u;
		if (EaVbpQCQLRmcoCxtXqVaTWrpFfEe == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
		{
			NativeOverlapped nativeOverlapped = new NativeOverlapped
			{
				OffsetLow = 0,
				OffsetHigh = 0
			};
			try
			{
				fixed (byte* ptr = P_0)
				{
					if (!FAybFIUyhQQoIUWFiuSraaiMBJE.qletEBZUCuwMpHdQNgOUvJVODzT(Handle, (IntPtr)ptr, (uint)P_0.Length, ref nativeOverlapped, NICvPgHnqTfTndrXRwnrhenWblz()))
					{
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
					}
					switch (FAybFIUyhQQoIUWFiuSraaiMBJE.QxplxiIivBQVplrVWLqROOTUnDj(65535, true))
					{
					case 0u:
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
					case 192u:
					{
						int num2;
						if (!FAybFIUyhQQoIUWFiuSraaiMBJE.vmpCTKkSqaWwekGwokgfBejYXGxT(Handle, ref nativeOverlapped, out num2, false))
						{
							return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
						}
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.mmVARMJeNgPzFhCEbPdQSlTtUNt;
					}
					case 258u:
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.moEmLqRIFXEDgCdwGldCxZGLUkmR;
					case uint.MaxValue:
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.YoCkNWilNGtewrFYATviElhyGfu;
					case 128u:
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.YKVXEhqJfPSDpGnTDtlQSInyBlT;
					default:
						return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.JzItyLsmVexnfzwnhcFcMfKawOD;
					}
				}
			}
			catch
			{
				return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
			}
		}
		try
		{
			NativeOverlapped nativeOverlapped2 = default(NativeOverlapped);
			if (FAybFIUyhQQoIUWFiuSraaiMBJE.QVsEFmgWYzXVVTMNugekESaHpdto(Handle, P_0, (uint)P_0.Length, out num, ref nativeOverlapped2))
			{
				return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.mmVARMJeNgPzFhCEbPdQSlTtUNt;
			}
			return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
		}
		catch
		{
			return VOwBPRSIcgMbwNNxsMOAWsKZwrz.QZzRVjbhYCXXPVBPQINWuWPfZDO.ruHtvAlLYwOaEHQvYXbPPCSDuPU;
		}
	}

	private FAybFIUyhQQoIUWFiuSraaiMBJE.uMDGCDVqhCpkSZqAjCaSmJeGbpP NICvPgHnqTfTndrXRwnrhenWblz()
	{
		return eOrxANqpHodUXEKftgvXfqBejOHq;
	}

	private void eOrxANqpHodUXEKftgvXfqBejOHq(int P_0, int P_1, IntPtr P_2)
	{
	}

	public static IntPtr CqgWnCWASUhKAQiZNHUBaEsvjsQ(string P_0, uint P_1)
	{
		return CqgWnCWASUhKAQiZNHUBaEsvjsQ(P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi.zsEAbCQXtFYLJJvlswkmsKaYOfS, P_1, utFNrkhqcRYjcoBIIPDdjrIEcTu.KdkAlnBkyoezudAOKFyDdMyEzPTm | utFNrkhqcRYjcoBIIPDdjrIEcTu.iQctmYQaAZvUIfEWvxxBsgVMmmY);
	}

	public static IntPtr CqgWnCWASUhKAQiZNHUBaEsvjsQ(string P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi P_1, uint P_2, utFNrkhqcRYjcoBIIPDdjrIEcTu P_3)
	{
		FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr iJRYQsFsGwgSmBgDlQYdDpUHPxr = default(FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr);
		int num = 0;
		if (P_1 == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
		{
			num = 1073741824;
		}
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.RFbftrjvnoloiCZEkIyFgveDutgK = IntPtr.Zero;
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.oVAcgCcIadaSZnKrbKxKCzbuVViy = true;
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.FwjdyNSogEAyCynRfgRXCwxfiHk = FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr.NativeSize;
		return FAybFIUyhQQoIUWFiuSraaiMBJE.LCzvRPAKlSsqLWcyyJRnwKCDYNf(P_0, P_2, (int)P_3, ref iJRYQsFsGwgSmBgDlQYdDpUHPxr, 3, num, 0);
	}

	public static IntPtr CqgWnCWASUhKAQiZNHUBaEsvjsQ(IntPtr P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi P_1, uint P_2, utFNrkhqcRYjcoBIIPDdjrIEcTu P_3)
	{
		FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr iJRYQsFsGwgSmBgDlQYdDpUHPxr = default(FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr);
		int num = 0;
		if (P_1 == rTzbEMDvKHZoPAqwvPfaoLyrXgi.PAZAFcEuTCOnwcOxBCqSOtxrvbRc)
		{
			num = 1073741824;
		}
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.RFbftrjvnoloiCZEkIyFgveDutgK = IntPtr.Zero;
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.oVAcgCcIadaSZnKrbKxKCzbuVViy = true;
		iJRYQsFsGwgSmBgDlQYdDpUHPxr.FwjdyNSogEAyCynRfgRXCwxfiHk = FAybFIUyhQQoIUWFiuSraaiMBJE.iJRYQsFsGwgSmBgDlQYdDpUHPxr.NativeSize;
		return FAybFIUyhQQoIUWFiuSraaiMBJE.LCzvRPAKlSsqLWcyyJRnwKCDYNf(P_0, P_2, (int)P_3, ref iJRYQsFsGwgSmBgDlQYdDpUHPxr, 3, num, 0);
	}

	public static void BJCdvwujENgVreNoJVqDsUboZvX(IntPtr P_0)
	{
		OXYaOwpnPogEmAwqvvlBBMCjTHE(P_0);
		FAybFIUyhQQoIUWFiuSraaiMBJE.ZOqXLoExjyblnMXkGrMMSSDfdLb(P_0);
	}

	public static void OXYaOwpnPogEmAwqvvlBBMCjTHE(IntPtr P_0)
	{
		if (Environment.OSVersion.Version.Major > 5)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.HgLGOycBybSCMmLGYeojbLkrANX(P_0, IntPtr.Zero);
		}
		else
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.AJOLBZsIUKPcaOSSEWTTyGbQazI(P_0);
		}
	}

	internal static hdKCmGlHttTBdcjeWBCjBOXCTjJ RngPhDbbSgrmRxALegiOitidxsEr(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		fVWXbOYCdWeFCJUBVXNatWMsbvp[] array = new fVWXbOYCdWeFCJUBVXNatWMsbvp[P_3];
		for (int i = 0; i < P_3; i++)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ.wEAOwfgkiygOdwWkySGAmfUmJfs eWHiUdmQoRNyvODaRwlpBBXvlHH = new FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ.wEAOwfgkiygOdwWkySGAmfUmJfs
			{
				HXuSfSlDjQDjPPsMxzRgyVLBfaF = new ushort[8]
			};
			eWHiUdmQoRNyvODaRwlpBBXvlHH.HXuSfSlDjQDjPPsMxzRgyVLBfaF[0] = (ushort)i;
			array[i] = new fVWXbOYCdWeFCJUBVXNatWMsbvp(new FAybFIUyhQQoIUWFiuSraaiMBJE.ObEXWVxLVEExZsrxvIxTHRIObJZ
			{
				ChVuJmqNQNkcCxPIAUfevOTNKRb = 9,
				EWHiUdmQoRNyvODaRwlpBBXvlHH = eWHiUdmQoRNyvODaRwlpBBXvlHH
			});
		}
		int num = P_2 + P_4;
		MFUrcluqOBPEvSbzhRQjzcrDggKC[] array2 = new MFUrcluqOBPEvSbzhRQjzcrDggKC[num];
		for (int j = 0; j < num; j++)
		{
			FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav.mIHbLOXOrTgYLPSVcImqidakdXyG eWHiUdmQoRNyvODaRwlpBBXvlHH2 = new FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav.mIHbLOXOrTgYLPSVcImqidakdXyG
			{
				HXuSfSlDjQDjPPsMxzRgyVLBfaF = new ushort[8]
			};
			if (j < P_2)
			{
				eWHiUdmQoRNyvODaRwlpBBXvlHH2.HXuSfSlDjQDjPPsMxzRgyVLBfaF[0] = 48;
			}
			else
			{
				eWHiUdmQoRNyvODaRwlpBBXvlHH2.HXuSfSlDjQDjPPsMxzRgyVLBfaF[0] = 57;
			}
			array2[j] = new MFUrcluqOBPEvSbzhRQjzcrDggKC(new FAybFIUyhQQoIUWFiuSraaiMBJE.vUIoYNEvSPCAFhdDdZiXldHmhav
			{
				ChVuJmqNQNkcCxPIAUfevOTNKRb = 1,
				EWHiUdmQoRNyvODaRwlpBBXvlHH = eWHiUdmQoRNyvODaRwlpBBXvlHH2
			});
		}
		return new hdKCmGlHttTBdcjeWBCjBOXCTjJ(new atMUBsjqMZcztvgByyqIWUONwcH(new FAybFIUyhQQoIUWFiuSraaiMBJE.mfdGbaaYiFKGnlvzEqDaNsOmZeh
		{
			SIpKsnprFSjfaLNncodIHAPIBgOa = (ushort)P_1,
			MgIDmgZdRcfdAiejjCaNPTnrasTy = (ushort)P_0
		}), new WRmWIdgRNTmJYmlFGkqlcOyQAuac(new FAybFIUyhQQoIUWFiuSraaiMBJE.fJzRFsumvSErDwirHhoVmJbpGrSe
		{
			iqykiEpZLqvhEpccpZHBCBERBZh = (short)P_3,
			smcxDKlJbQTNWFqBvdQdAbIDXBJ = (short)P_2
		}), array, array2);
	}

	private void UWpaVViNLfuwzpIJUeRTdaWyPgzO()
	{
		if (IsOpen)
		{
			OpenDevice();
		}
		if (fSVgTvcTnxbZTpwTcIWPmiegINYd != null)
		{
			fSVgTvcTnxbZTpwTcIWPmiegINYd();
		}
	}

	private void tqracJkLXlJzWDLWlbByurYtOegb()
	{
		if (IsOpen)
		{
			CloseDevice();
		}
		if (JOWjpaIWLqFYaxmyqgNPqkAGGnd != null)
		{
			JOWjpaIWLqFYaxmyqgNPqkAGGnd();
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~hdKCmGlHttTBdcjeWBCjBOXCTjJ()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			if (MonitorDeviceEvents)
			{
				MonitorDeviceEvents = false;
			}
			if (IsOpen)
			{
				CloseDevice();
			}
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}
}
