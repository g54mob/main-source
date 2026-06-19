using System;
using Services.Missions;
using Services.Save.Player;
using UI.Inventory;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.Parts
{
	public class PartObjectTightenedState : StateBase<StateIdentifier>
	{
		private PartObject _part;

		private AssembleObjectParent _parent;

		private IInventoryService _inventoryService;

		private IInventoryUIService _inventoryUIService;

		[Inject]
		private MissionEventBus _missionEventBus;

		[Inject]
		private PlayerSaveService _playerSaveService;

		public PartObjectTightenedState(PartObject part, AssembleObjectParent parent, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_parent = parent;
			_part = part;
		}

		public override void OnEnter()
		{
			_parent.TightenedItems++;
			_part.StateMachine.Tightened = true;
			_parent?.StateMachine?.SetCanCheckAfterTight(value: true);
			if (!_playerSaveService.PlayerData.GameData.TutorialDone && _part.name.Contains("Table", StringComparison.OrdinalIgnoreCase))
			{
				_missionEventBus.Emit("interact", "tightenTableTop");
			}
		}

		public override void OnExit()
		{
			_parent.TightenedItems--;
			_part.StateMachine.Tightened = false;
			_parent?.StateMachine?.SetCanCheckAfterTight(value: true);
			if (_parent.TightenedItems == 0)
			{
				_parent.StateMachine.Placed = false;
			}
		}
	}
}
