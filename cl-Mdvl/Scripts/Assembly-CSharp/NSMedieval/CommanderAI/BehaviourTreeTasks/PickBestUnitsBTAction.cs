using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Pick Unit")]
	[Description("Pick the best unit(s) to deal damage to a target")]
	public class PickBestUnitsBTAction : UnitsBTActionBaseThread
	{
		[RequiredField]
		public BBParameter<IDamageTakingAgent> target;

		public BBParameter<List<CommanderAIUnit>> saveAs;

		protected override string info => $"{saveAs} = Best unit(s) to attack {target}";

		protected override void OnStart()
		{
			BBParameter<List<CommanderAIUnit>> bBParameter = saveAs;
			if (bBParameter.value == null)
			{
				List<CommanderAIUnit> list = (bBParameter.value = new List<CommanderAIUnit>());
			}
			saveAs.value.Clear();
			if (base.UnitCount == 0 || target.value == null || target.value.HasDisposed)
			{
				EndAction(success: false);
			}
			else
			{
				base.OnStart();
			}
		}

		protected override bool OnThread()
		{
			int num = 3;
			int num2 = 3;
			if (target.value is BaseBuildingInstance baseBuildingInstance)
			{
				num = Math.Max(num, baseBuildingInstance.Size.x);
				num2 = Math.Max(num2, 2 * baseBuildingInstance.Size.x);
			}
			using PooledList<CommanderAIUnit> pooledList = ListPool<CommanderAIUnit>.GetJanitor();
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(unit.Humanoid, target.value))
				{
					pooledList.Add(unit);
				}
			}
			pooledList.Sort(delegate(CommanderAIUnit unit1, CommanderAIUnit unit2)
			{
				float value = CombatCalculator.CalculateDamage(unit1.Humanoid, target.value, isCritical: false) / CombatCalculator.CalculateAttackSpeed(unit1.Humanoid);
				return (CombatCalculator.CalculateDamage(unit2.Humanoid, target.value, isCritical: false) / CombatCalculator.CalculateAttackSpeed(unit2.Humanoid)).CompareTo(value);
			});
			int num3 = 0;
			int num4 = 0;
			foreach (CommanderAIUnit item in pooledList)
			{
				if (CombatUtils.GetAttackType(item.Humanoid) == AttackType.Melee)
				{
					if (num3 >= num)
					{
						continue;
					}
					num3++;
				}
				else
				{
					if (num4 >= num2)
					{
						continue;
					}
					num4++;
				}
				saveAs.value.Add(item);
			}
			return true;
		}

		protected override void OnDoneCallback(bool result)
		{
			if (saveAs.value.Count == 0)
			{
				EndAction(success: false);
			}
			else
			{
				EndAction();
			}
		}
	}
}
