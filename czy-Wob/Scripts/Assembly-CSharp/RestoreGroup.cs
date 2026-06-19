using System.Collections.Generic;
using UnityEngine;

public class RestoreGroup
{
	public List<GameObject> legsToRestore;

	private List<RotationRestore> restoreRefs;

	public RestoreGroup(List<GameObject> legs)
	{
		legsToRestore = new List<GameObject>();
		legsToRestore.AddRange(legs);
		restoreRefs = new List<RotationRestore>();
		for (int i = 0; i < legsToRestore.Count; i++)
		{
			restoreRefs.Add(legsToRestore[i].GetComponent<RotationRestore>());
		}
	}

	public void RestoreLegs(Vector3 modifier)
	{
		for (int i = 0; i < restoreRefs.Count; i++)
		{
			restoreRefs[i].FixedUpdateRestore(modifier);
		}
	}

	public void AllowRestorationOverride(float timer)
	{
		for (int i = 0; i < restoreRefs.Count; i++)
		{
			restoreRefs[i].AllowRestorationOverride(timer);
		}
	}
}
