namespace Coherence
{
	public static class AuthorityModeExtensions
	{
		public static bool CanTransfer(this AuthorityType authorityType, AuthorityType other)
		{
			return false;
		}

		public static AuthorityType Subtract(this AuthorityType authorityType, AuthorityType other)
		{
			return default(AuthorityType);
		}

		public static bool Contains(this AuthorityType authorityType, AuthorityType other)
		{
			return false;
		}

		public static bool ControlsState(this AuthorityType authorityType)
		{
			return false;
		}

		public static bool ControlsInput(this AuthorityType authorityType)
		{
			return false;
		}
	}
}
