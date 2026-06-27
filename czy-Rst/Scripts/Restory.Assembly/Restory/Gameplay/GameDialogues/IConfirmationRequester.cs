namespace Restory.Gameplay.GameDialogues
{
	public interface IConfirmationRequester
	{
		void OnConfirmationResponse(bool isConfirmed);
	}
}
