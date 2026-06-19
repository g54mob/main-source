using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int EMVSsULlHEGdPBTOynBsYZoXwlaoA;

		private readonly int VWlrXJrjGLYTqYTZZrONJAgVEgef;

		private readonly bool[] LZgbXniINNvtYWmHpFSlfCMoajbRA;

		private readonly bool[] kKYQHCjpMXaUlpRoGhXvCSnPkLyjb;

		private readonly float[] QLpMRSFRUzsyyByHgnynwEeBVxDU;

		private bool WWtYXElerVwKatvwgqeyQKsSOpJo;

		public int axisCount => EMVSsULlHEGdPBTOynBsYZoXwlaoA;

		public int buttonCount => VWlrXJrjGLYTqYTZZrONJAgVEgef;

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
			EMVSsULlHEGdPBTOynBsYZoXwlaoA = P_0;
			VWlrXJrjGLYTqYTZZrONJAgVEgef = P_1;
			QLpMRSFRUzsyyByHgnynwEeBVxDU = new float[P_0];
			LZgbXniINNvtYWmHpFSlfCMoajbRA = new bool[P_1];
			kKYQHCjpMXaUlpRoGhXvCSnPkLyjb = new bool[P_1];
		}

		protected abstract void Update();

		internal virtual void qewMkHDdLAlwJqtxaRESVhPHKIqJ()
		{
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void Clear()
		{
			Array.Clear(QLpMRSFRUzsyyByHgnynwEeBVxDU, 0, EMVSsULlHEGdPBTOynBsYZoXwlaoA);
			Array.Clear(LZgbXniINNvtYWmHpFSlfCMoajbRA, 0, VWlrXJrjGLYTqYTZZrONJAgVEgef);
			Array.Clear(kKYQHCjpMXaUlpRoGhXvCSnPkLyjb, 0, VWlrXJrjGLYTqYTZZrONJAgVEgef);
		}

		protected float GetAxisValue(int index)
		{
			if ((uint)index >= (uint)axisCount)
			{
				return 0f;
			}
			return QLpMRSFRUzsyyByHgnynwEeBVxDU[index];
		}

		protected bool GetButtonValue(int index)
		{
			if ((uint)index >= (uint)buttonCount)
			{
				return false;
			}
			return LZgbXniINNvtYWmHpFSlfCMoajbRA[index];
		}

		protected void SetAxisValue(int index, float value)
		{
			if ((uint)index < (uint)axisCount)
			{
				QLpMRSFRUzsyyByHgnynwEeBVxDU[index] = value;
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
				Array.Copy(values as float[], QLpMRSFRUzsyyByHgnynwEeBVxDU, num);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				QLpMRSFRUzsyyByHgnynwEeBVxDU[i] = values[i];
			}
		}

		protected void SetButtonValue(int index, bool value)
		{
			if ((uint)index < (uint)buttonCount)
			{
				if (!LZgbXniINNvtYWmHpFSlfCMoajbRA[index] && value)
				{
					kKYQHCjpMXaUlpRoGhXvCSnPkLyjb[index] = true;
				}
				LZgbXniINNvtYWmHpFSlfCMoajbRA[index] = value;
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
					if (!LZgbXniINNvtYWmHpFSlfCMoajbRA[i] && values[i])
					{
						kKYQHCjpMXaUlpRoGhXvCSnPkLyjb[i] = true;
					}
				}
				Array.Copy(values as bool[], LZgbXniINNvtYWmHpFSlfCMoajbRA, num);
				return;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = values[j];
				if (!LZgbXniINNvtYWmHpFSlfCMoajbRA[j] && flag)
				{
					kKYQHCjpMXaUlpRoGhXvCSnPkLyjb[j] = true;
				}
				LZgbXniINNvtYWmHpFSlfCMoajbRA[j] = flag;
			}
		}

		internal void uTJJzLAfNgFJTuNpbUcoujMYHPFm()
		{
			OnInitialize();
		}

		internal void lNdLRvibkDoWXDnjqpcNbZoCmnRj()
		{
			Clear();
		}

		internal void SgttIvWYILdcHjIcNXirfznqodXh(ControllerDataUpdater P_0)
		{
			RPVxvoXIEiuczXsFGrwPNkUepUpV();
			Update();
			qewMkHDdLAlwJqtxaRESVhPHKIqJ();
			Array.Copy(QLpMRSFRUzsyyByHgnynwEeBVxDU, P_0.axisValues, EMVSsULlHEGdPBTOynBsYZoXwlaoA);
			for (int i = 0; i < EMVSsULlHEGdPBTOynBsYZoXwlaoA; i++)
			{
				if (QLpMRSFRUzsyyByHgnynwEeBVxDU[i] != 0f && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
			}
			Array.Copy(LZgbXniINNvtYWmHpFSlfCMoajbRA, P_0.buttonValues, VWlrXJrjGLYTqYTZZrONJAgVEgef);
			for (int j = 0; j < VWlrXJrjGLYTqYTZZrONJAgVEgef; j++)
			{
				if (LZgbXniINNvtYWmHpFSlfCMoajbRA[j] && !P_0.hasReceivedInput)
				{
					P_0.hasReceivedInput = true;
				}
				if (kKYQHCjpMXaUlpRoGhXvCSnPkLyjb[j] && !LZgbXniINNvtYWmHpFSlfCMoajbRA[j])
				{
					LZgbXniINNvtYWmHpFSlfCMoajbRA[j] = true;
				}
			}
		}

		private void RPVxvoXIEiuczXsFGrwPNkUepUpV()
		{
			Array.Clear(kKYQHCjpMXaUlpRoGhXvCSnPkLyjb, 0, kKYQHCjpMXaUlpRoGhXvCSnPkLyjb.Length);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!WWtYXElerVwKatvwgqeyQKsSOpJo)
			{
				WWtYXElerVwKatvwgqeyQKsSOpJo = true;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
