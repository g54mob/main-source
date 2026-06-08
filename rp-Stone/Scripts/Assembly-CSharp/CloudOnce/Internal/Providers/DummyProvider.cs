using System;
using CloudOnce.Internal.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

namespace CloudOnce.Internal.Providers
{
	public sealed class DummyProvider : CloudProviderBase<DummyProvider>
	{
		private CloudOnceEvents cloudOnceEvents;

		public override string PlayerID => "DummyPlayerID";

		public override string PlayerDisplayName => "DummyPlayerName";

		public override Texture2D PlayerImage => Texture2D.whiteTexture;

		public override bool IsSignedIn => false;

		public bool CloudSaveInitialized => false;

		public override bool CloudSaveEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override ICloudStorageProvider Storage { get; protected set; }

		public override void Initialize(bool activateCloudSave = true, bool autoSignIn = true, bool autoCloudLoad = true)
		{
			cloudOnceEvents.RaiseOnInitializeComplete();
			cloudOnceEvents.RaiseOnPlayerImageDownloaded(Texture2D.whiteTexture);
			if (autoSignIn)
			{
				SignIn(autoCloudLoad);
			}
		}

		public override void SignIn(bool autoCloudLoad = true, UnityAction<bool> callback = null)
		{
			CloudOnceUtils.SafeInvoke(callback, param: false);
			if (autoCloudLoad)
			{
				cloudOnceEvents.RaiseOnCloudLoadComplete(success: false);
			}
		}

		public override void SignOut()
		{
		}

		public override void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
		{
		}

		public void InternalInit(CloudOnceEvents events)
		{
			cloudOnceEvents = events;
			Storage = new DummyStorageWrapper(events);
			base.ServiceName = "Dummy Provider";
		}
	}
}
