using System;
using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Services;
using UI.HUD;
using UnityEngine;
using Zenject;

namespace Items
{
	public class MoneyCard : MonoBehaviour, IInventoryManagable, IUsable, IThrowable, ISmoothMovable, IMoveable, IActiveStateSaveable
	{
		[SerializeField]
		private Rigidbody _rb;

		[SerializeField]
		private float _minMoney;

		[SerializeField]
		private float _maxMoney;

		[Inject]
		private IMoneyService _moneyService;

		[Inject]
		private PlayerHUDView _playerHUDView;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		private float _smooth = 5f;

		string IInventoryManagable.ID
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		PartConfig IInventoryManagable.ItemConfig => null;

		float ISmoothMovable.Smooth => _smooth;

		private void Start()
		{
			_fallenItemsService?.Register(this);
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		public void Throw(Vector3 direction)
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

		void IInventoryManagable.PickupItem()
		{
		}

		void IInventoryManagable.RemoveItem()
		{
		}

		void IUsable.UnUse()
		{
		}

		void IUsable.Use()
		{
			float num = UnityEngine.Random.Range(_minMoney, _maxMoney);
			_playerHUDView.InfoMessageSender.SendMoneyMessage(num);
			_moneyService.AddCurrency(num);
			base.gameObject.SetActive(value: false);
		}
	}
}
