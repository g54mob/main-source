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
		private class IWHvTVFgSxJYhPmKqNOjdOxyEdc
		{
			private float[] lFaEKOcwCvWtzOZrgPJkBadksZZ;

			private bool[] JkjWgiYLcoakhuEDGqNJNgKMODK;

			public IWHvTVFgSxJYhPmKqNOjdOxyEdc(int buttonCount, int axisCount)
			{
				while (true)
				{
					int num = -68192246;
					while (true)
					{
						switch (num ^ -68192247)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							JkjWgiYLcoakhuEDGqNJNgKMODK = new bool[buttonCount];
							num = -68192245;
							continue;
						case 2:
							lFaEKOcwCvWtzOZrgPJkBadksZZ = new float[axisCount];
							num = -68192248;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}

			public void BebeSqCKvCcEWgIcBGKwaRvOzzYJ(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, JkjWgiYLcoakhuEDGqNJNgKMODK, P_0.Length);
				int num = 0;
				while (num < lFaEKOcwCvWtzOZrgPJkBadksZZ.Length)
				{
					while (true)
					{
						lFaEKOcwCvWtzOZrgPJkBadksZZ[num] += P_1[num];
						int num2 = -834488398;
						while (true)
						{
							switch (num2 ^ -834488397)
							{
							case 0:
								num2 = -834488399;
								continue;
							case 2:
								break;
							case 1:
								num++;
								num2 = -834488400;
								continue;
							default:
								goto end_IL_0035;
							}
							break;
						}
						continue;
						end_IL_0035:
						break;
					}
				}
			}

			public void TfqYJpQjzhnpJQPQkXPfHStIqtU(ControllerDataUpdater P_0)
			{
				Array.Copy(lFaEKOcwCvWtzOZrgPJkBadksZZ, P_0.axisValues, lFaEKOcwCvWtzOZrgPJkBadksZZ.Length);
				Array.Copy(JkjWgiYLcoakhuEDGqNJNgKMODK, P_0.buttonValues, JkjWgiYLcoakhuEDGqNJNgKMODK.Length);
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				Array.Clear(lFaEKOcwCvWtzOZrgPJkBadksZZ, 0, lFaEKOcwCvWtzOZrgPJkBadksZZ.Length);
				Array.Clear(JkjWgiYLcoakhuEDGqNJNgKMODK, 0, JkjWgiYLcoakhuEDGqNJNgKMODK.Length);
			}

			public void wXXNFApYRgTBBkYTbThFerxmpoF()
			{
				Array.Clear(lFaEKOcwCvWtzOZrgPJkBadksZZ, 0, lFaEKOcwCvWtzOZrgPJkBadksZZ.Length);
			}
		}

		private static HardwareControllerMap_Game oSDhpgtCAJtNfbjNuwGUXobPDBO;

		private UpdateLoopDataSet<IWHvTVFgSxJYhPmKqNOjdOxyEdc> sJdOmJvatNYzjWUiYrFrMflMurn;

		private float[] lFaEKOcwCvWtzOZrgPJkBadksZZ;

		private bool[] JkjWgiYLcoakhuEDGqNJNgKMODK;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		[CompilerGenerated]
		private static Func<IWHvTVFgSxJYhPmKqNOjdOxyEdc> TblfxMGFSPowbRLCNkMeDtWBtrTm;

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

		public int buttonCount => 7;

		public int axisCount => 4;

		public Vector2 mousePosition => ThreadSafeUnityInput.mouse.mousePosition;

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			ThreadSafeUnityInput.mouse.Monitor(state: true);
			sJdOmJvatNYzjWUiYrFrMflMurn = new UpdateLoopDataSet<IWHvTVFgSxJYhPmKqNOjdOxyEdc>(ReInput.configVars.updateLoop, () => new IWHvTVFgSxJYhPmKqNOjdOxyEdc(7, 4));
			lFaEKOcwCvWtzOZrgPJkBadksZZ = new float[4];
			JkjWgiYLcoakhuEDGqNJNgKMODK = new bool[7];
			ReInput.UpdateEndedEvent += oGHCICblqQnoFKLfFFNDyhYGjKgA;
			ReInput.EarlyUpdateEvent += ymrPjyxGuMabILOMnUVPoYgVjVY;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			sJdOmJvatNYzjWUiYrFrMflMurn.Get(ReInput.currentUpdateLoop).TfqYJpQjzhnpJQPQkXPfHStIqtU(dataUpdater);
		}

		public void Clear()
		{
			int count = sJdOmJvatNYzjWUiYrFrMflMurn.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1438994610;
				while (true)
				{
					switch (num ^ 0x55C550B3)
					{
					case 2:
						break;
					default:
						return;
					case 5:
					{
						int num3;
						if (num2 < count)
						{
							num = 1438994608;
							num3 = num;
						}
						else
						{
							num = 1438994615;
							num3 = num;
						}
						continue;
					}
					case 3:
						sJdOmJvatNYzjWUiYrFrMflMurn.Get(num2).tAgADqjTsMUxSqYXeDyJIdETYRAp();
						num2++;
						num = 1438994614;
						continue;
					case 0:
						num = 1438994614;
						continue;
					case 1:
						num2 = 0;
						num = 1438994611;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void ymrPjyxGuMabILOMnUVPoYgVjVY()
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(lFaEKOcwCvWtzOZrgPJkBadksZZ);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = -375685777;
				while (true)
				{
					switch (num ^ -375685781)
					{
					case 0:
						break;
					case 2:
						num2++;
						num = -375685784;
						continue;
					case 1:
						sJdOmJvatNYzjWUiYrFrMflMurn.Get(num2).BebeSqCKvCcEWgIcBGKwaRvOzzYJ(JkjWgiYLcoakhuEDGqNJNgKMODK, lFaEKOcwCvWtzOZrgPJkBadksZZ);
						num = -375685783;
						continue;
					case 5:
						count = sJdOmJvatNYzjWUiYrFrMflMurn.Count;
						num2 = 0;
						num = -375685784;
						continue;
					case 4:
						ThreadSafeUnityInput.mouse.GetButtonValues(JkjWgiYLcoakhuEDGqNJNgKMODK);
						num = -375685778;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private void oGHCICblqQnoFKLfFFNDyhYGjKgA(UpdateLoopType P_0)
		{
			sJdOmJvatNYzjWUiYrFrMflMurn.Get(P_0).wXXNFApYRgTBBkYTbThFerxmpoF();
		}

		private static HardwareControllerMap_Game goqfCijiGytyPUXbdgsNfbZQGrw()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
			int num = 0;
			int[] array2 = default(int[]);
			int[] array3 = default(int[]);
			int num6 = default(int);
			int num7 = default(int);
			HardwareAxisInfo[] array6 = default(HardwareAxisInfo[]);
			int num4 = default(int);
			float pollingDeadZone = default(float);
			AxisCalibrationData[] array4 = default(AxisCalibrationData[]);
			AxisRange[] array5 = default(AxisRange[]);
			int num3 = default(int);
			HardwareButtonInfo[] array7 = default(HardwareButtonInfo[]);
			int num5 = default(int);
			while (true)
			{
				int num2;
				if (num >= array.Length)
				{
					array2 = new int[7];
					array3 = new int[4];
					num2 = 650838311;
					goto IL_001c;
				}
				goto IL_0222;
				IL_001c:
				while (true)
				{
					switch (num2 ^ 0x26CB0121)
					{
					case 11:
						num2 = 650838317;
						continue;
					case 1:
						array3[num6++] = array[num7].id;
						num2 = 650838315;
						continue;
					case 7:
						array6[num4] = new HardwareAxisInfo(AxisCoordinateMode.Relative, excludeFromPolling: false, pollingDeadZone, SpecialAxisType.None);
						num4++;
						num2 = 650838322;
						continue;
					case 15:
					{
						ref AxisCalibrationData reference = ref array4[num4];
						reference = AxisCalibrationData.Raw;
						array5[num4] = AxisRange.Full;
						num2 = 650838312;
						continue;
					}
					case 19:
						if (num4 >= 4)
						{
							num3 = 0;
							num2 = 650838321;
							continue;
						}
						goto case 15;
					case 3:
						if (num7 >= array.Length)
						{
							array4 = new AxisCalibrationData[4];
							array5 = new AxisRange[4];
							array6 = new HardwareAxisInfo[4];
							array7 = new HardwareButtonInfo[7];
							num4 = 0;
							num2 = 650838322;
							continue;
						}
						goto IL_0203;
					case 0:
						pollingDeadZone = 2f;
						num2 = 650838310;
						continue;
					case 8:
						break;
					case 5:
						pollingDeadZone = 100f;
						num2 = 650838310;
						continue;
					case 10:
						num2 = 650838316;
						continue;
					case 4:
						if (array[num7].elementType == ControllerElementType.Button)
						{
							array2[num5++] = array[num7].id;
							num2 = 650838316;
							continue;
						}
						goto case 13;
					case 6:
						num5 = 0;
						num6 = 0;
						num7 = 0;
						num2 = 650838323;
						continue;
					case 2:
						num2 = 650838305;
						continue;
					case 14:
						array7[num3] = new HardwareButtonInfo();
						num3++;
						num2 = 650838321;
						continue;
					case 13:
						num7++;
						num2 = 650838306;
						continue;
					case 9:
						switch (num4)
						{
						case 0:
						case 1:
							break;
						default:
							num2 = 650838307;
							continue;
						}
						goto case 5;
					case 18:
						num2 = 650838306;
						continue;
					case 17:
						goto IL_0203;
					case 12:
						goto IL_0222;
					default:
						if (num3 >= 7)
						{
							return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
						}
						goto case 14;
					}
					break;
					IL_0203:
					int num8;
					if (array[num7].elementType != ControllerElementType.Axis)
					{
						num2 = 650838309;
						num8 = num2;
					}
					else
					{
						num2 = 650838304;
						num8 = num2;
					}
				}
				continue;
				IL_0222:
				array[num] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[num]);
				num++;
				num2 = 650838313;
				goto IL_001c;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~UnityUnifiedMouseSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (disposing)
				{
					num = -1913515783;
					num2 = num;
				}
				else
				{
					num = -1913515782;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1913515781)
					{
					case 0:
						num = -1913515784;
						continue;
					case 3:
						break;
					case 4:
						ReInput.EarlyUpdateEvent -= ymrPjyxGuMabILOMnUVPoYgVjVY;
						num = -1913515782;
						continue;
					case 2:
						ThreadSafeUnityInput.mouse.Monitor(state: false);
						num = -1913515778;
						continue;
					case 5:
						ReInput.UpdateEndedEvent -= oGHCICblqQnoFKLfFFNDyhYGjKgA;
						num = -1913515777;
						continue;
					default:
						xRygqjRmTtURDPiwlgMmFcdNBrr = true;
						return;
					}
					break;
				}
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (oSDhpgtCAJtNfbjNuwGUXobPDBO == null)
			{
				oSDhpgtCAJtNfbjNuwGUXobPDBO = goqfCijiGytyPUXbdgsNfbZQGrw();
			}
			return oSDhpgtCAJtNfbjNuwGUXobPDBO.GetElementType(elementIdentifierId);
		}

		[CompilerGenerated]
		private static IWHvTVFgSxJYhPmKqNOjdOxyEdc hfjhnHzBKtgeMgaJnUTLkpoZRlbT()
		{
			return new IWHvTVFgSxJYhPmKqNOjdOxyEdc(7, 4);
		}
	}
}
