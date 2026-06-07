using DV.Customization.Gadgets;

namespace DV.Tutorial.QT
{
	public class SolderingGunFullCondition : AQuickTutorialCondition
	{
		public delegate GadgetSolderingTool ToolProvider();

		private ToolProvider provider;

		private GadgetSolderingTool solderingTool;

		private string message;

		public SolderingGunFullCondition(GadgetSolderingTool solderingTool, string message = "", bool shouldRecheck = true)
		{
			this.solderingTool = solderingTool;
			this.message = (string.IsNullOrEmpty(message) ? "NOT FULL" : message);
		}

		public SolderingGunFullCondition(ToolProvider provider, string message = "", bool shouldRecheck = true)
		{
			this.provider = provider;
			this.message = (string.IsNullOrEmpty(message) ? "NOT FULL" : message);
		}

		public override void Start()
		{
			base.Start();
			if (provider != null)
			{
				solderingTool = provider();
			}
		}

		public override string Check()
		{
			if (!solderingTool.CoilFull)
			{
				return message;
			}
			return string.Empty;
		}
	}
}
