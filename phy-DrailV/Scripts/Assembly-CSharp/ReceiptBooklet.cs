using System.Collections;
using UnityEngine;

public class ReceiptBooklet : MonoBehaviour
{
	private IEnumerator Start()
	{
		yield return null;
		RespawnOnDrop component = GetComponent<RespawnOnDrop>();
		if (component != null)
		{
			component.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			Debug.LogError("RespawnOnDrop not found on ReceiptBooklet!", this);
		}
	}
}
