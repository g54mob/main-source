using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public class ForceWorkHourEffect : EffectorBase
	{
		private HourType type;

		public ForceWorkHourEffect(StatEffector parent)
			: base(EffectorType.ForceWorkHour, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			if (!data.ContainsKey("HourType"))
			{
				Log.Error("Key 'type' not found!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Model\\Effectors\\ForceWorkHourEffect.cs");
			}
			else
			{
				type = (HourType)int.Parse(data["HourType"], CultureInfo.InvariantCulture);
			}
		}

		public override void Start(StatsInstance instance)
		{
			if (!(instance.Owner is HumanoidInstance { ActiveBehaviour: var activeBehaviour } humanoidInstance))
			{
				return;
			}
			if (!(activeBehaviour is WorkerBehaviour))
			{
				if (activeBehaviour is CaptiveLabourerBehaviour)
				{
					humanoidInstance.CaptiveLabourerBehaviour.ForceWorkHour(type);
				}
				return;
			}
			if (humanoidInstance.WorkerBehaviour.IsDrafting && type == HourType.PsyhoticCrazy)
			{
				MonoSingleton<DraftController>.Instance.OnEndDraft(humanoidInstance);
			}
			humanoidInstance.WorkerBehaviour.ForceWorkHour(type);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			if (!(instance.Owner is HumanoidInstance { HasDisposed: false, ActiveBehaviour: var activeBehaviour } humanoidInstance))
			{
				return;
			}
			if (!(activeBehaviour is WorkerBehaviour))
			{
				if (activeBehaviour is CaptiveLabourerBehaviour)
				{
					humanoidInstance.CaptiveLabourerBehaviour.ForceWorkHour(HourType.None);
				}
			}
			else
			{
				humanoidInstance.WorkerBehaviour.ForceWorkHour(HourType.None);
			}
		}
	}
}
