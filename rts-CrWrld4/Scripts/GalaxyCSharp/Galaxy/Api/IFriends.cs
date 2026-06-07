using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IFriends : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IFriends(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IFriends()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual string GetPersonaName()
		{
			return null;
		}

		public virtual string GetFriendPersonaName(GalaxyID userID)
		{
			return null;
		}

		public virtual PersonaState GetFriendPersonaState(GalaxyID userID)
		{
			return default(PersonaState);
		}

		public virtual uint GetFriendCount()
		{
			return 0u;
		}

		public virtual GalaxyID GetFriendByIndex(uint index)
		{
			return null;
		}

		public virtual void SetRichPresence(string key, string value)
		{
		}
	}
}
