using System.Collections.Generic;
using Rewired.Platforms.Custom;

namespace Rewired.Platforms.XboxOne
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
	{
		[CustomObfuscation]
		private enum BadConnectionReason
		{
			[CustomObfuscation]
			None = 0,
			[CustomObfuscation]
			GamepadNotActive = 1,
			[CustomObfuscation]
			InvalidName = 2
		}

		private struct QXQEHVGaQGqSIDZbhklJhBHjtRs
		{
			public uint DsZpLHPtvudxrwmVrmzgjEbaGnS;

			public uint iScEsJTlTpmDzlhOrFhkrgASDYH;

			public QXQEHVGaQGqSIDZbhklJhBHjtRs(uint unityJoystickId, uint connectedFrame)
			{
				DsZpLHPtvudxrwmVrmzgjEbaGnS = 0u;
				iScEsJTlTpmDzlhOrFhkrgASDYH = 0u;
			}
		}

		private class ezFDIpazoFVfDniRXPlTtlLkIAq : Joystick
		{
			private const int qKQydGYzZiFdavuuXkrbxuGVdee = 6;

			private const int MPfcFHBAqdEVRKAwFPIsRPrJOKNM = 14;

			private const string TMqMhZinfXHujqsKTZCsmCIOhlZ = "Xbox One Controller";

			private const int oskQHlXxLdQURyRftQMYGGPcAXi = 0;

			private const int JpLlFVexoTiZoVbbZgvVqFCjAXF = 1;

			private const int abVOCKKdkOPQjNbRNaVNKBqLtSY = 2;

			private const int JlvvkfackXtYdWipCmfuTxkZnKU = 3;

			private const int UnzijzvVKUPowvRvIoFBodAZBLo = 4;

			private const int xENGATbRvgHuHcQldssSihvWrgZe = 5;

			private const int RrqLYcFfMogGIORdLSaecpfogqh = 6;

			private const int gydKUetBoEybBewZttnQcFBAHiaB = 7;

			private const int ANBcUWubfIjIBusjnBSLFyOCFNqs = 8;

			private const int cssehDDRJDfCDtnzLxlRJLgwUdGh = 9;

			private const int JANSFlGcJQINUDQURxlamkeksdKg = 12;

			private const int ACFpUEgLjoBjXhGqlSyHrJtkKdzj = 13;

			private const int mmKJcJwvjJZtWGJBrxURkViNfnD = 14;

			private const int idxyBEFDIOMMRjRFkUsFHoWUjBm = 15;

			private const int eLXIbEjenHWRPAkxKGJdpCbOjbY = 0;

			private const int TvqIMyDHTbeyXyfyULRVufZUDsOc = 1;

			private const int UMNyglLjlpZhTRuhnmwEtEbWluJ = 3;

			private const int BAQeHHrONszuzsMwoiHKbDnMIhF = 4;

			private const int eEyPUMQXNHaBPQhTNBmMUPuFCXMd = 8;

			private const int NubREVKzCwaJbLusTGJnyaYAzgG = 9;

			private readonly IXboxOneInputSource dnfAWeiIBXMpBFlZiOlXhVnVQAbk;

			private int eoALexHkaDZgfvBrLbQAzagdEOjj;

			private ulong nTeIfDAZLIvHvXSZEVnboXQuZJf;

			private string[] SBgmepWsKgWVyMgmcpfAZMGhtPN;

			public ulong xboxControllerId => 0uL;

			public ezFDIpazoFVfDniRXPlTtlLkIAq(IXboxOneInputSource inputSource, ulong xboxControllerId, int unityJoystickId, bool isConnected)
				: base(null, null, 0, 0, 0)
			{
			}

			public override void Update()
			{
			}

			public void nKQbCtkHPOPnqlOqEQhEesshditg(ulong P_0)
			{
			}

			private void QqZeOLdWEjPjIBfLhDEvtsNSapID()
			{
			}

			private bool GcQePpiafhoRDeIbiFcQbxTpLzm(int P_0)
			{
				return false;
			}

			private void xnfEtIFkhntQyqzVUxgpFmLxfVz()
			{
			}
		}

		private const int dCOkyaFmGizaRLRxdYcaxKZIlJe = 8;

		private readonly bool xkHHODSPHleoVLjIPrRKYmhhPZj;

		private bool OPbpTFhfzbBMBZANACumchjfPKdl;

		private Queue<QXQEHVGaQGqSIDZbhklJhBHjtRs> dqrlHjJdblahraSMLMyTkSjRWdP;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

		public override bool isReady => false;

		public XboxOneInputSource()
			: base(0)
		{
		}

		public override void Update()
		{
		}

		private void nKSMxgRTIQlekEGgIVMNlXcRWUr(uint P_0, bool P_1)
		{
		}

		private void RaMzrxmfTnOMQLHfAnoamNELjFG(uint P_0, bool P_1)
		{
		}

		private void mKjGsXgCYBbEQseswpsvjQsOrtS()
		{
		}

		private bool JdBHIaSachpzxheoROWDFdVxeCmI(uint P_0, bool P_1, out BadConnectionReason P_2)
		{
			P_2 = default(BadConnectionReason);
			return false;
		}

		private void FQCcEJBDrBjrhJWVoIgOhEwUIKT()
		{
		}

		public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
		{
			return 0;
		}

		public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
		}

		public bool SetXboxOneVibration(ulong xboxOneJoystickId, UaxwQGXMeryxvUqRPjBsAQxhpCj vibration)
		{
			return false;
		}

		public override void Dispose()
		{
		}

		~XboxOneInputSource()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
