using System;
using JetBrains.Annotations;
using Lexone.UnityTwitchChat;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.Framework
{
	[UsedImplicitly]
	public class TwitchIntegration : IInitializable, IDisposable
	{
		private static TwitchIntegration _sInstance;

		private string _username;

		[Inject]
		private PlayerOptions _playerOptions;

		public string TwitchUsername
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static TwitchIntegration Instance => null;

		public IRC TwitchClient => null;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Init()
		{
		}

		public void Kill()
		{
		}

		public bool IsTwitchOn()
		{
			return false;
		}

		public bool IsTwitchWorking()
		{
			return false;
		}
	}
}
