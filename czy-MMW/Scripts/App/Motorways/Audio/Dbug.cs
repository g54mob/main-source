namespace Motorways.Audio
{
	public static class Dbug
	{
		public static readonly Diagnostics.Log.Channel Log = AudioSystem.Log;

		public static bool Assert(bool condition)
		{
			return Diagnostics.Verify(condition);
		}

		public static bool Assert(bool condition, string message, object[] args = null)
		{
			return Diagnostics.Verify(condition, message, args);
		}
	}
}
