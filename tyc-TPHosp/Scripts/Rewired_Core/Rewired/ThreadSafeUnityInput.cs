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
			private const int dCfZAcoPBTIBLdotUSvkGLJtaGkM = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] KrqvZMprqAobXQTYPchWVkxXNIZ;

			private readonly int BukTegbYDJItSjLUZOcyVNBHKSu;

			private readonly int[] RIVBtlAbAYNoaeaBwCECfoVCFnIT;

			private readonly bool[] DweVMBpPPXSyWlIhmDaVoAakIIp;

			private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF;

			private int NSPgjZtsQNqAJsTenRgxLHSwCPD;

			private readonly bool DBibHQQRifdUpWAxGQiYCmvSEMn;

			private bool DcpAdYTkAlTCTcKAidfuoMGNIzp;

			public bool enabled
			{
				get
				{
					return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
				}
				set
				{
					if (value != TAiAzEAcNOkrpYWJEmhYYqnFvpF)
					{
						TAiAzEAcNOkrpYWJEmhYYqnFvpF = value;
						if (!TAiAzEAcNOkrpYWJEmhYYqnFvpF)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => NSPgjZtsQNqAJsTenRgxLHSwCPD > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					KrqvZMprqAobXQTYPchWVkxXNIZ = new int[7]
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
				DweVMBpPPXSyWlIhmDaVoAakIIp = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > BukTegbYDJItSjLUZOcyVNBHKSu)
					{
						BukTegbYDJItSjLUZOcyVNBHKSu = keyboardKeyValues[i];
					}
				}
				RIVBtlAbAYNoaeaBwCECfoVCFnIT = new int[BukTegbYDJItSjLUZOcyVNBHKSu + 1];
				ArrayTools.Fill(RIVBtlAbAYNoaeaBwCECfoVCFnIT, -1);
				for (int j = 0; j < num; j++)
				{
					RIVBtlAbAYNoaeaBwCECfoVCFnIT[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD != 0)
				{
					dNIAwpZWOJSsFWMNKjahBJNgdnT();
				}
				OhOZdYxFTscbQxoVMmQSNNzYgeU();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					DcpAdYTkAlTCTcKAidfuoMGNIzp = true;
					if (TAiAzEAcNOkrpYWJEmhYYqnFvpF)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							DweVMBpPPXSyWlIhmDaVoAakIIp[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (DBibHQQRifdUpWAxGQiYCmvSEMn)
					{
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_F2] = GetKey(KeyCode.F2);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						DweVMBpPPXSyWlIhmDaVoAakIIp[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (DcpAdYTkAlTCTcKAidfuoMGNIzp)
				{
					Array.Clear(DweVMBpPPXSyWlIhmDaVoAakIIp, 0, DweVMBpPPXSyWlIhmDaVoAakIIp.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					NSPgjZtsQNqAJsTenRgxLHSwCPD++;
					if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 1)
					{
						fiMxGGEuNsSJgouqqzQCdacUeHs();
					}
					return;
				}
				NSPgjZtsQNqAJsTenRgxLHSwCPD--;
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD < 0)
				{
					NSPgjZtsQNqAJsTenRgxLHSwCPD = 0;
					gKGrBZCMVEgTWfQuMDBRMjiLcbx();
				}
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					LXzUOdlyfaaOZGxmXWPPlPatjMs();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					CXwArVjOtuCkMTZwNgkSKgAjqgIB();
					return false;
				}
				if ((uint)keyCode > (uint)BukTegbYDJItSjLUZOcyVNBHKSu)
				{
					return false;
				}
				return DweVMBpPPXSyWlIhmDaVoAakIIp[RIVBtlAbAYNoaeaBwCECfoVCFnIT[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					CXwArVjOtuCkMTZwNgkSKgAjqgIB();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(DweVMBpPPXSyWlIhmDaVoAakIIp, values, 132);
				}
			}

			public void Clear()
			{
				if (DBibHQQRifdUpWAxGQiYCmvSEMn)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(KrqvZMprqAobXQTYPchWVkxXNIZ, i) < 0)
						{
							DweVMBpPPXSyWlIhmDaVoAakIIp[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(DweVMBpPPXSyWlIhmDaVoAakIIp, 0, 132);
				}
			}

			private void dNIAwpZWOJSsFWMNKjahBJNgdnT()
			{
				Array.Clear(DweVMBpPPXSyWlIhmDaVoAakIIp, 0, 132);
			}

			private void OhOZdYxFTscbQxoVMmQSNNzYgeU()
			{
				NSPgjZtsQNqAJsTenRgxLHSwCPD = 0;
				TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;
			}

			private void fiMxGGEuNsSJgouqqzQCdacUeHs()
			{
			}

			private void LXzUOdlyfaaOZGxmXWPPlPatjMs()
			{
				dNIAwpZWOJSsFWMNKjahBJNgdnT();
			}

			private void CXwArVjOtuCkMTZwNgkSKgAjqgIB()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void gKGrBZCMVEgTWfQuMDBRMjiLcbx()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 7;

			private const int skotmctbDSWIawJPITTDnlfQMrI = 4;

			private readonly bool[] fMHXJPWJIudshUOjLfHOLECkvEl;

			private readonly float[] SGnVxfDVyVHHLMKJxLIJFpveDKaH;

			private int NSPgjZtsQNqAJsTenRgxLHSwCPD;

			private Vector3 VXTXEuTzKGLJfhiUwichyCLLHXh;

			private bool MExeitwgrqUNGwToFSUXcvUmapm;

			private bool ULTbZbiPhthAeafWvGryIIASPZE;

			public bool monitoring => NSPgjZtsQNqAJsTenRgxLHSwCPD > 0;

			public Vector3 mousePosition => VXTXEuTzKGLJfhiUwichyCLLHXh;

			public bool mousePresent => MExeitwgrqUNGwToFSUXcvUmapm;

			public Mouse()
			{
				fMHXJPWJIudshUOjLfHOLECkvEl = new bool[7];
				SGnVxfDVyVHHLMKJxLIJFpveDKaH = new float[4];
				OhOZdYxFTscbQxoVMmQSNNzYgeU();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					return;
				}
				if (!ULTbZbiPhthAeafWvGryIIASPZE)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							fMHXJPWJIudshUOjLfHOLECkvEl[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							SGnVxfDVyVHHLMKJxLIJFpveDKaH[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						ULTbZbiPhthAeafWvGryIIASPZE = true;
					}
				}
				SGnVxfDVyVHHLMKJxLIJFpveDKaH[3] = Input.mouseScrollDelta.x;
				VXTXEuTzKGLJfhiUwichyCLLHXh = Input.mousePosition;
				MExeitwgrqUNGwToFSUXcvUmapm = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					NSPgjZtsQNqAJsTenRgxLHSwCPD++;
					if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 1)
					{
						fiMxGGEuNsSJgouqqzQCdacUeHs();
					}
					return;
				}
				NSPgjZtsQNqAJsTenRgxLHSwCPD--;
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD < 0)
				{
					NSPgjZtsQNqAJsTenRgxLHSwCPD = 0;
					gKGrBZCMVEgTWfQuMDBRMjiLcbx();
				}
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					LXzUOdlyfaaOZGxmXWPPlPatjMs();
				}
			}

			public bool GetButton(int index)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					WiWeBzfIuxjXmAsSCZcdELfAtOdh();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return fMHXJPWJIudshUOjLfHOLECkvEl[index];
			}

			public float GetAxisRaw(int index)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					WiWeBzfIuxjXmAsSCZcdELfAtOdh();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return SGnVxfDVyVHHLMKJxLIJFpveDKaH[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					WiWeBzfIuxjXmAsSCZcdELfAtOdh();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(fMHXJPWJIudshUOjLfHOLECkvEl, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (NSPgjZtsQNqAJsTenRgxLHSwCPD == 0)
				{
					WiWeBzfIuxjXmAsSCZcdELfAtOdh();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(SGnVxfDVyVHHLMKJxLIJFpveDKaH, axes, 4);
				}
			}

			private void dNIAwpZWOJSsFWMNKjahBJNgdnT()
			{
				Array.Clear(fMHXJPWJIudshUOjLfHOLECkvEl, 0, 7);
				Array.Clear(SGnVxfDVyVHHLMKJxLIJFpveDKaH, 0, 4);
			}

			private void OhOZdYxFTscbQxoVMmQSNNzYgeU()
			{
				NSPgjZtsQNqAJsTenRgxLHSwCPD = 0;
				VXTXEuTzKGLJfhiUwichyCLLHXh = Vector3.zero;
				MExeitwgrqUNGwToFSUXcvUmapm = false;
			}

			private void fiMxGGEuNsSJgouqqzQCdacUeHs()
			{
			}

			private void LXzUOdlyfaaOZGxmXWPPlPatjMs()
			{
				dNIAwpZWOJSsFWMNKjahBJNgdnT();
			}

			private void WiWeBzfIuxjXmAsSCZcdELfAtOdh()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void gKGrBZCMVEgTWfQuMDBRMjiLcbx()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse MHHxCnPJuVpyaLEYrQeUALhfptZ;

		private static Keyboard flBQCxhJlEGYufzaQtAAiyGFDOS;

		public static Mouse mouse => MHHxCnPJuVpyaLEYrQeUALhfptZ ?? (MHHxCnPJuVpyaLEYrQeUALhfptZ = new Mouse());

		public static Keyboard keyboard => flBQCxhJlEGYufzaQtAAiyGFDOS ?? (flBQCxhJlEGYufzaQtAAiyGFDOS = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (flBQCxhJlEGYufzaQtAAiyGFDOS != null)
			{
				flBQCxhJlEGYufzaQtAAiyGFDOS.PostInitialize();
			}
			if (MHHxCnPJuVpyaLEYrQeUALhfptZ != null)
			{
				MHHxCnPJuVpyaLEYrQeUALhfptZ.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (flBQCxhJlEGYufzaQtAAiyGFDOS != null)
			{
				flBQCxhJlEGYufzaQtAAiyGFDOS = null;
			}
			if (MHHxCnPJuVpyaLEYrQeUALhfptZ != null)
			{
				MHHxCnPJuVpyaLEYrQeUALhfptZ = null;
			}
		}

		public static void Update()
		{
			if (flBQCxhJlEGYufzaQtAAiyGFDOS != null)
			{
				flBQCxhJlEGYufzaQtAAiyGFDOS.enabled = ReInput.controllers.Keyboard.enabled;
				flBQCxhJlEGYufzaQtAAiyGFDOS.Update();
			}
			if (MHHxCnPJuVpyaLEYrQeUALhfptZ != null)
			{
				MHHxCnPJuVpyaLEYrQeUALhfptZ.Update();
			}
		}
	}
}
