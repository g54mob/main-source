using UnityEngine;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public class GameplayRewiredContextSwitcher : IGameplayInputContextSwitcher
	{
		private readonly IPlayerInput playerInput;

		private string previousInputContext;

		[Inject]
		public GameplayRewiredContextSwitcher(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		public void SwitchInputContext(string inputContext)
		{
			previousInputContext = playerInput.GetMapEnableTag();
			playerInput.SetMapEnableTag(inputContext);
		}

		public void RestoreInputContext()
		{
			if (previousInputContext == null)
			{
				Debug.LogError("Failed to restore input context, previousInputContext is null");
			}
			else
			{
				playerInput.SetMapEnableTag(previousInputContext);
			}
		}
	}
}
