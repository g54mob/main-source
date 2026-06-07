using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class ThreadSafeUnityInput
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Keyboard
		{
			private const int ZwBHpSJKaAvuRjJZZedhDosHnYU = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] iAOGqgIxPDPSLVtiGAtFNbStUWb;

			private readonly int rdWmoGEkvOvoCewjGCXfZasrOuI;

			private readonly int[] dtxMxRdhsXLfunxytSkHyaamzSw;

			private readonly bool[] tzWantMecCtCGcgypHWNoVgAMHT;

			private bool fnEBjitvkHhPtXTzRLmBYpIxFbt;

			private int rItyMrAnzYdhNDnMqfmabHvdURrb;

			private readonly bool rMxEqIvJeWWddFXXpARGQYckQDR;

			private bool pyLfJekuPegeYptmntJpybsfYXZ;

			public bool enabled
			{
				get
				{
					return fnEBjitvkHhPtXTzRLmBYpIxFbt;
				}
				set
				{
					if (value != fnEBjitvkHhPtXTzRLmBYpIxFbt)
					{
						fnEBjitvkHhPtXTzRLmBYpIxFbt = value;
						if (!fnEBjitvkHhPtXTzRLmBYpIxFbt)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => rItyMrAnzYdhNDnMqfmabHvdURrb > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					iAOGqgIxPDPSLVtiGAtFNbStUWb = new int[7]
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
				tzWantMecCtCGcgypHWNoVgAMHT = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > rdWmoGEkvOvoCewjGCXfZasrOuI)
					{
						rdWmoGEkvOvoCewjGCXfZasrOuI = keyboardKeyValues[i];
					}
				}
				dtxMxRdhsXLfunxytSkHyaamzSw = new int[rdWmoGEkvOvoCewjGCXfZasrOuI + 1];
				ArrayTools.Fill(dtxMxRdhsXLfunxytSkHyaamzSw, -1);
				for (int j = 0; j < num; j++)
				{
					dtxMxRdhsXLfunxytSkHyaamzSw[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb != 0)
				{
					PJwtlVyxvUbETJYaDjFwVXkSjnp();
				}
				qXicwyGusjNQQcYXJuzNZoiogRa();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					pyLfJekuPegeYptmntJpybsfYXZ = true;
					if (fnEBjitvkHhPtXTzRLmBYpIxFbt)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							tzWantMecCtCGcgypHWNoVgAMHT[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (rMxEqIvJeWWddFXXpARGQYckQDR)
					{
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_F2] = GetKey(KeyCode.F2);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						tzWantMecCtCGcgypHWNoVgAMHT[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (pyLfJekuPegeYptmntJpybsfYXZ)
				{
					Array.Clear(tzWantMecCtCGcgypHWNoVgAMHT, 0, tzWantMecCtCGcgypHWNoVgAMHT.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					rItyMrAnzYdhNDnMqfmabHvdURrb++;
					if (rItyMrAnzYdhNDnMqfmabHvdURrb == 1)
					{
						FbyUodfkMhleMbSHhrfBzJMuwYE();
					}
					return;
				}
				rItyMrAnzYdhNDnMqfmabHvdURrb--;
				if (rItyMrAnzYdhNDnMqfmabHvdURrb < 0)
				{
					rItyMrAnzYdhNDnMqfmabHvdURrb = 0;
					GiQUzfVaZXDWkroPKJCQjNbMwV();
				}
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					rbJJdZQpSfnUVNaIOeZSpJHTtAW();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					ihInClneQtdFKhUYAOkVbaxHUuug();
					return false;
				}
				if ((uint)keyCode > (uint)rdWmoGEkvOvoCewjGCXfZasrOuI)
				{
					return false;
				}
				return tzWantMecCtCGcgypHWNoVgAMHT[dtxMxRdhsXLfunxytSkHyaamzSw[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					ihInClneQtdFKhUYAOkVbaxHUuug();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(tzWantMecCtCGcgypHWNoVgAMHT, values, 132);
				}
			}

			public void Clear()
			{
				if (rMxEqIvJeWWddFXXpARGQYckQDR)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(iAOGqgIxPDPSLVtiGAtFNbStUWb, i) < 0)
						{
							tzWantMecCtCGcgypHWNoVgAMHT[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(tzWantMecCtCGcgypHWNoVgAMHT, 0, 132);
				}
			}

			private void PJwtlVyxvUbETJYaDjFwVXkSjnp()
			{
				Array.Clear(tzWantMecCtCGcgypHWNoVgAMHT, 0, 132);
			}

			private void qXicwyGusjNQQcYXJuzNZoiogRa()
			{
				rItyMrAnzYdhNDnMqfmabHvdURrb = 0;
				fnEBjitvkHhPtXTzRLmBYpIxFbt = true;
			}

			private void FbyUodfkMhleMbSHhrfBzJMuwYE()
			{
			}

			private void rbJJdZQpSfnUVNaIOeZSpJHTtAW()
			{
				PJwtlVyxvUbETJYaDjFwVXkSjnp();
			}

			private void ihInClneQtdFKhUYAOkVbaxHUuug()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void GiQUzfVaZXDWkroPKJCQjNbMwV()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 7;

			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 4;

			private readonly bool[] BSdobvxzcvULrRIsWxFTPPpGtUR;

			private readonly float[] kJHgAHslHMVyHFbvopQSFuUEHCE;

			private int rItyMrAnzYdhNDnMqfmabHvdURrb;

			private Vector3 jLdwcMgErDyorkIYpqTogscbLlZ;

			private bool qADHTQXsNhzuJzqhSYINwHUUqdP;

			private bool szrOGPPIiyIwsryUmxIvAvisHMs;

			public bool monitoring => rItyMrAnzYdhNDnMqfmabHvdURrb > 0;

			public Vector3 mousePosition => jLdwcMgErDyorkIYpqTogscbLlZ;

			public bool mousePresent => qADHTQXsNhzuJzqhSYINwHUUqdP;

			public Mouse()
			{
				BSdobvxzcvULrRIsWxFTPPpGtUR = new bool[7];
				kJHgAHslHMVyHFbvopQSFuUEHCE = new float[4];
				qXicwyGusjNQQcYXJuzNZoiogRa();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					return;
				}
				if (!szrOGPPIiyIwsryUmxIvAvisHMs)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							BSdobvxzcvULrRIsWxFTPPpGtUR[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							kJHgAHslHMVyHFbvopQSFuUEHCE[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						szrOGPPIiyIwsryUmxIvAvisHMs = true;
					}
				}
				kJHgAHslHMVyHFbvopQSFuUEHCE[3] = Input.mouseScrollDelta.x;
				jLdwcMgErDyorkIYpqTogscbLlZ = Input.mousePosition;
				qADHTQXsNhzuJzqhSYINwHUUqdP = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					rItyMrAnzYdhNDnMqfmabHvdURrb++;
					if (rItyMrAnzYdhNDnMqfmabHvdURrb == 1)
					{
						FbyUodfkMhleMbSHhrfBzJMuwYE();
					}
					return;
				}
				rItyMrAnzYdhNDnMqfmabHvdURrb--;
				if (rItyMrAnzYdhNDnMqfmabHvdURrb < 0)
				{
					rItyMrAnzYdhNDnMqfmabHvdURrb = 0;
					GiQUzfVaZXDWkroPKJCQjNbMwV();
				}
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					rbJJdZQpSfnUVNaIOeZSpJHTtAW();
				}
			}

			public bool GetButton(int index)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					kmiOuZlMNmHucbBsYTqaZUWVrKL();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return BSdobvxzcvULrRIsWxFTPPpGtUR[index];
			}

			public float GetAxisRaw(int index)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					kmiOuZlMNmHucbBsYTqaZUWVrKL();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return kJHgAHslHMVyHFbvopQSFuUEHCE[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					kmiOuZlMNmHucbBsYTqaZUWVrKL();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(BSdobvxzcvULrRIsWxFTPPpGtUR, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (rItyMrAnzYdhNDnMqfmabHvdURrb == 0)
				{
					kmiOuZlMNmHucbBsYTqaZUWVrKL();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(kJHgAHslHMVyHFbvopQSFuUEHCE, axes, 4);
				}
			}

			private void PJwtlVyxvUbETJYaDjFwVXkSjnp()
			{
				Array.Clear(BSdobvxzcvULrRIsWxFTPPpGtUR, 0, 7);
				Array.Clear(kJHgAHslHMVyHFbvopQSFuUEHCE, 0, 4);
			}

			private void qXicwyGusjNQQcYXJuzNZoiogRa()
			{
				rItyMrAnzYdhNDnMqfmabHvdURrb = 0;
				jLdwcMgErDyorkIYpqTogscbLlZ = Vector3.zero;
				qADHTQXsNhzuJzqhSYINwHUUqdP = false;
			}

			private void FbyUodfkMhleMbSHhrfBzJMuwYE()
			{
			}

			private void rbJJdZQpSfnUVNaIOeZSpJHTtAW()
			{
				PJwtlVyxvUbETJYaDjFwVXkSjnp();
			}

			private void kmiOuZlMNmHucbBsYTqaZUWVrKL()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void GiQUzfVaZXDWkroPKJCQjNbMwV()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse slbHvFaONIcHgSmumuuNAAIZyjt;

		private static Keyboard RbzbjFADsNfrYwMPVtwBejJhJVw;

		public static Mouse mouse => slbHvFaONIcHgSmumuuNAAIZyjt ?? (slbHvFaONIcHgSmumuuNAAIZyjt = new Mouse());

		public static Keyboard keyboard => RbzbjFADsNfrYwMPVtwBejJhJVw ?? (RbzbjFADsNfrYwMPVtwBejJhJVw = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (RbzbjFADsNfrYwMPVtwBejJhJVw != null)
			{
				RbzbjFADsNfrYwMPVtwBejJhJVw.PostInitialize();
			}
			if (slbHvFaONIcHgSmumuuNAAIZyjt != null)
			{
				slbHvFaONIcHgSmumuuNAAIZyjt.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (RbzbjFADsNfrYwMPVtwBejJhJVw != null)
			{
				RbzbjFADsNfrYwMPVtwBejJhJVw = null;
			}
			if (slbHvFaONIcHgSmumuuNAAIZyjt != null)
			{
				slbHvFaONIcHgSmumuuNAAIZyjt = null;
			}
		}

		public static void Update()
		{
			if (RbzbjFADsNfrYwMPVtwBejJhJVw != null)
			{
				RbzbjFADsNfrYwMPVtwBejJhJVw.enabled = ReInput.controllers.Keyboard.enabled;
				RbzbjFADsNfrYwMPVtwBejJhJVw.Update();
			}
			if (slbHvFaONIcHgSmumuuNAAIZyjt != null)
			{
				slbHvFaONIcHgSmumuuNAAIZyjt.Update();
			}
		}
	}
}
