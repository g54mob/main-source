using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpdateChecker : MonoBehaviour
{
	public Character character;

	public ConfirmationBox box;

	public HoverTooltip tooltip;

	private UnityAction yesAction;

	private UnityAction noAction;

	private PlayerTime updateCheckTime;

	public Text buildText;

	public void Start()
	{
		yesAction = acknowledge;
		noAction = acknowledge;
		updateCheckTime = new PlayerTime();
	}

	public void test()
	{
		box.displayBox("Hey! There's a new update available for the game: Build 0.butts! Refresh if you want some new NGU hotness!", "Sweet!", "Cool!", yesAction, noAction);
	}

	public void Update()
	{
		updateCheckTime.advanceTime(Time.deltaTime);
		if (!(updateCheckTime.totalseconds >= 1800.0))
		{
			return;
		}
		updateCheckTime.setTime(0f);
		if (character.settings.checkForUpdates)
		{
			if (character.platform == platform.Kong)
			{
				StartCoroutine(checkForKongUpdate());
			}
			else if (character.platform == platform.AG)
			{
				StartCoroutine(checkForAGUpdate());
			}
			else if (character.platform == platform.Kartridge)
			{
				StartCoroutine(checkForKartUpdate());
			}
			else if (character.platform == platform.Steam)
			{
				StartCoroutine(checkForSteamUpdate());
			}
		}
	}

	public IEnumerator checkForKongUpdate()
	{
		int curVersion = character.getVersion();
		string url = "https://www.nguidle.com/currentVersion.php";
		WWW www = new WWW(url);
		yield return new WaitForSeconds(1f);
		if (www.isDone && string.IsNullOrEmpty(www.error))
		{
			curVersion = int.Parse(www.text);
		}
		if (curVersion > character.getVersion())
		{
			box.displayBox("Hey! There's a new update available for the game: Build " + character.getVersionAsString(curVersion) + "! Refresh if you want some new NGU hotness!", "Sweet!", "Cool!", yesAction, noAction);
			buildText.text = "<b>REFRESH FOR NEW BUILD</b>";
		}
	}

	public IEnumerator checkForAGUpdate()
	{
		int curVersion = character.getVersion();
		string url = "https://www.nguidle.com/currentAGVersion.php";
		WWW www = new WWW(url);
		yield return new WaitForSeconds(1f);
		if (www.isDone && string.IsNullOrEmpty(www.error))
		{
			curVersion = int.Parse(www.text);
		}
		if (curVersion > character.getVersion())
		{
			box.displayBox("Hey! There's a new update available for the game: Build " + character.getVersionAsString(curVersion) + "! Refresh if you want some new NGU hotness!", "Sweet!", "Cool!", yesAction, noAction);
			buildText.text = "<b>REFRESH FOR NEW BUILD</b>";
		}
	}

	public IEnumerator checkForKartUpdate()
	{
		int curVersion = character.getVersion();
		string url = "https://www.nguidle.com/currentKartVersion.php";
		WWW www = new WWW(url);
		yield return new WaitForSeconds(1f);
		if (www.isDone && string.IsNullOrEmpty(www.error))
		{
			curVersion = int.Parse(www.text);
		}
		if (curVersion > character.getVersion())
		{
			box.displayBox("Hey! There's a new update available for the game: Build " + character.getVersionAsString(curVersion) + "! Close the game and check your Kartridge Library to update your game!", "Sweet!", "Cool!", yesAction, noAction);
			buildText.text = "<b>REFRESH FOR NEW BUILD</b>";
		}
	}

	public IEnumerator checkForSteamUpdate()
	{
		int curVersion = character.getVersion();
		string url = "https://www.nguidle.com/currentSteamVersion.php";
		WWW www = new WWW(url);
		yield return new WaitForSeconds(1f);
		if (www.isDone && string.IsNullOrEmpty(www.error))
		{
			curVersion = int.Parse(www.text);
		}
		if (curVersion > character.getVersion())
		{
			box.displayBox("Hey! There's a new update available for the game: Build " + character.getVersionAsString(curVersion) + "! Close the game and let Steam update it, if you want!", "Sweet!", "Cool!", yesAction, noAction);
			buildText.text = "<b>REFRESH FOR NEW BUILD</b>";
		}
	}

	public void acknowledge()
	{
	}
}
