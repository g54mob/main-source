using System;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedMouseSource : IDisposable, IUnifiedMouseSource
	{
		private class ELNUHPVDFzjdVKAQJTgqKUqliOWI
		{
			private float[] lDcuUEeYdvJFXXyZLebbawNxBQj;

			private bool[] LBfpgqAWVyAGHfuvtIBMkEiLzMs;

			public ELNUHPVDFzjdVKAQJTgqKUqliOWI(int buttonCount, int axisCount)
			{
				LBfpgqAWVyAGHfuvtIBMkEiLzMs = new bool[buttonCount];
				lDcuUEeYdvJFXXyZLebbawNxBQj = new float[axisCount];
			}

			public void LBpsVaSXSQkcwnTMybAtexLXfOw(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, LBfpgqAWVyAGHfuvtIBMkEiLzMs, P_0.Length);
				int num = 0;
				while (num < lDcuUEeYdvJFXXyZLebbawNxBQj.Length)
				{
					while (true)
					{
						lDcuUEeYdvJFXXyZLebbawNxBQj[num] += P_1[num];
						num++;
						int num2 = -1549083088;
						while (true)
						{
							switch (num2 ^ -1549083086)
							{
							case 0:
								num2 = -1549083085;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0031;
							}
							break;
						}
						continue;
						end_IL_0031:
						break;
					}
				}
			}

			public void ZZebUlUGtjBzpJmgHcPisXyZtae(ControllerDataUpdater P_0)
			{
				Array.Copy(lDcuUEeYdvJFXXyZLebbawNxBQj, P_0.axisValues, lDcuUEeYdvJFXXyZLebbawNxBQj.Length);
				Array.Copy(LBfpgqAWVyAGHfuvtIBMkEiLzMs, P_0.buttonValues, LBfpgqAWVyAGHfuvtIBMkEiLzMs.Length);
			}

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				Array.Clear(lDcuUEeYdvJFXXyZLebbawNxBQj, 0, lDcuUEeYdvJFXXyZLebbawNxBQj.Length);
				Array.Clear(LBfpgqAWVyAGHfuvtIBMkEiLzMs, 0, LBfpgqAWVyAGHfuvtIBMkEiLzMs.Length);
			}

			public void sEJGlOIjzgifzyhkCWeYUBDjqdxq()
			{
				Array.Clear(lDcuUEeYdvJFXXyZLebbawNxBQj, 0, lDcuUEeYdvJFXXyZLebbawNxBQj.Length);
			}
		}

		private static HardwareControllerMap_Game cLVUPgpXvNTHDsnZDRDXonKMcJy;

		private UpdateLoopDataSet<ELNUHPVDFzjdVKAQJTgqKUqliOWI> mtnCXNhGEJZnJZGQpwPudPTRhtR;

		private float[] lDcuUEeYdvJFXXyZLebbawNxBQj;

		private bool[] LBfpgqAWVyAGHfuvtIBMkEiLzMs;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		[CompilerGenerated]
		private static Func<ELNUHPVDFzjdVKAQJTgqKUqliOWI> PkdHFYJlZLMiTCimwpAnCiFWpZz;

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
				return 7;
			}
		}

		public int axisCount
		{
			get
			{
				return 3;
			}
		}

		public Vector2 mousePosition
		{
			get
			{
				return ThreadSafeUnityInput.mouse.mousePosition;
			}
		}

		public UnityUnifiedMouseSource()
		{
			ThreadSafeUnityInput.mouse.Monitor(true);
			mtnCXNhGEJZnJZGQpwPudPTRhtR = new UpdateLoopDataSet<ELNUHPVDFzjdVKAQJTgqKUqliOWI>(ReInput.configVars.updateLoop, () => new ELNUHPVDFzjdVKAQJTgqKUqliOWI(7, 3));
			lDcuUEeYdvJFXXyZLebbawNxBQj = new float[3];
			LBfpgqAWVyAGHfuvtIBMkEiLzMs = new bool[7];
			ReInput.UpdateEndedEvent += gZimAxINAGanCPPcmrEUhkBFAW;
			ReInput.EarlyUpdateEvent += kLzgfkzvBIVVaIZuWaxWRsCUVMk;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			mtnCXNhGEJZnJZGQpwPudPTRhtR.Get(ReInput.currentUpdateLoop).ZZebUlUGtjBzpJmgHcPisXyZtae(dataUpdater);
		}

		public void Clear()
		{
			int count = mtnCXNhGEJZnJZGQpwPudPTRhtR.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					mtnCXNhGEJZnJZGQpwPudPTRhtR.Get(num).nympziBLtYDUiPlWNRoEGqbSPfa();
					int num2 = -1038367777;
					while (true)
					{
						switch (num2 ^ -1038367777)
						{
						case 2:
							num2 = -1038367778;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = -1038367780;
							continue;
						default:
							goto end_IL_0032;
						}
						break;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
		}

		private void kLzgfkzvBIVVaIZuWaxWRsCUVMk()
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(lDcuUEeYdvJFXXyZLebbawNxBQj);
			ThreadSafeUnityInput.mouse.GetButtonValues(LBfpgqAWVyAGHfuvtIBMkEiLzMs);
			int count = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -1660224556;
				while (true)
				{
					switch (num ^ -1660224560)
					{
					case 2:
						break;
					case 4:
						count = mtnCXNhGEJZnJZGQpwPudPTRhtR.Count;
						num2 = 0;
						num = -1660224557;
						continue;
					case 1:
						num2++;
						num = -1660224557;
						continue;
					case 0:
						mtnCXNhGEJZnJZGQpwPudPTRhtR.Get(num2).LBpsVaSXSQkcwnTMybAtexLXfOw(LBfpgqAWVyAGHfuvtIBMkEiLzMs, lDcuUEeYdvJFXXyZLebbawNxBQj);
						num = -1660224559;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private void gZimAxINAGanCPPcmrEUhkBFAW(UpdateLoopType P_0)
		{
			mtnCXNhGEJZnJZGQpwPudPTRhtR.Get(P_0).sEJGlOIjzgifzyhkCWeYUBDjqdxq();
		}

		private static HardwareControllerMap_Game aLwAgqfgniRIvXABCwRQKPbNEES()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityMouseElementNames.Count];
			int num = 0;
			int[] array2 = default(int[]);
			int[] array3 = default(int[]);
			int num2 = default(int);
			ControllerElementType elementType = default(ControllerElementType);
			HardwareButtonInfo[] array7 = default(HardwareButtonInfo[]);
			int num4 = default(int);
			AxisRange[] array5 = default(AxisRange[]);
			HardwareAxisInfo[] array6 = default(HardwareAxisInfo[]);
			int num6 = default(int);
			AxisCalibrationData[] array4 = default(AxisCalibrationData[]);
			int num5 = default(int);
			while (true)
			{
				int num3;
				if (num >= array.Length)
				{
					array2 = new int[7];
					array3 = new int[3];
					num2 = 0;
					num3 = -1136849660;
					goto IL_001c;
				}
				goto IL_01d6;
				IL_01a1:
				elementType = ControllerElementType.Button;
				num3 = -1136849654;
				goto IL_001c;
				IL_01d6:
				if (num < 3)
				{
					elementType = ControllerElementType.Axis;
					num3 = -1136849654;
					goto IL_001c;
				}
				goto IL_01a1;
				IL_001c:
				while (true)
				{
					switch (num3 ^ -1136849653)
					{
					case 16:
						num3 = -1136849658;
						continue;
					case 20:
						array7[num4] = new HardwareButtonInfo();
						num4++;
						num3 = -1136849659;
						continue;
					case 21:
						break;
					case 0:
						array3[num2] = array[num2].id;
						num2++;
						num3 = -1136849649;
						continue;
					case 8:
						array5 = new AxisRange[3];
						array6 = new HardwareAxisInfo[3];
						num3 = -1136849663;
						continue;
					case 4:
						if (num2 >= 3)
						{
							num6 = 0;
							num3 = -1136849650;
							continue;
						}
						goto case 0;
					case 1:
						array[num] = new ControllerElementIdentifier(Consts.unityMouseElementIdentifierIds[num], Consts.unityMouseElementNames[num], (num < Consts.unityMouseAxisPositiveNames.Count) ? Consts.unityMouseAxisPositiveNames[num] : string.Empty, (num < Consts.unityMouseAxisNegativeNames.Count) ? Consts.unityMouseAxisNegativeNames[num] : string.Empty, elementType, true);
						num++;
						num3 = -1136849634;
						continue;
					case 14:
						goto IL_0176;
					case 12:
						array4 = new AxisCalibrationData[3];
						num3 = -1136849661;
						continue;
					case 7:
						goto IL_01a1;
					case 11:
						num5++;
						num3 = -1136849640;
						continue;
					case 5:
						goto IL_01bd;
					case 13:
						goto IL_01d6;
					case 15:
						num3 = -1136849649;
						continue;
					case 18:
						array2[num6] = array[num6 + 3].id;
						num6++;
						num3 = -1136849650;
						continue;
					case 19:
						goto IL_020f;
					case 3:
						array4[num5] = AxisCalibrationData.Raw;
						array5[num5] = AxisRange.Full;
						num3 = -1136849638;
						continue;
					case 9:
						num3 = -1136849640;
						continue;
					case 17:
						array6[num5] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, SpecialAxisType.None);
						num3 = -1136849664;
						continue;
					case 10:
						array7 = new HardwareButtonInfo[7];
						num5 = 0;
						num3 = -1136849662;
						continue;
					case 2:
						num4 = 0;
						num3 = -1136849659;
						continue;
					default:
						return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
					}
					break;
					IL_020f:
					int num7;
					if (num5 >= 3)
					{
						num3 = -1136849655;
						num7 = num3;
					}
					else
					{
						num3 = -1136849656;
						num7 = num3;
					}
					continue;
					IL_01bd:
					int num8;
					if (num6 >= 7)
					{
						num3 = -1136849657;
						num8 = num3;
					}
					else
					{
						num3 = -1136849639;
						num8 = num3;
					}
					continue;
					IL_0176:
					int num9;
					if (num4 < 7)
					{
						num3 = -1136849633;
						num9 = num3;
					}
					else
					{
						num3 = -1136849651;
						num9 = num3;
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~UnityUnifiedMouseSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (disposing)
			{
				ThreadSafeUnityInput.mouse.Monitor(false);
				int num = -217195729;
				while (true)
				{
					switch (num ^ -217195732)
					{
					case 2:
						num = -217195731;
						continue;
					case 1:
						break;
					case 3:
						ReInput.UpdateEndedEvent -= gZimAxINAGanCPPcmrEUhkBFAW;
						ReInput.EarlyUpdateEvent -= kLzgfkzvBIVVaIZuWaxWRsCUVMk;
						num = -217195732;
						continue;
					default:
						goto end_IL_002b;
					}
					break;
				}
				continue;
				end_IL_002b:
				break;
			}
			vsurYtRlepcrpAzAENwjqjJEZPT = true;
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (cLVUPgpXvNTHDsnZDRDXonKMcJy == null)
			{
				while (true)
				{
					int num = 425483134;
					while (true)
					{
						switch (num ^ 0x195C5B7F)
						{
						case 0:
							break;
						case 1:
							cLVUPgpXvNTHDsnZDRDXonKMcJy = aLwAgqfgniRIvXABCwRQKPbNEES();
							num = 425483133;
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

		[CompilerGenerated]
		private static ELNUHPVDFzjdVKAQJTgqKUqliOWI fFhZiHxhrdJIizmpUjsGDMQIWtFs()
		{
			return new ELNUHPVDFzjdVKAQJTgqKUqliOWI(7, 3);
		}
	}
}
