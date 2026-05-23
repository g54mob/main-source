using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int fLdPNdzDmIoiuFznLvauKNJCEuhW;

		private readonly int yUFMFaBbKTDTHMhwePKNEjbAmXnn;

		private readonly bool[] oNCgUGEqEFegpCqMIbwfHlMvqNeE;

		private readonly bool[] FpsYilXHlRuROvvXnrilFmSMuSfq;

		private readonly float[] tmDvqbluvztVDHFeJcJxlHNGPwIp;

		private bool vwBOwzHzIXlHZduTPJVgXzBDjoWS;

		public int axisCount => fLdPNdzDmIoiuFznLvauKNJCEuhW;

		public int buttonCount => yUFMFaBbKTDTHMhwePKNEjbAmXnn;

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
			fLdPNdzDmIoiuFznLvauKNJCEuhW = P_0;
			yUFMFaBbKTDTHMhwePKNEjbAmXnn = P_1;
			tmDvqbluvztVDHFeJcJxlHNGPwIp = new float[P_0];
			oNCgUGEqEFegpCqMIbwfHlMvqNeE = new bool[P_1];
			FpsYilXHlRuROvvXnrilFmSMuSfq = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void TIKdBwxaeOhaemHAHHwQGGsEYTfS()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(tmDvqbluvztVDHFeJcJxlHNGPwIp, 0, fLdPNdzDmIoiuFznLvauKNJCEuhW);
			Array.Clear(oNCgUGEqEFegpCqMIbwfHlMvqNeE, 0, yUFMFaBbKTDTHMhwePKNEjbAmXnn);
			Array.Clear(FpsYilXHlRuROvvXnrilFmSMuSfq, 0, yUFMFaBbKTDTHMhwePKNEjbAmXnn);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return tmDvqbluvztVDHFeJcJxlHNGPwIp[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return oNCgUGEqEFegpCqMIbwfHlMvqNeE[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				tmDvqbluvztVDHFeJcJxlHNGPwIp[index] = value;
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
				Array.Copy(values as float[], tmDvqbluvztVDHFeJcJxlHNGPwIp, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				tmDvqbluvztVDHFeJcJxlHNGPwIp[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!oNCgUGEqEFegpCqMIbwfHlMvqNeE[index] && value)
				{
					FpsYilXHlRuROvvXnrilFmSMuSfq[index] = true;
				}
				oNCgUGEqEFegpCqMIbwfHlMvqNeE[index] = value;
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
					if (!oNCgUGEqEFegpCqMIbwfHlMvqNeE[i] && values[i])
					{
						FpsYilXHlRuROvvXnrilFmSMuSfq[i] = true;
					}
				}
				Array.Copy(values as bool[], oNCgUGEqEFegpCqMIbwfHlMvqNeE, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!oNCgUGEqEFegpCqMIbwfHlMvqNeE[j] && flag)
				{
					FpsYilXHlRuROvvXnrilFmSMuSfq[j] = true;
				}
				oNCgUGEqEFegpCqMIbwfHlMvqNeE[j] = flag;
			}
		}

		internal void FUhmfiizGwEZuqiuEbTshvrJIaUg()
		{
			OnInitialize();
		}

		internal void AbLqzOKOPDndaRMMTQhJwiXDtUGL()
		{
			Clear();
		}

		internal void xmVbKGcRxTkaqdrLifmxudGjifGhA(ControllerDataUpdater P_0)
		{
			qIrRCPvvlyBpITwmpZRBSIzlgVuq();
			Update();
			TIKdBwxaeOhaemHAHHwQGGsEYTfS();
			Array.Copy(tmDvqbluvztVDHFeJcJxlHNGPwIp, P_0.axisValues, fLdPNdzDmIoiuFznLvauKNJCEuhW);
			for (int i = 0; i < fLdPNdzDmIoiuFznLvauKNJCEuhW; i++)
			{
				if (tmDvqbluvztVDHFeJcJxlHNGPwIp[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(oNCgUGEqEFegpCqMIbwfHlMvqNeE, P_0.buttonValues, yUFMFaBbKTDTHMhwePKNEjbAmXnn);
			for (int j = 0; j < yUFMFaBbKTDTHMhwePKNEjbAmXnn; j++)
			{
				if (oNCgUGEqEFegpCqMIbwfHlMvqNeE[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (FpsYilXHlRuROvvXnrilFmSMuSfq[j] && !oNCgUGEqEFegpCqMIbwfHlMvqNeE[j])
				{
					oNCgUGEqEFegpCqMIbwfHlMvqNeE[j] = true;
				}
			}
		}

		private void qIrRCPvvlyBpITwmpZRBSIzlgVuq()
		{
			Array.Clear(FpsYilXHlRuROvvXnrilFmSMuSfq, 0, FpsYilXHlRuROvvXnrilFmSMuSfq.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!vwBOwzHzIXlHZduTPJVgXzBDjoWS)
			{
				vwBOwzHzIXlHZduTPJVgXzBDjoWS = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
