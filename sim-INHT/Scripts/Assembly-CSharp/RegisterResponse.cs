using System;

public class RegisterResponse
{
	public Guid Id { get; set; }

	public string Username { get; set; }

	public string AvatarBase64 { get; set; }

	public bool DiscordLinked { get; set; }
}
