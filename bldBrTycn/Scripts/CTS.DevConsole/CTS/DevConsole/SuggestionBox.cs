using System.Collections.Generic;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.DevConsole
{
	public class SuggestionBox : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _textBoxPrefab;

		[SerializeField]
		private float _padding = 10f;

		private readonly List<string> _currentSuggestions = new List<string>();

		private RectTransform _inputFieldTransform;

		private RectTransform _content;

		private Image _suggestionHighlight;

		private RectTransform _suggestionHighlightTransform;

		private Vector3[] _inputFieldCorners = new Vector3[4];

		private readonly List<TextMeshProUGUI> _textObjects = new List<TextMeshProUGUI>();

		public string CurrentSuggestion { get; private set; } = "";

		public int CurrentSuggestionIndex { get; private set; }

		public int SuggestionCount => _currentSuggestions.Count;

		private void Awake()
		{
			_inputFieldTransform = (RectTransform)base.transform.parent;
			_suggestionHighlight = base.transform.GetChild(0).GetComponent<Image>();
			_suggestionHighlightTransform = _suggestionHighlight.rectTransform;
			_content = (RectTransform)base.transform.GetChild(1);
			base.gameObject.SetActive(value: false);
		}

		public void UpdateSuggestions(string currentString, List<string> suggestions, List<string> baseTypes)
		{
			EnableSuggestionHighlight(value: false);
			_currentSuggestions.Clear();
			_currentSuggestions.AddRange(suggestions);
			base.gameObject.SetActive(suggestions.Count > 0 || baseTypes.Count > 0);
			int lineIndex;
			if ((suggestions.Count > 0 || baseTypes.Count > 0) && !(currentString == string.Empty))
			{
				_inputFieldTransform.GetLocalCorners(_inputFieldCorners);
				base.transform.localPosition = _inputFieldCorners[1] + new Vector3((float)currentString.Length * _padding, 0f, 0f);
				lineIndex = 0;
				AddLines(suggestions);
				AddLines(baseTypes);
				for (; lineIndex < _textObjects.Count; lineIndex++)
				{
					_textObjects[lineIndex].gameObject.SetActive(value: false);
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				((RectTransform)base.transform).sizeDelta = _content.sizeDelta;
				if (_currentSuggestions.Count > 0)
				{
					SetHighlightIndex(0);
				}
			}
			void AddLines(IEnumerable<string> lines)
			{
				foreach (string line in lines)
				{
					if (lineIndex >= _textObjects.Count)
					{
						_textObjects.Add(Object.Instantiate(_textBoxPrefab, _content));
					}
					_textObjects[lineIndex].text = line;
					_textObjects[lineIndex].gameObject.SetActive(value: true);
					lineIndex++;
				}
			}
		}

		public void EnableSuggestionHighlight(bool value)
		{
			_suggestionHighlight.enabled = value;
		}

		private void SetHighlightIndex(int index)
		{
			EnableSuggestionHighlight(value: true);
			CurrentSuggestionIndex = index.ClampIndex(_currentSuggestions);
			_suggestionHighlightTransform.position = _textObjects[CurrentSuggestionIndex].transform.position;
			_suggestionHighlightTransform.anchoredPosition = new Vector2(0f, _suggestionHighlightTransform.anchoredPosition.y);
			_suggestionHighlightTransform.sizeDelta = new Vector2(-4f, _suggestionHighlightTransform.sizeDelta.y);
			CurrentSuggestion = _currentSuggestions[CurrentSuggestionIndex];
		}

		public void IncrementHighlightIndex(int value)
		{
			CurrentSuggestionIndex += value;
			if (CurrentSuggestionIndex >= _currentSuggestions.Count)
			{
				CurrentSuggestionIndex = 0;
			}
			else if (CurrentSuggestionIndex < 0)
			{
				CurrentSuggestionIndex = _currentSuggestions.Count - 1;
			}
			SetHighlightIndex(CurrentSuggestionIndex);
		}
	}
}
