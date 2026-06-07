using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class MovingTheTownTrigger : DelayedTutorialTriggerAction
	{
		public override void Update()
		{
			if (!base.WasTriggered && GameManager.UIManager.WorldMapCanvas.isActiveAndEnabled)
			{
				base.Update();
			}
		}
	}
}
