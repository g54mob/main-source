using System;

namespace Coffee.UISoftMaskInternal
{
	internal class FastAction : FastActionBase<Action>
	{
		public void Invoke()
		{
			Invoke(delegate(Action action)
			{
				action();
			});
		}
	}
}
