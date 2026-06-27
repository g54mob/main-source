using Restory.AssetManagement.References;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.Bootstrap
{
	public class GameBootstrapper : MonoBehaviour
	{
		public Game GameInstance { get; private set; }

		[Inject]
		private void Configure(Game game)
		{
			GameInstance = game;
		}

		public void BootPreset(GameScenesAssetRef preset)
		{
			GameInstance.StateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(preset);
		}
	}
}
