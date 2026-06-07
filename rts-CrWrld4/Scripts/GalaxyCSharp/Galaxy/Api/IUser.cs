using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IUser : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IUser(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IUser()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual bool SignedIn()
		{
			return false;
		}

		public virtual GalaxyID GetGalaxyID()
		{
			return null;
		}

		public virtual void SignInCredentials(string login, string password)
		{
		}

		public virtual void SignInGalaxy()
		{
		}

		public virtual void SignOut()
		{
		}

		public virtual void RequestUserData(GalaxyID userID, ISpecificUserDataListener listener)
		{
		}

		public virtual string GetUserData(string key, GalaxyID userID)
		{
			return null;
		}

		public virtual void SetUserData(string key, string value)
		{
		}

		public virtual bool IsLoggedOn()
		{
			return false;
		}
	}
}
