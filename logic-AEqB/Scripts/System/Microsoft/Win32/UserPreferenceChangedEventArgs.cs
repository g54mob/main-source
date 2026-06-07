using System;
using System.Security.Permissions;
using Unity;

namespace Microsoft.Win32
{
	/// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.UserPreferenceChanged" /> event.</summary>
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	public class UserPreferenceChangedEventArgs : EventArgs
	{
		/// <summary>Gets the category of user preferences that has changed.</summary>
		/// <returns>One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicates the category of user preferences that has changed.</returns>
		public UserPreferenceCategory Category
		{
			get
			{
				Unity.ThrowStub.ThrowNotSupportedException();
				return default(UserPreferenceCategory);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.UserPreferenceChangedEventArgs" /> class using the specified user preference category identifier.</summary>
		/// <param name="category">One of the <see cref="T:Microsoft.Win32.UserPreferenceCategory" /> values that indicates the user preference category that has changed. </param>
		public UserPreferenceChangedEventArgs(UserPreferenceCategory category)
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}
}
