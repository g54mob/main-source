public class StrengthPotionActivationState : BasePotionActivationState
{
	public DebuffStatMod strengthBuff;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_strength");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing)
		{
			if (stateElapsedTics == 33)
			{
				AddBuff(strengthBuff);
			}
			else if (stateElapsedTics == 45)
			{
				SetState(State.Done);
			}
		}
	}
}
