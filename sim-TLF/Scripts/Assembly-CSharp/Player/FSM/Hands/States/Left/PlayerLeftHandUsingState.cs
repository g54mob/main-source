using Items;
using JSAM;
using Player.Animations;
using UnityHFSM;
using Zenject;

namespace Player.FSM.Hands.States.Left
{
	public class PlayerLeftHandUsingState : StateBase<string>
	{
		private IEquipable _equipable;

		protected ArmsAnimator _armsAnimator;

		[Inject]
		protected IPlayerEquipService _playerEquipService;

		public PlayerLeftHandUsingState(ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "using";
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_armsAnimator.SmokinLoop(value: true);
			AudioManager.PlaySound(PlayerLibrarySounds.Smoking);
			_equipable = _playerEquipService.GetEquipableAt(EquipSide.LEFT_HAND);
		}

		public override void OnLogic()
		{
			if (_equipable != null && _equipable is IConsumeDecremental consumeDecremental)
			{
				if (consumeDecremental.CurrentProgress <= 0f)
				{
					AudioManager.StopSoundIfPlaying(PlayerLibrarySounds.Smoking);
					_armsAnimator.SmokinLoop(value: false);
					_armsAnimator.StopSmokingAnimation();
					_playerEquipService.TryUnequip(EquipSide.LEFT_HAND);
				}
				consumeDecremental.ChangeConsumableProgress();
			}
		}

		public override void OnExit()
		{
			AudioManager.StopSoundIfPlaying(PlayerLibrarySounds.Smoking);
			_armsAnimator.SmokinLoop(value: false);
		}
	}
}
