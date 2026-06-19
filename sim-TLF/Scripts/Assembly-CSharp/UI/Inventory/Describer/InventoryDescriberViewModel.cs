using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace UI.Inventory.Describer
{
	public class InventoryDescriberViewModel : ViewModelBase
	{
		public ObservableProperty<bool> Enabled = new ObservableProperty<bool>(value: false);

		public ObservableProperty<bool> UseTooltipEnabled = new ObservableProperty<bool>(value: false);

		private Vector2 _offset;

		private Vector2 _position;

		private string _infoText;

		public string InfoText
		{
			get
			{
				return _infoText;
			}
			set
			{
				Set(ref _infoText, value, "InfoText");
			}
		}

		public Vector2 Position
		{
			get
			{
				return _position;
			}
			set
			{
				Set(ref _position, value, "Position");
			}
		}

		public Vector2 Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				Set(ref _offset, value, "Offset");
			}
		}
	}
}
