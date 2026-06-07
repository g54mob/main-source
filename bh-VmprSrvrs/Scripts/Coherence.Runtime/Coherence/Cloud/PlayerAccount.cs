using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Runtime;
using UnityEngine;

namespace Coherence.Cloud
{
	public sealed class PlayerAccount : IDisposable, IEquatable<PlayerAccount>
	{
		private enum State
		{
			LoggedOut = 0,
			LoggingIn = 1,
			LoggedIn = 2,
			LoggingOut = 3
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDisposeAsync_003Ed__120 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public PlayerAccount _003C_003E4__this;

			public bool waitForOngoingOperationsToFinish;

			private ValueTaskAwaiter _003C_003Eu__1;

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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("'null' is now being used to represent the lack of a player account instead.")]
		[Deprecated("04/2024", 1, 6, 0, Reason = "'null' is now being used to represent the lack of a PlayerAccount instead.")]
		public static readonly PlayerAccount None;

		internal static readonly CloudUniqueId DefaultCloudUniqueId;

		private static PlayerAccount main;

		private static PlayerAccount[] all;

		private readonly HashSet<LoginInfo> loginInfos;

		[MaybeNull]
		private LoginResult loginResult;

		internal bool shouldDisposeCloudService;

		private CloudService services;

		private bool shouldReleaseGuid;

		internal string projectId;

		private bool isDisposed;

		private CloudUniqueId cloudUniqueId;

		private State state;

		internal IReadOnlyCollection<LoginInfo> LoginInfos => null;

		internal LoginResult LoginResult
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static IReadOnlyList<PlayerAccount> All => null;

		public static PlayerAccount Main
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public PlayerAccountId Id { get; private set; }

		public GuestId? GuestId { get; private set; }

		internal CloudUniqueId CloudUniqueId
		{
			get
			{
				return default(CloudUniqueId);
			}
			set
			{
			}
		}

		public string Username { get; private set; }

		public bool IsGuest { get; private set; }

		public SessionToken SessionToken { get; private set; }

		public string DisplayName { get; private set; }

		public string AvatarUrl { get; private set; }

		public bool IsNewPlayer { get; private set; }

		public bool IsVerified { get; private set; }

		public bool IsLoggedIn => false;

		public CloudService Services
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool IsMain => false;

		public static event OnMainPlayerAccountChangedEventHandler OnMainChanged
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

		public static event Action<PlayerAccount> OnMainLoggedIn
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

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnStart()
		{
		}

		internal PlayerAccount(LoginInfo loginInfo, CloudUniqueId cloudUniqueId, string projectId, CloudService services)
		{
		}

		~PlayerAccount()
		{
		}

		public static PlayerAccount Find([DisallowNull] Predicate<PlayerAccount> match)
		{
			return null;
		}

		internal static PlayerAccount Find(LoginInfo info)
		{
			return null;
		}

		public static PlayerAccount[] FindAll([DisallowNull] Predicate<PlayerAccount> match)
		{
			return null;
		}

		public static CoherenceTask<PlayerAccount> GetMainAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static CoherenceTask<PlayerAccount> GetMainAsync(bool waitUntilLoggedIn, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public void SetAsMain()
		{
		}

		public PlayerAccountOperation<PlayerAccountInfo> GetInfo(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation SetUsername(string username, string password = "", bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation RemoveUsername(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation SetDisplayInfo(string displayName, string avatarUrl = "", CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation RemoveDisplayInfo(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation SetEmail(string emailAddress, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation RemoveEmail(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation<string> GetOneTimeCode(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkGuest(GuestId guestId, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkGuest(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkSteam(string ticket, string identity = "", bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkSteam(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkEpicGames(string token, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkEpicGames(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkPlayStation(string token, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkPlayStation(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkXbox(string token, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkXbox(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkNintendo(string token, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkNintendo(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation LinkJwt(string token, bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public PlayerAccountOperation UnlinkJwt(bool force = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public void Logout()
		{
		}

		internal static void Register([DisallowNull] PlayerAccount playerAccount)
		{
		}

		internal static void Unregister([DisallowNull] PlayerAccount playerAccount)
		{
		}

		private static void Add(PlayerAccount playerAccount)
		{
		}

		internal void AddLoginInfo(LoginInfo loginInfo)
		{
		}

		private void RemoveLoginInfos(LoginType loginType)
		{
		}

		private void RemoveLoginInfos(Func<LoginInfo, bool> predicate)
		{
		}

		private void UpdateIsGuest()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator CloudUniqueId(PlayerAccount playerAccount)
		{
			return default(CloudUniqueId);
		}

		private void OnLoggingIn(PlayerAccount playerAccount)
		{
		}

		private void OnLoggedin(LoginResponse response)
		{
		}

		private void OnLoggingOut(PlayerAccount playerAccount)
		{
		}

		public void Dispose()
		{
		}

		[AsyncStateMachine(typeof(_003CDisposeAsync_003Ed__120))]
		internal ValueTask DisposeAsync(bool waitForOngoingOperationsToFinish)
		{
			return default(ValueTask);
		}

		private void DisposeShared()
		{
		}

		internal static Action<Task<LoginResult>> OnLoginAttemptCompleted(TaskCompletionSource<PlayerAccount> taskCompletionSource, CloudService services, CancellationToken cancellationToken)
		{
			return null;
		}

		public static bool operator ==(PlayerAccount x, PlayerAccount y)
		{
			return false;
		}

		public static bool operator !=(PlayerAccount x, PlayerAccount y)
		{
			return false;
		}

		public bool Equals(PlayerAccount other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private void SetState(State setState)
		{
		}
	}
}
