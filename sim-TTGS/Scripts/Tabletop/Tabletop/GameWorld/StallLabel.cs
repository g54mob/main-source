using System;
using Simulator;
using Simulator.GameWorld;
using TMPro;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class StallLabel : MonoBehaviour, ISensable, IMainInteractable
	{
		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[Header("UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_priceText;

		[Header("Input hint")]
		[SerializeField]
		private InputHint m_inputHint;

		public MiniatureProduct Product { get; private set; }

		public static StallLabel CurrentlyInspected { get; private set; }

		public event Action<float> PriceChanged;

		private void OnEnable()
		{
			TabletopPriceManager.MiniatureMarketPricePercentageChanged += OnMiniatureMarketPricePercentageChanged;
			Collection.PaintedMiniature += OnPaintedMiniature;
			UpdatePriceDisplay();
		}

		private void OnDisable()
		{
			TabletopPriceManager.MiniatureMarketPricePercentageChanged -= OnMiniatureMarketPricePercentageChanged;
		}

		public void SetContent(MiniatureProduct miniatureProduct)
		{
			Product = miniatureProduct;
			UpdatePriceDisplay();
		}

		public float GetActualPrice(float percentage)
		{
			return percentage * TabletopPriceManager.GetMiniatureProductMarketPrice(Product.ProductData.UID, Product.Painted);
		}

		protected virtual void UpdatePriceDisplay(float percentage)
		{
			if (m_priceText != null)
			{
				m_priceText.text = GetActualPrice(percentage).ToStringMoneyFormat();
			}
		}

		protected virtual void UpdatePriceDisplay()
		{
			if (Product != null && TabletopPriceManager.TryGetMiniatureMarketPricePercentage(Product.ProductData.UID, Product.Painted, out var percentage))
			{
				UpdatePriceDisplay(percentage);
			}
			else
			{
				DisablePriceDisplay();
			}
		}

		protected virtual void DisablePriceDisplay()
		{
			if (m_priceText != null)
			{
				m_priceText.text = "- - -";
			}
		}

		protected virtual void OnMiniatureMarketPricePercentageChanged(int miniatureProductUID, bool painted, float percentage)
		{
			if (Product != null && Product.ProductData.UID == miniatureProductUID && Product.Painted == painted)
			{
				UpdatePriceDisplay(percentage);
			}
		}

		private void OnPaintedMiniature(int miniatureUID, int paintScore)
		{
			if (Product != null && Product.ProductData.UID == -miniatureUID && Product.Painted)
			{
				UpdatePriceDisplay();
			}
		}

		public bool CanBeSensed()
		{
			if (Product != null && World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			if (m_outline != null)
			{
				m_outline.enabled = false;
			}
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		public bool CanMainInteract(Character character)
		{
			return Product != null;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			CurrentlyInspected = this;
			TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.STALL_LABEL);
		}
	}
}
