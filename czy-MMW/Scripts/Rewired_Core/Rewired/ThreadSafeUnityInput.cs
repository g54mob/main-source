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
			private const int nQqEdGFUhuEwbNeiQwdyVxBauYqe = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] xWaBfUDtLjhtmwBkQaegsrUWaAAE;

			private readonly int GuvNlXSJaKBhzfKtKFlvvnwNiOEU;

			private readonly int[] pPrbqOAVWSvLsJtfOtSrOcqoVITqA;

			private readonly bool[] QAlIRQrmQDngJppXAekhawyvXqpGA;

			private bool EXhuhkSMIfvUhbFxzUXrwWafafuD;

			private int lYKYhrlyBAfYNzHXXEZzWeIOqnmu;

			private readonly bool ZznIyYPDNHrwyuiZcleDfqSjLInk;

			private bool lnEWImVxFoonHzgcBsAtabYDBlgv;

			public bool enabled
			{
				get
				{
					return EXhuhkSMIfvUhbFxzUXrwWafafuD;
				}
				set
				{
					if (value != EXhuhkSMIfvUhbFxzUXrwWafafuD)
					{
						EXhuhkSMIfvUhbFxzUXrwWafafuD = value;
						if (!EXhuhkSMIfvUhbFxzUXrwWafafuD)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => lYKYhrlyBAfYNzHXXEZzWeIOqnmu > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					xWaBfUDtLjhtmwBkQaegsrUWaAAE = new int[7]
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
				QAlIRQrmQDngJppXAekhawyvXqpGA = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > GuvNlXSJaKBhzfKtKFlvvnwNiOEU)
					{
						GuvNlXSJaKBhzfKtKFlvvnwNiOEU = keyboardKeyValues[i];
					}
				}
				pPrbqOAVWSvLsJtfOtSrOcqoVITqA = new int[GuvNlXSJaKBhzfKtKFlvvnwNiOEU + 1];
				ArrayTools.Fill(pPrbqOAVWSvLsJtfOtSrOcqoVITqA, -1);
				for (int j = 0; j < num; j++)
				{
					pPrbqOAVWSvLsJtfOtSrOcqoVITqA[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu != 0)
				{
					nAxHFTwSaIYGiBcroghaPWtBJtgr();
				}
				WTyckRIHAmIJMDRgyAbCpiYPVjsiA();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					lnEWImVxFoonHzgcBsAtabYDBlgv = true;
					if (EXhuhkSMIfvUhbFxzUXrwWafafuD)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							QAlIRQrmQDngJppXAekhawyvXqpGA[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (ZznIyYPDNHrwyuiZcleDfqSjLInk)
					{
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_F2] = GetKey(KeyCode.F2);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						QAlIRQrmQDngJppXAekhawyvXqpGA[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (lnEWImVxFoonHzgcBsAtabYDBlgv)
				{
					Array.Clear(QAlIRQrmQDngJppXAekhawyvXqpGA, 0, QAlIRQrmQDngJppXAekhawyvXqpGA.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					lYKYhrlyBAfYNzHXXEZzWeIOqnmu++;
					if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu == 1)
					{
						OefbCaaLLOERvDdKUTfLzuPvVLyLA();
					}
					return;
				}
				lYKYhrlyBAfYNzHXXEZzWeIOqnmu--;
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu < 0)
				{
					lYKYhrlyBAfYNzHXXEZzWeIOqnmu = 0;
					qTrtuXfLrCWKVTmOgIZXHZzTQYLSA();
				}
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu == 0)
				{
					qnLcuiGfTBIbHDZSADskfQUrJFOdA();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu == 0)
				{
					jhnTsYqSOycmZyDQDbuqqWjLRDOi();
					return false;
				}
				if ((uint)keyCode > (uint)GuvNlXSJaKBhzfKtKFlvvnwNiOEU)
				{
					return false;
				}
				return QAlIRQrmQDngJppXAekhawyvXqpGA[pPrbqOAVWSvLsJtfOtSrOcqoVITqA[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (lYKYhrlyBAfYNzHXXEZzWeIOqnmu == 0)
				{
					jhnTsYqSOycmZyDQDbuqqWjLRDOi();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(QAlIRQrmQDngJppXAekhawyvXqpGA, values, 132);
				}
			}

			public void Clear()
			{
				if (ZznIyYPDNHrwyuiZcleDfqSjLInk)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(xWaBfUDtLjhtmwBkQaegsrUWaAAE, i) < 0)
						{
							QAlIRQrmQDngJppXAekhawyvXqpGA[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(QAlIRQrmQDngJppXAekhawyvXqpGA, 0, 132);
				}
			}

			private void nAxHFTwSaIYGiBcroghaPWtBJtgr()
			{
				Array.Clear(QAlIRQrmQDngJppXAekhawyvXqpGA, 0, 132);
			}

			private void WTyckRIHAmIJMDRgyAbCpiYPVjsiA()
			{
				lYKYhrlyBAfYNzHXXEZzWeIOqnmu = 0;
				EXhuhkSMIfvUhbFxzUXrwWafafuD = true;
			}

			private void OefbCaaLLOERvDdKUTfLzuPvVLyLA()
			{
			}

			private void qnLcuiGfTBIbHDZSADskfQUrJFOdA()
			{
				nAxHFTwSaIYGiBcroghaPWtBJtgr();
			}

			private void jhnTsYqSOycmZyDQDbuqqWjLRDOi()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void qTrtuXfLrCWKVTmOgIZXHZzTQYLSA()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int XfZPIaulqrkMMiOZoHeQkxmzFICh = 7;

			private const int LQqIzPDLSGmkWcWaJzmdAHXBlOIB = 4;

			private readonly bool[] qYQuIPiKSevYJxcMFeTSwqBgVvts;

			private readonly float[] NjEnRNYMWUpsRcBAqsBBZYqtsTww;

			private int PQlosAyRZvmcWphCISDPLmdbkSyJ;

			private Vector3 KnzhSQTcnVdYtexxkIoECqTLswMDA;

			private bool BjhmorvAyxmfFkGfVoKVVYNuFIpC;

			private bool GFbHFykiWZFYIlaaJXsgfhaniImEb;

			public bool monitoring => PQlosAyRZvmcWphCISDPLmdbkSyJ > 0;

			public Vector3 mousePosition => KnzhSQTcnVdYtexxkIoECqTLswMDA;

			public bool mousePresent => BjhmorvAyxmfFkGfVoKVVYNuFIpC;

			public Mouse()
			{
				qYQuIPiKSevYJxcMFeTSwqBgVvts = new bool[7];
				NjEnRNYMWUpsRcBAqsBBZYqtsTww = new float[4];
				ttrmZeDRDWUsCoMbakwwAZWLFOkh();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					return;
				}
				if (!GFbHFykiWZFYIlaaJXsgfhaniImEb)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							qYQuIPiKSevYJxcMFeTSwqBgVvts[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							NjEnRNYMWUpsRcBAqsBBZYqtsTww[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						GFbHFykiWZFYIlaaJXsgfhaniImEb = true;
					}
				}
				NjEnRNYMWUpsRcBAqsBBZYqtsTww[3] = Input.mouseScrollDelta.x;
				KnzhSQTcnVdYtexxkIoECqTLswMDA = Input.mousePosition;
				BjhmorvAyxmfFkGfVoKVVYNuFIpC = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					PQlosAyRZvmcWphCISDPLmdbkSyJ++;
					if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 1)
					{
						fMPozDHOlHrLYhgoBsJxzpWuAppiA();
					}
					return;
				}
				PQlosAyRZvmcWphCISDPLmdbkSyJ--;
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ < 0)
				{
					PQlosAyRZvmcWphCISDPLmdbkSyJ = 0;
					HIVCjjXOxUzgVIjhtgJFXIBZOWAi();
				}
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					LPnEFLYRWDMXdHUkEsqsfOVcYLpU();
				}
			}

			public bool GetButton(int index)
			{
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					CvJvrLvlFbQaCEelRPrEJXLVwzei();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return qYQuIPiKSevYJxcMFeTSwqBgVvts[index];
			}

			public float GetAxisRaw(int index)
			{
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					CvJvrLvlFbQaCEelRPrEJXLVwzei();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return NjEnRNYMWUpsRcBAqsBBZYqtsTww[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					CvJvrLvlFbQaCEelRPrEJXLVwzei();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(qYQuIPiKSevYJxcMFeTSwqBgVvts, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (PQlosAyRZvmcWphCISDPLmdbkSyJ == 0)
				{
					CvJvrLvlFbQaCEelRPrEJXLVwzei();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(NjEnRNYMWUpsRcBAqsBBZYqtsTww, axes, 4);
				}
			}

			private void TJPSSWJmtGUmchhbuhPlcuARRtbx()
			{
				Array.Clear(qYQuIPiKSevYJxcMFeTSwqBgVvts, 0, 7);
				Array.Clear(NjEnRNYMWUpsRcBAqsBBZYqtsTww, 0, 4);
			}

			private void ttrmZeDRDWUsCoMbakwwAZWLFOkh()
			{
				PQlosAyRZvmcWphCISDPLmdbkSyJ = 0;
				KnzhSQTcnVdYtexxkIoECqTLswMDA = Vector3.zero;
				BjhmorvAyxmfFkGfVoKVVYNuFIpC = false;
			}

			private void fMPozDHOlHrLYhgoBsJxzpWuAppiA()
			{
			}

			private void LPnEFLYRWDMXdHUkEsqsfOVcYLpU()
			{
				TJPSSWJmtGUmchhbuhPlcuARRtbx();
			}

			private void CvJvrLvlFbQaCEelRPrEJXLVwzei()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void HIVCjjXOxUzgVIjhtgJFXIBZOWAi()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse vRgZADRJHtKAYGvAYqeuIDHDYKhd;

		private static Keyboard BNdHlcJCjGVmdPXMPQNVCjQvJoIm;

		public static Mouse mouse => vRgZADRJHtKAYGvAYqeuIDHDYKhd ?? (vRgZADRJHtKAYGvAYqeuIDHDYKhd = new Mouse());

		public static Keyboard keyboard => BNdHlcJCjGVmdPXMPQNVCjQvJoIm ?? (BNdHlcJCjGVmdPXMPQNVCjQvJoIm = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (BNdHlcJCjGVmdPXMPQNVCjQvJoIm != null)
			{
				BNdHlcJCjGVmdPXMPQNVCjQvJoIm.PostInitialize();
			}
			if (vRgZADRJHtKAYGvAYqeuIDHDYKhd != null)
			{
				vRgZADRJHtKAYGvAYqeuIDHDYKhd.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (BNdHlcJCjGVmdPXMPQNVCjQvJoIm != null)
			{
				BNdHlcJCjGVmdPXMPQNVCjQvJoIm = null;
			}
			if (vRgZADRJHtKAYGvAYqeuIDHDYKhd != null)
			{
				vRgZADRJHtKAYGvAYqeuIDHDYKhd = null;
			}
		}

		public static void Update()
		{
			if (BNdHlcJCjGVmdPXMPQNVCjQvJoIm != null)
			{
				BNdHlcJCjGVmdPXMPQNVCjQvJoIm.enabled = ReInput.controllers.Keyboard.enabled;
				BNdHlcJCjGVmdPXMPQNVCjQvJoIm.Update();
			}
			if (vRgZADRJHtKAYGvAYqeuIDHDYKhd != null)
			{
				vRgZADRJHtKAYGvAYqeuIDHDYKhd.Update();
			}
		}
	}
}
