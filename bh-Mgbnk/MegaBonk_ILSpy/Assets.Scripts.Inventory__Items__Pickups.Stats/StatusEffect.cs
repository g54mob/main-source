using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class StatusEffect
{
	public EStatusEffect eStatusEffect;

	public StatModifier[] modifiers;

	public float expirationTime;

	public float addedTime;

	public StatusEffect(EStatusEffect eStatusEffect, float expirationTime, StatModifier[] modifiers)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		this.eStatusEffect = eStatusEffect;
		this.modifiers = modifiers;
		this.expirationTime = expirationTime;
		addedTime = MyTime.time;
	}
}
