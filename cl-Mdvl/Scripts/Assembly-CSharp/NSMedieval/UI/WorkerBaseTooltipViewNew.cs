using System;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public abstract class WorkerBaseTooltipViewNew : TooltipViewNew
	{
		[field: NonSerialized]
		protected HumanoidInstance Humanoid { get; private set; }

		public void SetOwner(HumanoidInstance humanoid)
		{
			Humanoid = humanoid;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Humanoid = null;
		}
	}
}
