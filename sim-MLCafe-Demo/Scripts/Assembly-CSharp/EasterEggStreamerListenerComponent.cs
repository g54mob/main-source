using Lexone.UnityTwitchChat;
using UnityEngine;

public class EasterEggStreamerListenerComponent : MonoBehaviour
{
	[SerializeField]
	private string channelNameKey;

	[SerializeField]
	private GameObject easterEggPrefab;

	private void Start()
	{
		IRC.Instance.OnConnected.AddListener(delegate
		{
			if (IRC.Instance.channel.ToLower() == channelNameKey.ToLower())
			{
				TryUnlock();
			}
		});
	}

	private void TryUnlock()
	{
		if (!GameObject.Find(channelNameKey))
		{
			GameObject obj = Object.Instantiate(easterEggPrefab, base.transform);
			obj.SetActive(value: true);
			obj.name = channelNameKey;
		}
	}
}
