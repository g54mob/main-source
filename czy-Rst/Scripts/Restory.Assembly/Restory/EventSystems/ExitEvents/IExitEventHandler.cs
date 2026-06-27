namespace Restory.EventSystems.ExitEvents
{
	public interface IExitEventHandler
	{
		string ID { get; }

		void ExecuteExit();

		void ConfirmExitExecution();
	}
}
