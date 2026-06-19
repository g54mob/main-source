#define LOG_LEVEL_VERBOSE
using System;
using System.IO;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class LevelStatsCapture : MustCallDestroy
	{
		private FileStream _fileStream;

		private StreamWriter _streamWriter;

		private float _nextMemoryLogTime;

		private CharacterManager _characterManager;

		public LevelStatsCapture(CharacterManager characterManager)
		{
			_characterManager = characterManager;
			ConsoleCommandsDatabase.RegisterCommand("LevelStatsCaptureStartRecording", "Start recording level stats data to file", "", Debug_StartRecording);
		}

		public void Update()
		{
			if (_streamWriter != null)
			{
				_nextMemoryLogTime -= Time.unscaledDeltaTime;
				if (_nextMemoryLogTime < 0f)
				{
					_streamWriter.WriteLine("{0},{1},", DateTime.UtcNow.ToString(), _characterManager.AllCharacters.Count);
					_nextMemoryLogTime += 30f;
				}
			}
		}

		private ConsoleCommandResult Debug_StartRecording(params string[] args)
		{
			string text = Path.Combine(Directories.GameOutputDirectory, "Perf" + Path.DirectorySeparatorChar);
			Directory.CreateDirectory(text);
			string text2 = Path.Combine(text, "levelStats.csv");
			Logging.Info("Saving Performance Capture Summary file {0}", text2);
			if (_fileStream != null)
			{
				_fileStream.Dispose();
			}
			_fileStream = File.Create(text2);
			_streamWriter = new StreamWriter(_fileStream);
			_streamWriter.WriteLine("Date Time, Character Count");
			return ConsoleCommandResult.Succeeded($"Level Stats Capture data saved to {text2}");
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("LevelStatsCaptureStartRecording");
			if (_streamWriter != null)
			{
				_streamWriter.Dispose();
				_streamWriter = null;
			}
			if (_fileStream != null)
			{
				_fileStream.Dispose();
				_fileStream = null;
			}
			base.Destroy();
		}
	}
}
