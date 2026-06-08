using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mmdb_profile : WebsiteDownload
{
	[SerializeField]
	private GameObject profileNotFoundObject;

	[SerializeField]
	private GameObject profileFoundObject;

	[SerializeField]
	private TextMeshProUGUI username;

	[SerializeField]
	private TextMeshProUGUI bio;

	[SerializeField]
	private Image image;

	[SerializeField]
	private TextMeshProUGUI movieReviewed;

	[SerializeField]
	private TextMeshProUGUI reviewScore;

	[SerializeField]
	private TextMeshProUGUI review;

	public static string SUSPECT_PROFILE = "ribbit78";

	private static Dictionary<string, ProfileSettings> profileSettings;

	public const string URL = "mmdb.com/profile/";

	public static string REVIEWS_PREFIX = "reviews_";

	private static string currentUser;

	public override bool LoadPage(string url)
	{
		currentUser = url.Substring("mmdb.com/profile/".Length);
		if (!mmdb_profile.profileSettings.ContainsKey(currentUser))
		{
			ProfileFound(found: false);
			return true;
		}
		ProfileFound(found: true);
		ProfileSettings profileSettings = mmdb_profile.profileSettings[currentUser];
		username.text = currentUser;
		bio.text = profileSettings.bio;
		movieReviewed.text = profileSettings.movieReviewed;
		reviewScore.text = profileSettings.rating;
		review.text = profileSettings.review;
		image.sprite = ResourcesManager.GetImage("Website UI/mmdb/profile/pic" + profileSettings.image);
		return true;
	}

	public void DownloadRatings()
	{
		if (LevelManager.GetCurrLevel() != 5)
		{
			FailPopup(Messages.MoviesDownloadFailed());
			return;
		}
		string tableName = REVIEWS_PREFIX + currentUser;
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup("User's reviews has already been downloaded.");
			return;
		}
		SuccessPopupMessage(notificationPrefab, "User's reviews have been downloaded!");
		Level5.CreateReviewsTable(currentUser);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}

	public static List<string> GetProfileNames()
	{
		return new List<string>(profileSettings.Keys);
	}

	public static void SetProfiles(Dictionary<string, ProfileSettings> mmdb_profiles)
	{
		profileSettings = mmdb_profiles;
	}

	private void ProfileFound(bool found)
	{
		profileNotFoundObject.SetActive(!found);
		profileFoundObject.SetActive(found);
	}
}
