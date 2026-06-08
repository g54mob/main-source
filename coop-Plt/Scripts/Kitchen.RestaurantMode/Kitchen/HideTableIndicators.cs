using Unity.Entities;

namespace Kitchen
{
	public class HideTableIndicators : DaySystem
	{
		private EntityQuery Indicators;

		protected override void Initialise()
		{
			base.Initialise();
			Indicators = GetEntityQuery(new QueryHelper().All(typeof(CTableSetIndicator)).None(typeof(CHideView)));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CHideView>(Indicators);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
