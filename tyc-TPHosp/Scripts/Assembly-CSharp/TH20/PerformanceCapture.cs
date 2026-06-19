#define LOG_LEVEL_VERBOSE
using System;
using System.IO;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class PerformanceCapture : MustCallDestroy
	{
		private int _maxRecordedFrames = 18000;

		private int _currentFrameIndex;

		private float[] _frameTimes;

		private bool _recording;

		private Preferences _preferences;

		private LocalPreferences _localPreferences;

		public PerformanceCapture(Preferences preferences, LocalPreferences localPreferences)
		{
			Refresh(preferences, localPreferences);
			ConsoleCommandsDatabase.RegisterCommand("PerfStartRecording", "Start recording performance data", "", Debug_PerfStartRecording);
			ConsoleCommandsDatabase.RegisterCommand("PerfStopAndSaveRecording", "Stop and save the current recorded performance data", "", Debug_PerfStopAndSaveRecording);
			ConsoleCommandsDatabase.RegisterCommand("PerfPrepareSettings", "Change game settings to be best for performance capture", "", Debug_PerfPrepareSettings);
		}

		public void Refresh(Preferences preferences, LocalPreferences localPreferences)
		{
			_preferences = preferences;
			_localPreferences = localPreferences;
		}

		private ConsoleCommandResult Debug_PerfPrepareSettings(params string[] args)
		{
			_preferences.Game.LogLevel = LogLevel.Warning;
			_preferences.Game.LevelAutoSaveFrequency = Preferences.GamePreferences.LevelAutoSaveFrequencyOption.Disabled;
			_preferences.Control.EnableEdgeScrolling = false;
			_localPreferences.Video.QualitySettingsIndex = 4;
			_localPreferences.Video.CustomVSyncCount = 0;
			_localPreferences.Video.MaximumFPS = LocalPreferences.VideoPreferences.MaximumMaximumFPS;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PerfStartRecording(params string[] args)
		{
			if (_frameTimes == null)
			{
				_frameTimes = new float[_maxRecordedFrames];
			}
			Logging.Info("Start Performance Capture");
			_currentFrameIndex = 0;
			_recording = true;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PerfStopAndSaveRecording(params string[] args)
		{
			if (!_recording)
			{
				return ConsoleCommandResult.Failed("No performance data currently being recorded");
			}
			_recording = false;
			string text = Path.Combine(Directories.GameOutputDirectory, "Perf" + Path.DirectorySeparatorChar);
			Directory.CreateDirectory(text);
			SaveCapture(_frameTimes, _currentFrameIndex, text);
			return ConsoleCommandResult.Succeeded($"Performance data saved to {Directories.GameOutputDirectory}");
		}

		private static void SaveCapture(float[] frameTimes, int numOfFrames, string directory)
		{
			string filePath = Path.Combine(directory, "perf-frameTimes.csv");
			SavePerfCaptureFrameTimesCSV(frameTimes, numOfFrames, filePath);
			string filePath2 = Path.Combine(directory, "perf-summary.txt");
			SavePerfCaptureSummary(frameTimes, numOfFrames, filePath2);
		}

		private static void SavePerfCaptureSummary(float[] frameTimes, int numOfFrames, string filePath)
		{
			float num = 0f;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < numOfFrames; i++)
			{
				num += frameTimes[i];
				if (frameTimes[i] > 1f / 60f)
				{
					num2++;
				}
				if (frameTimes[i] > 1f / 30f)
				{
					num3++;
				}
			}
			num /= (float)numOfFrames;
			Array.Sort(frameTimes, 0, numOfFrames);
			float num4 = frameTimes[Mathf.RoundToInt((float)numOfFrames * 0.25f)];
			float num5 = frameTimes[Mathf.RoundToInt((float)numOfFrames * 0.5f)];
			float num6 = frameTimes[Mathf.RoundToInt((float)numOfFrames * 0.75f)];
			float num7 = frameTimes[Mathf.RoundToInt((float)numOfFrames * 0.05f)];
			float num8 = frameTimes[Mathf.RoundToInt((float)numOfFrames * 0.95f)];
			Logging.Info("Saving Performance Capture Summary file {0}", filePath);
			using FileStream stream = File.Create(filePath);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.WriteLine("PercentageOfFramesBelow60fps={0:P2}", (float)num2 / (float)numOfFrames);
			streamWriter.WriteLine("PercentageOfFramesBelow30fps={0:P2}", (float)num3 / (float)numOfFrames);
			streamWriter.WriteLine("MeanFrameTime={0}", 1000f * num);
			streamWriter.WriteLine("MedianFrameTime={0}", 1000f * num5);
			streamWriter.WriteLine("LowerQuartileFrameTime={0}", 1000f * num4);
			streamWriter.WriteLine("UpperQuartileFrameTime={0}", 1000f * num6);
			streamWriter.WriteLine("Percentile05FrameTime={0}", 1000f * num7);
			streamWriter.WriteLine("Percentile95FrameTime={0}", 1000f * num8);
		}

		private static void SavePerfCaptureFrameTimesCSV(float[] frameTimes, int numOfFrames, string filePath)
		{
			Logging.Info("Saving Performance Capture Frame Times CSV file {0}", filePath);
			using FileStream stream = File.Create(filePath);
			using StreamWriter streamWriter = new StreamWriter(stream);
			streamWriter.WriteLine("Frame Number,Frame Time");
			for (int i = 0; i < numOfFrames; i++)
			{
				streamWriter.WriteLine("{0},{1}", i, frameTimes[i]);
			}
		}

		public void Update()
		{
			if (_recording)
			{
				_frameTimes[_currentFrameIndex] = Time.unscaledDeltaTime;
				if (_currentFrameIndex + 1 >= _frameTimes.Length)
				{
					_recording = false;
					string text = Path.Combine(Directories.GameOutputDirectory, "Perf" + Path.DirectorySeparatorChar);
					Directory.CreateDirectory(text);
					SaveCapture(_frameTimes, _currentFrameIndex, text);
				}
				else
				{
					_currentFrameIndex++;
				}
			}
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("PerfStartRecording");
			ConsoleCommandsDatabase.UnRegisterCommand("PerfStopAndSaveRecording");
			ConsoleCommandsDatabase.UnRegisterCommand("PerfPrepareSettings");
			base.Destroy();
		}
	}
}
