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
		private class oUEjXBXQFIRiyvFWQfOeEhIZXzkrA : IDisposable
		{
			public readonly bool pjPaXknvXEGAkgOyusMCUXyqIUSE;

			public oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				pjPaXknvXEGAkgOyusMCUXyqIUSE = mOzXDLghVbsPZgHESqrmUHNJhIVhA(P_0, P_1, P_2);
				ocVdDHiqMUbiKDRiZFKAPueWQskd.sMffQRkdzbALigUvkMsFTospGEfX++;
			}

			private bool mOzXDLghVbsPZgHESqrmUHNJhIVhA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return RPZpEZEVaGnVRIyCNBAZDCwduFLl(P_1, GUILayout.Toggle(MHBvjHUnCGlewGhHQlJdThTmrKhC(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool MHBvjHUnCGlewGhHQlJdThTmrKhC(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool RPZpEZEVaGnVRIyCNBAZDCwduFLl(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				ocVdDHiqMUbiKDRiZFKAPueWQskd.sMffQRkdzbALigUvkMsFTospGEfX--;
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}
		}

		private static class ocVdDHiqMUbiKDRiZFKAPueWQskd
		{
			private static int DmsRLEEbjCgWMVlrovITzOGimmiq;

			public static int sMffQRkdzbALigUvkMsFTospGEfX
			{
				get
				{
					return DmsRLEEbjCgWMVlrovITzOGimmiq;
				}
				set
				{
					DmsRLEEbjCgWMVlrovITzOGimmiq = Mathf.Max(0, b);
				}
			}
		}

		private static class jLTdbSOdMmJgIOptUfwPzCVwbDCdA
		{
			public static void hgbGFcqJdtCjAhOFNSEcXvUbAJyz()
			{
				GUILayout.BeginHorizontal();
			}

			public static void QHiXbqrxrIeAnyYcmcVIQHkNQnEu()
			{
				GUILayout.EndHorizontal();
			}

			public static void SeMWQQkZJuSeMAptemqWeuLRRslR()
			{
				GUILayout.BeginVertical();
			}

			public static void YnFXKRUJgKBUeWCeHoIiiVBXssXf()
			{
				GUILayout.EndVertical();
			}

			public static void qxPyqLlckvjqJNydgBzbGgtnXUbG(string P_0, ldQIjLBKNSOSVojCTAMrsXbFkof P_1)
			{
				GUILayout.Label(P_0, hKIAJHhxCJgQufhEbmYFFbcCUQGLd());
			}

			public static void SKmkSnmatTaRVVWlvivlPUnHOgiA(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, hKIAJHhxCJgQufhEbmYFFbcCUQGLd());
			}

			public static void axhSbWWwpeQLwZKIxksczRJZdxHT(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool ilVgFLipsujGvEIoHvjXCQJtOPWE(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, hKIAJHhxCJgQufhEbmYFFbcCUQGLd());
			}
		}

		private static class HNfmVBALrXKVUbkmokAoAYqYpJBl
		{
			[CompilerGenerated]
			private static float EoaQrHhigHbBcXAgqbVaAmuwxml;

			[CompilerGenerated]
			private static float ACBbyqQiABudpGluJZtWQujaFywr;

			public static float SVVQOlYeuFVTTkPBPiYEvkzbvHZo
			{
				[CompilerGenerated]
				get
				{
					return EoaQrHhigHbBcXAgqbVaAmuwxml;
				}
				[CompilerGenerated]
				set
				{
					EoaQrHhigHbBcXAgqbVaAmuwxml = eoaQrHhigHbBcXAgqbVaAmuwxml;
				}
			}

			public static float nnvzxYSbBQwKlKPgjeQMGtnBCEMQA
			{
				[CompilerGenerated]
				get
				{
					return ACBbyqQiABudpGluJZtWQujaFywr;
				}
				[CompilerGenerated]
				set
				{
					ACBbyqQiABudpGluJZtWQujaFywr = aCBbyqQiABudpGluJZtWQujaFywr;
				}
			}
		}

		internal enum ldQIjLBKNSOSVojCTAMrsXbFkof
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class lzSbzdSwqSehveOKfTTHJFIfhnWxA
		{
			public static readonly lzSbzdSwqSehveOKfTTHJFIfhnWxA _003C_003E9 = new lzSbzdSwqSehveOKfTTHJFIfhnWxA();

			public static Comparison<InputAction> _003C_003E9__16_0;

			internal int DKkxdNgfRLvlevQmdeMojyYarXFL(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class BjZlZwLVgKOTpGxFPRasURpDqGIv
		{
			public InputCategory HgAKItTjGQqKeqMNPeehiFtguaYLA;

			internal bool dKSAlVhyhlNtITOoTmOQbINHNycN(InputAction P_0)
			{
				return P_0.categoryId == HgAKItTjGQqKeqMNPeehiFtguaYLA.id;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _fontSize = 13;

		private static DebugInformation oehFoxGlmdcwibpPGnRRkiHbmvzuc;

		private IDictionary<string, bool> KwxpYFibqdnBtiBvswXhraleVhCF = new Dictionary<string, bool>();

		private static Vector2 bgnfcKAWWWDmaXXcBEhhgmPROREMA;

		private const string dRxCdpyiTfLvDkScUfdskWwkxnkL = "Rewired_DebugInformation";

		private const string SBgQeUmTMUpKGFIGdizwHxmqMffv = "Rewired Debug Information";

		private const int tRTBkFohRsQNBHBuIRLIsrIOQLfe = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			oehFoxGlmdcwibpPGnRRkiHbmvzuc = this;
			if (KwxpYFibqdnBtiBvswXhraleVhCF.Count == 0)
			{
				KwxpYFibqdnBtiBvswXhraleVhCF.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (oehFoxGlmdcwibpPGnRRkiHbmvzuc == this)
			{
				oehFoxGlmdcwibpPGnRRkiHbmvzuc = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			ocVdDHiqMUbiKDRiZFKAPueWQskd.sMffQRkdzbALigUvkMsFTospGEfX = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			bgnfcKAWWWDmaXXcBEhhgmPROREMA = GUILayout.BeginScrollView(bgnfcKAWWWDmaXXcBEhhgmPROREMA, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, KwxpYFibqdnBtiBvswXhraleVhCF);
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
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.hgbGFcqJdtCjAhOFNSEcXvUbAJyz();
			GUILayout.FlexibleSpace();
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.QHiXbqrxrIeAnyYcmcVIQHkNQnEu();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			HNfmVBALrXKVUbkmokAoAYqYpJBl.SVVQOlYeuFVTTkPBPiYEvkzbvHZo = lastRect.width - num2;
			HNfmVBALrXKVUbkmokAoAYqYpJBl.nnvzxYSbBQwKlKPgjeQMGtnBCEMQA = num2;
			ojOZljQnTkRHGfiZZTUiGBTmDuYg(enabled, foldouts);
			GUI.enabled = num;
			HNfmVBALrXKVUbkmokAoAYqYpJBl.SVVQOlYeuFVTTkPBPiYEvkzbvHZo = 0f;
			HNfmVBALrXKVUbkmokAoAYqYpJBl.nnvzxYSbBQwKlKPgjeQMGtnBCEMQA = 0f;
		}

		private static void ojOZljQnTkRHGfiZZTUiGBTmDuYg(bool P_0, IDictionary<string, bool> P_1)
		{
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Rewired Debug Information", "Rewired_DebugInformation", P_1);
			if (!ReInput.isReady || !P_0)
			{
				GUILayout.Label("There is no active Rewired Input Manager in the scene.");
			}
			else
			{
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					return;
				}
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Rewired Version", ReInput.programVersion);
				bool flag = ReInput.configuration.disableNativeInput;
				if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
				{
					flag = true;
				}
				if (flag)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.qxPyqLlckvjqJNydgBzbGgtnXUbG("Native input is disabled. Many special features are unavailable without native input.", ldQIjLBKNSOSVojCTAMrsXbFkof.Warning);
				}
				viIdESTcxhGlEmEQhVDSBvzGtezb(P_1, "Rewired_DebugInformation");
				string text = "Rewired_DebugInformation_controllers";
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Controllers", text, P_1);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					CCQYrXBaKwjNQJTgesebgVOSYSURA(ReInput.controllers.Joysticks, P_1, text);
					KjUACXFwhWbASIjhXQslCOWdpSXrA(ReInput.controllers.CustomControllers, P_1, text);
					UwOTEBJmVTThEApGHUoiRKwdCPLCA(P_1, "Rewired_DebugInformation");
					hLufqXrGxpvWGlTjeLMKgcBPYZVR(P_1, "Rewired_DebugInformation");
				}
				return;
			}
		}

		private static void viIdESTcxhGlEmEQhVDSBvzGtezb(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Players (" + ReInput.players.allPlayerCount + ")", text, P_0);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				int playerCount = ReInput.players.playerCount;
				for (int i = 0; i < playerCount; i++)
				{
					RTsfjQbqLahMckIaBdauCEWnUqaXA(ReInput.players.GetPlayer(i), i, P_0, text);
				}
				RTsfjQbqLahMckIaBdauCEWnUqaXA(ReInput.players.SystemPlayer, -1, P_0, text);
			}
		}

		private static void CCQYrXBaKwjNQJTgesebgVOSYSURA(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Joysticks (" + num + ")", P_2 + "_joysticks", P_1);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Joystick joystick = P_0[i];
				int id = joystick.id;
				string text = P_2 + "_joystick" + id;
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				id = joystick.id;
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id (unique id)", id.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", joystick.name);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Name", joystick.hardwareName);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", joystick.enabled.ToString());
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
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("System Id", joystick.systemId.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Identifier", joystick.hardwareIdentifier);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", joystick.tag);
				MHkdNRDGyCveMMOMrkaXoRlipCGvA(joystick.Axes, P_1, text);
				ZMRPLQrOemxGopgXrQBHmLGOcZqU(joystick.Buttons, ControllerType.Joystick, P_1, text);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis2D Count", joystick.axis2DCount.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hat Count", joystick.hatCount.ToString());
				GTtpGzwHCARpNlLZdDysannJZefMA(joystick, P_1, text);
				CalibrationMap calibrationMap = joystick.calibrationMap;
				using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						int axisCount = calibrationMap.axisCount;
						for (int k = 0; k < axisCount; k++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[k];
							using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1);
							if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
							{
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", axisCalibration.enabled.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Dead Zone", axisCalibration.deadZone.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Invert", axisCalibration.invert.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num2 = GUI.enabled;
									GUI.enabled = false;
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.axhSbWWwpeQLwZKIxksczRJZdxHT("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num2;
								}
								else
								{
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Supports Vibration", joystick.supportsVibration.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Extension", (joystick.extension != null).ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
				gTkdhFhCarczQDHfYNieAjvfvSnsA(joystick, P_1, text);
			}
		}

		private static void UwOTEBJmVTThEApGHUoiRKwdCPLCA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Mouse", text, P_0);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			Mouse mouse = ReInput.controllers.Mouse;
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", mouse.enabled.ToString());
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
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Screen Position", mouse.screenPosition.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Screen Position Prev", mouse.screenPositionPrev.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Screen Position Delta", mouse.screenPositionDelta.ToString());
			MHkdNRDGyCveMMOMrkaXoRlipCGvA(mouse.Axes, P_0, text);
			ZMRPLQrOemxGopgXrQBHmLGOcZqU(mouse.Buttons, ControllerType.Mouse, P_0, text);
			GTtpGzwHCARpNlLZdDysannJZefMA(mouse, P_0, text);
			gTkdhFhCarczQDHfYNieAjvfvSnsA(mouse, P_0, text);
		}

		private static void hLufqXrGxpvWGlTjeLMKgcBPYZVR(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Keyboard", text, P_0);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			Keyboard keyboard = ReInput.controllers.Keyboard;
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", keyboard.enabled.ToString());
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
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
			ZMRPLQrOemxGopgXrQBHmLGOcZqU(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
			GTtpGzwHCARpNlLZdDysannJZefMA(keyboard, P_0, text);
			gTkdhFhCarczQDHfYNieAjvfvSnsA(keyboard, P_0, text);
		}

		private static void KjUACXFwhWbASIjhXQslCOWdpSXrA(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				CustomController customController = P_0[i];
				int id = customController.id;
				string text = P_2 + "_customController" + id;
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + customController.name, text, P_1);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				id = customController.id;
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", id.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", customController.name);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Name", customController.hardwareName);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", customController.tag);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Identifier", customController.hardwareIdentifier);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", customController.enabled.ToString());
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
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				MHkdNRDGyCveMMOMrkaXoRlipCGvA(customController.Axes, P_1, text);
				ZMRPLQrOemxGopgXrQBHmLGOcZqU(customController.Buttons, ControllerType.Custom, P_1, text);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis2D Count", customController.axis2DCount.ToString());
				using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Element Identifiers", text + "_elementIdentifiers", P_1))
				{
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
						using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
						{
							if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
							{
								for (int k = 0; k < num2; k++)
								{
									ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
									using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(k + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
									if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6.pjPaXknvXEGAkgOyusMCUXyqIUSE)
									{
										jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
										jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
									}
								}
							}
						}
						num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
						using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA7 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1);
						if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA7.pjPaXknvXEGAkgOyusMCUXyqIUSE)
						{
							for (int l = 0; l < num2; l++)
							{
								ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
								using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA8 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(l + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
								if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA8.pjPaXknvXEGAkgOyusMCUXyqIUSE)
								{
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
								}
							}
						}
					}
				}
				CalibrationMap calibrationMap = customController.calibrationMap;
				using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA9 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Calibration Map", text + "_calibrationMap", P_1))
				{
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA9.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						int num2 = calibrationMap.axisCount;
						for (int m = 0; m < num2; m++)
						{
							AxisCalibration axisCalibration = calibrationMap.Axes[m];
							using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA10 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1);
							if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA10.pjPaXknvXEGAkgOyusMCUXyqIUSE)
							{
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", axisCalibration.enabled.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Max", axisCalibration.calibratedMax.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Min", axisCalibration.calibratedMin.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Calibrated Zero", axisCalibration.calibratedZero.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Dead Zone", axisCalibration.deadZone.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Invert", axisCalibration.invert.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity Type", axisCalibration.sensitivityType.ToString());
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity", axisCalibration.sensitivity.ToString());
								if (axisCalibration.sensitivityCurve != null)
								{
									bool num3 = GUI.enabled;
									GUI.enabled = false;
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.axhSbWWwpeQLwZKIxksczRJZdxHT("Sensitivity Curve", axisCalibration.sensitivityCurve);
									GUI.enabled = num3;
								}
								else
								{
									jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Sensitivity Curve", "--");
								}
							}
						}
					}
				}
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Extension", (customController.extension != null).ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
				gTkdhFhCarczQDHfYNieAjvfvSnsA(customController, P_1, text);
			}
		}

		private static void RTsfjQbqLahMckIaBdauCEWnUqaXA(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Player Id", P_0.id.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", P_0.name);
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Descriptive Name", P_0.descriptiveName);
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Is Playing", P_0.isPlaying.ToString());
			using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Controllers", text + "_controllers", P_2))
			{
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					Player.ControllerHelper controllers = P_0.controllers;
					CCQYrXBaKwjNQJTgesebgVOSYSURA(controllers.Joysticks, P_2, text);
					KjUACXFwhWbASIjhXQslCOWdpSXrA(controllers.CustomControllers, P_2, text);
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Mouse", controllers.hasMouse.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Keyboard", controllers.hasKeyboard.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
				}
			}
			string text2 = text + "_controllerMaps";
			using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Controller Maps", text2, P_2))
			{
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					oBSDMVehggBRrJlxQKErvuMjpICw(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
					oBSDMVehggBRrJlxQKErvuMjpICw(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
					string text3 = text2 + "_joystickMaps";
					using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
					{
						if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
						{
							for (int i = 0; i < P_0.controllers.joystickCount; i++)
							{
								Joystick joystick = P_0.controllers.Joysticks[i];
								IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
								string text4 = text3;
								int id = joystick.id;
								text3 = text4 + "_joystickId" + id;
								oBSDMVehggBRrJlxQKErvuMjpICw(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
							}
						}
					}
					text3 = text2 + "_customControllerMaps";
					using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2);
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						for (int j = 0; j < P_0.controllers.customControllerCount; j++)
						{
							CustomController customController = P_0.controllers.CustomControllers[j];
							IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							string text5 = text3;
							int id = customController.id;
							text3 = text5 + "_customControllerId" + id;
							oBSDMVehggBRrJlxQKErvuMjpICw(ControllerType.Custom, maps2, customController.name, P_2, text3);
						}
					}
				}
			}
			text2 = text + "_controllerMapLayoutManager";
			using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA7 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Layout Manager", text2, P_2))
			{
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA7.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					WUjERllvsZvxMaQXRoaHtjHrzZOr(P_0.controllers.maps.layoutManager, P_2, text2);
				}
			}
			text2 = text + "_controllerMapEnabler";
			using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA8 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Map Enabler", text2, P_2))
			{
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA8.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					frBSBGsPoJEiBqbdUtkbEbfPMTKc(P_0.controllers.maps.mapEnabler, P_2, text2);
				}
			}
			text2 = text + "_inputBehaviors";
			WiPRDDKyMtlPcGHhQNUpfykcpvbg(P_0.controllers.maps.InputBehaviors, P_2, text2);
			text2 = text + "_actions";
			List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
			list.Sort(lzSbzdSwqSehveOKfTTHJFIfhnWxA._003C_003E9.DKkxdNgfRLvlevQmdeMojyYarXFL);
			IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA9 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Actions (" + list.Count + ")", text2, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA9.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int k = 0; k < actionCategories.Count; k++)
			{
				BjZlZwLVgKOTpGxFPRasURpDqGIv bjZlZwLVgKOTpGxFPRasURpDqGIv = new BjZlZwLVgKOTpGxFPRasURpDqGIv();
				bjZlZwLVgKOTpGxFPRasURpDqGIv.HgAKItTjGQqKeqMNPeehiFtguaYLA = actionCategories[k];
				string text6 = text2 + "_actionCat" + bjZlZwLVgKOTpGxFPRasURpDqGIv.HgAKItTjGQqKeqMNPeehiFtguaYLA.id;
				int num = ListTools.Count(list, bjZlZwLVgKOTpGxFPRasURpDqGIv.dKSAlVhyhlNtITOoTmOQbINHNycN);
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA10 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("id " + bjZlZwLVgKOTpGxFPRasURpDqGIv.HgAKItTjGQqKeqMNPeehiFtguaYLA.id + ": " + bjZlZwLVgKOTpGxFPRasURpDqGIv.HgAKItTjGQqKeqMNPeehiFtguaYLA.name + " (" + num + ")", text6, P_2);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA10.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				for (int l = 0; l < list.Count; l++)
				{
					InputAction inputAction = list[l];
					if (inputAction.categoryId != bjZlZwLVgKOTpGxFPRasURpDqGIv.HgAKItTjGQqKeqMNPeehiFtguaYLA.id)
					{
						continue;
					}
					string text7 = text6 + "_actionId" + inputAction.id;
					using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA11 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text7, P_2);
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA11.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Value", P_0.GetAxis(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Value", P_0.GetButton(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
						jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
					}
				}
			}
		}

		private static void WiPRDDKyMtlPcGHhQNUpfykcpvbg(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < num; i++)
				{
					blWSkrimPcvEcwPUOoYnnVBblUBC(P_0[i], i, P_1, P_2);
				}
			}
		}

		private static void blWSkrimPcvEcwPUOoYnnVBblUBC(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(P_1 + ": " + P_0.name, text, P_2);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", P_0.id.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", P_0.name);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Dead Zone", P_0.buttonDeadZone.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Short Press Time", P_0.buttonShortPressTime.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Long Press Time", P_0.buttonLongPressTime.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Button Down Buffer", P_0.buttonDownBuffer.ToString());
			}
		}

		private static void GTtpGzwHCARpNlLZdDysannJZefMA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Element Identifiers", P_2 + "_elementIdentifiers", P_1);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			int num;
			if (P_0 is ControllerWithAxes)
			{
				ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
				num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					for (int i = 0; i < num; i++)
					{
						ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
						using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
						if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
						{
							jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
							jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", controllerElementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
						}
					}
				}
			}
			if (P_0 == null)
			{
				return;
			}
			num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int j = 0; j < num; j++)
			{
				ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(j + ": " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + " (id: " + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, P_1);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", controllerElementIdentifier2.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename);
				}
			}
		}

		private static void ZMRPLQrOemxGopgXrQBHmLGOcZqU(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(obj + "s (" + num + ")", P_3 + "_Buttons", P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Button button = P_0[i];
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Is Member Element", button.isMemberElement.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Is Pressure Sensitive", button.isPressureSensitive.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", button.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", button.valuePrev.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Pressure", button.pressure.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Pressure Prev", button.pressurePrev.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Just Pressed", button.justPressed.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Just Released", button.justReleased.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Just Double Pressed", button.justDoublePressed.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Double Pressed And Held", button.doublePressedAndHeld.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Pressed", button.timePressed.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Unpressed", button.timeUnpressed.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Pressed", button.lastTimePressed.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Unpressed", button.lastTimeUnpressed.ToString());
				}
			}
		}

		private static void MHkdNRDGyCveMMOMrkaXoRlipCGvA(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Axes (" + num + ")", P_2 + "_Axes", P_1);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				Controller.Axis axis = P_0[i];
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + axis.elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Is Member Element", axis.isMemberElement.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", axis.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Raw", axis.valueRaw.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", axis.valuePrev.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Raw Prev", axis.valueRawPrev.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Delta", axis.valueDelta.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Delta Raw", axis.valueDeltaRaw.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Active", axis.timeActive.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Active Raw", axis.timeActiveRaw.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Inactive", axis.timeInactive.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Time Inactive Raw", axis.timeInactiveRaw.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Active", axis.lastTimeActive.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Inactive", axis.lastTimeInactive.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
				}
			}
		}

		private static void oBSDMVehggBRrJlxQKErvuMjpICw<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(P_2 + " (" + num + ")", text, P_3);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
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
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3);
				if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					if (P_1[i] is ControllerMapWithAxes)
					{
						AQNihetuEzBgAFSgePBBngbiUOiJ(P_1[i] as ControllerMapWithAxes, P_3, text + i);
					}
					else
					{
						pZZEJzuJLJKnQMhbREGkPlLFjEZb(P_1[i], P_3, text + i);
					}
				}
			}
		}

		private static void pZZEJzuJLJKnQMhbREGkPlLFjEZb(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id (unique id)", P_0.id.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Source Map Id", P_0.sourceMapId.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", P_0.enabled.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Controller Id", P_0.controllerId.ToString());
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
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Category Id", text);
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
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Button Maps (" + buttonMapCount + ")", text3, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < buttonMapCount; i++)
				{
					HcHZuPvznXlCnDpjVBPwpwzIbrfk(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
				}
			}
		}

		private static void AQNihetuEzBgAFSgePBBngbiUOiJ(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			pZZEJzuJLJKnQMhbREGkPlLFjEZb(P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Axis Maps (" + axisMapCount + ")", text, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < axisMapCount; i++)
				{
					HcHZuPvznXlCnDpjVBPwpwzIbrfk(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
				}
			}
		}

		private static void HcHZuPvznXlCnDpjVBPwpwzIbrfk(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = iIbpiPqrBzClvVsGcLeMjbRhcHcGA(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(P_2 + ": " + text, P_4 + "_" + P_2, P_3);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id (unique id)", P_1.id.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Enabled", P_1.enabled.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Type", P_1.elementType.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Identifier Id", P_1.elementIdentifierId.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Identifier Name", P_1.elementIdentifierName);
			if (P_1.elementType == ControllerElementType.Axis)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Index", P_1.elementIndex.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Range", P_1.axisRange.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Type", P_1.axisType.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Invert", P_1.invert.ToString());
			}
			else if (P_1.elementType == ControllerElementType.Button)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Index", P_1.elementIndex.ToString());
				if (P_0 == ControllerType.Keyboard)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Key Code", P_1.keyCode.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Modifiers", P_1.hasModifiers.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Modifier Key 1", P_1.modifierKey1.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Modifier Key 2", P_1.modifierKey2.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Modifier Key 3", P_1.modifierKey3.ToString());
				}
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Contribution", P_1.axisContribution.ToString());
		}

		private static string iIbpiPqrBzClvVsGcLeMjbRhcHcGA(ActionElementMap P_0)
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

		private static void WUjERllvsZvxMaQXRoaHtjHrzZOr(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (gSjjDBXGKkXrdHhGIkINZJMQjDzq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Rule Sets (" + count + ")", text, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < count; i++)
				{
					CxAQPRFMyNQxymzOMJCDqGLvGQUw(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void CxAQPRFMyNQxymzOMJCDqGLvGQUw(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			if (gSjjDBXGKkXrdHhGIkINZJMQjDzq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapLayoutManager_002ERule_003E_002ECount + ")", text, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapLayoutManager.Rule rule = P_0[i];
				string text2 = text + i;
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", rule.tag);
				SHzRExzDfCfutSOWqfQHFksdPomi(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						if (num2 == 0)
						{
							jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Category " + j, text3);
							}
						}
					}
				}
				InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
			}
		}

		private static void frBSBGsPoJEiBqbdUtkbEbfPMTKc(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (gSjjDBXGKkXrdHhGIkINZJMQjDzq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Rule Sets (" + count + ")", text, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < count; i++)
				{
					uRHquvNlMFBDUSElFgfdWSuPDZBCA(P_0.ruleSets[i], i, P_1, text + i);
				}
			}
		}

		private static void uRHquvNlMFBDUSElFgfdWSuPDZBCA(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount ?? 0;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			if (gSjjDBXGKkXrdHhGIkINZJMQjDzq("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", P_0.tag);
			string text = P_3 + "_rules";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Rules (" + P_0.System_002ECollections_002EGeneric_002EICollection_00601_003CRewired_002EControllerMapEnabler_002ERule_003E_002ECount + ")", text, P_2);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				ControllerMapEnabler.Rule rule = P_0[i];
				string text2 = text + i;
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA4.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				if (gSjjDBXGKkXrdHhGIkINZJMQjDzq("Enable", rule.enable))
				{
					rule.enable = !rule.enable;
				}
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Tag", rule.tag);
				SHzRExzDfCfutSOWqfQHFksdPomi(rule.controllerSetSelector, P_2, text2);
				int[] categoryIds = rule.categoryIds;
				int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
				using (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
				{
					if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA5.pjPaXknvXEGAkgOyusMCUXyqIUSE)
					{
						if (num2 == 0)
						{
							jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Category", "All Map Categories");
						}
						else
						{
							for (int j = 0; j < categoryIds.Length; j++)
							{
								InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
								string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
								jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Category " + j, text3);
							}
						}
					}
				}
				int[] layoutIds = rule.layoutIds;
				int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
				using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2);
				if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA6.pjPaXknvXEGAkgOyusMCUXyqIUSE)
				{
					continue;
				}
				if (num3 == 0)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
					continue;
				}
				for (int k = 0; k < layoutIds.Length; k++)
				{
					InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
					string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
				}
			}
		}

		private static void SHzRExzDfCfutSOWqfQHFksdPomi(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Controller Set Selector", text, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
				if (P_0.type != ControllerSetSelector.Type.All)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Controller Type", P_0.controllerType.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.HardwareType)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Hardware Identifier", P_0.hardwareIdentifier);
				}
				if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
				}
				if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Controller Id", P_0.controllerId.ToString());
				}
			}
		}

		private static void gTkdhFhCarczQDHfYNieAjvfvSnsA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Templates (" + P_0.templateCount + ")", P_2, P_1);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < P_0.templateCount; i++)
				{
					JNowGymFpdujKwfpxYOMvyYhsUOF(P_0.Templates[i], i, P_2, P_1);
				}
			}
		}

		private static void JNowGymFpdujKwfpxYOMvyYhsUOF(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3);
			if (!oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				return;
			}
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Type GUID", P_0.typeGuid.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Class Type", P_0.GetType().ToString());
			P_2 += "_elements";
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Elements (" + P_0.elementCount + ")", P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA3.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				for (int i = 0; i < P_0.elementCount; i++)
				{
					BPtkaYshJjAKlMUhHEEBtGpIulFr(P_0.elements[i], i, P_2, P_3);
				}
			}
		}

		private static void BPtkaYshJjAKlMUhHEEBtGpIulFr(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Id", P_0.id.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Name", P_0.descriptiveName.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Type", P_0.type.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Exists", P_0.exists.ToString());
				if (P_0.type == ControllerTemplateElementType.Button)
				{
					IRudPWbVcXbhviMMVXaUIXPdUNlUb(P_0 as IControllerTemplateButton, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Axis)
				{
					LEfjGgCVIiJGauzSmOAeAhJwCPSA(P_0 as IControllerTemplateAxis, P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.DPad)
				{
					IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateDPad.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateDPad.valuePrev.ToString());
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateDPad.up, "Up", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateDPad.right, "Right", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateDPad.down, "Down", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateDPad.left, "Left", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Hat)
				{
					IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateHat.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateHat.valuePrev.ToString());
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.up, "up", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.upRight, "upRight", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.right, "right", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.downRight, "downRight", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.down, "down", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.left, "left", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick)
				{
					IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateStick.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateStick.valuePrev.ToString());
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick.vertical, "vertical", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick.rotation, "rotation", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Throttle)
				{
					IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateThrottle.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.ThumbStick)
				{
					IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateThumbStick.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
					PuaLlBbIeIMMGEWgOkafPQOPPVjs(controllerTemplateThumbStick.press, "press", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Yoke)
				{
					IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", controllerTemplateYoke.value.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", controllerTemplateYoke.valuePrev.ToString());
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
				}
				else if (P_0.type == ControllerTemplateElementType.Stick6D)
				{
					IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Position", controllerTemplateStick6D.position.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Rotation", controllerTemplateStick6D.rotation.ToString());
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
					GphmXrXwpitbFVySptTlAowubsvt(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
				}
				else
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Unknown element type", P_0.type.ToString());
				}
			}
		}

		private static void GphmXrXwpitbFVySptTlAowubsvt(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				LEfjGgCVIiJGauzSmOAeAhJwCPSA(P_0, P_2, P_3);
			}
		}

		private static void PuaLlBbIeIMMGEWgOkafPQOPPVjs(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				IRudPWbVcXbhviMMVXaUIXPdUNlUb(P_0, P_2, P_3);
			}
		}

		private static void LEfjGgCVIiJGauzSmOAeAhJwCPSA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", P_0.value.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", P_0.valuePrev.ToString());
			lJxbfvpKKnxexlfCnoVYPzlFqoI(P_0.source, "target", P_1, P_2);
		}

		private static void IRudPWbVcXbhviMMVXaUIXPdUNlUb(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value", P_0.value.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Value Prev", P_0.valuePrev.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Pressure", P_0.pressure.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Pressure Prev", P_0.pressurePrev.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Just Pressed", P_0.justPressed.ToString());
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Just Released", P_0.justReleased.ToString());
			mmxbjhzvYKhLVvMpmDcDwDtjNKrs(P_0.source, "target", P_1, P_2);
		}

		private static void lJxbfvpKKnxexlfCnoVYPzlFqoI(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA("Axis Target", P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Split Axis", P_0.splitAxis.ToString());
				UcDncxTSCkKuTcFPpBisomqcGPoJ(P_0.fullTarget, "target", P_2, P_3);
				UcDncxTSCkKuTcFPpBisomqcGPoJ(P_0.positiveTarget, "positiveTarget", P_2, P_3);
				UcDncxTSCkKuTcFPpBisomqcGPoJ(P_0.negativeTarget, "negativeTarget", P_2, P_3);
			}
		}

		private static void mmxbjhzvYKhLVvMpmDcDwDtjNKrs(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			UcDncxTSCkKuTcFPpBisomqcGPoJ(P_0.target, "target", P_2, P_3);
		}

		private static void UcDncxTSCkKuTcFPpBisomqcGPoJ(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using oUEjXBXQFIRiyvFWQfOeEhIZXzkrA oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2 = new oUEjXBXQFIRiyvFWQfOeEhIZXzkrA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3);
			if (oUEjXBXQFIRiyvFWQfOeEhIZXzkrA2.pjPaXknvXEGAkgOyusMCUXyqIUSE)
			{
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Element Identifier Id", P_0.elementIdentifierId.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Axis Range", P_0.axisRange.ToString());
				jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Has Target", P_0.hasTarget.ToString());
				if (P_0.hasTarget)
				{
					jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA("Target Element", P_0.descriptiveName);
				}
			}
		}

		private static bool gSjjDBXGKkXrdHhGIkINZJMQjDzq(string P_0, bool P_1)
		{
			jLTdbSOdMmJgIOptUfwPzCVwbDCdA.SKmkSnmatTaRVVWlvivlPUnHOgiA(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle hKIAJHhxCJgQufhEbmYFFbcCUQGLd()
		{
			return gZshrDgLaGvlIVkabVVOCwWELyyE(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = oehFoxGlmdcwibpPGnRRkiHbmvzuc._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = gZshrDgLaGvlIVkabVVOCwWELyyE(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = oehFoxGlmdcwibpPGnRRkiHbmvzuc._fontSize;
			return gUIStyle;
		}

		private static GUIStyle gZshrDgLaGvlIVkabVVOCwWELyyE(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = ocVdDHiqMUbiKDRiZFKAPueWQskd.sMffQRkdzbALigUvkMsFTospGEfX * 20;
			return P_0;
		}
	}
}
