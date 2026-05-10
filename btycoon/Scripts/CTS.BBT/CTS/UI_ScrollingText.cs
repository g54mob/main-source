using System;
using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ScrollingText : CTSBehaviour
	{
		[SerializeField]
		private TMP_Text _textPrefab;

		[SerializeField]
		private int _prefabCount = 1;

		[SerializeField]
		private float _padding;

		[SerializeField]
		private float _speed;

		[SerializeField]
		private bool _prewarm;

		[SerializeField]
		[Inject(false)]
		private RectTransform _textContainer;

		private List<TMP_Text> _texts = new List<TMP_Text>();

		private string _text;

		public string Text
		{
			get
			{
				if (string.IsNullOrEmpty(_text))
				{
					_text = _textPrefab.text;
				}
				return _text;
			}
			set
			{
				_text = value;
				Repaint();
			}
		}

		private void Start()
		{
			if (_prewarm)
			{
				RectTransform rectTransform = _texts[0].rectTransform;
				float width = _textContainer.rect.width;
				rectTransform.anchoredPosition = new Vector2((float)Math.Sign(_speed) * width, rectTransform.anchoredPosition.y);
				AlignTexts();
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Repaint();
		}

		private void Update()
		{
			RectTransform rectTransform = _texts[0].rectTransform;
			rectTransform.anchoredPosition += Vector2.right * (_speed * Time.unscaledDeltaTime);
			float width = _textContainer.rect.width;
			float width2 = rectTransform.rect.width;
			if (Math.Abs(rectTransform.anchoredPosition.x) > width + width2)
			{
				LoopFirstText();
			}
			else
			{
				AlignTexts();
			}
		}

		public void Repaint()
		{
			while (_texts.Count < _prefabCount)
			{
				TMP_Text item = CTSFactory.Instantiate(_textPrefab, _textContainer, instantiateInWorldSpace: false, true);
				_texts.Add(item);
			}
			foreach (TMP_Text text in _texts)
			{
				text.SetText(Text);
			}
			AlignTexts();
		}

		private void AlignTexts()
		{
			RectTransform rectTransform = _texts[0].rectTransform;
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			float width = rectTransform.rect.width;
			float num = Math.Sign(_speed);
			for (int i = 1; i < _texts.Count; i++)
			{
				float x = anchoredPosition.x - num * (width * (float)i + _padding * (float)i);
				_texts[i].rectTransform.anchoredPosition = new Vector2(x, anchoredPosition.y);
			}
		}

		private void LoopFirstText()
		{
			TMP_Text item = _texts[0];
			_texts.RemoveAt(0);
			_texts.Add(item);
			AlignTexts();
		}
	}
}
