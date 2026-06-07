using System.Collections;
using System.Linq;
using DV;
using DV.Utils;
using UnityEngine;

public class CameraAnchorBedSleepingAnimation : MonoBehaviour
{
	private static string N = "[CameraAnchorBedSleepingAnimation]";

	public CameraAnchorLeanCrouch originalScript;

	public Transform head;

	public Transform pillowTarget;

	public float duration = 4f;

	public AnimationCurveAsset xzCurve;

	public AnimationCurveAsset yCurve;

	public AnimationCurveAsset rotationCurve;

	public AnimationCurveAsset rotateDownCurve;

	public bool debugAnimate;

	private Vector3 initialHeadLocalPosition;

	private Quaternion initialHeadLocalRotation;

	private float startTime;

	private bool GotNulls
	{
		get
		{
			if ((bool)pillowTarget && ((bool)head || (bool)originalScript) && (bool)xzCurve && (bool)yCurve && (bool)rotationCurve)
			{
				return !rotateDownCurve;
			}
			return true;
		}
	}

	private void Awake()
	{
		if (VRManager.IsVREnabled())
		{
			Debug.LogError(N + " shouldn't be used in VR, removing self");
			Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		if (GotNulls)
		{
			Debug.LogWarning(N + " something is null, disabling self");
			SingletonBehaviour<CoroutineManager>.Instance.Run(FindClosestBed());
			base.enabled = false;
			return;
		}
		if (!head)
		{
			head = originalScript.cameraAnchor;
		}
		initialHeadLocalPosition = base.transform.InverseTransformPoint(head.position);
		initialHeadLocalRotation = head.rotation * Quaternion.Inverse(base.transform.rotation);
		startTime = Time.timeSinceLevelLoad;
		if ((bool)originalScript)
		{
			originalScript.enabled = false;
		}
	}

	private void OnDisable()
	{
		if ((bool)originalScript)
		{
			originalScript.enabled = true;
		}
	}

	private IEnumerator FindClosestBed()
	{
		yield return WaitFor.SecondsRealtime(0.05f);
		if (!pillowTarget)
		{
			BedSleeping bedSleeping = (from b in Object.FindObjectsOfType<BedSleeping>()
				orderby Vector3.Distance(b.transform.position, base.transform.position)
				select b).FirstOrDefault();
			if ((bool)bedSleeping)
			{
				Debug.Log(N + " found closest bed: " + bedSleeping.name);
				pillowTarget = bedSleeping.pillowTarget;
				base.enabled = true;
			}
		}
	}

	private (Vector3, Quaternion) GetPosRot(float t)
	{
		Vector3 a = base.transform.TransformPoint(initialHeadLocalPosition);
		Quaternion a2 = base.transform.rotation * initialHeadLocalRotation;
		Vector3 item = Vector3.LerpUnclamped(a, pillowTarget.position, xzCurve.Evaluate(t));
		item.y = Mathf.LerpUnclamped(a.y, pillowTarget.position.y, yCurve.Evaluate(t));
		Quaternion b = Quaternion.FromToRotation(base.transform.forward, Vector3.down);
		b = Quaternion.Slerp(Quaternion.identity, b, rotateDownCurve.Evaluate(t));
		Quaternion item2 = b * Quaternion.Slerp(a2, pillowTarget.rotation, rotationCurve.Evaluate(t));
		return (item, item2);
	}

	private void Update()
	{
		if (GotNulls)
		{
			return;
		}
		float num;
		if (debugAnimate)
		{
			num = Time.timeSinceLevelLoad % duration;
			num /= duration;
			if (Mathf.FloorToInt(Time.timeSinceLevelLoad % (2f * duration) / duration) == 1)
			{
				num = 1f;
			}
		}
		else
		{
			num = Mathf.Clamp01((Time.timeSinceLevelLoad - startTime) / duration);
		}
		(head.position, head.rotation) = GetPosRot(num);
	}

	private void OnDrawGizmosSelected()
	{
		if (!GotNulls)
		{
			if (!Application.isPlaying)
			{
				initialHeadLocalPosition = head.localPosition;
				initialHeadLocalRotation = head.localRotation;
			}
			for (float num = 0f; num <= 1f; num += 0.025f)
			{
				Gizmos.color = Color.green;
				var (vector, quaternion) = GetPosRot(num);
				Gizmos.DrawSphere(vector, 0.03f);
				Gizmos.DrawLine(vector, vector + quaternion * Vector3.forward * 0.1f);
			}
		}
	}
}
