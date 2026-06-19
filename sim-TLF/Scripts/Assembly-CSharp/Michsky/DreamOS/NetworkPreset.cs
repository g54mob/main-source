using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class NetworkPreset : MonoBehaviour
	{
		public ButtonManager connectButton;

		public ButtonManager disconnectButton;

		public Image signalImage;

		public Image lockedImage;

		public TextMeshProUGUI titleText;

		public TMP_InputField passwordInput;

		public GameObject indicatorObject;

		[HideInInspector]
		public NetworkManager manager;

		[HideInInspector]
		public string networkID;

		[HideInInspector]
		public string password;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Network;

		private void OnEnable()
		{
			if (!(manager == null))
			{
				if (manager.IsConnectedToNetwork(networkID) && !disconnectButton.gameObject.activeInHierarchy)
				{
					SetConnected();
				}
				else if (!manager.IsConnectedToNetwork(networkID) && disconnectButton.gameObject.activeInHierarchy)
				{
					SetNotConnected();
				}
			}
		}

		public void SetConnected()
		{
			connectButton.gameObject.SetActive(value: false);
			disconnectButton.gameObject.SetActive(value: true);
			passwordInput.gameObject.SetActive(value: false);
			lockedImage.gameObject.SetActive(value: false);
			indicatorObject.gameObject.SetActive(value: true);
		}

		public void SetNotConnected()
		{
			connectButton.gameObject.SetActive(value: true);
			disconnectButton.gameObject.SetActive(value: false);
			indicatorObject.gameObject.SetActive(value: false);
			if (!string.IsNullOrEmpty(password))
			{
				passwordInput.gameObject.SetActive(value: true);
				lockedImage.gameObject.SetActive(value: true);
			}
			else
			{
				passwordInput.gameObject.SetActive(value: false);
				lockedImage.gameObject.SetActive(value: false);
			}
		}

		public void Connect(bool bypassPasswordCheck = false)
		{
			if (bypassPasswordCheck || passwordInput.text == password)
			{
				if (manager.isConnected && manager.currentNetworkIndex >= 0 && manager.currentNetworkIndex < manager.networkItems.Count)
				{
					manager.networkItems[manager.currentNetworkIndex].preset.SetNotConnected();
				}
				passwordInput.text = "";
				SetConnected();
				manager.isConnected = true;
				manager.currentNetworkIndex = manager.GetNetworkIndex(networkID);
				manager.UpdateIndicators();
				DreamOSDataManager.WriteBooleanData(dataCat, "IsConnected", value: true);
				DreamOSDataManager.WriteStringData(dataCat, "CurrentNetwork", networkID);
			}
			else if (passwordInput.text != password)
			{
				passwordInput.text = "";
				manager.PlayWrongPassword();
			}
		}

		public void Disconnect()
		{
			SetNotConnected();
			manager.isConnected = false;
			manager.UpdateIndicators(checkForConnection: true);
			DreamOSDataManager.WriteBooleanData(dataCat, "IsConnected", value: false);
			DreamOSDataManager.WriteStringData(dataCat, "CurrentNetwork", null);
		}
	}
}
