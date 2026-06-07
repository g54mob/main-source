using System;
using System.Collections.Generic;

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

		public int axisCount => 0;

		public int buttonCount => 0;

		public virtual Controller.Extension controllerExtension => null;

		public CustomPlatformUnifiedControllerSource(int P_0, int P_1)
		{
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
		}

		protected float GetAxisValue(int index)
		{
			return 0f;
		}

		protected bool GetButtonValue(int index)
		{
			return false;
		}

		protected void SetAxisValue(int index, float value)
		{
		}

		protected void SetAxisValues(IList<float> values)
		{
		}

		protected void SetButtonValue(int index, bool value)
		{
		}

		protected void SetButtonValues(IList<bool> values)
		{
		}

		internal void uTJJzLAfNgFJTuNpbUcoujMYHPFm()
		{
		}

		internal void lNdLRvibkDoWXDnjqpcNbZoCmnRj()
		{
		}

		internal void SgttIvWYILdcHjIcNXirfznqodXh(ControllerDataUpdater P_0)
		{
		}

		private void RPVxvoXIEiuczXsFGrwPNkUepUpV()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
