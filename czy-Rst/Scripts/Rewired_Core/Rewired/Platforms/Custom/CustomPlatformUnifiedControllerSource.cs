using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int VAgwxAoyiWZjIOciEGdDdQzJAOJy;

		private readonly int SnCJzHKIYZAqjDfpfZRghPHPudBq;

		private readonly bool[] OCByDpRAyRdZNENpRBkWdwDeXIQXA;

		private readonly bool[] pTnNAOKndXyjucCBendSsFeTulVi;

		private readonly float[] FCsDSfcvErExbIvPUSAAIzuPOmaB;

		private bool NfADRKMXYLFmroPIEgYLCmnMnKqeA;

		public int axisCount => VAgwxAoyiWZjIOciEGdDdQzJAOJy;

		public int buttonCount => SnCJzHKIYZAqjDfpfZRghPHPudBq;

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
			VAgwxAoyiWZjIOciEGdDdQzJAOJy = P_0;
			SnCJzHKIYZAqjDfpfZRghPHPudBq = P_1;
			FCsDSfcvErExbIvPUSAAIzuPOmaB = new float[P_0];
			OCByDpRAyRdZNENpRBkWdwDeXIQXA = new bool[P_1];
			pTnNAOKndXyjucCBendSsFeTulVi = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void pUJIEReQcKLJQtQXMqfzvsOBezPs()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(FCsDSfcvErExbIvPUSAAIzuPOmaB, 0, VAgwxAoyiWZjIOciEGdDdQzJAOJy);
			Array.Clear(OCByDpRAyRdZNENpRBkWdwDeXIQXA, 0, SnCJzHKIYZAqjDfpfZRghPHPudBq);
			Array.Clear(pTnNAOKndXyjucCBendSsFeTulVi, 0, SnCJzHKIYZAqjDfpfZRghPHPudBq);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return FCsDSfcvErExbIvPUSAAIzuPOmaB[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return OCByDpRAyRdZNENpRBkWdwDeXIQXA[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				FCsDSfcvErExbIvPUSAAIzuPOmaB[index] = value;
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
				Array.Copy(values as float[], FCsDSfcvErExbIvPUSAAIzuPOmaB, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				FCsDSfcvErExbIvPUSAAIzuPOmaB[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!OCByDpRAyRdZNENpRBkWdwDeXIQXA[index] && value)
				{
					pTnNAOKndXyjucCBendSsFeTulVi[index] = true;
				}
				OCByDpRAyRdZNENpRBkWdwDeXIQXA[index] = value;
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
					if (!OCByDpRAyRdZNENpRBkWdwDeXIQXA[i] && values[i])
					{
						pTnNAOKndXyjucCBendSsFeTulVi[i] = true;
					}
				}
				Array.Copy(values as bool[], OCByDpRAyRdZNENpRBkWdwDeXIQXA, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!OCByDpRAyRdZNENpRBkWdwDeXIQXA[j] && flag)
				{
					pTnNAOKndXyjucCBendSsFeTulVi[j] = true;
				}
				OCByDpRAyRdZNENpRBkWdwDeXIQXA[j] = flag;
			}
		}

		internal void fLeJRZzlMmItIttvHcwPIpFQjamcA()
		{
			OnInitialize();
		}

		internal void asIiBfHTHRVEEKEBYfXgRSlCDJsGA()
		{
			Clear();
		}

		internal void TyYrjtrolJgHCgWOfulWXTkspBgv(ControllerDataUpdater P_0)
		{
			GyolUyyeloJUoMqpkZKulHXapbWR();
			Update();
			pUJIEReQcKLJQtQXMqfzvsOBezPs();
			Array.Copy(FCsDSfcvErExbIvPUSAAIzuPOmaB, P_0.axisValues, VAgwxAoyiWZjIOciEGdDdQzJAOJy);
			for (int i = 0; i < VAgwxAoyiWZjIOciEGdDdQzJAOJy; i++)
			{
				if (FCsDSfcvErExbIvPUSAAIzuPOmaB[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(OCByDpRAyRdZNENpRBkWdwDeXIQXA, P_0.buttonValues, SnCJzHKIYZAqjDfpfZRghPHPudBq);
			for (int j = 0; j < SnCJzHKIYZAqjDfpfZRghPHPudBq; j++)
			{
				if (OCByDpRAyRdZNENpRBkWdwDeXIQXA[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (pTnNAOKndXyjucCBendSsFeTulVi[j] && !OCByDpRAyRdZNENpRBkWdwDeXIQXA[j])
				{
					OCByDpRAyRdZNENpRBkWdwDeXIQXA[j] = true;
				}
			}
		}

		private void GyolUyyeloJUoMqpkZKulHXapbWR()
		{
			Array.Clear(pTnNAOKndXyjucCBendSsFeTulVi, 0, pTnNAOKndXyjucCBendSsFeTulVi.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!NfADRKMXYLFmroPIEgYLCmnMnKqeA)
			{
				NfADRKMXYLFmroPIEgYLCmnMnKqeA = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
