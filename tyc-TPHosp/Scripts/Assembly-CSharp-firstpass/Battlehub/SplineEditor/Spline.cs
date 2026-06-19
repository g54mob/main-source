using UnityEngine;

namespace Battlehub.SplineEditor
{
	[ExecuteInEditMode]
	public class Spline : SplineBase
	{
		private const float Mag = 5f;

		public void Append()
		{
			AppendCurve(5f, enforceNeighbour: false);
		}

		public void AppendThorugh(Transform t)
		{
			Vector3[] array = new Vector3[3];
			AlignWithEnding(array, base.CurveCount - 1, 5f);
			Vector3 pointLocal = GetPointLocal(1f);
			Vector3 vector = (array[2] = base.transform.InverseTransformPoint(t.position - t.forward));
			array[1] = vector - base.transform.InverseTransformVector(t.forward).normalized * (vector - pointLocal).magnitude * (1f / 3f);
			array[0] = vector - base.transform.InverseTransformVector(t.forward).normalized * (vector - pointLocal).magnitude * (2f / 3f);
			AppendCurve(array, enforceNeighbour: false);
		}

		public void Insert(int curveIndex)
		{
			PrependCurve(5f, curveIndex, enforceNeighbour: false, shrinkPreceding: true);
		}

		public void Prepend()
		{
			if (!Loop)
			{
				PrependCurve(5f, 0, enforceNeighbour: false, shrinkPreceding: false);
			}
			else
			{
				AppendCurve(5f, enforceNeighbour: false);
			}
		}

		public void PrependThrough(Transform t)
		{
			if (!Loop)
			{
				Vector3[] array = new Vector3[3];
				AlignWithBeginning(array, 0, 5f);
				Vector3 pointLocal = GetPointLocal(0f);
				Vector3 vector = (array[0] = base.transform.InverseTransformPoint(t.position + t.forward));
				array[1] = vector + base.transform.InverseTransformVector(t.forward).normalized * (vector - pointLocal).magnitude * (1f / 3f);
				array[2] = vector + base.transform.InverseTransformVector(t.forward).normalized * (vector - pointLocal).magnitude * (2f / 3f);
				PrependCurve(array, 0, 5f, enforceNeighbour: false, shrinkPreceding: false);
			}
			else
			{
				AppendThorugh(t);
			}
		}

		public bool Remove(int curveIndex)
		{
			return RemoveCurve(curveIndex);
		}

		public override void Load(SplineSnapshot snapshot)
		{
			LoadSpline(snapshot);
		}

		protected override void OnCurveChanged()
		{
		}

		protected override float GetMag()
		{
			return 5f;
		}

		private void AppendCurve(float mag, bool enforceNeighbour)
		{
			Vector3[] points = new Vector3[3];
			AlignWithEnding(points, base.CurveCount - 1, mag);
			AppendCurve(points, enforceNeighbour);
		}

		private void PrependCurve(float mag, int curveIndex, bool enforceNeighbour, bool shrinkPreceding)
		{
			Vector3[] points = new Vector3[3];
			if (!shrinkPreceding)
			{
				AlignWithBeginning(points, curveIndex, mag);
			}
			PrependCurve(points, curveIndex, mag, enforceNeighbour, shrinkPreceding);
		}
	}
}
