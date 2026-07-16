using UnityEngine;

public class PlaceableRegisterComponent : MonoBehaviour
{
	public enum PlaceableRegistrationType
	{
		None = 0,
		ServiceCounter = 1,
		Seat = 2,
		Table = 3,
		Toillete = 4
	}

	public PlaceableRegistrationType registrationType;

	[SerializeField]
	private bool registerOnStart;

	private void Start()
	{
		if (registerOnStart)
		{
			OnPlace();
		}
	}

	public void OnPlace()
	{
		switch (registrationType)
		{
		case PlaceableRegistrationType.ServiceCounter:
			CafeShopManager.RegisterServiceCounter(GetComponent<ServiceCounterComponent>());
			break;
		case PlaceableRegistrationType.Seat:
			CafeShopManager.RegisterSeat(GetComponent<CustomerUseableComponent>());
			break;
		case PlaceableRegistrationType.Table:
			CafeShopManager.RegisterTable(GetComponent<CustomerUseableComponent>());
			break;
		}
	}

	public void OnRemove()
	{
		switch (registrationType)
		{
		case PlaceableRegistrationType.ServiceCounter:
			CafeShopManager.UnregisterServiceCounter(GetComponent<ServiceCounterComponent>());
			break;
		case PlaceableRegistrationType.Seat:
			CafeShopManager.UnregisterSeat(GetComponent<CustomerUseableComponent>());
			break;
		case PlaceableRegistrationType.Table:
			CafeShopManager.UnregisterTable(GetComponent<CustomerUseableComponent>());
			break;
		}
	}
}
