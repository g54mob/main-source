using System.Collections.Generic;
using UnityEngine;

public class MailBase : MonoBehaviour
{
	public static MailBase instance;

	public AppMail appMail;

	public TabletAppMail tabletAppMail;

	public List<Mail> mailsReceived;

	private void Awake()
	{
	}

	public void addMail(string title, int fromUserId, string to, string contents, string time, bool isRead, string[] tag, string taskID = "", int howMuchAttachments = 0, bool isWebAttachments = false, string linkToWeb = "", bool isPdfAttachments = false, int idPdf = 0)
	{
	}

	public void removeMail(Mail mail)
	{
	}

	public void RemoveDeletedMails()
	{
	}

	public void VerifyRefresh()
	{
	}

	public List<Mail> FindMails(string findText)
	{
		return null;
	}

	public string MailToJson()
	{
		return null;
	}

	public void JsonToMail(string json)
	{
	}
}
