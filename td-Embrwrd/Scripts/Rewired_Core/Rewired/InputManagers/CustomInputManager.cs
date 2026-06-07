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
		private class dlSjShBAdUzGTDiRMVBbqYcimkiq : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource PLRzsFvUPrbcIvNxLUAnEMxanYkR;

			private readonly CustomInputSource DqcCxksQVIwCRjiMpNyrqtprFaiL;

			private readonly Controller.Extension uQmlLUPtaEKnyIFkLFDEULUAdYeR;

			private int KHCrdTYPieipMNBBWZNFwxVuqjHK;

			private int aXXwRhMSUQRfLaxeIxSdZpnVYtRh;

			private long? ovEbAZxtGuMSdwxdslHjEgsibNHeA;

			private int KDucijdilkgglFJlGycgyFANtJxoA;

			public Guid mloFAZMJJSholeizacbqSyqciICmA;

			public string JBMjHFAlhTUDaBlYYwUnDkpPtevvA;

			public string EquUzyeUPPYZqRrsziWuhiIALAnH;

			private int voEeBSwdEmZbxQfVBhSwfoSksmlrA;

			private int ZqUJweIewDbglPUMoejuQdnAbWGO;

			private float[] lheXcsUCxNfVXhufIVtUUQTmWihx;

			private bool[] uWGwcFcgkAOEpfFndonqSJBxgqdQ;

			private float[] iurNRhHnrpSZxOGgjhvMdLswkKsD;

			private bool[] eqRarBzaykBMhNhPYtParRryEfIFA;

			private HardwareJoystickMap_InputManager ramGmfSbWaefEeISQNEAQUHNkplSA;

			public CustomInputSource.Joystick ZhUXwZEaNwAiEiODoQeiyjhXZKGAA;

			private bool EdUceHIIQZmoFanckkOkbZwauZEne;

			private readonly bool EtiAgvoUkZrcCgqvnftkDGgLyBnpA;

			private readonly LocalizedString uMOfbMjpusnWulhijwgmrSDtxOuY;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qTLEtQgsolTSTmiiQUcmbuexhWXeA;

			public int IdVrVrCsvVmVPTFaxMvGXITdlrCc => 0;

			public int KVbyfhuNXmWqgjXmuRbxxCpNGVJn => 0;

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

			public dlSjShBAdUzGTDiRMVBbqYcimkiq(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
			}

			public void xvrMoUMkjUkBVbAFEGMjaMWnKjjqA()
			{
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
			}

			public int ekVQDZRARdqscnlcUHGneESXaNMH(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0)
			{
				return 0;
			}

			private void JYCfvWKFdDLtSRoZzvfyUJBKoRGq(BridgedControllerHWInfo P_0)
			{
			}

			private void KpNEWGQnLHISAcsIDpSSWtQGnVVhA(BridgedController P_0)
			{
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
			}

			public BridgedControllerHWInfo YrLVxMuPrssWMEmUKbkILdckmAHe()
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

			private void kDVXqGiJCTlOzmdNThBkGcuqHKDH()
			{
			}

			private void rDXbhRciYoUmmKJFraccVpgdvTiI()
			{
			}

			private bool XLEeDvjPHsKdlgIKdXYxFXpLhCHRc(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private bool LMHeorgzVyyKMOqMYiLjUDGoYelt(float P_0, float P_1)
			{
				return false;
			}

			private float usRHHIrEYVVrqGDkbVgwZhZpMaFV(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				return 0f;
			}

			private float GYGQQdnlyABXMdNWQrfaGPyjBSZi(int P_0)
			{
				return 0f;
			}

			private bool yyKzRblfsxmBHVhCAgpWBHDTIDwPA(int P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private void AZNggvyzXUgsdrcfSntJBMcKTtGK()
			{
			}

			private void eXVcRUyRswwNEWbitqcmVgmmQAeY()
			{
			}

			private string jmbyuXThlBDuodNxjOUExUHXJXwM()
			{
				return null;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				value = null;
				return false;
			}

			public static int GQrcKYGMjQuBGvHyNKRzOQywRFInA(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, dlSjShBAdUzGTDiRMVBbqYcimkiq P_1)
			{
				return 0;
			}

			public static int yWHBauEjtCiOWZDubgDLbgcaNhpD(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, dlSjShBAdUzGTDiRMVBbqYcimkiq P_1)
			{
				return 0;
			}
		}

		private class FAFGjPPkCMPbqceahellguvLsmaCA
		{
			public enum uRaAVlQPFLiXcqffqOCGBntsABeH
			{
				Exact = 0,
				Approximate = 1
			}

			public class rgXrdqtaaJHNSbOeQARVgofoDovgA
			{
				public int TmxQxiJZzVSTGocfBSlmOoHxTOMB;

				public long? TqqAdPbbfCsJtnAvurNdxEOnsCVnA;

				public string XEmhMOjZttIuAlmJnfpAKhoFegtt;

				public int eEojoramjFokKDgEaepSTYUDcCuGc;

				public int nzGuVxKycfwumTiKjynaOXjZMWFH;

				public int yQZgnOArZHZWrnIvxopxsDHFhqLg;

				public rgXrdqtaaJHNSbOeQARVgofoDovgA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
				}

				public bool NYTNpxtArduAeTuKPbuPfizpUrX(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, uRaAVlQPFLiXcqffqOCGBntsABeH P_1)
				{
					return false;
				}
			}

			private sealed class wrYHuZeenEfXrMDpKNXMiFQBTbLl : IEnumerable<rgXrdqtaaJHNSbOeQARVgofoDovgA>, IEnumerable, IEnumerator<rgXrdqtaaJHNSbOeQARVgofoDovgA>, IEnumerator, IDisposable
			{
				private int HOLpbCOAckABTyszfJIKJTZrnSrb;

				private rgXrdqtaaJHNSbOeQARVgofoDovgA BlCjcnBPLgSxgoZbEMoDNjRaewxq;

				private int kCBbmRaBVlAAIPemMRQQDqEaolGVA;

				public FAFGjPPkCMPbqceahellguvLsmaCA UMbbqfEOIDraIKLsudXGOLxnWzjJ;

				private dlSjShBAdUzGTDiRMVBbqYcimkiq BCXQsKHQJdEWxACmFGefRBuUFkWy;

				public dlSjShBAdUzGTDiRMVBbqYcimkiq vGikOWsHbgYgDWOqEqoxyhWAEuTZ;

				private uRaAVlQPFLiXcqffqOCGBntsABeH PgFdPryMDCiUDCFccHAvyJjzVCqN;

				public uRaAVlQPFLiXcqffqOCGBntsABeH XRkdwgejdHZqFehYTyfdpFBeGIxV;

				private int INuEKfGJfvPLOrjvWmIrGzmQsNvd;

				private int pjqTgrFqOOGRpFwLGWFLmDYaFTHG;

				rgXrdqtaaJHNSbOeQARVgofoDovgA IEnumerator<rgXrdqtaaJHNSbOeQARVgofoDovgA>.Current
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
				public wrYHuZeenEfXrMDpKNXMiFQBTbLl(int P_0)
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
				IEnumerator<rgXrdqtaaJHNSbOeQARVgofoDovgA> IEnumerable<rgXrdqtaaJHNSbOeQARVgofoDovgA>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private List<rgXrdqtaaJHNSbOeQARVgofoDovgA> VDbNDlTyszBIEYotLbNzAGIsiUye;

			public int IYQAOWEDtCshtmfqvsxDXgvcDcfm => 0;

			public void EnScbwPTFAcumFNtjEQsDCShrehGB(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0)
			{
			}

			public bool vXrybwUcnQEwRaxoMcHBcVAELfjPB(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, uRaAVlQPFLiXcqffqOCGBntsABeH P_1)
			{
				return false;
			}

			[IteratorStateMachine(typeof(wrYHuZeenEfXrMDpKNXMiFQBTbLl))]
			public IEnumerable<rgXrdqtaaJHNSbOeQARVgofoDovgA> wtOaYvEbBVlLKgcrDALvwvpAYNwJB(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, uRaAVlQPFLiXcqffqOCGBntsABeH P_1)
			{
				return null;
			}

			public int LccpLREfoamJDsXoKUsSbeQxEPVDA(rgXrdqtaaJHNSbOeQARVgofoDovgA P_0)
			{
				return 0;
			}

			private void KbUJhIApMMgXUczlQNrDKzRfxYvO(int P_0, int P_1)
			{
			}
		}

		private List<dlSjShBAdUzGTDiRMVBbqYcimkiq> zmQUYJYaqvSffgSCZrHxAlvpomIF;

		private int yWkfbecZUUMigbjcYnbmprdfIMfgA;

		private FAFGjPPkCMPbqceahellguvLsmaCA VXlcNiJDpUezVGHDxQjNImxHAyrsA;

		private UpdateLoopType dKkPYwjdHpdrQEPmlriFVDhEacBxA;

		private Action<int, ControllerDataUpdater> PlviExWtTdRAGYYKmUmhbDVxPISm;

		private PlatformInputManager bWbrwefjGddlrptlLBQhVFoAyAFG;

		private CustomInputSource twdhuPgibQZoDbSJQPUhWYFUfZfSA;

		private bool lpiHnIJgixZHlwkZbsKTGkVkCnfS;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> VwqXCkCuLivmxtPVSpSKRHDfRkPv;

		private Func<int> RLZCEQHNKHwsgRktMkGBlEQhIcYC;

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

		private void YGpxvCvGobMmeXixDlnJOeAKIXoW(CustomInputSource.Joystick[] P_0)
		{
		}

		private void TtWrLLHakGGwRFJFqopGdlwkuOXd()
		{
		}

		private void sZgsXXYeVjeTBtIxeKioaiDxEKXC(int P_0, int P_1, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_2, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_3)
		{
		}

		private void dajfmUgXARuFCVDYLQFZukBccilhA(List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_0, int P_1, int P_2)
		{
		}

		private bool tXfLUzmenQBwquIlSfTNTPXsNHaO(List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_0, int P_1)
		{
			return false;
		}

		private int kKxiKQmJHVcVylvnwmIcgjiiwdWh(List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_0)
		{
			return 0;
		}

		private bool xcTSYQWgEXjpXOhVByvUXkNmIHRA(List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_0, int P_1)
		{
			return false;
		}

		private void YYdEVUljRNIyPDanOtkhuIHvevPfA(int P_0, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_1, int P_2, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_3, FAFGjPPkCMPbqceahellguvLsmaCA.uRaAVlQPFLiXcqffqOCGBntsABeH P_4)
		{
		}

		private void vkjnLIgeKIapRMNJJGpsAMVMVGJb(int P_0, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_1, FAFGjPPkCMPbqceahellguvLsmaCA.uRaAVlQPFLiXcqffqOCGBntsABeH P_2)
		{
		}

		private void oiHUYsjVFSnYpLiUnqjjNMYQdvDm()
		{
		}

		private bool RaMXrniroydRtEnJeHBdZCiLjxig(CustomInputSource.Joystick[] P_0)
		{
			return false;
		}

		private void VtUlFpTtrXvDSoNgkbYLtGFLgMOy(List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_0, List<dlSjShBAdUzGTDiRMVBbqYcimkiq> P_1, bool P_2)
		{
		}

		private void oykCiqZtBtemmcmkTXHopxcfEHIoA(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, bool P_1)
		{
		}

		private void WgeCxmbbFmPbSxPrxDmvnvnlQwjP(dlSjShBAdUzGTDiRMVBbqYcimkiq P_0, bool P_1)
		{
		}
	}
}
