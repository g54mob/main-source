using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.JSON;
using TMPro;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class TextWidget : BaseWidget
	{
		internal class Parameters : BaseParameters
		{
			public string Text { get; private set; }

			public LocalizedString LocalizedString { get; private set; }

			public string Term { get; private set; }

			public Dictionary<InputFlags, string> InputTerms { get; private set; }

			public Parameters(Dictionary<string, object> parameters)
			{
				if (JSONExtensions.TryReturnParameter<string>(parameters, "text", out var parameter))
				{
					Term = parameter;
					return;
				}
				if (JSONExtensions.TryReturnParameter<Dictionary<string, object>>(parameters, "input_terms", out var parameter2))
				{
					InputTerms = ParseInputTerms(parameter2);
					return;
				}
				throw new NotImplementedException("Text Widget must have Text.");
			}

			public Parameters(string text)
			{
				Text = text;
			}

			public Parameters(LocalizedString localizedString)
			{
				LocalizedString = localizedString;
			}

			public bool TryGetTerm(out string term)
			{
				term = Term;
				if (string.IsNullOrEmpty(term) && !InputTerms.IsNullOrEmpty())
				{
					foreach (KeyValuePair<InputFlags, string> inputTerm in InputTerms)
					{
						if (FlotsamInputManager.HasActiveInput(inputTerm.Key))
						{
							term = inputTerm.Value;
							break;
						}
					}
				}
				if (string.IsNullOrEmpty(term))
				{
					term = LocalizedString.mTerm;
				}
				return !string.IsNullOrEmpty(term);
			}

			private Dictionary<InputFlags, string> ParseInputTerms(Dictionary<string, object> data)
			{
				Dictionary<InputFlags, string> dictionary = new Dictionary<InputFlags, string>();
				foreach (KeyValuePair<string, object> datum in data)
				{
					if (Enum.TryParse<InputFlags>(datum.Key, out var result))
					{
						dictionary.Add(result, datum.Value as string);
					}
				}
				return dictionary;
			}
		}

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Localize _localize;

		private Parameters _data;

		private bool _updateInputTerm;

		private void OnEnable()
		{
			if (_updateInputTerm)
			{
				SetInputTerm();
				_updateInputTerm = false;
			}
		}

		private void OnDestroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		}

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters data))
			{
				Debug.LogException(new NotImplementedException());
				return;
			}
			_data = data;
			if (_data.TryGetTerm(out var term))
			{
				SetTerm(term);
				if (!_data.InputTerms.IsNullOrEmpty())
				{
					GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
				}
			}
			else
			{
				_text.text = _data.Text;
			}
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(parameters);
		}

		private void OnActiveInputUpdated(GameEvent gameEvent)
		{
			if (base.enabled)
			{
				SetInputTerm();
			}
			else
			{
				_updateInputTerm = true;
			}
		}

		private void SetInputTerm()
		{
			if (_data == null || _data.InputTerms.IsNullOrEmpty())
			{
				return;
			}
			foreach (KeyValuePair<InputFlags, string> inputTerm in _data.InputTerms)
			{
				if (FlotsamInputManager.HasActiveInput(inputTerm.Key))
				{
					SetTerm(inputTerm.Value);
					break;
				}
			}
		}

		private void SetTerm(string term)
		{
			if ((bool)_localize && _localize.Term != term)
			{
				_localize.SetTerm(term);
			}
		}
	}
}
