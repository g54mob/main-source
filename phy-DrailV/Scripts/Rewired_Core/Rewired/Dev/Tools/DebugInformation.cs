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
		private class tueUGrgAFRWspWHnNyYtXNwgGmIA : IDisposable
		{
			public readonly bool cDCFjaTmPlyARcuxprWDeBqRdeTC;

			public tueUGrgAFRWspWHnNyYtXNwgGmIA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				cDCFjaTmPlyARcuxprWDeBqRdeTC = rvqeqfzNQJTknxBiGeTRKBTFRwzgA(P_0, P_1, P_2);
				vHdHaMNlrHfRQcaUkszsFEztsfuQ.PFRWMgXIkCDBuNShXjcbQNKnGiMz++;
			}

			private bool rvqeqfzNQJTknxBiGeTRKBTFRwzgA(string P_0, string P_1, IDictionary<string, bool> P_2)
			{
				return fElLeNKMSAhlcJPwietTbUUphCeJA(P_1, GUILayout.Toggle(XFKgPkLXhqoueziYelpurcVJnstA(P_1, P_2), new GUIContent(P_0, P_0), GetToggleStyle()), P_2);
			}

			private bool XFKgPkLXhqoueziYelpurcVJnstA(string P_0, IDictionary<string, bool> P_1)
			{
				if (!P_1.ContainsKey(P_0))
				{
					P_1.Add(P_0, value: false);
				}
				return P_1[P_0];
			}

			private bool fElLeNKMSAhlcJPwietTbUUphCeJA(string P_0, bool P_1, IDictionary<string, bool> P_2)
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
				vHdHaMNlrHfRQcaUkszsFEztsfuQ.PFRWMgXIkCDBuNShXjcbQNKnGiMz--;
			}
		}

		private static class vHdHaMNlrHfRQcaUkszsFEztsfuQ
		{
			private static int IhJHTIjVVoMEgdoHQCfkgwQwcvYLA;

			public static int PFRWMgXIkCDBuNShXjcbQNKnGiMz
			{
				get
				{
					return IhJHTIjVVoMEgdoHQCfkgwQwcvYLA;
				}
				set
				{
					IhJHTIjVVoMEgdoHQCfkgwQwcvYLA = Mathf.Max(0, b);
				}
			}
		}

		private static class mNnTeNvATbZWIzmgbLGpdISPtyMK
		{
			public static void ahcEAaAUcmiFWjoLHFEZhWuFrKBbb()
			{
				GUILayout.BeginHorizontal();
			}

			public static void lHFfifjBLkSTlsFvjSbYmhReAEYj()
			{
				GUILayout.EndHorizontal();
			}

			public static void zteVrrMhbkiMqGSvlTnyiyxJRuKoA()
			{
				GUILayout.BeginVertical();
			}

			public static void BatRgAPRuifdtHfgQuacgfwgLNTHA()
			{
				GUILayout.EndVertical();
			}

			public static void GivSYFoDNmoiKvvGFQhiVwkdgnfJ(string P_0, gqFKJocYDMPwGuQqjhpatvOMRgyS P_1)
			{
				GUILayout.Label(P_0, TYBLtPLvtLKilVkMVfWoHpnItTRbA());
			}

			public static void OkwTIfHkjzKBvNRiKVYAYYDXxfYE(string P_0, string P_1)
			{
				GUILayout.Label(P_0 + ": " + P_1, TYBLtPLvtLKilVkMVfWoHpnItTRbA());
			}

			public static void ihQDSbHOyfewvWuqxGoqNzmybogc(string P_0, AnimationCurve P_1)
			{
				GUILayout.Label(P_0 + ": Curves are not visualized by this tool.");
			}

			public static bool PpjYAcKSHhrqQHFnEGDwuxFiaYMc(string P_0, bool P_1)
			{
				return GUILayout.Toggle(P_1, P_0, TYBLtPLvtLKilVkMVfWoHpnItTRbA());
			}
		}

		private static class SFZslKlkwQIcEUTxZITQKGnxBGZt
		{
			[CompilerGenerated]
			private static float BjVAWsnEzVBCKKtLvrhWAXoEVQPeA;

			[CompilerGenerated]
			private static float BytboOrzWjJmPkLzUVQHInttQNDt;

			public static float SZTjOhDYPAazrBAABzYsbOwzpcoM
			{
				[CompilerGenerated]
				get
				{
					return BjVAWsnEzVBCKKtLvrhWAXoEVQPeA;
				}
				[CompilerGenerated]
				set
				{
					BjVAWsnEzVBCKKtLvrhWAXoEVQPeA = bjVAWsnEzVBCKKtLvrhWAXoEVQPeA;
				}
			}

			public static float JGtRnCfOBGOCvaETwhpgKSkMcQR
			{
				[CompilerGenerated]
				get
				{
					return BytboOrzWjJmPkLzUVQHInttQNDt;
				}
				[CompilerGenerated]
				set
				{
					BytboOrzWjJmPkLzUVQHInttQNDt = bytboOrzWjJmPkLzUVQHInttQNDt;
				}
			}
		}

		internal enum gqFKJocYDMPwGuQqjhpatvOMRgyS
		{
			None = 0,
			Info = 1,
			Warning = 2,
			Error = 3
		}

		[Serializable]
		private sealed class uVcacihapNORvxnZWBhdCLJUpUIOA
		{
			public static readonly uVcacihapNORvxnZWBhdCLJUpUIOA _003C_003E9 = new uVcacihapNORvxnZWBhdCLJUpUIOA();

			public static Comparison<InputAction> _003C_003E9__17_0;

			internal int NnzQAsHzBMTyGwAraRmWsvvjuBkI(InputAction P_0, InputAction P_1)
			{
				return P_0.name.CompareTo(P_1.name);
			}
		}

		private sealed class ztTiZspYuFHuFoGVJgVzObxqVQfO
		{
			public InputCategory hePjFDSVuvEgMZpONbVloFpyTzLf;

			internal bool JKMtPciEAApFLLVNaAAIhYYhuJgG(InputAction P_0)
			{
				return P_0.categoryId == hePjFDSVuvEgMZpONbVloFpyTzLf.id;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _fontSize = 13;

		private static DebugInformation ngWWJQOmNpFGXgzPCBggBNDROQLkA;

		private IDictionary<string, bool> OYFEtKxHZSbxKguWklojQzVGawsSA = new Dictionary<string, bool>();

		private static Vector2 ojawOlymOqgoAsQfbDHiomCtLYBV;

		private const string XHSGblYPEnVqalgSuEMKBJfNEphp = "Rewired_DebugInformation";

		private const string hwZpwcnsTrmQZCzipqIOLpoeOrjq = "Rewired Debug Information";

		private const int JsrsZUlvWUiBbHeZFxqzBRbDOPlG = 20;

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			ngWWJQOmNpFGXgzPCBggBNDROQLkA = this;
			if (OYFEtKxHZSbxKguWklojQzVGawsSA.Count == 0)
			{
				OYFEtKxHZSbxKguWklojQzVGawsSA.Add("Rewired_DebugInformation", value: true);
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			if (ngWWJQOmNpFGXgzPCBggBNDROQLkA == this)
			{
				ngWWJQOmNpFGXgzPCBggBNDROQLkA = null;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			vHdHaMNlrHfRQcaUkszsFEztsfuQ.PFRWMgXIkCDBuNShXjcbQNKnGiMz = 0;
			GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
			ojawOlymOqgoAsQfbDHiomCtLYBV = GUILayout.BeginScrollView(ojawOlymOqgoAsQfbDHiomCtLYBV, GUILayout.ExpandWidth(expand: true), GUILayout.ExpandHeight(expand: true));
			DrawDebugInformation(enabled: true, OYFEtKxHZSbxKguWklojQzVGawsSA);
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
			mNnTeNvATbZWIzmgbLGpdISPtyMK.ahcEAaAUcmiFWjoLHFEZhWuFrKBbb();
			GUILayout.FlexibleSpace();
			mNnTeNvATbZWIzmgbLGpdISPtyMK.lHFfifjBLkSTlsFvjSbYmhReAEYj();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = lastRect.width / 3f;
			SFZslKlkwQIcEUTxZITQKGnxBGZt.SZTjOhDYPAazrBAABzYsbOwzpcoM = lastRect.width - num2;
			SFZslKlkwQIcEUTxZITQKGnxBGZt.JGtRnCfOBGOCvaETwhpgKSkMcQR = num2;
			hAewuYPZRhdgfkahjDWIIBLyysBx(enabled, foldouts);
			GUI.enabled = num;
			SFZslKlkwQIcEUTxZITQKGnxBGZt.SZTjOhDYPAazrBAABzYsbOwzpcoM = 0f;
			SFZslKlkwQIcEUTxZITQKGnxBGZt.JGtRnCfOBGOCvaETwhpgKSkMcQR = 0f;
		}

		private static void hAewuYPZRhdgfkahjDWIIBLyysBx(bool P_0, IDictionary<string, bool> P_1)
		{
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Rewired Debug Information", "Rewired_DebugInformation", P_1))
			{
				if (!ReInput.isReady || !P_0)
				{
					GUILayout.Label("There is no active Rewired Input Manager in the scene.");
				}
				else
				{
					if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						return;
					}
					OWnFDXcxssIfaWwWXbfCCiOHzGhwB(P_1, "Rewired_DebugInformation");
					bool flag = ReInput.configuration.disableNativeInput;
					if (!flag && (ReInput.currentPlatform == Platform.Windows || ReInput.currentPlatform == Platform.OSX) && ReInput.primaryInputManager.inputSourceType == InputSource.Fallback)
					{
						flag = true;
					}
					if (flag)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.GivSYFoDNmoiKvvGFQhiVwkdgnfJ("Native input is disabled. Many special features are unavailable without native input.", gqFKJocYDMPwGuQqjhpatvOMRgyS.Warning);
					}
					DZwdJrEGASIAljRyuPSOxrzvlqQrA(P_1, "Rewired_DebugInformation");
					string text = "Rewired_DebugInformation_controllers";
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Controllers", text, P_1))
					{
						if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							bUoycruDyDxcfUcNdnqtqnxiYRBI(ReInput.controllers.Joysticks, P_1, text);
							zxxlhoCNiivihrtunBZuFPzKgUwJ(ReInput.controllers.CustomControllers, P_1, text);
							ypeQMwMtUlpNxLnPCkbWqJPQSPDe(P_1, "Rewired_DebugInformation");
							KVeCpIJtuScNItGXySYASNYaIDVd(P_1, "Rewired_DebugInformation");
						}
						return;
					}
				}
			}
		}

		private static void OWnFDXcxssIfaWwWXbfCCiOHzGhwB(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_info";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Info", text, P_0))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Rewired Version", ReInput.programVersion);
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Platform", ReInput.currentPlatform.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Primary Input Source", ReInput.primaryInputManager.inputSourceType.ToString());
					if (ReInput.currentPlatform == Platform.Windows)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Use Windows Gaming Input", ReInput.configuration.useWindowsGamingInput.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Use XInput", ReInput.configuration.useXInput.ToString());
					}
					else if (ReInput.currentPlatform == Platform.WindowsUWP)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Support HID Devices", ReInput.configuration.windowsUWPSupportHIDDevices.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Support Gamepads", ReInput.configuration.windowsUWPSupportGamepads.ToString());
					}
					else if (ReInput.currentPlatform == Platform.OSX)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Use Game Controller Framework", ReInput.configuration.useAppleGameControllerFramework.ToString());
					}
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enhanced Device Support", ReInput.configuration.enhancedDeviceSupport.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Native Keyboard Handling", ReInput.configuration.nativeKeyboardSupport.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Physical Key Mapping", ReInput.configVars.unityUsePhysicalKeys.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Native Mouse Handling", ReInput.configuration.nativeMouseSupport.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Ignore Input When App Not in Focus", ReInput.configuration.ignoreInputWhenAppNotInFocus.ToString());
				}
			}
		}

		private static void DZwdJrEGASIAljRyuPSOxrzvlqQrA(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_players";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Players (" + ReInput.players.allPlayerCount + ")", text, P_0))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					int playerCount = ReInput.players.playerCount;
					for (int i = 0; i < playerCount; i++)
					{
						VItOdUvamxIwUKNTViLGSPYRcbRFA(ReInput.players.GetPlayer(i), i, P_0, text);
					}
					VItOdUvamxIwUKNTViLGSPYRcbRFA(ReInput.players.SystemPlayer, -1, P_0, text);
				}
			}
		}

		private static void bUoycruDyDxcfUcNdnqtqnxiYRBI(IList<Joystick> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Joysticks (" + num + ")", P_2 + "_joysticks", P_1))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				for (int i = 0; i < num; i++)
				{
					Joystick joystick = P_0[i];
					string text = P_2 + "_joystick" + joystick.id;
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + ((joystick.name == "Unknown Controller") ? joystick.hardwareName : joystick.name), text, P_1))
					{
						if (!tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							continue;
						}
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id (unique id)", joystick.id.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", joystick.name);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Name", joystick.hardwareName);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Is Recognized", (joystick.hardwareTypeGuid != Guid.Empty).ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", joystick.enabled.ToString());
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
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("System Id", joystick.systemId.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Unity Id", ReInput.usingUnityInput ? joystick.unityId.ToString() : "--");
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Type Guid", joystick.hardwareTypeGuid.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Identifier", joystick.hardwareIdentifier);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Device Instance Guid", joystick.deviceInstanceGuid.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", joystick.tag);
						bPsYPvZiSGGoRVrSOsnlabEMMdsQ(joystick.Axes, P_1, text);
						bcUlPEBBRIPBakjOqxJePBKoDVedA(joystick.Buttons, ControllerType.Joystick, P_1, text);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis2D Count", joystick.axis2DCount.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hat Count", joystick.hatCount.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("D-Pad Count", joystick.directionalPadCount.ToString());
						TUIwojtJdagyOOOAXsadFznFQKDA(joystick, P_1, text);
						CalibrationMap calibrationMap = joystick.calibrationMap;
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Calibration Map", text + "_calibrationMap", P_1))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								int axisCount = calibrationMap.axisCount;
								for (int k = 0; k < axisCount; k++)
								{
									AxisCalibration axisCalibration = calibrationMap.Axes[k];
									using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(k + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + k, P_1))
									{
										if (tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
										{
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", axisCalibration.enabled.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Max", axisCalibration.calibratedMax.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Min", axisCalibration.calibratedMin.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Zero", axisCalibration.calibratedZero.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Dead Zone", axisCalibration.deadZone.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Invert", axisCalibration.invert.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity Type", axisCalibration.sensitivityType.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity", axisCalibration.sensitivity.ToString());
											if (axisCalibration.sensitivityCurve != null)
											{
												bool num2 = GUI.enabled;
												GUI.enabled = false;
												mNnTeNvATbZWIzmgbLGpdISPtyMK.ihQDSbHOyfewvWuqxGoqNzmybogc("Sensitivity Curve", axisCalibration.sensitivityCurve);
												GUI.enabled = num2;
											}
											else
											{
												mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity Curve", "--");
											}
										}
									}
								}
							}
						}
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Supports Vibration", joystick.supportsVibration.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Vibration Motor Count", joystick.vibrationMotorCount.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Extension", (joystick.extension != null).ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Extension Type", (joystick.extension != null) ? joystick.extension.GetType().Name : "--");
						oTvBLWOizZAMQKyKTAsRuNuCScHW(joystick, P_1, text);
					}
				}
			}
		}

		private static void ypeQMwMtUlpNxLnPCkbWqJPQSPDe(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_mouse";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Mouse", text, P_0))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				Mouse mouse = ReInput.controllers.Mouse;
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", mouse.enabled.ToString());
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
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Screen Position", mouse.screenPosition.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Screen Position Prev", mouse.screenPositionPrev.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Screen Position Delta", mouse.screenPositionDelta.ToString());
				bPsYPvZiSGGoRVrSOsnlabEMMdsQ(mouse.Axes, P_0, text);
				bcUlPEBBRIPBakjOqxJePBKoDVedA(mouse.Buttons, ControllerType.Mouse, P_0, text);
				TUIwojtJdagyOOOAXsadFznFQKDA(mouse, P_0, text);
				oTvBLWOizZAMQKyKTAsRuNuCScHW(mouse, P_0, text);
			}
		}

		private static void KVeCpIJtuScNItGXySYASNYaIDVd(IDictionary<string, bool> P_0, string P_1)
		{
			string text = P_1 + "_keyboard";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Keyboard", text, P_0))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				Keyboard keyboard = ReInput.controllers.Keyboard;
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", keyboard.enabled.ToString());
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
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
				bcUlPEBBRIPBakjOqxJePBKoDVedA(keyboard.Buttons, ControllerType.Keyboard, P_0, text);
				TUIwojtJdagyOOOAXsadFznFQKDA(keyboard, P_0, text);
				oTvBLWOizZAMQKyKTAsRuNuCScHW(keyboard, P_0, text);
			}
		}

		private static void zxxlhoCNiivihrtunBZuFPzKgUwJ(IList<CustomController> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Custom Controllers (" + num + ")", P_2 + "_customControllers", P_1))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				for (int i = 0; i < num; i++)
				{
					CustomController customController = P_0[i];
					string text = P_2 + "_customController" + customController.id;
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + customController.name, text, P_1))
					{
						if (!tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							continue;
						}
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", customController.id.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", customController.name);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Name", customController.hardwareName);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", customController.tag);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Identifier", customController.hardwareIdentifier);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", customController.enabled.ToString());
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
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Assigned to Players", (!string.IsNullOrEmpty(text2)) ? text2 : "None");
						bPsYPvZiSGGoRVrSOsnlabEMMdsQ(customController.Axes, P_1, text);
						bcUlPEBBRIPBakjOqxJePBKoDVedA(customController.Buttons, ControllerType.Custom, P_1, text);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis2D Count", customController.axis2DCount.ToString());
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Element Identifiers", text + "_elementIdentifiers", P_1))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								int num2 = ((customController.AxisElementIdentifiers != null) ? customController.AxisElementIdentifiers.Count : 0);
								using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Axis Element Identifiers (" + num2 + ")", text + "_axisEIs", P_1))
								{
									if (tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
									{
										for (int k = 0; k < num2; k++)
										{
											ControllerElementIdentifier controllerElementIdentifier = customController.AxisElementIdentifiers[k];
											using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA6 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(k + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", text + "_AxisEI" + k + "_" + controllerElementIdentifier.name, P_1))
											{
												if (tueUGrgAFRWspWHnNyYtXNwgGmIA6.cDCFjaTmPlyARcuxprWDeBqRdeTC)
												{
													mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", controllerElementIdentifier.id.ToString());
													mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", controllerElementIdentifier.name);
												}
											}
										}
									}
								}
								num2 = ((customController.ButtonElementIdentifiers != null) ? customController.ButtonElementIdentifiers.Count : 0);
								using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA7 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Button Element Identifiers (" + num2 + ")", text + "_buttonEIs", P_1))
								{
									if (tueUGrgAFRWspWHnNyYtXNwgGmIA7.cDCFjaTmPlyARcuxprWDeBqRdeTC)
									{
										for (int l = 0; l < num2; l++)
										{
											ControllerElementIdentifier controllerElementIdentifier2 = customController.ButtonElementIdentifiers[l];
											using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA8 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(l + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", text + "_ButtonEI" + l + "_" + controllerElementIdentifier2.name, P_1))
											{
												if (tueUGrgAFRWspWHnNyYtXNwgGmIA8.cDCFjaTmPlyARcuxprWDeBqRdeTC)
												{
													mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", controllerElementIdentifier2.id.ToString());
													mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", controllerElementIdentifier2.name);
												}
											}
										}
									}
								}
							}
						}
						CalibrationMap calibrationMap = customController.calibrationMap;
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA9 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Calibration Map", text + "_calibrationMap", P_1))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA9.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								int num2 = calibrationMap.axisCount;
								for (int m = 0; m < num2; m++)
								{
									AxisCalibration axisCalibration = calibrationMap.Axes[m];
									using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA10 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(m + ": Axis Calibration (" + (axisCalibration.enabled ? "Enabled" : "Disabled") + ")", text + "_AxisCalibration" + m, P_1))
									{
										if (tueUGrgAFRWspWHnNyYtXNwgGmIA10.cDCFjaTmPlyARcuxprWDeBqRdeTC)
										{
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", axisCalibration.enabled.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Apply Range Calibration", axisCalibration.applyRangeCalibration.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Max", axisCalibration.calibratedMax.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Min", axisCalibration.calibratedMin.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Calibrated Zero", axisCalibration.calibratedZero.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Dead Zone", axisCalibration.deadZone.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Invert", axisCalibration.invert.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity Type", axisCalibration.sensitivityType.ToString());
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity", axisCalibration.sensitivity.ToString());
											if (axisCalibration.sensitivityCurve != null)
											{
												bool num3 = GUI.enabled;
												GUI.enabled = false;
												mNnTeNvATbZWIzmgbLGpdISPtyMK.ihQDSbHOyfewvWuqxGoqNzmybogc("Sensitivity Curve", axisCalibration.sensitivityCurve);
												GUI.enabled = num3;
											}
											else
											{
												mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Sensitivity Curve", "--");
											}
										}
									}
								}
							}
						}
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Extension", (customController.extension != null).ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Extension Type", (customController.extension != null) ? customController.extension.GetType().Name : "--");
						oTvBLWOizZAMQKyKTAsRuNuCScHW(customController, P_1, text);
					}
				}
			}
		}

		private static void VItOdUvamxIwUKNTViLGSPYRcbRFA(Player P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_player" + P_0.id;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA((P_0.id == 9999999) ? "System Player" : (P_1 + ": " + P_0.name), text, P_2))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Player Id", P_0.id.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", P_0.name);
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Descriptive Name", P_0.descriptiveName);
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Is Playing", P_0.isPlaying.ToString());
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Controllers", text + "_controllers", P_2))
				{
					if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						Player.ControllerHelper controllers = P_0.controllers;
						bUoycruDyDxcfUcNdnqtqnxiYRBI(controllers.Joysticks, P_2, text);
						zxxlhoCNiivihrtunBZuFPzKgUwJ(controllers.CustomControllers, P_2, text);
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Mouse", controllers.hasMouse.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Keyboard", controllers.hasKeyboard.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Exclude From Controller Auto Assignment", controllers.excludeFromControllerAutoAssignment.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Active Controller", (controllers.GetLastActiveController() != null) ? controllers.GetLastActiveController().name.ToString() : "NULL");
					}
				}
				string text2 = text + "_controllerMaps";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Controller Maps", text2, P_2))
				{
					if (tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						RvwCNVjBZCfocfCXCQLwMjIiPBAPD(ControllerType.Keyboard, P_0.controllers.maps.GetMaps<KeyboardMap>(0), "Keyboard Maps", P_2, text2 + "_keyboard");
						RvwCNVjBZCfocfCXCQLwMjIiPBAPD(ControllerType.Mouse, P_0.controllers.maps.GetMaps<MouseMap>(0), "Mouse Maps", P_2, text2 + "_mouse");
						string text3 = text2 + "_joystickMaps";
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Joystick Maps (" + P_0.controllers.joystickCount + ")", text3, P_2))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								for (int i = 0; i < P_0.controllers.joystickCount; i++)
								{
									Joystick joystick = P_0.controllers.Joysticks[i];
									IList<JoystickMap> maps = P_0.controllers.maps.GetMaps<JoystickMap>(joystick.id);
									text3 = text3 + "_joystickId" + joystick.id;
									RvwCNVjBZCfocfCXCQLwMjIiPBAPD(ControllerType.Joystick, maps, (joystick.name != "Unknown Controller") ? joystick.name : joystick.hardwareName, P_2, text3);
								}
							}
						}
						text3 = text2 + "_customControllerMaps";
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA6 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Custom Controller Maps (" + P_0.controllers.customControllerCount + ")", text3, P_2))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA6.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								for (int j = 0; j < P_0.controllers.customControllerCount; j++)
								{
									CustomController customController = P_0.controllers.CustomControllers[j];
									IList<CustomControllerMap> maps2 = P_0.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
									text3 = text3 + "_customControllerId" + customController.id;
									RvwCNVjBZCfocfCXCQLwMjIiPBAPD(ControllerType.Custom, maps2, customController.name, P_2, text3);
								}
							}
						}
					}
				}
				text2 = text + "_controllerMapLayoutManager";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA7 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Layout Manager", text2, P_2))
				{
					if (tueUGrgAFRWspWHnNyYtXNwgGmIA7.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						yPNGakmLtKyAYpilWqKOSjMWJmlc(P_0.controllers.maps.layoutManager, P_2, text2);
					}
				}
				text2 = text + "_controllerMapEnabler";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA8 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Map Enabler", text2, P_2))
				{
					if (tueUGrgAFRWspWHnNyYtXNwgGmIA8.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						fZACzDGdzOWtSWNpXzVRcTenlxvc(P_0.controllers.maps.mapEnabler, P_2, text2);
					}
				}
				text2 = text + "_inputBehaviors";
				WszPVaTGPgCHIxOjRattTximHHmj(P_0.controllers.maps.InputBehaviors, P_2, text2);
				text2 = text + "_actions";
				List<InputAction> list = new List<InputAction>(ReInput.mapping.Actions);
				list.Sort(uVcacihapNORvxnZWBhdCLJUpUIOA._003C_003E9.NnzQAsHzBMTyGwAraRmWsvvjuBkI);
				IList<InputCategory> actionCategories = ReInput.mapping.ActionCategories;
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA9 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Actions (" + list.Count + ")", text2, P_2))
				{
					if (!tueUGrgAFRWspWHnNyYtXNwgGmIA9.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						return;
					}
					for (int k = 0; k < actionCategories.Count; k++)
					{
						ztTiZspYuFHuFoGVJgVzObxqVQfO ztTiZspYuFHuFoGVJgVzObxqVQfO2 = new ztTiZspYuFHuFoGVJgVzObxqVQfO();
						ztTiZspYuFHuFoGVJgVzObxqVQfO2.hePjFDSVuvEgMZpONbVloFpyTzLf = actionCategories[k];
						string text4 = text2 + "_actionCat" + ztTiZspYuFHuFoGVJgVzObxqVQfO2.hePjFDSVuvEgMZpONbVloFpyTzLf.id;
						int num = ListTools.Count(list, ztTiZspYuFHuFoGVJgVzObxqVQfO2.JKMtPciEAApFLLVNaAAIhYYhuJgG);
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA10 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("id " + ztTiZspYuFHuFoGVJgVzObxqVQfO2.hePjFDSVuvEgMZpONbVloFpyTzLf.id + ": " + ztTiZspYuFHuFoGVJgVzObxqVQfO2.hePjFDSVuvEgMZpONbVloFpyTzLf.name + " (" + num + ")", text4, P_2))
						{
							if (!tueUGrgAFRWspWHnNyYtXNwgGmIA10.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								continue;
							}
							for (int l = 0; l < list.Count; l++)
							{
								InputAction inputAction = list[l];
								if (inputAction.categoryId != ztTiZspYuFHuFoGVJgVzObxqVQfO2.hePjFDSVuvEgMZpONbVloFpyTzLf.id)
								{
									continue;
								}
								string text5 = text4 + "_actionId" + inputAction.id;
								using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA11 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("id " + inputAction.id + ": " + inputAction.name + ": " + P_0.GetAxis(inputAction.id).ToString("f3"), text5, P_2))
								{
									if (tueUGrgAFRWspWHnNyYtXNwgGmIA11.cDCFjaTmPlyARcuxprWDeBqRdeTC)
									{
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Value", P_0.GetAxis(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Raw Value", P_0.GetAxisRaw(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Value", P_0.GetButton(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Double Press Value", P_0.GetButtonDoublePressHold(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Short Press Value", P_0.GetButtonShortPress(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Long Press Value", P_0.GetButtonLongPress(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Repeating Value", P_0.GetButtonRepeating(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Value", P_0.GetNegativeButton(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Double Press Value", P_0.GetNegativeButtonDoublePressHold(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Short Press Value", P_0.GetNegativeButtonShortPress(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Long Press Value", P_0.GetNegativeButtonLongPress(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Repeating Value", P_0.GetNegativeButtonRepeating(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Time Active", P_0.GetAxisTimeActive(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Time Inactive", P_0.GetAxisTimeInactive(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Raw Time Active", P_0.GetAxisRawTimeActive(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Raw Time Inactive", P_0.GetAxisRawTimeInactive(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Time Pressed", P_0.GetButtonTimePressed(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Time Unpressed", P_0.GetButtonTimeUnpressed(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Time Pressed", P_0.GetNegativeButtonTimePressed(inputAction.id).ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Negative Button Time Unpressed", P_0.GetNegativeButtonTimeUnpressed(inputAction.id).ToString());
									}
								}
							}
						}
					}
				}
			}
		}

		private static void WszPVaTGPgCHIxOjRattTximHHmj(IList<InputBehavior> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Input Behaviors (" + num + ")", P_2 + "_inputBehaviors", P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < num; i++)
					{
						GpckxcHmvFPXDZXaKxmoZHUXhpby(P_0[i], i, P_1, P_2);
					}
				}
			}
		}

		private static void GpckxcHmvFPXDZXaKxmoZHUXhpby(InputBehavior P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string text = P_3 + "_inputBehavior" + P_0.id;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(P_1 + ": " + P_0.name, text, P_2))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", P_0.id.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", P_0.name);
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Digital Axis Gravity", P_0.digitalAxisGravity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Digital Axis Instant Reverse", P_0.digitalAxisInstantReverse.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Digital Axis Sensitivity", P_0.digitalAxisSensitivity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Digital Axis Snap", P_0.digitalAxisSnap.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Joystick Axis Sensitivity", P_0.joystickAxisSensitivity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Custom Controller Axis Sensitivity", P_0.customControllerAxisSensitivity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Mouse XY Axis Mode", P_0.mouseXYAxisMode.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Mouse XY Axis Sensitivity", P_0.mouseXYAxisSensitivity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Mouse XY Axis Delta Calc", P_0.mouseXYAxisDeltaCalc.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Mouse Other Axis Mode", P_0.mouseOtherAxisMode.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Mouse Other Axis Sensitivity", P_0.mouseOtherAxisSensitivity.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Dead Zone", P_0.buttonDeadZone.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Double Press Speed", P_0.buttonDoublePressSpeed.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Short Press Time", P_0.buttonShortPressTime.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Short Press Expires In", P_0.buttonShortPressExpiresIn.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Long Press Time", P_0.buttonLongPressTime.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Long Press Expires In", P_0.buttonLongPressExpiresIn.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Button Down Buffer", P_0.buttonDownBuffer.ToString());
				}
			}
		}

		private static void TUIwojtJdagyOOOAXsadFznFQKDA(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Element Identifiers", P_2 + "_elementIdentifiers", P_1))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				int num;
				if (P_0 is ControllerWithAxes)
				{
					ControllerWithAxes controllerWithAxes = P_0 as ControllerWithAxes;
					num = ((controllerWithAxes.AxisElementIdentifiers != null) ? controllerWithAxes.AxisElementIdentifiers.Count : 0);
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Axis Element Identifiers (" + num + ")", P_2 + "_axisEIs", P_1))
					{
						if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							for (int i = 0; i < num; i++)
							{
								ControllerElementIdentifier controllerElementIdentifier = controllerWithAxes.AxisElementIdentifiers[i];
								using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + controllerElementIdentifier.name + " (id: " + controllerElementIdentifier.id + ")", P_2 + "_AxisEI" + i + "_" + controllerElementIdentifier.name, P_1))
								{
									if (tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
									{
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", controllerElementIdentifier.id.ToString());
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", controllerElementIdentifier.name);
									}
								}
							}
						}
					}
				}
				if (P_0 == null)
				{
					return;
				}
				num = ((P_0.ButtonElementIdentifiers != null) ? P_0.ButtonElementIdentifiers.Count : 0);
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Button Element Identifiers (" + num + ")", P_2 + "_buttonEIs", P_1))
				{
					if (!tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						return;
					}
					for (int j = 0; j < num; j++)
					{
						ControllerElementIdentifier controllerElementIdentifier2 = P_0.ButtonElementIdentifiers[j];
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA6 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(j + ": " + controllerElementIdentifier2.name + " (id: " + controllerElementIdentifier2.id + ")", P_2 + "_ButtonEI" + j + "_" + controllerElementIdentifier2.name, P_1))
						{
							if (tueUGrgAFRWspWHnNyYtXNwgGmIA6.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", controllerElementIdentifier2.id.ToString());
								mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", controllerElementIdentifier2.name);
							}
						}
					}
				}
			}
		}

		private static void bcUlPEBBRIPBakjOqxJePBKoDVedA(IList<Controller.Button> P_0, ControllerType P_1, IDictionary<string, bool> P_2, string P_3)
		{
			string obj = ((P_1 == ControllerType.Keyboard) ? "Key" : "Button");
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(obj + "s (" + num + ")", P_3 + "_Buttons", P_2))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				for (int i = 0; i < num; i++)
				{
					Controller.Button button = P_0[i];
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + ((P_1 == ControllerType.Keyboard) ? (Keyboard.GetKeyboardKeyCodeByButtonIndex(i).ToString() + " (" + Keyboard.GetKeyName((KeyCode)Keyboard.GetKeyboardKeyCodeByButtonIndex(i)) + ")") : button.elementIdentifier.name) + ": " + (button.value ? "Pressed" : "") + " (" + button.pressure.ToString("f3") + ")", P_3 + "_" + button.name, P_2))
					{
						if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Is Member Element", button.isMemberElement.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Is Pressure Sensitive", button.isPressureSensitive.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", button.value.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", button.valuePrev.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Pressure", button.pressure.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Pressure Prev", button.pressurePrev.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Just Pressed", button.justPressed.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Just Released", button.justReleased.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Just Double Pressed", button.justDoublePressed.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Double Pressed And Held", button.doublePressedAndHeld.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Pressed", button.timePressed.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Unpressed", button.timeUnpressed.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Pressed", button.lastTimePressed.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Unpressed", button.lastTimeUnpressed.ToString());
						}
					}
				}
			}
		}

		private static void bPsYPvZiSGGoRVrSOsnlabEMMdsQ(IList<Controller.Axis> P_0, IDictionary<string, bool> P_1, string P_2)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Axes (" + num + ")", P_2 + "_Axes", P_1))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				for (int i = 0; i < num; i++)
				{
					Controller.Axis axis = P_0[i];
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + axis.elementIdentifier.name + ": " + axis.value.ToString("f3") + " (" + axis.valueRaw.ToString("f3") + ")", P_2 + "_" + axis.name, P_1))
					{
						if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Is Member Element", axis.isMemberElement.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", axis.value.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Raw", axis.valueRaw.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", axis.valuePrev.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Raw Prev", axis.valueRawPrev.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Delta", axis.valueDelta.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Delta Raw", axis.valueDeltaRaw.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Active", axis.timeActive.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Active Raw", axis.timeActiveRaw.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Inactive", axis.timeInactive.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Time Inactive Raw", axis.timeInactiveRaw.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Active", axis.lastTimeActive.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Active Raw", axis.lastTimeActiveRaw.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Inactive", axis.lastTimeInactive.ToString());
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Last Time Inactive Raw", axis.lastTimeInactiveRaw.ToString());
						}
					}
				}
			}
		}

		private static void RvwCNVjBZCfocfCXCQLwMjIiPBAPD<_0001>(ControllerType P_0, IList<_0001> P_1, string P_2, IDictionary<string, bool> P_3, string P_4) where _0001 : ControllerMap
		{
			string text = P_4 + "_controllerMaps";
			int num = P_1?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(P_2 + " (" + num + ")", text, P_3))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
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
					using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + text3 + ", " + text4 + ": " + text2, P_4 + "_index" + i, P_3))
					{
						if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
						{
							if (P_1[i] is ControllerMapWithAxes)
							{
								AOChVSBkXjjpiZJRFtVdfQKGioRB(P_1[i] as ControllerMapWithAxes, P_3, text + i);
							}
							else
							{
								AOChVSBkXjjpiZJRFtVdfQKGioRB(P_1[i], P_3, text + i);
							}
						}
					}
				}
			}
		}

		private static void AOChVSBkXjjpiZJRFtVdfQKGioRB(ControllerMap P_0, IDictionary<string, bool> P_1, string P_2)
		{
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id (unique id)", P_0.id.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Source Map Id", P_0.sourceMapId.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", P_0.enabled.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Controller Type", P_0.controllerType.ToString());
			if (P_0.controllerType == ControllerType.Joystick || P_0.controllerType == ControllerType.Custom)
			{
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Controller Id", P_0.controllerId.ToString());
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
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Category Id", text);
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
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Layout Id", text2);
			int buttonMapCount = P_0.buttonMapCount;
			string text3 = P_2 + "_buttonMaps";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Button Maps (" + buttonMapCount + ")", text3, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < buttonMapCount; i++)
					{
						RuaPmbNHASaEGHISCEMVPgfHleCm(P_0.controllerType, P_0.ButtonMaps[i], i, P_1, text3 + i);
					}
				}
			}
		}

		private static void AOChVSBkXjjpiZJRFtVdfQKGioRB(ControllerMapWithAxes P_0, IDictionary<string, bool> P_1, string P_2)
		{
			AOChVSBkXjjpiZJRFtVdfQKGioRB((ControllerMap)P_0, P_1, P_2);
			string text = P_2 + "_axisMaps";
			int axisMapCount = P_0.axisMapCount;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Axis Maps (" + axisMapCount + ")", text, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < axisMapCount; i++)
					{
						RuaPmbNHASaEGHISCEMVPgfHleCm(P_0.controllerType, P_0.AxisMaps[i], i, P_1, text + i);
					}
				}
			}
		}

		private static void RuaPmbNHASaEGHISCEMVPgfHleCm(ControllerType P_0, ActionElementMap P_1, int P_2, IDictionary<string, bool> P_3, string P_4)
		{
			string text = "Action Element Map";
			InputAction action = ReInput.mapping.GetAction(P_1.actionId);
			string text2 = ((action != null) ? action.name : string.Empty);
			string text3 = RkCiNKGZcIgtXTgzJdzKxhhTPhJm(P_1);
			if (!string.IsNullOrEmpty(text3))
			{
				text = P_1.elementIdentifierName + " (" + text3 + ")";
			}
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(P_2 + ": " + text, P_4 + "_" + P_2, P_3))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id (unique id)", P_1.id.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Enabled", P_1.enabled.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Type", P_1.elementType.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Action Id", P_1.actionId + " " + ((action != null) ? ("(" + text2 + ")") : ""));
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Identifier Id", P_1.elementIdentifierId.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Identifier Name", P_1.elementIdentifierName);
				if (P_1.elementType == ControllerElementType.Axis)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Index", P_1.elementIndex.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Range", P_1.axisRange.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Type", P_1.axisType.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Invert", P_1.invert.ToString());
				}
				else if (P_1.elementType == ControllerElementType.Button)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Index", P_1.elementIndex.ToString());
					if (P_0 == ControllerType.Keyboard)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Key Code", P_1.keyCode.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Keyboard Key Code", P_1.keyboardKeyCode.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Modifiers", P_1.hasModifiers.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Modifier Key 1", P_1.modifierKey1.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Modifier Key 2", P_1.modifierKey2.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Modifier Key 3", P_1.modifierKey3.ToString());
					}
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Contribution", P_1.axisContribution.ToString());
			}
		}

		private static string RkCiNKGZcIgtXTgzJdzKxhhTPhJm(ActionElementMap P_0)
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

		private static void yPNGakmLtKyAYpilWqKOSjMWJmlc(ControllerMapLayoutManager P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (PpjYAcKSHhrqQHFnEGDwuxFiaYMc("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Load from User Data Store", P_0.loadFromUserDataStore.ToString());
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Rule Sets (" + count + ")", text, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < count; i++)
					{
						qQZHEVlqgXGUTCXARSLhAxYFqYikA(P_0.ruleSets[i], i, P_1, text + i);
					}
				}
			}
		}

		private static void qQZHEVlqgXGUTCXARSLhAxYFqYikA(ControllerMapLayoutManager.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				if (PpjYAcKSHhrqQHFnEGDwuxFiaYMc("Enabled", P_0.enabled))
				{
					P_0.enabled = !P_0.enabled;
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", P_0.tag);
				string text = P_3 + "_rules";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Rules (" + P_0.Count + ")", text, P_2))
				{
					if (!tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						return;
					}
					for (int i = 0; i < num; i++)
					{
						ControllerMapLayoutManager.Rule rule = P_0[i];
						string text2 = text + i;
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
						{
							if (!tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								continue;
							}
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", rule.tag);
							ynckSmFoqSeGebGiMOsHOhaBbZWUA(rule.controllerSetSelector, P_2, text2);
							int[] categoryIds = rule.categoryIds;
							int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
							using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
							{
								if (tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
								{
									if (num2 == 0)
									{
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Category", "All Map Categories");
									}
									else
									{
										for (int j = 0; j < categoryIds.Length; j++)
										{
											InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
											string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Category " + j, text3);
										}
									}
								}
							}
							InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, rule.layoutId);
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE(rule.controllerSetSelector.controllerType.ToString() + " Layout", (layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
						}
					}
				}
			}
		}

		private static void fZACzDGdzOWtSWNpXzVRcTenlxvc(ControllerMapEnabler P_0, IDictionary<string, bool> P_1, string P_2)
		{
			if (PpjYAcKSHhrqQHFnEGDwuxFiaYMc("Enabled", P_0.enabled))
			{
				P_0.enabled = !P_0.enabled;
			}
			string text = P_2 + "_ruleSets";
			int count = P_0.ruleSets.Count;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Rule Sets (" + count + ")", text, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < count; i++)
					{
						PksNzgQNDnGWFGXYsLIhydokTtlO(P_0.ruleSets[i], i, P_1, text + i);
					}
				}
			}
		}

		private static void PksNzgQNDnGWFGXYsLIhydokTtlO(ControllerMapEnabler.RuleSet P_0, int P_1, IDictionary<string, bool> P_2, string P_3)
		{
			int num = P_0?.Count ?? 0;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(P_1 + ": " + ((!string.IsNullOrEmpty(P_0.tag)) ? (P_0.tag + ", ") : "") + (P_0.enabled ? "Enabled" : "Disabled"), P_3, P_2))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				if (PpjYAcKSHhrqQHFnEGDwuxFiaYMc("Enabled", P_0.enabled))
				{
					P_0.enabled = !P_0.enabled;
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", P_0.tag);
				string text = P_3 + "_rules";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Rules (" + P_0.Count + ")", text, P_2))
				{
					if (!tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						return;
					}
					for (int i = 0; i < num; i++)
					{
						ControllerMapEnabler.Rule rule = P_0[i];
						string text2 = text + i;
						using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA4 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(i + ": " + ((!string.IsNullOrEmpty(rule.tag)) ? rule.tag : ""), text2, P_2))
						{
							if (!tueUGrgAFRWspWHnNyYtXNwgGmIA4.cDCFjaTmPlyARcuxprWDeBqRdeTC)
							{
								continue;
							}
							if (PpjYAcKSHhrqQHFnEGDwuxFiaYMc("Enable", rule.enable))
							{
								rule.enable = !rule.enable;
							}
							mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Tag", rule.tag);
							ynckSmFoqSeGebGiMOsHOhaBbZWUA(rule.controllerSetSelector, P_2, text2);
							int[] categoryIds = rule.categoryIds;
							int num2 = ((categoryIds != null) ? categoryIds.Length : 0);
							using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA5 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Map Categories (" + num2 + ")", text2 + "_categoryIds", P_2))
							{
								if (tueUGrgAFRWspWHnNyYtXNwgGmIA5.cDCFjaTmPlyARcuxprWDeBqRdeTC)
								{
									if (num2 == 0)
									{
										mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Category", "All Map Categories");
									}
									else
									{
										for (int j = 0; j < categoryIds.Length; j++)
										{
											InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryIds[j]);
											string text3 = ((mapCategory != null) ? (mapCategory.name + " (" + mapCategory.id + ")") : "[INVALID]");
											mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Category " + j, text3);
										}
									}
								}
							}
							int[] layoutIds = rule.layoutIds;
							int num3 = ((layoutIds != null) ? layoutIds.Length : 0);
							using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA6 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Layouts (" + num3 + ")", text2 + "_layoutIds", P_2))
							{
								if (!tueUGrgAFRWspWHnNyYtXNwgGmIA6.cDCFjaTmPlyARcuxprWDeBqRdeTC)
								{
									continue;
								}
								if (num3 == 0)
								{
									mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Layout", (rule.controllerSetSelector.type == ControllerSetSelector.Type.All) ? "All Layouts" : ("All " + rule.controllerSetSelector.controllerType.ToString() + " Layouts"));
									continue;
								}
								for (int k = 0; k < layoutIds.Length; k++)
								{
									InputLayout layout = ReInput.mapping.GetLayout(rule.controllerSetSelector.controllerType, layoutIds[k]);
									string text4 = ((layout != null) ? (layout.name + " (" + layout.id + ")") : "[INVALID]");
									mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE(rule.controllerSetSelector.controllerType.ToString() + " Layout " + k, text4);
								}
							}
						}
					}
				}
			}
		}

		private static void ynckSmFoqSeGebGiMOsHOhaBbZWUA(ControllerSetSelector P_0, IDictionary<string, bool> P_1, string P_2)
		{
			string text = P_2 + "_controllerSetSelector";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Controller Set Selector", text, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Type", StringTools.AddSpacesToSentence(P_0.type.ToString(), preserveAcronyms: false));
					if (P_0.type != ControllerSetSelector.Type.All)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Controller Type", P_0.controllerType.ToString());
					}
					if (P_0.type == ControllerSetSelector.Type.HardwareType)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Type Guid", P_0.hardwareTypeGuid.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Hardware Identifier", P_0.hardwareIdentifier);
					}
					if (P_0.type == ControllerSetSelector.Type.ControllerTemplateType)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Controller Template Type Guid", P_0.controllerTemplateTypeGuid.ToString());
					}
					if (P_0.type == ControllerSetSelector.Type.PersistentControllerInstance)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Device Instance Guid", P_0.deviceInstanceGuid.ToString());
					}
					if (P_0.type == ControllerSetSelector.Type.SessionControllerInstance)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Controller Id", P_0.controllerId.ToString());
					}
				}
			}
		}

		private static void oTvBLWOizZAMQKyKTAsRuNuCScHW(Controller P_0, IDictionary<string, bool> P_1, string P_2)
		{
			P_2 += "_templates";
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Templates (" + P_0.templateCount + ")", P_2, P_1))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					for (int i = 0; i < P_0.templateCount; i++)
					{
						gLtspjvjCfuFiwplieaLZRzRjUGD(P_0.Templates[i], i, P_2, P_1);
					}
				}
			}
		}

		private static void gLtspjvjCfuFiwplieaLZRzRjUGD(IControllerTemplate P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(((P_1 >= 0) ? (P_1 + ": ") : "") + P_0.name, P_2, P_3))
			{
				if (!tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					return;
				}
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Type GUID", P_0.typeGuid.ToString());
				mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Class Type", P_0.GetType().ToString());
				P_2 += "_elements";
				using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA3 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Elements (" + P_0.elementCount + ")", P_2, P_3))
				{
					if (tueUGrgAFRWspWHnNyYtXNwgGmIA3.cDCFjaTmPlyARcuxprWDeBqRdeTC)
					{
						for (int i = 0; i < P_0.elementCount; i++)
						{
							jTnRCjjHSrHGVpLkIWLvWpIsWZjt(P_0.elements[i], i, P_2, P_3);
						}
					}
				}
			}
		}

		private static void jTnRCjjHSrHGVpLkIWLvWpIsWZjt(IControllerTemplateElement P_0, int P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 += ((P_1 >= 0) ? ("_" + P_1) : "");
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(((P_1 >= 0) ? ": " : "") + P_0.descriptiveName + " (id: " + P_0.id + ")", P_2, P_3))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Id", P_0.id.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Name", P_0.descriptiveName.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Type", P_0.type.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Exists", P_0.exists.ToString());
					if (P_0.type == ControllerTemplateElementType.Button)
					{
						yxAeqXSwFBvvPtNOxQrIKOrMEvPeA(P_0 as IControllerTemplateButton, P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Axis)
					{
						lQbZyAhaTfQPUtbdpCzVATQubuQoA(P_0 as IControllerTemplateAxis, P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.DPad)
					{
						IControllerTemplateDPad controllerTemplateDPad = P_0 as IControllerTemplateDPad;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateDPad.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateDPad.valuePrev.ToString());
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateDPad.up, "Up", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateDPad.right, "Right", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateDPad.down, "Down", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateDPad.left, "Left", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Hat)
					{
						IControllerTemplateHat controllerTemplateHat = P_0 as IControllerTemplateHat;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateHat.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateHat.valuePrev.ToString());
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.up, "up", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.upRight, "upRight", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.right, "right", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.downRight, "downRight", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.down, "down", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.downLeft, "downLeft", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.left, "left", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateHat.upLeft, "upLeft", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Stick)
					{
						IControllerTemplateStick controllerTemplateStick = P_0 as IControllerTemplateStick;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateStick.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateStick.valuePrev.ToString());
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick.horizontal, "horizontal", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick.vertical, "vertical", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick.rotation, "rotation", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Throttle)
					{
						IControllerTemplateThrottle controllerTemplateThrottle = P_0 as IControllerTemplateThrottle;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateThrottle.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateThrottle.valuePrev.ToString());
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateThrottle.throttle, "throttle", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateThrottle.minDetent, "zeroDetent", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.ThumbStick)
					{
						IControllerTemplateThumbStick controllerTemplateThumbStick = P_0 as IControllerTemplateThumbStick;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateThumbStick.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateThumbStick.valuePrev.ToString());
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateThumbStick.horizontal, "horizontal", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateThumbStick.vertical, "vertical", P_2, P_3);
						EPcEMDfKeJJpMzqsTljwoLSXDypC(controllerTemplateThumbStick.press, "press", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Yoke)
					{
						IControllerTemplateYoke controllerTemplateYoke = P_0 as IControllerTemplateYoke;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", controllerTemplateYoke.value.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", controllerTemplateYoke.valuePrev.ToString());
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateYoke.rotation, "rotation", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateYoke.pushPull, "pushPull", P_2, P_3);
					}
					else if (P_0.type == ControllerTemplateElementType.Stick6D)
					{
						IControllerTemplateStick6D controllerTemplateStick6D = P_0 as IControllerTemplateStick6D;
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Position", controllerTemplateStick6D.position.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Position Prev", controllerTemplateStick6D.positionPrev.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Rotation", controllerTemplateStick6D.rotation.ToString());
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Rotation Prev", controllerTemplateStick6D.rotationPrev.ToString());
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.positionX, "PositionX", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.positionY, "PositionY", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.positionZ, "PositionZ", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.rotationX, "RotationX", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.rotationY, "RotationY", P_2, P_3);
						ubEaNnBtfdyZienuJfIrXFpjhIRxA(controllerTemplateStick6D.rotationZ, "RotationZ", P_2, P_3);
					}
					else
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Unknown element type", P_0.type.ToString());
					}
				}
			}
		}

		private static void ubEaNnBtfdyZienuJfIrXFpjhIRxA(IControllerTemplateAxis P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					lQbZyAhaTfQPUtbdpCzVATQubuQoA(P_0, P_2, P_3);
				}
			}
		}

		private static void EPcEMDfKeJJpMzqsTljwoLSXDypC(IControllerTemplateButton P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					yxAeqXSwFBvvPtNOxQrIKOrMEvPeA(P_0, P_2, P_3);
				}
			}
		}

		private static void lQbZyAhaTfQPUtbdpCzVATQubuQoA(IControllerTemplateAxis P_0, string P_1, IDictionary<string, bool> P_2)
		{
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", P_0.value.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", P_0.valuePrev.ToString());
			xEPdxNcqMwKOeYAFNPrLnfhElenW(P_0.source, "target", P_1, P_2);
		}

		private static void yxAeqXSwFBvvPtNOxQrIKOrMEvPeA(IControllerTemplateButton P_0, string P_1, IDictionary<string, bool> P_2)
		{
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value", P_0.value.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Value Prev", P_0.valuePrev.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Pressure", P_0.pressure.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Pressure Prev", P_0.pressurePrev.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Just Pressed", P_0.justPressed.ToString());
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Just Released", P_0.justReleased.ToString());
			HezHZkOmorKHXxeuocwewoHvWKpI(P_0.source, "target", P_1, P_2);
		}

		private static void xEPdxNcqMwKOeYAFNPrLnfhElenW(IControllerTemplateAxisSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA("Axis Target", P_2, P_3))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Split Axis", P_0.splitAxis.ToString());
					PZLDjJKmopDISRQjEIGSESXHtWTz(P_0.fullTarget, "target", P_2, P_3);
					PZLDjJKmopDISRQjEIGSESXHtWTz(P_0.positiveTarget, "positiveTarget", P_2, P_3);
					PZLDjJKmopDISRQjEIGSESXHtWTz(P_0.negativeTarget, "negativeTarget", P_2, P_3);
				}
			}
		}

		private static void HezHZkOmorKHXxeuocwewoHvWKpI(IControllerTemplateButtonSource P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			PZLDjJKmopDISRQjEIGSESXHtWTz(P_0.target, "target", P_2, P_3);
		}

		private static void PZLDjJKmopDISRQjEIGSESXHtWTz(IControllerElementTarget P_0, string P_1, string P_2, IDictionary<string, bool> P_3)
		{
			P_2 = P_2 + "_" + P_1;
			using (tueUGrgAFRWspWHnNyYtXNwgGmIA tueUGrgAFRWspWHnNyYtXNwgGmIA2 = new tueUGrgAFRWspWHnNyYtXNwgGmIA(StringTools.VariableNameToDisplayName(P_1), P_2, P_3))
			{
				if (tueUGrgAFRWspWHnNyYtXNwgGmIA2.cDCFjaTmPlyARcuxprWDeBqRdeTC)
				{
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Element Identifier Id", P_0.elementIdentifierId.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Axis Range", P_0.axisRange.ToString());
					mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Has Target", P_0.hasTarget.ToString());
					if (P_0.hasTarget)
					{
						mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE("Target Element", P_0.descriptiveName);
					}
				}
			}
		}

		private static bool PpjYAcKSHhrqQHFnEGDwuxFiaYMc(string P_0, bool P_1)
		{
			mNnTeNvATbZWIzmgbLGpdISPtyMK.OkwTIfHkjzKBvNRiKVYAYYDXxfYE(P_0, P_1.ToString());
			return false;
		}

		private static GUIStyle TYBLtPLvtLKilVkMVfWoHpnItTRbA()
		{
			return OpbfAGrGXfuNBGWkQKZzBbmGsrHK(new GUIStyle(GUI.skin.label)
			{
				margin = 
				{
					top = 1,
					bottom = 1
				},
				fontSize = ngWWJQOmNpFGXgzPCBggBNDROQLkA._fontSize
			});
		}

		public static GUIStyle GetToggleStyle()
		{
			GUIStyle gUIStyle = OpbfAGrGXfuNBGWkQKZzBbmGsrHK(new GUIStyle(GUI.skin.toggle)
			{
				margin = 
				{
					top = 0,
					bottom = 0
				}
			});
			gUIStyle.fontSize = ngWWJQOmNpFGXgzPCBggBNDROQLkA._fontSize;
			return gUIStyle;
		}

		private static GUIStyle OpbfAGrGXfuNBGWkQKZzBbmGsrHK(GUIStyle P_0)
		{
			P_0 = new GUIStyle(P_0);
			P_0.margin.left = vHdHaMNlrHfRQcaUkszsFEztsfuQ.PFRWMgXIkCDBuNShXjcbQNKnGiMz * 20;
			return P_0;
		}
	}
}
