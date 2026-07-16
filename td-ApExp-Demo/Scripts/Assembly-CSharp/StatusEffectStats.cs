using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect Stats", menuName = "Status Effects/Create New Status Effect Stats")]
public class StatusEffectStats : StatusEffect
{
	[NonReorderable]
	public StatUpgrade[] statUpgrades;
}
