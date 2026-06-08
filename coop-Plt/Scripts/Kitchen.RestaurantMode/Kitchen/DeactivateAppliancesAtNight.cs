using Unity.Entities;

namespace Kitchen
{
	public class DeactivateAppliancesAtNight : StartOfNightSystem
	{
		private EntityQuery DeactivateAppliances;

		protected override void Initialise()
		{
			base.Initialise();
			DeactivateAppliances = GetEntityQuery(typeof(CDeactivateAtNight));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CIsInactive>(DeactivateAppliances);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
