using System;
using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.CashRegister
{
	public abstract class CashRegisterBase : MonoBehaviour, IInteractionPointProvider
	{
		private const float RETURN_MONEY_CHECK_PERIOD = 2f;

		private const float RETURN_MONEY_SQR_DISTANCE = 400f;

		public static List<CashRegisterBase> allCashRegisters;

		[SerializeField]
		private Transform interactionPoint;

		[Header("Audio")]
		public AudioClip buyAudio;

		public AudioClip cancelAudio;

		public AudioClip notEnoughMoneyAudio;

		public AudioClip addCashAudio;

		private MoneyPrinter moneyPrinter;

		public double DepositedCash { get; private set; }

		public virtual bool IsProcessingTransaction { get; set; }

		public Transform InteractionPoint => interactionPoint;

		public event Action CashAdded;

		public event Action CashRemoved;

		protected virtual void Awake()
		{
			if (allCashRegisters == null)
			{
				allCashRegisters = new List<CashRegisterBase>();
			}
			allCashRegisters.Add(this);
			moneyPrinter = GetComponent<MoneyPrinter>();
			if (moneyPrinter == null)
			{
				Debug.LogError("MoneyPrinter component isn't attached to CashRegisterBase!", this);
			}
		}

		protected virtual void OnEnable()
		{
			StartCoroutine(ReturnMoneyToPlayerCheck(2f));
		}

		protected virtual void OnDisable()
		{
			StopAllCoroutines();
			ReturnDepositedMoneyToWallet();
		}

		protected virtual void OnDestroy()
		{
			if (!allCashRegisters.Remove(this))
			{
				Debug.LogError("Unexpected state: CashRegisterBase was not part of allCashRegisters");
			}
		}

		public abstract double GetTotalCost();

		public abstract float TotalUnitsInBasket();

		public virtual bool Buy()
		{
			if (TotalUnitsInBasket() == 0f)
			{
				return false;
			}
			double totalCost = GetTotalCost();
			if (DepositedCash >= totalCost && !IsProcessingTransaction)
			{
				RemoveCash(totalCost);
				ReturnLeftoverDepositedCash();
				buyAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
				return true;
			}
			notEnoughMoneyAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			return false;
		}

		public virtual void Cancel()
		{
			if (DepositedCash > 0.0)
			{
				cancelAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			ReturnLeftoverDepositedCash();
		}

		public double GetRemainingCost()
		{
			return GetTotalCost() - DepositedCash;
		}

		public void SetCash(double amount)
		{
			double depositedCash = DepositedCash;
			if (depositedCash != amount)
			{
				DepositedCash = amount;
				if (depositedCash < amount)
				{
					addCashAudio.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
					this.CashAdded?.Invoke();
				}
				else if (depositedCash > amount)
				{
					this.CashRemoved?.Invoke();
				}
			}
		}

		public void AddCash(double amount)
		{
			SetCash(DepositedCash + amount);
		}

		public void RemoveCash(double amount)
		{
			SetCash(DepositedCash - amount);
		}

		private void ReturnLeftoverDepositedCash()
		{
			if (DepositedCash > 0.0)
			{
				moneyPrinter.PrintMoney(DepositedCash);
				SetCash(0.0);
			}
		}

		private void OnTriggerEnter(Collider col)
		{
			double remainingCost = GetRemainingCost();
			if (remainingCost == 0.0)
			{
				return;
			}
			IMoney componentInParent = col.GetComponentInParent<IMoney>();
			if (componentInParent == null)
			{
				return;
			}
			ItemBase componentInParent2 = col.GetComponentInParent<ItemBase>();
			if ((bool)componentInParent2 && componentInParent2.IsGrabbed())
			{
				if (componentInParent.ShouldDestroyOnUse)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedMoneyDestroy(componentInParent2));
				}
				if (componentInParent.Amount > double.Epsilon)
				{
					componentInParent.SoundAlreadyPlayed = true;
					AddCash(componentInParent.TrySpend(remainingCost));
				}
			}
		}

		private void ReturnDepositedMoneyToWallet()
		{
			if (DepositedCash > 0.0)
			{
				SingletonBehaviour<Inventory>.Instance.AddMoney(DepositedCash);
				SetCash(0.0);
			}
		}

		private IEnumerator ReturnMoneyToPlayerCheck(float timeout)
		{
			WaitForSeconds waitTimeout = WaitFor.Seconds(timeout);
			while (true)
			{
				yield return waitTimeout;
				if (!(DepositedCash <= 0.0) && !(PlayerManager.PlayerTransform == null) && (PlayerManager.PlayerTransform.position - base.transform.position).sqrMagnitude > 400f)
				{
					ReturnDepositedMoneyToWallet();
				}
			}
		}

		private IEnumerator DelayedMoneyDestroy(ItemBase item)
		{
			item.ForceEndInteraction();
			yield return null;
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}
}
