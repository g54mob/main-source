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
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IInputSource, IDisposable
	{
		public delegate void OiVzLGLUoOotmFLjSgMythGqIijGA(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void bsowMhTvxKarHnRnmqkgAfoIohWf(int joystickIndex);

		public delegate void fdxWXKTPdKHgTuMlqiuIEvaSMbjv(int joystickId);

		public delegate void FRSBZANALxiIiPKexMFHEIWxbdnq(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int zJmrEuaDPmOaHPiKuftkppyWECbN = 32;

		private bool QoTSAIvVICVSbMWDfJrYLPiMiUTY;

		private bool DmzhjxdebFCWYTtQHbiurfHUVaAR;

		private bool DvfMPGRxeWcmxejvECffLQPBisKl;

		private bool ChbTuqhUWAQTKKQQfWrBMtsjpLEW;

		private bool HMKCMZhhoSZwxeapKMbRBejnPeSwA;

		private ADictionary<int, QybEXzfcnDxYBdLOCnYSjOfYiCNyA> KEKjwYSFeHjLJajNPIhOyrwKpPkPA;

		private ADictionary<int, gapgBNODSkWmTfqDdshoeWFSLmvW> sQFCYWDglqzGGVKZwAnTzqdypxGD;

		private tOngruuekVuFUFicELTBAbvqjfEu.kZbQpNAJauJSmRhWitvZRqlmgBqf vWmDoEdsNeJCERGFrWNKCOhSPWRF;

		private NativeBuffer GoJaEeAkPRsDHBzIGQlcmRuErslp;

		[CompilerGenerated]
		private Action CJudEWCDFxQHbeBDXEFwlDlnfeaD;

		private bool qdgdAPzQWAMNNgRRUdnMFEAQZfOB;

		public bool initialized => HMKCMZhhoSZwxeapKMbRBejnPeSwA;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = CJudEWCDFxQHbeBDXEFwlDlnfeaD;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref CJudEWCDFxQHbeBDXEFwlDlnfeaD, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = CJudEWCDFxQHbeBDXEFwlDlnfeaD;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref CJudEWCDFxQHbeBDXEFwlDlnfeaD, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		event Action IInputSource.DeviceChangedEvent
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
			QoTSAIvVICVSbMWDfJrYLPiMiUTY = P_1;
			DmzhjxdebFCWYTtQHbiurfHUVaAR = P_2;
			DvfMPGRxeWcmxejvECffLQPBisKl = P_3;
			ChbTuqhUWAQTKKQQfWrBMtsjpLEW = P_4;
			KEKjwYSFeHjLJajNPIhOyrwKpPkPA = new ADictionary<int, QybEXzfcnDxYBdLOCnYSjOfYiCNyA>();
			sQFCYWDglqzGGVKZwAnTzqdypxGD = new ADictionary<int, gapgBNODSkWmTfqDdshoeWFSLmvW>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				tOngruuekVuFUFicELTBAbvqjfEu.holLqOeCHnZdmyfmXDIQjDIiPLMWA(UnityTools.effectivePlatform);
				if (tOngruuekVuFUFicELTBAbvqjfEu.GZWoicJInvevHfPqdfYTquwphJBdb((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				HMKCMZhhoSZwxeapKMbRBejnPeSwA = true;
				if (P_2)
				{
					TOAycvueOoZWIiWOgqbfPzfqlTYQ();
				}
				TwxKelFgxCBeXDwclUKbJiAqoGMeb();
				GoJaEeAkPRsDHBzIGQlcmRuErslp = new NativeBuffer(56);
			}
			catch
			{
				HMKCMZhhoSZwxeapKMbRBejnPeSwA = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceConnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
			this.SystemDeviceConnected();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		void IInputSource.SystemDeviceDisconnected()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
			this.SystemDeviceDisconnected();
		}

		public void Update()
		{
			_ = HMKCMZhhoSZwxeapKMbRBejnPeSwA;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (HMKCMZhhoSZwxeapKMbRBejnPeSwA)
			{
				syxdCBEQwbRYwMQqrSjTUkyBUUuBA();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = HMKCMZhhoSZwxeapKMbRBejnPeSwA;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!HMKCMZhhoSZwxeapKMbRBejnPeSwA)
			{
				return null;
			}
			List<XAZzsMQMImLcZRwmVzOOEmMtHEOJ> list = new List<XAZzsMQMImLcZRwmVzOOEmMtHEOJ>();
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				foreach (KeyValuePair<int, QybEXzfcnDxYBdLOCnYSjOfYiCNyA> item in KEKjwYSFeHjLJajNPIhOyrwKpPkPA)
				{
					if (item.Value.tZtAUglChTRFLNRVljFbecXdJLYc)
					{
						list.Add(item.Value);
					}
				}
			}
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR)
			{
				foreach (KeyValuePair<int, gapgBNODSkWmTfqDdshoeWFSLmvW> item2 in sQFCYWDglqzGGVKZwAnTzqdypxGD)
				{
					gapgBNODSkWmTfqDdshoeWFSLmvW value = item2.Value;
					if (value.tZtAUglChTRFLNRVljFbecXdJLYc)
					{
						list.Add(value);
					}
				}
			}
			return list as IList<T>;
		}

		IList<T> IInputSource.GetJoysticks<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
			return this.GetJoysticks<T>();
		}

		private int xXwcqchFnApcadjkFhTSUbqqEYNLA()
		{
			if (!HMKCMZhhoSZwxeapKMbRBejnPeSwA)
			{
				return 0;
			}
			return Math.Min(tOngruuekVuFUFicELTBAbvqjfEu.tNcpQaPdHfjSJxXuthFhUoMONCqo(), 32);
		}

		private int NpyDiIAognpNWjTxAEnDPZXQLRpEb()
		{
			if (!HMKCMZhhoSZwxeapKMbRBejnPeSwA)
			{
				return 0;
			}
			int num = xXwcqchFnApcadjkFhTSUbqqEYNLA();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!tOngruuekVuFUFicELTBAbvqjfEu.UinxUNsAmwyqyxhtGMGNpWKhodtf(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private QybEXzfcnDxYBdLOCnYSjOfYiCNyA tJLsKtpfdJhwVwndyLLGnLzJHzXo(int P_0)
		{
			IntPtr intPtr = tOngruuekVuFUFicELTBAbvqjfEu.hoQRGkTApRRWguVvEsnowaOwvpmo(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			HxuTdcCdfitpMWSaqHOcYRpUyViO hxuTdcCdfitpMWSaqHOcYRpUyViO = new HxuTdcCdfitpMWSaqHOcYRpUyViO(intPtr);
			lEXUOZyrtptSFduQgbxDtqJIFtc lEXUOZyrtptSFduQgbxDtqJIFtc2 = ihdgBzRiOzAlgkmNMCTMKoItutinA(P_0, hxuTdcCdfitpMWSaqHOcYRpUyViO);
			if (lEXUOZyrtptSFduQgbxDtqJIFtc2 == null)
			{
				tOngruuekVuFUFicELTBAbvqjfEu.IRCiqZRLFjkcgHHVmbwpeqManJqXA(intPtr);
				return null;
			}
			return new QybEXzfcnDxYBdLOCnYSjOfYiCNyA(hxuTdcCdfitpMWSaqHOcYRpUyViO, lEXUOZyrtptSFduQgbxDtqJIFtc2);
		}

		private gapgBNODSkWmTfqDdshoeWFSLmvW VUMyJcqgtgmACSUHAWiTiUcmqFGw(int P_0)
		{
			IntPtr intPtr = tOngruuekVuFUFicELTBAbvqjfEu.AlaNMNIsfMCZYOVzNrDaDentsJYM(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			GBReQFcCLaTLgcpuJCdChBlcwQlcb gBReQFcCLaTLgcpuJCdChBlcwQlcb = new GBReQFcCLaTLgcpuJCdChBlcwQlcb(intPtr);
			lEXUOZyrtptSFduQgbxDtqJIFtc lEXUOZyrtptSFduQgbxDtqJIFtc2 = DiCBlReCjyDxPFHwkOJbQsiZnMBj(P_0, gBReQFcCLaTLgcpuJCdChBlcwQlcb);
			if (lEXUOZyrtptSFduQgbxDtqJIFtc2 == null)
			{
				return null;
			}
			if (!lEXUOZyrtptSFduQgbxDtqJIFtc2.HBIGRpUjnIczXcgrjICXrydfKCdDA)
			{
				tOngruuekVuFUFicELTBAbvqjfEu.YRJgaGMnKUiqCgxgeknxSXRWatGKA(intPtr);
				return null;
			}
			lEXUOZyrtptSFduQgbxDtqJIFtc2.TFFZHdPkZyEmJCBRHEQlTPxRXAgmA = tOngruuekVuFUFicELTBAbvqjfEu.WssDYbydXLyMwdIqOOesRbLJiWtv(gBReQFcCLaTLgcpuJCdChBlcwQlcb);
			return new gapgBNODSkWmTfqDdshoeWFSLmvW(gBReQFcCLaTLgcpuJCdChBlcwQlcb, lEXUOZyrtptSFduQgbxDtqJIFtc2);
		}

		private lEXUOZyrtptSFduQgbxDtqJIFtc ihdgBzRiOzAlgkmNMCTMKoItutinA(int P_0, HxuTdcCdfitpMWSaqHOcYRpUyViO P_1)
		{
			if (!HMKCMZhhoSZwxeapKMbRBejnPeSwA)
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
			return new lEXUOZyrtptSFduQgbxDtqJIFtc
			{
				OzrddnKJxlYmeWScchUUCYVqptOH = P_0,
				NYmsntNmerBdfjqWsqOAJSxXtHzm = tOngruuekVuFUFicELTBAbvqjfEu.UMRyAnJIbDtQmAGkXhajkiXOCHzdA(P_1),
				HBIGRpUjnIczXcgrjICXrydfKCdDA = tOngruuekVuFUFicELTBAbvqjfEu.UinxUNsAmwyqyxhtGMGNpWKhodtf(P_0),
				drwYfDsmzyYnzGtWAmJDQsBHFltY = tOngruuekVuFUFicELTBAbvqjfEu.dZwRDobUWedSLwCaCscasvIfrXsu(P_1),
				jQbemCbXkYArMcGFAxSBRspzqPAs = tOngruuekVuFUFicELTBAbvqjfEu.oCcEpLLnTwpYKCpMLhhxYOuGKNcX(P_1),
				uXtavkpiGnTELWlIoiAOdjmSccCe = tOngruuekVuFUFicELTBAbvqjfEu.BOznFRyxxvkpEobobexWECerBzpW(P_0),
				xaFCqVfuYPPZYAWPQgdNpgdYGngE = tOngruuekVuFUFicELTBAbvqjfEu.GAfFxJVXsiZPxOHjKjPJJfLakMdcb(P_1),
				HelnMFnZCbVTCBEOyjdnjFdMoTAtA = tOngruuekVuFUFicELTBAbvqjfEu.eADEngTZJAozuoIgIHmMBWEOnVae(P_1),
				vpyKIZrHOUkyVjQPhuddtTzxnrnN = tOngruuekVuFUFicELTBAbvqjfEu.gfCsQPCySOHloBASzVYWslEnkzSi(P_1),
				JHyGyDWWPkLfNdXYLnZhbtmFjqyE = tOngruuekVuFUFicELTBAbvqjfEu.iOXCQSMeQVGOncyeDOfcKQXYaJGF(P_1)
			};
		}

		private lEXUOZyrtptSFduQgbxDtqJIFtc DiCBlReCjyDxPFHwkOJbQsiZnMBj(int P_0, GBReQFcCLaTLgcpuJCdChBlcwQlcb P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			HxuTdcCdfitpMWSaqHOcYRpUyViO hxuTdcCdfitpMWSaqHOcYRpUyViO = new HxuTdcCdfitpMWSaqHOcYRpUyViO(tOngruuekVuFUFicELTBAbvqjfEu.gqLCMAVhmyzyPFCdYFHXmtJzlIUP(P_1));
			if (!hxuTdcCdfitpMWSaqHOcYRpUyViO.IsValid)
			{
				return null;
			}
			return ihdgBzRiOzAlgkmNMCTMKoItutinA(P_0, hxuTdcCdfitpMWSaqHOcYRpUyViO);
		}

		private void TwxKelFgxCBeXDwclUKbJiAqoGMeb()
		{
			for (int i = 0; i < xXwcqchFnApcadjkFhTSUbqqEYNLA(); i++)
			{
				if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
				{
					nkRdJVamKqFzqcpPUKJmDxKEvqAD(i);
				}
				if (DmzhjxdebFCWYTtQHbiurfHUVaAR)
				{
					MloQrZlQjLamMdYNMQkQrnCIdXlAA(i);
				}
			}
		}

		private void IFlpQykgrABSVmpwwZEpQZsoHBtt()
		{
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR)
			{
				foreach (KeyValuePair<int, gapgBNODSkWmTfqDdshoeWFSLmvW> item in sQFCYWDglqzGGVKZwAnTzqdypxGD)
				{
					gapgBNODSkWmTfqDdshoeWFSLmvW value = item.Value;
					value.YWZqvwDSLUmYwSkPyobrwwdDQcQN();
					value.Dispose();
				}
				sQFCYWDglqzGGVKZwAnTzqdypxGD.Clear();
			}
			if (!QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				return;
			}
			foreach (KeyValuePair<int, QybEXzfcnDxYBdLOCnYSjOfYiCNyA> item2 in KEKjwYSFeHjLJajNPIhOyrwKpPkPA)
			{
				QybEXzfcnDxYBdLOCnYSjOfYiCNyA value2 = item2.Value;
				value2.YWZqvwDSLUmYwSkPyobrwwdDQcQN();
				value2.Dispose();
			}
			KEKjwYSFeHjLJajNPIhOyrwKpPkPA.Clear();
		}

		private bool nkRdJVamKqFzqcpPUKJmDxKEvqAD(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR && tOngruuekVuFUFicELTBAbvqjfEu.UinxUNsAmwyqyxhtGMGNpWKhodtf(P_0))
			{
				return false;
			}
			QybEXzfcnDxYBdLOCnYSjOfYiCNyA qybEXzfcnDxYBdLOCnYSjOfYiCNyA = tJLsKtpfdJhwVwndyLLGnLzJHzXo(P_0);
			if (qybEXzfcnDxYBdLOCnYSjOfYiCNyA == null)
			{
				return false;
			}
			int fmKkFlHCEqVqZKXItXClrCWGikTD = qybEXzfcnDxYBdLOCnYSjOfYiCNyA.FmKkFlHCEqVqZKXItXClrCWGikTD;
			if (KEKjwYSFeHjLJajNPIhOyrwKpPkPA.ContainsKey(fmKkFlHCEqVqZKXItXClrCWGikTD))
			{
				KEKjwYSFeHjLJajNPIhOyrwKpPkPA[fmKkFlHCEqVqZKXItXClrCWGikTD].YWZqvwDSLUmYwSkPyobrwwdDQcQN();
				KEKjwYSFeHjLJajNPIhOyrwKpPkPA[fmKkFlHCEqVqZKXItXClrCWGikTD] = qybEXzfcnDxYBdLOCnYSjOfYiCNyA;
			}
			else
			{
				KEKjwYSFeHjLJajNPIhOyrwKpPkPA.Add(fmKkFlHCEqVqZKXItXClrCWGikTD, qybEXzfcnDxYBdLOCnYSjOfYiCNyA);
			}
			qybEXzfcnDxYBdLOCnYSjOfYiCNyA.tghbHzvjAwrOUFdEuECoRDaqceVcA();
			return true;
		}

		private void EhqkRoAkpRvzZbxTGgzFtTJJYuqg(int P_0)
		{
			if (KEKjwYSFeHjLJajNPIhOyrwKpPkPA.ContainsKey(P_0))
			{
				KEKjwYSFeHjLJajNPIhOyrwKpPkPA[P_0].YWZqvwDSLUmYwSkPyobrwwdDQcQN();
				KEKjwYSFeHjLJajNPIhOyrwKpPkPA.Remove(P_0);
			}
		}

		private bool MloQrZlQjLamMdYNMQkQrnCIdXlAA(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!tOngruuekVuFUFicELTBAbvqjfEu.UinxUNsAmwyqyxhtGMGNpWKhodtf(P_0))
			{
				return false;
			}
			gapgBNODSkWmTfqDdshoeWFSLmvW gapgBNODSkWmTfqDdshoeWFSLmvW2 = VUMyJcqgtgmACSUHAWiTiUcmqFGw(P_0);
			if (gapgBNODSkWmTfqDdshoeWFSLmvW2 == null)
			{
				return false;
			}
			int fmKkFlHCEqVqZKXItXClrCWGikTD = gapgBNODSkWmTfqDdshoeWFSLmvW2.FmKkFlHCEqVqZKXItXClrCWGikTD;
			if (sQFCYWDglqzGGVKZwAnTzqdypxGD.ContainsKey(fmKkFlHCEqVqZKXItXClrCWGikTD))
			{
				sQFCYWDglqzGGVKZwAnTzqdypxGD[fmKkFlHCEqVqZKXItXClrCWGikTD].YWZqvwDSLUmYwSkPyobrwwdDQcQN();
				sQFCYWDglqzGGVKZwAnTzqdypxGD[fmKkFlHCEqVqZKXItXClrCWGikTD] = gapgBNODSkWmTfqDdshoeWFSLmvW2;
			}
			else
			{
				sQFCYWDglqzGGVKZwAnTzqdypxGD.Add(fmKkFlHCEqVqZKXItXClrCWGikTD, gapgBNODSkWmTfqDdshoeWFSLmvW2);
			}
			gapgBNODSkWmTfqDdshoeWFSLmvW2.tghbHzvjAwrOUFdEuECoRDaqceVcA();
			return true;
		}

		private void oVsJqMdaQIgdvISIFjiTsPlIimtQ(int P_0)
		{
			if (sQFCYWDglqzGGVKZwAnTzqdypxGD.ContainsKey(P_0))
			{
				sQFCYWDglqzGGVKZwAnTzqdypxGD[P_0].YWZqvwDSLUmYwSkPyobrwwdDQcQN();
				sQFCYWDglqzGGVKZwAnTzqdypxGD.Remove(P_0);
			}
		}

		private QybEXzfcnDxYBdLOCnYSjOfYiCNyA cBDvbYpviYedAtHoIfGUGFzFimbzA(int P_0)
		{
			if (!KEKjwYSFeHjLJajNPIhOyrwKpPkPA.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private gapgBNODSkWmTfqDdshoeWFSLmvW tfaZYEpTWFdoGOBYmKTMFkMdTIfP(int P_0)
		{
			if (!sQFCYWDglqzGGVKZwAnTzqdypxGD.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void syxdCBEQwbRYwMQqrSjTUkyBUUuBA()
		{
			while (tOngruuekVuFUFicELTBAbvqjfEu.dNMwjSBQhjLjwFyQerfMiDOQMzyV(GoJaEeAkPRsDHBzIGQlcmRuErslp) != 0)
			{
				vWmDoEdsNeJCERGFrWNKCOhSPWRF.DTgbWssDceFYuJJWUHIQbqNaaOpGA(GoJaEeAkPRsDHBzIGQlcmRuErslp);
				tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU pSXgpegkwWVAYQNBSHpNDWadDeJJB = vWmDoEdsNeJCERGFrWNKCOhSPWRF.pSXgpegkwWVAYQNBSHpNDWadDeJJB;
				double realTime = ReInput.realTime;
				switch (pSXgpegkwWVAYQNBSHpNDWadDeJJB)
				{
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERAXISMOTION:
					hoRQckzHxPnZdnNsdazqJRrUJoIU(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.yQmlacVSVvdVwdidRRpRYCuBmeEcb, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERBUTTONDOWN:
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERBUTTONUP:
					UOWyBSapGVFDpUrznEFNCvqcqJvJA(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.vQuPWqkxNSdPNaRlXXNFbGpBwBwE, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERDEVICEREMAPPED:
					sxFvsReijSLahnWdkHMLcbMdqSBO(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.qPzpIhxPsjxvldfIRdijncmtFyHiA);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYAXISMOTION:
					oYrEvaBZqBOeGnwaAWyDFgQTmQKbA(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.uIcWGCzqlCjgvTKlVLuDZVrjhWnT, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYBUTTONDOWN:
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYBUTTONUP:
					SjJjMJbUUcevXcOoycqFjtCeqPdhA(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.fWIHNTmcpWoCkpetkxjmxezeouyN, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYHATMOTION:
					mzkxfVpZWLConmqRGYkzcrkokDmm(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.gCPouJfPZVfhCePrFhiGRFjOlYYfA, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYBALLMOTION:
					eiUjitzXiVxrUenmdzfFYPwWxCbD(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.WXrJazMpbYZNUboCxBUdgnXlCUqDb, realTime);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYDEVICEADDED:
					kNMQWouYFsfTTTJtmkuCMKedZqcy(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.IOykBzMlpThbhlcpQeVOenfxJeWXA);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_JOYDEVICEREMOVED:
					XsBidyjlLCBuUhwimRikIicGahOr(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.IOykBzMlpThbhlcpQeVOenfxJeWXA);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERDEVICEADDED:
					GUYeaBytqlrbRjcxflpWBpFSFsWs(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.qPzpIhxPsjxvldfIRdijncmtFyHiA);
					break;
				case tOngruuekVuFUFicELTBAbvqjfEu.bgkcYSscVyaPttQUkqZiJjOulFqU.SDL_CONTROLLERDEVICEREMOVED:
					tFAMfQOjkwUmgrEYQnsxFcuLZBAQ(ref vWmDoEdsNeJCERGFrWNKCOhSPWRF.qPzpIhxPsjxvldfIRdijncmtFyHiA);
					break;
				}
			}
		}

		private void oYrEvaBZqBOeGnwaAWyDFgQTmQKbA(ref tOngruuekVuFUFicELTBAbvqjfEu.IgpejblsXcNycYBzCrAgYZHYNlDq P_0, double P_1)
		{
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				oHhWebHfLVVqaUFCxcJipatyEMnBA(P_0.vxfGDxyeywapYkIpyLeQyXwTCZOTA, LGtssOHZcSDfhUlYEjzhcVhlTpEE.Axis, P_0.gfMZkrCTdMRAVewXNFueqEdEowTp, P_0.BTXDeoVGWLDJTsrfSJHbcSvnEaXGA, P_1);
			}
		}

		private void SjJjMJbUUcevXcOoycqFjtCeqPdhA(ref tOngruuekVuFUFicELTBAbvqjfEu.uheFRVsaJJSGQeEAOEGxbHOQumZC P_0, double P_1)
		{
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				oHhWebHfLVVqaUFCxcJipatyEMnBA(P_0.DSNqQyamBoQWXlRJmOqOvebZhiQM, LGtssOHZcSDfhUlYEjzhcVhlTpEE.Button, P_0.hwHBNFhufEjKXAhtsenaJmqiwdYy, P_0.GWBycbfgcXcYXEzoNZqnNCnWiNaRA, P_1);
			}
		}

		private void mzkxfVpZWLConmqRGYkzcrkokDmm(ref tOngruuekVuFUFicELTBAbvqjfEu.dkdzphgndPNWzAFGIktxFeCmojpC P_0, double P_1)
		{
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				oHhWebHfLVVqaUFCxcJipatyEMnBA(P_0.drScerIpcFaNfAkQFCcSYuyKpqNRA, LGtssOHZcSDfhUlYEjzhcVhlTpEE.Hat, P_0.XcDfQyGtLaTZscdMgXxAaLBSZQqHA, P_0.yZRvMOCEDXvtYaFmnstkiXOnZATh, P_1);
			}
		}

		private void eiUjitzXiVxrUenmdzfFYPwWxCbD(ref tOngruuekVuFUFicELTBAbvqjfEu.YSFHQrjDIGhRsHxITwHBAfSuqtsnA P_0, double P_1)
		{
			_ = QoTSAIvVICVSbMWDfJrYLPiMiUTY;
		}

		private void kNMQWouYFsfTTTJtmkuCMKedZqcy(ref tOngruuekVuFUFicELTBAbvqjfEu.gWdvZPrOBKrGsCARQozgSMNTeDTG P_0)
		{
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				nkRdJVamKqFzqcpPUKJmDxKEvqAD(P_0.wZHwgbeJEZPBLuxeDGQuOzJoOKkT);
				if (CJudEWCDFxQHbeBDXEFwlDlnfeaD != null)
				{
					CJudEWCDFxQHbeBDXEFwlDlnfeaD();
				}
			}
		}

		private void XsBidyjlLCBuUhwimRikIicGahOr(ref tOngruuekVuFUFicELTBAbvqjfEu.gWdvZPrOBKrGsCARQozgSMNTeDTG P_0)
		{
			if (QoTSAIvVICVSbMWDfJrYLPiMiUTY)
			{
				EhqkRoAkpRvzZbxTGgzFtTJJYuqg(P_0.wZHwgbeJEZPBLuxeDGQuOzJoOKkT);
				if (CJudEWCDFxQHbeBDXEFwlDlnfeaD != null)
				{
					CJudEWCDFxQHbeBDXEFwlDlnfeaD();
				}
			}
		}

		private void hoRQckzHxPnZdnNsdazqJRrUJoIU(ref tOngruuekVuFUFicELTBAbvqjfEu.YXWhsuogkZJEUWEtORmZYaNjBIgGA P_0, double P_1)
		{
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR && P_0.ccUVkquqnNaDtGHDNqmOCURTNWsR != 6)
			{
				loMcogKJgLnxMOWqncsFFZrVKCgCb(P_0.eWwbNBgahokllmMLIPcjrQSbSRMd, LGtssOHZcSDfhUlYEjzhcVhlTpEE.Axis, P_0.ccUVkquqnNaDtGHDNqmOCURTNWsR, P_0.NrVKRgbqUtEXfpziLirLLldCeFgx, P_1);
			}
		}

		private void UOWyBSapGVFDpUrznEFNCvqcqJvJA(ref tOngruuekVuFUFicELTBAbvqjfEu.hCnxazHFYiGVbHfepSQMEquZpVRtA P_0, double P_1)
		{
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR && P_0.eLxFIaQeumhbnEwXedMNAEZcraCy != 15)
			{
				loMcogKJgLnxMOWqncsFFZrVKCgCb(P_0.KhvPVAzKbePahuqvujCSUcLXrpKV, LGtssOHZcSDfhUlYEjzhcVhlTpEE.Button, P_0.eLxFIaQeumhbnEwXedMNAEZcraCy, P_0.kMsRdplcVMLHwuHpBMaCIMQbfWLGA, P_1);
			}
		}

		private void GUYeaBytqlrbRjcxflpWBpFSFsWs(ref tOngruuekVuFUFicELTBAbvqjfEu.ZQtCDXyYRWKemWfYcawwgbdfqFtOA P_0)
		{
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR)
			{
				MloQrZlQjLamMdYNMQkQrnCIdXlAA(P_0.NtTgzKbbfJHibdmmIyfHNtTVPUDf);
				if (CJudEWCDFxQHbeBDXEFwlDlnfeaD != null)
				{
					CJudEWCDFxQHbeBDXEFwlDlnfeaD();
				}
			}
		}

		private void tFAMfQOjkwUmgrEYQnsxFcuLZBAQ(ref tOngruuekVuFUFicELTBAbvqjfEu.ZQtCDXyYRWKemWfYcawwgbdfqFtOA P_0)
		{
			if (DmzhjxdebFCWYTtQHbiurfHUVaAR)
			{
				oVsJqMdaQIgdvISIFjiTsPlIimtQ(P_0.NtTgzKbbfJHibdmmIyfHNtTVPUDf);
				if (CJudEWCDFxQHbeBDXEFwlDlnfeaD != null)
				{
					CJudEWCDFxQHbeBDXEFwlDlnfeaD();
				}
			}
		}

		private void sxFvsReijSLahnWdkHMLcbMdqSBO(ref tOngruuekVuFUFicELTBAbvqjfEu.ZQtCDXyYRWKemWfYcawwgbdfqFtOA P_0)
		{
			_ = DmzhjxdebFCWYTtQHbiurfHUVaAR;
		}

		private void oHhWebHfLVVqaUFCxcJipatyEMnBA(int P_0, LGtssOHZcSDfhUlYEjzhcVhlTpEE P_1, byte P_2, short P_3, double P_4)
		{
			cBDvbYpviYedAtHoIfGUGFzFimbzA(P_0)?.mOPJTZrCloNifgRBRLJuBvjQfaBD(P_1, P_2, P_3, P_4);
		}

		private void loMcogKJgLnxMOWqncsFFZrVKCgCb(int P_0, LGtssOHZcSDfhUlYEjzhcVhlTpEE P_1, byte P_2, short P_3, double P_4)
		{
			tfaZYEpTWFdoGOBYmKTMFkMdTIfP(P_0)?.mOPJTZrCloNifgRBRLJuBvjQfaBD(P_1, P_2, P_3, P_4);
		}

		private void TOAycvueOoZWIiWOgqbfPzfqlTYQ()
		{
			string[] array = naITXDaGWmhqQYlQEIRYeQeUiveu.lnWuzdtmWYQThTSNfrHSRhAsuQjD();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(tOngruuekVuFUFicELTBAbvqjfEu.xYqdamIOKFHvJCiStzKLFZKsfTKcA(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					tOngruuekVuFUFicELTBAbvqjfEu.OPJkvMkCStwUDatsMohPDdvZsGTy(array[i]);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (qdgdAPzQWAMNNgRRUdnMFEAQZfOB)
			{
				return;
			}
			if (disposing)
			{
				if (GoJaEeAkPRsDHBzIGQlcmRuErslp != null)
				{
					GoJaEeAkPRsDHBzIGQlcmRuErslp.Dispose();
				}
				IFlpQykgrABSVmpwwZEpQZsoHBtt();
			}
			tOngruuekVuFUFicELTBAbvqjfEu.LjHAdgAvaYAiUwONeOdsMSttCygAb();
			HMKCMZhhoSZwxeapKMbRBejnPeSwA = false;
			qdgdAPzQWAMNNgRRUdnMFEAQZfOB = true;
		}
	}
}
