namespace FishNet.Object
{
	public static class ReplicateStateExtensions
	{
		public static bool IsValid(this ReplicateState value)
		{
			return false;
		}

		public static bool IsReplayed(this ReplicateState value)
		{
			return false;
		}

		public static bool IsUserCreated(this ReplicateState value)
		{
			return false;
		}

		public static bool IsPredicted(this ReplicateState value)
		{
			return false;
		}
	}
}
