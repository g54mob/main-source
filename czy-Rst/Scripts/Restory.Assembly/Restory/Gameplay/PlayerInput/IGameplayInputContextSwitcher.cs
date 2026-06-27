namespace Restory.Gameplay.PlayerInput
{
	public interface IGameplayInputContextSwitcher
	{
		void SwitchInputContext(string inputContext);

		void RestoreInputContext();
	}
}
