using UnityEngine;

public class CustomerUseableComponent : MonoBehaviour
{
	[SerializeField]
	private Transform pointPosition;

	private CustomerCore customer;

	public bool InUse()
	{
		return customer != null;
	}

	public void Claim(CustomerCore customer)
	{
		this.customer = customer;
		if (GetComponent<RemovableInstance>() != null)
		{
			GetComponent<RemovableInstance>().Deactivate();
		}
	}

	public void Free()
	{
		customer = null;
		if (GetComponent<RemovableInstance>() != null)
		{
			GetComponent<RemovableInstance>().Activate();
		}
	}

	public Transform GetPointTransform()
	{
		return pointPosition;
	}
}
