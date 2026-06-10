using System;
using NSEipix.Base;
using NSMedieval.Controllers;

namespace NSMedieval.UI.ScenarioEditor
{
	public class GeneratingWorkersPopupView : CharacterEditPopupView
	{
		protected override void Start()
		{
			CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
			instance.GeneratingWorkersAction = (Action<bool>)Delegate.Combine(instance.GeneratingWorkersAction, new Action<bool>(OnWorkerGeneration));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<CharacterEditController>.IsInstantiated())
			{
				CharacterEditController instance = MonoSingleton<CharacterEditController>.Instance;
				instance.GeneratingWorkersAction = (Action<bool>)Delegate.Remove(instance.GeneratingWorkersAction, new Action<bool>(OnWorkerGeneration));
			}
		}

		private void OnWorkerGeneration(bool workersGenerating)
		{
			if (workersGenerating)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}
	}
}
