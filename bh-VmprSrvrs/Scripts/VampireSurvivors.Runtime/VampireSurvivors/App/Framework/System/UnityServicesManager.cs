using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace VampireSurvivors.App.Framework.System
{
	public class UnityServicesManager : IInitializable, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CInitServicesAsync_003Ed__18 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public UnityServicesManager _003C_003E4__this;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CanBeNull]
		private Action<IronSourceAdInfo> _rewardUserCallback;

		private bool _rewardEarned;

		private const string POST_RUN_EXTRA_GOLD_REWARDED = "";

		private const string REVIVE_REWARDED = "";

		public bool IsUnityServicesInitialized { get; private set; }

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public bool IsAppleArcade()
		{
			return false;
		}

		public bool CanShowPostRunRewardAd()
		{
			return false;
		}

		public void ShowPostRunRewardAd(Action<IronSourceAdInfo> rewardUserCallback)
		{
		}

		public void LoadRewardedVideoAd()
		{
		}

		public bool CanShowReviveRewardAd()
		{
			return false;
		}

		public void ShowReviveRewardAd(Action<IronSourceAdInfo> rewardUserCallback)
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitOnLoad()
		{
		}

		private static void DisableUnityAnalytics()
		{
		}

		[AsyncStateMachine(typeof(_003CInitServicesAsync_003Ed__18))]
		private UniTask InitServicesAsync()
		{
			return default(UniTask);
		}

		private void InitFailed(Exception error)
		{
		}

		private void SetupAds()
		{
		}

		private void InitLevelPlay()
		{
		}

		private void OnLevelPlayInitialized()
		{
		}

		private void CleanupAds()
		{
		}

		private void ShowRewardedAdAsync(string adId = null)
		{
		}

		private bool CanUserHideAdsViaDlc()
		{
			return false;
		}

		private void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
		{
		}

		private void RewardedVideoOnAdUnavailable()
		{
		}

		private void RewardedVideoOnAdLoadFailed(IronSourceError error)
		{
		}

		private void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
		{
		}

		private void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
		{
		}

		private void RewardedVideoOnAdClickedEvent(IronSourcePlacement placementInfo, IronSourceAdInfo adInfo)
		{
		}

		private void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
		{
		}

		private void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placementInfo, IronSourceAdInfo adInfo)
		{
		}
	}
}
