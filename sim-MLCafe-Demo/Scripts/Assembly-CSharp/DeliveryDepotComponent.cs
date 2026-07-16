using System.Linq;
using UnityEngine;

public class DeliveryDepotComponent : MonoBehaviour
{
	[SerializeField]
	private ItemSocket[] packageSockets;

	[SerializeField]
	private bool registerOnStart = true;

	private void Start()
	{
		if (registerOnStart)
		{
			InitDeliveryDepotComponent();
		}
	}

	public int GetSocketCount()
	{
		return packageSockets.Length;
	}

	public int GetCurrentPackageCount()
	{
		return packageSockets.Where((ItemSocket x) => x.IsHoldingItem()).Count();
	}

	public bool DepotIsFull()
	{
		return !packageSockets.Any((ItemSocket x) => !x.IsHoldingItem());
	}

	private ItemSocket GetFreeSocket()
	{
		return packageSockets.FirstOrDefault((ItemSocket x) => !x.IsHoldingItem());
	}

	public bool TryDeliverPackage(DeliveryPackage package)
	{
		if (DepotIsFull())
		{
			return false;
		}
		ItemSocket freeSocket = GetFreeSocket();
		if (freeSocket == null)
		{
			return false;
		}
		freeSocket.PushItem(package.GetComponent<ItemComponent>());
		TweenerManager.TweenTimeAction("DeliveredPackage_", 0.5f, delegate
		{
			package.gameObject.SetActive(value: true);
		});
		package.AssignDepot(this);
		return true;
	}

	public void TakePackage(DeliveryPackage package)
	{
		DeliverSystem.TakeDeliveredPackage(1);
	}

	public void InitDeliveryDepotComponent()
	{
		if (!DeliverSystem.IsDepotRegistered(this))
		{
			DeliverSystem.RegisterDeliveryDepotSlot(this);
		}
	}

	public void RemoveDepot()
	{
		if (DeliverSystem.IsDepotRegistered(this) && DeliverSystem.GetRegisteredDepotCount() > 1)
		{
			DeliverSystem.UnregisterDeliveryDepotSlot(this);
		}
	}

	public void LoadDeliverPackage(DeliveryPackage package)
	{
		if (DepotIsFull())
		{
			Object.Destroy(package.gameObject);
			return;
		}
		ItemSocket freeSocket = GetFreeSocket();
		if (freeSocket == null)
		{
			Object.Destroy(package.gameObject);
			return;
		}
		freeSocket.PushItem(package.GetComponent<ItemComponent>());
		package.gameObject.SetActive(value: true);
		package.AssignDepot(this);
	}
}
