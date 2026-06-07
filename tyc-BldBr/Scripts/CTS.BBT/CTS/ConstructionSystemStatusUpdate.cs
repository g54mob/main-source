using CTS.Core;

namespace CTS
{
	public abstract class ConstructionSystemStatusUpdate : CTSBehaviour
	{
		protected override void OnAwake()
		{
			base.OnAwake();
			UI_ConstructionSystem.OnOpenBuildMode += OnConstructionOpened;
			UI_ConstructionSystem.OnCloseBuildMode += OnConstructionClosed;
		}

		protected void OnDestroy()
		{
			UI_ConstructionSystem.OnOpenBuildMode -= OnConstructionOpened;
			UI_ConstructionSystem.OnCloseBuildMode -= OnConstructionClosed;
		}

		protected abstract void OnConstructionOpened();

		protected abstract void OnConstructionClosed();
	}
}
