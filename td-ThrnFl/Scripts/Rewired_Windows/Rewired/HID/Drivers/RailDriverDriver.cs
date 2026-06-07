using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum kEEfcmfHbfsDzpvMJBxGHPDceTah
		{
			Speaker = 0,
			LED = 1
		}

		private const int JeXItPRhONDYkQBXWtUAgHBKVMqB = 1523;

		private const int fFRbozpzUTUpceccyiAndtsHyRBj = 210;

		private const int vCijidgyVWUyffxfkNHvlKxHprXAb = 50;

		private const int VoeipxTbMjbZtJrwVOToLwODACRr = 44;

		private const int OTRliEoiEfRcQxPzrPJXxewYUXMP = 6;

		private const int tUAdeuRWYrAQmwBoqZpzRMGYHLbx = 44;

		private const int BojdyrMQGngfNSBrzcrBqXPzlssO = 45;

		private const int uEoLsXminvnuJCeZBFoCStRqgdFR = 46;

		private const int sVsqDOLJiUMietoMIgrSgjgxcLKx = 47;

		private const int onuRwsjCTSVpOnsKFaDoHOAeQukp = 48;

		private const int chTPZcDeZpbZOCbuCHDgvJLlnMig = 49;

		private const int xvTAbJpVVxyCDudbjqZlBoHlotBs = 0;

		private const int wSbyHtgpqCaGHhKhsQDmZZVjBIMG = 15;

		private const int NFoMLFDOwjBoQvgvRmlQsgcEcRzgA = 9;

		private const int zzFiEyQnpoSEpLhomISBlMHckJZ = 1;

		private const int XYMBFRWUMIdbJhYFdDPhyhNVibXkA = 2;

		private const int jxNDbcCKTaximDrrBdXBcWqYCWfab = 3;

		private const int HVUwHfBbmPBjaMhYFdDBnfeoSifj = 4;

		private const int jZHdEszIGgRKWTpiZGaqgtBCOuGr = 5;

		private const int EnkSvokLEoXMgmDnRQXJfZaJUTQL = 6;

		private const int VxnSczoQAAsqTnfXMfoIFIeDNsaCA = 7;

		private const int DvJkGewSGClrKyaUhfoatDbhVTEM = 8;

		private const int JDPvzTiJbyNZFCHKwUQfTmIhIzKu = 14;

		private const int HPUTrEvhAeFgAEinxsGFRbjMttiTA = 3;

		private const int VnWVwoyULkeXtVcWioEdRPEigJu = 7;

		private readonly NativeBuffer burBjHgBCNLelAhKFOjWRJGazFDeB;

		private readonly NativeBuffer JSapJurOfrAqvHapaNfeNZvLaMANA;

		private bool vMWLBOLtBhAFxEDuPdnVgKZqlNzSA;

		private byte[] bCILQGOfMEztRNfSWtLduHEsvfsT = new byte[3];

		private readonly IHIDDevice gZJohjjJJuckTACYpPyaGIpApmbeB;

		private readonly HIDProperties ISDGktIwKprkBzmAsDcFEOZeLAznA;

		private readonly dccInhMggZtLYGkWFjXacEyGQoUL HRMWfoZVzKwxyukNbmItqcnPHSGR;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return vMWLBOLtBhAFxEDuPdnVgKZqlNzSA;
			}
			set
			{
				vMWLBOLtBhAFxEDuPdnVgKZqlNzSA = value;
				tSAFbqjpksJqEfxinKxprnTVblLB(kEEfcmfHbfsDzpvMJBxGHPDceTah.Speaker, ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => ISDGktIwKprkBzmAsDcFEOZeLAznA.vendorId;

		ushort IHIDControllerExtension.productId => ISDGktIwKprkBzmAsDcFEOZeLAznA.productId;

		string IHIDControllerExtension.productName => ISDGktIwKprkBzmAsDcFEOZeLAznA.productName;

		string IHIDControllerExtension.manufacturer => ISDGktIwKprkBzmAsDcFEOZeLAznA.manufacturer;

		ushort IHIDControllerExtension.usagePage => ISDGktIwKprkBzmAsDcFEOZeLAznA.usagePage;

		ushort IHIDControllerExtension.usage => ISDGktIwKprkBzmAsDcFEOZeLAznA.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				bCILQGOfMEztRNfSWtLduHEsvfsT[digitIndex] = digitBitValues;
				tSAFbqjpksJqEfxinKxprnTVblLB(kEEfcmfHbfsDzpvMJBxGHPDceTah.LED, ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			bCILQGOfMEztRNfSWtLduHEsvfsT[0] = digit1BitValues;
			bCILQGOfMEztRNfSWtLduHEsvfsT[1] = digit2BitValues;
			bCILQGOfMEztRNfSWtLduHEsvfsT[2] = digit3BitValues;
			tSAFbqjpksJqEfxinKxprnTVblLB(kEEfcmfHbfsDzpvMJBxGHPDceTah.LED, ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous);
		}

		void IDriver_RailDriver.SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
		}

		public RailDriverDriver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			gZJohjjJJuckTACYpPyaGIpApmbeB = P_0.hidDevice;
			ISDGktIwKprkBzmAsDcFEOZeLAznA = gZJohjjJJuckTACYpPyaGIpApmbeB.properties;
			burBjHgBCNLelAhKFOjWRJGazFDeB = new NativeBuffer(15);
			JSapJurOfrAqvHapaNfeNZvLaMANA = new NativeBuffer(9);
			HRMWfoZVzKwxyukNbmItqcnPHSGR = new dccInhMggZtLYGkWFjXacEyGQoUL(JSapJurOfrAqvHapaNfeNZvLaMANA.Pointer, JSapJurOfrAqvHapaNfeNZvLaMANA.Length, 9);
			buttons = new YgmprUEDpDakYucBfpnWbXzouOGJ[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new YgmprUEDpDakYucBfpnWbXzouOGJ(0, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new nZeIQQWnQohhanyhWEOObGRunlRc[4]
			{
				new nZeIQQWnQohhanyhWEOObGRunlRc(0, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(0, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(0, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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
				new nZeIQQWnQohhanyhWEOObGRunlRc(0, new QTwvMqRjxXBwLOoUpuezGnwheUbM.HIDInfo
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

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < burBjHgBCNLelAhKFOjWRJGazFDeB.Length)
			{
				return false;
			}
			burBjHgBCNLelAhKFOjWRJGazFDeB.Write(inputReportPtr, inputReportLength, burBjHgBCNLelAhKFOjWRJGazFDeB.Length);
			ahgjqnFwBiGRUeSxqqRUqblxeyoy(burBjHgBCNLelAhKFOjWRJGazFDeB, timestamp);
			QTwvMqRjxXBwLOoUpuezGnwheUbM[] array = axes;
			xnastzfWpWwmnLiCcHfEtGIHfBZHA(array, burBjHgBCNLelAhKFOjWRJGazFDeB, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool tSAFbqjpksJqEfxinKxprnTVblLB(kEEfcmfHbfsDzpvMJBxGHPDceTah P_0, ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_1)
		{
			HxNBuUPQGkmZXGaMmLTODbHQNzpg(P_0);
			return EeNaRnhYbkyUBwNLESmzIaAJNzYv(P_1);
		}

		private void HxNBuUPQGkmZXGaMmLTODbHQNzpg(kEEfcmfHbfsDzpvMJBxGHPDceTah P_0)
		{
			switch (P_0)
			{
			case kEEfcmfHbfsDzpvMJBxGHPDceTah.Speaker:
				JSapJurOfrAqvHapaNfeNZvLaMANA.Clear();
				JSapJurOfrAqvHapaNfeNZvLaMANA[1] = 133;
				JSapJurOfrAqvHapaNfeNZvLaMANA[7] = (byte)(vMWLBOLtBhAFxEDuPdnVgKZqlNzSA ? 1 : 0);
				break;
			case kEEfcmfHbfsDzpvMJBxGHPDceTah.LED:
				JSapJurOfrAqvHapaNfeNZvLaMANA.Clear();
				JSapJurOfrAqvHapaNfeNZvLaMANA[1] = 134;
				JSapJurOfrAqvHapaNfeNZvLaMANA[2] = bCILQGOfMEztRNfSWtLduHEsvfsT[0];
				JSapJurOfrAqvHapaNfeNZvLaMANA[3] = bCILQGOfMEztRNfSWtLduHEsvfsT[1];
				JSapJurOfrAqvHapaNfeNZvLaMANA[4] = bCILQGOfMEztRNfSWtLduHEsvfsT[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool EeNaRnhYbkyUBwNLESmzIaAJNzYv(ScLWlPMAqEiHtjIIWbjHNAZkYXXI P_0)
		{
			switch (P_0)
			{
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Synchronous:
				return gZJohjjJJuckTACYpPyaGIpApmbeB.WriteSync(HRMWfoZVzKwxyukNbmItqcnPHSGR, 0);
			case ScLWlPMAqEiHtjIIWbjHNAZkYXXI.Asynchronous:
				gZJohjjJJuckTACYpPyaGIpApmbeB.WriteAsync(HRMWfoZVzKwxyukNbmItqcnPHSGR, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void ahgjqnFwBiGRUeSxqqRUqblxeyoy(NativeBuffer P_0, double P_1)
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
					buttons[num2].YMBfCqamFtXXCaOMewymSLhGnbUnA((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 < 95, P_1);
			buttons[45].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 >= 95 && b2 < 161, P_1);
			buttons[46].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 < 95, P_1);
			buttons[48].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 >= 95 && b2 < 161, P_1);
			buttons[49].YMBfCqamFtXXCaOMewymSLhGnbUnA(b2 >= 161, P_1);
		}

		private void xnastzfWpWwmnLiCcHfEtGIHfBZHA(QTwvMqRjxXBwLOoUpuezGnwheUbM[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].nbdaOhPzrnnznbxNEnDgLWCrHhfx(P_1, P_2);
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
				if (burBjHgBCNLelAhKFOjWRJGazFDeB != null)
				{
					burBjHgBCNLelAhKFOjWRJGazFDeB.Dispose();
				}
				if (JSapJurOfrAqvHapaNfeNZvLaMANA != null)
				{
					JSapJurOfrAqvHapaNfeNZvLaMANA.Dispose();
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
