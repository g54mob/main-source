using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	public class DebugInputController : MonoSingleton<DebugInputController>, IObserver
	{
		public event Action RightMouseDownEvent;

		public event Action MouseDownEvent;

		public event Action<float> MouseDownTickEvent;

		public event Action MouseUpEvent;

		public event Action<float> TickEvent;

		public event Action OnUpdateEvent;

		public void RightMouseDown()
		{
			this.RightMouseDownEvent?.Invoke();
		}

		public void MouseDown()
		{
			this.MouseDownEvent?.Invoke();
		}

		public void MouseDownTick()
		{
			this.MouseDownTickEvent?.Invoke(Time.unscaledDeltaTime);
		}

		public void Tick()
		{
			this.TickEvent?.Invoke(Time.unscaledDeltaTime);
		}

		public void MouseUp()
		{
			this.MouseUpEvent?.Invoke();
		}

		public void Reset()
		{
			this.RightMouseDownEvent = null;
			this.MouseDownEvent = null;
			this.MouseDownTickEvent = null;
			this.MouseUpEvent = null;
			this.TickEvent = null;
		}

		public void Update()
		{
			this.OnUpdateEvent?.Invoke();
		}
	}
}
