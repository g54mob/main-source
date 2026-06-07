using Assets.Scripts.Flight.MapView.Items;
using ModApi.Flight.UI;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface INavigationTargetProvider
	{
		IChainableOrbit ChainNodeToGetTargetInfoFor { get; }

		ITargetableItem NavigationTarget { get; }

		bool Pinned { get; }

		bool IsProcessingTargetInformationFor(IChainableOrbit chainableOrbit);

		bool IsValidTarget(ITargetableItem target);

		void SetNavigationTarget(ITargetableItem target);

		void SetNavSphereTarget(INavSphereTarget target);

		void SetPinned(bool pinned);
	}
}
