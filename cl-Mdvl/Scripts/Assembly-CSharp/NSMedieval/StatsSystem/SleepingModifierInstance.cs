using System;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class SleepingModifierInstance : ModifierInstance
	{
		private AttributeInstance sleepAttribute;

		private StatInstance sleepStatInstance;

		private bool wakeUpEventFired;

		public SleepingModifierInstance()
			: base(ModifierType.Sleeping)
		{
		}

		public override bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return stack.Instances.Count == 1;
		}

		public override void Init(StatsInstance instance)
		{
			base.Init(instance);
			sleepAttribute = instance.GetAttributeInstance(AttributeType.SleepNeed);
			base.AffectedAttributes.Add(sleepAttribute);
			sleepStatInstance = instance.GetStat(StatType.Sleep);
			MonoSingleton<LifeController>.Instance.WakeUpEvent += OnWakeUp;
		}

		public override void Apply()
		{
			sleepAttribute.SetMultiplier(sleepAttribute.Multiplier * -1f);
		}

		protected override void OnExpired()
		{
			if (!wakeUpEventFired && sleepStatInstance != null && MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.WakeUp(sleepStatInstance.Owner);
			}
			if (base.Owner == null || base.Owner.HasDisposed || !(base.Owner.Owner is HumanoidInstance humanoidInstance) || humanoidInstance.CurrentHumanType?.SleepEffectors == null)
			{
				return;
			}
			string value = humanoidInstance.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("sleeping"))?.Value;
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			if (MonoSingleton<TaskController>.IsInstantiated())
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.Owner?.EndEffector(value);
				});
			}
			else
			{
				base.Owner.EndEffector(value);
			}
		}

		private void OnWakeUp(StatsInstance stats)
		{
			if (stats.Equals(base.Owner))
			{
				if (MonoSingleton<LifeController>.IsInstantiated())
				{
					MonoSingleton<LifeController>.Instance.WakeUpEvent -= OnWakeUp;
				}
				wakeUpEventFired = true;
				EndNow();
			}
		}
	}
}
