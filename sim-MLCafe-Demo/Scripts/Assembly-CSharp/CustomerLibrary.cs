using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer Library", menuName = "Libraries/Customer Library", order = 1)]
public class CustomerLibrary : ScriptableObject
{
	public List<Customer> customerSelection = new List<Customer>();

	private List<string> names = new List<string>();

	public List<string> GetCustomerNames()
	{
		names.Clear();
		if (names.Count != customerSelection.Count)
		{
			foreach (Customer item in customerSelection)
			{
				names.Add(item.name);
			}
		}
		return names;
	}

	public List<Customer> GetValidCustomersByProgress(int progress)
	{
		List<Customer> list = new List<Customer>();
		for (int i = 0; i < customerSelection.Count; i++)
		{
			if (customerSelection[i].minimumProgressLevel <= progress)
			{
				list.Add(customerSelection[i]);
			}
		}
		return list;
	}
}
