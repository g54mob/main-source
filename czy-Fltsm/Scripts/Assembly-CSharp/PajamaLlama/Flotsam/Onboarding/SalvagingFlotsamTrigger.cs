using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class SalvagingFlotsamTrigger : DelayedTutorialTriggerAction
	{
		public override void Update()
		{
			if (!base.WasTriggered)
			{
				if ((bool)GameManager.CursorManager.Properties && GameManager.CursorManager.Properties.Cursor == CursorState.Salvage)
				{
					base.WasTriggered = true;
				}
				else
				{
					base.Update();
				}
			}
		}
	}
}
