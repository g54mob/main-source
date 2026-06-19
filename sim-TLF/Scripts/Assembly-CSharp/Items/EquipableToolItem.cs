using System;
using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Computer.Sites.SellOrWaste;
using JSAM;
using Player;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Items
{
	public class EquipableToolItem : MonoBehaviour, IInventoryManagable, IEquipable, ISmoothMovable, IMoveable, IThrowable, IProductConfigGetter
	{
		[SerializeField]
		private PartConfig _inventoryItem;

		[SerializeField]
		private ToolObject _toolObject;

		[SerializeField]
		private ProductObjectConfig _productConfig;

		private string _id;

		private Rigidbody _rb;

		private float _smooth = 5f;

		private LayerMask _defaultLayerMask;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		[Inject]
		private IPlayerToolView _playerToolView;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		public ToolObject ToolObject => _toolObject;

		PartConfig IInventoryManagable.ItemConfig => _inventoryItem;

		string IInventoryManagable.ID => _id;

		float ISmoothMovable.Smooth => _smooth;

		ProductObjectConfig IProductConfigGetter.Config => _productConfig;

		private void Awake()
		{
			_id = DateTime.UtcNow.Ticks.ToString();
			_rb = GetComponent<Rigidbody>();
			_defaultLayerMask = base.gameObject.layer;
		}

		private void Start()
		{
			_fallenItemsService?.Register(this);
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		void IEquipable.Equip()
		{
			foreach (SoundFileObject equipSound in ToolObject.EquipSounds)
			{
				AudioManager.PlaySound(equipSound);
			}
			_playerToolView.SetToolObject(_toolObject);
			if (this != null)
			{
				SetLayerWithChildren(gameObject, "InventoryObjectOutlined");
			}
			else
			{
				SetLayerWithChildren(base.gameObject, "InventoryObjectOutlined");
			}
			DoEquip();
		}

		private static void SetLayerWithChildren(GameObject inventoryPart, string layer)
		{
			inventoryPart.layer = LayerMask.NameToLayer(layer);
			foreach (Transform item in inventoryPart.transform)
			{
				SetLayerWithChildren(item.gameObject, layer);
			}
		}

		void IEquipable.Unequip()
		{
			if (this != null)
			{
				SetLayerWithChildren(gameObject, LayerMask.LayerToName(_defaultLayerMask));
			}
			else
			{
				SetLayerWithChildren(base.gameObject, LayerMask.LayerToName(_defaultLayerMask));
			}
			_playerToolView.ClearToolObject();
			DoUnequip();
		}

		void IInventoryManagable.PickupItem()
		{
		}

		void IInventoryManagable.RemoveItem()
		{
		}

		void IThrowable.Throw(Vector3 direction)
		{
			if (_rb != null)
			{
				_rb.isKinematic = false;
				_rb.linearVelocity = Vector3.zero;
				_rb.AddForce(direction, ForceMode.Impulse);
			}
			else
			{
				Debug.LogError("Rigidbody component is missing on the EquipableToolItem.");
			}
		}

		void IMoveable.Move(Vector3 targetPos)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, targetPos, _smooth * Time.deltaTime);
		}

		protected virtual void DoEquip()
		{
		}

		protected virtual void DoUnequip()
		{
		}
	}
}
