using System.Collections;
using NGS.MeshFusionPro;
using UnityEngine;

public class BuildingMeshTracker : MonoBehaviour
{
	[SerializeField]
	private MeshFusionSource meshFuser;

	private Coroutine freezeWithDelay;

	private bool freezeWithDelayCoroRunning;

	protected void OnEnable()
	{
		FreezeMeshWithDelay();
	}

	protected void OnDisable()
	{
		Unfreeze();
	}

	public virtual void Unfreeze()
	{
		if (freezeWithDelayCoroRunning)
		{
			StopCoroutine(freezeWithDelay);
			freezeWithDelayCoroRunning = false;
		}
		meshFuser.UndoCombine();
	}

	public virtual void FreezeMeshWithDelay()
	{
		if (!meshFuser.gameObject.activeInHierarchy)
		{
			return;
		}
		if (freezeWithDelay == null)
		{
			freezeWithDelay = StartCoroutine(FreezeMeshWithDelayCoro());
			return;
		}
		if (freezeWithDelayCoroRunning)
		{
			StopCoroutine(freezeWithDelay);
			freezeWithDelayCoroRunning = false;
		}
		freezeWithDelay = StartCoroutine(FreezeMeshWithDelayCoro());
	}

	public virtual IEnumerator FreezeMeshWithDelayCoro()
	{
		freezeWithDelayCoroRunning = true;
		yield return new WaitForSeconds(2f);
		meshFuser.AssignToController();
		freezeWithDelayCoroRunning = false;
	}
}
