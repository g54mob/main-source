using System;

public class EventObjectiveDrinkPotion : EventObjectiveBase
{
	private Potion.Type potionType;

	public EventObjectiveDrinkPotion(int goal, Potion.Type potionType = Potion.Type.Empty, string potionName = "tid_potion_00")
		: base("drink_potion", goal)
	{
		this.potionType = potionType;
		if (potionType == Potion.Type.Empty)
		{
			description = Te.xt("tid_q_basic_drink_potion_any");
		}
		else
		{
			description = string.Format(Te.xt("tid_q_basic_drink_potion"), TranslateIfTID(potionName));
		}
	}

	public override void Init()
	{
		Potion.OnPotionActivated = (Action<Potion>)Delegate.Combine(Potion.OnPotionActivated, new Action<Potion>(HandlePotionActivated));
	}

	public override void End()
	{
		Potion.OnPotionActivated = (Action<Potion>)Delegate.Remove(Potion.OnPotionActivated, new Action<Potion>(HandlePotionActivated));
	}

	private void HandlePotionActivated(Potion potion)
	{
		if (potionType == Potion.Type.Empty || potionType == potion.type)
		{
			AddProgress();
		}
	}
}
