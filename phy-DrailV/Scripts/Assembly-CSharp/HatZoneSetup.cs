using System.Collections;
using UnityEngine;

public class HatZoneSetup : MonoBehaviour
{
	private const string SNAP_ZONE_PREFAB = "SnapZone";

	public float yZoneOffset = 0.31f;

	public bool forceAnchorOffset = true;

	public Vector3 anchorOffset = Vector3.zero;

	public Vector3 anchorLocalRotation = Vector3.zero;

	private IEnumerator Start()
	{
		yield return WaitFor.Seconds(5f);
		GameObject gameObject = Object.Instantiate(Resources.Load("SnapZone", typeof(GameObject))) as GameObject;
		Camera playerCamera = PlayerManager.PlayerCamera;
		if (gameObject != null && playerCamera != null)
		{
			Vector3 position = playerCamera.transform.position + playerCamera.transform.up * yZoneOffset;
			gameObject.transform.SetPositionAndRotation(position, playerCamera.transform.rotation);
			gameObject.transform.SetParent(playerCamera.transform);
			if (forceAnchorOffset)
			{
				SnapItemZone component = gameObject.GetComponent<SnapItemZone>();
				component.snapAnchor.transform.localPosition = anchorOffset;
				component.snapAnchor.transform.localRotation = Quaternion.Euler(anchorLocalRotation);
			}
		}
		Object.Destroy(base.gameObject);
	}
}
