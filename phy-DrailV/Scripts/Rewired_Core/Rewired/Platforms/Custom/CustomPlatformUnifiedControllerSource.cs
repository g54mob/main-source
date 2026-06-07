using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int KkbOXxEuXwhRkKpefZpsKkvoQFpI;

		private readonly int sqOAjqiYgpyrLlQchddtcgIsmpGfb;

		private readonly bool[] KPyRASCadfDvEEQtaqmfYfKlhabJ;

		private readonly bool[] zpiDSbjhSttVWrnHmbytbmYwoIlfb;

		private readonly float[] iyvePiDsBkaQEukPGjVOgSrcFsyCB;

		private bool ZEucKeKlveETZGcCGvBfVqUuxSvEB;

		public int axisCount => KkbOXxEuXwhRkKpefZpsKkvoQFpI;

		public int buttonCount => sqOAjqiYgpyrLlQchddtcgIsmpGfb;

		public virtual Controller.Extension controllerExtension => null;

		public CustomPlatformUnifiedControllerSource(int P_0, int P_1)
		{
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			KkbOXxEuXwhRkKpefZpsKkvoQFpI = P_0;
			sqOAjqiYgpyrLlQchddtcgIsmpGfb = P_1;
			iyvePiDsBkaQEukPGjVOgSrcFsyCB = new float[P_0];
			KPyRASCadfDvEEQtaqmfYfKlhabJ = new bool[P_1];
			zpiDSbjhSttVWrnHmbytbmYwoIlfb = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void cwOErHdoGDKEsFmyGHskstVlrOhbB()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(iyvePiDsBkaQEukPGjVOgSrcFsyCB, 0, KkbOXxEuXwhRkKpefZpsKkvoQFpI);
			Array.Clear(KPyRASCadfDvEEQtaqmfYfKlhabJ, 0, sqOAjqiYgpyrLlQchddtcgIsmpGfb);
			Array.Clear(zpiDSbjhSttVWrnHmbytbmYwoIlfb, 0, sqOAjqiYgpyrLlQchddtcgIsmpGfb);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return iyvePiDsBkaQEukPGjVOgSrcFsyCB[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return KPyRASCadfDvEEQtaqmfYfKlhabJ[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				iyvePiDsBkaQEukPGjVOgSrcFsyCB[index] = value;
			}
		}

		protected void SetAxisValues(IList<float> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, axisCount);
			if (values is float[])
			{
				Array.Copy(values as float[], iyvePiDsBkaQEukPGjVOgSrcFsyCB, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				iyvePiDsBkaQEukPGjVOgSrcFsyCB[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!KPyRASCadfDvEEQtaqmfYfKlhabJ[index] && value)
				{
					zpiDSbjhSttVWrnHmbytbmYwoIlfb[index] = true;
				}
				KPyRASCadfDvEEQtaqmfYfKlhabJ[index] = value;
			}
		}

		protected void SetButtonValues(IList<bool> values)
		{
			if (values == null)
			{
				return;
			}
			int num = MathTools.Min(values.Count, buttonCount);
			if (values is bool[])
			{
				for (int i = 0; i < num; i++)
				{
					if (!KPyRASCadfDvEEQtaqmfYfKlhabJ[i] && values[i])
					{
						zpiDSbjhSttVWrnHmbytbmYwoIlfb[i] = true;
					}
				}
				Array.Copy(values as bool[], KPyRASCadfDvEEQtaqmfYfKlhabJ, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!KPyRASCadfDvEEQtaqmfYfKlhabJ[j] && flag)
				{
					zpiDSbjhSttVWrnHmbytbmYwoIlfb[j] = true;
				}
				KPyRASCadfDvEEQtaqmfYfKlhabJ[j] = flag;
			}
		}

		internal void TlzckGoQDITHcUYaslQXPQBOhTwq()
		{
			OnInitialize();
		}

		internal void CqcLWLPcoljiIapBMxavaEZwQtbB()
		{
			Clear();
		}

		internal void uCTfSYfhTsfpmeiPwfdAzCZjMcOMA(ControllerDataUpdater P_0)
		{
			WhtIakgWUZoLwcMgqgKkCszheDfBA();
			Update();
			cwOErHdoGDKEsFmyGHskstVlrOhbB();
			Array.Copy(iyvePiDsBkaQEukPGjVOgSrcFsyCB, P_0.axisValues, KkbOXxEuXwhRkKpefZpsKkvoQFpI);
			for (int i = 0; i < KkbOXxEuXwhRkKpefZpsKkvoQFpI; i++)
			{
				if (iyvePiDsBkaQEukPGjVOgSrcFsyCB[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(KPyRASCadfDvEEQtaqmfYfKlhabJ, P_0.buttonValues, sqOAjqiYgpyrLlQchddtcgIsmpGfb);
			for (int j = 0; j < sqOAjqiYgpyrLlQchddtcgIsmpGfb; j++)
			{
				if (KPyRASCadfDvEEQtaqmfYfKlhabJ[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (zpiDSbjhSttVWrnHmbytbmYwoIlfb[j] && !KPyRASCadfDvEEQtaqmfYfKlhabJ[j])
				{
					KPyRASCadfDvEEQtaqmfYfKlhabJ[j] = true;
				}
			}
		}

		private void WhtIakgWUZoLwcMgqgKkCszheDfBA()
		{
			Array.Clear(zpiDSbjhSttVWrnHmbytbmYwoIlfb, 0, zpiDSbjhSttVWrnHmbytbmYwoIlfb.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!ZEucKeKlveETZGcCGvBfVqUuxSvEB)
			{
				ZEucKeKlveETZGcCGvBfVqUuxSvEB = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
