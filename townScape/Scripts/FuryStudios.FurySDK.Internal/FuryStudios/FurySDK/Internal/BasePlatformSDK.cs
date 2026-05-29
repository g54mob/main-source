using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FuryStudios.FurySDK.Settings;
using UnityEngine;

namespace FuryStudios.FurySDK.Internal
{
	public abstract class BasePlatformSDK : MonoBehaviour, IPlatformSDK
	{
		protected Dictionary<ContainerID, BaseStorageContainer> storageContainers;

		private bool isSuspended;

		private bool isConstrained;

		public abstract SystemIdentifier systemId { get; }

		public abstract PlatformIdentifier platformId { get; }

		public virtual bool IsInitialized { get; protected set; }

		protected abstract PlatformFeature supportedFeatures { get; }

		protected PlatformSettings Settings { get; private set; }

		public virtual bool IsSuspended
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsConstrained
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual Rect SafeArea => default(Rect);

		public abstract IUser User { get; }

		public abstract bool IsUserSigningIn { get; }

		public virtual event Action OnSuspended
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual event Action OnResumed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual event Action OnConstrained
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual event Action OnUnconstrained
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual void Init(PlatformSettings settings)
		{
		}

		protected virtual void Update()
		{
		}

		public virtual Language GetSystemLanguage()
		{
			return default(Language);
		}

		public virtual bool AreFeaturesSupported(PlatformFeature features)
		{
			return false;
		}

		public abstract IAsyncRequest SignIn(SignInOptions options);

		public abstract IAsyncRequest SignOut();

		protected abstract BaseStorageContainer CreateContainer(ContainerID containerID);

		public virtual IStorageContainer Storage(ContainerID containerID)
		{
			return null;
		}

		public virtual IAsyncRequest<bool> IsAchievementUnlocked(AchievementID achievement)
		{
			return null;
		}

		public abstract IAsyncRequest<bool> AreAchievementsUnlocked(IEnumerable<AchievementID> achievements);

		public abstract IAsyncRequest SetAchievementProgress(AchievementID achievement, float progress);

		public abstract IAsyncRequest LockAchievement(AchievementID achievement);

		public abstract IAsyncRequest ShowAchievementsUI();

		public abstract IAsyncRequest ShowWishlistUI();

		public abstract IAsyncRequest SetRichPresence(RichPresenceID richPresence, params string[] tokens);

		public abstract IAsyncRequest SetStat(StatID stat, float value, int[] metadata = null);

		public abstract IAsyncRequest<ILeaderboard> GetLeaderboard(StatID stat);

		public abstract IAsyncRequest<bool> IsDlcUnlocked(DlcID dlc);

		public virtual IAsyncRequest OpenURL(string url)
		{
			return null;
		}
	}
}
