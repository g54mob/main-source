using System;
using System.Collections.Generic;
using SharpConfig;
using UnityEngine;

namespace UnityConsole
{
	public class ConsoleInputHistory
	{
		private readonly List<string> _inputHistory;

		public int MaxCapacity;

		private string _consoleHistoryIniPath;

		private const string HistorySectionName = "History";

		private Configuration _userConfig;

		private int _currentInput;

		private bool _isNavigating;

		public ConsoleInputHistory(int maxCapacity)
		{
			_inputHistory = new List<string>(maxCapacity);
			MaxCapacity = maxCapacity;
		}

		public void SetHistoryFilePathAndLoadHistory(string path)
		{
			_consoleHistoryIniPath = path;
			LoadHistory();
		}

		public string Navigate(bool up)
		{
			bool flag = !up;
			if (!_isNavigating)
			{
				_isNavigating = (up && _inputHistory.Count > 0) || (flag && _currentInput > 0);
			}
			else if (up)
			{
				_currentInput++;
			}
			if (flag)
			{
				_currentInput--;
			}
			_currentInput = Mathf.Clamp(_currentInput, 0, _inputHistory.Count - 1);
			if (_isNavigating)
			{
				return _inputHistory[_currentInput];
			}
			return "";
		}

		public void AddNewInputEntry(string input)
		{
			_isNavigating = false;
			_inputHistory.RemoveAll((string s) => s.Equals(input, StringComparison.OrdinalIgnoreCase));
			if (_inputHistory.Count == MaxCapacity)
			{
				_inputHistory.RemoveAt(MaxCapacity - 1);
			}
			_inputHistory.Insert(0, input);
			if (_currentInput == MaxCapacity - 1)
			{
				_currentInput = 0;
			}
			else
			{
				_currentInput = Mathf.Clamp(++_currentInput, 0, _inputHistory.Count - 1);
			}
			if (!input.Equals(_inputHistory[_currentInput], StringComparison.OrdinalIgnoreCase))
			{
				_currentInput = 0;
			}
			SaveHistory();
		}

		public void Clear()
		{
			_inputHistory.Clear();
			_currentInput = 0;
			_isNavigating = false;
		}

		private void LoadHistory()
		{
			if (_consoleHistoryIniPath == null)
			{
				return;
			}
			_userConfig = Configuration.LoadFromFile(_consoleHistoryIniPath);
			if (_userConfig == null)
			{
				return;
			}
			foreach (Setting item in _userConfig["History"])
			{
				_inputHistory.Add(item.StringValue);
			}
		}

		private void SaveHistory()
		{
			if (_consoleHistoryIniPath != null)
			{
				if (_userConfig == null)
				{
					_userConfig = new Configuration();
				}
				Section section = _userConfig["History"];
				for (int i = 0; i < _inputHistory.Count; i++)
				{
					section[$"Entry{i}"].StringValue = _inputHistory[i];
				}
				_userConfig.SaveToFile(_consoleHistoryIniPath);
			}
		}
	}
}
