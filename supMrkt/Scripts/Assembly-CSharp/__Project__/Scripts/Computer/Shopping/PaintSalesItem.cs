using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace __Project__.Scripts.Computer.Shopping
{
	public class PaintSalesItem : SalesUIElement
	{
		[Header("Sales Item")]
		[SerializeField]
		private Image m_ProductIcon;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedPaintText;

		private BucketViewer m_BucketViewer;

		public string BucketName => null;

		public void Setup(int bucketId, BucketViewer bucketViewer)
		{
		}

		public void Setup(int boxId, BucketViewer bucketViewer, bool isFloorBox)
		{
		}

		public void AddToCart()
		{
		}

		public void AddToCart(bool isPaint)
		{
		}
	}
}
