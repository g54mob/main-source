using Aggro.Core.Networking;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ModifierBase : NetworkEntityBehaviourBase
{
	public ModifierFlags flags;

	public ModifierArtStyle modifierArtStyle;

	[Min(0f)]
	public float patienceMultiplier = 1f;

	[Min(0f)]
	public float payoutMultiplier = 1f;

	[Min(0f)]
	public int hazardPay;

	[FormerlySerializedAs("modifierIconA")]
	public Sprite modifierIcon;

	public string modifierName;

	public string modifierDescription;

	[Space]
	public string contractCompleteAchievement;

	public virtual bool Evaluate()
	{
		return true;
	}

	public override bool Weaved()
	{
		return true;
	}
}
