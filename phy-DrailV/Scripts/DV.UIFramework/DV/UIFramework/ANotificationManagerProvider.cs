using UnityEngine;

namespace DV.UIFramework
{
	public abstract class ANotificationManagerProvider : MonoBehaviour
	{
		public abstract RectTransform ContentRoot { get; }

		public abstract void AddWorldSpacePointer(GameObject notification, Transform to, bool targetIsUI, GameObject owner);

		public abstract void ClearWorldSpacePointer(GameObject notification);

		public abstract void OnNotificationAdded(GameObject notification);
	}
}
