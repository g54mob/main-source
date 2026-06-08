using UnityEngine;
using UnityEngine.UI;

public class MessageContainerController : MonoBehaviour
{
	[SerializeField]
	private GameObject messagePrefab;

	[SerializeField]
	private AudioMessageManager messageManager;

	private AudioSwitcher audioPlayer;

	private void Awake()
	{
		audioPlayer = GetComponent<AudioSwitcher>();
	}

	public void SetMessage(Message message)
	{
		foreach (Transform item in base.transform)
		{
			item.GetComponent<Button>().interactable = true;
		}
		messageManager.SetDisplayMessage(message);
	}

	public void SetMostRecentMessage()
	{
		Transform child = base.transform.GetChild(0);
		Message component = child.GetComponent<Message>();
		SetMessage(component);
		child.GetComponent<Button>().interactable = false;
	}

	public void AddMessage(Message message)
	{
		GameObject obj = Object.Instantiate(messagePrefab, base.transform.position, Quaternion.identity, base.transform);
		obj.GetComponent<Message>().SetMessage(message);
		obj.transform.SetAsFirstSibling();
		SetMostRecentMessage();
	}

	public void PlayMessageClickEffect()
	{
		audioPlayer.PlayEffect();
	}
}
