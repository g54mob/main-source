using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class RemoveIllness : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_IllnessDefinition[] _illnesses;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			CharacterEvents characterEvents = base.Owner.Level.CharacterEvents;
			SharedInstance_TH20TH20_IllnessDefinition[] illnesses = _illnesses;
			foreach (SharedInstance_TH20TH20_IllnessDefinition sharedInstance_TH20TH20_IllnessDefinition in illnesses)
			{
				characterEvents.OnRemoveIllness.InvokeSafe(sharedInstance_TH20TH20_IllnessDefinition.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
