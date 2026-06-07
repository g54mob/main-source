using Zenject;

namespace VampireSurvivors
{
	public class AppStateMachineState : StateMachineState
	{
		protected AppStateMachine appStateMachine;

		protected bool UsesBackButton;

		protected bool AutoSelectBackButton;

		public LobbiesManager LobbiesManager;

		[Inject]
		private void Construct(LobbiesManager lobbiesManager)
		{
		}

		public override void Init(StateMachine stateMachine)
		{
		}

		public override void OnEnter()
		{
		}

		private void ShowBackButton()
		{
		}

		public override void OnExit()
		{
		}

		private void HideBackButton()
		{
		}

		protected virtual void GoBack()
		{
		}
	}
}
