using System;
using App.Data;
using Localization;
using UnityEngine;

public class ForumMessageData : BaseKeyData, ICloneable
{
	public string authorKey;

	public string messageKey;

	public string avatarSpriteName;

	public int depth;

	private string author;

	private string message;

	public string Author => author ?? (author = TextResources.GetString(authorKey));

	public string Message => message ?? (message = TextResources.GetString(messageKey));

	public Sprite AvatarSprite
	{
		get
		{
			if (avatarSpriteName == null)
			{
				return null;
			}
			return Logic.LoadSprite(avatarSpriteName);
		}
	}

	public ForumMessageData()
	{
	}

	public ForumMessageData(string author, string message, string avatarSpriteName, int depth)
	{
		authorKey = author;
		messageKey = message;
		this.avatarSpriteName = avatarSpriteName;
		this.depth = depth;
	}

	public object Clone()
	{
		return new ForumMessageData((authorKey == null) ? null : ((string)authorKey.Clone()), (messageKey == null) ? null : ((string)messageKey.Clone()), (avatarSpriteName == null) ? null : ((string)avatarSpriteName.Clone()), depth)
		{
			KeyName = (string)KeyName.Clone()
		};
	}
}
