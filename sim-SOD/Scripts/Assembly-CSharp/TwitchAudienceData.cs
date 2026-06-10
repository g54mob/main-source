using System;

[Serializable]
public class TwitchAudienceData
{
	public string user_id;

	public string login;

	public string _links;

	public int chatter_count;

	public Chatters chatters;

	public TwitchRootObject followers;

	public TwitchRootObject chattersNew;

	public TwitchRootObject vipsNew;

	public TwitchRootObject moderatorsNew;
}
