using System;
using System.Collections;
using System.Text;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	private enum Achievement
	{
		boss10 = 0,
		boss20 = 1,
		boss30 = 2,
		boss40 = 3,
		boss50 = 4,
		boss60 = 5,
		boss70 = 6,
		boss80 = 7,
		boss90 = 8,
		boss100 = 9,
		boss110 = 10,
		boss120 = 11,
		boss130 = 12,
		boss140 = 13,
		boss150 = 14,
		boss160 = 15,
		boss170 = 16,
		boss180 = 17,
		boss190 = 18,
		boss200 = 19,
		boss210 = 20,
		boss220 = 21,
		boss230 = 22,
		boss240 = 23,
		boss250 = 24,
		boss260 = 25,
		boss270 = 26,
		boss280 = 27,
		boss290 = 28,
		boss301 = 29,
		energy1m = 30,
		energy1b = 31,
		energy1t = 32,
		energy1q = 33,
		energyhardcap = 34,
		magic1m = 35,
		magic1b = 36,
		magic1t = 37,
		magic1q = 38,
		magichardcap = 39,
		res3unlock = 40,
		res31m = 41,
		res31b = 42,
		res31t = 43,
		res31q = 44,
		res3hardcap = 45,
		lol69 = 46,
		augsunlocked = 47,
		bmunlocked = 48,
		nguunlocked = 49,
		yggunlocked = 50,
		diggersunlocked = 51,
		beardsunlocked = 52,
		questsunlocked = 53,
		hacksunlocked = 54,
		wishesunlocked = 55,
		exploder = 56,
		enterevil = 57,
		entersadistic = 58,
		firstchallenge = 59,
		trollchallenge = 60
	}

	private class Achievement_t
	{
		public Achievement m_eAchievementID;

		public string m_strName;

		public string m_strDescription;

		public bool m_bAchieved;

		public Achievement_t(Achievement achievementID, string name, string desc)
		{
			m_eAchievementID = achievementID;
			m_strName = name;
			m_strDescription = desc;
			m_bAchieved = false;
		}
	}

	public bool steamEnabled;

	public Character character;

	public HoverTooltip tooltip;

	private CallResult<RemoteStorageFileWriteAsyncComplete_t> OnRemoteStorageFileWriteAsyncCompleteCallResult;

	private CallResult<RemoteStorageFileReadAsyncComplete_t> OnRemoteStorageFileReadAsyncCompleteCallResult;

	private Callback<MicroTxnAuthorizationResponse_t> mtxResult;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserStatsStored_t> m_UserStatsStored;

	private static SteamManager s_instance;

	private static bool s_EverInitialized;

	private bool m_bInitialized;

	private PlayerTime achieveTime = new PlayerTime();

	private PlayerTime purchaseTime = new PlayerTime();

	private Achievement_t[] m_Achievements = new Achievement_t[61]
	{
		new Achievement_t(Achievement.boss10, "Boss 10 Defeated!", "Boss 10 is uh... it's defeated. You defeated it. The name basically says it all."),
		new Achievement_t(Achievement.boss20, "Boss 20 Defeated!", "Boss 20 Defeated!"),
		new Achievement_t(Achievement.boss30, "Boss 30 Defeated!", "Boss 30 Defeated!"),
		new Achievement_t(Achievement.boss40, "Boss 40 Defeated!", "Boss 40 Defeated!"),
		new Achievement_t(Achievement.boss50, "Boss 50 Defeated!", "Boss 50 Defeated!"),
		new Achievement_t(Achievement.boss60, "Boss 60 Defeated!", "Boss 60 Defeated!"),
		new Achievement_t(Achievement.boss70, "Boss 70 Defeated!", "Boss 70 Defeated!"),
		new Achievement_t(Achievement.boss80, "Boss 80 Defeated!", "Boss 80 Defeated!"),
		new Achievement_t(Achievement.boss90, "Boss 90 Defeated!", "Boss 90 Defeated!"),
		new Achievement_t(Achievement.boss100, "Boss 100 Defeated!", "Boss 100 Defeated! Ooh, now the skull is all blue and shiny."),
		new Achievement_t(Achievement.boss110, "Boss 110 Defeated!", "Boss 110 Defeated!"),
		new Achievement_t(Achievement.boss120, "Boss 120 Defeated!", "Boss 120 Defeated!"),
		new Achievement_t(Achievement.boss130, "Boss 130 Defeated!", "Boss 130 Defeated!"),
		new Achievement_t(Achievement.boss140, "Boss 140 Defeated!", "Boss 140 Defeated!"),
		new Achievement_t(Achievement.boss150, "Boss 150 Defeated!", "Boss 150 Defeated!"),
		new Achievement_t(Achievement.boss160, "Boss 160 Defeated!", "Boss 160 Defeated!"),
		new Achievement_t(Achievement.boss170, "Boss 170 Defeated!", "Boss 170 Defeated!"),
		new Achievement_t(Achievement.boss180, "Boss 180 Defeated!", "Boss 180 Defeated!"),
		new Achievement_t(Achievement.boss190, "Boss 190 Defeated!", "Boss 190 Defeated!"),
		new Achievement_t(Achievement.boss200, "Boss 200 Defeated!", "Boss 200 Defeated! Oh snap, they have red skulls now!"),
		new Achievement_t(Achievement.boss210, "Boss 210 Defeated!", "Boss 210 Defeated!"),
		new Achievement_t(Achievement.boss220, "Boss 220 Defeated!", "Boss 220 Defeated!"),
		new Achievement_t(Achievement.boss230, "Boss 230 Defeated!", "Boss 230 Defeated!"),
		new Achievement_t(Achievement.boss240, "Boss 240 Defeated!", "Boss 240 Defeated!"),
		new Achievement_t(Achievement.boss250, "Boss 250 Defeated!", "Boss 250 Defeated!"),
		new Achievement_t(Achievement.boss260, "Boss 260 Defeated!", "Boss 260 Defeated!"),
		new Achievement_t(Achievement.boss270, "Boss 270 Defeated!", "Boss 270 Defeated!"),
		new Achievement_t(Achievement.boss280, "Boss 280 Defeated!", "Boss 280 Defeated!"),
		new Achievement_t(Achievement.boss290, "Boss 290 Defeated!", "Boss 290 Defeated!"),
		new Achievement_t(Achievement.boss301, "Boss 301 Defeated!", "You defeated them all! Now to move on to EVIL difficulty..."),
		new Achievement_t(Achievement.energy1m, "Obtain 1 Million Energy!", "Obtain 1 Million Energy!"),
		new Achievement_t(Achievement.energy1b, "Obtain 1 Billion Energy!", "Obtain 1 Billion Energy!"),
		new Achievement_t(Achievement.energy1t, "Obtain 1 Trillion Energy!", "Obtain 1 Trillion Energy!"),
		new Achievement_t(Achievement.energy1q, "Obtain 1 Quadrillion Energy!", "Obtain 1 Quadrillion Energy!"),
		new Achievement_t(Achievement.energyhardcap, "THE ENERGY HARCAP", "Obtain 9 QUINTILLION Energy, the most you can have in the game!"),
		new Achievement_t(Achievement.magic1m, "Obtain 1 Million Energy!", "Obtain 1 Million Energy!"),
		new Achievement_t(Achievement.magic1b, "Obtain 1 Billion Energy!", "Obtain 1 Billion Energy!"),
		new Achievement_t(Achievement.magic1t, "Obtain 1 Trillion Energy!", "Obtain 1 Tillion Energy!"),
		new Achievement_t(Achievement.magic1q, "Obtain 1 Quadrillion Energy!", "Obtain 1 Quadrillion Energy!"),
		new Achievement_t(Achievement.magichardcap, "THE MAGIC HARDCAP", "Obtain 9 QUINTILLION Magic, the most you can have in the game!"),
		new Achievement_t(Achievement.res3unlock, "Unlocked Resource 3!", "You can give this resource its own name in the settings menu!"),
		new Achievement_t(Achievement.res31m, "Obtain 1 Million of Resource 3!", "Obtain 1 Million Resource 3!"),
		new Achievement_t(Achievement.res31b, "Obtain 1 Billion Resource 3!", "Obtain 1 Million Resource 3!"),
		new Achievement_t(Achievement.res31t, "Obtain 1 Trillion Resource 3!", "Obtain 1 Million Resource 3!"),
		new Achievement_t(Achievement.res31q, "Obtain 1 Quadrillion Resource 3!", "Obtain 1 Million Resource 3!"),
		new Achievement_t(Achievement.res3hardcap, "THE END", "Defeated the Traitor and earned the final END piece."),
		new Achievement_t(Achievement.lol69, "How Immature", "Wear a set of gear on your body, all at level 69."),
		new Achievement_t(Achievement.augsunlocked, "Augmentation Unlocked!", "Unlock the Augmentation feature"),
		new Achievement_t(Achievement.bmunlocked, "Blood Magic Unlocked!", "Blood Magic Unlocked!"),
		new Achievement_t(Achievement.nguunlocked, "NGU's Unlocked!", "NGU's Unlocked!"),
		new Achievement_t(Achievement.yggunlocked, "Yggdrasil Unlocked!", "Yggdrasil Unlocked!"),
		new Achievement_t(Achievement.diggersunlocked, "Gold Diggers Unlocked!", "Gold Diggers Unlocked!"),
		new Achievement_t(Achievement.beardsunlocked, "Beards Unlocked", "Beards Unlocked"),
		new Achievement_t(Achievement.questsunlocked, "Questing unlocked!", "Questing unlocked!"),
		new Achievement_t(Achievement.hacksunlocked, "Hacks Unlocked!", "Hacks Unlocked!"),
		new Achievement_t(Achievement.wishesunlocked, "Wishes Unlocked!", "Wishes Unlocked!"),
		new Achievement_t(Achievement.exploder, "Exploder Survivor", "Survive an attack from an Exploder type enemy!"),
		new Achievement_t(Achievement.enterevil, "Evil Difficulty", "Took the plunge into Evil Difficulty for the first time."),
		new Achievement_t(Achievement.entersadistic, "SADISTIC DIFFICULTY", "F's in chat for you, cause you're in for a world of pain."),
		new Achievement_t(Achievement.firstchallenge, "Baby's First Challenge", "I'm so proud of you."),
		new Achievement_t(Achievement.trollchallenge, "I Hate the Developer.", "Completed your first troll challenge... I'm sorry :c")
	};

	private CGameID m_GameID;

	private bool m_bRequestedStats;

	private bool m_bStatsValid;

	private bool m_bStoreStats;

	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	private static SteamManager Instance
	{
		get
		{
			if (s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return s_instance;
		}
	}

	public static bool Initialized => Instance.m_bInitialized;

	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	private void Awake()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			steamEnabled = true;
		}
		if (steamEnabled)
		{
			if (s_instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			s_instance = this;
			if (s_EverInitialized)
			{
				throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (!Packsize.Test())
			{
				Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
			}
			if (!DllCheck.Test())
			{
				Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
			}
			try
			{
				if (SteamAPI.RestartAppIfNecessary((AppId_t)1147690u))
				{
					Application.Quit();
					return;
				}
			}
			catch (DllNotFoundException ex)
			{
				Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + ex, this);
				Application.Quit();
				return;
			}
			m_bInitialized = SteamAPI.Init();
			if (!m_bInitialized)
			{
				Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			}
			else
			{
				s_EverInitialized = true;
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		if (m_bInitialized)
		{
			if (m_SteamAPIWarningMessageHook == null)
			{
				m_SteamAPIWarningMessageHook = SteamAPIDebugTextHook;
				SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);
			}
			OnRemoteStorageFileWriteAsyncCompleteCallResult = CallResult<RemoteStorageFileWriteAsyncComplete_t>.Create(OnRemoteStorageFileWriteAsyncComplete);
			OnRemoteStorageFileReadAsyncCompleteCallResult = CallResult<RemoteStorageFileReadAsyncComplete_t>.Create(OnRemoteStorageFileReadAsyncComplete);
			mtxResult = Callback<MicroTxnAuthorizationResponse_t>.Create(ONMTXResponse);
			m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
			m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			m_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			m_GameID = new CGameID(SteamUtils.GetAppID());
			m_bRequestedStats = false;
			m_bStatsValid = false;
		}
	}

	private void OnDestroy()
	{
		if (!(s_instance != this))
		{
			s_instance = null;
			if (m_bInitialized)
			{
				SteamAPI.Shutdown();
			}
		}
	}

	private float achieveThreshold()
	{
		return 1f;
	}

	private float purchaseCooldown()
	{
		return 10f;
	}

	private void Update()
	{
		if (!m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
		if (!m_bRequestedStats)
		{
			if (!Initialized)
			{
				m_bRequestedStats = true;
				return;
			}
			bool bRequestedStats = SteamUserStats.RequestCurrentStats();
			m_bRequestedStats = bRequestedStats;
		}
		if (achieveTime.totalseconds < (double)achieveThreshold())
		{
			achieveTime.advanceTime(Time.deltaTime);
		}
		if (achieveTime.totalseconds >= (double)achieveThreshold())
		{
			if (!m_bStatsValid)
			{
				achieveTime.reset();
			}
			else
			{
				achieveTime.reset();
				checkAllAchievements();
			}
		}
		if (m_bStoreStats)
		{
			bool flag = SteamUserStats.StoreStats();
			m_bStoreStats = !flag;
		}
		if (purchaseTime.totalseconds < (double)purchaseCooldown())
		{
			purchaseTime.advanceTime(Time.deltaTime);
		}
	}

	public void writeToSteamCloud(byte[] fileData)
	{
		if (m_bInitialized && fileData != null && fileData.Length != 0)
		{
			SteamAPICall_t hAPICall = SteamRemoteStorage.FileWriteAsync("NGUCloud", fileData, (uint)fileData.Length);
			OnRemoteStorageFileWriteAsyncCompleteCallResult.Set(hAPICall);
		}
	}

	private void OnRemoteStorageFileWriteAsyncComplete(RemoteStorageFileWriteAsyncComplete_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_eResult == EResult.k_EResultFail)
		{
			tooltip.showTooltip("Steam Cloud failed to save!", 2f);
		}
	}

	public void fetchSteamCloud()
	{
		if (!m_bInitialized)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
			return;
		}
		try
		{
			int fileSize = SteamRemoteStorage.GetFileSize("NGUCloud");
			SteamAPICall_t hAPICall = SteamRemoteStorage.FileReadAsync("NGUCloud", 0u, (uint)fileSize);
			OnRemoteStorageFileReadAsyncCompleteCallResult.Set(hAPICall);
		}
		catch (Exception)
		{
			character.mainMenu.setCloudSaveValidity(validity: false);
		}
	}

	private void OnRemoteStorageFileReadAsyncComplete(RemoteStorageFileReadAsyncComplete_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_eResult == EResult.k_EResultOK)
		{
			try
			{
				byte[] array = new byte[pCallback.m_cubRead];
				if (SteamRemoteStorage.FileReadAsyncComplete(pCallback.m_hFileReadAsync, array, pCallback.m_cubRead))
				{
					string cloudSaveSteam = Encoding.UTF8.GetString(array, (int)pCallback.m_nOffset, (int)pCallback.m_cubRead);
					character.saveLoad.setCloudSaveSteam(cloudSaveSteam);
				}
				else
				{
					character.mainMenu.setCloudSaveValidity(validity: false);
				}
				return;
			}
			catch (Exception)
			{
				character.mainMenu.setCloudSaveValidity(validity: false);
				return;
			}
		}
		character.mainMenu.setCloudSaveValidity(validity: false);
	}

	private void ONMTXResponse(MicroTxnAuthorizationResponse_t pCallback)
	{
		if (pCallback.m_bAuthorized == 1)
		{
			ulong ulOrderID = pCallback.m_ulOrderID;
			StartCoroutine(consumePurchase(ulOrderID));
		}
	}

	private IEnumerator consumePurchase(ulong orderid)
	{
		string url = "https://www.nguindustries.net/confirmMTX.php";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("OrderID", orderid.ToString());
		WWW www = new WWW(url, wWWForm);
		yield return www;
		if (www.error != null)
		{
			tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c.", 2f);
			yield break;
		}
		if (www.text == "")
		{
			tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c.", 2f);
			yield break;
		}
		try
		{
			int num = int.Parse(www.text);
			if (num < 0)
			{
				switch (num)
				{
				case -1:
					tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c. Check that the purchase went through on Steam and if so, contact 4G to fix it.", 6f);
					break;
				case -2:
					tooltip.showOverrideTooltip("You didn't seem to actually buy anything. Check that the purchase went through on Steam and if so, contact 4G to fix it.", 6f);
					break;
				default:
					tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c. Check that the purchase went through on Steam and if so, contact 4G to fix it.", 6f);
					break;
				}
				yield break;
			}
			switch (num)
			{
			case 1:
				consume20KPurchase();
				break;
			case 2:
				consume100KPurchase();
				break;
			case 3:
				consume200KPurchase();
				break;
			case 4:
				consume400KPurchase();
				break;
			case 5:
				consume1MPurchase();
				break;
			case 6:
				consume2MPurchase();
				break;
			case 7:
				consumeNewPlayerPurchase();
				break;
			case 8:
				consumeAscendedNewbiePurchase();
				break;
			case 9:
				consumeAscendedNewbiePurchase2();
				break;
			case 10:
				consumeAscendedNewbiePurchase3();
				break;
			case 11:
				consumeITOPODNamePack();
				break;
			case 12:
				consumeRes3Purchase();
				break;
			case 13:
				consumeFashionPack1();
				break;
			case 14:
				consumeAscendedNewbiePurchase4();
				break;
			default:
				tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c.", 2f);
				break;
			}
		}
		catch (Exception)
		{
			tooltip.showOverrideTooltip("Something messed up with the internet and the purchase didn't go through :c.", 2f);
			tooltip.showOverrideTooltip(www.text);
		}
	}

	private IEnumerator initOrder(int id)
	{
		ulong steamID = SteamUser.GetSteamID().m_SteamID;
		string personaName = SteamFriends.GetPersonaName();
		string currentGameLanguage = SteamApps.GetCurrentGameLanguage();
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("SteamID", steamID.ToString());
		wWWForm.AddField("GameLanguage", currentGameLanguage);
		wWWForm.AddField("SteamName", personaName);
		wWWForm.AddField("ItemID", id);
		yield return new WWW("https://www.nguindustries.net/testMTX.php", wWWForm);
	}

	public void startBuy20KAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(1));
			purchaseTime.reset();
		}
	}

	public void startBuy100KAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(2));
			purchaseTime.reset();
		}
	}

	public void startBuy200KAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(3));
			purchaseTime.reset();
		}
	}

	public void startBuy400KAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(4));
			purchaseTime.reset();
		}
	}

	public void startBuy1MAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(5));
			purchaseTime.reset();
		}
	}

	public void startBuy2MAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(6));
			purchaseTime.reset();
		}
	}

	public void startNewPlayerAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(7));
			purchaseTime.reset();
		}
	}

	public void startAscendedNewbieAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			StartCoroutine(initOrder(8));
		}
	}

	public void startAscendedNewbie2AP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(9));
			purchaseTime.reset();
		}
	}

	public void startAscendedNewbie3AP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(10));
			purchaseTime.reset();
		}
	}

	public void startAscendedNewbie4AP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(14));
			purchaseTime.reset();
		}
	}

	public void startITOPODNameAP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(11));
			purchaseTime.reset();
		}
	}

	public void startRes3AP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(12));
			purchaseTime.reset();
		}
	}

	public void startFashionPack1AP()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			if (purchaseTime.totalseconds < (double)purchaseCooldown())
			{
				tooltip.showOverrideTooltip("It takes a bit of time to confirm each purchase, wait a few seconds before clicking again!", 3f);
				return;
			}
			StartCoroutine(initOrder(13));
			purchaseTime.reset();
		}
	}

	public void consume20KPurchase()
	{
		character.addAP(20000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(20000L).ToString("###,##0") + " AP has been added!", 5f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consume100KPurchase()
	{
		character.addAP(110000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(100000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(10000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consume200KPurchase()
	{
		character.addAP(225000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(200000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(25000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consume400KPurchase()
	{
		character.addAP(460000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(400000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(60000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consume1MPurchase()
	{
		character.addAP(1200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(1000000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(200000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consume2MPurchase()
	{
		character.addAP(3200000);
		tooltip.showOverrideTooltip("Thank you so much! " + character.checkAPAdded(2500000L).ToString("###,##0") + " AP has been added, plus a bonus of " + character.checkAPAdded(700000L).ToString("###,##0") + " AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!", 10f);
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeNewPlayerPurchase()
	{
		string text = "Thank you so much for buying the Stupid Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(225000L).ToString("###,##0") + "AP!</b>\n<b>2 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(225000);
		character.arbitrary.energyPotion1Count += 2;
		character.arbitrary.energyPotion2Count += 2;
		character.arbitrary.energyPotion3Count += 2;
		character.arbitrary.magicPotion1Count += 2;
		character.arbitrary.magicPotion2Count += 2;
		character.arbitrary.magicPotion3Count += 2;
		character.arbitrary.lootCharm1Count += 2;
		character.arbitrary.energyBarBar1Count += 2;
		character.arbitrary.magicBarBar1Count += 2;
		character.arbitrary.poop1Count += 25;
		character.arbitrary.lootCharm2Count += 2;
		if (character.arbitrary.lootFilter)
		{
			character.arbitrary.curArbitraryPoints += 100000L;
			text += "\n<b>An extra 100000 AP Since you already have the Improved Loot Filter!</b>";
		}
		else
		{
			character.arbitrary.lootFilter = true;
			text += "\n<b>The Improved Loot Filter!</b>";
		}
		long num = 0L;
		long num2 = character.arbitrary.inventorySpaces + 12 - character.allArbitrary.randomArbitraryController.maxSpaces();
		if (num2 < 0)
		{
			num2 = 0L;
		}
		if (num2 > 12)
		{
			num2 = 12L;
		}
		if (num2 > 0)
		{
			num = num2 * 10000;
		}
		if (num > 0)
		{
			character.arbitrary.curArbitraryPoints += num;
			character.arbitrary.curLifetimePoints += num;
			text = text + "\n<b>An extra " + num.ToString("###,##0") + " AP since you reached the max inventory spaces available!</b>";
		}
		else
		{
			text += "\n<b>12 inventory spaces!</b>";
		}
		character.arbitrary.inventorySpaces += 12;
		if (character.arbitrary.inventorySpaces > character.allArbitrary.randomArbitraryController.maxSpaces())
		{
			character.arbitrary.inventorySpaces = (int)character.allArbitrary.randomArbitraryController.maxSpaces();
		}
		character.arbitrary.boughtNewbiePack = true;
		character.inventoryController.updateInvCount();
		text += "\n<b>Plus, you can PM me for a personalized insult!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.APPackDisplay.refreshMenu();
		character.allArbitrary.updateMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeAscendedNewbiePurchase()
	{
		string text = "Thank you so much for buying the Ascended Newbie Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>25 Poop!</b>";
		character.addAP(600000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Red Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[119]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Red Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[119])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Red Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(119, 10);
			text += "\n<b>A Red Heart!</b>";
		}
		if (character.arbitrary.boughtLazyITOPOD)
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already bought the Lazy ITOPOD Shifter!</b>";
		}
		else
		{
			character.arbitrary.boughtLazyITOPOD = true;
			text += "\n<b>The Lazy ITOPOD Shifter!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack = true;
		text += "\n<b>Plus, you can PM me for a personalized compliment!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeITOPODNamePack()
	{
		character.arbitrary.nameSlotsBought++;
		if (character.arbitrary.nameSlotsBought == 1)
		{
			character.addAP(1200000);
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! Since this is your first purchase, you've received a bonus of <b>" + character.checkAPAdded(1200000L).ToString("###,##0") + "</b> AP! I have to add names manually on my server, so it may take a few days for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Steam!", 12f);
		}
		else
		{
			tooltip.showOverrideTooltip("Thank you so much for purchasing the ITOPOD Name Pack! I have to add names manually on my server, so it may take a few days for your name to appear on the list! If you want the name to be something other than your username, you can contact me on Discord or Steam!", 12f);
		}
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeAscendedNewbiePurchase2()
	{
		string text = "Thank you so much for buying the Ascended Ascended Pack! You've received:\n\n<b>" + character.checkAPAdded(700000L).ToString("###,##0") + "AP!</b>\n<b>4 of every consumable boost!</b>\n<b>50 Poop!</b>";
		character.addAP(700000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Orange Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[293]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Orange Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[293])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Orange Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(293, 10);
			text += "\n<b>An Orange Heart!</b>";
		}
		if (character.arbitrary.hasFasterQuests)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already bought Faster Questing!</b>";
		}
		else
		{
			character.arbitrary.hasFasterQuests = true;
			text += "\n<b>Faster Questing!</b>";
		}
		character.inventory.unlockedKittyArt[3] = true;
		text += "\n<b>THE GOLDEN KITTY</b>";
		character.arbitrary.boughtAscendedNewbiePack2 = true;
		text += "\n<b>Plus, you can PM me for a personalized pun!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeRes3Purchase()
	{
		string text = "Thank you so much for buying the Resource 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(600000L).ToString("###,##0") + "AP!</b>\n<b>4 of each Resource 3 Potion!</b>";
		character.addAP(600000);
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Grey Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[297]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Grey Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[297])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Grey Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(297, 10);
			text += "\n<b>A Grey Heart!</b>";
		}
		text += "\n<b>You can now fully customize Resource 3's Colour! Check Page 2 of the Settings Menu.</b>";
		character.arbitrary.boughtRes3Pack = true;
		text += "\n<b>Plus, you can PM me for a personalized NUMBER! No one else can have the number I give you, it's yours and yours alone.</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeAscendedNewbiePurchase3()
	{
		string text = "Thank you so much for buying the Ascended ^ 3 Pack! You've received:\n\n<b>" + character.checkAPAdded(500000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(500000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had no space for the Blue Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[196]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you had the Blue Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[196])
		{
			character.arbitrary.curArbitraryPoints += 225000L;
			text += "\n<b>An additional 225,000 AP because you already had a maxxed out Blue Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(196, 10);
			text += "\n<b>A Blue Heart!</b>";
		}
		if (character.arbitrary.wishSpeedBoster)
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already bought Faster Wishes!</b>";
		}
		else
		{
			character.arbitrary.wishSpeedBoster = true;
			text += "\n<b>Faster Wishes!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack3 = true;
		text += "\n<b>Plus, you can PM me, and i'll send back a kitten pic or video!</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeFashionPack1()
	{
		character.arbitrary.boughtFashionPack1 = true;
		character.portraits.portraitUnlocked[1] = true;
		character.portraits.portraitUnlocked[2] = true;
		character.portraits.portraitUnlocked[3] = true;
		character.portraits.portraitUnlocked[4] = true;
		character.portraits.portraitUnlocked[5] = true;
		character.portraits.portraitUnlocked[6] = true;
		character.portraits.portraitUnlocked[7] = true;
		character.portraits.portraitUnlocked[8] = true;
		character.portraits.portraitUnlocked[9] = true;
		character.portraits.portraitUnlocked[10] = true;
		character.addAP(200000);
		string message = "Thank you so much for buying the Sexy Player Fashion Pack! You've unlocked 10 sexy new pics for your player in the Fight Boss Menu, PLUS a bonus " + character.checkAPAdded(200000L).ToString("###,##0") + "AP! I <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(message, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
		character.saveLoad.saveGamestateToSteamCloud();
	}

	public void consumeAscendedNewbiePurchase4()
	{
		string text = "Thank you so much for buying the Ascended ^ 4 Pack! You've received:\n\n<b>" + character.checkAPAdded(300000L).ToString("###,##0") + "AP!</b>\n<b>A huge dump of consumable boosts!</b>\n<b>50 Poop!</b>";
		character.addAP(300000);
		character.arbitrary.energyPotion1Count += 4;
		character.arbitrary.energyPotion2Count += 4;
		character.arbitrary.energyPotion3Count += 4;
		character.arbitrary.magicPotion1Count += 4;
		character.arbitrary.magicPotion2Count += 4;
		character.arbitrary.magicPotion3Count += 4;
		character.arbitrary.res3Potion1Count += 4;
		character.arbitrary.res3Potion2Count += 4;
		character.arbitrary.res3Potion3Count += 4;
		character.arbitrary.lootCharm1Count += 4;
		character.arbitrary.energyBarBar1Count += 4;
		character.arbitrary.magicBarBar1Count += 4;
		character.arbitrary.poop1Count += 50;
		character.adventure.itopod.buffedKills += 4000L;
		character.arbitrary.lootCharm2Count += 4;
		character.arbitrary.macGuffinBooster1Count += 4;
		character.arbitrary.beastButterCount += 4;
		character.arbitrary.mayoSpeedPotCount += 4;
		character.arbitrary.cardTierUpperCount += 100;
		if (!character.inventoryController.freeSpace())
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had no space for the Rainbow Heart!</b>";
		}
		else if ((character.arbitrary.lootFilter && character.inventory.itemList.itemFiltered[390]) || (character.settings.filterOn && character.settings.filterAccessory))
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you had the Rainbow Heart filtered!</b>";
		}
		else if (character.inventory.itemList.itemMaxxed[390])
		{
			character.arbitrary.curArbitraryPoints += 500000L;
			text += "\n<b>An additional 500,000 AP because you already had a maxxed out Rainbow Heart!</b>";
		}
		else
		{
			character.itemInfo.makeLevelledLoot(390, 10);
			text += "\n<b>A Rainbow Heart!</b>";
		}
		if (!character.arbitrary.boughtFoils)
		{
			character.arbitrary.boughtFoils = true;
			text += "\n<b>Perma Foils!</b>";
		}
		else
		{
			character.arbitrary.curArbitraryPoints += 250000L;
			text += "\n<b>An additional 250,000 AP because you already have Perma Foils!</b>";
		}
		character.arbitrary.boughtAscendedNewbiePack4 = true;
		text += "\n<b>Plus, you can PM me, and I'll do something... weird.</b>\n\nI <b>Strongly</b> recommend you make a backup save now to ensure you don't lose what you bought!";
		tooltip.showOverrideTooltip(text, 11f);
		character.allArbitrary.updateMenu();
		character.APPackDisplay.refreshMenu();
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!m_bInitialized || (ulong)m_GameID != pCallback.m_nGameID)
		{
			return;
		}
		if (EResult.k_EResultOK == pCallback.m_eResult)
		{
			m_bStatsValid = true;
			Achievement_t[] achievements = m_Achievements;
			foreach (Achievement_t achievement_t in achievements)
			{
				if (SteamUserStats.GetAchievement(achievement_t.m_eAchievementID.ToString(), out achievement_t.m_bAchieved))
				{
					achievement_t.m_strName = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "name");
					achievement_t.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "desc");
				}
				else
				{
					Debug.LogWarning(string.Concat("SteamUserStats.GetAchievement failed for Achievement ", achievement_t.m_eAchievementID, "\nIs it registered in the Steam Partner site?"));
				}
			}
		}
		else
		{
			Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
		}
	}

	private void OnUserStatsStored(UserStatsStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID && EResult.k_EResultOK != pCallback.m_eResult && EResult.k_EResultInvalidParam == pCallback.m_eResult)
		{
			OnUserStatsReceived(new UserStatsReceived_t
			{
				m_eResult = EResult.k_EResultOK,
				m_nGameID = (ulong)m_GameID
			});
		}
	}

	private void checkAllAchievements()
	{
		Achievement_t[] achievements = m_Achievements;
		foreach (Achievement_t achievement_t in achievements)
		{
			if (achievement_t.m_bAchieved)
			{
				continue;
			}
			switch (achievement_t.m_eAchievementID)
			{
			case Achievement.boss10:
				if (character.highestBoss >= 10)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss20:
				if (character.highestBoss >= 20)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss30:
				if (character.highestBoss >= 30)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss40:
				if (character.highestBoss >= 40)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss50:
				if (character.highestBoss >= 50)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss60:
				if (character.highestBoss >= 60)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss70:
				if (character.highestBoss >= 70)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss80:
				if (character.highestBoss >= 80)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss90:
				if (character.highestBoss >= 90)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss100:
				if (character.highestBoss >= 100)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss110:
				if (character.highestBoss >= 110)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss120:
				if (character.highestBoss >= 120)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss130:
				if (character.highestBoss >= 130)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss140:
				if (character.highestBoss >= 140)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss150:
				if (character.highestBoss >= 150)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss160:
				if (character.highestBoss >= 160)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss170:
				if (character.highestBoss >= 170)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss180:
				if (character.highestBoss >= 180)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss190:
				if (character.highestBoss >= 190)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss200:
				if (character.highestBoss >= 200)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss210:
				if (character.highestBoss >= 210)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss220:
				if (character.highestBoss >= 220)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss230:
				if (character.highestBoss >= 230)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss240:
				if (character.highestBoss >= 240)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss250:
				if (character.highestBoss >= 250)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss260:
				if (character.highestBoss >= 260)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss270:
				if (character.highestBoss >= 270)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss280:
				if (character.highestBoss >= 280)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss290:
				if (character.highestBoss >= 290)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.boss301:
				if (character.highestBoss >= 301)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.energy1m:
				if (character.totalCapEnergy() >= 1000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.energy1b:
				if (character.totalCapEnergy() >= 1000000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.energy1t:
				if (character.totalCapEnergy() >= 1000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.energy1q:
				if (character.totalCapEnergy() >= 1000000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.energyhardcap:
				if (character.totalCapEnergy() >= character.hardCap())
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.magic1m:
				if (character.totalCapMagic() >= 1000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.magic1b:
				if (character.totalCapMagic() >= 1000000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.magic1t:
				if (character.totalCapMagic() >= 1000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.magic1q:
				if (character.totalCapMagic() >= 1000000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.magichardcap:
				if (character.totalCapMagic() >= character.hardCap())
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res3unlock:
				if (character.res3.res3On)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res31m:
				if (character.totalCapRes3() >= 1000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res31b:
				if (character.totalCapRes3() >= 1000000000)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res31t:
				if (character.totalCapRes3() >= 1000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res31q:
				if (character.totalCapRes3() >= 1000000000000000L)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.res3hardcap:
				if (character.adventure.finalTitanDefeated)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.lol69:
				if (character.achievements.achievementComplete[127])
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.augsunlocked:
				if (character.bossID >= 17)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.bmunlocked:
				if (character.bossID >= 37)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.nguunlocked:
				if (character.settings.nguOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.yggunlocked:
				if (character.settings.yggdrasilOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.diggersunlocked:
				if (character.settings.diggersOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.beardsunlocked:
				if (character.settings.beardsOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.questsunlocked:
				if (character.settings.beastOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.hacksunlocked:
				if (character.hacks.hacksOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.wishesunlocked:
				if (character.wishes.wishesOn)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.exploder:
				if (character.achievements.achievementComplete[126])
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.enterevil:
				if (character.settings.rebirthDifficulty >= difficulty.evil)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.entersadistic:
				if (character.settings.rebirthDifficulty >= difficulty.sadistic)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.firstchallenge:
				if (character.challenges.basicChallenge.curCompletions >= 1)
				{
					unlockAchievement(achievement_t);
				}
				break;
			case Achievement.trollchallenge:
				if (character.challenges.trollChallenge.curCompletions >= 1)
				{
					unlockAchievement(achievement_t);
				}
				break;
			}
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			_ = pCallback.m_nMaxProgress;
		}
	}

	private void unlockAchievement(Achievement_t achievement)
	{
		achievement.m_bAchieved = true;
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());
		m_bStoreStats = true;
	}

	public void setSteamNameOnFile()
	{
		if (character.platform == platform.Steam && m_bInitialized)
		{
			try
			{
				string personaName = SteamFriends.GetPersonaName();
				character.playerName = personaName;
			}
			catch (Exception)
			{
				character.playerName = "Bob";
			}
		}
	}
}
