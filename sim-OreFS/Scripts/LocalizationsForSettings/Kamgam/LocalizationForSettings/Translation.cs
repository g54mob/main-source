using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.LocalizationForSettings
{
	[Serializable]
	public class Translation : ITranslation
	{
		[SerializeField]
		[HideInInspector]
		protected string _term;

		[SerializeField]
		[HideInInspector]
		protected List<string> _texts = new List<string>();

		public Translation(string term, int languageCount)
		{
			_term = term;
			_texts = new List<string>();
			for (int i = 0; i < languageCount; i++)
			{
				_texts.Add("");
			}
		}

		public Translation(string term, List<string> texts)
		{
			_term = term;
			_texts = texts;
		}

		public string GetTerm()
		{
			return _term;
		}

		public bool HasText(int languageIndex)
		{
			if (_texts != null && _texts.Count != 0 && languageIndex >= 0)
			{
				return languageIndex <= _texts.Count - 1;
			}
			return false;
		}

		public string GetText(int languageIndex)
		{
			if (!HasText(languageIndex))
			{
				return _term;
			}
			return _texts[languageIndex];
		}

		public void SetText(int languageIndex, string text)
		{
			if (_texts == null || text == null)
			{
				return;
			}
			if (languageIndex < 0)
			{
				_texts.Add(text);
				return;
			}
			if (languageIndex > _texts.Count - 1)
			{
				while (_texts.Count - 1 < languageIndex)
				{
					_texts.Add(null);
				}
			}
			_texts[languageIndex] = text;
		}

		public void ClearTexts()
		{
			_texts.Clear();
		}
	}
}
