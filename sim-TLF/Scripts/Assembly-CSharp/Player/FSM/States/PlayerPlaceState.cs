using AssembleSystem;
using JSAM;
using Loxodon.Framework.Contexts;
using Services.Missions;
using UI.HUD;
using UnityEngine;
using UnityHFSM;
using Zenject;

namespace Player.FSM.States
{
	public class PlayerPlaceState : StateBase<StateIdentifier>
	{
		private const string PlaceHintText = "To Place";

		private PlayerBehaviourStateMachine playerFSM;

		private RaycasterInfo playerRaycaster;

		private IPlayerInputService _playerInputService;

		private InfoCursorsViewModel _infoCursorsViewModel;

		[Inject]
		private readonly MissionEventBus _missionEventBus;

		public PlayerPlaceState(IPlayerInputService inputService, PlayerBehaviourStateMachine fsm, RaycasterInfo playerRaycaster, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			playerFSM = fsm;
			this.playerRaycaster = playerRaycaster;
			_playerInputService = inputService;
			_infoCursorsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		public override void OnEnter()
		{
			playerFSM.CancelPlacingRequested = false;
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePlacingStart);
			_playerInputService.OnRotate += RotateMovingPoint;
			_infoCursorsViewModel.EnableUseHintSeperately(value: true, "To Place");
		}

		public override void OnLogic()
		{
			playerFSM.ParentBeingPlaced.TestMovingPoint.position = playerRaycaster.Hit.point;
			if (!_infoCursorsViewModel.UseHintSeparatelyEnabled || _infoCursorsViewModel.UseHintSeparatelyText != "To Place")
			{
				_infoCursorsViewModel.EnableUseHintSeperately(value: true, "To Place");
			}
		}

		public override void OnExit()
		{
			_playerInputService.OnRotate -= RotateMovingPoint;
			_infoCursorsViewModel.EnableUseHintSeperately(value: false);
			AssembleObjectParent parentBeingPlaced = playerFSM.ParentBeingPlaced;
			playerFSM.ParentBeingPlaced = null;
			if (playerFSM.CancelPlacingRequested)
			{
				playerFSM.CancelPlacingRequested = false;
				if (parentBeingPlaced != null)
				{
					parentBeingPlaced.StateMachine.ReadyToBuild = false;
				}
				return;
			}
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePlacingComplete);
			AudioManager.PlaySound(InteractionLibrarySounds.AssemblePlacingCompleteAdd);
			if (parentBeingPlaced != null)
			{
				parentBeingPlaced.StateMachine.Placed = true;
			}
			_missionEventBus.Emit("interact", "buildTable");
		}

		private void RotateMovingPoint(float value)
		{
			playerFSM.ParentBeingPlaced.TestMovingPoint.Rotate(Vector3.up, value * 5f);
		}
	}
}
