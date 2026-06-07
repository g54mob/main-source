using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Web;
using DG.Tweening;
using Jundroo.Services.Purchasing;
using ModApi;
using ModApi.Audio;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.Purchase
{
	public class PurchaseDialogScript : DialogScript, IDragHandler, IEventSystemHandler, IEndDragHandler
	{
		private XmlElement _cardParent;

		private List<CardScript> _cards = new List<CardScript>();

		private CardInfoSource _cardSource;

		private XmlElement _cardTemplate;

		private CardScript _detailCard;

		private XmlElement _loadingPanel;

		private XmlElement _panel;

		private bool _requiresSceneReload;

		private CardScript _selectedCard;

		private Tweener _tweenMove;

		private VideoPlayerService _videoPlayerService;

		public CardScript DetailCard
		{
			get
			{
				return _detailCard;
			}
			set
			{
				if (!(_detailCard != value))
				{
					return;
				}
				if (_detailCard != null)
				{
					_detailCard.CardDetails.ShowDetails = false;
				}
				_detailCard = value;
				if (_detailCard != null)
				{
					_detailCard.CardDetails.ShowDetails = true;
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Purchase.OpenBundle);
				}
				_panel.GetElementByInternalId("button-panel").SetActive(_detailCard == null);
				foreach (CardScript card in _cards)
				{
					if (_detailCard == null || _detailCard == card)
					{
						card.Hidden = false;
					}
					else
					{
						card.Hidden = true;
					}
				}
			}
		}

		public IPurchaseService PurchaseService { get; private set; }

		public static PurchaseDialogScript Create(IPurchaseService purchaseService, Transform parent, string productId)
		{
			PurchaseDialogScript purchaseDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/Purchase/PurchaseDialog", parent, delegate(PurchaseDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			purchaseDialogScript.Initialize(purchaseService, productId);
			return purchaseDialogScript;
		}

		public override void Close()
		{
			base.Close();
			if (_requiresSceneReload)
			{
				ReloadCurrentScene();
			}
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		public void OnDrag(PointerEventData eventData)
		{
			_tweenMove?.Kill();
			_cardParent.transform.localPosition += new Vector3(eventData.delta.x, 0f, 0f);
			float num = (float)Screen.width / 2f;
			float num2 = float.MaxValue;
			CardScript card = _cards[0];
			foreach (CardScript card2 in _cards)
			{
				float num3 = Mathf.Abs(num - ((Vector3)RectTransformUtility.WorldToScreenPoint(Game.Instance.UserInterface.Camera, card2.transform.position)).x);
				if (num3 < num2)
				{
					num2 = num3;
					card = card2;
				}
			}
			SelectCard(card, animateToCard: false);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			AnimateToCard(_selectedCard);
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
			_videoPlayerService?.Dispose();
			_videoPlayerService = null;
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private static void RecalculateCardContainerScale(RectTransform scaleRoot)
		{
			float a = scaleRoot.rect.width / 1060f;
			float b = scaleRoot.rect.height / 600f;
			float num = Mathf.Min(a, b);
			scaleRoot.transform.localScale = Vector3.one * num;
		}

		private void AnimateToCard(CardScript card)
		{
			int num = _cards.Where((CardScript x) => x.IsAvailable).ToList().IndexOf(card);
			_tweenMove?.Kill(complete: true);
			_tweenMove = _cardParent.transform.DOLocalMoveX(-160 - num * 320, 0.5f);
		}

		private void CreateCard(CardInfo cardInfo, IVideoPlayerService videoPlayerService)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_cardTemplate, _cardParent);
			xmlElement.SetActive(active: true);
			CardScript cardScript = xmlElement.gameObject.AddComponent<CardScript>();
			cardScript.Initialize(xmlElement, cardInfo, videoPlayerService);
			_cards.Add(cardScript);
		}

		private void Initialize(IPurchaseService purchaseService, string selectProductId)
		{
			PurchaseService = purchaseService;
			_cardSource = new CardInfoSource(purchaseService);
			_videoPlayerService = new VideoPlayerService(base.gameObject, 1280, 720);
			foreach (CardInfo card in _cardSource.Cards)
			{
				CreateCard(card, _videoPlayerService);
			}
			if (!string.IsNullOrEmpty(selectProductId))
			{
				SelectProduct(selectProductId);
				return;
			}
			CardScript cardScript = _cards.Where((CardScript x) => !x.IsPurchased).FirstOrDefault();
			if (cardScript == null)
			{
				cardScript = _cards[0];
			}
			SelectCard(cardScript);
		}

		private async void OnBuyClicked()
		{
			CardScript detailCard = DetailCard;
			if ((object)detailCard == null || detailCard.IsPurchased || DetailCard.IsPurchasing)
			{
				return;
			}
			if (DetailCard.CardInfo.IsCompleteEdition)
			{
				string text = (Device.IsIosBuild ? "iOS" : "GooglePlay");
				WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Client/RedirectCompleteEdition?store=" + text);
				return;
			}
			DetailCard.IsPurchasing = true;
			_loadingPanel.SetActive(active: true);
			PurchaseProductResult purchaseProductResult;
			try
			{
				purchaseProductResult = await PurchaseService.PurchaseProductAsync(DetailCard.CardInfo.ProductId);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				purchaseProductResult = new PurchaseProductResult(null, PurchaseFailureReason.Unknown, ex.Message);
			}
			_loadingPanel.SetActive(active: false);
			_requiresSceneReload = true;
			DetailCard.IsPurchasing = false;
			if (!purchaseProductResult.Success)
			{
				string message = ((purchaseProductResult.FailureReason == PurchaseFailureReason.UserCancelled) ? "User cancelled the purchase." : ("An error occurred while processing the in app purchase:" + Environment.NewLine + $"{purchaseProductResult.FailureReason ?? PurchaseFailureReason.Unknown}: {purchaseProductResult.FailureMessage ?? string.Empty}"));
				Game.Instance.UserInterface.CreateMessageDialog(message);
			}
			DetailCard = null;
			RefreshCards();
		}

		private void OnCardClicked(XmlElement xmlElement)
		{
			CardScript componentInParent = xmlElement.GetComponentInParent<CardScript>();
			if (componentInParent != null)
			{
				if (_selectedCard != componentInParent)
				{
					SelectCard(componentInParent);
				}
				else
				{
					DetailCard = _selectedCard;
				}
			}
		}

		private void OnCloseClicked()
		{
			DetailCard?.CardDetails.OnCloseClicked(this);
		}

		private void OnExitClicked()
		{
			Close();
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_cardParent = xmlLayout.GetElementById("card-parent");
			_cardTemplate = xmlLayout.GetElementById("card-template");
			_loadingPanel = xmlLayout.GetElementById("loading-panel");
			_loadingPanel.gameObject.AddComponent<DragBlockerScript>();
			RectTransform scaleRoot = xmlLayout.GetElementById("scale-root").rectTransform;
			RecalculateCardContainerScale(scaleRoot);
			SafeAreaScript componentInParent = scaleRoot.GetComponentInParent<SafeAreaScript>();
			if (componentInParent != null)
			{
				componentInParent.DimensionsRecalculated += delegate
				{
					RecalculateCardContainerScale(scaleRoot);
				};
			}
			_panel.SetAttribute("active", "false");
		}

		private void OnMoreInfoClicked()
		{
			if (DetailCard != _selectedCard)
			{
				DetailCard = _selectedCard;
			}
			else
			{
				DetailCard = null;
			}
		}

		private void OnRestorePurchasesClicked()
		{
			_loadingPanel.SetActive(active: true);
			PurchasingService.RestorePurchases(delegate(bool success, string failureMessage)
			{
				_loadingPanel.SetActive(active: false);
				if (success)
				{
					Game.Instance.UserInterface.CreateMessageDialog("Purchases Restored");
				}
				else
				{
					Game.Instance.UserInterface.CreateErrorDialog("Failed to restore purchases: " + failureMessage);
				}
				DetailCard = null;
				RefreshCards();
			});
		}

		private void RefreshCards()
		{
			_cardSource.RefreshStatus();
			foreach (CardScript card in _cards)
			{
				card.RefreshStatus();
			}
		}

		private void ReloadCurrentScene()
		{
			if (Game.InDesignerScene)
			{
				Game.Instance.Designer.Exit("Design");
			}
			else if (Game.InMenuScene)
			{
				Game.Instance.SceneManager.ReloadCurrentScene();
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Thank you! Some new features might require the flight scene to be restarted.", devlog: false, 20f);
			}
		}

		private void SelectCard(CardScript card, bool animateToCard = true, bool playAudio = true)
		{
			if (!(_selectedCard != card))
			{
				return;
			}
			DetailCard = null;
			if (_selectedCard != null)
			{
				_selectedCard.Selected = false;
				_selectedCard = null;
			}
			_selectedCard = card;
			if (_selectedCard != null)
			{
				_selectedCard.Selected = true;
				if (playAudio)
				{
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Purchase.SelectBundle);
				}
			}
			if (animateToCard)
			{
				AnimateToCard(card);
			}
		}

		private void SelectProduct(string productId)
		{
			CardScript cardScript = _cards.Where((CardScript x) => x.CardInfo.ProductId == productId).FirstOrDefault();
			if (cardScript != null)
			{
				SelectCard(cardScript, animateToCard: true, playAudio: false);
				DetailCard = cardScript;
			}
		}
	}
}
