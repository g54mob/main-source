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
		private class nPuTebazjrtferQfMGWNIUZtomDp : IInputManagerJoystick, IInputManagerJoystickPublic
		{
			private readonly InputSource XOtDGLQwPSJBfTkLDFZVcvQtExNG;

			private readonly CustomInputSource HkGgIeFYitHvkXyfnEPDYABeBAVf;

			private readonly Controller.Extension mDSBQiqytndLuyGdVIaymzKVCFqb;

			private int KWcDcRrcCBBLfrdiMUddWfylqKaJ;

			private int aMnMfPjAFtwwBGGvAoLExMvKSwfc;

			private long? uAomWFKAIBvbWAGFqMUZecDbVPgG;

			private int EeAsOdNkdNGXEdgFgXhKnJnQQLWQ;

			public Guid meSZmVxVPrOTGSOBkIqSGKPzyWdY;

			public string HlilhTWhpcNyVLpiGVXBGdWAcsGy;

			public string MMqwgNFXqThTbxShGxYmFlJlHEkA;

			private int rmezxADUCHwAGuahJeREkArxMoSPA;

			private int XNknGmzoDqAAEdDokxySwTEDOwhg;

			private float[] deGiUarwboRmyWsLKuesoaqpNsUy;

			private bool[] wjghMNJxqvKzIToBjgWKacqwHgOp;

			private HardwareJoystickMap_InputManager xFYYAxlHWZvEbgsqWjHkkkgIBdMX;

			public CustomInputSource.Joystick FdqHAThzLTURzoWbsSfSJhWILYnK;

			private bool KEasQNnqUcKJsPQOyJVKxdPxyPMR;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ySnnDSTCwKCfsbIUOqtABJBmbEieb;

			public int IgnJYVljsqNpitlvvXaBpxnonIEm
			{
				get
				{
					if (FdqHAThzLTURzoWbsSfSJhWILYnK == null)
					{
						return 0;
					}
					return FdqHAThzLTURzoWbsSfSJhWILYnK.buttonCount;
				}
			}

			public int AfJfVlPBDFtxJBNGmwCHFdUODViAA
			{
				get
				{
					if (FdqHAThzLTURzoWbsSfSJhWILYnK == null)
					{
						return 0;
					}
					return FdqHAThzLTURzoWbsSfSJhWILYnK.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return KWcDcRrcCBBLfrdiMUddWfylqKaJ;
				}
				set
				{
					KWcDcRrcCBBLfrdiMUddWfylqKaJ = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return aMnMfPjAFtwwBGGvAoLExMvKSwfc;
				}
				set
				{
					aMnMfPjAFtwwBGGvAoLExMvKSwfc = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(FdqHAThzLTURzoWbsSfSJhWILYnK.customName)) ? FdqHAThzLTURzoWbsSfSJhWILYnK.customName : HlilhTWhpcNyVLpiGVXBGdWAcsGy);
					if (text == "Unknown Controller")
					{
						text = MMqwgNFXqThTbxShGxYmFlJlHEkA;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => uAomWFKAIBvbWAGFqMUZecDbVPgG;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => EeAsOdNkdNGXEdgFgXhKnJnQQLWQ;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!uAomWFKAIBvbWAGFqMUZecDbVPgG.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + uAomWFKAIBvbWAGFqMUZecDbVPgG);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => mDSBQiqytndLuyGdVIaymzKVCFqb;

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

			public nPuTebazjrtferQfMGWNIUZtomDp(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				HkGgIeFYitHvkXyfnEPDYABeBAVf = P_0;
				XOtDGLQwPSJBfTkLDFZVcvQtExNG = P_4;
				uAomWFKAIBvbWAGFqMUZecDbVPgG = P_1;
				FdqHAThzLTURzoWbsSfSJhWILYnK = P_3;
				EeAsOdNkdNGXEdgFgXhKnJnQQLWQ = P_2;
				mDSBQiqytndLuyGdVIaymzKVCFqb = P_5;
				ySnnDSTCwKCfsbIUOqtABJBmbEieb = P_6;
				aMnMfPjAFtwwBGGvAoLExMvKSwfc = -1;
				KWcDcRrcCBBLfrdiMUddWfylqKaJ = -1;
				pwLfIADjrvhuifDnFIVNIizZkhSnc();
				IQxWSdZSHffTWHIFGdgpdyZJdZzL();
				meSZmVxVPrOTGSOBkIqSGKPzyWdY = xFYYAxlHWZvEbgsqWjHkkkgIBdMX.hardwareMapIdentifier.guid;
				HlilhTWhpcNyVLpiGVXBGdWAcsGy = xFYYAxlHWZvEbgsqWjHkkkgIBdMX.controllerName;
				deGiUarwboRmyWsLKuesoaqpNsUy = new float[rmezxADUCHwAGuahJeREkArxMoSPA];
				wjghMNJxqvKzIToBjgWKacqwHgOp = new bool[XNknGmzoDqAAEdDokxySwTEDOwhg];
				Update();
			}

			public void pwLfIADjrvhuifDnFIVNIizZkhSnc()
			{
				MMqwgNFXqThTbxShGxYmFlJlHEkA = FdqHAThzLTURzoWbsSfSJhWILYnK.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (FdqHAThzLTURzoWbsSfSJhWILYnK.isConnected)
				{
					mcbfxKNzCeAVMWrTTmJYmMRfZLsl();
					hhvbVPTGSHstXcZfxrXMnxLahLBf();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int aqluzRkcUGZWTJAFIQTFEWpYmhzl(nPuTebazjrtferQfMGWNIUZtomDp P_0)
			{
				if (P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA == MMqwgNFXqThTbxShGxYmFlJlHEkA && P_0.uAomWFKAIBvbWAGFqMUZecDbVPgG == uAomWFKAIBvbWAGFqMUZecDbVPgG)
				{
					return 2;
				}
				if (P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA == MMqwgNFXqThTbxShGxYmFlJlHEkA)
				{
					return 1;
				}
				return 0;
			}

			private void HckyTKrPjcGOfEhlxMiWeRiXYHpO(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = XOtDGLQwPSJBfTkLDFZVcvQtExNG;
				P_0.inputSource = XOtDGLQwPSJBfTkLDFZVcvQtExNG;
				P_0.hardwareIdentifier = jpJfENwEruVHDNhXvYFaTBiCrVPo();
				P_0.hardwareAxisCount = rmezxADUCHwAGuahJeREkArxMoSPA;
				P_0.hardwareButtonCount = XNknGmzoDqAAEdDokxySwTEDOwhg;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = MMqwgNFXqThTbxShGxYmFlJlHEkA;
				P_0.hw_supportsVibration = FdqHAThzLTURzoWbsSfSJhWILYnK.supportsVibration;
			}

			private void CspnaEjKNoNjdOViJEByZpzTJZyT(BridgedController P_0)
			{
				HckyTKrPjcGOfEhlxMiWeRiXYHpO(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = xFYYAxlHWZvEbgsqWjHkkkgIBdMX.ToGameHardwareControllerMap();
				P_0.instanceName = MMqwgNFXqThTbxShGxYmFlJlHEkA;
				P_0.productName = MMqwgNFXqThTbxShGxYmFlJlHEkA;
				P_0.isXInputDevice = false;
				P_0.axisCount = rmezxADUCHwAGuahJeREkArxMoSPA;
				P_0.buttonCount = XNknGmzoDqAAEdDokxySwTEDOwhg;
				P_0.controllerTypeGuid = meSZmVxVPrOTGSOBkIqSGKPzyWdY;
				P_0.customInputSource = HkGgIeFYitHvkXyfnEPDYABeBAVf;
				P_0.controllerExtension = mDSBQiqytndLuyGdVIaymzKVCFqb;
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (rmezxADUCHwAGuahJeREkArxMoSPA != dataUpdater.axisCount || XNknGmzoDqAAEdDokxySwTEDOwhg != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < rmezxADUCHwAGuahJeREkArxMoSPA; i++)
				{
					dataUpdater.axisValues[i] = deGiUarwboRmyWsLKuesoaqpNsUy[i];
				}
				for (int j = 0; j < XNknGmzoDqAAEdDokxySwTEDOwhg; j++)
				{
					dataUpdater.buttonValues[j] = wjghMNJxqvKzIToBjgWKacqwHgOp[j];
				}
				if (KEasQNnqUcKJsPQOyJVKxdPxyPMR && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo GIvrKtVlBBTVfmfGCcCWzdSxFqau()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				HckyTKrPjcGOfEhlxMiWeRiXYHpO(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				CspnaEjKNoNjdOViJEByZpzTJZyT(bridgedController);
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
				return new ControllerDisconnectedEventArgs(KWcDcRrcCBBLfrdiMUddWfylqKaJ);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void mcbfxKNzCeAVMWrTTmJYmMRfZLsl()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)xFYYAxlHWZvEbgsqWjHkkkgIBdMX.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= rmezxADUCHwAGuahJeREkArxMoSPA)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						deGiUarwboRmyWsLKuesoaqpNsUy[i] = qixvrEArWosULumYbEjYbnqwbouu(axes[i]);
						if (!KEasQNnqUcKJsPQOyJVKxdPxyPMR && deGiUarwboRmyWsLKuesoaqpNsUy[i] != 0f)
						{
							KEasQNnqUcKJsPQOyJVKxdPxyPMR = true;
						}
					}
				}
			}

			private void hhvbVPTGSHstXcZfxrXMnxLahLBf()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)xFYYAxlHWZvEbgsqWjHkkkgIBdMX.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= XNknGmzoDqAAEdDokxySwTEDOwhg)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					wjghMNJxqvKzIToBjgWKacqwHgOp[i] = PfRRpYUlhyHOIIVELNPfurFchPOdb(buttons[i]);
					if (!KEasQNnqUcKJsPQOyJVKxdPxyPMR && wjghMNJxqvKzIToBjgWKacqwHgOp[i])
					{
						KEasQNnqUcKJsPQOyJVKxdPxyPMR = true;
					}
				}
			}

			private bool PfRRpYUlhyHOIIVELNPfurFchPOdb(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return wVsksimbIiGxEtfXooHhWJXPdKIbA(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = QlcalHMcrfspIBmXUuGmuJZkLyLb(P_0.sourceAxis);
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

			private bool ZuvNGtADPNcztbomOZYTTabhpwKBA(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float qixvrEArWosULumYbEjYbnqwbouu(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return QlcalHMcrfspIBmXUuGmuJZkLyLb(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!wVsksimbIiGxEtfXooHhWJXPdKIbA(P_0.sourceButton))
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

			private float QlcalHMcrfspIBmXUuGmuJZkLyLb(int P_0)
			{
				return FdqHAThzLTURzoWbsSfSJhWILYnK.GetAxisValue(P_0);
			}

			private bool wVsksimbIiGxEtfXooHhWJXPdKIbA(int P_0)
			{
				return FdqHAThzLTURzoWbsSfSJhWILYnK.GetButtonValue(P_0);
			}

			private void IQxWSdZSHffTWHIFGdgpdyZJdZzL()
			{
				xFYYAxlHWZvEbgsqWjHkkkgIBdMX = ySnnDSTCwKCfsbIUOqtABJBmbEieb(GIvrKtVlBBTVfmfGCcCWzdSxFqau());
				if (xFYYAxlHWZvEbgsqWjHkkkgIBdMX == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				rmezxADUCHwAGuahJeREkArxMoSPA = xFYYAxlHWZvEbgsqWjHkkkgIBdMX.axisCount;
				XNknGmzoDqAAEdDokxySwTEDOwhg = xFYYAxlHWZvEbgsqWjHkkkgIBdMX.buttonCount;
			}

			private void okdPhUDDcJSqrmHYpgnSznLnkUPU()
			{
				Array.Clear(wjghMNJxqvKzIToBjgWKacqwHgOp, 0, wjghMNJxqvKzIToBjgWKacqwHgOp.Length);
				Array.Clear(deGiUarwboRmyWsLKuesoaqpNsUy, 0, deGiUarwboRmyWsLKuesoaqpNsUy.Length);
			}

			private string jpJfENwEruVHDNhXvYFaTBiCrVPo()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{XOtDGLQwPSJBfTkLDFZVcvQtExNG.ToString()}{MMqwgNFXqThTbxShGxYmFlJlHEkA}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{XOtDGLQwPSJBfTkLDFZVcvQtExNG.ToString()}{MMqwgNFXqThTbxShGxYmFlJlHEkA}");
			}

			public static int AbFsaMfmhtAcjHhMVPATMsFdbZxjA(nPuTebazjrtferQfMGWNIUZtomDp P_0, nPuTebazjrtferQfMGWNIUZtomDp P_1)
			{
				if (P_0.aMnMfPjAFtwwBGGvAoLExMvKSwfc < P_1.aMnMfPjAFtwwBGGvAoLExMvKSwfc)
				{
					return -1;
				}
				if (P_0.aMnMfPjAFtwwBGGvAoLExMvKSwfc > P_1.aMnMfPjAFtwwBGGvAoLExMvKSwfc)
				{
					return 1;
				}
				return 0;
			}

			public static int cnztLcllrfXhbnehvKdrVPXjeZOr(nPuTebazjrtferQfMGWNIUZtomDp P_0, nPuTebazjrtferQfMGWNIUZtomDp P_1)
			{
				if (P_0.uAomWFKAIBvbWAGFqMUZecDbVPgG < P_1.uAomWFKAIBvbWAGFqMUZecDbVPgG)
				{
					return -1;
				}
				if (P_0.uAomWFKAIBvbWAGFqMUZecDbVPgG > P_1.uAomWFKAIBvbWAGFqMUZecDbVPgG)
				{
					return 1;
				}
				return 0;
			}
		}

		private class HfhzHLyuIjJAZYIMxzaRILGCFgRbA
		{
			public enum aMkuvJnDohRNUMTqtLwtdUjkKDCA
			{
				Exact = 0,
				Approximate = 1
			}

			public class bdhJyUIcIqqvmZOMIQneSOAluQEB
			{
				public int DxJeQhgpPUdqsWcWHZuDaqDsNkvK;

				public long? FMKrVTOSpxcyUszHmiWZoLvqPQgq;

				public string FwKHmKMjzMlcjHrlbwekoeLEKwCP;

				public int aMKlItXYvkXXnWxukyXoyohtSwJg;

				public int nmmSCtvkcIJxVpnmxxbCueWMHOgX;

				public int iDlOEzzVHgkEtJHmlpZkKsVUzsAB;

				public bdhJyUIcIqqvmZOMIQneSOAluQEB(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					DxJeQhgpPUdqsWcWHZuDaqDsNkvK = P_0;
					FMKrVTOSpxcyUszHmiWZoLvqPQgq = P_1;
					FwKHmKMjzMlcjHrlbwekoeLEKwCP = P_2;
					aMKlItXYvkXXnWxukyXoyohtSwJg = P_3;
					nmmSCtvkcIJxVpnmxxbCueWMHOgX = P_4;
					iDlOEzzVHgkEtJHmlpZkKsVUzsAB = P_5;
				}

				public bool FaythlMgQYeHhQKUQzoYrATaLGYw(nPuTebazjrtferQfMGWNIUZtomDp P_0, aMkuvJnDohRNUMTqtLwtdUjkKDCA P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == DxJeQhgpPUdqsWcWHZuDaqDsNkvK)
					{
						return true;
					}
					if (P_0.IgnJYVljsqNpitlvvXaBpxnonIEm != nmmSCtvkcIJxVpnmxxbCueWMHOgX)
					{
						return false;
					}
					if (P_0.AfJfVlPBDFtxJBNGmwCHFdUODViAA != iDlOEzzVHgkEtJHmlpZkKsVUzsAB)
					{
						return false;
					}
					switch (P_1)
					{
					case aMkuvJnDohRNUMTqtLwtdUjkKDCA.Exact:
						if (FMKrVTOSpxcyUszHmiWZoLvqPQgq == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return FwKHmKMjzMlcjHrlbwekoeLEKwCP == P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA;
						}
						return false;
					case aMkuvJnDohRNUMTqtLwtdUjkKDCA.Approximate:
						return FwKHmKMjzMlcjHrlbwekoeLEKwCP == P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class iNkpIVLldbIuKaFJYOuNYrwANcPB : IEnumerable<bdhJyUIcIqqvmZOMIQneSOAluQEB>, IEnumerable, IEnumerator<bdhJyUIcIqqvmZOMIQneSOAluQEB>, IEnumerator, IDisposable
			{
				private int XFzVJjrRSLjByYqQfCsodwcefRxI;

				private bdhJyUIcIqqvmZOMIQneSOAluQEB LPkuWfiaFZuvPWBHQeVvcxgxveSDA;

				private int yihEKTmZBCJzpGmUMEVmGkhtilbKA;

				public HfhzHLyuIjJAZYIMxzaRILGCFgRbA GxFJhZxKicMhngGbmaBecMOcGNUd;

				private nPuTebazjrtferQfMGWNIUZtomDp DvleUasJKUpQkqEsNVDJzJxHirub;

				public nPuTebazjrtferQfMGWNIUZtomDp teYvyGLplDSFqwIQYgzRGJpZsuwm;

				private aMkuvJnDohRNUMTqtLwtdUjkKDCA TanzXfHVdxJeycWXiJcRIUWqScFf;

				public aMkuvJnDohRNUMTqtLwtdUjkKDCA FnYJhqFbUescuOkuBpbFPeNxOgUF;

				private int CoYdixzXTKpurJkJCjuBwiYREuEO;

				private int zLSdWjubkdbLEzEIIZChIWppZtaF;

				bdhJyUIcIqqvmZOMIQneSOAluQEB IEnumerator<bdhJyUIcIqqvmZOMIQneSOAluQEB>.Current
				{
					[DebuggerHidden]
					get
					{
						return LPkuWfiaFZuvPWBHQeVvcxgxveSDA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return LPkuWfiaFZuvPWBHQeVvcxgxveSDA;
					}
				}

				[DebuggerHidden]
				public iNkpIVLldbIuKaFJYOuNYrwANcPB(int P_0)
				{
					XFzVJjrRSLjByYqQfCsodwcefRxI = P_0;
					yihEKTmZBCJzpGmUMEVmGkhtilbKA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int xFzVJjrRSLjByYqQfCsodwcefRxI = XFzVJjrRSLjByYqQfCsodwcefRxI;
					HfhzHLyuIjJAZYIMxzaRILGCFgRbA gxFJhZxKicMhngGbmaBecMOcGNUd = GxFJhZxKicMhngGbmaBecMOcGNUd;
					if (xFzVJjrRSLjByYqQfCsodwcefRxI != 0)
					{
						if (xFzVJjrRSLjByYqQfCsodwcefRxI != 1)
						{
							return false;
						}
						XFzVJjrRSLjByYqQfCsodwcefRxI = -1;
						goto IL_0083;
					}
					XFzVJjrRSLjByYqQfCsodwcefRxI = -1;
					CoYdixzXTKpurJkJCjuBwiYREuEO = gxFJhZxKicMhngGbmaBecMOcGNUd.LbDnobiRyYkLlklATikJcjlzbkDx.Count;
					zLSdWjubkdbLEzEIIZChIWppZtaF = 0;
					goto IL_0093;
					IL_0083:
					zLSdWjubkdbLEzEIIZChIWppZtaF++;
					goto IL_0093;
					IL_0093:
					if (zLSdWjubkdbLEzEIIZChIWppZtaF < CoYdixzXTKpurJkJCjuBwiYREuEO)
					{
						if (gxFJhZxKicMhngGbmaBecMOcGNUd.LbDnobiRyYkLlklATikJcjlzbkDx[zLSdWjubkdbLEzEIIZChIWppZtaF].FaythlMgQYeHhQKUQzoYrATaLGYw(DvleUasJKUpQkqEsNVDJzJxHirub, TanzXfHVdxJeycWXiJcRIUWqScFf))
						{
							LPkuWfiaFZuvPWBHQeVvcxgxveSDA = gxFJhZxKicMhngGbmaBecMOcGNUd.LbDnobiRyYkLlklATikJcjlzbkDx[zLSdWjubkdbLEzEIIZChIWppZtaF];
							XFzVJjrRSLjByYqQfCsodwcefRxI = 1;
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
				IEnumerator<bdhJyUIcIqqvmZOMIQneSOAluQEB> IEnumerable<bdhJyUIcIqqvmZOMIQneSOAluQEB>.GetEnumerator()
				{
					iNkpIVLldbIuKaFJYOuNYrwANcPB iNkpIVLldbIuKaFJYOuNYrwANcPB2;
					if (XFzVJjrRSLjByYqQfCsodwcefRxI == -2 && yihEKTmZBCJzpGmUMEVmGkhtilbKA == Environment.CurrentManagedThreadId)
					{
						XFzVJjrRSLjByYqQfCsodwcefRxI = 0;
						iNkpIVLldbIuKaFJYOuNYrwANcPB2 = this;
					}
					else
					{
						iNkpIVLldbIuKaFJYOuNYrwANcPB2 = new iNkpIVLldbIuKaFJYOuNYrwANcPB(0);
						iNkpIVLldbIuKaFJYOuNYrwANcPB2.GxFJhZxKicMhngGbmaBecMOcGNUd = GxFJhZxKicMhngGbmaBecMOcGNUd;
					}
					iNkpIVLldbIuKaFJYOuNYrwANcPB2.DvleUasJKUpQkqEsNVDJzJxHirub = teYvyGLplDSFqwIQYgzRGJpZsuwm;
					iNkpIVLldbIuKaFJYOuNYrwANcPB2.TanzXfHVdxJeycWXiJcRIUWqScFf = FnYJhqFbUescuOkuBpbFPeNxOgUF;
					return iNkpIVLldbIuKaFJYOuNYrwANcPB2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<bdhJyUIcIqqvmZOMIQneSOAluQEB>)this).GetEnumerator();
				}
			}

			private List<bdhJyUIcIqqvmZOMIQneSOAluQEB> LbDnobiRyYkLlklATikJcjlzbkDx;

			public int ShgmkKvfLhcZCCXAhtXndhCtgDOn => LbDnobiRyYkLlklATikJcjlzbkDx.Count;

			public HfhzHLyuIjJAZYIMxzaRILGCFgRbA()
			{
				LbDnobiRyYkLlklATikJcjlzbkDx = new List<bdhJyUIcIqqvmZOMIQneSOAluQEB>();
			}

			public void KUiPXkyCDxVNLbLBrZROqphuIkMKA(nPuTebazjrtferQfMGWNIUZtomDp P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = LbDnobiRyYkLlklATikJcjlzbkDx.Count;
				for (int i = 0; i < count; i++)
				{
					if (LbDnobiRyYkLlklATikJcjlzbkDx[i].FaythlMgQYeHhQKUQzoYrATaLGYw(P_0, aMkuvJnDohRNUMTqtLwtdUjkKDCA.Exact))
					{
						LbDnobiRyYkLlklATikJcjlzbkDx[i].DxJeQhgpPUdqsWcWHZuDaqDsNkvK = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						LbDnobiRyYkLlklATikJcjlzbkDx[i].FMKrVTOSpxcyUszHmiWZoLvqPQgq = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						LbDnobiRyYkLlklATikJcjlzbkDx[i].FwKHmKMjzMlcjHrlbwekoeLEKwCP = P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA;
						LbDnobiRyYkLlklATikJcjlzbkDx[i].aMKlItXYvkXXnWxukyXoyohtSwJg = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						LbDnobiRyYkLlklATikJcjlzbkDx[i].nmmSCtvkcIJxVpnmxxbCueWMHOgX = P_0.IgnJYVljsqNpitlvvXaBpxnonIEm;
						LbDnobiRyYkLlklATikJcjlzbkDx[i].iDlOEzzVHgkEtJHmlpZkKsVUzsAB = P_0.AfJfVlPBDFtxJBNGmwCHFdUODViAA;
						EZstJYfJCrmmdWgVQUglcvucqEYs(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				LbDnobiRyYkLlklATikJcjlzbkDx.Add(new bdhJyUIcIqqvmZOMIQneSOAluQEB(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.MMqwgNFXqThTbxShGxYmFlJlHEkA, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.IgnJYVljsqNpitlvvXaBpxnonIEm, P_0.AfJfVlPBDFtxJBNGmwCHFdUODViAA));
				EZstJYfJCrmmdWgVQUglcvucqEYs(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, LbDnobiRyYkLlklATikJcjlzbkDx.Count - 1);
			}

			public bool bDTEXevVvvOFqRXMCDCpzbxWjfUx(nPuTebazjrtferQfMGWNIUZtomDp P_0, aMkuvJnDohRNUMTqtLwtdUjkKDCA P_1)
			{
				int count = LbDnobiRyYkLlklATikJcjlzbkDx.Count;
				for (int i = 0; i < count; i++)
				{
					if (LbDnobiRyYkLlklATikJcjlzbkDx[i].FaythlMgQYeHhQKUQzoYrATaLGYw(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(iNkpIVLldbIuKaFJYOuNYrwANcPB))]
			public IEnumerable<bdhJyUIcIqqvmZOMIQneSOAluQEB> womRwxGVNoVkhEVHCNEFZaGBrTRM(nPuTebazjrtferQfMGWNIUZtomDp P_0, aMkuvJnDohRNUMTqtLwtdUjkKDCA P_1)
			{
				return new iNkpIVLldbIuKaFJYOuNYrwANcPB(-2)
				{
					GxFJhZxKicMhngGbmaBecMOcGNUd = this,
					teYvyGLplDSFqwIQYgzRGJpZsuwm = P_0,
					FnYJhqFbUescuOkuBpbFPeNxOgUF = P_1
				};
			}

			public int JFWfnRjRgDEqaiUKOCbiTXzsqRifA(bdhJyUIcIqqvmZOMIQneSOAluQEB P_0)
			{
				int count = LbDnobiRyYkLlklATikJcjlzbkDx.Count;
				for (int i = 0; i < count; i++)
				{
					if (LbDnobiRyYkLlklATikJcjlzbkDx[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void EZstJYfJCrmmdWgVQUglcvucqEYs(int P_0, int P_1)
			{
				for (int num = LbDnobiRyYkLlklATikJcjlzbkDx.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && LbDnobiRyYkLlklATikJcjlzbkDx[num].DxJeQhgpPUdqsWcWHZuDaqDsNkvK == P_0)
					{
						LbDnobiRyYkLlklATikJcjlzbkDx.RemoveAt(num);
					}
				}
			}
		}

		private List<nPuTebazjrtferQfMGWNIUZtomDp> lIsqeDleLIrbYWwQRwYPsYDgsPre;

		private int sfQMNumcArWBHZAIGMwKNZKkEAYU;

		private HfhzHLyuIjJAZYIMxzaRILGCFgRbA RDNvReyhHtGCarbGnaYdYSKEqMQD;

		private UpdateLoopType hWMcmugQLYLGfIpYvLhvqnKJHocib;

		private Action<int, ControllerDataUpdater> DvPUspvcTOXbvkqggjbNCXgeGWfwA;

		private PlatformInputManager jZZFSeCdtYhGONGJZmSJxpuFfwcR;

		private CustomInputSource zFZKARDebphLkcsvAKTTbkgiBLQsb;

		private bool zACyLEeQoIweEKtpvkFduMwljxMr;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ReWfucbdNNbNAJPtMLVaafcqkcugA;

		private Func<int> TohsyIudBoHVTtROGnZvBopsWahL;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => sfQMNumcArWBHZAIGMwKNZKkEAYU;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => jZZFSeCdtYhGONGJZmSJxpuFfwcR;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => zFZKARDebphLkcsvAKTTbkgiBLQsb.byneCVecOfLQLwZAqjbLTkmNJxMgb;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			zFZKARDebphLkcsvAKTTbkgiBLQsb = P_0;
			ReWfucbdNNbNAJPtMLVaafcqkcugA = P_2;
			TohsyIudBoHVTtROGnZvBopsWahL = P_3;
			jZZFSeCdtYhGONGJZmSJxpuFfwcR = this;
			try
			{
				DvPUspvcTOXbvkqggjbNCXgeGWfwA = UpdateControllerData;
				P_0.JTFdCGfzIKYWZoERpDXXYIZdLjGD += SystemDeviceConnected;
				P_0.jOYgdhCpNDMLSpHoOyasRIQSdPkgb += SystemDeviceDisconnected;
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
			RDNvReyhHtGCarbGnaYdYSKEqMQD = new HfhzHLyuIjJAZYIMxzaRILGCFgRbA();
			lIsqeDleLIrbYWwQRwYPsYDgsPre = new List<nPuTebazjrtferQfMGWNIUZtomDp>();
			zACyLEeQoIweEKtpvkFduMwljxMr = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			hWMcmugQLYLGfIpYvLhvqnKJHocib = updateLoop;
			if (zFZKARDebphLkcsvAKTTbkgiBLQsb.isReady)
			{
				zFZKARDebphLkcsvAKTTbkgiBLQsb.Update();
				if (zACyLEeQoIweEKtpvkFduMwljxMr)
				{
					cydIoyWYJxtlSnLqhEeDezfPmvqtA();
				}
				FRwCXXqKybctizPbqfdsHRKtPeueb();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (zFZKARDebphLkcsvAKTTbkgiBLQsb != null)
			{
				zFZKARDebphLkcsvAKTTbkgiBLQsb.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return DvPUspvcTOXbvkqggjbNCXgeGWfwA;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < sfQMNumcArWBHZAIGMwKNZKkEAYU; i++)
			{
				if (lIsqeDleLIrbYWwQRwYPsYDgsPre[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					lIsqeDleLIrbYWwQRwYPsYDgsPre[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			zACyLEeQoIweEKtpvkFduMwljxMr = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			zACyLEeQoIweEKtpvkFduMwljxMr = true;
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

		private void IDXiFMCLkYDPRzLTDaydHudLpLFAA(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<nPuTebazjrtferQfMGWNIUZtomDp> list = lIsqeDleLIrbYWwQRwYPsYDgsPre;
			int num2 = sfQMNumcArWBHZAIGMwKNZKkEAYU;
			lIsqeDleLIrbYWwQRwYPsYDgsPre = new List<nPuTebazjrtferQfMGWNIUZtomDp>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					nPuTebazjrtferQfMGWNIUZtomDp item = new nPuTebazjrtferQfMGWNIUZtomDp(zFZKARDebphLkcsvAKTTbkgiBLQsb, P_0[i].systemId, P_0[i].unityId, P_0[i], zFZKARDebphLkcsvAKTTbkgiBLQsb.byneCVecOfLQLwZAqjbLTkmNJxMgb, P_0[i].extension, ReWfucbdNNbNAJPtMLVaafcqkcugA);
					lIsqeDleLIrbYWwQRwYPsYDgsPre.Add(item);
					num++;
				}
			}
			sfQMNumcArWBHZAIGMwKNZKkEAYU = num;
			mwSEOZlxcGFjcLfamJPOGjHcPQaV(num2, num, list, lIsqeDleLIrbYWwQRwYPsYDgsPre);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(lIsqeDleLIrbYWwQRwYPsYDgsPre[j]));
				}
			}
			LScGrxHofyNgnFMWssXdpBmCFKdVA(list, lIsqeDleLIrbYWwQRwYPsYDgsPre, false);
			LScGrxHofyNgnFMWssXdpBmCFKdVA(lIsqeDleLIrbYWwQRwYPsYDgsPre, list, true);
		}

		private void FRwCXXqKybctizPbqfdsHRKtPeueb()
		{
			for (int i = 0; i < sfQMNumcArWBHZAIGMwKNZKkEAYU; i++)
			{
				lIsqeDleLIrbYWwQRwYPsYDgsPre[i].Update();
			}
		}

		private void mwSEOZlxcGFjcLfamJPOGjHcPQaV(int P_0, int P_1, List<nPuTebazjrtferQfMGWNIUZtomDp> P_2, List<nPuTebazjrtferQfMGWNIUZtomDp> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(nPuTebazjrtferQfMGWNIUZtomDp.cnztLcllrfXhbnehvKdrVPXjeZOr);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				WcHYfKQeLqONyjSROenHMKeuUnoR(P_1, P_3, P_0, P_2, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA.Exact);
				if (zFZKARDebphLkcsvAKTTbkgiBLQsb.useApproximateMatching)
				{
					WcHYfKQeLqONyjSROenHMKeuUnoR(P_1, P_3, P_0, P_2, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA.Approximate);
				}
			}
			jCMXtVFocnZOUgUbZLiXqZbLLTlg(P_1, P_3, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA.Exact);
			if (zFZKARDebphLkcsvAKTTbkgiBLQsb.useApproximateMatching)
			{
				jCMXtVFocnZOUgUbZLiXqZbLLTlg(P_1, P_3, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp2 = P_3[i];
				if (nPuTebazjrtferQfMGWNIUZtomDp2 != null && nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = cVRUeEPTJwsFBBNHmNrUQANdXchN(P_3);
					nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					RDNvReyhHtGCarbGnaYdYSKEqMQD.KUiPXkyCDxVNLbLBrZROqphuIkMKA(nPuTebazjrtferQfMGWNIUZtomDp2);
				}
			}
			P_3.Sort(nPuTebazjrtferQfMGWNIUZtomDp.AbFsaMfmhtAcjHhMVPATMsFdbZxjA);
		}

		private void zFJWpOVUBkkavpwvXUbhEkqzkIMh(List<nPuTebazjrtferQfMGWNIUZtomDp> P_0, int P_1, int P_2)
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

		private bool bnPbGxLctdROJYDZWhUzboyrWFRn(List<nPuTebazjrtferQfMGWNIUZtomDp> P_0, int P_1)
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

		private int cVRUeEPTJwsFBBNHmNrUQANdXchN(List<nPuTebazjrtferQfMGWNIUZtomDp> P_0)
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

		private bool zGlgDMfgqvGOYeCTPqvLbzZUMisk(List<nPuTebazjrtferQfMGWNIUZtomDp> P_0, int P_1)
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

		private void WcHYfKQeLqONyjSROenHMKeuUnoR(int P_0, List<nPuTebazjrtferQfMGWNIUZtomDp> P_1, int P_2, List<nPuTebazjrtferQfMGWNIUZtomDp> P_3, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA P_4)
		{
			int num = ((P_4 != HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp2 = P_1[i];
				if (nPuTebazjrtferQfMGWNIUZtomDp2 == null || nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp3 = P_3[j];
					if (nPuTebazjrtferQfMGWNIUZtomDp3 != null && !zGlgDMfgqvGOYeCTPqvLbzZUMisk(P_1, nPuTebazjrtferQfMGWNIUZtomDp3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && nPuTebazjrtferQfMGWNIUZtomDp2.aqluzRkcUGZWTJAFIQTFEWpYmhzl(nPuTebazjrtferQfMGWNIUZtomDp3) >= num)
					{
						nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = nPuTebazjrtferQfMGWNIUZtomDp3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = nPuTebazjrtferQfMGWNIUZtomDp3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						RDNvReyhHtGCarbGnaYdYSKEqMQD.KUiPXkyCDxVNLbLBrZROqphuIkMKA(nPuTebazjrtferQfMGWNIUZtomDp2);
					}
				}
			}
		}

		private void jCMXtVFocnZOUgUbZLiXqZbLLTlg(int P_0, List<nPuTebazjrtferQfMGWNIUZtomDp> P_1, HfhzHLyuIjJAZYIMxzaRILGCFgRbA.aMkuvJnDohRNUMTqtLwtdUjkKDCA P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp2 = P_1[i];
				if (nPuTebazjrtferQfMGWNIUZtomDp2 == null || nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				HfhzHLyuIjJAZYIMxzaRILGCFgRbA.bdhJyUIcIqqvmZOMIQneSOAluQEB bdhJyUIcIqqvmZOMIQneSOAluQEB = null;
				foreach (HfhzHLyuIjJAZYIMxzaRILGCFgRbA.bdhJyUIcIqqvmZOMIQneSOAluQEB item in RDNvReyhHtGCarbGnaYdYSKEqMQD.womRwxGVNoVkhEVHCNEFZaGBrTRM(nPuTebazjrtferQfMGWNIUZtomDp2, P_2))
				{
					if (!zGlgDMfgqvGOYeCTPqvLbzZUMisk(P_1, item.DxJeQhgpPUdqsWcWHZuDaqDsNkvK) && item.aMKlItXYvkXXnWxukyXoyohtSwJg >= 0)
					{
						bdhJyUIcIqqvmZOMIQneSOAluQEB = item;
						break;
					}
				}
				if (bdhJyUIcIqqvmZOMIQneSOAluQEB != null)
				{
					int num = bdhJyUIcIqqvmZOMIQneSOAluQEB.aMKlItXYvkXXnWxukyXoyohtSwJg;
					if (!bnPbGxLctdROJYDZWhUzboyrWFRn(P_1, num))
					{
						num = (bdhJyUIcIqqvmZOMIQneSOAluQEB.aMKlItXYvkXXnWxukyXoyohtSwJg = cVRUeEPTJwsFBBNHmNrUQANdXchN(P_1));
					}
					nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = bdhJyUIcIqqvmZOMIQneSOAluQEB.DxJeQhgpPUdqsWcWHZuDaqDsNkvK;
					RDNvReyhHtGCarbGnaYdYSKEqMQD.KUiPXkyCDxVNLbLBrZROqphuIkMKA(nPuTebazjrtferQfMGWNIUZtomDp2);
				}
			}
		}

		private void cydIoyWYJxtlSnLqhEeDezfPmvqtA()
		{
			CustomInputSource.Joystick[] array = zFZKARDebphLkcsvAKTTbkgiBLQsb.TcTBrVKPjpjkfMKpUGBkhEZYHzhd();
			if (BjunadXNvNWlAyeXmUZTrBrOdgDf(array))
			{
				IDXiFMCLkYDPRzLTDaydHudLpLFAA(array);
			}
			zACyLEeQoIweEKtpvkFduMwljxMr = false;
		}

		private bool BjunadXNvNWlAyeXmUZTrBrOdgDf(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = lIsqeDleLIrbYWwQRwYPsYDgsPre.Count;
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
					if (lIsqeDleLIrbYWwQRwYPsYDgsPre[j] != null && systemId == lIsqeDleLIrbYWwQRwYPsYDgsPre[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
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
				if (lIsqeDleLIrbYWwQRwYPsYDgsPre[k] == null)
				{
					continue;
				}
				long? num2 = lIsqeDleLIrbYWwQRwYPsYDgsPre[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
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

		private void LScGrxHofyNgnFMWssXdpBmCFKdVA(List<nPuTebazjrtferQfMGWNIUZtomDp> P_0, List<nPuTebazjrtferQfMGWNIUZtomDp> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp2 = P_0[i];
				if (nPuTebazjrtferQfMGWNIUZtomDp2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						nPuTebazjrtferQfMGWNIUZtomDp nPuTebazjrtferQfMGWNIUZtomDp3 = P_1[j];
						if (nPuTebazjrtferQfMGWNIUZtomDp3 != null && nPuTebazjrtferQfMGWNIUZtomDp2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == nPuTebazjrtferQfMGWNIUZtomDp3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					aOMpEcsoXStPHIvYRUtYVDByjNvQ(P_0[i], P_2);
				}
			}
		}

		private void aOMpEcsoXStPHIvYRUtYVDByjNvQ(nPuTebazjrtferQfMGWNIUZtomDp P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.pwLfIADjrvhuifDnFIVNIizZkhSnc();
			}
			EZSZnqAXfFWQtPRqxlBOFWemihYe(P_0, P_1);
		}

		private void EZSZnqAXfFWQtPRqxlBOFWemihYe(nPuTebazjrtferQfMGWNIUZtomDp P_0, bool P_1)
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
