using System;
using System.Security.Permissions;
using Unity;

namespace Microsoft.Win32
{
	/// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.PowerModeChanged" /> event.</summary>
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public class PowerModeChangedEventArgs : EventArgs
	{
		/// <summary>Gets an identifier that indicates the type of the power mode event that has occurred.</summary>
		/// <returns>One of the <see cref="T:Microsoft.Win32.PowerModes" /> values.</returns>
		public PowerModes Mode
		{
			get
			{
				Unity.ThrowStub.ThrowNotSupportedException();
				return default(PowerModes);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.PowerModeChangedEventArgs" /> class using the specified power mode event type.</summary>
		/// <param name="mode">One of the <see cref="T:Microsoft.Win32.PowerModes" /> values that represents the type of power mode event. </param>
		public PowerModeChangedEventArgs(PowerModes mode)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}
}
