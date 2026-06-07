using System;

namespace Coffee.UIParticleInternal
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
