using System;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Loading
{
	public class MainMenuLoader : IInitializable
	{
		private static DataManager _dataManager;

		private static PlayerOptions _playerOptions;

		public const string CACHE_GROUP_NAME = "MainMenu";

		[Inject]
		private void Construct(DataManager dataManager, PlayerOptions playerOptions)
		{
		}

		public void Initialize()
		{
		}

		public static void Load(Action onComplete)
		{
		}

		private static void LoadAlbumArt(AsyncLoader loader)
		{
		}

		public static void Release(Action onComplete)
		{
		}
	}
}
