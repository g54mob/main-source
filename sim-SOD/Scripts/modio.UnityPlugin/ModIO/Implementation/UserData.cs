using System;
using System.Collections.Generic;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.Wss.Messages.Objects;

namespace ModIO.Implementation
{
	[Serializable]
	internal class UserData
	{
		public static UserData instance;

		public string oAuthToken;

		public long oAuthExpiryDate;

		public bool oAuthTokenWasRejected;

		public Dictionary<ModId, SubscribedMod> queuedUnsubscribedMods;

		public UserObject userObject;

		public string rootLocalStoragePath;

		public bool IsOAuthTokenValid()
		{
			return false;
		}

		public void SetUserObject(UserObject user)
		{
		}

		public void ClearUser()
		{
		}

		public void SetOAuthToken(AccessTokenObject newToken)
		{
		}

		public void SetOAuthToken(WssLoginSuccess newToken)
		{
		}

		public void SetOAuthTokenAsRejected()
		{
		}

		internal void ClearAuthenticatedSession()
		{
		}
	}
}
