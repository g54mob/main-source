using System.Collections.Generic;
using NSEipix.Base;

namespace NSMedieval.Tutorial
{
	public class FinalTutorialStep : TutorialStep
	{
		public FinalTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>();
		}

		public override void BeginStep()
		{
			base.BeginStep();
			DeselectAllDelayed();
			MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.SetTutorialComplete();
			CompleteStep();
		}
	}
}
