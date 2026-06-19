#define LOG_LEVEL_VERBOSE
using System;
using System.IO;
using System.Text;

namespace TH20
{
	public class FileLogHandler : ILogHandler
	{
		private readonly LoggerConfig _config;

		private StreamWriter _fileStreamWriter;

		private readonly StringBuilder _stringBuilder;

		private string _logFileSpec;

		public LogLevel LogLevelToPrintCallstacks = LogLevel.Error;

		public string OutputDirectory => Path.Combine(Directories.GameOutputDirectory, _config.LogFileSubdirectory);

		public string LogFileSpec => _logFileSpec;

		public FileLogHandler(LoggerConfig config)
		{
			_config = config;
			string commandLineOption = GetCommandLineOption("logfilepath");
			if (commandLineOption == null)
			{
				string outputDirectory = OutputDirectory;
				FileUtils.EnsureDirectoryExists(outputDirectory);
				DeleteOldLogFiles(outputDirectory);
				string path = $"{_config.LogFileNamePrefix}{TimeUtils.NowSafe().ToString(_config.LogFileNameDateFormat)}{_config.LogFileNameExtension}";
				_logFileSpec = Path.Combine(outputDirectory, path);
				_fileStreamWriter = File.CreateText(_logFileSpec);
			}
			else
			{
				_logFileSpec = commandLineOption;
				_fileStreamWriter = File.CreateText(_logFileSpec);
			}
			_fileStreamWriter.AutoFlush = true;
			_stringBuilder = new StringBuilder();
		}

		private static string GetCommandLineOption(string name)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			int num = Array.FindIndex(commandLineArgs, (string x) => x.ToLower().StartsWith("-" + name));
			if (num >= 0)
			{
				if (num + 1 < commandLineArgs.Length)
				{
					return commandLineArgs[num + 1].Replace("\"", "").Trim();
				}
				Logging.Warning("Command line argument {0} needs following path argument", name);
			}
			return null;
		}

		private void DeleteOldLogFiles(string directory)
		{
			string[] files = Directory.GetFiles(directory, _config.LogFileNamePrefix + "*", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fileInfo = new FileInfo(files[i]);
				if (fileInfo.Exists)
				{
					DateTime creationTimeUtc = fileInfo.CreationTimeUtc;
					if (DateTime.UtcNow - creationTimeUtc > _config.TimeToKeepLogFiles)
					{
						FileUtils.TryDeleteFileIfExists(fileInfo.FullName);
					}
				}
			}
		}

		[StackTraceIgnore]
		public void Log(LogEntry logEntry)
		{
			if (_fileStreamWriter == null)
			{
				return;
			}
			_stringBuilder.Length = 0;
			_stringBuilder.Append(logEntry.TimeFormatted);
			_stringBuilder.Append("|");
			_stringBuilder.Append(logEntry.FrameCount);
			_stringBuilder.Append("|");
			_stringBuilder.Append(LogLevelHelpers.To4CharString(logEntry.Level));
			_stringBuilder.Append("|");
			if (logEntry.Channel != null)
			{
				_stringBuilder.Append(logEntry.Channel.Name);
			}
			_stringBuilder.Append("|");
			_stringBuilder.Append(logEntry.Message);
			string value = _stringBuilder.ToString();
			try
			{
				_fileStreamWriter.WriteLine(value);
				if (RequestsCallstackAtLevel(logEntry.Level))
				{
					_fileStreamWriter.WriteLine(LogCallStack.CallStackToString(logEntry.CallStack));
				}
			}
			catch (IOException)
			{
				_fileStreamWriter.Close();
				_fileStreamWriter.Dispose();
				_fileStreamWriter = null;
			}
			catch (ObjectDisposedException)
			{
				_fileStreamWriter = null;
			}
		}

		public bool RequestsCallstackAtLevel(LogLevel logLevel)
		{
			if (logLevel >= LogLevelToPrintCallstacks)
			{
				return logLevel != LogLevel.AlwaysLog;
			}
			return false;
		}
	}
}
