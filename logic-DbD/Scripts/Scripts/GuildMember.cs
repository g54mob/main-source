public class GuildMember
{
	public string username;

	public string playerClass;

	public GuildMember(string username, string playerClass)
	{
		this.username = username;
		this.playerClass = playerClass;
	}

	public override string ToString()
	{
		return "'" + username + "', '" + playerClass + "'";
	}
}
