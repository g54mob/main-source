using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Goap;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Instruct units to stand around a given list of objects. Runs indefinitely.")]
	public class StandAroundObjectListBTAction : UnitsBTActionBase
	{
		public BBParameter<List<IGoapTargetable>> targets;

		[MinValue(0f)]
		public float desiredSpacing;

		private List<StandAroundObjectInstance> instances;

		protected override string info => $"{base.info} stand around {targets}";

		protected override void OnStart()
		{
			if (instances == null)
			{
				instances = new List<StandAroundObjectInstance>();
			}
			instances.Clear();
			if (targets.value == null || targets.value.Count == 0 || base.Units == null)
			{
				EndAction(success: false);
				return;
			}
			using PooledList<CommanderAIUnit> pooledList = ListPool<CommanderAIUnit>.GetJanitor(base.Units);
			int count = targets.value.Count;
			int num = base.UnitCount / count;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\StandAroundObjectListBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("TargetCount ");
				messageBuilder.AppendFormatted(count);
				messageBuilder.AppendLiteral(", unitsPerTarget ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Trace(messageBuilder);
			for (int i = 0; i < count; i++)
			{
				if (pooledList.Count == 0)
				{
					break;
				}
				IGoapTargetable target = targets.value[i];
				if (target.HasDisposed)
				{
					continue;
				}
				pooledList.Sort((CommanderAIUnit unit1, CommanderAIUnit unit2) => unit1.Humanoid.DistanceSquared(target).CompareTo(unit2.Humanoid.DistanceSquared(target)));
				List<CommanderAIUnit> list = new List<CommanderAIUnit>();
				for (int num2 = 0; num2 < num; num2++)
				{
					if (pooledList.Count == 0)
					{
						break;
					}
					CommanderAIUnit item = pooledList.PopFront();
					list.Add(item);
				}
				if (i == count - 1)
				{
					list.AddRange(pooledList);
				}
				instances.Add(new StandAroundObjectInstance(list, target, desiredSpacing, base.agent.Map));
				messageBuilder = new FVLogTraceInterpolationHandler(45, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\StandAroundObjectListBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("StandAround instance created, ");
					messageBuilder.AppendFormatted(list.Count);
					messageBuilder.AppendLiteral(" units, target ");
					messageBuilder.AppendFormatted(target);
				}
				Log.Trace(messageBuilder);
			}
		}

		protected override void OnTick()
		{
			if (instances == null || instances.Count == 0)
			{
				EndAction(success: false);
				return;
			}
			foreach (StandAroundObjectInstance instance in instances)
			{
				if (!instance.Tick())
				{
					EndAction(success: false);
					break;
				}
			}
		}

		protected override void OnStop(bool interrupted)
		{
			base.OnStop(interrupted);
			if (instances == null)
			{
				return;
			}
			foreach (StandAroundObjectInstance instance in instances)
			{
				instance?.Dispose();
			}
			instances.Clear();
		}
	}
}
