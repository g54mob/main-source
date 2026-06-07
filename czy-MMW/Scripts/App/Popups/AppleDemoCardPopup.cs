using System;
using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
	public class AppleDemoCardPopup : BasePopup
	{
		[System.Serializable]
		public class LocalizedFrontCards
		{
			public LocaleDatabase.LocaleId locale;

			public Sprite[] sprites;
		}

		public float minimumTimeShown = 5f;

		public float maximumTimeShown = 10f;

		[Dependency]
		private LocaleDatabase _locales;

		[Dependency]
		private PopupStack _popupStack;

		[SerializeField]
		private Image _image;

		private float _timeOpened;

		private bool _pendingDismissal;

		[SerializeField]
		private Sprite[] _frontCards;

		[SerializeField]
		private LocalizedFrontCards[] _cards = new LocalizedFrontCards[11]
		{
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.ar,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.pt_BR,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.ca,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.de,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.it,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.ja,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.ko,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.nl,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.tr,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.zh_TW,
				sprites = new Sprite[5]
			},
			new LocalizedFrontCards
			{
				locale = LocaleDatabase.LocaleId.en_US,
				sprites = new Sprite[5]
			}
		};

		public void Initialise(bool showFrontCard = false)
		{
			if (showFrontCard)
			{
				AssignBestSuitedSprite(_frontCards);
				return;
			}
			LocalizedFrontCards[] cards = _cards;
			foreach (LocalizedFrontCards localizedFrontCards in cards)
			{
				if (localizedFrontCards.locale == _locales.CurrentLocaleId)
				{
					AssignBestSuitedSprite(localizedFrontCards.sprites);
					break;
				}
			}
		}

		public override void OnOpened(float delay)
		{
			base.OnOpened(delay);
			_timeOpened = Time.time;
			inputState.BlockAllInput = true;
		}

		public override void OnClosed(Action onComplete = null, bool skipTransition = false)
		{
			_popupStack.ResetReturnBlur();
			base.OnClosed(onComplete);
		}

		public override bool CanBeDismissed()
		{
			return Time.time - _timeOpened > minimumTimeShown;
		}

		public void OnClicked()
		{
			_pendingDismissal = true;
		}

		private void Update()
		{
			if (isFullyVisible)
			{
				float num = Time.time - _timeOpened;
				if (num > maximumTimeShown)
				{
					_pendingDismissal = true;
				}
				if (_pendingDismissal && num > minimumTimeShown)
				{
					_popupStack.PopPopup();
				}
			}
		}

		private void AssignBestSuitedSprite(Sprite[] sprites)
		{
			Vector2Int vector2Int = new Vector2Int(Screen.width, Screen.height);
			float num = (float)vector2Int.x / (float)vector2Int.y;
			int num2 = 0;
			float num3 = (float)sprites[num2].texture.width / (float)sprites[num2].texture.height;
			for (int i = 1; i < sprites.Length; i++)
			{
				Vector2Int vector2Int2 = new Vector2Int(sprites[i].texture.width, sprites[i].texture.height);
				float num4 = (float)vector2Int2.x / (float)vector2Int2.y;
				if (vector2Int2 == vector2Int)
				{
					num2 = i;
					break;
				}
				if (Mathf.Abs(num4 - num) < Math.Abs(num3 - num))
				{
					num2 = i;
					num3 = num4;
				}
			}
			_image.sprite = sprites[num2];
		}

		public override void Reset()
		{
			_pendingDismissal = false;
			_timeOpened = 0f;
			base.Reset();
		}
	}
}
