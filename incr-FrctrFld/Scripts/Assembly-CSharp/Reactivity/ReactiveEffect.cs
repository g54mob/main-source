using System;

namespace Reactivity
{
	public class ReactiveEffect : ReactiveEffectBase, IReactiveEffect
	{
		private readonly Action _effectAction;

		public ReactiveEffect(Action effectAction)
		{
		}

		public override void Invalidate()
		{
		}

		public virtual void RunEffect()
		{
		}
	}
}
