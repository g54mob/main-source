using UnityEngine;

namespace NSMedieval.Manager
{
	public class MenuShownIndicator : MonoBehaviour
	{
		private Transform followTarget;

		public void FollowTarget(Transform target)
		{
			followTarget = target;
		}

		private void Update()
		{
			if (followTarget != null)
			{
				base.transform.position = followTarget.position;
			}
		}
	}
}
