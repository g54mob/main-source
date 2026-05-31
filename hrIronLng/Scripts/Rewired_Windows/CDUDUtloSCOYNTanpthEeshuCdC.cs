using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class CDUDUtloSCOYNTanpthEeshuCdC : IDisposable, IInputSource
{
	private class YPnvfkdqdmvaoZJfetQblvZMSRZ
	{
		public ushort GhRxJUEFfHwZOPqFzsKjMYeoIPm;

		public ushort TpMniVMUhqTQkYOAVBMFVjfmfAhG;

		public YPnvfkdqdmvaoZJfetQblvZMSRZ(ushort usagePage, ushort usage)
		{
			GhRxJUEFfHwZOPqFzsKjMYeoIPm = usagePage;
			TpMniVMUhqTQkYOAVBMFVjfmfAhG = usage;
		}
	}

	internal class XxyJWBtqXuLRkPzhutTHCoiNIZYC : IDisposable, MFFbigtCSAERTKmOTUlnAJmgNhe
	{
		public const int HJJEEZbCVyXsrdYPhzUmmrqKkQA = 255;

		private IntPtr getGvAiwqyoBEKJbmsZSbrharXkz;

		private IntPtr HBtXOJfHBVSdLpJeGXAVcmyhoqj;

		private PgdfUoYursRcPXlvyPcuyFpZAtRc hVPgmpKSqUNsJCKANsrpHaZKSaOj;

		private readonly string rrJNMMeMhokXfROOkwMcgUyWaYg;

		private readonly string daoTxRCmXXmibNhjAmdcoXelKQb;

		private readonly string pvIaqSGSuhkjTRAnubbOiUOObAX;

		private readonly string VxUhDlcjidEycVnEHXAILRBgalp;

		private readonly lfJHVnVymeYwwQXbCwkRAWNItlo EkePzpkLzuzSIRLUyKlYiOgzfiq;

		private readonly string ViTZqpvtTcCdLlRVkAufqgDkycT;

		private readonly int jRFJgnmwOOJSXkeCnRcESkovPE;

		private readonly int eeLTrRQdylLGfNoddAVIYEdRKZX;

		private readonly bool xxPspZGrBhzkMNuatDLYgiLSuNt;

		private readonly string VuciFjzmuBBoGrgqemyvYeCPmgV;

		private readonly bool dyISvrQQLAplFeQTTAQqwpEZcGZi;

		private readonly PgdfUoYursRcPXlvyPcuyFpZAtRc ScGxawGDbnpKoQXoSKxTPxPwifG;

		private readonly exNgjJiNVhHePqgxfPJprRBjPsE[] AFozQbdaJQSKUhyiDSxZeeWhhsH;

		private readonly HUXGqmGKaytnimdNVoGehreiWbbz[] AvydjJcgvZaZvhoPvdrIajnElKi;

		private sSitzLtsLskxvjKvTBbkifCoAGX VYIinJkjhciPfaAPlpHhYFumsghF;

		private sSitzLtsLskxvjKvTBbkifCoAGX ACsbZcHkQManajrogbVtLUPwLHAX;

		private NTKOqlhAzYCUXMRuFcFjQesOHnQ adEsBmfFNMxiAXvfEeUImOtnjMb;

		private YrgWGjOKeHRPyckVeZiwDeiZhZQi IkNXhhcntTYnlMaACTXMwvHLHkM;

		[CompilerGenerated]
		private bool FpYahwruTbouPTWwNFfuABImyoo;

		public IntPtr Handle => HBtXOJfHBVSdLpJeGXAVcmyhoqj;

		public bool IsOpen
		{
			[CompilerGenerated]
			get
			{
				return FpYahwruTbouPTWwNFfuABImyoo;
			}
			[CompilerGenerated]
			private set
			{
				FpYahwruTbouPTWwNFfuABImyoo = value;
			}
		}

		public bool IsConnected => true;

		public string Description => "";

		public PgdfUoYursRcPXlvyPcuyFpZAtRc Capabilities => hVPgmpKSqUNsJCKANsrpHaZKSaOj;

		public lfJHVnVymeYwwQXbCwkRAWNItlo Attributes => EkePzpkLzuzSIRLUyKlYiOgzfiq;

		public string DevicePath => daoTxRCmXXmibNhjAmdcoXelKQb;

		public bool MonitorDeviceEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public exNgjJiNVhHePqgxfPJprRBjPsE[] ButtonCapabilities => AFozQbdaJQSKUhyiDSxZeeWhhsH;

		public HUXGqmGKaytnimdNVoGehreiWbbz[] ValueCapabilities => AvydjJcgvZaZvhoPvdrIajnElKi;

		public string DevicePathStripped => pvIaqSGSuhkjTRAnubbOiUOObAX;

		public string InstanceId => VxUhDlcjidEycVnEHXAILRBgalp;

		public string Manufacturer => ViTZqpvtTcCdLlRVkAufqgDkycT;

		public int HubId => jRFJgnmwOOJSXkeCnRcESkovPE;

		public int PortId => eeLTrRQdylLGfNoddAVIYEdRKZX;

		public bool IsBluetoothDevice => xxPspZGrBhzkMNuatDLYgiLSuNt;

		public string BluetoothDeviceName => VuciFjzmuBBoGrgqemyvYeCPmgV;

		public bool HasLocationInfo => false;

		public event NTKOqlhAzYCUXMRuFcFjQesOHnQ Inserted
		{
			add
			{
				NTKOqlhAzYCUXMRuFcFjQesOHnQ nTKOqlhAzYCUXMRuFcFjQesOHnQ = adEsBmfFNMxiAXvfEeUImOtnjMb;
				NTKOqlhAzYCUXMRuFcFjQesOHnQ nTKOqlhAzYCUXMRuFcFjQesOHnQ2;
				do
				{
					nTKOqlhAzYCUXMRuFcFjQesOHnQ2 = nTKOqlhAzYCUXMRuFcFjQesOHnQ;
					NTKOqlhAzYCUXMRuFcFjQesOHnQ value2 = (NTKOqlhAzYCUXMRuFcFjQesOHnQ)Delegate.Combine(nTKOqlhAzYCUXMRuFcFjQesOHnQ2, value);
					nTKOqlhAzYCUXMRuFcFjQesOHnQ = Interlocked.CompareExchange(ref adEsBmfFNMxiAXvfEeUImOtnjMb, value2, nTKOqlhAzYCUXMRuFcFjQesOHnQ2);
				}
				while ((object)nTKOqlhAzYCUXMRuFcFjQesOHnQ != nTKOqlhAzYCUXMRuFcFjQesOHnQ2);
			}
			remove
			{
				NTKOqlhAzYCUXMRuFcFjQesOHnQ nTKOqlhAzYCUXMRuFcFjQesOHnQ = adEsBmfFNMxiAXvfEeUImOtnjMb;
				NTKOqlhAzYCUXMRuFcFjQesOHnQ nTKOqlhAzYCUXMRuFcFjQesOHnQ2;
				do
				{
					nTKOqlhAzYCUXMRuFcFjQesOHnQ2 = nTKOqlhAzYCUXMRuFcFjQesOHnQ;
					NTKOqlhAzYCUXMRuFcFjQesOHnQ value2 = (NTKOqlhAzYCUXMRuFcFjQesOHnQ)Delegate.Remove(nTKOqlhAzYCUXMRuFcFjQesOHnQ2, value);
					nTKOqlhAzYCUXMRuFcFjQesOHnQ = Interlocked.CompareExchange(ref adEsBmfFNMxiAXvfEeUImOtnjMb, value2, nTKOqlhAzYCUXMRuFcFjQesOHnQ2);
				}
				while ((object)nTKOqlhAzYCUXMRuFcFjQesOHnQ != nTKOqlhAzYCUXMRuFcFjQesOHnQ2);
			}
		}

		public event YrgWGjOKeHRPyckVeZiwDeiZhZQi Removed
		{
			add
			{
				YrgWGjOKeHRPyckVeZiwDeiZhZQi yrgWGjOKeHRPyckVeZiwDeiZhZQi = IkNXhhcntTYnlMaACTXMwvHLHkM;
				YrgWGjOKeHRPyckVeZiwDeiZhZQi yrgWGjOKeHRPyckVeZiwDeiZhZQi2;
				do
				{
					yrgWGjOKeHRPyckVeZiwDeiZhZQi2 = yrgWGjOKeHRPyckVeZiwDeiZhZQi;
					YrgWGjOKeHRPyckVeZiwDeiZhZQi value2 = (YrgWGjOKeHRPyckVeZiwDeiZhZQi)Delegate.Combine(yrgWGjOKeHRPyckVeZiwDeiZhZQi2, value);
					yrgWGjOKeHRPyckVeZiwDeiZhZQi = Interlocked.CompareExchange(ref IkNXhhcntTYnlMaACTXMwvHLHkM, value2, yrgWGjOKeHRPyckVeZiwDeiZhZQi2);
				}
				while ((object)yrgWGjOKeHRPyckVeZiwDeiZhZQi != yrgWGjOKeHRPyckVeZiwDeiZhZQi2);
			}
			remove
			{
				YrgWGjOKeHRPyckVeZiwDeiZhZQi yrgWGjOKeHRPyckVeZiwDeiZhZQi = IkNXhhcntTYnlMaACTXMwvHLHkM;
				YrgWGjOKeHRPyckVeZiwDeiZhZQi yrgWGjOKeHRPyckVeZiwDeiZhZQi2;
				do
				{
					yrgWGjOKeHRPyckVeZiwDeiZhZQi2 = yrgWGjOKeHRPyckVeZiwDeiZhZQi;
					YrgWGjOKeHRPyckVeZiwDeiZhZQi value2 = (YrgWGjOKeHRPyckVeZiwDeiZhZQi)Delegate.Remove(yrgWGjOKeHRPyckVeZiwDeiZhZQi2, value);
					yrgWGjOKeHRPyckVeZiwDeiZhZQi = Interlocked.CompareExchange(ref IkNXhhcntTYnlMaACTXMwvHLHkM, value2, yrgWGjOKeHRPyckVeZiwDeiZhZQi2);
				}
				while ((object)yrgWGjOKeHRPyckVeZiwDeiZhZQi != yrgWGjOKeHRPyckVeZiwDeiZhZQi2);
			}
		}

		public static XxyJWBtqXuLRkPzhutTHCoiNIZYC yuZWzefywVncOLtKjjtqVVIyemk(IntPtr P_0, string P_1)
		{
			return new XxyJWBtqXuLRkPzhutTHCoiNIZYC(P_0, P_1, P_1, "", "", 0, 0, isBluetoothDevice: false, "");
		}

		public XxyJWBtqXuLRkPzhutTHCoiNIZYC(IntPtr rawInputDeviceHandle, string devicePath, string instanceId, string description, string manufacturer, int hubId, int portId, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			getGvAiwqyoBEKJbmsZSbrharXkz = rawInputDeviceHandle;
			try
			{
				daoTxRCmXXmibNhjAmdcoXelKQb = devicePath;
				pvIaqSGSuhkjTRAnubbOiUOObAX = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(devicePath);
				VxUhDlcjidEycVnEHXAILRBgalp = instanceId;
				rrJNMMeMhokXfROOkwMcgUyWaYg = StringTools.SanitizeDeviceString(description);
				ViTZqpvtTcCdLlRVkAufqgDkycT = StringTools.SanitizeDeviceString(manufacturer);
				jRFJgnmwOOJSXkeCnRcESkovPE = hubId;
				eeLTrRQdylLGfNoddAVIYEdRKZX = portId;
				xxPspZGrBhzkMNuatDLYgiLSuNt = isBluetoothDevice;
				VuciFjzmuBBoGrgqemyvYeCPmgV = StringTools.SanitizeDeviceString(bluetoothDeviceName);
				if (!IsOpen)
				{
					dyISvrQQLAplFeQTTAQqwpEZcGZi = true;
					HBtXOJfHBVSdLpJeGXAVcmyhoqj = rawInputDeviceHandle;
					IsOpen = true;
				}
				IntPtr hBtXOJfHBVSdLpJeGXAVcmyhoqj = HBtXOJfHBVSdLpJeGXAVcmyhoqj;
				hVPgmpKSqUNsJCKANsrpHaZKSaOj = oODKWlXjjUaKGJbFcHDHZKTTKwC.unkHHMbJizIemykrHyCvbWrmLzb(hBtXOJfHBVSdLpJeGXAVcmyhoqj);
				EkePzpkLzuzSIRLUyKlYiOgzfiq = oODKWlXjjUaKGJbFcHDHZKTTKwC.oUKYtRjndsnSaFReBFAegBsNobB(hBtXOJfHBVSdLpJeGXAVcmyhoqj);
				ScGxawGDbnpKoQXoSKxTPxPwifG = oODKWlXjjUaKGJbFcHDHZKTTKwC.unkHHMbJizIemykrHyCvbWrmLzb(hBtXOJfHBVSdLpJeGXAVcmyhoqj);
				AFozQbdaJQSKUhyiDSxZeeWhhsH = oODKWlXjjUaKGJbFcHDHZKTTKwC.UKfCEmjVfTtJxicvObnisHHaFOpb(hBtXOJfHBVSdLpJeGXAVcmyhoqj, 0, ScGxawGDbnpKoQXoSKxTPxPwifG.NumberInputButtonCaps);
				AvydjJcgvZaZvhoPvdrIajnElKi = oODKWlXjjUaKGJbFcHDHZKTTKwC.faMscNYkvTnzFvGHlhmSJbJYxbd(hBtXOJfHBVSdLpJeGXAVcmyhoqj, 0, ScGxawGDbnpKoQXoSKxTPxPwifG.NumberInputValueCaps);
				_ = EkePzpkLzuzSIRLUyKlYiOgzfiq;
				_ = ScGxawGDbnpKoQXoSKxTPxPwifG;
				_ = AFozQbdaJQSKUhyiDSxZeeWhhsH;
				_ = AvydjJcgvZaZvhoPvdrIajnElKi;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error querying HID device \"{devicePath}\" at location {HBtXOJfHBVSdLpJeGXAVcmyhoqj}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
			}
			finally
			{
				try
				{
					UvHrZvEbOOuQkrsjogEOCCoIacZ();
				}
				catch
				{
				}
			}
		}

		public void lnrYGKHiMVbmPCPHxupspWXFqVJT()
		{
			lnrYGKHiMVbmPCPHxupspWXFqVJT(sSitzLtsLskxvjKvTBbkifCoAGX.cuTASueltitUKmsLGmZrmKPFLNb, sSitzLtsLskxvjKvTBbkifCoAGX.cuTASueltitUKmsLGmZrmKPFLNb, dcMHdvBJUgQSpaRiuINemzFFmMJU.ZllbRgxAcXAWxMqOuwSYWhYHMiK);
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.lnrYGKHiMVbmPCPHxupspWXFqVJT()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lnrYGKHiMVbmPCPHxupspWXFqVJT
			this.lnrYGKHiMVbmPCPHxupspWXFqVJT();
		}

		public void lnrYGKHiMVbmPCPHxupspWXFqVJT(sSitzLtsLskxvjKvTBbkifCoAGX P_0, sSitzLtsLskxvjKvTBbkifCoAGX P_1, dcMHdvBJUgQSpaRiuINemzFFmMJU P_2)
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				IsOpen = true;
				return;
			}
			VYIinJkjhciPfaAPlpHhYFumsghF = P_0;
			ACsbZcHkQManajrogbVtLUPwLHAX = P_1;
			try
			{
				HBtXOJfHBVSdLpJeGXAVcmyhoqj = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, P_0, 2147483648u, P_2);
			}
			catch (Exception innerException)
			{
				IsOpen = false;
				throw new Exception("Error opening HID device.", innerException);
			}
			IsOpen = HBtXOJfHBVSdLpJeGXAVcmyhoqj.ToInt32() != -1;
			_ = IsOpen;
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.lnrYGKHiMVbmPCPHxupspWXFqVJT(sSitzLtsLskxvjKvTBbkifCoAGX P_0, sSitzLtsLskxvjKvTBbkifCoAGX P_1, dcMHdvBJUgQSpaRiuINemzFFmMJU P_2)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lnrYGKHiMVbmPCPHxupspWXFqVJT
			this.lnrYGKHiMVbmPCPHxupspWXFqVJT(P_0, P_1, P_2);
		}

		public void UvHrZvEbOOuQkrsjogEOCCoIacZ()
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				IsOpen = false;
			}
			else if (IsOpen)
			{
				if (HBtXOJfHBVSdLpJeGXAVcmyhoqj != IntPtr.Zero)
				{
					oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(HBtXOJfHBVSdLpJeGXAVcmyhoqj);
				}
				IsOpen = false;
				HBtXOJfHBVSdLpJeGXAVcmyhoqj = IntPtr.Zero;
			}
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.UvHrZvEbOOuQkrsjogEOCCoIacZ()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UvHrZvEbOOuQkrsjogEOCCoIacZ
			this.UvHrZvEbOOuQkrsjogEOCCoIacZ();
		}

		public QzxTvOeWALIhvefHOWyHODDSlRY OyoZWUuiamgvSVRBhbJZhjZZxdr()
		{
			return null;
		}

		QzxTvOeWALIhvefHOWyHODDSlRY MFFbigtCSAERTKmOTUlnAJmgNhe.OyoZWUuiamgvSVRBhbJZhjZZxdr()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OyoZWUuiamgvSVRBhbJZhjZZxdr
			return this.OyoZWUuiamgvSVRBhbJZhjZZxdr();
		}

		public void OyoZWUuiamgvSVRBhbJZhjZZxdr(WboBSzaOvaGnoDvWcEyTNabfeKPi P_0)
		{
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.OyoZWUuiamgvSVRBhbJZhjZZxdr(WboBSzaOvaGnoDvWcEyTNabfeKPi P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OyoZWUuiamgvSVRBhbJZhjZZxdr
			this.OyoZWUuiamgvSVRBhbJZhjZZxdr(P_0);
		}

		public QzxTvOeWALIhvefHOWyHODDSlRY OyoZWUuiamgvSVRBhbJZhjZZxdr(int P_0)
		{
			return null;
		}

		QzxTvOeWALIhvefHOWyHODDSlRY MFFbigtCSAERTKmOTUlnAJmgNhe.OyoZWUuiamgvSVRBhbJZhjZZxdr(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OyoZWUuiamgvSVRBhbJZhjZZxdr
			return this.OyoZWUuiamgvSVRBhbJZhjZZxdr(P_0);
		}

		public void eJmTJbYCnNjJDasIEjBfvvrpainh(cScLsgruiYkFMGVBIpdtnHDqiULG P_0)
		{
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.eJmTJbYCnNjJDasIEjBfvvrpainh(cScLsgruiYkFMGVBIpdtnHDqiULG P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eJmTJbYCnNjJDasIEjBfvvrpainh
			this.eJmTJbYCnNjJDasIEjBfvvrpainh(P_0);
		}

		public nQfFkZhVbYgCICGbKJhqQlKDtpOT eJmTJbYCnNjJDasIEjBfvvrpainh(int P_0)
		{
			return null;
		}

		nQfFkZhVbYgCICGbKJhqQlKDtpOT MFFbigtCSAERTKmOTUlnAJmgNhe.eJmTJbYCnNjJDasIEjBfvvrpainh(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eJmTJbYCnNjJDasIEjBfvvrpainh
			return this.eJmTJbYCnNjJDasIEjBfvvrpainh(P_0);
		}

		public nQfFkZhVbYgCICGbKJhqQlKDtpOT eJmTJbYCnNjJDasIEjBfvvrpainh()
		{
			return null;
		}

		nQfFkZhVbYgCICGbKJhqQlKDtpOT MFFbigtCSAERTKmOTUlnAJmgNhe.eJmTJbYCnNjJDasIEjBfvvrpainh()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eJmTJbYCnNjJDasIEjBfvvrpainh
			return this.eJmTJbYCnNjJDasIEjBfvvrpainh();
		}

		public bool giZjACpkSfOvkplJFaRRDeJUHNqO(out byte[] P_0, byte P_1 = 0)
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				P_0 = null;
				return false;
			}
			if (ScGxawGDbnpKoQXoSKxTPxPwifG.FeatureReportByteLength <= 0)
			{
				P_0 = new byte[0];
				return false;
			}
			P_0 = new byte[ScGxawGDbnpKoQXoSKxTPxPwifG.FeatureReportByteLength];
			byte[] array = xMMULUEMsjmsHKOCfyIGQoSjNIG();
			array[0] = P_1;
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (IsOpen)
				{
					intPtr = Handle;
				}
				else
				{
					intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				flag = MsdjFrwPRhtDqvryUwwfexLTAxz.RcVsesqGgWdMmfGYPJXQxGvncjc(intPtr, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, ScGxawGDbnpKoQXoSKxTPxPwifG.FeatureReportByteLength));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{daoTxRCmXXmibNhjAmdcoXelKQb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
				}
			}
			return flag;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.giZjACpkSfOvkplJFaRRDeJUHNqO(out byte[] P_0, byte P_1 = 0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in giZjACpkSfOvkplJFaRRDeJUHNqO
			return this.giZjACpkSfOvkplJFaRRDeJUHNqO(out P_0, P_1);
		}

		public string qZvONhbQmhqKnNrMmPatPTIwFOu()
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				return string.Empty;
			}
			try
			{
				if (!qZvONhbQmhqKnNrMmPatPTIwFOu(out var bytes))
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

		string MFFbigtCSAERTKmOTUlnAJmgNhe.qZvONhbQmhqKnNrMmPatPTIwFOu()
		{
			//ILSpy generated this explicit interface implementation from .override directive in qZvONhbQmhqKnNrMmPatPTIwFOu
			return this.qZvONhbQmhqKnNrMmPatPTIwFOu();
		}

		public unsafe bool qZvONhbQmhqKnNrMmPatPTIwFOu(out byte[] P_0)
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				P_0 = null;
				return false;
			}
			P_0 = new byte[255];
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (IsOpen)
				{
					intPtr = Handle;
				}
				else
				{
					intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				fixed (IntPtr* ptr = P_0)
				{
					return MsdjFrwPRhtDqvryUwwfexLTAxz.GlXcmJBQitnDECFfxhHKfVrMKMaC(intPtr, (IntPtr)ptr, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{daoTxRCmXXmibNhjAmdcoXelKQb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
				}
			}
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.qZvONhbQmhqKnNrMmPatPTIwFOu(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qZvONhbQmhqKnNrMmPatPTIwFOu
			return this.qZvONhbQmhqKnNrMmPatPTIwFOu(out P_0);
		}

		public string sGlGxVXmpWmZtSOOjiEBDZjUYMx()
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				return string.Empty;
			}
			sGlGxVXmpWmZtSOOjiEBDZjUYMx(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string MFFbigtCSAERTKmOTUlnAJmgNhe.sGlGxVXmpWmZtSOOjiEBDZjUYMx()
		{
			//ILSpy generated this explicit interface implementation from .override directive in sGlGxVXmpWmZtSOOjiEBDZjUYMx
			return this.sGlGxVXmpWmZtSOOjiEBDZjUYMx();
		}

		public bool sGlGxVXmpWmZtSOOjiEBDZjUYMx(out byte[] P_0)
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				P_0 = null;
				return false;
			}
			P_0 = new byte[255];
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (IsOpen)
				{
					intPtr = Handle;
				}
				else
				{
					intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = MsdjFrwPRhtDqvryUwwfexLTAxz.OOwDsbaxWqDPAFuWXroVMGVZmEGx(intPtr, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
				return flag;
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{daoTxRCmXXmibNhjAmdcoXelKQb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
				}
			}
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.sGlGxVXmpWmZtSOOjiEBDZjUYMx(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in sGlGxVXmpWmZtSOOjiEBDZjUYMx
			return this.sGlGxVXmpWmZtSOOjiEBDZjUYMx(out P_0);
		}

		public string BRmxKCgUEwFrfmXPnrqBAXoQjAk()
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				return string.Empty;
			}
			BRmxKCgUEwFrfmXPnrqBAXoQjAk(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string MFFbigtCSAERTKmOTUlnAJmgNhe.BRmxKCgUEwFrfmXPnrqBAXoQjAk()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BRmxKCgUEwFrfmXPnrqBAXoQjAk
			return this.BRmxKCgUEwFrfmXPnrqBAXoQjAk();
		}

		public bool BRmxKCgUEwFrfmXPnrqBAXoQjAk(out byte[] P_0)
		{
			if (dyISvrQQLAplFeQTTAQqwpEZcGZi)
			{
				P_0 = null;
				return false;
			}
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (IsOpen)
				{
					intPtr = Handle;
				}
				else
				{
					intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(daoTxRCmXXmibNhjAmdcoXelKQb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						P_0 = null;
						return false;
					}
				}
				return oODKWlXjjUaKGJbFcHDHZKTTKwC.BRmxKCgUEwFrfmXPnrqBAXoQjAk(intPtr, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{daoTxRCmXXmibNhjAmdcoXelKQb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
				}
			}
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.BRmxKCgUEwFrfmXPnrqBAXoQjAk(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BRmxKCgUEwFrfmXPnrqBAXoQjAk
			return this.BRmxKCgUEwFrfmXPnrqBAXoQjAk(out P_0);
		}

		public string RwEQTNETrqDeeSkUTEKecRRXDypo()
		{
			return "";
		}

		string MFFbigtCSAERTKmOTUlnAJmgNhe.RwEQTNETrqDeeSkUTEKecRRXDypo()
		{
			//ILSpy generated this explicit interface implementation from .override directive in RwEQTNETrqDeeSkUTEKecRRXDypo
			return this.RwEQTNETrqDeeSkUTEKecRRXDypo();
		}

		public bool RwEQTNETrqDeeSkUTEKecRRXDypo(out byte[] P_0)
		{
			P_0 = null;
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.RwEQTNETrqDeeSkUTEKecRRXDypo(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RwEQTNETrqDeeSkUTEKecRRXDypo
			return this.RwEQTNETrqDeeSkUTEKecRRXDypo(out P_0);
		}

		public void xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, PBvXXgHbvFJeaFjSccufKDEsLTv P_1)
		{
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, PBvXXgHbvFJeaFjSccufKDEsLTv P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xwyOTGiXUEnQReUfdMBlfOwNgvM
			this.xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1);
		}

		public bool xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xwyOTGiXUEnQReUfdMBlfOwNgvM
			return this.xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0);
		}

		public bool xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xwyOTGiXUEnQReUfdMBlfOwNgvM
			return this.xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1);
		}

		public void zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0, PBvXXgHbvFJeaFjSccufKDEsLTv P_1)
		{
		}

		void MFFbigtCSAERTKmOTUlnAJmgNhe.zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0, PBvXXgHbvFJeaFjSccufKDEsLTv P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zJVPoQUlTVMXcfhBGcAknTCRyOt
			this.zJVPoQUlTVMXcfhBGcAknTCRyOt(P_0, P_1);
		}

		public bool zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zJVPoQUlTVMXcfhBGcAknTCRyOt
			return this.zJVPoQUlTVMXcfhBGcAknTCRyOt(P_0);
		}

		public bool zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0, int P_1)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.zJVPoQUlTVMXcfhBGcAknTCRyOt(nQfFkZhVbYgCICGbKJhqQlKDtpOT P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zJVPoQUlTVMXcfhBGcAknTCRyOt
			return this.zJVPoQUlTVMXcfhBGcAknTCRyOt(P_0, P_1);
		}

		public nQfFkZhVbYgCICGbKJhqQlKDtpOT XJHSwSThcRmWsusbmEFmrqvrmGS()
		{
			return null;
		}

		nQfFkZhVbYgCICGbKJhqQlKDtpOT MFFbigtCSAERTKmOTUlnAJmgNhe.XJHSwSThcRmWsusbmEFmrqvrmGS()
		{
			//ILSpy generated this explicit interface implementation from .override directive in XJHSwSThcRmWsusbmEFmrqvrmGS
			return this.XJHSwSThcRmWsusbmEFmrqvrmGS();
		}

		public bool EFfTeRnFMWfLsvrhUZWcVJwBSwa(byte[] P_0)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.EFfTeRnFMWfLsvrhUZWcVJwBSwa(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EFfTeRnFMWfLsvrhUZWcVJwBSwa
			return this.EFfTeRnFMWfLsvrhUZWcVJwBSwa(P_0);
		}

		public void Dispose()
		{
		}

		public bool RNMBtPgCfOgWhDTcqfZdPVhxISL(OutputReport P_0)
		{
			return false;
		}

		bool MFFbigtCSAERTKmOTUlnAJmgNhe.RNMBtPgCfOgWhDTcqfZdPVhxISL(OutputReport P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RNMBtPgCfOgWhDTcqfZdPVhxISL
			return this.RNMBtPgCfOgWhDTcqfZdPVhxISL(P_0);
		}

		private byte[] oxWLerLcbELkrhbRRSStTuBNazo()
		{
			return WVfORyVukVevWMJiepJMUPlDhng(Capabilities.InputReportByteLength - 1);
		}

		private byte[] BvdxIdJUEedzcnBxmChlyEzTqmW()
		{
			return WVfORyVukVevWMJiepJMUPlDhng(Capabilities.OutputReportByteLength - 1);
		}

		private byte[] xMMULUEMsjmsHKOCfyIGQoSjNIG()
		{
			return WVfORyVukVevWMJiepJMUPlDhng(Capabilities.FeatureReportByteLength - 1);
		}

		private static byte[] WVfORyVukVevWMJiepJMUPlDhng(int P_0)
		{
			byte[] array = null;
			Array.Resize(ref array, P_0 + 1);
			return array;
		}
	}

	private sealed class ZOavNtPzbJokcePRMYDxsOThHel
	{
		public IList<pDdfcWqxDAHCEFuHEUpBobYCGVaf.aBGHUHfNCcVnSUkIQdHgprgokKHB> UJjngNatkPneKgncEeGuykKsXG;
	}

	private sealed class IAqVJhMmjnyKulMdBLXwfHCLvKy
	{
		public ZOavNtPzbJokcePRMYDxsOThHel RCBgVSyZHTKrhjVEtIAFVoRbzcu;

		public int LSBZNFvFIBjrdZJYfgPRzEbigLTH;

		public bool YashnAjqMMwCFgHZvtGNujKRKsb(string P_0)
		{
			return P_0.Equals(RCBgVSyZHTKrhjVEtIAFVoRbzcu.UJjngNatkPneKgncEeGuykKsXG[LSBZNFvFIBjrdZJYfgPRzEbigLTH].LMaMbxUwpISaejpwpFWYBPvqSto, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class hFGRnpnmGSdItjUopCIRLKQJdJYA
	{
		public XISatJdVArtMUkOXRoGcIhpgBatq FkmnFtdKieRqBiwGIrLzzcwjOpn;

		public bool fGRXkgvHAZlpOQFVVEqNWQBLtVr(XISatJdVArtMUkOXRoGcIhpgBatq P_0)
		{
			return P_0.InstanceGuid == FkmnFtdKieRqBiwGIrLzzcwjOpn.InstanceGuid;
		}
	}

	private sealed class HbvIOCdWqqJLSpqLtMzUWheKZKsh
	{
		public MFFbigtCSAERTKmOTUlnAJmgNhe jDVtkZrKNwkxGhxQCjCBsSeZqLz;

		public byte[] NoQhcQNyhZweugGoCsmFrRWGtUA(byte P_0)
		{
			jDVtkZrKNwkxGhxQCjCBsSeZqLz.giZjACpkSfOvkplJFaRRDeJUHNqO(out var result, P_0);
			return result;
		}
	}

	private sealed class qqoLMCWhEreviyjNNWcZApFsRit
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public CDUDUtloSCOYNTanpthEeshuCdC jCCESxhkXKXRASiiyhhDQRyWTmj;

		public void CEsqPtPFaJvJViOgiHsHvHvnrZr()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)4, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb | udeFPeagJNADrdnQrjwMerhHHxJM.GmDsHlwLzkfpMfwfAeiWNmARfusX, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)5, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb | udeFPeagJNADrdnQrjwMerhHHxJM.GmDsHlwLzkfpMfwfAeiWNmARfusX, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)8, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb | udeFPeagJNADrdnQrjwMerhHHxJM.GmDsHlwLzkfpMfwfAeiWNmARfusX, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)12, (VABRdqYQwczyEykxLDdEfwgXtM)1, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb | udeFPeagJNADrdnQrjwMerhHHxJM.GmDsHlwLzkfpMfwfAeiWNmARfusX, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class kxBnLPdUkVFkYvwerScZpPgXsSl
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public void sELLpYEudfrFaXVykIRJxosLcOD()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)4);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)5);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)8);
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)12, (VABRdqYQwczyEykxLDdEfwgXtM)1);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class WcPaGqfKnjUGbChbeyFOrVNwbFsA
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public void PBjIRQDktJzVfcoKqRUQCJBLrGp()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)2);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class ZcGEhAAHzJcSJnnxnHTDYJXxWppg
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public CDUDUtloSCOYNTanpthEeshuCdC jCCESxhkXKXRASiiyhhDQRyWTmj;

		public void KNLlJqEmwZCyCBWTdKLVoNYKjpc()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)2, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class TbtIKzjfZigmcImSIHiVHiZkaPKL
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public CDUDUtloSCOYNTanpthEeshuCdC jCCESxhkXKXRASiiyhhDQRyWTmj;

		public void aarbMvUvgwMvoGmpcjxMgGPfTGC()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)6, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb, jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class IYYOfdESmgjOwbcVZbiwdhkzNPwW
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public void rZiCCnsEMBiSpRBdSzbOXQtvcaU()
		{
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.eOHWtWJjUGQSvtUiHnEKkDIcqJr((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)6);
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private sealed class JBYcIcYcdkAoQgkNkcdvHtflsie
	{
		public bool PyuFrSBeUIgNtjBlGISqDiWaodoK;

		public CDUDUtloSCOYNTanpthEeshuCdC jCCESxhkXKXRASiiyhhDQRyWTmj;

		public fIwdfzxbbCPDQCFdxJoWFgqoGVGe.bzlLqTJAxhIKJodCgngLvqCPWrE wWevsbVsXuPVWtRMvxCBvbCpQXa;

		public void tOujmeWIaeEVzAMhUdIuebBnZwe()
		{
			try
			{
				jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx = fnnlHdsyZpALwxMzxiWeUCCSBnI(wWevsbVsXuPVWtRMvxCBvbCpQXa);
				if (jCCESxhkXKXRASiiyhhDQRyWTmj.TkzRUwgZbBhFZfoYvaKmbxZGcfmx == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				PyuFrSBeUIgNtjBlGISqDiWaodoK = true;
			}
		}
	}

	private const float fkcXfnhrBHjyuIxcXyjKspfgMWg = 0.25f;

	private const float JoPzRAJUkuwzLrrcKRoxennofYZ = 1f;

	private List<XISatJdVArtMUkOXRoGcIhpgBatq> BNRwQaHYudxtMzjvBeOOjyanYNh;

	private List<XISatJdVArtMUkOXRoGcIhpgBatq> gQqqTxfqVPojznoSqApJbGNnQoI;

	private ReadOnlyCollection<XISatJdVArtMUkOXRoGcIhpgBatq> yXiXNavUOhRWVTCnadoOpdMlygu;

	private SItXuYbYOTfkYGCaLEfPjCCHCOnG bfGNYwKXEUTHcSMsSbVYbqRcFyX;

	private semsxMCoWgefAkNrSJJwPcOjkQI EyqykcmEIygobLZbPDDtXCagSsP;

	private ConfigVars VsMgYcimWEGlycMVKSeLPFvWQnhv;

	private UpdateLoopSetting FgREoWxRjDNWqaQZIHifDtHgOgI;

	private readonly bool GgcxdJMndFQaXoamiKBfmlMxEvw;

	private readonly bool wjKcjakyNggjYkTtNALWrDlwLpFA;

	private readonly bool MHOguSHKDpCslowFrgeilBKioqQB;

	private readonly bool nDrVOOXzsMdXepMzAAVSLdpYhnhj;

	private readonly bool uBGKEXTNaXBEteCerUaGHNPNSQc;

	private bool XHqfwIZrEzfEEjDzfeJbcZXckXxw;

	private bool tkezIZqHnQlbxumsBBCHAyEESwfR;

	private bool pDRnBUTRxwqAzNGgJBEDIpRruQF;

	private bool hpZcELkRkEkNGhdBRByTprKSdTH;

	private int GcaBhOZSJvXXckgzCClGnWStIA;

	private readonly object hPJCLiCUpxQTtluQoqkhIxuyRXEw = new object();

	private readonly uATVrxLrtwlNyXjbHebdtrBRgRv nOcGEnklYEcclVReawchLHwxZEu;

	private int eTHDwqAftXgPlLgTRMewNGmXZKpP = -1;

	private dHXyzyTbuzAetPEwCgxUBzMPWtiN sZDCuXonuesoQqBPayGRZTryRwu;

	private IntPtr ZvsyKgFylLUNgnDmrXZkzAIyLYs;

	private IntPtr NFihkPDnwgEcYWzGEwNbqjdpvyq;

	private ValueWatcher<IntPtr> NNSzYtnWHdPHWjkuyfCECFBZfORy;

	private ValueWatcher[] zfEgxqGPNstOlkOMkENMdZhbgtgb;

	private double jMYCGEpEuXlxLgeslzAwkmYzpHi;

	private fIwdfzxbbCPDQCFdxJoWFgqoGVGe TkzRUwgZbBhFZfoYvaKmbxZGcfmx;

	private EugmBWQTjvJBXorkcWtQvGwQgTc PoDjTJppaPPtHExXCWvCBnzfiwi;

	private static HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA nRnzUwmHLpPXKgtXVmMeRSTttZA;

	private HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs JSaUXKdCgfvlHCGoSdQDEIIStAKP;

	private NativeBuffer sleBOBolfTikaIEYLQUTzKrAguY;

	private static Rewired.Internal.GUIText WvNFRSCUwacXNIADgFbvovXxqsfb;

	private static YPnvfkdqdmvaoZJfetQblvZMSRZ[] kUZREHlWMZmcqoMkaBEJCdiHtqHC = new YPnvfkdqdmvaoZJfetQblvZMSRZ[4]
	{
		new YPnvfkdqdmvaoZJfetQblvZMSRZ(1, 4),
		new YPnvfkdqdmvaoZJfetQblvZMSRZ(1, 5),
		new YPnvfkdqdmvaoZJfetQblvZMSRZ(1, 8),
		new YPnvfkdqdmvaoZJfetQblvZMSRZ(12, 1)
	};

	private readonly BNfOmYDxvqNCLrrYukBTimTmfzA vvTSFtolMIxRVZqcBIGPVuQyeOG = new BNfOmYDxvqNCLrrYukBTimTmfzA();

	private readonly ipwruYYKPldFWmYuJnDLBmTbJhD qYgvtOJkaJDYbkSIbvVGywNGPsE = new ipwruYYKPldFWmYuJnDLBmTbJhD();

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	[CompilerGenerated]
	private static Action<XISatJdVArtMUkOXRoGcIhpgBatq> XPHcFbixprBJKYePXgDMyiOncKzj;

	public static Rewired.Internal.GUIText guiText
	{
		get
		{
			if (WvNFRSCUwacXNIADgFbvovXxqsfb != null)
			{
				return WvNFRSCUwacXNIADgFbvovXxqsfb;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			if (gameObject != null)
			{
				WvNFRSCUwacXNIADgFbvovXxqsfb = gameObject.GetComponent<Rewired.Internal.GUIText>();
			}
			else
			{
				gameObject = new GameObject("DebugScreenLog");
				gameObject.transform.position = Vector3.zero;
				WvNFRSCUwacXNIADgFbvovXxqsfb = gameObject.AddComponent<Rewired.Internal.GUIText>();
				WvNFRSCUwacXNIADgFbvovXxqsfb.anchor = TextAnchor.LowerLeft;
				WvNFRSCUwacXNIADgFbvovXxqsfb.alignment = TextAlignment.Left;
				WvNFRSCUwacXNIADgFbvovXxqsfb.pixelOffset = new Vector2(1200f, 0f);
			}
			return WvNFRSCUwacXNIADgFbvovXxqsfb;
		}
	}

	public event Action DeviceChangedEvent
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
			throw new NotImplementedException();
		}
	}

	public CDUDUtloSCOYNTanpthEeshuCdC(ConfigVars configVars, bool handleJoysticks, bool useCustomDrivers, SItXuYbYOTfkYGCaLEfPjCCHCOnG unifiedMouse, semsxMCoWgefAkNrSJJwPcOjkQI unifiedKeyboard)
	{
		try
		{
			VsMgYcimWEGlycMVKSeLPFvWQnhv = configVars;
			FgREoWxRjDNWqaQZIHifDtHgOgI = configVars.updateLoop;
			NNSzYtnWHdPHWjkuyfCECFBZfORy = new ValueWatcher<IntPtr>(AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR(), AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR, autoTriggerEvent: true);
			NNSzYtnWHdPHWjkuyfCECFBZfORy.ChangedEvent += TXfLlMufNNaPJIpZbCHyloukmKxF;
			zfEgxqGPNstOlkOMkENMdZhbgtgb = new ValueWatcher[1] { NNSzYtnWHdPHWjkuyfCECFBZfORy };
			wjKcjakyNggjYkTtNALWrDlwLpFA = handleJoysticks;
			uBGKEXTNaXBEteCerUaGHNPNSQc = useCustomDrivers;
			bfGNYwKXEUTHcSMsSbVYbqRcFyX = unifiedMouse;
			EyqykcmEIygobLZbPDDtXCagSsP = unifiedKeyboard;
			MHOguSHKDpCslowFrgeilBKioqQB = unifiedMouse != null;
			nDrVOOXzsMdXepMzAAVSLdpYhnhj = unifiedKeyboard != null;
			GgcxdJMndFQaXoamiKBfmlMxEvw = ReInput.isEditor;
			BNRwQaHYudxtMzjvBeOOjyanYNh = new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
			yXiXNavUOhRWVTCnadoOpdMlygu = new ReadOnlyCollection<XISatJdVArtMUkOXRoGcIhpgBatq>(BNRwQaHYudxtMzjvBeOOjyanYNh);
			gQqqTxfqVPojznoSqApJbGNnQoI = new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
			nRnzUwmHLpPXKgtXVmMeRSTttZA = new HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA
			{
				LSkXGyldcGzcsniYgtVoxFzBUgQ = (uint)Marshal.SizeOf(typeof(HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA)),
				NxwKXiZZPzGfbqADNsYbSmCSZMr = true,
				SktzEWBrrBtdyOnqVaQOcPBxxEu = true,
				aWbSUhJDvCdVtkllSTkeGNeulCj = false,
				RfxaCqCTZtXRJOcskupfnYkFpXpO = true,
				jHDwUiAeZVEJETgBGdZFfndmbpOD = IntPtr.Zero
			};
			JSaUXKdCgfvlHCGoSdQDEIIStAKP = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs.XEZZaRuCBatWlcrdVaazQoMlqtI();
			sleBOBolfTikaIEYLQUTzKrAguY = new NativeBuffer((int)JSaUXKdCgfvlHCGoSdQDEIIStAKP.LSkXGyldcGzcsniYgtVoxFzBUgQ);
			sleBOBolfTikaIEYLQUTzKrAguY.Write(JSaUXKdCgfvlHCGoSdQDEIIStAKP.LSkXGyldcGzcsniYgtVoxFzBUgQ, 0);
			if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
			{
				oMRLBYjdihAhVZHfzaElKUtHBYol(SKRvzQSHgIEBgwIYQAoOmdXStap);
				YUSBsLIhAHghefmIfcNbUiyfyVGH();
			}
			if (handleJoysticks)
			{
				try
				{
					MGgSpbKODMUDxdrrqofKFoVwyxn();
					QACcwYFLqvwWODIguIBSWFlSkwx(ref BNRwQaHYudxtMzjvBeOOjyanYNh, zBdvWOpEyCoezxSNbetUnFYJBhY(true));
				}
				catch (Exception ex)
				{
					if (ex.Data != null && ex.Data.Contains(1))
					{
						string text = ex.Data[1] as string;
						if (text == "sandbox")
						{
							Rewired.Logger.LogWarning("Detected possible sandbox. Raw Input does not work correctly in a sandbox with default security settings.");
						}
					}
					throw;
				}
			}
			rnLvdUVHOwDFpAFwoXQwviYHLJzD();
			ReInput.ApplicationIsFullScreenChangedEvent += QEgviCIOXceAkluEgTvZzmjZFdD;
			ReInput.ApplicationFullScreenModeChangedEvent += SzxrrziurVLHDPmtOGWOBZoWowk;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void MGgSpbKODMUDxdrrqofKFoVwyxn()
	{
	}

	public void bBgkhnueVbhjKRKwscthvcoztta()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			lock (hPJCLiCUpxQTtluQoqkhIxuyRXEw)
			{
				QACcwYFLqvwWODIguIBSWFlSkwx(ref BNRwQaHYudxtMzjvBeOOjyanYNh, gQqqTxfqVPojznoSqApJbGNnQoI);
				gQqqTxfqVPojznoSqApJbGNnQoI.Clear();
			}
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			zlndKKjpzVDnMiHyjStAgQrXDIop();
		}
		pDRnBUTRxwqAzNGgJBEDIpRruQF = false;
	}

	public bool XotdmMEHyLPNWVKWMuMTGEMJsNsB()
	{
		lock (hPJCLiCUpxQTtluQoqkhIxuyRXEw)
		{
			if (TXZUXNyRQGlUCbpyzSobuuiKWFX())
			{
				Thread.Sleep(250);
			}
			gQqqTxfqVPojznoSqApJbGNnQoI = zBdvWOpEyCoezxSNbetUnFYJBhY(false);
			return true;
		}
	}

	public bool bmNDFsCrIgtruDdZyobLpGWnBEYL()
	{
		int num = XuHOGZVIxTlXWkyfxSpBqjGRXSg();
		if (num == GcaBhOZSJvXXckgzCClGnWStIA)
		{
			return false;
		}
		GcaBhOZSJvXXckgzCClGnWStIA = num;
		return true;
	}

	public bool TXZUXNyRQGlUCbpyzSobuuiKWFX()
	{
		try
		{
			return pDdfcWqxDAHCEFuHEUpBobYCGVaf.TXZUXNyRQGlUCbpyzSobuuiKWFX();
		}
		catch
		{
		}
		return false;
	}

	public bool JxwgIWemLgZLViQDegvbxYgcrKE(bool P_0)
	{
		bool result = hpZcELkRkEkNGhdBRByTprKSdTH;
		if (P_0)
		{
			hpZcELkRkEkNGhdBRByTprKSdTH = false;
		}
		return result;
	}

	public void SystemDeviceDisconnected()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			pDRnBUTRxwqAzNGgJBEDIpRruQF = true;
		}
	}

	public void SystemDeviceConnected()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			pDRnBUTRxwqAzNGgJBEDIpRruQF = true;
		}
	}

	public void Update()
	{
		for (int i = 0; i < zfEgxqGPNstOlkOMkENMdZhbgtgb.Length; i++)
		{
			zfEgxqGPNstOlkOMkENMdZhbgtgb[i].Update();
		}
		if (eTHDwqAftXgPlLgTRMewNGmXZKpP >= 0)
		{
			btQBbPUSFaAXXLKTVLNKdHzzlFC();
		}
		if (GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			if (eTHDwqAftXgPlLgTRMewNGmXZKpP < 0 && (nDrVOOXzsMdXepMzAAVSLdpYhnhj || MHOguSHKDpCslowFrgeilBKioqQB))
			{
				MCYowUJlKZrCFoEJQetVIlVuLkLC();
			}
		}
		else if (nDrVOOXzsMdXepMzAAVSLdpYhnhj || MHOguSHKDpCslowFrgeilBKioqQB)
		{
			oOyeBNECWrlaRhMmqxNQlRTINOsf();
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			int count = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
			for (int i = 0; i < count; i++)
			{
				BNRwQaHYudxtMzjvBeOOjyanYNh[i]?.RMEkOMsGFSFWbHqrAFftMTIKNIHO(updateLoop);
			}
		}
	}

	public void UpdateFinished()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			int count = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
			for (int i = 0; i < count; i++)
			{
				BNRwQaHYudxtMzjvBeOOjyanYNh[i]?.xbrgbsymhweSXlyAZAqkvRqFNEB();
			}
		}
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return yXiXNavUOhRWVTCnadoOpdMlygu as IList<T>;
	}

	private List<XISatJdVArtMUkOXRoGcIhpgBatq> zBdvWOpEyCoezxSNbetUnFYJBhY(bool P_0)
	{
		ZOavNtPzbJokcePRMYDxsOThHel zOavNtPzbJokcePRMYDxsOThHel = new ZOavNtPzbJokcePRMYDxsOThHel();
		if (!wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			return new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
		}
		LgKSumIhgmRsfsyhteVwtjUNdnh();
		List<iyIwThXmVTAIckoxFwEfUfmQUsL> list = null;
		List<XISatJdVArtMUkOXRoGcIhpgBatq> list2 = new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
		GcaBhOZSJvXXckgzCClGnWStIA = QKnbTokZqrqrqOTuwoUcFyBEDzZJ();
		if (0 == 0)
		{
			list = EkVkWMYCVwtPsFXxHOsvvAxKeBxA.yDqiGSkMQYxYBcosfJNCvDgVcTXc(P_0);
			bool flag = true;
		}
		if (list == null)
		{
			list = new List<iyIwThXmVTAIckoxFwEfUfmQUsL>();
		}
		try
		{
			zOavNtPzbJokcePRMYDxsOThHel.UJjngNatkPneKgncEeGuykKsXG = pDdfcWqxDAHCEFuHEUpBobYCGVaf.LnfKhouDKJmylVgEuDaGCcHLfNPD();
		}
		catch (Exception ex)
		{
			zOavNtPzbJokcePRMYDxsOThHel.UJjngNatkPneKgncEeGuykKsXG = new List<pDdfcWqxDAHCEFuHEUpBobYCGVaf.aBGHUHfNCcVnSUkIQdHgprgokKHB>();
			Rewired.Logger.LogError("Exception getting HID device list.\n" + ex);
		}
		List<string> list3 = new List<string>();
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq = null;
			try
			{
				iyIwThXmVTAIckoxFwEfUfmQUsL iyIwThXmVTAIckoxFwEfUfmQUsL2 = list[i];
				if (list[i] != null && iyIwThXmVTAIckoxFwEfUfmQUsL2.DeviceType == MAPTyOhgNVdBQSioUpquSdYiRkd.FwhTFJcoxdOAZsdJarteiktzdNZ && iyIwThXmVTAIckoxFwEfUfmQUsL2 is eCLbMTsKFfJvBGnCXBKQePUbRlEi eCLbMTsKFfJvBGnCXBKQePUbRlEi2)
				{
					xISatJdVArtMUkOXRoGcIhpgBatq = aDNArmHkuIGSxGMmilwZnyxHYez(iyIwThXmVTAIckoxFwEfUfmQUsL2.Handle, eCLbMTsKFfJvBGnCXBKQePUbRlEi2, zOavNtPzbJokcePRMYDxsOThHel.UJjngNatkPneKgncEeGuykKsXG, list3, num);
					if (xISatJdVArtMUkOXRoGcIhpgBatq != null)
					{
						list2.Add(xISatJdVArtMUkOXRoGcIhpgBatq);
						num++;
					}
				}
			}
			catch (Exception ex2)
			{
				Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex2.Message);
			}
		}
		if (!VsMgYcimWEGlycMVKSeLPFvWQnhv.useXInput)
		{
			IAqVJhMmjnyKulMdBLXwfHCLvKy aqVJhMmjnyKulMdBLXwfHCLvKy = new IAqVJhMmjnyKulMdBLXwfHCLvKy();
			aqVJhMmjnyKulMdBLXwfHCLvKy.RCBgVSyZHTKrhjVEtIAFVoRbzcu = zOavNtPzbJokcePRMYDxsOThHel;
			aqVJhMmjnyKulMdBLXwfHCLvKy.LSBZNFvFIBjrdZJYfgPRzEbigLTH = 0;
			while (aqVJhMmjnyKulMdBLXwfHCLvKy.LSBZNFvFIBjrdZJYfgPRzEbigLTH < zOavNtPzbJokcePRMYDxsOThHel.UJjngNatkPneKgncEeGuykKsXG.Count)
			{
				XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq2 = null;
				try
				{
					if (string.IsNullOrEmpty(list3.Find(aqVJhMmjnyKulMdBLXwfHCLvKy.YashnAjqMMwCFgHZvtGNujKRKsb)))
					{
						xISatJdVArtMUkOXRoGcIhpgBatq2 = QNKQinqNSqOQRLFbGcaOkrhLBkAp(zOavNtPzbJokcePRMYDxsOThHel.UJjngNatkPneKgncEeGuykKsXG[aqVJhMmjnyKulMdBLXwfHCLvKy.LSBZNFvFIBjrdZJYfgPRzEbigLTH], num);
						if (xISatJdVArtMUkOXRoGcIhpgBatq2 != null)
						{
							list2.Add(xISatJdVArtMUkOXRoGcIhpgBatq2);
							num++;
						}
					}
				}
				catch (Exception ex3)
				{
					Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional." + ex3.Message);
				}
				aqVJhMmjnyKulMdBLXwfHCLvKy.LSBZNFvFIBjrdZJYfgPRzEbigLTH++;
			}
		}
		return list2;
	}

	private static void QACcwYFLqvwWODIguIBSWFlSkwx(ref List<XISatJdVArtMUkOXRoGcIhpgBatq> P_0, List<XISatJdVArtMUkOXRoGcIhpgBatq> P_1)
	{
		if (P_0 == null)
		{
			P_0 = new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
		}
		if (P_1 == null)
		{
			P_1 = new List<XISatJdVArtMUkOXRoGcIhpgBatq>();
		}
		if (P_1.Count == 0)
		{
			P_0.ForEach(delegate(XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq)
			{
				xISatJdVArtMUkOXRoGcIhpgBatq.Dispose();
			});
			P_0.Clear();
			return;
		}
		int count = P_1.Count;
		int count2 = P_0.Count;
		XISatJdVArtMUkOXRoGcIhpgBatq[] array = P_1.ToArray();
		if (array.Length > 0)
		{
			Array.Sort(array, SlhQbPqlxQsScOsnpIqpCRqeWnJq);
		}
		for (int num = 0; num < count2; num++)
		{
			hFGRnpnmGSdItjUopCIRLKQJdJYA hFGRnpnmGSdItjUopCIRLKQJdJYA2 = new hFGRnpnmGSdItjUopCIRLKQJdJYA();
			hFGRnpnmGSdItjUopCIRLKQJdJYA2.FkmnFtdKieRqBiwGIrLzzcwjOpn = P_0[num];
			if (hFGRnpnmGSdItjUopCIRLKQJdJYA2.FkmnFtdKieRqBiwGIrLzzcwjOpn != null && Array.Find(array, hFGRnpnmGSdItjUopCIRLKQJdJYA2.fGRXkgvHAZlpOQFVVEqNWQBLtVr) == null)
			{
				hFGRnpnmGSdItjUopCIRLKQJdJYA2.FkmnFtdKieRqBiwGIrLzzcwjOpn.Dispose();
			}
		}
		P_0.Clear();
		for (int num2 = 0; num2 < count; num2++)
		{
			if (array[num2] != null)
			{
				array[num2].zMRhGjCghfxrQxKqmZOzHufbmgp(num2);
				P_0.Add(array[num2]);
			}
		}
	}

	private List<iyIwThXmVTAIckoxFwEfUfmQUsL> pWQBGlfddRHSpzzGBLeaJxWrDbru()
	{
		List<iyIwThXmVTAIckoxFwEfUfmQUsL> list = new List<iyIwThXmVTAIckoxFwEfUfmQUsL>();
		try
		{
			foreach (oODKWlXjjUaKGJbFcHDHZKTTKwC item in pDdfcWqxDAHCEFuHEUpBobYCGVaf.MyNVLpupPnuFmchFifIhQkijTHz())
			{
				try
				{
					list.Add(new eCLbMTsKFfJvBGnCXBKQePUbRlEi
					{
						DeviceName = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(item.DevicePath),
						DeviceType = MAPTyOhgNVdBQSioUpquSdYiRkd.FwhTFJcoxdOAZsdJarteiktzdNZ,
						Handle = IntPtr.Zero,
						ProductId = item.Attributes.ProductId,
						VendorId = item.Attributes.VendorId,
						VersionNumber = item.Attributes.Version,
						UsagePage = (cqrrYzQQNtwerOenPmEAhYSfbvo)item.Capabilities.UsagePage,
						Usage = (VABRdqYQwczyEykxLDdEfwgXtM)item.Capabilities.Usage
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private XISatJdVArtMUkOXRoGcIhpgBatq aDNArmHkuIGSxGMmilwZnyxHYez(IntPtr P_0, eCLbMTsKFfJvBGnCXBKQePUbRlEi P_1, IList<pDdfcWqxDAHCEFuHEUpBobYCGVaf.aBGHUHfNCcVnSUkIQdHgprgokKHB> P_2, List<string> P_3, int P_4)
	{
		ushort num = (ushort)P_1.UsagePage;
		ushort num2 = (ushort)P_1.Usage;
		string deviceName = P_1.DeviceName;
		if (!qITntIwMeRtFtCzwzPxuKMeXYPv(num, num2))
		{
			return null;
		}
		string text = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(deviceName);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		P_3.Add(text);
		MFFbigtCSAERTKmOTUlnAJmgNhe mFFbigtCSAERTKmOTUlnAJmgNhe = pDdfcWqxDAHCEFuHEUpBobYCGVaf.bNIMOAyNtrGFJOyEAeujsuLGPtG(P_2, text, StringComparison.OrdinalIgnoreCase);
		if (mFFbigtCSAERTKmOTUlnAJmgNhe == null)
		{
			mFFbigtCSAERTKmOTUlnAJmgNhe = XxyJWBtqXuLRkPzhutTHCoiNIZYC.yuZWzefywVncOLtKjjtqVVIyemk(P_0, deviceName);
		}
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			string text2 = mFFbigtCSAERTKmOTUlnAJmgNhe.qZvONhbQmhqKnNrMmPatPTIwFOu();
			string bluetoothDeviceName = mFFbigtCSAERTKmOTUlnAJmgNhe.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(mFFbigtCSAERTKmOTUlnAJmgNhe.Attributes.VendorId, mFFbigtCSAERTKmOTUlnAJmgNhe.Attributes.ProductId);
			if (MwoFssxjTIQzJQFdgnRgTEwkueQ.IkwbPuTwnCFjSIUFHddovCKshqw(guid, text2, bluetoothDeviceName))
			{
				P_3.RemoveAt(P_3.Count - 1);
				return null;
			}
		}
		return tUKopUKqRJzOwfoWdEEbgZDpabN(biZfRftwELiGKLYOEPcPoCAhFEM.dqxZCtZKFepYbNxRzUGjBpCpjgSj, mFFbigtCSAERTKmOTUlnAJmgNhe, P_0, num, num2, P_4);
	}

	private XISatJdVArtMUkOXRoGcIhpgBatq QNKQinqNSqOQRLFbGcaOkrhLBkAp(pDdfcWqxDAHCEFuHEUpBobYCGVaf.aBGHUHfNCcVnSUkIQdHgprgokKHB P_0, int P_1)
	{
		oODKWlXjjUaKGJbFcHDHZKTTKwC oODKWlXjjUaKGJbFcHDHZKTTKwC2 = pDdfcWqxDAHCEFuHEUpBobYCGVaf.dcBjHlFmnjNyuKVEzQrnFiVTbiH(P_0);
		if (oODKWlXjjUaKGJbFcHDHZKTTKwC2 == null)
		{
			return null;
		}
		ushort num = (ushort)oODKWlXjjUaKGJbFcHDHZKTTKwC2.Capabilities.UsagePage;
		ushort num2 = (ushort)oODKWlXjjUaKGJbFcHDHZKTTKwC2.Capabilities.Usage;
		if (!qITntIwMeRtFtCzwzPxuKMeXYPv(num, num2))
		{
			return null;
		}
		bool flag = false;
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			flag = MwoFssxjTIQzJQFdgnRgTEwkueQ.IkwbPuTwnCFjSIUFHddovCKshqw(MiscTools.CreateHIDProductGuid(oODKWlXjjUaKGJbFcHDHZKTTKwC2.Attributes.VendorId, oODKWlXjjUaKGJbFcHDHZKTTKwC2.Attributes.ProductId), oODKWlXjjUaKGJbFcHDHZKTTKwC2.qZvONhbQmhqKnNrMmPatPTIwFOu(), oODKWlXjjUaKGJbFcHDHZKTTKwC2.BluetoothDeviceName);
		}
		if (!flag)
		{
			return null;
		}
		return tUKopUKqRJzOwfoWdEEbgZDpabN(biZfRftwELiGKLYOEPcPoCAhFEM.RqeANvtgChvkhpVhUhrZRbzfwuB, oODKWlXjjUaKGJbFcHDHZKTTKwC2, IntPtr.Zero, num, num2, P_1);
	}

	private XISatJdVArtMUkOXRoGcIhpgBatq tUKopUKqRJzOwfoWdEEbgZDpabN(biZfRftwELiGKLYOEPcPoCAhFEM P_0, MFFbigtCSAERTKmOTUlnAJmgNhe P_1, IntPtr P_2, ushort P_3, ushort P_4, int P_5)
	{
		bool flag = P_3 != 1 || !TtkWfAxSfFGpHWxqDTvJlooeIGU.ioUsNxBkKmDGJrbzqjiceWZnqtq.ZQDCOqEaOwpObrlMhaXuAxzeBAbV(P_4);
		if (VsMgYcimWEGlycMVKSeLPFvWQnhv.useXInput && P_3 == 1 && (P_4 == 4 || P_4 == 5))
		{
			string text = P_1.qZvONhbQmhqKnNrMmPatPTIwFOu();
			string bluetoothDeviceName = P_1.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(P_1.Attributes.VendorId, P_1.Attributes.ProductId);
			if (dSElFGVpyqTZVtKoEbCEnZfBwBs.AtUjsMHXuqlHRCvkrgGRGBocvYd(P_1.DevicePath, text, bluetoothDeviceName, guid))
			{
				return null;
			}
		}
		XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq = CWEFxYiNBBjKcVgzELYZiuGtPfH(P_0, P_2, P_5, P_1, BNRwQaHYudxtMzjvBeOOjyanYNh, flag);
		if (xISatJdVArtMUkOXRoGcIhpgBatq == null || !xISatJdVArtMUkOXRoGcIhpgBatq.HasElements)
		{
			if (xISatJdVArtMUkOXRoGcIhpgBatq != null && !xISatJdVArtMUkOXRoGcIhpgBatq.HasElements)
			{
				xISatJdVArtMUkOXRoGcIhpgBatq.Dispose();
			}
			return null;
		}
		return xISatJdVArtMUkOXRoGcIhpgBatq;
	}

	private bool qITntIwMeRtFtCzwzPxuKMeXYPv(ushort P_0, ushort P_1)
	{
		for (int i = 0; i < kUZREHlWMZmcqoMkaBEJCdiHtqHC.Length; i++)
		{
			if (kUZREHlWMZmcqoMkaBEJCdiHtqHC[i].GhRxJUEFfHwZOPqFzsKjMYeoIPm == P_0 && kUZREHlWMZmcqoMkaBEJCdiHtqHC[i].TpMniVMUhqTQkYOAVBMFVjfmfAhG == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private int QKnbTokZqrqrqOTuwoUcFyBEDzZJ()
	{
		try
		{
			return pDdfcWqxDAHCEFuHEUpBobYCGVaf.QKVNtxkIRUoPMrJFRDZsguZgSVJi();
		}
		catch
		{
			return 0;
		}
	}

	private int XuHOGZVIxTlXWkyfxSpBqjGRXSg()
	{
		try
		{
			return pDdfcWqxDAHCEFuHEUpBobYCGVaf.QKVNtxkIRUoPMrJFRDZsguZgSVJi(ref nRnzUwmHLpPXKgtXVmMeRSTttZA, sleBOBolfTikaIEYLQUTzKrAguY);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private XISatJdVArtMUkOXRoGcIhpgBatq CWEFxYiNBBjKcVgzELYZiuGtPfH(biZfRftwELiGKLYOEPcPoCAhFEM P_0, IntPtr P_1, int P_2, MFFbigtCSAERTKmOTUlnAJmgNhe P_3, List<XISatJdVArtMUkOXRoGcIhpgBatq> P_4, bool P_5)
	{
		HbvIOCdWqqJLSpqLtMzUWheKZKsh hbvIOCdWqqJLSpqLtMzUWheKZKsh = new HbvIOCdWqqJLSpqLtMzUWheKZKsh();
		hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz = P_3;
		if (P_5 && !uBGKEXTNaXBEteCerUaGHNPNSQc)
		{
			return null;
		}
		try
		{
			if (uBGKEXTNaXBEteCerUaGHNPNSQc)
			{
				if (P_4 != null)
				{
					for (int i = 0; i < P_4.Count; i++)
					{
						if (P_4[i] is qTsLTsamUQtWubcTjAnRwJiHdby qTsLTsamUQtWubcTjAnRwJiHdby2 && qTsLTsamUQtWubcTjAnRwJiHdby2.Driver != null && !(hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.InstanceId != qTsLTsamUQtWubcTjAnRwJiHdby2.HidDevice.InstanceId))
						{
							qTsLTsamUQtWubcTjAnRwJiHdby2.zMRhGjCghfxrQxKqmZOzHufbmgp(P_2);
							return qTsLTsamUQtWubcTjAnRwJiHdby2;
						}
					}
				}
				HIDDeviceDriver.DriverType driverType = HIDDeviceDriver.FindDriverId(hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.Attributes.VendorId, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.Attributes.ProductId);
				if (driverType != HIDDeviceDriver.DriverType.xHdBaRgdNDZThJOvnpmpFtvdLIun)
				{
					HidOutputReportHandler hidOutputReportHandler = new HidOutputReportHandler(hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.RNMBtPgCfOgWhDTcqfZdPVhxISL);
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(driverType, new HIDDeviceDriver.InitArgs(FgREoWxRjDNWqaQZIHifDtHgOgI, (!hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.IsBluetoothDevice) ? DeviceConnectionType.otyfefYfZNFkrcMHyeZcjaNHvEdW : DeviceConnectionType.SFwcoIElPuWXQcTCEiAmKWHEztR, 65535, -65535, -1, 4500, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.Capabilities.InputReportByteLength, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.Capabilities.OutputReportByteLength, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.RNMBtPgCfOgWhDTcqfZdPVhxISL, hidOutputReportHandler.WriteReport, hbvIOCdWqqJLSpqLtMzUWheKZKsh.NoQhcQNyhZweugGoCsmFrRWGtUA));
					if (driver != null)
					{
						return new qTsLTsamUQtWubcTjAnRwJiHdby(P_2, P_0, P_1, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz, driver, hidOutputReportHandler);
					}
				}
				if (P_5)
				{
					return null;
				}
			}
		}
		catch
		{
			Rewired.Logger.LogWarning("Exception creating custom driver joystick. Will fall back to normal HID joystick.");
		}
		try
		{
			if (P_4 != null)
			{
				for (int j = 0; j < P_4.Count; j++)
				{
					if (P_4[j] is dHehSZErNPSnylbgSIAEHzyqWNwJ dHehSZErNPSnylbgSIAEHzyqWNwJ2 && !(hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz.InstanceId != dHehSZErNPSnylbgSIAEHzyqWNwJ2.HidDevice.InstanceId))
					{
						dHehSZErNPSnylbgSIAEHzyqWNwJ2.zMRhGjCghfxrQxKqmZOzHufbmgp(P_2);
						return dHehSZErNPSnylbgSIAEHzyqWNwJ2;
					}
				}
			}
			return new dHehSZErNPSnylbgSIAEHzyqWNwJ(P_2, P_0, P_1, hbvIOCdWqqJLSpqLtMzUWheKZKsh.jDVtkZrKNwkxGhxQCjCBsSeZqLz);
		}
		catch
		{
			return null;
		}
	}

	private XISatJdVArtMUkOXRoGcIhpgBatq bomphbyuEnSyibdDziyaEhYQzZk(biZfRftwELiGKLYOEPcPoCAhFEM P_0, IntPtr P_1)
	{
		if (BNRwQaHYudxtMzjvBeOOjyanYNh == null)
		{
			return null;
		}
		for (int i = 0; i < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; i++)
		{
			XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq = BNRwQaHYudxtMzjvBeOOjyanYNh[i];
			if (xISatJdVArtMUkOXRoGcIhpgBatq.JoystickSourceType == P_0 && !(xISatJdVArtMUkOXRoGcIhpgBatq.JoystickSourceHandle != P_1))
			{
				return xISatJdVArtMUkOXRoGcIhpgBatq;
			}
		}
		return null;
	}

	private unsafe XISatJdVArtMUkOXRoGcIhpgBatq mDBmTuCgWLfHPHousQiXejEosLO(IntPtr P_0)
	{
		AewjMoBLyBolnnNMhBXWHRooNZC.CpjpWEnKlJLIOeGWTdmFcIIOsFMS(P_0, 536870919u, IntPtr.Zero, out var num);
		if (num == 0)
		{
			return null;
		}
		char* value = stackalloc char[(int)num];
		AewjMoBLyBolnnNMhBXWHRooNZC.CpjpWEnKlJLIOeGWTdmFcIIOsFMS(P_0, 536870919u, new IntPtr(value), out num);
		int length = (int)(((int)num > 0) ? (num - 1) : 0);
		string text = new string(value, 0, length);
		if (text.Length == 0)
		{
			text = string.Empty;
		}
		if (BNRwQaHYudxtMzjvBeOOjyanYNh == null)
		{
			return null;
		}
		text = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(text);
		for (int i = 0; i < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; i++)
		{
			XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq = BNRwQaHYudxtMzjvBeOOjyanYNh[i];
			if (xISatJdVArtMUkOXRoGcIhpgBatq.JoystickSourceType == biZfRftwELiGKLYOEPcPoCAhFEM.dqxZCtZKFepYbNxRzUGjBpCpjgSj && xISatJdVArtMUkOXRoGcIhpgBatq.HidDevice.DevicePathStripped.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				xISatJdVArtMUkOXRoGcIhpgBatq.GOOgnFFAqwQNgKxSPRwAOTnCrYV(P_0);
				return xISatJdVArtMUkOXRoGcIhpgBatq;
			}
		}
		return null;
	}

	private static int SlhQbPqlxQsScOsnpIqpCRqeWnJq(XISatJdVArtMUkOXRoGcIhpgBatq P_0, XISatJdVArtMUkOXRoGcIhpgBatq P_1)
	{
		if (!P_0.HidDevice.HasLocationInfo)
		{
			return 1;
		}
		if (!P_1.HidDevice.HasLocationInfo)
		{
			return -1;
		}
		int hubId = P_0.HidDevice.HubId;
		int hubId2 = P_1.HidDevice.HubId;
		if (hubId < hubId2)
		{
			return -1;
		}
		if (hubId > hubId2)
		{
			return 1;
		}
		int portId = P_0.HidDevice.PortId;
		int portId2 = P_1.HidDevice.PortId;
		if (portId < portId2)
		{
			return -1;
		}
		if (portId > portId2)
		{
			return 1;
		}
		return 0;
	}

	private void LgKSumIhgmRsfsyhteVwtjUNdnh()
	{
		qqoLMCWhEreviyjNNWcZApFsRit qqoLMCWhEreviyjNNWcZApFsRit2 = new qqoLMCWhEreviyjNNWcZApFsRit();
		qqoLMCWhEreviyjNNWcZApFsRit2.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			qqoLMCWhEreviyjNNWcZApFsRit2.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(qqoLMCWhEreviyjNNWcZApFsRit2.CEsqPtPFaJvJViOgiHsHvHvnrZr, true);
			if (qqoLMCWhEreviyjNNWcZApFsRit2.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to register HID devices.", requiredThreadSafety: true);
			}
		}
	}

	private void VYJesxXsaEbiPabvKdbBlVINFHYQ()
	{
		kxBnLPdUkVFkYvwerScZpPgXsSl kxBnLPdUkVFkYvwerScZpPgXsSl2 = new kxBnLPdUkVFkYvwerScZpPgXsSl();
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			kxBnLPdUkVFkYvwerScZpPgXsSl2.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(kxBnLPdUkVFkYvwerScZpPgXsSl2.sELLpYEudfrFaXVykIRJxosLcOD, true);
			if (kxBnLPdUkVFkYvwerScZpPgXsSl2.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to unregister HID devices.", requiredThreadSafety: true);
			}
		}
	}

	private void MCYowUJlKZrCFoEJQetVIlVuLkLC()
	{
		if (ReInput.isAllowedEditorWindowFocused)
		{
			if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
			{
				mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
				if (MHOguSHKDpCslowFrgeilBKioqQB)
				{
					IntPtr zvsyKgFylLUNgnDmrXZkzAIyLYs;
					bool flag = !uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Mouse, sZDCuXonuesoQqBPayGRZTryRwu, num, out zvsyKgFylLUNgnDmrXZkzAIyLYs);
					if (!XHqfwIZrEzfEEjDzfeJbcZXckXxw || !flag)
					{
						if (zvsyKgFylLUNgnDmrXZkzAIyLYs == IntPtr.Zero)
						{
							zvsyKgFylLUNgnDmrXZkzAIyLYs = ZvsyKgFylLUNgnDmrXZkzAIyLYs;
						}
						qyHeJjkMRqLAbBpVAPczagYgUWFv(zvsyKgFylLUNgnDmrXZkzAIyLYs);
					}
				}
				if (!nDrVOOXzsMdXepMzAAVSLdpYhnhj)
				{
					return;
				}
				IntPtr nFihkPDnwgEcYWzGEwNbqjdpvyq;
				bool flag2 = !uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Keyboard, sZDCuXonuesoQqBPayGRZTryRwu, num, out nFihkPDnwgEcYWzGEwNbqjdpvyq);
				if (!tkezIZqHnQlbxumsBBCHAyEESwfR || !flag2)
				{
					if (nFihkPDnwgEcYWzGEwNbqjdpvyq == IntPtr.Zero)
					{
						nFihkPDnwgEcYWzGEwNbqjdpvyq = NFihkPDnwgEcYWzGEwNbqjdpvyq;
					}
					VnqYvxUPLVQPzxunODBBEhUjFYd(nFihkPDnwgEcYWzGEwNbqjdpvyq);
				}
			}
			else
			{
				if (MHOguSHKDpCslowFrgeilBKioqQB && !XHqfwIZrEzfEEjDzfeJbcZXckXxw)
				{
					pgrgcaFvYIqVPgAWAmsTJiIGLJik();
				}
				if (nDrVOOXzsMdXepMzAAVSLdpYhnhj && !tkezIZqHnQlbxumsBBCHAyEESwfR)
				{
					zlndKKjpzVDnMiHyjStAgQrXDIop();
				}
			}
		}
		else
		{
			if (XHqfwIZrEzfEEjDzfeJbcZXckXxw)
			{
				TFPkljSVxNexVRAQOEQjOBBkDTXB();
			}
			if (tkezIZqHnQlbxumsBBCHAyEESwfR)
			{
				mQkQbUeMQxQsNTJYosapndRNZHU();
			}
		}
	}

	private void oOyeBNECWrlaRhMmqxNQlRTINOsf()
	{
		double realTime = ReInput.realTime;
		if (realTime < jMYCGEpEuXlxLgeslzAwkmYzpHi + 1.0)
		{
			return;
		}
		jMYCGEpEuXlxLgeslzAwkmYzpHi = realTime;
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
			if (MHOguSHKDpCslowFrgeilBKioqQB)
			{
				IntPtr intPtr;
				bool flag = !uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Mouse, sZDCuXonuesoQqBPayGRZTryRwu, num, out intPtr);
				if (!XHqfwIZrEzfEEjDzfeJbcZXckXxw || !flag)
				{
					if (intPtr == IntPtr.Zero)
					{
						intPtr = ZvsyKgFylLUNgnDmrXZkzAIyLYs;
					}
					FRmLDPBJRWLXCzgoXgFMxmwDznD();
				}
			}
			if (!nDrVOOXzsMdXepMzAAVSLdpYhnhj)
			{
				return;
			}
			IntPtr intPtr2;
			bool flag2 = !uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Keyboard, sZDCuXonuesoQqBPayGRZTryRwu, num, out intPtr2);
			if (!tkezIZqHnQlbxumsBBCHAyEESwfR || !flag2)
			{
				if (intPtr2 == IntPtr.Zero)
				{
					intPtr2 = NFihkPDnwgEcYWzGEwNbqjdpvyq;
				}
				izqmMBuzbIdLDlDiYVKJMsleeRy();
			}
		}
		else
		{
			if (MHOguSHKDpCslowFrgeilBKioqQB && !XHqfwIZrEzfEEjDzfeJbcZXckXxw)
			{
				pgrgcaFvYIqVPgAWAmsTJiIGLJik();
			}
			if (nDrVOOXzsMdXepMzAAVSLdpYhnhj && !tkezIZqHnQlbxumsBBCHAyEESwfR)
			{
				zlndKKjpzVDnMiHyjStAgQrXDIop();
			}
		}
	}

	private void VQLyZMyAfLItIefhSaqacDJIyGTM()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
			if (MHOguSHKDpCslowFrgeilBKioqQB && uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Mouse, sZDCuXonuesoQqBPayGRZTryRwu, num, out var _))
			{
				if (XHqfwIZrEzfEEjDzfeJbcZXckXxw)
				{
					XHqfwIZrEzfEEjDzfeJbcZXckXxw = false;
					bfGNYwKXEUTHcSMsSbVYbqRcFyX.wyrqFdOgaxQVgbBnFdlZHDmYRww(false);
				}
				FRmLDPBJRWLXCzgoXgFMxmwDznD();
			}
		}
		else if (MHOguSHKDpCslowFrgeilBKioqQB && !XHqfwIZrEzfEEjDzfeJbcZXckXxw)
		{
			pgrgcaFvYIqVPgAWAmsTJiIGLJik();
		}
	}

	private void TFPkljSVxNexVRAQOEQjOBBkDTXB()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			NLAafvtpIMpkQDvRyQpTkAkoxUf.pBkWucpvPeUIQSMdobwZGjnHrV(false);
			AELGGaEsAbjpdaBrHeZsplIerKxD();
		}
		XHqfwIZrEzfEEjDzfeJbcZXckXxw = false;
		bfGNYwKXEUTHcSMsSbVYbqRcFyX.wyrqFdOgaxQVgbBnFdlZHDmYRww(false);
	}

	private void AELGGaEsAbjpdaBrHeZsplIerKxD()
	{
		if (!MHOguSHKDpCslowFrgeilBKioqQB || nOcGEnklYEcclVReawchLHwxZEu != uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			return;
		}
		IntPtr intPtr;
		if (GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
			if (uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Mouse, sZDCuXonuesoQqBPayGRZTryRwu, num, out var zvsyKgFylLUNgnDmrXZkzAIyLYs))
			{
				ZvsyKgFylLUNgnDmrXZkzAIyLYs = zvsyKgFylLUNgnDmrXZkzAIyLYs;
			}
			intPtr = ZvsyKgFylLUNgnDmrXZkzAIyLYs;
		}
		else
		{
			intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR();
		}
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)2, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb, intPtr);
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				Rewired.Logger.LogError("Failed to unregister mouse.", requiredThreadSafety: true);
			}
		}
		else if (XHqfwIZrEzfEEjDzfeJbcZXckXxw)
		{
			WcPaGqfKnjUGbChbeyFOrVNwbFsA wcPaGqfKnjUGbChbeyFOrVNwbFsA = new WcPaGqfKnjUGbChbeyFOrVNwbFsA();
			wcPaGqfKnjUGbChbeyFOrVNwbFsA.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(wcPaGqfKnjUGbChbeyFOrVNwbFsA.PBjIRQDktJzVfcoKqRUQCJBLrGp, true);
			if (wcPaGqfKnjUGbChbeyFOrVNwbFsA.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to unregister mouse.", requiredThreadSafety: true);
			}
		}
	}

	private void qyHeJjkMRqLAbBpVAPczagYgUWFv(IntPtr P_0)
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			pgrgcaFvYIqVPgAWAmsTJiIGLJik();
			if (P_0 != IntPtr.Zero && P_0 != TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle)
			{
				ZvsyKgFylLUNgnDmrXZkzAIyLYs = P_0;
				NLAafvtpIMpkQDvRyQpTkAkoxUf.LFIgfiHYNUQmKRHYAoaxATLEvNvL(ZvsyKgFylLUNgnDmrXZkzAIyLYs, true);
			}
		}
	}

	private void FRmLDPBJRWLXCzgoXgFMxmwDznD()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			pgrgcaFvYIqVPgAWAmsTJiIGLJik();
			NLAafvtpIMpkQDvRyQpTkAkoxUf.LFIgfiHYNUQmKRHYAoaxATLEvNvL(NNSzYtnWHdPHWjkuyfCECFBZfORy.value, true);
		}
	}

	private void pgrgcaFvYIqVPgAWAmsTJiIGLJik()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			ZcGEhAAHzJcSJnnxnHTDYJXxWppg zcGEhAAHzJcSJnnxnHTDYJXxWppg = new ZcGEhAAHzJcSJnnxnHTDYJXxWppg();
			zcGEhAAHzJcSJnnxnHTDYJXxWppg.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
			zcGEhAAHzJcSJnnxnHTDYJXxWppg.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(zcGEhAAHzJcSJnnxnHTDYJXxWppg.KNLlJqEmwZCyCBWTdKLVoNYKjpc, true);
			if (zcGEhAAHzJcSJnnxnHTDYJXxWppg.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to register mouse.", requiredThreadSafety: true);
				XHqfwIZrEzfEEjDzfeJbcZXckXxw = false;
				bfGNYwKXEUTHcSMsSbVYbqRcFyX.wyrqFdOgaxQVgbBnFdlZHDmYRww(false);
				return;
			}
		}
		if (!XHqfwIZrEzfEEjDzfeJbcZXckXxw)
		{
			XHqfwIZrEzfEEjDzfeJbcZXckXxw = true;
			bfGNYwKXEUTHcSMsSbVYbqRcFyX.wyrqFdOgaxQVgbBnFdlZHDmYRww(true);
		}
	}

	public static bool mwMKDgrBrcPjXwXLTxoVdEkzDkb(dHXyzyTbuzAetPEwCgxUBzMPWtiN P_0, out uint P_1)
	{
		P_1 = 0u;
		if (P_0 == null)
		{
			return false;
		}
		uint maxDevices = (uint)P_0.maxDevices;
		P_1 = AewjMoBLyBolnnNMhBXWHRooNZC.mwMKDgrBrcPjXwXLTxoVdEkzDkb(P_0, ref maxDevices, (uint)P_0.structSize);
		return P_1 != 0;
	}

	private unsafe bool uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType P_0, dHXyzyTbuzAetPEwCgxUBzMPWtiN P_1, uint P_2, out IntPtr P_3)
	{
		P_3 = IntPtr.Zero;
		if (P_1 == null)
		{
			return false;
		}
		for (int i = 0; i < P_2; i++)
		{
			IntPtr pointer = P_1.GetPointer(i * P_1.structSize);
			cAVyYWbLYhVCRervifJOVKvhDaC* ptr = (cAVyYWbLYhVCRervifJOVKvhDaC*)(void*)pointer;
			switch (P_0)
			{
			case ControllerType.Keyboard:
				if (ptr->NmQhBtQCcgcHDaWeaCjxXfWGcIGd == 1 && ptr->ZYGeQPjXCaJVJLnAiYGNJFbZgfk == 6 && ptr->PJlJGGkbAhuATkazDDtetKaRWR != IntPtr.Zero && ptr->PJlJGGkbAhuATkazDDtetKaRWR != TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle)
				{
					P_3 = ptr->PJlJGGkbAhuATkazDDtetKaRWR;
					return true;
				}
				break;
			case ControllerType.Mouse:
				if (ptr->NmQhBtQCcgcHDaWeaCjxXfWGcIGd == 1 && ptr->ZYGeQPjXCaJVJLnAiYGNJFbZgfk == 2 && ptr->PJlJGGkbAhuATkazDDtetKaRWR != IntPtr.Zero && ptr->PJlJGGkbAhuATkazDDtetKaRWR != TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle)
				{
					P_3 = ptr->PJlJGGkbAhuATkazDDtetKaRWR;
					return true;
				}
				break;
			}
		}
		return false;
	}

	private unsafe IntPtr fDCjLRrtxJqCszmomNjXdKTAERy()
	{
		dHXyzyTbuzAetPEwCgxUBzMPWtiN dHXyzyTbuzAetPEwCgxUBzMPWtiN2 = null;
		try
		{
			dHXyzyTbuzAetPEwCgxUBzMPWtiN2 = new dHXyzyTbuzAetPEwCgxUBzMPWtiN(cAVyYWbLYhVCRervifJOVKvhDaC.SizeInBytes, 100);
			uint maxDevices = (uint)dHXyzyTbuzAetPEwCgxUBzMPWtiN2.maxDevices;
			uint num = AewjMoBLyBolnnNMhBXWHRooNZC.mwMKDgrBrcPjXwXLTxoVdEkzDkb(dHXyzyTbuzAetPEwCgxUBzMPWtiN2, ref maxDevices, (uint)dHXyzyTbuzAetPEwCgxUBzMPWtiN2.structSize);
			if (num == 0)
			{
				return IntPtr.Zero;
			}
			for (int i = 0; i < num; i++)
			{
				IntPtr pointer = dHXyzyTbuzAetPEwCgxUBzMPWtiN2.GetPointer(i * dHXyzyTbuzAetPEwCgxUBzMPWtiN2.structSize);
				cAVyYWbLYhVCRervifJOVKvhDaC* ptr = (cAVyYWbLYhVCRervifJOVKvhDaC*)(void*)pointer;
				Rewired.Logger.Log("RI DEVICE " + i);
				Rewired.Logger.Log("usage = " + ptr->ZYGeQPjXCaJVJLnAiYGNJFbZgfk);
				Rewired.Logger.Log("usagePage = " + ptr->NmQhBtQCcgcHDaWeaCjxXfWGcIGd);
				Rewired.Logger.Log("flags = " + ptr->wbmxfUinNZtnthzDdPSUImGyMjT);
				Rewired.Logger.Log("target = " + ptr->PJlJGGkbAhuATkazDDtetKaRWR);
				if (ptr->NmQhBtQCcgcHDaWeaCjxXfWGcIGd == 1 && ptr->ZYGeQPjXCaJVJLnAiYGNJFbZgfk == 2 && ptr->PJlJGGkbAhuATkazDDtetKaRWR != IntPtr.Zero && ptr->PJlJGGkbAhuATkazDDtetKaRWR != TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle)
				{
					return ptr->PJlJGGkbAhuATkazDDtetKaRWR;
				}
			}
			return IntPtr.Zero;
		}
		catch
		{
			return IntPtr.Zero;
		}
		finally
		{
			dHXyzyTbuzAetPEwCgxUBzMPWtiN2?.Dispose();
		}
	}

	private void VnqYvxUPLVQPzxunODBBEhUjFYd(IntPtr P_0)
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			zlndKKjpzVDnMiHyjStAgQrXDIop();
			if (P_0 != IntPtr.Zero && P_0 != TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Handle)
			{
				NFihkPDnwgEcYWzGEwNbqjdpvyq = P_0;
			}
		}
	}

	private void izqmMBuzbIdLDlDiYVKJMsleeRy()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			zlndKKjpzVDnMiHyjStAgQrXDIop();
		}
	}

	private void zlndKKjpzVDnMiHyjStAgQrXDIop()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			TbtIKzjfZigmcImSIHiVHiZkaPKL tbtIKzjfZigmcImSIHiVHiZkaPKL = new TbtIKzjfZigmcImSIHiVHiZkaPKL();
			tbtIKzjfZigmcImSIHiVHiZkaPKL.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
			tbtIKzjfZigmcImSIHiVHiZkaPKL.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(tbtIKzjfZigmcImSIHiVHiZkaPKL.aarbMvUvgwMvoGmpcjxMgGPfTGC, true);
			if (tbtIKzjfZigmcImSIHiVHiZkaPKL.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to register keyboard.", requiredThreadSafety: true);
				tkezIZqHnQlbxumsBBCHAyEESwfR = false;
				EyqykcmEIygobLZbPDDtXCagSsP.wyrqFdOgaxQVgbBnFdlZHDmYRww(false);
				return;
			}
		}
		if (!tkezIZqHnQlbxumsBBCHAyEESwfR)
		{
			tkezIZqHnQlbxumsBBCHAyEESwfR = true;
			EyqykcmEIygobLZbPDDtXCagSsP.wyrqFdOgaxQVgbBnFdlZHDmYRww(true);
		}
	}

	private void mQkQbUeMQxQsNTJYosapndRNZHU()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			abaynVnJKAOijoguCEmNJhClaFyE();
		}
		tkezIZqHnQlbxumsBBCHAyEESwfR = false;
		EyqykcmEIygobLZbPDDtXCagSsP.wyrqFdOgaxQVgbBnFdlZHDmYRww(false);
	}

	private void abaynVnJKAOijoguCEmNJhClaFyE()
	{
		if (!nDrVOOXzsMdXepMzAAVSLdpYhnhj || nOcGEnklYEcclVReawchLHwxZEu != uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			return;
		}
		IntPtr intPtr;
		if (GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
			if (uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Keyboard, sZDCuXonuesoQqBPayGRZTryRwu, num, out var nFihkPDnwgEcYWzGEwNbqjdpvyq))
			{
				NFihkPDnwgEcYWzGEwNbqjdpvyq = nFihkPDnwgEcYWzGEwNbqjdpvyq;
			}
			intPtr = NFihkPDnwgEcYWzGEwNbqjdpvyq;
		}
		else
		{
			intPtr = AewjMoBLyBolnnNMhBXWHRooNZC.YABwwXHSsTojcscsIpnzfwQpmnR();
		}
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				EkVkWMYCVwtPsFXxHOsvvAxKeBxA.JXvLmUdzSkDuqEitjeAVpcnLGqm((cqrrYzQQNtwerOenPmEAhYSfbvo)1, (VABRdqYQwczyEykxLDdEfwgXtM)6, udeFPeagJNADrdnQrjwMerhHHxJM.anJMNwHoofrzpDoOBSScbhemzdb, intPtr);
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				Rewired.Logger.LogError("Failed to unregister keyboard.", requiredThreadSafety: true);
			}
		}
		else if (tkezIZqHnQlbxumsBBCHAyEESwfR)
		{
			IYYOfdESmgjOwbcVZbiwdhkzNPwW iYYOfdESmgjOwbcVZbiwdhkzNPwW = new IYYOfdESmgjOwbcVZbiwdhkzNPwW();
			iYYOfdESmgjOwbcVZbiwdhkzNPwW.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
			qTKnunibIXbdKEikJsGpaFITKodP(iYYOfdESmgjOwbcVZbiwdhkzNPwW.rZiCCnsEMBiSpRBdSzbOXQtvcaU, true);
			if (iYYOfdESmgjOwbcVZbiwdhkzNPwW.PyuFrSBeUIgNtjBlGISqDiWaodoK)
			{
				Rewired.Logger.LogError("Failed to unregister keyboard.", requiredThreadSafety: true);
			}
		}
	}

	private void HiiTvoNPcGjxldZszkjwFICZGRy()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu == uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			if (MHOguSHKDpCslowFrgeilBKioqQB)
			{
				TFPkljSVxNexVRAQOEQjOBBkDTXB();
			}
			VYJesxXsaEbiPabvKdbBlVINFHYQ();
			if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
			{
				mQkQbUeMQxQsNTJYosapndRNZHU();
			}
		}
		else if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			TFPkljSVxNexVRAQOEQjOBBkDTXB();
		}
	}

	private void rnLvdUVHOwDFpAFwoXQwviYHLJzD()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.RawInput += QvFBTiQGvZYmEHxEPRDBvUogIAn;
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.MouseInput += AbZiNBBUbBMDPRKljUbPaVZJvSI;
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.KeyboardInput += sdfSCGkwKYkyYPySIULhrwQIHbA;
		}
		if (wjKcjakyNggjYkTtNALWrDlwLpFA || MHOguSHKDpCslowFrgeilBKioqQB || nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.DeviceConnectedEvent += erEWQRYSNykZgZnqIPWeDEjvWph;
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.DeviceDisconnectedEvent += tFuGjDgrYDgSxWzaXkFecYxZqaJ;
		}
	}

	private void QuiexSCzyHZMbFAsOcXmxztPyYJp()
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.RawInput -= QvFBTiQGvZYmEHxEPRDBvUogIAn;
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.MouseInput -= AbZiNBBUbBMDPRKljUbPaVZJvSI;
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.KeyboardInput -= sdfSCGkwKYkyYPySIULhrwQIHbA;
		}
		if (wjKcjakyNggjYkTtNALWrDlwLpFA || MHOguSHKDpCslowFrgeilBKioqQB || nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.DeviceConnectedEvent -= erEWQRYSNykZgZnqIPWeDEjvWph;
			EkVkWMYCVwtPsFXxHOsvvAxKeBxA.DeviceDisconnectedEvent -= tFuGjDgrYDgSxWzaXkFecYxZqaJ;
		}
	}

	private void oMRLBYjdihAhVZHfzaElKUtHBYol(fIwdfzxbbCPDQCFdxJoWFgqoGVGe.bzlLqTJAxhIKJodCgngLvqCPWrE P_0)
	{
		JBYcIcYcdkAoQgkNkcdvHtflsie jBYcIcYcdkAoQgkNkcdvHtflsie = new JBYcIcYcdkAoQgkNkcdvHtflsie();
		jBYcIcYcdkAoQgkNkcdvHtflsie.wWevsbVsXuPVWtRMvxCBvbCpQXa = P_0;
		jBYcIcYcdkAoQgkNkcdvHtflsie.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
		jBYcIcYcdkAoQgkNkcdvHtflsie.PyuFrSBeUIgNtjBlGISqDiWaodoK = false;
		qTKnunibIXbdKEikJsGpaFITKodP(jBYcIcYcdkAoQgkNkcdvHtflsie.tOujmeWIaeEVzAMhUdIuebBnZwe, true);
		if (jBYcIcYcdkAoQgkNkcdvHtflsie.PyuFrSBeUIgNtjBlGISqDiWaodoK)
		{
			throw new Exception("Error creating message window.");
		}
	}

	private static fIwdfzxbbCPDQCFdxJoWFgqoGVGe fnnlHdsyZpALwxMzxiWeUCCSBnI(fIwdfzxbbCPDQCFdxJoWFgqoGVGe.bzlLqTJAxhIKJodCgngLvqCPWrE P_0)
	{
		fIwdfzxbbCPDQCFdxJoWFgqoGVGe fIwdfzxbbCPDQCFdxJoWFgqoGVGe2 = new fIwdfzxbbCPDQCFdxJoWFgqoGVGe("RewiredMesssageWindow", createMessageOnlyWindow: true, P_0);
		if (fIwdfzxbbCPDQCFdxJoWFgqoGVGe2.Handle == IntPtr.Zero)
		{
			fIwdfzxbbCPDQCFdxJoWFgqoGVGe2.Dispose();
			return null;
		}
		return fIwdfzxbbCPDQCFdxJoWFgqoGVGe2;
	}

	private void YUSBsLIhAHghefmIfcNbUiyfyVGH()
	{
		if (nOcGEnklYEcclVReawchLHwxZEu != uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			return;
		}
		NLAafvtpIMpkQDvRyQpTkAkoxUf.BVmTKMsAVVqdkfwNjSwlgNFzTsh();
		NLAafvtpIMpkQDvRyQpTkAkoxUf.ELUEoNhYrHreYFEIkHkjFSeIrCJz(UnityTools.externalTools.WindowsStandalone_ForwardRawInput);
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			LgKSumIhgmRsfsyhteVwtjUNdnh();
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB || nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			sZDCuXonuesoQqBPayGRZTryRwu = new dHXyzyTbuzAetPEwCgxUBzMPWtiN(cAVyYWbLYhVCRervifJOVKvhDaC.SizeInBytes, 100);
			if (GgcxdJMndFQaXoamiKBfmlMxEvw)
			{
				eTHDwqAftXgPlLgTRMewNGmXZKpP = 1;
			}
			else
			{
				if (MHOguSHKDpCslowFrgeilBKioqQB)
				{
					FRmLDPBJRWLXCzgoXgFMxmwDznD();
				}
				if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
				{
					izqmMBuzbIdLDlDiYVKJMsleeRy();
				}
			}
		}
		PoDjTJppaPPtHExXCWvCBnzfiwi = NLAafvtpIMpkQDvRyQpTkAkoxUf.shBkdkpsRRvZpzjDrUquQNAjPao();
	}

	private void btQBbPUSFaAXXLKTVLNKdHzzlFC()
	{
		if (!GgcxdJMndFQaXoamiKBfmlMxEvw || nOcGEnklYEcclVReawchLHwxZEu != uATVrxLrtwlNyXjbHebdtrBRgRv.AxaCFTFzVcQGiieoeBAkqvCTmv)
		{
			return;
		}
		if (eTHDwqAftXgPlLgTRMewNGmXZKpP > 0)
		{
			eTHDwqAftXgPlLgTRMewNGmXZKpP--;
			return;
		}
		mwMKDgrBrcPjXwXLTxoVdEkzDkb(sZDCuXonuesoQqBPayGRZTryRwu, out var num);
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Mouse, sZDCuXonuesoQqBPayGRZTryRwu, num, out var intPtr);
			qyHeJjkMRqLAbBpVAPczagYgUWFv(intPtr);
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			uzZmvZzlNQTaAKlkWZeKBQYxXyG(ControllerType.Keyboard, sZDCuXonuesoQqBPayGRZTryRwu, num, out var intPtr2);
			VnqYvxUPLVQPzxunODBBEhUjFYd(intPtr2);
		}
		eTHDwqAftXgPlLgTRMewNGmXZKpP = -1;
	}

	private void QEgviCIOXceAkluEgTvZzmjZFdD(bool P_0)
	{
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			FRmLDPBJRWLXCzgoXgFMxmwDznD();
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			zlndKKjpzVDnMiHyjStAgQrXDIop();
		}
	}

	private void SzxrrziurVLHDPmtOGWOBZoWowk(FullScreenMode P_0)
	{
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			VQLyZMyAfLItIefhSaqacDJIyGTM();
		}
	}

	private void TXfLlMufNNaPJIpZbCHyloukmKxF(IntPtr P_0)
	{
		if (!GgcxdJMndFQaXoamiKBfmlMxEvw)
		{
			if (MHOguSHKDpCslowFrgeilBKioqQB)
			{
				FRmLDPBJRWLXCzgoXgFMxmwDznD();
			}
			if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
			{
				izqmMBuzbIdLDlDiYVKJMsleeRy();
			}
		}
	}

	private IntPtr SKRvzQSHgIEBgwIYQAoOmdXStap(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return IntPtr.Zero;
		}
		if (PoDjTJppaPPtHExXCWvCBnzfiwi != null)
		{
			PoDjTJppaPPtHExXCWvCBnzfiwi(P_0, P_1, P_2, P_3);
		}
		return IntPtr.Zero;
	}

	private void qTKnunibIXbdKEikJsGpaFITKodP(Action P_0, bool P_1)
	{
		P_0?.Invoke();
	}

	private void QvFBTiQGvZYmEHxEPRDBvUogIAn(xVpqVseTQjmLMIZnQEZASnpdzDu P_0, double P_1)
	{
		try
		{
			bomphbyuEnSyibdDziyaEhYQzZk(biZfRftwELiGKLYOEPcPoCAhFEM.dqxZCtZKFepYbNxRzUGjBpCpjgSj, P_0.IwQsZkJYbdNBBYrWJIGRHvvDEft)?.EbVOACURTuIOJEQxAtEgRrFmQSQ(P_0.RawDataPtr, P_0.RawDataBytes, P_0.RhAZtGylZIlqFAlkWgbLvitHuRP, P_0.eWxhbyRJEJBxoPGkeUikLAJgMYg, P_1);
		}
		catch
		{
		}
	}

	private void pAFeemAZVvBpqaHyCkuImZItlMoY(eYeIJMJVDsQmHFksScZAJrwwR P_0)
	{
		try
		{
			bomphbyuEnSyibdDziyaEhYQzZk(biZfRftwELiGKLYOEPcPoCAhFEM.dqxZCtZKFepYbNxRzUGjBpCpjgSj, P_0.TtxGEzbPGmfFtctndOWwSOdhrvR)?.EbVOACURTuIOJEQxAtEgRrFmQSQ(P_0.rawDataPtr, P_0.bXiAqBggXeBliiDFDpAplSdFlDEN, P_0.SGFhTdTxaZBwtXlKxvkwhwIprEL, P_0.VPwAhdHHqWWOvIezQeKKbIadjWe, P_0.lwetWUmJoDgKnNxGfQksKVlucJD);
		}
		catch
		{
		}
	}

	private void AbZiNBBUbBMDPRKljUbPaVZJvSI(FxXuFsDGohnklEbYOAktGXFvpsa P_0, double P_1)
	{
		vvTSFtolMIxRVZqcBIGPVuQyeOG.OcfraEykjBtASDrfWrlPPDyQQVt(ref P_0);
		qIJvyLGbSnLAldLlqTNFPcBaBGz(vvTSFtolMIxRVZqcBIGPVuQyeOG, P_1);
	}

	private void qIJvyLGbSnLAldLlqTNFPcBaBGz(BNfOmYDxvqNCLrrYukBTimTmfzA P_0, double P_1)
	{
		try
		{
			bfGNYwKXEUTHcSMsSbVYbqRcFyX.pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
		}
		catch (Exception)
		{
		}
	}

	private void sdfSCGkwKYkyYPySIULhrwQIHbA(cBjdMczDgoEYQlFSGytXSwLhLdF P_0, double P_1)
	{
		qYgvtOJkaJDYbkSIbvVGywNGPsE.OcfraEykjBtASDrfWrlPPDyQQVt(ref P_0);
		vvGPLprItkpFlLRPjecrxYzudTM(qYgvtOJkaJDYbkSIbvVGywNGPsE, P_1);
	}

	private void vvGPLprItkpFlLRPjecrxYzudTM(ipwruYYKPldFWmYuJnDLBmTbJhD P_0, double P_1)
	{
		try
		{
			EyqykcmEIygobLZbPDDtXCagSsP.pxuGNwZmtUejHeAPFpfZJLcwCmlw(P_0);
		}
		catch
		{
		}
	}

	private void erEWQRYSNykZgZnqIPWeDEjvWph(IntPtr P_0)
	{
		hpZcELkRkEkNGhdBRByTprKSdTH = true;
	}

	private void tFuGjDgrYDgSxWzaXkFecYxZqaJ()
	{
		hpZcELkRkEkNGhdBRByTprKSdTH = true;
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~CDUDUtloSCOYNTanpthEeshuCdC()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		QuiexSCzyHZMbFAsOcXmxztPyYJp();
		ReInput.ApplicationIsFullScreenChangedEvent -= QEgviCIOXceAkluEgTvZzmjZFdD;
		ReInput.ApplicationFullScreenModeChangedEvent -= SzxrrziurVLHDPmtOGWOBZoWowk;
		lock (hPJCLiCUpxQTtluQoqkhIxuyRXEw)
		{
			if (P_0 && BNRwQaHYudxtMzjvBeOOjyanYNh != null)
			{
				for (int i = 0; i < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; i++)
				{
					if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null)
					{
						BNRwQaHYudxtMzjvBeOOjyanYNh[i].SdCpHXCeCCZSBrMShYjjsXEWWgu();
						BNRwQaHYudxtMzjvBeOOjyanYNh[i].Dispose();
					}
				}
			}
			HiiTvoNPcGjxldZszkjwFICZGRy();
			if (TkzRUwgZbBhFZfoYvaKmbxZGcfmx != null)
			{
				TkzRUwgZbBhFZfoYvaKmbxZGcfmx.Dispose();
				TkzRUwgZbBhFZfoYvaKmbxZGcfmx = null;
			}
			if (MHOguSHKDpCslowFrgeilBKioqQB && bfGNYwKXEUTHcSMsSbVYbqRcFyX != null)
			{
				bfGNYwKXEUTHcSMsSbVYbqRcFyX.Dispose();
			}
			if (nDrVOOXzsMdXepMzAAVSLdpYhnhj && EyqykcmEIygobLZbPDDtXCagSsP != null)
			{
				EyqykcmEIygobLZbPDDtXCagSsP.Dispose();
			}
			NLAafvtpIMpkQDvRyQpTkAkoxUf.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
		}
		if (sZDCuXonuesoQqBPayGRZTryRwu != null)
		{
			sZDCuXonuesoQqBPayGRZTryRwu.Dispose();
		}
		euujVPFzGztViWDbYvUutBvFQFP = true;
	}

	public unsafe static bool vTXbPWoRYRDlFArXUISNbPwbwMuJ(MAPTyOhgNVdBQSioUpquSdYiRkd P_0, out int P_1)
	{
		P_1 = 0;
		uint num = 0u;
		AewjMoBLyBolnnNMhBXWHRooNZC.WPimmLUNirHddOMGogIEehnEPAPc(IntPtr.Zero, ref num, (uint)Marshal.SizeOf(typeof(AZmbvcVIunYbHEntMIOGHkdhIws)));
		if (num == 0)
		{
			return false;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		AZmbvcVIunYbHEntMIOGHkdhIws* ptr = stackalloc AZmbvcVIunYbHEntMIOGHkdhIws[(int)num];
		AewjMoBLyBolnnNMhBXWHRooNZC.WPimmLUNirHddOMGogIEehnEPAPc((IntPtr)ptr, ref num, (uint)Marshal.SizeOf(typeof(AZmbvcVIunYbHEntMIOGHkdhIws)));
		for (int i = 0; i < num; i++)
		{
			IntPtr iwQsZkJYbdNBBYrWJIGRHvvDEft = ptr[i].IwQsZkJYbdNBBYrWJIGRHvvDEft;
			int num5 = 0;
			int num6 = pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.KYGPUtgqYxzzHXPzLmAfndkgbKA, IntPtr.Zero, ref num5);
			if (num5 == 0)
			{
				num4++;
				continue;
			}
			num3++;
			byte* ptr2 = stackalloc byte[(int)(uint)num5];
			*(int*)ptr2 = num5;
			num6 = pKZMnjMMImQdiKyeumoKPkbgwQI.uXdQxHDpZlhDnraSJLluJrIrfUF(iwQsZkJYbdNBBYrWJIGRHvvDEft, yDzOYwhrGcjGweXvPzNXXJeRUPD.KYGPUtgqYxzzHXPzLmAfndkgbKA, (IntPtr)ptr2, ref num5);
			if (num6 >= 0)
			{
				ghJPqjSBgqEidmvfDuvMlyNpuRu ghJPqjSBgqEidmvfDuvMlyNpuRu2 = *(ghJPqjSBgqEidmvfDuvMlyNpuRu*)ptr2;
				if (ghJPqjSBgqEidmvfDuvMlyNpuRu2.UANajORgEjGJZDtTWdmqYjUulHF == P_0)
				{
					num2++;
				}
			}
		}
		if (num4 > 0 && num3 == 0)
		{
			return false;
		}
		P_1 = num2;
		return true;
	}

	[CompilerGenerated]
	private static void AtgCHRmKGaZhsoMWcUInOalqbckf(XISatJdVArtMUkOXRoGcIhpgBatq P_0)
	{
		P_0.Dispose();
	}
}
