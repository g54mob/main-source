using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	public class DebugInformation : MonoBehaviour
	{
		private class eWVwkvxHbziiwmgULiupFelEtQb : IDisposable
		{
			public readonly bool jxPomRXaPrbPqAjcoMnYhSGCfxJTA;

			public eWVwkvxHbziiwmgULiupFelEtQb(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				jxPomRXaPrbPqAjcoMnYhSGCfxJTA = gOtRxiCAtIKnHvCoYkVuOjCvtyEJ(P_0, P_1, P_2);
				gCNidcSeAlioGAOpPeASsPbqijpXA.qMvgpocWJIPCacxHqHpXoBfDmpmjb++;
			}

			private bool gOtRxiCAtIKnHvCoYkVuOjCvtyEJ(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return ZwDFricOztBsHTOGTSOFPNrPENGT(P_1, GUILayout.Toggle(AvFHlWgoJrDkcEXHATmpUTyQKYyGA(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool AvFHlWgoJrDkcEXHATmpUTyQKYyGA(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool ZwDFricOztBsHTOGTSOFPNrPENGT(string P_0, bool P_1, IDictionary<string, bool> P_2)
			{
				if (!P_2.ContainsKey(P_0))
				{
					P_2.Add(P_0, P_1);
				}
				else
				{
					P_2[P_0] = P_1;
				}
				return P_1;
			}

			public void Dispose()
			{
				gCNidcSeAlioGAOpPeASsPbqijpXA.qMvgpocWJIPCacxHqHpXoBfDmpmjb--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class gCNidcSeAlioGAOpPeASsPbqijpXA
		{
			private static int JfwIDhHwLrTXWNQVqkBDajRGjXvBb;

			public static int qMvgpocWJIPCacxHqHpXoBfDmpmjb
			{
				get
				{
					return JfwIDhHwLrTXWNQVqkBDajRGjXvBb;
				}
				set
				{
					JfwIDhHwLrTXWNQVqkBDajRGjXvBb = Mathf.Max(0, b);
				}
			}
		}

		private static class lRXudzumeJBjOZoJOblLipMKXsTCA
		{
			public static void jgfNcNGTYKuvAFzzBXjgTVrNibTc()
			{
				GUILayout.BeginHorizontal();
			}

			public static void IaghmBJWRlTvxfQugWxSGtgnKYTd()
			{
				GUILayout.EndHorizontal();
			}

			public static void WDAQCfUAdVpWQXgNmIlCsWWfuJsu()
			{
				GUILayout.BeginVertical();
			}

			public static void YSZLZeylAhGKwXhGDtzqgsOlCLQu()
			{
				GUILayout.EndVertical();
			}

			public static void gjJneyZnOIoqVOmTcjCnKbaJrkmt(string P_0, rvvJGWnOwyTrSAXPUMQQfvAJsKji P_1)
			{
				GUILayout.Label(P_0, vYObHkTPcmcBoyToqhPDfebgRfOR());
			}

			public static void ORAKmzOHMCOtVSloxDzvVtNDBhpX(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, vYObHkTPcmcBoyToqhPDfebgRfOR());
			}

			public static void kqzbUbkTRJIVeOAsxtpmpeGjMqOg(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool keTbqoCIAVimxCFMeLgLhUEoBpRMc(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, vYObHkTPcmcBoyToqhPDfebgRfOR());
			}
		}

		private static class TujtocquDuFFAiMCkRvqUFzeEIMY
		{
			[CompilerGenerated]
			private static float UxkKcCdIWVIEVjWsudpZeVfIsJty;

			[CompilerGenerated]
			private static float YjXFyLAkcwVszRsMDIqCKTyUgNxGA;

			public static float CbJMLGuYigKhJdipDHKQxBmRoYSg
			{
				[CompilerGenerated]
				get
				{
					return UxkKcCdIWVIEVjWsudpZeVfIsJty;
				}
				[CompilerGenerated]
				set
				{
					UxkKcCdIWVIEVjWsudpZeVfIsJty = uxkKcCdIWVIEVjWsudpZeVfIsJty;
				}
			}

			public static float tnjhClqozbHwlFFGbXEYfOsdnCNk
			{
				[CompilerGenerated]
				get
				{
					return YjXFyLAkcwVszRsMDIqCKTyUgNxGA;
				}
				[CompilerGenerated]
				set
				{
					YjXFyLAkcwVszRsMDIqCKTyUgNxGA = yjXFyLAkcwVszRsMDIqCKTyUgNxGA;
				}
			}
		}

		internal enum rvvJGWnOwyTrSAXPUMQQfvAJsKji
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class zaKdzAinQrLorBGwbmOVFKVLoCNn
		{
			public static readonly zaKdzAinQrLorBGwbmOVFKVLoCNn _003C_003E9 = new zaKdzAinQrLorBGwbmOVFKVLoCNn();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int bBXRsNQqIXjGaFgRQKibGaLhPqvDB(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class qJpkUQiAZvzgVEhisEcPONpvkGsO
		{
			public InputCategory LOIEtlivPIlvUXZxactURDWuDMkXA;

			internal bool elniZiQPYssvvHNwhBknjoPoEygs(InputAction P_0)
			{
				return P_0.categoryId == LOIEtlivPIlvUXZxactURDWuDMkXA.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation sXvofGVeSMCniorpjrEDgnSQGCwt;

		private IDictionary<string, bool> IphobsUKDSFoblpbujTzzfhYJyTk = new Dictionary<string, bool>();

		private static Vector2 fYhuipkCehjSyGwOFobrqYUbooXL;

		private const string lxvbzGiIbAPyBUxWYAckZghIMQfRA = "Rewired_DebugInformation";

		private const string OwwYAjKIknamUCKmxKwyDXpMxIseb = "Rewired Debug Information";

		private const int ldVEBkOPZLdDNGibUySWykianWyL = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			sXvofGVeSMCniorpjrEDgnSQGCwt = this;
			if (IphobsUKDSFoblpbujTzzfhYJyTk.Count == 0)
			{
				IphobsUKDSFoblpbujTzzfhYJyTk.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (sXvofGVeSMCniorpjrEDgnSQGCwt == this)
			{
				sXvofGVeSMCniorpjrEDgnSQGCwt = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			gCNidcSeAlioGAOpPeASsPbqijpXA.qMvgpocWJIPCacxHqHpXoBfDmpmjb = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			fYhuipkCehjSyGwOFobrqYUbooXL = GUILayout.BeginScrollView(fYhuipkCehjSyGwOFobrqYUbooXL, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, IphobsUKDSFoblpbujTzzfhYJyTk);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool num = GUI.enabled;
			if (!ReInput.isReady || !enabled)
			{
				GUI.enabled = false;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.jgfNcNGTYKuvAFzzBXjgTVrNibTc();
			GUILayout.FlexibleSpace();
			lRXudzumeJBjOZoJOblLipMKXsTCA.IaghmBJWRlTvxfQugWxSGtgnKYTd();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			TujtocquDuFFAiMCkRvqUFzeEIMY.CbJMLGuYigKhJdipDHKQxBmRoYSg = lastRect.width - num2;
			TujtocquDuFFAiMCkRvqUFzeEIMY.tnjhClqozbHwlFFGbXEYfOsdnCNk = num2;
			eqCLBIksLBVMSaDzNdKcJKWQnuHdA(enabled, foldouts);
			GUI.enabled = num;
			TujtocquDuFFAiMCkRvqUFzeEIMY.CbJMLGuYigKhJdipDHKQxBmRoYSg = 0f;
			TujtocquDuFFAiMCkRvqUFzeEIMY.tnjhClqozbHwlFFGbXEYfOsdnCNk = 0f;
		}

		private static void eqCLBIksLBVMSaDzNdKcJKWQnuHdA(bool P_0, IDictionary<string, bool> P_1)
		{
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					return;
				}
				ABsEfsmJDUHxNHQUhEwFbgMehjSlb(P_1, "Rewired_DebugInformation");
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.gjJneyZnOIoqVOmTcjCnKbaJrkmt("Native input is disabled. Many special features are unavailable without native input.", rvvJGWnOwyTrSAXPUMQQfvAJsKji.Warning);
				}
				hpSFxbrUISTHCvlgryYHJgkoSMhp(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Controllers", text, P_1);
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					EVQleijNeBSyCSjIankzJnVglSZg(ReInput.controllers.Joysticks, P_1, text);
					SXKbEmvXFvUVYwMHBEjnEqLNknKV(ReInput.controllers.CustomControllers, P_1, text);
					QQWSDedhvqbqSTraPrncVLpJVgSt(P_1, "Rewired_DebugInformation");
					bYgoGkDNYMVQEeZDiLzMmAHvwgUf(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void ABsEfsmJDUHxNHQUhEwFbgMehjSlb(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Info", text, P_0);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Rewired Version", ReInput.programVersion);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Platform", ReInput.currentPlatform.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
				if (ReInput.currentPlatform == Platform.Windows)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Use XInput", ReInput.configuration.useXInput.ToString());
				}
				else if (ReInput.currentPlatform == Platform.WindowsUWP)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
				}
				else if (ReInput.currentPlatform == Platform.OSX)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
			}
		}

		private static void hpSFxbrUISTHCvlgryYHJgkoSMhp(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					DNuhGbRfPDHbqDSpHtxcKNiZZszd(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				DNuhGbRfPDHbqDSpHtxcKNiZZszd(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void EVQleijNeBSyCSjIankzJnVglSZg(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				id = joystick.id;
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id (unique id)", id.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", joystick.name);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Name", joystick.hardwareName);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", joystick.enabled.ToString());
				string text2 = string.Empty;
				for (int j = 0; j < ReInput.players.allPlayerCount; j++)
				{
					Player player = ReInput.players.AllPlayers[j];
					if (ReInput.controllers.IsJoystickAssignedToPlayer(joystick.id, player.id))
					{
						if (text2 != string.Empty)
						{
							text2 += ", ";
						}
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
					}
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("System Id", joystick.systemId.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Identifier", joystick.hardwareIdentifier);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", joystick.tag);
				IjsbVkkVGnJhWFQktixVNUmOgpPGA(joystick.Axes, P_1, text);
				ZtLVCzVYFHZFmoBvpYuLaAJuujxE(joystick.Buttons, ControllerType.Joystick, P_1, text);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis2D Count", joystick.axis2DCount.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hat Count", joystick.hatCount.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("D-Pad Count", joystick.directionalPadCount.ToString());
				MFjMGSKkwvcsNuVzhxgkrrujNJwL(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
							{
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", axisCalibration.enabled.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Max", axisCalibration.calibratedMax.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Min", axisCalibration.calibratedMin.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Dead Zone", axisCalibration.deadZone.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Invert", axisCalibration.invert.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									lRXudzumeJBjOZoJOblLipMKXsTCA.kqzbUbkTRJIVeOAsxtpmpeGjMqOg("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Supports Vibration", joystick.supportsVibration.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Extension", (joystick.extension != null).ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				cgsbbwNQQMgmQBWJUcxkPtwLgjiTA(joystick, P_1, text);
			}
		}

		private static void QQWSDedhvqbqSTraPrncVLpJVgSt(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Mouse", text, P_0);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", mouse.enabled.ToString());
			string text2 = string.Empty;
			for (int i = 0; i < ReInput.players.allPlayerCount; i++)
			{
				Player player = ReInput.players.AllPlayers[i];
				if (player.controllers.hasMouse)
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Screen Position", mouse.screenPosition.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Screen Position Prev", mouse.screenPositionPrev.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Screen Position Delta", mouse.screenPositionDelta.ToString());
			IjsbVkkVGnJhWFQktixVNUmOgpPGA(mouse.Axes, P_0, text);
			ZtLVCzVYFHZFmoBvpYuLaAJuujxE(mouse.Buttons, ControllerType.Mouse, P_0, text);
			MFjMGSKkwvcsNuVzhxgkrrujNJwL(mouse, P_0, text);
			cgsbbwNQQMgmQBWJUcxkPtwLgjiTA(mouse, P_0, text);
		}

		private static void bYgoGkDNYMVQEeZDiLzMmAHvwgUf(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Keyboard", text, P_0);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", keyboard.enabled.ToString());
			string text2 = string.Empty;
			for (int i = 0; i < ReInput.players.allPlayerCount; i++)
			{
				Player player = ReInput.players.AllPlayers[i];
				if (player.controllers.hasKeyboard)
				{
					if (text2 != string.Empty)
					{
						text2 += ", ";
					}
					text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
				}
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			ZtLVCzVYFHZFmoBvpYuLaAJuujxE(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			MFjMGSKkwvcsNuVzhxgkrrujNJwL(keyboard, P_0, text);
			cgsbbwNQQMgmQBWJUcxkPtwLgjiTA(keyboard, P_0, text);
		}

		private static void SXKbEmvXFvUVYwMHBEjnEqLNknKV(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + customController.name, text, P_1);
				if (!eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				id = customController.id;
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", id.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", customController.name);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Name", customController.hardwareName);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", customController.tag);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Identifier", customController.hardwareIdentifier);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", customController.enabled.ToString());
				string text2 = string.Empty;
				for (int j = 0; j < ReInput.players.allPlayerCount; j++)
				{
					Player player = ReInput.players.AllPlayers[j];
					if (ReInput.controllers.IsCustomControllerAssignedToPlayer(customController.id, player.id))
					{
						if (text2 != string.Empty)
						{
							text2 += ", ";
						}
						text2 += ((player.id == 9999999) ? "System" : player.id.ToString());
					}
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				IjsbVkkVGnJhWFQktixVNUmOgpPGA(customController.Axes, P_1, text);
				ZtLVCzVYFHZFmoBvpYuLaAJuujxE(customController.Buttons, ControllerType.Custom, P_1, text);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis2D Count", customController.axis2DCount.ToString());
				using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb6 = new eWVwkvxHbziiwmgULiupFelEtQb(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (eWVwkvxHbziiwmgULiupFelEtQb6.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
									{
										lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb7 = new eWVwkvxHbziiwmgULiupFelEtQb("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (eWVwkvxHbziiwmgULiupFelEtQb7.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb8 = new eWVwkvxHbziiwmgULiupFelEtQb(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (eWVwkvxHbziiwmgULiupFelEtQb8.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
								{
									lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb9 = new eWVwkvxHbziiwmgULiupFelEtQb("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (eWVwkvxHbziiwmgULiupFelEtQb9.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb10 = new eWVwkvxHbziiwmgULiupFelEtQb(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (eWVwkvxHbziiwmgULiupFelEtQb10.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
							{
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", axisCalibration.enabled.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Max", axisCalibration.calibratedMax.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Min", axisCalibration.calibratedMin.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Dead Zone", axisCalibration.deadZone.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Invert", axisCalibration.invert.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									lRXudzumeJBjOZoJOblLipMKXsTCA.kqzbUbkTRJIVeOAsxtpmpeGjMqOg("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Extension", (customController.extension != null).ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				cgsbbwNQQMgmQBWJUcxkPtwLgjiTA(customController, P_1, text);
			}
		}

		private static void DNuhGbRfPDHbqDSpHtxcKNiZZszd(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Player Id", P_0.id.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", P_0.name);
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Descriptive Name", P_0.descriptiveName);
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Playing", P_0.isPlaying.ToString());
			using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Controllers", text + "_controllers", P_2))
			{
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					EVQleijNeBSyCSjIankzJnVglSZg(controllers.Joysticks, P_2, text);
					SXKbEmvXFvUVYwMHBEjnEqLNknKV(controllers.CustomControllers, P_2, text);
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Mouse", controllers.hasMouse.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Keyboard", controllers.hasKeyboard.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
				}
			}
			string text2 = text + "_controllerMaps";
			using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb("Controller Maps", text2, P_2))
			{
				if (eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					yMYaKoiSKXGCjqKJGEBnvdLPgnVdb(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					yMYaKoiSKXGCjqKJGEBnvdLPgnVdb(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								yMYaKoiSKXGCjqKJGEBnvdLPgnVdb(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb6 = new eWVwkvxHbziiwmgULiupFelEtQb("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (eWVwkvxHbziiwmgULiupFelEtQb6.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							yMYaKoiSKXGCjqKJGEBnvdLPgnVdb(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb7 = new eWVwkvxHbziiwmgULiupFelEtQb("Layout Manager", text2, P_2))
			{
				if (eWVwkvxHbziiwmgULiupFelEtQb7.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					QTpFKWTFIqiaYpKdTsbDtxADpoPU(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb8 = new eWVwkvxHbziiwmgULiupFelEtQb("Map Enabler", text2, P_2))
			{
				if (eWVwkvxHbziiwmgULiupFelEtQb8.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					zkhkAmGrnDTNkpaFbJkiaQibEjAPA(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			WGVwZemgmOooaZDXMSCrzfbKbGaIA(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(zaKdzAinQrLorBGwbmOVFKVLoCNn._003C_003E9.bBXRsNQqIXjGaFgRQKibGaLhPqvDB);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb9 = new eWVwkvxHbziiwmgULiupFelEtQb("Actions (" + list.Count + ")", text2, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb9.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				qJpkUQiAZvzgVEhisEcPONpvkGsO qJpkUQiAZvzgVEhisEcPONpvkGsO2 = new qJpkUQiAZvzgVEhisEcPONpvkGsO();
				qJpkUQiAZvzgVEhisEcPONpvkGsO2.LOIEtlivPIlvUXZxactURDWuDMkXA = actionCategories[k];
				string text6 = text2 + "_actionCat" + qJpkUQiAZvzgVEhisEcPONpvkGsO2.LOIEtlivPIlvUXZxactURDWuDMkXA.id;
				int num = ListTools.Count(list, qJpkUQiAZvzgVEhisEcPONpvkGsO2.elniZiQPYssvvHNwhBknjoPoEygs);
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb10 = new eWVwkvxHbziiwmgULiupFelEtQb("id " + qJpkUQiAZvzgVEhisEcPONpvkGsO2.LOIEtlivPIlvUXZxactURDWuDMkXA.id + ": " + qJpkUQiAZvzgVEhisEcPONpvkGsO2.LOIEtlivPIlvUXZxactURDWuDMkXA.name + " (" + num + ")", text6, P_2);
				if (!eWVwkvxHbziiwmgULiupFelEtQb10.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != qJpkUQiAZvzgVEhisEcPONpvkGsO2.LOIEtlivPIlvUXZxactURDWuDMkXA.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb11 = new eWVwkvxHbziiwmgULiupFelEtQb("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (eWVwkvxHbziiwmgULiupFelEtQb11.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Value", P_0.GetButton(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void WGVwZemgmOooaZDXMSCrzfbKbGaIA(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < num; i++)
				{
					fLYQUWMUELsSmbabMeblblMTzCMx(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void fLYQUWMUELsSmbabMeblblMTzCMx(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(P_1 + ": " + P_0.name, text, P_2);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", P_0.id.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", P_0.name);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Dead Zone", P_0.buttonDeadZone.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void MFjMGSKkwvcsNuVzhxgkrrujNJwL(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
						{
							lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb6 = new eWVwkvxHbziiwmgULiupFelEtQb(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (eWVwkvxHbziiwmgULiupFelEtQb6.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void ZtLVCzVYFHZFmoBvpYuLaAJuujxE(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Member Element", button.isMemberElement.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", button.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", button.valuePrev.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Pressure", button.pressure.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Pressure Prev", button.pressurePrev.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Just Pressed", button.justPressed.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Just Released", button.justReleased.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Just Double Pressed", button.justDoublePressed.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Pressed", button.timePressed.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Unpressed", button.timeUnpressed.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Pressed", button.lastTimePressed.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void IjsbVkkVGnJhWFQktixVNUmOgpPGA(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Member Element", axis.isMemberElement.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", axis.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Raw", axis.valueRaw.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", axis.valuePrev.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Raw Prev", axis.valueRawPrev.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Delta", axis.valueDelta.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Delta Raw", axis.valueDeltaRaw.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Active", axis.timeActive.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Active Raw", axis.timeActiveRaw.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Inactive", axis.timeInactive.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Active", axis.lastTimeActive.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Inactive", axis.lastTimeInactive.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void yMYaKoiSKXGCjqKJGEBnvdLPgnVdb<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(P_2 + " (" + num + ")", text, P_3);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				string text2 = (P_1[i].enabled ? "Enabled" : "Disabled");
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_1[i].categoryId);
				InputLayout layout = ReInput.mapping.GetLayout(P_0, P_1[i].layoutId);
				string text3 = ((mapCategory != null) ? mapCategory.name : "n/a");
				string text4 = ((layout != null) ? layout.name : "n/a");
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						YjXHySNUCChQYAPcgXGJxZsEnzlS(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						laDHSoQfnmIVvCPLJtLUdDwfHGTFA(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void laDHSoQfnmIVvCPLJtLUdDwfHGTFA(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id (unique id)", P_0.id.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Source Map Id", P_0.sourceMapId.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", P_0.enabled.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Controller Id", P_0.controllerId.ToString());
			}
			string text = P_0.categoryId.ToString();
			if (P_0.categoryId >= 0)
			{
				try
				{
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(P_0.categoryId);
					if (mapCategory != null)
					{
						text = text + " (" + mapCategory.name + ")";
					}
				}
				catch
				{
				}
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Category Id", text);
			string text2 = P_0.layoutId.ToString();
			if (P_0.layoutId >= 0)
			{
				try
				{
					InputLayout layout = ReInput.mapping.GetLayout(P_0.controllerType, P_0.layoutId);
					if (layout != null)
					{
						text2 = text2 + " (" + layout.name + ")";
					}
				}
				catch
				{
				}
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Layout Id", text2);
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Is Modified", P_0.isModified.ToString());
			if (P_0.isModified)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Modified Time", P_0.modifiedTime.ToString());
			}
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					RwFqBaPoTeBPpAtRLYiczPwsUyyF(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void YjXHySNUCChQYAPcgXGJxZsEnzlS(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			laDHSoQfnmIVvCPLJtLUdDwfHGTFA(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					RwFqBaPoTeBPpAtRLYiczPwsUyyF(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void RwFqBaPoTeBPpAtRLYiczPwsUyyF(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = uqxqgqMtWCoCfYBcavIShDYXwWfK(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id (unique id)", P_1.id.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Enabled", P_1.enabled.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Type", P_1.elementType.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Identifier Id", P_1.elementIdentifierId.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Index", P_1.elementIndex.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Range", P_1.axisRange.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Type", P_1.axisType.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Key Code", P_1.keyCode.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Modifiers", P_1.hasModifiers.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Modifier Key 1", P_1.modifierKey1.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Modifier Key 2", P_1.modifierKey2.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Contribution", P_1.axisContribution.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Modified Timestamp", P_1.modifiedTime.ToString());
		}

		private static string uqxqgqMtWCoCfYBcavIShDYXwWfK(ActionElementMap P_0)
		{
			InputAction action = ReInput.mapping.GetAction(P_0.actionId);
			if (action == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			if (P_0.elementType == ControllerElementType.Button || (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Split))
			{
				if (P_0.axisContribution == Pole.Positive)
				{
					text = action.positiveDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " +") : (action.name + " +"));
					}
				}
				else
				{
					text = action.negativeDescriptiveName;
					if (string.IsNullOrEmpty(text))
					{
						text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? (action.descriptiveName + " -") : (action.name + " -"));
					}
				}
			}
			else if (P_0.elementType == ControllerElementType.Axis && P_0.axisType == AxisType.Normal)
			{
				text = ((!string.IsNullOrEmpty(action.descriptiveName)) ? action.descriptiveName : action.name);
			}
			return text;
		}

		private static void QTpFKWTFIqiaYpKdTsbDtxADpoPU(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (qFhulajNcLHAxYakOzVXBTFwgmko("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Rule Sets (" + count + ")", text, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < count; i++)
				{
					AcULmqjYLsDtgviPGQgRgMRPzMBD(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void AcULmqjYLsDtgviPGQgRgMRPzMBD(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			if (qFhulajNcLHAxYakOzVXBTFwgmko("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", rule.tag);
				YTdpJSByNbturRLmsKePJdrDhqbBA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						if (num2 == 0)
						{
							lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void zkhkAmGrnDTNkpaFbJkiaQibEjAPA(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (qFhulajNcLHAxYakOzVXBTFwgmko("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Rule Sets (" + count + ")", text, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < count; i++)
				{
					ylFwoOxeagmQCRBDVQefSDpljiMdA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void ylFwoOxeagmQCRBDVQefSDpljiMdA(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			if (qFhulajNcLHAxYakOzVXBTFwgmko("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb4 = new eWVwkvxHbziiwmgULiupFelEtQb(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!eWVwkvxHbziiwmgULiupFelEtQb4.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				if (qFhulajNcLHAxYakOzVXBTFwgmko("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Tag", rule.tag);
				YTdpJSByNbturRLmsKePJdrDhqbBA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb5 = new eWVwkvxHbziiwmgULiupFelEtQb("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (eWVwkvxHbziiwmgULiupFelEtQb5.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
					{
						if (num2 == 0)
						{
							lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb6 = new eWVwkvxHbziiwmgULiupFelEtQb("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!eWVwkvxHbziiwmgULiupFelEtQb6.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
				{
					continue;
				}
				if (num3 == 0)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void YTdpJSByNbturRLmsKePJdrDhqbBA(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Controller Set Selector", text, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void cgsbbwNQQMgmQBWJUcxkPtwLgjiTA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					JagRoXAExKtbShSVxTVCfyZDDCRH(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void JagRoXAExKtbShSVxTVCfyZDDCRH(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				return;
			}
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Type GUID", P_0.typeGuid.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb3 = new eWVwkvxHbziiwmgULiupFelEtQb("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb3.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					VfXyvFExQBJvwTZVLTPzrmaCWIOA(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void VfXyvFExQBJvwTZVLTPzrmaCWIOA(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Id", P_0.id.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Name", P_0.descriptiveName.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Type", P_0.type.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					MzwAVbfPUoykvNRiVhvYRlIiteeY(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					RLEjhdkunxHMGbpHMfREIKqbMnAQA(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateDPad.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateDPad.up, "Up", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateDPad.right, "Right", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateDPad.down, "Down", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateHat.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateHat.valuePrev.ToString());
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.up, "up", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.right, "right", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.down, "down", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.left, "left", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateStick.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateStick.valuePrev.ToString());
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateThrottle.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateThumbStick.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					HOctmqHJArFTAVqQUjrtBkZluDgf(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", controllerTemplateYoke.value.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Position", controllerTemplateStick6D.position.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Rotation", controllerTemplateStick6D.rotation.ToString());
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					MkxFiAvhDVsqBKnerYHtUdzGLNsg(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void MkxFiAvhDVsqBKnerYHtUdzGLNsg(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				RLEjhdkunxHMGbpHMfREIKqbMnAQA(P_0, P_2, P_3);
			}
		}

		private static void HOctmqHJArFTAVqQUjrtBkZluDgf(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				MzwAVbfPUoykvNRiVhvYRlIiteeY(P_0, P_2, P_3);
			}
		}

		private static void RLEjhdkunxHMGbpHMfREIKqbMnAQA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", P_0.value.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", P_0.valuePrev.ToString());
			pWHKhQDnspWaquhFUGcJaUiLSirAA(P_0.source, "target", P_1, P_2);
		}

		private static void MzwAVbfPUoykvNRiVhvYRlIiteeY(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value", P_0.value.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Value Prev", P_0.valuePrev.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Pressure", P_0.pressure.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Pressure Prev", P_0.pressurePrev.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Just Pressed", P_0.justPressed.ToString());
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Just Released", P_0.justReleased.ToString());
			ssbAhKgNibMIFvsDenhTcyqTWzeDA(P_0.source, "target", P_1, P_2);
		}

		private static void pWHKhQDnspWaquhFUGcJaUiLSirAA(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb("Axis Target", P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Split Axis", P_0.splitAxis.ToString());
				CwFZdMrWmHGBFxddhAKiDglODnfYA(P_0.fullTarget, "target", P_2, P_3);
				CwFZdMrWmHGBFxddhAKiDglODnfYA(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				CwFZdMrWmHGBFxddhAKiDglODnfYA(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void ssbAhKgNibMIFvsDenhTcyqTWzeDA(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			CwFZdMrWmHGBFxddhAKiDglODnfYA(P_0.target, "target", P_2, P_3);
		}

		private static void CwFZdMrWmHGBFxddhAKiDglODnfYA(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using eWVwkvxHbziiwmgULiupFelEtQb eWVwkvxHbziiwmgULiupFelEtQb2 = new eWVwkvxHbziiwmgULiupFelEtQb(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eWVwkvxHbziiwmgULiupFelEtQb2.jxPomRXaPrbPqAjcoMnYhSGCfxJTA)
			{
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Element Identifier Id", P_0.elementIdentifierId.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Axis Range", P_0.axisRange.ToString());
				lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool qFhulajNcLHAxYakOzVXBTFwgmko(string P_0, bool P_1)
		{
			lRXudzumeJBjOZoJOblLipMKXsTCA.ORAKmzOHMCOtVSloxDzvVtNDBhpX(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle vYObHkTPcmcBoyToqhPDfebgRfOR()
		{
			return qYyTzkOhGzhyEMSSnBGCMPVcyanx(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = sXvofGVeSMCniorpjrEDgnSQGCwt._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = qYyTzkOhGzhyEMSSnBGCMPVcyanx(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = sXvofGVeSMCniorpjrEDgnSQGCwt._fontSize;
			return gUIStyle;
		}

		private static GUIStyle qYyTzkOhGzhyEMSSnBGCMPVcyanx(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = gCNidcSeAlioGAOpPeASsPbqijpXA.qMvgpocWJIPCacxHqHpXoBfDmpmjb * 20;
			return P_0;
		}
	}
}
