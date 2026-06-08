namespace LaundryBear.PlatformServices
{
	public interface IProfanityService
	{
		int CleanProfanity(Region region, string inputText, out string cleanedText);

		void CleanProfanity(Region region, string inputText, OnCleanProfanityComplete callback);
	}
}
