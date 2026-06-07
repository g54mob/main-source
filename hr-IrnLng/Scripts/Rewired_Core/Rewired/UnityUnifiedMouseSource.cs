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
		private class wubTOVsyCFQXfzehSenVBruEhLo
		{
			private float[] XGXKgXBqECcxPcDlSsvajEAACoi;

			private bool[] lLIwNjjdqRJzDQYDsFLZjNnkkln;

			public wubTOVsyCFQXfzehSenVBruEhLo(int buttonCount, int axisCount)
			{
				lLIwNjjdqRJzDQYDsFLZjNnkkln = new bool[buttonCount];
				XGXKgXBqECcxPcDlSsvajEAACoi = new float[axisCount];
			}

			public void reMLqphorxRNwOLsntnodyWsmQt(bool[] P_0, float[] P_1)
			{
				Array.Copy(P_0, lLIwNjjdqRJzDQYDsFLZjNnkkln, P_0.Length);
				for (int i = 0; i < XGXKgXBqECcxPcDlSsvajEAACoi.Length; i++)
				{
					XGXKgXBqECcxPcDlSsvajEAACoi[i] += P_1[i];
				}
			}

			public void jFZgbgkjlUqanUiCWnsjxvYmfGja(ControllerDataUpdater P_0)
			{
				Array.Copy(XGXKgXBqECcxPcDlSsvajEAACoi, P_0.axisValues, XGXKgXBqECcxPcDlSsvajEAACoi.Length);
				Array.Copy(lLIwNjjdqRJzDQYDsFLZjNnkkln, P_0.buttonValues, lLIwNjjdqRJzDQYDsFLZjNnkkln.Length);
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				Array.Clear(XGXKgXBqECcxPcDlSsvajEAACoi, 0, XGXKgXBqECcxPcDlSsvajEAACoi.Length);
				Array.Clear(lLIwNjjdqRJzDQYDsFLZjNnkkln, 0, lLIwNjjdqRJzDQYDsFLZjNnkkln.Length);
			}

			public void WXkbuRYfYFEspCLEPoTVQdAOMkg()
			{
				Array.Clear(XGXKgXBqECcxPcDlSsvajEAACoi, 0, XGXKgXBqECcxPcDlSsvajEAACoi.Length);
			}
		}

		private static HardwareControllerMap_Game MagDxMEYyHuLNPjIpNIExVnjaxA;

		private UpdateLoopDataSet<wubTOVsyCFQXfzehSenVBruEhLo> SJOgMWGirqgoByjouUivofMkIEMB;

		private float[] XGXKgXBqECcxPcDlSsvajEAACoi;

		private bool[] lLIwNjjdqRJzDQYDsFLZjNnkkln;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		[CompilerGenerated]
		private static Func<wubTOVsyCFQXfzehSenVBruEhLo> rZGVFRgQMmptVpKQzBtcADhlKAsu;

		public InputSource inputSource => InputSource.UnityKeyboardAndMouse;

		public HardwareControllerMap_Game hardwareMap
		{
			get
			{
				if (MagDxMEYyHuLNPjIpNIExVnjaxA == null)
				{
					MagDxMEYyHuLNPjIpNIExVnjaxA = GoDnaxMLAFBpfbupFMVHYRaePhZh();
				}
				return MagDxMEYyHuLNPjIpNIExVnjaxA;
			}
		}

		public int buttonCount => 7;

		public int axisCount => 4;

		public Vector2 mousePosition => ThreadSafeUnityInput.mouse.mousePosition;

		public Controller.Extension controllerExtension => null;

		public UnityUnifiedMouseSource()
		{
			ThreadSafeUnityInput.mouse.Monitor(state: true);
			SJOgMWGirqgoByjouUivofMkIEMB = new UpdateLoopDataSet<wubTOVsyCFQXfzehSenVBruEhLo>(ReInput.configVars.updateLoop, () => new wubTOVsyCFQXfzehSenVBruEhLo(7, 4));
			XGXKgXBqECcxPcDlSsvajEAACoi = new float[4];
			lLIwNjjdqRJzDQYDsFLZjNnkkln = new bool[7];
			ReInput.UpdateEndedEvent += OGeVoLKxstqhbxehzcoBfDbiYtNr;
			ReInput.EarlyUpdateEvent += YmCvxhWdqvaSizsODqYZGrBlmSp;
		}

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
			SJOgMWGirqgoByjouUivofMkIEMB.Get(ReInput.currentUpdateLoop).jFZgbgkjlUqanUiCWnsjxvYmfGja(dataUpdater);
		}

		public void Clear()
		{
			int count = SJOgMWGirqgoByjouUivofMkIEMB.Count;
			for (int i = 0; i < count; i++)
			{
				SJOgMWGirqgoByjouUivofMkIEMB.Get(i).VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			}
		}

		private void YmCvxhWdqvaSizsODqYZGrBlmSp()
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(XGXKgXBqECcxPcDlSsvajEAACoi);
			ThreadSafeUnityInput.mouse.GetButtonValues(lLIwNjjdqRJzDQYDsFLZjNnkkln);
			int count = SJOgMWGirqgoByjouUivofMkIEMB.Count;
			for (int i = 0; i < count; i++)
			{
				SJOgMWGirqgoByjouUivofMkIEMB.Get(i).reMLqphorxRNwOLsntnodyWsmQt(lLIwNjjdqRJzDQYDsFLZjNnkkln, XGXKgXBqECcxPcDlSsvajEAACoi);
			}
		}

		private void OGeVoLKxstqhbxehzcoBfDbiYtNr(UpdateLoopType P_0)
		{
			SJOgMWGirqgoByjouUivofMkIEMB.Get(P_0).WXkbuRYfYFEspCLEPoTVQdAOMkg();
		}

		private static HardwareControllerMap_Game GoDnaxMLAFBpfbupFMVHYRaePhZh()
		{
			ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[i]);
			}
			int[] array2 = new int[7];
			int[] array3 = new int[4];
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].elementType == ControllerElementType.Axis)
				{
					array3[num2++] = array[j].id;
				}
				else if (array[j].elementType == ControllerElementType.Button)
				{
					array2[num++] = array[j].id;
				}
			}
			AxisCalibrationData[] array4 = new AxisCalibrationData[4];
			AxisRange[] array5 = new AxisRange[4];
			HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
			HardwareButtonInfo[] array7 = new HardwareButtonInfo[7];
			for (int k = 0; k < 4; k++)
			{
				ref AxisCalibrationData reference = ref array4[k];
				reference = AxisCalibrationData.Raw;
				array5[k] = AxisRange.Full;
				float pollingDeadZone;
				switch (k)
				{
				case 0:
				case 1:
					pollingDeadZone = 100f;
					break;
				default:
					pollingDeadZone = 2f;
					break;
				}
				array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, excludeFromPolling: false, pollingDeadZone, SpecialAxisType.None);
			}
			for (int l = 0; l < 7; l++)
			{
				array7[l] = new HardwareButtonInfo();
			}
			return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing)
				{
					ThreadSafeUnityInput.mouse.Monitor(state: false);
					ReInput.UpdateEndedEvent -= OGeVoLKxstqhbxehzcoBfDbiYtNr;
					ReInput.EarlyUpdateEvent -= YmCvxhWdqvaSizsODqYZGrBlmSp;
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			if (MagDxMEYyHuLNPjIpNIExVnjaxA == null)
			{
				MagDxMEYyHuLNPjIpNIExVnjaxA = GoDnaxMLAFBpfbupFMVHYRaePhZh();
			}
			return MagDxMEYyHuLNPjIpNIExVnjaxA.GetElementType(elementIdentifierId);
		}

		[CompilerGenerated]
		private static wubTOVsyCFQXfzehSenVBruEhLo XfINNKEmUKzSsCzPHajDXqTnGNY()
		{
			return new wubTOVsyCFQXfzehSenVBruEhLo(7, 4);
		}
	}
}
