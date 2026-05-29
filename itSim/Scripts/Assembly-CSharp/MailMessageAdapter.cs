using UnityEngine;
using UnityEngine.UI;

public class MailMessageAdapter : MonoBehaviour
{
	public Text title;

	public Text from;

	public Text contents;

	public Text time;

	public Transform isRead;

	[SerializeField]
	public Image avatar;

	public Mail mail;

	public AppMail appMail;

	public void OpenMail()
	{
	}
}
