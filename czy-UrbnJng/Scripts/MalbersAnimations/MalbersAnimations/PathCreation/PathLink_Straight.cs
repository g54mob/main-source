using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Link (Straight)")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/path-constraint/path-link-straight")]
	public class PathLink_Straight : MonoBehaviour, IPath
	{
		public Vector3 EndPoint = Vector3.forward;

		[Tooltip("Rotation Along the Spline")]
		public float Roll;

		public bool ShowTangents;

		public float TangentLength = 0.2f;

		[Min(1f)]
		public int TangentCount = 20;

		public Color TangentColor = Color.yellow;

		public Vector3 StartPath => base.transform.position;

		public Vector3 EndPath => base.transform.TransformPoint(EndPoint);

		public bool IsClosed => false;

		public Bounds bounds => CalculateBounds();

		public float GetClosestTimeOnPath(Vector3 position)
		{
			return position.ClosestTimeOnSegment(StartPath, EndPath);
		}

		public Quaternion GetPathRotation(float NormalizedTime)
		{
			return Quaternion.Euler(0f, 0f, Roll * NormalizedTime) * base.transform.rotation;
		}

		public Vector3 GetPointAtTime(float NormalizedTime)
		{
			return StartPath + (EndPath - StartPath) * NormalizedTime;
		}

		internal Bounds CalculateBounds()
		{
			Bounds result = default(Bounds);
			result.Encapsulate(EndPoint);
			return result;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(StartPath, EndPath);
			Gizmos.DrawSphere(StartPath, 0.02f * base.transform.localScale.y);
			Gizmos.DrawSphere(EndPath, 0.02f * base.transform.localScale.y);
			if (ShowTangents)
			{
				Gizmos.color = TangentColor;
				for (int i = 0; i <= TangentCount; i++)
				{
					float num = (float)i / (float)TangentCount;
					Vector3 direction = Quaternion.Euler(0f, 0f, Roll * num) * (base.transform.up * TangentLength);
					Gizmos.DrawRay(GetPointAtTime(num), direction);
				}
			}
		}
	}
}
