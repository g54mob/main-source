using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IDriver_RailDriver, IControllerDriver, IHIDControllerExtension
	{
		private enum aiekIsMwzypNdJeImCzEonbPhIbj
		{
			Speaker = 0,
			LED = 1
		}

		private const int BhjFivmQjSCPIaTwqyDOXzThEBZf = 1523;

		private const int hmrygtKKMYFswKlyXrmvQeQsvgWL = 210;

		private const int ptIpnbTqTHqvpHehTCUbhrZyKyCZA = 50;

		private const int PAYbdvuhQwMBxpeuaCOoilagNPWP = 44;

		private const int EzvajCCXCytjIaTxIASFLGSvNCPbA = 6;

		private const int fvyndsqjGcDYcATyRmVnqgvhKzsC = 44;

		private const int XXByxJtKckpRUqjQWwRFBhoKrvkc = 45;

		private const int coKCjRaHbaFcNniRoblSjfbkPyEHc = 46;

		private const int oXYCCScycJofmqLYrnkIVVGSvSFSA = 47;

		private const int uISgtsjYLNCeGpVSkFWcEmigZvdjB = 48;

		private const int kehWuqaDbasKfklAdOeoAfAKidnh = 49;

		private const int zZjlaPEDDiuPHKefMqIhwepKmkAu = 0;

		private const int yvHzRrFRtBxkVLeQNHPewEjECXVG = 15;

		private const int JPKDQJeToqifCJDtqxaOBVGtUCuvA = 9;

		private const int jhNrNEZrxsNeITxhFXOOkaakvwKf = 1;

		private const int DOkQyNlMbRyaPXJuWGvzFrZoaDOe = 2;

		private const int tDlueihKDvHdszlpgQONzwIvTPgP = 3;

		private const int LXuzpreplQAwagxCggpROaGDTToG = 4;

		private const int tqfPfsYjItJiWvgomdykVorxhpLg = 5;

		private const int IjKGwuFSMhrBcSDjuQINYtWgPDDt = 6;

		private const int RbNGffHaCJVzPRKVbtrCtAUamhzQ = 7;

		private const int FjnlqZJSPlkKNQKGqjqFSDCEAZLA = 8;

		private const int NNtegHTFvtFWZyKMRhNdIagGCmXvA = 14;

		private const int LBuHsEEAUrzjEWldYXrHIiVrekfY = 3;

		private const int TbVYpyHMUQfgZDmadjGAYHbfgpSR = 7;

		private readonly NativeBuffer ngLpmXqpWMkrzJhItIiOeJqMkWER;

		private readonly NativeBuffer BDAjYqGGryrdhuKxROwoeeVuFFDrA;

		private bool xnmcWKcXTkdOvhqqeAsPAxnFXWcqB;

		private byte[] fUkvPOhHIRFwPadEddQvDRkJNahMc = new byte[3];

		private readonly IHIDDevice wYffwdiGFhldXEgESFxowbFMPjoIA;

		private readonly HIDProperties YBdAlxFrAcIhLsRUPNzDevxPrTcOA;

		private readonly fSMyuzvVmAACQsIYyLcgNLStbZVN ByFVofcnBBdqkIRGStbSZTWyBFeB;

		bool IDriver_RailDriver.SpeakerEnabled
		{
			get
			{
				return xnmcWKcXTkdOvhqqeAsPAxnFXWcqB;
			}
			set
			{
				xnmcWKcXTkdOvhqqeAsPAxnFXWcqB = value;
				ftiIYjOlnzMHwZprAXmbIGNgjemr(aiekIsMwzypNdJeImCzEonbPhIbj.Speaker, UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
			}
		}

		ushort IHIDControllerExtension.vendorId => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.vendorId;

		ushort IHIDControllerExtension.productId => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.productId;

		string IHIDControllerExtension.productName => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.productName;

		string IHIDControllerExtension.manufacturer => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.manufacturer;

		ushort IHIDControllerExtension.usagePage => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.usagePage;

		ushort IHIDControllerExtension.usage => YBdAlxFrAcIhLsRUPNzDevxPrTcOA.usage;

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0 && digitIndex < 3)
			{
				fUkvPOhHIRFwPadEddQvDRkJNahMc[digitIndex] = digitBitValues;
				ftiIYjOlnzMHwZprAXmbIGNgjemr(aiekIsMwzypNdJeImCzEonbPhIbj.LED, UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
			}
		}

		void IDriver_RailDriver.SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLEDDisplay
			this.SetLEDDisplay(digitIndex, digitBitValues);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			fUkvPOhHIRFwPadEddQvDRkJNahMc[0] = digit1BitValues;
			fUkvPOhHIRFwPadEddQvDRkJNahMc[1] = digit2BitValues;
			fUkvPOhHIRFwPadEddQvDRkJNahMc[2] = digit3BitValues;
			ftiIYjOlnzMHwZprAXmbIGNgjemr(aiekIsMwzypNdJeImCzEonbPhIbj.LED, UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous);
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
			wYffwdiGFhldXEgESFxowbFMPjoIA = P_0.hidDevice;
			YBdAlxFrAcIhLsRUPNzDevxPrTcOA = wYffwdiGFhldXEgESFxowbFMPjoIA.properties;
			ngLpmXqpWMkrzJhItIiOeJqMkWER = new NativeBuffer(15);
			BDAjYqGGryrdhuKxROwoeeVuFFDrA = new NativeBuffer(9);
			ByFVofcnBBdqkIRGStbSZTWyBFeB = new fSMyuzvVmAACQsIYyLcgNLStbZVN(BDAjYqGGryrdhuKxROwoeeVuFFDrA.Pointer, BDAjYqGGryrdhuKxROwoeeVuFFDrA.Length, 9);
			buttons = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new WLKCiIfkjEHrYQVDYJcKGKPTVxLS(0, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new dnWPfQfDfnEmaJKgzGFSEYqFnsqm[4]
			{
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(0, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(0, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(0, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
				new dnWPfQfDfnEmaJKgzGFSEYqFnsqm(0, new QAOlVgyStIKpRmoWAGbpIzIYHZwjA.HIDInfo
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
			if (inputReportLength < ngLpmXqpWMkrzJhItIiOeJqMkWER.Length)
			{
				return false;
			}
			ngLpmXqpWMkrzJhItIiOeJqMkWER.Write(inputReportPtr, inputReportLength, ngLpmXqpWMkrzJhItIiOeJqMkWER.Length);
			cNEXzhgbTrnEMGXbTSICXvJCjpzN(ngLpmXqpWMkrzJhItIiOeJqMkWER, timestamp);
			QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] array = axes;
			peErNjWvXXrIlnMhBusEWoHeAwOe(array, ngLpmXqpWMkrzJhItIiOeJqMkWER, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool ftiIYjOlnzMHwZprAXmbIGNgjemr(aiekIsMwzypNdJeImCzEonbPhIbj P_0, UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_1)
		{
			PwxWCDoUpffTreOhPQKIutPlYSuE(P_0);
			return WStGQnthhneTVKUDhrlvDfamIkBjb(P_1);
		}

		private void PwxWCDoUpffTreOhPQKIutPlYSuE(aiekIsMwzypNdJeImCzEonbPhIbj P_0)
		{
			switch (P_0)
			{
			case aiekIsMwzypNdJeImCzEonbPhIbj.Speaker:
				BDAjYqGGryrdhuKxROwoeeVuFFDrA.Clear();
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[1] = 133;
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[7] = (byte)(xnmcWKcXTkdOvhqqeAsPAxnFXWcqB ? 1 : 0);
				break;
			case aiekIsMwzypNdJeImCzEonbPhIbj.LED:
				BDAjYqGGryrdhuKxROwoeeVuFFDrA.Clear();
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[1] = 134;
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[2] = fUkvPOhHIRFwPadEddQvDRkJNahMc[0];
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[3] = fUkvPOhHIRFwPadEddQvDRkJNahMc[1];
				BDAjYqGGryrdhuKxROwoeeVuFFDrA[4] = fUkvPOhHIRFwPadEddQvDRkJNahMc[2];
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private bool WStGQnthhneTVKUDhrlvDfamIkBjb(UMnHtFvBMVBpdLBIzKmDsNjPHJOQ P_0)
		{
			switch (P_0)
			{
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Synchronous:
				return wYffwdiGFhldXEgESFxowbFMPjoIA.WriteSync(ByFVofcnBBdqkIRGStbSZTWyBFeB, 0);
			case UMnHtFvBMVBpdLBIzKmDsNjPHJOQ.Asynchronous:
				wYffwdiGFhldXEgESFxowbFMPjoIA.WriteAsync(ByFVofcnBBdqkIRGStbSZTWyBFeB, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void cNEXzhgbTrnEMGXbTSICXvJCjpzN(NativeBuffer P_0, double P_1)
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
					buttons[num2].MGdQDuXuJchSCgHSZmfwaNPbKwTP((b & (1 << j)) != 0, P_1);
				}
			}
			byte b2 = P_0[6];
			buttons[44].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 < 95, P_1);
			buttons[45].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 >= 95 && b2 < 161, P_1);
			buttons[46].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 >= 161, P_1);
			b2 = P_0[7];
			buttons[47].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 < 95, P_1);
			buttons[48].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 >= 95 && b2 < 161, P_1);
			buttons[49].MGdQDuXuJchSCgHSZmfwaNPbKwTP(b2 >= 161, P_1);
		}

		private void peErNjWvXXrIlnMhBusEWoHeAwOe(QAOlVgyStIKpRmoWAGbpIzIYHZwjA[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].zlNHwfexPeybhRZVfQjgkewMqYcH(P_1, P_2);
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
				if (ngLpmXqpWMkrzJhItIiOeJqMkWER != null)
				{
					ngLpmXqpWMkrzJhItIiOeJqMkWER.Dispose();
				}
				if (BDAjYqGGryrdhuKxROwoeeVuFFDrA != null)
				{
					BDAjYqGGryrdhuKxROwoeeVuFFDrA.Dispose();
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
