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
		private class SCEvzlLmJnoJbOHbnHQkEDedEIu : IDisposable
		{
			public readonly bool BqoyXZwedXMnGuhYlBMnZggUXtF;

			public SCEvzlLmJnoJbOHbnHQkEDedEIu(string label, string key, IDictionary<string, bool> foldouts)
			{
				BqoyXZwedXMnGuhYlBMnZggUXtF = EcAzHKElTxDGclRUMFqtiuoKZmx(label, key, foldouts);
				OfVaVtEkmndbDLwceCGOBiWjyvsa.indentLevel++;
			}

			private bool EcAzHKElTxDGclRUMFqtiuoKZmx(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return MAVgRwflHsbJtGHSKyGfYhrCqGww(P_1, GUILayout.Toggle(iezFyggnQNUgztZWOWjTCUZIflw(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool iezFyggnQNUgztZWOWjTCUZIflw(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool MAVgRwflHsbJtGHSKyGfYhrCqGww(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				OfVaVtEkmndbDLwceCGOBiWjyvsa.indentLevel--;
			}
		}

		private static class OfVaVtEkmndbDLwceCGOBiWjyvsa
		{
			private static int hDtaobCKMELkfRrrYRQCqZhvytM;

			public static int indentLevel
			{
				get
				{
					return hDtaobCKMELkfRrrYRQCqZhvytM;
				}
				set
				{
					hDtaobCKMELkfRrrYRQCqZhvytM = Mathf.Max(0, value);
				}
			}
		}

		private static class TsLhZsAiWPBwXnwCjOfREWbMfoS
		{
			public static void HLAqvFfojWulVoVnTNzfnvXCsEJ()
			{
				GUILayout.BeginHorizontal();
			}

			public static void QyfbQQAqAEAucByjnQteFJsjpYGA()
			{
				GUILayout.EndHorizontal();
			}

			public static void KMSfYWlfkQukrEJHjbSAgTAQjqWe()
			{
				GUILayout.BeginVertical();
			}

			public static void cHNaHremdEORcxfUIpVUPYLrFHDO()
			{
				GUILayout.EndVertical();
			}

			public static void zRZrkpFSWSENMxilJjCdsVSsgfG(string P_0, DbpvuTNRIuCuXwdUvfMCKIrFlos P_1)
			{
				GUILayout.Label(P_0, mwjGOeHeqbBEwSZqVejMkGUVYRFf());
			}

			public static void nAYsQrwUlJmPuZSvIgnuzdtKbdA(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, mwjGOeHeqbBEwSZqVejMkGUVYRFf());
			}

			public static void ZxegUvcPXXOihIdWfpyIkBMtfhc(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool eNZfejtaXJFRtBolKUnbZLEdBiQ(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, mwjGOeHeqbBEwSZqVejMkGUVYRFf());
			}
		}

		private static class jatKMnSOpqcSHYDVDPbonSIqJOB
		{
			[CompilerGenerated]
			private static float mwrOzXEpodLoHrqtjrUgutNZgUH;

			[CompilerGenerated]
			private static float ykLVhzCgRTAfIarNMzEpvQQgDsZ;

			public static float labelWidth
			{
				[CompilerGenerated]
				get
				{
					return mwrOzXEpodLoHrqtjrUgutNZgUH;
				}
				[CompilerGenerated]
				set
				{
					mwrOzXEpodLoHrqtjrUgutNZgUH = value;
				}
			}

			public static float fieldWidth
			{
				[CompilerGenerated]
				get
				{
					return ykLVhzCgRTAfIarNMzEpvQQgDsZ;
				}
				[CompilerGenerated]
				set
				{
					ykLVhzCgRTAfIarNMzEpvQQgDsZ = value;
				}
			}
		}

		internal enum DbpvuTNRIuCuXwdUvfMCKIrFlos
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			nPFuMXJQsXojTakVwxXkGxBrRPc = 1,
			UrYBPjqBYphfkuVDGSyilhRdbBC = 2,
			lUheQgkFbLQKQEdieYahYEkjWepw = 3
		}

		private sealed class rsDwoTVWiWPfriOGPquqTINMMch
		{
			public InputCategory ATbKyYpzfLuDyXcrHYBENEsfLZA;

			public bool mBqIVTXFVqBTUZdfmvleKynuFam(InputAction P_0)
			{
				return P_0.categoryId == ATbKyYpzfLuDyXcrHYBENEsfLZA.id;
			}
		}

		private const string eskdIDlDVXrpPziCepsouWfEpvA = "Rewired_DebugInformation";

		private const string ILjaZZYIULasIfCOpdbmbkJifrpZ = "Rewired Debug Information";

		private const int ubLHevEepqOTsXlXFAEDgGDISAx = 20;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _fontSize = 13;

		private static DebugInformation SKcIgrdHSZRiIzfxUyDOqjyMnCX;

		private IDictionary<string, bool> hUbYWpCcOalNPwkkkmFBCxqRtqc = new Dictionary<string, bool>();

		private static Vector2 XbWLpEPgTWdCRekZtgaQoVtgbIPx;

		[CompilerGenerated]
		private static Comparison<InputAction> aiXaKuCWRzBHdQrFqgBzyLzkAydQ;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			SKcIgrdHSZRiIzfxUyDOqjyMnCX = this;
			if (hUbYWpCcOalNPwkkkmFBCxqRtqc.Count == 0)
			{
				hUbYWpCcOalNPwkkkmFBCxqRtqc.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (SKcIgrdHSZRiIzfxUyDOqjyMnCX == this)
			{
				SKcIgrdHSZRiIzfxUyDOqjyMnCX = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			OfVaVtEkmndbDLwceCGOBiWjyvsa.indentLevel = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			XbWLpEPgTWdCRekZtgaQoVtgbIPx = GUILayout.BeginScrollView(XbWLpEPgTWdCRekZtgaQoVtgbIPx, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, hUbYWpCcOalNPwkkkmFBCxqRtqc);
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
			TsLhZsAiWPBwXnwCjOfREWbMfoS.HLAqvFfojWulVoVnTNzfnvXCsEJ();
			GUILayout.FlexibleSpace();
			TsLhZsAiWPBwXnwCjOfREWbMfoS.QyfbQQAqAEAucByjnQteFJsjpYGA();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num = lastRect.width / 3f;
			jatKMnSOpqcSHYDVDPbonSIqJOB.labelWidth = lastRect.width - num;
			jatKMnSOpqcSHYDVDPbonSIqJOB.fieldWidth = num;
			IoUFrxsiYFPMqgoPdptutEwdkKD(enabled, foldouts);
			GUI.enabled = flag;
			jatKMnSOpqcSHYDVDPbonSIqJOB.labelWidth = 0f;
			jatKMnSOpqcSHYDVDPbonSIqJOB.fieldWidth = 0f;
		}

		private static void IoUFrxsiYFPMqgoPdptutEwdkKD(bool P_0, IDictionary<string, bool> P_1)
		{
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					return;
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Rewired Version", ReInput.programVersion);
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.zRZrkpFSWSENMxilJjCdsVSsgfG("Native input is disabled. Many special features are unavailable without native input.", DbpvuTNRIuCuXwdUvfMCKIrFlos.UrYBPjqBYphfkuVDGSyilhRdbBC);
				}
				wIGuyKtRTiomuHWcadlaCYTkaEO(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Controllers", text, P_1);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					YGSDlSRzttXDuKPdlUfRNYQfIJV(ReInput.controllers.Joysticks, P_1, text);
					WDNGGBIxvMAYgYlOfKaAMgELQkoC(ReInput.controllers.CustomControllers, P_1, text);
					PFADrPlaaJsJaVkZKUZoPqgHGOX(P_1, "Rewired_DebugInformation");
					jIlXjaMdiURVrnmgvtwhlsrAPZ(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void wIGuyKtRTiomuHWcadlaCYTkaEO(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					Player player = ReInput.players.GetPlayer(i);
					gcDvbjIjHVKBLQnTFokfxbSSxNX(player, i, P_0, text);
				}
				gcDvbjIjHVKBLQnTFokfxbSSxNX(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void YGSDlSRzttXDuKPdlUfRNYQfIJV(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				string text = P_2 + "_joystick" + joystick.id;
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id (unique id)", joystick.id.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", joystick.name);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Name", joystick.hardwareName);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", joystick.enabled.ToString());
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
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("System Id", joystick.systemId.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Identifier", joystick.hardwareIdentifier);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", joystick.tag);
				GeGGoSwaPseCQKNeACSHbHjfZnie(joystick.Axes, P_1, text);
				GIsWuhiwYgLlryGyepoGeOthmVm(joystick.Buttons, ControllerType.Joystick, P_1, text);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis2D Count", joystick.axis2DCount.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hat Count", joystick.hatCount.ToString());
				mSgLrVENGNEXdAjcQBPKYWUqKBA(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
							{
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", axisCalibration.enabled.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Dead Zone", axisCalibration.deadZone.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Invert", axisCalibration.invert.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool flag = GUI.enabled;
									GUI.enabled = false;
									TsLhZsAiWPBwXnwCjOfREWbMfoS.ZxegUvcPXXOihIdWfpyIkBMtfhc("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = flag;
								}
								else
								{
									TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Supports Vibration", joystick.supportsVibration.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Extension", (joystick.extension != null).ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				VmJuFdnhwdsyHYiwHRbbZgBLwPL(joystick, P_1, text);
			}
		}

		private static void PFADrPlaaJsJaVkZKUZoPqgHGOX(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Mouse", text, P_0);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", mouse.enabled.ToString());
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
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Screen Position", mouse.screenPosition.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Screen Position Prev", mouse.screenPositionPrev.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Screen Position Delta", mouse.screenPositionDelta.ToString());
			GeGGoSwaPseCQKNeACSHbHjfZnie(mouse.Axes, P_0, text);
			GIsWuhiwYgLlryGyepoGeOthmVm(mouse.Buttons, ControllerType.Mouse, P_0, text);
			mSgLrVENGNEXdAjcQBPKYWUqKBA(mouse, P_0, text);
			VmJuFdnhwdsyHYiwHRbbZgBLwPL(mouse, P_0, text);
		}

		private static void jIlXjaMdiURVrnmgvtwhlsrAPZ(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Keyboard", text, P_0);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", keyboard.enabled.ToString());
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
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			GIsWuhiwYgLlryGyepoGeOthmVm(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			mSgLrVENGNEXdAjcQBPKYWUqKBA(keyboard, P_0, text);
			VmJuFdnhwdsyHYiwHRbbZgBLwPL(keyboard, P_0, text);
		}

		private static void WDNGGBIxvMAYgYlOfKaAMgELQkoC(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				string text = P_2 + "_customController" + customController.id;
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + customController.name, text, P_1);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", customController.id.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", customController.name);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Name", customController.hardwareName);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", customController.tag);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Identifier", customController.hardwareIdentifier);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", customController.enabled.ToString());
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
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				GeGGoSwaPseCQKNeACSHbHjfZnie(customController.Axes, P_1, text);
				GIsWuhiwYgLlryGyepoGeOthmVm(customController.Buttons, ControllerType.Custom, P_1, text);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis2D Count", customController.axis2DCount.ToString());
				using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu5 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(k + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.name, P_1);
									if (sCEvzlLmJnoJbOHbnHQkEDedEIu5.BqoyXZwedXMnGuhYlBMnZggUXtF)
									{
										TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", controllerElementIdentifier.id.ToString());
										TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", controllerElementIdentifier.name);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu6 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (sCEvzlLmJnoJbOHbnHQkEDedEIu6.BqoyXZwedXMnGuhYlBMnZggUXtF)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu7 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(l + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.name, P_1);
								if (sCEvzlLmJnoJbOHbnHQkEDedEIu7.BqoyXZwedXMnGuhYlBMnZggUXtF)
								{
									TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", controllerElementIdentifier2.id.ToString());
									TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", controllerElementIdentifier2.name);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu8 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu8.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu9 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (sCEvzlLmJnoJbOHbnHQkEDedEIu9.BqoyXZwedXMnGuhYlBMnZggUXtF)
							{
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", axisCalibration.enabled.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Dead Zone", axisCalibration.deadZone.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Invert", axisCalibration.invert.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool flag = GUI.enabled;
									GUI.enabled = false;
									TsLhZsAiWPBwXnwCjOfREWbMfoS.ZxegUvcPXXOihIdWfpyIkBMtfhc("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = flag;
								}
								else
								{
									TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Extension", (customController.extension != null).ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				VmJuFdnhwdsyHYiwHRbbZgBLwPL(customController, P_1, text);
			}
		}

		private static void gcDvbjIjHVKBLQnTFokfxbSSxNX(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Player Id", P_0.id.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", P_0.name);
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Descriptive Name", P_0.descriptiveName);
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Is Playing", P_0.isPlaying.ToString());
			using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Controllers", text + "_controllers", P_2))
			{
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					YGSDlSRzttXDuKPdlUfRNYQfIJV(controllers.Joysticks, P_2, text);
					WDNGGBIxvMAYgYlOfKaAMgELQkoC(controllers.CustomControllers, P_2, text);
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Mouse", controllers.hasMouse.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Keyboard", controllers.hasKeyboard.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				}
			}
			string text2 = text + "_controllerMaps";
			using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Controller Maps", text2, P_2))
			{
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					wJKMagwPEesYnMgvEQwYCmtGUZP(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					wJKMagwPEesYnMgvEQwYCmtGUZP(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								text3 = text3 + "_joystickId" + joystick.id;
								wJKMagwPEesYnMgvEQwYCmtGUZP(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu5 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu5.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							text3 = text3 + "_customControllerId" + customController.id;
							wJKMagwPEesYnMgvEQwYCmtGUZP(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu6 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Layout Manager", text2, P_2))
			{
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu6.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					BXlndLRSIyWADrEUUCXadUORWXm(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu7 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Map Enabler", text2, P_2))
			{
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu7.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					EVcxQspwkiwKXYkfJMOlPDqgjHh(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			nGTiODaEJYrRidTaFTHZqTNzDGg(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort((InputAction inputAction2, InputAction inputAction3) => inputAction2.name.CompareTo(inputAction3.name));
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu8 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Actions (" + list.Count + ")", text2, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu8.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int num = 0; num < actionCategories.Count; num++)
			{
				rsDwoTVWiWPfriOGPquqTINMMch rsDwoTVWiWPfriOGPquqTINMMch2 = new rsDwoTVWiWPfriOGPquqTINMMch();
				rsDwoTVWiWPfriOGPquqTINMMch2.ATbKyYpzfLuDyXcrHYBENEsfLZA = actionCategories[num];
				string text4 = text2 + "_actionCat" + rsDwoTVWiWPfriOGPquqTINMMch2.ATbKyYpzfLuDyXcrHYBENEsfLZA.id;
				int num2 = ListTools.Count(list, rsDwoTVWiWPfriOGPquqTINMMch2.mBqIVTXFVqBTUZdfmvleKynuFam);
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu9 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("id " + rsDwoTVWiWPfriOGPquqTINMMch2.ATbKyYpzfLuDyXcrHYBENEsfLZA.id + ": " + rsDwoTVWiWPfriOGPquqTINMMch2.ATbKyYpzfLuDyXcrHYBENEsfLZA.name + " (" + num2 + ")", text4, P_2);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu9.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				for (int num3 = 0; num3 < list.Count; num3++)
				{
					InputAction inputAction = list[num3];
					if (inputAction.categoryId != rsDwoTVWiWPfriOGPquqTINMMch2.ATbKyYpzfLuDyXcrHYBENEsfLZA.id)
					{
						continue;
					}
					string key = text4 + "_actionId" + inputAction.id;
					using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu10 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), key, P_2);
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu10.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Value", P_0.GetButton(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void nGTiODaEJYrRidTaFTHZqTNzDGg(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < num; i++)
				{
					InputBehavior inputBehavior = P_0[i];
					vBAVGXieudBnCGZGKOCYFatWYxr(inputBehavior, i, P_1, P_2);
				}
			}
		}

		private static void vBAVGXieudBnCGZGKOCYFatWYxr(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string key = P_3 + "_inputBehavior" + P_0.id;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(P_1 + ": " + P_0.name, key, P_2);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", P_0.id.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", P_0.name);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Dead Zone", P_0.buttonDeadZone.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void mSgLrVENGNEXdAjcQBPKYWUqKBA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.name, P_1);
						if (sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
						{
							TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", controllerElementIdentifier.id.ToString());
							TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", controllerElementIdentifier.name);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu5 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(j + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.name, P_1);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu5.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", controllerElementIdentifier2.id.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", controllerElementIdentifier2.name);
				}
			}
		}

		private static void GIsWuhiwYgLlryGyepoGeOthmVm(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(text + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.name) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Is Member Element", button.isMemberElement.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", button.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", button.valuePrev.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Pressure", button.pressure.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Pressure Prev", button.pressurePrev.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Just Pressed", button.justPressed.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Just Released", button.justReleased.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Just Double Pressed", button.justDoublePressed.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Pressed", button.timePressed.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Unpressed", button.timeUnpressed.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Pressed", button.lastTimePressed.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void GeGGoSwaPseCQKNeACSHbHjfZnie(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + axis.elementIdentifier.name + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Is Member Element", axis.isMemberElement.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", axis.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Raw", axis.valueRaw.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", axis.valuePrev.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Raw Prev", axis.valueRawPrev.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Delta", axis.valueDelta.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Delta Raw", axis.valueDeltaRaw.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Active", axis.timeActive.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Active Raw", axis.timeActiveRaw.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Inactive", axis.timeInactive.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Active", axis.lastTimeActive.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Inactive", axis.lastTimeInactive.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void wJKMagwPEesYnMgvEQwYCmtGUZP<T>(ControllerType P_0, IList<T> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where T : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(P_2 + " (" + num + ")", text, P_3);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
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
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						dDmSUsmqxbBSkPctHWxjQEjXqbi(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						dDmSUsmqxbBSkPctHWxjQEjXqbi(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void dDmSUsmqxbBSkPctHWxjQEjXqbi(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id (unique id)", P_0.id.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Source Map Id", P_0.sourceMapId.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", P_0.enabled.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Controller Id", P_0.controllerId.ToString());
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
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Category Id", text);
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
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					oAOdgSyHCajAHTCyCczhqpCAXbK(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void dDmSUsmqxbBSkPctHWxjQEjXqbi(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			dDmSUsmqxbBSkPctHWxjQEjXqbi((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					oAOdgSyHCajAHTCyCczhqpCAXbK(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void oAOdgSyHCajAHTCyCczhqpCAXbK(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = gOaXCjfDpmAaQJVZBAUkQiSOJCF(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id (unique id)", P_1.id.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Enabled", P_1.enabled.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Type", P_1.elementType.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Identifier Id", P_1.elementIdentifierId.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Index", P_1.elementIndex.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Range", P_1.axisRange.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Type", P_1.axisType.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Key Code", P_1.keyCode.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Modifiers", P_1.hasModifiers.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Modifier Key 1", P_1.modifierKey1.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Modifier Key 2", P_1.modifierKey2.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string gOaXCjfDpmAaQJVZBAUkQiSOJCF(ActionElementMap P_0)
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

		private static void BXlndLRSIyWADrEUUCXadUORWXm(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (eNZfejtaXJFRtBolKUnbZLEdBiQ("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Rule Sets (" + count + ")", text, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < count; i++)
				{
					RMjSfaKYhpjwMJpkJJqRStnSdSm(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void RMjSfaKYhpjwMJpkJJqRStnSdSm(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			if (eNZfejtaXJFRtBolKUnbZLEdBiQ("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Rules (" + P_0.Count + ")", text, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", rule.tag);
				HDAVxPwtrgGmnCJSKgTbKCVGmVO(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						if (num2 == 0)
						{
							TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void EVcxQspwkiwKXYkfJMOlPDqgjHh(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (eNZfejtaXJFRtBolKUnbZLEdBiQ("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Rule Sets (" + count + ")", text, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < count; i++)
				{
					gcIjCRifGXHsWQWmeobVfJVplzxS(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void gcIjCRifGXHsWQWmeobVfJVplzxS(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			if (eNZfejtaXJFRtBolKUnbZLEdBiQ("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Rules (" + P_0.Count + ")", text, P_2);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu3 = new SCEvzlLmJnoJbOHbnHQkEDedEIu(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu3.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				if (eNZfejtaXJFRtBolKUnbZLEdBiQ("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Tag", rule.tag);
				HDAVxPwtrgGmnCJSKgTbKCVGmVO(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu4 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (sCEvzlLmJnoJbOHbnHQkEDedEIu4.BqoyXZwedXMnGuhYlBMnZggUXtF)
					{
						if (num2 == 0)
						{
							TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu5 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!sCEvzlLmJnoJbOHbnHQkEDedEIu5.BqoyXZwedXMnGuhYlBMnZggUXtF)
				{
					continue;
				}
				if (num3 == 0)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : string.Concat("All ", rule.controllerSetSelector.controllerType, " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA(string.Concat(rule.controllerSetSelector.controllerType, " Layout ", k.ToString()), text4);
				}
			}
		}

		private static void HDAVxPwtrgGmnCJSKgTbKCVGmVO(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string key = P_2 + "_controllerSetSelector";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Controller Set Selector", key, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void VmJuFdnhwdsyHYiwHRbbZgBLwPL(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					BtTJuWMQyVOExylLkNnfoGeSbbI(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void BtTJuWMQyVOExylLkNnfoGeSbbI(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				return;
			}
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Type GUID", P_0.typeGuid.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu2 = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu2.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					ClDiAGMNTLmSkxQUMgPgrrefTfn(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void ClDiAGMNTLmSkxQUMgPgrrefTfn(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Id", P_0.id.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Name", P_0.descriptiveName.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Type", P_0.type.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					IControllerTemplateButton controllerTemplateButton = P_0 as IControllerTemplateButton;
					HTqzTangIhuRCpZsnuWknCWPBxXd(controllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					IControllerTemplateAxis controllerTemplateAxis = P_0 as IControllerTemplateAxis;
					UaDgRvOOMTGjZJlBtWUnKadpxuGF(controllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateDPad.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateDPad.up, "Up", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateDPad.right, "Right", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateDPad.down, "Down", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateHat.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateHat.valuePrev.ToString());
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.up, "up", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.right, "right", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.down, "down", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.left, "left", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateStick.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateStick.valuePrev.ToString());
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateThrottle.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateThumbStick.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					rWMnnaYcrfxuVlCCTfIIVHqWBBzh(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", controllerTemplateYoke.value.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Position", controllerTemplateStick6D.position.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Rotation", controllerTemplateStick6D.rotation.ToString());
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					NjsHuSUdcPCpbJvURkhBLmGmGSRg(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void NjsHuSUdcPCpbJvURkhBLmGmGSRg(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				UaDgRvOOMTGjZJlBtWUnKadpxuGF(P_0, P_2, P_3);
			}
		}

		private static void rWMnnaYcrfxuVlCCTfIIVHqWBBzh(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				HTqzTangIhuRCpZsnuWknCWPBxXd(P_0, P_2, P_3);
			}
		}

		private static void UaDgRvOOMTGjZJlBtWUnKadpxuGF(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", P_0.value.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", P_0.valuePrev.ToString());
			KNbYKeJLQYsPdMhxHQovWYANcfl(P_0.source, "target", P_1, P_2);
		}

		private static void HTqzTangIhuRCpZsnuWknCWPBxXd(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value", P_0.value.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Value Prev", P_0.valuePrev.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Pressure", P_0.pressure.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Pressure Prev", P_0.pressurePrev.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Just Pressed", P_0.justPressed.ToString());
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Just Released", P_0.justReleased.ToString());
			kPMkREdxLmeGMrMmPXMeDkeSWvg(P_0.source, "target", P_1, P_2);
		}

		private static void KNbYKeJLQYsPdMhxHQovWYANcfl(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu("Axis Target", P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Split Axis", P_0.splitAxis.ToString());
				qrhZGofkrXskPVWFSghebBqSNSD(P_0.fullTarget, "target", P_2, P_3);
				qrhZGofkrXskPVWFSghebBqSNSD(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				qrhZGofkrXskPVWFSghebBqSNSD(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void kPMkREdxLmeGMrMmPXMeDkeSWvg(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			qrhZGofkrXskPVWFSghebBqSNSD(P_0.target, "target", P_2, P_3);
		}

		private static void qrhZGofkrXskPVWFSghebBqSNSD(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using SCEvzlLmJnoJbOHbnHQkEDedEIu sCEvzlLmJnoJbOHbnHQkEDedEIu = new SCEvzlLmJnoJbOHbnHQkEDedEIu(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (sCEvzlLmJnoJbOHbnHQkEDedEIu.BqoyXZwedXMnGuhYlBMnZggUXtF)
			{
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Element Identifier Id", P_0.elementIdentifierId.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Axis Range", P_0.axisRange.ToString());
				TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool eNZfejtaXJFRtBolKUnbZLEdBiQ(string P_0, bool P_1)
		{
			TsLhZsAiWPBwXnwCjOfREWbMfoS.nAYsQrwUlJmPuZSvIgnuzdtKbdA(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle mwjGOeHeqbBEwSZqVejMkGUVYRFf()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.margin.top = 1;
			gUIStyle.margin.bottom = 1;
			gUIStyle.fontSize = SKcIgrdHSZRiIzfxUyDOqjyMnCX._fontSize;
			return bKRydzOVKHqbQWJGMGaVeAVVRoX(gUIStyle);
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.toggle);
			gUIStyle.margin.top = 0;
			gUIStyle.margin.bottom = 0;
			gUIStyle = bKRydzOVKHqbQWJGMGaVeAVVRoX(gUIStyle);
			gUIStyle.fontSize = SKcIgrdHSZRiIzfxUyDOqjyMnCX._fontSize;
			return gUIStyle;
		}

		private static GUIStyle bKRydzOVKHqbQWJGMGaVeAVVRoX(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = OfVaVtEkmndbDLwceCGOBiWjyvsa.indentLevel * 20;
			return P_0;
		}

		[CompilerGenerated]
		private static int GJjLFqPglOgmShikWUmaNjPlbUJb(InputAction P_0, InputAction P_1)
		{
			return P_0.name.CompareTo(P_1.name);
		}
	}
}
