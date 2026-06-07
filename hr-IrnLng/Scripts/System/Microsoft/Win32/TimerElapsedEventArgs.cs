using System;
using System.Security.Permissions;
using Unity;

namespace Microsoft.Win32
{
	/// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.TimerElapsed" /> event.</summary>
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	public class TimerElapsedEventArgs : EventArgs
	{
		/// <summary>Gets the ID number for the timer.</summary>
		/// <returns>The ID number for the timer.</returns>
		public IntPtr TimerId
		{
			get
			{
				Unity.ThrowStub.ThrowNotSupportedException();
				return default(IntPtr);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.TimerElapsedEventArgs" /> class.</summary>
		/// <param name="timerId">The ID number for the timer. </param>
		public TimerElapsedEventArgs(IntPtr timerId)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}
}
