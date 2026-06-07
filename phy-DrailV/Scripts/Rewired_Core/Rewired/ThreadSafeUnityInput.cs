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
			private const int ehxtIrqtjsfGYrGrTWIJoANQqAWr = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] RSazTJxfUhjiOLQCUoUdonjmGApBA;

			private readonly int OVuXxxrWhkZTPkIISbbBytPyESOj;

			private readonly int[] EILjPeSCmjzvfzZNxpyfRbFbplmf;

			private readonly bool[] WusJDKbpzaFpRchYdmbiHkaXGSJg;

			private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

			private int YQDfdQrGmkvTSzKmedXEkbGHpNbq;

			private readonly bool WBshyHSrEYgqcTwjPvVfrvvhUmXF;

			private bool QzUsJTGJIKZShSXvYDgBQNwALcc;

			public bool enabled
			{
				get
				{
					return KByWFLCBjjvqwXYVZFDfzPdklyjf;
				}
				set
				{
					if (value != KByWFLCBjjvqwXYVZFDfzPdklyjf)
					{
						KByWFLCBjjvqwXYVZFDfzPdklyjf = value;
						if (!KByWFLCBjjvqwXYVZFDfzPdklyjf)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => YQDfdQrGmkvTSzKmedXEkbGHpNbq > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					RSazTJxfUhjiOLQCUoUdonjmGApBA = new int[7]
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
				WusJDKbpzaFpRchYdmbiHkaXGSJg = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > OVuXxxrWhkZTPkIISbbBytPyESOj)
					{
						OVuXxxrWhkZTPkIISbbBytPyESOj = keyboardKeyValues[i];
					}
				}
				EILjPeSCmjzvfzZNxpyfRbFbplmf = new int[OVuXxxrWhkZTPkIISbbBytPyESOj + 1];
				ArrayTools.Fill(EILjPeSCmjzvfzZNxpyfRbFbplmf, -1);
				for (int j = 0; j < num; j++)
				{
					EILjPeSCmjzvfzZNxpyfRbFbplmf[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq != 0)
				{
					qpUQawNFaaZcEBZUVAIWcXDZlAfI();
				}
				VGCLZHztyTfZQiiaXRrQoHMhyexb();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					QzUsJTGJIKZShSXvYDgBQNwALcc = true;
					if (KByWFLCBjjvqwXYVZFDfzPdklyjf)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							WusJDKbpzaFpRchYdmbiHkaXGSJg[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (WBshyHSrEYgqcTwjPvVfrvvhUmXF)
					{
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_F2] = GetKey(KeyCode.F2);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						WusJDKbpzaFpRchYdmbiHkaXGSJg[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (QzUsJTGJIKZShSXvYDgBQNwALcc)
				{
					Array.Clear(WusJDKbpzaFpRchYdmbiHkaXGSJg, 0, WusJDKbpzaFpRchYdmbiHkaXGSJg.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					YQDfdQrGmkvTSzKmedXEkbGHpNbq++;
					if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 1)
					{
						kJWdXXEsjRHjxjbcbAKpGRyfUeMQ();
					}
					return;
				}
				YQDfdQrGmkvTSzKmedXEkbGHpNbq--;
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq < 0)
				{
					YQDfdQrGmkvTSzKmedXEkbGHpNbq = 0;
					fgQjTOQnlbfGLmVEVgvkllwqgLBj();
				}
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					EwnTUqphZROTOVhyYGagGWoOTMAMA();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					FyiczMEVNLGrNjOeAHVlNTWEByqmA();
					return false;
				}
				if ((uint)keyCode > (uint)OVuXxxrWhkZTPkIISbbBytPyESOj)
				{
					return false;
				}
				return WusJDKbpzaFpRchYdmbiHkaXGSJg[EILjPeSCmjzvfzZNxpyfRbFbplmf[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					FyiczMEVNLGrNjOeAHVlNTWEByqmA();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(WusJDKbpzaFpRchYdmbiHkaXGSJg, values, 132);
				}
			}

			public void Clear()
			{
				if (WBshyHSrEYgqcTwjPvVfrvvhUmXF)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(RSazTJxfUhjiOLQCUoUdonjmGApBA, i) < 0)
						{
							WusJDKbpzaFpRchYdmbiHkaXGSJg[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(WusJDKbpzaFpRchYdmbiHkaXGSJg, 0, 132);
				}
			}

			private void qpUQawNFaaZcEBZUVAIWcXDZlAfI()
			{
				Array.Clear(WusJDKbpzaFpRchYdmbiHkaXGSJg, 0, 132);
			}

			private void VGCLZHztyTfZQiiaXRrQoHMhyexb()
			{
				YQDfdQrGmkvTSzKmedXEkbGHpNbq = 0;
				KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
			}

			private void kJWdXXEsjRHjxjbcbAKpGRyfUeMQ()
			{
			}

			private void EwnTUqphZROTOVhyYGagGWoOTMAMA()
			{
				qpUQawNFaaZcEBZUVAIWcXDZlAfI();
			}

			private void FyiczMEVNLGrNjOeAHVlNTWEByqmA()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void fgQjTOQnlbfGLmVEVgvkllwqgLBj()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int tObjhmgFAEBeFipTpZeFFPDcmxkgA = 7;

			private const int bJwzshhohzRBtbFJNwiiEOrrgtux = 4;

			private readonly bool[] cmXHQZIxDUukeRCdGAxvuSrRrVmb;

			private readonly float[] XAvBnsKJWmbWOYRPcxtibuvFnUYgA;

			private int YQDfdQrGmkvTSzKmedXEkbGHpNbq;

			private Vector3 CxBCLjBJclqOqiemdRNGVoTmODBQ;

			private bool DkjghuiOjNTeEnLvKnUpTbBXixTD;

			private bool TfJhkkkpXQobxvAQijCNhPAliFup;

			public bool monitoring => YQDfdQrGmkvTSzKmedXEkbGHpNbq > 0;

			public Vector3 mousePosition => CxBCLjBJclqOqiemdRNGVoTmODBQ;

			public bool mousePresent => DkjghuiOjNTeEnLvKnUpTbBXixTD;

			public Mouse()
			{
				cmXHQZIxDUukeRCdGAxvuSrRrVmb = new bool[7];
				XAvBnsKJWmbWOYRPcxtibuvFnUYgA = new float[4];
				VGCLZHztyTfZQiiaXRrQoHMhyexb();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					return;
				}
				if (!TfJhkkkpXQobxvAQijCNhPAliFup)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							cmXHQZIxDUukeRCdGAxvuSrRrVmb[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							XAvBnsKJWmbWOYRPcxtibuvFnUYgA[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						TfJhkkkpXQobxvAQijCNhPAliFup = true;
					}
				}
				XAvBnsKJWmbWOYRPcxtibuvFnUYgA[3] = Input.mouseScrollDelta.x;
				CxBCLjBJclqOqiemdRNGVoTmODBQ = Input.mousePosition;
				DkjghuiOjNTeEnLvKnUpTbBXixTD = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					YQDfdQrGmkvTSzKmedXEkbGHpNbq++;
					if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 1)
					{
						kJWdXXEsjRHjxjbcbAKpGRyfUeMQ();
					}
					return;
				}
				YQDfdQrGmkvTSzKmedXEkbGHpNbq--;
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq < 0)
				{
					YQDfdQrGmkvTSzKmedXEkbGHpNbq = 0;
					fgQjTOQnlbfGLmVEVgvkllwqgLBj();
				}
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					EwnTUqphZROTOVhyYGagGWoOTMAMA();
				}
			}

			public bool GetButton(int index)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					BCGiHgiKSAcStYzKIOROImdYWATDA();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index];
			}

			public float GetAxisRaw(int index)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					BCGiHgiKSAcStYzKIOROImdYWATDA();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return XAvBnsKJWmbWOYRPcxtibuvFnUYgA[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					BCGiHgiKSAcStYzKIOROImdYWATDA();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(cmXHQZIxDUukeRCdGAxvuSrRrVmb, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (YQDfdQrGmkvTSzKmedXEkbGHpNbq == 0)
				{
					BCGiHgiKSAcStYzKIOROImdYWATDA();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(XAvBnsKJWmbWOYRPcxtibuvFnUYgA, axes, 4);
				}
			}

			private void qpUQawNFaaZcEBZUVAIWcXDZlAfI()
			{
				Array.Clear(cmXHQZIxDUukeRCdGAxvuSrRrVmb, 0, 7);
				Array.Clear(XAvBnsKJWmbWOYRPcxtibuvFnUYgA, 0, 4);
			}

			private void VGCLZHztyTfZQiiaXRrQoHMhyexb()
			{
				YQDfdQrGmkvTSzKmedXEkbGHpNbq = 0;
				CxBCLjBJclqOqiemdRNGVoTmODBQ = Vector3.zero;
				DkjghuiOjNTeEnLvKnUpTbBXixTD = false;
			}

			private void kJWdXXEsjRHjxjbcbAKpGRyfUeMQ()
			{
			}

			private void EwnTUqphZROTOVhyYGagGWoOTMAMA()
			{
				qpUQawNFaaZcEBZUVAIWcXDZlAfI();
			}

			private void BCGiHgiKSAcStYzKIOROImdYWATDA()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void fgQjTOQnlbfGLmVEVgvkllwqgLBj()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse ZBRAGqgTMsgpryWCyaJhIfhaOhxAB;

		private static Keyboard oFPQoxzrpjVRMipHwUtBJqGgReSB;

		public static Mouse mouse => ZBRAGqgTMsgpryWCyaJhIfhaOhxAB ?? (ZBRAGqgTMsgpryWCyaJhIfhaOhxAB = new Mouse());

		public static Keyboard keyboard => oFPQoxzrpjVRMipHwUtBJqGgReSB ?? (oFPQoxzrpjVRMipHwUtBJqGgReSB = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (oFPQoxzrpjVRMipHwUtBJqGgReSB != null)
			{
				oFPQoxzrpjVRMipHwUtBJqGgReSB.PostInitialize();
			}
			if (ZBRAGqgTMsgpryWCyaJhIfhaOhxAB != null)
			{
				ZBRAGqgTMsgpryWCyaJhIfhaOhxAB.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (oFPQoxzrpjVRMipHwUtBJqGgReSB != null)
			{
				oFPQoxzrpjVRMipHwUtBJqGgReSB = null;
			}
			if (ZBRAGqgTMsgpryWCyaJhIfhaOhxAB != null)
			{
				ZBRAGqgTMsgpryWCyaJhIfhaOhxAB = null;
			}
		}

		public static void Update()
		{
			if (oFPQoxzrpjVRMipHwUtBJqGgReSB != null)
			{
				oFPQoxzrpjVRMipHwUtBJqGgReSB.enabled = ReInput.controllers.Keyboard.enabled;
				oFPQoxzrpjVRMipHwUtBJqGgReSB.Update();
			}
			if (ZBRAGqgTMsgpryWCyaJhIfhaOhxAB != null)
			{
				ZBRAGqgTMsgpryWCyaJhIfhaOhxAB.Update();
			}
		}
	}
}
