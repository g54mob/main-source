using System;
using System.Collections.Generic;
using FixMath;

namespace Motorways.Processes
{
	public class IdleHint
	{
		private const float DefaultDelayBeforeIdleHint = 1f;

		public Fix64 idleTime = Fix64.Zero;

		public Fix64 DelayBeforeShowing = (Fix64)1f;

		public Action<Fix64> ShowHintHandler;

		public Action HideHintHandler;

		public List<Func<bool>> ShowConditions = new List<Func<bool>>();

		public Action StepProgressedHandler;

		public IdleHint SetDelayBeforeShowing(float delay)
		{
			DelayBeforeShowing = (Fix64)delay;
			return this;
		}

		public IdleHint SetShowHintHandler(Action handler)
		{
			ShowHintHandler = delegate
			{
				handler();
			};
			return this;
		}

		public IdleHint SetShowHintHandler(Action<Fix64> handler)
		{
			ShowHintHandler = handler;
			return this;
		}

		public IdleHint SetHideHintHandler(Action handler)
		{
			HideHintHandler = handler;
			return this;
		}

		public IdleHint SetProgressionHandler(Action handler)
		{
			StepProgressedHandler = handler;
			return this;
		}

		public IdleHint AddCondition(Func<bool> condition)
		{
			ShowConditions.Add(condition);
			return this;
		}
	}
}
