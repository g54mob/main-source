using UnityEngine;

public class LauncherTriggerArea : MonoBehaviour
{
	public DoggyLauncher launcherRef;

	public DoggyLauncher.TriggerType tType;

	private void OnCollisionEnter(Collision c)
	{
		launcherRef.OnObjectInTriggerArea(tType);
	}

	private void OnTriggerStay(Collider other)
	{
		if (tType == DoggyLauncher.TriggerType.UNDER_PAD && other != null && ObjectGrabber.IsTagDraggable(other.transform.root.gameObject.tag))
		{
			launcherRef.OnObjectInTriggerArea(tType);
		}
	}
}
