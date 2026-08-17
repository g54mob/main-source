using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using VampireSurvivors.Builds;
using VampireSurvivors.Builds.Game;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.App.Framework.System;

public class UnityServicesManager : IInitializable, IDisposable
{
	[StructLayout((LayoutKind)3)]
	private struct _003CInitServicesAsync_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public UnityServicesManager _003C_003E4__this;

		private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_002c: Expected I4, but got I8
			//IL_00f3: Expected O, but got I4
			//IL_0102: Expected I4, but got I8
			//IL_007b: Expected O, but got I4
			//IL_00c5: Expected O, but got I4
			//IL_00d0: Expected O, but got Ref
			//IL_033c: Expected I4, but got I8
			//IL_01bf: Expected O, but got I4
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_026c: Expected O, but got Ref
			int num = _003C_003E1__state;
			UnityServicesManager unityServicesManager = _003C_003E4__this;
			CancellationToken cancellationToken = default(CancellationToken);
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
				num = -1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					goto IL_02e1;
				}
				SwitchToMainThreadAwaitable.Awaiter awaiter = default(SwitchToMainThreadAwaitable.Awaiter);
				bool isCompleted = awaiter.IsCompleted;
				bool flag = !isCompleted;
				cancellationToken = (CancellationToken)0;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)8;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			unityServicesManager._003CIsUnityServicesInitialized_003Ek__BackingField = false;
			goto IL_02e1;
			IL_02e1:
			Task task;
			if (num == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__2;
			}
			else
			{
				BaseGameData baseGameData = BaseGame._baseGameData;
				if ((object)BaseGame._baseGameData == null)
				{
					throw new NullReferenceException();
				}
				BuildMeta buildMeta = baseGameData._BuildMeta;
				if (buildMeta.BuildPlatform == BuildPlatform.APPLE_ARCADE)
				{
					DisableUnityAnalytics();
				}
				Task task2 = UnityServices.InitializeAsync();
				int num2 = task2.m_stateFlags & 0x1600000;
				bool flag2 = num2 == 0;
				bool flag3 = num2 < 0;
				bool flag4 = !flag3;
				object obj = !flag4;
				object obj2 = obj | flag2;
				task = task2;
				if (obj2 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter)task2;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder2 = (AsyncUniTaskMethodBuilder)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter2 = default(TaskAwaiter);
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Debug.Log("[UnityServicesManager] UnityServices Initialized");
			unityServicesManager._003CIsUnityServicesInitialized_003Ek__BackingField = true;
			_003C_003E1__state = -2;
			if ((object)_003C_003Et__builder != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private Action<IronSourceAdInfo> _rewardUserCallback;

	private bool _rewardEarned;

	private const string POST_RUN_EXTRA_GOLD_REWARDED = "";

	private const string REVIVE_REWARDED = "";

	private bool _003CIsUnityServicesInitialized_003Ek__BackingField;

	public bool IsUnityServicesInitialized
	{
		get
		{
			return _003CIsUnityServicesInitialized_003Ek__BackingField;
		}
		private set
		{
			_003CIsUnityServicesInitialized_003Ek__BackingField = value;
		}
	}

	public unsafe void Initialize()
	{
		//IL_002c: Expected O, but got Ref
		_003CInitServicesAsync_003Ed__18 obj = default(_003CInitServicesAsync_003Ed__18);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		object obj2 = default(object);
		UniTaskExtensions.Forget((UniTask)(&obj2));
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E23]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_rewardUserCallback = null;
		_rewardUserCallback = rewardUserCallback;
		_rewardEarned = false;
		ShowRewardedAdAsync("");
	}

	public void LoadRewardedVideoAd()
	{
		IronSource agent = IronSource.Agent;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
	}

	public bool CanShowReviveRewardAd()
	{
		return false;
	}

	public void ShowReviveRewardAd(Action<IronSourceAdInfo> rewardUserCallback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E26]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_rewardUserCallback = null;
		_rewardUserCallback = rewardUserCallback;
		_rewardEarned = false;
		ShowRewardedAdAsync("");
	}

	private static void InitOnLoad()
	{
		BaseGameData baseGameData = BaseGame._baseGameData;
		if ((object)BaseGame._baseGameData != null && ((UnityEngine.Object)baseGameData).m_CachedPtr != (IntPtr)0)
		{
			BaseGameData baseGameData2 = BaseGame._baseGameData;
			BuildMeta buildMeta = baseGameData2._BuildMeta;
			if (buildMeta.BuildPlatform == BuildPlatform.APPLE_ARCADE)
			{
				DisableUnityAnalytics();
			}
		}
	}

	private static void DisableUnityAnalytics()
	{
		//IL_0015: Expected O, but got I
		AnalyticsCommon.ugsAnalyticsEnabledInternal = false;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v81 @ rax_v8 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	private unsafe UniTask InitServicesAsync()
	{
		//IL_002b: Expected native int or pointer, but got O
		_003CInitServicesAsync_003Ed__18 obj = default(_003CInitServicesAsync_003Ed__18);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		UniTask uniTask = default(UniTask);
		object source = default(object);
		global::System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
		return uniTask;
	}

	private void InitFailed(Exception error)
	{
		string message = error.Message;
		string message2 = "[UnityServicesManager] Initialization Failed: " + message;
		Debug.Log(message2);
		Debug.LogException(error._innerException);
	}

	private void SetupAds()
	{
		BaseGameData baseGameData = BaseGame._baseGameData;
		if ((object)BaseGame._baseGameData != null)
		{
			BuildMeta buildMeta = baseGameData._BuildMeta;
			if (buildMeta.BuildPlatform == BuildPlatform.APPLE_ARCADE)
			{
				return;
			}
		}
		Action value = OnLevelPlayInitialized;
		IronSourceEvents.onSdkInitializationCompletedEvent += value;
		Action<IronSourceAdInfo> value2 = RewardedVideoOnAdAvailable;
		IronSourceRewardedVideoEvents.onAdAvailableEvent += value2;
		Action value3 = RewardedVideoOnAdUnavailable;
		IronSourceRewardedVideoEvents.onAdUnavailableEvent += value3;
		Action<IronSourceError> value4 = RewardedVideoOnAdLoadFailed;
		IronSourceRewardedVideoEvents.onAdLoadFailedEvent += value4;
		Action<IronSourceAdInfo> value5 = RewardedVideoOnAdOpenedEvent;
		IronSourceRewardedVideoEvents.onAdOpenedEvent += value5;
		Action<IronSourceError, IronSourceAdInfo> value6 = RewardedVideoOnAdShowFailedEvent;
		IronSourceRewardedVideoEvents.onAdShowFailedEvent += value6;
		Action<IronSourcePlacement, IronSourceAdInfo> value7 = RewardedVideoOnAdClickedEvent;
		IronSourceRewardedVideoEvents.onAdClickedEvent += value7;
		Action<IronSourceAdInfo> value8 = RewardedVideoOnAdClosedEvent;
		IronSourceRewardedVideoEvents.onAdClosedEvent += value8;
		Action<IronSourcePlacement, IronSourceAdInfo> value9 = RewardedVideoOnAdRewardedEvent;
		IronSourceRewardedVideoEvents.onAdRewardedEvent += value9;
		Debug.Log("[UnityServicesManager] Ads initialized");
	}

	private void InitLevelPlay()
	{
	}

	private void OnLevelPlayInitialized()
	{
		Debug.Log("OnLevelPlayInitialized");
		IronSource agent = IronSource.Agent;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003900");
	}

	private void CleanupAds()
	{
		Action value = OnLevelPlayInitialized;
		IronSourceEvents.onSdkInitializationCompletedEvent -= value;
		Action<IronSourceAdInfo> value2 = RewardedVideoOnAdAvailable;
		IronSourceRewardedVideoEvents.onAdAvailableEvent -= value2;
		Action value3 = RewardedVideoOnAdUnavailable;
		IronSourceRewardedVideoEvents.onAdUnavailableEvent -= value3;
		Action<IronSourceError> value4 = RewardedVideoOnAdLoadFailed;
		IronSourceRewardedVideoEvents.onAdLoadFailedEvent -= value4;
		Action<IronSourceAdInfo> value5 = RewardedVideoOnAdOpenedEvent;
		IronSourceRewardedVideoEvents.onAdOpenedEvent -= value5;
		Action<IronSourceError, IronSourceAdInfo> value6 = RewardedVideoOnAdShowFailedEvent;
		IronSourceRewardedVideoEvents.onAdShowFailedEvent -= value6;
		Action<IronSourcePlacement, IronSourceAdInfo> value7 = RewardedVideoOnAdClickedEvent;
		IronSourceRewardedVideoEvents.onAdClickedEvent -= value7;
		Action<IronSourceAdInfo> value8 = RewardedVideoOnAdClosedEvent;
		IronSourceRewardedVideoEvents.onAdClosedEvent -= value8;
		Action<IronSourcePlacement, IronSourceAdInfo> value9 = RewardedVideoOnAdRewardedEvent;
		IronSourceRewardedVideoEvents.onAdRewardedEvent -= value9;
	}

	private void ShowRewardedAdAsync(string adId = null)
	{
		IronSource agent = IronSource.Agent;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Debug.LogWarning("[UnityServicesManager] RewardedAd not available");
			return;
		}
		Debug.Log("[UnityServicesManager] Rewarded Ad Shown!");
		if (adId == null)
		{
			IronSource agent2 = IronSource.Agent;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
		else
		{
			IronSource agent3 = IronSource.Agent;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		}
	}

	private bool CanUserHideAdsViaDlc()
	{
		return true;
	}

	private void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
	{
		string message = "[UnityServicesManager] OnAdAvailable event from ad unit id: " + adInfo.adUnit;
		Debug.Log(message);
	}

	private void RewardedVideoOnAdUnavailable()
	{
		Debug.Log("[UnityServicesManager] OnAdUnavailable");
	}

	private unsafe void RewardedVideoOnAdLoadFailed(IronSourceError error)
	{
		//IL_0048: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		global::System.ParamsArray paramsArray = new global::System.ParamsArray(arg, arg2, error.description);
		object obj = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "OnAdLoadFailed: [{0}] [{1}] {2}", (global::System.ParamsArray)(&obj));
		string message = "[UnityServicesManager] " + text;
		Debug.Log(message);
	}

	private void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
	{
		string message = "[UnityServicesManager] OnAdOpened event from ad unit id: " + adInfo.adUnit;
		Debug.Log(message);
	}

	private unsafe void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
	{
		//IL_002f: Expected I, but got O
		//IL_0095: Expected I, but got O
		//IL_00fa: Expected I, but got O
		//IL_01a7: Expected O, but got Ref
		//IL_0155: Expected I, but got O
		object[] array = new object[4];
		if (adInfo.adUnit != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj4 = default(object);
		if (obj4 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if (error.description != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		global::System.ParamsArray paramsArray = new global::System.ParamsArray(array);
		object obj7 = default(object);
		string text = string.FormatHelper((IFormatProvider)null, "OnAdShowFailed event from ad unit id: {0} with error: [{1}] [{2}] {3}", (global::System.ParamsArray)(&obj7));
		string message = "[UnityServicesManager] " + text;
		Debug.Log(message);
	}

	private void RewardedVideoOnAdClickedEvent(IronSourcePlacement placementInfo, IronSourceAdInfo adInfo)
	{
		string message = "[UnityServicesManager] OnAdClicked event from ad unit id: " + adInfo.adUnit;
		Debug.Log(message);
	}

	private void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
	{
		Debug.Log("[UnityServicesManager] OnAdClosed event");
		if (_rewardEarned)
		{
			Action<IronSourceAdInfo> rewardUserCallback = _rewardUserCallback;
			_rewardEarned = false;
			if (_rewardUserCallback != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rax_v5 (System.Action`1<IronSourceAdInfo>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placementInfo, IronSourceAdInfo adInfo)
	{
		_rewardEarned = true;
	}
}
