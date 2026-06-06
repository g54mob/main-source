using System;
using System.Security.Permissions;
using Unity;

namespace Microsoft.Win32
{
	/// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.SessionEnded" /> event.</summary>
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	public class SessionEndedEventArgs : EventArgs
	{
		/// <summary>Gets an identifier that indicates how the session ended.</summary>
		/// <returns>One of the <see cref="T:Microsoft.Win32.SessionEndReasons" /> values that indicates how the session ended.</returns>
		public SessionEndReasons Reason
		{
			get
			{
				Unity.ThrowStub.ThrowNotSupportedException();
				return default(SessionEndReasons);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.SessionEndedEventArgs" /> class.</summary>
		/// <param name="reason">One of the <see cref="T:Microsoft.Win32.SessionEndReasons" /> values indicating how the session ended. </param>
		public SessionEndedEventArgs(SessionEndReasons reason)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}
}
