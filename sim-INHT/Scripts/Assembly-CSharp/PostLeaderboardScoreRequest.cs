public class PostLeaderboardScoreRequest
{
	public string SessionKey { get; set; }

	public string DeviceId { get; set; }

	public bool ClientTampered { get; set; }

	public string ImageBase64 { get; set; }

	public string[] ImagesBase64 { get; set; }

	public LeaderboardRunData RunData { get; set; }
}
