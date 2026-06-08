using System;
using UnityEngine;

namespace Dorfromantik
{
	public class NetworkEventRouter : ScriptableObject
	{
		private bool _003CIsLinkedToAccount_003Ek__BackingField;

		private bool _003CIsConnectedToNetwork_003Ek__BackingField;

		public bool IsLinkedToAccount
		{
			get
			{
				return _003CIsLinkedToAccount_003Ek__BackingField;
			}
			private set
			{
				_003CIsLinkedToAccount_003Ek__BackingField = value;
			}
		}

		public bool IsConnectedToNetwork
		{
			get
			{
				return _003CIsConnectedToNetwork_003Ek__BackingField;
			}
			private set
			{
				_003CIsConnectedToNetwork_003Ek__BackingField = value;
			}
		}

		public event Action OnNetworkConnectionChanged;

		public event Action<bool> OnAccountLinkedStatusChanged;

		public event Action<bool> OnRequestAccountLink;

		public event Action<bool> OnRequestNetworkConnection;

		public event Action<string, int, string, Action<string>> OnRequestOpenSystemKeyboard;

		public void RequestNetworkConnection()
		{
			Debug.Log("NetworkEventRouter - Request Network Connection Link");
			this.OnRequestNetworkConnection?.Invoke(obj: false);
		}

		public void RequestAccountLink()
		{
			Debug.Log("NetworkEventRouter - Request Account Link");
			this.OnRequestAccountLink?.Invoke(obj: false);
		}

		public void RequestNetworkConnectionOrAccountLink()
		{
			if (!IsConnectedToNetwork)
			{
				this.OnRequestNetworkConnection?.Invoke(obj: true);
			}
			else if (!IsLinkedToAccount)
			{
				this.OnRequestAccountLink?.Invoke(obj: true);
			}
		}

		public void BroadcastNetworkConnectionChanged(bool connected)
		{
			Debug.Log($"NetworkEventRouter - Broadcast Network Connection Changed - connected? {connected}");
			IsConnectedToNetwork = connected;
			this.OnNetworkConnectionChanged?.Invoke();
		}

		public void BroadcastAccountLinkedChanged(bool linked)
		{
			Debug.Log($"NetworkEventRouter - Broadcast Account Linked Changed - linked? {linked}");
			IsLinkedToAccount = linked;
			this.OnNetworkConnectionChanged?.Invoke();
		}

		public void RequestOpenSystemKeyboard(string description, int maxTextLength, string existingText, Action<string> textEntered)
		{
			this.OnRequestOpenSystemKeyboard?.Invoke(description, maxTextLength, existingText, textEntered);
		}
	}
}
