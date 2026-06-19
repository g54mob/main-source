using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class RemoveQualification : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_QualificationDefinition[] _qualifications;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			CharacterEvents characterEvents = base.Owner.Level.CharacterEvents;
			SharedInstance_TH20TH20_QualificationDefinition[] qualifications = _qualifications;
			foreach (SharedInstance_TH20TH20_QualificationDefinition sharedInstance_TH20TH20_QualificationDefinition in qualifications)
			{
				characterEvents.OnRemoveQualification.InvokeSafe(sharedInstance_TH20TH20_QualificationDefinition.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
