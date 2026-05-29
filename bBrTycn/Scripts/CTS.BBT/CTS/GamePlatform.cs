using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class GamePlatform : CTSSingleton<GamePlatform>
	{
		private class DummyPlatform : IPlatformUser, IPlatformLibrary
		{
			public string GetUserID()
			{
				return "nil";
			}

			public bool IsDLCInstalled(StringKey dlcName)
			{
				return false;
			}

			public bool TryAuthenticateGame()
			{
				return false;
			}
		}

		[SerializeField]
		private List<GamePlatformResources> _platforms = new List<GamePlatformResources>();

		[SerializeField]
		private bool _authenticateGame;

		public IPlatformUser User { get; private set; }

		public IPlatformLibrary Library { get; private set; }

		private void Construct()
		{
			foreach (GamePlatformResources platform in _platforms)
			{
				if (platform.IsCurrentPlatform())
				{
					User = platform.GetUser();
					Library = platform.GetLibrary();
					return;
				}
			}
			DummyPlatform library = (DummyPlatform)(User = new DummyPlatform());
			Library = library;
		}

		protected override void SingletonAwake()
		{
		}

		private void Start()
		{
			if (_authenticateGame && (Library == null || !Library.TryAuthenticateGame()))
			{
				Application.Quit();
			}
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
