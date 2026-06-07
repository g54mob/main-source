using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace __Project__.Scripts.Computer.Shopping
{
	public class FloorSalesItem : SalesUIElement
	{
		[Header("Sales Item")]
		[SerializeField]
		private Image m_ProductIcon;

		[SerializeField]
		private TextMeshProUGUI m_ProductAmountText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedFloorText;

		private FloorViewer m_FloorViewer;

		public string BucketName => null;

		public void Setup(int boxId, FloorViewer floorViewer)
		{
		}

		public void AddToCart()
		{
		}
	}
}
