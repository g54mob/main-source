using System.Collections.Generic;
using UnityEngine;

public class CustomerStrategiesManager : NoktaSingleton<CustomerStrategiesManager>
{
	[SerializeField]
	private List<CustomerStrategySO> m_CustomerStrategies;

	public CustomerStrategySO CurrentStrategy => null;
}
