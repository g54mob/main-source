using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class ReserveShelfLabel : MonoBehaviour, ISensable
	{
		[Header("Shelf Label")]
		[SerializeField]
		private Canvas m_canvas;

		[Header("UI Components")]
		[SerializeField]
		private SimulatorText m_productNameText;

		[SerializeField]
		private TextMeshProUGUI m_quantityText;

		[SerializeField]
		private Image m_itemImage;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		public BaseShopBoxData Data { get; private set; }

		public static ReserveShelfLabel CurrentlyInspected { get; private set; }

		private void OnEnable()
		{
			InitContent();
		}

		private void OnDisable()
		{
		}

		private void InitContent()
		{
			if (Data == null)
			{
				m_itemImage.enabled = false;
				m_productNameText.gameObject.SetActive(value: false);
				SetQuantity(0);
			}
		}

		public void SetContent(StackableBox box)
		{
			Data = ((box != null) ? box.BoxData : null);
			if (Data != null)
			{
				m_itemImage.sprite = Data.Sprite;
				m_itemImage.enabled = true;
				m_productNameText.gameObject.SetActive(value: true);
				m_productNameText.SetTerm(Data.NameTerm);
				SetQuantity(box.ObjectStack.Count);
			}
			else
			{
				m_itemImage.enabled = false;
				m_productNameText.gameObject.SetActive(value: false);
				SetQuantity(0);
			}
		}

		public void SetQuantity(int quantity)
		{
			m_quantityText.text = quantity.ToString();
		}

		public bool CanBeSensed()
		{
			if (Data != null && World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (Data is ProductShopBoxData productShopBoxData)
			{
				HUD.ShowProductTooltip(productShopBoxData.Product);
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			HUD.HideProductTooltip();
		}
	}
}
