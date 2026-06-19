using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStopIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionEnd : CharacterAction
	{
		[Tooltip("Interaction")]
		public SharedObjectInteractionRef _interaction;

		protected ObjectInteraction Interaction
		{
			get
			{
				if (_interaction.IsValid())
				{
					return _interaction.Get;
				}
				if (base.Character.Interaction != null)
				{
					return base.Character.Interaction;
				}
				if (base.Character.ReservedInteraction != null)
				{
					return base.Character.ReservedInteraction;
				}
				return null;
			}
		}

		public override void OnStart()
		{
			base.OnStart();
			if (Interaction != null)
			{
				if (Interaction.IsInteracting(base.Character))
				{
					Interaction.RequestExit();
				}
				else if (Interaction.Interactor == base.Character)
				{
					Interaction.FreeInteraction(base.Character);
				}
			}
		}

		public override void OnEnd()
		{
			if (base.CharacterUnsafe != null && Interaction != null && Interaction.IsInteracting(base.Character))
			{
				Interaction.EndInteraction(base.Character);
			}
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			if (base.CharacterUnsafe == null)
			{
				return TaskStatus.Failure;
			}
			if (Interaction == null || !Interaction.IsInteracting(base.Character))
			{
				return TaskStatus.Success;
			}
			if (!Interaction.HasFinished())
			{
				return TaskStatus.Running;
			}
			Interaction.EndInteraction(base.Character);
			return TaskStatus.Success;
		}
	}
}
