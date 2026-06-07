using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using AOT;
using Gh.Tk;
using Steamworks;
using UnityEngine;

namespace Gh
{
	[DisallowMultipleComponent]
	public class SteamManager : SingletonMonoBehaviour<SteamManager>
	{
		[CompilerGenerated]
		private sealed class _003CGetAllFilesFromCloudStorage_003Ed__38 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private int _003Ccount_003E5__2;

			private int _003Ci_003E5__3;

			string IEnumerator<string>.Current
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
			public _003CGetAllFilesFromCloudStorage_003Ed__38(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		protected static bool s_EverInitialized;

		protected bool m_bInitialized;

		protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

		private static readonly AppId_t _devCommentaryAppId;

		private static readonly AppId_t _appId;

		private static Action _onOverlayDisabledAction;

		private static readonly AppId_t _gameDevTycoonAppId;

		protected Callback<GameOverlayActivated_t> _gameOverlayActivated;

		private static bool _statsReady;

		private static Callback<UserStatsReceived_t> _onStats;

		public static bool Initialized => false;

		public static event EventHandler<EventArgs<bool>> GameOverlayToggled
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

		[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
		protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
		{
		}

		public override void Awake()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDestroy()
		{
		}

		protected void Update()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitOnPlayMode()
		{
		}

		public static void Init()
		{
		}

		private static uint GetAppId()
		{
			return 0u;
		}

		public static bool IsDevCommentaryDLCInstalled()
		{
			return false;
		}

		private bool AllowInitialize()
		{
			return false;
		}

		private void OnInitialized()
		{
		}

		public static string GetAuthTicket()
		{
			return null;
		}

		private static void OnPlayerProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private static void OnSteamOverlayToggled(object sender, EventArgs<bool> e)
		{
		}

		public static bool DoesCurrentUserOwnGameDevTycoon()
		{
			return false;
		}

		public static ulong GetUserSteamId()
		{
			return 0uL;
		}

		public static string GetPlayerName()
		{
			return null;
		}

		public static string GetLanguage()
		{
			return null;
		}

		private void AfterOnEnable()
		{
		}

		private void CreateCallbacks()
		{
		}

		private void OnGameOverlayActivated(GameOverlayActivated_t param)
		{
		}

		public bool EnsureCloudSupport()
		{
			return false;
		}

		public void MakeCopyOfLocalDataFile(string filePath)
		{
		}

		public void SaveTextToCloud(string fileName, string contents)
		{
		}

		public string LoadTextFromCloud(string fileName)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllFilesFromCloudStorage_003Ed__38))]
		public IEnumerable<string> GetAllFilesFromCloudStorage()
		{
			return null;
		}

		public static void UpdateRichPresence(string status)
		{
		}

		public static void ClearRichPresence()
		{
		}

		private static void InitAchievements()
		{
		}

		private static void OnUserStatsReceived(UserStatsReceived_t e)
		{
		}

		private static bool EnsureAchievementsReady()
		{
			return false;
		}

		public static void TriggerSteamAchievement(string achievementId)
		{
		}

		public static void ClearAchievement(string achievementId)
		{
		}

		public static void SyncSteamAchievements()
		{
		}
	}
}
