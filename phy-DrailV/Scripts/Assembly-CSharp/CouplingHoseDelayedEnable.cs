using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class CouplingHoseDelayedEnable : MonoBehaviour
{
	private const float WAIT_TIME = 0.1f;

	public GameObject[] childrenToEnable;

	private static Coroutine coro;

	private static readonly List<CouplingHoseDelayedEnable> awaitingEnable = new List<CouplingHoseDelayedEnable>();

	private void OnEnable()
	{
		awaitingEnable.Add(this);
		if (coro == null)
		{
			coro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(Coro());
		}
	}

	private static IEnumerator Coro()
	{
		CouplingHoseDelayedEnable closestToCamera;
		while ((object)(closestToCamera = GetClosestToCamera()) != null && closestToCamera != null)
		{
			GameObject[] array = closestToCamera.childrenToEnable;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
			Object.Destroy(closestToCamera);
			yield return WaitFor.Seconds(0.1f);
		}
		coro = null;
	}

	private static CouplingHoseDelayedEnable GetClosestToCamera()
	{
		int i = -1;
		CouplingHoseDelayedEnable couplingHoseDelayedEnable = null;
		float num = float.PositiveInfinity;
		int numToRemove = 0;
		for (int j = 0; j < awaitingEnable.Count; j++)
		{
			CouplingHoseDelayedEnable couplingHoseDelayedEnable2 = awaitingEnable[j];
			if (couplingHoseDelayedEnable2 == null || !couplingHoseDelayedEnable2.gameObject.activeInHierarchy)
			{
				PrepareRemoveAt(j);
				continue;
			}
			float sqrMagnitude = (PlayerManager.ActiveCamera.transform.position - couplingHoseDelayedEnable2.transform.position).sqrMagnitude;
			if (couplingHoseDelayedEnable == null || sqrMagnitude < num)
			{
				i = j;
				couplingHoseDelayedEnable = couplingHoseDelayedEnable2;
				num = sqrMagnitude;
			}
		}
		if (couplingHoseDelayedEnable != null)
		{
			PrepareRemoveAt(i);
		}
		if (numToRemove > 0)
		{
			awaitingEnable.RemoveRange(awaitingEnable.Count - numToRemove, numToRemove);
		}
		return couplingHoseDelayedEnable;
		void PrepareRemoveAt(int index)
		{
			numToRemove++;
			awaitingEnable[index] = awaitingEnable[awaitingEnable.Count - numToRemove];
		}
	}
}
