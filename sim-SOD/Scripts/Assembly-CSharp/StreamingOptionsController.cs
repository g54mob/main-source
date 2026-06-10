using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class StreamingOptionsController : MonoBehaviour
{
	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003COnAuthChange_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CUpdateTwitchCitizens_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CValidateTokenUpdated_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UnityWebRequest _003CwebRequest_003E5__2;

		private UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter _003C_003Eu__1;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGetChattersUpdated_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UnityWebRequest _003CwebRequest_003E5__2;

		private UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter _003C_003Eu__1;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGetModeratorsUpdated_003Ed__48 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UnityWebRequest _003CwebRequest_003E5__2;

		private UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter _003C_003Eu__1;

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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CGetVipsUpdated_003Ed__49 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public StreamingOptionsController _003C_003E4__this;

		private UnityWebRequest _003CwebRequest_003E5__2;

		private UnityAsyncExtensions.UnityWebRequestAsyncOperationAwaiter _003C_003Eu__1;

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

	[CompilerGenerated]
	private sealed class _003CGrabKnownOnlineBots_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StreamingOptionsController _003C_003E4__this;

		private UnityWebRequest _003CwebRequest_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CGrabKnownOnlineBots_003Ed__50(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Settings")]
	public bool enableTwitchAudienceCitizens;

	public int updateFrequency;

	public int maxListCount;

	[Header("Components")]
	public TextMeshProUGUI twitchConnectStatusText;

	public ButtonController connectToTwitchButton;

	public ToggleController enableTwitchAudienceToggle;

	public TextMeshProUGUI citizenUpdateText;

	public List<ButtonController> disabledIfNoConnection;

	[Header("State")]
	public bool grabbedAudience;

	public bool grabbingAudenceInProgress;

	public bool loginNameSet;

	public TwitchAudienceData audienceData;

	public float autoUpdateTime;

	public List<CitizenReplacement> customNames;

	public List<CitizenReplacement> customNamesReserves;

	private bool _hasAuth;

	private bool _hasValidToken;

	private bool _fetchingDataInProgress;

	private List<string> namePool;

	private List<string> activeKnownBots;

	private HashSet<string> finalNamePool;

	private const string twitchValidationEndpoint = "https://id.twitch.tv/oauth2/validate";

	private const string twitchChatterEndpoint = "https://api.twitch.tv/helix/chat/chatters?broadcaster_id=";

	private const string twitchModeratorEndpoint = "https://api.twitch.tv/helix/moderation/moderators?broadcaster_id=";

	private const string twitchVipEndpoint = "https://api.twitch.tv/helix/channels/vips?broadcaster_id=";

	private const string knownBotsEndpoints = "https://api.twitchinsights.net/v1/bots/online";

	[Header("Custom Name List")]
	[InfoBox("Can be used for debugging to test the name parsing functionality", EInfoBoxType.Normal)]
	public TextAsset customNameList;

	private static StreamingOptionsController _instance;

	public static StreamingOptionsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void OnConnectButton()
	{
	}

	[AsyncStateMachine(typeof(_003COnAuthChange_003Ed__36))]
	public void OnAuthChange()
	{
	}

	public void ResetTwitchAuthFlushGeneratedData()
	{
	}

	private void ForceTwitchAudienceCitizensToOff()
	{
	}

	public void SetEnableTwitchAudienceCitizens(bool val)
	{
	}

	public void SetUpdateFrequency(int val)
	{
	}

	[AsyncStateMachine(typeof(_003CUpdateTwitchCitizens_003Ed__41))]
	public void UpdateTwitchCitizens()
	{
	}

	private void AddUsersDataToNamePool(TwitchRootObject userData)
	{
	}

	private void FinalizeNamePool()
	{
	}

	private void ProcessNamePool()
	{
	}

	[AsyncStateMachine(typeof(_003CValidateTokenUpdated_003Ed__45))]
	public UniTask<bool> ValidateTokenUpdated()
	{
		return default(UniTask<bool>);
	}

	public void SetStatusText(string newText)
	{
	}

	[AsyncStateMachine(typeof(_003CGetChattersUpdated_003Ed__47))]
	public UniTask GetChattersUpdated()
	{
		return default(UniTask);
	}

	[AsyncStateMachine(typeof(_003CGetModeratorsUpdated_003Ed__48))]
	public UniTask GetModeratorsUpdated()
	{
		return default(UniTask);
	}

	[AsyncStateMachine(typeof(_003CGetVipsUpdated_003Ed__49))]
	public UniTask GetVipsUpdated()
	{
		return default(UniTask);
	}

	[IteratorStateMachine(typeof(_003CGrabKnownOnlineBots_003Ed__50))]
	private IEnumerator GrabKnownOnlineBots()
	{
		return null;
	}

	private bool TryAddCustomName(string input)
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ParseNamesFromNameList()
	{
	}
}
