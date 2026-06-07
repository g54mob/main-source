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
		private class cAKCHfRaPjvbMXNILLCXyYBYlLhs : IDisposable
		{
			public readonly bool zTLuqMzahzAPIbYWfIczvBIvUwVgA;

			public cAKCHfRaPjvbMXNILLCXyYBYlLhs(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				zTLuqMzahzAPIbYWfIczvBIvUwVgA = iQxRefiALWAmbAGMHfWVXsSGamAi(P_0, P_1, P_2);
				mBJidvKkqpRoiBfLQoLhjCjgLejJB.kHrgpxwmnOGCGCdlrwyiYFzeDsqW++;
			}

			private bool iQxRefiALWAmbAGMHfWVXsSGamAi(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return VBRfrtcILlnkjJwaERHoEGnmnECdb(P_1, GUILayout.Toggle(CtParNfGxxMmSiedbHpKNWoAbBiqe(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool CtParNfGxxMmSiedbHpKNWoAbBiqe(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool VBRfrtcILlnkjJwaERHoEGnmnECdb(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				mBJidvKkqpRoiBfLQoLhjCjgLejJB.kHrgpxwmnOGCGCdlrwyiYFzeDsqW--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class mBJidvKkqpRoiBfLQoLhjCjgLejJB
		{
			private static int HgsGZmUbrhYHsfSzdUTaaBBfFEtR;

			public static int kHrgpxwmnOGCGCdlrwyiYFzeDsqW
			{
				get
				{
					return HgsGZmUbrhYHsfSzdUTaaBBfFEtR;
				}
				set
				{
					HgsGZmUbrhYHsfSzdUTaaBBfFEtR = Mathf.Max(0, b);
				}
			}
		}

		private static class nTDodqGlABqxkoJjZpiiuGUxWxDp
		{
			public static void dmpJoCqFrEKcqsfFWrAHEEXyidfq()
			{
				GUILayout.BeginHorizontal();
			}

			public static void WxkhtYfijtHSBMkmjRlfBMhMRFNm()
			{
				GUILayout.EndHorizontal();
			}

			public static void WgMKlgkVYDxioqvLtqdrlSNQUDeh()
			{
				GUILayout.BeginVertical();
			}

			public static void AyHxLzWvsfEUCkrcEfwFbrSQnGKiA()
			{
				GUILayout.EndVertical();
			}

			public static void sHRyehxryOcqplcpvvVYZWckCnss(string P_0, lbpcWHCZUsUXutspDfPnkKOkBnjO P_1)
			{
				GUILayout.Label(P_0, tYRTjbpGEoXGyJUHrMqfsvvXqGmB());
			}

			public static void CrUCsgIskMXlvpzGopwMAQLyygfIA(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, tYRTjbpGEoXGyJUHrMqfsvvXqGmB());
			}

			public static void qmprFyUEjVQsSzjUswQPobQYPqQf(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool wGVNqfqtgVqXJwGiCBfwXUEksgLV(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, tYRTjbpGEoXGyJUHrMqfsvvXqGmB());
			}
		}

		private static class HWnpqxWedypDgRRgtfaDPetPeLMaA
		{
			[CompilerGenerated]
			private static float CcmdaBFTsNxCxUCSnOgujJdlBEfjA;

			[CompilerGenerated]
			private static float AJLDeOAeQolmLoDqYWfjNsgnwMfV;

			public static float YzBANHCVkeGQnOoROWmpcDwarYUf
			{
				[CompilerGenerated]
				get
				{
					return CcmdaBFTsNxCxUCSnOgujJdlBEfjA;
				}
				[CompilerGenerated]
				set
				{
					CcmdaBFTsNxCxUCSnOgujJdlBEfjA = ccmdaBFTsNxCxUCSnOgujJdlBEfjA;
				}
			}

			public static float hPxdWsYJzxDDWmqasOibcoWCgVRD
			{
				[CompilerGenerated]
				get
				{
					return AJLDeOAeQolmLoDqYWfjNsgnwMfV;
				}
				[CompilerGenerated]
				set
				{
					AJLDeOAeQolmLoDqYWfjNsgnwMfV = aJLDeOAeQolmLoDqYWfjNsgnwMfV;
				}
			}
		}

		internal enum lbpcWHCZUsUXutspDfPnkKOkBnjO
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class bGzFEEkldeLuaSveTssAVGeTFHB
		{
			public static readonly bGzFEEkldeLuaSveTssAVGeTFHB _003C_003E9 = new bGzFEEkldeLuaSveTssAVGeTFHB();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int pFXSkMyRmVuYINyjRlREtnJuradJ(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class eodaGDHWrfMwfPpAxplgpHbUqZuYA
		{
			public InputCategory XiAHjyBebUBfkCgPhomjESEKRFkic;

			internal bool kqlFHrkyeyhlFCoSiMfOCmZXArcEb(InputAction P_0)
			{
				return P_0.categoryId == XiAHjyBebUBfkCgPhomjESEKRFkic.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation ssjqDRfoSGnsQVZKoNjyjEKbZQed;

		private IDictionary<string, bool> OupzjlcJdAPsJICBtluUutxrHbLN = new Dictionary<string, bool>();

		private static Vector2 nudaiyEYirdMGlegGdIEvKUSxBDl;

		private const string tYvghNoCFGGafgGyTCfXMprtoRlDA = "Rewired_DebugInformation";

		private const string OXqlGoaWUfNsexMCaFtLOkffbPieA = "Rewired Debug Information";

		private const int zdREHbfuhXMZtRbBFJDxEbkDxekEA = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			ssjqDRfoSGnsQVZKoNjyjEKbZQed = this;
			if (OupzjlcJdAPsJICBtluUutxrHbLN.Count == 0)
			{
				OupzjlcJdAPsJICBtluUutxrHbLN.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (ssjqDRfoSGnsQVZKoNjyjEKbZQed == this)
			{
				ssjqDRfoSGnsQVZKoNjyjEKbZQed = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			mBJidvKkqpRoiBfLQoLhjCjgLejJB.kHrgpxwmnOGCGCdlrwyiYFzeDsqW = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			nudaiyEYirdMGlegGdIEvKUSxBDl = GUILayout.BeginScrollView(nudaiyEYirdMGlegGdIEvKUSxBDl, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, OupzjlcJdAPsJICBtluUutxrHbLN);
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
			nTDodqGlABqxkoJjZpiiuGUxWxDp.dmpJoCqFrEKcqsfFWrAHEEXyidfq();
			GUILayout.FlexibleSpace();
			nTDodqGlABqxkoJjZpiiuGUxWxDp.WxkhtYfijtHSBMkmjRlfBMhMRFNm();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			HWnpqxWedypDgRRgtfaDPetPeLMaA.YzBANHCVkeGQnOoROWmpcDwarYUf = lastRect.width - num2;
			HWnpqxWedypDgRRgtfaDPetPeLMaA.hPxdWsYJzxDDWmqasOibcoWCgVRD = num2;
			iTSWJJYtpXGSqTsDWsJNBaYtYvTP(enabled, foldouts);
			GUI.enabled = num;
			HWnpqxWedypDgRRgtfaDPetPeLMaA.YzBANHCVkeGQnOoROWmpcDwarYUf = 0f;
			HWnpqxWedypDgRRgtfaDPetPeLMaA.hPxdWsYJzxDDWmqasOibcoWCgVRD = 0f;
		}

		private static void iTSWJJYtpXGSqTsDWsJNBaYtYvTP(bool P_0, IDictionary<string, bool> P_1)
		{
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					return;
				}
				IbgvfPQjAGvxNfgqslywpQAwiYxA(P_1, "Rewired_DebugInformation");
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.sHRyehxryOcqplcpvvVYZWckCnss("Native input is disabled. Many special features are unavailable without native input.", lbpcWHCZUsUXutspDfPnkKOkBnjO.Warning);
				}
				zuIdjugBeGcVcRYAyVXyGRiRcNrcA(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Controllers", text, P_1);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					OSCpmpFbCJOLszMgjuLIYwLRoqZE(ReInput.controllers.Joysticks, P_1, text);
					UGnSfFFfFpFwnJhJKaIMNDKwcIQB(ReInput.controllers.CustomControllers, P_1, text);
					KLWQbnJiPoiyugIuEijLIFxuhyCI(P_1, "Rewired_DebugInformation");
					beaytjpfpEfHyPkbtjSrhjCKsnGv(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void IbgvfPQjAGvxNfgqslywpQAwiYxA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Info", text, P_0);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Rewired Version", ReInput.programVersion);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Platform", ReInput.currentPlatform.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
				if (ReInput.currentPlatform == Platform.Windows)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Use XInput", ReInput.configuration.useXInput.ToString());
				}
				else if (ReInput.currentPlatform == Platform.WindowsUWP)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
				}
				else if (ReInput.currentPlatform == Platform.OSX)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
				}
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
			}
		}

		private static void zuIdjugBeGcVcRYAyVXyGRiRcNrcA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					HnwhTybwHRZzIsmuOyaZDEDiUFtj(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				HnwhTybwHRZzIsmuOyaZDEDiUFtj(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void OSCpmpFbCJOLszMgjuLIYwLRoqZE(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				id = joystick.id;
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id (unique id)", id.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", joystick.name);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Name", joystick.hardwareName);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", joystick.enabled.ToString());
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
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("System Id", joystick.systemId.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Identifier", joystick.hardwareIdentifier);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", joystick.tag);
				KeTPfYHwxTzmqGKixyaGdkhwsDw(joystick.Axes, P_1, text);
				BRZVTcjgsPZeKTHXyNYubHPLvLbG(joystick.Buttons, ControllerType.Joystick, P_1, text);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis2D Count", joystick.axis2DCount.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hat Count", joystick.hatCount.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("D-Pad Count", joystick.directionalPadCount.ToString());
				YkdCwNuwUlwHfJZBcmnNmpuUWUeI(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
							{
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", axisCalibration.enabled.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Dead Zone", axisCalibration.deadZone.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Upper Dead Zone", axisCalibration.upperDeadZone.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Invert", axisCalibration.invert.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									nTDodqGlABqxkoJjZpiiuGUxWxDp.qmprFyUEjVQsSzjUswQPobQYPqQf("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity Curve", "--");
								}
							}
						}
						axisCount = calibrationMap.axis2DCount;
						for (int l = 0; l < axisCount; l++)
						{
							Axis2DCalibration axis2DCalibration = calibrationMap.Axes2D[l];
							using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs6 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(l + ": Axis2D Calibration", text + "_Axis2DCalibration" + l, P_1);
							if (cAKCHfRaPjvbMXNILLCXyYBYlLhs6.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
							{
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Dead Zone Type", axis2DCalibration.deadZoneType.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity Type", axis2DCalibration.sensitivityType.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Clamp Type", axis2DCalibration.clampType.ToString());
							}
						}
					}
				}
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Supports Vibration", joystick.supportsVibration.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Extension", (joystick.extension != null).ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				yayIdhriqCwssnQtFFwHylmqwsmk(joystick, P_1, text);
			}
		}

		private static void KLWQbnJiPoiyugIuEijLIFxuhyCI(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Mouse", text, P_0);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", mouse.enabled.ToString());
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
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Screen Position", mouse.screenPosition.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Screen Position Prev", mouse.screenPositionPrev.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Screen Position Delta", mouse.screenPositionDelta.ToString());
			KeTPfYHwxTzmqGKixyaGdkhwsDw(mouse.Axes, P_0, text);
			BRZVTcjgsPZeKTHXyNYubHPLvLbG(mouse.Buttons, ControllerType.Mouse, P_0, text);
			YkdCwNuwUlwHfJZBcmnNmpuUWUeI(mouse, P_0, text);
			yayIdhriqCwssnQtFFwHylmqwsmk(mouse, P_0, text);
		}

		private static void beaytjpfpEfHyPkbtjSrhjCKsnGv(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Keyboard", text, P_0);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", keyboard.enabled.ToString());
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
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			BRZVTcjgsPZeKTHXyNYubHPLvLbG(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			YkdCwNuwUlwHfJZBcmnNmpuUWUeI(keyboard, P_0, text);
			yayIdhriqCwssnQtFFwHylmqwsmk(keyboard, P_0, text);
		}

		private static void UGnSfFFfFpFwnJhJKaIMNDKwcIQB(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + customController.name, text, P_1);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				id = customController.id;
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", id.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", customController.name);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Name", customController.hardwareName);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", customController.tag);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Identifier", customController.hardwareIdentifier);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", customController.enabled.ToString());
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
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				KeTPfYHwxTzmqGKixyaGdkhwsDw(customController.Axes, P_1, text);
				BRZVTcjgsPZeKTHXyNYubHPLvLbG(customController.Buttons, ControllerType.Custom, P_1, text);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis2D Count", customController.axis2DCount.ToString());
				using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs6 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (cAKCHfRaPjvbMXNILLCXyYBYlLhs6.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
									{
										nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs7 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (cAKCHfRaPjvbMXNILLCXyYBYlLhs7.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs8 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (cAKCHfRaPjvbMXNILLCXyYBYlLhs8.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
								{
									nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs9 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs9.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs10 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (cAKCHfRaPjvbMXNILLCXyYBYlLhs10.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
							{
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", axisCalibration.enabled.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Dead Zone", axisCalibration.deadZone.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Upper Dead Zone", axisCalibration.upperDeadZone.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Invert", axisCalibration.invert.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									nTDodqGlABqxkoJjZpiiuGUxWxDp.qmprFyUEjVQsSzjUswQPobQYPqQf("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Extension", (customController.extension != null).ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				yayIdhriqCwssnQtFFwHylmqwsmk(customController, P_1, text);
			}
		}

		private static void HnwhTybwHRZzIsmuOyaZDEDiUFtj(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Player Id", P_0.id.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", P_0.name);
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Descriptive Name", P_0.descriptiveName);
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Playing", P_0.isPlaying.ToString());
			using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Controllers", text + "_controllers", P_2))
			{
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					OSCpmpFbCJOLszMgjuLIYwLRoqZE(controllers.Joysticks, P_2, text);
					UGnSfFFfFpFwnJhJKaIMNDKwcIQB(controllers.CustomControllers, P_2, text);
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Mouse", controllers.hasMouse.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Keyboard", controllers.hasKeyboard.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
				}
			}
			string text2 = text + "_controllerMaps";
			using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Controller Maps", text2, P_2))
			{
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					qiUkQvycqPgYHdqlVGIKFkLwkqLqA(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					qiUkQvycqPgYHdqlVGIKFkLwkqLqA(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								qiUkQvycqPgYHdqlVGIKFkLwkqLqA(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs6 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs6.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							qiUkQvycqPgYHdqlVGIKFkLwkqLqA(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs7 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Layout Manager", text2, P_2))
			{
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs7.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					YvnBHStwdcgIaKLOCososMLmhRBE(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs8 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Map Enabler", text2, P_2))
			{
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs8.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					dkjCGlAmBZFNKFYpiktNjVoKCaEyB(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			KePSHlMTWIcsIuNxPGNEsPzlpHkX(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(bGzFEEkldeLuaSveTssAVGeTFHB._003C_003E9.pFXSkMyRmVuYINyjRlREtnJuradJ);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs9 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Actions (" + list.Count + ")", text2, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs9.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				eodaGDHWrfMwfPpAxplgpHbUqZuYA eodaGDHWrfMwfPpAxplgpHbUqZuYA2 = new eodaGDHWrfMwfPpAxplgpHbUqZuYA();
				eodaGDHWrfMwfPpAxplgpHbUqZuYA2.XiAHjyBebUBfkCgPhomjESEKRFkic = actionCategories[k];
				string text6 = text2 + "_actionCat" + eodaGDHWrfMwfPpAxplgpHbUqZuYA2.XiAHjyBebUBfkCgPhomjESEKRFkic.id;
				int num = ListTools.Count(list, eodaGDHWrfMwfPpAxplgpHbUqZuYA2.kqlFHrkyeyhlFCoSiMfOCmZXArcEb);
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs10 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("id " + eodaGDHWrfMwfPpAxplgpHbUqZuYA2.XiAHjyBebUBfkCgPhomjESEKRFkic.id + ": " + eodaGDHWrfMwfPpAxplgpHbUqZuYA2.XiAHjyBebUBfkCgPhomjESEKRFkic.name + " (" + num + ")", text6, P_2);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs10.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != eodaGDHWrfMwfPpAxplgpHbUqZuYA2.XiAHjyBebUBfkCgPhomjESEKRFkic.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs11 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs11.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Value", P_0.GetButton(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void KePSHlMTWIcsIuNxPGNEsPzlpHkX(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < num; i++)
				{
					riCxKDwKmZcsCMgDDeoCkRIsnFKy(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void riCxKDwKmZcsCMgDDeoCkRIsnFKy(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(P_1 + ": " + P_0.name, text, P_2);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", P_0.id.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", P_0.name);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Dead Zone", P_0.buttonDeadZone.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void YkdCwNuwUlwHfJZBcmnNmpuUWUeI(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
						{
							nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs6 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs6.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void BRZVTcjgsPZeKTHXyNYubHPLvLbG(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Member Element", button.isMemberElement.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", button.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", button.valuePrev.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Pressure", button.pressure.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Pressure Prev", button.pressurePrev.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Just Pressed", button.justPressed.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Just Released", button.justReleased.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Just Double Pressed", button.justDoublePressed.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Pressed", button.timePressed.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Unpressed", button.timeUnpressed.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Pressed", button.lastTimePressed.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void KeTPfYHwxTzmqGKixyaGdkhwsDw(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Member Element", axis.isMemberElement.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", axis.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Raw", axis.valueRaw.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", axis.valuePrev.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Raw Prev", axis.valueRawPrev.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Delta", axis.valueDelta.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Delta Raw", axis.valueDeltaRaw.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Active", axis.timeActive.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Active Raw", axis.timeActiveRaw.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Inactive", axis.timeInactive.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Active", axis.lastTimeActive.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Inactive", axis.lastTimeInactive.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void qiUkQvycqPgYHdqlVGIKFkLwkqLqA<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(P_2 + " (" + num + ")", text, P_3);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
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
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						GqVfeHbsqOCMqDbYvHNijuqnvuheA(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						nzJfIfDeJoQHLLedOdYfvMqCwFTeA(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void nzJfIfDeJoQHLLedOdYfvMqCwFTeA(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id (unique id)", P_0.id.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Source Map Id", P_0.sourceMapId.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", P_0.enabled.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Controller Id", P_0.controllerId.ToString());
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
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Category Id", text);
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
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Layout Id", text2);
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Is Modified", P_0.isModified.ToString());
			if (P_0.isModified)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Modified Time", P_0.modifiedTime.ToString());
			}
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					DsZohhlBbmHANfzpYTjBgtmDXysG(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void GqVfeHbsqOCMqDbYvHNijuqnvuheA(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			nzJfIfDeJoQHLLedOdYfvMqCwFTeA(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					DsZohhlBbmHANfzpYTjBgtmDXysG(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void DsZohhlBbmHANfzpYTjBgtmDXysG(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = knvoXngRxGoaDdiEbykfcBCmavzt(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id (unique id)", P_1.id.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Enabled", P_1.enabled.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Type", P_1.elementType.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Identifier Id", P_1.elementIdentifierId.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Index", P_1.elementIndex.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Range", P_1.axisRange.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Type", P_1.axisType.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Key Code", P_1.keyCode.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Modifiers", P_1.hasModifiers.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Modifier Key 1", P_1.modifierKey1.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Modifier Key 2", P_1.modifierKey2.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Contribution", P_1.axisContribution.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Modified Timestamp", P_1.modifiedTime.ToString());
		}

		private static string knvoXngRxGoaDdiEbykfcBCmavzt(ActionElementMap P_0)
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

		private static void YvnBHStwdcgIaKLOCososMLmhRBE(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (yblqvvDXUDfEBhLITYCgCeTZPlmn("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Rule Sets (" + count + ")", text, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < count; i++)
				{
					QASRBhTdmiiXMQTEBFJghmUusyHV(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void QASRBhTdmiiXMQTEBFJghmUusyHV(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			if (yblqvvDXUDfEBhLITYCgCeTZPlmn("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", rule.tag);
				GRrSVPzXlnVmTkeMdwrmQgnkjpvcA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						if (num2 == 0)
						{
							nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void dkjCGlAmBZFNKFYpiktNjVoKCaEyB(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (yblqvvDXUDfEBhLITYCgCeTZPlmn("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Rule Sets (" + count + ")", text, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < count; i++)
				{
					aNBquVTRAsBQqkohKDrSHFpChhMBA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void aNBquVTRAsBQqkohKDrSHFpChhMBA(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			if (yblqvvDXUDfEBhLITYCgCeTZPlmn("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs4 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs4.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				if (yblqvvDXUDfEBhLITYCgCeTZPlmn("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Tag", rule.tag);
				GRrSVPzXlnVmTkeMdwrmQgnkjpvcA(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs5 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (cAKCHfRaPjvbMXNILLCXyYBYlLhs5.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
					{
						if (num2 == 0)
						{
							nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs6 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs6.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
				{
					continue;
				}
				if (num3 == 0)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void GRrSVPzXlnVmTkeMdwrmQgnkjpvcA(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Controller Set Selector", text, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void yayIdhriqCwssnQtFFwHylmqwsmk(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					LygSuCsUHCJhoKIvonIhcPPyOOBv(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void LygSuCsUHCJhoKIvonIhcPPyOOBv(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				return;
			}
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Type GUID", P_0.typeGuid.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs3 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs3.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					RUdivoyHXIeTVmjjQtYquteXhZEp(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void RUdivoyHXIeTVmjjQtYquteXhZEp(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Id", P_0.id.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Name", P_0.descriptiveName.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Type", P_0.type.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					YeoJoRPqqgsVNeSYNovfEYLWxyfb(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					RlMexmdIHzCOiqYbXcWpeBgjIyUlc(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateDPad.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateDPad.up, "Up", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateDPad.right, "Right", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateDPad.down, "Down", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateHat.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateHat.valuePrev.ToString());
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.up, "up", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.right, "right", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.down, "down", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.left, "left", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateStick.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateStick.valuePrev.ToString());
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateThrottle.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateThumbStick.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					XloxqlnVsdNkscRoVgpSAbZYjqgG(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", controllerTemplateYoke.value.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Position", controllerTemplateStick6D.position.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Rotation", controllerTemplateStick6D.rotation.ToString());
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					MGjNnDJTfNgDdnVCaZoGHHzzWbuf(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void MGjNnDJTfNgDdnVCaZoGHHzzWbuf(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				RlMexmdIHzCOiqYbXcWpeBgjIyUlc(P_0, P_2, P_3);
			}
		}

		private static void XloxqlnVsdNkscRoVgpSAbZYjqgG(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				YeoJoRPqqgsVNeSYNovfEYLWxyfb(P_0, P_2, P_3);
			}
		}

		private static void RlMexmdIHzCOiqYbXcWpeBgjIyUlc(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", P_0.value.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", P_0.valuePrev.ToString());
			jCRdvHftKfKaWTVvPAhoADuFwbpIB(P_0.source, "target", P_1, P_2);
		}

		private static void YeoJoRPqqgsVNeSYNovfEYLWxyfb(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value", P_0.value.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Value Prev", P_0.valuePrev.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Pressure", P_0.pressure.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Pressure Prev", P_0.pressurePrev.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Just Pressed", P_0.justPressed.ToString());
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Just Released", P_0.justReleased.ToString());
			etzHvZztIhPSlFrfbNigzmcqiUul(P_0.source, "target", P_1, P_2);
		}

		private static void jCRdvHftKfKaWTVvPAhoADuFwbpIB(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs("Axis Target", P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Split Axis", P_0.splitAxis.ToString());
				YyZLhRBxOFEFdKhFyZDPbQdrjsbz(P_0.fullTarget, "target", P_2, P_3);
				YyZLhRBxOFEFdKhFyZDPbQdrjsbz(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				YyZLhRBxOFEFdKhFyZDPbQdrjsbz(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void etzHvZztIhPSlFrfbNigzmcqiUul(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			YyZLhRBxOFEFdKhFyZDPbQdrjsbz(P_0.target, "target", P_2, P_3);
		}

		private static void YyZLhRBxOFEFdKhFyZDPbQdrjsbz(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using cAKCHfRaPjvbMXNILLCXyYBYlLhs cAKCHfRaPjvbMXNILLCXyYBYlLhs2 = new cAKCHfRaPjvbMXNILLCXyYBYlLhs(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (cAKCHfRaPjvbMXNILLCXyYBYlLhs2.zTLuqMzahzAPIbYWfIczvBIvUwVgA)
			{
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Element Identifier Id", P_0.elementIdentifierId.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Axis Range", P_0.axisRange.ToString());
				nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool yblqvvDXUDfEBhLITYCgCeTZPlmn(string P_0, bool P_1)
		{
			nTDodqGlABqxkoJjZpiiuGUxWxDp.CrUCsgIskMXlvpzGopwMAQLyygfIA(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle tYRTjbpGEoXGyJUHrMqfsvvXqGmB()
		{
			return kVsqhjesgfRierYugBPvXuBDmznV(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = ssjqDRfoSGnsQVZKoNjyjEKbZQed._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = kVsqhjesgfRierYugBPvXuBDmznV(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = ssjqDRfoSGnsQVZKoNjyjEKbZQed._fontSize;
			return gUIStyle;
		}

		private static GUIStyle kVsqhjesgfRierYugBPvXuBDmznV(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = mBJidvKkqpRoiBfLQoLhjCjgLejJB.kHrgpxwmnOGCGCdlrwyiYFzeDsqW * 20;
			return P_0;
		}
	}
}
