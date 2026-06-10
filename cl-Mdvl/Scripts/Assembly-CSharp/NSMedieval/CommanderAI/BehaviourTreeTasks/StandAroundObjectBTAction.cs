using System.Linq;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Instruct units to stand around a given object. Runs indefinitely.")]
	public class StandAroundObjectBTAction : UnitsBTActionBase
	{
		public BBParameter<IGoapTargetable> target;

		[MinValue(0f)]
		public float desiredSpacing;

		private StandAroundObjectInstance instance;

		protected override string info => $"{base.info} stand around {target}";

		protected override void OnStart()
		{
			if (target.value == null || target.value.HasDisposed || base.Units == null)
			{
				EndAction(success: false);
			}
			else
			{
				instance = new StandAroundObjectInstance(base.Units.ToList(), target.value, desiredSpacing, base.agent.Map);
			}
		}

		protected override void OnTick()
		{
			if (instance == null)
			{
				EndAction(success: false);
			}
			else if (!instance.Tick())
			{
				EndAction(success: false);
			}
		}

		protected override void OnStop(bool interrupted)
		{
			base.OnStop(interrupted);
			instance?.Dispose();
		}
	}
}
