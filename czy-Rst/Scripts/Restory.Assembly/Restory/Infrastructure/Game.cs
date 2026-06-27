using Restory.Infrastructure.StateMachine;
using Zenject;

namespace Restory.Infrastructure
{
	public class Game
	{
		public GlobalStateMachine StateMachine { get; }

		[Inject]
		public Game(GlobalStateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}
	}
}
