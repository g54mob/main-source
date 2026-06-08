public class InvisibilityPotionActivationState : BasePotionActivationState
{
	public DebuffStatMod invisibilityBuff;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_invisibility");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing)
		{
			if (stateElapsedTics == 20)
			{
				AddBuff(invisibilityBuff);
			}
			else if (stateElapsedTics == 45)
			{
				SetState(State.Done);
			}
		}
	}
}
