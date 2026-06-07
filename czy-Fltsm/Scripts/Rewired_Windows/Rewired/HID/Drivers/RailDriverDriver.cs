using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum kaRwZkSJmkEZTpVFWmhYliPKrlJj
		{
			Speaker = 0,
			LED = 1
		}

		private const int NAOdyvuNyKDschEYWRYEPGDsdKlSA = 1523;

		private const int jrIeDrAeXMIjWyUldqNbTJaxXbgV = 210;

		private const int hMxOxWHWhLLLxnifrgnschijajgE = 50;

		private const int HdvDCvmcDuDiFdRnAQasbrKahLsWb = 44;

		private const int UHIWEEHTPsXUyhhsgqBHJcmafArO = 6;

		private const int rKRIQokRDoLhUmRzzGAxfeScLKMu = 44;

		private const int RBgTNlfuRcuNbWmgixCHWOZVDxJx = 45;

		private const int gMbWfTPsceAvlAfIUBpSwAHWkbci = 46;

		private const int gkpjDAyExLXxMrbBPGwSMesBgKrT = 47;

		private const int kSnYuaSRSPMtodiFAqfuvYQAnOFK = 48;

		private const int gUWmpwwEAwpGeCVwBSkwFmTTRgZo = 49;

		private const int xACTFQFAeznvwmkqfkdDbLHRsoSA = 0;

		private const int cnqfWzRLoTcHnKbLxpheulVPoQxuA = 15;

		private const int PLlvXFyjweBdytcFMUjMGFuqUyIi = 9;

		private const int vUsZIAFxycPfejYelivSvPYlFdkbA = 1;

		private const int VQFkrHxnFRQKxzHQgFifkGXtykkfA = 2;

		private const int daGVdenGrrXHYXgaUkXXkaFqVIId = 3;

		private const int ZOXEYtsGwUvkWEQJMiOZTrmAWJOQ = 4;

		private const int jqAjmmSDZlcteHZtUUNgCALyGbbCA = 5;

		private const int ATpPScDNbjfrWkyxAgmTBkAfLEfG = 6;

		private const int VImGujPFGPNNlvEKRDaGasXtlXvc = 7;

		private const int NlGlCcTwRZSMyuGPkzLkFWrHdExs = 8;

		private const int FlWVfZNgybcCrOwHxvYtvgYPgcli = 14;

		private const int LcFXNMEHdxPgwsdisxVRTLjsehJJ = 3;

		private const int HHaazsVeNQxTxdjjTmBEFWDuBpwW = 7;

		private readonly NativeBuffer noLKVqeNYVARbaNPBCYtoGXzGiW;

		private readonly NativeBuffer XZvdIeKRwkXdRoSizQkobErtRGvK;

		private bool vtDlCMuoOsinHKKjEGlHshZMGgOf;

		private byte[] nsHCeQjoXTEKxZFFRDovCASEpqNx = new byte[3];

		private readonly IHIDDevice whAPcpKIYhfXvGdBcBRuGinForAeA;

		private readonly HIDProperties GZIAGndqXmqBbvATvuBFotVKKNQn;

		private readonly dQrAZjxmvMRuuUvHYPSsKegoCJrCA NJNlssuoqBKJKmFKwaZdgMvdkVlGA;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return vtDlCMuoOsinHKKjEGlHshZMGgOf;
			}
			set
			{
				vtDlCMuoOsinHKKjEGlHshZMGgOf = value;
				fJTGhfBYoviwGNpscjfldRlglwMhb(kaRwZkSJmkEZTpVFWmhYliPKrlJj.Speaker, IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => GZIAGndqXmqBbvATvuBFotVKKNQn.vendorId;

		ushort IHIDControllerExtension.productId => GZIAGndqXmqBbvATvuBFotVKKNQn.productId;

		string IHIDControllerExtension.productName => GZIAGndqXmqBbvATvuBFotVKKNQn.productName;

		string IHIDControllerExtension.manufacturer => GZIAGndqXmqBbvATvuBFotVKKNQn.manufacturer;

		ushort IHIDControllerExtension.usagePage => GZIAGndqXmqBbvATvuBFotVKKNQn.usagePage;

		ushort IHIDControllerExtension.usage => GZIAGndqXmqBbvATvuBFotVKKNQn.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				nsHCeQjoXTEKxZFFRDovCASEpqNx[digitIndex] = digitBitValues;
				fJTGhfBYoviwGNpscjfldRlglwMhb(kaRwZkSJmkEZTpVFWmhYliPKrlJj.LED, IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			nsHCeQjoXTEKxZFFRDovCASEpqNx[0] = digit1BitValues;
			nsHCeQjoXTEKxZFFRDovCASEpqNx[1] = digit2BitValues;
			nsHCeQjoXTEKxZFFRDovCASEpqNx[2] = digit3BitValues;
			fJTGhfBYoviwGNpscjfldRlglwMhb(kaRwZkSJmkEZTpVFWmhYliPKrlJj.LED, IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
		}

		void IDriver_RailDriver.SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}

		public RailDriverDriver(InitArgs P_0)
			: base(P_0)
		{
			whAPcpKIYhfXvGdBcBRuGinForAeA = P_0.hidDevice;
			GZIAGndqXmqBbvATvuBFotVKKNQn = whAPcpKIYhfXvGdBcBRuGinForAeA.properties;
			noLKVqeNYVARbaNPBCYtoGXzGiW = new NativeBuffer(15);
			XZvdIeKRwkXdRoSizQkobErtRGvK = new NativeBuffer(9);
			NJNlssuoqBKJKmFKwaZdgMvdkVlGA = new dQrAZjxmvMRuuUvHYPSsKegoCJrCA(XZvdIeKRwkXdRoSizQkobErtRGvK.Pointer, XZvdIeKRwkXdRoSizQkobErtRGvK.Length, 9);
			buttons = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA(0, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new bpjwwWbNobTCGrXbZKxCDfQGumWO[4]
			{
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(0, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(0, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(0, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(0, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 4,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127)
			};
		}

		protected override void OnInitialize()
		{
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < noLKVqeNYVARbaNPBCYtoGXzGiW.Length)
			{
				return false;
			}
			noLKVqeNYVARbaNPBCYtoGXzGiW.Write(inputReportPtr, inputReportLength, noLKVqeNYVARbaNPBCYtoGXzGiW.Length);
			wvnaUreOMnsgcykgzivMGzfNtMNG(noLKVqeNYVARbaNPBCYtoGXzGiW, timestamp);
			OYzieseEeYXDrIqXsZAdwVmBBsCg[] array = axes;
			dGvHYjWZyTsZFVsJtMSWXzYlMSqX(array, noLKVqeNYVARbaNPBCYtoGXzGiW, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool fJTGhfBYoviwGNpscjfldRlglwMhb(kaRwZkSJmkEZTpVFWmhYliPKrlJj P_0, IpOusHhkFVHLPKjRNBUJTzZIWToMA P_1)
		{
			ZnEsnUojZldHrKXDxhaEdFPyuCCr(P_0);
			return IQSbrhvewxpfneDCXLMhwkQfmAxL(P_1);
		}

		private void ZnEsnUojZldHrKXDxhaEdFPyuCCr(kaRwZkSJmkEZTpVFWmhYliPKrlJj P_0)
		{
			switch (P_0)
			{
			case kaRwZkSJmkEZTpVFWmhYliPKrlJj.Speaker:
				XZvdIeKRwkXdRoSizQkobErtRGvK.Clear();
				XZvdIeKRwkXdRoSizQkobErtRGvK[1] = 133;
				XZvdIeKRwkXdRoSizQkobErtRGvK[7] = (vtDlCMuoOsinHKKjEGlHshZMGgOf ? ((byte)1) : ((byte)0));
				break;
			case kaRwZkSJmkEZTpVFWmhYliPKrlJj.LED:
				XZvdIeKRwkXdRoSizQkobErtRGvK.Clear();
				XZvdIeKRwkXdRoSizQkobErtRGvK[1] = 134;
				XZvdIeKRwkXdRoSizQkobErtRGvK[2] = nsHCeQjoXTEKxZFFRDovCASEpqNx[0];
				XZvdIeKRwkXdRoSizQkobErtRGvK[3] = nsHCeQjoXTEKxZFFRDovCASEpqNx[1];
				XZvdIeKRwkXdRoSizQkobErtRGvK[4] = nsHCeQjoXTEKxZFFRDovCASEpqNx[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool IQSbrhvewxpfneDCXLMhwkQfmAxL(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			switch (P_0)
			{
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous:
				return whAPcpKIYhfXvGdBcBRuGinForAeA.WriteSync(NJNlssuoqBKJKmFKwaZdgMvdkVlGA, 0);
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous:
				whAPcpKIYhfXvGdBcBRuGinForAeA.WriteAsync(NJNlssuoqBKJKmFKwaZdgMvdkVlGA, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void wvnaUreOMnsgcykgzivMGzfNtMNG(NativeBuffer P_0, double P_1)
		{
			for (int i = 0; i < 6; i++)
			{
				byte b = P_0[8 + i];
				int num = i * 8;
				for (int j = 0; j < 8; j++)
				{
					int num2 = num + j;
					if (num2 >= 44)
					{
						break;
					}
					buttons[num2].AtQsHqTAryodwUVQnJukddZkgqvd((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].AtQsHqTAryodwUVQnJukddZkgqvd(b2 < 95, P_1);
			buttons[45].AtQsHqTAryodwUVQnJukddZkgqvd(b2 >= 95 && b2 < 161, P_1);
			buttons[46].AtQsHqTAryodwUVQnJukddZkgqvd(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].AtQsHqTAryodwUVQnJukddZkgqvd(b2 < 95, P_1);
			buttons[48].AtQsHqTAryodwUVQnJukddZkgqvd(b2 >= 95 && b2 < 161, P_1);
			buttons[49].AtQsHqTAryodwUVQnJukddZkgqvd(b2 >= 161, P_1);
		}

		private void dGvHYjWZyTsZFVsJtMSWXzYlMSqX(OYzieseEeYXDrIqXsZAdwVmBBsCg[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].bNihcfetwkjYPbAQTEqgnRQFuUSJ(P_1, P_2);
			}
		}

		~RailDriverDriver()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			base.Dispose(disposing);
			if (disposing)
			{
				if (noLKVqeNYVARbaNPBCYtoGXzGiW != null)
				{
					noLKVqeNYVARbaNPBCYtoGXzGiW.Dispose();
				}
				if (XZvdIeKRwkXdRoSizQkobErtRGvK != null)
				{
					XZvdIeKRwkXdRoSizQkobErtRGvK.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (1523 == vid)
			{
				return 210 == pid;
			}
			return false;
		}
	}
}
