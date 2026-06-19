using System;
using System.Security.Permissions;
using Unity;

namespace Microsoft.Win32
{
	/// <summary>Provides access to system event notifications. This class cannot be inherited.</summary>
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	public sealed class SystemEvents
	{
		/// <summary>Occurs when the user changes the display settings.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler DisplaySettingsChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the display settings are changing.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler DisplaySettingsChanging
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs before the thread that listens for system events is terminated.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler EventsThreadShutdown
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user adds fonts to or removes fonts from the system.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler InstalledFontsChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the system is running out of available RAM.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler LowMemory
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user switches to an application that uses a different palette.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler PaletteChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user suspends or resumes the system.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event PowerModeChangedEventHandler PowerModeChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user is logging off or shutting down the system.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event SessionEndedEventHandler SessionEnded
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user is trying to log off or shut down the system.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event SessionEndingEventHandler SessionEnding
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the currently logged-in user has changed.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event SessionSwitchEventHandler SessionSwitch
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when the user changes the time on the system clock.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event EventHandler TimeChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when a windows timer interval has expired.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event TimerElapsedEventHandler TimerElapsed
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when a user preference has changed.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event UserPreferenceChangedEventHandler UserPreferenceChanged
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		/// <summary>Occurs when a user preference is changing.</summary>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static event UserPreferenceChangingEventHandler UserPreferenceChanging
		{
			add
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
			remove
			{
				Unity.ThrowStub.ThrowNotSupportedException();
			}
		}

		internal SystemEvents()
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}

		/// <summary>Creates a new window timer associated with the system events window.</summary>
		/// <param name="interval">Specifies the interval between timer notifications, in milliseconds.</param>
		/// <returns>The ID of the new timer.</returns>
		/// <exception cref="T:System.ArgumentException">The interval is less than or equal to zero. </exception>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed, or the attempt to create the timer did not succeed.</exception>
		public static IntPtr CreateTimer(int interval)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default(IntPtr);
		}

		/// <summary>Invokes the specified delegate using the thread that listens for system events.</summary>
		/// <param name="method">A delegate to invoke using the thread that listens for system events. </param>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed.</exception>
		public static void InvokeOnEventsThread(Delegate method)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}

		/// <summary>Terminates the timer specified by the given id.</summary>
		/// <param name="timerId">The ID of the timer to terminate. </param>
		/// <exception cref="T:System.InvalidOperationException">System event notifications are not supported under the current context. Server processes, for example, might not support global system event notifications.</exception>
		/// <exception cref="T:System.Runtime.InteropServices.ExternalException">The attempt to create a system events window thread did not succeed, or the attempt to terminate the timer did not succeed. </exception>
		public static void KillTimer(IntPtr timerId)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}
}
