using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		protected enum yLpbwZJUFNkRouxglOYNdRyBNHOG
		{
			ProController = 0,
			JoyConLeft = 1,
			JoyConRight = 2
		}

		protected class YeaAQADPQMsdYWaxpIFbZaIqSbdMA
		{
			private OuyedDeYgCfMJhRepxbdANVcvqtM faWgWvePOmqwrucTSbDvjuZqSOGo;

			private QcCssoCbfSGRfkQchmIULAFUgwPs YhhqovPaHZTfTYoAqYglzLXQCJUZ;

			private float UoAtTDPEFvOvrPpgFalUsBrxlszU;

			private double QdZDDBbdvlGNzatsCBgzJlGAPOihD;

			public QcCssoCbfSGRfkQchmIULAFUgwPs fHigMnZyzxTMioMyWPRjQzSFCFYP => default(QcCssoCbfSGRfkQchmIULAFUgwPs);

			public YeaAQADPQMsdYWaxpIFbZaIqSbdMA(OuyedDeYgCfMJhRepxbdANVcvqtM P_0)
			{
			}

			public void NKnhsYMiEGzBquCGpnHTGfGMiLUBA(float P_0, float P_1, float P_2, float P_3, float P_4)
			{
			}

			public void RNjNtIEWfJWiZpeZhKQubnuTYvTg(double P_0)
			{
			}

			public void CFjucjfBokAfxdwaqAXJFftGjPQwA()
			{
			}

			public void UMrbZEfDXftdAlVnbUZQqMMAgbvcA()
			{
			}
		}

		protected struct QcCssoCbfSGRfkQchmIULAFUgwPs
		{
			public float cdHQDZxAaqVvKEXVJdVONEamrOMM;

			public float HAyeIEbcuaeAxaiFACKabGLFjEHvb;

			public float XwyjIzMnktiNRVDJWbpTrXHKAsCz;

			public float mricfIduxQqDnjJtfIOngeoOGColA;

			internal QcCssoCbfSGRfkQchmIULAFUgwPs(float P_0, float P_1, float P_2, float P_3)
			{
				cdHQDZxAaqVvKEXVJdVONEamrOMM = 0f;
				HAyeIEbcuaeAxaiFACKabGLFjEHvb = 0f;
				XwyjIzMnktiNRVDJWbpTrXHKAsCz = 0f;
				mricfIduxQqDnjJtfIOngeoOGColA = 0f;
			}

			public static QcCssoCbfSGRfkQchmIULAFUgwPs WKslORwmjiPyhdtAGkHtYRYmYQMC()
			{
				return default(QcCssoCbfSGRfkQchmIULAFUgwPs);
			}

			public override string ToString()
			{
				return null;
			}
		}

		private struct hdXxgasagMjZbaZiVAeujVcDZpweA
		{
			public byte qqkGbaCIhdvPpbMwjAWkBweHIMBk;

			public byte[] jWtpVMleyxsBDEcjGsQfgYDGBBZl;

			public int dEQMoeiOoJfENjicSVSZxORODzu;

			public hdXxgasagMjZbaZiVAeujVcDZpweA(byte P_0, byte[] P_1, int P_2)
			{
				qqkGbaCIhdvPpbMwjAWkBweHIMBk = 0;
				jWtpVMleyxsBDEcjGsQfgYDGBBZl = null;
				dEQMoeiOoJfENjicSVSZxORODzu = 0;
			}
		}

		protected class drUhrinNPucRxTwgPGMBgegBBqdIA
		{
			public ushort USTXPeKwIyOOAIixwPdptPXMekVo;

			public ushort KnUNgSciNoxZHPOxndZgAGObabwCA;

			public ushort ppCvuUvavpaCeYbhnBwZcCGQmkaxA;

			public ushort MrILFTiDVxKkTWgwkeLVDMPkKuKXA;

			public override string ToString()
			{
				return null;
			}
		}

		protected readonly yLpbwZJUFNkRouxglOYNdRyBNHOG _controllerType;

		protected readonly int _buttonCount;

		protected readonly int _axisCount;

		protected readonly int _vibrationMotorCount;

		private readonly IHIDDevice LIcjIzUUhdWFFbCGUfvKkmViJEig;

		private readonly HIDProperties VcvGSzdXotZHuVuMaJNDkPIHPejuA;

		private readonly bool YRYoIlAdYNBKOixJslmEPLMprKmHA;

		private readonly NativeBuffer XNXpCXzcoryxzhPHGHgpKsWtHEnE;

		private readonly NativeBuffer DFsuRxNKqgwAPkTbYQbXxpDXGCVH;

		private readonly NativeBuffer RIfDvnFdGYkZgbedcVKkyebnxZKu;

		private readonly byte[] qpKRkUsOMpNYiaaLKerlVwVqwfzI;

		private readonly NativeBuffer mPWVqZlPIpBQuyVLVBnUecAcacNzA;

		private readonly NativeBuffer doENNsXWYQjBGbLNelFhcQpnWbuS;

		private MwEMUNdEdQpngdbXMtjwIdOvEFgfA tJsvjECNcSqhMYLrdLOuyoQaErVIA;

		private double GeIoFvhvHxcZWhnnBIsqyuumRroP;

		private byte SFxLMILxjCnFnJImLBlDgVEdRaleA;

		private double HnjozlzYuiDkceOgwZgCfdMgqqTO;

		private bool sOmfYAgBIWgqWFhRGECwBZOgaBiPb;

		private bool zTYvncIBdKsohvQnmaiSoyHqKapg;

		private YeaAQADPQMsdYWaxpIFbZaIqSbdMA[] jrpsLKjollKMYJVBabXGytqmHBMp;

		private drUhrinNPucRxTwgPGMBgegBBqdIA[] irPvOXFlnFqunAaoEjtbhqDGRcZqA;

		private static readonly byte[] qETLngrjetckkcHIOBuBFhvFqenqb;

		public int vibrationMotorCount => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
		{
			amplitudeLow = default(float);
			frequencyLow = default(float);
			amplitudeHigh = default(float);
			frequencyHigh = default(float);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
		}

		public void StopVibration(int motorIndex)
		{
		}

		public void StopVibration()
		{
		}

		private void cnzilXFsxEluofIcokNRtHehscK(int P_0)
		{
		}

		protected NintendoSwitchGamepadDriver(InitArgs P_0, yLpbwZJUFNkRouxglOYNdRyBNHOG P_1, int P_2, int P_3, int P_4)
		{
		}

		protected void Initialize()
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

		protected abstract void UpdateElements(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] elements, NativeBuffer inputReport, double timestamp);

		private bool JMMJQIsbCyDvCBaocpaBCWNmTRok(hdXxgasagMjZbaZiVAeujVcDZpweA P_0, byte[] P_1)
		{
			return false;
		}

		private bool hnjBYqDLhNxMXNUKPkHHqvBIQIfw(NativeBuffer P_0, byte P_1)
		{
			return false;
		}

		private void HcuWsCQmMIWduhKGFByARbtbWujF(NativeBuffer P_0)
		{
		}

		private void CnQuHYKhpUIPUccvmeodwOMJGDgxA(NativeBuffer P_0, int P_1)
		{
		}

		private static void qclevnGzQISwGtJuQfaQiZOmnLkab(NativeBuffer P_0, int P_1, QcCssoCbfSGRfkQchmIULAFUgwPs P_2)
		{
		}

		private static byte axYjFIBXxklcgcXnNJAWDbnBVCjl(float P_0)
		{
			return 0;
		}

		private bool UzQFOuueERTKejpCcailpNvuNQVy()
		{
			return false;
		}

		private bool uTggNPQCHZQtwCZVZRMBwGNMXaCT(byte P_0, byte P_1, byte P_2, byte[] P_3)
		{
			return false;
		}

		private bool sNEYrPsIMnHVVSNILpYLZXraqtPv(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private byte qXKBUdaMkVORRfAaudNPHNZWNhIMA()
		{
			return 0;
		}

		private bool RbvPmxcCjZKlrsLPVUMLyHxpeqUu()
		{
			return false;
		}

		private static void MhpewfgzNJhLePcVPdPIowaRPWpU(byte[] P_0, drUhrinNPucRxTwgPGMBgegBBqdIA P_1, drUhrinNPucRxTwgPGMBgegBBqdIA P_2, bool P_3)
		{
		}

		private static void sXaCrezAnYJlggfaMAXplhkLjgue(byte[] P_0, drUhrinNPucRxTwgPGMBgegBBqdIA P_1, drUhrinNPucRxTwgPGMBgegBBqdIA P_2)
		{
		}

		protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, drUhrinNPucRxTwgPGMBgegBBqdIA calX, drUhrinNPucRxTwgPGMBgegBBqdIA calY, out ushort calibratedX, out ushort calibratedY)
		{
			calibratedX = default(ushort);
			calibratedY = default(ushort);
			return false;
		}

		protected drUhrinNPucRxTwgPGMBgegBBqdIA GetAxisCalibration(int index)
		{
			return null;
		}

		private void qoDTESqhLFQdqZsztOSGjUPAeWjC(bool P_0)
		{
		}

		~NintendoSwitchGamepadDriver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
