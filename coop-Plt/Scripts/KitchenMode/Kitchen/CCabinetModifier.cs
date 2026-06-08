using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCabinetModifier : IApplianceProperty, IAttachableProperty, IComponentData, IEffectType
	{
		public bool Upgrades;

		public bool Duplicates;

		public bool MakesFree;

		public bool DisablesDeskAfterImprovement;

		public bool DefaultUpgrades;

		public bool DefaultDuplicates;

		public bool DefaultMakesFree;

		public bool DefaultDisablesDeskAfterImprovement;

		public void Combine(CCabinetModifier other)
		{
			Upgrades |= other.Upgrades;
			Duplicates |= other.Duplicates;
			MakesFree |= other.MakesFree;
			DisablesDeskAfterImprovement |= other.DisablesDeskAfterImprovement;
		}

		public void Reset()
		{
			Upgrades = DefaultUpgrades;
			Duplicates = DefaultDuplicates;
			MakesFree = DefaultMakesFree;
			DisablesDeskAfterImprovement = DefaultDisablesDeskAfterImprovement;
		}
	}
}
