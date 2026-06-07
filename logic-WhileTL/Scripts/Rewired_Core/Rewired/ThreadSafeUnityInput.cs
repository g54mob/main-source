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
			private const int RXjRgsOMDkllwCDJkaPbnwoTSzQH = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] ewmMiMDnonJriaNsfivBtvQjMOzi;

			private readonly int bSkEQoFNHmMejiZadjRvNbwinMCUE;

			private readonly int[] nfBdsxGcSnOQTMYpOdFZnKqcjnilA;

			private readonly bool[] freVGZZoLcUutVigWPIUYOXCaOFo;

			private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

			private int hHHiPLJOcmgggAGjRdFsxfAOXIlG;

			private readonly bool jYeZsMeNsIJLGmlRwyPXaqKuUsHK;

			private bool zyteTGlFgKrfnMkkIGebhCxfFOBXA;

			public bool enabled
			{
				get
				{
					return llkLFSoLVtaASCstwdnHCsIDxnhYb;
				}
				set
				{
					if (value != llkLFSoLVtaASCstwdnHCsIDxnhYb)
					{
						llkLFSoLVtaASCstwdnHCsIDxnhYb = value;
						if (!llkLFSoLVtaASCstwdnHCsIDxnhYb)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => hHHiPLJOcmgggAGjRdFsxfAOXIlG > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					ewmMiMDnonJriaNsfivBtvQjMOzi = new int[7]
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
				freVGZZoLcUutVigWPIUYOXCaOFo = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > bSkEQoFNHmMejiZadjRvNbwinMCUE)
					{
						bSkEQoFNHmMejiZadjRvNbwinMCUE = keyboardKeyValues[i];
					}
				}
				nfBdsxGcSnOQTMYpOdFZnKqcjnilA = new int[bSkEQoFNHmMejiZadjRvNbwinMCUE + 1];
				ArrayTools.Fill(nfBdsxGcSnOQTMYpOdFZnKqcjnilA, -1);
				for (int j = 0; j < num; j++)
				{
					nfBdsxGcSnOQTMYpOdFZnKqcjnilA[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG != 0)
				{
					DmAsJbfQQaaUsgDgiDywzbcGfubK();
				}
				iqSeAMNoRFWAzJLKanbJnrgyPcwX();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					zyteTGlFgKrfnMkkIGebhCxfFOBXA = true;
					if (llkLFSoLVtaASCstwdnHCsIDxnhYb)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							freVGZZoLcUutVigWPIUYOXCaOFo[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (jYeZsMeNsIJLGmlRwyPXaqKuUsHK)
					{
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_F2] = GetKey(KeyCode.F2);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						freVGZZoLcUutVigWPIUYOXCaOFo[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (zyteTGlFgKrfnMkkIGebhCxfFOBXA)
				{
					Array.Clear(freVGZZoLcUutVigWPIUYOXCaOFo, 0, freVGZZoLcUutVigWPIUYOXCaOFo.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					hHHiPLJOcmgggAGjRdFsxfAOXIlG++;
					if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 1)
					{
						LtUUiWcLZFdoJIVOQEyPFpJckyCw();
					}
					return;
				}
				hHHiPLJOcmgggAGjRdFsxfAOXIlG--;
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG < 0)
				{
					hHHiPLJOcmgggAGjRdFsxfAOXIlG = 0;
					QCWAqVkqFddIpdFaitIGikJfbiFhB();
				}
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					jMzDHhPwtJmEmgfQrCGWVHZXAKKv();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					iOwcaJiNhHoUtnrAzFfLGltXcegHA();
					return false;
				}
				if ((uint)keyCode > (uint)bSkEQoFNHmMejiZadjRvNbwinMCUE)
				{
					return false;
				}
				return freVGZZoLcUutVigWPIUYOXCaOFo[nfBdsxGcSnOQTMYpOdFZnKqcjnilA[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					iOwcaJiNhHoUtnrAzFfLGltXcegHA();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(freVGZZoLcUutVigWPIUYOXCaOFo, values, 132);
				}
			}

			public void Clear()
			{
				if (jYeZsMeNsIJLGmlRwyPXaqKuUsHK)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(ewmMiMDnonJriaNsfivBtvQjMOzi, i) < 0)
						{
							freVGZZoLcUutVigWPIUYOXCaOFo[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(freVGZZoLcUutVigWPIUYOXCaOFo, 0, 132);
				}
			}

			private void DmAsJbfQQaaUsgDgiDywzbcGfubK()
			{
				Array.Clear(freVGZZoLcUutVigWPIUYOXCaOFo, 0, 132);
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
				hHHiPLJOcmgggAGjRdFsxfAOXIlG = 0;
				llkLFSoLVtaASCstwdnHCsIDxnhYb = true;
			}

			private void LtUUiWcLZFdoJIVOQEyPFpJckyCw()
			{
			}

			private void jMzDHhPwtJmEmgfQrCGWVHZXAKKv()
			{
				DmAsJbfQQaaUsgDgiDywzbcGfubK();
			}

			private void iOwcaJiNhHoUtnrAzFfLGltXcegHA()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void QCWAqVkqFddIpdFaitIGikJfbiFhB()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int CslwhBCeGKNctEjyAWkxAmQhbouC = 7;

			private const int AaihlwBABrsvNIbzidACPdKeixsCA = 4;

			private readonly bool[] ZvPFEBoODFIFAalgjPuHlidSttRw;

			private readonly float[] oelaYhnmcedAmsllPBWChpEQMWAf;

			private int hHHiPLJOcmgggAGjRdFsxfAOXIlG;

			private Vector3 rgTEYyHlAbgfWCHMWSrszGgvNFThA;

			private bool ytxhvgKCwJNkiUItnUJFKgIUvyVq;

			private bool gOTTwzSodYNHJYteHDopaepqDXihA;

			public bool monitoring => hHHiPLJOcmgggAGjRdFsxfAOXIlG > 0;

			public Vector3 mousePosition => rgTEYyHlAbgfWCHMWSrszGgvNFThA;

			public bool mousePresent => ytxhvgKCwJNkiUItnUJFKgIUvyVq;

			public Mouse()
			{
				ZvPFEBoODFIFAalgjPuHlidSttRw = new bool[7];
				oelaYhnmcedAmsllPBWChpEQMWAf = new float[4];
				iqSeAMNoRFWAzJLKanbJnrgyPcwX();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					return;
				}
				if (!gOTTwzSodYNHJYteHDopaepqDXihA)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							ZvPFEBoODFIFAalgjPuHlidSttRw[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							oelaYhnmcedAmsllPBWChpEQMWAf[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						gOTTwzSodYNHJYteHDopaepqDXihA = true;
					}
				}
				oelaYhnmcedAmsllPBWChpEQMWAf[3] = Input.mouseScrollDelta.x;
				rgTEYyHlAbgfWCHMWSrszGgvNFThA = Input.mousePosition;
				ytxhvgKCwJNkiUItnUJFKgIUvyVq = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					hHHiPLJOcmgggAGjRdFsxfAOXIlG++;
					if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 1)
					{
						LtUUiWcLZFdoJIVOQEyPFpJckyCw();
					}
					return;
				}
				hHHiPLJOcmgggAGjRdFsxfAOXIlG--;
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG < 0)
				{
					hHHiPLJOcmgggAGjRdFsxfAOXIlG = 0;
					QCWAqVkqFddIpdFaitIGikJfbiFhB();
				}
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					jMzDHhPwtJmEmgfQrCGWVHZXAKKv();
				}
			}

			public bool GetButton(int index)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					oFMdIngisYAfVIEwlujgcvGDvCBvA();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return ZvPFEBoODFIFAalgjPuHlidSttRw[index];
			}

			public float GetAxisRaw(int index)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					oFMdIngisYAfVIEwlujgcvGDvCBvA();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return oelaYhnmcedAmsllPBWChpEQMWAf[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					oFMdIngisYAfVIEwlujgcvGDvCBvA();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(ZvPFEBoODFIFAalgjPuHlidSttRw, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (hHHiPLJOcmgggAGjRdFsxfAOXIlG == 0)
				{
					oFMdIngisYAfVIEwlujgcvGDvCBvA();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(oelaYhnmcedAmsllPBWChpEQMWAf, axes, 4);
				}
			}

			private void DmAsJbfQQaaUsgDgiDywzbcGfubK()
			{
				Array.Clear(ZvPFEBoODFIFAalgjPuHlidSttRw, 0, 7);
				Array.Clear(oelaYhnmcedAmsllPBWChpEQMWAf, 0, 4);
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
				hHHiPLJOcmgggAGjRdFsxfAOXIlG = 0;
				rgTEYyHlAbgfWCHMWSrszGgvNFThA = Vector3.zero;
				ytxhvgKCwJNkiUItnUJFKgIUvyVq = false;
			}

			private void LtUUiWcLZFdoJIVOQEyPFpJckyCw()
			{
			}

			private void jMzDHhPwtJmEmgfQrCGWVHZXAKKv()
			{
				DmAsJbfQQaaUsgDgiDywzbcGfubK();
			}

			private void oFMdIngisYAfVIEwlujgcvGDvCBvA()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void QCWAqVkqFddIpdFaitIGikJfbiFhB()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse efFBGlzgiieSBvsyNvhDahCFSnlM;

		private static Keyboard HpBePlHRDrcclVCNoiaHkUPloXeDA;

		public static Mouse mouse => efFBGlzgiieSBvsyNvhDahCFSnlM ?? (efFBGlzgiieSBvsyNvhDahCFSnlM = new Mouse());

		public static Keyboard keyboard => HpBePlHRDrcclVCNoiaHkUPloXeDA ?? (HpBePlHRDrcclVCNoiaHkUPloXeDA = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (HpBePlHRDrcclVCNoiaHkUPloXeDA != null)
			{
				HpBePlHRDrcclVCNoiaHkUPloXeDA.PostInitialize();
			}
			if (efFBGlzgiieSBvsyNvhDahCFSnlM != null)
			{
				efFBGlzgiieSBvsyNvhDahCFSnlM.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (HpBePlHRDrcclVCNoiaHkUPloXeDA != null)
			{
				HpBePlHRDrcclVCNoiaHkUPloXeDA = null;
			}
			if (efFBGlzgiieSBvsyNvhDahCFSnlM != null)
			{
				efFBGlzgiieSBvsyNvhDahCFSnlM = null;
			}
		}

		public static void Update()
		{
			if (HpBePlHRDrcclVCNoiaHkUPloXeDA != null)
			{
				HpBePlHRDrcclVCNoiaHkUPloXeDA.enabled = ReInput.controllers.Keyboard.enabled;
				HpBePlHRDrcclVCNoiaHkUPloXeDA.Update();
			}
			if (efFBGlzgiieSBvsyNvhDahCFSnlM != null)
			{
				efFBGlzgiieSBvsyNvhDahCFSnlM.Update();
			}
		}
	}
}
