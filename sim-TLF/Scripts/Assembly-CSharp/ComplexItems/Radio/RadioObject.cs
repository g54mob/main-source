using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Items;
using Radio;
using UnityEngine;
using Zenject;

namespace ComplexItems.Radio
{
	public class RadioObject : MonoBehaviour, ISmoothMovable, IMoveable, IUsable, IInventoryManagable, IScrollManipulatable
	{
		[SerializeField]
		private RadioController _radioController;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		float ISmoothMovable.Smooth => 5f;

		string IInventoryManagable.ID => "-1";

		PartConfig IInventoryManagable.ItemConfig => null;

		private void Start()
		{
			_fallenItemsService?.Register(this);
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		void IMoveable.Move(Vector3 targetPos)
		{
		}

		void IUsable.Use()
		{
			_radioController.Toggle();
		}

		void IUsable.UnUse()
		{
		}

		void IInventoryManagable.PickupItem()
		{
		}

		void IInventoryManagable.RemoveItem()
		{
		}

		void IScrollManipulatable.ScrollUp(float value)
		{
			_radioController.SetVolume(_radioController.GetVolume() + value);
		}

		void IScrollManipulatable.ScrollDown(float value)
		{
			_radioController.SetVolume(_radioController.GetVolume() + value);
		}
	}
}
