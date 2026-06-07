using System;
using Rewired.ControllerExtensions;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualShock4Driver : HIDDeviceDriver, IDriver_DualShock4, IControllerDriver, IHIDControllerExtension, IDisposable
	{
		private enum HoNZqYBfovUxrcucXxMohxcgfiKm
		{
			None = 0,
			XZ = 1,
			Y = 2
		}

		private static class LFtZljwOSdxaEGdTzXewVrJXDKBl
		{
			public unsafe static uint LjgniRQzpUhtoCchFquUnOJEZoeI(byte* P_0, int P_1, uint P_2)
			{
				return 0u;
			}

			private unsafe static uint nLIvKIAPOJomNLSBkhsYdjMJttyf(uint P_0, byte* P_1, int P_2, uint P_3)
			{
				return 0u;
			}
		}

		private enum zxCbZRqqtmmWKNqbwvWQdMNZlYXK
		{
			Discharging = 0,
			Charging = 1,
			Full = 2,
			Unknown = 3
		}

		private readonly IHIDDevice CWbWFAHuAdKSkqCoKGFgBFfQtUQKA;

		private readonly HIDProperties qzcqxsvOdvKtvPDchdSXJviDIykLA;

		private readonly bool LRPKAiiAziutaCDILjOdlTBulxiE;

		private readonly gQgddHFyNfVGfPIXZPBcuigOMkbz vCuFOwupbXAwZDYXEGttCBuWIdQXA;

		private readonly int QXWKyAiDWecZQdFbDkZAoEtfbfabb;

		private readonly int dxVOdVvfNdiVJLVtEjFcFyxaDSit;

		private readonly bool cWMKHGmqMGgFlzIuJERVeLXwXrGTA;

		private readonly byte YGmqfnQDafkZTUGduMKWJzJATonI;

		private readonly int UtbjwpYJKgfhHULakGUDufZzLVzI;

		private readonly int UEhGzvqolsrVcuxPkhmeCpVDkuYX;

		private readonly int OplHRmaRfGQChJwelTKhFWzrESEr;

		private readonly int WHjXTmxOzpVjXstgnpiUWSZCNRBM;

		private readonly NativeBuffer ZNZNonYqKrLsmUSdiIqdRVRKEICt;

		private readonly NativeBuffer lLoYVSTQKILJSWDNIGdghdQnSvEeA;

		private readonly MwEMUNdEdQpngdbXMtjwIdOvEFgfA xhZVaAiKhhZyJTIRcLqchtgSjpYq;

		private readonly byte[] UtIFfzFpRZsIWnlPLjSHzlAjRjaqA;

		private bool mIolQKeSYQbvLAfWrDhyTVUqFVyp;

		private bool uqXnaxFKEdSDPmxPRSHutldpmVHP;

		private double WSOOyjnDkExcDZEpCdREdEZNjpzG;

		private int LBzaEwxBYXJdefGUAbKkIzzAazzoA;

		private zxCbZRqqtmmWKNqbwvWQdMNZlYXK zUEsTuRZxPwGtsHVxLCCIsWIOGyg;

		private Quaternion bXemivkxYCqAYjSVuqlIGMpAvOjv;

		private ushort ILiJiOgPUEWphOnDRACoyIkxcKvH;

		private float VyAolrNzNCmlnBhgXflAGimNnYaDA;

		private double SKnBqLJmRnXvbHwYZPEKicqmlfAh;

		private float FpbKkblYmKhLGvKOCUIapNJbXiH;

		private bool mDAHbNhxFwgqMwcidFENQaPkrRhWA;

		private bool fSBmSkviGQhaTViJYpNhwyawaNB;

		private bool HjDhneCOJpSPcAQilaJzvraEpYFVA;

		private bool EAtcMDBRwwDmwtoMcVSucXYQyWjgA;

		private byte OEGurMjmRvMLUqfPzJXkHKNWLEDX;

		private byte eewaTRNODAeLOIgEaCPZVvNemotE;

		private Quaternion EqlauxxVTtlsBXZAwFLeddnVERtDA;

		private Quaternion EoveIGygDgrkueVpPUspgKYIyscU;

		private bool lpIzAjRPeitdyNLAGLMOUdGmfrdg;

		private int PSlxNcEQoZBTKehjPHKsrvEnrSCw;

		private int[] aUQrJbRoZycRtqRPVdkMpzkdmydE;

		private int[] rDaLYuKvKJzhEuwqznImBejgYgli;

		private bool isVibrating => false;

		public float BatteryLevel => 0f;

		public bool BatteryCharging => false;

		public float LeftMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RightMotor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorR
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorG
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightColorB
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOnDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LightFlashOffDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 AccelerometerValue => default(Vector3);

		public Vector3 AccelerometerValueRaw => default(Vector3);

		public Vector3 GyroscopeValue => default(Vector3);

		public Vector3 GyroscopeValueRaw => default(Vector3);

		public Vector3 LastGyroscopeValue => default(Vector3);

		public Vector3 LastGyroscopeValueRaw => default(Vector3);

		public Quaternion Orientation => default(Quaternion);

		public int MaxTouches => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		public void ResetOrientation()
		{
		}

		public int GetTouchCount()
		{
			return 0;
		}

		public bool IsTouchingAtIndex(int index)
		{
			return false;
		}

		public bool IsTouchingAtTouchId(int touchId)
		{
			return false;
		}

		public int GetTouchIdAtIndex(int index)
		{
			return 0;
		}

		public bool GetTouchPositionByIndex(int index, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
		{
			positionX = default(int);
			positionY = default(int);
			return false;
		}

		public void StopLightFlash()
		{
		}

		public void StopVibration()
		{
		}

		public DualShock4Driver(InitArgs P_0)
		{
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			return false;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return null;
		}

		private void zpHLWakARvZTdSfjZbTbFjuyXwIFA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
		}

		private bool ysjqgdxiAPTuPKGeMzGtNbKNutiI(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private void RmoZJVwkFNLJfFdZSsZJHmOcNMYt()
		{
		}

		private bool wKkahjlpgraKxuAnxiEfAjEszePGA(pVnphHvTNRURYWZADvNPfpgNNbuB P_0)
		{
			return false;
		}

		private void qMbOWyPCMRgAehaWyRJyJUeUXCPE(NativeBuffer P_0, double P_1)
		{
		}

		private void AzHxhlYmvBlJqRdzpwOqUwMXKExD(tNSBtIwTqUeWpGtNoXsrdaEOoFDcA[] P_0, NativeBuffer P_1, double P_2)
		{
		}

		private void HKJqNxRVaOiAEBOyrAwmsUBnMfDR()
		{
		}

		private void itDiGauwXuBkjasTyjSYGIfgnJpc(NativeBuffer P_0)
		{
		}

		private void CFGWzirSFTusDFXWQOTPiOPgjeujA()
		{
		}

		private static bool PwdOakIvomqsooIJBcoNYczImWlO(ref Vector3 P_0)
		{
			return false;
		}

		private void FFTDGJbPMZijLeRBfJfYRsIOJoCQA(Vector3 P_0, Vector3 P_1)
		{
		}

		private Quaternion YpeFyGjWzYioKVuUBEOPnxePkOCE(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private Quaternion CPmGrjbRlVeOXQtGAZYwWETsRiTK(Vector3 P_0, float P_1 = 0f)
		{
			return default(Quaternion);
		}

		private bool oPFkClVVohqrSAmkPLtBxnOvdLyW(Vector3 P_0, out HoNZqYBfovUxrcucXxMohxcgfiKm P_1)
		{
			P_1 = default(HoNZqYBfovUxrcucXxMohxcgfiKm);
			return false;
		}

		private bool pFWUaAxXpWxSWlJAZtYtrbFplsV(Vector3 P_0)
		{
			return false;
		}

		private bool yseuzdhxLuLpKcjHZmVhxXbTbrvS(Vector3 P_0)
		{
			return false;
		}

		private Vector3 aKbEtaDnVwqMFhphAMwNJItPjLKCB(float[] P_0)
		{
			return default(Vector3);
		}

		private Vector3 wxRvSjCVdHIlKqadmNvJDSLBudUf(RingBuffer<XeuQUxbgIYfXehYWxYnOrZfhgALkA.NMUfRuddrxzsOdYlzmZPObqZgnUAb> P_0)
		{
			return default(Vector3);
		}

		private Vector3 LVZTRaomhgSMpeBUUEoXKxgAoHNK(Vector3 P_0, float P_1)
		{
			return default(Vector3);
		}

		private int bVDhNIAJRaaOjTcPSvyaqLdLoCLeA(int P_0)
		{
			return 0;
		}

		private void sQvMJCEggeitwLVoXFLcGEuwLpqTA(byte[] P_0, float[] P_1)
		{
		}

		private void ljLTLgGiFEKdbWGfJPllgyJwnUwF(byte[] P_0, float[] P_1)
		{
		}

		private float OWIQuZsnnBAQQkSxPYcbDQxIUYen()
		{
			return 0f;
		}

		private void ckpDAKvBoKzaBcxniGhfqxVCmDlt(NativeBuffer P_0, hwDBnDzZlOwqwaLOCXGWdEQuXFFf.TouchData[] P_1)
		{
		}

		private int zrJjtbnUdrpgJGKiObaDeLESFcPp(int P_0, bool P_1, int P_2)
		{
			return 0;
		}

		private void BvKYSyMehPsmaIoxdIrwYswmkoKQ()
		{
		}

		private void DsstyHneeFCAjCnYbgNaTjnnrDZI()
		{
		}

		private void IXVBcJaLygsbLVHjNcXwrEeXNNUIA()
		{
		}

		private void kOfNcIelXNjKsNiTyiSbJncRhLUQ()
		{
		}

		~DualShock4Driver()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public static bool Matches(int vid, int pid)
		{
			return false;
		}
	}
}
