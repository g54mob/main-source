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
			private const int ONhRyfEzSbudGIoyRnkfedhSqWGl = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] CNPNvICEzygUAHrJDadbSRdiOiiwA;

			private readonly int fKXkVJFsHBOHiQpJWmcSisztUyr;

			private readonly int[] KAACfYGaIRCeUahtVrTcZomWZGpU;

			private readonly bool[] bMAhPIeKRWRdlgcVVfdqPGmNBmTw;

			private bool zMGPQsXeOkbSXfyHshJEDRWBjcGGb;

			private int EkzaPzmqTPAxvolLAWQufoQyDrMEA;

			private readonly bool gPGFsCeOVOuCQGhLrFmYhWMFDTVCc;

			private bool SdtymcWqJjNNpwJsIHbsJJAffzMt;

			public bool enabled
			{
				get
				{
					return zMGPQsXeOkbSXfyHshJEDRWBjcGGb;
				}
				set
				{
					if (value != zMGPQsXeOkbSXfyHshJEDRWBjcGGb)
					{
						zMGPQsXeOkbSXfyHshJEDRWBjcGGb = value;
						if (!zMGPQsXeOkbSXfyHshJEDRWBjcGGb)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => EkzaPzmqTPAxvolLAWQufoQyDrMEA > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					CNPNvICEzygUAHrJDadbSRdiOiiwA = new int[7]
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
				bMAhPIeKRWRdlgcVVfdqPGmNBmTw = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > fKXkVJFsHBOHiQpJWmcSisztUyr)
					{
						fKXkVJFsHBOHiQpJWmcSisztUyr = keyboardKeyValues[i];
					}
				}
				KAACfYGaIRCeUahtVrTcZomWZGpU = new int[fKXkVJFsHBOHiQpJWmcSisztUyr + 1];
				ArrayTools.Fill(KAACfYGaIRCeUahtVrTcZomWZGpU, -1);
				for (int j = 0; j < num; j++)
				{
					KAACfYGaIRCeUahtVrTcZomWZGpU[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA != 0)
				{
					UOOHzFnKkFQrOORbtSctyIbbJdMfA();
				}
				xJLWQNLPKtukmEpexIeFFSWpVzWS();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					SdtymcWqJjNNpwJsIHbsJJAffzMt = true;
					if (zMGPQsXeOkbSXfyHshJEDRWBjcGGb)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							bMAhPIeKRWRdlgcVVfdqPGmNBmTw[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (gPGFsCeOVOuCQGhLrFmYhWMFDTVCc)
					{
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_F2] = GetKey(KeyCode.F2);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						bMAhPIeKRWRdlgcVVfdqPGmNBmTw[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (SdtymcWqJjNNpwJsIHbsJJAffzMt)
				{
					Array.Clear(bMAhPIeKRWRdlgcVVfdqPGmNBmTw, 0, bMAhPIeKRWRdlgcVVfdqPGmNBmTw.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					EkzaPzmqTPAxvolLAWQufoQyDrMEA++;
					if (EkzaPzmqTPAxvolLAWQufoQyDrMEA == 1)
					{
						xoCAyqYUPPByTwxMTeZWPePTJhQf();
					}
					return;
				}
				EkzaPzmqTPAxvolLAWQufoQyDrMEA--;
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA < 0)
				{
					EkzaPzmqTPAxvolLAWQufoQyDrMEA = 0;
					FGCBOVcOvBebdeSIdcESOkjhTMbJA();
				}
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA == 0)
				{
					ZveCYuwSRCWHlEqOPpLphIMZFWul();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA == 0)
				{
					EyEAdQBhWhKVjqzYYSinCNfjzHsY();
					return false;
				}
				if ((uint)keyCode > (uint)fKXkVJFsHBOHiQpJWmcSisztUyr)
				{
					return false;
				}
				return bMAhPIeKRWRdlgcVVfdqPGmNBmTw[KAACfYGaIRCeUahtVrTcZomWZGpU[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (EkzaPzmqTPAxvolLAWQufoQyDrMEA == 0)
				{
					EyEAdQBhWhKVjqzYYSinCNfjzHsY();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(bMAhPIeKRWRdlgcVVfdqPGmNBmTw, values, 132);
				}
			}

			public void Clear()
			{
				if (gPGFsCeOVOuCQGhLrFmYhWMFDTVCc)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(CNPNvICEzygUAHrJDadbSRdiOiiwA, i) < 0)
						{
							bMAhPIeKRWRdlgcVVfdqPGmNBmTw[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(bMAhPIeKRWRdlgcVVfdqPGmNBmTw, 0, 132);
				}
			}

			private void UOOHzFnKkFQrOORbtSctyIbbJdMfA()
			{
				Array.Clear(bMAhPIeKRWRdlgcVVfdqPGmNBmTw, 0, 132);
			}

			private void xJLWQNLPKtukmEpexIeFFSWpVzWS()
			{
				EkzaPzmqTPAxvolLAWQufoQyDrMEA = 0;
				zMGPQsXeOkbSXfyHshJEDRWBjcGGb = true;
			}

			private void xoCAyqYUPPByTwxMTeZWPePTJhQf()
			{
			}

			private void ZveCYuwSRCWHlEqOPpLphIMZFWul()
			{
				UOOHzFnKkFQrOORbtSctyIbbJdMfA();
			}

			private void EyEAdQBhWhKVjqzYYSinCNfjzHsY()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void FGCBOVcOvBebdeSIdcESOkjhTMbJA()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int syqEpeajmgPBypzPdiMZTHmXGHoTA = 7;

			private const int wHZMgzCBZPaDEijQSsavfvNfKhyKA = 4;

			private readonly bool[] PlvckVhROnoxrmFECvEJDQPWHpJu;

			private readonly float[] iunxPeHEfDVHpbUNpKGtgmBTDFQd;

			private int aiAdEKFtHkMPgQyAPMBWVynFFmIjA;

			private Vector3 bXIysGMcxEtEVaftxctJVdPrEioGA;

			private bool yzKgCnsdKaUTjxSCSgbGwPAOORPn;

			private bool bnSvLctNIMvZutDeKjnnMVaTQUGF;

			public bool monitoring => aiAdEKFtHkMPgQyAPMBWVynFFmIjA > 0;

			public Vector3 mousePosition => bXIysGMcxEtEVaftxctJVdPrEioGA;

			public bool mousePresent => yzKgCnsdKaUTjxSCSgbGwPAOORPn;

			public Mouse()
			{
				PlvckVhROnoxrmFECvEJDQPWHpJu = new bool[7];
				iunxPeHEfDVHpbUNpKGtgmBTDFQd = new float[4];
				YDSvioOFCVFpwvxvdxRbnClvRIEe();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					return;
				}
				if (!bnSvLctNIMvZutDeKjnnMVaTQUGF)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							PlvckVhROnoxrmFECvEJDQPWHpJu[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							iunxPeHEfDVHpbUNpKGtgmBTDFQd[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						bnSvLctNIMvZutDeKjnnMVaTQUGF = true;
					}
				}
				iunxPeHEfDVHpbUNpKGtgmBTDFQd[3] = Input.mouseScrollDelta.x;
				bXIysGMcxEtEVaftxctJVdPrEioGA = Input.mousePosition;
				yzKgCnsdKaUTjxSCSgbGwPAOORPn = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					aiAdEKFtHkMPgQyAPMBWVynFFmIjA++;
					if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 1)
					{
						GyyDVQGhjSkIwmeKOYtoQCtIbxFe();
					}
					return;
				}
				aiAdEKFtHkMPgQyAPMBWVynFFmIjA--;
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA < 0)
				{
					aiAdEKFtHkMPgQyAPMBWVynFFmIjA = 0;
					aashybAMdJpOtFLpcmnIqiRHrOuBc();
				}
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					ycIlJPPCWOceZWPiHjpfMgPSHsTk();
				}
			}

			public bool GetButton(int index)
			{
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					jLebBNHiFqupkxZpUxYBteRlZqClA();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return PlvckVhROnoxrmFECvEJDQPWHpJu[index];
			}

			public float GetAxisRaw(int index)
			{
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					jLebBNHiFqupkxZpUxYBteRlZqClA();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return iunxPeHEfDVHpbUNpKGtgmBTDFQd[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					jLebBNHiFqupkxZpUxYBteRlZqClA();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(PlvckVhROnoxrmFECvEJDQPWHpJu, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (aiAdEKFtHkMPgQyAPMBWVynFFmIjA == 0)
				{
					jLebBNHiFqupkxZpUxYBteRlZqClA();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(iunxPeHEfDVHpbUNpKGtgmBTDFQd, axes, 4);
				}
			}

			private void iawCaMCWpDBtEFkdAlAmvJUotpBDB()
			{
				Array.Clear(PlvckVhROnoxrmFECvEJDQPWHpJu, 0, 7);
				Array.Clear(iunxPeHEfDVHpbUNpKGtgmBTDFQd, 0, 4);
			}

			private void YDSvioOFCVFpwvxvdxRbnClvRIEe()
			{
				aiAdEKFtHkMPgQyAPMBWVynFFmIjA = 0;
				bXIysGMcxEtEVaftxctJVdPrEioGA = Vector3.zero;
				yzKgCnsdKaUTjxSCSgbGwPAOORPn = false;
			}

			private void GyyDVQGhjSkIwmeKOYtoQCtIbxFe()
			{
			}

			private void ycIlJPPCWOceZWPiHjpfMgPSHsTk()
			{
				iawCaMCWpDBtEFkdAlAmvJUotpBDB();
			}

			private void jLebBNHiFqupkxZpUxYBteRlZqClA()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void aashybAMdJpOtFLpcmnIqiRHrOuBc()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse QIHotNQNRkofaZbdLmxjjVBbwURm;

		private static Keyboard aDGGrmEehPGwXhOCIUXOGnWBdNyYA;

		public static Mouse mouse => QIHotNQNRkofaZbdLmxjjVBbwURm ?? (QIHotNQNRkofaZbdLmxjjVBbwURm = new Mouse());

		public static Keyboard keyboard => aDGGrmEehPGwXhOCIUXOGnWBdNyYA ?? (aDGGrmEehPGwXhOCIUXOGnWBdNyYA = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (aDGGrmEehPGwXhOCIUXOGnWBdNyYA != null)
			{
				aDGGrmEehPGwXhOCIUXOGnWBdNyYA.PostInitialize();
			}
			if (QIHotNQNRkofaZbdLmxjjVBbwURm != null)
			{
				QIHotNQNRkofaZbdLmxjjVBbwURm.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (aDGGrmEehPGwXhOCIUXOGnWBdNyYA != null)
			{
				aDGGrmEehPGwXhOCIUXOGnWBdNyYA = null;
			}
			if (QIHotNQNRkofaZbdLmxjjVBbwURm != null)
			{
				QIHotNQNRkofaZbdLmxjjVBbwURm = null;
			}
		}

		public static void Update()
		{
			if (aDGGrmEehPGwXhOCIUXOGnWBdNyYA != null)
			{
				aDGGrmEehPGwXhOCIUXOGnWBdNyYA.enabled = ReInput.controllers.Keyboard.enabled;
				aDGGrmEehPGwXhOCIUXOGnWBdNyYA.Update();
			}
			if (QIHotNQNRkofaZbdLmxjjVBbwURm != null)
			{
				QIHotNQNRkofaZbdLmxjjVBbwURm.Update();
			}
		}
	}
}
