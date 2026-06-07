using Client;
using Factory;

namespace Motorways.Views
{
	public class UpgradeBarWrapper : UpgradeBarClient
	{
		[EnumTypedArray(typeof(DeviceCategory))]
		public UpgradeBarClient[] upgradeBars;

		public override TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Tick(timeInterval, stepAlpha);
			}
			return base.Tick(timeInterval, stepAlpha);
		}

		public override void OnCreatedInScope(IScope scope)
		{
			UpgradeBarClient[] array = upgradeBars;
			foreach (UpgradeBarClient unboundObject in array)
			{
				scope.Assemble(unboundObject);
			}
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnReleasedFromScope(scope);
			}
		}

		public override void SetVisibility(bool isVisible, bool instantly = false)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetVisibility(isVisible, instantly);
			}
			base.IsVisible = isVisible;
		}

		public override void SetUpgradeButtonVisible(UpgradeType type, bool visible)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetUpgradeButtonVisible(type, visible);
			}
		}

		public override void AddToUpgradeButtonStack(UpgradeType type, bool fromAnimation = false, int count = 1)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddToUpgradeButtonStack(type, fromAnimation, count);
			}
		}

		public override void AddPendingToUpgradeButtonStack(UpgradeType type, int count = 1)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddPendingToUpgradeButtonStack(type, count);
			}
		}

		public override void RemoveFromUpgradeButtonStack(UpgradeType type, bool fromAnimation = false)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveFromUpgradeButtonStack(type, fromAnimation);
			}
		}

		public override void PulseUpgradeIcon(UpgradeType type)
		{
			UpgradeBarClient[] array = upgradeBars;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PulseUpgradeIcon(type);
			}
		}
	}
}
