using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Link (Path Creator)")]
	public class PathLink_PathCreator : MonoBehaviour, IPath
	{
		[RequiredField]
		public PathCreator m_Path;

		public Vector3 StartPath => base.transform.TransformPoint(m_Path.bezierPath.GetPoint(0));

		public Vector3 EndPath => base.transform.TransformPoint(m_Path.bezierPath.GetPoint(m_Path.bezierPath.NumPoints - 1));

		public bool IsClosed => m_Path.path.isClosedLoop;

		public Bounds bounds => m_Path.path.bounds;

		public float GetClosestTimeOnPath(Vector3 position)
		{
			return m_Path.path.GetClosestTimeOnPath(position);
		}

		public Quaternion GetPathRotation(float NormalizedTime)
		{
			EndOfPathInstruction endOfPathInstruction = ((!IsClosed) ? EndOfPathInstruction.Stop : EndOfPathInstruction.Loop);
			return m_Path.path.GetRotation(NormalizedTime, endOfPathInstruction);
		}

		public Vector3 GetPointAtTime(float NormalizedTime)
		{
			EndOfPathInstruction endOfPathInstruction = ((!IsClosed) ? EndOfPathInstruction.Stop : EndOfPathInstruction.Loop);
			return m_Path.path.GetPointAtTime(NormalizedTime, endOfPathInstruction);
		}

		private void Reset()
		{
			PathCreator component = GetComponent<PathCreator>();
			if (component == null)
			{
				m_Path = base.gameObject.AddComponent<PathCreator>();
			}
			else
			{
				m_Path = component;
			}
		}
	}
}
