using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
	[FilterModes(AllowedModes = GameSetupMode.All)]
	public class PerformLateUpdate : GenericSystemBase
	{
		protected RouterManager RouterManager;

		protected override void OnUpdate()
		{
			if (RouterManager == null)
			{
				RouterManager = base.World.GetExistingSystem<RouterManager>();
			}
			RouterManager.OnLateUpdate();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
