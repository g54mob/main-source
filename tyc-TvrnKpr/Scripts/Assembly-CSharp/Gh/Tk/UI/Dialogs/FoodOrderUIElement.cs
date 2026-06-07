using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class FoodOrderUIElement : InventoryItemUIElement
	{
		[SerializeField]
		private Transform _servingStateTransform;

		[SerializeField]
		private Transform _cookingStateTransform;

		[SerializeField]
		private Transform _orderedStateTransform;

		[SerializeField]
		private Countdown3DUIView _patienceMeter;

		[SerializeField]
		private Transform _isPausedTransform;

		private Job _mainJob;

		public override GameItem Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Update()
		{
		}
	}
}
