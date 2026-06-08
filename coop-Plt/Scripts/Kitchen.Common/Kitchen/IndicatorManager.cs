using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public abstract class IndicatorManager : GenericSystemBase
	{
		private EntityQuery Candidates;

		protected abstract ViewType ViewType { get; }

		protected virtual ViewMode ViewMode => ViewMode.WorldToScreen;

		protected override void Initialise()
		{
			base.Initialise();
			Candidates = GetCandidateQuery();
			RequireForUpdate(GetCandidateQuery());
		}

		protected abstract EntityQuery GetCandidateQuery();

		protected override void OnUpdate()
		{
			foreach (Entity item in Candidates.ToEntityArray(Allocator.Temp))
			{
				if (Require<CHasIndicator>(item, out CHasIndicator comp))
				{
					if (comp.IndicatorType == ViewType)
					{
						if (ShouldLoseIndicator(item))
						{
							DestroyIndicator(comp.Indicator, item);
							base.EntityManager.RemoveComponent<CHasIndicator>(item);
						}
						else
						{
							UpdateIndicator(comp.Indicator, item);
						}
					}
				}
				else if (ShouldHaveIndicator(item))
				{
					StatTracker.Main.Report(StatType.IndicatorCreated, base.Time.RealTotalTime, 1);
					Entity entity = CreateIndicator(item);
					if (entity != default(Entity))
					{
						base.EntityManager.AddComponentData(item, new CHasIndicator
						{
							Indicator = entity,
							IndicatorType = ViewType
						});
					}
					else
					{
						Debug.LogWarning($"Failed to create indicator for {item} ({this})");
					}
				}
			}
		}

		protected abstract bool ShouldHaveIndicator(Entity candidate);

		protected virtual bool ShouldLoseIndicator(Entity candidate)
		{
			return !ShouldHaveIndicator(candidate);
		}

		protected virtual Entity CreateIndicator(Entity source)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CIndicator));
			base.EntityManager.AddComponentData(entity, new CIndicator
			{
				Source = source
			});
			base.EntityManager.AddComponentData(entity, new CRequiresView
			{
				ViewMode = ViewMode,
				Type = ViewType
			});
			return entity;
		}

		protected virtual void DestroyIndicator(Entity indicator, Entity source)
		{
			base.EntityManager.DestroyEntity(indicator);
		}

		protected virtual void UpdateIndicator(Entity indicator, Entity source)
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
