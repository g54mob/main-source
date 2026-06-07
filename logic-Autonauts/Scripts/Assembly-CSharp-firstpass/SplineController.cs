using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Splines/Spline Controller")]
[RequireComponent(typeof(SplineInterpolator))]
public class SplineController : MonoBehaviour
{
	public GameObject SplineRoot;

	public float Duration = 10f;

	public eOrientationMode OrientationMode;

	public eWrapMode WrapMode;

	public bool AutoStart = true;

	public bool AutoClose = true;

	public bool HideOnExecute = true;

	private SplineInterpolator mSplineInterp;

	private Transform[] mTransforms;

	private float[] mTimes;

	private void OnDrawGizmos()
	{
		Transform[] transforms = GetTransforms();
		if (transforms.Length < 2)
		{
			return;
		}
		float[] array = new float[transforms.Length];
		float num = (AutoClose ? (Duration / (float)transforms.Length) : (Duration / (float)(transforms.Length - 1)));
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = num * (float)i;
		}
		SplineInterpolator splineInterpolator = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;
		if (Application.isEditor && !Application.isPlaying)
		{
			SetupSplineInterpolator(splineInterpolator, transforms, array);
			splineInterpolator.StartInterpolation(null, false, WrapMode);
			Vector3 vector = transforms[0].position;
			for (int j = 1; j <= 100; j++)
			{
				float timeParam = (float)j * Duration / 100f;
				Vector3 hermiteAtTime = splineInterpolator.GetHermiteAtTime(timeParam);
				Gizmos.color = new Color((hermiteAtTime - vector).magnitude * 2f, 0f, 0f, 1f);
				Gizmos.DrawLine(vector, hermiteAtTime);
				vector = hermiteAtTime;
			}
		}
	}

	private void Start()
	{
		Go(null);
	}

	public void Go(OnEndCallback Callback, List<Transform> NewTransforms = null, List<float> NewTimes = null)
	{
		mSplineInterp = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;
		if (NewTransforms == null)
		{
			mTransforms = GetTransforms();
		}
		else
		{
			mTransforms = NewTransforms.ToArray();
			mTimes = NewTimes.ToArray();
		}
		if (HideOnExecute)
		{
			DisableTransforms();
		}
		if (AutoStart)
		{
			FollowSpline(Callback);
		}
	}

	private void SetupSplineInterpolator(SplineInterpolator interp, Transform[] trans, float[] times)
	{
		interp.Reset();
		int i;
		for (i = 0; i < trans.Length; i++)
		{
			if (OrientationMode == eOrientationMode.NODE)
			{
				interp.AddPoint(trans[i].position, trans[i].rotation, times[i], new Vector2(0f, 1f));
			}
			else if (OrientationMode == eOrientationMode.TANGENT)
			{
				interp.AddPoint(quat: (i != trans.Length - 1) ? Quaternion.LookRotation(trans[i + 1].position - trans[i].position, trans[i].up) : ((!AutoClose) ? trans[i].rotation : Quaternion.LookRotation(trans[0].position - trans[i].position, trans[i].up)), pos: trans[i].position, timeInSeconds: times[i], easeInOut: new Vector2(0f, 1f));
			}
		}
		if (AutoClose)
		{
			interp.SetAutoCloseMode(times[i]);
		}
	}

	private Transform[] GetTransforms()
	{
		if (SplineRoot != null)
		{
			List<Transform> list = new List<Component>(SplineRoot.GetComponentsInChildren(typeof(Transform))).ConvertAll((Component c) => (Transform)c);
			list.Remove(SplineRoot.transform);
			list.Sort((Transform a, Transform b) => a.name.CompareTo(b.name));
			return list.ToArray();
		}
		return null;
	}

	private void DisableTransforms()
	{
		if (SplineRoot != null)
		{
			SplineRoot.SetActive(false);
		}
	}

	private void FollowSpline(OnEndCallback Callback)
	{
		if (mTransforms.Length != 0)
		{
			SetupSplineInterpolator(mSplineInterp, mTransforms, mTimes);
			mSplineInterp.StartInterpolation(Callback, true, WrapMode);
		}
	}
}
