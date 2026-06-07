using System.Collections;
using DV.Utils;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
	public GameObject pointedObject;

	public Transform pointerOrigin;

	public float maxDistance = 200f;

	private string SWITCH_OBJ_NAME = "SwitchTrigger";

	private RaycastHit[] hits = new RaycastHit[3];

	private bool initialized;

	private void Start()
	{
		if (pointerOrigin == null)
		{
			pointerOrigin = base.transform;
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	private IEnumerator Initialize()
	{
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
		initialized = true;
	}

	private void Update()
	{
		pointedObject = null;
		if (!pointerOrigin.gameObject.activeSelf || !initialized)
		{
			return;
		}
		Ray ray = ((!VRManager.IsVREnabled()) ? new Ray(PlayerManager.PlayerCamera.transform.position, PlayerManager.PlayerCamera.transform.forward) : new Ray(pointerOrigin.position, pointerOrigin.up));
		int num = Physics.RaycastNonAlloc(ray, hits, maxDistance, LayerMask.GetMask("Laser_Pointer_Target"));
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = hits[i].collider.gameObject;
			if (gameObject.name == SWITCH_OBJ_NAME)
			{
				pointedObject = gameObject;
			}
		}
	}
}
