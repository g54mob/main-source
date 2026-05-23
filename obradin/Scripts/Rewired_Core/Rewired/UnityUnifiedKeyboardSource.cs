using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedKeyboardSource : IDisposable, IUnifiedKeyboardSource
	{
		private const int pIunZPkSJnFMXKFbWbNaMjfyJdX = 132;

		private static HardwareControllerMap_Game cLVUPgpXvNTHDsnZDRDXonKMcJy;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public InputSource inputSource
		{
			get
			{
				return InputSource.UnityKeyboardAndMouse;
			}
		}

		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (cLVUPgpXvNTHDsnZDRDXonKMcJy == null)
				{
					cLVUPgpXvNTHDsnZDRDXonKMcJy = aLwAgqfgniRIvXABCwRQKPbNEES();
				}
				return cLVUPgpXvNTHDsnZDRDXonKMcJy;
			}
		}

		public int buttonCount
		{
			get
			{
				return 132;
			}
		}

		public UnityUnifiedKeyboardSource()
		{
			ThreadSafeUnityInput.keyboard.Monitor(true);
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			ThreadSafeUnityInput.keyboard.GetKeyValues(dataUpdater.buttonValues);
		}

		public void Clear()
		{
		}

		private static HardwareControllerMap_Game aLwAgqfgniRIvXABCwRQKPbNEES()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			int num = 0;
			int num4 = default(int);
			HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
			int[] array2 = default(int[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1417083648;
				while (true)
				{
					switch (num2 ^ 0x5476FB05)
					{
					case 8:
						break;
					case 10:
						if (num4 >= 132)
						{
							array3 = new HardwareButtonInfo[132];
							num2 = 1417083651;
							continue;
						}
						goto case 3;
					case 9:
						num4 = 0;
						num2 = 1417083663;
						continue;
					case 4:
						if (num >= array.Length)
						{
							array2 = new int[132];
							num2 = 1417083660;
							continue;
						}
						goto case 2;
					case 3:
						array2[num4] = array[num4].id;
						num4++;
						num2 = 1417083663;
						continue;
					case 2:
						array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, true);
						num++;
						num2 = 1417083649;
						continue;
					case 0:
						num2 = 1417083652;
						continue;
					case 6:
						num3 = 0;
						num2 = 1417083653;
						continue;
					case 7:
						array3[num3] = new HardwareButtonInfo();
						num3++;
						num2 = 1417083652;
						continue;
					case 5:
						num2 = 1417083649;
						continue;
					default:
						if (num3 >= 132)
						{
							return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
						}
						goto case 7;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~UnityUnifiedKeyboardSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (disposing)
				{
					num = -1304216233;
					num2 = num;
				}
				else
				{
					num = -1304216234;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1304216236)
					{
					case 0:
						num = -1304216235;
						continue;
					case 1:
						break;
					case 3:
						ThreadSafeUnityInput.keyboard.Monitor(false);
						num = -1304216234;
						continue;
					default:
						vsurYtRlepcrpAzAENwjqjJEZPT = true;
						return;
					}
					break;
				}
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (cLVUPgpXvNTHDsnZDRDXonKMcJy == null)
			{
				while (true)
				{
					int num = -387011502;
					while (true)
					{
						switch (num ^ -387011501)
						{
						case 2:
							break;
						case 1:
							cLVUPgpXvNTHDsnZDRDXonKMcJy = aLwAgqfgniRIvXABCwRQKPbNEES();
							num = -387011501;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return cLVUPgpXvNTHDsnZDRDXonKMcJy.GetElementType(elementIdentifierId);
		}
	}
}
