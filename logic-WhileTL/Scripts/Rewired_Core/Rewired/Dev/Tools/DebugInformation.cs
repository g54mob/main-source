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
		private class ENsiVJCXsDLnUhvxIUQecQmhxEeR : IDisposable
		{
			public readonly bool XaKLIbtUCxTVbHaGOHVxhwqGFdTT;

			public ENsiVJCXsDLnUhvxIUQecQmhxEeR(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				XaKLIbtUCxTVbHaGOHVxhwqGFdTT = ULenkpRqaJDRwCMcpnenKeBYuvdC(P_0, P_1, P_2);
				IfClDdpZJgmesRyNTBKwICguxkiA.aCZcZhgtOMFsAFsZGqSTNFvducMoB++;
			}

			private bool ULenkpRqaJDRwCMcpnenKeBYuvdC(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return EvbhVKqmlQSvEaCgPVRnBpDoGokd(P_1, GUILayout.Toggle(qJJijEnxlzlRUADCnpDDiOFCbneP(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool qJJijEnxlzlRUADCnpDDiOFCbneP(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool EvbhVKqmlQSvEaCgPVRnBpDoGokd(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				IfClDdpZJgmesRyNTBKwICguxkiA.aCZcZhgtOMFsAFsZGqSTNFvducMoB--;
			}
		}

		private static class IfClDdpZJgmesRyNTBKwICguxkiA
		{
			private static int tDXSNLqlgtdEOKzlDEKhcrnFdAU;

			public static int aCZcZhgtOMFsAFsZGqSTNFvducMoB
			{
				get
				{
					return tDXSNLqlgtdEOKzlDEKhcrnFdAU;
				}
				set
				{
					tDXSNLqlgtdEOKzlDEKhcrnFdAU = Mathf.Max(0, b);
				}
			}
		}

		private static class VezhiAZOptjXeAWWWeMBcRvEiiQK
		{
			public static void LkoHkpogYsdyyLslyfsnZZTOYxDL()
			{
				GUILayout.BeginHorizontal();
			}

			public static void KrVLcsRApuQjHNmhUZkolOwxdIYo()
			{
				GUILayout.EndHorizontal();
			}

			public static void CkoudwmcXmdzOhDNOQHAtyYWhsKx()
			{
				GUILayout.BeginVertical();
			}

			public static void mQlnNHnYTaQFFMcCdQiEqODhBNPJ()
			{
				GUILayout.EndVertical();
			}

			public static void pEjxBKUnbymDoMJmqgkIaWBoSsjFA(string P_0, NtNYhEOrRUZsdLAQATWuqdHRyuQB P_1)
			{
				GUILayout.Label(P_0, ccFusGxTkDHCJeIgwsuOmkSLBoJk());
			}

			public static void dTshEDpfKpPvVqllvLleBUlSJtOu(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, ccFusGxTkDHCJeIgwsuOmkSLBoJk());
			}

			public static void BQOeCFhhcjHTGKbWONwKZOEtApccb(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool kGtEPZqigtdEQgitfbsfhKQzTmGo(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, ccFusGxTkDHCJeIgwsuOmkSLBoJk());
			}
		}

		private static class fWPqCVFUQWLpuboLwqtgZqWwGVXG
		{
			[CompilerGenerated]
			private static float eZZZOlPhTDJdsUMfIcBaOeRVYYZK;

			[CompilerGenerated]
			private static float aHbgjTJRchBVjXFFfNwdnTSunFLmA;

			public static float ldXBgmbhwWAIVqyiqsIIoLfmgDaf
			{
				[CompilerGenerated]
				get
				{
					return eZZZOlPhTDJdsUMfIcBaOeRVYYZK;
				}
				[CompilerGenerated]
				set
				{
					eZZZOlPhTDJdsUMfIcBaOeRVYYZK = num;
				}
			}

			public static float uBShaayGcNbjeFGigzTHSxnbicQUA
			{
				[CompilerGenerated]
				get
				{
					return aHbgjTJRchBVjXFFfNwdnTSunFLmA;
				}
				[CompilerGenerated]
				set
				{
					aHbgjTJRchBVjXFFfNwdnTSunFLmA = num;
				}
			}
		}

		internal enum NtNYhEOrRUZsdLAQATWuqdHRyuQB
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class LSsExvCNPPPkVlQdxFPHjIkaNEGgc
		{
			public static readonly LSsExvCNPPPkVlQdxFPHjIkaNEGgc _003C_003E9 = new LSsExvCNPPPkVlQdxFPHjIkaNEGgc();

			public static Comparison<InputAction> _003C_003E9__16_0;

			internal int yxhHoXUxqhToVYCDPWWBZjjOIScn(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class nSnOLgSNVFJWZCiyBOaqFlVrJjKR
		{
			public InputCategory OAJVeKkSIlmvoqPuyDXBddKhlRHvA;

			internal bool euGNshGacQFCfJitZlochcteiiqhA(InputAction P_0)
			{
				return P_0.categoryId == OAJVeKkSIlmvoqPuyDXBddKhlRHvA.id;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _fontSize = 13;

		private static DebugInformation WjQAaHwnldjGbWthvILYYAgChYHq;

		private IDictionary<string, bool> hBmIBFjvKQGmResJJQDsLeXdgoO = new Dictionary<string, bool>();

		private static Vector2 DMuBUmEgiaFFoHwTArDOnXpkIkLg;

		private const string iEIvDmglitPmGYkeVFkwIMCKarpgA = "Rewired_DebugInformation";

		private const string GMHzNfXvsvzUzzKcYadmQRHtjzfe = "Rewired Debug Information";

		private const int cpxWrJTOVIxLJeulsPXFEHWCAKdN = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			WjQAaHwnldjGbWthvILYYAgChYHq = this;
			if (hBmIBFjvKQGmResJJQDsLeXdgoO.Count == 0)
			{
				hBmIBFjvKQGmResJJQDsLeXdgoO.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (WjQAaHwnldjGbWthvILYYAgChYHq == this)
			{
				WjQAaHwnldjGbWthvILYYAgChYHq = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			IfClDdpZJgmesRyNTBKwICguxkiA.aCZcZhgtOMFsAFsZGqSTNFvducMoB = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			DMuBUmEgiaFFoHwTArDOnXpkIkLg = GUILayout.BeginScrollView(DMuBUmEgiaFFoHwTArDOnXpkIkLg, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, hBmIBFjvKQGmResJJQDsLeXdgoO);
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
			VezhiAZOptjXeAWWWeMBcRvEiiQK.LkoHkpogYsdyyLslyfsnZZTOYxDL();
			GUILayout.FlexibleSpace();
			VezhiAZOptjXeAWWWeMBcRvEiiQK.KrVLcsRApuQjHNmhUZkolOwxdIYo();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			fWPqCVFUQWLpuboLwqtgZqWwGVXG.ldXBgmbhwWAIVqyiqsIIoLfmgDaf = lastRect.width - num2;
			fWPqCVFUQWLpuboLwqtgZqWwGVXG.uBShaayGcNbjeFGigzTHSxnbicQUA = num2;
			GkaBbVJxbbnSBdFLWgcuRFwhHuRoA(enabled, foldouts);
			GUI.enabled = num;
			fWPqCVFUQWLpuboLwqtgZqWwGVXG.ldXBgmbhwWAIVqyiqsIIoLfmgDaf = 0f;
			fWPqCVFUQWLpuboLwqtgZqWwGVXG.uBShaayGcNbjeFGigzTHSxnbicQUA = 0f;
		}

		private static void GkaBbVJxbbnSBdFLWgcuRFwhHuRoA(bool P_0, IDictionary<string, bool> P_1)
		{
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					return;
				}
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Rewired Version", ReInput.programVersion);
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.pEjxBKUnbymDoMJmqgkIaWBoSsjFA("Native input is disabled. Many special features are unavailable without native input.", NtNYhEOrRUZsdLAQATWuqdHRyuQB.Warning);
				}
				cjoFGqiaiIJzLWkQZMgcQiAiryKX(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Controllers", text, P_1);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					QreqfqUKKFsUDpevKxVTjkYvdYRBA(ReInput.controllers.Joysticks, P_1, text);
					CohcfdibWeFfXOmIKdFESjANawqk(ReInput.controllers.CustomControllers, P_1, text);
					LmsOTjiiXlRUVuNVpUMmzcwTzSNS(P_1, "Rewired_DebugInformation");
					fSmxXFdLYMsFmWpmVnmwNokjEULK(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void cjoFGqiaiIJzLWkQZMgcQiAiryKX(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					isrVRDZaAnDHqKtvmwpgOTpQpfBKA(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				isrVRDZaAnDHqKtvmwpgOTpQpfBKA(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void QreqfqUKKFsUDpevKxVTjkYvdYRBA(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				id = joystick.id;
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id (unique id)", id.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", joystick.name);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Name", joystick.hardwareName);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", joystick.enabled.ToString());
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
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("System Id", joystick.systemId.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Identifier", joystick.hardwareIdentifier);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", joystick.tag);
				GSeOjgvweQHepgpkhHtBlJrJdveh(joystick.Axes, P_1, text);
				SfMAgZvdACsPABcbDnZEEdlbXjih(joystick.Buttons, ControllerType.Joystick, P_1, text);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis2D Count", joystick.axis2DCount.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hat Count", joystick.hatCount.ToString());
				aeCHxlTXrdDZWbMevGCCoPIsvYMk(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
							{
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", axisCalibration.enabled.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Max", axisCalibration.calibratedMax.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Min", axisCalibration.calibratedMin.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Dead Zone", axisCalibration.deadZone.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Invert", axisCalibration.invert.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									VezhiAZOptjXeAWWWeMBcRvEiiQK.BQOeCFhhcjHTGKbWONwKZOEtApccb("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Supports Vibration", joystick.supportsVibration.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Extension", (joystick.extension != null).ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				HdlGITdgZLBjiRlmkOMjnxTHCcPZA(joystick, P_1, text);
			}
		}

		private static void LmsOTjiiXlRUVuNVpUMmzcwTzSNS(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Mouse", text, P_0);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", mouse.enabled.ToString());
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
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Screen Position", mouse.screenPosition.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Screen Position Prev", mouse.screenPositionPrev.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Screen Position Delta", mouse.screenPositionDelta.ToString());
			GSeOjgvweQHepgpkhHtBlJrJdveh(mouse.Axes, P_0, text);
			SfMAgZvdACsPABcbDnZEEdlbXjih(mouse.Buttons, ControllerType.Mouse, P_0, text);
			aeCHxlTXrdDZWbMevGCCoPIsvYMk(mouse, P_0, text);
			HdlGITdgZLBjiRlmkOMjnxTHCcPZA(mouse, P_0, text);
		}

		private static void fSmxXFdLYMsFmWpmVnmwNokjEULK(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Keyboard", text, P_0);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", keyboard.enabled.ToString());
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
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			SfMAgZvdACsPABcbDnZEEdlbXjih(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			aeCHxlTXrdDZWbMevGCCoPIsvYMk(keyboard, P_0, text);
			HdlGITdgZLBjiRlmkOMjnxTHCcPZA(keyboard, P_0, text);
		}

		private static void CohcfdibWeFfXOmIKdFESjANawqk(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + customController.name, text, P_1);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				id = customController.id;
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", id.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", customController.name);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Name", customController.hardwareName);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", customController.tag);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Identifier", customController.hardwareIdentifier);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", customController.enabled.ToString());
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
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				GSeOjgvweQHepgpkhHtBlJrJdveh(customController.Axes, P_1, text);
				SfMAgZvdACsPABcbDnZEEdlbXjih(customController.Buttons, ControllerType.Custom, P_1, text);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis2D Count", customController.axis2DCount.ToString());
				using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR5 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(k + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.name, P_1);
									if (eNsiVJCXsDLnUhvxIUQecQmhxEeR5.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
									{
										VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", controllerElementIdentifier.id.ToString());
										VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", controllerElementIdentifier.name);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR6 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (eNsiVJCXsDLnUhvxIUQecQmhxEeR6.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR7 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(l + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.name, P_1);
								if (eNsiVJCXsDLnUhvxIUQecQmhxEeR7.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
								{
									VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", controllerElementIdentifier2.id.ToString());
									VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", controllerElementIdentifier2.name);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR8 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR8.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR9 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (eNsiVJCXsDLnUhvxIUQecQmhxEeR9.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
							{
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", axisCalibration.enabled.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Max", axisCalibration.calibratedMax.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Min", axisCalibration.calibratedMin.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Dead Zone", axisCalibration.deadZone.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Invert", axisCalibration.invert.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									VezhiAZOptjXeAWWWeMBcRvEiiQK.BQOeCFhhcjHTGKbWONwKZOEtApccb("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Extension", (customController.extension != null).ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				HdlGITdgZLBjiRlmkOMjnxTHCcPZA(customController, P_1, text);
			}
		}

		private static void isrVRDZaAnDHqKtvmwpgOTpQpfBKA(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Player Id", P_0.id.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", P_0.name);
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Descriptive Name", P_0.descriptiveName);
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Is Playing", P_0.isPlaying.ToString());
			using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Controllers", text + "_controllers", P_2))
			{
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					QreqfqUKKFsUDpevKxVTjkYvdYRBA(controllers.Joysticks, P_2, text);
					CohcfdibWeFfXOmIKdFESjANawqk(controllers.CustomControllers, P_2, text);
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Mouse", controllers.hasMouse.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Keyboard", controllers.hasKeyboard.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				}
			}
			string text2 = text + "_controllerMaps";
			using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Controller Maps", text2, P_2))
			{
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					uLkdCWlzbUuNWzOdrCjOwRdGcPZq(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					uLkdCWlzbUuNWzOdrCjOwRdGcPZq(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								uLkdCWlzbUuNWzOdrCjOwRdGcPZq(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR5 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR5.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							uLkdCWlzbUuNWzOdrCjOwRdGcPZq(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR6 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Layout Manager", text2, P_2))
			{
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR6.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					NzJHVfGGrAbNsSQGpfCgcROXJNqjb(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR7 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Map Enabler", text2, P_2))
			{
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR7.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					UwSrLQgHJYazkffjopNfehaKyxnCB(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			fphEIrBzlscmkEEDCoAZzSPejHkAB(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(LSsExvCNPPPkVlQdxFPHjIkaNEGgc._003C_003E9.yxhHoXUxqhToVYCDPWWBZjjOIScn);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR8 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Actions (" + list.Count + ")", text2, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR8.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				nSnOLgSNVFJWZCiyBOaqFlVrJjKR nSnOLgSNVFJWZCiyBOaqFlVrJjKR2 = new nSnOLgSNVFJWZCiyBOaqFlVrJjKR();
				nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.OAJVeKkSIlmvoqPuyDXBddKhlRHvA = actionCategories[k];
				string text6 = text2 + "_actionCat" + nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.OAJVeKkSIlmvoqPuyDXBddKhlRHvA.id;
				int num = ListTools.Count(list, nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.euGNshGacQFCfJitZlochcteiiqhA);
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR9 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("id " + nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.OAJVeKkSIlmvoqPuyDXBddKhlRHvA.id + ": " + nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.OAJVeKkSIlmvoqPuyDXBddKhlRHvA.name + " (" + num + ")", text6, P_2);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR9.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != nSnOLgSNVFJWZCiyBOaqFlVrJjKR2.OAJVeKkSIlmvoqPuyDXBddKhlRHvA.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR10 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR10.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Value", P_0.GetButton(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void fphEIrBzlscmkEEDCoAZzSPejHkAB(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < num; i++)
				{
					vssojNxVaPmjiuCyhDQsMdhCvjtE(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void vssojNxVaPmjiuCyhDQsMdhCvjtE(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(P_1 + ": " + P_0.name, text, P_2);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", P_0.id.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", P_0.name);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Dead Zone", P_0.buttonDeadZone.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void aeCHxlTXrdDZWbMevGCCoPIsvYMk(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.name, P_1);
						if (eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
						{
							VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", controllerElementIdentifier.id.ToString());
							VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", controllerElementIdentifier.name);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR5 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(j + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.name, P_1);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR5.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", controllerElementIdentifier2.id.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", controllerElementIdentifier2.name);
				}
			}
		}

		private static void SfMAgZvdACsPABcbDnZEEdlbXjih(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.name) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Is Member Element", button.isMemberElement.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", button.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", button.valuePrev.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Pressure", button.pressure.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Pressure Prev", button.pressurePrev.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Just Pressed", button.justPressed.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Just Released", button.justReleased.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Just Double Pressed", button.justDoublePressed.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Pressed", button.timePressed.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Unpressed", button.timeUnpressed.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Pressed", button.lastTimePressed.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void GSeOjgvweQHepgpkhHtBlJrJdveh(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + axis.elementIdentifier.name + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Is Member Element", axis.isMemberElement.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", axis.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Raw", axis.valueRaw.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", axis.valuePrev.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Raw Prev", axis.valueRawPrev.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Delta", axis.valueDelta.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Delta Raw", axis.valueDeltaRaw.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Active", axis.timeActive.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Active Raw", axis.timeActiveRaw.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Inactive", axis.timeInactive.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Active", axis.lastTimeActive.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Inactive", axis.lastTimeInactive.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void uLkdCWlzbUuNWzOdrCjOwRdGcPZq<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(P_2 + " (" + num + ")", text, P_3);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
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
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						vMUGgOxqCRiOBbczmMPvMghBqmupA(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						vMUGgOxqCRiOBbczmMPvMghBqmupA(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void vMUGgOxqCRiOBbczmMPvMghBqmupA(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id (unique id)", P_0.id.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Source Map Id", P_0.sourceMapId.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", P_0.enabled.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Controller Id", P_0.controllerId.ToString());
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
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Category Id", text);
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
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					krgOConixSUPmyMchgozULSErxUQ(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void vMUGgOxqCRiOBbczmMPvMghBqmupA(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			vMUGgOxqCRiOBbczmMPvMghBqmupA((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					krgOConixSUPmyMchgozULSErxUQ(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void krgOConixSUPmyMchgozULSErxUQ(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = khWcvXfqWMXTnLmByFPgxeQWQBXHA(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id (unique id)", P_1.id.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Enabled", P_1.enabled.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Type", P_1.elementType.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Identifier Id", P_1.elementIdentifierId.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Index", P_1.elementIndex.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Range", P_1.axisRange.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Type", P_1.axisType.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Key Code", P_1.keyCode.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Modifiers", P_1.hasModifiers.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Modifier Key 1", P_1.modifierKey1.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Modifier Key 2", P_1.modifierKey2.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string khWcvXfqWMXTnLmByFPgxeQWQBXHA(ActionElementMap P_0)
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

		private static void NzJHVfGGrAbNsSQGpfCgcROXJNqjb(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (kGtEPZqigtdEQgitfbsfhKQzTmGo("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Rule Sets (" + count + ")", text, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < count; i++)
				{
					ZhDVcCFSTVpCdwqwkjfZmpHYSOoD(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void ZhDVcCFSTVpCdwqwkjfZmpHYSOoD(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			if (kGtEPZqigtdEQgitfbsfhKQzTmGo("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Rules (" + P_0.Count + ")", text, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", rule.tag);
				JQsZhppIgCnSobGlnIhqsBzGJEmc(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						if (num2 == 0)
						{
							VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void UwSrLQgHJYazkffjopNfehaKyxnCB(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (kGtEPZqigtdEQgitfbsfhKQzTmGo("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Rule Sets (" + count + ")", text, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < count; i++)
				{
					unkmtlynxzdSdneIJiZRzZMzfure(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void unkmtlynxzdSdneIJiZRzZMzfure(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			if (kGtEPZqigtdEQgitfbsfhKQzTmGo("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Rules (" + P_0.Count + ")", text, P_2);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR3 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR3.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				if (kGtEPZqigtdEQgitfbsfhKQzTmGo("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Tag", rule.tag);
				JQsZhppIgCnSobGlnIhqsBzGJEmc(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR4 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (eNsiVJCXsDLnUhvxIUQecQmhxEeR4.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
					{
						if (num2 == 0)
						{
							VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR5 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR5.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
				{
					continue;
				}
				if (num3 == 0)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void JQsZhppIgCnSobGlnIhqsBzGJEmc(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Controller Set Selector", text, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void HdlGITdgZLBjiRlmkOMjnxTHCcPZA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					ZUjEtaTUNpiPKZOXZATnShsMhxUp(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void ZUjEtaTUNpiPKZOXZATnShsMhxUp(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				return;
			}
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Type GUID", P_0.typeGuid.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR2 = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR2.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					WCfyWyHhczbhhWeWzAxPABtxQBnnA(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void WCfyWyHhczbhhWeWzAxPABtxQBnnA(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Id", P_0.id.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Name", P_0.descriptiveName.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Type", P_0.type.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					JOhCbohiPIerIkJUNeUVEEFjbFD(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					UTjllDFThvwRwUaVIJFvCerhDsAx(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateDPad.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateDPad.up, "Up", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateDPad.right, "Right", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateDPad.down, "Down", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateHat.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateHat.valuePrev.ToString());
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.up, "up", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.right, "right", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.down, "down", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.left, "left", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateStick.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateStick.valuePrev.ToString());
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateThrottle.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateThumbStick.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					bzmpZSDySZieuEHCiGZWhZiEJTxT(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", controllerTemplateYoke.value.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Position", controllerTemplateStick6D.position.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Rotation", controllerTemplateStick6D.rotation.ToString());
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					NEOUzyRQFpcyOOTWyghZCoCiQmTH(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void NEOUzyRQFpcyOOTWyghZCoCiQmTH(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				UTjllDFThvwRwUaVIJFvCerhDsAx(P_0, P_2, P_3);
			}
		}

		private static void bzmpZSDySZieuEHCiGZWhZiEJTxT(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				JOhCbohiPIerIkJUNeUVEEFjbFD(P_0, P_2, P_3);
			}
		}

		private static void UTjllDFThvwRwUaVIJFvCerhDsAx(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", P_0.value.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", P_0.valuePrev.ToString());
			QBFiuYgEyuPjIDvlyEJdwiILWihbA(P_0.source, "target", P_1, P_2);
		}

		private static void JOhCbohiPIerIkJUNeUVEEFjbFD(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value", P_0.value.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Value Prev", P_0.valuePrev.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Pressure", P_0.pressure.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Pressure Prev", P_0.pressurePrev.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Just Pressed", P_0.justPressed.ToString());
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Just Released", P_0.justReleased.ToString());
			oAlaIxCkQrApvcQQPuAOxrsmhCngb(P_0.source, "target", P_1, P_2);
		}

		private static void QBFiuYgEyuPjIDvlyEJdwiILWihbA(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR("Axis Target", P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Split Axis", P_0.splitAxis.ToString());
				yRiqGiDMvbLwyeDtyroBumQOnZK(P_0.fullTarget, "target", P_2, P_3);
				yRiqGiDMvbLwyeDtyroBumQOnZK(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				yRiqGiDMvbLwyeDtyroBumQOnZK(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void oAlaIxCkQrApvcQQPuAOxrsmhCngb(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			yRiqGiDMvbLwyeDtyroBumQOnZK(P_0.target, "target", P_2, P_3);
		}

		private static void yRiqGiDMvbLwyeDtyroBumQOnZK(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using ENsiVJCXsDLnUhvxIUQecQmhxEeR eNsiVJCXsDLnUhvxIUQecQmhxEeR = new ENsiVJCXsDLnUhvxIUQecQmhxEeR(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (eNsiVJCXsDLnUhvxIUQecQmhxEeR.XaKLIbtUCxTVbHaGOHVxhwqGFdTT)
			{
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Element Identifier Id", P_0.elementIdentifierId.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Axis Range", P_0.axisRange.ToString());
				VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool kGtEPZqigtdEQgitfbsfhKQzTmGo(string P_0, bool P_1)
		{
			VezhiAZOptjXeAWWWeMBcRvEiiQK.dTshEDpfKpPvVqllvLleBUlSJtOu(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle ccFusGxTkDHCJeIgwsuOmkSLBoJk()
		{
			return xFjTLmJzBvezPpIpxfJfEPRryHFb(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = WjQAaHwnldjGbWthvILYYAgChYHq._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = xFjTLmJzBvezPpIpxfJfEPRryHFb(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = WjQAaHwnldjGbWthvILYYAgChYHq._fontSize;
			return gUIStyle;
		}

		private static GUIStyle xFjTLmJzBvezPpIpxfJfEPRryHFb(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = IfClDdpZJgmesRyNTBKwICguxkiA.aCZcZhgtOMFsAFsZGqSTNFvducMoB * 20;
			return P_0;
		}
	}
}
