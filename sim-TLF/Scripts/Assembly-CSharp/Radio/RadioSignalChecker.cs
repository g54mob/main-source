using UnityEngine;

namespace Radio
{
	public class RadioSignalChecker : MonoBehaviour
	{
		[Tooltip("Transform used as the listener position (e.g. player or radio object)")]
		[SerializeField]
		private Transform listenerTransform;

		private void Awake()
		{
			if (listenerTransform == null)
			{
				listenerTransform = base.transform;
			}
		}

		public bool HasSignal(RadioChannel channel)
		{
			if (channel.signalRadius <= 0f)
			{
				return true;
			}
			return Vector3.Distance(listenerTransform.position, channel.signalOrigin) <= channel.signalRadius;
		}

		public void SetListener(Transform t)
		{
			listenerTransform = t;
		}
	}
}
