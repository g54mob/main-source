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
		public delegate void zstakmDetJBPUBoojPCsqJubXvNDB(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void KzQVZQqiuBMxXCEcrqoMoFHnrkwc(int joystickIndex);

		public delegate void YRPfwoamkLZQtZBmnPcMsZMdSuXV(int joystickId);

		public delegate void kCgdkmuWIokMYqgxyxSTaLwAEmRdA(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int GUSWbSBCzfqzQmJArjGyLOyfLXyb = 32;

		private bool ttjDrgDQFLLgHAjQmjtOQzOfwNvoA;

		private bool ypDUTVYQwGgVocnPKssgBprvbOyF;

		private bool cZPdmmkMnLIRTNtkBCRjjvdgpXsh;

		private bool hALGRGJAZRWzssrDgXfJJoOKMEcdb;

		private bool kbkbpffQhTLUDgPuPwhRBYLKglkeb;

		private ADictionary<int, xiFtgBJFkEGohisLDEUCdkVzqFfqA> nJwVXclJjEtwtEBCAKdIXuEzPYCN;

		private ADictionary<int, NrHRsbjtLxVWvMsSasrsCbxrglHeA> ZrHnogTlbOVounPfGKBXyKPOaqr;

		private KwJRYYJfhUodsqflVvXZeiVRhqcU.VEDjjlzzGxbDEsFplrwVrUFNvrQd WOSeJiYzerxywuMZyCeSoRtjSUvC;

		private NativeBuffer tTnjSIbmYAltduiXFfAqSmMdrYRF;

		[CompilerGenerated]
		private Action zVKSrcxfOagQhFfAKSOwLQnGezKf;

		private bool LiYULiQHRXySpFfULtJdvjynQBLh;

		public bool initialized => kbkbpffQhTLUDgPuPwhRBYLKglkeb;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = zVKSrcxfOagQhFfAKSOwLQnGezKf;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref zVKSrcxfOagQhFfAKSOwLQnGezKf, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = zVKSrcxfOagQhFfAKSOwLQnGezKf;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref zVKSrcxfOagQhFfAKSOwLQnGezKf, value2, action2);
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
			ttjDrgDQFLLgHAjQmjtOQzOfwNvoA = P_1;
			ypDUTVYQwGgVocnPKssgBprvbOyF = P_2;
			cZPdmmkMnLIRTNtkBCRjjvdgpXsh = P_3;
			hALGRGJAZRWzssrDgXfJJoOKMEcdb = P_4;
			nJwVXclJjEtwtEBCAKdIXuEzPYCN = new ADictionary<int, xiFtgBJFkEGohisLDEUCdkVzqFfqA>();
			ZrHnogTlbOVounPfGKBXyKPOaqr = new ADictionary<int, NrHRsbjtLxVWvMsSasrsCbxrglHeA>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				KwJRYYJfhUodsqflVvXZeiVRhqcU.SJRKPqFQUuDRUfRtGaIORzuVWWct(UnityTools.effectivePlatform);
				if (KwJRYYJfhUodsqflVvXZeiVRhqcU.jEyfBQwfocAXdhenwJQVTQMOpCjvA((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				kbkbpffQhTLUDgPuPwhRBYLKglkeb = true;
				if (P_2)
				{
					ofaEJPINFjbgcERFhlpvSlHFTIkic();
				}
				abDkNNsGeNdUpAHvwiIzFUsDHJuwA();
				tTnjSIbmYAltduiXFfAqSmMdrYRF = new NativeBuffer(56);
			}
			catch
			{
				kbkbpffQhTLUDgPuPwhRBYLKglkeb = false;
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
			_ = kbkbpffQhTLUDgPuPwhRBYLKglkeb;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (kbkbpffQhTLUDgPuPwhRBYLKglkeb)
			{
				ViHShjvYhqiWEvznwbiRMCAckFIM();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = kbkbpffQhTLUDgPuPwhRBYLKglkeb;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!kbkbpffQhTLUDgPuPwhRBYLKglkeb)
			{
				return null;
			}
			List<yTxKLgtyFntzrmhxUvcIusyQEikI> list = new List<yTxKLgtyFntzrmhxUvcIusyQEikI>();
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				foreach (KeyValuePair<int, xiFtgBJFkEGohisLDEUCdkVzqFfqA> item in nJwVXclJjEtwtEBCAKdIXuEzPYCN)
				{
					if (item.Value.IRRnpgMTjKrYzqGcetDvCWuKYEag)
					{
						list.Add(item.Value);
					}
				}
			}
			if (ypDUTVYQwGgVocnPKssgBprvbOyF)
			{
				foreach (KeyValuePair<int, NrHRsbjtLxVWvMsSasrsCbxrglHeA> item2 in ZrHnogTlbOVounPfGKBXyKPOaqr)
				{
					NrHRsbjtLxVWvMsSasrsCbxrglHeA value = item2.Value;
					if (value.IRRnpgMTjKrYzqGcetDvCWuKYEag)
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

		private int GjEuRYeIqBbAGASxYEZCCJAZWNxbA()
		{
			if (!kbkbpffQhTLUDgPuPwhRBYLKglkeb)
			{
				return 0;
			}
			return Math.Min(KwJRYYJfhUodsqflVvXZeiVRhqcU.ShEMxAopIgeTfSKvgLOxccsnBiYg(), 32);
		}

		private int uYYxTeBubwCjoeUcBltRppzrBAXGA()
		{
			if (!kbkbpffQhTLUDgPuPwhRBYLKglkeb)
			{
				return 0;
			}
			int num = GjEuRYeIqBbAGASxYEZCCJAZWNxbA();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!KwJRYYJfhUodsqflVvXZeiVRhqcU.xpNEjXRXGhUAJSaILAJVXiJOdNWb(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private xiFtgBJFkEGohisLDEUCdkVzqFfqA CrjBrHGxqKMftXnojTkCDgJqwwbL(int P_0)
		{
			IntPtr intPtr = KwJRYYJfhUodsqflVvXZeiVRhqcU.WCahfUsOqEOmWPreHsdiShuTmiCQ(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			qdGECWatufyXebprdISidsHKfSMVB qdGECWatufyXebprdISidsHKfSMVB2 = new qdGECWatufyXebprdISidsHKfSMVB(intPtr);
			MWycXiczxePqggmPLkAztFDmLRbg mWycXiczxePqggmPLkAztFDmLRbg = BETTyLakZiGBYJUYXNTWAnsOlqMq(P_0, qdGECWatufyXebprdISidsHKfSMVB2);
			if (mWycXiczxePqggmPLkAztFDmLRbg == null)
			{
				KwJRYYJfhUodsqflVvXZeiVRhqcU.xMamJbspEgAsMmiOhfopWpsDAGQBA(intPtr);
				return null;
			}
			return new xiFtgBJFkEGohisLDEUCdkVzqFfqA(qdGECWatufyXebprdISidsHKfSMVB2, mWycXiczxePqggmPLkAztFDmLRbg);
		}

		private NrHRsbjtLxVWvMsSasrsCbxrglHeA iageeEFPahqesjbKRsyJGUQCTAaPc(int P_0)
		{
			IntPtr intPtr = KwJRYYJfhUodsqflVvXZeiVRhqcU.jACMvhtTiPgxklOcQONglwDIAImR(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			bSvXbbvmYpklUYPzWvIUtANLiPPx bSvXbbvmYpklUYPzWvIUtANLiPPx2 = new bSvXbbvmYpklUYPzWvIUtANLiPPx(intPtr);
			MWycXiczxePqggmPLkAztFDmLRbg mWycXiczxePqggmPLkAztFDmLRbg = idoqtaPaztjtGgrdxAAbsAaigpdE(P_0, bSvXbbvmYpklUYPzWvIUtANLiPPx2);
			if (mWycXiczxePqggmPLkAztFDmLRbg == null)
			{
				return null;
			}
			if (!mWycXiczxePqggmPLkAztFDmLRbg.sqassXbwqFpRzVkcwIIRKkZQHNVn)
			{
				KwJRYYJfhUodsqflVvXZeiVRhqcU.bmjMJktLVRvQkKPnvSlbexdbHugS(intPtr);
				return null;
			}
			mWycXiczxePqggmPLkAztFDmLRbg.kvzawZGeEliGpykQYKAbgxXqVTANA = KwJRYYJfhUodsqflVvXZeiVRhqcU.jcGdsTPHWGdOIMcjTzSgfubqqDRV(bSvXbbvmYpklUYPzWvIUtANLiPPx2);
			return new NrHRsbjtLxVWvMsSasrsCbxrglHeA(bSvXbbvmYpklUYPzWvIUtANLiPPx2, mWycXiczxePqggmPLkAztFDmLRbg);
		}

		private MWycXiczxePqggmPLkAztFDmLRbg BETTyLakZiGBYJUYXNTWAnsOlqMq(int P_0, qdGECWatufyXebprdISidsHKfSMVB P_1)
		{
			if (!kbkbpffQhTLUDgPuPwhRBYLKglkeb)
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
			return new MWycXiczxePqggmPLkAztFDmLRbg
			{
				rjZUkFhOweOvYlPndnIYcEzPwqkK = P_0,
				qmUGUHgNjwiBTQuDdBISnJFqYGJs = KwJRYYJfhUodsqflVvXZeiVRhqcU.hSpNHVomZEJoEbnuQqfdUtCnYcNg(P_1),
				sqassXbwqFpRzVkcwIIRKkZQHNVn = KwJRYYJfhUodsqflVvXZeiVRhqcU.xpNEjXRXGhUAJSaILAJVXiJOdNWb(P_0),
				KDScKfkRsnLJHjnJdFDFomntmqXXB = KwJRYYJfhUodsqflVvXZeiVRhqcU.GmKheSWlVzeilTNtLFuuQZeIoCKu(P_1),
				KGPrVgGwlHjTgBdUDxUTbkNEbEoIA = KwJRYYJfhUodsqflVvXZeiVRhqcU.BFKQrxiRUlqLmjNTWbYnsaWjMVCJ(P_1),
				RtPVoFWjYyzazhivlkMIPFWfxsaE = KwJRYYJfhUodsqflVvXZeiVRhqcU.sWHkcnXFkgVQeNPzeBbSaXGYPaLR(P_0),
				SNdcbdYtNYkfkfGDLQmDHeUbZRGS = KwJRYYJfhUodsqflVvXZeiVRhqcU.dhJuAhiMrnGnJfaaRzXBJTxFrZFN(P_1),
				sZLGptAODsnrqiIJtnjdvBBrbAcGA = KwJRYYJfhUodsqflVvXZeiVRhqcU.HEfhGAwkONUAMDaXNgHIrSgxDeQo(P_1),
				UIAkrlYLZROlnCyQelrtPCPMeCDm = KwJRYYJfhUodsqflVvXZeiVRhqcU.FwgBlfhnDVbLGojPsFxYCduUCnwr(P_1),
				wMYdfxvfWvvLbEhVEajhVwWqGcOx = KwJRYYJfhUodsqflVvXZeiVRhqcU.NxefmIrBIQwZaBvrOYgBmjZrhwZB(P_1)
			};
		}

		private MWycXiczxePqggmPLkAztFDmLRbg idoqtaPaztjtGgrdxAAbsAaigpdE(int P_0, bSvXbbvmYpklUYPzWvIUtANLiPPx P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			qdGECWatufyXebprdISidsHKfSMVB qdGECWatufyXebprdISidsHKfSMVB2 = new qdGECWatufyXebprdISidsHKfSMVB(KwJRYYJfhUodsqflVvXZeiVRhqcU.PYvbVkwAdbWJnqZuHTTLIszWJcuJ(P_1));
			if (!qdGECWatufyXebprdISidsHKfSMVB2.IsValid)
			{
				return null;
			}
			return BETTyLakZiGBYJUYXNTWAnsOlqMq(P_0, qdGECWatufyXebprdISidsHKfSMVB2);
		}

		private void abDkNNsGeNdUpAHvwiIzFUsDHJuwA()
		{
			for (int i = 0; i < GjEuRYeIqBbAGASxYEZCCJAZWNxbA(); i++)
			{
				if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
				{
					IAnQarNibzxLCVOsLEGcfXNrymgk(i);
				}
				if (ypDUTVYQwGgVocnPKssgBprvbOyF)
				{
					xgUHInQpiIIOmAnUDAkGeDsznMRbb(i);
				}
			}
		}

		private void xITKZEZUgLebjBytbEIpcxARCmFG()
		{
			if (ypDUTVYQwGgVocnPKssgBprvbOyF)
			{
				foreach (KeyValuePair<int, NrHRsbjtLxVWvMsSasrsCbxrglHeA> item in ZrHnogTlbOVounPfGKBXyKPOaqr)
				{
					NrHRsbjtLxVWvMsSasrsCbxrglHeA value = item.Value;
					value.voliSYgFSBfyMhtAzCrhGMNHwjuMB();
					value.Dispose();
				}
				ZrHnogTlbOVounPfGKBXyKPOaqr.Clear();
			}
			if (!ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				return;
			}
			foreach (KeyValuePair<int, xiFtgBJFkEGohisLDEUCdkVzqFfqA> item2 in nJwVXclJjEtwtEBCAKdIXuEzPYCN)
			{
				xiFtgBJFkEGohisLDEUCdkVzqFfqA value2 = item2.Value;
				value2.voliSYgFSBfyMhtAzCrhGMNHwjuMB();
				value2.Dispose();
			}
			nJwVXclJjEtwtEBCAKdIXuEzPYCN.Clear();
		}

		private bool IAnQarNibzxLCVOsLEGcfXNrymgk(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (ypDUTVYQwGgVocnPKssgBprvbOyF && KwJRYYJfhUodsqflVvXZeiVRhqcU.xpNEjXRXGhUAJSaILAJVXiJOdNWb(P_0))
			{
				return false;
			}
			xiFtgBJFkEGohisLDEUCdkVzqFfqA xiFtgBJFkEGohisLDEUCdkVzqFfqA2 = CrjBrHGxqKMftXnojTkCDgJqwwbL(P_0);
			if (xiFtgBJFkEGohisLDEUCdkVzqFfqA2 == null)
			{
				return false;
			}
			int qYkXMFqPLnbmvnIcqTbdJjmnnkdJ = xiFtgBJFkEGohisLDEUCdkVzqFfqA2.qYkXMFqPLnbmvnIcqTbdJjmnnkdJ;
			if (nJwVXclJjEtwtEBCAKdIXuEzPYCN.ContainsKey(qYkXMFqPLnbmvnIcqTbdJjmnnkdJ))
			{
				nJwVXclJjEtwtEBCAKdIXuEzPYCN[qYkXMFqPLnbmvnIcqTbdJjmnnkdJ].voliSYgFSBfyMhtAzCrhGMNHwjuMB();
				nJwVXclJjEtwtEBCAKdIXuEzPYCN[qYkXMFqPLnbmvnIcqTbdJjmnnkdJ] = xiFtgBJFkEGohisLDEUCdkVzqFfqA2;
			}
			else
			{
				nJwVXclJjEtwtEBCAKdIXuEzPYCN.Add(qYkXMFqPLnbmvnIcqTbdJjmnnkdJ, xiFtgBJFkEGohisLDEUCdkVzqFfqA2);
			}
			xiFtgBJFkEGohisLDEUCdkVzqFfqA2.IvVWuRMzRlHmwkBXdApelpKDpcnm();
			return true;
		}

		private void pqULoKftyOJJjIfMVLoDJkziSLYo(int P_0)
		{
			if (nJwVXclJjEtwtEBCAKdIXuEzPYCN.ContainsKey(P_0))
			{
				nJwVXclJjEtwtEBCAKdIXuEzPYCN[P_0].voliSYgFSBfyMhtAzCrhGMNHwjuMB();
				nJwVXclJjEtwtEBCAKdIXuEzPYCN.Remove(P_0);
			}
		}

		private bool xgUHInQpiIIOmAnUDAkGeDsznMRbb(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!KwJRYYJfhUodsqflVvXZeiVRhqcU.xpNEjXRXGhUAJSaILAJVXiJOdNWb(P_0))
			{
				return false;
			}
			NrHRsbjtLxVWvMsSasrsCbxrglHeA nrHRsbjtLxVWvMsSasrsCbxrglHeA = iageeEFPahqesjbKRsyJGUQCTAaPc(P_0);
			if (nrHRsbjtLxVWvMsSasrsCbxrglHeA == null)
			{
				return false;
			}
			int qYkXMFqPLnbmvnIcqTbdJjmnnkdJ = nrHRsbjtLxVWvMsSasrsCbxrglHeA.qYkXMFqPLnbmvnIcqTbdJjmnnkdJ;
			if (ZrHnogTlbOVounPfGKBXyKPOaqr.ContainsKey(qYkXMFqPLnbmvnIcqTbdJjmnnkdJ))
			{
				ZrHnogTlbOVounPfGKBXyKPOaqr[qYkXMFqPLnbmvnIcqTbdJjmnnkdJ].voliSYgFSBfyMhtAzCrhGMNHwjuMB();
				ZrHnogTlbOVounPfGKBXyKPOaqr[qYkXMFqPLnbmvnIcqTbdJjmnnkdJ] = nrHRsbjtLxVWvMsSasrsCbxrglHeA;
			}
			else
			{
				ZrHnogTlbOVounPfGKBXyKPOaqr.Add(qYkXMFqPLnbmvnIcqTbdJjmnnkdJ, nrHRsbjtLxVWvMsSasrsCbxrglHeA);
			}
			nrHRsbjtLxVWvMsSasrsCbxrglHeA.IvVWuRMzRlHmwkBXdApelpKDpcnm();
			return true;
		}

		private void HzSqksQOZTFpFdaDYkKVOAFllIBj(int P_0)
		{
			if (ZrHnogTlbOVounPfGKBXyKPOaqr.ContainsKey(P_0))
			{
				ZrHnogTlbOVounPfGKBXyKPOaqr[P_0].voliSYgFSBfyMhtAzCrhGMNHwjuMB();
				ZrHnogTlbOVounPfGKBXyKPOaqr.Remove(P_0);
			}
		}

		private xiFtgBJFkEGohisLDEUCdkVzqFfqA VSvgAcKuxLBRqFMjXwCWkhJmazJzA(int P_0)
		{
			if (!nJwVXclJjEtwtEBCAKdIXuEzPYCN.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private NrHRsbjtLxVWvMsSasrsCbxrglHeA KVUazkGPREdKopTFrjTCknqOSLPlA(int P_0)
		{
			if (!ZrHnogTlbOVounPfGKBXyKPOaqr.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void ViHShjvYhqiWEvznwbiRMCAckFIM()
		{
			while (KwJRYYJfhUodsqflVvXZeiVRhqcU.KbiHIodaueQNOHoLcnjCjOePjeWsb(tTnjSIbmYAltduiXFfAqSmMdrYRF) != 0)
			{
				WOSeJiYzerxywuMZyCeSoRtjSUvC.shMCeYTPnlqLMkvXJMsANftDHTLH(tTnjSIbmYAltduiXFfAqSmMdrYRF);
				KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ iBbvOGRGjBfauCwEZCnFHiIisfzBb = WOSeJiYzerxywuMZyCeSoRtjSUvC.IBbvOGRGjBfauCwEZCnFHiIisfzBb;
				double realTime = ReInput.realTime;
				switch (iBbvOGRGjBfauCwEZCnFHiIisfzBb)
				{
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERAXISMOTION:
					WCtHFKQRsIGjBAOtkTruxwXphvck(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.LGMJJAcpGiatKZUeUyfPyxEsFrgN, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERBUTTONDOWN:
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERBUTTONUP:
					nfmegeKLTOhbPBbgecLHkRSBFYRMB(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.WCHgUFmyLeDnGDSEoLHoJqqAfMdb, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERDEVICEREMAPPED:
					BkzAZbeJcLHYJPIwvJYZKAsCkBrOA(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.DVJJrBQrdoJPPGsDEUedFkWCVptv);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYAXISMOTION:
					DpZwOYqTnWbSkBWrFjwRUvyksZaN(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.XEShnuaUcLxURaagIeaPmjRQhZZQA, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYBUTTONDOWN:
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYBUTTONUP:
					hOlnvpQSXtcLdDUblquNVqgDOEZT(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.AialupJbcXumUWgazjpaJVJFgfKdA, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYHATMOTION:
					DpMCajYbXYbuZHJYBBYnOiCXPfAv(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.NOtKXxKcOUzZmaviUJkCzHFdiToHA, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYBALLMOTION:
					XdsKBDWiMEDjcJiqcJdLucbtIcPgA(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.hnPNJFbqePgbkhYRiBUfDTtgOJIRB, realTime);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYDEVICEADDED:
					ZDuipCJZMjDvfkFinMsKqRWGSzYS(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.lCAOyBzouKRvTQUeXVRAPwHIzauk);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_JOYDEVICEREMOVED:
					mldmAYCYKZJtoESzlNIqkZQxgUaI(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.lCAOyBzouKRvTQUeXVRAPwHIzauk);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERDEVICEADDED:
					tdmRTrHDtyNDnQmyaSlQdWjrgtow(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.DVJJrBQrdoJPPGsDEUedFkWCVptv);
					break;
				case KwJRYYJfhUodsqflVvXZeiVRhqcU.UOOlDyXrQppYFCMJdZkkdSiRAqUJ.SDL_CONTROLLERDEVICEREMOVED:
					GyagGqpvxlWLWCwFFmsbjdYcFMiQ(ref WOSeJiYzerxywuMZyCeSoRtjSUvC.DVJJrBQrdoJPPGsDEUedFkWCVptv);
					break;
				}
			}
		}

		private void DpZwOYqTnWbSkBWrFjwRUvyksZaN(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.bXHPKRQEUvrOCvMeNcWmmShhsqjO P_0, double P_1)
		{
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				XxNnAJyGTOhCWtRckZRcNRJPDjZC(P_0.EGVmkBRihfENmgtulUaAsjMemGmiA, obZZMcwXxLpzVzsHXvFvGghQECsv.Axis, P_0.RjkDLDehgFPatEBYYaaslAZlKzbVA, P_0.oOtgvIyHZGCtdZVwFDnrYbJMAxtT, P_1);
			}
		}

		private void hOlnvpQSXtcLdDUblquNVqgDOEZT(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.DrCwxjFnECoGuNNYPEtdJxutpKhd P_0, double P_1)
		{
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				XxNnAJyGTOhCWtRckZRcNRJPDjZC(P_0.yIpZKUHWMheCvCPAxGSYHLMcvAeF, obZZMcwXxLpzVzsHXvFvGghQECsv.Button, P_0.EfjchjOcsHAFrvgyzajqkzIFvecTA, P_0.hsbETZfCjGqirjOrEhybWyNdjGEKA, P_1);
			}
		}

		private void DpMCajYbXYbuZHJYBBYnOiCXPfAv(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.YnHUTpXacGtcVdQZJklvhCVNlTTc P_0, double P_1)
		{
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				XxNnAJyGTOhCWtRckZRcNRJPDjZC(P_0.MxeHyBdKnIvaVLwDYaxYQAGthihj, obZZMcwXxLpzVzsHXvFvGghQECsv.Hat, P_0.wEhTrCKKWfWrCOmXrHrOzTjhEHIV, P_0.TLnYFarNHSXNoTYzqaggOfOMGsrD, P_1);
			}
		}

		private void XdsKBDWiMEDjcJiqcJdLucbtIcPgA(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.lKxKpTOoTBWrQSgROSHDJKcNmqGq P_0, double P_1)
		{
			_ = ttjDrgDQFLLgHAjQmjtOQzOfwNvoA;
		}

		private void ZDuipCJZMjDvfkFinMsKqRWGSzYS(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.VAFWRnOXPZNIWvNSXuaceoPgrPne P_0)
		{
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				IAnQarNibzxLCVOsLEGcfXNrymgk(P_0.NHfaHXbRJOqbnFLzMICeUmnLNBSVA);
				if (zVKSrcxfOagQhFfAKSOwLQnGezKf != null)
				{
					zVKSrcxfOagQhFfAKSOwLQnGezKf();
				}
			}
		}

		private void mldmAYCYKZJtoESzlNIqkZQxgUaI(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.VAFWRnOXPZNIWvNSXuaceoPgrPne P_0)
		{
			if (ttjDrgDQFLLgHAjQmjtOQzOfwNvoA)
			{
				pqULoKftyOJJjIfMVLoDJkziSLYo(P_0.NHfaHXbRJOqbnFLzMICeUmnLNBSVA);
				if (zVKSrcxfOagQhFfAKSOwLQnGezKf != null)
				{
					zVKSrcxfOagQhFfAKSOwLQnGezKf();
				}
			}
		}

		private void WCtHFKQRsIGjBAOtkTruxwXphvck(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.xCcWcIDvnMgJgbagLeRPwKtAPkSH P_0, double P_1)
		{
			if (ypDUTVYQwGgVocnPKssgBprvbOyF && P_0.FsgGRKaHmOPxRMlGGmuOgelfgZGOc != 6)
			{
				MasbREiwhMYNeLnnkhiZGdPfiXQgB(P_0.HOSEGzBtAvSeZRDsFDNpBwPAPHoC, obZZMcwXxLpzVzsHXvFvGghQECsv.Axis, P_0.FsgGRKaHmOPxRMlGGmuOgelfgZGOc, P_0.wanoiAErXgBvRGpnMdjDtfJbUKUT, P_1);
			}
		}

		private void nfmegeKLTOhbPBbgecLHkRSBFYRMB(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.GyPbHLIaLrWlTeUjuNSMKUEgJGtEb P_0, double P_1)
		{
			if (ypDUTVYQwGgVocnPKssgBprvbOyF && P_0.BpFstAjodnXWRbjOpGqPmPzXfCgj != 15)
			{
				MasbREiwhMYNeLnnkhiZGdPfiXQgB(P_0.frFfckSyehtQXNiexjMOwXfkcakX, obZZMcwXxLpzVzsHXvFvGghQECsv.Button, P_0.BpFstAjodnXWRbjOpGqPmPzXfCgj, P_0.PfGhEVQOQLixWRSsCHmKksuSKNnu, P_1);
			}
		}

		private void tdmRTrHDtyNDnQmyaSlQdWjrgtow(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.qxDoxlZGETGnKxfTtDoaHcXWBMTAA P_0)
		{
			if (ypDUTVYQwGgVocnPKssgBprvbOyF)
			{
				xgUHInQpiIIOmAnUDAkGeDsznMRbb(P_0.yBhdXgCWgKGlFICdZgkVDhleQQjJA);
				if (zVKSrcxfOagQhFfAKSOwLQnGezKf != null)
				{
					zVKSrcxfOagQhFfAKSOwLQnGezKf();
				}
			}
		}

		private void GyagGqpvxlWLWCwFFmsbjdYcFMiQ(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.qxDoxlZGETGnKxfTtDoaHcXWBMTAA P_0)
		{
			if (ypDUTVYQwGgVocnPKssgBprvbOyF)
			{
				HzSqksQOZTFpFdaDYkKVOAFllIBj(P_0.yBhdXgCWgKGlFICdZgkVDhleQQjJA);
				if (zVKSrcxfOagQhFfAKSOwLQnGezKf != null)
				{
					zVKSrcxfOagQhFfAKSOwLQnGezKf();
				}
			}
		}

		private void BkzAZbeJcLHYJPIwvJYZKAsCkBrOA(ref KwJRYYJfhUodsqflVvXZeiVRhqcU.qxDoxlZGETGnKxfTtDoaHcXWBMTAA P_0)
		{
			_ = ypDUTVYQwGgVocnPKssgBprvbOyF;
		}

		private void XxNnAJyGTOhCWtRckZRcNRJPDjZC(int P_0, obZZMcwXxLpzVzsHXvFvGghQECsv P_1, byte P_2, short P_3, double P_4)
		{
			VSvgAcKuxLBRqFMjXwCWkhJmazJzA(P_0)?.PIhcMdQVQdlBSRKlQLLHdPmnujlf(P_1, P_2, P_3, P_4);
		}

		private void MasbREiwhMYNeLnnkhiZGdPfiXQgB(int P_0, obZZMcwXxLpzVzsHXvFvGghQECsv P_1, byte P_2, short P_3, double P_4)
		{
			KVUazkGPREdKopTFrjTCknqOSLPlA(P_0)?.PIhcMdQVQdlBSRKlQLLHdPmnujlf(P_1, P_2, P_3, P_4);
		}

		private void ofaEJPINFjbgcERFhlpvSlHFTIkic()
		{
			string[] array = IOgkDjPdNfGuorjJLRrWUYUjuxOF.KRuDFZEpsVwpDuFhyjeUpgDZvVDf();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(KwJRYYJfhUodsqflVvXZeiVRhqcU.CjYTkCdwBEVOzFcTmSMZzoeRCOyE(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					KwJRYYJfhUodsqflVvXZeiVRhqcU.pbfNSwVqJohcbjJdJBpDlzBakLprA(array[i]);
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
			if (LiYULiQHRXySpFfULtJdvjynQBLh)
			{
				return;
			}
			if (disposing)
			{
				if (tTnjSIbmYAltduiXFfAqSmMdrYRF != null)
				{
					tTnjSIbmYAltduiXFfAqSmMdrYRF.Dispose();
				}
				xITKZEZUgLebjBytbEIpcxARCmFG();
			}
			KwJRYYJfhUodsqflVvXZeiVRhqcU.cXjWCAKHzZOCgdYErrjesmRKMnYm();
			kbkbpffQhTLUDgPuPwhRBYLKglkeb = false;
			LiYULiQHRXySpFfULtJdvjynQBLh = true;
		}
	}
}
