using System;
using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using UnityEngine;
using Zenject;

namespace Items
{
	public class PropItem : MonoBehaviour, IMoveable, IInventoryManagable
	{
		[SerializeField]
		private PartConfig _partConfig;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		private string _id;

		PartConfig IInventoryManagable.ItemConfig => _partConfig;

		string IInventoryManagable.ID => _id;

		private void Awake()
		{
			_id = DateTime.UtcNow.Ticks.ToString();
		}

		private void Start()
		{
			_fallenItemsService?.Register(this);
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		void IInventoryManagable.RemoveItem()
		{
		}

		void IMoveable.Move(Vector3 targetPos)
		{
			base.transform.position = targetPos;
		}

		void IInventoryManagable.PickupItem()
		{
		}
	}
}
