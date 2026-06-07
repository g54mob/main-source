using System;
using System.Runtime.CompilerServices;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class SystemPlatform : IInitializable, IDisposable, ITickable
	{
		private IBaseAccount m_CurrentSystem;

		private static SystemPlatform sInstance;

		public static SystemPlatformTypes Platform;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private DataManager _dataManager;

		public static IBaseAccount Account => null;

		public static SystemPlatform Instance => null;

		public PlayerOptions PlayerOptions => null;

		public DataManager DataManager => null;

		public static AchievementPlatform CurrentPlatform => default(AchievementPlatform);

		public static event Action OnUpdate
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

		public static event Action OnQuit
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

		private void Update()
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}

		public void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort)
		{
		}
	}
}
