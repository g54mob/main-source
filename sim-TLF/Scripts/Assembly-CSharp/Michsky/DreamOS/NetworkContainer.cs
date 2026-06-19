using UnityEngine;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Network/Network Container")]
	public class NetworkContainer : MonoBehaviour
	{
		[SerializeField]
		private NetworkManager networkManager;

		private void Start()
		{
			ListNetworks();
		}

		public void ListNetworks()
		{
			if (networkManager == null)
			{
				if (Object.FindObjectsByType<NetworkManager>(FindObjectsSortMode.None).Length == 0)
				{
					Debug.Log("<b>[Network Container]</b> Network Manager is missing.", this);
					return;
				}
				networkManager = Object.FindObjectsByType<NetworkManager>(FindObjectsSortMode.None)[0];
			}
			foreach (Transform item in base.transform)
			{
				Object.Destroy(item.gameObject);
			}
			networkManager.ListNetworks(base.transform);
		}
	}
}
