using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using ModApi;
using ModApi.Levels;
using ModApi.Levels.Scores;
using UnityEngine;

namespace Assets.Scripts.Levels.Scores
{
	public class LevelScoreData : ILevelScoreData
	{
		public const int MaxScoreCount = 10;

		private static char[] _dataSeparator = new char[1] { '|' };

		private static char[] _lineSeparator = new char[1] { '\n' };

		private List<LevelScore> _scores;

		private string _scoresPath;

		public ILevelScoreComparer Comparer { get; }

		public ILevelScoreFormatter Formatter { get; }

		public LevelData LevelData { get; }

		ILevelData ILevelScoreData.LevelData => LevelData;

		public IReadOnlyList<LevelScore> Scores => _scores;

		public bool ShowTopScores { get; }

		public LevelScoreData(LevelData levelData, XElement xml)
		{
			LevelData = levelData;
			ShowTopScores = (bool?)xml?.Attribute("showTopScores") == true;
			Comparer = LoadComparer((string)xml?.Attribute("comparer"));
			Formatter = LoadFormatter((string)xml?.Attribute("formatter"), (string)xml?.Attribute("formatterArg"));
			_scores = new List<LevelScore>(11);
			_scoresPath = Utilities.CombinePaths(Game.PersistentDataPath, "UserData/Levels/Scores/", LevelData.Id);
		}

		public void LoadScores()
		{
			try
			{
				if (!File.Exists(_scoresPath))
				{
					return;
				}
				string text = File.ReadAllText(_scoresPath);
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				text = Meh(text);
				string[] array = text.Split(_lineSeparator, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(_dataSeparator);
					if (array2.Length != 2)
					{
						Debug.LogError("Invalid data encountered while reading scores for level '" + LevelData.Id + "'.");
						return;
					}
					float score = DataIO.ParseFloat(array2[0]);
					DateTime dateTime = new DateTime(DataIO.ParseLong(array2[1]), DateTimeKind.Utc).ToLocalTime();
					LevelScore item = new LevelScore(score, dateTime);
					_scores.Add(item);
					if (_scores.Count == 10)
					{
						break;
					}
				}
				_scores.Sort(Comparer);
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred loading scores for level '" + LevelData.Id + "'.");
				Debug.LogException(exception);
				_scores.Clear();
			}
		}

		public void LogScore(LevelScore score)
		{
			_scores.Add(score);
			_scores.Sort(Comparer);
			if (_scores.Count > 10)
			{
				_scores.RemoveRange(10, _scores.Count - 10);
			}
			SaveScores();
		}

		private static ILevelScoreComparer LoadComparer(string comparer)
		{
			ILevelScoreComparer levelScoreComparer = null;
			if (string.Equals(comparer, "DefaultAscending", StringComparison.OrdinalIgnoreCase))
			{
				levelScoreComparer = LevelScoreComparer.AscendingComparer;
			}
			else if (string.Equals(comparer, "DefaultDescending", StringComparison.OrdinalIgnoreCase))
			{
				levelScoreComparer = LevelScoreComparer.DescendingComparer;
			}
			else if (!string.IsNullOrEmpty(comparer))
			{
				try
				{
					Type type = Type.GetType(comparer, throwOnError: false, ignoreCase: false);
					if (type != null)
					{
						levelScoreComparer = (ILevelScoreComparer)Activator.CreateInstance(type);
					}
					else
					{
						Debug.LogError("Score comparer could not be found '" + comparer + "'");
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred trying to load score comparer '" + comparer + "'.");
					Debug.LogException(exception);
				}
			}
			return levelScoreComparer ?? LevelScoreComparer.AscendingComparer;
		}

		private static ILevelScoreFormatter LoadFormatter(string formatter, string formatterArg)
		{
			if (formatter == "Default" || formatter == "default")
			{
				formatter = typeof(LevelScoreFormatterDefault).Name;
			}
			return LoadFormatterByTypeName(typeof(LevelScoreFormatterDefault).Namespace + "." + formatter, formatterArg) ?? LoadFormatterByTypeName(formatter, formatterArg) ?? new LevelScoreFormatterDefault();
		}

		private static ILevelScoreFormatter LoadFormatterByTypeName(string fullyQualifiedTypeName, string formatterArg)
		{
			if (!string.IsNullOrWhiteSpace(fullyQualifiedTypeName))
			{
				try
				{
					Type type = Type.GetType(fullyQualifiedTypeName, throwOnError: false, ignoreCase: false);
					if (type != null)
					{
						return (ILevelScoreFormatter)((formatterArg == null) ? Activator.CreateInstance(type) : Activator.CreateInstance(type, formatterArg));
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred trying to load score formatter '" + fullyQualifiedTypeName + "'.");
					Debug.LogException(exception);
				}
			}
			return null;
		}

		private string Meh(string input)
		{
			string fullName = typeof(Game).FullName;
			StringBuilder stringBuilder = new StringBuilder(input.Length);
			for (int i = 0; i < input.Length; i++)
			{
				stringBuilder.Append((char)(input[i] ^ fullName[i % fullName.Length]));
			}
			return stringBuilder.ToString();
		}

		private void SaveScores()
		{
			try
			{
				FileInfo fileInfo = new FileInfo(_scoresPath);
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (LevelScore score in _scores)
				{
					stringBuilder.Append(score.Score);
					stringBuilder.Append(_dataSeparator[0]);
					stringBuilder.Append(score.DateTime.ToUniversalTime().Ticks);
					stringBuilder.Append(_lineSeparator[0]);
				}
				string contents = Meh(stringBuilder.ToString());
				File.WriteAllText(_scoresPath, contents);
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred saving scores for level '" + LevelData.Id + "'.");
				Debug.LogException(exception);
			}
		}
	}
}
