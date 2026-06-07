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
		public delegate void mVYODCbzKBEghCKpEzCosIynGPGC(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void XJjdhtEfgFtNQNyuunJcIVhJZEroA(int joystickIndex);

		public delegate void VefYYfOqFoXEfmCycHMLooDaTWkA(int joystickId);

		public delegate void tlZgYGzwUiUNpGrNhmpNFuWukVMQ(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int DszAkgGOOfkdIeQrexSwVgoHsmYbA = 32;

		private bool iCAZYUXFPJfkqDinJCKIIiHnuwab;

		private bool dzglqbLCmMVhXCSbZGVosxLBfWbn;

		private bool nJkODSfJnPhLmjUSYRvjSnVEqUny;

		private bool aCcnozLHTxcXGTjnSWLcRegobveB;

		private bool pRDBqPVbwNLpudQZQQLsrrYsWboc;

		private ADictionary<int, kKcUrlWIsWzJKGjtCfpCJSdZBisp> ayTrDYqbmOqXYwyOFQSMiiRTxKDe;

		private ADictionary<int, YGiWyNskVjDwCqVkbSowpTHFOOGH> YsYfPQrQvpaEZcInapjBHcsihDtxB;

		private TLgiAoUVfCyIREMLAuHTFAzrCRtx.AdkfPBKundDqfrEfePCTjAqCjGFAc LoxZKCHsnvyiLYooxfdCHqpXMdsO;

		private NativeBuffer koEnDiogYIxmGYLfQqEazykRVYAl;

		[CompilerGenerated]
		private Action irhSiKeyGwlpChpaPsvmkpJciVHBA;

		private bool SFtTyUPAJTmpSzYuILWtEBWPQlEy;

		public bool initialized => pRDBqPVbwNLpudQZQQLsrrYsWboc;

		private event Action _DeviceChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = irhSiKeyGwlpChpaPsvmkpJciVHBA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref irhSiKeyGwlpChpaPsvmkpJciVHBA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = irhSiKeyGwlpChpaPsvmkpJciVHBA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref irhSiKeyGwlpChpaPsvmkpJciVHBA, value2, action2);
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
			iCAZYUXFPJfkqDinJCKIIiHnuwab = P_1;
			dzglqbLCmMVhXCSbZGVosxLBfWbn = P_2;
			nJkODSfJnPhLmjUSYRvjSnVEqUny = P_3;
			aCcnozLHTxcXGTjnSWLcRegobveB = P_4;
			ayTrDYqbmOqXYwyOFQSMiiRTxKDe = new ADictionary<int, kKcUrlWIsWzJKGjtCfpCJSdZBisp>();
			YsYfPQrQvpaEZcInapjBHcsihDtxB = new ADictionary<int, YGiWyNskVjDwCqVkbSowpTHFOOGH>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				TLgiAoUVfCyIREMLAuHTFAzrCRtx.VNojROKHUyFSjlhTPBpKHYUhQfzhA(UnityTools.effectivePlatform);
				if (TLgiAoUVfCyIREMLAuHTFAzrCRtx.ujBBjurvombMIUzRdnrTrryanbow((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				pRDBqPVbwNLpudQZQQLsrrYsWboc = true;
				if (P_2)
				{
					hSHxfMYPbohLhhbhiCrOEzttllTB();
				}
				himjujzYmNRvEvLHdpvlffGhugll();
				koEnDiogYIxmGYLfQqEazykRVYAl = new NativeBuffer(56);
			}
			catch
			{
				pRDBqPVbwNLpudQZQQLsrrYsWboc = false;
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
			_ = pRDBqPVbwNLpudQZQQLsrrYsWboc;
		}

		void IInputSource.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (pRDBqPVbwNLpudQZQQLsrrYsWboc)
			{
				MKkBtDqcvqrJlVJRjIIBjheAfaPO();
			}
		}

		void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
			this.UpdateDevices(updateLoop);
		}

		public void UpdateFinished()
		{
			_ = pRDBqPVbwNLpudQZQQLsrrYsWboc;
		}

		void IInputSource.UpdateFinished()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
			this.UpdateFinished();
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!pRDBqPVbwNLpudQZQQLsrrYsWboc)
			{
				return null;
			}
			List<lCQLyMgHDpqaOULHBFMANOWmXxtv> list = new List<lCQLyMgHDpqaOULHBFMANOWmXxtv>();
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				foreach (KeyValuePair<int, kKcUrlWIsWzJKGjtCfpCJSdZBisp> item in ayTrDYqbmOqXYwyOFQSMiiRTxKDe)
				{
					if (item.Value.HByARADXLAVsISEmluMzvlmyLfxz)
					{
						list.Add(item.Value);
					}
				}
			}
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn)
			{
				foreach (KeyValuePair<int, YGiWyNskVjDwCqVkbSowpTHFOOGH> item2 in YsYfPQrQvpaEZcInapjBHcsihDtxB)
				{
					YGiWyNskVjDwCqVkbSowpTHFOOGH value = item2.Value;
					if (value.HByARADXLAVsISEmluMzvlmyLfxz)
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

		private int VllbngfbsHJenywRRsUCyVmvuvuh()
		{
			if (!pRDBqPVbwNLpudQZQQLsrrYsWboc)
			{
				return 0;
			}
			return Math.Min(TLgiAoUVfCyIREMLAuHTFAzrCRtx.TQjpoefyQkMjWchVlnsxPaURMoDq(), 32);
		}

		private int zprbWOEjQimeTIhCSQNVIeBRdPAK()
		{
			if (!pRDBqPVbwNLpudQZQQLsrrYsWboc)
			{
				return 0;
			}
			int num = VllbngfbsHJenywRRsUCyVmvuvuh();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!TLgiAoUVfCyIREMLAuHTFAzrCRtx.iauDmDHGFzlRznoAIktXnwWwRQOZ(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private kKcUrlWIsWzJKGjtCfpCJSdZBisp LYSlbjFusQcNEzaEkhuCAazAaTabb(int P_0)
		{
			IntPtr intPtr = TLgiAoUVfCyIREMLAuHTFAzrCRtx.ZUZPXcjEoEBnrjgQAbEoExIlOFTrA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			rFjcmnamizCDRXHkylGeDAfLtBXI rFjcmnamizCDRXHkylGeDAfLtBXI2 = new rFjcmnamizCDRXHkylGeDAfLtBXI(intPtr);
			PHTwOSfBtovGZIvMEGVvQSdSiweP pHTwOSfBtovGZIvMEGVvQSdSiweP = CTwYxxzRXyKWdhwXOwpApQsiJTxc(P_0, rFjcmnamizCDRXHkylGeDAfLtBXI2);
			if (pHTwOSfBtovGZIvMEGVvQSdSiweP == null)
			{
				TLgiAoUVfCyIREMLAuHTFAzrCRtx.kqHlAPtBQqZvzUUuePrzdRUjhyVi(intPtr);
				return null;
			}
			return new kKcUrlWIsWzJKGjtCfpCJSdZBisp(rFjcmnamizCDRXHkylGeDAfLtBXI2, pHTwOSfBtovGZIvMEGVvQSdSiweP);
		}

		private YGiWyNskVjDwCqVkbSowpTHFOOGH xpTAqvIydnzTKFaqAHTnhuZtdxFc(int P_0)
		{
			IntPtr intPtr = TLgiAoUVfCyIREMLAuHTFAzrCRtx.mrvZiHwioTeoLTlMBcgaKVbsGhnbA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			gGWJsLqSTpcJnaZFVUmICpmbskMd gGWJsLqSTpcJnaZFVUmICpmbskMd2 = new gGWJsLqSTpcJnaZFVUmICpmbskMd(intPtr);
			PHTwOSfBtovGZIvMEGVvQSdSiweP pHTwOSfBtovGZIvMEGVvQSdSiweP = tbZfWPWWetDqADOFakfpCFmbAZcnB(P_0, gGWJsLqSTpcJnaZFVUmICpmbskMd2);
			if (pHTwOSfBtovGZIvMEGVvQSdSiweP == null)
			{
				return null;
			}
			if (!pHTwOSfBtovGZIvMEGVvQSdSiweP.tHRMulsbqJWgEnSSblXHzofyalKi)
			{
				TLgiAoUVfCyIREMLAuHTFAzrCRtx.ssYhVKyTDTBAXuLDaQjpXbBJaBxv(intPtr);
				return null;
			}
			pHTwOSfBtovGZIvMEGVvQSdSiweP.pXIMGhjQKbVVWOclLxWhGpuEetTC = TLgiAoUVfCyIREMLAuHTFAzrCRtx.qKzgKxSuIUOBliHVAzbuALVMEqWFA(gGWJsLqSTpcJnaZFVUmICpmbskMd2);
			return new YGiWyNskVjDwCqVkbSowpTHFOOGH(gGWJsLqSTpcJnaZFVUmICpmbskMd2, pHTwOSfBtovGZIvMEGVvQSdSiweP);
		}

		private PHTwOSfBtovGZIvMEGVvQSdSiweP CTwYxxzRXyKWdhwXOwpApQsiJTxc(int P_0, rFjcmnamizCDRXHkylGeDAfLtBXI P_1)
		{
			if (!pRDBqPVbwNLpudQZQQLsrrYsWboc)
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
			return new PHTwOSfBtovGZIvMEGVvQSdSiweP
			{
				qDyredklmkVDdDcNaVOMBRZbsDtx = P_0,
				rGtCivjUneRMkuFnkobMAsjOTlWp = TLgiAoUVfCyIREMLAuHTFAzrCRtx.wpCarjAleCJYbbTTBKRvWzHBDdUYA(P_1),
				tHRMulsbqJWgEnSSblXHzofyalKi = TLgiAoUVfCyIREMLAuHTFAzrCRtx.iauDmDHGFzlRznoAIktXnwWwRQOZ(P_0),
				BQpmZKCabjCCoHvlEeAHJNvKJeKd = TLgiAoUVfCyIREMLAuHTFAzrCRtx.XFdCSeRjXnqjSrONGrRipPGqVtVr(P_1),
				PmqdnWZmbPYFXtxmGnqZGjLajGzE = TLgiAoUVfCyIREMLAuHTFAzrCRtx.UcnqqHxQExgjZZpfTbMhDZyLbjFV(P_1),
				SdybptjTzetaISRCyYTUkcbRPYxAA = TLgiAoUVfCyIREMLAuHTFAzrCRtx.zPsCjHQYusNSZlPFbQMUDIooVkGf(P_0),
				JGOEXFNTROTsVZhtIBVXoNqJekNHA = TLgiAoUVfCyIREMLAuHTFAzrCRtx.kIialHzdvlqguPaAWaeFinTfWyUl(P_1),
				bEoaJDRrRsaiFOOvmwQxImdBIrrDA = TLgiAoUVfCyIREMLAuHTFAzrCRtx.GdAyLireIFsRpzmpQFmSCOOToVFZA(P_1),
				RppTUTTXDNJXCoIcvEehkmncDUOG = TLgiAoUVfCyIREMLAuHTFAzrCRtx.KdJplPsSDLWmzEhzhniIjpMsFGzgA(P_1),
				twtkZFgeUjZiWqGpTnElgmaCENXW = TLgiAoUVfCyIREMLAuHTFAzrCRtx.UWUeDMfgTAwfqhQHLGtsJNLXoYrDA(P_1)
			};
		}

		private PHTwOSfBtovGZIvMEGVvQSdSiweP tbZfWPWWetDqADOFakfpCFmbAZcnB(int P_0, gGWJsLqSTpcJnaZFVUmICpmbskMd P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			rFjcmnamizCDRXHkylGeDAfLtBXI rFjcmnamizCDRXHkylGeDAfLtBXI2 = new rFjcmnamizCDRXHkylGeDAfLtBXI(TLgiAoUVfCyIREMLAuHTFAzrCRtx.MVGPFOhufhIPWGPOCfmDvTZwpihM(P_1));
			if (!rFjcmnamizCDRXHkylGeDAfLtBXI2.IsValid)
			{
				return null;
			}
			return CTwYxxzRXyKWdhwXOwpApQsiJTxc(P_0, rFjcmnamizCDRXHkylGeDAfLtBXI2);
		}

		private void himjujzYmNRvEvLHdpvlffGhugll()
		{
			for (int i = 0; i < VllbngfbsHJenywRRsUCyVmvuvuh(); i++)
			{
				if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
				{
					NxCWeNYOjhBejklQEpzkdEtZuRnab(i);
				}
				if (dzglqbLCmMVhXCSbZGVosxLBfWbn)
				{
					oXxwRJTewUGXBcnaWqRSmWCLmzGq(i);
				}
			}
		}

		private void gfgLoeWFoLebAKrHgPxrcDmbMrCYA()
		{
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn)
			{
				foreach (KeyValuePair<int, YGiWyNskVjDwCqVkbSowpTHFOOGH> item in YsYfPQrQvpaEZcInapjBHcsihDtxB)
				{
					YGiWyNskVjDwCqVkbSowpTHFOOGH value = item.Value;
					value.oiEbwstwIVjprHYyaqOtvofAMOlQ();
					value.Dispose();
				}
				YsYfPQrQvpaEZcInapjBHcsihDtxB.Clear();
			}
			if (!iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				return;
			}
			foreach (KeyValuePair<int, kKcUrlWIsWzJKGjtCfpCJSdZBisp> item2 in ayTrDYqbmOqXYwyOFQSMiiRTxKDe)
			{
				kKcUrlWIsWzJKGjtCfpCJSdZBisp value2 = item2.Value;
				value2.oiEbwstwIVjprHYyaqOtvofAMOlQ();
				value2.Dispose();
			}
			ayTrDYqbmOqXYwyOFQSMiiRTxKDe.Clear();
		}

		private bool NxCWeNYOjhBejklQEpzkdEtZuRnab(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn && TLgiAoUVfCyIREMLAuHTFAzrCRtx.iauDmDHGFzlRznoAIktXnwWwRQOZ(P_0))
			{
				return false;
			}
			kKcUrlWIsWzJKGjtCfpCJSdZBisp kKcUrlWIsWzJKGjtCfpCJSdZBisp2 = LYSlbjFusQcNEzaEkhuCAazAaTabb(P_0);
			if (kKcUrlWIsWzJKGjtCfpCJSdZBisp2 == null)
			{
				return false;
			}
			int vvJWlppaBxokUFlyhsSxsdOLUSmL = kKcUrlWIsWzJKGjtCfpCJSdZBisp2.vvJWlppaBxokUFlyhsSxsdOLUSmL;
			if (ayTrDYqbmOqXYwyOFQSMiiRTxKDe.ContainsKey(vvJWlppaBxokUFlyhsSxsdOLUSmL))
			{
				ayTrDYqbmOqXYwyOFQSMiiRTxKDe[vvJWlppaBxokUFlyhsSxsdOLUSmL].oiEbwstwIVjprHYyaqOtvofAMOlQ();
				ayTrDYqbmOqXYwyOFQSMiiRTxKDe[vvJWlppaBxokUFlyhsSxsdOLUSmL] = kKcUrlWIsWzJKGjtCfpCJSdZBisp2;
			}
			else
			{
				ayTrDYqbmOqXYwyOFQSMiiRTxKDe.Add(vvJWlppaBxokUFlyhsSxsdOLUSmL, kKcUrlWIsWzJKGjtCfpCJSdZBisp2);
			}
			kKcUrlWIsWzJKGjtCfpCJSdZBisp2.LdmHgnFKLrERTICjqFrkYjetnKwo();
			return true;
		}

		private void cWxMxiuMwIMrUwacOTvPodHYggPj(int P_0)
		{
			if (ayTrDYqbmOqXYwyOFQSMiiRTxKDe.ContainsKey(P_0))
			{
				ayTrDYqbmOqXYwyOFQSMiiRTxKDe[P_0].oiEbwstwIVjprHYyaqOtvofAMOlQ();
				ayTrDYqbmOqXYwyOFQSMiiRTxKDe.Remove(P_0);
			}
		}

		private bool oXxwRJTewUGXBcnaWqRSmWCLmzGq(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!TLgiAoUVfCyIREMLAuHTFAzrCRtx.iauDmDHGFzlRznoAIktXnwWwRQOZ(P_0))
			{
				return false;
			}
			YGiWyNskVjDwCqVkbSowpTHFOOGH yGiWyNskVjDwCqVkbSowpTHFOOGH = xpTAqvIydnzTKFaqAHTnhuZtdxFc(P_0);
			if (yGiWyNskVjDwCqVkbSowpTHFOOGH == null)
			{
				return false;
			}
			int vvJWlppaBxokUFlyhsSxsdOLUSmL = yGiWyNskVjDwCqVkbSowpTHFOOGH.vvJWlppaBxokUFlyhsSxsdOLUSmL;
			if (YsYfPQrQvpaEZcInapjBHcsihDtxB.ContainsKey(vvJWlppaBxokUFlyhsSxsdOLUSmL))
			{
				YsYfPQrQvpaEZcInapjBHcsihDtxB[vvJWlppaBxokUFlyhsSxsdOLUSmL].oiEbwstwIVjprHYyaqOtvofAMOlQ();
				YsYfPQrQvpaEZcInapjBHcsihDtxB[vvJWlppaBxokUFlyhsSxsdOLUSmL] = yGiWyNskVjDwCqVkbSowpTHFOOGH;
			}
			else
			{
				YsYfPQrQvpaEZcInapjBHcsihDtxB.Add(vvJWlppaBxokUFlyhsSxsdOLUSmL, yGiWyNskVjDwCqVkbSowpTHFOOGH);
			}
			yGiWyNskVjDwCqVkbSowpTHFOOGH.LdmHgnFKLrERTICjqFrkYjetnKwo();
			return true;
		}

		private void GIzOIUBlBJnSaDVfXLrDnBzHgEIN(int P_0)
		{
			if (YsYfPQrQvpaEZcInapjBHcsihDtxB.ContainsKey(P_0))
			{
				YsYfPQrQvpaEZcInapjBHcsihDtxB[P_0].oiEbwstwIVjprHYyaqOtvofAMOlQ();
				YsYfPQrQvpaEZcInapjBHcsihDtxB.Remove(P_0);
			}
		}

		private kKcUrlWIsWzJKGjtCfpCJSdZBisp YAyWQJzjNIdHolXIznIYhbMWzKh(int P_0)
		{
			if (!ayTrDYqbmOqXYwyOFQSMiiRTxKDe.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private YGiWyNskVjDwCqVkbSowpTHFOOGH VVfZhUDBwODmJPpWmgREASnuuZYc(int P_0)
		{
			if (!YsYfPQrQvpaEZcInapjBHcsihDtxB.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void MKkBtDqcvqrJlVJRjIIBjheAfaPO()
		{
			while (TLgiAoUVfCyIREMLAuHTFAzrCRtx.JFowUizoyEOjRUtioWWbzWNwPRfA(koEnDiogYIxmGYLfQqEazykRVYAl) != 0)
			{
				LoxZKCHsnvyiLYooxfdCHqpXMdsO.nsnquyKbjdfhhYrnQYxOotTvMyOr(koEnDiogYIxmGYLfQqEazykRVYAl);
				TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA btOgisUanJxlFIpeQGgFHaaAHGit = LoxZKCHsnvyiLYooxfdCHqpXMdsO.BtOgisUanJxlFIpeQGgFHaaAHGit;
				double realTime = ReInput.realTime;
				switch (btOgisUanJxlFIpeQGgFHaaAHGit)
				{
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERAXISMOTION:
					ZUYbswPGmEIiuioZtiMsGJtLEGhW(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.SldlWypGWmcglxEUNIADBNaWkGzN, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERBUTTONDOWN:
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERBUTTONUP:
					iSDWIaKZoIieIXQIboPlukPjbEfB(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.BSpfGifUgFOMEubaDreHsuWUwKBU, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERDEVICEREMAPPED:
					KkSjBVIwvVPDkuSHwjhJfOMouVie(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.KmgZnbDghqkAeoRfXFVvDasgoKirA);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYAXISMOTION:
					WDgwNababOHlZpSHAFiVdyAMwQpF(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.EdKLUTFaJILsaIIdBBToGlCugSNB, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYBUTTONDOWN:
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYBUTTONUP:
					suOLTVZtNnSfUbTBsJkBstMrpiUk(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.PlZOeFEDsZEnbgTOowUguwllaCHT, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYHATMOTION:
					QjfLcTRGHGAfoCjsQlzdtbsnDUBRA(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.WFWffLDIGMaSTAVMPKHYIvfNoujX, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYBALLMOTION:
					UzHwkbTDWOtMVnFCzUGPRLZBYZOR(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.agibdvqFoNFwByAdxFhnKuXyKoZjb, realTime);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYDEVICEADDED:
					QvVDSeIaGjGcSKiYmLqELGcqDEFv(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.iVhKOrkpcWMnocJAYqmYyrfuGplf);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_JOYDEVICEREMOVED:
					fREyAoPbYDieRwXLasWgNXuTJYlF(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.iVhKOrkpcWMnocJAYqmYyrfuGplf);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERDEVICEADDED:
					oFDbkRMTtuCYWwfQpAxAEOJFALrf(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.KmgZnbDghqkAeoRfXFVvDasgoKirA);
					break;
				case TLgiAoUVfCyIREMLAuHTFAzrCRtx.JztqHYGZOrvesyDrsaiuHUYjLpPIA.SDL_CONTROLLERDEVICEREMOVED:
					JfRAcUyfvzzDjqupOTNjKfsCxxxQ(ref LoxZKCHsnvyiLYooxfdCHqpXMdsO.KmgZnbDghqkAeoRfXFVvDasgoKirA);
					break;
				}
			}
		}

		private void WDgwNababOHlZpSHAFiVdyAMwQpF(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.cAskHrDSCxDChBfQSbpwPLLXMHqo P_0, double P_1)
		{
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				IueBDvBfAGUqlTZzjBqmdixavoIsB(P_0.TMuCyxKlpxWbHPIKocXOOOoAGnlt, dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Axis, P_0.EYHbnwekHDbCxjccNXyIdjvDMyvB, P_0.nHEkIctHLGPyCdUIWAuzttjyuSiW, P_1);
			}
		}

		private void suOLTVZtNnSfUbTBsJkBstMrpiUk(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.GDnCILKQtUzbTfwbCHjvsNVTHSgU P_0, double P_1)
		{
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				IueBDvBfAGUqlTZzjBqmdixavoIsB(P_0.npSJtcMKWzCbIgngazrSuKpMFGbcA, dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Button, P_0.VNYkKJPOeVmKUBDUkaEoHIcvMHnDb, P_0.sEEljSFtgGlJGyRXDFoxLrvLpWTE, P_1);
			}
		}

		private void QjfLcTRGHGAfoCjsQlzdtbsnDUBRA(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.NAkcczeWgSBgiHRyIGFxlOwSnUKib P_0, double P_1)
		{
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				IueBDvBfAGUqlTZzjBqmdixavoIsB(P_0.TsPpdhaQhSRyinjpDJTYnzcHKIml, dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Hat, P_0.hjSBncXbWjgulahvoGcAMcNTcUFm, P_0.IIMAsIckZOcGNbzepKBkZvRsJzwTA, P_1);
			}
		}

		private void UzHwkbTDWOtMVnFCzUGPRLZBYZOR(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.eOUVCnPIZDbifertXfaBBwAjSZLCA P_0, double P_1)
		{
			_ = iCAZYUXFPJfkqDinJCKIIiHnuwab;
		}

		private void QvVDSeIaGjGcSKiYmLqELGcqDEFv(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.QnkYgNPBDDLEhLrzGQVmJGGKFSaHA P_0)
		{
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				NxCWeNYOjhBejklQEpzkdEtZuRnab(P_0.SHUdibMBCMavGjLuPrduXJNfesPd);
				if (irhSiKeyGwlpChpaPsvmkpJciVHBA != null)
				{
					irhSiKeyGwlpChpaPsvmkpJciVHBA();
				}
			}
		}

		private void fREyAoPbYDieRwXLasWgNXuTJYlF(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.QnkYgNPBDDLEhLrzGQVmJGGKFSaHA P_0)
		{
			if (iCAZYUXFPJfkqDinJCKIIiHnuwab)
			{
				cWxMxiuMwIMrUwacOTvPodHYggPj(P_0.SHUdibMBCMavGjLuPrduXJNfesPd);
				if (irhSiKeyGwlpChpaPsvmkpJciVHBA != null)
				{
					irhSiKeyGwlpChpaPsvmkpJciVHBA();
				}
			}
		}

		private void ZUYbswPGmEIiuioZtiMsGJtLEGhW(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.wlPQwgWUpEzwBPjSKCTBHlTmlkTw P_0, double P_1)
		{
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn && P_0.KZIlyObeSHkcBZyRlPURLVAVqLgA != 6)
			{
				RNFnosppXMAVJJNZfPPRStiAkNXd(P_0.AOhayRDSppIXeXhbEIknoiQqxofDA, dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Axis, P_0.KZIlyObeSHkcBZyRlPURLVAVqLgA, P_0.lSCSQcZTNsyYwcBLDUANCUlVjsVf, P_1);
			}
		}

		private void iSDWIaKZoIieIXQIboPlukPjbEfB(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.TYcncbfJOtuAacDXxhRUjurEpmcd P_0, double P_1)
		{
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn && P_0.KzelGkoozrYjyBVswnoNPMVfKAnl != 15)
			{
				RNFnosppXMAVJJNZfPPRStiAkNXd(P_0.uVmBAULYmrDLirFOoUjCPoHIjHxx, dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Button, P_0.KzelGkoozrYjyBVswnoNPMVfKAnl, P_0.EzbasbBrQXwqjdXWVHVQDJUceoqDA, P_1);
			}
		}

		private void oFDbkRMTtuCYWwfQpAxAEOJFALrf(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.xsoPCVCQGTKVjFhlqCRsksryShEAA P_0)
		{
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn)
			{
				oXxwRJTewUGXBcnaWqRSmWCLmzGq(P_0.zhYgtKHjiIccwIoXCqPVGQPKLvsGA);
				if (irhSiKeyGwlpChpaPsvmkpJciVHBA != null)
				{
					irhSiKeyGwlpChpaPsvmkpJciVHBA();
				}
			}
		}

		private void JfRAcUyfvzzDjqupOTNjKfsCxxxQ(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.xsoPCVCQGTKVjFhlqCRsksryShEAA P_0)
		{
			if (dzglqbLCmMVhXCSbZGVosxLBfWbn)
			{
				GIzOIUBlBJnSaDVfXLrDnBzHgEIN(P_0.zhYgtKHjiIccwIoXCqPVGQPKLvsGA);
				if (irhSiKeyGwlpChpaPsvmkpJciVHBA != null)
				{
					irhSiKeyGwlpChpaPsvmkpJciVHBA();
				}
			}
		}

		private void KkSjBVIwvVPDkuSHwjhJfOMouVie(ref TLgiAoUVfCyIREMLAuHTFAzrCRtx.xsoPCVCQGTKVjFhlqCRsksryShEAA P_0)
		{
			_ = dzglqbLCmMVhXCSbZGVosxLBfWbn;
		}

		private void IueBDvBfAGUqlTZzjBqmdixavoIsB(int P_0, dVoLlUxjpPIyeHjpWVGrrnZugrtEA P_1, byte P_2, short P_3, double P_4)
		{
			YAyWQJzjNIdHolXIznIYhbMWzKh(P_0)?.OvIZYBTJRfgspdmoRotRMDxXfTmu(P_1, P_2, P_3, P_4);
		}

		private void RNFnosppXMAVJJNZfPPRStiAkNXd(int P_0, dVoLlUxjpPIyeHjpWVGrrnZugrtEA P_1, byte P_2, short P_3, double P_4)
		{
			VVfZhUDBwODmJPpWmgREASnuuZYc(P_0)?.OvIZYBTJRfgspdmoRotRMDxXfTmu(P_1, P_2, P_3, P_4);
		}

		private void hSHxfMYPbohLhhbhiCrOEzttllTB()
		{
			string[] array = PKTlSLKCHfmBVFIxKsjAjboLgVXs.FRVAjrcJhJwnwgArrXSOfSrfPUAz();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(TLgiAoUVfCyIREMLAuHTFAzrCRtx.FezrhicSZUMGMdblzPhPISCtTdfp(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					TLgiAoUVfCyIREMLAuHTFAzrCRtx.kRCySKEVVejYSvSZOKjBYrpGggcL(array[i]);
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
			if (SFtTyUPAJTmpSzYuILWtEBWPQlEy)
			{
				return;
			}
			if (disposing)
			{
				if (koEnDiogYIxmGYLfQqEazykRVYAl != null)
				{
					koEnDiogYIxmGYLfQqEazykRVYAl.Dispose();
				}
				gfgLoeWFoLebAKrHgPxrcDmbMrCYA();
			}
			TLgiAoUVfCyIREMLAuHTFAzrCRtx.fBIoYqLxJHDjTJFwkMgkJmraYnVH();
			pRDBqPVbwNLpudQZQQLsrrYsWboc = false;
			SFtTyUPAJTmpSzYuILWtEBWPQlEy = true;
		}
	}
}
