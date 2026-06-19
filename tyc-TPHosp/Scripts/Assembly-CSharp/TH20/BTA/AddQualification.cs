using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/UnlockIcon.png")]
	public class AddQualification : ExpiringLevelAction
	{
		[UsedImplicitly]
		public WeightedQualification[] _qualifications;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			CharacterEvents characterEvents = base.Owner.Level.CharacterEvents;
			WeightedQualification[] qualifications = _qualifications;
			foreach (WeightedQualification weightedQualification in qualifications)
			{
				characterEvents.OnAddQualification.InvokeSafe(weightedQualification.Definition.Instance, weightedQualification.Weight);
			}
			return TaskStatus.Success;
		}
	}
}
