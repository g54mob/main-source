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
		private class ifLOodAiDNAvPlLYpyrPuneEMcts : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource WeIcPZclNmPnWTypmejZGnIMQwbE;

			private readonly CustomInputSource IwprKmtywLkBFXjVWVdPqVjFTFfs;

			private readonly Controller.Extension pBdPnMYaQNgjoaxvyzrcCTSodAdV;

			private int JURqrXFcYdWXAbgSvbppioDOssYYA;

			private int dCWowlZrePFsFEYttiLZTbllNYEM;

			private long? xQTEYRcZwzpOpWIeTgxDKfuWbJEiA;

			private int ROtalOlDvtNrIzeZDSIlROFhNmyB;

			public Guid jObcMLLTjPIDzMScXRWKoFcKAOLN;

			public string EHLBFWeDYUqqhNDbfePGklbfowdc;

			public string ZJzlUqpBxGDlygbvIqCUqbAmzRsHA;

			private int yXPCZIzckxNMdmEUkPmIqvEYlikU;

			private int GdNuLmHfCIeArGrXZhYWfWvDaOBEc;

			private float[] cMbiFqLERUgXTAnmzNdgIxBYatig;

			private bool[] pVXqKLlUIFppfNuHGTNQEVdTmVsd;

			private float[] fPitZlQKNoovrykPCsDulmFAgvzK;

			private bool[] haAHgJwhYvAzpGpWvzdYixjGPdXNA;

			private HardwareJoystickMap_InputManager mPbAcvHRknUUIanDvXmySBRpntgy;

			public CustomInputSource.Joystick OmRiETVGhfLDEuPGBSwSlftdEbVH;

			private bool XpTgFjLaWAXVQXlIPaEaNsCIHHsd;

			private readonly bool ZWxewrtwQYETKSYwOBNUCCqrbHuDA;

			private readonly LocalizedString rNvdKwmKbpwqLQrAKrSIpLBIrrh;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lErzGlBEypxRUzjpEbGfTmNSFGL;

			public int TzWcfRaRAWGBLXdAIioDYXGPPlkJA => 0;

			public int DoylurrjrhzjmPvBHrGLrCthFxKj => 0;

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

			public ifLOodAiDNAvPlLYpyrPuneEMcts(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
			}

			public void iywkWGPoPByQDZyClcrNAcGDxJoj()
			{
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
			}

			public int hgSZAXGquagLcDPofQtJJoIfOcPMA(ifLOodAiDNAvPlLYpyrPuneEMcts P_0)
			{
				return 0;
			}

			private void STRbRQVZDAIPCpdIQRvIEtHwPzXF(BridgedControllerHWInfo P_0)
			{
			}

			private void BKYfKZzNSteQGgBcclqvMAeXMAI(BridgedController P_0)
			{
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
			}

			public BridgedControllerHWInfo LbMcHnhpfnOLEVgvbyBKVUjCHeIjA()
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

			private void vPKvBMzpeGaYpSNeoQJMAnmCdBWdA()
			{
			}

			private void kYCVxDpSsznUiqASEkGUVZeZRtfx()
			{
			}

			private bool YXFZdTGjJvMjiiNtsmXkBjVXEKdc(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private bool IZGsjugxxstGCgRBdpBpUSYRceab(float P_0, float P_1)
			{
				return false;
			}

			private float paGZtWaagQKvwqBjMBOWHeXLnyCR(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				return 0f;
			}

			private float NDHoKlqYSBhmGBGXnGPKkEoZqBCaA(int P_0)
			{
				return 0f;
			}

			private bool plDPOtoMcuwCTpfFpFPeBHRpJMlh(int P_0, out float P_1)
			{
				P_1 = default(float);
				return false;
			}

			private void BdAaqpnGrBSDzHfybEZrLNwwUPDo()
			{
			}

			private void xQyDQVxYfhwMSinCvOMPHaYaErhb()
			{
			}

			private string uDyaUJQVgMZsaLwSOcDkzLLjHgde()
			{
				return null;
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				value = null;
				return false;
			}

			public static int ZCuGEILJQVsGKfjNwljNOeAWLSFC(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, ifLOodAiDNAvPlLYpyrPuneEMcts P_1)
			{
				return 0;
			}

			public static int vfYePiaDRXVHGtvUKjGhbbeGFJiFb(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, ifLOodAiDNAvPlLYpyrPuneEMcts P_1)
			{
				return 0;
			}
		}

		private class EsSalVUwoRpQyImrUHVVyrbvwytP
		{
			public enum zkdMCdLWnCNBoYDqVwuwNOlAbAtFA
			{
				Exact = 0,
				Approximate = 1
			}

			public class onQonyiuMUhwOBidfUdpahhWdswkA
			{
				public int KJugSxiEngOnRBGdoiaDPQgJSHHbA;

				public long? UttpJXwFAXumrmiBRvuLCGmXOMXc;

				public string GlvIfEizBkvxUTBMUpLyGVmnDgqp;

				public int jvWkrktXGlXQUGBZhPgzGEKyGtAA;

				public int gdJimvTHAmzLureJGbSMFEvvMSWGb;

				public int dBYNwSVCxWZodZlmKDEDEsVhTpOQA;

				public onQonyiuMUhwOBidfUdpahhWdswkA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
				}

				public bool GtZEVhEgieLFQSTvbhHADTiDcOkGA(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, zkdMCdLWnCNBoYDqVwuwNOlAbAtFA P_1)
				{
					return false;
				}
			}

			private sealed class jcRTNNzPFJNWrkLirIlsoJMlgNYjA : IEnumerable<onQonyiuMUhwOBidfUdpahhWdswkA>, IEnumerable, IEnumerator<onQonyiuMUhwOBidfUdpahhWdswkA>, IEnumerator, IDisposable
			{
				private int UDMCfhLuevhfRhKhYYdqoJVFsnLWA;

				private onQonyiuMUhwOBidfUdpahhWdswkA KfVcNdMizzrhkAJwxCqzHhTQDqyp;

				private int bTUkKRGbVoluIIrGpkpkiCKEjBNG;

				public EsSalVUwoRpQyImrUHVVyrbvwytP TGqqtlPHgMAMSCctDyXiPOhLdUqxA;

				private ifLOodAiDNAvPlLYpyrPuneEMcts KJOOKCOrhaatzHursvoPHBosCwVsA;

				public ifLOodAiDNAvPlLYpyrPuneEMcts qpjGTIlyDzVQTgztbSzDsWAwmEUF;

				private zkdMCdLWnCNBoYDqVwuwNOlAbAtFA WPSGLvvfdVxPByKhNaeZgBhDVYzn;

				public zkdMCdLWnCNBoYDqVwuwNOlAbAtFA OevTfebMLWGcPeQXyLITaxFfGIeOb;

				private int NwdYIpFLxegeUDgklhUPQxnsfcuZ;

				private int mjxaLvKWUNOznLvtzcyxQoGKINCyA;

				onQonyiuMUhwOBidfUdpahhWdswkA IEnumerator<onQonyiuMUhwOBidfUdpahhWdswkA>.Current
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
				public jcRTNNzPFJNWrkLirIlsoJMlgNYjA(int P_0)
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
				IEnumerator<onQonyiuMUhwOBidfUdpahhWdswkA> IEnumerable<onQonyiuMUhwOBidfUdpahhWdswkA>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private List<onQonyiuMUhwOBidfUdpahhWdswkA> IscEDtkAKckiIDkliHJNySIWIohfb;

			public int VxBSWOJzfTWXlQIfYvIfTYtEUTwm => 0;

			public void HzZfuPOloXZgShcMUcERIUcFkqQB(ifLOodAiDNAvPlLYpyrPuneEMcts P_0)
			{
			}

			public bool qoopVwJPkPHMJTbKnrfVDEdfxikE(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, zkdMCdLWnCNBoYDqVwuwNOlAbAtFA P_1)
			{
				return false;
			}

			[IteratorStateMachine(typeof(jcRTNNzPFJNWrkLirIlsoJMlgNYjA))]
			public IEnumerable<onQonyiuMUhwOBidfUdpahhWdswkA> pSJAhvapOYofWUoKrnxXndecLErF(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, zkdMCdLWnCNBoYDqVwuwNOlAbAtFA P_1)
			{
				return null;
			}

			public int QqfXjZVRWdaMTUJhdMuezKURLTMj(onQonyiuMUhwOBidfUdpahhWdswkA P_0)
			{
				return 0;
			}

			private void LIVlSOBHaTgiSGDghvNrOLNLjMqdA(int P_0, int P_1)
			{
			}
		}

		private List<ifLOodAiDNAvPlLYpyrPuneEMcts> oxDsQJPlYuzrzWvVigPHWqnXXoXN;

		private int pplpkIOqXMTcHHzdPLGZbtDDEweb;

		private EsSalVUwoRpQyImrUHVVyrbvwytP QoyFDcIrNVRMJvHYCITxeDdpegiKA;

		private UpdateLoopType szvSKssrzwSiKhmbQWOxXRtkuCAH;

		private Action<int, ControllerDataUpdater> WAicUpDZjuErKmrXBQRThZXFCIDJ;

		private PlatformInputManager aweVzmcyHyDOhHJkawzZJuTyjmUu;

		private CustomInputSource ugnyLhkJNbZVeeSfNqHWuHeGHsKA;

		private bool cExbrUCoIwbufWLEYzypAtTScnkU;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ANhStcFpRfXKfROfputcTNKVsEEd;

		private Func<int> SGEaYYFIzKUNofrfnNUvdfQBQGVpA;

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

		private void HMkpDWcEWoZoipFmoHhxIlIwRJxl(CustomInputSource.Joystick[] P_0)
		{
		}

		private void SCVbtTFCSPfzVKjUTWIqjrvCAuUdb()
		{
		}

		private void tmlwoDLqWiOZTFeXLauMiamHXGKy(int P_0, int P_1, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_2, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_3)
		{
		}

		private void awsDcSfGeEUsYlTHkLptmKZQzokS(List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_0, int P_1, int P_2)
		{
		}

		private bool ccoHVtlfHZoLoEauzYpdTwVINVrm(List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_0, int P_1)
		{
			return false;
		}

		private int jBkcYSzubKMNsJpwVPKGkJgGPsZo(List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_0)
		{
			return 0;
		}

		private bool eaIgKMTVWXBAbHiuwyMBbJivLIKtA(List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_0, int P_1)
		{
			return false;
		}

		private void DToAJQilbUhLXkfytzQVHaBJCzGQA(int P_0, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_1, int P_2, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_3, EsSalVUwoRpQyImrUHVVyrbvwytP.zkdMCdLWnCNBoYDqVwuwNOlAbAtFA P_4)
		{
		}

		private void qtpdvLApCDOTjZaSiKyNiAKoYXXy(int P_0, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_1, EsSalVUwoRpQyImrUHVVyrbvwytP.zkdMCdLWnCNBoYDqVwuwNOlAbAtFA P_2)
		{
		}

		private void xHYMmwgjVLtExtFPGFkFHHCmhAUh()
		{
		}

		private bool MVNZBfntTrrYlwnmLejVBmelZljU(CustomInputSource.Joystick[] P_0)
		{
			return false;
		}

		private void KaXHMbGDHGJqIOqnRUurjJDdGYNu(List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_0, List<ifLOodAiDNAvPlLYpyrPuneEMcts> P_1, bool P_2)
		{
		}

		private void pBjkucWjycJoqEnBwbcWdoqZHELe(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, bool P_1)
		{
		}

		private void PPlghwyBhhBIEDBiYiQJRlbBAkybb(ifLOodAiDNAvPlLYpyrPuneEMcts P_0, bool P_1)
		{
		}
	}
}
