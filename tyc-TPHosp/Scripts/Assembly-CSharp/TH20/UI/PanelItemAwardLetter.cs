using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class PanelItemAwardLetter : PanelItem
	{
		private enum LetterStates
		{
			LsClosed = 0,
			LsOpening = 1,
			LsOpen = 2
		}

		[SerializeField]
		private TMP_Text _topPageText;

		[SerializeField]
		private TMP_Text _bottomPageText;

		private CanvasGroup _theCanvasGroup;

		private Image _theImage;

		private LetterStates _theState;

		private Quaternion _destRot;

		private RectTransform _theRectTransform;

		private Vector2 _destSize;

		private Vector3 _destPos;

		public override void Setup()
		{
			_theImage = GetComponentInChildren<Image>();
			if ((bool)_theImage)
			{
				_destSize = _theImage.rectTransform.rect.size;
			}
			_theRectTransform = GetComponent<RectTransform>();
			if ((bool)_theRectTransform)
			{
				_destPos = _theRectTransform.localPosition;
				_destRot = _theRectTransform.localRotation;
			}
			_theCanvasGroup = GetComponent<CanvasGroup>();
		}

		public void Open()
		{
			Reset();
			base.gameObject.SetActive(value: true);
			StartCoroutine(OpenLetter());
		}

		public void Reset()
		{
			_theRectTransform.localPosition = Vector3.zero;
			_theRectTransform.localRotation = Quaternion.identity;
			Vector2 destSize = _destSize;
			destSize.y = 10f;
			_theImage.rectTransform.sizeDelta = destSize;
			_theState = LetterStates.LsClosed;
			base.gameObject.SetActive(value: false);
			if ((bool)_theCanvasGroup)
			{
				_theCanvasGroup.alpha = 1f;
			}
		}

		private IEnumerator FadeLetter()
		{
			bool stop = false;
			float time = 1f;
			do
			{
				if (time <= 0f)
				{
					stop = true;
				}
				_theCanvasGroup.alpha = EasingsUtils.CubicEaseOut(Mathf.Clamp01(time));
				yield return null;
				time -= Time.unscaledDeltaTime * 2f;
			}
			while (!stop);
			_theState = LetterStates.LsClosed;
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator OpenLetter()
		{
			_theState = LetterStates.LsOpening;
			if ((bool)_theRectTransform)
			{
				bool stop = false;
				float moveTime = 0f;
				float openTime = 0f;
				Vector2 startSize = _theImage.rectTransform.sizeDelta;
				float settleTimeout = 5f;
				do
				{
					if (moveTime >= settleTimeout && openTime >= settleTimeout)
					{
						stop = true;
					}
					float t = EasingsUtils.CubicEaseOut(Mathf.Clamp01(moveTime));
					float t2 = EasingsUtils.ElasticEaseOut(Mathf.Clamp01(openTime));
					_theRectTransform.localPosition = Vector2.LerpUnclamped(Vector3.zero, _destPos, t);
					_theRectTransform.rotation = Quaternion.LerpUnclamped(Quaternion.identity, _destRot, t);
					_theImage.rectTransform.sizeDelta = Vector2.LerpUnclamped(startSize, _destSize, t2);
					yield return null;
					float unscaledDeltaTime = Time.unscaledDeltaTime;
					moveTime += unscaledDeltaTime * 2f;
					openTime += unscaledDeltaTime;
				}
				while (!stop);
			}
			_theState = LetterStates.LsOpen;
			_theRectTransform.localPosition = _destPos;
			_theRectTransform.rotation = _destRot;
			_theImage.rectTransform.sizeDelta = _destSize;
			yield return null;
		}

		public void Process()
		{
			bool flag = true;
			bool flag2 = true;
			if (_theState == LetterStates.LsOpening && flag && (bool)_theRectTransform)
			{
				float num = 1f;
				float num2 = 0.1f;
				Vector2 vector = _destSize - _theImage.rectTransform.rect.size;
				Vector3 vector2 = _destPos - _theRectTransform.localPosition;
				if (vector2.sqrMagnitude > num || Mathf.Abs(vector.y) > num2)
				{
					flag2 = false;
				}
				if (flag2)
				{
					_theRectTransform.localPosition = _destPos;
					_theRectTransform.rotation = _destRot;
					_theImage.rectTransform.sizeDelta = _destSize;
					_theState = LetterStates.LsOpen;
				}
				else
				{
					float unscaledDeltaTime = Time.unscaledDeltaTime;
					_theImage.rectTransform.sizeDelta += vector * 10f * unscaledDeltaTime;
					_theRectTransform.localPosition += vector2 * 10f * unscaledDeltaTime;
					_theRectTransform.rotation = Quaternion.Lerp(_theRectTransform.localRotation, _destRot, unscaledDeltaTime * 5f);
				}
			}
		}

		public void SetText(string topText, string bottomText)
		{
			if ((bool)_topPageText)
			{
				_topPageText.text = topText;
			}
			if ((bool)_bottomPageText)
			{
				_bottomPageText.text = bottomText;
			}
		}

		public void HideLetter()
		{
			if ((bool)_theCanvasGroup)
			{
				StartCoroutine(FadeLetter());
				return;
			}
			base.gameObject.SetActive(value: false);
			_theState = LetterStates.LsClosed;
		}

		public bool IsOpened()
		{
			return _theState == LetterStates.LsOpen;
		}

		public bool IsClosed()
		{
			return _theState == LetterStates.LsClosed;
		}
	}
}
