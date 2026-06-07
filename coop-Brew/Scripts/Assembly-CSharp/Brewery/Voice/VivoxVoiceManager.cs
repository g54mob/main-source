using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.Services.Vivox;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brewery.Voice
{
	public class VivoxVoiceManager : MonoBehaviour
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CInitializeServicesAsync_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VivoxVoiceManager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CInitializeWithRetry_003Ed__26 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public VivoxVoiceManager _003C_003E4__this;

			private int _003Cattempt_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CJoinPositionalChannelAsync_003Ed__31 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

			public VivoxVoiceManager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CJoinWithRetry_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VivoxVoiceManager _003C_003E4__this;

			private int _003Cattempt_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLeaveChannelAsync_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public VivoxVoiceManager _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

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

		[Header("Channel Settings")]
		[Tooltip("Audible distance in meters (max hearing range)")]
		[SerializeField]
		private int audibleDistance;

		[Tooltip("Conversational distance in meters (full volume range)")]
		[SerializeField]
		private int conversationalDistance;

		[Tooltip("Audio fade model")]
		[SerializeField]
		private AudioFadeModel fadeModel;

		[Header("Scene Settings")]
		[Tooltip("Scene name that triggers voice channel join")]
		[SerializeField]
		private string gameSceneName;

		[Header("Retry Settings")]
		[Tooltip("Maximum number of initialization retry attempts")]
		[SerializeField]
		private int maxInitRetries;

		[Tooltip("Maximum number of channel join retry attempts")]
		[SerializeField]
		private int maxJoinRetries;

		[Tooltip("Base delay in seconds between retry attempts (doubles each attempt)")]
		[SerializeField]
		private float retryBaseDelay;

		private bool _ugsInitialized;

		private bool _vivoxInitialized;

		private bool _inChannel;

		private bool _pendingJoin;

		private bool _isMuted;

		private string _currentChannelName;

		private bool _isInitializing;

		private bool _isJoining;

		private bool _destroyed;

		private float _lastSpeechDebugTime;

		public static VivoxVoiceManager Instance { get; private set; }

		public bool IsMuted => false;

		public bool IsTransmitting => false;

		public bool IsConnected => false;

		public bool IsInitialized => false;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		[AsyncStateMachine(typeof(_003CInitializeWithRetry_003Ed__26))]
		private void InitializeWithRetry()
		{
		}

		[AsyncStateMachine(typeof(_003CInitializeServicesAsync_003Ed__27))]
		private Task InitializeServicesAsync()
		{
			return null;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private bool IsInMultiplayerLobby()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CJoinWithRetry_003Ed__30))]
		private Task JoinWithRetry()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CJoinPositionalChannelAsync_003Ed__31))]
		private Task<bool> JoinPositionalChannelAsync()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLeaveChannelAsync_003Ed__32))]
		private Task LeaveChannelAsync()
		{
			return null;
		}

		private string BuildChannelName()
		{
			return null;
		}

		public void Set3DPosition(Vector3 speakerPosition, Vector3 listenerPosition, Quaternion listenerRotation)
		{
		}

		public void SetOutputVolume(float volume01)
		{
		}

		public void SetInputVolume(float volume01)
		{
		}

		public void SetMute(bool muted)
		{
		}

		public List<(string, VivoxParticipant)> GetRemoteParticipants()
		{
			return null;
		}

		public void SetParticipantVolume(VivoxParticipant participant, int volume)
		{
		}

		private void ApplyPersistedVolumes()
		{
		}
	}
}
