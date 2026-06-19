namespace PlayFab.Multiplayer
{
	public class LobbyError
	{
		public const int Success = 0;

		public const int InvalidArg = -2147024809;

		public static bool SUCCEEDED(int error)
		{
			return error >= 0;
		}

		public static bool FAILED(int error)
		{
			return !SUCCEEDED(error);
		}
	}
}
