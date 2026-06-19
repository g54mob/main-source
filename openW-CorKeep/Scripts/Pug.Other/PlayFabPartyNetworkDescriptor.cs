using UnityEngine;

public class PlayFabPartyNetworkDescriptor
{
	public string FullId { get; }

	public string Guid { get; }

	public string Suffix { get; }

	public PlayFabPartyNetworkDescriptor(string fullNetworkId)
	{
		FullId = fullNetworkId;
		string[] array = fullNetworkId.Split('|');
		if (array.Length == 0)
		{
			Debug.LogError("PlayFabPartyNetworkDescriptor: network id " + fullNetworkId + " is not a valid PlayFab Party network descriptor as it's missing the | character. This instance will have invalid Guid and Suffix.");
			return;
		}
		Guid = array[0];
		if (array.Length == 1)
		{
			Debug.LogError("PlayFabPartyNetworkDescriptor: network id " + fullNetworkId + " is not a valid PlayFab Party network descriptor as it's missing the | character. This instance will have invalid Guid and Suffix.");
		}
		else
		{
			Suffix = array[1];
		}
	}

	public override string ToString()
	{
		return "PlayFabPartyNetworkDescriptor:\nFull ID: " + FullId + "\nGUID: " + Guid + "\nSuffix: " + Suffix;
	}
}
