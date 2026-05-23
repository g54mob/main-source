using System.Collections;
using NGS.MeshFusionPro;
using UnityEngine;

public class BuildingMeshesTracker : BuildingMeshTracker
{
	[SerializeField]
	private MeshFusionSource[] meshFusers;

	private Coroutine freezeWithDelay2;

	private bool freezeWithDelayCoroRunning2;

	public override void Unfreeze()
	{
		if (freezeWithDelayCoroRunning2)
		{
			StopCoroutine(freezeWithDelay2);
			freezeWithDelayCoroRunning2 = false;
		}
		MeshFusionSource[] array = meshFusers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UndoCombine();
		}
	}

	public override void FreezeMeshWithDelay()
	{
		if (freezeWithDelay2 == null)
		{
			freezeWithDelay2 = StartCoroutine(FreezeMeshWithDelayCoro());
			return;
		}
		if (freezeWithDelayCoroRunning2)
		{
			StopCoroutine(freezeWithDelay2);
			freezeWithDelayCoroRunning2 = false;
		}
		freezeWithDelay2 = StartCoroutine(FreezeMeshWithDelayCoro());
	}

	public override IEnumerator FreezeMeshWithDelayCoro()
	{
		freezeWithDelayCoroRunning2 = true;
		yield return new WaitForSeconds(2f);
		MeshFusionSource[] array = meshFusers;
		foreach (MeshFusionSource meshFusionSource in array)
		{
			if (meshFusionSource.gameObject.activeInHierarchy)
			{
				meshFusionSource.AssignToController();
			}
		}
		freezeWithDelayCoroRunning2 = false;
	}
}
