using Unity.Entities;

namespace Kitchen
{
	public class ClearItemProcessesAtNight : StartOfNightSystem
	{
		private EntityQuery UndergoingProcesses;

		protected override void Initialise()
		{
			base.Initialise();
			UndergoingProcesses = GetEntityQuery(typeof(CItemUndergoingProcess));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CItemUndergoingProcess>(UndergoingProcesses);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
