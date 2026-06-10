using System;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class SelectionExtraEnemy : SelectionExtraWindowView
	{
		[NonSerialized]
		private HumanoidInstance humanoidInstance;

		public HumanoidInstance HumanoidInstance => humanoidInstance;

		public void ShowPanel(HumanoidInstance humanoidInstance)
		{
			if (this.humanoidInstance != humanoidInstance)
			{
				this.humanoidInstance = humanoidInstance;
			}
			ShowPanel();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoidInstance = null;
		}
	}
}
