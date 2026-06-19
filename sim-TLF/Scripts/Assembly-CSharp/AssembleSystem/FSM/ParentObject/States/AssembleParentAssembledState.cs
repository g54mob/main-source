using JSAM;
using Services.Missions;
using UnityEngine.Events;
using UnityHFSM;
using Zenject;

namespace AssembleSystem.FSM.ParentObject.States
{
	public class AssembleParentAssembledState : StateBase<StateIdentifier>
	{
		protected UnityEvent _onEnter;

		private readonly AssembleObjectParent _parent;

		[Inject]
		protected readonly MissionEventBus _missionEventBus;

		public AssembleParentAssembledState(AssembleObjectParent parent, UnityEvent onEnter, bool needsExitTime, bool isGhostState = false)
			: base(needsExitTime, isGhostState)
		{
			_onEnter = onEnter;
			_parent = parent;
		}

		public override void OnEnter()
		{
			AudioManager.PlaySound(InteractionLibrarySounds.AssembleComplete);
			AudioManager.PlaySound(InteractionLibrarySounds.AssembleCompleteAdd);
			if (_parent.ItemConfig.name == "Computer_config")
			{
				_missionEventBus.Emit("interact", "buildComputer");
			}
			_parent.StateMachine.ReadyToBuild = true;
			_parent.StateMachine.Placed = true;
			_onEnter?.Invoke();
		}
	}
}
