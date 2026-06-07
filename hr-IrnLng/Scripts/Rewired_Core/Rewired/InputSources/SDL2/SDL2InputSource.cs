using System;
using System.Collections.Generic;
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
		public delegate void YBQykgfnbwLAilptjcgyBFoJBnWN(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void zojBUHnwMmPhNNLPVEFioKPzfif(int joystickIndex);

		public delegate void hGsVamtKqmJNDUNnLeYGBcYhYiOd(int joystickId);

		public delegate void FLXwDgluIRLWgrwvUkXJquoQgGG(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int HURcRgAnSOkgdLiCWDmvrEyIxWO = 32;

		private bool PbyhNBOEDhbNoCeKjEMDqIEDKC;

		private bool YBlWzJDolZAgldWQxpxQqgrxJUV;

		private bool fPdfCbrEyOcGiZWMmtJsZlnSFIF;

		private bool QSGVPtmrFlRVhCgNDOeYBOvwOTw;

		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		private ADictionary<int, OUgdcHhQmlMrDebWxXeQGqHzlPyU> kjwFdZmRbOPrZUBwYofYzTFLQnc;

		private ADictionary<int, ggshungMJQPHDVjJMpDqElvvczQ> QYUMPReFZfPlWGmPWRapOiBXhvvF;

		private blqhAICLjdxoAhSwtLtZkkXVbevB.IrDBCACCcIthaCdNzrNbonLEgJOm vfNzqsjgBudpIQbkBSDnJKlRQvs;

		private NativeBuffer QbLjDZnVbMualsArhMRDjkPbDPU;

		private Action GQaDQPkqdmlfJzHYYMBBAFWNYQom;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public bool initialized => rXobafaxvUDrItlgWahiaYSKJqn;

		private event Action _DeviceChangedEvent
		{
			add
			{
				Action action = GQaDQPkqdmlfJzHYYMBBAFWNYQom;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref GQaDQPkqdmlfJzHYYMBBAFWNYQom, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = GQaDQPkqdmlfJzHYYMBBAFWNYQom;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref GQaDQPkqdmlfJzHYYMBBAFWNYQom, value2, action2);
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

		public SDL2InputSource(UpdateLoopSetting updateLoop, bool handleJoysticks, bool handleGamepads, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
		{
			PbyhNBOEDhbNoCeKjEMDqIEDKC = handleJoysticks;
			YBlWzJDolZAgldWQxpxQqgrxJUV = handleGamepads;
			fPdfCbrEyOcGiZWMmtJsZlnSFIF = handleUnifiedMouse;
			QSGVPtmrFlRVhCgNDOeYBOvwOTw = handleUnifiedKeyboard;
			kjwFdZmRbOPrZUBwYofYzTFLQnc = new ADictionary<int, OUgdcHhQmlMrDebWxXeQGqHzlPyU>();
			QYUMPReFZfPlWGmPWRapOiBXhvvF = new ADictionary<int, ggshungMJQPHDVjJMpDqElvvczQ>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				blqhAICLjdxoAhSwtLtZkkXVbevB.MhoQGlolyxhksCFrRJMqFGImCgF(UnityTools.effectivePlatform);
				if (blqhAICLjdxoAhSwtLtZkkXVbevB.OsfGOpJmVTSWKRRvuZdFsUXhlG((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				rXobafaxvUDrItlgWahiaYSKJqn = true;
				if (handleGamepads)
				{
					urgjvaiFQyWdbmxFpiRDKgXaZLo();
				}
				iUHTNiUSzIbgZkRVgCdbwSbphZH();
				QbLjDZnVbMualsArhMRDjkPbDPU = new NativeBuffer(56);
			}
			catch
			{
				rXobafaxvUDrItlgWahiaYSKJqn = false;
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
			_ = rXobafaxvUDrItlgWahiaYSKJqn;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				pKqWJjjjZPvFavbPqxlXqRWWjXN();
			}
		}

		public void UpdateFinished()
		{
			_ = rXobafaxvUDrItlgWahiaYSKJqn;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return null;
			}
			List<PECWzsyRHQmqJrheqhVEuVmEOuh> list = new List<PECWzsyRHQmqJrheqhVEuVmEOuh>();
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				foreach (KeyValuePair<int, OUgdcHhQmlMrDebWxXeQGqHzlPyU> item in kjwFdZmRbOPrZUBwYofYzTFLQnc)
				{
					OUgdcHhQmlMrDebWxXeQGqHzlPyU value = item.Value;
					if (value.IsValid)
					{
						list.Add(item.Value);
					}
				}
			}
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				foreach (KeyValuePair<int, ggshungMJQPHDVjJMpDqElvvczQ> item2 in QYUMPReFZfPlWGmPWRapOiBXhvvF)
				{
					ggshungMJQPHDVjJMpDqElvvczQ value2 = item2.Value;
					if (value2.IsValid)
					{
						list.Add(value2);
					}
				}
			}
			return list as IList<T>;
		}

		private int KBbaNyfbKboHawwoguWWVisyCPKj()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return 0;
			}
			return Math.Min(blqhAICLjdxoAhSwtLtZkkXVbevB.mSYishsMPIZUgYjHSkvsCxiTQgP(), 32);
		}

		private int OcWWwQEfPpbjBtbwtzAlRQMWdzP()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return 0;
			}
			int num = KBbaNyfbKboHawwoguWWVisyCPKj();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (!blqhAICLjdxoAhSwtLtZkkXVbevB.TKOsnnMFkhPdMbxDBOoXyzaKTPF(i))
				{
					num2++;
				}
			}
			return num2;
		}

		private OUgdcHhQmlMrDebWxXeQGqHzlPyU ncjaufNeIugGzopeTiPLeWrDbKS(int P_0)
		{
			IntPtr intPtr = blqhAICLjdxoAhSwtLtZkkXVbevB.kEwBPWVwWAQjKAEqbYEeohMZDYG(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			HrrSCSuLeAJEIoHkHDmudoDhKKXF hrrSCSuLeAJEIoHkHDmudoDhKKXF = new HrrSCSuLeAJEIoHkHDmudoDhKKXF(intPtr);
			nNuVsdZxHYtWhtbvImxtnLaTgc nNuVsdZxHYtWhtbvImxtnLaTgc2 = kRnfvEVfLwsFJUmMzPrOqhiPXnv(P_0, hrrSCSuLeAJEIoHkHDmudoDhKKXF);
			if (nNuVsdZxHYtWhtbvImxtnLaTgc2 == null)
			{
				blqhAICLjdxoAhSwtLtZkkXVbevB.nDWEPuIsNPGyaCccDQhVeqlCNdFc(intPtr);
				return null;
			}
			return new OUgdcHhQmlMrDebWxXeQGqHzlPyU(hrrSCSuLeAJEIoHkHDmudoDhKKXF, nNuVsdZxHYtWhtbvImxtnLaTgc2);
		}

		private ggshungMJQPHDVjJMpDqElvvczQ JYgqRXeMnApiikqAJSxeIckLlRT(int P_0)
		{
			IntPtr intPtr = blqhAICLjdxoAhSwtLtZkkXVbevB.pWYFbcImQfAyfFIueAxxpcPZncs(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			WHMdxhdgWApeuhBoasHYAfNRHBAr wHMdxhdgWApeuhBoasHYAfNRHBAr = new WHMdxhdgWApeuhBoasHYAfNRHBAr(intPtr);
			nNuVsdZxHYtWhtbvImxtnLaTgc nNuVsdZxHYtWhtbvImxtnLaTgc2 = mBOAkfJaHQRwsrWDUaHxhNZtbLs(P_0, wHMdxhdgWApeuhBoasHYAfNRHBAr);
			if (nNuVsdZxHYtWhtbvImxtnLaTgc2 == null)
			{
				return null;
			}
			if (!nNuVsdZxHYtWhtbvImxtnLaTgc2.VjQTFGTPeABliEUxEaDhSqJgqcad)
			{
				blqhAICLjdxoAhSwtLtZkkXVbevB.peoUiabpVgYAUipVPZmXhKiiDSX(intPtr);
				return null;
			}
			nNuVsdZxHYtWhtbvImxtnLaTgc2.iiSTExMiHYwCqXJDsMrnFbtdknJ = blqhAICLjdxoAhSwtLtZkkXVbevB.ZNZIsVZuKxTtgIfvdetziSAvXfxq(wHMdxhdgWApeuhBoasHYAfNRHBAr);
			return new ggshungMJQPHDVjJMpDqElvvczQ(wHMdxhdgWApeuhBoasHYAfNRHBAr, nNuVsdZxHYtWhtbvImxtnLaTgc2);
		}

		private nNuVsdZxHYtWhtbvImxtnLaTgc kRnfvEVfLwsFJUmMzPrOqhiPXnv(int P_0, HrrSCSuLeAJEIoHkHDmudoDhKKXF P_1)
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
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
			nNuVsdZxHYtWhtbvImxtnLaTgc nNuVsdZxHYtWhtbvImxtnLaTgc2 = new nNuVsdZxHYtWhtbvImxtnLaTgc();
			nNuVsdZxHYtWhtbvImxtnLaTgc2.YeoWTxCQgRnimGZWwTJsKNURUbe = P_0;
			nNuVsdZxHYtWhtbvImxtnLaTgc2.sdUcfBHJKZrpwNGKHzcwwlwLVTI = blqhAICLjdxoAhSwtLtZkkXVbevB.QMRQpuKgczqyeMOUUeoAPUcnSMz(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.VjQTFGTPeABliEUxEaDhSqJgqcad = blqhAICLjdxoAhSwtLtZkkXVbevB.TKOsnnMFkhPdMbxDBOoXyzaKTPF(P_0);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.SzYRXywEPUSdsLwYXuWDoPjSZCH = blqhAICLjdxoAhSwtLtZkkXVbevB.WLcoMZPESqjzmGoommJqAWRExkR(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.CMFtfkGsxOEywTzjktNctHAIUpO = blqhAICLjdxoAhSwtLtZkkXVbevB.qzDITyNjiTpxmADEgMPyqsbnInB(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.QjIgOSUFmhjTxyJFVchIHcvaGPRD = blqhAICLjdxoAhSwtLtZkkXVbevB.eWSHxglFMJuedQFERunzvRiSXAC(P_0);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.qrXpdbCUzFLCBfjCDTfPHyJCus = blqhAICLjdxoAhSwtLtZkkXVbevB.MxKelPWvPNEqAJuuZEtTiosNRiT(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.rGEuFEtJcMmFaLOCcsmbRHUjSpy = blqhAICLjdxoAhSwtLtZkkXVbevB.uCCqFXYuqupkojGarmvGFSEUtFI(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.EgZAgydUSUMAbFugLVPACbffArM = blqhAICLjdxoAhSwtLtZkkXVbevB.yhEafLeTwFMuVgqdYcPlkKtQVbZ(P_1);
			nNuVsdZxHYtWhtbvImxtnLaTgc2.YheYnwPCtGgZIFrqJXlGuLcCMmg = blqhAICLjdxoAhSwtLtZkkXVbevB.KQfPyTihSLnMGHNKuyTXzCwghuA(P_1);
			return nNuVsdZxHYtWhtbvImxtnLaTgc2;
		}

		private nNuVsdZxHYtWhtbvImxtnLaTgc mBOAkfJaHQRwsrWDUaHxhNZtbLs(int P_0, WHMdxhdgWApeuhBoasHYAfNRHBAr P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			HrrSCSuLeAJEIoHkHDmudoDhKKXF hrrSCSuLeAJEIoHkHDmudoDhKKXF = new HrrSCSuLeAJEIoHkHDmudoDhKKXF(blqhAICLjdxoAhSwtLtZkkXVbevB.xGtzAUkmruaDslttDHXGbgbJGRl(P_1));
			if (!hrrSCSuLeAJEIoHkHDmudoDhKKXF.IsValid)
			{
				return null;
			}
			return kRnfvEVfLwsFJUmMzPrOqhiPXnv(P_0, hrrSCSuLeAJEIoHkHDmudoDhKKXF);
		}

		private void iUHTNiUSzIbgZkRVgCdbwSbphZH()
		{
			for (int i = 0; i < KBbaNyfbKboHawwoguWWVisyCPKj(); i++)
			{
				if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
				{
					tUnghiHvJLidlTBQdQnaACAvMpOh(i);
				}
				if (YBlWzJDolZAgldWQxpxQqgrxJUV)
				{
					trjYiqklzjBcbzmNPEIpDAuJKYT(i);
				}
			}
		}

		private void MNKbAPISFmUunCotMijatTBuRAwI()
		{
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				foreach (KeyValuePair<int, ggshungMJQPHDVjJMpDqElvvczQ> item in QYUMPReFZfPlWGmPWRapOiBXhvvF)
				{
					ggshungMJQPHDVjJMpDqElvvczQ value = item.Value;
					value.PyThGYEUvHVBltEuomLEiPVXvqC();
					value.Dispose();
				}
				QYUMPReFZfPlWGmPWRapOiBXhvvF.Clear();
			}
			if (!PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				return;
			}
			foreach (KeyValuePair<int, OUgdcHhQmlMrDebWxXeQGqHzlPyU> item2 in kjwFdZmRbOPrZUBwYofYzTFLQnc)
			{
				OUgdcHhQmlMrDebWxXeQGqHzlPyU value2 = item2.Value;
				value2.PyThGYEUvHVBltEuomLEiPVXvqC();
				value2.Dispose();
			}
			kjwFdZmRbOPrZUBwYofYzTFLQnc.Clear();
		}

		private bool tUnghiHvJLidlTBQdQnaACAvMpOh(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (YBlWzJDolZAgldWQxpxQqgrxJUV && blqhAICLjdxoAhSwtLtZkkXVbevB.TKOsnnMFkhPdMbxDBOoXyzaKTPF(P_0))
			{
				return false;
			}
			OUgdcHhQmlMrDebWxXeQGqHzlPyU oUgdcHhQmlMrDebWxXeQGqHzlPyU = ncjaufNeIugGzopeTiPLeWrDbKS(P_0);
			if (oUgdcHhQmlMrDebWxXeQGqHzlPyU == null)
			{
				return false;
			}
			int rtfomaLcybcuzWrpSDyohFWaFege = oUgdcHhQmlMrDebWxXeQGqHzlPyU.rtfomaLcybcuzWrpSDyohFWaFege;
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc.ContainsKey(rtfomaLcybcuzWrpSDyohFWaFege))
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[rtfomaLcybcuzWrpSDyohFWaFege].PyThGYEUvHVBltEuomLEiPVXvqC();
				kjwFdZmRbOPrZUBwYofYzTFLQnc[rtfomaLcybcuzWrpSDyohFWaFege] = oUgdcHhQmlMrDebWxXeQGqHzlPyU;
			}
			else
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc.Add(rtfomaLcybcuzWrpSDyohFWaFege, oUgdcHhQmlMrDebWxXeQGqHzlPyU);
			}
			oUgdcHhQmlMrDebWxXeQGqHzlPyU.iDBXctPcOcjjzWbKaCnxuPiVNUc();
			return true;
		}

		private void PIUibaZzJyyFaqSXWQcpLHakJEY(int P_0)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc.ContainsKey(P_0))
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[P_0].PyThGYEUvHVBltEuomLEiPVXvqC();
				kjwFdZmRbOPrZUBwYofYzTFLQnc.Remove(P_0);
			}
		}

		private bool trjYiqklzjBcbzmNPEIpDAuJKYT(int P_0)
		{
			if (P_0 < 0 || P_0 >= 32)
			{
				return false;
			}
			if (!blqhAICLjdxoAhSwtLtZkkXVbevB.TKOsnnMFkhPdMbxDBOoXyzaKTPF(P_0))
			{
				return false;
			}
			ggshungMJQPHDVjJMpDqElvvczQ ggshungMJQPHDVjJMpDqElvvczQ2 = JYgqRXeMnApiikqAJSxeIckLlRT(P_0);
			if (ggshungMJQPHDVjJMpDqElvvczQ2 == null)
			{
				return false;
			}
			int rtfomaLcybcuzWrpSDyohFWaFege = ggshungMJQPHDVjJMpDqElvvczQ2.rtfomaLcybcuzWrpSDyohFWaFege;
			if (QYUMPReFZfPlWGmPWRapOiBXhvvF.ContainsKey(rtfomaLcybcuzWrpSDyohFWaFege))
			{
				QYUMPReFZfPlWGmPWRapOiBXhvvF[rtfomaLcybcuzWrpSDyohFWaFege].PyThGYEUvHVBltEuomLEiPVXvqC();
				QYUMPReFZfPlWGmPWRapOiBXhvvF[rtfomaLcybcuzWrpSDyohFWaFege] = ggshungMJQPHDVjJMpDqElvvczQ2;
			}
			else
			{
				QYUMPReFZfPlWGmPWRapOiBXhvvF.Add(rtfomaLcybcuzWrpSDyohFWaFege, ggshungMJQPHDVjJMpDqElvvczQ2);
			}
			ggshungMJQPHDVjJMpDqElvvczQ2.iDBXctPcOcjjzWbKaCnxuPiVNUc();
			return true;
		}

		private void DpLJKOzAkYddWZLEweHMvDzIRIl(int P_0)
		{
			if (QYUMPReFZfPlWGmPWRapOiBXhvvF.ContainsKey(P_0))
			{
				QYUMPReFZfPlWGmPWRapOiBXhvvF[P_0].PyThGYEUvHVBltEuomLEiPVXvqC();
				QYUMPReFZfPlWGmPWRapOiBXhvvF.Remove(P_0);
			}
		}

		private OUgdcHhQmlMrDebWxXeQGqHzlPyU cdEZCmjuLpaiXcSXdaIfUVrroQg(int P_0)
		{
			if (!kjwFdZmRbOPrZUBwYofYzTFLQnc.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private ggshungMJQPHDVjJMpDqElvvczQ efxFnJaoxTbKmEYtibSmzMrOevi(int P_0)
		{
			if (!QYUMPReFZfPlWGmPWRapOiBXhvvF.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void pKqWJjjjZPvFavbPqxlXqRWWjXN()
		{
			while (blqhAICLjdxoAhSwtLtZkkXVbevB.stmEOeiiloUzDFVCLTfIRgkNHjsj(QbLjDZnVbMualsArhMRDjkPbDPU) != 0)
			{
				vfNzqsjgBudpIQbkBSDnJKlRQvs.dcjUMvxDxFTLluYUqwOUVWpUcUG(QbLjDZnVbMualsArhMRDjkPbDPU);
				blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR bAPyGAfeWoGVtSjhtFRwzpyXFad = vfNzqsjgBudpIQbkBSDnJKlRQvs.bAPyGAfeWoGVtSjhtFRwzpyXFad;
				double realTime = ReInput.realTime;
				switch (bAPyGAfeWoGVtSjhtFRwzpyXFad)
				{
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.iSQKeRukzVbAhGKnmEkRTIOqpnMH:
					DTGbuLtulXLgulRtrcSDkUdOcWT(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.vEEFwaCxWfzlysvDbfQErGsUdfp, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.MMUfzlBVXpIxBYRVYHkTObGmLsOo:
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.oiwDHCkEeskNqcnDkMiQmOXZmyrA:
					mXqTOrcLBXQDyOVlOckjlmYDIkb(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.HuBFzzNcpJSTQybNttNmkNLFeJTK, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.xgJFTcFrybXigTySQZjbeJhtkbM:
					OoPVBXrBrVRtVxaveXnctGUlcRvE(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.WhiATIJaQsHavvEoOSVhKaSCpfmz);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.uIqmYqSzmiwDivTQSEVUYIdIKpH:
					XHCKPjWOvLUPGAJxCzDTlhAdfBA(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.BNrxTRCqiJBuRamGvlKLNfifenl, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.neiUkuhtalPHuGTvYlNfSDscNLx:
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.UJoyVVfGBbAmZGynsvIlZTTVavN:
					ZwntXVTAKbnCsYpRJoGyODTRleh(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.hQACFTewZtbkSaTBeacZcRtVOaNZ, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.GpsBqQCayvHbwfiUONraqhwcNjx:
					gFfpIUvvvruGklNcJtGHiBQzdOT(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.FejghpvSuWfVVFeOXOfKAgIKbQPL, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.ZEdCKkgyeKIiCCHOBrANNtXhzAH:
					oNiZJaaZdmKYcDTGJQquwdlyrGi(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.HDIZEMRiHGRGabiAtbpGLzFYczc, realTime);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.nGcfIsPhzFqQTeDncDgfCjhKewVf:
					mcvxWschSVCvgrbPhxivIriqdnz(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.upYqpKwYrFLpLXzdswJvmTMBKBK);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.MODLJCRtIKDxRsKVFBaOnGADQPN:
					aLiGHuKezacFEduXCAyQKtzFnrez(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.upYqpKwYrFLpLXzdswJvmTMBKBK);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.DzJwbpqBanfbhlZTXdecfqFsDjZ:
					ZsFoppJRpogjqSKwKzEMZPPfIhW(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.WhiATIJaQsHavvEoOSVhKaSCpfmz);
					break;
				case blqhAICLjdxoAhSwtLtZkkXVbevB.lTdlbtjqAuIsKTgDwHGFfLFCtfAR.wLvbFgkRLehfsDlOSrUydmsGZTlq:
					bhqciyERsYQvoUAMHLszxlvfMhQ(ref vfNzqsjgBudpIQbkBSDnJKlRQvs.WhiATIJaQsHavvEoOSVhKaSCpfmz);
					break;
				}
			}
		}

		private void XHCKPjWOvLUPGAJxCzDTlhAdfBA(ref blqhAICLjdxoAhSwtLtZkkXVbevB.fJGvkQLktnoLszBBPVtpyKYBiIE P_0, double P_1)
		{
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				RZmOiWwbjvcsfAkXapgajxRQmywy(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD, LMwPWmrezsdezcEObLBzCJnGuOt.vOLImljxsbFUhrkbOfeHLOkwnVi, P_0.TYONpsQjDmdnPNgQXukLoEDRLZo, P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp, P_1);
			}
		}

		private void ZwntXVTAKbnCsYpRJoGyODTRleh(ref blqhAICLjdxoAhSwtLtZkkXVbevB.uJgdNWlPGsUYyEIwAUSBpXMtIZX P_0, double P_1)
		{
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				RZmOiWwbjvcsfAkXapgajxRQmywy(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD, LMwPWmrezsdezcEObLBzCJnGuOt.gjOGkVMUluYrFYtpSEboScqlrct, P_0.fegFsOfZSzJQgljLSVrHDZCfmzwI, P_0.NOPQVhqkBWMrvrfDpfQaBWDBYUI, P_1);
			}
		}

		private void gFfpIUvvvruGklNcJtGHiBQzdOT(ref blqhAICLjdxoAhSwtLtZkkXVbevB.SIJhMLEEIqhXWNIiJpXyUMeGFJU P_0, double P_1)
		{
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				RZmOiWwbjvcsfAkXapgajxRQmywy(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD, LMwPWmrezsdezcEObLBzCJnGuOt.NOHEmYGKydBMlibSUApaFiXclRMS, P_0.ubnlqLujpDoXEeQmgjSsHFCNSAD, P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp, P_1);
			}
		}

		private void oNiZJaaZdmKYcDTGJQquwdlyrGi(ref blqhAICLjdxoAhSwtLtZkkXVbevB.rbctAmLpLZjQwFFqVhfrvVBeWbK P_0, double P_1)
		{
			_ = PbyhNBOEDhbNoCeKjEMDqIEDKC;
		}

		private void mcvxWschSVCvgrbPhxivIriqdnz(ref blqhAICLjdxoAhSwtLtZkkXVbevB.RTfeVqAVuUydmVqZfPhMxCxEZaz P_0)
		{
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				tUnghiHvJLidlTBQdQnaACAvMpOh(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD);
				if (GQaDQPkqdmlfJzHYYMBBAFWNYQom != null)
				{
					GQaDQPkqdmlfJzHYYMBBAFWNYQom();
				}
			}
		}

		private void aLiGHuKezacFEduXCAyQKtzFnrez(ref blqhAICLjdxoAhSwtLtZkkXVbevB.RTfeVqAVuUydmVqZfPhMxCxEZaz P_0)
		{
			if (PbyhNBOEDhbNoCeKjEMDqIEDKC)
			{
				PIUibaZzJyyFaqSXWQcpLHakJEY(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD);
				if (GQaDQPkqdmlfJzHYYMBBAFWNYQom != null)
				{
					GQaDQPkqdmlfJzHYYMBBAFWNYQom();
				}
			}
		}

		private void DTGbuLtulXLgulRtrcSDkUdOcWT(ref blqhAICLjdxoAhSwtLtZkkXVbevB.SsiwcBETDaFRJtCBGBiJyQzejxS P_0, double P_1)
		{
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				byte tYONpsQjDmdnPNgQXukLoEDRLZo = P_0.TYONpsQjDmdnPNgQXukLoEDRLZo;
				if (tYONpsQjDmdnPNgQXukLoEDRLZo != 6)
				{
					AsMYsPdkzAeYZqXFHGWvNjOAhKZG(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD, LMwPWmrezsdezcEObLBzCJnGuOt.vOLImljxsbFUhrkbOfeHLOkwnVi, P_0.TYONpsQjDmdnPNgQXukLoEDRLZo, P_0.lvXCTCWOhrCtuFDbbEqyqyUVPhp, P_1);
				}
			}
		}

		private void mXqTOrcLBXQDyOVlOckjlmYDIkb(ref blqhAICLjdxoAhSwtLtZkkXVbevB.SabRlXaYRlvmrGeGZphuEWaKdgP P_0, double P_1)
		{
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				byte fegFsOfZSzJQgljLSVrHDZCfmzwI = P_0.fegFsOfZSzJQgljLSVrHDZCfmzwI;
				if (fegFsOfZSzJQgljLSVrHDZCfmzwI != 15)
				{
					AsMYsPdkzAeYZqXFHGWvNjOAhKZG(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD, LMwPWmrezsdezcEObLBzCJnGuOt.gjOGkVMUluYrFYtpSEboScqlrct, P_0.fegFsOfZSzJQgljLSVrHDZCfmzwI, P_0.NOPQVhqkBWMrvrfDpfQaBWDBYUI, P_1);
				}
			}
		}

		private void ZsFoppJRpogjqSKwKzEMZPPfIhW(ref blqhAICLjdxoAhSwtLtZkkXVbevB.aXdHvBxbolGTMixMePzbmARlRKQ P_0)
		{
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				trjYiqklzjBcbzmNPEIpDAuJKYT(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD);
				if (GQaDQPkqdmlfJzHYYMBBAFWNYQom != null)
				{
					GQaDQPkqdmlfJzHYYMBBAFWNYQom();
				}
			}
		}

		private void bhqciyERsYQvoUAMHLszxlvfMhQ(ref blqhAICLjdxoAhSwtLtZkkXVbevB.aXdHvBxbolGTMixMePzbmARlRKQ P_0)
		{
			if (YBlWzJDolZAgldWQxpxQqgrxJUV)
			{
				DpLJKOzAkYddWZLEweHMvDzIRIl(P_0.UjBOKoJgjChdeUJZdrDWhERTWTD);
				if (GQaDQPkqdmlfJzHYYMBBAFWNYQom != null)
				{
					GQaDQPkqdmlfJzHYYMBBAFWNYQom();
				}
			}
		}

		private void OoPVBXrBrVRtVxaveXnctGUlcRvE(ref blqhAICLjdxoAhSwtLtZkkXVbevB.aXdHvBxbolGTMixMePzbmARlRKQ P_0)
		{
			_ = YBlWzJDolZAgldWQxpxQqgrxJUV;
		}

		private void RZmOiWwbjvcsfAkXapgajxRQmywy(int P_0, LMwPWmrezsdezcEObLBzCJnGuOt P_1, byte P_2, short P_3, double P_4)
		{
			cdEZCmjuLpaiXcSXdaIfUVrroQg(P_0)?.aYsFvoceHxJCyLcdXQiYPSoYSvl(P_1, P_2, P_3, P_4);
		}

		private void AsMYsPdkzAeYZqXFHGWvNjOAhKZG(int P_0, LMwPWmrezsdezcEObLBzCJnGuOt P_1, byte P_2, short P_3, double P_4)
		{
			efxFnJaoxTbKmEYtibSmzMrOevi(P_0)?.aYsFvoceHxJCyLcdXQiYPSoYSvl(P_1, P_2, P_3, P_4);
		}

		private void urgjvaiFQyWdbmxFpiRDKgXaZLo()
		{
			string[] array = pDDbsrGuHERDEmpSbfjGfAQbckDy.YzfMnTAtORqEvlAZrlZfqkbGSDk();
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && array[i].Length > 32 && !(blqhAICLjdxoAhSwtLtZkkXVbevB.lzePgCRtoDNIBLSiktiYnNIkeDXI(new Guid(array[i].Substring(0, 32))) != string.Empty))
				{
					blqhAICLjdxoAhSwtLtZkkXVbevB.CAMTbikPMorhdVBYuMJAwEefQgJ(array[i]);
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
			if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				return;
			}
			if (disposing)
			{
				if (QbLjDZnVbMualsArhMRDjkPbDPU != null)
				{
					QbLjDZnVbMualsArhMRDjkPbDPU.Dispose();
				}
				MNKbAPISFmUunCotMijatTBuRAwI();
			}
			blqhAICLjdxoAhSwtLtZkkXVbevB.UwrGWyPduwbGnhqFTnwYcTyfQRZE();
			rXobafaxvUDrItlgWahiaYSKJqn = false;
			JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
		}
	}
}
