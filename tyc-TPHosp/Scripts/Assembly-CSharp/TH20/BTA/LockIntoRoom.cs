using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LockIntoRoom : CharacterAction
	{
		public override void OnStart()
		{
			base.OnStart();
			base.Character.AddComponent<LockCharacterInRoomComponent>();
		}

		public override void OnEnd()
		{
			base.Character.RemoveComponents<LockCharacterInRoomComponent>();
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Running;
		}
	}
}
