using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MailMessageAdapterTablet : MonoBehaviour
{
	public TextMeshProUGUI title;

	public TextMeshProUGUI from;

	public TextMeshProUGUI contents;

	public TextMeshProUGUI time;

	public Transform isRead;

	[SerializeField]
	public Image avatar;

	public Mail mail;

	public TabletAppMail tabletAppMail;

	public void OpenMail()
	{
	}
}
