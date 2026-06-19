using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class ThreadSafeUnityInput
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Keyboard
		{
			private const int pKLyHKcLrtlsfGLLyBGvezYBCtZAA = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] lEjUOrqxAyBDvvbuoIMjGeSnxhxQ;

			private readonly int CoqaawxqFNDFsFaQsNPmsFRmMZxLA;

			private readonly int[] vnmnLjmChFnVnqmSkmWiCLHZNLsJ;

			private readonly bool[] UAmKNbYVtOYjSaOuqCmeImLQrOQK;

			private bool EGqStLlxjcDXewFeHTuSYQjAVlTN;

			private int tLloIGNsBTyAkzerghkkKlzxaVO;

			private readonly bool DJkkDvwvkQkRllAmYnNYFQlKZICp;

			private bool dqZrVFeQgnhMKoEPlCEoAAlePuZmA;

			public bool enabled
			{
				get
				{
					return EGqStLlxjcDXewFeHTuSYQjAVlTN;
				}
				set
				{
					if (value != EGqStLlxjcDXewFeHTuSYQjAVlTN)
					{
						EGqStLlxjcDXewFeHTuSYQjAVlTN = value;
						if (!EGqStLlxjcDXewFeHTuSYQjAVlTN)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => tLloIGNsBTyAkzerghkkKlzxaVO > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					lEjUOrqxAyBDvvbuoIMjGeSnxhxQ = new int[7]
					{
						(keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27)),
						(keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319)),
						(keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283)),
						(keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273)),
						(keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275)),
						(keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274)),
						(keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276))
					};
				}
			}

			public Keyboard()
			{
				UAmKNbYVtOYjSaOuqCmeImLQrOQK = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > CoqaawxqFNDFsFaQsNPmsFRmMZxLA)
					{
						CoqaawxqFNDFsFaQsNPmsFRmMZxLA = keyboardKeyValues[i];
					}
				}
				vnmnLjmChFnVnqmSkmWiCLHZNLsJ = new int[CoqaawxqFNDFsFaQsNPmsFRmMZxLA + 1];
				ArrayTools.Fill(vnmnLjmChFnVnqmSkmWiCLHZNLsJ, -1);
				for (int j = 0; j < num; j++)
				{
					vnmnLjmChFnVnqmSkmWiCLHZNLsJ[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (tLloIGNsBTyAkzerghkkKlzxaVO != 0)
				{
					vJiAWcVWTLBglFOAOsRbglWequFfB();
				}
				MjhlrcpUrpBlLCMJKgTTgGxsbsFzA();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (tLloIGNsBTyAkzerghkkKlzxaVO == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					dqZrVFeQgnhMKoEPlCEoAAlePuZmA = true;
					if (EGqStLlxjcDXewFeHTuSYQjAVlTN)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							UAmKNbYVtOYjSaOuqCmeImLQrOQK[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (DJkkDvwvkQkRllAmYnNYFQlKZICp)
					{
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_F2] = GetKey(KeyCode.F2);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						UAmKNbYVtOYjSaOuqCmeImLQrOQK[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (dqZrVFeQgnhMKoEPlCEoAAlePuZmA)
				{
					Array.Clear(UAmKNbYVtOYjSaOuqCmeImLQrOQK, 0, UAmKNbYVtOYjSaOuqCmeImLQrOQK.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					tLloIGNsBTyAkzerghkkKlzxaVO++;
					if (tLloIGNsBTyAkzerghkkKlzxaVO == 1)
					{
						QsJgXeXmNjesuUfaPUEAByOGONi();
					}
					return;
				}
				tLloIGNsBTyAkzerghkkKlzxaVO--;
				if (tLloIGNsBTyAkzerghkkKlzxaVO < 0)
				{
					tLloIGNsBTyAkzerghkkKlzxaVO = 0;
					uHkrjyQAaNwAWQnIAhyExAzmTGmC();
				}
				if (tLloIGNsBTyAkzerghkkKlzxaVO == 0)
				{
					mxEjcJQkmOJxKQshoMUnoMzGCkvj();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (tLloIGNsBTyAkzerghkkKlzxaVO == 0)
				{
					vzoEKpHLtjDYObvhdRPlcWCqVMbhA();
					return false;
				}
				if ((uint)keyCode > (uint)CoqaawxqFNDFsFaQsNPmsFRmMZxLA)
				{
					return false;
				}
				return UAmKNbYVtOYjSaOuqCmeImLQrOQK[vnmnLjmChFnVnqmSkmWiCLHZNLsJ[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (tLloIGNsBTyAkzerghkkKlzxaVO == 0)
				{
					vzoEKpHLtjDYObvhdRPlcWCqVMbhA();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(UAmKNbYVtOYjSaOuqCmeImLQrOQK, values, 132);
				}
			}

			public void Clear()
			{
				if (DJkkDvwvkQkRllAmYnNYFQlKZICp)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(lEjUOrqxAyBDvvbuoIMjGeSnxhxQ, i) < 0)
						{
							UAmKNbYVtOYjSaOuqCmeImLQrOQK[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(UAmKNbYVtOYjSaOuqCmeImLQrOQK, 0, 132);
				}
			}

			private void vJiAWcVWTLBglFOAOsRbglWequFfB()
			{
				Array.Clear(UAmKNbYVtOYjSaOuqCmeImLQrOQK, 0, 132);
			}

			private void MjhlrcpUrpBlLCMJKgTTgGxsbsFzA()
			{
				tLloIGNsBTyAkzerghkkKlzxaVO = 0;
				EGqStLlxjcDXewFeHTuSYQjAVlTN = true;
			}

			private void QsJgXeXmNjesuUfaPUEAByOGONi()
			{
			}

			private void mxEjcJQkmOJxKQshoMUnoMzGCkvj()
			{
				vJiAWcVWTLBglFOAOsRbglWequFfB();
			}

			private void vzoEKpHLtjDYObvhdRPlcWCqVMbhA()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void uHkrjyQAaNwAWQnIAhyExAzmTGmC()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int PwWHQPBPTsmIZhdkGAzHhKHOrKtAA = 7;

			private const int TPtUBCupsFfQdrFntPXbkymueirU = 4;

			private readonly bool[] uCNZbcBdlngFAsbnbhZLIpiPqKAi;

			private readonly float[] XTDcEipDvRSYArkvMftWvrXCBGHR;

			private int PPqEzpBciofSDcmtqGqSTvWIanXNA;

			private Vector3 YQaNizoPUOwNewICASXHYaewtnlH;

			private bool FzcGtUFQhoLYIUvdbgAWchbDZIIOb;

			private bool WEaMSJXlOOeVHnTUbKlvTTiEFGBd;

			public bool monitoring => PPqEzpBciofSDcmtqGqSTvWIanXNA > 0;

			public Vector3 mousePosition => YQaNizoPUOwNewICASXHYaewtnlH;

			public bool mousePresent => FzcGtUFQhoLYIUvdbgAWchbDZIIOb;

			public Mouse()
			{
				uCNZbcBdlngFAsbnbhZLIpiPqKAi = new bool[7];
				XTDcEipDvRSYArkvMftWvrXCBGHR = new float[4];
				vJobMReYqXdEJzgWKnWxyzpwrQRt();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					return;
				}
				if (!WEaMSJXlOOeVHnTUbKlvTTiEFGBd)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							uCNZbcBdlngFAsbnbhZLIpiPqKAi[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							XTDcEipDvRSYArkvMftWvrXCBGHR[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						WEaMSJXlOOeVHnTUbKlvTTiEFGBd = true;
					}
				}
				XTDcEipDvRSYArkvMftWvrXCBGHR[3] = Input.mouseScrollDelta.x;
				YQaNizoPUOwNewICASXHYaewtnlH = Input.mousePosition;
				FzcGtUFQhoLYIUvdbgAWchbDZIIOb = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					PPqEzpBciofSDcmtqGqSTvWIanXNA++;
					if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 1)
					{
						jQKAmguWWCpXBcfZrebkJLvBteSQ();
					}
					return;
				}
				PPqEzpBciofSDcmtqGqSTvWIanXNA--;
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA < 0)
				{
					PPqEzpBciofSDcmtqGqSTvWIanXNA = 0;
					XXSHTIctMPnBAXDKNmKMjMuwjDts();
				}
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					TQeEgojalOedeCZJitIpDMsJRYYM();
				}
			}

			public bool GetButton(int index)
			{
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					IGMGeiUQgigVPDGSlaxFrbcaYnXs();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return uCNZbcBdlngFAsbnbhZLIpiPqKAi[index];
			}

			public float GetAxisRaw(int index)
			{
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					IGMGeiUQgigVPDGSlaxFrbcaYnXs();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return XTDcEipDvRSYArkvMftWvrXCBGHR[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					IGMGeiUQgigVPDGSlaxFrbcaYnXs();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(uCNZbcBdlngFAsbnbhZLIpiPqKAi, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (PPqEzpBciofSDcmtqGqSTvWIanXNA == 0)
				{
					IGMGeiUQgigVPDGSlaxFrbcaYnXs();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(XTDcEipDvRSYArkvMftWvrXCBGHR, axes, 4);
				}
			}

			private void NuUEVjqNCFOofcmSSDzgWOzuigOs()
			{
				Array.Clear(uCNZbcBdlngFAsbnbhZLIpiPqKAi, 0, 7);
				Array.Clear(XTDcEipDvRSYArkvMftWvrXCBGHR, 0, 4);
			}

			private void vJobMReYqXdEJzgWKnWxyzpwrQRt()
			{
				PPqEzpBciofSDcmtqGqSTvWIanXNA = 0;
				YQaNizoPUOwNewICASXHYaewtnlH = Vector3.zero;
				FzcGtUFQhoLYIUvdbgAWchbDZIIOb = false;
			}

			private void jQKAmguWWCpXBcfZrebkJLvBteSQ()
			{
			}

			private void TQeEgojalOedeCZJitIpDMsJRYYM()
			{
				NuUEVjqNCFOofcmSSDzgWOzuigOs();
			}

			private void IGMGeiUQgigVPDGSlaxFrbcaYnXs()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void XXSHTIctMPnBAXDKNmKMjMuwjDts()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse rJlTAsmCgoRiXJaEsZCvwoocaLGEA;

		private static Keyboard NPkbWTdyGBZniaAbvdoGTczUIEdeb;

		public static Mouse mouse => rJlTAsmCgoRiXJaEsZCvwoocaLGEA ?? (rJlTAsmCgoRiXJaEsZCvwoocaLGEA = new Mouse());

		public static Keyboard keyboard => NPkbWTdyGBZniaAbvdoGTczUIEdeb ?? (NPkbWTdyGBZniaAbvdoGTczUIEdeb = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (NPkbWTdyGBZniaAbvdoGTczUIEdeb != null)
			{
				NPkbWTdyGBZniaAbvdoGTczUIEdeb.PostInitialize();
			}
			if (rJlTAsmCgoRiXJaEsZCvwoocaLGEA != null)
			{
				rJlTAsmCgoRiXJaEsZCvwoocaLGEA.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (NPkbWTdyGBZniaAbvdoGTczUIEdeb != null)
			{
				NPkbWTdyGBZniaAbvdoGTczUIEdeb = null;
			}
			if (rJlTAsmCgoRiXJaEsZCvwoocaLGEA != null)
			{
				rJlTAsmCgoRiXJaEsZCvwoocaLGEA = null;
			}
		}

		public static void Update()
		{
			if (NPkbWTdyGBZniaAbvdoGTczUIEdeb != null)
			{
				NPkbWTdyGBZniaAbvdoGTczUIEdeb.enabled = ReInput.controllers.Keyboard.enabled;
				NPkbWTdyGBZniaAbvdoGTczUIEdeb.Update();
			}
			if (rJlTAsmCgoRiXJaEsZCvwoocaLGEA != null)
			{
				rJlTAsmCgoRiXJaEsZCvwoocaLGEA.Update();
			}
		}
	}
}
