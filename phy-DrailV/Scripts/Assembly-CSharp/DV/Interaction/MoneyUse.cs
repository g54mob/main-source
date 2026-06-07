using System.Collections;
using DV.CabControls;
using DV.CashRegister;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class MoneyUse : MonoBehaviour, IItemUseAnimated, IItemUse, IInteractionPointProvider
	{
		private IMoney money;

		private ItemBase item;

		public Transform InteractionPoint
		{
			get
			{
				if (!(this != null))
				{
					return null;
				}
				return base.transform;
			}
		}

		private void Awake()
		{
			if (!TryGetComponent<IMoney>(out money))
			{
				Debug.LogError("Unexpected state: Couldn't extract IMoney for MoneyUse script. Deleting this script!", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			if (!TryGetComponent<ItemBase>(out item))
			{
				Debug.LogError("Unexpected state: Couldn't extract ItemBase for MoneyUse script. Deleting this script!", base.gameObject);
				Object.Destroy(this);
			}
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			if ((bool)target.GetComponent<CashRegisterBase>())
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.WalletCashRegisterUse);
			}
			else
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.WalletMoneyUse);
			}
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			if (target.TryGetComponent<CashRegisterBase>(out var component))
			{
				double remainingCost = component.GetRemainingCost();
				if (remainingCost <= 0.0)
				{
					return false;
				}
				component.AddCash(money.TrySpend(remainingCost));
				if (!money.ShouldDestroyOnUse)
				{
					return true;
				}
				item.ForceEndInteraction();
				SingletonBehaviour<CoroutineManager>.Instance.Run(HandleMoneyDestroy());
				return true;
			}
			if (!target.TryGetComponent<IMoney>(out var component2))
			{
				return false;
			}
			if (money.ShouldDestroyOnUse == component2.ShouldDestroyOnUse)
			{
				return false;
			}
			if (money.ShouldDestroyOnUse)
			{
				money.StashMoney();
			}
			else
			{
				component2.StashMoney();
			}
			return true;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			if (!target.TryGetComponent<CashRegisterBase>(out var component) || !(component.GetRemainingCost() > 0.0))
			{
				if (target.TryGetComponent<IMoney>(out var component2))
				{
					return money.ShouldDestroyOnUse != component2.ShouldDestroyOnUse;
				}
				return false;
			}
			return true;
		}

		private IEnumerator HandleMoneyDestroy()
		{
			if (VRManager.IsVREnabled())
			{
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}

		public (Vector3 pos, Quaternion rot) TargetPoint(ItemUseTarget target)
		{
			if (target.TryGetComponent<CashRegisterBase>(out var component))
			{
				return (pos: component.InteractionPoint.position, rot: component.InteractionPoint.rotation);
			}
			if (target.TryGetComponent<IMoney>(out var component2) && (bool)component2.gameObject)
			{
				return (pos: component2.gameObject.transform.position, rot: component2.gameObject.transform.rotation);
			}
			return default((Vector3, Quaternion));
		}
	}
}
