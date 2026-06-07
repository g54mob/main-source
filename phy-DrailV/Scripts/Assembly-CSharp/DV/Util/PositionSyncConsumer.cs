using UnityEngine;

namespace DV.Util
{
	public class PositionSyncConsumer : MonoBehaviour
	{
		public string syncTag;

		private Transform providerTransform;

		public void SetProviderTransform(PositionSyncProvider positionSyncProvider)
		{
			if (syncTag != positionSyncProvider.syncTag)
			{
				Debug.LogError("Unexpected state: Bad connection on PositionSyncConsumer, non-matching tags (" + syncTag + ", " + providerTransform.tag);
			}
			else
			{
				providerTransform = positionSyncProvider.transform;
			}
		}

		public void Sync()
		{
			base.transform.position = providerTransform.position;
		}
	}
}
