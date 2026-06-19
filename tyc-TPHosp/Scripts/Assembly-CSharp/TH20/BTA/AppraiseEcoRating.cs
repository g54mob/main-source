using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/VIP")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InspectIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AppraiseEcoRating : CharacterAction
	{
		public override TaskStatus OnUpdate()
		{
			VIPComponent component = base.Character.GetComponent<VIPComponent>();
			if (component == null)
			{
				return TaskStatus.Failure;
			}
			component.AppraiseEcoRating();
			return TaskStatus.Success;
		}
	}
}
