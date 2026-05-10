using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.MiniMap
{
	[RequireComponent(typeof(Button))]
	public class VendingGlobalMapUIMarker : GlobalMapMarker
	{
		private VendingMachine m_VendingMachine;

		private RectTransform m_MapRectTransform;

		private int m_UniqueID;

		private bool m_IsHighlighted;

		[SerializeField]
		private Vector2 m_WorldMinCoords;

		[SerializeField]
		private Vector2 m_WorldMaxCoords;

		[SerializeField]
		private float m_XOffset;

		[SerializeField]
		private float m_YOffset;

		private const string BasePlaceName = "Vending Machine #";

		public int UniqueID => 0;

		public bool IsHighlighted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		public void Initialize(VendingMachine vendingMachine)
		{
		}

		private void CalculateUIPosition(Vector3 worldPosition)
		{
		}

		private void SetTargetPosition()
		{
		}

		public override void Highlight()
		{
		}

		public override void DeHighlight()
		{
		}

		public override void ResetMarker()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
