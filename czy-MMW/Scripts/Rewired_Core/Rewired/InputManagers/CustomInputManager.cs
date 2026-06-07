using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class ntrerzlSeRSSjtLosOxIyqpuDOdx : IInputManagerJoystick, IInputManagerJoystickPublic
		{
			private readonly InputSource PvsuVPDNSwkwgRsAvPuSONwsdmdbA;

			private readonly CustomInputSource VqTjtqIRNFkYbNTlJlOEqsVzhxdD;

			private readonly Controller.Extension akLMLMnodTOjEcSRfblrIiTKcJfm;

			private int KtxAZDuljzawwvleutjmqsUgEXWg;

			private int mjyZRzelTLZsvSrBiHGSHeuHHkKu;

			private long? yhpvFPPDNngURIkGAidQKrnsvzGO;

			private int WkREHtBCktLgZZrWOeGXdTJcRfwUb;

			public Guid yXJKzLesKRpwJWwEQFwHuitqeaZv;

			public string DHzBePXtiWaDGGBbaHyWkagLZMmOA;

			public string MPFpdiUpKUCoQnKVVENDjzBUrOem;

			private int vPzIcKUyHpWdTeYcfDaFilPmfWwM;

			private int NKxqUkyVrMvwVzQlEIeDUQoEoyZH;

			private float[] zaJvBkkXeOrRlMuImbPfWBSidOkCA;

			private bool[] aqbwBXCYnBkEBFdMTIPRFYStKGeJA;

			private HardwareJoystickMap_InputManager bJFjPxquVjItckKzikmjWMERFFmFA;

			public CustomInputSource.Joystick FZbtVJeVOfVsaaEmIPOBxqoXsaZT;

			private bool ClrEHXJcNEFirCLFDIoRWTfdcjyWb;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> kPmZWQOBbeFAtKUFqzWBffttLkQmA;

			public int UZwSNqanwSshLlmaVycCDBctRVee
			{
				get
				{
					if (FZbtVJeVOfVsaaEmIPOBxqoXsaZT == null)
					{
						return 0;
					}
					return FZbtVJeVOfVsaaEmIPOBxqoXsaZT.buttonCount;
				}
			}

			public int ILKtCxQtAhgAUTMJSxTCrCqRdtIS
			{
				get
				{
					if (FZbtVJeVOfVsaaEmIPOBxqoXsaZT == null)
					{
						return 0;
					}
					return FZbtVJeVOfVsaaEmIPOBxqoXsaZT.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return KtxAZDuljzawwvleutjmqsUgEXWg;
				}
				set
				{
					KtxAZDuljzawwvleutjmqsUgEXWg = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return mjyZRzelTLZsvSrBiHGSHeuHHkKu;
				}
				set
				{
					mjyZRzelTLZsvSrBiHGSHeuHHkKu = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(FZbtVJeVOfVsaaEmIPOBxqoXsaZT.customName)) ? FZbtVJeVOfVsaaEmIPOBxqoXsaZT.customName : DHzBePXtiWaDGGBbaHyWkagLZMmOA);
					if (text == "Unknown Controller")
					{
						text = MPFpdiUpKUCoQnKVVENDjzBUrOem;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => yhpvFPPDNngURIkGAidQKrnsvzGO;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => WkREHtBCktLgZZrWOeGXdTJcRfwUb;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!yhpvFPPDNngURIkGAidQKrnsvzGO.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + yhpvFPPDNngURIkGAidQKrnsvzGO);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => akLMLMnodTOjEcSRfblrIiTKcJfm;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetVibration
				this.SetVibration(amount, motorIndex);
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			void IInputManagerJoystickPublic.StopVibration()
			{
				//ILSpy generated this explicit interface implementation from .override directive in StopVibration
				this.StopVibration();
			}

			public ntrerzlSeRSSjtLosOxIyqpuDOdx(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				VqTjtqIRNFkYbNTlJlOEqsVzhxdD = P_0;
				PvsuVPDNSwkwgRsAvPuSONwsdmdbA = P_4;
				yhpvFPPDNngURIkGAidQKrnsvzGO = P_1;
				FZbtVJeVOfVsaaEmIPOBxqoXsaZT = P_3;
				WkREHtBCktLgZZrWOeGXdTJcRfwUb = P_2;
				akLMLMnodTOjEcSRfblrIiTKcJfm = P_5;
				kPmZWQOBbeFAtKUFqzWBffttLkQmA = P_6;
				mjyZRzelTLZsvSrBiHGSHeuHHkKu = -1;
				KtxAZDuljzawwvleutjmqsUgEXWg = -1;
				hPORRCcsiTbJvNdeuliSQyDvwBcr();
				AkkgFlSgAPskXVDEgELmhPlWPzDfA();
				yXJKzLesKRpwJWwEQFwHuitqeaZv = bJFjPxquVjItckKzikmjWMERFFmFA.hardwareMapIdentifier.guid;
				DHzBePXtiWaDGGBbaHyWkagLZMmOA = bJFjPxquVjItckKzikmjWMERFFmFA.controllerName;
				zaJvBkkXeOrRlMuImbPfWBSidOkCA = new float[vPzIcKUyHpWdTeYcfDaFilPmfWwM];
				aqbwBXCYnBkEBFdMTIPRFYStKGeJA = new bool[NKxqUkyVrMvwVzQlEIeDUQoEoyZH];
				Update();
			}

			public void hPORRCcsiTbJvNdeuliSQyDvwBcr()
			{
				MPFpdiUpKUCoQnKVVENDjzBUrOem = FZbtVJeVOfVsaaEmIPOBxqoXsaZT.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (FZbtVJeVOfVsaaEmIPOBxqoXsaZT.isConnected)
				{
					yVamuASRJAjsZOIerLQPUlKwhuEE();
					zasStJQdTxWOUksgDUjTDehpjHxR();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int ewthHljJukeAjZQEsxQkeJDJKLQb(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0)
			{
				if (P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem == MPFpdiUpKUCoQnKVVENDjzBUrOem && P_0.yhpvFPPDNngURIkGAidQKrnsvzGO == yhpvFPPDNngURIkGAidQKrnsvzGO)
				{
					return 2;
				}
				if (P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem == MPFpdiUpKUCoQnKVVENDjzBUrOem)
				{
					return 1;
				}
				return 0;
			}

			private void RftJSMiNgMThgxpeNHJFMnYWGhFjA(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = PvsuVPDNSwkwgRsAvPuSONwsdmdbA;
				P_0.inputSource = PvsuVPDNSwkwgRsAvPuSONwsdmdbA;
				P_0.hardwareIdentifier = rVKtTFpOoSIiKLqSZtollwCXqrfS();
				P_0.hardwareAxisCount = vPzIcKUyHpWdTeYcfDaFilPmfWwM;
				P_0.hardwareButtonCount = NKxqUkyVrMvwVzQlEIeDUQoEoyZH;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = MPFpdiUpKUCoQnKVVENDjzBUrOem;
				P_0.hw_supportsVibration = FZbtVJeVOfVsaaEmIPOBxqoXsaZT.supportsVibration;
			}

			private void GYkZbYaIKKcOsChzxOsnpgNOWdGs(BridgedController P_0)
			{
				RftJSMiNgMThgxpeNHJFMnYWGhFjA(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = bJFjPxquVjItckKzikmjWMERFFmFA.ToGameHardwareControllerMap();
				P_0.instanceName = MPFpdiUpKUCoQnKVVENDjzBUrOem;
				P_0.productName = MPFpdiUpKUCoQnKVVENDjzBUrOem;
				P_0.isXInputDevice = false;
				P_0.axisCount = vPzIcKUyHpWdTeYcfDaFilPmfWwM;
				P_0.buttonCount = NKxqUkyVrMvwVzQlEIeDUQoEoyZH;
				P_0.controllerTypeGuid = yXJKzLesKRpwJWwEQFwHuitqeaZv;
				P_0.customInputSource = VqTjtqIRNFkYbNTlJlOEqsVzhxdD;
				P_0.controllerExtension = akLMLMnodTOjEcSRfblrIiTKcJfm;
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (vPzIcKUyHpWdTeYcfDaFilPmfWwM != dataUpdater.axisCount || NKxqUkyVrMvwVzQlEIeDUQoEoyZH != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < vPzIcKUyHpWdTeYcfDaFilPmfWwM; i++)
				{
					dataUpdater.axisValues[i] = zaJvBkkXeOrRlMuImbPfWBSidOkCA[i];
				}
				for (int j = 0; j < NKxqUkyVrMvwVzQlEIeDUQoEoyZH; j++)
				{
					dataUpdater.buttonValues[j] = aqbwBXCYnBkEBFdMTIPRFYStKGeJA[j];
				}
				if (ClrEHXJcNEFirCLFDIoRWTfdcjyWb && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo ULqwpLWQqhoocoLtiDFrJecmGSXB()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				RftJSMiNgMThgxpeNHJFMnYWGhFjA(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				GYkZbYaIKKcOsChzxOsnpgNOWdGs(bridgedController);
				return bridgedController;
			}

			BridgedController IInputManagerJoystick.ToBridgedController()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
				return this.ToBridgedController();
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(KtxAZDuljzawwvleutjmqsUgEXWg);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void yVamuASRJAjsZOIerLQPUlKwhuEE()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)bJFjPxquVjItckKzikmjWMERFFmFA.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= vPzIcKUyHpWdTeYcfDaFilPmfWwM)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						zaJvBkkXeOrRlMuImbPfWBSidOkCA[i] = eLkHiYRjZKDhOHsDBaGNWHMtaGQxA(axes[i]);
						if (!ClrEHXJcNEFirCLFDIoRWTfdcjyWb && zaJvBkkXeOrRlMuImbPfWBSidOkCA[i] != 0f)
						{
							ClrEHXJcNEFirCLFDIoRWTfdcjyWb = true;
						}
					}
				}
			}

			private void zasStJQdTxWOUksgDUjTDehpjHxR()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)bJFjPxquVjItckKzikmjWMERFFmFA.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= NKxqUkyVrMvwVzQlEIeDUQoEoyZH)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					aqbwBXCYnBkEBFdMTIPRFYStKGeJA[i] = DLIfuUfDwCPvLPHTjKusxXrrRxgz(buttons[i]);
					if (!ClrEHXJcNEFirCLFDIoRWTfdcjyWb && aqbwBXCYnBkEBFdMTIPRFYStKGeJA[i])
					{
						ClrEHXJcNEFirCLFDIoRWTfdcjyWb = true;
					}
				}
			}

			private bool DLIfuUfDwCPvLPHTjKusxXrrRxgz(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return iPhdjkfVUEGZRvOcKgqycnaScZid(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = GijpQtHqfZJMuVLteJvTOszlbbMG(P_0.sourceAxis);
					if (MathTools.Abs(num) <= P_0.axisDeadZone)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
					{
						return false;
					}
					return true;
				}
				return false;
			}

			private bool RAygRhHDOfBKixuzuWnGlQXyWQqsA(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float eLkHiYRjZKDhOHsDBaGNWHMtaGQxA(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return GijpQtHqfZJMuVLteJvTOszlbbMG(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!iPhdjkfVUEGZRvOcKgqycnaScZid(P_0.sourceButton))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						return 1f;
					}
					return -1f;
				}
				throw new NotImplementedException();
			}

			private float GijpQtHqfZJMuVLteJvTOszlbbMG(int P_0)
			{
				return FZbtVJeVOfVsaaEmIPOBxqoXsaZT.GetAxisValue(P_0);
			}

			private bool iPhdjkfVUEGZRvOcKgqycnaScZid(int P_0)
			{
				return FZbtVJeVOfVsaaEmIPOBxqoXsaZT.GetButtonValue(P_0);
			}

			private void AkkgFlSgAPskXVDEgELmhPlWPzDfA()
			{
				bJFjPxquVjItckKzikmjWMERFFmFA = kPmZWQOBbeFAtKUFqzWBffttLkQmA(ULqwpLWQqhoocoLtiDFrJecmGSXB());
				if (bJFjPxquVjItckKzikmjWMERFFmFA == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				vPzIcKUyHpWdTeYcfDaFilPmfWwM = bJFjPxquVjItckKzikmjWMERFFmFA.axisCount;
				NKxqUkyVrMvwVzQlEIeDUQoEoyZH = bJFjPxquVjItckKzikmjWMERFFmFA.buttonCount;
			}

			private void sQscsCaIpdAHqGuZDSAJjRnbsilJc()
			{
				Array.Clear(aqbwBXCYnBkEBFdMTIPRFYStKGeJA, 0, aqbwBXCYnBkEBFdMTIPRFYStKGeJA.Length);
				Array.Clear(zaJvBkkXeOrRlMuImbPfWBSidOkCA, 0, zaJvBkkXeOrRlMuImbPfWBSidOkCA.Length);
			}

			private string rVKtTFpOoSIiKLqSZtollwCXqrfS()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{PvsuVPDNSwkwgRsAvPuSONwsdmdbA.ToString()}{MPFpdiUpKUCoQnKVVENDjzBUrOem}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{PvsuVPDNSwkwgRsAvPuSONwsdmdbA.ToString()}{MPFpdiUpKUCoQnKVVENDjzBUrOem}");
			}

			public static int AXWcnOimcPxVgLfHtLnIJWtaLbJSA(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, ntrerzlSeRSSjtLosOxIyqpuDOdx P_1)
			{
				if (P_0.mjyZRzelTLZsvSrBiHGSHeuHHkKu < P_1.mjyZRzelTLZsvSrBiHGSHeuHHkKu)
				{
					return -1;
				}
				if (P_0.mjyZRzelTLZsvSrBiHGSHeuHHkKu > P_1.mjyZRzelTLZsvSrBiHGSHeuHHkKu)
				{
					return 1;
				}
				return 0;
			}

			public static int ugeyuqmosDqcrdaSTIoTlbcyxuXA(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, ntrerzlSeRSSjtLosOxIyqpuDOdx P_1)
			{
				if (P_0.yhpvFPPDNngURIkGAidQKrnsvzGO < P_1.yhpvFPPDNngURIkGAidQKrnsvzGO)
				{
					return -1;
				}
				if (P_0.yhpvFPPDNngURIkGAidQKrnsvzGO > P_1.yhpvFPPDNngURIkGAidQKrnsvzGO)
				{
					return 1;
				}
				return 0;
			}
		}

		private class RiwIGXnpDFvjYIcZPSTOyreVbKbx
		{
			public enum wNLtWdqkICwrEKzGCsJlFGoagony
			{
				Exact = 0,
				Approximate = 1
			}

			public class rZyMEiXVzABEuFhJwzSwgPmwOigh
			{
				public int LQCrxtpAyvUbYSNjjoCjYtgdlJDB;

				public long? JtPFEFCNcRaNJwkWGkvEBOHlbmCjb;

				public string NCJfWSHCqopCmRoeXbPlAhbNYSsT;

				public int mjXBNjEvuIXwmIexMMTzOrJaTuft;

				public int nIfTVfyffcGmMpQfRoSNSrsZAmSQ;

				public int mkaDPGeLWARFPJdOTeSSyUMJqHAn;

				public rZyMEiXVzABEuFhJwzSwgPmwOigh(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					LQCrxtpAyvUbYSNjjoCjYtgdlJDB = P_0;
					JtPFEFCNcRaNJwkWGkvEBOHlbmCjb = P_1;
					NCJfWSHCqopCmRoeXbPlAhbNYSsT = P_2;
					mjXBNjEvuIXwmIexMMTzOrJaTuft = P_3;
					nIfTVfyffcGmMpQfRoSNSrsZAmSQ = P_4;
					mkaDPGeLWARFPJdOTeSSyUMJqHAn = P_5;
				}

				public bool BTzsepPHJygmkMZraDMBJvShieud(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, wNLtWdqkICwrEKzGCsJlFGoagony P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == LQCrxtpAyvUbYSNjjoCjYtgdlJDB)
					{
						return true;
					}
					if (P_0.UZwSNqanwSshLlmaVycCDBctRVee != nIfTVfyffcGmMpQfRoSNSrsZAmSQ)
					{
						return false;
					}
					if (P_0.ILKtCxQtAhgAUTMJSxTCrCqRdtIS != mkaDPGeLWARFPJdOTeSSyUMJqHAn)
					{
						return false;
					}
					switch (P_1)
					{
					case wNLtWdqkICwrEKzGCsJlFGoagony.Exact:
						if (JtPFEFCNcRaNJwkWGkvEBOHlbmCjb == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return NCJfWSHCqopCmRoeXbPlAhbNYSsT == P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem;
						}
						return false;
					case wNLtWdqkICwrEKzGCsJlFGoagony.Approximate:
						return NCJfWSHCqopCmRoeXbPlAhbNYSsT == P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class ukxkSPYKqBbRPaiOykpdmaPRNdSR : IEnumerable<rZyMEiXVzABEuFhJwzSwgPmwOigh>, IEnumerable, IEnumerator<rZyMEiXVzABEuFhJwzSwgPmwOigh>, IEnumerator, IDisposable
			{
				private int LjmQrDmBAtSHfODxNbblVKxjJEHE;

				private rZyMEiXVzABEuFhJwzSwgPmwOigh PtbeFfrkKrHOSCxCcewqBKAsmCex;

				private int yEeTRTfJWwgEwEyVapynegFaALLq;

				public RiwIGXnpDFvjYIcZPSTOyreVbKbx CTYENnwSNWpJwcaVQcZdECgnZmau;

				private ntrerzlSeRSSjtLosOxIyqpuDOdx RdwdgUbJMeMPVwWLtmKSZfbEQMNf;

				public ntrerzlSeRSSjtLosOxIyqpuDOdx lXTfrMUOepfqnFkLiWQKOsRGWOOeA;

				private wNLtWdqkICwrEKzGCsJlFGoagony FxoaObWHCVikvwdZSjuIqnwpBipGA;

				public wNLtWdqkICwrEKzGCsJlFGoagony FJBGUwEOiYXFjYQdxEeSnAYeaeiM;

				private int CRXjjtwiAuNruRSKcYRIUaqYCQuS;

				private int jPXmjrsbVXMPxCJySkkamDgGfUU;

				rZyMEiXVzABEuFhJwzSwgPmwOigh IEnumerator<rZyMEiXVzABEuFhJwzSwgPmwOigh>.Current
				{
					[DebuggerHidden]
					get
					{
						return PtbeFfrkKrHOSCxCcewqBKAsmCex;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return PtbeFfrkKrHOSCxCcewqBKAsmCex;
					}
				}

				[DebuggerHidden]
				public ukxkSPYKqBbRPaiOykpdmaPRNdSR(int P_0)
				{
					LjmQrDmBAtSHfODxNbblVKxjJEHE = P_0;
					yEeTRTfJWwgEwEyVapynegFaALLq = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int ljmQrDmBAtSHfODxNbblVKxjJEHE = LjmQrDmBAtSHfODxNbblVKxjJEHE;
					RiwIGXnpDFvjYIcZPSTOyreVbKbx cTYENnwSNWpJwcaVQcZdECgnZmau = CTYENnwSNWpJwcaVQcZdECgnZmau;
					if (ljmQrDmBAtSHfODxNbblVKxjJEHE != 0)
					{
						if (ljmQrDmBAtSHfODxNbblVKxjJEHE != 1)
						{
							return false;
						}
						LjmQrDmBAtSHfODxNbblVKxjJEHE = -1;
						goto IL_0083;
					}
					LjmQrDmBAtSHfODxNbblVKxjJEHE = -1;
					CRXjjtwiAuNruRSKcYRIUaqYCQuS = cTYENnwSNWpJwcaVQcZdECgnZmau.TGycbLvneQLskyHzxXKeCZypGtbA.Count;
					jPXmjrsbVXMPxCJySkkamDgGfUU = 0;
					goto IL_0093;
					IL_0083:
					jPXmjrsbVXMPxCJySkkamDgGfUU++;
					goto IL_0093;
					IL_0093:
					if (jPXmjrsbVXMPxCJySkkamDgGfUU < CRXjjtwiAuNruRSKcYRIUaqYCQuS)
					{
						if (cTYENnwSNWpJwcaVQcZdECgnZmau.TGycbLvneQLskyHzxXKeCZypGtbA[jPXmjrsbVXMPxCJySkkamDgGfUU].BTzsepPHJygmkMZraDMBJvShieud(RdwdgUbJMeMPVwWLtmKSZfbEQMNf, FxoaObWHCVikvwdZSjuIqnwpBipGA))
						{
							PtbeFfrkKrHOSCxCcewqBKAsmCex = cTYENnwSNWpJwcaVQcZdECgnZmau.TGycbLvneQLskyHzxXKeCZypGtbA[jPXmjrsbVXMPxCJySkkamDgGfUU];
							LjmQrDmBAtSHfODxNbblVKxjJEHE = 1;
							return true;
						}
						goto IL_0083;
					}
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
					throw new NotSupportedException();
				}

				[DebuggerHidden]
				IEnumerator<rZyMEiXVzABEuFhJwzSwgPmwOigh> IEnumerable<rZyMEiXVzABEuFhJwzSwgPmwOigh>.GetEnumerator()
				{
					ukxkSPYKqBbRPaiOykpdmaPRNdSR ukxkSPYKqBbRPaiOykpdmaPRNdSR2;
					if (LjmQrDmBAtSHfODxNbblVKxjJEHE == -2 && yEeTRTfJWwgEwEyVapynegFaALLq == Environment.CurrentManagedThreadId)
					{
						LjmQrDmBAtSHfODxNbblVKxjJEHE = 0;
						ukxkSPYKqBbRPaiOykpdmaPRNdSR2 = this;
					}
					else
					{
						ukxkSPYKqBbRPaiOykpdmaPRNdSR2 = new ukxkSPYKqBbRPaiOykpdmaPRNdSR(0);
						ukxkSPYKqBbRPaiOykpdmaPRNdSR2.CTYENnwSNWpJwcaVQcZdECgnZmau = CTYENnwSNWpJwcaVQcZdECgnZmau;
					}
					ukxkSPYKqBbRPaiOykpdmaPRNdSR2.RdwdgUbJMeMPVwWLtmKSZfbEQMNf = lXTfrMUOepfqnFkLiWQKOsRGWOOeA;
					ukxkSPYKqBbRPaiOykpdmaPRNdSR2.FxoaObWHCVikvwdZSjuIqnwpBipGA = FJBGUwEOiYXFjYQdxEeSnAYeaeiM;
					return ukxkSPYKqBbRPaiOykpdmaPRNdSR2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<rZyMEiXVzABEuFhJwzSwgPmwOigh>)this).GetEnumerator();
				}
			}

			private List<rZyMEiXVzABEuFhJwzSwgPmwOigh> TGycbLvneQLskyHzxXKeCZypGtbA;

			public int AbptPOeUqTonTCDQJMEaFeomxZof => TGycbLvneQLskyHzxXKeCZypGtbA.Count;

			public RiwIGXnpDFvjYIcZPSTOyreVbKbx()
			{
				TGycbLvneQLskyHzxXKeCZypGtbA = new List<rZyMEiXVzABEuFhJwzSwgPmwOigh>();
			}

			public void SbtECmAfYVPyKOxYJpyZjOTxuGcpA(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = TGycbLvneQLskyHzxXKeCZypGtbA.Count;
				for (int i = 0; i < count; i++)
				{
					if (TGycbLvneQLskyHzxXKeCZypGtbA[i].BTzsepPHJygmkMZraDMBJvShieud(P_0, wNLtWdqkICwrEKzGCsJlFGoagony.Exact))
					{
						TGycbLvneQLskyHzxXKeCZypGtbA[i].LQCrxtpAyvUbYSNjjoCjYtgdlJDB = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						TGycbLvneQLskyHzxXKeCZypGtbA[i].JtPFEFCNcRaNJwkWGkvEBOHlbmCjb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						TGycbLvneQLskyHzxXKeCZypGtbA[i].NCJfWSHCqopCmRoeXbPlAhbNYSsT = P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem;
						TGycbLvneQLskyHzxXKeCZypGtbA[i].mjXBNjEvuIXwmIexMMTzOrJaTuft = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						TGycbLvneQLskyHzxXKeCZypGtbA[i].nIfTVfyffcGmMpQfRoSNSrsZAmSQ = P_0.UZwSNqanwSshLlmaVycCDBctRVee;
						TGycbLvneQLskyHzxXKeCZypGtbA[i].mkaDPGeLWARFPJdOTeSSyUMJqHAn = P_0.ILKtCxQtAhgAUTMJSxTCrCqRdtIS;
						EdzhISghJFARyKIOykNaIdQloaay(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				TGycbLvneQLskyHzxXKeCZypGtbA.Add(new rZyMEiXVzABEuFhJwzSwgPmwOigh(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.MPFpdiUpKUCoQnKVVENDjzBUrOem, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.UZwSNqanwSshLlmaVycCDBctRVee, P_0.ILKtCxQtAhgAUTMJSxTCrCqRdtIS));
				EdzhISghJFARyKIOykNaIdQloaay(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, TGycbLvneQLskyHzxXKeCZypGtbA.Count - 1);
			}

			public bool fkATCgyWqNpepXPBkepugRHTsFkRA(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, wNLtWdqkICwrEKzGCsJlFGoagony P_1)
			{
				int count = TGycbLvneQLskyHzxXKeCZypGtbA.Count;
				for (int i = 0; i < count; i++)
				{
					if (TGycbLvneQLskyHzxXKeCZypGtbA[i].BTzsepPHJygmkMZraDMBJvShieud(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(ukxkSPYKqBbRPaiOykpdmaPRNdSR))]
			public IEnumerable<rZyMEiXVzABEuFhJwzSwgPmwOigh> avffbdgLEGrNizYIaGnIiraApnjEA(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, wNLtWdqkICwrEKzGCsJlFGoagony P_1)
			{
				return new ukxkSPYKqBbRPaiOykpdmaPRNdSR(-2)
				{
					CTYENnwSNWpJwcaVQcZdECgnZmau = this,
					lXTfrMUOepfqnFkLiWQKOsRGWOOeA = P_0,
					FJBGUwEOiYXFjYQdxEeSnAYeaeiM = P_1
				};
			}

			public int TIVriJmAnxrRpCwVgbOrlyLtcxCO(rZyMEiXVzABEuFhJwzSwgPmwOigh P_0)
			{
				int count = TGycbLvneQLskyHzxXKeCZypGtbA.Count;
				for (int i = 0; i < count; i++)
				{
					if (TGycbLvneQLskyHzxXKeCZypGtbA[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void EdzhISghJFARyKIOykNaIdQloaay(int P_0, int P_1)
			{
				for (int num = TGycbLvneQLskyHzxXKeCZypGtbA.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && TGycbLvneQLskyHzxXKeCZypGtbA[num].LQCrxtpAyvUbYSNjjoCjYtgdlJDB == P_0)
					{
						TGycbLvneQLskyHzxXKeCZypGtbA.RemoveAt(num);
					}
				}
			}
		}

		private List<ntrerzlSeRSSjtLosOxIyqpuDOdx> tphzxPosvmQEZWfxliLWADejuAXU;

		private int gLJaYoAdTNsaAhVDiGTVRnwtYwcy;

		private RiwIGXnpDFvjYIcZPSTOyreVbKbx FkQclaxAuLjTrlyiNDUqiGiZMHqL;

		private UpdateLoopType vZRPbeZKIoYhyzRZJoIeZnoESSGp;

		private Action<int, ControllerDataUpdater> NySihfabWkyIuwUlGYsErxYbmgTG;

		private PlatformInputManager jdQASsZHqedeBRhKfJbKRiQSBYCZ;

		private CustomInputSource nmAcTXhEyNqslTqqulqEqICQItupA;

		private bool hUDHKYjLjcjRXeWoZFkasSKaTZmz;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZKPSbagBIhcyVcPkkDsjSVUbcWOVA;

		private Func<int> DqJxWnvUKBeYVdXevYwunTxksLUA;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => gLJaYoAdTNsaAhVDiGTVRnwtYwcy;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => jdQASsZHqedeBRhKfJbKRiQSBYCZ;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => nmAcTXhEyNqslTqqulqEqICQItupA.nRqNNZnjVHBvSDAJWwOGOwOIEHyt;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			nmAcTXhEyNqslTqqulqEqICQItupA = P_0;
			ZKPSbagBIhcyVcPkkDsjSVUbcWOVA = P_2;
			DqJxWnvUKBeYVdXevYwunTxksLUA = P_3;
			jdQASsZHqedeBRhKfJbKRiQSBYCZ = this;
			try
			{
				NySihfabWkyIuwUlGYsErxYbmgTG = UpdateControllerData;
				P_0.TWUwWrgRaapFEgJKNkjWoHcmtpwH += SystemDeviceConnected;
				P_0.jsTqsdgTSbCuFDWhkQPlmLkDnzYQ += SystemDeviceDisconnected;
			}
			catch (Exception)
			{
				OnDestroy();
				throw;
			}
		}

		[CustomObfuscation(rename = false)]
		public override void Initialize()
		{
			FkQclaxAuLjTrlyiNDUqiGiZMHqL = new RiwIGXnpDFvjYIcZPSTOyreVbKbx();
			tphzxPosvmQEZWfxliLWADejuAXU = new List<ntrerzlSeRSSjtLosOxIyqpuDOdx>();
			hUDHKYjLjcjRXeWoZFkasSKaTZmz = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			vZRPbeZKIoYhyzRZJoIeZnoESSGp = updateLoop;
			if (nmAcTXhEyNqslTqqulqEqICQItupA.isReady)
			{
				nmAcTXhEyNqslTqqulqEqICQItupA.Update();
				if (hUDHKYjLjcjRXeWoZFkasSKaTZmz)
				{
					gEgczyHFYJbAJQdrLkJErRTCdZONA();
				}
				XKrUkBrfRXKyznqRWSeflcIkEvEe();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (nmAcTXhEyNqslTqqulqEqICQItupA != null)
			{
				nmAcTXhEyNqslTqqulqEqICQItupA.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return NySihfabWkyIuwUlGYsErxYbmgTG;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < gLJaYoAdTNsaAhVDiGTVRnwtYwcy; i++)
			{
				if (tphzxPosvmQEZWfxliLWADejuAXU[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					tphzxPosvmQEZWfxliLWADejuAXU[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			hUDHKYjLjcjRXeWoZFkasSKaTZmz = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			hUDHKYjLjcjRXeWoZFkasSKaTZmz = true;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				_SystemDeviceDisconnectedEvent();
			}
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

		private void UaSUWMXYpgEaWjjSjsTaOLHIDpdv(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<ntrerzlSeRSSjtLosOxIyqpuDOdx> list = tphzxPosvmQEZWfxliLWADejuAXU;
			int num2 = gLJaYoAdTNsaAhVDiGTVRnwtYwcy;
			tphzxPosvmQEZWfxliLWADejuAXU = new List<ntrerzlSeRSSjtLosOxIyqpuDOdx>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					ntrerzlSeRSSjtLosOxIyqpuDOdx item = new ntrerzlSeRSSjtLosOxIyqpuDOdx(nmAcTXhEyNqslTqqulqEqICQItupA, P_0[i].systemId, P_0[i].unityId, P_0[i], nmAcTXhEyNqslTqqulqEqICQItupA.nRqNNZnjVHBvSDAJWwOGOwOIEHyt, P_0[i].extension, ZKPSbagBIhcyVcPkkDsjSVUbcWOVA);
					tphzxPosvmQEZWfxliLWADejuAXU.Add(item);
					num++;
				}
			}
			gLJaYoAdTNsaAhVDiGTVRnwtYwcy = num;
			aZDFLHqrawwopZnwKkcRopOxoQUE(num2, num, list, tphzxPosvmQEZWfxliLWADejuAXU);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(tphzxPosvmQEZWfxliLWADejuAXU[j]));
				}
			}
			XmxqgxhYmOOHiOgFUjqoDvGZigTZA(list, tphzxPosvmQEZWfxliLWADejuAXU, false);
			XmxqgxhYmOOHiOgFUjqoDvGZigTZA(tphzxPosvmQEZWfxliLWADejuAXU, list, true);
		}

		private void XKrUkBrfRXKyznqRWSeflcIkEvEe()
		{
			for (int i = 0; i < gLJaYoAdTNsaAhVDiGTVRnwtYwcy; i++)
			{
				tphzxPosvmQEZWfxliLWADejuAXU[i].Update();
			}
		}

		private void aZDFLHqrawwopZnwKkcRopOxoQUE(int P_0, int P_1, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_2, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(ntrerzlSeRSSjtLosOxIyqpuDOdx.ugeyuqmosDqcrdaSTIoTlbcyxuXA);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				GFWjsCHQQAdkpdHQsOGYyrGjLRYn(P_1, P_3, P_0, P_2, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony.Exact);
				if (nmAcTXhEyNqslTqqulqEqICQItupA.useApproximateMatching)
				{
					GFWjsCHQQAdkpdHQsOGYyrGjLRYn(P_1, P_3, P_0, P_2, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony.Approximate);
				}
			}
			tFNUKPUfsPsGZeqOjcESGNeGtFRG(P_1, P_3, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony.Exact);
			if (nmAcTXhEyNqslTqqulqEqICQItupA.useApproximateMatching)
			{
				tFNUKPUfsPsGZeqOjcESGNeGtFRG(P_1, P_3, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx2 = P_3[i];
				if (ntrerzlSeRSSjtLosOxIyqpuDOdx2 != null && ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = qYQinGQrGOGkEFkIWGAHbmrieANuA(P_3);
					ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					FkQclaxAuLjTrlyiNDUqiGiZMHqL.SbtECmAfYVPyKOxYJpyZjOTxuGcpA(ntrerzlSeRSSjtLosOxIyqpuDOdx2);
				}
			}
			P_3.Sort(ntrerzlSeRSSjtLosOxIyqpuDOdx.AXWcnOimcPxVgLfHtLnIJWtaLbJSA);
		}

		private void vcMBNKKiDINsuffznxmgmAAmjCao(List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
				{
					P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
				}
			}
		}

		private bool rJKmUjWzoHoNUGBOmftwPvOetnnk(List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
				{
					return false;
				}
			}
			return true;
		}

		private int qYQinGQrGOGkEFkIWGAHbmrieANuA(List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_0)
		{
			int num = 0;
			while (true)
			{
				bool flag = false;
				int count = P_0.Count;
				for (int i = 0; i < count; i++)
				{
					if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}

		private bool raohAQqjHVvkPkMepOwABfoZqvED(List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		private void GFWjsCHQQAdkpdHQsOGYyrGjLRYn(int P_0, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_1, int P_2, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_3, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony P_4)
		{
			int num = ((P_4 != RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx2 = P_1[i];
				if (ntrerzlSeRSSjtLosOxIyqpuDOdx2 == null || ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx3 = P_3[j];
					if (ntrerzlSeRSSjtLosOxIyqpuDOdx3 != null && !raohAQqjHVvkPkMepOwABfoZqvED(P_1, ntrerzlSeRSSjtLosOxIyqpuDOdx3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && ntrerzlSeRSSjtLosOxIyqpuDOdx2.ewthHljJukeAjZQEsxQkeJDJKLQb(ntrerzlSeRSSjtLosOxIyqpuDOdx3) >= num)
					{
						ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = ntrerzlSeRSSjtLosOxIyqpuDOdx3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ntrerzlSeRSSjtLosOxIyqpuDOdx3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						FkQclaxAuLjTrlyiNDUqiGiZMHqL.SbtECmAfYVPyKOxYJpyZjOTxuGcpA(ntrerzlSeRSSjtLosOxIyqpuDOdx2);
					}
				}
			}
		}

		private void tFNUKPUfsPsGZeqOjcESGNeGtFRG(int P_0, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_1, RiwIGXnpDFvjYIcZPSTOyreVbKbx.wNLtWdqkICwrEKzGCsJlFGoagony P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx2 = P_1[i];
				if (ntrerzlSeRSSjtLosOxIyqpuDOdx2 == null || ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				RiwIGXnpDFvjYIcZPSTOyreVbKbx.rZyMEiXVzABEuFhJwzSwgPmwOigh rZyMEiXVzABEuFhJwzSwgPmwOigh = null;
				foreach (RiwIGXnpDFvjYIcZPSTOyreVbKbx.rZyMEiXVzABEuFhJwzSwgPmwOigh item in FkQclaxAuLjTrlyiNDUqiGiZMHqL.avffbdgLEGrNizYIaGnIiraApnjEA(ntrerzlSeRSSjtLosOxIyqpuDOdx2, P_2))
				{
					if (!raohAQqjHVvkPkMepOwABfoZqvED(P_1, item.LQCrxtpAyvUbYSNjjoCjYtgdlJDB) && item.mjXBNjEvuIXwmIexMMTzOrJaTuft >= 0)
					{
						rZyMEiXVzABEuFhJwzSwgPmwOigh = item;
						break;
					}
				}
				if (rZyMEiXVzABEuFhJwzSwgPmwOigh != null)
				{
					int num = rZyMEiXVzABEuFhJwzSwgPmwOigh.mjXBNjEvuIXwmIexMMTzOrJaTuft;
					if (!rJKmUjWzoHoNUGBOmftwPvOetnnk(P_1, num))
					{
						num = (rZyMEiXVzABEuFhJwzSwgPmwOigh.mjXBNjEvuIXwmIexMMTzOrJaTuft = qYQinGQrGOGkEFkIWGAHbmrieANuA(P_1));
					}
					ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = rZyMEiXVzABEuFhJwzSwgPmwOigh.LQCrxtpAyvUbYSNjjoCjYtgdlJDB;
					FkQclaxAuLjTrlyiNDUqiGiZMHqL.SbtECmAfYVPyKOxYJpyZjOTxuGcpA(ntrerzlSeRSSjtLosOxIyqpuDOdx2);
				}
			}
		}

		private void gEgczyHFYJbAJQdrLkJErRTCdZONA()
		{
			CustomInputSource.Joystick[] array = nmAcTXhEyNqslTqqulqEqICQItupA.PYQCqlToMPGmuUYZadqtJMvJpfVJ();
			if (NdaqdMaqvtMTmDUWxNSTRbZNJfK(array))
			{
				UaSUWMXYpgEaWjjSjsTaOLHIDpdv(array);
			}
			hUDHKYjLjcjRXeWoZFkasSKaTZmz = false;
		}

		private bool NdaqdMaqvtMTmDUWxNSTRbZNJfK(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = tphzxPosvmQEZWfxliLWADejuAXU.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (P_0[i] == null)
				{
					continue;
				}
				long? systemId = P_0[i].systemId;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					if (tphzxPosvmQEZWfxliLWADejuAXU[j] != null && systemId == tphzxPosvmQEZWfxliLWADejuAXU[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (tphzxPosvmQEZWfxliLWADejuAXU[k] == null)
				{
					continue;
				}
				long? num2 = tphzxPosvmQEZWfxliLWADejuAXU[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && num2 == P_0[l].systemId)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private void XmxqgxhYmOOHiOgFUjqoDvGZigTZA(List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_0, List<ntrerzlSeRSSjtLosOxIyqpuDOdx> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx2 = P_0[i];
				if (ntrerzlSeRSSjtLosOxIyqpuDOdx2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						ntrerzlSeRSSjtLosOxIyqpuDOdx ntrerzlSeRSSjtLosOxIyqpuDOdx3 = P_1[j];
						if (ntrerzlSeRSSjtLosOxIyqpuDOdx3 != null && ntrerzlSeRSSjtLosOxIyqpuDOdx2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == ntrerzlSeRSSjtLosOxIyqpuDOdx3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					mlJCLyajWurmKgWHtdzVEbvDthVUb(P_0[i], P_2);
				}
			}
		}

		private void mlJCLyajWurmKgWHtdzVEbvDthVUb(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.hPORRCcsiTbJvNdeuliSQyDvwBcr();
			}
			AwDGMaFXMzfGqVGUJASKhpedbCcX(P_0, P_1);
		}

		private void AwDGMaFXMzfGqVGUJASKhpedbCcX(ntrerzlSeRSSjtLosOxIyqpuDOdx P_0, bool P_1)
		{
			if (P_1)
			{
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(P_0.ToBridgedController());
				}
			}
			else if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			}
		}
	}
}
