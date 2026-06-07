using System.Collections.Generic;
using UnityEngine;

public class GlobalDataBankHelper : MonoBehaviour
{
	public static GlobalDataBankHelper Singleton;

	public Dictionary<ulong, GameObject> playerObjectsDictionary = new Dictionary<ulong, GameObject>();

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}
}
