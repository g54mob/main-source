using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Avatar : SelfInstancingMonoSingleton<Avatar>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetSprite_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Sprite> _003C_003Et__builder;

			public UserPortal currentAuthenticationPortal;

			public Avatar _003C_003E4__this;

			public UserProfile currentUserProfile;

			private TaskAwaiter<UserProfile> _003C_003Eu__1;

			private TaskAwaiter<Sprite> _003C_003Eu__2;

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
		private struct _003CSetupUser_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public Avatar _003C_003E4__this;

			public UserPortal currentAuthenticationPortal;

			public UserProfile currentUserProfile;

			private TaskAwaiter<Sprite> _003C_003Eu__1;

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
		private struct _003CGetCurrentUser_003Ed__14 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<UserProfile> _003C_003Et__builder;

			public UserProfile currentUserProfile;

			private TaskAwaiter<ResultAnd<UserProfile>> _003C_003Eu__1;

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
		private struct _003CDownloadSprite_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Sprite> _003C_003Et__builder;

			public DownloadReference reference;

			private TaskAwaiter<ResultAnd<Texture2D>> _003C_003Eu__1;

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

		[SerializeField]
		public Image Avatar_Main;

		[SerializeField]
		public Image AvatarDownloadBar;

		[Header("Platform Avatar Icons")]
		[SerializeField]
		public Image PlatformIcon_Main;

		[SerializeField]
		public Image PlatformIcon_DownloadQueue;

		[SerializeField]
		public Sprite switchAvatar;

		[SerializeField]
		public Sprite SteamAvatar;

		[SerializeField]
		public Sprite XboxAvatar;

		[SerializeField]
		public Sprite PlayStationAvatar;

		[AsyncStateMachine(typeof(_003CGetSprite_003Ed__8))]
		private Task<Sprite> GetSprite(UserPortal currentAuthenticationPortal, UserProfile currentUserProfile)
		{
			return null;
		}

		public void SetupUser()
		{
		}

		[AsyncStateMachine(typeof(_003CSetupUser_003Ed__10))]
		private void SetupUser(UserPortal currentAuthenticationPortal, UserProfile currentUserProfile)
		{
		}

		private void ShowDefaultAvatar()
		{
		}

		private void PlatformFree(Sprite sprite)
		{
		}

		private void Platform(Sprite sprite)
		{
		}

		[AsyncStateMachine(typeof(_003CGetCurrentUser_003Ed__14))]
		internal Task<UserProfile> GetCurrentUser(UserProfile currentUserProfile)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CDownloadSprite_003Ed__15))]
		private Task<Sprite> DownloadSprite(DownloadReference reference)
		{
			return null;
		}

		internal void UpdateDownloadProgressBar(ProgressHandle handle)
		{
		}
	}
}
