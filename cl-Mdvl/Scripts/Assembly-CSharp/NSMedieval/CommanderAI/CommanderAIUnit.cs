using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.State;

namespace NSMedieval.CommanderAI
{
	public class CommanderAIUnit
	{
		public readonly HumanoidInstance Humanoid;

		private readonly EnemyBehaviour enemyBehaviour;

		public OrderBase CurrentOrder
		{
			get
			{
				return enemyBehaviour.CurrentOrder;
			}
			set
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\CommanderAIUnit.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Order changed to ");
					messageBuilder.AppendFormatted(value?.GetType().Name);
					messageBuilder.AppendLiteral(" for ");
					messageBuilder.AppendFormatted(Humanoid);
				}
				Log.Trace(messageBuilder);
				if (enemyBehaviour.CurrentOrder == null || !enemyBehaviour.CurrentOrder.Equals(value))
				{
					enemyBehaviour.CurrentOrder = value;
				}
			}
		}

		public CommanderAIUnit(HumanoidInstance humanoid)
		{
			if (humanoid == null)
			{
				throw new Exception("Can't create CommanderAIUnit: Humanoid cannot be null");
			}
			if (!humanoid.IsEnemy())
			{
				throw new Exception("Can't create CommanderAIUnit: Humanoid cannot be null");
			}
			Humanoid = humanoid;
			enemyBehaviour = Humanoid.EnemyBehaviour;
		}

		public T GetOrder<T>() where T : OrderBase
		{
			return CurrentOrder as T;
		}

		public override string ToString()
		{
			return Humanoid?.ToString() ?? "NULL Humanoid";
		}
	}
}
