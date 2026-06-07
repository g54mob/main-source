using System;
using System.Diagnostics;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDisposable, IHIDControllerExtension, IControllerDriver, IDriver_DualShock4
	{
		private enum aTPLNrYJJUEVrBnDaoRqbWpAPcNic
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		private enum iZsphDkzjPgceZFZIAIMNAGbcIMy
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class ioSfOaNFLNKVRhyqoaaQxTdEFiZW
		{
			private const uint KWChTeLvqYQxPvSMslAamtPXSCwT = 3988292384u;

			public unsafe static uint YhJJfzmaHygCFQBnzvwJUIiFvEzL(byte* P_0, int P_1, uint P_2)
			{
				return ~LItGAAdOdaxStDizJBTgIiCjGKYTA(LItGAAdOdaxStDizJBTgIiCjGKYTA(uint.MaxValue, (byte*)(&P_2), 1, 3988292384u), P_0, P_1, 3988292384u);
			}

			public unsafe static uint YhJJfzmaHygCFQBnzvwJUIiFvEzL(uint P_0, byte* P_1, int P_2)
			{
				return LItGAAdOdaxStDizJBTgIiCjGKYTA(P_0, P_1, P_2, 3988292384u);
			}

			private unsafe static uint LItGAAdOdaxStDizJBTgIiCjGKYTA(uint P_0, byte* P_1, int P_2, uint P_3)
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

		private enum SClfmAPogQiMJoCYbdnaXbISnARF
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private const float tsemGoiGnTwYdWptJfFTQNuugqoF = 4f;

		private const int CyZlyMvoGxSvfFEPCQWXSDYugSthA = 14;

		private const int KPGBMQetEpXJKzrVKDVmnoqvhRUS = 2;

		private const int mRZZGzsKnWFRPIOItEtsisXHlFOC = 0;

		private const int ObARokmSaxSwxLudqnodKrRXuHkj = 1912;

		private const int gdpkYxcBnblSxredwzYamWBEHyip = 0;

		private const int VTlEzzHNmzprZDWuHHStZvtEfvfwB = 941;

		private const bool telDkYGVBtedBDwzSPAQKElqlUkV = false;

		private const bool jhffanKCqvwXXWjBxUQBrOndBsk = true;

		private const float JlLXJoxpusxLwPchqfNMDoDCCJdx = 2.5f;

		private const int leJnkqTXdAnszzsTncRzwmgNbSsM = 0;

		private const int xmCyQEoOWzJUpjUBoHYUkTOOOWmV = 0;

		private const int QGsgOYlVHJkHvrEGmcmWWXzWnTxj = 1;

		private const int nFLrTqZdaBuurgqMsjrMqafMIakn = 0;

		private const int bitQdeonCxkERCyVLZJIBiFaAEqe = 0;

		private const int pgCxFpMPMCdogDnPCHepmPEwYjkA = 0;

		private const int IcWXAOwNCmIDvhQunxORfLNZetEU = 1;

		private const int maMJWDpeapGalFtFvVIaAmqBxfXv = 17;

		private const int QtFiUCuaaCLGeKyAIXejaoVeMFne = 0;

		private const int hXHCMsjkxTZVbbAlcjJPzZynvhxt = 2;

		private const int VcJFZzzlAWxckLPoSgLRIJnIAIgKA = 64;

		private const int HGmPYYeUBLObJVuxEpwQuxZwmnYL = 78;

		private const byte SXWbQBKzanlbyGBCrEXZbpcGLgatB = 17;

		private const byte YJKTFrNDFaJfEgYlSAWGifbycjhq = 5;

		private const byte XqJideYvYsnJYNJXhZFQlZwqINvT = 2;

		private const byte AjCjDoTUCfZKcNDpQPbjDypZxAUi = 37;

		private const byte kWreklrrlJFEhDdcTmCjlxynEfdeA = 5;

		private const byte kcccggexGSgHEvLFbMBlWDhNsSPpA = 41;

		private const byte QwdrNqrjuJXsyMoaGEFWjFrVWTg = 163;

		private const byte guLAuCBeGsbyWJgHaVGmChEIFlhhb = 49;

		private const byte iKtbGAOJJiUlVUkFXFEbaSfgORYv = 18;

		private const byte LvWADetOYBinvNqsXEOaKsfuHqqCA = 16;

		private const byte ZwxjLrqfWFnXKQxeRTxlVLIlOfoA = 161;

		private const byte AGyyyCrZOyHPHoXnwRxzNjZADsAb = 162;

		private const byte xiJBOKVpKsuXMGUiunlUsRcbcbZI = 163;

		private const int sWNhlJCHglDaihXCRvngWikmNBVHb = 1;

		private const int HqXVQRSJVgPIQblrYZCmzgiGpydI = 2;

		private const int MsvJxtmdpVdOOhMLUReJhTsviYKk = 3;

		private const int AlOEKvXMxBeKObUDlBbmCEFbgCug = 4;

		private const int kjKQMNmhuJzqlFQthLkKfeuVIJbr = 8;

		private const int tUFIAslParxoIjGXeAOsqtiiFcBhA = 9;

		private const int tjvozQOiprbtHoQRBtIsNGcYVQun = 5;

		private const int hJgcurfsBEmGSHXpCtOHISSTMJrh = 19;

		private const int RLHnjxibKzkpRRufWmugpYdzuDWT = 13;

		private const int KOXrSfwjkYqCJzTSwAsbsztyYSBk = 35;

		private const int zBuimTFhFSyNZlhxcrGNlcPGglBS = 5;

		private const int OdmIhKHnUMIqWwPSpQWKLzficJzP = 6;

		private const int qjJJDhdKVYNvzvPbVDAGrKQfeQSO = 7;

		private const int WIgtMvudrInuQxazYXJDhjopkICe = 10;

		private const int ADFDqbPlDqhxMWsdDWhxLsqULCCu = 30;

		private const int tOxSCnlvzDjKKaSrPOTqZpUMBBGv = 27;

		private const byte CDnVuGzjkggnBobTDIoSEljLJqhk = 200;

		private const byte qaobczFxOBXLsDDIMjWjUUACXfvo = 53;

		private const byte JieBYnijLSlfiuTPyLjvpZeMGREk = byte.MaxValue;

		private const byte EduujZCRGHpvbvnYpcKaqQLACzAR = 0;

		private const bool qsXwyHdXrnBXqDaPcUNZWMvKmwje = true;

		private const int GzzfocIhlInKVwzlafgqxzFxSqiw = 60;

		private const int deGkPuMobbJrFMjHCRlJpoaXpJLL = 60;

		private const int jXOyrGynIxpEfWfafdfXnDBwoSyj = 187500;

		private const float whwfQTJRzmAaqzgkTFbvWgHnPqbo = 8192f;

		private const float GOwfIbnoFdBTBhmOLxcYdaZAewPqA = 0.0010652969f;

		private const float OiKltqoCZGaIprKvlYpezBoMdIpKA = 0.06103702f;

		private const bool LZPNmAIpRvqbRCqKAimuhuseAlAe = true;

		private const bool fRyaNrdtlgpjGatKtYJCdPsWthdwA = true;

		private const bool ZxrJSNDWgOMpvpFudSgJSzHSVKZx = true;

		private const bool FCEqGtfCnuNPxqgDKUCzqYAUCFZf = true;

		private const float fPHicWCAjSHAhIEmENTKxOtawIMX = 4096f;

		private const float MBgnCtoZJkIYdIzaQglcrcalAKCA = 16384f;

		private const float PAGlSCxtGJEPnxGosdXYeuSAEPTQ = 16777216f;

		private const float INTDykiIVhStDQMCgRbcpocyRwnL = 268435460f;

		private const float qOxMphrEWpOuFVGYFuiYvCPRigiJ = 0.01999998f;

		private const float zibzPojNWfeVufFaiIyTUJUHqztjA = 8192f;

		private const float yGAUNhCGzxzPAfHnMZVNhjQPlVrA = 0.98f;

		private const float xJrhdlzydnUTqrjOPiHbNzeqIFfO = 45f;

		private const float IgFaONXZhPjsaXIBHJkieVlwaDdP = 20f;

		private readonly IHIDDevice ZdGAobiSJtgKVSSufZEKkbWOqrot;

		private readonly HIDProperties wZOmWuPOIaODgUnRVvZwyhfFATbk;

		private readonly bool urBDemPOotqBqeojOrfYeWijKhII;

		private readonly PWHRTOVLUXMumxboQQmQIFMHEBfDA oFudNlxKdMojthHdyMbeDRQwpyBN;

		private readonly int bRicqYdnNbwwHkipklylBEvnJrcNA;

		private readonly int hWEGHBdQlyQBbSeYolKFNefsBnwIA;

		private readonly bool lNGAvXlTjRBdbhRRCiLGCejbpaZqB;

		private readonly byte sFQUUpiRcaUTpVPFtzLehuIfiuRG;

		private readonly int etfeeqhRxzuXClxtntTdTmHsujQtA;

		private readonly int qGeivaAcooafAqvFgiGvXiMEZGyO;

		private readonly int jPWIgRUQhtNlfEChTUtzDBmifELs;

		private readonly int HPZrmGTWnrZtgFiDJjmKWZCFdazP;

		private readonly NativeBuffer WynDIcPUQZuoNwMFNYtngVTThDLT;

		private readonly NativeBuffer HuOJQfTacspCpPwKDklzixhSDESC;

		private readonly xDlFkKEEsqHDzeOiaTIGueyqTccYA OdRhINdCygWtgcGOteXZfFdHmxobc;

		private readonly byte[] LuqGUGYCuMQTKzlVJTHfpoNQkGyy = new byte[1] { 162 };

		private bool JwwdfVjOEMovpkhfbRzzYlOpNtUJA;

		private bool VjMpHRPfTGaObFjrIpMYdbRBFZwK;

		private double sCIFzfCzHxAEbILAFuKwqrPaMqHD;

		private int QpNjTZhmqPgwyuhnZLWPIEQjLOw;

		private SClfmAPogQiMJoCYbdnaXbISnARF rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Unknown;

		private Quaternion zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.identity;

		private ushort YdUSBXGmADBzvsDDenAWrLbOAHbjA;

		private float xovBdFFcqIfbcbSWcLDyghHqsQsCB;

		private double tjdhXOfoAURHJPKsmhoatrVWiMzrA;

		private float KJFRPDKQVBxSXCmhvQOymfaAHFbz;

		private bool OVJNuzGSXISHAQHTiBGlYCSfxkGQ;

		private bool KUhPIeClePflLeafXuKgGfSUkSIDb;

		private bool HFpsNCDBmpdeSObXktPyDcVbQdjU;

		private bool eyKWgxMCJQVxzFyOQBXrOzqNSvWu;

		private byte wfslEtjuqVKXJHXweSxJJjiowqm;

		private byte DxKYNRDuiUGcCDmfcKveDHZilumR;

		private Quaternion jFRykxwGKTjsZkdnrNHYIfHelnTub = Quaternion.identity;

		private Quaternion sGdFLqxnUgbhKukCZFnldilnADSL = Quaternion.identity;

		private bool yhuuHcCrIZplXsduuEJbHSUkNEBPA;

		private int ffwZpFaWwrqEGZPjlKUgfxhlkDJg;

		private int[] paQonnCmYRXNtoJynDGoZlnknPzR = new int[2];

		private int[] YbncaJsCCXzqLpAuGYVFXdcoWTgW = new int[2];

		private bool isVibrating
		{
			get
			{
				for (int i = 0; i < base.VibrationMotorCount; i++)
				{
					if (vibrationMotors[i].WPYNyFAdjBraRLgEqCcHbcfbsIkf > 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public float BatteryLevel => QpNjTZhmqPgwyuhnZLWPIEQjLOw;

		public bool BatteryCharging => rQVliytBRDhFlMdbZQcUqmSqLSBi == SClfmAPogQiMJoCYbdnaXbISnARF.Charging;

		public float LeftMotor
		{
			get
			{
				return vibrationMotors[0].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA;
			}
			set
			{
				vibrationMotors[0].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA = value;
			}
		}

		public float RightMotor
		{
			get
			{
				return vibrationMotors[1].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA;
			}
			set
			{
				vibrationMotors[1].EFmUVEpUcrIwRWHZCDJnLnIbiwvAA = value;
			}
		}

		public float LightColorR
		{
			get
			{
				return lights[0].XuilfXHvQLvtozMStdIqbvBZEvHA;
			}
			set
			{
				lights[0].XuilfXHvQLvtozMStdIqbvBZEvHA = value;
			}
		}

		public float LightColorG
		{
			get
			{
				return lights[0].QvbgjVpFXGFLuKKcqiINoDxhmJdy;
			}
			set
			{
				lights[0].QvbgjVpFXGFLuKKcqiINoDxhmJdy = value;
			}
		}

		public float LightColorB
		{
			get
			{
				return lights[0].KZjAKBRCqWvItsiSidTaxzXnlvlP;
			}
			set
			{
				lights[0].KZjAKBRCqWvItsiSidTaxzXnlvlP = value;
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return (int)wfslEtjuqVKXJHXweSxJJjiowqm;
			}
			set
			{
				wfslEtjuqVKXJHXweSxJJjiowqm = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				PjORlTFIHIgTRULpmSlDvHbOoYWJ();
				if (wfslEtjuqVKXJHXweSxJJjiowqm == 0 && DxKYNRDuiUGcCDmfcKveDHZilumR == 0)
				{
					VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
				}
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return (int)DxKYNRDuiUGcCDmfcKveDHZilumR;
			}
			set
			{
				DxKYNRDuiUGcCDmfcKveDHZilumR = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
				PjORlTFIHIgTRULpmSlDvHbOoYWJ();
				if (wfslEtjuqVKXJHXweSxJJjiowqm == 0 && DxKYNRDuiUGcCDmfcKveDHZilumR == 0)
				{
					VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
				}
			}
		}

		public Vector3 AccelerometerValue => KUxImQGffBiXidDYRrJBrGLNWqDJ(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui);

		public Vector3 AccelerometerValueRaw => new Vector3(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[0], accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[1], accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[2]);

		public Vector3 GyroscopeValue => QrjKifXGtFxeyUVcmWqYuAhTpTHt(gyroscopes[0].mOMEUBQyWiiPqJDJTDuPNharRHPG);

		public Vector3 GyroscopeValueRaw => new Vector3(gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[0], gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[1], gyroscopes[0].QGEPzKgIedvthGPliWOduwXNjWui[2]);

		public Vector3 LastGyroscopeValue
		{
			get
			{
				Vector3 vector = new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]);
				return QrjKifXGtFxeyUVcmWqYuAhTpTHt(vector, xovBdFFcqIfbcbSWcLDyghHqsQsCB);
			}
		}

		public Vector3 LastGyroscopeValueRaw => new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]);

		public Quaternion Orientation => zNUiIspBsYKIsgKmuPEojpgGhqIo;

		public int MaxTouches => 2;

		ushort IHIDControllerExtension.vendorId => wZOmWuPOIaODgUnRVvZwyhfFATbk.vendorId;

		ushort IHIDControllerExtension.productId => wZOmWuPOIaODgUnRVvZwyhfFATbk.productId;

		string IHIDControllerExtension.productName => wZOmWuPOIaODgUnRVvZwyhfFATbk.productName;

		string IHIDControllerExtension.manufacturer => wZOmWuPOIaODgUnRVvZwyhfFATbk.manufacturer;

		ushort IHIDControllerExtension.usagePage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usagePage;

		ushort IHIDControllerExtension.usage => wZOmWuPOIaODgUnRVvZwyhfFATbk.usage;

		public void ResetOrientation()
		{
			zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.identity;
			yhuuHcCrIZplXsduuEJbHSUkNEBPA = false;
		}

		public int GetTouchCount()
		{
			int num = 0;
			for (int i = 0; i < 2; i++)
			{
				if (touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					num++;
				}
			}
			return num;
		}

		public bool IsTouchingAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return false;
			}
			return touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId);
		}

		public int GetTouchIdAtIndex(int index)
		{
			if (index < 0 || index >= 2)
			{
				return -1;
			}
			return touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].touchId;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			if (index < 0 || index >= 2)
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			if (!vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching)
			{
				return false;
			}
			position.x = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionX;
			position.y = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionY;
			return true;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			if (!touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId))
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
			{
				if (vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					position.x = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionX;
					position.y = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionY;
				}
			}
			return true;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (index < 0 || index >= 2)
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			if (!vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].isTouching)
			{
				return false;
			}
			positionX = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionAbsX;
			positionY = vdoCmmimVgkttAEVHxTdgHVkQBPMb[index].positionAbsY;
			return true;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = 0;
			positionY = 0;
			if (!touchpads[0].zDrAPvbHymMENazrJhImBDpGdtFiA(touchId))
			{
				return false;
			}
			IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] vdoCmmimVgkttAEVHxTdgHVkQBPMb = touchpads[0].vdoCmmimVgkttAEVHxTdgHVkQBPMb;
			for (int i = 0; i < vdoCmmimVgkttAEVHxTdgHVkQBPMb.Length; i++)
			{
				if (vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].isTouching)
				{
					positionX = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionAbsX;
					positionY = vdoCmmimVgkttAEVHxTdgHVkQBPMb[i].positionAbsY;
				}
			}
			return true;
		}

		public void StopLightFlash()
		{
			wfslEtjuqVKXJHXweSxJJjiowqm = 0;
			DxKYNRDuiUGcCDmfcKveDHZilumR = 0;
			JwwdfVjOEMovpkhfbRzzYlOpNtUJA = true;
			VjMpHRPfTGaObFjrIpMYdbRBFZwK = true;
			HFpsNCDBmpdeSObXktPyDcVbQdjU = true;
		}

		public void StopVibration()
		{
			int vibrationMotorCount = base.VibrationMotorCount;
			for (int i = 0; i < vibrationMotorCount; i++)
			{
				vibrationMotors[i].WPYNyFAdjBraRLgEqCcHbcfbsIkf = 0;
			}
		}

		public DualShock4Driver(InitArgs P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			ZdGAobiSJtgKVSSufZEKkbWOqrot = P_0.hidDevice;
			wZOmWuPOIaODgUnRVvZwyhfFATbk = ZdGAobiSJtgKVSSufZEKkbWOqrot.properties;
			bRicqYdnNbwwHkipklylBEvnJrcNA = P_0.hatZeroValue;
			hWEGHBdQlyQBbSeYolKFNefsBnwIA = P_0.hatSpan;
			oFudNlxKdMojthHdyMbeDRQwpyBN = P_0.connectionType;
			urBDemPOotqBqeojOrfYeWijKhII = oFudNlxKdMojthHdyMbeDRQwpyBN == PWHRTOVLUXMumxboQQmQIFMHEBfDA.Bluetooth;
			if (urBDemPOotqBqeojOrfYeWijKhII)
			{
				wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength = 78;
			}
			if (wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength < 23)
			{
				wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength = 23;
			}
			WynDIcPUQZuoNwMFNYtngVTThDLT = new NativeBuffer(64);
			HuOJQfTacspCpPwKDklzixhSDESC = new NativeBuffer(wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength);
			OdRhINdCygWtgcGOteXZfFdHmxobc = new xDlFkKEEsqHDzeOiaTIGueyqTccYA(HuOJQfTacspCpPwKDklzixhSDESC.Pointer, HuOJQfTacspCpPwKDklzixhSDESC.Length, wZOmWuPOIaODgUnRVvZwyhfFATbk.maxOutputReportLength);
			lights = new wcZVsiHdENbhsBlZJfyeZHJzcruiA[1]
			{
				new wcZVsiHdENbhsBlZJfyeZHJzcruiA(11, 24, 28)
			};
			lights[0].jbfGSranhZTjcNFJQWUMIeosJyxS += TQxfqoBZgxeSCedyEAdfxZDhlJWGc;
			KUhPIeClePflLeafXuKgGfSUkSIDb = true;
			vibrationMotors = new pmTlTYxlhgTeYOMZqBSNaIrfQJzO[2]
			{
				new pmTlTYxlhgTeYOMZqBSNaIrfQJzO(0, 255),
				new pmTlTYxlhgTeYOMZqBSNaIrfQJzO(0, 255)
			};
			vibrationMotors[0].jbfGSranhZTjcNFJQWUMIeosJyxS += lOJpkPbYtoodKHIDNYCuqegQLeEh;
			vibrationMotors[1].jbfGSranhZTjcNFJQWUMIeosJyxS += lOJpkPbYtoodKHIDNYCuqegQLeEh;
			if (ZdGAobiSJtgKVSSufZEKkbWOqrot.GetHidFeatureData(2, 37, 1000, 3) == null)
			{
				throw new Exception();
			}
			eyKWgxMCJQVxzFyOQBXrOzqNSvWu = true;
			if (urBDemPOotqBqeojOrfYeWijKhII)
			{
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = true;
				OdRhINdCygWtgcGOteXZfFdHmxobc.vVKRiokJGjZFUsDfHXTaxdFOMKfy |= nKtbafSXrnTNPtOvtJxfpVimFmOA.WriteDirect;
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = ueVUxdtLNlEmviSBAGTegtixQTeF(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
				if (!lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
				{
					OdRhINdCygWtgcGOteXZfFdHmxobc.vVKRiokJGjZFUsDfHXTaxdFOMKfy &= ~nKtbafSXrnTNPtOvtJxfpVimFmOA.WriteDirect;
				}
			}
			else
			{
				lNGAvXlTjRBdbhRRCiLGCejbpaZqB = ueVUxdtLNlEmviSBAGTegtixQTeF(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
			}
			if (!lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				throw new Exception();
			}
			sFQUUpiRcaUTpVPFtzLehuIfiuRG = 1;
			etfeeqhRxzuXClxtntTdTmHsujQtA = 0;
			if (urBDemPOotqBqeojOrfYeWijKhII && lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				sFQUUpiRcaUTpVPFtzLehuIfiuRG = 17;
				etfeeqhRxzuXClxtntTdTmHsujQtA = 2;
			}
			qGeivaAcooafAqvFgiGvXiMEZGyO = 5 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			jPWIgRUQhtNlfEChTUtzDBmifELs = 6 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			HPZrmGTWnrZtgFiDJjmKWZCFdazP = 7 + etfeeqhRxzuXClxtntTdTmHsujQtA;
			buttons = new UGvkBdUzfogfxagdjdQqdinGSMwv[14];
			for (int i = 0; i < 14; i++)
			{
				buttons[i] = new UGvkBdUzfogfxagdjdQqdinGSMwv(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new vapXGbCthTfrBlIUGtkgzOtCLETf[6]
			{
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 3 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 53,
					dataIndex = 4 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 51,
					dataIndex = 8 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0),
				new vapXGbCthTfrBlIUGtkgzOtCLETf(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 52,
					dataIndex = 9 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 315,
					units = 0u,
					unitsExp = 0u
				}, false, 0)
			};
			hats = new DgGSAFeoadnaMFTBvLhTaezSCUDD[1]
			{
				new DgGSAFeoadnaMFTBvLhTaezSCUDD(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					usage = 57,
					dataIndex = 5 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 4,
					logicalMin = 0,
					logicalMax = 7,
					physicalMin = 0,
					physicalMax = 315,
					units = 20u,
					unitsExp = 0u
				}, seeiMBQfqrPHRiAGueuQwOdYDPRt)
			};
			accelerometers = new olIxPUWFAfTtYSNqDeGoXGwRumpd[1]
			{
				new olIxPUWFAfTtYSNqDeGoXGwRumpd(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 19 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 3, erEBmeCbXbRPzEwyuAMdkXOLvDNCA)
			};
			gyroscopes = new qVVbimaITgoplhjrKwIaqtLqwxTAc[1]
			{
				new qVVbimaITgoplhjrKwIaqtLqwxTAc(P_0.updateLoopSetting, sFQUUpiRcaUTpVPFtzLehuIfiuRG, new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 13 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 3, 60, vNZecraOwHroRIIkIlReqOExPAsZA, eRGGfDbEvCUvWHNhtrAJiLNjlgvMA)
			};
			touchpads = new IRcdnSIjiuKLhXFkJwhyNQabopZH[1]
			{
				new IRcdnSIjiuKLhXFkJwhyNQabopZH(sFQUUpiRcaUTpVPFtzLehuIfiuRG, new IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new YszNVDBZreQueMHaxAPTEUkXgqRz.HIDInfo
				{
					usagePage = 1,
					dataIndex = 35 + etfeeqhRxzuXClxtntTdTmHsujQtA,
					bitSize = 48
				}, 60, rKCJvNKrEVUPtKqKvbOjKsTsDOkhA)
			};
			tjdhXOfoAURHJPKsmhoatrVWiMzrA = ReInput.realTime;
		}

		public override void Update(UpdateLoopType updateLoop)
		{
			XpsptNOSAkuJQtpkRgrzactHjdaEb();
			IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous);
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < WynDIcPUQZuoNwMFNYtngVTThDLT.Length)
			{
				return false;
			}
			KJFRPDKQVBxSXCmhvQOymfaAHFbz = (float)(timestamp - tjdhXOfoAURHJPKsmhoatrVWiMzrA);
			tjdhXOfoAURHJPKsmhoatrVWiMzrA = timestamp;
			WynDIcPUQZuoNwMFNYtngVTThDLT.Write(inputReportPtr, inputReportLength, WynDIcPUQZuoNwMFNYtngVTThDLT.Length);
			CZtWNUYAvWJuKUZdOhPfRshdErFs(WynDIcPUQZuoNwMFNYtngVTThDLT);
			RdPFzuLpsssVUfJbWIHhRQPBGScT(WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			YszNVDBZreQueMHaxAPTEUkXgqRz[] array = axes;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = hats;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = accelerometers;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = gyroscopes;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			array = touchpads;
			tNFwFMIVpqJCnYRvDmgzNUNGOLYB(array, WynDIcPUQZuoNwMFNYtngVTThDLT, timestamp);
			byte num = WynDIcPUQZuoNwMFNYtngVTThDLT[30 + etfeeqhRxzuXClxtntTdTmHsujQtA];
			byte b = (byte)(num & 0xF);
			if ((num & 0x10) != 0)
			{
				if (b <= 10)
				{
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = MathTools.Clamp(b * 10 + 5, 0, 100);
					rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Charging;
				}
				else
				{
					switch (b)
					{
					case 11:
						QpNjTZhmqPgwyuhnZLWPIEQjLOw = 100;
						rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Full;
						break;
					case 14:
						QpNjTZhmqPgwyuhnZLWPIEQjLOw = 0;
						rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Charging;
						break;
					default:
						QpNjTZhmqPgwyuhnZLWPIEQjLOw = 0;
						rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Unknown;
						break;
					}
				}
			}
			else
			{
				switch (MathTools.Clamp((int)b, 0, 8))
				{
				case 0:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 5;
					break;
				case 1:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 20;
					break;
				case 2:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 30;
					break;
				case 3:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 45;
					break;
				case 4:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 55;
					break;
				case 5:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 70;
					break;
				case 6:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 80;
					break;
				case 7:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 95;
					break;
				case 8:
					QpNjTZhmqPgwyuhnZLWPIEQjLOw = 100;
					break;
				}
				rQVliytBRDhFlMdbZQcUqmSqLSBi = SClfmAPogQiMJoCYbdnaXbISnARF.Discharging;
			}
			QWsQgHoNItqERAYRrEUeWKzUEOwx();
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new DualShock4Extension(this);
		}

		private void IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			if (JwwdfVjOEMovpkhfbRzzYlOpNtUJA)
			{
				ueVUxdtLNlEmviSBAGTegtixQTeF(P_0);
				JwwdfVjOEMovpkhfbRzzYlOpNtUJA = false;
			}
		}

		private bool ueVUxdtLNlEmviSBAGTegtixQTeF(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			TeBejrASFvqxZaiiEktdanDSFjglb();
			bool result = aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0);
			if (VjMpHRPfTGaObFjrIpMYdbRBFZwK)
			{
				result = aclPpaLxnqyTLVJMfezZhuMzsQcg(P_0);
				VjMpHRPfTGaObFjrIpMYdbRBFZwK = false;
			}
			return result;
		}

		private unsafe void TeBejrASFvqxZaiiEktdanDSFjglb()
		{
			byte b = 0;
			b |= 1;
			OVJNuzGSXISHAQHTiBGlYCSfxkGQ = false;
			b |= 2;
			KUhPIeClePflLeafXuKgGfSUkSIDb = false;
			b |= 4;
			HFpsNCDBmpdeSObXktPyDcVbQdjU = false;
			byte b2 = 128;
			if (urBDemPOotqBqeojOrfYeWijKhII)
			{
				b2 |= 0x40;
			}
			if (eyKWgxMCJQVxzFyOQBXrOzqNSvWu)
			{
				b2 |= 4;
				eyKWgxMCJQVxzFyOQBXrOzqNSvWu = false;
			}
			if (urBDemPOotqBqeojOrfYeWijKhII && lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				HuOJQfTacspCpPwKDklzixhSDESC[0] = 17;
				HuOJQfTacspCpPwKDklzixhSDESC[1] = b2;
				HuOJQfTacspCpPwKDklzixhSDESC[2] = 0;
				HuOJQfTacspCpPwKDklzixhSDESC[3] = b;
				HuOJQfTacspCpPwKDklzixhSDESC[4] = 0;
				HuOJQfTacspCpPwKDklzixhSDESC[5] = 0;
				HuOJQfTacspCpPwKDklzixhSDESC[6] = (byte)vibrationMotors[1].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
				HuOJQfTacspCpPwKDklzixhSDESC[7] = (byte)vibrationMotors[0].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
				HuOJQfTacspCpPwKDklzixhSDESC[8] = lights[0].qliHrwMycrHSwdrYkWwBtKZLSFkj;
				HuOJQfTacspCpPwKDklzixhSDESC[9] = lights[0].lVKGsWgUBkpHMUSOdQPuLcJjaZjiA;
				HuOJQfTacspCpPwKDklzixhSDESC[10] = lights[0].pkPiWyPinEsSkuGqQARVqCeMkJuv;
				HuOJQfTacspCpPwKDklzixhSDESC[11] = wfslEtjuqVKXJHXweSxJJjiowqm;
				HuOJQfTacspCpPwKDklzixhSDESC[12] = DxKYNRDuiUGcCDmfcKveDHZilumR;
				int muWgIwfZykaHnaQEEYPetzSeXIsSA = OdRhINdCygWtgcGOteXZfFdHmxobc.muWgIwfZykaHnaQEEYPetzSeXIsSA;
				uint bytes = ioSfOaNFLNKVRhyqoaaQxTdEFiZW.YhJJfzmaHygCFQBnzvwJUIiFvEzL((byte*)(void*)HuOJQfTacspCpPwKDklzixhSDESC.Pointer, muWgIwfZykaHnaQEEYPetzSeXIsSA - 4, 162u);
				HuOJQfTacspCpPwKDklzixhSDESC.Write(bytes, muWgIwfZykaHnaQEEYPetzSeXIsSA - 4);
			}
			else
			{
				HuOJQfTacspCpPwKDklzixhSDESC[0] = 5;
				HuOJQfTacspCpPwKDklzixhSDESC[1] = b;
				HuOJQfTacspCpPwKDklzixhSDESC[2] = 0;
				HuOJQfTacspCpPwKDklzixhSDESC[4] = (byte)vibrationMotors[1].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
				HuOJQfTacspCpPwKDklzixhSDESC[5] = (byte)vibrationMotors[0].WPYNyFAdjBraRLgEqCcHbcfbsIkf;
				HuOJQfTacspCpPwKDklzixhSDESC[6] = lights[0].qliHrwMycrHSwdrYkWwBtKZLSFkj;
				HuOJQfTacspCpPwKDklzixhSDESC[7] = lights[0].lVKGsWgUBkpHMUSOdQPuLcJjaZjiA;
				HuOJQfTacspCpPwKDklzixhSDESC[8] = lights[0].pkPiWyPinEsSkuGqQARVqCeMkJuv;
				HuOJQfTacspCpPwKDklzixhSDESC[9] = wfslEtjuqVKXJHXweSxJJjiowqm;
				HuOJQfTacspCpPwKDklzixhSDESC[10] = DxKYNRDuiUGcCDmfcKveDHZilumR;
			}
		}

		private bool aclPpaLxnqyTLVJMfezZhuMzsQcg(AdGZaeWqClcGEbNkSQklXlRYcQrJ P_0)
		{
			sCIFzfCzHxAEbILAFuKwqrPaMqHD = ReInput.realTime + 4.0;
			switch (P_0)
			{
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous:
				return ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteSync(OdRhINdCygWtgcGOteXZfFdHmxobc, 0);
			case AdGZaeWqClcGEbNkSQklXlRYcQrJ.Asynchronous:
				ZdGAobiSJtgKVSSufZEKkbWOqrot.WriteAsync(OdRhINdCygWtgcGOteXZfFdHmxobc, 1000);
				return true;
			default:
				throw new NotImplementedException();
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT(NativeBuffer P_0, double P_1)
		{
			byte b = P_0[qGeivaAcooafAqvFgiGvXiMEZGyO];
			buttons[0].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x10) != 0, P_1);
			buttons[1].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, P_1);
			buttons[2].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x40) != 0, P_1);
			buttons[3].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x80) != 0, P_1);
			b = P_0[jPWIgRUQhtNlfEChTUtzDBmifELs];
			buttons[4].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, P_1);
			buttons[5].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, P_1);
			buttons[6].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 4) != 0, P_1);
			buttons[7].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 8) != 0, P_1);
			buttons[8].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x10) != 0, P_1);
			buttons[9].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x20) != 0, P_1);
			buttons[10].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x40) != 0, P_1);
			buttons[11].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 0x80) != 0, P_1);
			b = P_0[HPZrmGTWnrZtgFiDJjmKWZCFdazP];
			buttons[12].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 1) != 0, P_1);
			buttons[13].uqcjdwWGLmpPBtHzkpeQnIbXtmIb((b & 2) != 0, P_1);
		}

		private void tNFwFMIVpqJCnYRvDmgzNUNGOLYB(YszNVDBZreQueMHaxAPTEUkXgqRz[] P_0, NativeBuffer P_1, double P_2)
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i].trsfRiBFSIjLrLMemKcGjgULCoSi(P_1, P_2);
			}
		}

		private void XpsptNOSAkuJQtpkRgrzactHjdaEb()
		{
			if (isVibrating && ReInput.realTime >= sCIFzfCzHxAEbILAFuKwqrPaMqHD)
			{
				JwwdfVjOEMovpkhfbRzzYlOpNtUJA = true;
				OVJNuzGSXISHAQHTiBGlYCSfxkGQ = true;
			}
		}

		private void CZtWNUYAvWJuKUZdOhPfRshdErFs(NativeBuffer P_0)
		{
			if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				ushort num = WynDIcPUQZuoNwMFNYtngVTThDLT.ReadUShort(10 + etfeeqhRxzuXClxtntTdTmHsujQtA);
				float num3;
				if (num != YdUSBXGmADBzvsDDenAWrLbOAHbjA)
				{
					int num2 = ((num >= YdUSBXGmADBzvsDDenAWrLbOAHbjA) ? (num - YdUSBXGmADBzvsDDenAWrLbOAHbjA) : (num + 65535 - YdUSBXGmADBzvsDDenAWrLbOAHbjA));
					num3 = (float)num2 / 187500f;
				}
				else
				{
					int num2 = 0;
					num3 = 0f;
				}
				YdUSBXGmADBzvsDDenAWrLbOAHbjA = num;
				xovBdFFcqIfbcbSWcLDyghHqsQsCB = num3;
			}
		}

		private void QWsQgHoNItqERAYRrEUeWKzUEOwx()
		{
			if (lNGAvXlTjRBdbhRRCiLGCejbpaZqB)
			{
				_ = xovBdFFcqIfbcbSWcLDyghHqsQsCB;
				_ = 0f;
				Vector3 vector = QrjKifXGtFxeyUVcmWqYuAhTpTHt(new Vector3(gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[0], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[1], gyroscopes[0].byxGkOgARwUJQCPZJukQPfWRpXkj[2]), xovBdFFcqIfbcbSWcLDyghHqsQsCB);
				dFnDnxElNKgtXEnRVWUipJIPCNBQA(ref vector);
				Vector3 vector2 = new Vector3(accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[0] * -1f, accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[1] * -1f, accelerometers[0].QGEPzKgIedvthGPliWOduwXNjWui[2] * -1f);
				HZKiaolXvBivPROkYyFrEIrCphrs(vector2, vector);
			}
		}

		private static bool dFnDnxElNKgtXEnRVWUipJIPCNBQA(ref Vector3 P_0)
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

		private void HZKiaolXvBivPROkYyFrEIrCphrs(Vector3 P_0, Vector3 P_1)
		{
			Quaternion quaternion = Quaternion.Euler(P_1);
			float sqrMagnitude = P_0.sqrMagnitude;
			if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && qIpsAUbaZFbDTkpjgqZfuOsIYnKo(P_0, out var iZsphDkzjPgceZFZIAIMNAGbcIMy2))
			{
				Quaternion a = zNUiIspBsYKIsgKmuPEojpgGhqIo * quaternion;
				if (!yhuuHcCrIZplXsduuEJbHSUkNEBPA)
				{
					yhuuHcCrIZplXsduuEJbHSUkNEBPA = true;
					jFRykxwGKTjsZkdnrNHYIfHelnTub = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
					sGdFLqxnUgbhKukCZFnldilnADSL = zNUiIspBsYKIsgKmuPEojpgGhqIo;
				}
				jFRykxwGKTjsZkdnrNHYIfHelnTub *= quaternion;
				sGdFLqxnUgbhKukCZFnldilnADSL *= quaternion;
				Quaternion b;
				if ((iZsphDkzjPgceZFZIAIMNAGbcIMy2 & iZsphDkzjPgceZFZIAIMNAGbcIMy.XZ) != iZsphDkzjPgceZFZIAIMNAGbcIMy.None)
				{
					b = PMPEUgxgyCoEmYVVZhImehqvEfad(P_0, a.eulerAngles.y);
				}
				else if ((iZsphDkzjPgceZFZIAIMNAGbcIMy2 & iZsphDkzjPgceZFZIAIMNAGbcIMy.Y) != iZsphDkzjPgceZFZIAIMNAGbcIMy.None)
				{
					b = AaabVIrfEjjkNlrbTOyjoDwtNxxv(P_0);
					Vector3 vector = sGdFLqxnUgbhKukCZFnldilnADSL * Vector3.right;
					float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
					b = Quaternion.Euler(0f, y, 0f) * b;
				}
				else
				{
					b = Quaternion.identity;
				}
				zNUiIspBsYKIsgKmuPEojpgGhqIo = Quaternion.Lerp(a, b, 0.01999998f);
			}
			else
			{
				zNUiIspBsYKIsgKmuPEojpgGhqIo *= quaternion;
				if (yhuuHcCrIZplXsduuEJbHSUkNEBPA)
				{
					yhuuHcCrIZplXsduuEJbHSUkNEBPA = false;
				}
			}
		}

		private static Quaternion cXxseHLUaEhifswqgmWtKVFwdTWn(Quaternion P_0, Vector3 P_1)
		{
			Vector3 vector = OqtoErTcVPvPdrpqqzJEphTTxQGE(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
			return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
		}

		private static Vector3 OqtoErTcVPvPdrpqqzJEphTTxQGE(Vector3 P_0, Vector3 P_1)
		{
			float num = Vector3.Dot(P_1, P_1);
			if (num < float.Epsilon)
			{
				return Vector3.zero;
			}
			return P_1 * Vector3.Dot(P_0, P_1) / num;
		}

		private Quaternion yhNbdZBJgEIBisZARTEFEcepeNVl(Quaternion P_0, aTPLNrYJJUEVrBnDaoRqbWpAPcNic P_1)
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

		private float AWKzCjWURPkhuupwummLqjLEgjsw(float P_0, float P_1)
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

		private Vector3 UAqhiPKGQilDpaCJcSNVnNiUHvEKB(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return new Vector3(x, P_1, z);
		}

		private Quaternion PMPEUgxgyCoEmYVVZhImehqvEfad(Vector3 P_0, float P_1 = 0f)
		{
			float num = MathTools.Atan2(P_0.z, P_0.y);
			float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
			float x = num * 57.29578f + 180f;
			float z = (0f - num2) * 57.29578f;
			return Quaternion.Euler(x, P_1, z);
		}

		private Quaternion AaabVIrfEjjkNlrbTOyjoDwtNxxv(Vector3 P_0, float P_1 = 0f)
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

		private float wRmigcEVcERbvhnvYpyTBlPNJbhE(Vector3 P_0)
		{
			return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
		}

		private bool fOZhcxcWmvvaZnuMNRPPCaZNbwoo(float P_0)
		{
			if (P_0 >= 45f)
			{
				return P_0 <= 70f;
			}
			return false;
		}

		private bool qIpsAUbaZFbDTkpjgqZfuOsIYnKo(Vector3 P_0, out iZsphDkzjPgceZFZIAIMNAGbcIMy P_1)
		{
			P_0.Normalize();
			P_1 = iZsphDkzjPgceZFZIAIMNAGbcIMy.None;
			bool result = false;
			if (SviVhuZgtvsMQyoeJPIjegrZgEfb(P_0))
			{
				result = true;
				P_1 |= iZsphDkzjPgceZFZIAIMNAGbcIMy.XZ;
			}
			if (ttIigsljASzcBEnoKgMofdIeagUTA(P_0))
			{
				result = true;
				P_1 |= iZsphDkzjPgceZFZIAIMNAGbcIMy.Y;
			}
			return result;
		}

		private bool SviVhuZgtvsMQyoeJPIjegrZgEfb(Vector3 P_0)
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

		private bool ttIigsljASzcBEnoKgMofdIeagUTA(Vector3 P_0)
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

		private Vector3 KUxImQGffBiXidDYRrJBrGLNWqDJ(float[] P_0)
		{
			return new Vector3(P_0[0] * 0.00012207031f * -1f, P_0[1] * 0.00012207031f * -1f, P_0[2] * 0.00012207031f);
		}

		private Vector3 QrjKifXGtFxeyUVcmWqYuAhTpTHt(RingBuffer<qVVbimaITgoplhjrKwIaqtLqwxTAc.RabBRypoXYAJwkbCIuOqggayIjHt> P_0)
		{
			Vector3 result = default(Vector3);
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				qVVbimaITgoplhjrKwIaqtLqwxTAc.RabBRypoXYAJwkbCIuOqggayIjHt rabBRypoXYAJwkbCIuOqggayIjHt = P_0[i];
				result += QrjKifXGtFxeyUVcmWqYuAhTpTHt(rabBRypoXYAJwkbCIuOqggayIjHt.QGEPzKgIedvthGPliWOduwXNjWui, rabBRypoXYAJwkbCIuOqggayIjHt.rUDxkIqFCKfJYnEJOjJtlBdnXVRN);
			}
			return result;
		}

		private Vector3 QrjKifXGtFxeyUVcmWqYuAhTpTHt(Vector3 P_0, float P_1)
		{
			P_0.x *= -1f;
			P_0.y *= -1f;
			return P_0 * 0.06103702f * P_1;
		}

		private int seeiMBQfqrPHRiAGueuQwOdYDPRt(int P_0)
		{
			P_0 &= 0xF;
			return P_0;
		}

		private void erEBmeCbXbRPzEwyuAMdkXOLvDNCA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private void vNZecraOwHroRIIkIlReqOExPAsZA(byte[] P_0, float[] P_1)
		{
			P_1[0] = BitConverter.ToInt16(P_0, 0);
			P_1[1] = BitConverter.ToInt16(P_0, 2);
			P_1[2] = BitConverter.ToInt16(P_0, 4);
		}

		private float eRGGfDbEvCUvWHNhtrAJiLNjlgvMA()
		{
			return xovBdFFcqIfbcbSWcLDyghHqsQsCB;
		}

		private void rKCJvNKrEVUPtKqKvbOjKsTsDOkhA(NativeBuffer P_0, IRcdnSIjiuKLhXFkJwhyNQabopZH.TouchData[] P_1)
		{
			int num = 35 + etfeeqhRxzuXClxtntTdTmHsujQtA;
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
			P_1[0].touchId = rtxRKpGowIXKJGnkCWDEvLcjQEQV(0, flag, num3);
			P_1[0].positionRawX = positionRawX;
			P_1[0].positionRawY = positionRawY;
			P_1[1].isTouching = flag2;
			P_1[1].touchId = rtxRKpGowIXKJGnkCWDEvLcjQEQV(1, flag2, num4);
			P_1[1].positionRawX = positionRawX2;
			P_1[1].positionRawY = positionRawY2;
		}

		private int rtxRKpGowIXKJGnkCWDEvLcjQEQV(int P_0, bool P_1, int P_2)
		{
			if (!P_1)
			{
				paQonnCmYRXNtoJynDGoZlnknPzR[P_0] = -1;
				YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0] = P_2;
				return -1;
			}
			if (P_2 != YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0])
			{
				int num = ffwZpFaWwrqEGZPjlKUgfxhlkDJg;
				if (ffwZpFaWwrqEGZPjlKUgfxhlkDJg == int.MaxValue)
				{
					ffwZpFaWwrqEGZPjlKUgfxhlkDJg = 0;
				}
				else
				{
					ffwZpFaWwrqEGZPjlKUgfxhlkDJg++;
				}
				YbncaJsCCXzqLpAuGYVFXdcoWTgW[P_0] = P_2;
				paQonnCmYRXNtoJynDGoZlnknPzR[P_0] = num;
				return num;
			}
			return paQonnCmYRXNtoJynDGoZlnknPzR[P_0];
		}

		private void TQxfqoBZgxeSCedyEAdfxZDhlJWGc()
		{
			KUhPIeClePflLeafXuKgGfSUkSIDb = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void PjORlTFIHIgTRULpmSlDvHbOoYWJ()
		{
			HFpsNCDBmpdeSObXktPyDcVbQdjU = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void lOJpkPbYtoodKHIDNYCuqegQLeEh()
		{
			OVJNuzGSXISHAQHTiBGlYCSfxkGQ = true;
			gmdQklpwzAYKUmtJdmvUNiAWBKqi();
		}

		private void gmdQklpwzAYKUmtJdmvUNiAWBKqi()
		{
			JwwdfVjOEMovpkhfbRzzYlOpNtUJA = true;
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
				IPxBlkRXLfFPWhuMRfsCTwsdWDubA(AdGZaeWqClcGEbNkSQklXlRYcQrJ.Synchronous);
				if (WynDIcPUQZuoNwMFNYtngVTThDLT != null)
				{
					WynDIcPUQZuoNwMFNYtngVTThDLT.Dispose();
				}
				if (HuOJQfTacspCpPwKDklzixhSDESC != null)
				{
					HuOJQfTacspCpPwKDklzixhSDESC.Dispose();
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
		private static void xspmGHIIbuJrRYkaewzNNrGOWdCm(object P_0)
		{
			Logger.Log(P_0, requiredThreadSafety: true);
		}
	}
}
