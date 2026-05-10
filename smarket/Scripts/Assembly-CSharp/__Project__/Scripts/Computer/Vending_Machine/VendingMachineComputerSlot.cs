using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.Computer.Vending_Machine
{
	public class VendingMachineComputerSlot : MonoBehaviour
	{
		public enum HighlightStat
		{
			Selected = 0,
			UnSelected = 1
		}

		public enum PlacedStat
		{
			Box = 0,
			Placed = 1
		}

		private VendingData _vendingMachineData;

		private Button _selectButton;

		private Image _selectButtonImage;

		private bool _isPlaced;

		[SerializeField]
		private TextMeshProUGUI slotName;

		[SerializeField]
		private Image slotImage;

		[SerializeField]
		private Sprite furnitureIcon;

		[SerializeField]
		private Sprite boxIcon;

		public Image SelectButtonImage => null;

		public Button SelectButton => null;

		public VendingData VendingMachineData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsPlaced
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void InitializeSlot()
		{
		}

		public void SelectThisVendingMachineSlot()
		{
		}

		private void Initialize()
		{
		}

		public void SetVendingData(VendingData vendingData)
		{
		}

		public void SelectedStatus(HighlightStat stat)
		{
		}

		public void SlotStat(PlacedStat stat)
		{
		}
	}
}
