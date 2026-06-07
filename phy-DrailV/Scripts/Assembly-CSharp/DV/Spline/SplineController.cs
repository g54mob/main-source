using System.Collections.Generic;
using UnityEngine;

namespace DV.Spline
{
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

		private void OnDrawGizmos()
		{
			Transform[] transforms = GetTransforms();
			if (transforms.Length >= 2)
			{
				SplineInterpolator splineInterpolator = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;
				SetupSplineInterpolator(splineInterpolator, transforms);
				splineInterpolator.StartInterpolation(null, bRotations: false, WrapMode);
				Vector3 vector = transforms[0].position;
				for (int i = 1; i <= 100; i++)
				{
					float timeParam = (float)i * Duration / 100f;
					Vector3 hermiteAtTime = splineInterpolator.GetHermiteAtTime(timeParam);
					Gizmos.color = new Color((hermiteAtTime - vector).magnitude * 2f, 0f, 0f, 1f);
					Gizmos.DrawLine(vector, hermiteAtTime);
					vector = hermiteAtTime;
				}
			}
		}

		private void Start()
		{
			mSplineInterp = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;
			mTransforms = GetTransforms();
			if (HideOnExecute)
			{
				DisableTransforms();
			}
			if (AutoStart)
			{
				FollowSpline();
			}
		}

		private void SetupSplineInterpolator(SplineInterpolator interp, Transform[] trans)
		{
			interp.Reset();
			float num = (AutoClose ? (Duration / (float)trans.Length) : (Duration / (float)(trans.Length - 1)));
			int i;
			for (i = 0; i < trans.Length; i++)
			{
				if (OrientationMode == eOrientationMode.NODE)
				{
					interp.AddPoint(trans[i].position, trans[i].rotation, num * (float)i, new Vector2(0f, 1f));
				}
				else if (OrientationMode == eOrientationMode.TANGENT)
				{
					interp.AddPoint(quat: (i != trans.Length - 1) ? Quaternion.LookRotation(trans[i + 1].position - trans[i].position, trans[i].up) : ((!AutoClose) ? trans[i].rotation : Quaternion.LookRotation(trans[0].position - trans[i].position, trans[i].up)), pos: trans[i].position, timeInSeconds: num * (float)i, easeInOut: new Vector2(0f, 1f));
				}
			}
			if (AutoClose)
			{
				interp.SetAutoCloseMode(num * (float)i);
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
				SplineRoot.SetActive(value: false);
			}
		}

		private void FollowSpline()
		{
			if (mTransforms.Length != 0)
			{
				SetupSplineInterpolator(mSplineInterp, mTransforms);
				mSplineInterp.StartInterpolation(null, bRotations: true, WrapMode);
			}
		}
	}
}
