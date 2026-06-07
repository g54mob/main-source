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
			private const int fNTnZVUALhuRLndrzcPGqpWeDsFn = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] zBvQUoQKckJwBGBYdXlGZYYIsXhd;

			private readonly int YoqoajZtPJLcKRAahWwPSlHLMgtj;

			private readonly int[] lkyfOcEpZPfiRDSqvjwTDSBiKLwl;

			private readonly bool[] SWsGHywGBUSukPsStHHPVuFboOKL;

			private bool CCaRrIXKHwgLEXKISivrZTzttmTm;

			private int vHTcoJcmOTHgiaBOeMiXgpjgAtZxb;

			private readonly bool LogaFgbUQGeLFYCGNLEhSCnnxHIpA;

			private bool lNNvPGGCGbRSyRrpaQLNTwrRIxTm;

			public bool enabled
			{
				get
				{
					return CCaRrIXKHwgLEXKISivrZTzttmTm;
				}
				set
				{
					if (value != CCaRrIXKHwgLEXKISivrZTzttmTm)
					{
						CCaRrIXKHwgLEXKISivrZTzttmTm = value;
						if (!CCaRrIXKHwgLEXKISivrZTzttmTm)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => vHTcoJcmOTHgiaBOeMiXgpjgAtZxb > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					zBvQUoQKckJwBGBYdXlGZYYIsXhd = new int[7]
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
				SWsGHywGBUSukPsStHHPVuFboOKL = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > YoqoajZtPJLcKRAahWwPSlHLMgtj)
					{
						YoqoajZtPJLcKRAahWwPSlHLMgtj = keyboardKeyValues[i];
					}
				}
				lkyfOcEpZPfiRDSqvjwTDSBiKLwl = new int[YoqoajZtPJLcKRAahWwPSlHLMgtj + 1];
				ArrayTools.Fill(lkyfOcEpZPfiRDSqvjwTDSBiKLwl, -1);
				for (int j = 0; j < num; j++)
				{
					lkyfOcEpZPfiRDSqvjwTDSBiKLwl[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb != 0)
				{
					beuKKplZpBDyZxVoJCPYszYXvaTi();
				}
				MHfYtxFEXtovzjkjVuUeTuhHsxPn();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					lNNvPGGCGbRSyRrpaQLNTwrRIxTm = true;
					if (CCaRrIXKHwgLEXKISivrZTzttmTm)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							SWsGHywGBUSukPsStHHPVuFboOKL[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (LogaFgbUQGeLFYCGNLEhSCnnxHIpA)
					{
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_F2] = GetKey(KeyCode.F2);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						SWsGHywGBUSukPsStHHPVuFboOKL[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (lNNvPGGCGbRSyRrpaQLNTwrRIxTm)
				{
					Array.Clear(SWsGHywGBUSukPsStHHPVuFboOKL, 0, SWsGHywGBUSukPsStHHPVuFboOKL.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					vHTcoJcmOTHgiaBOeMiXgpjgAtZxb++;
					if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb == 1)
					{
						CDwcNKAvKNsrAPtZxJWhBAyvdBXiA();
					}
					return;
				}
				vHTcoJcmOTHgiaBOeMiXgpjgAtZxb--;
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb < 0)
				{
					vHTcoJcmOTHgiaBOeMiXgpjgAtZxb = 0;
					sFmtVxsgaHEuwhqPJFwdamCJDQsCA();
				}
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb == 0)
				{
					yUAbxEeKOGFLilOFrFvMnwfpTTbI();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb == 0)
				{
					xzsEQmEjRvnAgZCZyZWCkZUTfJpuA();
					return false;
				}
				if ((uint)keyCode > (uint)YoqoajZtPJLcKRAahWwPSlHLMgtj)
				{
					return false;
				}
				return SWsGHywGBUSukPsStHHPVuFboOKL[lkyfOcEpZPfiRDSqvjwTDSBiKLwl[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (vHTcoJcmOTHgiaBOeMiXgpjgAtZxb == 0)
				{
					xzsEQmEjRvnAgZCZyZWCkZUTfJpuA();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(SWsGHywGBUSukPsStHHPVuFboOKL, values, 132);
				}
			}

			public void Clear()
			{
				if (LogaFgbUQGeLFYCGNLEhSCnnxHIpA)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(zBvQUoQKckJwBGBYdXlGZYYIsXhd, i) < 0)
						{
							SWsGHywGBUSukPsStHHPVuFboOKL[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(SWsGHywGBUSukPsStHHPVuFboOKL, 0, 132);
				}
			}

			private void beuKKplZpBDyZxVoJCPYszYXvaTi()
			{
				Array.Clear(SWsGHywGBUSukPsStHHPVuFboOKL, 0, 132);
			}

			private void MHfYtxFEXtovzjkjVuUeTuhHsxPn()
			{
				vHTcoJcmOTHgiaBOeMiXgpjgAtZxb = 0;
				CCaRrIXKHwgLEXKISivrZTzttmTm = true;
			}

			private void CDwcNKAvKNsrAPtZxJWhBAyvdBXiA()
			{
			}

			private void yUAbxEeKOGFLilOFrFvMnwfpTTbI()
			{
				beuKKplZpBDyZxVoJCPYszYXvaTi();
			}

			private void xzsEQmEjRvnAgZCZyZWCkZUTfJpuA()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void sFmtVxsgaHEuwhqPJFwdamCJDQsCA()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int NuYaOEkhjegQhECARVimDDVcbDpkb = 7;

			private const int XtnrJDOoYLrQRSiNmEAKvEkZtllV = 4;

			private readonly bool[] yhHXOtpfPpFiqTsNsigcXCegohAO;

			private readonly float[] ZXuWvMRZJrGydCJJNyrZyJzyHVEA;

			private int XwwcdaifIypKxJVXtUvrilGdPsPq;

			private Vector3 SLiXQgWqPEgpEFyrVXcsJaaNuclg;

			private bool TaoGnFasVaAAmgEFiHNvMgngrNMfA;

			private bool WdiOvAbRXOwPbEpvuHMSSjJdWZVI;

			public bool monitoring => XwwcdaifIypKxJVXtUvrilGdPsPq > 0;

			public Vector3 mousePosition => SLiXQgWqPEgpEFyrVXcsJaaNuclg;

			public bool mousePresent => TaoGnFasVaAAmgEFiHNvMgngrNMfA;

			public Mouse()
			{
				yhHXOtpfPpFiqTsNsigcXCegohAO = new bool[7];
				ZXuWvMRZJrGydCJJNyrZyJzyHVEA = new float[4];
				zeqGGjUAJDMzGWkfRXEWdvZLTEJD();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					return;
				}
				if (!WdiOvAbRXOwPbEpvuHMSSjJdWZVI)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							yhHXOtpfPpFiqTsNsigcXCegohAO[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							ZXuWvMRZJrGydCJJNyrZyJzyHVEA[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						WdiOvAbRXOwPbEpvuHMSSjJdWZVI = true;
					}
				}
				ZXuWvMRZJrGydCJJNyrZyJzyHVEA[3] = Input.mouseScrollDelta.x;
				SLiXQgWqPEgpEFyrVXcsJaaNuclg = Input.mousePosition;
				TaoGnFasVaAAmgEFiHNvMgngrNMfA = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					XwwcdaifIypKxJVXtUvrilGdPsPq++;
					if (XwwcdaifIypKxJVXtUvrilGdPsPq == 1)
					{
						rSXsnGKyUlizRYdgwUHQSjivJCl();
					}
					return;
				}
				XwwcdaifIypKxJVXtUvrilGdPsPq--;
				if (XwwcdaifIypKxJVXtUvrilGdPsPq < 0)
				{
					XwwcdaifIypKxJVXtUvrilGdPsPq = 0;
					BXCAJRKCwPHDmoqcQWBdWqmRIAtRA();
				}
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					RLoCBxBBLGbzErrpdPUKKTgkTZCJ();
				}
			}

			public bool GetButton(int index)
			{
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					MnIGcrEgAuhydacybccqmmycBmhDE();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return yhHXOtpfPpFiqTsNsigcXCegohAO[index];
			}

			public float GetAxisRaw(int index)
			{
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					MnIGcrEgAuhydacybccqmmycBmhDE();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return ZXuWvMRZJrGydCJJNyrZyJzyHVEA[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					MnIGcrEgAuhydacybccqmmycBmhDE();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(yhHXOtpfPpFiqTsNsigcXCegohAO, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (XwwcdaifIypKxJVXtUvrilGdPsPq == 0)
				{
					MnIGcrEgAuhydacybccqmmycBmhDE();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(ZXuWvMRZJrGydCJJNyrZyJzyHVEA, axes, 4);
				}
			}

			private void TzScLyJMuFzqVCRgZNuNoZxRffORA()
			{
				Array.Clear(yhHXOtpfPpFiqTsNsigcXCegohAO, 0, 7);
				Array.Clear(ZXuWvMRZJrGydCJJNyrZyJzyHVEA, 0, 4);
			}

			private void zeqGGjUAJDMzGWkfRXEWdvZLTEJD()
			{
				XwwcdaifIypKxJVXtUvrilGdPsPq = 0;
				SLiXQgWqPEgpEFyrVXcsJaaNuclg = Vector3.zero;
				TaoGnFasVaAAmgEFiHNvMgngrNMfA = false;
			}

			private void rSXsnGKyUlizRYdgwUHQSjivJCl()
			{
			}

			private void RLoCBxBBLGbzErrpdPUKKTgkTZCJ()
			{
				TzScLyJMuFzqVCRgZNuNoZxRffORA();
			}

			private void MnIGcrEgAuhydacybccqmmycBmhDE()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void BXCAJRKCwPHDmoqcQWBdWqmRIAtRA()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse lGxPExOCEaUwdazexoNOrIkXnKOt;

		private static Keyboard VrcgGAAUwTBtAbaFstxftLrrPNjs;

		public static Mouse mouse => lGxPExOCEaUwdazexoNOrIkXnKOt ?? (lGxPExOCEaUwdazexoNOrIkXnKOt = new Mouse());

		public static Keyboard keyboard => VrcgGAAUwTBtAbaFstxftLrrPNjs ?? (VrcgGAAUwTBtAbaFstxftLrrPNjs = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (VrcgGAAUwTBtAbaFstxftLrrPNjs != null)
			{
				VrcgGAAUwTBtAbaFstxftLrrPNjs.PostInitialize();
			}
			if (lGxPExOCEaUwdazexoNOrIkXnKOt != null)
			{
				lGxPExOCEaUwdazexoNOrIkXnKOt.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (VrcgGAAUwTBtAbaFstxftLrrPNjs != null)
			{
				VrcgGAAUwTBtAbaFstxftLrrPNjs = null;
			}
			if (lGxPExOCEaUwdazexoNOrIkXnKOt != null)
			{
				lGxPExOCEaUwdazexoNOrIkXnKOt = null;
			}
		}

		public static void Update()
		{
			if (VrcgGAAUwTBtAbaFstxftLrrPNjs != null)
			{
				VrcgGAAUwTBtAbaFstxftLrrPNjs.enabled = ReInput.controllers.Keyboard.enabled;
				VrcgGAAUwTBtAbaFstxftLrrPNjs.Update();
			}
			if (lGxPExOCEaUwdazexoNOrIkXnKOt != null)
			{
				lGxPExOCEaUwdazexoNOrIkXnKOt.Update();
			}
		}
	}
}
