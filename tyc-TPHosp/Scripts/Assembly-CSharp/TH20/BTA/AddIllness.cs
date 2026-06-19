using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/UnlockIcon.png")]
	public class AddIllness : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_IllnessDefinition[] _newIllnesses;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			CharacterEvents characterEvents = base.Owner.Level.CharacterEvents;
			SharedInstance_TH20TH20_IllnessDefinition[] newIllnesses = _newIllnesses;
			foreach (SharedInstance_TH20TH20_IllnessDefinition sharedInstance_TH20TH20_IllnessDefinition in newIllnesses)
			{
				characterEvents.OnAddIllness.InvokeSafe(sharedInstance_TH20TH20_IllnessDefinition.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
