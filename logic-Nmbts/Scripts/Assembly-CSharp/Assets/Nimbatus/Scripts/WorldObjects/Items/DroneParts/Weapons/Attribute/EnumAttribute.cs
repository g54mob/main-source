using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute
{
	public class EnumAttribute<T> : WeaponAttribute
	{
		public T Value;

		private bool _wasUpdated;

		public override void ApplyUpgrade(WeaponAttributeUpgrade emitterUpgrade)
		{
			foreach (AttributeUpgrade attributeUpgrade in emitterUpgrade.AttributeUpgrades)
			{
				if (attributeUpgrade is EnumAttributeUpgrade<T>)
				{
					Value = ((EnumAttributeUpgrade<T>)attributeUpgrade).Value;
					_wasUpdated = true;
				}
			}
		}

		public override void Update(bool shooting)
		{
		}

		public override string ToString()
		{
			if (_wasUpdated)
			{
				return LabelHelper.White + AttributeName + ": " + LabelHelper.Green + Value;
			}
			return LabelHelper.White + AttributeName + ": " + LabelHelper.Orange + Value;
		}
	}
}
