using DG.Tweening;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Purchase
{
	public class CardScript : MonoBehaviour
	{
		private XmlElement _cardRoot;

		private bool _purchasing;

		private float _scaleNotSelected = 0.75f;

		private bool _selected;

		private Tweener _tween;

		public CardDetails CardDetails { get; private set; }

		public CardInfo CardInfo { get; private set; }

		public XmlElement Element { get; private set; }

		public bool Hidden
		{
			get
			{
				return _cardRoot.gameObject.activeSelf;
			}
			set
			{
				_cardRoot.gameObject.SetActive(!value);
			}
		}

		public bool IsAvailable
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public bool IsPurchased
		{
			get
			{
				return Element.HasClass("purchased");
			}
			set
			{
				if (value)
				{
					Element.AddClass("purchased");
				}
				else
				{
					Element.RemoveClass("purchased");
				}
				CardDetails.UpdateBuyText();
			}
		}

		public bool IsPurchasing
		{
			get
			{
				return _purchasing;
			}
			set
			{
				_purchasing = value;
				CardDetails.UpdateBuyText();
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					_tween?.Kill(complete: true);
					_tween = Element.rectTransform.DOScale(value ? 1f : _scaleNotSelected, 0.5f).SetEase(Ease.OutBack);
					if (_selected)
					{
						Element.AddClass("selected");
					}
					else
					{
						Element.RemoveClass("selected");
					}
				}
			}
		}

		public void Initialize(XmlElement cardElement, CardInfo cardInfo, IVideoPlayerService videoPlayerService)
		{
			Element = cardElement;
			CardInfo = cardInfo;
			_cardRoot = Element.GetElementByInternalId("card-root");
			cardElement.GetElementByInternalId("cover-image").SetAndApplyAttribute("sprite", cardInfo.CoverImageSprite);
			Element.GetElementByInternalId("card-name").SetText(cardInfo.Name);
			CardDetails = new CardDetails(this, videoPlayerService);
			RefreshStatus();
			Element.rectTransform.localScale = Vector3.one * _scaleNotSelected;
		}

		public void RefreshStatus()
		{
			IsPurchased = CardInfo.IsPurchased;
			IsAvailable = CardInfo.IsAvailable;
		}
	}
}
