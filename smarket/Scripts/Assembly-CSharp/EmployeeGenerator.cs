using UnityEngine;
using __Project__.Scripts.Janitor;

public class EmployeeGenerator : NoktaSingleton<EmployeeGenerator>
{
	public Cashier SpawnCashier(Cashier prefab)
	{
		return null;
	}

	public Restocker SpawnRestocker(Restocker prefab, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public CustomerHelper SpawnCustomerHelper(CustomerHelper prefab)
	{
		return null;
	}

	public SecurityGuard SpawnSecurityGuard(SecurityGuard prefab)
	{
		return null;
	}

	public Janitor SpawnJanitor(Janitor prefab, Vector3 position, Quaternion rotation)
	{
		return null;
	}

	public IceCreamHelper SpawnIceCreamHelper(IceCreamHelper prefab)
	{
		return null;
	}
}
