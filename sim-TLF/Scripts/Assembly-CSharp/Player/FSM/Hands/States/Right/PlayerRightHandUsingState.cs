using Items;
using JSAM;
using Player.Animations;
using UnityHFSM;
using Zenject;

namespace Player.FSM.Hands.States.Right
{
	internal class PlayerRightHandUsingState : StateBase
	{
		private IEquipable _equipable;

		protected ArmsAnimator _armsAnimator;

		[Inject]
		protected IPlayerEquipService _playerEquipService;

		public PlayerRightHandUsingState(ArmsAnimator armsAnimator, bool needsExitTime = false, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			name = "using";
			_armsAnimator = armsAnimator;
		}

		public override void OnEnter()
		{
			_equipable = _playerEquipService.GetEquipableAt(EquipSide.RIGHT_HAND);
			if (_equipable is IConsumeChangeProgressable)
			{
				AudioManager.PlaySound(PlayerLibrarySounds.DrinkingLoop);
				_armsAnimator.DrinkingLoop(value: true);
			}
		}

		public override void OnLogic()
		{
			if (_equipable != null && _equipable is IConsumeProgressable consumeProgressable)
			{
				if (consumeProgressable.CurrentProgress <= 0f)
				{
					AudioManager.StopSoundIfPlaying(PlayerLibrarySounds.DrinkingLoop);
					_armsAnimator.DrinkingLoop(value: false);
					_armsAnimator.StopDrinkingAnimation();
					_playerEquipService.TryUnequip(EquipSide.RIGHT_HAND);
				}
				consumeProgressable.ChangeConsumableProgress();
			}
		}

		public override void OnExit()
		{
			AudioManager.StopSoundIfPlaying(PlayerLibrarySounds.DrinkingLoop);
			_armsAnimator.DrinkingLoop(value: false);
		}
	}
}
