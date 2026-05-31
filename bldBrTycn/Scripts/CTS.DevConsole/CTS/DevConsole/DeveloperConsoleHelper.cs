using System.Collections.Generic;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;

namespace CTS.DevConsole
{
	public class DeveloperConsoleHelper : MonoBehaviour
	{
		private DeveloperConsole _consoleRef;

		private TMP_InputField _inputFieldRef;

		[SerializeField]
		private TextMeshProUGUI _textObject;

		[SerializeField]
		private SuggestionBox _suggestionBox;

		[SerializeField]
		private int _maxHistory = 10;

		[SerializeField]
		private float _keyDownCooldown = 1f;

		[SerializeField]
		private float _keyDownUpdate = 0.5f;

		private static readonly List<string> History = new List<string>();

		private int _currentHistoryIndex = int.MaxValue;

		private DeveloperConsole.InputReport _currentInputReport;

		private readonly List<string> _emptyList = new List<string>();

		private float _nextKeyDownUpdate;

		private void Awake()
		{
			_inputFieldRef = base.transform.GetComponentInParent<TMP_InputField>();
			_consoleRef = _inputFieldRef.GetComponentInParent<DeveloperConsole>();
		}

		private void OnEnable()
		{
			RegisterEvents();
			DeveloperConsole.OnConsoleOpen += OnConsoleOpen;
			_textObject.color = Color.white;
		}

		private void OnDisable()
		{
			DeveloperConsole.OnConsoleOpen -= OnConsoleOpen;
			UnregisterEvents();
		}

		private void Update()
		{
			if ((bool)_consoleRef && _consoleRef.enabled)
			{
				TryIncrementSuggestion();
				TrySelectSuggestion();
			}
			void TryIncrementSuggestion()
			{
				if (_inputFieldRef.isFocused)
				{
					if (Input.GetKeyDown(KeyCode.UpArrow))
					{
						OnKeyUp(1);
					}
					else if (Input.GetKeyDown(KeyCode.DownArrow))
					{
						OnKeyUp(-1);
					}
					if (!(Time.unscaledTime < _nextKeyDownUpdate) && _suggestionBox.SuggestionCount > 0)
					{
						if (Input.GetKey(KeyCode.UpArrow))
						{
							SuggestionIncrement(-1);
						}
						else if (Input.GetKey(KeyCode.DownArrow))
						{
							SuggestionIncrement(1);
						}
					}
				}
			}
			void TrySelectSuggestion()
			{
				if (Input.GetKeyDown(KeyCode.Tab))
				{
					if (!_inputFieldRef.isFocused)
					{
						_inputFieldRef.Select();
						_inputFieldRef.ActivateInputField();
					}
					else if (_suggestionBox.SuggestionCount > 0)
					{
						UnregisterEvents();
						_inputFieldRef.text = _currentInputReport.FullValidInput + _suggestionBox.CurrentSuggestion;
						_inputFieldRef.MoveToEndOfLine(shift: false, ctrl: false);
						RegisterEvents();
					}
				}
			}
		}

		private void OnConsoleOpen(bool value)
		{
			_currentHistoryIndex = int.MaxValue;
			_currentHistoryIndex = int.MaxValue;
		}

		private void OnConsoleRefInputSubmit(string command)
		{
			_currentHistoryIndex = int.MaxValue;
			History.Add(command);
			if (History.Count > _maxHistory)
			{
				History.RemoveAt(0);
			}
		}

		private void SuggestionIncrement(int increment)
		{
			_inputFieldRef.MoveToEndOfLine(shift: false, ctrl: false);
			_suggestionBox.IncrementHighlightIndex(increment);
			_nextKeyDownUpdate = Time.unscaledTime + _keyDownUpdate;
		}

		private void OnKeyUp(int historyAdd)
		{
			if (_suggestionBox.SuggestionCount > 0)
			{
				SuggestionIncrement(-historyAdd);
			}
			else
			{
				if (History.Count <= 0)
				{
					return;
				}
				_currentHistoryIndex = (_currentHistoryIndex - historyAdd).ClampIndex(History);
				UnregisterEvents();
				_inputFieldRef.text = History[_currentHistoryIndex];
				_inputFieldRef.MoveToEndOfLine(shift: false, ctrl: false);
				RegisterEvents();
			}
			_nextKeyDownUpdate = Time.unscaledTime + _keyDownCooldown;
		}

		public void RegisterEvents()
		{
			_inputFieldRef.onValueChanged.AddListener(OnInputFieldUpdate);
			_consoleRef.OnInputSubmit += OnConsoleRefInputSubmit;
		}

		public void UnregisterEvents()
		{
			_inputFieldRef.onValueChanged.RemoveListener(OnInputFieldUpdate);
			_consoleRef.OnInputSubmit -= OnConsoleRefInputSubmit;
		}

		private void OnInputFieldUpdate(string input)
		{
			DeveloperConsole.InputReport inputReport = (_currentInputReport = _consoleRef.CheckValidityOfInput(input));
			TextMeshProUGUI textObject = _textObject;
			textObject.color = inputReport.Validity switch
			{
				EValidity.Empty => Color.white, 
				EValidity.Invalid => Color.red, 
				EValidity.Incomplete => Color.yellow, 
				EValidity.Valid => Color.green, 
				_ => _textObject.color, 
			};
			List<string> list = new List<string>(inputReport.CommandMatches ?? _emptyList);
			if (inputReport.CommandArgMatches != null)
			{
				list.AddRange(inputReport.CommandArgMatches);
			}
			_suggestionBox.UpdateSuggestions(inputReport.FullValidInput, list, inputReport.CommandHelpers ?? _emptyList);
		}
	}
}
