using System;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IDisposable, IUnifiedMouseSource
	{
		private class xDReYIffFdPEeWeXniggHdwIdPFH
		{
			private float[] IBmdXXABpruPchDAnbszJiDlKAa;

			private bool[] aJlfjzcyJmnrgLfmNCFCNqaJzNz;

			public xDReYIffFdPEeWeXniggHdwIdPFH(int buttonCount, int axisCount)
			{
				aJlfjzcyJmnrgLfmNCFCNqaJzNz = new bool[buttonCount];
				IBmdXXABpruPchDAnbszJiDlKAa = new float[axisCount];
			}

			public void kfnnYtmdEEPmRXQNMzHrHEBLKef(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, aJlfjzcyJmnrgLfmNCFCNqaJzNz, P_0.Length);
				int num = 0;
				while (num < IBmdXXABpruPchDAnbszJiDlKAa.Length)
				{
					while (true)
					{
						IBmdXXABpruPchDAnbszJiDlKAa[num] += P_1[num];
						num++;
						int num2 = 97903265;
						while (true)
						{
							switch (num2 ^ 0x5D5E2A3)
							{
							case 0:
								num2 = 97903266;
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

			public void qyoqokiAHbkJIffKtmimZLlZeLl(ControllerDataUpdater P_0)
			{
				Array.Copy(IBmdXXABpruPchDAnbszJiDlKAa, P_0.axisValues, IBmdXXABpruPchDAnbszJiDlKAa.Length);
				Array.Copy(aJlfjzcyJmnrgLfmNCFCNqaJzNz, P_0.buttonValues, aJlfjzcyJmnrgLfmNCFCNqaJzNz.Length);
			}

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				Array.Clear(IBmdXXABpruPchDAnbszJiDlKAa, 0, IBmdXXABpruPchDAnbszJiDlKAa.Length);
				Array.Clear(aJlfjzcyJmnrgLfmNCFCNqaJzNz, 0, aJlfjzcyJmnrgLfmNCFCNqaJzNz.Length);
			}

			public void REHBeNjHzwzMYaJlkzkCKyFnNkoR()
			{
				Array.Clear(IBmdXXABpruPchDAnbszJiDlKAa, 0, IBmdXXABpruPchDAnbszJiDlKAa.Length);
			}
		}

		private static HardwareControllerMap_Game VUTZItVupRVekGFKpvZHNFSOcIt;

		private UpdateLoopDataSet<xDReYIffFdPEeWeXniggHdwIdPFH> HgdVUQPGOJaacdFXVfmkaGDFLgE;

		private float[] IBmdXXABpruPchDAnbszJiDlKAa;

		private bool[] aJlfjzcyJmnrgLfmNCFCNqaJzNz;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		[CompilerGenerated]
		private static Func<xDReYIffFdPEeWeXniggHdwIdPFH> autMBJdbnRzwuaphYbdbvPoQqzm;

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
					VUTZItVupRVekGFKpvZHNFSOcIt = POcrGdJrdsdVGhxOmHiQlLzRTHJ();
				}
				return VUTZItVupRVekGFKpvZHNFSOcIt;
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
			while (true)
			{
				int num = 765239077;
				while (true)
				{
					switch (num ^ 0x2D9C9F27)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						ThreadSafeUnityInput.mouse.Monitor(true);
						HgdVUQPGOJaacdFXVfmkaGDFLgE = new UpdateLoopDataSet<xDReYIffFdPEeWeXniggHdwIdPFH>(ReInput.configVars.updateLoop, () => new xDReYIffFdPEeWeXniggHdwIdPFH(7, 3));
						num = 765239078;
						continue;
					case 1:
						IBmdXXABpruPchDAnbszJiDlKAa = new float[3];
						aJlfjzcyJmnrgLfmNCFCNqaJzNz = new bool[7];
						ReInput.UpdateEndedEvent += ZZTjNFFDAEvFIiKsCsCOhAkHPDD;
						ReInput.EarlyUpdateEvent += NQtlyjRdNCamFmmxeDyEcZEYEYh;
						num = 765239076;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			HgdVUQPGOJaacdFXVfmkaGDFLgE.Get(ReInput.currentUpdateLoop).qyoqokiAHbkJIffKtmimZLlZeLl(dataUpdater);
		}

		public void Clear()
		{
			int count = HgdVUQPGOJaacdFXVfmkaGDFLgE.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -126084094;
				while (true)
				{
					switch (num ^ -126084095)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = -126084093;
						continue;
					case 4:
						HgdVUQPGOJaacdFXVfmkaGDFLgE.Get(num2).QYwkAfdRMMgAPnyPzHFUdcsKUPp();
						num2++;
						num = -126084096;
						continue;
					case 2:
						num = -126084096;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		private void NQtlyjRdNCamFmmxeDyEcZEYEYh()
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(IBmdXXABpruPchDAnbszJiDlKAa);
			ThreadSafeUnityInput.mouse.GetButtonValues(aJlfjzcyJmnrgLfmNCFCNqaJzNz);
			int count = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -1040153925;
				while (true)
				{
					switch (num ^ -1040153921)
					{
					case 3:
						break;
					default:
						return;
					case 4:
						count = HgdVUQPGOJaacdFXVfmkaGDFLgE.Count;
						num2 = 0;
						num = -1040153921;
						continue;
					case 0:
					{
						int num3;
						if (num2 < count)
						{
							num = -1040153923;
							num3 = num;
						}
						else
						{
							num = -1040153922;
							num3 = num;
						}
						continue;
					}
					case 2:
						HgdVUQPGOJaacdFXVfmkaGDFLgE.Get(num2).kfnnYtmdEEPmRXQNMzHrHEBLKef(aJlfjzcyJmnrgLfmNCFCNqaJzNz, IBmdXXABpruPchDAnbszJiDlKAa);
						num2++;
						num = -1040153921;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void ZZTjNFFDAEvFIiKsCsCOhAkHPDD(UpdateLoopType P_0)
		{
			HgdVUQPGOJaacdFXVfmkaGDFLgE.Get(P_0).REHBeNjHzwzMYaJlkzkCKyFnNkoR();
		}

		private static HardwareControllerMap_Game POcrGdJrdsdVGhxOmHiQlLzRTHJ()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityMouseElementNames.Count];
			int num6 = default(int);
			AxisCalibrationData[] array4 = default(AxisCalibrationData[]);
			AxisRange[] array5 = default(AxisRange[]);
			HardwareAxisInfo[] array6 = default(HardwareAxisInfo[]);
			int[] array2 = default(int[]);
			int num3 = default(int);
			HardwareButtonInfo[] array7 = default(HardwareButtonInfo[]);
			int num2 = default(int);
			int num7 = default(int);
			ControllerElementType elementType = default(ControllerElementType);
			int[] array3 = default(int[]);
			int num4 = default(int);
			while (true)
			{
				int num = -1394794280;
				while (true)
				{
					switch (num ^ -1394794279)
					{
					case 5:
						break;
					case 2:
						num6++;
						num = -1394794273;
						continue;
					case 6:
						if (num6 >= 7)
						{
							array4 = new AxisCalibrationData[3];
							array5 = new AxisRange[3];
							array6 = new HardwareAxisInfo[3];
							num = -1394794281;
							continue;
						}
						goto case 17;
					case 17:
						array2[num6] = array[num6 + 3].id;
						num = -1394794277;
						continue;
					case 15:
						num6 = 0;
						num = -1394794273;
						continue;
					case 3:
						array6[num3] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, SpecialAxisType.None);
						num3++;
						num = -1394794274;
						continue;
					case 8:
						array4[num3] = AxisCalibrationData.Raw;
						array5[num3] = AxisRange.Full;
						num = -1394794278;
						continue;
					case 13:
						array7[num2] = new HardwareButtonInfo();
						num2++;
						num = -1394794286;
						continue;
					case 1:
						num7 = 0;
						num = -1394794285;
						continue;
					case 9:
						array[num7] = new ControllerElementIdentifier(Consts.unityMouseElementIdentifierIds[num7], Consts.unityMouseElementNames[num7], (num7 < Consts.unityMouseAxisPositiveNames.Count) ? Consts.unityMouseAxisPositiveNames[num7] : string.Empty, (num7 < Consts.unityMouseAxisNegativeNames.Count) ? Consts.unityMouseAxisNegativeNames[num7] : string.Empty, elementType, true);
						num7++;
						num = -1394794285;
						continue;
					case 20:
						if (num7 < 3)
						{
							elementType = ControllerElementType.Axis;
							num = -1394794275;
							continue;
						}
						goto case 18;
					case 10:
						if (num7 >= array.Length)
						{
							array2 = new int[7];
							array3 = new int[3];
							num4 = 0;
							num = -1394794295;
							continue;
						}
						goto case 20;
					case 14:
						array7 = new HardwareButtonInfo[7];
						num = -1394794279;
						continue;
					case 7:
						if (num3 >= 3)
						{
							num2 = 0;
							num = -1394794286;
							continue;
						}
						goto case 8;
					case 12:
					{
						int num5;
						if (num4 < 3)
						{
							num = -1394794294;
							num5 = num;
						}
						else
						{
							num = -1394794282;
							num5 = num;
						}
						continue;
					}
					case 4:
						num = -1394794288;
						continue;
					case 0:
						num3 = 0;
						num = -1394794274;
						continue;
					case 19:
						array3[num4] = array[num4].id;
						num4++;
						num = -1394794283;
						continue;
					case 18:
						elementType = ControllerElementType.Button;
						num = -1394794288;
						continue;
					case 16:
						num = -1394794283;
						continue;
					default:
						if (num2 >= 7)
						{
							return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
						}
						goto case 13;
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

		~UnityUnifiedMouseSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (disposing)
				{
					num = -945157734;
					num2 = num;
				}
				else
				{
					num = -945157731;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -945157730)
					{
					case 0:
						num = -945157729;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						QQqHByfwytAJSuMZiCPjJlZYHKG = true;
						num = -945157732;
						continue;
					case 4:
						ThreadSafeUnityInput.mouse.Monitor(false);
						ReInput.UpdateEndedEvent -= ZZTjNFFDAEvFIiKsCsCOhAkHPDD;
						ReInput.EarlyUpdateEvent -= NQtlyjRdNCamFmmxeDyEcZEYEYh;
						num = -945157731;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (VUTZItVupRVekGFKpvZHNFSOcIt == null)
			{
				VUTZItVupRVekGFKpvZHNFSOcIt = POcrGdJrdsdVGhxOmHiQlLzRTHJ();
			}
			return VUTZItVupRVekGFKpvZHNFSOcIt.GetElementType(elementIdentifierId);
		}

		[CompilerGenerated]
		private static xDReYIffFdPEeWeXniggHdwIdPFH QbjYJUHrzbbBZTgcghyGnqYCPyC()
		{
			return new xDReYIffFdPEeWeXniggHdwIdPFH(7, 3);
		}
	}
}
