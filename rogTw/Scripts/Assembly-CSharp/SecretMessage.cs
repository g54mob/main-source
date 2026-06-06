using UnityEngine;
using UnityEngine.UI;

public class SecretMessage : MonoBehaviour
{
	[SerializeField]
	private Text message;

	[SerializeField]
	private string[] messages;

	private void Start()
	{
		if (message == null || messages.Length < 1)
		{
			Debug.LogError("Empty secret message " + base.gameObject.name);
		}
		else
		{
			message.text = messages[Random.Range(0, messages.Length)];
		}
	}
}
