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

		public Dictionary<ModId, SubscribedMod> queuedUnsubscribedMods = new Dictionary<ModId, SubscribedMod>();

		public UserObject userObject;

		public string rootLocalStoragePath;

		public bool IsOAuthTokenValid()
		{
			if (!string.IsNullOrEmpty(oAuthToken))
			{
				return !oAuthTokenWasRejected;
			}
			return false;
		}

		public void SetUserObject(UserObject user)
		{
			userObject = user;
			ModCollectionManager.AddUserToRegistry(user);
			DataStorage.SaveUserData();
		}

		public void ClearUser()
		{
			userObject = default(UserObject);
			ClearAuthenticatedSession();
			DataStorage.SaveUserData();
		}

		public void SetOAuthToken(AccessTokenObject newToken)
		{
			oAuthToken = newToken.access_token;
			oAuthExpiryDate = newToken.date_expires;
			oAuthTokenWasRejected = false;
			DataStorage.SaveUserData();
		}

		public void SetOAuthToken(WssLoginSuccess newToken)
		{
			oAuthToken = newToken.access_token;
			oAuthExpiryDate = newToken.date_expires;
			oAuthTokenWasRejected = false;
			DataStorage.SaveUserData();
		}

		public void SetOAuthTokenAsRejected()
		{
			oAuthTokenWasRejected = true;
		}

		internal void ClearAuthenticatedSession()
		{
			oAuthToken = null;
			oAuthTokenWasRejected = false;
		}
	}
}
