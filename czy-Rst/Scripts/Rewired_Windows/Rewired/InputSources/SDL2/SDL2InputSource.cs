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
		public delegate void SmlJMGwnqZueetZnxgBuKTmBEtmR(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void hZSxIbuXdLhUVFNLHlsilTZdhIDi(int joystickIndex);

		public delegate void hVPEYOuYdVdUHApUNthWzBYbgxih(int joystickId);

		public delegate void HyeEWbeRJijmdhkeGNRUfocOkIkE(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int rCMcmwZgRvHrPncOZfueSOMnfTmY = 32;

		private bool UktGTEKOCHsZnumZKhoWoqSjfJQn;

		private bool HiTgzlKbvMZCUjYCchamGvQzdQBD;

		private bool HzBNTAkgWNnUjMjjhRtryzKovZXc;

		private bool QMPgteCrSHZSUqLKQIoRCzMKGSLtA;

		private bool HNoLRFQjqDvrbSHvraiJIZXICnTuA;

		private ADictionary<int, QvPrGrXWzKRBBptUxdFKfGDhAVSY> STkpxQzPgCEERXQVanuKSVWxsGzs;

		private ADictionary<int, kwBTSNzMQzQnNXmXYBeaERphYruSA> cBlENCmZsfmeSrSQFLtTYeSTJoVm;

		private vhZtykZYqEQVSdbitUuXjEVVcqFs.kSVHRFzaqbEEcfQUJZkLyMMThnbx tsKUHOSbcheSQdDFARRSjGLlnGKp;

		private NativeBuffer EDnZSwjPSKOuLzQPpuBiDAthtAqF;

		[CompilerGenerated]
		private Action GBOqTMjjHsJaTIUNiFnuUNtAaJhk;

		private bool mpAgdSUlEPFFZOnTdwVfclefQyiJ;

		public bool initialized => HNoLRFQjqDvrbSHvraiJIZXICnTuA;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = GBOqTMjjHsJaTIUNiFnuUNtAaJhk;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref GBOqTMjjHsJaTIUNiFnuUNtAaJhk, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = GBOqTMjjHsJaTIUNiFnuUNtAaJhk;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref GBOqTMjjHsJaTIUNiFnuUNtAaJhk, value2, action2);
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
			UktGTEKOCHsZnumZKhoWoqSjfJQn = P_1;
			HiTgzlKbvMZCUjYCchamGvQzdQBD = P_2;
			HzBNTAkgWNnUjMjjhRtryzKovZXc = P_3;
			QMPgteCrSHZSUqLKQIoRCzMKGSLtA = P_4;
			STkpxQzPgCEERXQVanuKSVWxsGzs = new ADictionary<int, QvPrGrXWzKRBBptUxdFKfGDhAVSY>();
			cBlENCmZsfmeSrSQFLtTYeSTJoVm = new ADictionary<int, kwBTSNzMQzQnNXmXYBeaERphYruSA>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				vhZtykZYqEQVSdbitUuXjEVVcqFs.rEHCnWjDHqreutEoiqBEbauLpWHuA(UnityTools.effectivePlatform);
				if (vhZtykZYqEQVSdbitUuXjEVVcqFs.WYmEzwhslgfiLjnmAKPZXDOvIQEmc((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				HNoLRFQjqDvrbSHvraiJIZXICnTuA = true;
				if (P_2)
				{
					JiwIlnLmKrIBKGSKPnavPkNHLAFDb();
				}
				ZDFdlnkmxNQdLLGwYeXxlTmDNVPDb();
				EDnZSwjPSKOuLzQPpuBiDAthtAqF = new NativeBuffer(56);
			}
			catch
			{
				HNoLRFQjqDvrbSHvraiJIZXICnTuA = false;
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
			_ = HNoLRFQjqDvrbSHvraiJIZXICnTuA;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (HNoLRFQjqDvrbSHvraiJIZXICnTuA)
			{
				svDsHTxEyyoPuaCwSjaDFzAgfFhp();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = HNoLRFQjqDvrbSHvraiJIZXICnTuA;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!HNoLRFQjqDvrbSHvraiJIZXICnTuA)
			{
				return null;
			}
			List<ZnhcDWhSsvGoFpuQyaqClglYKkPD> list = new List<ZnhcDWhSsvGoFpuQyaqClglYKkPD>();
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				foreach (KeyValuePair<int, QvPrGrXWzKRBBptUxdFKfGDhAVSY> sTkpxQzPgCEERXQVanuKSVWxsGz in STkpxQzPgCEERXQVanuKSVWxsGzs)
				{
					if (sTkpxQzPgCEERXQVanuKSVWxsGz.Value.brPNbQGcWYbMJxLNGwclBuOYaYTP)
					{
						list.Add(sTkpxQzPgCEERXQVanuKSVWxsGz.Value);
					}
				}
			}
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD)
			{
				foreach (KeyValuePair<int, kwBTSNzMQzQnNXmXYBeaERphYruSA> item in cBlENCmZsfmeSrSQFLtTYeSTJoVm)
				{
					kwBTSNzMQzQnNXmXYBeaERphYruSA value = item.Value;
					if (value.brPNbQGcWYbMJxLNGwclBuOYaYTP)
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

		private int lVCrrigOtDwtaRsuaGvGCaGHhLIM()
		{
			if (!HNoLRFQjqDvrbSHvraiJIZXICnTuA)
			{
				return 0;
			}
			return Math.Min(vhZtykZYqEQVSdbitUuXjEVVcqFs.rbQycqkGDiBSJDpsYYyrnTcjHgxI(), 32);
		}

		private int FgCntQZNocdSExNprUeJewdfKKex()
		{
			if (!HNoLRFQjqDvrbSHvraiJIZXICnTuA)
			{
				return 0;
			}
			int num = lVCrrigOtDwtaRsuaGvGCaGHhLIM();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!vhZtykZYqEQVSdbitUuXjEVVcqFs.MjDaoTNkYxlEeRblnkXZEowGtniP(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private QvPrGrXWzKRBBptUxdFKfGDhAVSY pHznwbUllOhUBWbhRIBEWFJuexCj(int P_0)
		{
			IntPtr intPtr = vhZtykZYqEQVSdbitUuXjEVVcqFs.bKogDwDytIiBqGGftNggCPaHVozhB(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			JBUHesdLprAiYsccDuRstPHlCCfN jBUHesdLprAiYsccDuRstPHlCCfN = new JBUHesdLprAiYsccDuRstPHlCCfN(intPtr);
			xLaUnUyMsswyKdClfravuOBgHcWK xLaUnUyMsswyKdClfravuOBgHcWK2 = ikPtYzoqGkGkuIqTtqSCTsuUDipN(P_0, jBUHesdLprAiYsccDuRstPHlCCfN);
			if (xLaUnUyMsswyKdClfravuOBgHcWK2 == null)
			{
				vhZtykZYqEQVSdbitUuXjEVVcqFs.AAwbhBbyRcxfatvPHNhpbLaBpUbVA(intPtr);
				return null;
			}
			return new QvPrGrXWzKRBBptUxdFKfGDhAVSY(jBUHesdLprAiYsccDuRstPHlCCfN, xLaUnUyMsswyKdClfravuOBgHcWK2);
		}

		private kwBTSNzMQzQnNXmXYBeaERphYruSA JEcIGaRLzlRVEqXDfWxDXVKBbQFS(int P_0)
		{
			IntPtr intPtr = vhZtykZYqEQVSdbitUuXjEVVcqFs.OMMATNtxtPEKUgurinEsjgJCAGPhc(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			IwjmBPdqXfpAyRvksjwSyAFHnPqU iwjmBPdqXfpAyRvksjwSyAFHnPqU = new IwjmBPdqXfpAyRvksjwSyAFHnPqU(intPtr);
			xLaUnUyMsswyKdClfravuOBgHcWK xLaUnUyMsswyKdClfravuOBgHcWK2 = BFmcETVdzzGGVazeXZFjsnCqkqCKA(P_0, iwjmBPdqXfpAyRvksjwSyAFHnPqU);
			if (xLaUnUyMsswyKdClfravuOBgHcWK2 == null)
			{
				return null;
			}
			if (!xLaUnUyMsswyKdClfravuOBgHcWK2.FxiSShpcvFWaJATxKNUPZhHSfNsP)
			{
				vhZtykZYqEQVSdbitUuXjEVVcqFs.ICpAhQIzIHldATHiRwozknjrFwBgb(intPtr);
				return null;
			}
			xLaUnUyMsswyKdClfravuOBgHcWK2.HTvJYtgCDjbbLdlVkEJtMaVkdNtxA = vhZtykZYqEQVSdbitUuXjEVVcqFs.OCZOjmTREuvcrJidRPulkrqcFkjb(iwjmBPdqXfpAyRvksjwSyAFHnPqU);
			return new kwBTSNzMQzQnNXmXYBeaERphYruSA(iwjmBPdqXfpAyRvksjwSyAFHnPqU, xLaUnUyMsswyKdClfravuOBgHcWK2);
		}

		private xLaUnUyMsswyKdClfravuOBgHcWK ikPtYzoqGkGkuIqTtqSCTsuUDipN(int P_0, JBUHesdLprAiYsccDuRstPHlCCfN P_1)
		{
			if (!HNoLRFQjqDvrbSHvraiJIZXICnTuA)
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
			return new xLaUnUyMsswyKdClfravuOBgHcWK
			{
				OoJuevhgfcfVmuTaJiKSbChRudLK = P_0,
				TcEgshAqqmtivaZWDpRQCqZscUsLA = vhZtykZYqEQVSdbitUuXjEVVcqFs.QEldgfeadMBccmreqTzvBbpvhAcS(P_1),
				FxiSShpcvFWaJATxKNUPZhHSfNsP = vhZtykZYqEQVSdbitUuXjEVVcqFs.MjDaoTNkYxlEeRblnkXZEowGtniP(P_0),
				hbYkmFXHvlEwzGyQvyWThqtoHaoP = vhZtykZYqEQVSdbitUuXjEVVcqFs.zbUgCwaIKnGVLnUwvMzcOFwAeGpvA(P_1),
				hiDVvQIckDQiQIJHnjFRCcHEhCHSA = vhZtykZYqEQVSdbitUuXjEVVcqFs.esWcWRoTLxZBKsAIysbjdKWnOXfh(P_1),
				goJvanYGceBGFukvFCxQAkZvbdHdA = vhZtykZYqEQVSdbitUuXjEVVcqFs.VGLAAREVjuNxYIYyYxgGMnIYVmez(P_0),
				rnbZLAKOOeSQBcKppxNCFMxePvhA = vhZtykZYqEQVSdbitUuXjEVVcqFs.WXVPaRsSyjeWhwiprWOJUlbTLWgl(P_1),
				ROBDNZDKWqoEShvGBiydIyDrhGRvA = vhZtykZYqEQVSdbitUuXjEVVcqFs.qSrHMoaoDRbNgIiYrMsWuwaduhtL(P_1),
				xFGdPPaCINLnNwZRSgahHETSgsyWA = vhZtykZYqEQVSdbitUuXjEVVcqFs.eMqdCRdEODSbmvbUShKMZmuQHvVT(P_1),
				NLGLjTvLejQSNFUaqisnYWHigbdg = vhZtykZYqEQVSdbitUuXjEVVcqFs.sbbdLCvHOAAPtBOakNXyzEjdBbBjA(P_1)
			};
		}

		private xLaUnUyMsswyKdClfravuOBgHcWK BFmcETVdzzGGVazeXZFjsnCqkqCKA(int P_0, IwjmBPdqXfpAyRvksjwSyAFHnPqU P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			JBUHesdLprAiYsccDuRstPHlCCfN jBUHesdLprAiYsccDuRstPHlCCfN = new JBUHesdLprAiYsccDuRstPHlCCfN(vhZtykZYqEQVSdbitUuXjEVVcqFs.uZpNGUmEobxXJhVjfItBVOhYFQXh(P_1));
			if (!jBUHesdLprAiYsccDuRstPHlCCfN.IsValid)
			{
				return null;
			}
			return ikPtYzoqGkGkuIqTtqSCTsuUDipN(P_0, jBUHesdLprAiYsccDuRstPHlCCfN);
		}

		private void ZDFdlnkmxNQdLLGwYeXxlTmDNVPDb()
		{
			for (int i = 0; i < lVCrrigOtDwtaRsuaGvGCaGHhLIM(); i++)
			{
				if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
				{
					hGjaaZLycjEqoUkhvVHcijHxcbJH(i);
				}
				if (HiTgzlKbvMZCUjYCchamGvQzdQBD)
				{
					UiGEgPISlUcxKgFXdkxEZKwpTCcMA(i);
				}
			}
		}

		private void AOVkNuNlCPNrTOsGDTmxdGqXOBge()
		{
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD)
			{
				foreach (KeyValuePair<int, kwBTSNzMQzQnNXmXYBeaERphYruSA> item in cBlENCmZsfmeSrSQFLtTYeSTJoVm)
				{
					kwBTSNzMQzQnNXmXYBeaERphYruSA value = item.Value;
					value.KzzcqckaDPrPwIsDPLafqZZytrLnA();
					value.Dispose();
				}
				cBlENCmZsfmeSrSQFLtTYeSTJoVm.Clear();
			}
			if (!UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				return;
			}
			foreach (KeyValuePair<int, QvPrGrXWzKRBBptUxdFKfGDhAVSY> sTkpxQzPgCEERXQVanuKSVWxsGz in STkpxQzPgCEERXQVanuKSVWxsGzs)
			{
				QvPrGrXWzKRBBptUxdFKfGDhAVSY value2 = sTkpxQzPgCEERXQVanuKSVWxsGz.Value;
				value2.KzzcqckaDPrPwIsDPLafqZZytrLnA();
				value2.Dispose();
			}
			STkpxQzPgCEERXQVanuKSVWxsGzs.Clear();
		}

		private bool hGjaaZLycjEqoUkhvVHcijHxcbJH(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD && vhZtykZYqEQVSdbitUuXjEVVcqFs.MjDaoTNkYxlEeRblnkXZEowGtniP(P_0))
			{
				return false;
			}
			QvPrGrXWzKRBBptUxdFKfGDhAVSY qvPrGrXWzKRBBptUxdFKfGDhAVSY = pHznwbUllOhUBWbhRIBEWFJuexCj(P_0);
			if (qvPrGrXWzKRBBptUxdFKfGDhAVSY == null)
			{
				return false;
			}
			int tZwdRlkxMlQkFoEVKGxfOlurzKEh = qvPrGrXWzKRBBptUxdFKfGDhAVSY.TZwdRlkxMlQkFoEVKGxfOlurzKEh;
			if (STkpxQzPgCEERXQVanuKSVWxsGzs.ContainsKey(tZwdRlkxMlQkFoEVKGxfOlurzKEh))
			{
				STkpxQzPgCEERXQVanuKSVWxsGzs[tZwdRlkxMlQkFoEVKGxfOlurzKEh].KzzcqckaDPrPwIsDPLafqZZytrLnA();
				STkpxQzPgCEERXQVanuKSVWxsGzs[tZwdRlkxMlQkFoEVKGxfOlurzKEh] = qvPrGrXWzKRBBptUxdFKfGDhAVSY;
			}
			else
			{
				STkpxQzPgCEERXQVanuKSVWxsGzs.Add(tZwdRlkxMlQkFoEVKGxfOlurzKEh, qvPrGrXWzKRBBptUxdFKfGDhAVSY);
			}
			qvPrGrXWzKRBBptUxdFKfGDhAVSY.pmVerOOAonkWXhKRWXwAwOgRhQzB();
			return true;
		}

		private void YnOYOytzxIOyVRZVbhxDKvbuDPxQ(int P_0)
		{
			if (STkpxQzPgCEERXQVanuKSVWxsGzs.ContainsKey(P_0))
			{
				STkpxQzPgCEERXQVanuKSVWxsGzs[P_0].KzzcqckaDPrPwIsDPLafqZZytrLnA();
				STkpxQzPgCEERXQVanuKSVWxsGzs.Remove(P_0);
			}
		}

		private bool UiGEgPISlUcxKgFXdkxEZKwpTCcMA(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!vhZtykZYqEQVSdbitUuXjEVVcqFs.MjDaoTNkYxlEeRblnkXZEowGtniP(P_0))
			{
				return false;
			}
			kwBTSNzMQzQnNXmXYBeaERphYruSA kwBTSNzMQzQnNXmXYBeaERphYruSA2 = JEcIGaRLzlRVEqXDfWxDXVKBbQFS(P_0);
			if (kwBTSNzMQzQnNXmXYBeaERphYruSA2 == null)
			{
				return false;
			}
			int tZwdRlkxMlQkFoEVKGxfOlurzKEh = kwBTSNzMQzQnNXmXYBeaERphYruSA2.TZwdRlkxMlQkFoEVKGxfOlurzKEh;
			if (cBlENCmZsfmeSrSQFLtTYeSTJoVm.ContainsKey(tZwdRlkxMlQkFoEVKGxfOlurzKEh))
			{
				cBlENCmZsfmeSrSQFLtTYeSTJoVm[tZwdRlkxMlQkFoEVKGxfOlurzKEh].KzzcqckaDPrPwIsDPLafqZZytrLnA();
				cBlENCmZsfmeSrSQFLtTYeSTJoVm[tZwdRlkxMlQkFoEVKGxfOlurzKEh] = kwBTSNzMQzQnNXmXYBeaERphYruSA2;
			}
			else
			{
				cBlENCmZsfmeSrSQFLtTYeSTJoVm.Add(tZwdRlkxMlQkFoEVKGxfOlurzKEh, kwBTSNzMQzQnNXmXYBeaERphYruSA2);
			}
			kwBTSNzMQzQnNXmXYBeaERphYruSA2.pmVerOOAonkWXhKRWXwAwOgRhQzB();
			return true;
		}

		private void qyIAsGUEfBcFzufGshINXiDxIfsS(int P_0)
		{
			if (cBlENCmZsfmeSrSQFLtTYeSTJoVm.ContainsKey(P_0))
			{
				cBlENCmZsfmeSrSQFLtTYeSTJoVm[P_0].KzzcqckaDPrPwIsDPLafqZZytrLnA();
				cBlENCmZsfmeSrSQFLtTYeSTJoVm.Remove(P_0);
			}
		}

		private QvPrGrXWzKRBBptUxdFKfGDhAVSY kUnEcWSQgNAiEZWmpSXQmvVyltoL(int P_0)
		{
			if (!STkpxQzPgCEERXQVanuKSVWxsGzs.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private kwBTSNzMQzQnNXmXYBeaERphYruSA nRQJBEKmSAJdGyFUJKGQsayGQBeR(int P_0)
		{
			if (!cBlENCmZsfmeSrSQFLtTYeSTJoVm.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void svDsHTxEyyoPuaCwSjaDFzAgfFhp()
		{
			while (vhZtykZYqEQVSdbitUuXjEVVcqFs.pDwFkKizpsFccnQSZdsYEXclmozJA(EDnZSwjPSKOuLzQPpuBiDAthtAqF) != 0)
			{
				tsKUHOSbcheSQdDFARRSjGLlnGKp.RbSkumZkXtFAencChHOGMGzXAJyw(EDnZSwjPSKOuLzQPpuBiDAthtAqF);
				vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh rdzRouBnwZELMfsPvyeLrGCsTzGm = tsKUHOSbcheSQdDFARRSjGLlnGKp.rdzRouBnwZELMfsPvyeLrGCsTzGm;
				double realTime = ReInput.realTime;
				switch (rdzRouBnwZELMfsPvyeLrGCsTzGm)
				{
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERAXISMOTION:
					bKjEdmEvbQfQfBRcYVcewmPxbtDqA(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.uGOChgjyLcvAomSdgtoLxtKietBbb, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERBUTTONDOWN:
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERBUTTONUP:
					KimIIALkOOXWpiYzCgSFYsOVVWuV(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.fBAEGgTirLGmZFQXaKKNJEimFrlFb, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERDEVICEREMAPPED:
					qUfjbXPbjPelzBTtNqLBFZeYIDCaA(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.ciZbPhIUguFwrfRWayvbCYSMpnGkA);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYAXISMOTION:
					oZBOoiqcsQljMMncjLfDLnaonHXs(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.aIGFPUQLfPEhrhiripxBsZBQHByK, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYBUTTONDOWN:
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYBUTTONUP:
					KqhXVBKMCxyWPCdwXDvDCkgHJIww(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.fVkzUBXxtBiXqLAxHxyiAoFVmdxo, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYHATMOTION:
					usScoZKEUMDlrCBKjFXvFMlXzWpD(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.mqpavDhEVMWeILvjoFhSBeNduHXDb, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYBALLMOTION:
					sDsubpQyPCgkKMNhAmOJxpThqGkf(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.CBBZjvbHtJgKAFNSQkHrLCdKAHpeb, realTime);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYDEVICEADDED:
					sKkfNgdZHfhCLBphVhpYKlWWKvduA(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.UKWYYlnUnCBuvJatveIObOLOFxPXA);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_JOYDEVICEREMOVED:
					LcvbyabUDZoYIJTwJOYsbzEcliXzb(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.UKWYYlnUnCBuvJatveIObOLOFxPXA);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERDEVICEADDED:
					GBoUtDVZwgcHXRGvSySIwhlxtsZJ(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.ciZbPhIUguFwrfRWayvbCYSMpnGkA);
					break;
				case vhZtykZYqEQVSdbitUuXjEVVcqFs.xJABkMBJUdQebXiUJSIayQkXEExh.SDL_CONTROLLERDEVICEREMOVED:
					zpceeQcjmzZzuaZKpWdhMaUejKBAA(ref tsKUHOSbcheSQdDFARRSjGLlnGKp.ciZbPhIUguFwrfRWayvbCYSMpnGkA);
					break;
				}
			}
		}

		private void oZBOoiqcsQljMMncjLfDLnaonHXs(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.EqLvkdKYRhkzoihfhhFktPplnyGr P_0, double P_1)
		{
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				sJTPqregHSeKosREIOWgSDHJUDmR(P_0.jxHyKlHmavjwIfspPntKSgIgPQBxA, BgDhrSgirTWpvwWVfuvQJhjKOFHe.Axis, P_0.wuyGnxfOjXVNRUWTqFluHDJlYfAP, P_0.BSpOiQuUsGUFYMhPxMrJXBuEvUjc, P_1);
			}
		}

		private void KqhXVBKMCxyWPCdwXDvDCkgHJIww(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.oHUURNLCwICDUIlKrpLbGPndhnIGA P_0, double P_1)
		{
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				sJTPqregHSeKosREIOWgSDHJUDmR(P_0.RyhnHkZJIhTrDVZNTLEUSiRuxUDi, BgDhrSgirTWpvwWVfuvQJhjKOFHe.Button, P_0.tsnMIFCjpDuKBcvANyaawaWTeKHI, P_0.YvzgvzWjgQwVXXdacfjlhbBfMAxuA, P_1);
			}
		}

		private void usScoZKEUMDlrCBKjFXvFMlXzWpD(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.hkZsSnBJtKeCtazPzsdvsdCBabqeA P_0, double P_1)
		{
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				sJTPqregHSeKosREIOWgSDHJUDmR(P_0.xbajVrvBeEUmfYgYiGrAHFSnEhMHA, BgDhrSgirTWpvwWVfuvQJhjKOFHe.Hat, P_0.JYfQRmSoVvbYeRrUXYgEwOnryHhy, P_0.qMvkjEtiGAhkAMTRYfnuTbtEYACv, P_1);
			}
		}

		private void sDsubpQyPCgkKMNhAmOJxpThqGkf(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.GefBNvjKKVmCeuHGgkOBHYcDEepmA P_0, double P_1)
		{
			_ = UktGTEKOCHsZnumZKhoWoqSjfJQn;
		}

		private void sKkfNgdZHfhCLBphVhpYKlWWKvduA(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.kWZybTGVKRyTiuEOrtVkjHiwjwIj P_0)
		{
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				hGjaaZLycjEqoUkhvVHcijHxcbJH(P_0.exnKjrVcGYwMFSayqqJipLxNZuxK);
				if (GBOqTMjjHsJaTIUNiFnuUNtAaJhk != null)
				{
					GBOqTMjjHsJaTIUNiFnuUNtAaJhk();
				}
			}
		}

		private void LcvbyabUDZoYIJTwJOYsbzEcliXzb(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.kWZybTGVKRyTiuEOrtVkjHiwjwIj P_0)
		{
			if (UktGTEKOCHsZnumZKhoWoqSjfJQn)
			{
				YnOYOytzxIOyVRZVbhxDKvbuDPxQ(P_0.exnKjrVcGYwMFSayqqJipLxNZuxK);
				if (GBOqTMjjHsJaTIUNiFnuUNtAaJhk != null)
				{
					GBOqTMjjHsJaTIUNiFnuUNtAaJhk();
				}
			}
		}

		private void bKjEdmEvbQfQfBRcYVcewmPxbtDqA(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.AUwklwZcgCDIYmRtffQDrVbCNxvf P_0, double P_1)
		{
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD && P_0.mWmDtgVLjKgKxqNBsDbKrKxgKPju != 6)
			{
				nEwLtecXwIkaIivyQgbVoJLqVwzk(P_0.iSOuEHFekdafjYlIxvExAcqQYRZw, BgDhrSgirTWpvwWVfuvQJhjKOFHe.Axis, P_0.mWmDtgVLjKgKxqNBsDbKrKxgKPju, P_0.RdnYIqClCgKtpVxoyieXubFrAStw, P_1);
			}
		}

		private void KimIIALkOOXWpiYzCgSFYsOVVWuV(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.zpVjjjwnClAAliHwApDMNTIwPMAvA P_0, double P_1)
		{
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD && P_0.eIREYsrkCxayjqNzBNJVlxODhULe != 15)
			{
				nEwLtecXwIkaIivyQgbVoJLqVwzk(P_0.AMFFAOiKtpRzzGmxPVLEtshkiuFfA, BgDhrSgirTWpvwWVfuvQJhjKOFHe.Button, P_0.eIREYsrkCxayjqNzBNJVlxODhULe, P_0.ujQgcxMsVVeEiWWjuYzOpFcUiRKW, P_1);
			}
		}

		private void GBoUtDVZwgcHXRGvSySIwhlxtsZJ(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.BBVSsBRdNBfDwkZIJliaWQDUKpem P_0)
		{
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD)
			{
				UiGEgPISlUcxKgFXdkxEZKwpTCcMA(P_0.TxGrMbQdiGKvBVqjxpNWevqeUUMc);
				if (GBOqTMjjHsJaTIUNiFnuUNtAaJhk != null)
				{
					GBOqTMjjHsJaTIUNiFnuUNtAaJhk();
				}
			}
		}

		private void zpceeQcjmzZzuaZKpWdhMaUejKBAA(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.BBVSsBRdNBfDwkZIJliaWQDUKpem P_0)
		{
			if (HiTgzlKbvMZCUjYCchamGvQzdQBD)
			{
				qyIAsGUEfBcFzufGshINXiDxIfsS(P_0.TxGrMbQdiGKvBVqjxpNWevqeUUMc);
				if (GBOqTMjjHsJaTIUNiFnuUNtAaJhk != null)
				{
					GBOqTMjjHsJaTIUNiFnuUNtAaJhk();
				}
			}
		}

		private void qUfjbXPbjPelzBTtNqLBFZeYIDCaA(ref vhZtykZYqEQVSdbitUuXjEVVcqFs.BBVSsBRdNBfDwkZIJliaWQDUKpem P_0)
		{
			_ = HiTgzlKbvMZCUjYCchamGvQzdQBD;
		}

		private void sJTPqregHSeKosREIOWgSDHJUDmR(int P_0, BgDhrSgirTWpvwWVfuvQJhjKOFHe P_1, byte P_2, short P_3, double P_4)
		{
			kUnEcWSQgNAiEZWmpSXQmvVyltoL(P_0)?.mZrYdLQcUpeUeKwZqgKDkjPdEmOgA(P_1, P_2, P_3, P_4);
		}

		private void nEwLtecXwIkaIivyQgbVoJLqVwzk(int P_0, BgDhrSgirTWpvwWVfuvQJhjKOFHe P_1, byte P_2, short P_3, double P_4)
		{
			nRQJBEKmSAJdGyFUJKGQsayGQBeR(P_0)?.mZrYdLQcUpeUeKwZqgKDkjPdEmOgA(P_1, P_2, P_3, P_4);
		}

		private void JiwIlnLmKrIBKGSKPnavPkNHLAFDb()
		{
			string[] array = tTaOMFLCubrBKeCFxOKQBEqnaZrd.zGcnlfUygLZMvhNUOuaUsVVXtIaH();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(vhZtykZYqEQVSdbitUuXjEVVcqFs.dOIteujbUEuABSvGKVlJeScLCaVJ(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					vhZtykZYqEQVSdbitUuXjEVVcqFs.QcnzsILkOucTPJMspMqXfoVcNNCgb(array[i]);
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
			if (mpAgdSUlEPFFZOnTdwVfclefQyiJ)
			{
				return;
			}
			if (disposing)
			{
				if (EDnZSwjPSKOuLzQPpuBiDAthtAqF != null)
				{
					EDnZSwjPSKOuLzQPpuBiDAthtAqF.Dispose();
				}
				AOVkNuNlCPNrTOsGDTmxdGqXOBge();
			}
			vhZtykZYqEQVSdbitUuXjEVVcqFs.HrvncqKzgNanMyRRPrsezbHWDlnbA();
			HNoLRFQjqDvrbSHvraiJIZXICnTuA = false;
			mpAgdSUlEPFFZOnTdwVfclefQyiJ = true;
		}
	}
}
