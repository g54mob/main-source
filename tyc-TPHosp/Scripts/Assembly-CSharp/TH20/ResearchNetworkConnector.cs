using UnityEngine;

namespace TH20
{
	public abstract class ResearchNetworkConnector : MonoBehaviour
	{
		protected Vector3 StartPosition;

		protected Vector3 EndPosition;

		public virtual void Setup(Vector3 startPosition, Vector3 endPosition)
		{
			StartPosition = startPosition;
			EndPosition = endPosition;
		}
	}
}
