using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Goap.Goals;
using NSMedieval.State;

namespace NSMedieval.CommanderAI.Orders
{
	public class AttackOrder : OrderBase
	{
		public IDamageTakingAgent Target;

		public SiegeWeaponComponentInstance SiegeWeapon;

		public bool IsSiegePathObstacle;

		public bool HasSuccessfullyHotSwapped;

		public AttackOrder(IDamageTakingAgent target, bool isSiegePathObstacle = false)
		{
			Target = target;
			IsSiegePathObstacle = isSiegePathObstacle;
		}

		public AttackOrder(IDamageTakingAgent target, SiegeWeaponComponentInstance siegeWeapon)
		{
			Target = target;
			SiegeWeapon = siegeWeapon;
		}

		public override void OnAssigned(EnemyBehaviour unit)
		{
			Agent goapAgent = unit.Humanoid.GoapAgent;
			Goal currentGoal = goapAgent.GetCurrentGoal();
			if (!(goapAgent.CurrentGoalName != "AttackGoal") && currentGoal is AttackGoal attackGoal)
			{
				HasSuccessfullyHotSwapped = attackGoal.TryHotSwapTarget(Target);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(59, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\Orders\\AttackOrder.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to hotswap target, success: ");
					messageBuilder.AppendFormatted(HasSuccessfullyHotSwapped);
					messageBuilder.AppendLiteral(", agent '");
					messageBuilder.AppendFormatted(unit.Humanoid.GetFullName());
					messageBuilder.AppendLiteral("', new target '");
					messageBuilder.AppendFormatted(Target);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} ({1}: {2}, siegeWeapon: '{3}')", "AttackOrder", "Target", Target, SiegeWeapon);
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is AttackOrder attackOrder))
			{
				return false;
			}
			if (Target == attackOrder.Target && SiegeWeapon == attackOrder.SiegeWeapon)
			{
				return IsSiegePathObstacle == attackOrder.IsSiegePathObstacle;
			}
			return false;
		}
	}
}
