using System.Collections;
using I2.Loc;
using Mirror;
using UnityEngine;

public class T_BusStop : MonoBehaviour
{
	[Header("Settings")]
	public bool isFactoryStop;

	public Transform marker;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(0.25f);
		if (!(GameManager.Instance == null))
		{
			if (isFactoryStop && marker != null)
			{
				GameManager.Instance.factoryMarker = marker;
			}
			else if (!isFactoryStop && marker != null)
			{
				GameManager.Instance.digsiteMarker = marker;
			}
		}
	}

	public void TryTeleport()
	{
		if (GameManager.Instance == null)
		{
			return;
		}
		Transform transform;
		LoadingType loadingType;
		if (isFactoryStop)
		{
			transform = GameManager.Instance.digsiteMarker;
			if (transform == null)
			{
				GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NoDigsiteAvailable"));
				return;
			}
			loadingType = LoadingType.Property;
		}
		else
		{
			transform = GameManager.Instance.factoryMarker;
			if (transform == null)
			{
				return;
			}
			loadingType = LoadingType.Scene;
		}
		StartCoroutine(CoTeleport(transform, loadingType));
	}

	private IEnumerator CoTeleport(Transform target, LoadingType loadingType)
	{
		GameManager.Instance.OpenLoadingUI(loadingType);
		yield return new WaitForSeconds(0.1f);
		UpdatePlayerDigsiteStatus();
		TeleportLocalPlayer(target);
		yield return new WaitForSeconds(0.75f);
		GameManager.Instance.CloseLoadingUIImmediate(loadingType);
	}

	private void TeleportLocalPlayer(Transform target)
	{
		NetworkIdentity localPlayer = NetworkClient.localPlayer;
		if (!(localPlayer == null))
		{
			GamePlayer component = localPlayer.GetComponent<GamePlayer>();
			if (component != null)
			{
				component.NetworkTeleport(target.position, target.rotation);
			}
		}
	}

	private void UpdatePlayerDigsiteStatus()
	{
		if (!(NetworkClient.localPlayer == null))
		{
			GamePlayer component = NetworkClient.localPlayer.GetComponent<GamePlayer>();
			if (!(component == null))
			{
				component.SetIsInDigsite(isFactoryStop);
			}
		}
	}
}
