using System;
using UnityEngine.Events;

namespace M4.Session
{
	public class PlatformDefault : IPlatform
	{
		private IUser user;

		public bool ItIsInitialized { get; private set; }

		public bool ItHasDefaultUser => true;

		public bool ItHandlesTextInput => false;

		public IUser ChangeUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public void Initialize()
		{
			LoadSettings();
			ItIsInitialized = true;
		}

		public void RequestUser(UnityAction<UserRequestResult, IUser> callback)
		{
			if (user == null)
			{
				user = new DefaultUser();
			}
			callback(UserRequestResult.SUCCES, user);
		}

		public void OnQuit()
		{
		}

		public void OnStart()
		{
		}

		public void OnUpdate()
		{
		}

		public void SaveSettings(object settings)
		{
		}

		private void LoadSettings()
		{
		}
	}
}
