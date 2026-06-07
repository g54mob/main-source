using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class StallInteractable : MonoBehaviour, ISensable, IMainInteractable, ISecondInteractable
	{
		[Header("Price Tag")]
		[SerializeField]
		private EnabledValue<StallLabel> m_label;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private StallInteractableInputHint m_inputHint;

		private MiniatureProduct m_miniatureProduct;

		private int MiniatureUID
		{
			get
			{
				if (!(m_miniatureProduct != null))
				{
					return 0;
				}
				return -m_miniatureProduct.ProductData.UID;
			}
		}

		private int MiniatureProductUID
		{
			get
			{
				if (!(m_miniatureProduct != null))
				{
					return 0;
				}
				return m_miniatureProduct.ProductData.UID;
			}
		}

		public static StallInteractable CurrentlyInteracted { get; private set; }

		public bool ProductPainted
		{
			get
			{
				if (m_miniatureProduct != null)
				{
					return m_miniatureProduct.Painted;
				}
				return false;
			}
		}

		public float GetProductMarketPricePercentage()
		{
			if (m_label.IsEnabled(out var _) && TabletopPriceManager.TryGetMiniatureMarketPricePercentage(MiniatureProductUID, m_miniatureProduct.Painted, out var percentage))
			{
				return percentage;
			}
			return 1f;
		}

		public bool HasAProduct(out int miniatureUID)
		{
			if (m_miniatureProduct != null)
			{
				miniatureUID = MiniatureUID;
				return true;
			}
			miniatureUID = 0;
			return false;
		}

		public bool HasABuyableProduct()
		{
			float percentage;
			if (m_label.IsEnabled(out var _) && HasAProduct(out var _))
			{
				return TabletopPriceManager.TryGetMiniatureMarketPricePercentage(MiniatureProductUID, m_miniatureProduct.Painted, out percentage);
			}
			return false;
		}

		private void PlaceMiniature(int miniatureUID)
		{
			if (Collection.AddToDisplay(miniatureUID, m_label.IsEnabled(out var _), out var data, out var painted))
			{
				ManualPlaceMiniature(data, painted);
			}
		}

		public void ManualPlaceMiniature(MiniatureProductData productData, bool painted)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(-productData.UID);
			m_miniatureProduct = Object.Instantiate(miniatureData.Product).GetComponent<MiniatureProduct>();
			m_miniatureProduct.Init(productData, miniatureData, painted);
			m_miniatureProduct.OnPlacedOnStall();
			m_miniatureProduct.Interacted += RemoveProduct;
			m_miniatureProduct.OnSensedEvent += OnMiniatureProductSensed;
			m_miniatureProduct.OnUnsensedEvent += OnMiniatureProductUnsensed;
			m_miniatureProduct.transform.SetParent(base.transform);
			m_miniatureProduct.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			if (m_label.IsEnabled(out var value))
			{
				value.SetContent(m_miniatureProduct);
			}
		}

		private void RemoveProduct()
		{
			OnLoseProduct(bought: false);
			Object.Destroy(m_miniatureProduct.gameObject);
			m_miniatureProduct = null;
		}

		public bool CanBeSensed()
		{
			if (!HasAProduct(out var _) && World.PlayerController.Context == EControllerContext.CHARACTER)
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
			return character.IsPlayer;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			if (character.IsPlayer)
			{
				Collection.Open(ECollectionMode.SELLING);
				CurrentlyInteracted = this;
			}
		}

		public bool CanSecondInteract(Character character)
		{
			if (m_label.IsEnabled(out var _))
			{
				return !character.IsPlayer;
			}
			return false;
		}

		void ISecondInteractable.OnSecondInteractedBy(Character character)
		{
			if (character.CanHandleStackable(m_miniatureProduct))
			{
				OnLoseProduct(bought: true);
				character.OnHandleStackable(m_miniatureProduct);
				m_miniatureProduct = null;
			}
		}

		private void OnLoseProduct(bool bought)
		{
			m_miniatureProduct.OnRemovedFromStall();
			Collection.RemoveFromDisplay(m_miniatureProduct, bought, m_label.IsEnabled(out var _));
			if (m_label.IsEnabled(out var value2))
			{
				value2.SetContent(null);
			}
		}

		private void OnMiniatureProductSensed()
		{
			if (m_inputHint != null)
			{
				m_inputHint.RemoveFlags(StallInteractableInputHint.EActionStates.ADD);
				m_inputHint.AddFlags(StallInteractableInputHint.EActionStates.REMOVE);
				m_inputHint.enabled = true;
			}
		}

		private void OnMiniatureProductUnsensed()
		{
			if (m_inputHint != null)
			{
				m_inputHint.RemoveFlags(StallInteractableInputHint.EActionStates.REMOVE);
				m_inputHint.AddFlags(StallInteractableInputHint.EActionStates.ADD);
				m_inputHint.enabled = false;
			}
		}

		public void OnMiniatureButtonClicked(int miniatureUID)
		{
			TabletopWorld.TabletopHUDPopup.OnCancel();
			PlaceMiniature(miniatureUID);
		}
	}
}
