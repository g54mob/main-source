using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class GameServicesError
	{
		public const string kDomain = "[Essential Kit] Game Services";

		public static Error Unknown(string description = null)
		{
			return null;
		}

		public static Error SystemError(string description = null)
		{
			return null;
		}

		public static Error NetworkError(string description = null)
		{
			return null;
		}

		public static Error NotAllowed(string description = null)
		{
			return null;
		}

		public static Error DataNotAvailable(string description = null)
		{
			return null;
		}

		public static Error NotSupported(string description = null)
		{
			return null;
		}

		public static Error ConfigurationError(string description = null)
		{
			return null;
		}

		public static Error InvalidInput(string description = null)
		{
			return null;
		}

		public static Error NotAuthenticated(string description = null)
		{
			return null;
		}

		private static Error CreateError(int code, string description)
		{
			return null;
		}
	}
}
