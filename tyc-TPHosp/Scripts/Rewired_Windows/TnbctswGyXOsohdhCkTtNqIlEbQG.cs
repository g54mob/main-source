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

internal class TnbctswGyXOsohdhCkTtNqIlEbQG : IDisposable, IInputSource
{
	private class pFXJjTPAHAkwSmwpNwTmrkLNvPI
	{
		public ushort BxafNJkJtOFaxVleUwCGlbttMIiV;

		public ushort KDfWXUFaLdQqPyAIcaaumlCxdCx;

		public pFXJjTPAHAkwSmwpNwTmrkLNvPI(ushort usagePage, ushort usage)
		{
			BxafNJkJtOFaxVleUwCGlbttMIiV = usagePage;
			KDfWXUFaLdQqPyAIcaaumlCxdCx = usage;
		}
	}

	internal class dmznEfMcmACrsElDBnNeNiwuKhjs : IDisposable, VaqvDpgkuJiGiwrYcarAfGJvBwg
	{
		public const int MTaeCHHvElgfKaBrYcFPFPcXAAh = 255;

		private IntPtr vpATVchIurDpwnfdZpfdKSQeZoM;

		private IntPtr YGKcpIierGbJsZdardmeJIJmsqh;

		private GOUqibZATrhkkfBhFGUPLtOGCtXc iAeQroVENVwrouKceRNINuLZsWQ;

		private readonly string qCcRlFrxLjvuAvPCVTKHJuXBFic;

		private readonly string cOVPWYHIxIeEGflbzRCBVoJkSmb;

		private readonly string eifqQBREWsQamjCzDPZfPxdTTAD;

		private readonly string EKryPeznGehMNHjIiXptWumbdoxm;

		private readonly cNqhVgEYIrMJTiTjxOdwdqkXdtm RWLrzajMNfQbzheCNfyxgRByUxeC;

		private readonly string KaaNdgotxpCOaNdBJkUIRisrgiD;

		private readonly int isyBtvjeSBnCfIjarLBNnpRtXnAm;

		private readonly int zMXbnkkBTtVBlodmKvaoAxdEVURo;

		private readonly bool oLgwCSZYHiRjtbQsOKflJyPVmmD;

		private readonly string OpLgIwHwYQnJbsVgZqCFHdVCsiJ;

		private readonly bool oJnLxaLfsLvWeOLKoklPDfVQCsF;

		private readonly GOUqibZATrhkkfBhFGUPLtOGCtXc BjlAyxVTnsIrTuwWbcoysqAbitK;

		private readonly vGadJCdIpisicGGdCatSEKaeeoMw[] BaBXBqoKjHSAjRRwaPeiZtpusjV;

		private readonly EYmOazTOIpjiDNDnyssTMNYXnGh[] BMRENGlPXSOPUPkDGCVjcTINPEkd;

		private vLFRVGoQdvLiGDEOuwvTRdjdROL MhdBNYrjFvSHIkkNMIpWkgHdvevR;

		private vLFRVGoQdvLiGDEOuwvTRdjdROL NoBpqbxIqJvEVTyaYpuIjCyIDgW;

		private IntXagckLNcUoGeacSUWpfTZVlAg lqpzJzunfFgMfvLtjeHvHuCaIuh;

		private HdBuxkNOOEZIHWRPVOLLsBUUVRU ZVcViedIZEhhOarQtnkxZQgQgTY;

		[CompilerGenerated]
		private bool AFjgThcyxilcexDgyEDTdjpjRksw;

		public IntPtr Handle => YGKcpIierGbJsZdardmeJIJmsqh;

		public bool IsOpen
		{
			[CompilerGenerated]
			get
			{
				return AFjgThcyxilcexDgyEDTdjpjRksw;
			}
			[CompilerGenerated]
			private set
			{
				AFjgThcyxilcexDgyEDTdjpjRksw = value;
			}
		}

		public bool IsConnected => true;

		public string Description => "";

		public GOUqibZATrhkkfBhFGUPLtOGCtXc Capabilities => iAeQroVENVwrouKceRNINuLZsWQ;

		public cNqhVgEYIrMJTiTjxOdwdqkXdtm Attributes => RWLrzajMNfQbzheCNfyxgRByUxeC;

		public string DevicePath => cOVPWYHIxIeEGflbzRCBVoJkSmb;

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

		public vGadJCdIpisicGGdCatSEKaeeoMw[] ButtonCapabilities => BaBXBqoKjHSAjRRwaPeiZtpusjV;

		public EYmOazTOIpjiDNDnyssTMNYXnGh[] ValueCapabilities => BMRENGlPXSOPUPkDGCVjcTINPEkd;

		public string DevicePathStripped => eifqQBREWsQamjCzDPZfPxdTTAD;

		public string InstanceId => EKryPeznGehMNHjIiXptWumbdoxm;

		public string Manufacturer => KaaNdgotxpCOaNdBJkUIRisrgiD;

		public int HubId => isyBtvjeSBnCfIjarLBNnpRtXnAm;

		public int PortId => zMXbnkkBTtVBlodmKvaoAxdEVURo;

		public bool IsBluetoothDevice => oLgwCSZYHiRjtbQsOKflJyPVmmD;

		public string BluetoothDeviceName => OpLgIwHwYQnJbsVgZqCFHdVCsiJ;

		public bool HasLocationInfo => false;

		public event IntXagckLNcUoGeacSUWpfTZVlAg Inserted
		{
			add
			{
				IntXagckLNcUoGeacSUWpfTZVlAg intXagckLNcUoGeacSUWpfTZVlAg = lqpzJzunfFgMfvLtjeHvHuCaIuh;
				IntXagckLNcUoGeacSUWpfTZVlAg intXagckLNcUoGeacSUWpfTZVlAg2;
				do
				{
					intXagckLNcUoGeacSUWpfTZVlAg2 = intXagckLNcUoGeacSUWpfTZVlAg;
					IntXagckLNcUoGeacSUWpfTZVlAg value2 = (IntXagckLNcUoGeacSUWpfTZVlAg)Delegate.Combine(intXagckLNcUoGeacSUWpfTZVlAg2, value);
					intXagckLNcUoGeacSUWpfTZVlAg = Interlocked.CompareExchange(ref lqpzJzunfFgMfvLtjeHvHuCaIuh, value2, intXagckLNcUoGeacSUWpfTZVlAg2);
				}
				while ((object)intXagckLNcUoGeacSUWpfTZVlAg != intXagckLNcUoGeacSUWpfTZVlAg2);
			}
			remove
			{
				IntXagckLNcUoGeacSUWpfTZVlAg intXagckLNcUoGeacSUWpfTZVlAg = lqpzJzunfFgMfvLtjeHvHuCaIuh;
				IntXagckLNcUoGeacSUWpfTZVlAg intXagckLNcUoGeacSUWpfTZVlAg2;
				do
				{
					intXagckLNcUoGeacSUWpfTZVlAg2 = intXagckLNcUoGeacSUWpfTZVlAg;
					IntXagckLNcUoGeacSUWpfTZVlAg value2 = (IntXagckLNcUoGeacSUWpfTZVlAg)Delegate.Remove(intXagckLNcUoGeacSUWpfTZVlAg2, value);
					intXagckLNcUoGeacSUWpfTZVlAg = Interlocked.CompareExchange(ref lqpzJzunfFgMfvLtjeHvHuCaIuh, value2, intXagckLNcUoGeacSUWpfTZVlAg2);
				}
				while ((object)intXagckLNcUoGeacSUWpfTZVlAg != intXagckLNcUoGeacSUWpfTZVlAg2);
			}
		}

		public event HdBuxkNOOEZIHWRPVOLLsBUUVRU Removed
		{
			add
			{
				HdBuxkNOOEZIHWRPVOLLsBUUVRU hdBuxkNOOEZIHWRPVOLLsBUUVRU = ZVcViedIZEhhOarQtnkxZQgQgTY;
				HdBuxkNOOEZIHWRPVOLLsBUUVRU hdBuxkNOOEZIHWRPVOLLsBUUVRU2;
				do
				{
					hdBuxkNOOEZIHWRPVOLLsBUUVRU2 = hdBuxkNOOEZIHWRPVOLLsBUUVRU;
					HdBuxkNOOEZIHWRPVOLLsBUUVRU value2 = (HdBuxkNOOEZIHWRPVOLLsBUUVRU)Delegate.Combine(hdBuxkNOOEZIHWRPVOLLsBUUVRU2, value);
					hdBuxkNOOEZIHWRPVOLLsBUUVRU = Interlocked.CompareExchange(ref ZVcViedIZEhhOarQtnkxZQgQgTY, value2, hdBuxkNOOEZIHWRPVOLLsBUUVRU2);
				}
				while ((object)hdBuxkNOOEZIHWRPVOLLsBUUVRU != hdBuxkNOOEZIHWRPVOLLsBUUVRU2);
			}
			remove
			{
				HdBuxkNOOEZIHWRPVOLLsBUUVRU hdBuxkNOOEZIHWRPVOLLsBUUVRU = ZVcViedIZEhhOarQtnkxZQgQgTY;
				HdBuxkNOOEZIHWRPVOLLsBUUVRU hdBuxkNOOEZIHWRPVOLLsBUUVRU2;
				do
				{
					hdBuxkNOOEZIHWRPVOLLsBUUVRU2 = hdBuxkNOOEZIHWRPVOLLsBUUVRU;
					HdBuxkNOOEZIHWRPVOLLsBUUVRU value2 = (HdBuxkNOOEZIHWRPVOLLsBUUVRU)Delegate.Remove(hdBuxkNOOEZIHWRPVOLLsBUUVRU2, value);
					hdBuxkNOOEZIHWRPVOLLsBUUVRU = Interlocked.CompareExchange(ref ZVcViedIZEhhOarQtnkxZQgQgTY, value2, hdBuxkNOOEZIHWRPVOLLsBUUVRU2);
				}
				while ((object)hdBuxkNOOEZIHWRPVOLLsBUUVRU != hdBuxkNOOEZIHWRPVOLLsBUUVRU2);
			}
		}

		public static dmznEfMcmACrsElDBnNeNiwuKhjs lbqDKtkdAEfGvlnCOTVXuRhvyhm(IntPtr P_0, string P_1)
		{
			return new dmznEfMcmACrsElDBnNeNiwuKhjs(P_0, P_1, P_1, "", "", 0, 0, isBluetoothDevice: false, "");
		}

		public dmznEfMcmACrsElDBnNeNiwuKhjs(IntPtr rawInputDeviceHandle, string devicePath, string instanceId, string description, string manufacturer, int hubId, int portId, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			vpATVchIurDpwnfdZpfdKSQeZoM = rawInputDeviceHandle;
			try
			{
				cOVPWYHIxIeEGflbzRCBVoJkSmb = devicePath;
				eifqQBREWsQamjCzDPZfPxdTTAD = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(devicePath);
				EKryPeznGehMNHjIiXptWumbdoxm = instanceId;
				qCcRlFrxLjvuAvPCVTKHJuXBFic = StringTools.SanitizeDeviceString(description);
				KaaNdgotxpCOaNdBJkUIRisrgiD = StringTools.SanitizeDeviceString(manufacturer);
				isyBtvjeSBnCfIjarLBNnpRtXnAm = hubId;
				zMXbnkkBTtVBlodmKvaoAxdEVURo = portId;
				oLgwCSZYHiRjtbQsOKflJyPVmmD = isBluetoothDevice;
				OpLgIwHwYQnJbsVgZqCFHdVCsiJ = StringTools.SanitizeDeviceString(bluetoothDeviceName);
				if (!IsOpen)
				{
					oJnLxaLfsLvWeOLKoklPDfVQCsF = true;
					YGKcpIierGbJsZdardmeJIJmsqh = rawInputDeviceHandle;
					IsOpen = true;
				}
				IntPtr yGKcpIierGbJsZdardmeJIJmsqh = YGKcpIierGbJsZdardmeJIJmsqh;
				iAeQroVENVwrouKceRNINuLZsWQ = nGuMwmGQLFierjbLPQhsmJwGfEIc.tdJfnKIwlmyKRFMqixSIaOrpcTnt(yGKcpIierGbJsZdardmeJIJmsqh);
				RWLrzajMNfQbzheCNfyxgRByUxeC = nGuMwmGQLFierjbLPQhsmJwGfEIc.ljrVgGikRbClXzhLaYlXZtBMSyR(yGKcpIierGbJsZdardmeJIJmsqh);
				BjlAyxVTnsIrTuwWbcoysqAbitK = nGuMwmGQLFierjbLPQhsmJwGfEIc.tdJfnKIwlmyKRFMqixSIaOrpcTnt(yGKcpIierGbJsZdardmeJIJmsqh);
				BaBXBqoKjHSAjRRwaPeiZtpusjV = nGuMwmGQLFierjbLPQhsmJwGfEIc.XSzknqEVWdXQZQfxpTDpeubjSlC(yGKcpIierGbJsZdardmeJIJmsqh, 0, BjlAyxVTnsIrTuwWbcoysqAbitK.NumberInputButtonCaps);
				BMRENGlPXSOPUPkDGCVjcTINPEkd = nGuMwmGQLFierjbLPQhsmJwGfEIc.kifKUGBOZSjCcPoVCQqlavaRnLh(yGKcpIierGbJsZdardmeJIJmsqh, 0, BjlAyxVTnsIrTuwWbcoysqAbitK.NumberInputValueCaps);
				_ = RWLrzajMNfQbzheCNfyxgRByUxeC;
				_ = BjlAyxVTnsIrTuwWbcoysqAbitK;
				_ = BaBXBqoKjHSAjRRwaPeiZtpusjV;
				_ = BMRENGlPXSOPUPkDGCVjcTINPEkd;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error querying HID device \"{devicePath}\" at location {YGKcpIierGbJsZdardmeJIJmsqh}.\nException Message: {ex.Message}\nStack Trace: {ex.StackTrace}", ex);
			}
			finally
			{
				try
				{
					PikORwFFuZFgRBJdRDOdGnDFJuHQ();
				}
				catch
				{
				}
			}
		}

		public void kTWqnDIbyEyichBFMBINlCeYDXF()
		{
			kTWqnDIbyEyichBFMBINlCeYDXF(vLFRVGoQdvLiGDEOuwvTRdjdROL.jnkRsbnZVdEnrWJTjbGGfLqWfFbT, vLFRVGoQdvLiGDEOuwvTRdjdROL.jnkRsbnZVdEnrWJTjbGGfLqWfFbT, mmtXDuKsQlMiStwVPbFRUklSYaT.QEItTnuCeYaACEukHOCvGzKKmQem);
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.kTWqnDIbyEyichBFMBINlCeYDXF()
		{
			//ILSpy generated this explicit interface implementation from .override directive in kTWqnDIbyEyichBFMBINlCeYDXF
			this.kTWqnDIbyEyichBFMBINlCeYDXF();
		}

		public void kTWqnDIbyEyichBFMBINlCeYDXF(vLFRVGoQdvLiGDEOuwvTRdjdROL P_0, vLFRVGoQdvLiGDEOuwvTRdjdROL P_1, mmtXDuKsQlMiStwVPbFRUklSYaT P_2)
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				IsOpen = true;
				return;
			}
			MhdBNYrjFvSHIkkNMIpWkgHdvevR = P_0;
			NoBpqbxIqJvEVTyaYpuIjCyIDgW = P_1;
			try
			{
				YGKcpIierGbJsZdardmeJIJmsqh = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, P_0, 2147483648u, P_2);
			}
			catch (Exception innerException)
			{
				IsOpen = false;
				throw new Exception("Error opening HID device.", innerException);
			}
			IsOpen = YGKcpIierGbJsZdardmeJIJmsqh.ToInt32() != -1;
			_ = IsOpen;
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.kTWqnDIbyEyichBFMBINlCeYDXF(vLFRVGoQdvLiGDEOuwvTRdjdROL P_0, vLFRVGoQdvLiGDEOuwvTRdjdROL P_1, mmtXDuKsQlMiStwVPbFRUklSYaT P_2)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kTWqnDIbyEyichBFMBINlCeYDXF
			this.kTWqnDIbyEyichBFMBINlCeYDXF(P_0, P_1, P_2);
		}

		public void PikORwFFuZFgRBJdRDOdGnDFJuHQ()
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				IsOpen = false;
			}
			else if (IsOpen)
			{
				if (YGKcpIierGbJsZdardmeJIJmsqh != IntPtr.Zero)
				{
					nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(YGKcpIierGbJsZdardmeJIJmsqh);
				}
				IsOpen = false;
				YGKcpIierGbJsZdardmeJIJmsqh = IntPtr.Zero;
			}
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.PikORwFFuZFgRBJdRDOdGnDFJuHQ()
		{
			//ILSpy generated this explicit interface implementation from .override directive in PikORwFFuZFgRBJdRDOdGnDFJuHQ
			this.PikORwFFuZFgRBJdRDOdGnDFJuHQ();
		}

		public VTSWpJxdqWwWKExRbpiyfgoBilMC DTWqTxyQfjlbrIFGzfuUHiIHdt()
		{
			return null;
		}

		VTSWpJxdqWwWKExRbpiyfgoBilMC VaqvDpgkuJiGiwrYcarAfGJvBwg.DTWqTxyQfjlbrIFGzfuUHiIHdt()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DTWqTxyQfjlbrIFGzfuUHiIHdt
			return this.DTWqTxyQfjlbrIFGzfuUHiIHdt();
		}

		public void DTWqTxyQfjlbrIFGzfuUHiIHdt(JnVmHkHhHfdeNXpEjMdsJeYfcAJ P_0)
		{
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.DTWqTxyQfjlbrIFGzfuUHiIHdt(JnVmHkHhHfdeNXpEjMdsJeYfcAJ P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DTWqTxyQfjlbrIFGzfuUHiIHdt
			this.DTWqTxyQfjlbrIFGzfuUHiIHdt(P_0);
		}

		public VTSWpJxdqWwWKExRbpiyfgoBilMC DTWqTxyQfjlbrIFGzfuUHiIHdt(int P_0)
		{
			return null;
		}

		VTSWpJxdqWwWKExRbpiyfgoBilMC VaqvDpgkuJiGiwrYcarAfGJvBwg.DTWqTxyQfjlbrIFGzfuUHiIHdt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DTWqTxyQfjlbrIFGzfuUHiIHdt
			return this.DTWqTxyQfjlbrIFGzfuUHiIHdt(P_0);
		}

		public void nqDzpsBVFGNGuUbCtzOGCESaaij(nFJUblcsKBXapcGVncXAWlehCvB P_0)
		{
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.nqDzpsBVFGNGuUbCtzOGCESaaij(nFJUblcsKBXapcGVncXAWlehCvB P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nqDzpsBVFGNGuUbCtzOGCESaaij
			this.nqDzpsBVFGNGuUbCtzOGCESaaij(P_0);
		}

		public kVIAiGUXiHUgrqGpkFpZAChkKzK nqDzpsBVFGNGuUbCtzOGCESaaij(int P_0)
		{
			return null;
		}

		kVIAiGUXiHUgrqGpkFpZAChkKzK VaqvDpgkuJiGiwrYcarAfGJvBwg.nqDzpsBVFGNGuUbCtzOGCESaaij(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nqDzpsBVFGNGuUbCtzOGCESaaij
			return this.nqDzpsBVFGNGuUbCtzOGCESaaij(P_0);
		}

		public kVIAiGUXiHUgrqGpkFpZAChkKzK nqDzpsBVFGNGuUbCtzOGCESaaij()
		{
			return null;
		}

		kVIAiGUXiHUgrqGpkFpZAChkKzK VaqvDpgkuJiGiwrYcarAfGJvBwg.nqDzpsBVFGNGuUbCtzOGCESaaij()
		{
			//ILSpy generated this explicit interface implementation from .override directive in nqDzpsBVFGNGuUbCtzOGCESaaij
			return this.nqDzpsBVFGNGuUbCtzOGCESaaij();
		}

		public bool byuaaJsMyyjrTHdBoFhsRkaLLRm(out byte[] P_0, byte P_1 = 0)
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				P_0 = null;
				return false;
			}
			if (BjlAyxVTnsIrTuwWbcoysqAbitK.FeatureReportByteLength <= 0)
			{
				P_0 = new byte[0];
				return false;
			}
			P_0 = new byte[BjlAyxVTnsIrTuwWbcoysqAbitK.FeatureReportByteLength];
			byte[] array = ggjpmVJhQkgcokaEAAKzsrrmtTYs();
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
					intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				flag = RGIgZGFrnmqngVujnbAVaLKYaInc.MQsVQxfpKZuzNTjIkMzlMpQaFji(intPtr, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, P_0, 0, Math.Min(P_0.Length, BjlAyxVTnsIrTuwWbcoysqAbitK.FeatureReportByteLength));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{cOVPWYHIxIeEGflbzRCBVoJkSmb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
				}
			}
			return flag;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.byuaaJsMyyjrTHdBoFhsRkaLLRm(out byte[] P_0, byte P_1 = 0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in byuaaJsMyyjrTHdBoFhsRkaLLRm
			return this.byuaaJsMyyjrTHdBoFhsRkaLLRm(out P_0, P_1);
		}

		public string hGWnWkyuYsGvKxKINIkKkOfzYJg()
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				return string.Empty;
			}
			try
			{
				if (!hGWnWkyuYsGvKxKINIkKkOfzYJg(out var bytes))
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

		string VaqvDpgkuJiGiwrYcarAfGJvBwg.hGWnWkyuYsGvKxKINIkKkOfzYJg()
		{
			//ILSpy generated this explicit interface implementation from .override directive in hGWnWkyuYsGvKxKINIkKkOfzYJg
			return this.hGWnWkyuYsGvKxKINIkKkOfzYJg();
		}

		public unsafe bool hGWnWkyuYsGvKxKINIkKkOfzYJg(out byte[] P_0)
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
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
					intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				fixed (IntPtr* ptr = P_0)
				{
					return RGIgZGFrnmqngVujnbAVaLKYaInc.VwsjMSSNYqYVtsTvKivduSMNqSg(intPtr, (IntPtr)ptr, P_0.Length);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{cOVPWYHIxIeEGflbzRCBVoJkSmb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
				}
			}
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.hGWnWkyuYsGvKxKINIkKkOfzYJg(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hGWnWkyuYsGvKxKINIkKkOfzYJg
			return this.hGWnWkyuYsGvKxKINIkKkOfzYJg(out P_0);
		}

		public string jYIpiYUiDDxgEemUYgUmGmENCMlV()
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				return string.Empty;
			}
			jYIpiYUiDDxgEemUYgUmGmENCMlV(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string VaqvDpgkuJiGiwrYcarAfGJvBwg.jYIpiYUiDDxgEemUYgUmGmENCMlV()
		{
			//ILSpy generated this explicit interface implementation from .override directive in jYIpiYUiDDxgEemUYgUmGmENCMlV
			return this.jYIpiYUiDDxgEemUYgUmGmENCMlV();
		}

		public bool jYIpiYUiDDxgEemUYgUmGmENCMlV(out byte[] P_0)
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
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
					intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				GCHandle gCHandle = GCHandle.Alloc(P_0, GCHandleType.Pinned);
				flag = RGIgZGFrnmqngVujnbAVaLKYaInc.DFuAcalabrTthKEzaIqsbqJEWWR(intPtr, gCHandle.AddrOfPinnedObject(), P_0.Length);
				GC.KeepAlive(gCHandle);
				gCHandle.Free();
				return flag;
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{cOVPWYHIxIeEGflbzRCBVoJkSmb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
				}
			}
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.jYIpiYUiDDxgEemUYgUmGmENCMlV(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jYIpiYUiDDxgEemUYgUmGmENCMlV
			return this.jYIpiYUiDDxgEemUYgUmGmENCMlV(out P_0);
		}

		public string OKJUZXbWmtKHCKBBILDyjkeFjvuc()
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
			{
				return string.Empty;
			}
			OKJUZXbWmtKHCKBBILDyjkeFjvuc(out var bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		string VaqvDpgkuJiGiwrYcarAfGJvBwg.OKJUZXbWmtKHCKBBILDyjkeFjvuc()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OKJUZXbWmtKHCKBBILDyjkeFjvuc
			return this.OKJUZXbWmtKHCKBBILDyjkeFjvuc();
		}

		public bool OKJUZXbWmtKHCKBBILDyjkeFjvuc(out byte[] P_0)
		{
			if (oJnLxaLfsLvWeOLKoklPDfVQCsF)
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
					intPtr = nGuMwmGQLFierjbLPQhsmJwGfEIc.EUCiiGthEwmWsFLtUbxbLHIplvv(cOVPWYHIxIeEGflbzRCBVoJkSmb, 0u);
					if (intPtr.ToInt32() == -1)
					{
						P_0 = null;
						return false;
					}
				}
				return nGuMwmGQLFierjbLPQhsmJwGfEIc.OKJUZXbWmtKHCKBBILDyjkeFjvuc(intPtr, out P_0);
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error accessing HID device '{cOVPWYHIxIeEGflbzRCBVoJkSmb}'.", innerException);
			}
			finally
			{
				if (!IsOpen && intPtr.ToInt32() != -1)
				{
					nGuMwmGQLFierjbLPQhsmJwGfEIc.DIdoDdNadmqPzrnrzduWVXqeCFI(intPtr);
				}
			}
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.OKJUZXbWmtKHCKBBILDyjkeFjvuc(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OKJUZXbWmtKHCKBBILDyjkeFjvuc
			return this.OKJUZXbWmtKHCKBBILDyjkeFjvuc(out P_0);
		}

		public string UKlbaGDDVjGkLsqMcKmLsWkSncb()
		{
			return "";
		}

		string VaqvDpgkuJiGiwrYcarAfGJvBwg.UKlbaGDDVjGkLsqMcKmLsWkSncb()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UKlbaGDDVjGkLsqMcKmLsWkSncb
			return this.UKlbaGDDVjGkLsqMcKmLsWkSncb();
		}

		public bool UKlbaGDDVjGkLsqMcKmLsWkSncb(out byte[] P_0)
		{
			P_0 = null;
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.UKlbaGDDVjGkLsqMcKmLsWkSncb(out byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UKlbaGDDVjGkLsqMcKmLsWkSncb
			return this.UKlbaGDDVjGkLsqMcKmLsWkSncb(out P_0);
		}

		public void ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, AOQmjnGYRWRJLtLCBMUKxYttZcp P_1)
		{
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, AOQmjnGYRWRJLtLCBMUKxYttZcp P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ujTUoJrkpPHtthAWMneMiOxOImEn
			this.ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1);
		}

		public bool ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ujTUoJrkpPHtthAWMneMiOxOImEn
			return this.ujTUoJrkpPHtthAWMneMiOxOImEn(P_0);
		}

		public bool ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.ujTUoJrkpPHtthAWMneMiOxOImEn(byte[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ujTUoJrkpPHtthAWMneMiOxOImEn
			return this.ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1);
		}

		public void kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0, AOQmjnGYRWRJLtLCBMUKxYttZcp P_1)
		{
		}

		void VaqvDpgkuJiGiwrYcarAfGJvBwg.kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0, AOQmjnGYRWRJLtLCBMUKxYttZcp P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kBeOjHNNxUQeLDBLfaYBEHtSIyl
			this.kBeOjHNNxUQeLDBLfaYBEHtSIyl(P_0, P_1);
		}

		public bool kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kBeOjHNNxUQeLDBLfaYBEHtSIyl
			return this.kBeOjHNNxUQeLDBLfaYBEHtSIyl(P_0);
		}

		public bool kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0, int P_1)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.kBeOjHNNxUQeLDBLfaYBEHtSIyl(kVIAiGUXiHUgrqGpkFpZAChkKzK P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kBeOjHNNxUQeLDBLfaYBEHtSIyl
			return this.kBeOjHNNxUQeLDBLfaYBEHtSIyl(P_0, P_1);
		}

		public kVIAiGUXiHUgrqGpkFpZAChkKzK AQkExFGUIQIURKtkNbHRCSTmELA()
		{
			return null;
		}

		kVIAiGUXiHUgrqGpkFpZAChkKzK VaqvDpgkuJiGiwrYcarAfGJvBwg.AQkExFGUIQIURKtkNbHRCSTmELA()
		{
			//ILSpy generated this explicit interface implementation from .override directive in AQkExFGUIQIURKtkNbHRCSTmELA
			return this.AQkExFGUIQIURKtkNbHRCSTmELA();
		}

		public bool NaCVrYyqyJSbLFxrhOzZglXSmSk(byte[] P_0)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.NaCVrYyqyJSbLFxrhOzZglXSmSk(byte[] P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in NaCVrYyqyJSbLFxrhOzZglXSmSk
			return this.NaCVrYyqyJSbLFxrhOzZglXSmSk(P_0);
		}

		public void Dispose()
		{
		}

		public bool MfhitAnTLXvQItFgTAdKkqWiUQDA(OutputReport P_0)
		{
			return false;
		}

		bool VaqvDpgkuJiGiwrYcarAfGJvBwg.MfhitAnTLXvQItFgTAdKkqWiUQDA(OutputReport P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MfhitAnTLXvQItFgTAdKkqWiUQDA
			return this.MfhitAnTLXvQItFgTAdKkqWiUQDA(P_0);
		}

		private byte[] dKdGDyYsNDixKBCNassIeBsMIzm()
		{
			return RCStZxIPCIffhqEcHEvfjOEOBlyh(Capabilities.InputReportByteLength - 1);
		}

		private byte[] GrMEPgCMinldRRLHRLiEsRbQKqUf()
		{
			return RCStZxIPCIffhqEcHEvfjOEOBlyh(Capabilities.OutputReportByteLength - 1);
		}

		private byte[] ggjpmVJhQkgcokaEAAKzsrrmtTYs()
		{
			return RCStZxIPCIffhqEcHEvfjOEOBlyh(Capabilities.FeatureReportByteLength - 1);
		}

		private static byte[] RCStZxIPCIffhqEcHEvfjOEOBlyh(int P_0)
		{
			byte[] array = null;
			Array.Resize(ref array, P_0 + 1);
			return array;
		}
	}

	private sealed class wCXiNVhyEYckyeYXBVpeOUQZcVTk
	{
		public IList<uNUGDLxbzFWxnCXPxXiZAvRTReD.ZmXFQUItFfCeopshMNfCzCYqGWRT> HSabFjYVXdETNBizFqCjBBZXYVCf;
	}

	private sealed class mwlMvUNXgflbgiOOpYzVIvXmobi
	{
		public wCXiNVhyEYckyeYXBVpeOUQZcVTk QlgAdVzhlCHhILfMSGaaCmeyBwmv;

		public int KkwenKcPgMthUjPIAjjsOvKvZNJ;

		public bool TnDOBToheHwkwQtLOmHmZmfSXsz(string P_0)
		{
			return P_0.Equals(QlgAdVzhlCHhILfMSGaaCmeyBwmv.HSabFjYVXdETNBizFqCjBBZXYVCf[KkwenKcPgMthUjPIAjjsOvKvZNJ].QINdymBLIRcKJaTdWehjTiexQWpP, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class ODSvKjXZmSEphpaRQouZNmsEhfp
	{
		public UzKBIaEyudSpXeLmfwTkGCYvktG KsFhwyqGXhghwAgCvdwIWUXkzkt;

		public bool sZyWzncRmIffnwwLctWgnboGPVt(UzKBIaEyudSpXeLmfwTkGCYvktG P_0)
		{
			return P_0.InstanceGuid == KsFhwyqGXhghwAgCvdwIWUXkzkt.InstanceGuid;
		}
	}

	private sealed class gkxdhTomeyDmmVsywpqArNXwoIA
	{
		public VaqvDpgkuJiGiwrYcarAfGJvBwg asmYaWmxhhxAvHfCvKwwZpLKsLb;

		public byte[] KezCvZUULWcDBEjitgQsEQlTFlCH(byte P_0)
		{
			asmYaWmxhhxAvHfCvKwwZpLKsLb.byuaaJsMyyjrTHdBoFhsRkaLLRm(out var result, P_0);
			return result;
		}
	}

	private sealed class bdfZUJUJPJNwMZQJnoSGXjTwidT
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public TnbctswGyXOsohdhCkTtNqIlEbQG atnkeqgXxTBLxuTqVeTupqRLlmp;

		public void HxnaIMdihxrzaAlUFSpFCYowntHf()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)4, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz | lnLtgfjCbGTuEHySKYDjQQSMxeZ.XSkpVyrTLlrlbWpxhSOtHNbWyri, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)5, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz | lnLtgfjCbGTuEHySKYDjQQSMxeZ.XSkpVyrTLlrlbWpxhSOtHNbWyri, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)8, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz | lnLtgfjCbGTuEHySKYDjQQSMxeZ.XSkpVyrTLlrlbWpxhSOtHNbWyri, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)12, (CUhcvapUsrWjXwNyOxmYzeTbHtG)1, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz | lnLtgfjCbGTuEHySKYDjQQSMxeZ.XSkpVyrTLlrlbWpxhSOtHNbWyri, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class APPVzYprMwNrwSiRUXwiduEFSjr
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public void zAiDbqXUAwGzsCrHLMswSAFbYeWr()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)4);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)5);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)8);
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)12, (CUhcvapUsrWjXwNyOxmYzeTbHtG)1);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class OioBBHLVfKNoSBXnKIozStWuqCR
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public void SwWUqDOOVCErCEFUPpjrfpsAtfn()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)2);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class NODbnQabezfdkHEorRcssumXzIR
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public TnbctswGyXOsohdhCkTtNqIlEbQG atnkeqgXxTBLxuTqVeTupqRLlmp;

		public void VGcPVbTzOYRItdsHMTwmZjvRNdw()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)2, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class tiBYawGCgGxSYdKebGZdvUUAJeJ
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public TnbctswGyXOsohdhCkTtNqIlEbQG atnkeqgXxTBLxuTqVeTupqRLlmp;

		public void jRWHyiJWClOlFaNtDhBxeRiwUCKQ()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)6, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz, atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw.Handle);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class fCMRlFtDkZDojWJhfCLeihHMMeM
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public void cRHqogxseOJYIxavvVSnkDSgeaO()
		{
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.fjotmDISHTdOOLGKqdHdKJtnuyxL((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)6);
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private sealed class conpUFOsToosceOsXkaLugPlyVj
	{
		public bool IiXkrZUDoDQJGBLvntiTVJhrQfe;

		public TnbctswGyXOsohdhCkTtNqIlEbQG atnkeqgXxTBLxuTqVeTupqRLlmp;

		public edTUHywUTXJFvcLrQjKxoJZxDUQ.XpiEHHTMzPiIeoZcydWZQlFDxjx fILqFoEEpbqLdNzWUDXySFpmWMw;

		public void sgBERjXbQxlLYaKvjaoTdHagSusi()
		{
			try
			{
				atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw = guEhgojmxcTfJTRnAANDnKlVhdQ(fILqFoEEpbqLdNzWUDXySFpmWMw);
				if (atnkeqgXxTBLxuTqVeTupqRLlmp.GXSoFvfITGBheVaKUcmXAVgDMlw == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				IiXkrZUDoDQJGBLvntiTVJhrQfe = true;
			}
		}
	}

	private const float uZLgfsHgTGpbVhohsqIlDHCdjSwt = 0.25f;

	private const float ShwnVNGQGbxqsRxknozMXYIzChJ = 1f;

	private List<UzKBIaEyudSpXeLmfwTkGCYvktG> WEuHIpAYAmfrlFuzqsSpOYLelMz;

	private List<UzKBIaEyudSpXeLmfwTkGCYvktG> jXTnesyDxIhSIBdAZXswAEeoFoK;

	private ReadOnlyCollection<UzKBIaEyudSpXeLmfwTkGCYvktG> dJNbUxoDgkPIipPdRAGjSqfiqoq;

	private TaAHjLoGaYExvekcumBiOQzAKKnf gbfDpHBZrJfTocsWzQNuhALfiJmz;

	private rzBAKwBWKxcqQDABpdzeUuBgNqWX DiHHKfzpefiqSfpheozUieJnZqLj;

	private ConfigVars KwfsfhlcXHbtZqDWjONkwMwRzFn;

	private UpdateLoopSetting MPyWITsdDQWvVIANbJUScpirSgO;

	private readonly bool DRXLJKNLPKWCwOywJSdSXWvcaxm;

	private readonly bool tzYHxRnlzOrnlnzshpfccGilhLX;

	private readonly bool JtjQTORvuooIOWTuKIJSajqliWY;

	private readonly bool ukIkfFWACDFFXBsntvhnwgCRpQh;

	private readonly bool tWdeiPaMhOkHvjUOAKwhhqsBYGmW;

	private bool OtXGRLAaxyKxYjnQrnIHwsxWHnp;

	private bool ewBwxUhZzBlDIIwgecsqRjiLurn;

	private bool uZccTIDEbaUmzvtUFyrzfnUOeuKF;

	private bool alCEEHebznjwuITtaGzLVOOHurR;

	private int BKJArabMgKLNywMoIKsMRdbDWEMM;

	private readonly object yAilvIBDYuDWgEEBLUCtOVezLUR = new object();

	private readonly vhuTewWDBpLMDxvpkZHGGwmKHcf ysJwuxouGXsgSrmKROPIaNUkOwR;

	private int zxiIrZmNjIFWUSPGqSXpdXWuIdc = -1;

	private staHFdAGuasEGlJuzBixSVxSxvc poyVeUdnFpEyfDMVRBIcmmarrXmR;

	private IntPtr QATuChSnHKVMVTyeMhUTMHlnIoq;

	private IntPtr YpNaCAUkMlSuzeXUlGbSNkEimyw;

	private ValueWatcher<IntPtr> ItxsIaechePrdDFoHqnlkEyGEOD;

	private ValueWatcher[] qQjDjDYprdIGvaQNLrjJqWGjpam;

	private double egvUaLcsYKljuIZeSeVHFJlkghwc;

	private edTUHywUTXJFvcLrQjKxoJZxDUQ GXSoFvfITGBheVaKUcmXAVgDMlw;

	private BIXdBVBpLiLDoIYaDiHpEQRHsEe AwHBHGASPjUXQAtzamgAseIyTkaw;

	private static SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf umIXXrtZhivZzSkLeuYFqUcuHbQ;

	private SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC GFVdlNmAIandcyoUjoFwnAdTIkS;

	private NativeBuffer nvJKiQpYNGkoVaIGqrsiWxSJMuW;

	private static Rewired.Internal.GUIText DAytqRVIexZgkoJZPPJUOmswmzd;

	private static pFXJjTPAHAkwSmwpNwTmrkLNvPI[] fBoigImAeWFmLSNgNEgeWFTAysX = new pFXJjTPAHAkwSmwpNwTmrkLNvPI[4]
	{
		new pFXJjTPAHAkwSmwpNwTmrkLNvPI(1, 4),
		new pFXJjTPAHAkwSmwpNwTmrkLNvPI(1, 5),
		new pFXJjTPAHAkwSmwpNwTmrkLNvPI(1, 8),
		new pFXJjTPAHAkwSmwpNwTmrkLNvPI(12, 1)
	};

	private readonly GAUEpREwZxMNaJbUVtjuRaurvUI oiyRgwlJyLTdqhAgqlqkmovhjuY = new GAUEpREwZxMNaJbUVtjuRaurvUI();

	private readonly joIDPhdLsQJpsETSRAVogyJSANzE neJBuHYCUGSMKAbUOjcxPAeVGsC = new joIDPhdLsQJpsETSRAVogyJSANzE();

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	[CompilerGenerated]
	private static Action<UzKBIaEyudSpXeLmfwTkGCYvktG> mxlckGTmVNtMARudttVxvqQQp;

	public static Rewired.Internal.GUIText guiText
	{
		get
		{
			if (DAytqRVIexZgkoJZPPJUOmswmzd != null)
			{
				return DAytqRVIexZgkoJZPPJUOmswmzd;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			if (gameObject != null)
			{
				DAytqRVIexZgkoJZPPJUOmswmzd = gameObject.GetComponent<Rewired.Internal.GUIText>();
			}
			else
			{
				gameObject = new GameObject("DebugScreenLog");
				gameObject.transform.position = Vector3.zero;
				DAytqRVIexZgkoJZPPJUOmswmzd = gameObject.AddComponent<Rewired.Internal.GUIText>();
				DAytqRVIexZgkoJZPPJUOmswmzd.anchor = TextAnchor.LowerLeft;
				DAytqRVIexZgkoJZPPJUOmswmzd.alignment = TextAlignment.Left;
				DAytqRVIexZgkoJZPPJUOmswmzd.pixelOffset = new Vector2(1200f, 0f);
			}
			return DAytqRVIexZgkoJZPPJUOmswmzd;
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

	public TnbctswGyXOsohdhCkTtNqIlEbQG(ConfigVars configVars, bool handleJoysticks, bool useCustomDrivers, TaAHjLoGaYExvekcumBiOQzAKKnf unifiedMouse, rzBAKwBWKxcqQDABpdzeUuBgNqWX unifiedKeyboard)
	{
		try
		{
			KwfsfhlcXHbtZqDWjONkwMwRzFn = configVars;
			MPyWITsdDQWvVIANbJUScpirSgO = configVars.updateLoop;
			ItxsIaechePrdDFoHqnlkEyGEOD = new ValueWatcher<IntPtr>(HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT(), HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT, autoTriggerEvent: true);
			ItxsIaechePrdDFoHqnlkEyGEOD.ChangedEvent += GgIRoZnPzOJagJKVSxMTHONpSon;
			qQjDjDYprdIGvaQNLrjJqWGjpam = new ValueWatcher[1] { ItxsIaechePrdDFoHqnlkEyGEOD };
			tzYHxRnlzOrnlnzshpfccGilhLX = handleJoysticks;
			tWdeiPaMhOkHvjUOAKwhhqsBYGmW = useCustomDrivers;
			gbfDpHBZrJfTocsWzQNuhALfiJmz = unifiedMouse;
			DiHHKfzpefiqSfpheozUieJnZqLj = unifiedKeyboard;
			JtjQTORvuooIOWTuKIJSajqliWY = unifiedMouse != null;
			ukIkfFWACDFFXBsntvhnwgCRpQh = unifiedKeyboard != null;
			DRXLJKNLPKWCwOywJSdSXWvcaxm = ReInput.isEditor;
			WEuHIpAYAmfrlFuzqsSpOYLelMz = new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
			dJNbUxoDgkPIipPdRAGjSqfiqoq = new ReadOnlyCollection<UzKBIaEyudSpXeLmfwTkGCYvktG>(WEuHIpAYAmfrlFuzqsSpOYLelMz);
			jXTnesyDxIhSIBdAZXswAEeoFoK = new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
			umIXXrtZhivZzSkLeuYFqUcuHbQ = new SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf
			{
				CyZqStgDIPaCFFuUFvMLYbSUmTA = (uint)Marshal.SizeOf(typeof(SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf)),
				ILBZqpUBdcwOCWrFqDMUfThBePpI = true,
				FwYcvZAFJCllLyaumofpiiVeOwR = true,
				dGSKygCEVJYNCGctpQYPlEDdwCh = false,
				YQQsOvGGdkTiyUZyJVlMfGBKJLv = true,
				ezyFEbZEpGjDhDxJvZhaDKYhntGf = IntPtr.Zero
			};
			GFVdlNmAIandcyoUjoFwnAdTIkS = SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC.KbsenlehkfKhrEUvGoQEltREagOX();
			nvJKiQpYNGkoVaIGqrsiWxSJMuW = new NativeBuffer((int)GFVdlNmAIandcyoUjoFwnAdTIkS.CyZqStgDIPaCFFuUFvMLYbSUmTA);
			nvJKiQpYNGkoVaIGqrsiWxSJMuW.Write(GFVdlNmAIandcyoUjoFwnAdTIkS.CyZqStgDIPaCFFuUFvMLYbSUmTA, 0);
			if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
			{
				jZarxNqRCkOrgvSxYccCpSKSdCi(NFaEHkhLdDAYcLQWfNoLlPOPqfeV);
				JfAUOeaeKijFEqMPRjKTJBzbHK();
			}
			if (handleJoysticks)
			{
				try
				{
					BmLXWuFfjXVDGDnTVJCtqjwhrdz();
					LSnPWTQwWkIknpTkXQajtOILawb(ref WEuHIpAYAmfrlFuzqsSpOYLelMz, mhQmEDsgUFylEDFVEQjnEFxCnnE(true));
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
			kaoPIXWAutVDAzxcJeZHFLjYZjf();
			ReInput.ApplicationIsFullScreenChangedEvent += BbDFRLeHglawFWHcZnxqtIVEuVBT;
			ReInput.ApplicationFullScreenModeChangedEvent += ZmQDYstoDQBIqnOrzcFdiYTXiiu;
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	public void BmLXWuFfjXVDGDnTVJCtqjwhrdz()
	{
	}

	public void yuBsGanGpqqzptceTaJAiCPaLrkD()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			lock (yAilvIBDYuDWgEEBLUCtOVezLUR)
			{
				LSnPWTQwWkIknpTkXQajtOILawb(ref WEuHIpAYAmfrlFuzqsSpOYLelMz, jXTnesyDxIhSIBdAZXswAEeoFoK);
				jXTnesyDxIhSIBdAZXswAEeoFoK.Clear();
			}
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			wvWIkVspNCxhznhoWtPlvoMCbMk();
		}
		uZccTIDEbaUmzvtUFyrzfnUOeuKF = false;
	}

	public bool KKxAHhSKkINjxsYIxciKdvSYHuM()
	{
		lock (yAilvIBDYuDWgEEBLUCtOVezLUR)
		{
			if (SdkntCjhcZWIdBruWIkCZfJRJVT())
			{
				Thread.Sleep(250);
			}
			jXTnesyDxIhSIBdAZXswAEeoFoK = mhQmEDsgUFylEDFVEQjnEFxCnnE(false);
			return true;
		}
	}

	public bool owfpfzaklbjNBPVhNVwCfhVyUWS()
	{
		int num = MbygVUWNZSfDtSutQmNkXFrCJem();
		if (num == BKJArabMgKLNywMoIKsMRdbDWEMM)
		{
			return false;
		}
		BKJArabMgKLNywMoIKsMRdbDWEMM = num;
		return true;
	}

	public bool SdkntCjhcZWIdBruWIkCZfJRJVT()
	{
		try
		{
			return uNUGDLxbzFWxnCXPxXiZAvRTReD.SdkntCjhcZWIdBruWIkCZfJRJVT();
		}
		catch
		{
		}
		return false;
	}

	public bool MLVEEFCtQzFVqsWSDKGUEGnjjnWV(bool P_0)
	{
		bool result = alCEEHebznjwuITtaGzLVOOHurR;
		if (P_0)
		{
			alCEEHebznjwuITtaGzLVOOHurR = false;
		}
		return result;
	}

	public void SystemDeviceDisconnected()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			uZccTIDEbaUmzvtUFyrzfnUOeuKF = true;
		}
	}

	public void SystemDeviceConnected()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			uZccTIDEbaUmzvtUFyrzfnUOeuKF = true;
		}
	}

	public void Update()
	{
		for (int i = 0; i < qQjDjDYprdIGvaQNLrjJqWGjpam.Length; i++)
		{
			qQjDjDYprdIGvaQNLrjJqWGjpam[i].Update();
		}
		if (zxiIrZmNjIFWUSPGqSXpdXWuIdc >= 0)
		{
			yCxmBYPNhvOTgdCFaMnnQaOyFDMf();
		}
		if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			if (zxiIrZmNjIFWUSPGqSXpdXWuIdc < 0 && (ukIkfFWACDFFXBsntvhnwgCRpQh || JtjQTORvuooIOWTuKIJSajqliWY))
			{
				PKpUpVOkaYEpwAwHbJUyEoergcV();
			}
		}
		else if (ukIkfFWACDFFXBsntvhnwgCRpQh || JtjQTORvuooIOWTuKIJSajqliWY)
		{
			dVtfOxRaqkqcOcaNovhhmkRnMcR();
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			int count = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
			for (int i = 0; i < count; i++)
			{
				WEuHIpAYAmfrlFuzqsSpOYLelMz[i]?.CWncwVbJhTWISMonvIVEimpDcKXc(updateLoop);
			}
		}
	}

	public void UpdateFinished()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			int count = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
			for (int i = 0; i < count; i++)
			{
				WEuHIpAYAmfrlFuzqsSpOYLelMz[i]?.gXADYrdzIttymTRoaKqLkIyUtDJ();
			}
		}
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return dJNbUxoDgkPIipPdRAGjSqfiqoq as IList<T>;
	}

	private List<UzKBIaEyudSpXeLmfwTkGCYvktG> mhQmEDsgUFylEDFVEQjnEFxCnnE(bool P_0)
	{
		wCXiNVhyEYckyeYXBVpeOUQZcVTk wCXiNVhyEYckyeYXBVpeOUQZcVTk2 = new wCXiNVhyEYckyeYXBVpeOUQZcVTk();
		if (!tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			return new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
		}
		OXrFmvFKCbADOFSbIASBdSdKAlzj();
		List<vExjksMabWUnVIMvagNEfjZDaFR> list = null;
		List<UzKBIaEyudSpXeLmfwTkGCYvktG> list2 = new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
		BKJArabMgKLNywMoIKsMRdbDWEMM = XUztxfKEcObZGjmTfyBLZmKdnJe();
		if (0 == 0)
		{
			list = RYsmQBBipzDHDxpfaoUEYTKBcDn.npLwcPNqCJKIqEewEfYdgbDGPcD(P_0);
			bool flag = true;
		}
		if (list == null)
		{
			list = new List<vExjksMabWUnVIMvagNEfjZDaFR>();
		}
		try
		{
			wCXiNVhyEYckyeYXBVpeOUQZcVTk2.HSabFjYVXdETNBizFqCjBBZXYVCf = uNUGDLxbzFWxnCXPxXiZAvRTReD.OWKbVxrqgGFsIdUOFPIlbCgKOPX();
		}
		catch (Exception ex)
		{
			wCXiNVhyEYckyeYXBVpeOUQZcVTk2.HSabFjYVXdETNBizFqCjBBZXYVCf = new List<uNUGDLxbzFWxnCXPxXiZAvRTReD.ZmXFQUItFfCeopshMNfCzCYqGWRT>();
			Rewired.Logger.LogError("Exception getting HID device list.\n" + ex);
		}
		List<string> list3 = new List<string>();
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG = null;
			try
			{
				vExjksMabWUnVIMvagNEfjZDaFR vExjksMabWUnVIMvagNEfjZDaFR2 = list[i];
				if (list[i] != null && vExjksMabWUnVIMvagNEfjZDaFR2.DeviceType == TNuYvFcSdWFqveHgvUhHbRntguj.YIMjNMrHOiIZiGZsLTHFXIEgJNJ && vExjksMabWUnVIMvagNEfjZDaFR2 is bugieSpilmSbyiYYybatwGrmmnM bugieSpilmSbyiYYybatwGrmmnM2)
				{
					uzKBIaEyudSpXeLmfwTkGCYvktG = hOggZrOHKLrEKyOiZdMcJmQISet(vExjksMabWUnVIMvagNEfjZDaFR2.Handle, bugieSpilmSbyiYYybatwGrmmnM2, wCXiNVhyEYckyeYXBVpeOUQZcVTk2.HSabFjYVXdETNBizFqCjBBZXYVCf, list3, num);
					if (uzKBIaEyudSpXeLmfwTkGCYvktG != null)
					{
						list2.Add(uzKBIaEyudSpXeLmfwTkGCYvktG);
						num++;
					}
				}
			}
			catch (Exception ex2)
			{
				Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex2.Message);
			}
		}
		if (!KwfsfhlcXHbtZqDWjONkwMwRzFn.useXInput)
		{
			mwlMvUNXgflbgiOOpYzVIvXmobi mwlMvUNXgflbgiOOpYzVIvXmobi2 = new mwlMvUNXgflbgiOOpYzVIvXmobi();
			mwlMvUNXgflbgiOOpYzVIvXmobi2.QlgAdVzhlCHhILfMSGaaCmeyBwmv = wCXiNVhyEYckyeYXBVpeOUQZcVTk2;
			mwlMvUNXgflbgiOOpYzVIvXmobi2.KkwenKcPgMthUjPIAjjsOvKvZNJ = 0;
			while (mwlMvUNXgflbgiOOpYzVIvXmobi2.KkwenKcPgMthUjPIAjjsOvKvZNJ < wCXiNVhyEYckyeYXBVpeOUQZcVTk2.HSabFjYVXdETNBizFqCjBBZXYVCf.Count)
			{
				UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG2 = null;
				try
				{
					if (string.IsNullOrEmpty(list3.Find(mwlMvUNXgflbgiOOpYzVIvXmobi2.TnDOBToheHwkwQtLOmHmZmfSXsz)))
					{
						uzKBIaEyudSpXeLmfwTkGCYvktG2 = TVbEZelWanKDcfvvtQwfSKGOsqY(wCXiNVhyEYckyeYXBVpeOUQZcVTk2.HSabFjYVXdETNBizFqCjBBZXYVCf[mwlMvUNXgflbgiOOpYzVIvXmobi2.KkwenKcPgMthUjPIAjjsOvKvZNJ], num);
						if (uzKBIaEyudSpXeLmfwTkGCYvktG2 != null)
						{
							list2.Add(uzKBIaEyudSpXeLmfwTkGCYvktG2);
							num++;
						}
					}
				}
				catch (Exception ex3)
				{
					Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional." + ex3.Message);
				}
				mwlMvUNXgflbgiOOpYzVIvXmobi2.KkwenKcPgMthUjPIAjjsOvKvZNJ++;
			}
		}
		return list2;
	}

	private static void LSnPWTQwWkIknpTkXQajtOILawb(ref List<UzKBIaEyudSpXeLmfwTkGCYvktG> P_0, List<UzKBIaEyudSpXeLmfwTkGCYvktG> P_1)
	{
		if (P_0 == null)
		{
			P_0 = new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
		}
		if (P_1 == null)
		{
			P_1 = new List<UzKBIaEyudSpXeLmfwTkGCYvktG>();
		}
		if (P_1.Count == 0)
		{
			P_0.ForEach(delegate(UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG)
			{
				uzKBIaEyudSpXeLmfwTkGCYvktG.Dispose();
			});
			P_0.Clear();
			return;
		}
		int count = P_1.Count;
		int count2 = P_0.Count;
		UzKBIaEyudSpXeLmfwTkGCYvktG[] array = P_1.ToArray();
		if (array.Length > 0)
		{
			Array.Sort(array, VtWZWEvMPFKlZmIfMYKGaiJbhrJ);
		}
		for (int num = 0; num < count2; num++)
		{
			ODSvKjXZmSEphpaRQouZNmsEhfp oDSvKjXZmSEphpaRQouZNmsEhfp = new ODSvKjXZmSEphpaRQouZNmsEhfp();
			oDSvKjXZmSEphpaRQouZNmsEhfp.KsFhwyqGXhghwAgCvdwIWUXkzkt = P_0[num];
			if (oDSvKjXZmSEphpaRQouZNmsEhfp.KsFhwyqGXhghwAgCvdwIWUXkzkt != null && Array.Find(array, oDSvKjXZmSEphpaRQouZNmsEhfp.sZyWzncRmIffnwwLctWgnboGPVt) == null)
			{
				oDSvKjXZmSEphpaRQouZNmsEhfp.KsFhwyqGXhghwAgCvdwIWUXkzkt.Dispose();
			}
		}
		P_0.Clear();
		for (int num2 = 0; num2 < count; num2++)
		{
			if (array[num2] != null)
			{
				array[num2].adyaTeLDJgHxhZocZCoUcxEskgr(num2);
				P_0.Add(array[num2]);
			}
		}
	}

	private List<vExjksMabWUnVIMvagNEfjZDaFR> obNisqRDCeOADiUuUCPWlhwjxz()
	{
		List<vExjksMabWUnVIMvagNEfjZDaFR> list = new List<vExjksMabWUnVIMvagNEfjZDaFR>();
		try
		{
			foreach (nGuMwmGQLFierjbLPQhsmJwGfEIc item in uNUGDLxbzFWxnCXPxXiZAvRTReD.NJgRnafHbufsFBKJRzsIEfBsYFn())
			{
				try
				{
					list.Add(new bugieSpilmSbyiYYybatwGrmmnM
					{
						DeviceName = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(item.DevicePath),
						DeviceType = TNuYvFcSdWFqveHgvUhHbRntguj.YIMjNMrHOiIZiGZsLTHFXIEgJNJ,
						Handle = IntPtr.Zero,
						ProductId = item.Attributes.ProductId,
						VendorId = item.Attributes.VendorId,
						VersionNumber = item.Attributes.Version,
						UsagePage = (nyUqWoTPfgeFKszzeqbfSzWedfw)item.Capabilities.UsagePage,
						Usage = (CUhcvapUsrWjXwNyOxmYzeTbHtG)item.Capabilities.Usage
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

	private UzKBIaEyudSpXeLmfwTkGCYvktG hOggZrOHKLrEKyOiZdMcJmQISet(IntPtr P_0, bugieSpilmSbyiYYybatwGrmmnM P_1, IList<uNUGDLxbzFWxnCXPxXiZAvRTReD.ZmXFQUItFfCeopshMNfCzCYqGWRT> P_2, List<string> P_3, int P_4)
	{
		ushort num = (ushort)P_1.UsagePage;
		ushort num2 = (ushort)P_1.Usage;
		string deviceName = P_1.DeviceName;
		if (!hVkRLHdkESCvYCecCuvBhlDMpSn(num, num2))
		{
			return null;
		}
		string text = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(deviceName);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		P_3.Add(text);
		VaqvDpgkuJiGiwrYcarAfGJvBwg vaqvDpgkuJiGiwrYcarAfGJvBwg = uNUGDLxbzFWxnCXPxXiZAvRTReD.qunazVrBUyDwcuIHjOiYTeaFryQ(P_2, text, StringComparison.OrdinalIgnoreCase);
		if (vaqvDpgkuJiGiwrYcarAfGJvBwg == null)
		{
			vaqvDpgkuJiGiwrYcarAfGJvBwg = dmznEfMcmACrsElDBnNeNiwuKhjs.lbqDKtkdAEfGvlnCOTVXuRhvyhm(P_0, deviceName);
		}
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			string text2 = vaqvDpgkuJiGiwrYcarAfGJvBwg.hGWnWkyuYsGvKxKINIkKkOfzYJg();
			string bluetoothDeviceName = vaqvDpgkuJiGiwrYcarAfGJvBwg.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(vaqvDpgkuJiGiwrYcarAfGJvBwg.Attributes.VendorId, vaqvDpgkuJiGiwrYcarAfGJvBwg.Attributes.ProductId);
			if (ZKLIjvmxtRjTyokzJnlXgDPvgmC.BVHeJtCJXPFBfGgHsARPRMvrhkyB(guid, text2, bluetoothDeviceName))
			{
				P_3.RemoveAt(P_3.Count - 1);
				return null;
			}
		}
		return mBzVyPHQbGOpJTQMQabAHXsuteV(kbwNPkkZgMQwtrrUfDtgBehkdCIF.AjimIsdzzIUtPBAKcIsQfuovG, vaqvDpgkuJiGiwrYcarAfGJvBwg, P_0, num, num2, P_4);
	}

	private UzKBIaEyudSpXeLmfwTkGCYvktG TVbEZelWanKDcfvvtQwfSKGOsqY(uNUGDLxbzFWxnCXPxXiZAvRTReD.ZmXFQUItFfCeopshMNfCzCYqGWRT P_0, int P_1)
	{
		nGuMwmGQLFierjbLPQhsmJwGfEIc nGuMwmGQLFierjbLPQhsmJwGfEIc2 = uNUGDLxbzFWxnCXPxXiZAvRTReD.essAheQJZqwiPkHWQAaOqbmODgRi(P_0);
		if (nGuMwmGQLFierjbLPQhsmJwGfEIc2 == null)
		{
			return null;
		}
		ushort num = (ushort)nGuMwmGQLFierjbLPQhsmJwGfEIc2.Capabilities.UsagePage;
		ushort num2 = (ushort)nGuMwmGQLFierjbLPQhsmJwGfEIc2.Capabilities.Usage;
		if (!hVkRLHdkESCvYCecCuvBhlDMpSn(num, num2))
		{
			return null;
		}
		bool flag = false;
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			flag = ZKLIjvmxtRjTyokzJnlXgDPvgmC.BVHeJtCJXPFBfGgHsARPRMvrhkyB(MiscTools.CreateHIDProductGuid(nGuMwmGQLFierjbLPQhsmJwGfEIc2.Attributes.VendorId, nGuMwmGQLFierjbLPQhsmJwGfEIc2.Attributes.ProductId), nGuMwmGQLFierjbLPQhsmJwGfEIc2.hGWnWkyuYsGvKxKINIkKkOfzYJg(), nGuMwmGQLFierjbLPQhsmJwGfEIc2.BluetoothDeviceName);
		}
		if (!flag)
		{
			return null;
		}
		return mBzVyPHQbGOpJTQMQabAHXsuteV(kbwNPkkZgMQwtrrUfDtgBehkdCIF.ADXAokkagcVrIlDjbhPcHkSHqqXZ, nGuMwmGQLFierjbLPQhsmJwGfEIc2, IntPtr.Zero, num, num2, P_1);
	}

	private UzKBIaEyudSpXeLmfwTkGCYvktG mBzVyPHQbGOpJTQMQabAHXsuteV(kbwNPkkZgMQwtrrUfDtgBehkdCIF P_0, VaqvDpgkuJiGiwrYcarAfGJvBwg P_1, IntPtr P_2, ushort P_3, ushort P_4, int P_5)
	{
		bool flag = P_3 != 1 || !SZFLyVaNzSdOsaspaPpaYDJlIGK.CyVbTMdtGIyOulKYQECpcbeCczc.IbssfQfaJfQGOPYGMrrPUYKGKiz(P_4);
		if (KwfsfhlcXHbtZqDWjONkwMwRzFn.useXInput && P_3 == 1 && (P_4 == 4 || P_4 == 5))
		{
			string text = P_1.hGWnWkyuYsGvKxKINIkKkOfzYJg();
			string bluetoothDeviceName = P_1.BluetoothDeviceName;
			Guid guid = MiscTools.CreateHIDProductGuid(P_1.Attributes.VendorId, P_1.Attributes.ProductId);
			if (mFhbDHUVMhTRsTSifoqtETGQFLi.TmdtXLMLtxmfoirfUPEqxZwbkhn(P_1.DevicePath, text, bluetoothDeviceName, guid))
			{
				return null;
			}
		}
		UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG = PllJfTjvnIWLJrnlfapcLBfylpZ(P_0, P_2, P_5, P_1, WEuHIpAYAmfrlFuzqsSpOYLelMz, flag);
		if (uzKBIaEyudSpXeLmfwTkGCYvktG == null || !uzKBIaEyudSpXeLmfwTkGCYvktG.HasElements)
		{
			if (uzKBIaEyudSpXeLmfwTkGCYvktG != null && !uzKBIaEyudSpXeLmfwTkGCYvktG.HasElements)
			{
				uzKBIaEyudSpXeLmfwTkGCYvktG.Dispose();
			}
			return null;
		}
		return uzKBIaEyudSpXeLmfwTkGCYvktG;
	}

	private bool hVkRLHdkESCvYCecCuvBhlDMpSn(ushort P_0, ushort P_1)
	{
		for (int i = 0; i < fBoigImAeWFmLSNgNEgeWFTAysX.Length; i++)
		{
			if (fBoigImAeWFmLSNgNEgeWFTAysX[i].BxafNJkJtOFaxVleUwCGlbttMIiV == P_0 && fBoigImAeWFmLSNgNEgeWFTAysX[i].KDfWXUFaLdQqPyAIcaaumlCxdCx == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private int XUztxfKEcObZGjmTfyBLZmKdnJe()
	{
		try
		{
			return uNUGDLxbzFWxnCXPxXiZAvRTReD.FyyHFsnMdNTwjVEDmbXDLritDjL();
		}
		catch
		{
			return 0;
		}
	}

	private int MbygVUWNZSfDtSutQmNkXFrCJem()
	{
		try
		{
			return uNUGDLxbzFWxnCXPxXiZAvRTReD.FyyHFsnMdNTwjVEDmbXDLritDjL(ref umIXXrtZhivZzSkLeuYFqUcuHbQ, nvJKiQpYNGkoVaIGqrsiWxSJMuW);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private UzKBIaEyudSpXeLmfwTkGCYvktG PllJfTjvnIWLJrnlfapcLBfylpZ(kbwNPkkZgMQwtrrUfDtgBehkdCIF P_0, IntPtr P_1, int P_2, VaqvDpgkuJiGiwrYcarAfGJvBwg P_3, List<UzKBIaEyudSpXeLmfwTkGCYvktG> P_4, bool P_5)
	{
		gkxdhTomeyDmmVsywpqArNXwoIA gkxdhTomeyDmmVsywpqArNXwoIA2 = new gkxdhTomeyDmmVsywpqArNXwoIA();
		gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb = P_3;
		if (P_5 && !tWdeiPaMhOkHvjUOAKwhhqsBYGmW)
		{
			return null;
		}
		try
		{
			if (tWdeiPaMhOkHvjUOAKwhhqsBYGmW)
			{
				if (P_4 != null)
				{
					for (int i = 0; i < P_4.Count; i++)
					{
						if (P_4[i] is xGZvbflmaFvIVZqDAVLwVcNGzWa xGZvbflmaFvIVZqDAVLwVcNGzWa2 && xGZvbflmaFvIVZqDAVLwVcNGzWa2.Driver != null && !(gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.InstanceId != xGZvbflmaFvIVZqDAVLwVcNGzWa2.HidDevice.InstanceId))
						{
							xGZvbflmaFvIVZqDAVLwVcNGzWa2.adyaTeLDJgHxhZocZCoUcxEskgr(P_2);
							return xGZvbflmaFvIVZqDAVLwVcNGzWa2;
						}
					}
				}
				HIDDeviceDriver.DriverType driverType = HIDDeviceDriver.FindDriverId(gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.Attributes.VendorId, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.Attributes.ProductId);
				if (driverType != HIDDeviceDriver.DriverType.DVDMTdEnkAaktJFJqNakDhECjSAS)
				{
					HidOutputReportHandler hidOutputReportHandler = new HidOutputReportHandler(gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.MfhitAnTLXvQItFgTAdKkqWiUQDA);
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(driverType, new HIDDeviceDriver.InitArgs(MPyWITsdDQWvVIANbJUScpirSgO, (!gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.IsBluetoothDevice) ? DeviceConnectionType.OgSTRTrIaGjDfcJzbNHbUocnLQDp : DeviceConnectionType.gGXVuYpwdzdIqhuTWerNGskghzz, 65535, -65535, -1, 4500, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.Capabilities.InputReportByteLength, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.Capabilities.OutputReportByteLength, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.MfhitAnTLXvQItFgTAdKkqWiUQDA, hidOutputReportHandler.WriteReport, gkxdhTomeyDmmVsywpqArNXwoIA2.KezCvZUULWcDBEjitgQsEQlTFlCH));
					if (driver != null)
					{
						return new xGZvbflmaFvIVZqDAVLwVcNGzWa(P_2, P_0, P_1, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb, driver, hidOutputReportHandler);
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
					if (P_4[j] is wwLeoMBCxCEjXPiqztkjGHLruPe wwLeoMBCxCEjXPiqztkjGHLruPe2 && !(gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb.InstanceId != wwLeoMBCxCEjXPiqztkjGHLruPe2.HidDevice.InstanceId))
					{
						wwLeoMBCxCEjXPiqztkjGHLruPe2.adyaTeLDJgHxhZocZCoUcxEskgr(P_2);
						return wwLeoMBCxCEjXPiqztkjGHLruPe2;
					}
				}
			}
			return new wwLeoMBCxCEjXPiqztkjGHLruPe(P_2, P_0, P_1, gkxdhTomeyDmmVsywpqArNXwoIA2.asmYaWmxhhxAvHfCvKwwZpLKsLb);
		}
		catch
		{
			return null;
		}
	}

	private UzKBIaEyudSpXeLmfwTkGCYvktG khVpXkrCgqXQBBdFCYKLvvpZkna(kbwNPkkZgMQwtrrUfDtgBehkdCIF P_0, IntPtr P_1)
	{
		if (WEuHIpAYAmfrlFuzqsSpOYLelMz == null)
		{
			return null;
		}
		for (int i = 0; i < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; i++)
		{
			UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG = WEuHIpAYAmfrlFuzqsSpOYLelMz[i];
			if (uzKBIaEyudSpXeLmfwTkGCYvktG.JoystickSourceType == P_0 && !(uzKBIaEyudSpXeLmfwTkGCYvktG.JoystickSourceHandle != P_1))
			{
				return uzKBIaEyudSpXeLmfwTkGCYvktG;
			}
		}
		return null;
	}

	private unsafe UzKBIaEyudSpXeLmfwTkGCYvktG dSgCtjFliQQFwCJgVqYoGvjhBNW(IntPtr P_0)
	{
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.VdMwMLmmJWAgrIVKcSrudndXJqM(P_0, 536870919u, IntPtr.Zero, out var num);
		if (num == 0)
		{
			return null;
		}
		char* value = stackalloc char[(int)num];
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.VdMwMLmmJWAgrIVKcSrudndXJqM(P_0, 536870919u, new IntPtr(value), out num);
		int length = (int)(((int)num > 0) ? (num - 1) : 0);
		string text = new string(value, 0, length);
		if (text.Length == 0)
		{
			text = string.Empty;
		}
		if (WEuHIpAYAmfrlFuzqsSpOYLelMz == null)
		{
			return null;
		}
		text = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(text);
		for (int i = 0; i < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; i++)
		{
			UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG = WEuHIpAYAmfrlFuzqsSpOYLelMz[i];
			if (uzKBIaEyudSpXeLmfwTkGCYvktG.JoystickSourceType == kbwNPkkZgMQwtrrUfDtgBehkdCIF.AjimIsdzzIUtPBAKcIsQfuovG && uzKBIaEyudSpXeLmfwTkGCYvktG.HidDevice.DevicePathStripped.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				uzKBIaEyudSpXeLmfwTkGCYvktG.BDfABKSWSvgJHmOKusCxrnCPRYP(P_0);
				return uzKBIaEyudSpXeLmfwTkGCYvktG;
			}
		}
		return null;
	}

	private static int VtWZWEvMPFKlZmIfMYKGaiJbhrJ(UzKBIaEyudSpXeLmfwTkGCYvktG P_0, UzKBIaEyudSpXeLmfwTkGCYvktG P_1)
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

	private void OXrFmvFKCbADOFSbIASBdSdKAlzj()
	{
		bdfZUJUJPJNwMZQJnoSGXjTwidT bdfZUJUJPJNwMZQJnoSGXjTwidT2 = new bdfZUJUJPJNwMZQJnoSGXjTwidT();
		bdfZUJUJPJNwMZQJnoSGXjTwidT2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			bdfZUJUJPJNwMZQJnoSGXjTwidT2.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(bdfZUJUJPJNwMZQJnoSGXjTwidT2.HxnaIMdihxrzaAlUFSpFCYowntHf, true);
			if (bdfZUJUJPJNwMZQJnoSGXjTwidT2.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to register HID devices.", requiredThreadSafety: true);
			}
		}
	}

	private void GCwQgHUYxVqmCJbDbPdogtdEDTG()
	{
		APPVzYprMwNrwSiRUXwiduEFSjr aPPVzYprMwNrwSiRUXwiduEFSjr = new APPVzYprMwNrwSiRUXwiduEFSjr();
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			aPPVzYprMwNrwSiRUXwiduEFSjr.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(aPPVzYprMwNrwSiRUXwiduEFSjr.zAiDbqXUAwGzsCrHLMswSAFbYeWr, true);
			if (aPPVzYprMwNrwSiRUXwiduEFSjr.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to unregister HID devices.", requiredThreadSafety: true);
			}
		}
	}

	private void PKpUpVOkaYEpwAwHbJUyEoergcV()
	{
		if (ReInput.isAllowedEditorWindowFocused)
		{
			if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
			{
				pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
				if (JtjQTORvuooIOWTuKIJSajqliWY)
				{
					IntPtr qATuChSnHKVMVTyeMhUTMHlnIoq;
					bool flag = !trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Mouse, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out qATuChSnHKVMVTyeMhUTMHlnIoq);
					if (!OtXGRLAaxyKxYjnQrnIHwsxWHnp || !flag)
					{
						if (qATuChSnHKVMVTyeMhUTMHlnIoq == IntPtr.Zero)
						{
							qATuChSnHKVMVTyeMhUTMHlnIoq = QATuChSnHKVMVTyeMhUTMHlnIoq;
						}
						pcktyxTbcnQcKLLCeQQUDdkTAbp(qATuChSnHKVMVTyeMhUTMHlnIoq);
					}
				}
				if (!ukIkfFWACDFFXBsntvhnwgCRpQh)
				{
					return;
				}
				IntPtr ypNaCAUkMlSuzeXUlGbSNkEimyw;
				bool flag2 = !trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Keyboard, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out ypNaCAUkMlSuzeXUlGbSNkEimyw);
				if (!ewBwxUhZzBlDIIwgecsqRjiLurn || !flag2)
				{
					if (ypNaCAUkMlSuzeXUlGbSNkEimyw == IntPtr.Zero)
					{
						ypNaCAUkMlSuzeXUlGbSNkEimyw = YpNaCAUkMlSuzeXUlGbSNkEimyw;
					}
					CzNrywTFdMkCCRHthdbwabnwXUdL(ypNaCAUkMlSuzeXUlGbSNkEimyw);
				}
			}
			else
			{
				if (JtjQTORvuooIOWTuKIJSajqliWY && !OtXGRLAaxyKxYjnQrnIHwsxWHnp)
				{
					qqUCfXekfPVeGiSuFIspDxYSPsz();
				}
				if (ukIkfFWACDFFXBsntvhnwgCRpQh && !ewBwxUhZzBlDIIwgecsqRjiLurn)
				{
					wvWIkVspNCxhznhoWtPlvoMCbMk();
				}
			}
		}
		else
		{
			if (OtXGRLAaxyKxYjnQrnIHwsxWHnp)
			{
				MUiVVgZAXABwojCGxSsKpRonDVF();
			}
			if (ewBwxUhZzBlDIIwgecsqRjiLurn)
			{
				lJFLmBlYeqEOolTOJaGSEYQEQTG();
			}
		}
	}

	private void dVtfOxRaqkqcOcaNovhhmkRnMcR()
	{
		double realTime = ReInput.realTime;
		if (realTime < egvUaLcsYKljuIZeSeVHFJlkghwc + 1.0)
		{
			return;
		}
		egvUaLcsYKljuIZeSeVHFJlkghwc = realTime;
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
			if (JtjQTORvuooIOWTuKIJSajqliWY)
			{
				IntPtr intPtr;
				bool flag = !trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Mouse, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out intPtr);
				if (!OtXGRLAaxyKxYjnQrnIHwsxWHnp || !flag)
				{
					if (intPtr == IntPtr.Zero)
					{
						intPtr = QATuChSnHKVMVTyeMhUTMHlnIoq;
					}
					UeTsfYEybTRRxHKgmKjnGiLWhlRH();
				}
			}
			if (!ukIkfFWACDFFXBsntvhnwgCRpQh)
			{
				return;
			}
			IntPtr intPtr2;
			bool flag2 = !trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Keyboard, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out intPtr2);
			if (!ewBwxUhZzBlDIIwgecsqRjiLurn || !flag2)
			{
				if (intPtr2 == IntPtr.Zero)
				{
					intPtr2 = YpNaCAUkMlSuzeXUlGbSNkEimyw;
				}
				lmLxAOlhDVXnkPqVnujgzlLxHkq();
			}
		}
		else
		{
			if (JtjQTORvuooIOWTuKIJSajqliWY && !OtXGRLAaxyKxYjnQrnIHwsxWHnp)
			{
				qqUCfXekfPVeGiSuFIspDxYSPsz();
			}
			if (ukIkfFWACDFFXBsntvhnwgCRpQh && !ewBwxUhZzBlDIIwgecsqRjiLurn)
			{
				wvWIkVspNCxhznhoWtPlvoMCbMk();
			}
		}
	}

	private void UxclSBpILAffdTEhfHQVoocjvSZ()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
			if (JtjQTORvuooIOWTuKIJSajqliWY && trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Mouse, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out var _))
			{
				if (OtXGRLAaxyKxYjnQrnIHwsxWHnp)
				{
					OtXGRLAaxyKxYjnQrnIHwsxWHnp = false;
					gbfDpHBZrJfTocsWzQNuhALfiJmz.riSHQeDOIkBABkFvimBoHoVHLsiP(false);
				}
				UeTsfYEybTRRxHKgmKjnGiLWhlRH();
			}
		}
		else if (JtjQTORvuooIOWTuKIJSajqliWY && !OtXGRLAaxyKxYjnQrnIHwsxWHnp)
		{
			qqUCfXekfPVeGiSuFIspDxYSPsz();
		}
	}

	private void MUiVVgZAXABwojCGxSsKpRonDVF()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			SEvLYskSkZLlxnIXLwKwTALnHbn.auacIlDtNWpslGmMQNQLmoUsVpR(false);
			LOcarJhkEipWbdlYXtZuMjMmErO();
		}
		OtXGRLAaxyKxYjnQrnIHwsxWHnp = false;
		gbfDpHBZrJfTocsWzQNuhALfiJmz.riSHQeDOIkBABkFvimBoHoVHLsiP(false);
	}

	private void LOcarJhkEipWbdlYXtZuMjMmErO()
	{
		if (!JtjQTORvuooIOWTuKIJSajqliWY || ysJwuxouGXsgSrmKROPIaNUkOwR != vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			return;
		}
		IntPtr intPtr;
		if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
			if (trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Mouse, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out var qATuChSnHKVMVTyeMhUTMHlnIoq))
			{
				QATuChSnHKVMVTyeMhUTMHlnIoq = qATuChSnHKVMVTyeMhUTMHlnIoq;
			}
			intPtr = QATuChSnHKVMVTyeMhUTMHlnIoq;
		}
		else
		{
			intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT();
		}
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)2, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz, intPtr);
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
		else if (OtXGRLAaxyKxYjnQrnIHwsxWHnp)
		{
			OioBBHLVfKNoSBXnKIozStWuqCR oioBBHLVfKNoSBXnKIozStWuqCR = new OioBBHLVfKNoSBXnKIozStWuqCR();
			oioBBHLVfKNoSBXnKIozStWuqCR.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(oioBBHLVfKNoSBXnKIozStWuqCR.SwWUqDOOVCErCEFUPpjrfpsAtfn, true);
			if (oioBBHLVfKNoSBXnKIozStWuqCR.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to unregister mouse.", requiredThreadSafety: true);
			}
		}
	}

	private void pcktyxTbcnQcKLLCeQQUDdkTAbp(IntPtr P_0)
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			qqUCfXekfPVeGiSuFIspDxYSPsz();
			if (P_0 != IntPtr.Zero && P_0 != GXSoFvfITGBheVaKUcmXAVgDMlw.Handle)
			{
				QATuChSnHKVMVTyeMhUTMHlnIoq = P_0;
				SEvLYskSkZLlxnIXLwKwTALnHbn.YPdHfRHpmBsnhhIbvOaEigiqFCr(QATuChSnHKVMVTyeMhUTMHlnIoq, true);
			}
		}
	}

	private void UeTsfYEybTRRxHKgmKjnGiLWhlRH()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			qqUCfXekfPVeGiSuFIspDxYSPsz();
			SEvLYskSkZLlxnIXLwKwTALnHbn.YPdHfRHpmBsnhhIbvOaEigiqFCr(ItxsIaechePrdDFoHqnlkEyGEOD.value, true);
		}
	}

	private void qqUCfXekfPVeGiSuFIspDxYSPsz()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			NODbnQabezfdkHEorRcssumXzIR nODbnQabezfdkHEorRcssumXzIR = new NODbnQabezfdkHEorRcssumXzIR();
			nODbnQabezfdkHEorRcssumXzIR.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
			nODbnQabezfdkHEorRcssumXzIR.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(nODbnQabezfdkHEorRcssumXzIR.VGcPVbTzOYRItdsHMTwmZjvRNdw, true);
			if (nODbnQabezfdkHEorRcssumXzIR.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to register mouse.", requiredThreadSafety: true);
				OtXGRLAaxyKxYjnQrnIHwsxWHnp = false;
				gbfDpHBZrJfTocsWzQNuhALfiJmz.riSHQeDOIkBABkFvimBoHoVHLsiP(false);
				return;
			}
		}
		if (!OtXGRLAaxyKxYjnQrnIHwsxWHnp)
		{
			OtXGRLAaxyKxYjnQrnIHwsxWHnp = true;
			gbfDpHBZrJfTocsWzQNuhALfiJmz.riSHQeDOIkBABkFvimBoHoVHLsiP(true);
		}
	}

	public static bool pjtXujuwBtsRiMeRyEPuKQToZilB(staHFdAGuasEGlJuzBixSVxSxvc P_0, out uint P_1)
	{
		P_1 = 0u;
		if (P_0 == null)
		{
			return false;
		}
		uint maxDevices = (uint)P_0.maxDevices;
		P_1 = HuTamtUgOYxfCNLWEcbrfgTfOVKO.pjtXujuwBtsRiMeRyEPuKQToZilB(P_0, ref maxDevices, (uint)P_0.structSize);
		return P_1 != 0;
	}

	private unsafe bool trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType P_0, staHFdAGuasEGlJuzBixSVxSxvc P_1, uint P_2, out IntPtr P_3)
	{
		P_3 = IntPtr.Zero;
		if (P_1 == null)
		{
			return false;
		}
		for (int i = 0; i < P_2; i++)
		{
			IntPtr pointer = P_1.GetPointer(i * P_1.structSize);
			fTcpORmwuyMLoYmbRANrcLnwzRY* ptr = (fTcpORmwuyMLoYmbRANrcLnwzRY*)(void*)pointer;
			switch (P_0)
			{
			case ControllerType.Keyboard:
				if (ptr->YAzbvqReGlaZigycDwVUEsjDMOM == 1 && ptr->MkpgUCmmoxVNynCIXjswJwYMVbor == 6 && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != IntPtr.Zero && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != GXSoFvfITGBheVaKUcmXAVgDMlw.Handle)
				{
					P_3 = ptr->EXgBhVeNFPEepjhojMvAHTrFjELt;
					return true;
				}
				break;
			case ControllerType.Mouse:
				if (ptr->YAzbvqReGlaZigycDwVUEsjDMOM == 1 && ptr->MkpgUCmmoxVNynCIXjswJwYMVbor == 2 && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != IntPtr.Zero && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != GXSoFvfITGBheVaKUcmXAVgDMlw.Handle)
				{
					P_3 = ptr->EXgBhVeNFPEepjhojMvAHTrFjELt;
					return true;
				}
				break;
			}
		}
		return false;
	}

	private unsafe IntPtr usvAfOsjPMiIPhDuRMRcvUgXYNyu()
	{
		staHFdAGuasEGlJuzBixSVxSxvc staHFdAGuasEGlJuzBixSVxSxvc2 = null;
		try
		{
			staHFdAGuasEGlJuzBixSVxSxvc2 = new staHFdAGuasEGlJuzBixSVxSxvc(fTcpORmwuyMLoYmbRANrcLnwzRY.SizeInBytes, 100);
			uint maxDevices = (uint)staHFdAGuasEGlJuzBixSVxSxvc2.maxDevices;
			uint num = HuTamtUgOYxfCNLWEcbrfgTfOVKO.pjtXujuwBtsRiMeRyEPuKQToZilB(staHFdAGuasEGlJuzBixSVxSxvc2, ref maxDevices, (uint)staHFdAGuasEGlJuzBixSVxSxvc2.structSize);
			if (num == 0)
			{
				return IntPtr.Zero;
			}
			for (int i = 0; i < num; i++)
			{
				IntPtr pointer = staHFdAGuasEGlJuzBixSVxSxvc2.GetPointer(i * staHFdAGuasEGlJuzBixSVxSxvc2.structSize);
				fTcpORmwuyMLoYmbRANrcLnwzRY* ptr = (fTcpORmwuyMLoYmbRANrcLnwzRY*)(void*)pointer;
				Rewired.Logger.Log("RI DEVICE " + i);
				Rewired.Logger.Log("usage = " + ptr->MkpgUCmmoxVNynCIXjswJwYMVbor);
				Rewired.Logger.Log("usagePage = " + ptr->YAzbvqReGlaZigycDwVUEsjDMOM);
				Rewired.Logger.Log("flags = " + ptr->tUBXRZljfAUzITeLSNnlnxnnsCR);
				Rewired.Logger.Log("target = " + ptr->EXgBhVeNFPEepjhojMvAHTrFjELt);
				if (ptr->YAzbvqReGlaZigycDwVUEsjDMOM == 1 && ptr->MkpgUCmmoxVNynCIXjswJwYMVbor == 2 && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != IntPtr.Zero && ptr->EXgBhVeNFPEepjhojMvAHTrFjELt != GXSoFvfITGBheVaKUcmXAVgDMlw.Handle)
				{
					return ptr->EXgBhVeNFPEepjhojMvAHTrFjELt;
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
			staHFdAGuasEGlJuzBixSVxSxvc2?.Dispose();
		}
	}

	private void CzNrywTFdMkCCRHthdbwabnwXUdL(IntPtr P_0)
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			wvWIkVspNCxhznhoWtPlvoMCbMk();
			if (P_0 != IntPtr.Zero && P_0 != GXSoFvfITGBheVaKUcmXAVgDMlw.Handle)
			{
				YpNaCAUkMlSuzeXUlGbSNkEimyw = P_0;
			}
		}
	}

	private void lmLxAOlhDVXnkPqVnujgzlLxHkq()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			wvWIkVspNCxhznhoWtPlvoMCbMk();
		}
	}

	private void wvWIkVspNCxhznhoWtPlvoMCbMk()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			tiBYawGCgGxSYdKebGZdvUUAJeJ tiBYawGCgGxSYdKebGZdvUUAJeJ2 = new tiBYawGCgGxSYdKebGZdvUUAJeJ();
			tiBYawGCgGxSYdKebGZdvUUAJeJ2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
			tiBYawGCgGxSYdKebGZdvUUAJeJ2.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(tiBYawGCgGxSYdKebGZdvUUAJeJ2.jRWHyiJWClOlFaNtDhBxeRiwUCKQ, true);
			if (tiBYawGCgGxSYdKebGZdvUUAJeJ2.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to register keyboard.", requiredThreadSafety: true);
				ewBwxUhZzBlDIIwgecsqRjiLurn = false;
				DiHHKfzpefiqSfpheozUieJnZqLj.riSHQeDOIkBABkFvimBoHoVHLsiP(false);
				return;
			}
		}
		if (!ewBwxUhZzBlDIIwgecsqRjiLurn)
		{
			ewBwxUhZzBlDIIwgecsqRjiLurn = true;
			DiHHKfzpefiqSfpheozUieJnZqLj.riSHQeDOIkBABkFvimBoHoVHLsiP(true);
		}
	}

	private void lJFLmBlYeqEOolTOJaGSEYQEQTG()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			fHDNQAubcNsJMIJmpUiyWshuPro();
		}
		ewBwxUhZzBlDIIwgecsqRjiLurn = false;
		DiHHKfzpefiqSfpheozUieJnZqLj.riSHQeDOIkBABkFvimBoHoVHLsiP(false);
	}

	private void fHDNQAubcNsJMIJmpUiyWshuPro()
	{
		if (!ukIkfFWACDFFXBsntvhnwgCRpQh || ysJwuxouGXsgSrmKROPIaNUkOwR != vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			return;
		}
		IntPtr intPtr;
		if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
			if (trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Keyboard, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out var ypNaCAUkMlSuzeXUlGbSNkEimyw))
			{
				YpNaCAUkMlSuzeXUlGbSNkEimyw = ypNaCAUkMlSuzeXUlGbSNkEimyw;
			}
			intPtr = YpNaCAUkMlSuzeXUlGbSNkEimyw;
		}
		else
		{
			intPtr = HuTamtUgOYxfCNLWEcbrfgTfOVKO.HHgObSYCASlxDMDexFzCKlSubXT();
		}
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				RYsmQBBipzDHDxpfaoUEYTKBcDn.OIYGtVuwcffLNijdGVUiITEQPqs((nyUqWoTPfgeFKszzeqbfSzWedfw)1, (CUhcvapUsrWjXwNyOxmYzeTbHtG)6, lnLtgfjCbGTuEHySKYDjQQSMxeZ.dgcoubYlEaIdWhdWcJoJQvRbcfz, intPtr);
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
		else if (ewBwxUhZzBlDIIwgecsqRjiLurn)
		{
			fCMRlFtDkZDojWJhfCLeihHMMeM fCMRlFtDkZDojWJhfCLeihHMMeM2 = new fCMRlFtDkZDojWJhfCLeihHMMeM();
			fCMRlFtDkZDojWJhfCLeihHMMeM2.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
			xGtUxadjcEfvnGfgokjIgjtKfsd(fCMRlFtDkZDojWJhfCLeihHMMeM2.cRHqogxseOJYIxavvVSnkDSgeaO, true);
			if (fCMRlFtDkZDojWJhfCLeihHMMeM2.IiXkrZUDoDQJGBLvntiTVJhrQfe)
			{
				Rewired.Logger.LogError("Failed to unregister keyboard.", requiredThreadSafety: true);
			}
		}
	}

	private void UnPDohIEfRpyAPaIKWdPmCnGKMw()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR == vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			if (JtjQTORvuooIOWTuKIJSajqliWY)
			{
				MUiVVgZAXABwojCGxSsKpRonDVF();
			}
			GCwQgHUYxVqmCJbDbPdogtdEDTG();
			if (ukIkfFWACDFFXBsntvhnwgCRpQh)
			{
				lJFLmBlYeqEOolTOJaGSEYQEQTG();
			}
		}
		else if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			MUiVVgZAXABwojCGxSsKpRonDVF();
		}
	}

	private void kaoPIXWAutVDAzxcJeZHFLjYZjf()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.RawInput += FLiKtzVjTIPivjOMynhwOmTtwAt;
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.MouseInput += HlcjBOXBTWTfauvCCDPkLuoWWeY;
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.KeyboardInput += jyEDwZhlWVouzclgGfaWmWDcRBIC;
		}
		if (tzYHxRnlzOrnlnzshpfccGilhLX || JtjQTORvuooIOWTuKIJSajqliWY || ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.DeviceConnectedEvent += hevwaCPGhbNaPjbebBqVwPGwLpf;
			RYsmQBBipzDHDxpfaoUEYTKBcDn.DeviceDisconnectedEvent += iPZNWQbgmWeWCyOquUfPZtMWdaH;
		}
	}

	private void BZZTHWmYQgEOaeaAnlDpWCbYKPx()
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.RawInput -= FLiKtzVjTIPivjOMynhwOmTtwAt;
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.MouseInput -= HlcjBOXBTWTfauvCCDPkLuoWWeY;
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.KeyboardInput -= jyEDwZhlWVouzclgGfaWmWDcRBIC;
		}
		if (tzYHxRnlzOrnlnzshpfccGilhLX || JtjQTORvuooIOWTuKIJSajqliWY || ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			RYsmQBBipzDHDxpfaoUEYTKBcDn.DeviceConnectedEvent -= hevwaCPGhbNaPjbebBqVwPGwLpf;
			RYsmQBBipzDHDxpfaoUEYTKBcDn.DeviceDisconnectedEvent -= iPZNWQbgmWeWCyOquUfPZtMWdaH;
		}
	}

	private void jZarxNqRCkOrgvSxYccCpSKSdCi(edTUHywUTXJFvcLrQjKxoJZxDUQ.XpiEHHTMzPiIeoZcydWZQlFDxjx P_0)
	{
		conpUFOsToosceOsXkaLugPlyVj conpUFOsToosceOsXkaLugPlyVj2 = new conpUFOsToosceOsXkaLugPlyVj();
		conpUFOsToosceOsXkaLugPlyVj2.fILqFoEEpbqLdNzWUDXySFpmWMw = P_0;
		conpUFOsToosceOsXkaLugPlyVj2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
		conpUFOsToosceOsXkaLugPlyVj2.IiXkrZUDoDQJGBLvntiTVJhrQfe = false;
		xGtUxadjcEfvnGfgokjIgjtKfsd(conpUFOsToosceOsXkaLugPlyVj2.sgBERjXbQxlLYaKvjaoTdHagSusi, true);
		if (conpUFOsToosceOsXkaLugPlyVj2.IiXkrZUDoDQJGBLvntiTVJhrQfe)
		{
			throw new Exception("Error creating message window.");
		}
	}

	private static edTUHywUTXJFvcLrQjKxoJZxDUQ guEhgojmxcTfJTRnAANDnKlVhdQ(edTUHywUTXJFvcLrQjKxoJZxDUQ.XpiEHHTMzPiIeoZcydWZQlFDxjx P_0)
	{
		edTUHywUTXJFvcLrQjKxoJZxDUQ edTUHywUTXJFvcLrQjKxoJZxDUQ2 = new edTUHywUTXJFvcLrQjKxoJZxDUQ("RewiredMesssageWindow", createMessageOnlyWindow: true, P_0);
		if (edTUHywUTXJFvcLrQjKxoJZxDUQ2.Handle == IntPtr.Zero)
		{
			edTUHywUTXJFvcLrQjKxoJZxDUQ2.Dispose();
			return null;
		}
		return edTUHywUTXJFvcLrQjKxoJZxDUQ2;
	}

	private void JfAUOeaeKijFEqMPRjKTJBzbHK()
	{
		if (ysJwuxouGXsgSrmKROPIaNUkOwR != vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			return;
		}
		SEvLYskSkZLlxnIXLwKwTALnHbn.EhDmNHbdNOhARNgJSMpMFgeqbsn();
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			OXrFmvFKCbADOFSbIASBdSdKAlzj();
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY || ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			poyVeUdnFpEyfDMVRBIcmmarrXmR = new staHFdAGuasEGlJuzBixSVxSxvc(fTcpORmwuyMLoYmbRANrcLnwzRY.SizeInBytes, 100);
			if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
			{
				zxiIrZmNjIFWUSPGqSXpdXWuIdc = 1;
			}
			else
			{
				if (JtjQTORvuooIOWTuKIJSajqliWY)
				{
					UeTsfYEybTRRxHKgmKjnGiLWhlRH();
				}
				if (ukIkfFWACDFFXBsntvhnwgCRpQh)
				{
					lmLxAOlhDVXnkPqVnujgzlLxHkq();
				}
			}
		}
		AwHBHGASPjUXQAtzamgAseIyTkaw = SEvLYskSkZLlxnIXLwKwTALnHbn.bwkBXbgDzYeRKPDPKuWFzHhitau();
	}

	private void yCxmBYPNhvOTgdCFaMnnQaOyFDMf()
	{
		if (!DRXLJKNLPKWCwOywJSdSXWvcaxm || ysJwuxouGXsgSrmKROPIaNUkOwR != vhuTewWDBpLMDxvpkZHGGwmKHcf.ZTMaSEAAJKNatbQePyjdsJAPhglB)
		{
			return;
		}
		if (zxiIrZmNjIFWUSPGqSXpdXWuIdc > 0)
		{
			zxiIrZmNjIFWUSPGqSXpdXWuIdc--;
			return;
		}
		pjtXujuwBtsRiMeRyEPuKQToZilB(poyVeUdnFpEyfDMVRBIcmmarrXmR, out var num);
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Mouse, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out var intPtr);
			pcktyxTbcnQcKLLCeQQUDdkTAbp(intPtr);
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			trerAWiXdHNtpmIwvbzrwfnwlZA(ControllerType.Keyboard, poyVeUdnFpEyfDMVRBIcmmarrXmR, num, out var intPtr2);
			CzNrywTFdMkCCRHthdbwabnwXUdL(intPtr2);
		}
		zxiIrZmNjIFWUSPGqSXpdXWuIdc = -1;
	}

	private void BbDFRLeHglawFWHcZnxqtIVEuVBT(bool P_0)
	{
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			UeTsfYEybTRRxHKgmKjnGiLWhlRH();
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			wvWIkVspNCxhznhoWtPlvoMCbMk();
		}
	}

	private void ZmQDYstoDQBIqnOrzcFdiYTXiiu(FullScreenMode P_0)
	{
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			UxclSBpILAffdTEhfHQVoocjvSZ();
		}
	}

	private void GgIRoZnPzOJagJKVSxMTHONpSon(IntPtr P_0)
	{
		if (!DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			if (JtjQTORvuooIOWTuKIJSajqliWY)
			{
				UeTsfYEybTRRxHKgmKjnGiLWhlRH();
			}
			if (ukIkfFWACDFFXBsntvhnwgCRpQh)
			{
				lmLxAOlhDVXnkPqVnujgzlLxHkq();
			}
		}
	}

	private IntPtr NFaEHkhLdDAYcLQWfNoLlPOPqfeV(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return IntPtr.Zero;
		}
		if (AwHBHGASPjUXQAtzamgAseIyTkaw != null)
		{
			AwHBHGASPjUXQAtzamgAseIyTkaw(P_0, P_1, P_2, P_3);
		}
		return IntPtr.Zero;
	}

	private void xGtUxadjcEfvnGfgokjIgjtKfsd(Action P_0, bool P_1)
	{
		P_0?.Invoke();
	}

	private void FLiKtzVjTIPivjOMynhwOmTtwAt(mNGsIvlLyceofikppBqdVtQuAhso P_0, double P_1)
	{
		try
		{
			khVpXkrCgqXQBBdFCYKLvvpZkna(kbwNPkkZgMQwtrrUfDtgBehkdCIF.AjimIsdzzIUtPBAKcIsQfuovG, P_0.LjvfuhORJgLCiwGYyiHqyWuCfjx)?.HiykjTZubrIXwcnpzwlBuignkIM(P_0.RawDataPtr, P_0.RawDataBytes, P_0.OFUbnqgnTEObJNgzZhMUjQRqSuLP, P_0.vrUgZnbMlYERXMlYNGcJMwxzdSsC, P_1);
		}
		catch
		{
		}
	}

	private void yFkYfNMtCstZcpwWDGxmwjDwYbg(AqJBMFDBhYLkbilJdXuVEtyRmmVg P_0)
	{
		try
		{
			khVpXkrCgqXQBBdFCYKLvvpZkna(kbwNPkkZgMQwtrrUfDtgBehkdCIF.AjimIsdzzIUtPBAKcIsQfuovG, P_0.WCOCwqyfkjnBUIRfGRcBnsMqqvP)?.HiykjTZubrIXwcnpzwlBuignkIM(P_0.rawDataPtr, P_0.cJMGSrxhfWxDtqNEoUIndSaeZF, P_0.RWklmqWZUQouKnFAWGkBSxdcOkZ, P_0.MeRxsmYPADuUAcLjnryrUZJyAmu, P_0.ijHkQHjOcOYoYhIOMWrPdUZbPdN);
		}
		catch
		{
		}
	}

	private void HlcjBOXBTWTfauvCCDPkLuoWWeY(ALqxMtANAkffGHoGplkAhpgimjiL P_0, double P_1)
	{
		oiyRgwlJyLTdqhAgqlqkmovhjuY.VpAIKPbOJQWFpjXrnVZoafNPJEv(ref P_0);
		vuomVIFxwmThSXGvDhdweSszhGb(oiyRgwlJyLTdqhAgqlqkmovhjuY, P_1);
	}

	private void vuomVIFxwmThSXGvDhdweSszhGb(GAUEpREwZxMNaJbUVtjuRaurvUI P_0, double P_1)
	{
		try
		{
			gbfDpHBZrJfTocsWzQNuhALfiJmz.oFXcnfERNBuhmyELcTDiktBteqh(P_0);
		}
		catch (Exception)
		{
		}
	}

	private void jyEDwZhlWVouzclgGfaWmWDcRBIC(nOOuRnyAfliGdBJXhtOuQxTgiBPW P_0, double P_1)
	{
		neJBuHYCUGSMKAbUOjcxPAeVGsC.VpAIKPbOJQWFpjXrnVZoafNPJEv(ref P_0);
		eIlWxiqMihivClTDShKMOnrnVlC(neJBuHYCUGSMKAbUOjcxPAeVGsC, P_1);
	}

	private void eIlWxiqMihivClTDShKMOnrnVlC(joIDPhdLsQJpsETSRAVogyJSANzE P_0, double P_1)
	{
		try
		{
			DiHHKfzpefiqSfpheozUieJnZqLj.oFXcnfERNBuhmyELcTDiktBteqh(P_0);
		}
		catch
		{
		}
	}

	private void hevwaCPGhbNaPjbebBqVwPGwLpf(IntPtr P_0)
	{
		alCEEHebznjwuITtaGzLVOOHurR = true;
	}

	private void iPZNWQbgmWeWCyOquUfPZtMWdaH()
	{
		alCEEHebznjwuITtaGzLVOOHurR = true;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~TnbctswGyXOsohdhCkTtNqIlEbQG()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return;
		}
		BZZTHWmYQgEOaeaAnlDpWCbYKPx();
		ReInput.ApplicationIsFullScreenChangedEvent -= BbDFRLeHglawFWHcZnxqtIVEuVBT;
		ReInput.ApplicationFullScreenModeChangedEvent -= ZmQDYstoDQBIqnOrzcFdiYTXiiu;
		lock (yAilvIBDYuDWgEEBLUCtOVezLUR)
		{
			if (P_0 && WEuHIpAYAmfrlFuzqsSpOYLelMz != null)
			{
				for (int i = 0; i < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; i++)
				{
					if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null)
					{
						WEuHIpAYAmfrlFuzqsSpOYLelMz[i].JkxbMOPQiVSbeNRGETMYZahHimc();
						WEuHIpAYAmfrlFuzqsSpOYLelMz[i].Dispose();
					}
				}
			}
			UnPDohIEfRpyAPaIKWdPmCnGKMw();
			if (GXSoFvfITGBheVaKUcmXAVgDMlw != null)
			{
				GXSoFvfITGBheVaKUcmXAVgDMlw.Dispose();
				GXSoFvfITGBheVaKUcmXAVgDMlw = null;
			}
			if (JtjQTORvuooIOWTuKIJSajqliWY && gbfDpHBZrJfTocsWzQNuhALfiJmz != null)
			{
				gbfDpHBZrJfTocsWzQNuhALfiJmz.Dispose();
			}
			if (ukIkfFWACDFFXBsntvhnwgCRpQh && DiHHKfzpefiqSfpheozUieJnZqLj != null)
			{
				DiHHKfzpefiqSfpheozUieJnZqLj.Dispose();
			}
			SEvLYskSkZLlxnIXLwKwTALnHbn.LLOFbzNISIbRkZTwkaVnsPpYig();
		}
		if (poyVeUdnFpEyfDMVRBIcmmarrXmR != null)
		{
			poyVeUdnFpEyfDMVRBIcmmarrXmR.Dispose();
		}
		dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
	}

	public unsafe static bool eijXNrPqAlSwVXFbujqixZhYUi(TNuYvFcSdWFqveHgvUhHbRntguj P_0, out int P_1)
	{
		P_1 = 0;
		uint num = 0u;
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.HdDWzONQvcthSwCYPgLtEpUHQDZ(IntPtr.Zero, ref num, (uint)Marshal.SizeOf(typeof(LNHvDvYjaclMyuJxhDyrbuVyHQyf)));
		if (num == 0)
		{
			return false;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		LNHvDvYjaclMyuJxhDyrbuVyHQyf* ptr = stackalloc LNHvDvYjaclMyuJxhDyrbuVyHQyf[(int)num];
		HuTamtUgOYxfCNLWEcbrfgTfOVKO.HdDWzONQvcthSwCYPgLtEpUHQDZ((IntPtr)ptr, ref num, (uint)Marshal.SizeOf(typeof(LNHvDvYjaclMyuJxhDyrbuVyHQyf)));
		for (int i = 0; i < num; i++)
		{
			IntPtr ljvfuhORJgLCiwGYyiHqyWuCfjx = ptr[i].LjvfuhORJgLCiwGYyiHqyWuCfjx;
			int num5 = 0;
			int num6 = mAgjioNWilhSVagqLOEzscTnDyYo.brIreOMwrgdtONdGsTbBcOjqghRD(ljvfuhORJgLCiwGYyiHqyWuCfjx, baSGeTkrHxGjHeWTiJXsSekEbWXI.NRpsjwlEmgsxolYniVWUMfZdRKG, IntPtr.Zero, ref num5);
			if (num5 == 0)
			{
				num4++;
				continue;
			}
			num3++;
			byte* ptr2 = stackalloc byte[(int)(uint)num5];
			*(int*)ptr2 = num5;
			num6 = mAgjioNWilhSVagqLOEzscTnDyYo.brIreOMwrgdtONdGsTbBcOjqghRD(ljvfuhORJgLCiwGYyiHqyWuCfjx, baSGeTkrHxGjHeWTiJXsSekEbWXI.NRpsjwlEmgsxolYniVWUMfZdRKG, (IntPtr)ptr2, ref num5);
			if (num6 >= 0)
			{
				jrcDlgXvKdneOKRryQPpUJwoVWg jrcDlgXvKdneOKRryQPpUJwoVWg2 = *(jrcDlgXvKdneOKRryQPpUJwoVWg*)ptr2;
				if (jrcDlgXvKdneOKRryQPpUJwoVWg2.HSgsKXENkcvZsdtDvNAJblnfTHZ == P_0)
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
	private static void ZCBmpMxFahppZKXKJvqKhiCfSeo(UzKBIaEyudSpXeLmfwTkGCYvktG P_0)
	{
		P_0.Dispose();
	}
}
