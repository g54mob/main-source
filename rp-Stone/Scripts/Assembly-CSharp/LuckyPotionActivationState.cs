public class LuckyPotionActivationState : BasePotionActivationState
{
	public DebuffStatMod criticalChanceBuff;

	public DebuffStatMod criticalMultBuff;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_lucky");
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing)
		{
			if (stateElapsedTics == 37)
			{
				AddBuff(criticalChanceBuff);
				AddBuff(criticalMultBuff);
				CameraShake.singleton.ShakeCamera(4f, 0.3f);
			}
			else if (stateElapsedTics == 45)
			{
				SetState(State.Done);
			}
		}
	}
}
