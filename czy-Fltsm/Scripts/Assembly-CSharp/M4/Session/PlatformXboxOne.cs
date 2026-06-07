using System;
using UnityEngine.Events;

namespace M4.Session
{
	public class PlatformXboxOne : IPlatform
	{
		public bool ItIsInitialized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool ItHasDefaultUser
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool ItHandlesTextInput
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Initialize()
		{
			throw new NotImplementedException();
		}

		public void OnStart()
		{
			throw new NotImplementedException();
		}

		public void OnUpdate()
		{
			throw new NotImplementedException();
		}

		public void OnQuit()
		{
			throw new NotImplementedException();
		}

		public void RequestPlayer(UnityAction<UserRequestResult, IUser> callback)
		{
			throw new NotImplementedException();
		}

		public void TogglePlayerUI(bool enabled)
		{
			throw new NotImplementedException();
		}

		public void SaveSettings(object settings)
		{
			throw new NotImplementedException();
		}

		public void RequestUser(UnityAction<UserRequestResult, IUser> callback)
		{
			throw new NotImplementedException();
		}

		public void ToggleSignedInUserUI(bool enabled)
		{
			throw new NotImplementedException();
		}

		public IUser ChangeUser(IUser user)
		{
			throw new NotImplementedException();
		}
	}
}
