using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStartIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionStart : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public int _interactionControllerID;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("Interaction")]
		public SharedObjectInteractionRef _interaction;

		private int _interactionControllerID;

		public override void OnStart()
		{
			base.OnStart();
			_interactionControllerID = (_interaction.IsValid() ? base.Character.InteractionControllers.Add(new InteractionController(base.Character, _interaction.Get, autoEnd: false)) : (-1));
		}

		public override void OnEnd()
		{
			base.CharacterUnsafe?.InteractionControllers.Destroy(_interactionControllerID);
			_interactionControllerID = -1;
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			Character characterUnsafe = base.CharacterUnsafe;
			if (characterUnsafe == null || characterUnsafe.HasBeenDestroyed())
			{
				return TaskStatus.Failure;
			}
			Character.InteractionControllerCollection interactionControllers = characterUnsafe.InteractionControllers;
			if (!interactionControllers.Contains(_interactionControllerID))
			{
				return TaskStatus.Failure;
			}
			return interactionControllers.Get(_interactionControllerID).OnUpdate();
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_interactionControllerID = _interactionControllerID
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_interactionControllerID = saveState._interactionControllerID;
		}
	}
}
