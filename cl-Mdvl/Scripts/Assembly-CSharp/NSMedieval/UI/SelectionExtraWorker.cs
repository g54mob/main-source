using System;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class SelectionExtraWorker : SelectionExtraWindowView
	{
		[NonSerialized]
		private HumanoidInstance humanoid;

		public HumanoidInstance Humanoid => humanoid;

		public void ShowPanel(HumanoidInstance humanoid)
		{
			if (this.humanoid != humanoid)
			{
				this.humanoid = humanoid;
			}
			ShowPanel();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			humanoid = null;
		}
	}
}
