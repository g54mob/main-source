using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionFindIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FindInteraction : FindInteractionBase
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

		[Tooltip("Interaction room item")]
		public SharedItemRef _interactionItem;

		[Tooltip("Start the interaction")]
		public bool _startImmediately;

		private int _interactionControllerID;

		public override void OnStart()
		{
			base.OnStart();
			ObjectInteraction objectInteraction = FindInteraction(_interactionName);
			_interactionControllerID = -1;
			_interaction.Value = new ObjectInteractionRef(objectInteraction);
			if (objectInteraction != null)
			{
				if (_interactionItem.IsShared)
				{
					_interactionItem.Value = new ItemRef(objectInteraction.ParentRoomItem);
				}
				if (_startImmediately)
				{
					_interactionControllerID = base.Character.InteractionControllers.Add(new InteractionController(base.Character, objectInteraction, autoEnd: false));
				}
			}
		}

		public override void OnEnd()
		{
			Character characterUnsafe = base.CharacterUnsafe;
			if (characterUnsafe != null)
			{
				characterUnsafe.InteractionControllers.Destroy(_interactionControllerID);
				_interactionControllerID = -1;
			}
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			Character characterUnsafe = base.CharacterUnsafe;
			if (characterUnsafe == null)
			{
				return TaskStatus.Failure;
			}
			Character.InteractionControllerCollection interactionControllers = characterUnsafe.InteractionControllers;
			if (!_interaction.IsValid() && interactionControllers.Contains(_interactionControllerID))
			{
				InteractionController interactionController = interactionControllers.Get(_interactionControllerID);
				if (interactionController != null)
				{
					_interaction.Value = new ObjectInteractionRef(interactionController.Interaction);
				}
			}
			if (!_interaction.IsValid())
			{
				return TaskStatus.Failure;
			}
			if (!_startImmediately)
			{
				return TaskStatus.Success;
			}
			if (!interactionControllers.Contains(_interactionControllerID))
			{
				return TaskStatus.Failure;
			}
			InteractionController interactionController2 = interactionControllers.Get(_interactionControllerID);
			if (!interactionController2.InteractionStarted && !ValidDelegate(_interaction.Get))
			{
				return TaskStatus.Failure;
			}
			return interactionController2.OnUpdate();
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
