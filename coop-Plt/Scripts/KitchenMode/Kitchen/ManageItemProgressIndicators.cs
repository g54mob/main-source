using Unity.Entities;

namespace Kitchen
{
	public class ManageItemProgressIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.ProgressView;

		protected override ViewMode ViewMode => ViewMode.World;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CItem));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (!Has<CItemUndergoingProcess>(candidate))
			{
				return false;
			}
			if (Require<CHeldBy>(candidate, out CHeldBy comp))
			{
				if (Has<CIsOnFire>(comp))
				{
					return false;
				}
				if (Has<CHideHeldProgressIndicator>(comp))
				{
					return false;
				}
				if (Has<CPlayer>(comp))
				{
					return false;
				}
			}
			if (Has<CHideProgressIndicator>(candidate))
			{
				return false;
			}
			if (Has<CStoredBy>(candidate))
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
			if (Require<CItemUndergoingProcess>(source, out CItemUndergoingProcess comp) && Require<CHeldBy>(source, out CHeldBy comp2) && Require<CPosition>((Entity)comp2, out CPosition comp3))
			{
				base.UpdateIndicator(indicator, source);
				base.EntityManager.SetComponentData(indicator, new CProgressIndicator
				{
					IsBad = comp.IsBad,
					Process = comp.Process,
					Progress = comp.Progress,
					IsUnknownLength = Has<CObfuscateProgressIndicator>(source),
					CurrentChange = comp.CurrentChange
				});
				base.EntityManager.SetComponentData(indicator, new CPosition(comp3));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
