namespace Microsoft.Win32
{
	/// <summary>Provides access to system event notifications. This class cannot be inherited.</summary>
	public sealed class SystemEvents
	{
		/// <summary>Occurs when a user preference has changed.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event UserPreferenceChangedEventHandler UserPreferenceChanged
		{
			add
			{
			}
			remove
			{
			}
		}
	}
}
