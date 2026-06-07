using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute
{
	public class FloatUpgrade
	{
		public AttributeUpgrade Upgrade;

		public float CurrentUpgradeValue;

		public FloatUpgrade(AttributeUpgrade attributeUpgrade)
		{
			Upgrade = attributeUpgrade;
			if (attributeUpgrade is FixedAttributeUpgrade)
			{
				CurrentUpgradeValue = (attributeUpgrade as FixedAttributeUpgrade).Enhancement;
			}
			else if (attributeUpgrade is TimedAttributeUpgrade)
			{
				CurrentUpgradeValue = (attributeUpgrade as TimedAttributeUpgrade).StartEnhancement;
			}
		}
	}
}
