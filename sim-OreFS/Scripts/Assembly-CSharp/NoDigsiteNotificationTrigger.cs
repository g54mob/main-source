using I2.Loc;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NoDigsiteNotificationTrigger : MonoBehaviour
{
	[SerializeField]
	private LayerMask triggerLayers;

	private void OnTriggerEnter(Collider other)
	{
		if (((1 << other.gameObject.layer) & (int)triggerLayers) != 0)
		{
			SCC_Network sCC_Network = other.GetComponent<SCC_Network>();
			if (sCC_Network == null)
			{
				sCC_Network = other.GetComponentInParent<SCC_Network>();
			}
			if (!(sCC_Network != null) || sCC_Network.IsLocalOccupant())
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NoDigsiteAvailable"));
			}
		}
	}
}
