using Aggro.Core;
using UnityEngine;

public class Billboard : EntityBehaviourBase
{
	protected override void OnUpdatePresentation()
	{
		Vector3 normalized = (base.transform.position - GameUtil.mainCamera.transform.position).normalized;
		base.transform.rotation = Quaternion.LookRotation(normalized);
	}
}
