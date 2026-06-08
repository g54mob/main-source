using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedKeyboardSource : IDisposable, IUnifiedKeyboardSource
	{
		private const int zwoPVZwQslafzXhBjWAdnlZzAjvA = 132;

		private static HardwareControllerMap_Game oSDhpgtCAJtNfbjNuwGUXobPDBO;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public InputSource inputSource => InputSource.UnityKeyboardAndMouse;

		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (oSDhpgtCAJtNfbjNuwGUXobPDBO == null)
				{
					oSDhpgtCAJtNfbjNuwGUXobPDBO = goqfCijiGytyPUXbdgsNfbZQGrw();
				}
				return oSDhpgtCAJtNfbjNuwGUXobPDBO;
			}
		}

		public int buttonCount => 132;

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedKeyboardSource()
		{
			ThreadSafeUnityInput.keyboard.Monitor(state: true);
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			ThreadSafeUnityInput.keyboard.GetKeyValues(dataUpdater.buttonValues);
		}

		public void Clear()
		{
		}

		private static HardwareControllerMap_Game goqfCijiGytyPUXbdgsNfbZQGrw()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			int num = 0;
			int[] array2 = default(int[]);
			int num4 = default(int);
			HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1127639220;
				while (true)
				{
					switch (num2 ^ 0x433668BD)
					{
					case 2:
						break;
					case 4:
						if (num >= array.Length)
						{
							array2 = new int[132];
							num2 = 1127639221;
							continue;
						}
						goto case 3;
					case 7:
						if (num4 >= 132)
						{
							array3 = new HardwareButtonInfo[132];
							num3 = 0;
							num2 = 1127639227;
							continue;
						}
						goto case 1;
					case 0:
						num2 = 1127639226;
						continue;
					case 5:
						array3[num3] = new HardwareButtonInfo();
						num3++;
						num2 = 1127639227;
						continue;
					case 9:
						num2 = 1127639225;
						continue;
					case 1:
						array2[num4] = array[num4].id;
						num4++;
						num2 = 1127639226;
						continue;
					case 8:
						num4 = 0;
						num2 = 1127639229;
						continue;
					case 3:
						array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, isMappableOnPlatform: true);
						num++;
						num2 = 1127639225;
						continue;
					default:
						if (num3 >= 132)
						{
							return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~UnityUnifiedKeyboardSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (disposing)
			{
				ThreadSafeUnityInput.keyboard.Monitor(state: false);
				int num = -465553203;
				while (true)
				{
					switch (num ^ -465553204)
					{
					case 0:
						num = -465553202;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (oSDhpgtCAJtNfbjNuwGUXobPDBO == null)
			{
				while (true)
				{
					int num = -1190917089;
					while (true)
					{
						switch (num ^ -1190917090)
						{
						case 0:
							break;
						case 1:
							oSDhpgtCAJtNfbjNuwGUXobPDBO = goqfCijiGytyPUXbdgsNfbZQGrw();
							num = -1190917092;
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
			return oSDhpgtCAJtNfbjNuwGUXobPDBO.GetElementType(elementIdentifierId);
		}
	}
}
