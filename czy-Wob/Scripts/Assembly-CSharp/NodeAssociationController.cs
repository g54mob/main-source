using System.Collections.Generic;
using UnityEngine;

public class NodeAssociationController : MonoBehaviour
{
	public bool debugVis;

	private ulong? currentPipe;

	private NavmeshHelper navmeshRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		navmeshRef = registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
	}

	public bool IsInPipe()
	{
		return currentPipe.HasValue;
	}

	public void SetCurrentPipe(GameObject newPipe)
	{
		if (newPipe == null)
		{
			currentPipe = null;
			return;
		}
		BuildObjectInfo component = newPipe.GetComponent<BuildObjectInfo>();
		if (component == null)
		{
			currentPipe = null;
		}
		else
		{
			currentPipe = component.GetUID();
		}
	}

	private Vector3 GetObjectPosition(GameObject obj)
	{
		Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = obj.GetComponentInChildren<Rigidbody>();
			if (rigidbody == null)
			{
				return obj.transform.position;
			}
		}
		return rigidbody.transform.position;
	}

	public List<PathPosition> GetPathToTarget(GameObject target, bool useTargetPosDirectly = false)
	{
		List<PathPosition> list = new List<PathPosition>();
		if (target == null)
		{
			Debug.LogError("Attempting to path a null object.");
			return list;
		}
		Vector3 hitPoint;
		if (useTargetPosDirectly)
		{
			hitPoint = target.transform.position;
		}
		else
		{
			InteractableBase component = target.GetComponent<InteractableBase>();
			hitPoint = ((!(component != null)) ? ObjectUtil.GetObjCenter(target) : component.GetInteractionPoint());
		}
		if (ObjectUtil.GetStageHitpoint(hitPoint, ref hitPoint))
		{
			list.AddRange(navmeshRef.GetPath(base.gameObject, hitPoint));
		}
		return list;
	}
}
