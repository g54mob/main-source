using System;
using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Computer.Sites.SellOrWaste;
using Items;
using JSAM;
using Loxodon.Framework.Contexts;
using Player;
using Player.Arms;
using UnityEngine;
using Zenject;

public class UsableConsumableItem : MonoBehaviour, IInventoryManagable, IEquipable, IThrowable, ISmoothMovable, IMoveable, IProductConfigGetter
{
	[SerializeField]
	private Rigidbody _rb;

	[SerializeField]
	private PartConfig _inventoryItem;

	[SerializeField]
	protected PlayerProgressiveConsumableObject _consumableObject;

	[SerializeField]
	private ProductObjectConfig _productConfig;

	private string _id;

	private float _smooth = 5f;

	[Inject]
	private DiContainer _container;

	[Inject]
	private IPlayerConsumeService _playerConsumeService;

	[Inject]
	private IFallenItemsService _fallenItemsService;

	private PlayerArmsViewModel _playerArmsViewModel;

	PartConfig IInventoryManagable.ItemConfig => _inventoryItem;

	string IInventoryManagable.ID => _id;

	ProductObjectConfig IProductConfigGetter.Config => _productConfig;

	public PlayerProgressiveConsumableObject ConsumableObject => _consumableObject;

	float ISmoothMovable.Smooth => _smooth;

	protected virtual void Start()
	{
		_id = DateTime.UtcNow.Ticks.ToString();
		_container.Inject(_consumableObject);
		_consumableObject.Resolve();
		_playerArmsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<PlayerArmsViewModel>();
		_fallenItemsService?.Register(this);
	}

	protected virtual void OnDestroy()
	{
		_fallenItemsService?.Unregister(this);
	}

	void IInventoryManagable.PickupItem()
	{
	}

	void IInventoryManagable.RemoveItem()
	{
	}

	void IThrowable.Throw(Vector3 direction)
	{
		base.gameObject.SetActive(value: true);
		_rb.isKinematic = false;
		_rb.linearVelocity = Vector3.zero;
		_rb.AddForce(direction, ForceMode.Impulse);
	}

	public virtual void Equip()
	{
		foreach (SoundFileObject equipSound in _consumableObject.EquipSounds)
		{
			AudioManager.PlaySound(equipSound);
		}
		Debug.Log("Equiping Usable Consumable Item");
		_consumableObject.Consume(this);
		_playerConsumeService.SetConsumingWorldItem(_consumableObject.SideConsuming, this);
	}

	public virtual void Unequip()
	{
		Debug.Log("UNequiping Usable Consumable Item");
		_consumableObject.TryUnuse();
	}

	void IMoveable.Move(Vector3 targetPos)
	{
		base.transform.position = Vector3.Lerp(base.transform.position, targetPos, _smooth * Time.deltaTime);
	}
}
