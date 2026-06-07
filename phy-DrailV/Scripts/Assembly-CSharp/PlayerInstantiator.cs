using UnityEngine;

public class PlayerInstantiator : MonoBehaviour
{
	[Header("External references")]
	public GameObject vrRigPrefab;

	public GameObject nonVrRigPrefab;

	private void Start()
	{
		GameObject obj = Object.Instantiate(VRManager.IsVREnabled() ? vrRigPrefab : nonVrRigPrefab);
		obj.transform.SetPositionAndRotation(base.transform.position + Vector3.up * 0.05f, base.transform.rotation);
		obj.transform.SetSiblingIndex(base.transform.GetSiblingIndex());
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(base.transform.position, 1f);
		}
	}
}
