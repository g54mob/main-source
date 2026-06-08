namespace LaundryBear.PlatformServices
{
	public interface IUserService
	{
		event OnUserSignIn UserSignInEvent;

		event OnUserSignOut UserSignOutEvent;

		event ControllerPairingChangedEventHandler ControllerPairingChangedEvent;

		bool SupportsMultipleUsers();

		IUser[] GetActiveUsers();

		IUser GetUser(ILocalID localID);

		void GetLaunchUser(OnGetLaunchUser callback);

		void ShowSignInModal(bool allowGuests, OnSignInModalComplete callback);
	}
}
