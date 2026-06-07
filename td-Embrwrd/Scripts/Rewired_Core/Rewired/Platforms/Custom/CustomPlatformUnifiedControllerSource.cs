using System;
using System.Collections.Generic;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformUnifiedControllerSource : IDisposable
	{
		private readonly int KfRWvCpzYFRemAUeZDKlTWcMkGL;

		private readonly int LAPgPqjsTFKoZxxNZZnjRpasmxUeb;

		private readonly bool[] VZKrnWpvlZiHljlPxlQJyTmPoMBU;

		private readonly bool[] qHaDtzusePciKYBuUaBRFcDwosAgA;

		private readonly float[] AlTxhnWhsrgMJsyNifcNKNYwuOlX;

		private bool OrNpaxiPpTsqTCmhgmAWkiQtITzf;

		public int axisCount => 0;

		public int buttonCount => 0;

		public virtual Controller.Extension controllerExtension => null;

		public CustomPlatformUnifiedControllerSource(int P_0, int P_1)
		{
		}

		protected abstract void Update();

		internal virtual void uHCGieECfKYBsHDnkLDeavbafxAIA()
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

		internal void sZpDxmDIJiGpoIZVdqUCkSmzqybqA()
		{
		}

		internal void xtLfvIetQVLWsBcrgsnrjJIMlNbkb()
		{
		}

		internal void MjTyHMLPoFiDgeUyXWJXGXTJMZdbA(ControllerDataUpdater P_0)
		{
		}

		private void PJvXeNSeqmQIScLzQcTzjiWNzAPC()
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
