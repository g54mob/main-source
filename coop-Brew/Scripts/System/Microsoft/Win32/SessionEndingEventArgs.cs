using System;

namespace Microsoft.Win32
{
	/// <summary>Provides data for the <see cref="E:Microsoft.Win32.SystemEvents.SessionEnding" /> event.</summary>
	public class SessionEndingEventArgs : EventArgs
	{
		/// <summary>Gets or sets a value indicating whether to cancel the user request to end the session.</summary>
		/// <returns>
		///     <see langword="true" /> to cancel the user request to end the session; otherwise, <see langword="false" />.</returns>
		public bool Cancel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>Gets the reason the session is ending.</summary>
		/// <returns>One of the <see cref="T:Microsoft.Win32.SessionEndReasons" /> values that specifies how the session is ending.</returns>
		public SessionEndReasons Reason => default(SessionEndReasons);

		/// <summary>Initializes a new instance of the <see cref="T:Microsoft.Win32.SessionEndingEventArgs" /> class using the specified value indicating the type of session close event that is occurring.</summary>
		/// <param name="reason">One of the <see cref="T:Microsoft.Win32.SessionEndReasons" /> that specifies how the session ends. </param>
		public SessionEndingEventArgs(SessionEndReasons reason)
		{
		}
	}
}
