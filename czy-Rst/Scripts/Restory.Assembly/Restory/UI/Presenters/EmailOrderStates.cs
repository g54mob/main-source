namespace Restory.UI.Presenters
{
	public enum EmailOrderStates
	{
		None = 0,
		CanBeTaken = 10,
		TakenAndAwaitingDelivery = 20,
		TakenAndInWork = 30,
		Completed = 40
	}
}
