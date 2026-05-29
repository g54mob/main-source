using System;
using UnityEngine;

[Serializable]
public class Mail
{
	public string title;

	public int fromUserId;

	public string to;

	public string contents;

	public string time;

	public string[] tag;

	public bool isRead;

	public int howMuchAttachments;

	public bool isWebAttachments;

	public string linkToWeb;

	public bool isPdfAttachments;

	public int idPdf;

	public string taskID;

	public Transform _object;

	public Mail(string title, int fromUserId, string to, string contents, string time, bool isRead, string[] tag, string taskID, int howMuchAttachments, bool isWebAttachments, string linkToWeb, bool isPdfAttachments, int idPdf)
	{
	}

	public string GetContentsShort(int maxLength)
	{
		return null;
	}

	public string GetTitleShort(int maxLength)
	{
		return null;
	}

	public string GetFromUserEmail()
	{
		return null;
	}
}
