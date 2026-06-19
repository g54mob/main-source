using UnityEngine;

public class ExcavationStatue : EntityMonoBehaviour
{
	public Transform lightTransform;

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.variation == 1)
		{
			lightTransform.gameObject.SetActive(value: true);
		}
		else
		{
			lightTransform.gameObject.SetActive(value: false);
		}
	}
}
