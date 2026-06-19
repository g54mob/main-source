using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RolodexControl : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler
	{
		[SerializeField]
		private DynamicButton _buttonPrev;

		[SerializeField]
		private DynamicButton _buttonNext;

		[SerializeField]
		private int _numCardsToDisplay = 2;

		[SerializeField]
		private float _cardSpacing = 128f;

		[SerializeField]
		private float _scrollSpeed = 64f;

		[SerializeField]
		private List<RectTransform> _cards = new List<RectTransform>();

		private float _scrollOffset;

		private RectTransform _rectTransform;

		private ButtonAnimator _buttonPrevAnimator;

		private ButtonAnimator _buttonNextAnimator;

		private int _numCards;

		private bool _loop;

		private bool _pointerIn;

		public Action<int> OnCardChanged;

		public int CardIndex { get; set; }

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			if (_buttonPrev != null)
			{
				_buttonPrev.onPrimaryDown.RemoveListener(Prev);
				_buttonPrev.onPrimaryDown.AddListener(Prev);
				_buttonPrevAnimator = _buttonPrev.GetComponent<ButtonAnimator>();
			}
			if (_buttonNext != null)
			{
				_buttonNext.onPrimaryDown.RemoveListener(Next);
				_buttonNext.onPrimaryDown.AddListener(Next);
				_buttonNextAnimator = _buttonNext.GetComponent<ButtonAnimator>();
			}
		}

		public void SetActive(bool active)
		{
			ButtonAnimator.State currentState = ((!active) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			_buttonPrev.interactable = active;
			_buttonNext.interactable = active;
			if (_buttonPrevAnimator != null)
			{
				_buttonPrevAnimator.CurrentState = currentState;
			}
			if (_buttonNextAnimator != null)
			{
				_buttonNextAnimator.CurrentState = currentState;
			}
		}

		public void SetCards<T>(List<RectTransform> cards, bool loop) where T : SandboxCycleImage
		{
			DestroyCards();
			_cards.AddRange(cards);
			_loop = loop;
			_numCards = _cards.Count;
			if (loop)
			{
				int num = _numCardsToDisplay * 2 + 1;
				while (_cards.Count < num)
				{
					foreach (RectTransform card in cards)
					{
						_cards.Add(UnityEngine.Object.Instantiate(card.gameObject, card.transform.parent).GetComponent<RectTransform>());
					}
				}
			}
			Update();
			foreach (RectTransform card2 in _cards)
			{
				T componentInChildren = card2.GetComponentInChildren<T>();
				if (componentInChildren != null)
				{
					componentInChildren.LateUpdate();
				}
			}
		}

		public void DestroyCards()
		{
			foreach (RectTransform card in _cards)
			{
				UnityEngine.Object.Destroy(card.gameObject);
			}
			_cards.Clear();
		}

		public void Prev()
		{
			if (_loop || CardIndex != 0)
			{
				CardIndex--;
				if (CardIndex < 0)
				{
					CardIndex = _numCards - 1;
				}
				_scrollOffset -= _cardSpacing;
				OnCardChanged.InvokeSafe(CardIndex);
			}
		}

		public void Next()
		{
			if (_loop || CardIndex != _numCards - 1)
			{
				CardIndex++;
				if (CardIndex == _numCards)
				{
					CardIndex = 0;
				}
				_scrollOffset += _cardSpacing;
				OnCardChanged.InvokeSafe(CardIndex);
			}
		}

		private void Update()
		{
			ProcessInput();
			UpdateCards();
		}

		private void ProcessInput()
		{
			if (_pointerIn && Mathf.Abs(_scrollOffset) < _cardSpacing * 0.5f)
			{
				float axis = Input.GetAxis("Mouse ScrollWheel");
				if (axis > 0f)
				{
					Next();
				}
				else if (axis < 0f)
				{
					Prev();
				}
			}
		}

		private void UpdateCards()
		{
			int count = _cards.Count;
			Rect rect = _rectTransform.rect;
			Vector2 center = rect.center;
			_scrollOffset -= _scrollOffset * Mathf.Clamp(Time.unscaledDeltaTime, 0f, 1f / 15f) * _scrollSpeed;
			int num = ((_loop && _scrollOffset / _cardSpacing > 0.5f) ? 1 : 0);
			foreach (RectTransform card in _cards)
			{
				card.localScale = Vector3.zero;
			}
			if (!(rect.width > 0f) || count == 0)
			{
				return;
			}
			int num2 = _numCardsToDisplay;
			if (!_loop && _numCards <= num2)
			{
				num2 = _numCards - 1;
			}
			for (int i = -num2; i < num2 + 1; i++)
			{
				int j = i + CardIndex;
				if (_loop || (j >= 0 && j < _numCards))
				{
					for (; j < 0; j += count)
					{
					}
					while (j >= count)
					{
						j -= count;
					}
					RectTransform rectTransform = _cards[j];
					float num3 = _scrollOffset + (float)i * _cardSpacing;
					float num4 = Mathf.Cos(Mathf.Abs(num3) * 0.5f / rect.width * (float)Math.PI * 0.5f);
					num4 *= num4;
					rectTransform.localScale = new Vector3(num4, num4, 1f);
					rectTransform.localPosition = new Vector3(center.x + num3 * num4 * num4, center.y, 0f);
					rectTransform.SetSiblingIndex(num2 - Mathf.Abs(i + ((i == 0) ? num : 0)));
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_pointerIn = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_pointerIn = false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			float num = 0f;
			int num2 = -1;
			int count = _cards.Count;
			Vector2 position = eventData.position;
			position.y = (float)Screen.height - position.y;
			if (count != 0)
			{
				int num3 = _numCardsToDisplay;
				if (!_loop && _numCards <= num3)
				{
					num3 = _numCards - 1;
				}
				for (int i = -num3; i < num3 + 1; i++)
				{
					int j = i + CardIndex;
					if (_loop || (j >= 0 && j < _numCards))
					{
						for (; j < 0; j += count)
						{
						}
						while (j >= count)
						{
							j -= count;
						}
						RectTransform rectTransform = _cards[j];
						if (rectTransform.GetScreenSpaceRect().Contains(position) && rectTransform.localScale.x > num)
						{
							num2 = j;
							num = rectTransform.localScale.x;
						}
					}
				}
			}
			if (num2 == -1)
			{
				return;
			}
			int num4 = num2 + _numCards - (CardIndex + _numCards);
			if (num4 > _numCards / 2)
			{
				num4 -= _numCards;
			}
			if (num4 < -_numCards / 2)
			{
				num4 += _numCards;
			}
			for (int k = 0; k < Mathf.Abs(num4); k++)
			{
				if (num4 < 0)
				{
					Prev();
				}
				else if (num4 > 0)
				{
					Next();
				}
			}
		}
	}
}
