using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int YjXrkDfplAsdtsBcluKXGZauAmyQ;

		private readonly int TUfvDADqPJOCQvlzWajaWBMeBTgj;

		private readonly bool[] ZAyVgqOrMNfmprrHaNGsVSBNurjc;

		private readonly bool[] qNEUXLJQwRoKZCFOXVYSDNfqBOcx;

		private readonly float[] MkfyRLfqajHeAhsxpFtAXlikpoDhb;

		private bool WzvlNDFsVPhUIUDWfdrVRTgzboFZ;

		public int axisCount => YjXrkDfplAsdtsBcluKXGZauAmyQ;

		public int buttonCount => TUfvDADqPJOCQvlzWajaWBMeBTgj;

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
			YjXrkDfplAsdtsBcluKXGZauAmyQ = P_0;
			TUfvDADqPJOCQvlzWajaWBMeBTgj = P_1;
			MkfyRLfqajHeAhsxpFtAXlikpoDhb = new float[P_0];
			ZAyVgqOrMNfmprrHaNGsVSBNurjc = new bool[P_1];
			qNEUXLJQwRoKZCFOXVYSDNfqBOcx = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void sisKDAvpjMbjnHxNlCCfIzPoFSmi()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(MkfyRLfqajHeAhsxpFtAXlikpoDhb, 0, YjXrkDfplAsdtsBcluKXGZauAmyQ);
			Array.Clear(ZAyVgqOrMNfmprrHaNGsVSBNurjc, 0, TUfvDADqPJOCQvlzWajaWBMeBTgj);
			Array.Clear(qNEUXLJQwRoKZCFOXVYSDNfqBOcx, 0, TUfvDADqPJOCQvlzWajaWBMeBTgj);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return MkfyRLfqajHeAhsxpFtAXlikpoDhb[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return ZAyVgqOrMNfmprrHaNGsVSBNurjc[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				MkfyRLfqajHeAhsxpFtAXlikpoDhb[index] = value;
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
				Array.Copy(values as float[], MkfyRLfqajHeAhsxpFtAXlikpoDhb, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				MkfyRLfqajHeAhsxpFtAXlikpoDhb[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!ZAyVgqOrMNfmprrHaNGsVSBNurjc[index] && value)
				{
					qNEUXLJQwRoKZCFOXVYSDNfqBOcx[index] = true;
				}
				ZAyVgqOrMNfmprrHaNGsVSBNurjc[index] = value;
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
					if (!ZAyVgqOrMNfmprrHaNGsVSBNurjc[i] && values[i])
					{
						qNEUXLJQwRoKZCFOXVYSDNfqBOcx[i] = true;
					}
				}
				Array.Copy(values as bool[], ZAyVgqOrMNfmprrHaNGsVSBNurjc, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!ZAyVgqOrMNfmprrHaNGsVSBNurjc[j] && flag)
				{
					qNEUXLJQwRoKZCFOXVYSDNfqBOcx[j] = true;
				}
				ZAyVgqOrMNfmprrHaNGsVSBNurjc[j] = flag;
			}
		}

		internal void qqDXECmLViHPfTLfoTgNzlCjIPFK()
		{
			OnInitialize();
		}

		internal void bKjDIwENMRchxgtLnyamqImhHjTn()
		{
			Clear();
		}

		internal void SLhbkkqHyHhprKhAUvOQgPrDcxLX(ControllerDataUpdater P_0)
		{
			NmLOnhbHeweaPKctRzpcUKGBmTbTA();
			Update();
			sisKDAvpjMbjnHxNlCCfIzPoFSmi();
			Array.Copy(MkfyRLfqajHeAhsxpFtAXlikpoDhb, P_0.axisValues, YjXrkDfplAsdtsBcluKXGZauAmyQ);
			for (int i = 0; i < YjXrkDfplAsdtsBcluKXGZauAmyQ; i++)
			{
				if (MkfyRLfqajHeAhsxpFtAXlikpoDhb[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(ZAyVgqOrMNfmprrHaNGsVSBNurjc, P_0.buttonValues, TUfvDADqPJOCQvlzWajaWBMeBTgj);
			for (int j = 0; j < TUfvDADqPJOCQvlzWajaWBMeBTgj; j++)
			{
				if (ZAyVgqOrMNfmprrHaNGsVSBNurjc[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (qNEUXLJQwRoKZCFOXVYSDNfqBOcx[j] && !ZAyVgqOrMNfmprrHaNGsVSBNurjc[j])
				{
					ZAyVgqOrMNfmprrHaNGsVSBNurjc[j] = true;
				}
			}
		}

		private void NmLOnhbHeweaPKctRzpcUKGBmTbTA()
		{
			Array.Clear(qNEUXLJQwRoKZCFOXVYSDNfqBOcx, 0, qNEUXLJQwRoKZCFOXVYSDNfqBOcx.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!WzvlNDFsVPhUIUDWfdrVRTgzboFZ)
			{
				WzvlNDFsVPhUIUDWfdrVRTgzboFZ = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
