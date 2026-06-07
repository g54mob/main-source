using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum chTiUUlSWiaiqpunvXfYinOPJiAG
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum cnoeSmPsqpADhgVcHUIispIholBUA
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class ufOAWTaiSlkyMhfPrtyekFpONJGFb
		{
			private const uint yCAHfpaRgkqPdeCClteNVJBURotk = 3988292384u;

			public unsafe static uint qFBrwpCdpQWimrnrVmNIxMtXMDnU(byte* P_0, int P_1, uint P_2)
			{
				return ~CotIgeSSGNAxJwrLgiECDfcQZtvgA(CotIgeSSGNAxJwrLgiECDfcQZtvgA(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint oghzadsEEkHwPARuZxOyRXzZbRIvA(uint P_0, byte* P_1, int P_2)
			{
				return CotIgeSSGNAxJwrLgiECDfcQZtvgA(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint CotIgeSSGNAxJwrLgiECDfcQZtvgA(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				for (int i = 0; i < P_2; i++)
				{
					P_0 ^= P_1[i];
					for (int j = 0; j < 8; j++)
					{
						P_0 = (P_0 >> 1) ^ (((P_0 & 1) != 0) ? P_3 : 0);
					}
				}
				return P_0;
			}
		}

		private enum ONjMUvozjmJZWovpgxkCfRzMQYSF
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float gMnNlhWVYYoNoKZeUGLPyBTaVldb = 4f;

		private const int axjuinwFfUCrAdTXPIlBScPyWHuS = 14;

		private const int bAVCSYFZyxdswTFVvXvwzjITUxYC = 2;

		private const int KRBbdnAgQFxlBfhHwPqkHJWWuKmiA = 0;

		private const int LgabFPMzqIghNHFeTFdIKjBXJdHF = 1912;

		private const int gLOgOXTmTPhHvXAryaGpFkhcCgxab = 0;

		private const int xjoNSjYKVGLwXySGLbbYHvcNTKMF = 941;

		private const bool MXNWsmJyuEOsXrpfRgABaRcOUfDWA = false;

		private const bool uavbNfGLYxeIKEIdWRmSoFVBJNSw = true;

		private const float QzDLmBRvRfFuwbWRqhVWQZnqWGAh = 2.5f;

		private const int tcHEyDTESWTdiToxhAgfNGaHAjIi = 0;

		private const int kFwMhWhwAPitglJjsbpCaAYnQoxd = 0;

		private const int CKtSaCHrHSBAtJddwNOflVLAQHsg = 1;

		private const int euixKbVbiqKVwLhwILddvrBzQJJV = 0;

		private const int SorONUNpXdpZrmlcZjFRBgDnNYHP = 0;

		private const int HHKCngMAhRKmSUThRBPOehDltMED = 0;

		private const int DPVGggbSbmaAELLMSTVVGGyfIuYYA = 1;

		private const int KMMEuRgoUaLLSVBnFbRzLJOsuANZ = 17;

		private const int UVVagPcxIKsIqyWvtyvcnuPUHWUu = 0;

		private const int fZJdhWIGLKPpuNxfBEjqERcfBMzKc = 2;

		private const int CQWLGzwlBtHBNQSQFkOlnbZDSiDL = 64;

		private const int lEBvBPYIBgloqkrWGTRUbcvAhOdu = 78;

		private const byte NHSfzUepfZvswpunTbdwvHVqcnExA = 17;

		private const byte rmMKwWfGVOukzzMSZQtMNjirOMux = 5;

		private const byte LNcAwVKqpmsTGWXPYtfWhdDxBubs = 2;

		private const byte CjSfJVircJYlmhjrOZZLmHtciItI = 37;

		private const byte kgaiRdmPXeGYVCkfbQYqjjvQGhSFA = 5;

		private const byte vdNjaMGaouKJujezlfUwazCOeqFFb = 41;

		private const byte BRWWLEnySNpBXcAIDaKbnKGBOpYt = 163;

		private const byte QraRUIDSeIodwyJkKkTusLgaITIKA = 49;

		private const byte vRIFTMvihWSRREHSvvzAismouEHb = 18;

		private const byte IHxDDGbaYkAvsUcpjOjZIxtlsCTJ = 16;

		private const byte pVgCyhVgsfvJzwlUArSECcygcRgv = 161;

		private const byte LdjYxYbpQNPedSXYziDlqwNQIJrC = 162;

		private const byte gbqiUiNXliBsndxTqXdoFPbdtTwH = 163;

		private const int pkxvwwqPDCIMjlVmtEAeenIfsNdM = 1;

		private const int yOsMGkCgzQgEiCKucdLcGVwvKWYhA = 2;

		private const int zFLqCcWzGNJEUCVAuqHaJaIZrbvy = 3;

		private const int UdoVJySuhniGIjEoTDnQorDoMBB = 4;

		private const int ywiPPxdnUBtyKTFWRokDuWxUERJx = 8;

		private const int AYFnBIOmqoiGNFbqtMenILpCgLUY = 9;

		private const int CNcgggrkpcxOPDeqBlmgosUHopQn = 5;

		private const int EWYtVWWhkedAOoWhsucyaqDHuxYJ = 19;

		private const int rEqAHkifOBxzLUOGjbppeqAyMbmb = 13;

		private const int xdFYRyOSslpovFeHVZApyhUTFvwh = 35;

		private const int GaWoBntglBhguarxdUHgsLimEipgA = 5;

		private const int gJCisvwsbbkWRfbPeayzFTPPLBeg = 6;

		private const int dUlnSdzlRMOExeAjyslYXmBsfhuy = 7;

		private const int bkGeRoEISnEUFPhBzeKuIMlgKaGHc = 10;

		private const int tJdmqTuJzqeuDNFUodQpEsUEiWSwA = 30;

		private const int ansfznyPwQYYunIJFfdUbthQXLoE = 27;

		private const byte ezUxIHXIrbOZIqAkcMZVDEoyAfGc = 200;

		private const byte jboHzrsrWvumQCEzjHspZDIUcYxK = 53;

		private const byte uaEHXCTHCKbgfAuctKZZRmoqvDxI = byte.MaxValue;

		private const byte ePjKdbtqbTeDSqJmiRkkBCzYrmAs = 0;

		private const bool gkYQZQhBZHLUCjRciqKweQMTZGHS = true;

		private const int iYelrLjpmHzOEylSOeTRCZZHsrhj = 60;

		private const int yYzUvATgdxjywtHVtQTejbgrKiJv = 60;

		private const int CDLFiqsPsWgnwOLsYTkLUsqnCTJX = 187500;

		private const float BOZwFMmyzoSrXrieKZCQptnaIaRJ = 8192f;

		private const float eEuRjeWjigPQbbASAQmxOrfWrmHk = 0.0010652969f;

		private const float TmxEFLEBvRCPeexdcxXJlcaUYnsn = 0.06103702f;

		private const bool NJBRvzWYuisBtlwDtqisCuRiOVvX = true;

		private const bool ZigCQpHjzZKOuSWQfrhRAUpigqizA = true;

		private const bool cFWcSUhjKggBHOTinxkqNxFccHNAA = true;

		private const bool OwOQACOPhINHsVSBHGHmYtpnzsFl = true;

		private const float cAekRjBLblJJZSQnKpxBFPPfDSTn = 4096f;

		private const float ZxpStYDClmbxtcEAfDhUhVUqvBUkA = 16384f;

		private const float wFjfYbwynIZjfIfGXGSdmvvDDjY = 16777216f;

		private const float eSivSGUtDyteWgNRDXspnHLRwvoA = 268435460f;

		private const float HEeButoessSiVAYLJpIaHhOVSnEr = 0.01999998f;

		private const float vHXrrlsVoYeNOCQNjGQnJjRkepsH = 8192f;

		private const float LpiYqKvRWCTEPlkzKDuSGWUEWvkn = 0.98f;

		private const float TxhjcuagOnYRqjlKOokoAzAxQypf = 45f;

		private const float WXghyjXcqKNMvEXbJKixTfWMADPv = 20f;

		private readonly IHIDDevice jGiKyvHMnHPeNLqKqueJtHJGWRAA;

		private readonly HIDProperties RdBaXYbvbhounsasvviRpFUUuydF;

		private readonly bool oGqVREqkWuxNyddHFeOrtnfdAttiA;

		private readonly THNsKdmFHrPljnxJReWkqtKXyhyf AZNMFWolxVEbDfUPEfIbDSWZbmPk;

		private readonly int lbnevyuiCsiQEsGdRbySQIBsjfbfA;

		private readonly int GeiHZxpzVjdKJqVbMSyaZKPjaCpV;

		private bool DArSpmomWOCutWJkNqMJRpxlvWTI;

		private byte vRZFjTgSypRbNxQlwejYILjDWFqTA;

		private int vrOGeBSKOcEaNAlewnpJJolaZHcuA;

		private int bTOwSVkkniIdyXuVuBiiCRlIgHDj;

		private int lkEUfCcEbUGDbiHelxblRwLcKYXQ;

		private int rMSyCbEbhgJZXGipaTYOszJLHSm;

		private readonly NativeBuffer knkcfXWlOdVjqlTlarNxZebHvIXq;

		private readonly NativeBuffer MlLIqkJAhCYbQvTPKGiitgmcxwTC;

		private dQrAZjxmvMRuuUvHYPSsKegoCJrCA SswbwvudepbILiXHoByojAbTlVBe;

		private readonly byte[] fjlaYNfRCZTMQGFZPzqXhiGetDxE = new byte[1] { 162 };

		private bool FGHcDikKAMHkHbpKreScLJonrLnoA;

		private bool LKqBtXZrUfNCBHePLQeuzmRedPYp;

		private double jwjARNehHGciDRkpQlSQyjzWNhwfA;

		private int qyIrPKnSUNTcsMxYQAxuvFTLnhkP;

		private ONjMUvozjmJZWovpgxkCfRzMQYSF GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Unknown;

		private Quaternion QRFrTTafGODBSODRgtQIUKFPfMsEA = Quaternion.identity;

		private ushort bPLxMyqhRGjLpvZrVFnkugSaSwcu;

		private float cQnafXBGTGJchySiRvWOyvQCnQdr;

		private double lAAGKvIVmjjYdhoqFSkMjeQhxrHHB;

		private float eHQycIdpEkbBRvkEMjjEiMnQvdxm;

		private bool RUtmovfVmcdcSVmxxhDPwtUnVkye;

		private bool ojSyOAuCnkUVvuPBXFtbivMrwkheA;

		private bool aEgwTWAPJvQHejgJdyhffGcZYlGd;

		private bool vAIXZxFEawlWgVGEcfZgFqwLKowE;

		private byte tVrJdebCRlMZULgXjsmkXktLaIKJA;

		private byte LIHgjvFTQIozAgluHunVPXNgjsmob;

		private Quaternion jvKnzZfSJpItBwbKiYqitBJOCBygA = Quaternion.identity;

		private Quaternion jxUXhmsoBarZmXPhNPyfgseVsLhF = Quaternion.identity;

		private bool CxfikFDSqeeswFsECMaSBQgdmnuLA;

		private int qSmCKvKeXrEEfHlFBbuOlkXwABGc;

		private int[] DezwcTLhkuwthFNHHcYUxBRqfqadA = new int[2];

		private int[] SxVNAACSUFqsKZMcxKMgFQBxWpeF = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount; i++)
				{
					if (vibrationMotors[i].SzNjajnXuqTkLVKNUlPZHTgLWZsS > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		float IDriver_DualShock4.BatteryLevel => qyIrPKnSUNTcsMxYQAxuvFTLnhkP;

		bool IDriver_DualShock4.BatteryCharging => GfnDvAHJXPvxrdVDjleMZGKFtYlHA == ONjMUvozjmJZWovpgxkCfRzMQYSF.Charging;

		float IDriver_DualShock4.LeftMotor
		{
			get
			{
				return vibrationMotors[0].PvKIhOBqjFDTufSBvzXfLPDhKvGfb;
			}
			set
			{
				vibrationMotors[0].PvKIhOBqjFDTufSBvzXfLPDhKvGfb = value;
			}
		}

		float IDriver_DualShock4.RightMotor
		{
			get
			{
				return vibrationMotors[1].PvKIhOBqjFDTufSBvzXfLPDhKvGfb;
			}
			set
			{
				vibrationMotors[1].PvKIhOBqjFDTufSBvzXfLPDhKvGfb = value;
			}
		}

		float IDriver_DualShock4.LightColorR
		{
			get
			{
				return lights[0].bmxoAjzsPVSTcbpsoalZqgIkhIBt;
			}
			set
			{
				lights[0].bmxoAjzsPVSTcbpsoalZqgIkhIBt = value;
			}
		}

		float IDriver_DualShock4.LightColorG
		{
			get
			{
				return lights[0].uGGffweBZbyGJjlgwJeLbWHGERux;
			}
			set
			{
				lights[0].uGGffweBZbyGJjlgwJeLbWHGERux = value;
			}
		}

		float IDriver_DualShock4.LightColorB
		{
			get
			{
				return lights[0].QiEWCumzGtErsUfsoqUSBOXdNDVn;
			}
			set
			{
				lights[0].QiEWCumzGtErsUfsoqUSBOXdNDVn = value;
			}
		}

		float IDriver_DualShock4.LightFlashOnDuration
		{
			get
			{
				return (int)tVrJdebCRlMZULgXjsmkXktLaIKJA;
			}
			set
			{
				tVrJdebCRlMZULgXjsmkXktLaIKJA = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				suDGsjtpqBdBhFbGpxBoWPFwKbSaA();
				if (tVrJdebCRlMZULgXjsmkXktLaIKJA == 0 && LIHgjvFTQIozAgluHunVPXNgjsmob == 0)
				{
					LKqBtXZrUfNCBHePLQeuzmRedPYp = true;
				}
			}
		}

		float IDriver_DualShock4.LightFlashOffDuration
		{
			get
			{
				return (int)LIHgjvFTQIozAgluHunVPXNgjsmob;
			}
			set
			{
				LIHgjvFTQIozAgluHunVPXNgjsmob = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				suDGsjtpqBdBhFbGpxBoWPFwKbSaA();
				if (tVrJdebCRlMZULgXjsmkXktLaIKJA == 0 && LIHgjvFTQIozAgluHunVPXNgjsmob == 0)
				{
					LKqBtXZrUfNCBHePLQeuzmRedPYp = true;
				}
			}
		}

		Vector3 IDriver_DualShock4.AccelerometerValue => BQGwsKjdXyTRRSGnYHqDKULyXUBh(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq);

		Vector3 IDriver_DualShock4.AccelerometerValueRaw => new Vector3(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[0], accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[1], accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[2]);

		Vector3 IDriver_DualShock4.GyroscopeValue => XbqioLiQJNPHIrFyinaZBLsjQcNrb(gyroscopes[0].ryJMmdZbgbmdaGLxdebJrFWVdjZP);

		Vector3 IDriver_DualShock4.GyroscopeValueRaw => new Vector3(gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[0], gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[1], gyroscopes[0].TOPmGrQoeSxFlEKkKDvFEfkvXbyBA[2]);

		Vector3 IDriver_DualShock4.LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]);
				return cRefESmqtsGRlFaYMepDDKUNooGoA(vector, cQnafXBGTGJchySiRvWOyvQCnQdr);
			}
		}

		Vector3 IDriver_DualShock4.LastGyroscopeValueRaw => new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]);

		Quaternion IDriver_DualShock4.Orientation => QRFrTTafGODBSODRgtQIUKFPfMsEA;

		int IDriver_DualShock4.MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => RdBaXYbvbhounsasvviRpFUUuydF.vendorId;

		ushort IHIDControllerExtension.productId => RdBaXYbvbhounsasvviRpFUUuydF.productId;

		string IHIDControllerExtension.productName => RdBaXYbvbhounsasvviRpFUUuydF.productName;

		string IHIDControllerExtension.manufacturer => RdBaXYbvbhounsasvviRpFUUuydF.manufacturer;

		ushort IHIDControllerExtension.usagePage => RdBaXYbvbhounsasvviRpFUUuydF.usagePage;

		ushort IHIDControllerExtension.usage => RdBaXYbvbhounsasvviRpFUUuydF.usage;

		public void ResetOrientation()
		{
			QRFrTTafGODBSODRgtQIUKFPfMsEA = Quaternion.identity;
			CxfikFDSqeeswFsECMaSBQgdmnuLA = false;
		}

		void IDriver_DualShock4.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		int IDriver_DualShock4.GetTouchCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
			return this.GetTouchCount();
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching;
		}

		bool IDriver_DualShock4.IsTouchingAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
			return this.IsTouchingAtIndex(index);
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId);
		}

		bool IDriver_DualShock4.IsTouchingAtTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
			return this.IsTouchingAtTouchId(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].touchId;
		}

		int IDriver_DualShock4.GetTouchIdAtIndex(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
			return this.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			if (!rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching)
			{
				return false;
			}
			position.x = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionX;
			position.y = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionY;
			return true;
		}

		bool IDriver_DualShock4.GetTouchPositionByIndex(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
			return this.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId))
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			for (int i = 0; i < rFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
			{
				if (rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
				{
					position.x = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionX;
					position.y = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionY;
				}
			}
			return true;
		}

		bool IDriver_DualShock4.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			if (!rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].isTouching)
			{
				return false;
			}
			positionX = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionAbsX;
			positionY = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[index].positionAbsY;
			return true;
		}

		bool IDriver_DualShock4.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
			return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].YpmgwwjwNILOgscVHbQZZLkGyLXu(touchId))
			{
				return false;
			}
			ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] rFuDyXZFSuwShPfcFbhPdVCqtPBKA = touchpads[0].RFuDyXZFSuwShPfcFbhPdVCqtPBKA;
			for (int i = 0; i < rFuDyXZFSuwShPfcFbhPdVCqtPBKA.Length; i++)
			{
				if (rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].isTouching)
				{
					positionX = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionAbsX;
					positionY = rFuDyXZFSuwShPfcFbhPdVCqtPBKA[i].positionAbsY;
				}
			}
			return true;
		}

		bool IDriver_DualShock4.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
			return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
		}

		public void StopLightFlash()
		{
			tVrJdebCRlMZULgXjsmkXktLaIKJA = 0;
			LIHgjvFTQIozAgluHunVPXNgjsmob = 0;
			FGHcDikKAMHkHbpKreScLJonrLnoA = true;
			LKqBtXZrUfNCBHePLQeuzmRedPYp = true;
			aEgwTWAPJvQHejgJdyhffGcZYlGd = true;
		}

		void IDriver_DualShock4.StopLightFlash()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
			this.StopLightFlash();
		}

		public void StopVibration()
		{
			int num = base.Rewired_002EHID_002EDrivers_002EIControllerDriver_002EVibrationMotorCount;
			for (int i = 0; i < num; i++)
			{
				vibrationMotors[i].SzNjajnXuqTkLVKNUlPZHTgLWZsS = 0;
			}
		}

		void IDriver_DualShock4.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public DualShock4Driver(InitArgs P_0)
			: base(P_0)
		{
			jGiKyvHMnHPeNLqKqueJtHJGWRAA = P_0.hidDevice;
			RdBaXYbvbhounsasvviRpFUUuydF = jGiKyvHMnHPeNLqKqueJtHJGWRAA.properties;
			lbnevyuiCsiQEsGdRbySQIBsjfbfA = P_0.hatZeroValue;
			GeiHZxpzVjdKJqVbMSyaZKPjaCpV = P_0.hatSpan;
			AZNMFWolxVEbDfUPEfIbDSWZbmPk = P_0.connectionType;
			oGqVREqkWuxNyddHFeOrtnfdAttiA = AZNMFWolxVEbDfUPEfIbDSWZbmPk == THNsKdmFHrPljnxJReWkqtKXyhyf.Bluetooth;
			if (oGqVREqkWuxNyddHFeOrtnfdAttiA)
			{
				RdBaXYbvbhounsasvviRpFUUuydF.maxOutputReportLength = 78;
			}
			if (RdBaXYbvbhounsasvviRpFUUuydF.maxOutputReportLength < 23)
			{
				RdBaXYbvbhounsasvviRpFUUuydF.maxOutputReportLength = 23;
			}
			knkcfXWlOdVjqlTlarNxZebHvIXq = new NativeBuffer(64);
			MlLIqkJAhCYbQvTPKGiitgmcxwTC = new NativeBuffer(RdBaXYbvbhounsasvviRpFUUuydF.maxOutputReportLength);
			SswbwvudepbILiXHoByojAbTlVBe = new dQrAZjxmvMRuuUvHYPSsKegoCJrCA(MlLIqkJAhCYbQvTPKGiitgmcxwTC.Pointer, MlLIqkJAhCYbQvTPKGiitgmcxwTC.Length, RdBaXYbvbhounsasvviRpFUUuydF.maxOutputReportLength);
			lights = new eOTDyXEaLnqMzCVeUQsYyxDdlUnRA[1]
			{
				new eOTDyXEaLnqMzCVeUQsYyxDdlUnRA(11, 24, 28)
			};
			lights[0].VjNtNSvDDNOJXHSCDSpNyyrXKTOM += oFzNEaMdANnIevjuvQCgCKMhujDE;
			ojSyOAuCnkUVvuPBXFtbivMrwkheA = true;
			vibrationMotors = new rTJgTxMejKLMRUmSvWOxEnqbcNsC[2]
			{
				new rTJgTxMejKLMRUmSvWOxEnqbcNsC(0, 255),
				new rTJgTxMejKLMRUmSvWOxEnqbcNsC(0, 255)
			};
			vibrationMotors[0].WzdlTpQpSqeyLlyDKcyfIzFLadvf += vOaxGdTwxswvDmtwNqWgOKxQNRDd;
			vibrationMotors[1].WzdlTpQpSqeyLlyDKcyfIzFLadvf += vOaxGdTwxswvDmtwNqWgOKxQNRDd;
		}

		protected override void OnInitialize()
		{
			if (jGiKyvHMnHPeNLqKqueJtHJGWRAA.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			vAIXZxFEawlWgVGEcfZgFqwLKowE = true;
			if (oGqVREqkWuxNyddHFeOrtnfdAttiA)
			{
				DArSpmomWOCutWJkNqMJRpxlvWTI = true;
				SswbwvudepbILiXHoByojAbTlVBe.wZWZYdhupQABWZEQqexXIjnmCGhaA |= pFKEYBfdSFpyWlUlolJLZXZaRgbo.WriteDirect;
				DArSpmomWOCutWJkNqMJRpxlvWTI = XGKxfDxmoJzKXzZKGHKnJLoGVchv(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
				if (!DArSpmomWOCutWJkNqMJRpxlvWTI)
				{
					SswbwvudepbILiXHoByojAbTlVBe.wZWZYdhupQABWZEQqexXIjnmCGhaA &= ~pFKEYBfdSFpyWlUlolJLZXZaRgbo.WriteDirect;
				}
			}
			else
			{
				DArSpmomWOCutWJkNqMJRpxlvWTI = XGKxfDxmoJzKXzZKGHKnJLoGVchv(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
			}
			if (!DArSpmomWOCutWJkNqMJRpxlvWTI)
			{
				throw new Exception();
			}
			vRZFjTgSypRbNxQlwejYILjDWFqTA = 1;
			vrOGeBSKOcEaNAlewnpJJolaZHcuA = 0;
			if (oGqVREqkWuxNyddHFeOrtnfdAttiA && DArSpmomWOCutWJkNqMJRpxlvWTI)
			{
				vRZFjTgSypRbNxQlwejYILjDWFqTA = 17;
				vrOGeBSKOcEaNAlewnpJJolaZHcuA = 2;
			}
			bTOwSVkkniIdyXuVuBiiCRlIgHDj = 5 + vrOGeBSKOcEaNAlewnpJJolaZHcuA;
			lkEUfCcEbUGDbiHelxblRwLcKYXQ = 6 + vrOGeBSKOcEaNAlewnpJJolaZHcuA;
			rMSyCbEbhgJZXGipaTYOszJLHSm = 7 + vrOGeBSKOcEaNAlewnpJJolaZHcuA;
			buttons = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new UAfXLOdFwSwHeolOgcMEHHfYJfpJA(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new bpjwwWbNobTCGrXbZKxCDfQGumWO[6]
			{
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new bpjwwWbNobTCGrXbZKxCDfQGumWO(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new ZGyGvtDVdXQGfZtomiLpAayOMjWu[1]
			{
				new ZGyGvtDVdXQGfZtomiLpAayOMjWu(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, IFeMGeNELaNCdPBXCBZwZSVMkEEP)
			};
			accelerometers = new ofElGznmYTkSLSeuUEeYlIATDRkU[1]
			{
				new ofElGznmYTkSLSeuUEeYlIATDRkU(vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 48
				}, 3, HVUOwkCbweoxemAwNFwiCUUzMpbX)
			};
			gyroscopes = new wiBPGDvFUUBIavEWhuSIVMNwIKCkA[1]
			{
				new wiBPGDvFUUBIavEWhuSIVMNwIKCkA(base.initArgs.updateLoopSetting, vRZFjTgSypRbNxQlwejYILjDWFqTA, new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 48
				}, 3, 60, SdgFWCDUaOyNlVnhBOyzDotrHljhA, lFvhQbkYnFRmUVTzNPdfBSXTEnbi)
			};
			touchpads = new ECuuExxPnMTpiDfXAPmQzhehTPKT[1]
			{
				new ECuuExxPnMTpiDfXAPmQzhehTPKT(vRZFjTgSypRbNxQlwejYILjDWFqTA, new ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new OYzieseEeYXDrIqXsZAdwVmBBsCg.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + vrOGeBSKOcEaNAlewnpJJolaZHcuA,
					bitSize = 48
				}, 60, FDYTverqqAlPZHEjsICzeHbDCFkdA)
			};
			lAAGKvIVmjjYdhoqFSkMjeQhxrHHB = ReInput.realTime;
			InitializationFinished(initialized: true);
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			ieiUKJDGgKFZSqjwlONiovbcPfMp();
			CYgFrKczPxUStflzVoGrbGEdeqVG(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < knkcfXWlOdVjqlTlarNxZebHvIXq.Length)
			{
				return false;
			}
			eHQycIdpEkbBRvkEMjjEiMnQvdxm = (float)(timestamp - lAAGKvIVmjjYdhoqFSkMjeQhxrHHB);
			lAAGKvIVmjjYdhoqFSkMjeQhxrHHB = timestamp;
			knkcfXWlOdVjqlTlarNxZebHvIXq.Write(inputReportPtr, inputReportLength, knkcfXWlOdVjqlTlarNxZebHvIXq.Length);
			FseUxwsdoqrMsHpmqUSOCJgpknQx(knkcfXWlOdVjqlTlarNxZebHvIXq);
			DcCgTEaNWFDfwoMamBosURmNmLMjb(knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			OYzieseEeYXDrIqXsZAdwVmBBsCg[] array = axes;
			rzkUyXCDgZMksihnbeBeUGOEzKeq(array, knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			array = hats;
			rzkUyXCDgZMksihnbeBeUGOEzKeq(array, knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			array = accelerometers;
			rzkUyXCDgZMksihnbeBeUGOEzKeq(array, knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			array = gyroscopes;
			rzkUyXCDgZMksihnbeBeUGOEzKeq(array, knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			array = touchpads;
			rzkUyXCDgZMksihnbeBeUGOEzKeq(array, knkcfXWlOdVjqlTlarNxZebHvIXq, timestamp);
			byte num = knkcfXWlOdVjqlTlarNxZebHvIXq[30 + vrOGeBSKOcEaNAlewnpJJolaZHcuA];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = MathTools.Clamp(b * 10 + 5, 0, 100);
					GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 100;
						GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Full;
						break;
					case 14:
						qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 0;
						GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Charging;
						break;
					default:
						qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 0;
						GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 5;
					break;
				case 1:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 20;
					break;
				case 2:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 30;
					break;
				case 3:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 45;
					break;
				case 4:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 55;
					break;
				case 5:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 70;
					break;
				case 6:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 80;
					break;
				case 7:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 95;
					break;
				case 8:
					qyIrPKnSUNTcsMxYQAxuvFTLnhkP = 100;
					break;
				}
				GfnDvAHJXPvxrdVDjleMZGKFtYlHA = ONjMUvozjmJZWovpgxkCfRzMQYSF.Discharging;
			}
			vvnyeMlRzBtjZoKIOgwBszijkebg();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void CYgFrKczPxUStflzVoGrbGEdeqVG(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			if (FGHcDikKAMHkHbpKreScLJonrLnoA)
			{
				XGKxfDxmoJzKXzZKGHKnJLoGVchv(P_0);
				FGHcDikKAMHkHbpKreScLJonrLnoA = false;
			}
		}

		private bool XGKxfDxmoJzKXzZKGHKnJLoGVchv(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			oCXOKjcKXDWYhmORMsMVDPgdKNRh();
			bool result = TNHsmZzfqxgTlLXbpGvzCzcbkuIeA(P_0);
			if (LKqBtXZrUfNCBHePLQeuzmRedPYp)
			{
				result = TNHsmZzfqxgTlLXbpGvzCzcbkuIeA(P_0);
				LKqBtXZrUfNCBHePLQeuzmRedPYp = false;
			}
			return result;
		}

		private unsafe void oCXOKjcKXDWYhmORMsMVDPgdKNRh()
		{
			byte b = 0;
			b |= 1;
			RUtmovfVmcdcSVmxxhDPwtUnVkye = false;
			b |= 2;
			ojSyOAuCnkUVvuPBXFtbivMrwkheA = false;
			b |= 4;
			aEgwTWAPJvQHejgJdyhffGcZYlGd = false;
			byte b2 = 128;
			if (oGqVREqkWuxNyddHFeOrtnfdAttiA)
			{
				b2 |= 0x40;
			}
			if (vAIXZxFEawlWgVGEcfZgFqwLKowE)
			{
				b2 |= 4;
				vAIXZxFEawlWgVGEcfZgFqwLKowE = false;
			}
			if (oGqVREqkWuxNyddHFeOrtnfdAttiA && DArSpmomWOCutWJkNqMJRpxlvWTI)
			{
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[0] = 17;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[1] = b2;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[2] = 0;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[3] = b;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[4] = 0;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[5] = 0;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[6] = (byte)vibrationMotors[1].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[7] = (byte)vibrationMotors[0].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[8] = lights[0].icHctacIJMzVGXgZeecHBnvYQQyD;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[9] = lights[0].sxriMIpQSAKUwYKSoWWkEypbExKV;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[10] = lights[0].GhRUEqUmyuxeFVpnBfPmcoxXDHeUA;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[11] = tVrJdebCRlMZULgXjsmkXktLaIKJA;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[12] = LIHgjvFTQIozAgluHunVPXNgjsmob;
				int jaUoCJvJieUwSVusZsZEvYfRaHVI = SswbwvudepbILiXHoByojAbTlVBe.JaUoCJvJieUwSVusZsZEvYfRaHVI;
				uint bytes = ufOAWTaiSlkyMhfPrtyekFpONJGFb.qFBrwpCdpQWimrnrVmNIxMtXMDnU((byte*)(void*)MlLIqkJAhCYbQvTPKGiitgmcxwTC.Pointer, jaUoCJvJieUwSVusZsZEvYfRaHVI - 4, 162u);
				MlLIqkJAhCYbQvTPKGiitgmcxwTC.Write(bytes, jaUoCJvJieUwSVusZsZEvYfRaHVI - 4);
			}
			else
			{
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[0] = 5;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[1] = b;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[2] = 0;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[4] = (byte)vibrationMotors[1].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[5] = (byte)vibrationMotors[0].SzNjajnXuqTkLVKNUlPZHTgLWZsS;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[6] = lights[0].icHctacIJMzVGXgZeecHBnvYQQyD;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[7] = lights[0].sxriMIpQSAKUwYKSoWWkEypbExKV;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[8] = lights[0].GhRUEqUmyuxeFVpnBfPmcoxXDHeUA;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[9] = tVrJdebCRlMZULgXjsmkXktLaIKJA;
				MlLIqkJAhCYbQvTPKGiitgmcxwTC[10] = LIHgjvFTQIozAgluHunVPXNgjsmob;
			}
		}

		private bool TNHsmZzfqxgTlLXbpGvzCzcbkuIeA(IpOusHhkFVHLPKjRNBUJTzZIWToMA P_0)
		{
			jwjARNehHGciDRkpQlSQyjzWNhwfA = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous:
				return jGiKyvHMnHPeNLqKqueJtHJGWRAA.WriteSync(SswbwvudepbILiXHoByojAbTlVBe, 0);
			case IpOusHhkFVHLPKjRNBUJTzZIWToMA.Asynchronous:
				jGiKyvHMnHPeNLqKqueJtHJGWRAA.WriteAsync(SswbwvudepbILiXHoByojAbTlVBe, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void DcCgTEaNWFDfwoMamBosURmNmLMjb(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[bTOwSVkkniIdyXuVuBiiCRlIgHDj];
			buttons[0].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x10) != 0, P_1);
			buttons[1].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x20) != 0, P_1);
			buttons[2].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x40) != 0, P_1);
			buttons[3].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x80) != 0, P_1);
			b = P_0[lkEUfCcEbUGDbiHelxblRwLcKYXQ];
			buttons[4].AtQsHqTAryodwUVQnJukddZkgqvd((b & 1) != 0, P_1);
			buttons[5].AtQsHqTAryodwUVQnJukddZkgqvd((b & 2) != 0, P_1);
			buttons[6].AtQsHqTAryodwUVQnJukddZkgqvd((b & 4) != 0, P_1);
			buttons[7].AtQsHqTAryodwUVQnJukddZkgqvd((b & 8) != 0, P_1);
			buttons[8].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x10) != 0, P_1);
			buttons[9].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x20) != 0, P_1);
			buttons[10].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x40) != 0, P_1);
			buttons[11].AtQsHqTAryodwUVQnJukddZkgqvd((b & 0x80) != 0, P_1);
			b = P_0[rMSyCbEbhgJZXGipaTYOszJLHSm];
			buttons[12].AtQsHqTAryodwUVQnJukddZkgqvd((b & 1) != 0, P_1);
			buttons[13].AtQsHqTAryodwUVQnJukddZkgqvd((b & 2) != 0, P_1);
		}

		private void rzkUyXCDgZMksihnbeBeUGOEzKeq(OYzieseEeYXDrIqXsZAdwVmBBsCg[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].bNihcfetwkjYPbAQTEqgnRQFuUSJ(P_1, P_2);
			}
		}

		private void ieiUKJDGgKFZSqjwlONiovbcPfMp()
		{
			if (isVibrating && ReInput.realTime >= jwjARNehHGciDRkpQlSQyjzWNhwfA)
			{
				FGHcDikKAMHkHbpKreScLJonrLnoA = true;
				RUtmovfVmcdcSVmxxhDPwtUnVkye = true;
			}
		}

		private void FseUxwsdoqrMsHpmqUSOCJgpknQx(NativeBuffer P_0)
		{
			if (DArSpmomWOCutWJkNqMJRpxlvWTI)
			{
				ushort num = knkcfXWlOdVjqlTlarNxZebHvIXq.ReadUShort(10 + vrOGeBSKOcEaNAlewnpJJolaZHcuA);
				float num3;
				if (num != bPLxMyqhRGjLpvZrVFnkugSaSwcu)
				{
					int num2 = ((num >= bPLxMyqhRGjLpvZrVFnkugSaSwcu) ? (num - bPLxMyqhRGjLpvZrVFnkugSaSwcu) : (num + 65535 - bPLxMyqhRGjLpvZrVFnkugSaSwcu));
					num3 = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					num3 = 0f;
				}
				bPLxMyqhRGjLpvZrVFnkugSaSwcu = num;
				cQnafXBGTGJchySiRvWOyvQCnQdr = num3;
			}
		}

		private void vvnyeMlRzBtjZoKIOgwBszijkebg()
		{
			if (DArSpmomWOCutWJkNqMJRpxlvWTI)
			{
				_ = cQnafXBGTGJchySiRvWOyvQCnQdr;
				_ = 0f;
				Vector3 vector = cRefESmqtsGRlFaYMepDDKUNooGoA(new Vector3(gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[0], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[1], gyroscopes[0].YdfXPmxeKAeSmthiRajhqEYfaKlq[2]), cQnafXBGTGJchySiRvWOyvQCnQdr);
				cpGjjICbsyitsBLJNXQNGeBJFAcO(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[0] * -1f, accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[1] * -1f, accelerometers[0].LWJBMyDpMAXWrlkvxBnTSFsUyyMq[2] * -1f);
				cekLxfhRORkOJsFJjOFWeUuHohNi(vector2, vector);
			}
		}

		private static bool cpGjjICbsyitsBLJNXQNGeBJFAcO(ref Vector3 P_0)
		{
			if (P_0.magnitude < 0.004f)
			{
				P_0.x = 0f;
				P_0.y = 0f;
				P_0.z = 0f;
				return false;
			}
			return true;
		}

		private void cekLxfhRORkOJsFJjOFWeUuHohNi(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && DIuVqTVrixeTGpieNCjBhPiyFQfF(P_0, out var cnoeSmPsqpADhgVcHUIispIholBUA2))
			{
				Quaternion a = QRFrTTafGODBSODRgtQIUKFPfMsEA * quaternion;
				if (!CxfikFDSqeeswFsECMaSBQgdmnuLA)
				{
					CxfikFDSqeeswFsECMaSBQgdmnuLA = true;
					jvKnzZfSJpItBwbKiYqitBJOCBygA = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					jxUXhmsoBarZmXPhNPyfgseVsLhF = QRFrTTafGODBSODRgtQIUKFPfMsEA;
				}
				jvKnzZfSJpItBwbKiYqitBJOCBygA *= quaternion;
				jxUXhmsoBarZmXPhNPyfgseVsLhF *= quaternion;
				Quaternion b;
				if ((cnoeSmPsqpADhgVcHUIispIholBUA2 & cnoeSmPsqpADhgVcHUIispIholBUA.XZ) != cnoeSmPsqpADhgVcHUIispIholBUA.None)
				{
					b = nyZaAaghQCdpKFwoZVxJVjJYukNuA(P_0, a.eulerAngles.y);
				}
				else if ((cnoeSmPsqpADhgVcHUIispIholBUA2 & cnoeSmPsqpADhgVcHUIispIholBUA.Y) != cnoeSmPsqpADhgVcHUIispIholBUA.None)
				{
					b = nvBfRJrxpHCbZphEWeroWejlgVUs(P_0);
					Vector3 vector = jxUXhmsoBarZmXPhNPyfgseVsLhF * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				QRFrTTafGODBSODRgtQIUKFPfMsEA = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				QRFrTTafGODBSODRgtQIUKFPfMsEA *= quaternion;
				if (CxfikFDSqeeswFsECMaSBQgdmnuLA)
				{
					CxfikFDSqeeswFsECMaSBQgdmnuLA = false;
				}
			}
		}

		private static Quaternion szhzbkOsLlbmsdPEbTOYQAHNBNNgA(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = TOsqcZRqfFzWjJFFSkTRatbdtIMX(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 TOsqcZRqfFzWjJFFSkTRatbdtIMX(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion ARAgZirPQWDFaBFoWcJZeqfWlZNGb(Quaternion P_0, chTiUUlSWiaiqpunvXfYinOPJiAG P_1)
		{
			Vector4 vector = default(Vector4);
			if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
			{
				P_0 = Quaternion.identity;
			}
			else
			{
				float num = P_0[(int)P_1];
				float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
				vector[3] = P_0.w / num2;
				vector[(int)P_1] = num / num2;
				P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
			}
			return P_0;
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
			float num2 = 1f / num;
			Quaternion result = default(Quaternion);
			result.x = (0f - quaternion.x) * num2;
			result.y = (0f - quaternion.y) * num2;
			result.z = (0f - quaternion.z) * num2;
			result.w = quaternion.w * num2;
			return result;
		}

		private float vrmiPuzNlpPKFyOLiFjxALnKSgdbA(float P_0, float P_1)
		{
			P_0 = MathTools.ClampAngle360(P_0);
			P_1 = MathTools.ClampAngle360(P_1);
			if (P_0 == P_1)
			{
				return 0f;
			}
			if (P_0 >= 180f)
			{
				P_0 -= 360f;
			}
			if (P_1 >= 180f)
			{
				P_1 -= 360f;
			}
			return P_0 - P_1;
		}

		private Vector3 XkWBLeGXKKLviPYbbemgDLDjqLuAA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion nyZaAaghQCdpKFwoZVxJVjJYukNuA(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion nvBfRJrxpHCbZphEWeroWejlgVUs(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
			float num2 = MathTools.Atan2(P_0.x, x);
			float x2 = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
			if (P_1 != 0f)
			{
				return quaternion * Quaternion.Euler(0f, P_1, 0f);
			}
			return quaternion;
		}

		private float YqVGBLRHrfKkdVWJDOzDaRPvZEIF(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool EPzABZNWfYwASWCFghAZqyaWtUlI(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool DIuVqTVrixeTGpieNCjBhPiyFQfF(Vector3 P_0, out cnoeSmPsqpADhgVcHUIispIholBUA P_1)
		{
			P_0.Normalize();
			P_1 = cnoeSmPsqpADhgVcHUIispIholBUA.None;
			bool result = false;
			if (IUqUXKlXVvQwAbrBErIQbqZCxldT(P_0))
			{
				result = true;
				P_1 |= cnoeSmPsqpADhgVcHUIispIholBUA.XZ;
			}
			if (DTPeHjjHZywMVNTDvcjXdPCXjguA(P_0))
			{
				result = true;
				P_1 |= cnoeSmPsqpADhgVcHUIispIholBUA.Y;
			}
			return result;
		}

		private bool IUqUXKlXVvQwAbrBErIQbqZCxldT(Vector3 P_0)
		{
			if (P_0.y > 0f)
			{
				return false;
			}
			if (Vector3.Angle(Vector3.down, P_0) > 45f)
			{
				return false;
			}
			return true;
		}

		private bool DTPeHjjHZywMVNTDvcjXdPCXjguA(Vector3 P_0)
		{
			if (P_0.z < 0f)
			{
				return false;
			}
			if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
			{
				return false;
			}
			return true;
		}

		private Vector3 BQGwsKjdXyTRRSGnYHqDKULyXUBh(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 XbqioLiQJNPHIrFyinaZBLsjQcNrb(RingBuffer<wiBPGDvFUUBIavEWhuSIVMNwIKCkA.omfOYSthvfxFOzvrfcgXtYNKrtBD> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				wiBPGDvFUUBIavEWhuSIVMNwIKCkA.omfOYSthvfxFOzvrfcgXtYNKrtBD omfOYSthvfxFOzvrfcgXtYNKrtBD = P_0[i];
				result += cRefESmqtsGRlFaYMepDDKUNooGoA(omfOYSthvfxFOzvrfcgXtYNKrtBD.OZrLUbmVszNAYtdqpGvGeqRxwPIu, omfOYSthvfxFOzvrfcgXtYNKrtBD.eGTwdyVsRArxyevZfnHlkMWJcZXd);
			}
			return result;
		}

		private Vector3 cRefESmqtsGRlFaYMepDDKUNooGoA(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int IFeMGeNELaNCdPBXCBZwZSVMkEEP(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void HVUOwkCbweoxemAwNFwiCUUzMpbX(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void SdgFWCDUaOyNlVnhBOyzDotrHljhA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float lFvhQbkYnFRmUVTzNPdfBSXTEnbi()
		{
			return cQnafXBGTGJchySiRvWOyvQCnQdr;
		}

		private void FDYTverqqAlPZHEjsICzeHbDCFkdA(NativeBuffer P_0, ECuuExxPnMTpiDfXAPmQzhehTPKT.TouchData[] P_1)
		{
			int num = 35 + vrOGeBSKOcEaNAlewnpJJolaZHcuA;
			int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
			int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
			int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
			int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
			byte b = P_0[num];
			bool flag = b < 128;
			byte num2 = P_0[num + 4];
			bool flag2 = num2 < 128;
			int num3 = b & 0x7F;
			int num4 = num2 & 0x7F;
			P_1[0].isTouching = flag;
			P_1[0].touchId = GJmmgNnqzhtQDvUkYFnFmayZcOOf(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = GJmmgNnqzhtQDvUkYFnFmayZcOOf(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int GJmmgNnqzhtQDvUkYFnFmayZcOOf(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				DezwcTLhkuwthFNHHcYUxBRqfqadA[P_0] = -1;
				SxVNAACSUFqsKZMcxKMgFQBxWpeF[P_0] = P_2;
				return -1;
			}
			if (P_2 != SxVNAACSUFqsKZMcxKMgFQBxWpeF[P_0])
			{
				int num = qSmCKvKeXrEEfHlFBbuOlkXwABGc;
				if (qSmCKvKeXrEEfHlFBbuOlkXwABGc == int.MaxValue)
				{
					qSmCKvKeXrEEfHlFBbuOlkXwABGc = 0;
				}
				else
				{
					qSmCKvKeXrEEfHlFBbuOlkXwABGc++;
				}
				SxVNAACSUFqsKZMcxKMgFQBxWpeF[P_0] = P_2;
				DezwcTLhkuwthFNHHcYUxBRqfqadA[P_0] = num;
				return num;
			}
			return DezwcTLhkuwthFNHHcYUxBRqfqadA[P_0];
		}

		private void oFzNEaMdANnIevjuvQCgCKMhujDE()
		{
			ojSyOAuCnkUVvuPBXFtbivMrwkheA = true;
			XNYBrkePBJVLeePBsttvVVGAKHLt();
		}

		private void suDGsjtpqBdBhFbGpxBoWPFwKbSaA()
		{
			aEgwTWAPJvQHejgJdyhffGcZYlGd = true;
			XNYBrkePBJVLeePBsttvVVGAKHLt();
		}

		private void vOaxGdTwxswvDmtwNqWgOKxQNRDd()
		{
			RUtmovfVmcdcSVmxxhDPwtUnVkye = true;
			XNYBrkePBJVLeePBsttvVVGAKHLt();
		}

		private void XNYBrkePBJVLeePBsttvVVGAKHLt()
		{
			FGHcDikKAMHkHbpKreScLJonrLnoA = true;
		}

		~DualShock4Driver()
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
				StopVibration();
				CYgFrKczPxUStflzVoGrbGEdeqVG(IpOusHhkFVHLPKjRNBUJTzZIWToMA.Synchronous);
				if (knkcfXWlOdVjqlTlarNxZebHvIXq != null)
				{
					knkcfXWlOdVjqlTlarNxZebHvIXq.Dispose();
				}
				if (MlLIqkJAhCYbQvTPKGiitgmcxwTC != null)
				{
					MlLIqkJAhCYbQvTPKGiitgmcxwTC.Dispose();
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			for (int i = 0; i < Consts.pidVids_sony_dualShock4.Count; i++)
			{
				if (Consts.pidVids_sony_dualShock4[i].vendorId == vid && Consts.pidVids_sony_dualShock4[i].productId == pid)
				{
					return true;
				}
			}
			return false;
		}

		[Conditional("DEBUG_THIS")]
		private static void hXWEpdkuJfQcvFNUbtyKkpfpwiQO(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
