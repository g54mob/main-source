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
		private class BMuAuLTlOvmgRkIBzbkoJmwclPcYA : IDisposable
		{
			public readonly bool KXzyHknQideAJpoBHzEQDvfFqiIT;

			public BMuAuLTlOvmgRkIBzbkoJmwclPcYA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				KXzyHknQideAJpoBHzEQDvfFqiIT = XDBcHNqAvMZFghfHdFPwHfjkAcLq(P_0, P_1, P_2);
				ZrlaCFAmnxHxbUKGidlWuSKhnkcQA.VGXjORyiuSBHRGjsPNEHpKEKVkpOA++;
			}

			private bool XDBcHNqAvMZFghfHdFPwHfjkAcLq(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return cCpcOPfOEdpryOBxaDtDYCEGhODYA(P_1, GUILayout.Toggle(zeniCrcImflbNQLqjnDtWIJBgFdqA(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool zeniCrcImflbNQLqjnDtWIJBgFdqA(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool cCpcOPfOEdpryOBxaDtDYCEGhODYA(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				ZrlaCFAmnxHxbUKGidlWuSKhnkcQA.VGXjORyiuSBHRGjsPNEHpKEKVkpOA--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class ZrlaCFAmnxHxbUKGidlWuSKhnkcQA
		{
			private static int etOgyMUCepIYtOgqPpmDonqNjCeX;

			public static int VGXjORyiuSBHRGjsPNEHpKEKVkpOA
			{
				get
				{
					return etOgyMUCepIYtOgqPpmDonqNjCeX;
				}
				set
				{
					etOgyMUCepIYtOgqPpmDonqNjCeX = Mathf.Max(0, b);
				}
			}
		}

		private static class AhvnAQEwZVridXTafMUXmXrLdMQj
		{
			public static void MmDCywezoYLjrNSMiLciOrmGrtgs()
			{
				GUILayout.BeginHorizontal();
			}

			public static void xLGSqiriIrOaWdvIJjcKHaYgNbQH()
			{
				GUILayout.EndHorizontal();
			}

			public static void njmzNCyFMVufnJIeRhAGpFtyZKrM()
			{
				GUILayout.BeginVertical();
			}

			public static void zZbuyFSIdbPDDRJhsWOuthheIMPM()
			{
				GUILayout.EndVertical();
			}

			public static void RJpvFBrnjEGziGAsFqrnRTPCfrjaA(string P_0, KXTClvhZPqrKrsAsdsxWbepGffgSA P_1)
			{
				GUILayout.Label(P_0, OpuyBbbPYiEJOkNYNwZkyCAnwHRb());
			}

			public static void zgkETWyrhQGacICLIDCleSqdUwmkB(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, OpuyBbbPYiEJOkNYNwZkyCAnwHRb());
			}

			public static void ZBJGqQKDsLLxNQnFQSIiqNheHURJ(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool RTzoRZkknHftCcVzyvFHjDjYuwKw(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, OpuyBbbPYiEJOkNYNwZkyCAnwHRb());
			}
		}

		private static class qZLmPNKRqsQMleMnNLKeDqCfyJVU
		{
			[CompilerGenerated]
			private static float vcGfBlIFvDDDmFjJBXUFcfOMPAmZb;

			[CompilerGenerated]
			private static float pKpjTuARRkwfQXFxocBWdPNPmGoY;

			public static float xlfzRzOunsNAgrRIecoIuqNEhPDm
			{
				[CompilerGenerated]
				get
				{
					return vcGfBlIFvDDDmFjJBXUFcfOMPAmZb;
				}
				[CompilerGenerated]
				set
				{
					vcGfBlIFvDDDmFjJBXUFcfOMPAmZb = num;
				}
			}

			public static float CaFKAYMdObSpEPulGglCogHkyMMi
			{
				[CompilerGenerated]
				get
				{
					return pKpjTuARRkwfQXFxocBWdPNPmGoY;
				}
				[CompilerGenerated]
				set
				{
					pKpjTuARRkwfQXFxocBWdPNPmGoY = num;
				}
			}
		}

		internal enum KXTClvhZPqrKrsAsdsxWbepGffgSA
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class MowIfIIhepjhCBPzGzJZMgpKRwGC
		{
			public static readonly MowIfIIhepjhCBPzGzJZMgpKRwGC _003C_003E9 = new MowIfIIhepjhCBPzGzJZMgpKRwGC();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int KspxNwiedXLRHuumvlFzvTmGUjmR(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class NPDFtzcAsjPfcjKXLrLXaDSqHHnib
		{
			public InputCategory igcKUUXeqIQupByKZUQSEHlzoLtR;

			internal bool HNLawXAypgJaWvJLGwBlMkkbIvtlA(InputAction P_0)
			{
				return P_0.categoryId == igcKUUXeqIQupByKZUQSEHlzoLtR.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation ZNXVrHzbMbaPsgIGcfJYjxRoBvJA;

		private IDictionary<string, bool> hILTGLgsqUQzUpvKPpStgHOHBfSu = new Dictionary<string, bool>();

		private static Vector2 ATpVGkMBrFkPXUvePVdUtrwvzYrA;

		private const string YADhIxyRSQotqzSjxITszdCTVDiQ = "Rewired_DebugInformation";

		private const string dyWojSugJvTdbKBPEXJiMXOBSPnN = "Rewired Debug Information";

		private const int GpxCeHHciFpQkCsEzBbCCzXdEyjHA = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			ZNXVrHzbMbaPsgIGcfJYjxRoBvJA = this;
			if (hILTGLgsqUQzUpvKPpStgHOHBfSu.Count == 0)
			{
				hILTGLgsqUQzUpvKPpStgHOHBfSu.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (ZNXVrHzbMbaPsgIGcfJYjxRoBvJA == this)
			{
				ZNXVrHzbMbaPsgIGcfJYjxRoBvJA = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			ZrlaCFAmnxHxbUKGidlWuSKhnkcQA.VGXjORyiuSBHRGjsPNEHpKEKVkpOA = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			ATpVGkMBrFkPXUvePVdUtrwvzYrA = GUILayout.BeginScrollView(ATpVGkMBrFkPXUvePVdUtrwvzYrA, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, hILTGLgsqUQzUpvKPpStgHOHBfSu);
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
			AhvnAQEwZVridXTafMUXmXrLdMQj.MmDCywezoYLjrNSMiLciOrmGrtgs();
			GUILayout.FlexibleSpace();
			AhvnAQEwZVridXTafMUXmXrLdMQj.xLGSqiriIrOaWdvIJjcKHaYgNbQH();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			qZLmPNKRqsQMleMnNLKeDqCfyJVU.xlfzRzOunsNAgrRIecoIuqNEhPDm = lastRect.width - num2;
			qZLmPNKRqsQMleMnNLKeDqCfyJVU.CaFKAYMdObSpEPulGglCogHkyMMi = num2;
			ReowsfOdaNzJryEMyWtoTMpDfvEHA(enabled, foldouts);
			GUI.enabled = num;
			qZLmPNKRqsQMleMnNLKeDqCfyJVU.xlfzRzOunsNAgrRIecoIuqNEhPDm = 0f;
			qZLmPNKRqsQMleMnNLKeDqCfyJVU.CaFKAYMdObSpEPulGglCogHkyMMi = 0f;
		}

		private static void ReowsfOdaNzJryEMyWtoTMpDfvEHA(bool P_0, IDictionary<string, bool> P_1)
		{
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					return;
				}
				vROUZYIcgUakVIxvKJHXjpnkcTbc(P_1, "Rewired_DebugInformation");
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.RJpvFBrnjEGziGAsFqrnRTPCfrjaA("Native input is disabled. Many special features are unavailable without native input.", KXTClvhZPqrKrsAsdsxWbepGffgSA.Warning);
				}
				CfeCUQbDdAXCxLtPYIdFCKFbvHqSB(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Controllers", text, P_1);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					lryWkZPRcVJUlQfhJGehOJszsFUj(ReInput.controllers.Joysticks, P_1, text);
					pVylRSFqUtSpqciqoIdfPufKoJsc(ReInput.controllers.CustomControllers, P_1, text);
					fCqlKPNEMapohTwTqYioMFGIlHDj(P_1, "Rewired_DebugInformation");
					ITIXXLneqMbYnkpgFRcIjHjiihNz(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void vROUZYIcgUakVIxvKJHXjpnkcTbc(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Info", text, P_0);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Rewired Version", ReInput.programVersion);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Platform", ReInput.currentPlatform.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
				if (ReInput.currentPlatform == Platform.Windows)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Use XInput", ReInput.configuration.useXInput.ToString());
				}
				else if (ReInput.currentPlatform == Platform.WindowsUWP)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
				}
				else if (ReInput.currentPlatform == Platform.OSX)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
				}
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
			}
		}

		private static void CfeCUQbDdAXCxLtPYIdFCKFbvHqSB(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					wZOSSWbXUTURNXupgKOcPGkUKYgH(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				wZOSSWbXUTURNXupgKOcPGkUKYgH(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void lryWkZPRcVJUlQfhJGehOJszsFUj(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				id = joystick.id;
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id (unique id)", id.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", joystick.name);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Name", joystick.hardwareName);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", joystick.enabled.ToString());
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
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("System Id", joystick.systemId.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Identifier", joystick.hardwareIdentifier);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", joystick.tag);
				zkOohROzWheldTPPACXPKLQZyjOC(joystick.Axes, P_1, text);
				auziWYvmlHCxTsBCKnBPvTetnawK(joystick.Buttons, ControllerType.Joystick, P_1, text);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis2D Count", joystick.axis2DCount.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hat Count", joystick.hatCount.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("D-Pad Count", joystick.directionalPadCount.ToString());
				nGLxzraGVhrQochYMSMkydFmMEbj(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
							{
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", axisCalibration.enabled.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Max", axisCalibration.calibratedMax.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Min", axisCalibration.calibratedMin.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Dead Zone", axisCalibration.deadZone.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Invert", axisCalibration.invert.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									AhvnAQEwZVridXTafMUXmXrLdMQj.ZBJGqQKDsLLxNQnFQSIiqNheHURJ("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Supports Vibration", joystick.supportsVibration.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Extension", (joystick.extension != null).ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				BNEhAXttrWldtGysvSGgykBKTgnO(joystick, P_1, text);
			}
		}

		private static void fCqlKPNEMapohTwTqYioMFGIlHDj(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Mouse", text, P_0);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", mouse.enabled.ToString());
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
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Screen Position", mouse.screenPosition.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Screen Position Prev", mouse.screenPositionPrev.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Screen Position Delta", mouse.screenPositionDelta.ToString());
			zkOohROzWheldTPPACXPKLQZyjOC(mouse.Axes, P_0, text);
			auziWYvmlHCxTsBCKnBPvTetnawK(mouse.Buttons, ControllerType.Mouse, P_0, text);
			nGLxzraGVhrQochYMSMkydFmMEbj(mouse, P_0, text);
			BNEhAXttrWldtGysvSGgykBKTgnO(mouse, P_0, text);
		}

		private static void ITIXXLneqMbYnkpgFRcIjHjiihNz(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Keyboard", text, P_0);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", keyboard.enabled.ToString());
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
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			auziWYvmlHCxTsBCKnBPvTetnawK(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			nGLxzraGVhrQochYMSMkydFmMEbj(keyboard, P_0, text);
			BNEhAXttrWldtGysvSGgykBKTgnO(keyboard, P_0, text);
		}

		private static void pVylRSFqUtSpqciqoIdfPufKoJsc(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + customController.name, text, P_1);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				id = customController.id;
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", id.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", customController.name);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Name", customController.hardwareName);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", customController.tag);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Identifier", customController.hardwareIdentifier);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", customController.enabled.ToString());
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
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				zkOohROzWheldTPPACXPKLQZyjOC(customController.Axes, P_1, text);
				auziWYvmlHCxTsBCKnBPvTetnawK(customController.Buttons, ControllerType.Custom, P_1, text);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis2D Count", customController.axis2DCount.ToString());
				using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA5 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA5.KXzyHknQideAJpoBHzEQDvfFqiIT)
									{
										AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA6 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA6.KXzyHknQideAJpoBHzEQDvfFqiIT)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA7 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA7.KXzyHknQideAJpoBHzEQDvfFqiIT)
								{
									AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA8 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA8.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA9 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA9.KXzyHknQideAJpoBHzEQDvfFqiIT)
							{
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", axisCalibration.enabled.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Max", axisCalibration.calibratedMax.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Min", axisCalibration.calibratedMin.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Dead Zone", axisCalibration.deadZone.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Invert", axisCalibration.invert.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									AhvnAQEwZVridXTafMUXmXrLdMQj.ZBJGqQKDsLLxNQnFQSIiqNheHURJ("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Extension", (customController.extension != null).ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				BNEhAXttrWldtGysvSGgykBKTgnO(customController, P_1, text);
			}
		}

		private static void wZOSSWbXUTURNXupgKOcPGkUKYgH(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Player Id", P_0.id.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", P_0.name);
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Descriptive Name", P_0.descriptiveName);
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Is Playing", P_0.isPlaying.ToString());
			using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Controllers", text + "_controllers", P_2))
			{
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					lryWkZPRcVJUlQfhJGehOJszsFUj(controllers.Joysticks, P_2, text);
					pVylRSFqUtSpqciqoIdfPufKoJsc(controllers.CustomControllers, P_2, text);
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Mouse", controllers.hasMouse.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Keyboard", controllers.hasKeyboard.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
				}
			}
			string text2 = text + "_controllerMaps";
			using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Controller Maps", text2, P_2))
			{
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					FKshhTctlVXRCCywpgHhcWmKyxKJ(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					FKshhTctlVXRCCywpgHhcWmKyxKJ(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								FKshhTctlVXRCCywpgHhcWmKyxKJ(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA5 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA5.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							FKshhTctlVXRCCywpgHhcWmKyxKJ(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA6 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Layout Manager", text2, P_2))
			{
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA6.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					fRnkvzzjmAxpfdGoUINhklOFfWKA(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA7 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Map Enabler", text2, P_2))
			{
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA7.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					IjLFrNiqGRJGLChaMeZgJBXgYqHkA(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			nqdmqHGDHYgbNhPedCtnukKXTJlcA(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(MowIfIIhepjhCBPzGzJZMgpKRwGC._003C_003E9.KspxNwiedXLRHuumvlFzvTmGUjmR);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA8 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Actions (" + list.Count + ")", text2, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA8.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				NPDFtzcAsjPfcjKXLrLXaDSqHHnib nPDFtzcAsjPfcjKXLrLXaDSqHHnib = new NPDFtzcAsjPfcjKXLrLXaDSqHHnib();
				nPDFtzcAsjPfcjKXLrLXaDSqHHnib.igcKUUXeqIQupByKZUQSEHlzoLtR = actionCategories[k];
				string text6 = text2 + "_actionCat" + nPDFtzcAsjPfcjKXLrLXaDSqHHnib.igcKUUXeqIQupByKZUQSEHlzoLtR.id;
				int num = ListTools.Count(list, nPDFtzcAsjPfcjKXLrLXaDSqHHnib.HNLawXAypgJaWvJLGwBlMkkbIvtlA);
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA9 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("id " + nPDFtzcAsjPfcjKXLrLXaDSqHHnib.igcKUUXeqIQupByKZUQSEHlzoLtR.id + ": " + nPDFtzcAsjPfcjKXLrLXaDSqHHnib.igcKUUXeqIQupByKZUQSEHlzoLtR.name + " (" + num + ")", text6, P_2);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA9.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != nPDFtzcAsjPfcjKXLrLXaDSqHHnib.igcKUUXeqIQupByKZUQSEHlzoLtR.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA10 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA10.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Value", P_0.GetButton(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void nqdmqHGDHYgbNhPedCtnukKXTJlcA(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < num; i++)
				{
					MIsYvfeUlLwlRdMSnAQxybpQdBDDA(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void MIsYvfeUlLwlRdMSnAQxybpQdBDDA(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(P_1 + ": " + P_0.name, text, P_2);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", P_0.id.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", P_0.name);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Dead Zone", P_0.buttonDeadZone.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void nGLxzraGVhrQochYMSMkydFmMEbj(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
						{
							AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA5 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA5.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void auziWYvmlHCxTsBCKnBPvTetnawK(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Is Member Element", button.isMemberElement.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", button.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", button.valuePrev.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Pressure", button.pressure.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Pressure Prev", button.pressurePrev.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Just Pressed", button.justPressed.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Just Released", button.justReleased.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Just Double Pressed", button.justDoublePressed.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Pressed", button.timePressed.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Unpressed", button.timeUnpressed.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Pressed", button.lastTimePressed.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void zkOohROzWheldTPPACXPKLQZyjOC(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Is Member Element", axis.isMemberElement.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", axis.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Raw", axis.valueRaw.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", axis.valuePrev.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Raw Prev", axis.valueRawPrev.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Delta", axis.valueDelta.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Delta Raw", axis.valueDeltaRaw.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Active", axis.timeActive.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Active Raw", axis.timeActiveRaw.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Inactive", axis.timeInactive.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Active", axis.lastTimeActive.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Inactive", axis.lastTimeInactive.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void FKshhTctlVXRCCywpgHhcWmKyxKJ<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(P_2 + " (" + num + ")", text, P_3);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
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
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						rovZRjfUfKPBlSsHVCnRqvNBQycO(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						UYvAlFBkUoEOYdZeaiuCIUFpsPOQB(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void UYvAlFBkUoEOYdZeaiuCIUFpsPOQB(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id (unique id)", P_0.id.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Source Map Id", P_0.sourceMapId.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", P_0.enabled.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Controller Id", P_0.controllerId.ToString());
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
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Category Id", text);
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
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					wRlPpHtgQcClOWoIwjCyeEDlLPhk(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void rovZRjfUfKPBlSsHVCnRqvNBQycO(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			UYvAlFBkUoEOYdZeaiuCIUFpsPOQB(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					wRlPpHtgQcClOWoIwjCyeEDlLPhk(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void wRlPpHtgQcClOWoIwjCyeEDlLPhk(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = RyNNsDonYWxEYCoNXApCoPnIlIyH(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id (unique id)", P_1.id.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Enabled", P_1.enabled.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Type", P_1.elementType.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Identifier Id", P_1.elementIdentifierId.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Index", P_1.elementIndex.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Range", P_1.axisRange.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Type", P_1.axisType.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Key Code", P_1.keyCode.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Modifiers", P_1.hasModifiers.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Modifier Key 1", P_1.modifierKey1.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Modifier Key 2", P_1.modifierKey2.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string RyNNsDonYWxEYCoNXApCoPnIlIyH(ActionElementMap P_0)
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

		private static void fRnkvzzjmAxpfdGoUINhklOFfWKA(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (JORoIPTxFRNNAOBDzqeJEQcnmlxv("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Rule Sets (" + count + ")", text, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < count; i++)
				{
					fkyyPHZubaWmNnMPjdkNjCrGyBIH(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void fkyyPHZubaWmNnMPjdkNjCrGyBIH(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			if (JORoIPTxFRNNAOBDzqeJEQcnmlxv("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", rule.tag);
				tePAinvvipzfIJGBJFNBgKMEklyHb(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						if (num2 == 0)
						{
							AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void IjLFrNiqGRJGLChaMeZgJBXgYqHkA(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (JORoIPTxFRNNAOBDzqeJEQcnmlxv("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Rule Sets (" + count + ")", text, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < count; i++)
				{
					NnnLVvFQHmjDlHFecKLfSJQgVfJwA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void NnnLVvFQHmjDlHFecKLfSJQgVfJwA(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			if (JORoIPTxFRNNAOBDzqeJEQcnmlxv("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA3 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA3.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				if (JORoIPTxFRNNAOBDzqeJEQcnmlxv("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Tag", rule.tag);
				tePAinvvipzfIJGBJFNBgKMEklyHb(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA4 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA4.KXzyHknQideAJpoBHzEQDvfFqiIT)
					{
						if (num2 == 0)
						{
							AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA5 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA5.KXzyHknQideAJpoBHzEQDvfFqiIT)
				{
					continue;
				}
				if (num3 == 0)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void tePAinvvipzfIJGBJFNBgKMEklyHb(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Controller Set Selector", text, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void BNEhAXttrWldtGysvSGgykBKTgnO(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					uyKyVmkoSEzqrpPuYZyOyryQgGKn(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void uyKyVmkoSEzqrpPuYZyOyryQgGKn(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				return;
			}
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Type GUID", P_0.typeGuid.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA2 = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA2.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					wXJRjQygIUdMQHQekJoXgHPpBSLm(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void wXJRjQygIUdMQHQekJoXgHPpBSLm(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Id", P_0.id.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Name", P_0.descriptiveName.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Type", P_0.type.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					vuSwYvDrzovWqFXByUEkMpxvpfKc(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					uHggKAiACdkHhZfypfiQWHHepkNXA(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateDPad.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateDPad.up, "Up", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateDPad.right, "Right", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateDPad.down, "Down", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateHat.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateHat.valuePrev.ToString());
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.up, "up", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.right, "right", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.down, "down", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.left, "left", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateStick.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateStick.valuePrev.ToString());
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateThrottle.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateThumbStick.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					yzGWoNlUfjEBbLNhzOinOMoenUti(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", controllerTemplateYoke.value.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Position", controllerTemplateStick6D.position.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Rotation", controllerTemplateStick6D.rotation.ToString());
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					pELkDtRcqNEdmQWJQOjdHEKJsKbO(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void pELkDtRcqNEdmQWJQOjdHEKJsKbO(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				uHggKAiACdkHhZfypfiQWHHepkNXA(P_0, P_2, P_3);
			}
		}

		private static void yzGWoNlUfjEBbLNhzOinOMoenUti(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				vuSwYvDrzovWqFXByUEkMpxvpfKc(P_0, P_2, P_3);
			}
		}

		private static void uHggKAiACdkHhZfypfiQWHHepkNXA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", P_0.value.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", P_0.valuePrev.ToString());
			OBlfGbCfZjRpLuweniJPPwDWchwhA(P_0.source, "target", P_1, P_2);
		}

		private static void vuSwYvDrzovWqFXByUEkMpxvpfKc(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value", P_0.value.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Value Prev", P_0.valuePrev.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Pressure", P_0.pressure.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Pressure Prev", P_0.pressurePrev.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Just Pressed", P_0.justPressed.ToString());
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Just Released", P_0.justReleased.ToString());
			HgRhKnfJJveNaakeRASJvyLAFcxn(P_0.source, "target", P_1, P_2);
		}

		private static void OBlfGbCfZjRpLuweniJPPwDWchwhA(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA("Axis Target", P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Split Axis", P_0.splitAxis.ToString());
				zXpNUrVHPBPMebHEOntobRWXokiT(P_0.fullTarget, "target", P_2, P_3);
				zXpNUrVHPBPMebHEOntobRWXokiT(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				zXpNUrVHPBPMebHEOntobRWXokiT(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void HgRhKnfJJveNaakeRASJvyLAFcxn(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			zXpNUrVHPBPMebHEOntobRWXokiT(P_0.target, "target", P_2, P_3);
		}

		private static void zXpNUrVHPBPMebHEOntobRWXokiT(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using BMuAuLTlOvmgRkIBzbkoJmwclPcYA bMuAuLTlOvmgRkIBzbkoJmwclPcYA = new BMuAuLTlOvmgRkIBzbkoJmwclPcYA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (bMuAuLTlOvmgRkIBzbkoJmwclPcYA.KXzyHknQideAJpoBHzEQDvfFqiIT)
			{
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Element Identifier Id", P_0.elementIdentifierId.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Axis Range", P_0.axisRange.ToString());
				AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool JORoIPTxFRNNAOBDzqeJEQcnmlxv(string P_0, bool P_1)
		{
			AhvnAQEwZVridXTafMUXmXrLdMQj.zgkETWyrhQGacICLIDCleSqdUwmkB(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle OpuyBbbPYiEJOkNYNwZkyCAnwHRb()
		{
			return XuAmEJodhnZtdYAxMzrWLggzehcDA(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = ZNXVrHzbMbaPsgIGcfJYjxRoBvJA._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = XuAmEJodhnZtdYAxMzrWLggzehcDA(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = ZNXVrHzbMbaPsgIGcfJYjxRoBvJA._fontSize;
			return gUIStyle;
		}

		private static GUIStyle XuAmEJodhnZtdYAxMzrWLggzehcDA(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = ZrlaCFAmnxHxbUKGidlWuSKhnkcQA.VGXjORyiuSBHRGjsPNEHpKEKVkpOA * 20;
			return P_0;
		}
	}
}
