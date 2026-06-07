namespace VoxelBusters.EssentialKit
{
	public class GameServicesAuthStatusChangeResult
	{
		public ILocalPlayer LocalPlayer { get; private set; }

		public LocalPlayerAuthStatus AuthStatus { get; private set; }

		internal GameServicesAuthStatusChangeResult(ILocalPlayer localPlayer, LocalPlayerAuthStatus authStatus)
		{
		}
	}
}
