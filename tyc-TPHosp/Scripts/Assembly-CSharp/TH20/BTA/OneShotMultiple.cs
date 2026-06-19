using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStartIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OneShotMultiple : CharacterAction
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

		[Tooltip("Room to search")]
		public SharedRoomRef _room;

		[Tooltip("Room item to search")]
		public SharedItemRef _roomItem;

		[Tooltip("Interaction to search for")]
		public SharedString _interactionName;

		public SharedInt _numInteractions;

		public bool _uniqueInteractions;

		[Tooltip("Evaluate attractiveness at interaction location")]
		public bool _evaluateAttractiveness;

		[Tooltip("Filter any interactions that aren't available")]
		public InteractionFilterAvailable _filterAvailable = new InteractionFilterAvailable();

		[Tooltip("Filter any interactions that're outside the radius")]
		public InteractionFilterWithinRadius _filterWithinRadius = new InteractionFilterWithinRadius();

		private int _interactionControllerID;

		private IEnumerator<ObjectInteraction> _nextInteractionEnumerator;

		private List<ObjectInteraction> _interactionList;

		public override void OnStart()
		{
			base.OnStart();
			_interactionControllerID = -1;
			_interactionList = new List<ObjectInteraction>();
			for (int i = 0; i < _numInteractions.Value; i++)
			{
				ObjectInteraction objectInteraction = ((!_roomItem.IsValid()) ? InteractionAlgorithms.GetClosestInteractionByName(_interactionName.Value, _room.Get.FloorPlan, base.Character.Position, _evaluateAttractiveness, ValidDelegate) : InteractionAlgorithms.GetClosestInteractionByName(_interactionName.Value, _roomItem.Get, base.Character.Position, _evaluateAttractiveness, ValidDelegate));
				if (objectInteraction == null)
				{
					break;
				}
				_interactionList.Add(objectInteraction);
			}
			_nextInteractionEnumerator = _interactionList.GetEnumerator();
		}

		public override void OnEnd()
		{
			base.OnEnd();
			base.Character.InteractionControllers.Destroy(_interactionControllerID);
			_interactionControllerID = -1;
		}

		private bool ValidDelegate(ObjectInteraction interaction)
		{
			if (interaction.Valid && (!_uniqueInteractions || IsInteractionRoomItemUnique(interaction.ParentRoomItem)) && _filterAvailable.IsValid(interaction, base.Character) && _filterWithinRadius.IsValid(interaction, base.Character))
			{
				return true;
			}
			return false;
		}

		private bool IsInteractionRoomItemUnique(RoomItem roomItem)
		{
			for (int i = 0; i < _interactionList.Count; i++)
			{
				if (roomItem == _interactionList[i].ParentRoomItem)
				{
					return false;
				}
			}
			return true;
		}

		public override TaskStatus OnUpdate()
		{
			if (base.Character.InteractionControllers.Contains(_interactionControllerID))
			{
				TaskStatus taskStatus = base.Character.InteractionControllers.Get(_interactionControllerID).OnUpdate();
				if (taskStatus != TaskStatus.Success)
				{
					return taskStatus;
				}
				base.Character.InteractionControllers.Destroy(_interactionControllerID);
			}
			if (_nextInteractionEnumerator == null || !_nextInteractionEnumerator.MoveNext())
			{
				return TaskStatus.Success;
			}
			_interactionControllerID = base.Character.InteractionControllers.Add(new InteractionController(base.Character, _nextInteractionEnumerator.Current, autoEnd: true));
			return TaskStatus.Running;
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
