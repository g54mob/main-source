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
			private const int gWcBHGDHYtoAmBZdUowSVyFFGOks = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] sCIaYvRbreNxocaIAMaUceRzxGMx;

			private readonly int TsBUksYJyVGnfdUgIGnDFjSaMsMsA;

			private readonly int[] kRJhdpPoIBiDiKxsWEMPviYREwNrA;

			private readonly bool[] NGHBGpefGMpsLgjSEQaPmiWeQGKrE;

			private bool DbDzwJCfCijdnhyEhgQfaTgEVOiu;

			private int qceokMztPTqWJfqGFHTRIiinxZmS;

			private readonly bool IuZXQxJEJAvzwyPGghdzjUsAhypg;

			private bool wpuRBEDXetmHTfjdJkETyGuyVtsH;

			public bool enabled
			{
				get
				{
					return DbDzwJCfCijdnhyEhgQfaTgEVOiu;
				}
				set
				{
					if (value != DbDzwJCfCijdnhyEhgQfaTgEVOiu)
					{
						DbDzwJCfCijdnhyEhgQfaTgEVOiu = value;
						if (!DbDzwJCfCijdnhyEhgQfaTgEVOiu)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => qceokMztPTqWJfqGFHTRIiinxZmS > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					sCIaYvRbreNxocaIAMaUceRzxGMx = new int[7]
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
				NGHBGpefGMpsLgjSEQaPmiWeQGKrE = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > TsBUksYJyVGnfdUgIGnDFjSaMsMsA)
					{
						TsBUksYJyVGnfdUgIGnDFjSaMsMsA = keyboardKeyValues[i];
					}
				}
				kRJhdpPoIBiDiKxsWEMPviYREwNrA = new int[TsBUksYJyVGnfdUgIGnDFjSaMsMsA + 1];
				ArrayTools.Fill(kRJhdpPoIBiDiKxsWEMPviYREwNrA, -1);
				for (int j = 0; j < num; j++)
				{
					kRJhdpPoIBiDiKxsWEMPviYREwNrA[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (qceokMztPTqWJfqGFHTRIiinxZmS != 0)
				{
					qCLMikkvyPQOmJsSmpzMDNayVymd();
				}
				BWEfuyWQfhHWGHnkZvwscuwbNwCb();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (qceokMztPTqWJfqGFHTRIiinxZmS == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					wpuRBEDXetmHTfjdJkETyGuyVtsH = true;
					if (DbDzwJCfCijdnhyEhgQfaTgEVOiu)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							NGHBGpefGMpsLgjSEQaPmiWeQGKrE[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (IuZXQxJEJAvzwyPGghdzjUsAhypg)
					{
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_F2] = GetKey(KeyCode.F2);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						NGHBGpefGMpsLgjSEQaPmiWeQGKrE[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (wpuRBEDXetmHTfjdJkETyGuyVtsH)
				{
					Array.Clear(NGHBGpefGMpsLgjSEQaPmiWeQGKrE, 0, NGHBGpefGMpsLgjSEQaPmiWeQGKrE.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					qceokMztPTqWJfqGFHTRIiinxZmS++;
					if (qceokMztPTqWJfqGFHTRIiinxZmS == 1)
					{
						XfBoVRZMDFIDtHtRMfjldofaMnwTB();
					}
					return;
				}
				qceokMztPTqWJfqGFHTRIiinxZmS--;
				if (qceokMztPTqWJfqGFHTRIiinxZmS < 0)
				{
					qceokMztPTqWJfqGFHTRIiinxZmS = 0;
					fXJpxuxVlRKSLRgXwhHpVzJiCuBX();
				}
				if (qceokMztPTqWJfqGFHTRIiinxZmS == 0)
				{
					lNbKdXnzHAjfZJAFEuaWAjuAevUp();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (qceokMztPTqWJfqGFHTRIiinxZmS == 0)
				{
					ikXSujaElvgfZeiBFzcMmaLiKlKO();
					return false;
				}
				if ((uint)keyCode > (uint)TsBUksYJyVGnfdUgIGnDFjSaMsMsA)
				{
					return false;
				}
				return NGHBGpefGMpsLgjSEQaPmiWeQGKrE[kRJhdpPoIBiDiKxsWEMPviYREwNrA[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (qceokMztPTqWJfqGFHTRIiinxZmS == 0)
				{
					ikXSujaElvgfZeiBFzcMmaLiKlKO();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(NGHBGpefGMpsLgjSEQaPmiWeQGKrE, values, 132);
				}
			}

			public void Clear()
			{
				if (IuZXQxJEJAvzwyPGghdzjUsAhypg)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(sCIaYvRbreNxocaIAMaUceRzxGMx, i) < 0)
						{
							NGHBGpefGMpsLgjSEQaPmiWeQGKrE[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(NGHBGpefGMpsLgjSEQaPmiWeQGKrE, 0, 132);
				}
			}

			private void qCLMikkvyPQOmJsSmpzMDNayVymd()
			{
				Array.Clear(NGHBGpefGMpsLgjSEQaPmiWeQGKrE, 0, 132);
			}

			private void BWEfuyWQfhHWGHnkZvwscuwbNwCb()
			{
				qceokMztPTqWJfqGFHTRIiinxZmS = 0;
				DbDzwJCfCijdnhyEhgQfaTgEVOiu = true;
			}

			private void XfBoVRZMDFIDtHtRMfjldofaMnwTB()
			{
			}

			private void lNbKdXnzHAjfZJAFEuaWAjuAevUp()
			{
				qCLMikkvyPQOmJsSmpzMDNayVymd();
			}

			private void ikXSujaElvgfZeiBFzcMmaLiKlKO()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void fXJpxuxVlRKSLRgXwhHpVzJiCuBX()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int SjrIqVaeWysGSkKwcDjqmbMOnwCI = 7;

			private const int OQCPJAFzVXsBogZTBpoSSnrsTiEJ = 4;

			private readonly bool[] hwsPJauoErJWNhVBHgZcsDfJEJlV;

			private readonly float[] EikXIcEmMDraPgrJsqXjXTYYbfwX;

			private int WNTvGhoCHosEWndFWAYbVaDMeSekA;

			private Vector3 FRRfXpARtMYQtDtayVquSupcYIAuA;

			private bool QiLbbQhaWgaiTqXLJkHtTXsFjhhl;

			private bool NfXiGFcTOIkESyNxXeVUvUKYcOaj;

			public bool monitoring => WNTvGhoCHosEWndFWAYbVaDMeSekA > 0;

			public Vector3 mousePosition => FRRfXpARtMYQtDtayVquSupcYIAuA;

			public bool mousePresent => QiLbbQhaWgaiTqXLJkHtTXsFjhhl;

			public Mouse()
			{
				hwsPJauoErJWNhVBHgZcsDfJEJlV = new bool[7];
				EikXIcEmMDraPgrJsqXjXTYYbfwX = new float[4];
				ozVvAJRTVPkkSglogeXSIcssftan();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					return;
				}
				if (!NfXiGFcTOIkESyNxXeVUvUKYcOaj)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							hwsPJauoErJWNhVBHgZcsDfJEJlV[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							EikXIcEmMDraPgrJsqXjXTYYbfwX[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						NfXiGFcTOIkESyNxXeVUvUKYcOaj = true;
					}
				}
				EikXIcEmMDraPgrJsqXjXTYYbfwX[3] = Input.mouseScrollDelta.x;
				FRRfXpARtMYQtDtayVquSupcYIAuA = Input.mousePosition;
				QiLbbQhaWgaiTqXLJkHtTXsFjhhl = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					WNTvGhoCHosEWndFWAYbVaDMeSekA++;
					if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 1)
					{
						ksfYayDpvONJMbzlTuFZhjwFtJtW();
					}
					return;
				}
				WNTvGhoCHosEWndFWAYbVaDMeSekA--;
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA < 0)
				{
					WNTvGhoCHosEWndFWAYbVaDMeSekA = 0;
					MmnHqYDdhDzqBIRcvsUdLdbaaQGh();
				}
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					KWRDKsFSQEPRdVJnQNqSapbHDfxbc();
				}
			}

			public bool GetButton(int index)
			{
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					XrhulmlLMoUItWkXPTkSPjgyCwkB();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return hwsPJauoErJWNhVBHgZcsDfJEJlV[index];
			}

			public float GetAxisRaw(int index)
			{
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					XrhulmlLMoUItWkXPTkSPjgyCwkB();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return EikXIcEmMDraPgrJsqXjXTYYbfwX[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					XrhulmlLMoUItWkXPTkSPjgyCwkB();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(hwsPJauoErJWNhVBHgZcsDfJEJlV, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (WNTvGhoCHosEWndFWAYbVaDMeSekA == 0)
				{
					XrhulmlLMoUItWkXPTkSPjgyCwkB();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(EikXIcEmMDraPgrJsqXjXTYYbfwX, axes, 4);
				}
			}

			private void SExNgzXvoTUysdqtyPqBmywcVWvE()
			{
				Array.Clear(hwsPJauoErJWNhVBHgZcsDfJEJlV, 0, 7);
				Array.Clear(EikXIcEmMDraPgrJsqXjXTYYbfwX, 0, 4);
			}

			private void ozVvAJRTVPkkSglogeXSIcssftan()
			{
				WNTvGhoCHosEWndFWAYbVaDMeSekA = 0;
				FRRfXpARtMYQtDtayVquSupcYIAuA = Vector3.zero;
				QiLbbQhaWgaiTqXLJkHtTXsFjhhl = false;
			}

			private void ksfYayDpvONJMbzlTuFZhjwFtJtW()
			{
			}

			private void KWRDKsFSQEPRdVJnQNqSapbHDfxbc()
			{
				SExNgzXvoTUysdqtyPqBmywcVWvE();
			}

			private void XrhulmlLMoUItWkXPTkSPjgyCwkB()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void MmnHqYDdhDzqBIRcvsUdLdbaaQGh()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse gyCKosPyFuYlYObkACqCCcroampAA;

		private static Keyboard SmJSqFPRbRLKtDdFHABvIekYCrGn;

		public static Mouse mouse => gyCKosPyFuYlYObkACqCCcroampAA ?? (gyCKosPyFuYlYObkACqCCcroampAA = new Mouse());

		public static Keyboard keyboard => SmJSqFPRbRLKtDdFHABvIekYCrGn ?? (SmJSqFPRbRLKtDdFHABvIekYCrGn = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (SmJSqFPRbRLKtDdFHABvIekYCrGn != null)
			{
				SmJSqFPRbRLKtDdFHABvIekYCrGn.PostInitialize();
			}
			if (gyCKosPyFuYlYObkACqCCcroampAA != null)
			{
				gyCKosPyFuYlYObkACqCCcroampAA.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (SmJSqFPRbRLKtDdFHABvIekYCrGn != null)
			{
				SmJSqFPRbRLKtDdFHABvIekYCrGn = null;
			}
			if (gyCKosPyFuYlYObkACqCCcroampAA != null)
			{
				gyCKosPyFuYlYObkACqCCcroampAA = null;
			}
		}

		public static void Update()
		{
			if (SmJSqFPRbRLKtDdFHABvIekYCrGn != null)
			{
				SmJSqFPRbRLKtDdFHABvIekYCrGn.enabled = ReInput.controllers.Keyboard.enabled;
				SmJSqFPRbRLKtDdFHABvIekYCrGn.Update();
			}
			if (gyCKosPyFuYlYObkACqCCcroampAA != null)
			{
				gyCKosPyFuYlYObkACqCCcroampAA.Update();
			}
		}
	}
}
