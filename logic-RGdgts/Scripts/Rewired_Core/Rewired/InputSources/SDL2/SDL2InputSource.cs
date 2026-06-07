using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void AmiACoqEiQFZzSlBSdqojoEPdGMe(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void bDLjtxiUFYFYqqIDeCJckETtivzfA(int joystickIndex);

		public delegate void jNIOWRiBBKMyxhbVuZCsOQipgWvB(int joystickId);

		public delegate void VclmKCasvxPCZSmmfzpRIZqGQiIU(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int JZtfKKPmtknTEsACbivfNagQQMYQ = 32;

		private bool BrFYCbSJfjRysPkarCLQvqAUmUSM;

		private bool QsHHfEAIztfGdACcAeeKYpjxYJXe;

		private bool lEJSPZmAzmnnByCILEkerWjAiZZbA;

		private bool KWqGvDitOLDGSIdkcqFCrbSWiIuhB;

		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private ADictionary<int, ADSKVxZJSFkDyMGJKnlKUBorZhuD> elKJbbxESyfcuzfcxFoUDTJZIhcJA;

		private ADictionary<int, gQYWqRhlmkWRkkrRpWjcmQltnfCL> YzmazhdNyVRyvbgJvbrvquZTCtpx;

		private xfYwdkRYAVrddGoiGqMNEgTVIqto.qVAbBFgjWczrDUCIgDEVvTAJhbNBb xqjRBKmBgGWalphoyBSrItlLGfyAb;

		private NativeBuffer IMhljfcLIgpTYZKpSUiJBBZxGFGx;

		[CompilerGenerated]
		private Action UYEcHrxIOUarqiNClIAJzCCXSryJ;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool initialized => false;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
		{
		}

		public void SystemDeviceConnected()
		{
		}

		public void SystemDeviceDisconnected()
		{
		}

		public void Update()
		{
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
		}

		public void UpdateFinished()
		{
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			return null;
		}

		private int MDudWcexNvUPNZuZENGqpwqvTAFA()
		{
			return 0;
		}

		private int CTkduoCFWBLgaCGeQRuxfxSMRrDlA()
		{
			return 0;
		}

		private ADSKVxZJSFkDyMGJKnlKUBorZhuD dwPoEFGcpWZTODGyaNCFWKxFdYUHA(int P_0)
		{
			return null;
		}

		private gQYWqRhlmkWRkkrRpWjcmQltnfCL FqcyCfMalNQeZDyaliHtiOqVbxBL(int P_0)
		{
			return null;
		}

		private dpvxMMmJEhBJrUwdSFTnDVVoyLgw qXJbFgeAgSmrofvEOPAITEmHlXhSA(int P_0, TWLwCilJIoPozLulqzpoQBubYmDC P_1)
		{
			return null;
		}

		private dpvxMMmJEhBJrUwdSFTnDVVoyLgw cSsWaASwRkIUXGhSrpzXBDJhdtVDA(int P_0, SqcPYTpnQyvIBscTNAfMBNAZXxSE P_1)
		{
			return null;
		}

		private void oVlbKMRYhwrmiJFaNiOvEjhfDyBe()
		{
		}

		private void EikcTvTdaExfWNJzdaSwbKDiYhej()
		{
		}

		private bool zATZtKwijtiXAsAuMoaoeUTntTAC(int P_0)
		{
			return false;
		}

		private void BLeFCCClaKSzNNgDflPvlbiyZIQM(int P_0)
		{
		}

		private bool xHAVAdEMRrtCSvPwLanhlqVKKNi(int P_0)
		{
			return false;
		}

		private void NfhTvomnhcIgAiqVBhjDZURUzHEo(int P_0)
		{
		}

		private ADSKVxZJSFkDyMGJKnlKUBorZhuD wKseQrqoRZjkoZFsARhjujPvWqOc(int P_0)
		{
			return null;
		}

		private gQYWqRhlmkWRkkrRpWjcmQltnfCL iRLXbhxxOhXwTzspBXfeNihMtTgm(int P_0)
		{
			return null;
		}

		private void ldGxgDqmkxSIPWNtNeIFSQtOJxLD()
		{
		}

		private void DgcjqVTsAnAsvjghrCiDBcSziROP(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.cZhJujCKWJEKilVkXGNxkTwEUoHkA P_0, double P_1)
		{
		}

		private void BRZrzNQzGJPKZlVIcXHeeJDFwEbG(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.BnkqDNSusWBKxlwVANRshrKvdIbg P_0, double P_1)
		{
		}

		private void kqJAgsohWHKTHAHwmbNLAGAnJEDCA(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.JeGfxXJjnrlUjkMZjaNEAepYaEIIb P_0, double P_1)
		{
		}

		private void keWsnCblYOoBRmUUghLiWVvadxsp(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.upSdQDXVNtGeoRdEJHZdTgrhWFlS P_0, double P_1)
		{
		}

		private void caEyNavoMwITCSQrwkmksKxgofbs(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.iDKviZQlqUCTZLpCOiVmImmyzlqM P_0)
		{
		}

		private void ygCdfKdhAESVtBhNnfJIVIzdlXlE(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.iDKviZQlqUCTZLpCOiVmImmyzlqM P_0)
		{
		}

		private void VzbXTAyuBNtCZETDIAtKWkIpxwEu(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.zYfHLuxlFqPKrZpZJRBPsrpZCOZB P_0, double P_1)
		{
		}

		private void kSQejZvaqdUCPdjFhpctZSuPydbG(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.FeZhjccPWHGYDJeDviTOpiDeIvWt P_0, double P_1)
		{
		}

		private void RFdRvJYdGCcuTlgezILQzqDnrlMO(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
		}

		private void bIEPKSDZHcogJpGMoIlfAFztZtIUA(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
		}

		private void KZfhhVcGGjqahOvBDujwHGgtJsfC(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
		}

		private void BwUQpinhQZbhIHzTZmvcLdLCnomO(int P_0, PfGsjQeDIWurWNVMIWGjsffAaCvbA P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void McErrgYIcPTmFnZiLxvxiGMUaFJ(int P_0, PfGsjQeDIWurWNVMIWGjsffAaCvbA P_1, byte P_2, short P_3, double P_4)
		{
		}

		private void sfEZxMbjtSmSGBHDWWgJsSJoTxii()
		{
		}

		public void Dispose()
		{
		}

		~SDL2InputSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
