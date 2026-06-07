using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class LeaderboardDisplayManager : MonoBehaviour
{
	[SerializeField]
	private RectTransform globalContentParent;

	[SerializeField]
	private RectTransform friendContentParent;

	[SerializeField]
	private RectTransform userContentParent;

	[SerializeField]
	private GameObject displayObjectPrefab;

	[SerializeField]
	private Vector2 displayOffset;

	[SerializeField]
	private int globalEntriesShown;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Scrollbar scrollbar;

	private LeaderboardEntryDisplayObject userGlobalLeaderboardEntryDisplayObject;

	private LeaderboardEntryDisplayObject userFriendLeaderboardEntryDisplayObject;

	private bool isViewingGlobal = true;

	[SerializeField]
	private TMP_Text leaderboardText;

	[SerializeField]
	private LocalizedString leaderboardString;

	[SerializeField]
	private LocalizedString globalString;

	[SerializeField]
	private LocalizedString friendString;

	[SerializeField]
	private GameObject blackScreen;

	[SerializeField]
	private GameObject noEntriesText;

	[SerializeField]
	private Material avatarMat;

	private bool noGlobalEntriesToShow;

	private bool noFriendsEntriesToShow;

	private bool isInitialized;

	[SerializeField]
	private float timeOut;

	private float elapsedTimeOut;

	private void Awake()
	{
		isInitialized = false;
		blackScreen.SetActive(value: true);
		noEntriesText.SetActive(value: false);
	}

	private void Start()
	{
		Initialize();
	}

	private async void Initialize()
	{
		string leaderboardString = "BestSpeedrunTime";
		string cheatLeaderboardString = "CheaterSpeedrunTime";
		bool hasPreviouslyCheated = await CheatPrevention.CheckIfPreviouslyCheated();
		LeaderboardEntry[] globalLeaderboardEntries = await SteamLeaderboards.TryGetGlobalLeaderboardEntries(leaderboardString, globalEntriesShown);
		if (hasPreviouslyCheated)
		{
			globalLeaderboardEntries = MergeLeaderboardEntryArrayAndSort(globalLeaderboardEntries, await SteamLeaderboards.TryGetGlobalLeaderboardEntries(cheatLeaderboardString, globalEntriesShown));
		}
		if (globalLeaderboardEntries != null)
		{
			CreateLeaderboardEntryDisplayObjects(globalLeaderboardEntries, globalContentParent);
		}
		else
		{
			noGlobalEntriesToShow = true;
		}
		LeaderboardEntry[] friendLeaderboardEntries = await SteamLeaderboards.TryGetFriendLeaderboardEntries(leaderboardString);
		if (hasPreviouslyCheated)
		{
			friendLeaderboardEntries = MergeLeaderboardEntryArrayAndSort(friendLeaderboardEntries, await SteamLeaderboards.TryGetFriendLeaderboardEntries(cheatLeaderboardString));
		}
		if (friendLeaderboardEntries != null)
		{
			CreateLeaderboardEntryDisplayObjects(friendLeaderboardEntries, friendContentParent);
		}
		else
		{
			noFriendsEntriesToShow = true;
		}
		LeaderboardEntry[] array = await SteamLeaderboards.TryGetGlobalLeaderboardEntriesAroundUser(leaderboardString, 0, 0);
		if (hasPreviouslyCheated)
		{
			array = await SteamLeaderboards.TryGetGlobalLeaderboardEntriesAroundUser(cheatLeaderboardString, 0, 0);
		}
		if (array != null)
		{
			userGlobalLeaderboardEntryDisplayObject = await InstantiateDisplayObject(array[0], userContentParent);
			userGlobalLeaderboardEntryDisplayObject.transform.localPosition = Vector2.zero;
			LeaderboardEntry[] array2 = friendLeaderboardEntries;
			for (int i = 0; i < array2.Length; i++)
			{
				LeaderboardEntry leaderboardEntry = array2[i];
				Friend user = leaderboardEntry.User;
				if (user.IsMe)
				{
					userFriendLeaderboardEntryDisplayObject = await InstantiateDisplayObject(leaderboardEntry, userContentParent);
					userFriendLeaderboardEntryDisplayObject.transform.localPosition = Vector2.zero;
					break;
				}
			}
		}
		SetGlobal();
		blackScreen.SetActive(value: false);
		SoundManager.LoadSoundEffect(base.transform, SoundManager.instance.titel_impact);
		isInitialized = true;
	}

	private async void CreateLeaderboardEntryDisplayObjects(LeaderboardEntry[] leaderboardEntries, RectTransform contentParent)
	{
		if (leaderboardEntries != null)
		{
			List<LeaderboardEntryDisplayObject> leaderboardEntryDisplayObjects = new List<LeaderboardEntryDisplayObject>();
			for (int i = 0; i < leaderboardEntries.Length; i++)
			{
				LeaderboardEntryDisplayObject leaderboardEntryDisplayObject = await InstantiateDisplayObject(leaderboardEntries[i], contentParent);
				leaderboardEntryDisplayObjects.Add(leaderboardEntryDisplayObject);
				leaderboardEntryDisplayObject.transform.localPosition = Vector2.zero;
			}
			Vector2 item = new Vector2((float)leaderboardEntryDisplayObjects.Count * displayOffset.x * -1f / 2f, (float)leaderboardEntryDisplayObjects.Count * displayOffset.y * -1f / 2f);
			item += new Vector2(displayOffset.x / 2f, displayOffset.y / 2f);
			List<Vector2> list = new List<Vector2>();
			for (int j = 0; j < leaderboardEntryDisplayObjects.Count; j++)
			{
				list.Add(item);
				item += displayOffset;
			}
			for (int k = 0; k < leaderboardEntryDisplayObjects.Count; k++)
			{
				leaderboardEntryDisplayObjects[k].transform.localPosition = list[k];
			}
			contentParent.sizeDelta = new Vector2(contentParent.sizeDelta.x, Mathf.Abs(displayOffset.y) * (float)leaderboardEntryDisplayObjects.Count);
		}
	}

	private async Task<LeaderboardEntryDisplayObject> InstantiateDisplayObject(LeaderboardEntry leaderboardEntry, RectTransform contentParent)
	{
		LeaderboardEntryDisplayObject leaderboardEntryDisplayObject = Object.Instantiate(displayObjectPrefab, Vector3.zero, Quaternion.identity, contentParent).GetComponent<LeaderboardEntryDisplayObject>();
		leaderboardEntryDisplayObject.rankDisplay.text = "#" + leaderboardEntry.GlobalRank;
		Steamworks.Data.Image? image = await leaderboardEntry.User.GetMediumAvatarAsync();
		if (image.HasValue)
		{
			leaderboardEntryDisplayObject.avatarDisplay.texture = SteamLeaderboards.GetTextureFromImage(image.Value);
		}
		leaderboardEntryDisplayObject.nameDisplay.text = leaderboardEntry.User.Name;
		float time = (float)leaderboardEntry.Score / 1000f;
		leaderboardEntryDisplayObject.timeDisplay.text = SpeedrunTimer.TimeToDisplayTime(time);
		return leaderboardEntryDisplayObject;
	}

	public void SetGlobal()
	{
		friendContentParent.gameObject.SetActive(value: false);
		globalContentParent.gameObject.SetActive(value: true);
		if (userFriendLeaderboardEntryDisplayObject != null && userGlobalLeaderboardEntryDisplayObject != null)
		{
			userFriendLeaderboardEntryDisplayObject.gameObject.SetActive(value: false);
			userGlobalLeaderboardEntryDisplayObject.gameObject.SetActive(value: true);
		}
		if (noGlobalEntriesToShow)
		{
			SetNoEntries();
		}
		else
		{
			noEntriesText.SetActive(value: false);
		}
		scrollbar.value = 1f;
		scrollRect.content = globalContentParent;
		scrollbar.value = 1f;
		isViewingGlobal = true;
		leaderboardText.text = leaderboardString.GetLocalizedString() + " : " + globalString.GetLocalizedString();
	}

	public void SetFriends()
	{
		globalContentParent.gameObject.SetActive(value: false);
		friendContentParent.gameObject.SetActive(value: true);
		if (userFriendLeaderboardEntryDisplayObject != null && userGlobalLeaderboardEntryDisplayObject != null)
		{
			userGlobalLeaderboardEntryDisplayObject.gameObject.SetActive(value: false);
			userFriendLeaderboardEntryDisplayObject.gameObject.SetActive(value: true);
		}
		if (noFriendsEntriesToShow)
		{
			SetNoEntries();
		}
		else
		{
			noEntriesText.SetActive(value: false);
		}
		scrollbar.value = 1f;
		scrollRect.content = friendContentParent;
		scrollbar.value = 1f;
		isViewingGlobal = false;
		leaderboardText.text = leaderboardString.GetLocalizedString() + " : " + friendString.GetLocalizedString();
	}

	public void OnLeaderboardToggle()
	{
		if (!isViewingGlobal)
		{
			SetGlobal();
		}
		else
		{
			SetFriends();
		}
	}

	public void SetNoEntries()
	{
		noEntriesText.SetActive(value: true);
	}

	private void Update()
	{
		if (!isInitialized)
		{
			if (elapsedTimeOut < timeOut)
			{
				elapsedTimeOut += Time.deltaTime;
			}
			else
			{
				TimeOut();
			}
		}
	}

	private void TimeOut()
	{
		isInitialized = true;
		noGlobalEntriesToShow = true;
		noFriendsEntriesToShow = true;
		SetGlobal();
		friendContentParent.gameObject.SetActive(value: false);
		globalContentParent.gameObject.SetActive(value: false);
		blackScreen.SetActive(value: false);
		SoundManager.LoadSoundEffect(base.transform, SoundManager.instance.titel_impact);
	}

	private LeaderboardEntry[] MergeLeaderboardEntryArrayAndSort(LeaderboardEntry[] list1, LeaderboardEntry[] list2)
	{
		List<LeaderboardEntry> list3 = new List<LeaderboardEntry>();
		list3.AddRange(list1);
		List<int> list4 = new List<int>();
		for (int i = 0; i < list2.Length; i++)
		{
			LeaderboardEntry leaderboardEntry = list2[i];
			list4.Add(leaderboardEntry.GlobalRank);
		}
		List<LeaderboardEntry> list5 = new List<LeaderboardEntry>();
		foreach (LeaderboardEntry item in list3)
		{
			Friend user = item.User;
			if (user.IsMe || list4.Contains(item.GlobalRank))
			{
				list5.Add(item);
			}
		}
		foreach (LeaderboardEntry item2 in list5)
		{
			list3.Remove(item2);
		}
		list3.AddRange(list2);
		list3 = list3.OrderBy((LeaderboardEntry x) => x.Score).ToList();
		return list3.ToArray();
	}
}
