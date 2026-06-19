using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class NetworkManager : MonoBehaviour
	{
		[Serializable]
		public class NetworkItem
		{
			public string networkID = "My Network";

			public string password = "password";

			public SignalPower signalPower;

			[Range(0.1f, 100f)]
			public float networkSpeed = 20f;

			[HideInInspector]
			public NetworkPreset preset;
		}

		public enum SignalPower
		{
			Weak = 0,
			Normal = 1,
			Strong = 2,
			Best = 3
		}

		public List<NetworkItem> networkItems = new List<NetworkItem>();

		public GameObject networkPreset;

		public List<Image> networkIndicators = new List<Image>();

		public bool dynamicNetwork = true;

		[Range(0.1f, 100f)]
		public float defaultSpeed = 20f;

		public bool isConnected;

		public int currentNetworkIndex;

		[SerializeField]
		private Sprite signalDisconnected;

		[SerializeField]
		private Sprite signalWeak;

		[SerializeField]
		private Sprite signalNormal;

		[SerializeField]
		private Sprite signalStrong;

		[SerializeField]
		private Sprite signalBest;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Network;

		private void Awake()
		{
			if (!dynamicNetwork)
			{
				isConnected = true;
				return;
			}
			if (DreamOSDataManager.ContainsJsonKey(dataCat, "IsConnected"))
			{
				isConnected = DreamOSDataManager.ReadBooleanData(dataCat, "IsConnected");
			}
			if (isConnected && DreamOSDataManager.ContainsJsonKey(dataCat, "CurrentNetwork"))
			{
				currentNetworkIndex = GetNetworkIndex(DreamOSDataManager.ReadStringData(dataCat, "CurrentNetwork"));
			}
			UpdateIndicators(checkForConnection: true);
		}

		public void ListNetworks(Transform parent)
		{
			if (!dynamicNetwork)
			{
				isConnected = true;
				return;
			}
			foreach (Transform item in parent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < networkItems.Count; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(networkPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(parent, worldPositionStays: false);
				gameObject.gameObject.name = networkItems[i].networkID;
				NetworkPreset preset = gameObject.GetComponent<NetworkPreset>();
				preset.manager = this;
				preset.networkID = networkItems[i].networkID;
				preset.password = networkItems[i].password;
				preset.signalImage.sprite = GetSignalPowerSprite(networkItems[i].signalPower);
				preset.titleText.text = preset.networkID;
				networkItems[i].preset = preset;
				preset.connectButton.onClick.AddListener(delegate
				{
					preset.Connect();
				});
				preset.disconnectButton.onClick.AddListener(delegate
				{
					preset.Disconnect();
				});
				if (i == currentNetworkIndex && isConnected)
				{
					preset.Connect(bypassPasswordCheck: true);
				}
				else
				{
					preset.SetNotConnected();
				}
			}
		}

		public void ConnectToNetwork(string networkID, string password = null)
		{
			for (int i = 0; i < networkItems.Count; i++)
			{
				if (!(networkItems[i].preset == null) && networkID == networkItems[i].networkID && password == networkItems[i].password)
				{
					networkItems[i].preset.Connect(bypassPasswordCheck: true);
					break;
				}
			}
		}

		public void DisconnectFromNetwork()
		{
			if (isConnected)
			{
				if (networkItems[currentNetworkIndex].preset != null)
				{
					networkItems[currentNetworkIndex].preset.Disconnect();
					return;
				}
				DreamOSDataManager.WriteBooleanData(dataCat, "IsConnected", value: false);
				UpdateIndicators();
			}
		}

		public void UpdateIndicators(bool checkForConnection = false)
		{
			foreach (Image networkIndicator in networkIndicators)
			{
				if (!(networkIndicator == null))
				{
					if (currentNetworkIndex < 0 || currentNetworkIndex >= networkItems.Count)
					{
						networkIndicator.sprite = signalDisconnected;
					}
					else
					{
						networkIndicator.sprite = GetSignalPowerSprite(networkItems[currentNetworkIndex].signalPower, checkForConnection);
					}
				}
			}
		}

		public void PlayWrongPassword()
		{
			if (AudioManager.instance != null)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.errorSound);
			}
		}

		public void CreateNetwork(string networkID, string password, SignalPower signalPower)
		{
			NetworkItem networkItem = new NetworkItem();
			networkItem.networkID = networkID;
			networkItem.signalPower = signalPower;
			networkItem.password = password;
			networkItems.Add(networkItem);
		}

		public Sprite GetSignalPowerSprite(SignalPower power, bool checkForConnection = false)
		{
			Sprite result = null;
			if (!isConnected && checkForConnection)
			{
				result = signalDisconnected;
			}
			else
			{
				switch (power)
				{
				case SignalPower.Weak:
					result = signalWeak;
					break;
				case SignalPower.Normal:
					result = signalNormal;
					break;
				case SignalPower.Strong:
					result = signalStrong;
					break;
				case SignalPower.Best:
					result = signalBest;
					break;
				}
			}
			return result;
		}

		public int GetNetworkIndex(string networkID)
		{
			int result = -1;
			for (int i = 0; i < networkItems.Count; i++)
			{
				if (networkItems[i].networkID == networkID)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public bool IsConnectedToNetwork(int index)
		{
			if (isConnected && currentNetworkIndex == index)
			{
				return true;
			}
			return false;
		}

		public bool IsConnectedToNetwork(string networkID)
		{
			int networkIndex = GetNetworkIndex(networkID);
			if (isConnected && currentNetworkIndex == networkIndex)
			{
				return true;
			}
			return false;
		}
	}
}
