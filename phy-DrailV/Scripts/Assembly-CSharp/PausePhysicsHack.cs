using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePhysicsHack : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Hack());
	}

	private IEnumerator Hack()
	{
		Dictionary<Rigidbody, bool[]> originalParams = new Dictionary<Rigidbody, bool[]>();
		Rigidbody[] componentsInChildren = base.transform.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			originalParams.Add(rigidbody, new bool[2] { rigidbody.useGravity, rigidbody.isKinematic });
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
		}
		yield return WaitFor.SecondsRealtime(1f);
		foreach (KeyValuePair<Rigidbody, bool[]> item in originalParams)
		{
			if (item.Key == null)
			{
				Debug.Log(item);
			}
			item.Key.useGravity = item.Value[0];
			item.Key.isKinematic = item.Value[1];
		}
	}
}
