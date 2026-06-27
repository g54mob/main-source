using System;

public class LeaderboardEntryResponse
{
	public Guid Id { get; set; }

	public string Key { get; set; }

	public int Position { get; set; }

	public string Username { get; set; }

	public string AvatarBase64 { get; set; }

	public int Score { get; set; }

	[Obsolete]
	public string ImageBase64 { get; set; }

	[Obsolete]
	public string[] ImagesBase64 { get; set; }

	[Obsolete]
	public string[] FrameUrls { get; set; }

	public string ImageUrl { get; set; }

	public string GifUrl { get; set; }

	public string ZipUrl { get; set; }

	public DateTime CreatedAtUtc { get; set; }
}
