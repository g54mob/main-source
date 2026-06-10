using System.Collections.Generic;
using NSEipix.Base;

namespace NSMedieval.Tutorial
{
	public class StartTutorialStep : TutorialStep
	{
		public StartTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>();
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleCreatureCommands(allow: false);
			MonoSingleton<TutorialManager>.Instance.HandleOrdersPanel(allow: false);
			MonoSingleton<TutorialManager>.Instance.PreventWorldTimeTick = true;
			CompleteStep();
		}
	}
}
