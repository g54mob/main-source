using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms.Custom;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class nvgLLBuhCjlZTcmWAqDKTCohHeobA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource PxjBzxEQiYarGsYgRPWSdvrjeQeRA;

			private readonly CustomInputSource XPIbREVJfrylBEdDhhPOeTzgUBwNA;

			private readonly Controller.Extension yoQwXaigXdhHqlnzNTFprpMHEUoS;

			private int IXmCkxzrDHmhGqUKQRLiZnBpXyVL;

			private int qgxAdJpRtrNCFFcpMmxGselCuYDl;

			private long? ukyPTtSBnRTJnXqTkVBKnDmdVjJj;

			private int WiSxtPLZUDjttwvgmkVXkGWKHHfm;

			public Guid cvOsThbimzWztNwkqKhVTZebVIGO;

			public string BiiUYxKpMkVCaSxFWlYGRnfSvmdy;

			public string QMMBnWDCkuGDwcQttvmZWWATiPlX;

			private int tuoqSqVphBDwpfmMVESTRiQxwmrr;

			private int NMuBEMptReNsbqaDgfoRIbhPOUSyA;

			private float[] zcGCtGafQgDMBZLyMcpvmjZzCgnjb;

			private bool[] cPgDjthHXhiXpDSeDxdNlpNeuallB;

			private float[] iZCEJglAIbPhKxTpZnhARNvIeiIA;

			private bool[] wnnnhxSmZDZEnkRWSDiZUpprdPOF;

			private HardwareJoystickMap_InputManager fGKQxFztzFeySxiNQvGffqPMtxtv;

			public CustomInputSource.Joystick FBwCfzCrePLjWOtQcoiHnIvSLCCyA;

			private bool CjsxzrhYdgHnBAmpgWANcWwjqZrR;

			private readonly bool WkEvPVHnRallKZTondJRtPqQTIdi;

			private readonly LocalizedString oWetmkEWDLiFsMIvfBkNDpZaOOkYA;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> gSfSeiRyDQHvHLidIicLUSyiGnXL;

			public int WzfwCntgBqreJaVSzUBMmiSsbdry => 0;

			public int INTakXDZuFvDoMMhskXAUWrOnRXo => 0;

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			[CustomObfuscation(rename = false)]
			public string name => null;

			[CustomObfuscation(rename = false)]
			public long? systemId => null;

			[CustomObfuscation(rename = false)]
			public int unityId => 0;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid => default(Guid);

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid => default(Guid);

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => null;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public nvgLLBuhCjlZTcmWAqDKTCohHeobA(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
			}

			public void jlZkfqrVInvGLWdGCWQIxJQofrrS()
			{
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
			}

			public int iQnPrhwngIvBcKkgOHpAPMIQcgWI(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0)
			{
				return 0;
			}

			private void PJirmqvNGuamQcPKjBdJpPDFUNSO(BridgedControllerHWInfo P_0)
			{
			}

			private void IudSPwfQkgVNYJhNNqAlOnKBFTVT(BridgedController P_0)
			{
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
			}

			public BridgedControllerHWInfo WlpYePVesNbmKtRbKlZHmPlvaQRf()
			{
				return null;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				return null;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return null;
			}

			private void wbgAibLhgqkvGPqTNpZSpihvPXtB()
			{
			}

			private void zyxolYDvlZLsQdCvbwFlceDgddyc()
			{
			}

			private bool DyuWODswsTBovjDHHsMQuPjsGOXy(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private bool RYtWjJKayFmVWpqBMFHKGhCnsedQA(float P_0, float P_1)
			{
				return false;
			}

			private float cqbpYyGAzqJosfabjfgXEiRescHGA(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				return 0f;
			}

			private float IHgAFTKoZjHCYUfVOYfDrOwsaBXdA(int P_0)
			{
				return 0f;
			}

			private bool aLoBWXHCRAKURutHOjrldaHYqXcbb(int P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private void CJbNxPRTwrunhIgcAbtmAwuRQFYMA()
			{
			}

			private void sOvUAgHXXPjKAjExnfcREiexlYoFb()
			{
			}

			private string rXTabfhcYqGxoBKcBpCpHYTUOTwlb()
			{
				return null;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				value = null;
				return false;
			}

			public static int CtRUXcjkQdIAIcYdHJXEjwypDhUK(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, nvgLLBuhCjlZTcmWAqDKTCohHeobA P_1)
			{
				return 0;
			}

			public static int wFvIAEhhSjtaKgRKlgMyWBevXRzJ(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, nvgLLBuhCjlZTcmWAqDKTCohHeobA P_1)
			{
				return 0;
			}
		}

		private class THnqqrahztxgsDcnlMpEHAtQXswO
		{
			public enum ynIZINpXgqfeaBnmsYSxiEjzISoI
			{
				Exact = 0,
				Approximate = 1
			}

			public class vWfoQEYyBaQzYOtlIFdsLLbvgHdj
			{
				public int NqLDYPoypUHfRRFrPWXOvQoeDxUF;

				public long? HTIyulCYKlxSxtjisgNYjbAwUITcA;

				public string PyUgBgMaOMiBWKoKjHxntZsQccfs;

				public int oEGUhJNcQicxIdFHcqxlkfMtRMwZ;

				public int nGwpmBxOFAtKqwhLxiDPfDrQdIDX;

				public int kOjararTwaPSzQLybPmALxTCjdLT;

				public vWfoQEYyBaQzYOtlIFdsLLbvgHdj(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
				}

				public bool DteAtHUfbWzuSXfzEdpPmcogOzpH(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, ynIZINpXgqfeaBnmsYSxiEjzISoI P_1)
				{
					return false;
				}
			}

			private sealed class umebSrPeIpBkrdfqCGNxsDIGIPVsA : IEnumerable<vWfoQEYyBaQzYOtlIFdsLLbvgHdj>, IEnumerable, IEnumerator<vWfoQEYyBaQzYOtlIFdsLLbvgHdj>, IEnumerator, IDisposable
			{
				private int JNvwCZlarTHqJBajjfBveiRowrQv;

				private vWfoQEYyBaQzYOtlIFdsLLbvgHdj PvqllZirgRmRiTWmSfEmmMHtEahR;

				private int wjlbdzHumMjXEDZbCOMxPNChXnKjb;

				public THnqqrahztxgsDcnlMpEHAtQXswO GQPamLnwhapyOzmvgDhphdlilErn;

				private nvgLLBuhCjlZTcmWAqDKTCohHeobA TCnNskaIiOdFttufZwKEmpyXaeYjA;

				public nvgLLBuhCjlZTcmWAqDKTCohHeobA jcYOHiVJEXLzDdTrStqKTqCXayJY;

				private ynIZINpXgqfeaBnmsYSxiEjzISoI BahIrFZmctdRTbgrkIpKPExcIoek;

				public ynIZINpXgqfeaBnmsYSxiEjzISoI DoGByKToAovILVpPBciMKkFjOMnU;

				private int EnGXJTvmWWAMDIwxCyOFllvDkzIc;

				private int hTUYTPsZitFAnuFhMEEuNkCdBJTk;

				vWfoQEYyBaQzYOtlIFdsLLbvgHdj IEnumerator<vWfoQEYyBaQzYOtlIFdsLLbvgHdj>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public umebSrPeIpBkrdfqCGNxsDIGIPVsA(int P_0)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<vWfoQEYyBaQzYOtlIFdsLLbvgHdj> IEnumerable<vWfoQEYyBaQzYOtlIFdsLLbvgHdj>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private List<vWfoQEYyBaQzYOtlIFdsLLbvgHdj> RzTUOVmTcIMjWlhdZveExYEpiLiK;

			public int WcXoevqsxlGhFjzjmioyyrzPmzF => 0;

			public void SzoUkGaJeznjmwoejoYNliQcPsty(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0)
			{
			}

			public bool dOJAqCavAxqtDGEphSFwzwWEwpxFb(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, ynIZINpXgqfeaBnmsYSxiEjzISoI P_1)
			{
				return false;
			}

			[IteratorStateMachine(typeof(umebSrPeIpBkrdfqCGNxsDIGIPVsA))]
			public IEnumerable<vWfoQEYyBaQzYOtlIFdsLLbvgHdj> atgXTHCTqqbQWHrcQBTGWsdZLrwk(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, ynIZINpXgqfeaBnmsYSxiEjzISoI P_1)
			{
				return null;
			}

			public int TGMkSrxzRNmOFTVvUEqjIXKumNPS(vWfoQEYyBaQzYOtlIFdsLLbvgHdj P_0)
			{
				return 0;
			}

			private void EfgOwcxujzuSSVIaYzUynfFqAujl(int P_0, int P_1)
			{
			}
		}

		private List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> trmcLjzWPMNBlTDRZLdYpnlmGgCAA;

		private int emKSkUqubxrfuCydKnfHKQbySsll;

		private THnqqrahztxgsDcnlMpEHAtQXswO FiLOYGihSvigNamKpbLqFEtMeyzU;

		private UpdateLoopType xvKiRKABgKreImunxRkicPfHEiBJA;

		private Action<int, ControllerDataUpdater> PXJPPPpMwMeHAfXFoJoWCXBmfMCN;

		private PlatformInputManager fgTugCOOWIkKrOyePLHUqbJNmURf;

		private CustomInputSource lMDUhlJZGdcrZvyMWRYAfBLXBZjv;

		private bool lRIpwysyLMdYxBJOlwMgrsNlDrrr;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZMEaTQlVkFjtfCEOGXOnccJknkHSA;

		private Func<int> FrhZuogoLexBwoCjGeCeMCUwAGWS;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => 0;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => null;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => default(InputSource);

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
		}

		[CustomObfuscation(rename = false)]
		public override void Initialize()
		{
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
		}

		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedMouseSource GetUnifiedMouseSource()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return null;
		}

		private void UcRcisJMHSvrooikPLlatnUDTBaAA(CustomInputSource.Joystick[] P_0)
		{
		}

		private void XIsiAvwDqbNyPwYsgyatGrpluJHE()
		{
		}

		private void wcCnhStHEElXYQHdcQJqFezoMFDc(int P_0, int P_1, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_2, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_3)
		{
		}

		private void rfFlDuRJheCwMiSTFTIyRWFxowpJ(List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_0, int P_1, int P_2)
		{
		}

		private bool tfFYiXFSMbpfcZRcEFPicbJtELmn(List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_0, int P_1)
		{
			return false;
		}

		private int syHPTwJkcgmjoYJyuyeDJzydrmCN(List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_0)
		{
			return 0;
		}

		private bool tZxHygdDtrqMfviEZynOmyjCOmDd(List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_0, int P_1)
		{
			return false;
		}

		private void EkDrCqIxqyWrVmHuAqmUPMTyarBeA(int P_0, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_1, int P_2, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_3, THnqqrahztxgsDcnlMpEHAtQXswO.ynIZINpXgqfeaBnmsYSxiEjzISoI P_4)
		{
		}

		private void xCCyuzRgDxzOjhYCNMGQndMHfZIN(int P_0, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_1, THnqqrahztxgsDcnlMpEHAtQXswO.ynIZINpXgqfeaBnmsYSxiEjzISoI P_2)
		{
		}

		private void kBpjPGBMsdsDzqwHhedCngKZqnDFb()
		{
		}

		private bool PcsOqTXCiNaAjdDyqRXQahcGhAuJ(CustomInputSource.Joystick[] P_0)
		{
			return false;
		}

		private void VMqIOXkMQokMSVgduyAyKkDMCIAx(List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_0, List<nvgLLBuhCjlZTcmWAqDKTCohHeobA> P_1, bool P_2)
		{
		}

		private void kLKvtMwkeGqjkFuvHlJVOXmeBHQQ(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, bool P_1)
		{
		}

		private void WYEcdEUWkVcVASKwfmYSMUvwoezj(nvgLLBuhCjlZTcmWAqDKTCohHeobA P_0, bool P_1)
		{
		}
	}
}
