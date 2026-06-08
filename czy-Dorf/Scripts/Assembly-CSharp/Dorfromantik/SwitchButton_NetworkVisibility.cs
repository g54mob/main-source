using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class SwitchButton_NetworkVisibility : MonoBehaviour
	{
		private enum NetworkEventType
		{
			ConnectedToNetwork = 0,
			LinkedToAccount = 1,
			Any = 2
		}

		[SerializeField]
		private GameObject target;

		[SerializeField]
		private NetworkEventRouter networkEventRouter;

		[SerializeField]
		private NetworkEventType networkCondition;

		[SerializeField]
		private List<RuntimePlatform> platformsToShowOn;

		private void OnEnable()
		{
			if (!platformsToShowOn.Contains(Application.platform))
			{
				target.SetActive(value: false);
				return;
			}
			networkEventRouter.OnNetworkConnectionChanged += ShowBasedOnNetworkConnectionStatus;
			ShowBasedOnNetworkConnectionStatus();
		}

		private void ShowBasedOnNetworkConnectionStatus()
		{
			switch (networkCondition)
			{
			case NetworkEventType.Any:
				target.SetActive(!networkEventRouter.IsConnectedToNetwork || !networkEventRouter.IsLinkedToAccount);
				break;
			case NetworkEventType.ConnectedToNetwork:
				target.SetActive(!networkEventRouter.IsConnectedToNetwork);
				break;
			case NetworkEventType.LinkedToAccount:
				target.SetActive(networkEventRouter.IsConnectedToNetwork && !networkEventRouter.IsLinkedToAccount);
				break;
			}
		}

		private void OnDisable()
		{
			networkEventRouter.OnNetworkConnectionChanged -= ShowBasedOnNetworkConnectionStatus;
		}
	}
}
