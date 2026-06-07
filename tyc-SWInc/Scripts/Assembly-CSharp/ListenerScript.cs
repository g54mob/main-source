using UnityEngine;

public class ListenerScript : MonoBehaviour
{
	public AnimationCurve GroundListenerCurve;

	private void Update()
	{
		if (CameraScript.Instance != null)
		{
			if (CameraScript.Instance.FlyMode)
			{
				base.transform.SetPositionAndRotation(CameraScript.Instance.mainCam.transform.position, CameraScript.Instance.mainCam.transform.rotation);
				return;
			}
			Vector3 position = base.transform.parent.position;
			Vector3 position2 = CameraScript.Instance.mainCam.transform.position;
			Vector3 a = new Vector3(position.x, position.y - CameraScript.Instance.mainCam.transform.localPosition.z / 8f, position.z);
			a = Vector3.Lerp(a, position2 + CameraScript.Instance.mainCam.nearClipPlane * CameraScript.Instance.mainCam.transform.forward, GroundListenerCurve.Evaluate(position2.y - position.y));
			base.transform.position = a;
			base.transform.localRotation = Quaternion.identity;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.2f);
	}
}
