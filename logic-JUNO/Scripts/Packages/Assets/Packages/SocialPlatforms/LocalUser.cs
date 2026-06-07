using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Packages.SocialPlatforms
{
	public class LocalUser : ILocalUser, IUserProfile
	{
		public virtual bool authenticated { get; set; }

		public virtual IUserProfile[] friends { get; set; }

		public virtual string id { get; set; }

		public virtual Texture2D image { get; set; }

		public virtual bool isFriend { get; set; }

		public virtual UserState state { get; set; }

		public virtual bool underage { get; set; }

		public virtual string userName { get; set; }

		public void Authenticate(Action<bool, string> callback)
		{
			authenticated = true;
			callback?.Invoke(arg1: true, null);
		}

		public virtual void Authenticate(Action<bool> callback)
		{
			authenticated = true;
			callback?.Invoke(obj: true);
		}

		public virtual void LoadFriends(Action<bool> callback)
		{
			Social.Active.LoadFriends(this, callback);
		}
	}
}
