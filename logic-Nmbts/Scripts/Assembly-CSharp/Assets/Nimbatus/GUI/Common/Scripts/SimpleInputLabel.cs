using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class SimpleInputLabel : SerializedMonoBehaviour
	{
		public delegate void OnSubmitHandler(string text);

		public string CurrentText;

		private UILabel _label;

		public int NumberOfChars;

		public bool ChangeColorOnSelect;

		public Color SelectColor;

		private List<AutoCompletionItem> _autoCompletionContainers;

		private bool _firstChar;

		private string _originalText;

		private Color _originalColor;

		private bool _listen;

		private float _lastBackspaceTime = -100f;

		private List<string> _autoCompletionItems = new List<string>();

		private int _selectedAutoCompletionIndex = -1;

		private int _availableResults;

		private float _lastUnderlineTime;

		public event OnSubmitHandler OnSubmit;

		public void Start()
		{
			_label = GetComponent<UILabel>();
			_originalText = "Enter Tag Here";
			_originalColor = _label.color;
			CurrentText = _originalText;
			_listen = false;
			_autoCompletionContainers = GetComponentsInChildren<AutoCompletionItem>().ToList();
			FillupAutoCompletion();
		}

		public void SetAutoCompletionList(List<string> items)
		{
			_autoCompletionItems = items;
		}

		private void FillupAutoCompletion()
		{
			string text = CurrentText.ToUpper();
			List<string> list = _autoCompletionItems.FindAll((string s) => s.StartsWith(text));
			_availableResults = list.Count;
			for (int num = 0; num < _autoCompletionContainers.Count; num++)
			{
				if (list.Count > num)
				{
					_autoCompletionContainers[num].Init(this, list[num]);
				}
				else
				{
					_autoCompletionContainers[num].Init(this, "");
				}
			}
		}

		public void Reset()
		{
			CurrentText = _originalText;
			_label.text = _originalText;
			_label.color = _originalColor;
			for (int i = 0; i < _autoCompletionContainers.Count; i++)
			{
				_autoCompletionContainers[i].Init(this, "");
			}
			_listen = false;
		}

		public void StartListen()
		{
			if (ChangeColorOnSelect)
			{
				_label.color = SelectColor;
			}
			_firstChar = true;
			_listen = true;
		}

		public void StopListen()
		{
			_label.color = _originalColor;
			_firstChar = true;
			_listen = false;
		}

		protected void OnSelect(bool isSelected)
		{
			if (isSelected && DragAndDropHelper.DraggedItem == null)
			{
				StartListen();
			}
		}

		private void DoBackspace()
		{
			CurrentText = RemoveLastChar(CurrentText);
			FillupAutoCompletion();
		}

		private void DeleteText()
		{
			CurrentText = "";
			FillupAutoCompletion();
		}

		public void ResetAutoCompletion()
		{
			_selectedAutoCompletionIndex = -1;
			for (int i = 0; i < _autoCompletionContainers.Count; i++)
			{
				if (_selectedAutoCompletionIndex == i)
				{
					_autoCompletionContainers[i].SetSelected(true);
				}
				else
				{
					_autoCompletionContainers[i].SetSelected(false);
				}
			}
		}

		public void Update()
		{
			if (TagInputPopup.Instance != null && !TagInputPopup.Instance.IsShown)
			{
				return;
			}
			if (Time.time - _lastBackspaceTime > 0.1f && Input.GetKey(KeyCode.Backspace))
			{
				DoBackspace();
				_lastBackspaceTime = Time.time;
			}
			else if (Input.GetKeyDown(KeyCode.Backspace))
			{
				DoBackspace();
				_lastBackspaceTime = Time.time;
			}
			if (Input.GetKey(KeyCode.Delete))
			{
				DeleteText();
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				_selectedAutoCompletionIndex++;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				_selectedAutoCompletionIndex--;
			}
			if (_listen && Time.time - _lastUnderlineTime > 0.5f)
			{
				_label.text = CurrentText + "_";
				if (Time.time - _lastUnderlineTime >= 1f)
				{
					_lastUnderlineTime = Time.time;
				}
			}
			else
			{
				_label.text = CurrentText;
			}
			_selectedAutoCompletionIndex = Mathf.Clamp(_selectedAutoCompletionIndex, -1, _availableResults - 1);
			for (int i = 0; i < _autoCompletionContainers.Count; i++)
			{
				_autoCompletionContainers[i].SetSelected(_selectedAutoCompletionIndex == i);
			}
			if (Input.GetKeyDown(KeyCode.Return))
			{
				if (_selectedAutoCompletionIndex >= 0)
				{
					_autoCompletionContainers[_selectedAutoCompletionIndex].OnClick();
					_selectedAutoCompletionIndex = -1;
				}
				else
				{
					StopListen();
					if (this.OnSubmit != null)
					{
						this.OnSubmit(CurrentText);
					}
					UICamera.selectedObject = null;
				}
			}
			if (!_listen)
			{
				return;
			}
			string text = Validate(NGUIText.StripSymbols(Input.inputString));
			if (!string.IsNullOrEmpty(text))
			{
				if (_firstChar)
				{
					CurrentText = "";
					_firstChar = false;
				}
				if (CurrentText.Length <= NumberOfChars)
				{
					CurrentText += text;
					FillupAutoCompletion();
				}
			}
		}

		public string RemoveLastChar(string val)
		{
			if (string.IsNullOrEmpty(val))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(val.Length);
			for (int i = 0; i < val.Length - 1; i++)
			{
				char value = val[i];
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		public string Validate(string val)
		{
			if (string.IsNullOrEmpty(val))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(val.Length);
			for (int i = 0; i < val.Length; i++)
			{
				char c = val[i];
				if (c != '\b' && c != '\r')
				{
					c = ValidateChar(c);
					if (c != 0)
					{
						stringBuilder.Append(c);
					}
				}
			}
			return stringBuilder.ToString();
		}

		public char ValidateChar(char ch)
		{
			return ch;
		}

		public void SetOriginalText(string text)
		{
			_label.text = (_originalText = (CurrentText = text));
		}
	}
}
