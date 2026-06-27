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
		private class vEtoZqIFSpeJzhbWekhRBKWnxpQn : IDisposable
		{
			public readonly bool kIauFwqkffjJryKRYFHjaRYYWQmC;

			public vEtoZqIFSpeJzhbWekhRBKWnxpQn(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				kIauFwqkffjJryKRYFHjaRYYWQmC = lRIdBqhzUYyoWmwUkeUXDsRnBSdmA(P_0, P_1, P_2);
				rckpTwtfCzGmHTXqjikvlkTkOhEe.dwAzSijwyKkUxmrlAVJarBqHeQTP++;
			}

			private bool lRIdBqhzUYyoWmwUkeUXDsRnBSdmA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return EhgvckNaWdYlKQBebucatDsBforn(P_1, GUILayout.Toggle(ZpgxvQBeXdKjdChjuEGMdXfOtBNJ(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool ZpgxvQBeXdKjdChjuEGMdXfOtBNJ(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool EhgvckNaWdYlKQBebucatDsBforn(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				rckpTwtfCzGmHTXqjikvlkTkOhEe.dwAzSijwyKkUxmrlAVJarBqHeQTP--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class rckpTwtfCzGmHTXqjikvlkTkOhEe
		{
			private static int EcHRAvPyshlgPPWpSfrmPiECmHAI;

			public static int dwAzSijwyKkUxmrlAVJarBqHeQTP
			{
				get
				{
					return EcHRAvPyshlgPPWpSfrmPiECmHAI;
				}
				set
				{
					EcHRAvPyshlgPPWpSfrmPiECmHAI = Mathf.Max(0, b);
				}
			}
		}

		private static class gOwdwfViJNTxHOzjeVxuVGZURSqf
		{
			public static void iyAqHJlXsQfKLWUVzBjPpkUZlZCt()
			{
				GUILayout.BeginHorizontal();
			}

			public static void NhPZbXwvcdRveuTuQrefmVwzgdmQ()
			{
				GUILayout.EndHorizontal();
			}

			public static void VytGOldfWNIXNEGtdWVlnKPWbuDuB()
			{
				GUILayout.BeginVertical();
			}

			public static void NFaTmUXzdduzSCkCvHTWANQjsbuB()
			{
				GUILayout.EndVertical();
			}

			public static void viDccamdDKAIqJhKMcIwmbmTFPIB(string P_0, gDISrYWaZqbYPLKvkeLxLSZXHaMj P_1)
			{
				GUILayout.Label(P_0, kdtXVqcHLebuldGCEIliDBywOYrv());
			}

			public static void LSfwDnlEbOHKSJjSVJoMblMJAWYf(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, kdtXVqcHLebuldGCEIliDBywOYrv());
			}

			public static void pxKczjDTaZDibiJQZJFHCHZrUlvY(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool jCyduebWfLFUeMAihBKkkuBPaAgnA(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, kdtXVqcHLebuldGCEIliDBywOYrv());
			}
		}

		private static class WhMuQaBeqwavLpOuMBJLwiaqGnbHA
		{
			[CompilerGenerated]
			private static float XGHiRGQhrNcYIefISLmcCrgYiqAI;

			[CompilerGenerated]
			private static float DSquBDZBDkBEwKqedvWtoHbAkkGO;

			public static float RDkGYSFAjswoUgYBfCzvFznLcVpr
			{
				[CompilerGenerated]
				get
				{
					return XGHiRGQhrNcYIefISLmcCrgYiqAI;
				}
				[CompilerGenerated]
				set
				{
					XGHiRGQhrNcYIefISLmcCrgYiqAI = xGHiRGQhrNcYIefISLmcCrgYiqAI;
				}
			}

			public static float yNCettkRKnvdcoOiZmdtGFfhROcWA
			{
				[CompilerGenerated]
				get
				{
					return DSquBDZBDkBEwKqedvWtoHbAkkGO;
				}
				[CompilerGenerated]
				set
				{
					DSquBDZBDkBEwKqedvWtoHbAkkGO = dSquBDZBDkBEwKqedvWtoHbAkkGO;
				}
			}
		}

		internal enum gDISrYWaZqbYPLKvkeLxLSZXHaMj
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class acbbzMDFphxUmuACRWouQrKZJbwGb
		{
			public static readonly acbbzMDFphxUmuACRWouQrKZJbwGb _003C_003E9 = new acbbzMDFphxUmuACRWouQrKZJbwGb();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int gyowfJvbXNsgfbbKmKaMQSMFPAYG(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class xuCMVYZuQzSCSTiYSSFgepojrqRl
		{
			public InputCategory MubzMbMQsCVpLCfJMNtrxwNgbPVl;

			internal bool jsKTTqfbEgBOiECyLQsIBAhsVqXe(InputAction P_0)
			{
				return P_0.categoryId == MubzMbMQsCVpLCfJMNtrxwNgbPVl.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation dJCtqYeubOdFnxELPcgeMWRSfzHhA;

		private IDictionary<string, bool> DGTzmavkQlEsfmVCuNOnNwAEZwrA = new Dictionary<string, bool>();

		private static Vector2 yNOtupJhHfoRlLQwdqEUYFNjjDkGA;

		private const string yJWpRGbPCUWMKoXeaMvPAmqMlDMH = "Rewired_DebugInformation";

		private const string RFPdKnlMVtVEBNOYFBOHzZeYrvXn = "Rewired Debug Information";

		private const int sbwJfwdmhPvdSHJFmsTxEcnyGLJF = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			dJCtqYeubOdFnxELPcgeMWRSfzHhA = this;
			if (DGTzmavkQlEsfmVCuNOnNwAEZwrA.Count == 0)
			{
				DGTzmavkQlEsfmVCuNOnNwAEZwrA.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (dJCtqYeubOdFnxELPcgeMWRSfzHhA == this)
			{
				dJCtqYeubOdFnxELPcgeMWRSfzHhA = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			rckpTwtfCzGmHTXqjikvlkTkOhEe.dwAzSijwyKkUxmrlAVJarBqHeQTP = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			yNOtupJhHfoRlLQwdqEUYFNjjDkGA = GUILayout.BeginScrollView(yNOtupJhHfoRlLQwdqEUYFNjjDkGA, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, DGTzmavkQlEsfmVCuNOnNwAEZwrA);
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
			gOwdwfViJNTxHOzjeVxuVGZURSqf.iyAqHJlXsQfKLWUVzBjPpkUZlZCt();
			GUILayout.FlexibleSpace();
			gOwdwfViJNTxHOzjeVxuVGZURSqf.NhPZbXwvcdRveuTuQrefmVwzgdmQ();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			WhMuQaBeqwavLpOuMBJLwiaqGnbHA.RDkGYSFAjswoUgYBfCzvFznLcVpr = lastRect.width - num2;
			WhMuQaBeqwavLpOuMBJLwiaqGnbHA.yNCettkRKnvdcoOiZmdtGFfhROcWA = num2;
			bjjFCnJiHByNrpRCraZraRySFkqB(enabled, foldouts);
			GUI.enabled = num;
			WhMuQaBeqwavLpOuMBJLwiaqGnbHA.RDkGYSFAjswoUgYBfCzvFznLcVpr = 0f;
			WhMuQaBeqwavLpOuMBJLwiaqGnbHA.yNCettkRKnvdcoOiZmdtGFfhROcWA = 0f;
		}

		private static void bjjFCnJiHByNrpRCraZraRySFkqB(bool P_0, IDictionary<string, bool> P_1)
		{
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					return;
				}
				RFTzhwFPgUENIEZuTwYcSeHznKjR(P_1, "Rewired_DebugInformation");
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.viDccamdDKAIqJhKMcIwmbmTFPIB("Native input is disabled. Many special features are unavailable without native input.", gDISrYWaZqbYPLKvkeLxLSZXHaMj.Warning);
				}
				eJxzehOhjUxPTscWBkRyjflugrUX(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Controllers", text, P_1);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					BMxApwCOZDsoJNFgUyNAShCsiGkXA(ReInput.controllers.Joysticks, P_1, text);
					DJfyUiUTizSfBzQrdPFGysIBkMxM(ReInput.controllers.CustomControllers, P_1, text);
					JWzDKqISQgWYPgIOzyXNEriJSBbVA(P_1, "Rewired_DebugInformation");
					eFDsaecKcIWzRzmpEHbdIODjBJjaA(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void RFTzhwFPgUENIEZuTwYcSeHznKjR(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Info", text, P_0);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Rewired Version", ReInput.programVersion);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Platform", ReInput.currentPlatform.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
				if (ReInput.currentPlatform == Platform.Windows)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Use XInput", ReInput.configuration.useXInput.ToString());
				}
				else if (ReInput.currentPlatform == Platform.WindowsUWP)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
				}
				else if (ReInput.currentPlatform == Platform.OSX)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
				}
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
			}
		}

		private static void eJxzehOhjUxPTscWBkRyjflugrUX(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					IsTOjjiNOBltpQwsdCJJcMCZakEw(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				IsTOjjiNOBltpQwsdCJJcMCZakEw(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void BMxApwCOZDsoJNFgUyNAShCsiGkXA(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				id = joystick.id;
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id (unique id)", id.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", joystick.name);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Name", joystick.hardwareName);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", joystick.enabled.ToString());
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
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("System Id", joystick.systemId.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Identifier", joystick.hardwareIdentifier);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", joystick.tag);
				VyXXHqPMlzHNHCUGPUVyfNpMHWgQ(joystick.Axes, P_1, text);
				UmcKDjsOlFxbfbNDXdweBWSisLOOA(joystick.Buttons, ControllerType.Joystick, P_1, text);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis2D Count", joystick.axis2DCount.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hat Count", joystick.hatCount.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("D-Pad Count", joystick.directionalPadCount.ToString());
				JSOFGKxjNddQEBlTLLLXOThftoDQA(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
							{
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", axisCalibration.enabled.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Max", axisCalibration.calibratedMax.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Min", axisCalibration.calibratedMin.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Dead Zone", axisCalibration.deadZone.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Invert", axisCalibration.invert.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									gOwdwfViJNTxHOzjeVxuVGZURSqf.pxKczjDTaZDibiJQZJFHCHZrUlvY("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Supports Vibration", joystick.supportsVibration.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Extension", (joystick.extension != null).ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				xbHbSeyTtUIPNNrriPjZPThNQJLf(joystick, P_1, text);
			}
		}

		private static void JWzDKqISQgWYPgIOzyXNEriJSBbVA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Mouse", text, P_0);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", mouse.enabled.ToString());
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
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Screen Position", mouse.screenPosition.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Screen Position Prev", mouse.screenPositionPrev.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Screen Position Delta", mouse.screenPositionDelta.ToString());
			VyXXHqPMlzHNHCUGPUVyfNpMHWgQ(mouse.Axes, P_0, text);
			UmcKDjsOlFxbfbNDXdweBWSisLOOA(mouse.Buttons, ControllerType.Mouse, P_0, text);
			JSOFGKxjNddQEBlTLLLXOThftoDQA(mouse, P_0, text);
			xbHbSeyTtUIPNNrriPjZPThNQJLf(mouse, P_0, text);
		}

		private static void eFDsaecKcIWzRzmpEHbdIODjBJjaA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Keyboard", text, P_0);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", keyboard.enabled.ToString());
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
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			UmcKDjsOlFxbfbNDXdweBWSisLOOA(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			JSOFGKxjNddQEBlTLLLXOThftoDQA(keyboard, P_0, text);
			xbHbSeyTtUIPNNrriPjZPThNQJLf(keyboard, P_0, text);
		}

		private static void DJfyUiUTizSfBzQrdPFGysIBkMxM(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + customController.name, text, P_1);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				id = customController.id;
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", id.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", customController.name);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Name", customController.hardwareName);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", customController.tag);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Identifier", customController.hardwareIdentifier);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", customController.enabled.ToString());
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
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				VyXXHqPMlzHNHCUGPUVyfNpMHWgQ(customController.Axes, P_1, text);
				UmcKDjsOlFxbfbNDXdweBWSisLOOA(customController.Buttons, ControllerType.Custom, P_1, text);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis2D Count", customController.axis2DCount.ToString());
				using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn6 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (vEtoZqIFSpeJzhbWekhRBKWnxpQn6.kIauFwqkffjJryKRYFHjaRYYWQmC)
									{
										gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn7 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (vEtoZqIFSpeJzhbWekhRBKWnxpQn7.kIauFwqkffjJryKRYFHjaRYYWQmC)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn8 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (vEtoZqIFSpeJzhbWekhRBKWnxpQn8.kIauFwqkffjJryKRYFHjaRYYWQmC)
								{
									gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn9 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn9.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn10 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (vEtoZqIFSpeJzhbWekhRBKWnxpQn10.kIauFwqkffjJryKRYFHjaRYYWQmC)
							{
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", axisCalibration.enabled.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Max", axisCalibration.calibratedMax.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Min", axisCalibration.calibratedMin.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Dead Zone", axisCalibration.deadZone.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Invert", axisCalibration.invert.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									gOwdwfViJNTxHOzjeVxuVGZURSqf.pxKczjDTaZDibiJQZJFHCHZrUlvY("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Extension", (customController.extension != null).ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				xbHbSeyTtUIPNNrriPjZPThNQJLf(customController, P_1, text);
			}
		}

		private static void IsTOjjiNOBltpQwsdCJJcMCZakEw(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Player Id", P_0.id.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", P_0.name);
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Descriptive Name", P_0.descriptiveName);
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Is Playing", P_0.isPlaying.ToString());
			using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Controllers", text + "_controllers", P_2))
			{
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					BMxApwCOZDsoJNFgUyNAShCsiGkXA(controllers.Joysticks, P_2, text);
					DJfyUiUTizSfBzQrdPFGysIBkMxM(controllers.CustomControllers, P_2, text);
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Mouse", controllers.hasMouse.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Keyboard", controllers.hasKeyboard.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
				}
			}
			string text2 = text + "_controllerMaps";
			using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Controller Maps", text2, P_2))
			{
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					nZrIUgzFbHicaTIbiItWBuUBKYym(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					nZrIUgzFbHicaTIbiItWBuUBKYym(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								nZrIUgzFbHicaTIbiItWBuUBKYym(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn6 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn6.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							nZrIUgzFbHicaTIbiItWBuUBKYym(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn7 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Layout Manager", text2, P_2))
			{
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn7.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					NMEvJUoUhcWYXmLHnhNoPxDHpLyo(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn8 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Map Enabler", text2, P_2))
			{
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn8.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					mvMSHchbYJlRpaprROjJwCpbHQvW(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			VfeXroJbZSWezYbtgHqMDVaIOfLq(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(acbbzMDFphxUmuACRWouQrKZJbwGb._003C_003E9.gyowfJvbXNsgfbbKmKaMQSMFPAYG);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn9 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Actions (" + list.Count + ")", text2, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn9.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				xuCMVYZuQzSCSTiYSSFgepojrqRl xuCMVYZuQzSCSTiYSSFgepojrqRl2 = new xuCMVYZuQzSCSTiYSSFgepojrqRl();
				xuCMVYZuQzSCSTiYSSFgepojrqRl2.MubzMbMQsCVpLCfJMNtrxwNgbPVl = actionCategories[k];
				string text6 = text2 + "_actionCat" + xuCMVYZuQzSCSTiYSSFgepojrqRl2.MubzMbMQsCVpLCfJMNtrxwNgbPVl.id;
				int num = ListTools.Count(list, xuCMVYZuQzSCSTiYSSFgepojrqRl2.jsKTTqfbEgBOiECyLQsIBAhsVqXe);
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn10 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("id " + xuCMVYZuQzSCSTiYSSFgepojrqRl2.MubzMbMQsCVpLCfJMNtrxwNgbPVl.id + ": " + xuCMVYZuQzSCSTiYSSFgepojrqRl2.MubzMbMQsCVpLCfJMNtrxwNgbPVl.name + " (" + num + ")", text6, P_2);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn10.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != xuCMVYZuQzSCSTiYSSFgepojrqRl2.MubzMbMQsCVpLCfJMNtrxwNgbPVl.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn11 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn11.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Value", P_0.GetButton(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void VfeXroJbZSWezYbtgHqMDVaIOfLq(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < num; i++)
				{
					eTpKMnttLTChgyDhwJACDDfRlhhE(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void eTpKMnttLTChgyDhwJACDDfRlhhE(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(P_1 + ": " + P_0.name, text, P_2);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", P_0.id.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", P_0.name);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Dead Zone", P_0.buttonDeadZone.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void JSOFGKxjNddQEBlTLLLXOThftoDQA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
						{
							gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn6 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn6.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void UmcKDjsOlFxbfbNDXdweBWSisLOOA(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Is Member Element", button.isMemberElement.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", button.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", button.valuePrev.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Pressure", button.pressure.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Pressure Prev", button.pressurePrev.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Just Pressed", button.justPressed.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Just Released", button.justReleased.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Just Double Pressed", button.justDoublePressed.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Pressed", button.timePressed.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Unpressed", button.timeUnpressed.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Pressed", button.lastTimePressed.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void VyXXHqPMlzHNHCUGPUVyfNpMHWgQ(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Is Member Element", axis.isMemberElement.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", axis.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Raw", axis.valueRaw.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", axis.valuePrev.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Raw Prev", axis.valueRawPrev.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Delta", axis.valueDelta.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Delta Raw", axis.valueDeltaRaw.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Active", axis.timeActive.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Active Raw", axis.timeActiveRaw.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Inactive", axis.timeInactive.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Active", axis.lastTimeActive.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Inactive", axis.lastTimeInactive.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void nZrIUgzFbHicaTIbiItWBuUBKYym<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(P_2 + " (" + num + ")", text, P_3);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
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
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						NuuiQWibKMeMXZEmEmHiJzUOQvCC(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						mJmIWyjGretviOhRxfodjveprzud(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void mJmIWyjGretviOhRxfodjveprzud(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id (unique id)", P_0.id.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Source Map Id", P_0.sourceMapId.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", P_0.enabled.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Controller Id", P_0.controllerId.ToString());
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
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Category Id", text);
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
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					AmqBkedugcqxkcNvhlmNvXvjyxLdB(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void NuuiQWibKMeMXZEmEmHiJzUOQvCC(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			mJmIWyjGretviOhRxfodjveprzud(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					AmqBkedugcqxkcNvhlmNvXvjyxLdB(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void AmqBkedugcqxkcNvhlmNvXvjyxLdB(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = zpQJqafRWQSKeFqQCHTxPAXHYZWo(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id (unique id)", P_1.id.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Enabled", P_1.enabled.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Type", P_1.elementType.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Identifier Id", P_1.elementIdentifierId.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Index", P_1.elementIndex.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Range", P_1.axisRange.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Type", P_1.axisType.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Key Code", P_1.keyCode.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Modifiers", P_1.hasModifiers.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Modifier Key 1", P_1.modifierKey1.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Modifier Key 2", P_1.modifierKey2.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string zpQJqafRWQSKeFqQCHTxPAXHYZWo(ActionElementMap P_0)
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

		private static void NMEvJUoUhcWYXmLHnhNoPxDHpLyo(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (nCSAruCrPTKsoBKUayholiAqSNBU("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Rule Sets (" + count + ")", text, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < count; i++)
				{
					RcxGNySTveTjrkRSeBasMCDNvCiT(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void RcxGNySTveTjrkRSeBasMCDNvCiT(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			if (nCSAruCrPTKsoBKUayholiAqSNBU("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", rule.tag);
				FQQRJKiiPtUVqUEGCSDmlJuVNeIL(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						if (num2 == 0)
						{
							gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void mvMSHchbYJlRpaprROjJwCpbHQvW(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (nCSAruCrPTKsoBKUayholiAqSNBU("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Rule Sets (" + count + ")", text, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < count; i++)
				{
					bvoipYSzNosVFCCxbUhIsWsdVqxK(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void bvoipYSzNosVFCCxbUhIsWsdVqxK(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			if (nCSAruCrPTKsoBKUayholiAqSNBU("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn4 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn4.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				if (nCSAruCrPTKsoBKUayholiAqSNBU("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Tag", rule.tag);
				FQQRJKiiPtUVqUEGCSDmlJuVNeIL(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn5 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (vEtoZqIFSpeJzhbWekhRBKWnxpQn5.kIauFwqkffjJryKRYFHjaRYYWQmC)
					{
						if (num2 == 0)
						{
							gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn6 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn6.kIauFwqkffjJryKRYFHjaRYYWQmC)
				{
					continue;
				}
				if (num3 == 0)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void FQQRJKiiPtUVqUEGCSDmlJuVNeIL(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Controller Set Selector", text, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void xbHbSeyTtUIPNNrriPjZPThNQJLf(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					YkLyjDfYjERLJyzJDjjTHMAXqDoe(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void YkLyjDfYjERLJyzJDjjTHMAXqDoe(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				return;
			}
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Type GUID", P_0.typeGuid.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn3 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn3.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					GICPylpMKGvlkCxxnrvmJuxkfvvT(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void GICPylpMKGvlkCxxnrvmJuxkfvvT(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Id", P_0.id.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Name", P_0.descriptiveName.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Type", P_0.type.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					ZoRYRzYUtmNEaUxClgRtlNLwSHPs(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					GudjXhFIuheRFydqqjirgfPdSIbE(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateDPad.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateDPad.up, "Up", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateDPad.right, "Right", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateDPad.down, "Down", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateHat.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateHat.valuePrev.ToString());
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.up, "up", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.right, "right", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.down, "down", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.left, "left", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateStick.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateStick.valuePrev.ToString());
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateThrottle.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateThumbStick.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					YqNglqeothjvVINugyZUngYfTLHl(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", controllerTemplateYoke.value.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Position", controllerTemplateStick6D.position.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Rotation", controllerTemplateStick6D.rotation.ToString());
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					XVSGPOQwsNaEOJrEVkwCecuSotVJ(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void XVSGPOQwsNaEOJrEVkwCecuSotVJ(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				GudjXhFIuheRFydqqjirgfPdSIbE(P_0, P_2, P_3);
			}
		}

		private static void YqNglqeothjvVINugyZUngYfTLHl(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				ZoRYRzYUtmNEaUxClgRtlNLwSHPs(P_0, P_2, P_3);
			}
		}

		private static void GudjXhFIuheRFydqqjirgfPdSIbE(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", P_0.value.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", P_0.valuePrev.ToString());
			cHcdtAaBTnGcjfRfkGxkkqtNLbYK(P_0.source, "target", P_1, P_2);
		}

		private static void ZoRYRzYUtmNEaUxClgRtlNLwSHPs(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value", P_0.value.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Value Prev", P_0.valuePrev.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Pressure", P_0.pressure.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Pressure Prev", P_0.pressurePrev.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Just Pressed", P_0.justPressed.ToString());
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Just Released", P_0.justReleased.ToString());
			nNMdhIkqDhaCCvWnGZgcMtdTSyTg(P_0.source, "target", P_1, P_2);
		}

		private static void cHcdtAaBTnGcjfRfkGxkkqtNLbYK(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn("Axis Target", P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Split Axis", P_0.splitAxis.ToString());
				RGgCzUCeFDItKefJVBwVDCmSDKWcb(P_0.fullTarget, "target", P_2, P_3);
				RGgCzUCeFDItKefJVBwVDCmSDKWcb(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				RGgCzUCeFDItKefJVBwVDCmSDKWcb(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void nNMdhIkqDhaCCvWnGZgcMtdTSyTg(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			RGgCzUCeFDItKefJVBwVDCmSDKWcb(P_0.target, "target", P_2, P_3);
		}

		private static void RGgCzUCeFDItKefJVBwVDCmSDKWcb(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using vEtoZqIFSpeJzhbWekhRBKWnxpQn vEtoZqIFSpeJzhbWekhRBKWnxpQn2 = new vEtoZqIFSpeJzhbWekhRBKWnxpQn(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (vEtoZqIFSpeJzhbWekhRBKWnxpQn2.kIauFwqkffjJryKRYFHjaRYYWQmC)
			{
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Element Identifier Id", P_0.elementIdentifierId.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Axis Range", P_0.axisRange.ToString());
				gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool nCSAruCrPTKsoBKUayholiAqSNBU(string P_0, bool P_1)
		{
			gOwdwfViJNTxHOzjeVxuVGZURSqf.LSfwDnlEbOHKSJjSVJoMblMJAWYf(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle kdtXVqcHLebuldGCEIliDBywOYrv()
		{
			return fJDlrqxblzkAVRleLRsxqPWyXDUt(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = dJCtqYeubOdFnxELPcgeMWRSfzHhA._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = fJDlrqxblzkAVRleLRsxqPWyXDUt(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = dJCtqYeubOdFnxELPcgeMWRSfzHhA._fontSize;
			return gUIStyle;
		}

		private static GUIStyle fJDlrqxblzkAVRleLRsxqPWyXDUt(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = rckpTwtfCzGmHTXqjikvlkTkOhEe.dwAzSijwyKkUxmrlAVJarBqHeQTP * 20;
			return P_0;
		}
	}
}
