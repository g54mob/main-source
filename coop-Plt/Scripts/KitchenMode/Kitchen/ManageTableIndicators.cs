using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class ManageTableIndicators : IndicatorManager
	{
		protected override ViewType ViewType => ViewType.TableIndicator;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(CTableSet), typeof(CTablePlace), typeof(CPosition));
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CPosition>(source, out CPosition comp))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			base.EntityManager.AddComponentData(entity, new CTableSetIndicator
			{
				Count = 0
			});
			base.EntityManager.AddComponentData(entity, new CPosition(comp));
			return entity;
		}

		protected override void UpdateIndicator(Entity indicator, Entity source)
		{
			if (!Require<CTableSetIndicator>(indicator, out CTableSetIndicator comp) || !Require<CTableSet>(source, out CTableSet comp2))
			{
				return;
			}
			comp.Count = comp2.ChairCount;
			if (Require<CTableSetModifier>(source, out CTableSetModifier comp3))
			{
				comp.Decoration = comp3.DecorationModifiers;
			}
			else
			{
				comp.Decoration = DecorationValues.Neutral;
			}
			if (RequireBuffer(source, out DynamicBuffer<CTableSetParts> comp4))
			{
				comp.InteractionTarget = false;
				for (int i = 0; i < comp4.Length; i++)
				{
					CTableSetParts cTableSetParts = comp4[i];
					comp.InteractionTarget |= HasComponent<CBeingLookedAt>(cTableSetParts);
					if (comp.InteractionTarget)
					{
						break;
					}
				}
			}
			base.EntityManager.SetComponentData(indicator, comp);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
