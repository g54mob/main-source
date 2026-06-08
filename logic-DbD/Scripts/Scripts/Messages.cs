public static class Messages
{
	public static string SuccessfullyDownloaded(string tableName)
	{
		return "Finished downloading <i>" + tableName + "</i>.";
	}

	public static string AlreadyDownloaded(string tableName)
	{
		return "<i>" + tableName + "</i> has already been downloaded.";
	}

	public static string MoviesDownloadFailed()
	{
		return "Our servers are currently incinerated.\nPlease come back soon.";
	}

	public static string MenuDownloadSuccess()
	{
		return "Thank you for downloading our menu!";
	}

	public static string StarDownloadSuccess()
	{
		return "Download complete.\nGo and find your star!";
	}

	public static string StarAlreadyDownloaded()
	{
		return "Slow down there!\nYou've already downloaded the stars!";
	}

	public static string StarsDownloadFailed()
	{
		return "Download failed.\nPlease try again soon to find your star!";
	}

	public static string LZUDownloadFailed()
	{
		return "The Los Zorangeles University servers are currently down.\nPlease let computer technician Alan Douglas know ASAP!!!\nThank you for your patience (this will not excuse late submissions).";
	}

	public static string GuildMembersServerDown()
	{
		return "guildsfornewhampshire.com\nis not currently available.";
	}

	public static string GuildMembersDownloadFailed(string guild)
	{
		return "Guild members for " + WikiLevel.guildNameMap[guild] + "\nhas already been downloaded.";
	}

	public static string PayupDownloadError()
	{
		return "Our servers for payup are down.\nPlease try again soon!";
	}

	public static string PayupDownloadFailed(string account)
	{
		return "Transaction history for " + account + " has already been downloaded.";
	}

	public static string RentDownloadFailed()
	{
		return "Sorry, our servers are down!\nPlease come back later.\nDon't forget to tip your landlord!";
	}

	public static string RentAlreadyDownloaded()
	{
		return "You want to rent a place that badly?\nrentals has already been downloaded!";
	}

	public static string RentSuccess()
	{
		return "Good luck finding a place!\nDon't forget to tip your landlord!";
	}

	public static string ClownDownloadFailed()
	{
		return "Our servers are clowning around!\nCome back again later!";
	}

	public static string DonatorDownloadFailed()
	{
		return "Our servers might be under siege.\nPlease come back later to appreciate our supporters.";
	}

	public static string DonatorDownloadSuccess()
	{
		return "Thank you for appreciating our supporters.";
	}

	public static string NutritionDownloadFailed()
	{
		return "SOMEONE DOESNT WANT YOU TO BE HEALTHY!!!\nOUR SERVERS ARE DOWN!!!!";
	}

	public static string OrderDownloadFailed()
	{
		return "Whoops, sorry about that.\nCan't seem to fetch your order.";
	}

	public static string OrderAlreadyDownloaded()
	{
		return "Your order has already been downloaded.";
	}

	public static string NoPackageFound(string name)
	{
		return "No packages found for " + name;
	}

	public static string OrderDownloadedSuccess()
	{
		return "Your order information has\nsuccessfully downloaded.";
	}

	public static string GenericDownloadFailed()
	{
		return "Our servers are down right now.\nPlease try again later.";
	}

	public static string SSSDownloadFailed()
	{
		return "It is not the time for that yet.";
	}
}
