public static class LinkConstants
{
	public enum LinkEnum
	{
		Website = 0,
		Newsletter = 1,
		Discord = 2,
		Feedback = 3,
		BugReport = 4,
		ClickMage = 5,
		LostMaximSteam = 6
	}

	public const string Website = "https://lostmaxim.com";

	public const string Discord = "https://lostmaxim.com/discord";

	public const string Newsletter = "https://lostmaxim.com/newsletter";

	public const string BugReportForm = "https://lostmaxim.com/bugreport";

	public const string ClickMage = "https://store.steampowered.com/app/3228180/Click_Mage/";

	public const string LostMaximSteam = "https://store.steampowered.com/developer/lostmaxim";

	public const string FeedbackForm = "https://docs.google.com/forms/d/e/1FAIpQLSfic1pHruQSPnkmCDj20KtK6vGcEp8_CzbIePxyxNAmymeOwA/viewform";

	public static string GetLink(LinkEnum link)
	{
		return null;
	}

	public static void OpenURL(LinkEnum link)
	{
	}
}
