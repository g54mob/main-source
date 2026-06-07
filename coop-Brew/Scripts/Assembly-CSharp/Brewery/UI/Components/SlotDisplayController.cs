using Brewery.Stations;
using UnityEngine.UIElements;

namespace Brewery.UI.Components
{
	public sealed class SlotDisplayController
	{
		private VisualElement iconElement;

		private Label nameLabel;

		private Label quantityLabel;

		private Label capacityLabel;

		public void Initialize(VisualElement root, string iconId, string nameLabelId, string quantityLabelId, string capacityLabelId = null)
		{
		}

		public void Update(string itemName, StationSlotData slot, int capacity)
		{
		}
	}
}
