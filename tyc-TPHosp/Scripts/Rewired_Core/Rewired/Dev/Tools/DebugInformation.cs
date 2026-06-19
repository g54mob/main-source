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
		private class iwsCHKmqzyFdUTFOaBjCIREPYcI : IDisposable
		{
			public readonly bool zKtLvBiEAvjMhsgknMoJfZaOfd;

			public iwsCHKmqzyFdUTFOaBjCIREPYcI(string label, string key, IDictionary<string, bool> foldouts)
			{
				zKtLvBiEAvjMhsgknMoJfZaOfd = kVaikmvAagTpqkfuNeeyDiRwUaBH(label, key, foldouts);
				eOpIsNHWLqwMXhQIjiMJigxWWzU.indentLevel++;
			}

			private bool kVaikmvAagTpqkfuNeeyDiRwUaBH(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return eDtRwQIxattglWTmnRIcfpWWGCEi(P_1, GUILayout.Toggle(YnNaUiDhBCxHzqwkRUqIImtkrCQ(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool YnNaUiDhBCxHzqwkRUqIImtkrCQ(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool eDtRwQIxattglWTmnRIcfpWWGCEi(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				eOpIsNHWLqwMXhQIjiMJigxWWzU.indentLevel--;
			}
		}

		private static class eOpIsNHWLqwMXhQIjiMJigxWWzU
		{
			private static int LNVIBJzJnZCXhimDFtSPRrANefg;

			public static int indentLevel
			{
				get
				{
					return LNVIBJzJnZCXhimDFtSPRrANefg;
				}
				set
				{
					LNVIBJzJnZCXhimDFtSPRrANefg = Mathf.Max(0, value);
				}
			}
		}

		private static class ljxxyAlflGPFNgnqgXvQGpGyyec
		{
			public static void rcmiSfGSYHyYVrdHYVxkPhkeRQpl()
			{
				GUILayout.BeginHorizontal();
			}

			public static void miRhNkhchJHtydSTojhzNWPFWMa()
			{
				GUILayout.EndHorizontal();
			}

			public static void wSsuzeWMJHETdPLlmXERDRvylmk()
			{
				GUILayout.BeginVertical();
			}

			public static void KUlLoZRrIFGmkifwNFNNAEiTbRtt()
			{
				GUILayout.EndVertical();
			}

			public static void TidKGUuahXIjPcwYOdvRmLkGccX(string P_0, toVGDlannnnfZpJiqVAJSFAlNeC P_1)
			{
				GUILayout.Label(P_0, EzJRzWZHVgsbqQZIWvpLSzjnRQf());
			}

			public static void FDkPPqLGuYRwTWVcXklKzIDcfyx(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, EzJRzWZHVgsbqQZIWvpLSzjnRQf());
			}

			public static void dHCRBDVuGAjFzVFgifpTcEdNxjQ(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool ARlOfJUkPCiDdQBVBzysTutRyjq(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, EzJRzWZHVgsbqQZIWvpLSzjnRQf());
			}
		}

		private static class NgHYfHhxUvblJPWlStUdjYnCIPd
		{
			[CompilerGenerated]
			private static float EdDhObgjXsHTPqiBssOnqsqxQGhK;

			[CompilerGenerated]
			private static float OXjuMRrbuMcfMnXnTLdajMhWcPr;

			public static float labelWidth
			{
				[CompilerGenerated]
				get
				{
					return EdDhObgjXsHTPqiBssOnqsqxQGhK;
				}
				[CompilerGenerated]
				set
				{
					EdDhObgjXsHTPqiBssOnqsqxQGhK = value;
				}
			}

			public static float fieldWidth
			{
				[CompilerGenerated]
				get
				{
					return OXjuMRrbuMcfMnXnTLdajMhWcPr;
				}
				[CompilerGenerated]
				set
				{
					OXjuMRrbuMcfMnXnTLdajMhWcPr = value;
				}
			}
		}

		internal enum toVGDlannnnfZpJiqVAJSFAlNeC
		{
			DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
			RJdFdzsILIBOVJjzxJZfpCaPyDQA = 1,
			abssRJNzlkAzexpNLyDrzorRXge = 2,
			RiXrdYetQWTzGifSHzocCSJcycN = 3
		}

		private sealed class ZfnKHburHNgUrBpeMtohnVykxqJc
		{
			public InputCategory wzBllMEvQSTfTADASAQIVZlBfLb;

			public bool SfCbyvgkWlkjYQXKxtFtOSqMufK(InputAction P_0)
			{
				return P_0.categoryId == wzBllMEvQSTfTADASAQIVZlBfLb.id;
			}
		}

		private const string IiCIWuMQaGWoraoYnzbpwYfilZL = "Rewired_DebugInformation";

		private const string wpPLqzxDjQONSZjcsStrgKkHDtL = "Rewired Debug Information";

		private const int GXbwSNnlNjdKeGFJCiCSulveFSJI = 20;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _fontSize = 13;

		private static DebugInformation cBGAPVaArOoNAxoZVXVJimDiaMfq;

		private IDictionary<string, bool> XXNKbLnwhnauNvrKpNJIQOBtGaG = new Dictionary<string, bool>();

		private static Vector2 nOmxGskHuBCvTChnizqDWHAWpWrc;

		[CompilerGenerated]
		private static Comparison<InputAction> YvplfWbjwiFspspndrHcVXCSMoL;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			cBGAPVaArOoNAxoZVXVJimDiaMfq = this;
			if (XXNKbLnwhnauNvrKpNJIQOBtGaG.Count == 0)
			{
				XXNKbLnwhnauNvrKpNJIQOBtGaG.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (cBGAPVaArOoNAxoZVXVJimDiaMfq == this)
			{
				cBGAPVaArOoNAxoZVXVJimDiaMfq = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			eOpIsNHWLqwMXhQIjiMJigxWWzU.indentLevel = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			nOmxGskHuBCvTChnizqDWHAWpWrc = GUILayout.BeginScrollView(nOmxGskHuBCvTChnizqDWHAWpWrc, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, XXNKbLnwhnauNvrKpNJIQOBtGaG);
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		public static void DrawDebugInformation(bool enabled, IDictionary<string, bool> foldouts)
		{
			bool flag = GUI.enabled;
			if (!ReInput.isReady || !enabled)
			{
				GUI.enabled = false;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.rcmiSfGSYHyYVrdHYVxkPhkeRQpl();
			GUILayout.FlexibleSpace();
			ljxxyAlflGPFNgnqgXvQGpGyyec.miRhNkhchJHtydSTojhzNWPFWMa();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num = lastRect.width / 3f;
			NgHYfHhxUvblJPWlStUdjYnCIPd.labelWidth = lastRect.width - num;
			NgHYfHhxUvblJPWlStUdjYnCIPd.fieldWidth = num;
			sUoCkLJzzWFoyjkjwZjvvxPXjqf(enabled, foldouts);
			GUI.enabled = flag;
			NgHYfHhxUvblJPWlStUdjYnCIPd.labelWidth = 0f;
			NgHYfHhxUvblJPWlStUdjYnCIPd.fieldWidth = 0f;
		}

		private static void sUoCkLJzzWFoyjkjwZjvvxPXjqf(bool P_0, IDictionary<string, bool> P_1)
		{
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					return;
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Rewired Version", ReInput.programVersion);
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.TidKGUuahXIjPcwYOdvRmLkGccX("Native input is disabled. Many special features are unavailable without native input.", toVGDlannnnfZpJiqVAJSFAlNeC.abssRJNzlkAzexpNLyDrzorRXge);
				}
				YfmVVuEWkdDrkUrclvnzYglQCgi(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Controllers", text, P_1);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					gueenmsCLckQkTLraOuKVvmPCYd(ReInput.controllers.Joysticks, P_1, text);
					sXhpnxQaKFClmcgwmveBTabpHwUT(ReInput.controllers.CustomControllers, P_1, text);
					tPoKcbYjJCszoSkhBNybROFnSkx(P_1, "Rewired_DebugInformation");
					FuuATFFgKpbABqWOzlhbjHTVJGl(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void YfmVVuEWkdDrkUrclvnzYglQCgi(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					Player player = ReInput.players.GetPlayer(i);
					SijWlDfqSMpjHBUHWkpdjZGedsb(player, i, P_0, text);
				}
				SijWlDfqSMpjHBUHWkpdjZGedsb(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void gueenmsCLckQkTLraOuKVvmPCYd(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				string text = P_2 + "_joystick" + joystick.id;
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id (unique id)", joystick.id.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", joystick.name);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Name", joystick.hardwareName);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", joystick.enabled.ToString());
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
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("System Id", joystick.systemId.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Identifier", joystick.hardwareIdentifier);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", joystick.tag);
				ckivHwJgyrCvOgUWRpWCtPIfefAO(joystick.Axes, P_1, text);
				oBKHVNTnvlKSvjrWnIyBmNQRBHA(joystick.Buttons, ControllerType.Joystick, P_1, text);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis2D Count", joystick.axis2DCount.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hat Count", joystick.hatCount.ToString());
				SgEqidxtMMnDxRIQXVvTOdrQMFo(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
							{
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", axisCalibration.enabled.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Max", axisCalibration.calibratedMax.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Min", axisCalibration.calibratedMin.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Dead Zone", axisCalibration.deadZone.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Invert", axisCalibration.invert.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool flag = GUI.enabled;
									GUI.enabled = false;
									ljxxyAlflGPFNgnqgXvQGpGyyec.dHCRBDVuGAjFzVFgifpTcEdNxjQ("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = flag;
								}
								else
								{
									ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Supports Vibration", joystick.supportsVibration.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Extension", (joystick.extension != null).ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				dZlNqFIXReVFRRwYMFTgPDypmIx(joystick, P_1, text);
			}
		}

		private static void tPoKcbYjJCszoSkhBNybROFnSkx(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Mouse", text, P_0);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", mouse.enabled.ToString());
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
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Screen Position", mouse.screenPosition.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Screen Position Prev", mouse.screenPositionPrev.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Screen Position Delta", mouse.screenPositionDelta.ToString());
			ckivHwJgyrCvOgUWRpWCtPIfefAO(mouse.Axes, P_0, text);
			oBKHVNTnvlKSvjrWnIyBmNQRBHA(mouse.Buttons, ControllerType.Mouse, P_0, text);
			SgEqidxtMMnDxRIQXVvTOdrQMFo(mouse, P_0, text);
			dZlNqFIXReVFRRwYMFTgPDypmIx(mouse, P_0, text);
		}

		private static void FuuATFFgKpbABqWOzlhbjHTVJGl(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Keyboard", text, P_0);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", keyboard.enabled.ToString());
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
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			oBKHVNTnvlKSvjrWnIyBmNQRBHA(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			SgEqidxtMMnDxRIQXVvTOdrQMFo(keyboard, P_0, text);
			dZlNqFIXReVFRRwYMFTgPDypmIx(keyboard, P_0, text);
		}

		private static void sXhpnxQaKFClmcgwmveBTabpHwUT(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				string text = P_2 + "_customController" + customController.id;
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + customController.name, text, P_1);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", customController.id.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", customController.name);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Name", customController.hardwareName);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", customController.tag);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Identifier", customController.hardwareIdentifier);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", customController.enabled.ToString());
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
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				ckivHwJgyrCvOgUWRpWCtPIfefAO(customController.Axes, P_1, text);
				oBKHVNTnvlKSvjrWnIyBmNQRBHA(customController.Buttons, ControllerType.Custom, P_1, text);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis2D Count", customController.axis2DCount.ToString());
				using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI6 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(k + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.name, P_1);
									if (iwsCHKmqzyFdUTFOaBjCIREPYcI6.zKtLvBiEAvjMhsgknMoJfZaOfd)
									{
										ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", controllerElementIdentifier.id.ToString());
										ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", controllerElementIdentifier.name);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI7 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (iwsCHKmqzyFdUTFOaBjCIREPYcI7.zKtLvBiEAvjMhsgknMoJfZaOfd)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI8 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(l + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.name, P_1);
								if (iwsCHKmqzyFdUTFOaBjCIREPYcI8.zKtLvBiEAvjMhsgknMoJfZaOfd)
								{
									ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", controllerElementIdentifier2.id.ToString());
									ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", controllerElementIdentifier2.name);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI9 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI9.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI10 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (iwsCHKmqzyFdUTFOaBjCIREPYcI10.zKtLvBiEAvjMhsgknMoJfZaOfd)
							{
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", axisCalibration.enabled.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Max", axisCalibration.calibratedMax.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Min", axisCalibration.calibratedMin.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Dead Zone", axisCalibration.deadZone.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Invert", axisCalibration.invert.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool flag = GUI.enabled;
									GUI.enabled = false;
									ljxxyAlflGPFNgnqgXvQGpGyyec.dHCRBDVuGAjFzVFgifpTcEdNxjQ("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = flag;
								}
								else
								{
									ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Extension", (customController.extension != null).ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				dZlNqFIXReVFRRwYMFTgPDypmIx(customController, P_1, text);
			}
		}

		private static void SijWlDfqSMpjHBUHWkpdjZGedsb(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Player Id", P_0.id.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", P_0.name);
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Descriptive Name", P_0.descriptiveName);
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Is Playing", P_0.isPlaying.ToString());
			using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Controllers", text + "_controllers", P_2))
			{
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					gueenmsCLckQkTLraOuKVvmPCYd(controllers.Joysticks, P_2, text);
					sXhpnxQaKFClmcgwmveBTabpHwUT(controllers.CustomControllers, P_2, text);
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Mouse", controllers.hasMouse.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Keyboard", controllers.hasKeyboard.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				}
			}
			string text2 = text + "_controllerMaps";
			using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Controller Maps", text2, P_2))
			{
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					SPkBVMRWzxXrzNPHXWqJQNYufJd(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					SPkBVMRWzxXrzNPHXWqJQNYufJd(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								text3 = text3 + "_joystickId" + joystick.id;
								SPkBVMRWzxXrzNPHXWqJQNYufJd(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI6 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI6.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							text3 = text3 + "_customControllerId" + customController.id;
							SPkBVMRWzxXrzNPHXWqJQNYufJd(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI7 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Layout Manager", text2, P_2))
			{
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI7.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					bKBEdxslrlbPRyoPQXfcndajXAF(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI8 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Map Enabler", text2, P_2))
			{
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI8.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					aFOCrIIPwnPSNFPRIOYsNTwQlGR(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			ZMpVghVgzLaOZqWvGRRGkHeLiPM(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort((InputAction inputAction2, InputAction inputAction3) => inputAction2.name.CompareTo(inputAction3.name));
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI9 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Actions (" + list.Count + ")", text2, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI9.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int num = 0; num < actionCategories.Count; num++)
			{
				ZfnKHburHNgUrBpeMtohnVykxqJc zfnKHburHNgUrBpeMtohnVykxqJc = new ZfnKHburHNgUrBpeMtohnVykxqJc();
				zfnKHburHNgUrBpeMtohnVykxqJc.wzBllMEvQSTfTADASAQIVZlBfLb = actionCategories[num];
				string text4 = text2 + "_actionCat" + zfnKHburHNgUrBpeMtohnVykxqJc.wzBllMEvQSTfTADASAQIVZlBfLb.id;
				int num2 = ListTools.Count(list, zfnKHburHNgUrBpeMtohnVykxqJc.SfCbyvgkWlkjYQXKxtFtOSqMufK);
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI10 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("id " + zfnKHburHNgUrBpeMtohnVykxqJc.wzBllMEvQSTfTADASAQIVZlBfLb.id + ": " + zfnKHburHNgUrBpeMtohnVykxqJc.wzBllMEvQSTfTADASAQIVZlBfLb.name + " (" + num2 + ")", text4, P_2);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI10.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				for (int num3 = 0; num3 < list.Count; num3++)
				{
					InputAction inputAction = list[num3];
					if (inputAction.categoryId != zfnKHburHNgUrBpeMtohnVykxqJc.wzBllMEvQSTfTADASAQIVZlBfLb.id)
					{
						continue;
					}
					string key = text4 + "_actionId" + inputAction.id;
					using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI11 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), key, P_2);
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI11.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Value", P_0.GetButton(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void ZMpVghVgzLaOZqWvGRRGkHeLiPM(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < num; i++)
				{
					InputBehavior inputBehavior = P_0[i];
					NOsgpbHkHgAEAiKmHvSTggEgKlFE(inputBehavior, i, P_1, P_2);
				}
			}
		}

		private static void NOsgpbHkHgAEAiKmHvSTggEgKlFE(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string key = P_3 + "_inputBehavior" + P_0.id;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(P_1 + ": " + P_0.name, key, P_2);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", P_0.id.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", P_0.name);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Dead Zone", P_0.buttonDeadZone.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void SgEqidxtMMnDxRIQXVvTOdrQMFo(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.name, P_1);
						if (iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
						{
							ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", controllerElementIdentifier.id.ToString());
							ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", controllerElementIdentifier.name);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI6 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(j + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.name, P_1);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI6.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", controllerElementIdentifier2.id.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", controllerElementIdentifier2.name);
				}
			}
		}

		private static void oBKHVNTnvlKSvjrWnIyBmNQRBHA(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(text + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.name) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Is Member Element", button.isMemberElement.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", button.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", button.valuePrev.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Pressure", button.pressure.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Pressure Prev", button.pressurePrev.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Just Pressed", button.justPressed.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Just Released", button.justReleased.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Just Double Pressed", button.justDoublePressed.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Pressed", button.timePressed.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Unpressed", button.timeUnpressed.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Pressed", button.lastTimePressed.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void ckivHwJgyrCvOgUWRpWCtPIfefAO(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + axis.elementIdentifier.name + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Is Member Element", axis.isMemberElement.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", axis.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Raw", axis.valueRaw.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", axis.valuePrev.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Raw Prev", axis.valueRawPrev.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Delta", axis.valueDelta.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Delta Raw", axis.valueDeltaRaw.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Active", axis.timeActive.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Active Raw", axis.timeActiveRaw.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Inactive", axis.timeInactive.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Active", axis.lastTimeActive.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Inactive", axis.lastTimeInactive.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void SPkBVMRWzxXrzNPHXWqJQNYufJd<T>(ControllerType P_0, IList<T> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where T : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(P_2 + " (" + num + ")", text, P_3);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				T val = P_1[i];
				string text2 = (val.enabled ? "Enabled" : "Disabled");
				ReInput.MappingHelper mapping = ReInput.mapping;
				T val2 = P_1[i];
				InputMapCategory mapCategory = mapping.GetMapCategory(val2.categoryId);
				ReInput.MappingHelper mapping2 = ReInput.mapping;
				T val3 = P_1[i];
				InputLayout layout = mapping2.GetLayout(P_0, val3.layoutId);
				string text3 = ((mapCategory != null) ? mapCategory.name : "n/a");
				string text4 = ((layout != null) ? layout.name : "n/a");
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						LWMvKYLIDgckSKZbOYcGCISzcKq(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						LWMvKYLIDgckSKZbOYcGCISzcKq(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void LWMvKYLIDgckSKZbOYcGCISzcKq(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id (unique id)", P_0.id.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Source Map Id", P_0.sourceMapId.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", P_0.enabled.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Controller Id", P_0.controllerId.ToString());
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
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Category Id", text);
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
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					SUkVCiRihhvnJUXYLzbgunuozyi(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void LWMvKYLIDgckSKZbOYcGCISzcKq(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			LWMvKYLIDgckSKZbOYcGCISzcKq((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					SUkVCiRihhvnJUXYLzbgunuozyi(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void SUkVCiRihhvnJUXYLzbgunuozyi(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = CEMbePIlWzCbUEtbEoUhAzteMFj(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id (unique id)", P_1.id.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Enabled", P_1.enabled.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Type", P_1.elementType.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Identifier Id", P_1.elementIdentifierId.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Index", P_1.elementIndex.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Range", P_1.axisRange.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Type", P_1.axisType.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Key Code", P_1.keyCode.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Modifiers", P_1.hasModifiers.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Modifier Key 1", P_1.modifierKey1.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Modifier Key 2", P_1.modifierKey2.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string CEMbePIlWzCbUEtbEoUhAzteMFj(ActionElementMap P_0)
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

		private static void bKBEdxslrlbPRyoPQXfcndajXAF(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (ARlOfJUkPCiDdQBVBzysTutRyjq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Rule Sets (" + count + ")", text, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < count; i++)
				{
					xqPeMMjUAqKPAWpUCFwQMHWcnIA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void xqPeMMjUAqKPAWpUCFwQMHWcnIA(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			if (ARlOfJUkPCiDdQBVBzysTutRyjq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Rules (" + P_0.Count + ")", text, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", rule.tag);
				pGsgAzVcOxWFlTrmPHHaUlkwaFsf(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						if (num2 == 0)
						{
							ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void aFOCrIIPwnPSNFPRIOYsNTwQlGR(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (ARlOfJUkPCiDdQBVBzysTutRyjq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Rule Sets (" + count + ")", text, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < count; i++)
				{
					ULcRrpCjpQfNAfNAjKvMgPyBUrVB(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void ULcRrpCjpQfNAfNAjKvMgPyBUrVB(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			if (ARlOfJUkPCiDdQBVBzysTutRyjq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Rules (" + P_0.Count + ")", text, P_2);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI4 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI4.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				if (ARlOfJUkPCiDdQBVBzysTutRyjq("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Tag", rule.tag);
				pGsgAzVcOxWFlTrmPHHaUlkwaFsf(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI5 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (iwsCHKmqzyFdUTFOaBjCIREPYcI5.zKtLvBiEAvjMhsgknMoJfZaOfd)
					{
						if (num2 == 0)
						{
							ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI6 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!iwsCHKmqzyFdUTFOaBjCIREPYcI6.zKtLvBiEAvjMhsgknMoJfZaOfd)
				{
					continue;
				}
				if (num3 == 0)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : string.Concat("All ", rule.controllerSetSelector.controllerType, " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx(string.Concat(rule.controllerSetSelector.controllerType, " Layout ", k.ToString()), text4);
				}
			}
		}

		private static void pGsgAzVcOxWFlTrmPHHaUlkwaFsf(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string key = P_2 + "_controllerSetSelector";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Controller Set Selector", key, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void dZlNqFIXReVFRRwYMFTgPDypmIx(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					bmfsfghLuGnfzvbTbLlaiXPqjma(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void bmfsfghLuGnfzvbTbLlaiXPqjma(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				return;
			}
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Type GUID", P_0.typeGuid.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI3 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI3.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					kyfVZgbJeYZZKmScJkoYzbAJBLH(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void kyfVZgbJeYZZKmScJkoYzbAJBLH(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Id", P_0.id.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Name", P_0.descriptiveName.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Type", P_0.type.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					IControllerTemplateButton controllerTemplateButton = P_0 as IControllerTemplateButton;
					zwIkyKGblqDyIyWIotCrrGjjnnr(controllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					IControllerTemplateAxis controllerTemplateAxis = P_0 as IControllerTemplateAxis;
					iqrVeDlzpYvSPkKjaAMaGgUFNkeA(controllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateDPad.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateDPad.up, "Up", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateDPad.right, "Right", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateDPad.down, "Down", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateHat.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateHat.valuePrev.ToString());
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.up, "up", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.right, "right", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.down, "down", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.left, "left", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateStick.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateStick.valuePrev.ToString());
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateThrottle.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateThumbStick.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					PkqChSthIkYPHobyAEyNDRjwXEP(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", controllerTemplateYoke.value.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Position", controllerTemplateStick6D.position.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Rotation", controllerTemplateStick6D.rotation.ToString());
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					fgUwVanKBCPIxalqYXdUmdnGeMjC(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void fgUwVanKBCPIxalqYXdUmdnGeMjC(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				iqrVeDlzpYvSPkKjaAMaGgUFNkeA(P_0, P_2, P_3);
			}
		}

		private static void PkqChSthIkYPHobyAEyNDRjwXEP(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				zwIkyKGblqDyIyWIotCrrGjjnnr(P_0, P_2, P_3);
			}
		}

		private static void iqrVeDlzpYvSPkKjaAMaGgUFNkeA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", P_0.value.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", P_0.valuePrev.ToString());
			sKHfkMeFeHbHdHMTMdEqQFpzGcVh(P_0.source, "target", P_1, P_2);
		}

		private static void zwIkyKGblqDyIyWIotCrrGjjnnr(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value", P_0.value.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Value Prev", P_0.valuePrev.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Pressure", P_0.pressure.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Pressure Prev", P_0.pressurePrev.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Just Pressed", P_0.justPressed.ToString());
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Just Released", P_0.justReleased.ToString());
			UJrXXxMAEQXtOibgdFhNZcDAHOT(P_0.source, "target", P_1, P_2);
		}

		private static void sKHfkMeFeHbHdHMTMdEqQFpzGcVh(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI("Axis Target", P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Split Axis", P_0.splitAxis.ToString());
				EvTJrGWpOGkTVSDzHTtxnHZoUEx(P_0.fullTarget, "target", P_2, P_3);
				EvTJrGWpOGkTVSDzHTtxnHZoUEx(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				EvTJrGWpOGkTVSDzHTtxnHZoUEx(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void UJrXXxMAEQXtOibgdFhNZcDAHOT(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			EvTJrGWpOGkTVSDzHTtxnHZoUEx(P_0.target, "target", P_2, P_3);
		}

		private static void EvTJrGWpOGkTVSDzHTtxnHZoUEx(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using iwsCHKmqzyFdUTFOaBjCIREPYcI iwsCHKmqzyFdUTFOaBjCIREPYcI2 = new iwsCHKmqzyFdUTFOaBjCIREPYcI(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (iwsCHKmqzyFdUTFOaBjCIREPYcI2.zKtLvBiEAvjMhsgknMoJfZaOfd)
			{
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Element Identifier Id", P_0.elementIdentifierId.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Axis Range", P_0.axisRange.ToString());
				ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool ARlOfJUkPCiDdQBVBzysTutRyjq(string P_0, bool P_1)
		{
			ljxxyAlflGPFNgnqgXvQGpGyyec.FDkPPqLGuYRwTWVcXklKzIDcfyx(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle EzJRzWZHVgsbqQZIWvpLSzjnRQf()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.margin.top = 1;
			gUIStyle.margin.bottom = 1;
			gUIStyle.fontSize = cBGAPVaArOoNAxoZVXVJimDiaMfq._fontSize;
			return NUngSRbOfWgGMABkFtkKfsabGujZ(gUIStyle);
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.toggle);
			gUIStyle.margin.top = 0;
			gUIStyle.margin.bottom = 0;
			gUIStyle = NUngSRbOfWgGMABkFtkKfsabGujZ(gUIStyle);
			gUIStyle.fontSize = cBGAPVaArOoNAxoZVXVJimDiaMfq._fontSize;
			return gUIStyle;
		}

		private static GUIStyle NUngSRbOfWgGMABkFtkKfsabGujZ(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = eOpIsNHWLqwMXhQIjiMJigxWWzU.indentLevel * 20;
			return P_0;
		}

		[CompilerGenerated]
		private static int ymVspImYGLNTIiWpJufjXDeZGQl(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}
}
