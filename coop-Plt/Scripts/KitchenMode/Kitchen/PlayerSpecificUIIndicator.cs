using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public abstract class PlayerSpecificUIIndicator<TAppProperty, TUIInfo> : IndicatorManager where TAppProperty : struct, IComponentData, IPlayerSpecificUISource where TUIInfo : struct, IComponentData, IPlayerSpecificUI
	{
		protected override ViewType ViewType => ViewType.CostumeChangeInfo;

		protected override EntityQuery GetCandidateQuery()
		{
			return GetEntityQuery(typeof(TAppProperty), typeof(CPosition));
		}

		protected virtual bool CheckIfIndicatorShouldBeCreated(Entity trigger)
		{
			return true;
		}

		protected override bool ShouldHaveIndicator(Entity candidate)
		{
			if (Require<CHasIndicator>(candidate, out CHasIndicator comp))
			{
				if (Require<CTriggerPlayerSpecificUI>(candidate, out CTriggerPlayerSpecificUI comp2) && comp2.IsTriggered)
				{
					Set(candidate, comp2.Reset());
				}
				if (!Require<TUIInfo>(comp.Indicator, out TUIInfo comp3))
				{
					return false;
				}
				if (!Has<CPlayer>(comp3.PlayerEntity))
				{
					return false;
				}
				return !ShouldDismiss(comp3);
			}
			if (!Has<CPosition>(candidate))
			{
				return false;
			}
			if (!Require<CTriggerPlayerSpecificUI>(candidate, out CTriggerPlayerSpecificUI comp4))
			{
				return false;
			}
			if (!Require<CPlayer>(comp4.TriggerEntity, out CPlayer _))
			{
				return false;
			}
			if (!CheckIfIndicatorShouldBeCreated(comp4.TriggerEntity))
			{
				Set(candidate, comp4.Reset());
				return false;
			}
			if (!comp4.IsTriggered)
			{
				return false;
			}
			return true;
		}

		protected override Entity CreateIndicator(Entity source)
		{
			if (!Require<CPosition>(source, out CPosition comp))
			{
				return default(Entity);
			}
			if (!Require<TAppProperty>(source, out TAppProperty comp2))
			{
				return default(Entity);
			}
			if (!Require<CTriggerPlayerSpecificUI>(source, out CTriggerPlayerSpecificUI comp3))
			{
				return default(Entity);
			}
			if (!Require<CPlayer>(comp3.TriggerEntity, out CPlayer comp4))
			{
				return default(Entity);
			}
			Entity entity = base.CreateIndicator(source);
			Set(source, comp3.Reset());
			base.EntityManager.AddComponentData(entity, new CPosition(comp + comp2.DrawLocation));
			base.EntityManager.AddComponentData(entity, GetInfo(source, comp2, comp3, comp4));
			return entity;
		}

		protected virtual bool ShouldDismiss(TUIInfo info)
		{
			return info.IsComplete;
		}

		protected abstract TUIInfo GetInfo(Entity source, TAppProperty selector, CTriggerPlayerSpecificUI trigger, CPlayer player);

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
