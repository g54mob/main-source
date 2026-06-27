using System;
using SRDebugger.Services;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public class DebugInputSwitcher : IInitializable, IDisposable
	{
		private const string SRDebugger = "SRDebugger";

		private IPlayerInput playerInput;

		private bool debugVisible;

		private bool itemCheatsOpen;

		private string previousTag;

		[Inject]
		private void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		public void Initialize()
		{
			SRDebug.Instance.PanelVisibilityChanged += ChangeRule;
		}

		public void Dispose()
		{
			IDebugService instance = SRDebug.Instance;
			if (instance != null)
			{
				instance.PanelVisibilityChanged -= ChangeRule;
			}
		}

		private void ChangeRule(bool isVisible)
		{
			debugVisible = isVisible;
			ChangeRule();
		}

		private void ChangeRule()
		{
			if (debugVisible)
			{
				previousTag = playerInput.GetMapEnableTag();
				playerInput.SetMapEnableTag("SRDebugger");
			}
			else if (playerInput.GetMapEnableTag() == "SRDebugger")
			{
				playerInput.SetMapEnableTag(previousTag);
			}
		}
	}
}
