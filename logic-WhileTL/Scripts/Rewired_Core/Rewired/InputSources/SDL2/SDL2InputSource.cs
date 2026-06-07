using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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

		public bool initialized => juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = UYEcHrxIOUarqiNClIAJzCCXSryJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref UYEcHrxIOUarqiNClIAJzCCXSryJ, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = UYEcHrxIOUarqiNClIAJzCCXSryJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref UYEcHrxIOUarqiNClIAJzCCXSryJ, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
				_DeviceChangedEvent += value;
			}
			remove
			{
				_DeviceChangedEvent -= value;
			}
		}

		public SDL2InputSource(UpdateLoopSetting P_0, bool P_1, bool P_2, bool P_3, bool P_4)
		{
			BrFYCbSJfjRysPkarCLQvqAUmUSM = P_1;
			QsHHfEAIztfGdACcAeeKYpjxYJXe = P_2;
			lEJSPZmAzmnnByCILEkerWjAiZZbA = P_3;
			KWqGvDitOLDGSIdkcqFCrbSWiIuhB = P_4;
			elKJbbxESyfcuzfcxFoUDTJZIhcJA = new ADictionary<int, ADSKVxZJSFkDyMGJKnlKUBorZhuD>();
			YzmazhdNyVRyvbgJvbrvquZTCtpx = new ADictionary<int, gQYWqRhlmkWRkkrRpWjcmQltnfCL>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				xfYwdkRYAVrddGoiGqMNEgTVIqto.KjUjoJfzDTVoPfWpmLKulJKefiNeA(UnityTools.effectivePlatform);
				if (xfYwdkRYAVrddGoiGqMNEgTVIqto.YuYYBaiRZxbCnpgHWXnljUGFnpOO((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
				if (P_2)
				{
					sfEZxMbjtSmSGBHDWWgJsSJoTxii();
				}
				oVlbKMRYhwrmiJFaNiOvEjhfDyBe();
				IMhljfcLIgpTYZKpSUiJBBZxGFGx = new NativeBuffer(56);
			}
			catch
			{
				juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			_ = juAmOHdlEuZcdEbopfsigKMAJgtHb;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				ldGxgDqmkxSIPWNtNeIFSQtOJxLD();
			}
		}

		public void UpdateFinished()
		{
			_ = juAmOHdlEuZcdEbopfsigKMAJgtHb;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return null;
			}
			List<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> list = new List<LjmiwQfcsmzrgAYaHEMKGLaOgKjY>();
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				foreach (KeyValuePair<int, ADSKVxZJSFkDyMGJKnlKUBorZhuD> item in elKJbbxESyfcuzfcxFoUDTJZIhcJA)
				{
					if (item.Value.LKcEAURAumgcFHtHkURWCAbgtWzMA)
					{
						list.Add(item.Value);
					}
				}
			}
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe)
			{
				foreach (KeyValuePair<int, gQYWqRhlmkWRkkrRpWjcmQltnfCL> item2 in YzmazhdNyVRyvbgJvbrvquZTCtpx)
				{
					gQYWqRhlmkWRkkrRpWjcmQltnfCL value = item2.Value;
					if (value.LKcEAURAumgcFHtHkURWCAbgtWzMA)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		private int MDudWcexNvUPNZuZENGqpwqvTAFA()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return 0;
			}
			return Math.Min(xfYwdkRYAVrddGoiGqMNEgTVIqto.oWygYLrtlmGSRfnzzSlvFkrVHCJBA(), 32);
		}

		private int CTkduoCFWBLgaCGeQRuxfxSMRrDlA()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return 0;
			}
			int num = MDudWcexNvUPNZuZENGqpwqvTAFA();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!xfYwdkRYAVrddGoiGqMNEgTVIqto.HheaLXLXJHFqlYQVuExLMVoMTSZK(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private ADSKVxZJSFkDyMGJKnlKUBorZhuD dwPoEFGcpWZTODGyaNCFWKxFdYUHA(int P_0)
		{
			IntPtr intPtr = xfYwdkRYAVrddGoiGqMNEgTVIqto.eTKEhwURXueBfjxUQSByuGSLRDORA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			TWLwCilJIoPozLulqzpoQBubYmDC tWLwCilJIoPozLulqzpoQBubYmDC = new TWLwCilJIoPozLulqzpoQBubYmDC(intPtr);
			dpvxMMmJEhBJrUwdSFTnDVVoyLgw dpvxMMmJEhBJrUwdSFTnDVVoyLgw2 = qXJbFgeAgSmrofvEOPAITEmHlXhSA(P_0, tWLwCilJIoPozLulqzpoQBubYmDC);
			if (dpvxMMmJEhBJrUwdSFTnDVVoyLgw2 == null)
			{
				xfYwdkRYAVrddGoiGqMNEgTVIqto.pLazBODcgrltBHdkqihBCHrPhtBf(intPtr);
				return null;
			}
			return new ADSKVxZJSFkDyMGJKnlKUBorZhuD(tWLwCilJIoPozLulqzpoQBubYmDC, dpvxMMmJEhBJrUwdSFTnDVVoyLgw2);
		}

		private gQYWqRhlmkWRkkrRpWjcmQltnfCL FqcyCfMalNQeZDyaliHtiOqVbxBL(int P_0)
		{
			IntPtr intPtr = xfYwdkRYAVrddGoiGqMNEgTVIqto.bXkDpYBKvFtRYgYmJajbBiXXhseq(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			SqcPYTpnQyvIBscTNAfMBNAZXxSE sqcPYTpnQyvIBscTNAfMBNAZXxSE = new SqcPYTpnQyvIBscTNAfMBNAZXxSE(intPtr);
			dpvxMMmJEhBJrUwdSFTnDVVoyLgw dpvxMMmJEhBJrUwdSFTnDVVoyLgw2 = cSsWaASwRkIUXGhSrpzXBDJhdtVDA(P_0, sqcPYTpnQyvIBscTNAfMBNAZXxSE);
			if (dpvxMMmJEhBJrUwdSFTnDVVoyLgw2 == null)
			{
				return null;
			}
			if (!dpvxMMmJEhBJrUwdSFTnDVVoyLgw2.TnqjIoSFmmuPFlrKzCXbQFGiiNcE)
			{
				xfYwdkRYAVrddGoiGqMNEgTVIqto.bqWKGxwqFABdXTFpodRLLocqGeTD(intPtr);
				return null;
			}
			dpvxMMmJEhBJrUwdSFTnDVVoyLgw2.gmqqHFPaRiTEZeJkDNWhtfnzrJWc = xfYwdkRYAVrddGoiGqMNEgTVIqto.PIdWydAAzNwbLlojQmjhwNCdvQjL(sqcPYTpnQyvIBscTNAfMBNAZXxSE);
			return new gQYWqRhlmkWRkkrRpWjcmQltnfCL(sqcPYTpnQyvIBscTNAfMBNAZXxSE, dpvxMMmJEhBJrUwdSFTnDVVoyLgw2);
		}

		private dpvxMMmJEhBJrUwdSFTnDVVoyLgw qXJbFgeAgSmrofvEOPAITEmHlXhSA(int P_0, TWLwCilJIoPozLulqzpoQBubYmDC P_1)
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return null;
			}
			if (P_0 < 0 || P_0 >= 32)
			{
				return null;
			}
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			return new dpvxMMmJEhBJrUwdSFTnDVVoyLgw
			{
				OsKdZyDPuvjDUfAlNOmAqMmXzmOB = P_0,
				gOiPPdQXptOcZupOsvpkYdiPsPSw = xfYwdkRYAVrddGoiGqMNEgTVIqto.AjfcqSEZPJYdFnlWzIfIwvezSIbdb(P_1),
				TnqjIoSFmmuPFlrKzCXbQFGiiNcE = xfYwdkRYAVrddGoiGqMNEgTVIqto.HheaLXLXJHFqlYQVuExLMVoMTSZK(P_0),
				UxwgbAluwgdNXwPCsadRMFpSSNNs = xfYwdkRYAVrddGoiGqMNEgTVIqto.SmKsMjWbnMymRzkoDJCuoTBEEoJR(P_1),
				UEsZZFLvHTFXBkynCCgZDLRMdWju = xfYwdkRYAVrddGoiGqMNEgTVIqto.iOxhwAMZXjDiNlVCFGXiAPdpUYHQ(P_1),
				YOeRSeRmLTyEWJcRmdmSlXlcALZJA = xfYwdkRYAVrddGoiGqMNEgTVIqto.scwbfDEucyQnDAzXgOplvXBQpNWfA(P_0),
				yrHZhNoSpLMEzcgptuOphbaHHcuiA = xfYwdkRYAVrddGoiGqMNEgTVIqto.CxcXjdDNqbvZjyBgqeYHQJiJgnLh(P_1),
				jhazYdoXweuxJmcAJnlflvXbFGyT = xfYwdkRYAVrddGoiGqMNEgTVIqto.elwUQxTrPAecLYgQWnpSvBEQffYjA(P_1),
				UHjJkIgmjqCHCDkouUWAlcntNjAwA = xfYwdkRYAVrddGoiGqMNEgTVIqto.aKosVxpWLzJhqDTvtQIdGjnIsrLQ(P_1),
				AKICkIcAdkhbleuthiWOLIXZQYwrB = xfYwdkRYAVrddGoiGqMNEgTVIqto.ObRcOznWhfKZjeTMXTzXZdmwBwIEA(P_1)
			};
		}

		private dpvxMMmJEhBJrUwdSFTnDVVoyLgw cSsWaASwRkIUXGhSrpzXBDJhdtVDA(int P_0, SqcPYTpnQyvIBscTNAfMBNAZXxSE P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			TWLwCilJIoPozLulqzpoQBubYmDC tWLwCilJIoPozLulqzpoQBubYmDC = new TWLwCilJIoPozLulqzpoQBubYmDC(xfYwdkRYAVrddGoiGqMNEgTVIqto.dhNisctChMSEJUtRsIQQLhJXJffG(P_1));
			if (!tWLwCilJIoPozLulqzpoQBubYmDC.IsValid)
			{
				return null;
			}
			return qXJbFgeAgSmrofvEOPAITEmHlXhSA(P_0, tWLwCilJIoPozLulqzpoQBubYmDC);
		}

		private void oVlbKMRYhwrmiJFaNiOvEjhfDyBe()
		{
			for (int i = 0; i < MDudWcexNvUPNZuZENGqpwqvTAFA(); i++)
			{
				if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
				{
					zATZtKwijtiXAsAuMoaoeUTntTAC(i);
				}
				if (QsHHfEAIztfGdACcAeeKYpjxYJXe)
				{
					xHAVAdEMRrtCSvPwLanhlqVKKNi(i);
				}
			}
		}

		private void EikcTvTdaExfWNJzdaSwbKDiYhej()
		{
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe)
			{
				foreach (KeyValuePair<int, gQYWqRhlmkWRkkrRpWjcmQltnfCL> item in YzmazhdNyVRyvbgJvbrvquZTCtpx)
				{
					gQYWqRhlmkWRkkrRpWjcmQltnfCL value = item.Value;
					value.NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
					value.Dispose();
				}
				YzmazhdNyVRyvbgJvbrvquZTCtpx.Clear();
			}
			if (!BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				return;
			}
			foreach (KeyValuePair<int, ADSKVxZJSFkDyMGJKnlKUBorZhuD> item2 in elKJbbxESyfcuzfcxFoUDTJZIhcJA)
			{
				ADSKVxZJSFkDyMGJKnlKUBorZhuD value2 = item2.Value;
				value2.NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
				value2.Dispose();
			}
			elKJbbxESyfcuzfcxFoUDTJZIhcJA.Clear();
		}

		private bool zATZtKwijtiXAsAuMoaoeUTntTAC(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe && xfYwdkRYAVrddGoiGqMNEgTVIqto.HheaLXLXJHFqlYQVuExLMVoMTSZK(P_0))
			{
				return false;
			}
			ADSKVxZJSFkDyMGJKnlKUBorZhuD aDSKVxZJSFkDyMGJKnlKUBorZhuD = dwPoEFGcpWZTODGyaNCFWKxFdYUHA(P_0);
			if (aDSKVxZJSFkDyMGJKnlKUBorZhuD == null)
			{
				return false;
			}
			int zEDIuMMjZVfjCnadvapadpKgQekjA = aDSKVxZJSFkDyMGJKnlKUBorZhuD.zEDIuMMjZVfjCnadvapadpKgQekjA;
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA.ContainsKey(zEDIuMMjZVfjCnadvapadpKgQekjA))
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[zEDIuMMjZVfjCnadvapadpKgQekjA].NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[zEDIuMMjZVfjCnadvapadpKgQekjA] = aDSKVxZJSFkDyMGJKnlKUBorZhuD;
			}
			else
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA.Add(zEDIuMMjZVfjCnadvapadpKgQekjA, aDSKVxZJSFkDyMGJKnlKUBorZhuD);
			}
			aDSKVxZJSFkDyMGJKnlKUBorZhuD.gUxczTgMdKUcYRnCXamteWaCXJodc();
			return true;
		}

		private void BLeFCCClaKSzNNgDflPvlbiyZIQM(int P_0)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA.ContainsKey(P_0))
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[P_0].NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
				elKJbbxESyfcuzfcxFoUDTJZIhcJA.Remove(P_0);
			}
		}

		private bool xHAVAdEMRrtCSvPwLanhlqVKKNi(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!xfYwdkRYAVrddGoiGqMNEgTVIqto.HheaLXLXJHFqlYQVuExLMVoMTSZK(P_0))
			{
				return false;
			}
			gQYWqRhlmkWRkkrRpWjcmQltnfCL gQYWqRhlmkWRkkrRpWjcmQltnfCL2 = FqcyCfMalNQeZDyaliHtiOqVbxBL(P_0);
			if (gQYWqRhlmkWRkkrRpWjcmQltnfCL2 == null)
			{
				return false;
			}
			int zEDIuMMjZVfjCnadvapadpKgQekjA = gQYWqRhlmkWRkkrRpWjcmQltnfCL2.zEDIuMMjZVfjCnadvapadpKgQekjA;
			if (YzmazhdNyVRyvbgJvbrvquZTCtpx.ContainsKey(zEDIuMMjZVfjCnadvapadpKgQekjA))
			{
				YzmazhdNyVRyvbgJvbrvquZTCtpx[zEDIuMMjZVfjCnadvapadpKgQekjA].NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
				YzmazhdNyVRyvbgJvbrvquZTCtpx[zEDIuMMjZVfjCnadvapadpKgQekjA] = gQYWqRhlmkWRkkrRpWjcmQltnfCL2;
			}
			else
			{
				YzmazhdNyVRyvbgJvbrvquZTCtpx.Add(zEDIuMMjZVfjCnadvapadpKgQekjA, gQYWqRhlmkWRkkrRpWjcmQltnfCL2);
			}
			gQYWqRhlmkWRkkrRpWjcmQltnfCL2.gUxczTgMdKUcYRnCXamteWaCXJodc();
			return true;
		}

		private void NfhTvomnhcIgAiqVBhjDZURUzHEo(int P_0)
		{
			if (YzmazhdNyVRyvbgJvbrvquZTCtpx.ContainsKey(P_0))
			{
				YzmazhdNyVRyvbgJvbrvquZTCtpx[P_0].NrvDJqVXljyWKGxgBCtKYeVJCdUGA();
				YzmazhdNyVRyvbgJvbrvquZTCtpx.Remove(P_0);
			}
		}

		private ADSKVxZJSFkDyMGJKnlKUBorZhuD wKseQrqoRZjkoZFsARhjujPvWqOc(int P_0)
		{
			if (!elKJbbxESyfcuzfcxFoUDTJZIhcJA.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private gQYWqRhlmkWRkkrRpWjcmQltnfCL iRLXbhxxOhXwTzspBXfeNihMtTgm(int P_0)
		{
			if (!YzmazhdNyVRyvbgJvbrvquZTCtpx.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void ldGxgDqmkxSIPWNtNeIFSQtOJxLD()
		{
			while (xfYwdkRYAVrddGoiGqMNEgTVIqto.wEUynYnYPWiqgkANekPOWcgNziyF(IMhljfcLIgpTYZKpSUiJBBZxGFGx) != 0)
			{
				xqjRBKmBgGWalphoyBSrItlLGfyAb.nwPFyBsmwzEEMIHAJhrAnnWCzmYeA(IMhljfcLIgpTYZKpSUiJBBZxGFGx);
				xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc znvDEmuGvKVGSdBvMcCkiViHjgxuA = xqjRBKmBgGWalphoyBSrItlLGfyAb.znvDEmuGvKVGSdBvMcCkiViHjgxuA;
				double realTime = ReInput.realTime;
				switch (znvDEmuGvKVGSdBvMcCkiViHjgxuA)
				{
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERAXISMOTION:
					VzbXTAyuBNtCZETDIAtKWkIpxwEu(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.tRuCbMZbzPGyTNbXAjcGNsiQVbxS, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERBUTTONDOWN:
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERBUTTONUP:
					kSQejZvaqdUCPdjFhpctZSuPydbG(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.RwrXALYHErMSxXvNMUpiUIZJBbFg, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERDEVICEREMAPPED:
					KZfhhVcGGjqahOvBDujwHGgtJsfC(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.SQQfHynafIdpEjIyhHQvYnUMphas);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYAXISMOTION:
					DgcjqVTsAnAsvjghrCiDBcSziROP(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.NjDEZtHGDzHMcZBSKuqFvOinhshCA, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYBUTTONDOWN:
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYBUTTONUP:
					BRZrzNQzGJPKZlVIcXHeeJDFwEbG(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.vYyxYhvgiTdKngZNLlETzivEeODk, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYHATMOTION:
					kqJAgsohWHKTHAHwmbNLAGAnJEDCA(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.VNNNGNybZqWZsPMdaiuQCCKnGITE, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYBALLMOTION:
					keWsnCblYOoBRmUUghLiWVvadxsp(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.JUmelsKYqcJKNeAUMRyASbHYBdkgb, realTime);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYDEVICEADDED:
					caEyNavoMwITCSQrwkmksKxgofbs(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.shixMBvXfhsOSeqnHbjnANZDHOON);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_JOYDEVICEREMOVED:
					ygCdfKdhAESVtBhNnfJIVIzdlXlE(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.shixMBvXfhsOSeqnHbjnANZDHOON);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERDEVICEADDED:
					RFdRvJYdGCcuTlgezILQzqDnrlMO(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.SQQfHynafIdpEjIyhHQvYnUMphas);
					break;
				case xfYwdkRYAVrddGoiGqMNEgTVIqto.QOVGWpDfBCFmdGAhivAflGwfMbxrc.SDL_CONTROLLERDEVICEREMOVED:
					bIEPKSDZHcogJpGMoIlfAFztZtIUA(ref xqjRBKmBgGWalphoyBSrItlLGfyAb.SQQfHynafIdpEjIyhHQvYnUMphas);
					break;
				}
			}
		}

		private void DgcjqVTsAnAsvjghrCiDBcSziROP(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.cZhJujCKWJEKilVkXGNxkTwEUoHkA P_0, double P_1)
		{
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				BwUQpinhQZbhIHzTZmvcLdLCnomO(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA, PfGsjQeDIWurWNVMIWGjsffAaCvbA.Axis, P_0.ZWuBjYJXuMePcqSIivlLWeZFNrmH, P_0.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, P_1);
			}
		}

		private void BRZrzNQzGJPKZlVIcXHeeJDFwEbG(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.BnkqDNSusWBKxlwVANRshrKvdIbg P_0, double P_1)
		{
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				BwUQpinhQZbhIHzTZmvcLdLCnomO(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA, PfGsjQeDIWurWNVMIWGjsffAaCvbA.Button, P_0.vNYIVoAjKLRDNIGPduQBhAAbIzyq, P_0.NdfIaBgxBgEDSMCdGRkmFhYCFUMaB, P_1);
			}
		}

		private void kqJAgsohWHKTHAHwmbNLAGAnJEDCA(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.JeGfxXJjnrlUjkMZjaNEAepYaEIIb P_0, double P_1)
		{
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				BwUQpinhQZbhIHzTZmvcLdLCnomO(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA, PfGsjQeDIWurWNVMIWGjsffAaCvbA.Hat, P_0.eMXAWdleOtQmrXMuHXSsfDOBURVg, P_0.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, P_1);
			}
		}

		private void keWsnCblYOoBRmUUghLiWVvadxsp(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.upSdQDXVNtGeoRdEJHZdTgrhWFlS P_0, double P_1)
		{
			_ = BrFYCbSJfjRysPkarCLQvqAUmUSM;
		}

		private void caEyNavoMwITCSQrwkmksKxgofbs(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.iDKviZQlqUCTZLpCOiVmImmyzlqM P_0)
		{
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				zATZtKwijtiXAsAuMoaoeUTntTAC(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA);
				if (UYEcHrxIOUarqiNClIAJzCCXSryJ != null)
				{
					UYEcHrxIOUarqiNClIAJzCCXSryJ();
				}
			}
		}

		private void ygCdfKdhAESVtBhNnfJIVIzdlXlE(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.iDKviZQlqUCTZLpCOiVmImmyzlqM P_0)
		{
			if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
			{
				BLeFCCClaKSzNNgDflPvlbiyZIQM(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA);
				if (UYEcHrxIOUarqiNClIAJzCCXSryJ != null)
				{
					UYEcHrxIOUarqiNClIAJzCCXSryJ();
				}
			}
		}

		private void VzbXTAyuBNtCZETDIAtKWkIpxwEu(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.zYfHLuxlFqPKrZpZJRBPsrpZCOZB P_0, double P_1)
		{
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe && P_0.ZWuBjYJXuMePcqSIivlLWeZFNrmH != 6)
			{
				McErrgYIcPTmFnZiLxvxiGMUaFJ(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA, PfGsjQeDIWurWNVMIWGjsffAaCvbA.Axis, P_0.ZWuBjYJXuMePcqSIivlLWeZFNrmH, P_0.pWbMhcBQKZEHHDwvEOhqpAUJhzfpA, P_1);
			}
		}

		private void kSQejZvaqdUCPdjFhpctZSuPydbG(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.FeZhjccPWHGYDJeDviTOpiDeIvWt P_0, double P_1)
		{
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe && P_0.vNYIVoAjKLRDNIGPduQBhAAbIzyq != 15)
			{
				McErrgYIcPTmFnZiLxvxiGMUaFJ(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA, PfGsjQeDIWurWNVMIWGjsffAaCvbA.Button, P_0.vNYIVoAjKLRDNIGPduQBhAAbIzyq, P_0.NdfIaBgxBgEDSMCdGRkmFhYCFUMaB, P_1);
			}
		}

		private void RFdRvJYdGCcuTlgezILQzqDnrlMO(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe)
			{
				xHAVAdEMRrtCSvPwLanhlqVKKNi(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA);
				if (UYEcHrxIOUarqiNClIAJzCCXSryJ != null)
				{
					UYEcHrxIOUarqiNClIAJzCCXSryJ();
				}
			}
		}

		private void bIEPKSDZHcogJpGMoIlfAFztZtIUA(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
			if (QsHHfEAIztfGdACcAeeKYpjxYJXe)
			{
				NfhTvomnhcIgAiqVBhjDZURUzHEo(P_0.UOxqyGMBQoooBznBWdGIHBRPlZXMA);
				if (UYEcHrxIOUarqiNClIAJzCCXSryJ != null)
				{
					UYEcHrxIOUarqiNClIAJzCCXSryJ();
				}
			}
		}

		private void KZfhhVcGGjqahOvBDujwHGgtJsfC(ref xfYwdkRYAVrddGoiGqMNEgTVIqto.sQMeutXTMPfZbXXMULaGaejjtwYd P_0)
		{
			_ = QsHHfEAIztfGdACcAeeKYpjxYJXe;
		}

		private void BwUQpinhQZbhIHzTZmvcLdLCnomO(int P_0, PfGsjQeDIWurWNVMIWGjsffAaCvbA P_1, byte P_2, short P_3, double P_4)
		{
			wKseQrqoRZjkoZFsARhjujPvWqOc(P_0)?.oZQllQxQuNaPXytzirxUjNaKuQtr(P_1, P_2, P_3, P_4);
		}

		private void McErrgYIcPTmFnZiLxvxiGMUaFJ(int P_0, PfGsjQeDIWurWNVMIWGjsffAaCvbA P_1, byte P_2, short P_3, double P_4)
		{
			iRLXbhxxOhXwTzspBXfeNihMtTgm(P_0)?.oZQllQxQuNaPXytzirxUjNaKuQtr(P_1, P_2, P_3, P_4);
		}

		private void sfEZxMbjtSmSGBHDWWgJsSJoTxii()
		{
			string[] array = dstOEBNmmscQlBZCGAeCouKxcgRQ.SwNdyxaBQvQtAfAVGngvYCbGeKyMA();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(xfYwdkRYAVrddGoiGqMNEgTVIqto.hWUWKeSfNtDVqwhqPbxUdTSoHNLHA(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					xfYwdkRYAVrddGoiGqMNEgTVIqto.WnmvbWnigYeaMkRBDEBUAIOvmWBGA(array[i]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return;
			}
			if (disposing)
			{
				if (IMhljfcLIgpTYZKpSUiJBBZxGFGx != null)
				{
					IMhljfcLIgpTYZKpSUiJBBZxGFGx.Dispose();
				}
				EikcTvTdaExfWNJzdaSwbKDiYhej();
			}
			xfYwdkRYAVrddGoiGqMNEgTVIqto.UXNuVCOGNYVxORlRsrMArUijPmZI();
			juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
			JChPmMbeaoLOGQvosPYqDDInSiCs = true;
		}
	}
}
