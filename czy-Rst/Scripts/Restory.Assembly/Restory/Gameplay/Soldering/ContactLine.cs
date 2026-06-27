using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	public class ContactLine : MonoBehaviour
	{
		[SerializeField]
		private LineRenderer lineRenderer;

		public int SegmentCount => lineRenderer.positionCount - ((!IsLoop) ? 1 : 0);

		public bool IsLoop
		{
			get
			{
				if (lineRenderer.loop)
				{
					return lineRenderer.positionCount > 3;
				}
				return false;
			}
		}

		public bool TryGetSegmentByIndex(int index, out Vector3 startPosition, out Vector3 endPosition)
		{
			startPosition = default(Vector3);
			endPosition = default(Vector3);
			int positionCount = lineRenderer.positionCount;
			if (positionCount < 2)
			{
				Debug.LogError("ContactLine must have at least 2 positions");
				return false;
			}
			if (positionCount <= index)
			{
				Debug.LogError(string.Format("{0} out of range, it is {1} but position is {2}", "index", index, positionCount));
				return false;
			}
			startPosition = lineRenderer.GetPosition(index);
			endPosition = lineRenderer.GetPosition((index < lineRenderer.positionCount - 1) ? (index + 1) : 0);
			return true;
		}
	}
}
