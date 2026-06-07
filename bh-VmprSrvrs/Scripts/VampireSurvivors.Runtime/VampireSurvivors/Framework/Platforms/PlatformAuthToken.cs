namespace VampireSurvivors.Framework.Platforms
{
	public class PlatformAuthToken
	{
		public string Token { get; set; }

		public string Signature { get; set; }

		public int IssuerId { get; set; }
	}
}
