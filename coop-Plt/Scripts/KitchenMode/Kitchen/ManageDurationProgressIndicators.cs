using Unity.Entities;

namespace Kitchen
{
	public class ManageDurationProgressIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.ProgressView;

		protected override ViewMode ViewMode => ViewMode.World;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CAppliance));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Require<CDisplayDuration>(candidate, out CDisplayDuration comp))
			{
				return false;
			}
			if (!Require<CTakesDuration>(candidate, out CTakesDuration comp2))
			{
				return false;
			}
			if (!comp2.Active)
			{
				return false;
			}
			if (!comp.ShowWhenEmpty && comp2.Remaining >= comp2.Total)
			{
				return false;
			}
			if (!Require<CAppliance>(candidate, out CAppliance _))
			{
				return false;
			}
			if (Has<CHasFireSubEntity>(candidate))
			{
				return false;
			}
			if (Has<CHasBrokenSubEntity>(candidate))
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponent<CProgressIndicator>(entity);
			base.EntityManager.AddComponent<CPosition>(entity);
			UpdateIndicator(entity, source);
			return entity;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			if (Require<CPosition>(source, out CPosition comp) && Require<CTakesDuration>(source, out CTakesDuration comp2) && Require<CDisplayDuration>(source, out CDisplayDuration comp3))
			{
				base.UpdateIndicator(indicator, source);
				float num = comp2.Remaining / comp2.Total;
				float progress = (comp2.IsInverse ? num : (1f - num));
				base.EntityManager.SetComponentData(indicator, new CProgressIndicator
				{
					IsBad = comp3.IsBad,
					Progress = progress,
					Process = comp3.Process,
					CurrentChange = comp2.CurrentChange
				});
				base.EntityManager.SetComponentData(indicator, new CPosition(comp));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
