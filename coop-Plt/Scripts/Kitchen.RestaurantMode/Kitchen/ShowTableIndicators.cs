using Unity.Entities;

namespace Kitchen
{
	public class ShowTableIndicators : NightSystem
	{
		private EntityQuery Indicators;

		protected override void Initialise()
		{
			base.Initialise();
			Indicators = GetEntityQuery(typeof(CTableSetIndicator), typeof(CHideView));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.RemoveComponent<CHideView>(Indicators);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
