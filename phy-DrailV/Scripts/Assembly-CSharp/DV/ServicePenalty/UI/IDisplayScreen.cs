namespace DV.ServicePenalty.UI
{
	public interface IDisplayScreen
	{
		void Activate(IDisplayScreen previousScreen);

		void Disable();

		void HandleInputAction(InputAction input);
	}
}
