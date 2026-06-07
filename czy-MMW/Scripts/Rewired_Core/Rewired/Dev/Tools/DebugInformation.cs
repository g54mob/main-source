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
		private class gbXbMPKYYsBFxfzFyVzzpZmKbXWkA : IDisposable
		{
			public readonly bool bgKAfomhaaVldaYHKFZZsItvcocQ;

			public gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				bgKAfomhaaVldaYHKFZZsItvcocQ = wRmkOBpdQJRiMkvPkFChiqzSyGtL(P_0, P_1, P_2);
				azOgLNrptiABTLoGpyoLtcKZEaQT.wqysmZhoERcCzyGsMZYEnvYyoiZG++;
			}

			private bool wRmkOBpdQJRiMkvPkFChiqzSyGtL(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return DMAizLRMYwOBKAzndkOYltWcYQvG(P_1, GUILayout.Toggle(AoCaIfVlyaOodWJugIVkrRJtBMHK(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool AoCaIfVlyaOodWJugIVkrRJtBMHK(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool DMAizLRMYwOBKAzndkOYltWcYQvG(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				azOgLNrptiABTLoGpyoLtcKZEaQT.wqysmZhoERcCzyGsMZYEnvYyoiZG--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class azOgLNrptiABTLoGpyoLtcKZEaQT
		{
			private static int VfdSoARuIohbRFoiCbwMRojpQiYe;

			public static int wqysmZhoERcCzyGsMZYEnvYyoiZG
			{
				get
				{
					return VfdSoARuIohbRFoiCbwMRojpQiYe;
				}
				set
				{
					VfdSoARuIohbRFoiCbwMRojpQiYe = Mathf.Max(0, b);
				}
			}
		}

		private static class tOOyCATDQWZFXUbwyTTYPCtfjumI
		{
			public static void tCgWKujTaDqSJOpGfcnhjmmsclMgA()
			{
				GUILayout.BeginHorizontal();
			}

			public static void YbdKmsuyuqDdwuxfYTyZuiAGqLqn()
			{
				GUILayout.EndHorizontal();
			}

			public static void KXFeFSdDCCFJHJOcADXVYMxSnULZ()
			{
				GUILayout.BeginVertical();
			}

			public static void OkQdSTNLfqYklWnhfENtGWhATUdmA()
			{
				GUILayout.EndVertical();
			}

			public static void guGcnXkudBWKIBDsITkswTXguzDm(string P_0, pIwBVzIZplzEJRDmyqWBNRxavySi P_1)
			{
				GUILayout.Label(P_0, teRmENiHPfIlrCdFMgbMvPMLdklhb());
			}

			public static void OODbzIlgjJRmIZDNZhHwxlkghsECA(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, teRmENiHPfIlrCdFMgbMvPMLdklhb());
			}

			public static void wqeFuMVSsAqmrNpHJlBjXFdUgZvaA(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool uCjiHhXxYCKeWVhjKtEomlqcOyk(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, teRmENiHPfIlrCdFMgbMvPMLdklhb());
			}
		}

		private static class ThcnKHXkCdllJltOWRAvieCNVszf
		{
			[CompilerGenerated]
			private static float IjrhanCsnGmcKuHLKBZUQsCtkWOQ;

			[CompilerGenerated]
			private static float IwApneZJmjWvsWbppYmDoFAlMCMF;

			public static float KcCIVpeLtpFsUnaQxFnHjNRiqzrcB
			{
				[CompilerGenerated]
				get
				{
					return IjrhanCsnGmcKuHLKBZUQsCtkWOQ;
				}
				[CompilerGenerated]
				set
				{
					IjrhanCsnGmcKuHLKBZUQsCtkWOQ = ijrhanCsnGmcKuHLKBZUQsCtkWOQ;
				}
			}

			public static float rQiIeKDvYwifkKkbVPbJJhTMPeww
			{
				[CompilerGenerated]
				get
				{
					return IwApneZJmjWvsWbppYmDoFAlMCMF;
				}
				[CompilerGenerated]
				set
				{
					IwApneZJmjWvsWbppYmDoFAlMCMF = iwApneZJmjWvsWbppYmDoFAlMCMF;
				}
			}
		}

		internal enum pIwBVzIZplzEJRDmyqWBNRxavySi
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class lCNomjNXrqfGyAMXHWyQtEswGPcs
		{
			public static readonly lCNomjNXrqfGyAMXHWyQtEswGPcs _003C_003E9 = new lCNomjNXrqfGyAMXHWyQtEswGPcs();

			public static Comparison<InputAction> _003C_003E9__16_0;

			internal int RNfgoDfBMtVMjxLdBshxXxofSLhr(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class BFIBKcgGzeLoaCUGdbPtQwTQMckAA
		{
			public InputCategory DCDXJvSjNeEfrgKQznNotzLzJGgu;

			internal bool hoHszZecuHIDDLhRbbOPVhrMQOQe(InputAction P_0)
			{
				return P_0.categoryId == DCDXJvSjNeEfrgKQznNotzLzJGgu.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation oHsrffqUbZvNtzKULCkWfSndLLPWA;

		private IDictionary<string, bool> WScAuHbaoREGadkQAyJqGPSfwhsPA = new Dictionary<string, bool>();

		private static Vector2 fJeRxQLyFkiPzNAlzcIsCEjIAngsA;

		private const string zKqoJbnfABCXKcdnwCHlSrUrToEl = "Rewired_DebugInformation";

		private const string WhRtQlcHeKCTHVDFbUrdLAnJDRo = "Rewired Debug Information";

		private const int bYOWTZfLyMjwKLrOmysTOhNLszHJ = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			oHsrffqUbZvNtzKULCkWfSndLLPWA = this;
			if (WScAuHbaoREGadkQAyJqGPSfwhsPA.Count == 0)
			{
				WScAuHbaoREGadkQAyJqGPSfwhsPA.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (oHsrffqUbZvNtzKULCkWfSndLLPWA == this)
			{
				oHsrffqUbZvNtzKULCkWfSndLLPWA = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			azOgLNrptiABTLoGpyoLtcKZEaQT.wqysmZhoERcCzyGsMZYEnvYyoiZG = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			fJeRxQLyFkiPzNAlzcIsCEjIAngsA = GUILayout.BeginScrollView(fJeRxQLyFkiPzNAlzcIsCEjIAngsA, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, WScAuHbaoREGadkQAyJqGPSfwhsPA);
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
			tOOyCATDQWZFXUbwyTTYPCtfjumI.tCgWKujTaDqSJOpGfcnhjmmsclMgA();
			GUILayout.FlexibleSpace();
			tOOyCATDQWZFXUbwyTTYPCtfjumI.YbdKmsuyuqDdwuxfYTyZuiAGqLqn();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			ThcnKHXkCdllJltOWRAvieCNVszf.KcCIVpeLtpFsUnaQxFnHjNRiqzrcB = lastRect.width - num2;
			ThcnKHXkCdllJltOWRAvieCNVszf.rQiIeKDvYwifkKkbVPbJJhTMPeww = num2;
			cPZCAzDWgApyBfYSlRwjgixhujqy(enabled, foldouts);
			GUI.enabled = num;
			ThcnKHXkCdllJltOWRAvieCNVszf.KcCIVpeLtpFsUnaQxFnHjNRiqzrcB = 0f;
			ThcnKHXkCdllJltOWRAvieCNVszf.rQiIeKDvYwifkKkbVPbJJhTMPeww = 0f;
		}

		private static void cPZCAzDWgApyBfYSlRwjgixhujqy(bool P_0, IDictionary<string, bool> P_1)
		{
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					return;
				}
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Rewired Version", ReInput.programVersion);
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.guGcnXkudBWKIBDsITkswTXguzDm("Native input is disabled. Many special features are unavailable without native input.", pIwBVzIZplzEJRDmyqWBNRxavySi.Warning);
				}
				dpRwWMEsbZtKJgKVJetGfFNTFjEf(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Controllers", text, P_1);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					GgNjeHQgPKIyFcTbYZLqCfiPPycaA(ReInput.controllers.Joysticks, P_1, text);
					KMNmXHSEmgPhNjegxpZauIgmOazQ(ReInput.controllers.CustomControllers, P_1, text);
					QPFENDAkAvKIJClBdaDnAvGqzrlKA(P_1, "Rewired_DebugInformation");
					hirSzZghuZjbFxlkSJhNUajWWdrO(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void dpRwWMEsbZtKJgKVJetGfFNTFjEf(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					DQbtqSsNQUTbtCkhdpNhcuaeUSGs(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				DQbtqSsNQUTbtCkhdpNhcuaeUSGs(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void GgNjeHQgPKIyFcTbYZLqCfiPPycaA(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				id = joystick.id;
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id (unique id)", id.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", joystick.name);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Name", joystick.hardwareName);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", joystick.enabled.ToString());
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
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("System Id", joystick.systemId.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Identifier", joystick.hardwareIdentifier);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", joystick.tag);
				UbtOGZThlgANVeUDJOJKGhDcxsgjB(joystick.Axes, P_1, text);
				LJMcIIfarKfdnjhSBJeMFIyYDtQYb(joystick.Buttons, ControllerType.Joystick, P_1, text);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis2D Count", joystick.axis2DCount.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hat Count", joystick.hatCount.ToString());
				YZkCFvnuXacYKBfEPlPrsJHALGFUA(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
							{
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", axisCalibration.enabled.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Dead Zone", axisCalibration.deadZone.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Invert", axisCalibration.invert.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									tOOyCATDQWZFXUbwyTTYPCtfjumI.wqeFuMVSsAqmrNpHJlBjXFdUgZvaA("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Supports Vibration", joystick.supportsVibration.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Extension", (joystick.extension != null).ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				kxlwlPufdZMIPNVawLudZQLkcSJj(joystick, P_1, text);
			}
		}

		private static void QPFENDAkAvKIJClBdaDnAvGqzrlKA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Mouse", text, P_0);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", mouse.enabled.ToString());
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
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Screen Position", mouse.screenPosition.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Screen Position Prev", mouse.screenPositionPrev.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Screen Position Delta", mouse.screenPositionDelta.ToString());
			UbtOGZThlgANVeUDJOJKGhDcxsgjB(mouse.Axes, P_0, text);
			LJMcIIfarKfdnjhSBJeMFIyYDtQYb(mouse.Buttons, ControllerType.Mouse, P_0, text);
			YZkCFvnuXacYKBfEPlPrsJHALGFUA(mouse, P_0, text);
			kxlwlPufdZMIPNVawLudZQLkcSJj(mouse, P_0, text);
		}

		private static void hirSzZghuZjbFxlkSJhNUajWWdrO(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Keyboard", text, P_0);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", keyboard.enabled.ToString());
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
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			LJMcIIfarKfdnjhSBJeMFIyYDtQYb(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			YZkCFvnuXacYKBfEPlPrsJHALGFUA(keyboard, P_0, text);
			kxlwlPufdZMIPNVawLudZQLkcSJj(keyboard, P_0, text);
		}

		private static void KMNmXHSEmgPhNjegxpZauIgmOazQ(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + customController.name, text, P_1);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				id = customController.id;
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", id.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", customController.name);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Name", customController.hardwareName);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", customController.tag);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Identifier", customController.hardwareIdentifier);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", customController.enabled.ToString());
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
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				UbtOGZThlgANVeUDJOJKGhDcxsgjB(customController.Axes, P_1, text);
				LJMcIIfarKfdnjhSBJeMFIyYDtQYb(customController.Buttons, ControllerType.Custom, P_1, text);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis2D Count", customController.axis2DCount.ToString());
				using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6.bgKAfomhaaVldaYHKFZZsItvcocQ)
									{
										tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA7 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA7.bgKAfomhaaVldaYHKFZZsItvcocQ)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA8 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA8.bgKAfomhaaVldaYHKFZZsItvcocQ)
								{
									tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA9 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA9.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA10 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA10.bgKAfomhaaVldaYHKFZZsItvcocQ)
							{
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", axisCalibration.enabled.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Dead Zone", axisCalibration.deadZone.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Invert", axisCalibration.invert.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									tOOyCATDQWZFXUbwyTTYPCtfjumI.wqeFuMVSsAqmrNpHJlBjXFdUgZvaA("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Extension", (customController.extension != null).ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				kxlwlPufdZMIPNVawLudZQLkcSJj(customController, P_1, text);
			}
		}

		private static void DQbtqSsNQUTbtCkhdpNhcuaeUSGs(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Player Id", P_0.id.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", P_0.name);
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Descriptive Name", P_0.descriptiveName);
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Is Playing", P_0.isPlaying.ToString());
			using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Controllers", text + "_controllers", P_2))
			{
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					GgNjeHQgPKIyFcTbYZLqCfiPPycaA(controllers.Joysticks, P_2, text);
					KMNmXHSEmgPhNjegxpZauIgmOazQ(controllers.CustomControllers, P_2, text);
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Mouse", controllers.hasMouse.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Keyboard", controllers.hasKeyboard.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				}
			}
			string text2 = text + "_controllerMaps";
			using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Controller Maps", text2, P_2))
			{
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					kvTDsDzcfMyysPeqyhfgLfauigco(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					kvTDsDzcfMyysPeqyhfgLfauigco(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Joysticks (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								kvTDsDzcfMyysPeqyhfgLfauigco(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Custom Controllers (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							kvTDsDzcfMyysPeqyhfgLfauigco(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA7 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Layout Manager", text2, P_2))
			{
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA7.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					SoisEvczbrIQTuxYzZnUNuhgpmaK(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA8 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Map Enabler", text2, P_2))
			{
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA8.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					jriVxHdEIKhMpqLcVKinczXYoChJ(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			EcSKaTHVHJUSzEuBwqewNOpbPtXC(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(lCNomjNXrqfGyAMXHWyQtEswGPcs._003C_003E9.RNfgoDfBMtVMjxLdBshxXxofSLhr);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA9 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Actions (" + list.Count + ")", text2, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA9.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				BFIBKcgGzeLoaCUGdbPtQwTQMckAA bFIBKcgGzeLoaCUGdbPtQwTQMckAA = new BFIBKcgGzeLoaCUGdbPtQwTQMckAA();
				bFIBKcgGzeLoaCUGdbPtQwTQMckAA.DCDXJvSjNeEfrgKQznNotzLzJGgu = actionCategories[k];
				string text6 = text2 + "_actionCat" + bFIBKcgGzeLoaCUGdbPtQwTQMckAA.DCDXJvSjNeEfrgKQznNotzLzJGgu.id;
				int num = ListTools.Count(list, bFIBKcgGzeLoaCUGdbPtQwTQMckAA.hoHszZecuHIDDLhRbbOPVhrMQOQe);
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA10 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("id " + bFIBKcgGzeLoaCUGdbPtQwTQMckAA.DCDXJvSjNeEfrgKQznNotzLzJGgu.id + ": " + bFIBKcgGzeLoaCUGdbPtQwTQMckAA.DCDXJvSjNeEfrgKQznNotzLzJGgu.name + " (" + num + ")", text6, P_2);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA10.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != bFIBKcgGzeLoaCUGdbPtQwTQMckAA.DCDXJvSjNeEfrgKQznNotzLzJGgu.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA11 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA11.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Value", P_0.GetButton(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void EcSKaTHVHJUSzEuBwqewNOpbPtXC(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < num; i++)
				{
					jRZRPjnffOiKzsPAoPTyHelesRxp(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void jRZRPjnffOiKzsPAoPTyHelesRxp(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(P_1 + ": " + P_0.name, text, P_2);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", P_0.id.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", P_0.name);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Dead Zone", P_0.buttonDeadZone.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void YZkCFvnuXacYKBfEPlPrsJHALGFUA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
						{
							tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void LJMcIIfarKfdnjhSBJeMFIyYDtQYb(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Is Member Element", button.isMemberElement.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", button.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", button.valuePrev.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Pressure", button.pressure.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Pressure Prev", button.pressurePrev.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Just Pressed", button.justPressed.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Just Released", button.justReleased.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Just Double Pressed", button.justDoublePressed.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Pressed", button.timePressed.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Unpressed", button.timeUnpressed.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Pressed", button.lastTimePressed.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void UbtOGZThlgANVeUDJOJKGhDcxsgjB(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Is Member Element", axis.isMemberElement.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", axis.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Raw", axis.valueRaw.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", axis.valuePrev.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Raw Prev", axis.valueRawPrev.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Delta", axis.valueDelta.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Delta Raw", axis.valueDeltaRaw.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Active", axis.timeActive.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Active Raw", axis.timeActiveRaw.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Inactive", axis.timeInactive.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Active", axis.lastTimeActive.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Inactive", axis.lastTimeInactive.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void kvTDsDzcfMyysPeqyhfgLfauigco<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(P_2 + " (" + num + ")", text, P_3);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
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
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						ExYnJzyqjHyPFXcROqOENATpqPCj(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						xgCZUXxrGzzVaWySlpBFrFHKXuoj(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void xgCZUXxrGzzVaWySlpBFrFHKXuoj(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id (unique id)", P_0.id.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Source Map Id", P_0.sourceMapId.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", P_0.enabled.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Controller Id", P_0.controllerId.ToString());
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
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Category Id", text);
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
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					RfEIbZmdonyvqRlkdTebDGNPfNVeA(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void ExYnJzyqjHyPFXcROqOENATpqPCj(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			xgCZUXxrGzzVaWySlpBFrFHKXuoj(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					RfEIbZmdonyvqRlkdTebDGNPfNVeA(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void RfEIbZmdonyvqRlkdTebDGNPfNVeA(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = mpcdhREnKXVOmnTBGhLFNJluOdEmA(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id (unique id)", P_1.id.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Enabled", P_1.enabled.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Type", P_1.elementType.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Identifier Id", P_1.elementIdentifierId.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Index", P_1.elementIndex.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Range", P_1.axisRange.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Type", P_1.axisType.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Key Code", P_1.keyCode.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Modifiers", P_1.hasModifiers.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Modifier Key 1", P_1.modifierKey1.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Modifier Key 2", P_1.modifierKey2.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string mpcdhREnKXVOmnTBGhLFNJluOdEmA(ActionElementMap P_0)
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

		private static void SoisEvczbrIQTuxYzZnUNuhgpmaK(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (uVyiAJEXjIgBwNXjqxBUpFeDdlNh("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Rule Sets (" + count + ")", text, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < count; i++)
				{
					GDPIGVbGjtUnbMcXyuaSsOzqJmwBA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void GDPIGVbGjtUnbMcXyuaSsOzqJmwBA(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			if (uVyiAJEXjIgBwNXjqxBUpFeDdlNh("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", rule.tag);
				KoaOuvwggkfGaCdNAtOEdnYadfUw(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						if (num2 == 0)
						{
							tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void jriVxHdEIKhMpqLcVKinczXYoChJ(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (uVyiAJEXjIgBwNXjqxBUpFeDdlNh("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Rule Sets (" + count + ")", text, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < count; i++)
				{
					evEpjPGLHxkHIWeofYcfsGyKhlqc(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void evEpjPGLHxkHIWeofYcfsGyKhlqc(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			if (uVyiAJEXjIgBwNXjqxBUpFeDdlNh("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA4.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				if (uVyiAJEXjIgBwNXjqxBUpFeDdlNh("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Tag", rule.tag);
				KoaOuvwggkfGaCdNAtOEdnYadfUw(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA5.bgKAfomhaaVldaYHKFZZsItvcocQ)
					{
						if (num2 == 0)
						{
							tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA6.bgKAfomhaaVldaYHKFZZsItvcocQ)
				{
					continue;
				}
				if (num3 == 0)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void KoaOuvwggkfGaCdNAtOEdnYadfUw(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Controller Set Selector", text, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void kxlwlPufdZMIPNVawLudZQLkcSJj(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					VkldUevaWTCBJqmuBjfLLboqgYsY(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void VkldUevaWTCBJqmuBjfLLboqgYsY(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				return;
			}
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Type GUID", P_0.typeGuid.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA3.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					NmkXbEzLCNmnaCKmxrpENYXJmNtX(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void NmkXbEzLCNmnaCKmxrpENYXJmNtX(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Id", P_0.id.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Name", P_0.descriptiveName.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Type", P_0.type.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					QlbOWSSMltECoWlJjqNVnIjJxwPL(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					TsJsfCTOYoaYHewLktVNkHMKuUdD(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateDPad.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateDPad.up, "Up", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateDPad.right, "Right", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateDPad.down, "Down", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateHat.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateHat.valuePrev.ToString());
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.up, "up", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.right, "right", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.down, "down", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.left, "left", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateStick.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateStick.valuePrev.ToString());
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateThrottle.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateThumbStick.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					BrhBiPjkzmutJuAzuuRiEhqCCvNlA(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", controllerTemplateYoke.value.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Position", controllerTemplateStick6D.position.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Rotation", controllerTemplateStick6D.rotation.ToString());
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					UvabAfgSmOdYKMNNZiusGgCavMVxb(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void UvabAfgSmOdYKMNNZiusGgCavMVxb(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				TsJsfCTOYoaYHewLktVNkHMKuUdD(P_0, P_2, P_3);
			}
		}

		private static void BrhBiPjkzmutJuAzuuRiEhqCCvNlA(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				QlbOWSSMltECoWlJjqNVnIjJxwPL(P_0, P_2, P_3);
			}
		}

		private static void TsJsfCTOYoaYHewLktVNkHMKuUdD(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", P_0.value.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", P_0.valuePrev.ToString());
			pJMmYxoFIsCzppcimYAQcAVgncUj(P_0.source, "target", P_1, P_2);
		}

		private static void QlbOWSSMltECoWlJjqNVnIjJxwPL(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value", P_0.value.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Value Prev", P_0.valuePrev.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Pressure", P_0.pressure.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Pressure Prev", P_0.pressurePrev.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Just Pressed", P_0.justPressed.ToString());
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Just Released", P_0.justReleased.ToString());
			qPqgslkGFyeFOdCgUfRQStTmQoPM(P_0.source, "target", P_1, P_2);
		}

		private static void pJMmYxoFIsCzppcimYAQcAVgncUj(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA("Axis Target", P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Split Axis", P_0.splitAxis.ToString());
				IIcojQnTSwvOaYCTRefIpAzFeYv(P_0.fullTarget, "target", P_2, P_3);
				IIcojQnTSwvOaYCTRefIpAzFeYv(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				IIcojQnTSwvOaYCTRefIpAzFeYv(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void qPqgslkGFyeFOdCgUfRQStTmQoPM(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			IIcojQnTSwvOaYCTRefIpAzFeYv(P_0.target, "target", P_2, P_3);
		}

		private static void IIcojQnTSwvOaYCTRefIpAzFeYv(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using gbXbMPKYYsBFxfzFyVzzpZmKbXWkA gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2 = new gbXbMPKYYsBFxfzFyVzzpZmKbXWkA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (gbXbMPKYYsBFxfzFyVzzpZmKbXWkA2.bgKAfomhaaVldaYHKFZZsItvcocQ)
			{
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Element Identifier Id", P_0.elementIdentifierId.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Axis Range", P_0.axisRange.ToString());
				tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool uVyiAJEXjIgBwNXjqxBUpFeDdlNh(string P_0, bool P_1)
		{
			tOOyCATDQWZFXUbwyTTYPCtfjumI.OODbzIlgjJRmIZDNZhHwxlkghsECA(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle teRmENiHPfIlrCdFMgbMvPMLdklhb()
		{
			return uCreARttdeMQFHlRPyjLuqxTvBGd(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = oHsrffqUbZvNtzKULCkWfSndLLPWA._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = uCreARttdeMQFHlRPyjLuqxTvBGd(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = oHsrffqUbZvNtzKULCkWfSndLLPWA._fontSize;
			return gUIStyle;
		}

		private static GUIStyle uCreARttdeMQFHlRPyjLuqxTvBGd(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = azOgLNrptiABTLoGpyoLtcKZEaQT.wqysmZhoERcCzyGsMZYEnvYyoiZG * 20;
			return P_0;
		}
	}
}
