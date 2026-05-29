using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedKeyboardSource : IDisposable, IUnifiedKeyboardSource
	{
		private const int IXoasCMsBdCawyQigelghUvoTwC = 132;

		private static HardwareControllerMap_Game VUTZItVupRVekGFKpvZHNFSOcIt;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

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
				if (VUTZItVupRVekGFKpvZHNFSOcIt == null)
				{
					while (true)
					{
						int num = 1188242759;
						while (true)
						{
							switch (num ^ 0x46D32546)
							{
							case 2:
								break;
							case 1:
								VUTZItVupRVekGFKpvZHNFSOcIt = POcrGdJrdsdVGhxOmHiQlLzRTHJ();
								num = 1188242758;
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
				return VUTZItVupRVekGFKpvZHNFSOcIt;
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

		private static HardwareControllerMap_Game POcrGdJrdsdVGhxOmHiQlLzRTHJ()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
			int num = 0;
			int[] array2 = default(int[]);
			int num2 = default(int);
			HardwareButtonInfo[] array3 = default(HardwareButtonInfo[]);
			int num4 = default(int);
			while (true)
			{
				int num3;
				if (num >= array.Length)
				{
					array2 = new int[132];
					num2 = 0;
					num3 = -1619706414;
					goto IL_0017;
				}
				goto IL_0113;
				IL_0017:
				while (true)
				{
					switch (num3 ^ -1619706414)
					{
					case 10:
						num3 = -1619706407;
						continue;
					case 0:
						num3 = -1619706411;
						continue;
					case 7:
						if (num2 >= 132)
						{
							array3 = new HardwareButtonInfo[132];
							num3 = -1619706413;
							continue;
						}
						goto case 12;
					case 5:
						num++;
						num3 = -1619706410;
						continue;
					case 2:
						num4++;
						num3 = -1619706412;
						continue;
					case 9:
						array3[num4] = new HardwareButtonInfo();
						num3 = -1619706416;
						continue;
					case 12:
						array2[num2] = array[num2].id;
						num2++;
						num3 = -1619706411;
						continue;
					case 8:
						num3 = -1619706412;
						continue;
					case 6:
						break;
					case 4:
						goto end_IL_0017;
					case 1:
						num4 = 0;
						num3 = -1619706406;
						continue;
					case 11:
						goto IL_0113;
					default:
						return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
					}
					int num5;
					if (num4 >= 132)
					{
						num3 = -1619706415;
						num5 = num3;
					}
					else
					{
						num3 = -1619706405;
						num5 = num3;
					}
					continue;
					end_IL_0017:
					break;
				}
				continue;
				IL_0113:
				array[num] = new ControllerElementIdentifier(num, Consts.keyboardKeyNames[num], Consts.keyboardKeyNames[num], string.Empty, ControllerElementType.Button, true);
				num3 = -1619706409;
				goto IL_0017;
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
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1554909405;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1554909407)
			{
			case 0:
				break;
			case 2:
				return;
			case 3:
				goto IL_0032;
			default:
				goto IL_0047;
			}
			goto IL_0008;
			IL_0032:
			if (disposing)
			{
				ThreadSafeUnityInput.keyboard.Monitor(false);
				num = -1554909408;
				goto IL_000d;
			}
			goto IL_0047;
			IL_0047:
			QQqHByfwytAJSuMZiCPjJlZYHKG = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (VUTZItVupRVekGFKpvZHNFSOcIt == null)
			{
				while (true)
				{
					int num = -2099852608;
					while (true)
					{
						switch (num ^ -2099852606)
						{
						case 0:
							break;
						case 2:
							VUTZItVupRVekGFKpvZHNFSOcIt = POcrGdJrdsdVGhxOmHiQlLzRTHJ();
							num = -2099852605;
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
			return VUTZItVupRVekGFKpvZHNFSOcIt.GetElementType(elementIdentifierId);
		}
	}
}
