using UnityEngine;

namespace NSMedieval.UI
{
	public class GameplayOverlayHook : MonoBehaviour
	{
		[SerializeField]
		private Transform hookReference;

		[SerializeField]
		private float offset;

		[SerializeField]
		private float smoothTime = 0.2f;

		private Vector3 target;

		private Vector3 velocity = Vector3.zero;

		private void Update()
		{
			Vector3 position = hookReference.position;
			target = new Vector3(position.x, position.y + offset, position.z);
			base.transform.position = Vector3.SmoothDamp(base.transform.position, target, ref velocity, smoothTime);
		}
	}
}
