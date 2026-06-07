using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public abstract class TabletopHUDPopupModule : HUDPopupModule
	{
		public sealed override EHUDPopupModuleType Type => EHUDPopupModuleType.SPECIFIC;

		public abstract ETabletopHUDPopupModuleType ActualType { get; }
	}
}
