using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Factory;
using JetBrains.Annotations;
using Screens;

namespace Motorways.Views
{
	public static class SaveToolUtilities
	{
		public static readonly List<ArchivedSavedGame> BookmarkedSavedGames = new List<ArchivedSavedGame>();

		public static readonly List<ArchivedSavedGame> AutomaticSavedGames = new List<ArchivedSavedGame>();

		private const string BookmarkedSaveStringDelimiter = ",";

		private const string BookmarkedGamesEditorPrefsId = "SaveGameTool-BookmarkedSaveGames";

		public static void BookmarkSavedGame(string savedGameName, MotorwaysGameJournalSave savedGame)
		{
			savedGameName = MakeValidFileName(savedGameName);
			string fullPath = Diagnostics.File.GetFullPath(savedGameName + ".gamejournal");
			using FileStream output = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write);
			using BinaryWriter binaryWriter = new BinaryWriter(output);
			savedGame.OnSerializeBeforeData(binaryWriter);
			binaryWriter.Write(savedGame.GetBytesForSerializing());
			BookmarkedSavedGames.Add(new ArchivedSavedGame(fullPath, savedGame));
			AddBookmark(savedGameName);
			SortBookmarkedSavedGames();
		}

		public static void DeleteArchivedSavedGame(ArchivedSavedGame archivedSavedGame)
		{
			if (BookmarkedSavedGames.Remove(archivedSavedGame) && !string.IsNullOrEmpty(archivedSavedGame.Name))
			{
				RemoveBookmark(archivedSavedGame.Name);
			}
			AutomaticSavedGames.Remove(archivedSavedGame);
			archivedSavedGame.Release();
			archivedSavedGame.Delete();
		}

		public static void DeleteAllArchivedSavedGames()
		{
			DeleteAllAutomaticSavedGames();
			DeleteAllBookmarkedSavedGames();
		}

		public static void DeleteAllAutomaticSavedGames()
		{
			foreach (ArchivedSavedGame automaticSavedGame in AutomaticSavedGames)
			{
				automaticSavedGame.Release();
				automaticSavedGame.Delete();
			}
			AutomaticSavedGames.Clear();
		}

		private static void DeleteAllBookmarkedSavedGames()
		{
			foreach (ArchivedSavedGame bookmarkedSavedGame in BookmarkedSavedGames)
			{
				bookmarkedSavedGame.Release();
				bookmarkedSavedGame.Delete();
			}
			BookmarkedSavedGames.Clear();
			RemoveAllBookmarks();
		}

		public static void LoadSavedGameLibrary(IScope appScope)
		{
			BookmarkedSavedGames.ForEach(delegate(ArchivedSavedGame savedGame)
			{
				savedGame.Release();
			});
			BookmarkedSavedGames.Clear();
			AutomaticSavedGames.ForEach(delegate(ArchivedSavedGame savedGame)
			{
				savedGame.Release();
			});
			AutomaticSavedGames.Clear();
			HashSet<string> hashSet = new HashSet<string>(LoadBookmarks());
			if (Directory.Exists(Diagnostics.File.Path))
			{
				foreach (string item in Directory.EnumerateFiles(Diagnostics.File.Path))
				{
					if (item.EndsWith(".DS_Store", StringComparison.InvariantCultureIgnoreCase))
					{
						continue;
					}
					ArchivedSavedGame archivedSavedGame = ArchivedSavedGame.Load(item, appScope);
					if (archivedSavedGame != null)
					{
						if (hashSet.Contains(archivedSavedGame.Name))
						{
							hashSet.Remove(item);
							BookmarkedSavedGames.Add(archivedSavedGame);
						}
						else
						{
							AutomaticSavedGames.Add(archivedSavedGame);
						}
					}
				}
			}
			SortBookmarkedSavedGames();
			SortAutomaticSavedGames();
		}

		public static void StartGame(MotorwaysGameJournalSave save, bool startGamePaused, IScope scope, ref GameStarter gameStarter)
		{
			ScreenStack screenStack = scope.Get<ScreenStack>();
			GameContainerScreen activeScreen = screenStack.GetActiveScreen<GameContainerScreen>();
			if (activeScreen != null && activeScreen.GetActiveGame() != null)
			{
				activeScreen.GetActiveGame().OnGameEnd(GameEndReason.Exit);
			}
			BaseScalingScreen baseScalingScreen = screenStack.GetTopVisibleScreen() as BaseScalingScreen;
			if (baseScalingScreen != null)
			{
				baseScalingScreen.SkipNextTransition();
			}
			if (!screenStack.IsScreenActive<MainMenuScreen>())
			{
				screenStack.ReplaceScreens<MainMenuScreen>(ScreenStack.MotorwaysScreen.MainMenu, typeof(GameContainerScreen));
			}
			else if (screenStack.GetTopActiveScreenType() != ScreenStack.MotorwaysScreen.MainMenu)
			{
				screenStack.PopToScreenOfType(ScreenStack.MotorwaysScreen.MainMenu);
			}
			MainMenuScreen activeScreen2 = screenStack.GetActiveScreen<MainMenuScreen>();
			if (gameStarter == null)
			{
				gameStarter = new GameStarter(activeScreen2);
			}
			MapDatabase mapDatabase = scope.Get<MapDatabase>();
			gameStarter.StartFromSavedGame(mapDatabase.MapLibrary, save, replaceTopScreen: false, skipNextTransition: true, startGamePaused);
		}

		private static string MakeValidFileName(string name)
		{
			string arg = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
			string pattern = string.Format("([{0}]*\\.+$)|([{0}]+)|(\\,)", arg);
			return Regex.Replace(name, pattern, "_");
		}

		private static void SortBookmarkedSavedGames()
		{
			BookmarkedSavedGames.Sort((ArchivedSavedGame a, ArchivedSavedGame b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
		}

		private static void SortAutomaticSavedGames()
		{
			AutomaticSavedGames.Sort(delegate(ArchivedSavedGame a, ArchivedSavedGame b)
			{
				int num = string.Compare(a.SavedGame.CityId, b.SavedGame.CityId, StringComparison.Ordinal);
				if (num != 0)
				{
					return num;
				}
				num = a.SavedGame.TimeElapsed.CompareTo(b.SavedGame.TimeElapsed);
				return (num != 0) ? num : a.SavedGame.TripCount.CompareTo(b.SavedGame.TripCount);
			});
		}

		private static void AddBookmark(string name)
		{
		}

		private static void RemoveBookmark(string name)
		{
		}

		[NotNull]
		private static string[] LoadBookmarks()
		{
			return new string[0];
		}

		private static void RemoveAllBookmarks()
		{
		}
	}
}
