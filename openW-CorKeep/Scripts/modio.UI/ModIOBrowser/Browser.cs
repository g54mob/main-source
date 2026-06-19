using System;
using System.Reflection;
using ModIO;
using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class Browser : MonoSingleton<Browser>
	{
		public delegate void VirtualKeyboardDelegate(string title, string text, string placeholder, VirtualKeyboardType virtualKeyboardType, int characterLimit, bool multiline, Action<string> onClose);

		public delegate void RetrieveAuthenticationCodeDelegate(Action<string> callbackOnReceiveCode);

		public enum VirtualKeyboardType
		{
			Default = 0,
			Search = 1,
			EmailAddress = 2
		}

		[Header("Settings")]
		[Tooltip("Setting this to false will stop the Browser from automatically initializing the plugin")]
		[SerializeField]
		private bool autoInitialize = true;

		internal static bool allowEmailAuthentication = true;

		internal static bool allowExternalAuthentication = true;

		[SerializeField]
		public UiSettings uiConfig;

		[SerializeField]
		public Home homePanel;

		public SingletonAwakener SingletonAwakener;

		[Header("Main")]
		public ColorScheme colorScheme;

		public GameObject BrowserCanvas;

		public static GameObject currentFocusedPanel;

		[Header("Default Selections")]
		[SerializeField]
		private Selectable defaultCollectionSelection;

		internal static Action OnClose;

		public static VirtualKeyboardDelegate OpenVirtualKeyboard;

		private static bool openOnInitialize = false;

		public static bool IsOpen = false;

		public SearchFilter FeaturedSearchFilter { get; private set; }

		public SearchFilter[] BrowserRowSearchFilters { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			SharedUi.settings = uiConfig;
			SharedUi.colorScheme = colorScheme;
			SetModRowFilterDefaults();
		}

		private void Start()
		{
			if (autoInitialize && !ModIOUnity.IsInitialized())
			{
				OnInitialize(ModIOUnity.InitializeForUser("User"));
			}
		}

		private void Update()
		{
			if (openOnInitialize && ModIOUnity.IsInitialized())
			{
				openOnInitialize = false;
				IsInitialized();
			}
		}

		private void LateUpdate()
		{
			if (BrowserCanvas.activeSelf)
			{
				Mods.UpdateProgressState();
			}
		}

		public void CloseBrowserPanel()
		{
			Close();
			homePanel.ResetScrollRect();
		}

		public static void Open(Action onClose)
		{
			OnClose = onClose;
			if (!ModIOUnity.IsInitialized())
			{
				openOnInitialize = true;
			}
			else
			{
				IsInitialized();
			}
		}

		public static void Close()
		{
			openOnInitialize = false;
			MonoSingleton<Browser>.Instance?.BrowserCanvas?.SetActive(value: false);
			IsOpen = false;
			OnClose?.Invoke();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.gameObject.SetActive(value: false);
		}

		[Obsolete("Use EncodeEncryptedSteamAppTicket located in ModIO.Utility instead.")]
		public static string EncodeEncryptedSteamAppTicket(byte[] ticketData, uint ticketSize)
		{
			byte[] array = new byte[ticketSize];
			Array.Copy(ticketData, array, ticketSize);
			string result = null;
			try
			{
				result = Convert.ToBase64String(array);
			}
			catch (Exception ex)
			{
				Debug.LogError("[mod.io Browser] Unable to convert the app ticket to a base64 string, caught exception: " + ex.Message + " - " + ex.InnerException?.Message);
			}
			return result;
		}

		public static void SetupXboxAuthenticationOption(RetrieveAuthenticationCodeDelegate getXboxTokenDelegate, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getXboxToken = getXboxTokenDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
			});
		}

		public static void SetupSwitchAuthenticationOption(RetrieveAuthenticationCodeDelegate getSwitchNsaIdDelegate, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getSwitchToken = getSwitchNsaIdDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
			});
		}

		public static void SetupSteamAuthenticationOption(RetrieveAuthenticationCodeDelegate getSteamTicketDelegate, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getSteamAppTicket = getSteamTicketDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
			});
		}

		public static void SetupEpicAuthenticationOption(RetrieveAuthenticationCodeDelegate getEpicTicketDelegate, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getEpicAuthCode = getEpicTicketDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
			});
		}

		public static void SetupGOGAuthenticationOption(RetrieveAuthenticationCodeDelegate getGogTicketDelegate, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getGogAuthCode = getGogTicketDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
			});
		}

		public static void SetupPlayStationAuthenticationOption(RetrieveAuthenticationCodeDelegate getPlayStationAuthCodeDelegate, PlayStationEnvironment environment, string userEmail = null)
		{
			SelfInstancingMonoSingleton<MonoDispatcher>.Instance.Run(delegate
			{
				Authentication.getPlayStationAuthCode = getPlayStationAuthCodeDelegate;
				Authentication.optionalThirdPartyEmailAddressUsedForAuthentication = userEmail;
				Authentication.PSEnvironment = environment;
			});
		}

		public void SetFeaturedFilter(SearchFilter searchFilter)
		{
			FeaturedSearchFilter = searchFilter;
		}

		public void SetBrowserRowSearchFilters(SearchFilter[] searchFilters)
		{
			BrowserRowSearchFilters = searchFilters;
		}

		private void SetModRowFilterDefaults()
		{
			if (FeaturedSearchFilter == null)
			{
				FeaturedSearchFilter = new SearchFilter();
				FeaturedSearchFilter.SetPageIndex(0);
				FeaturedSearchFilter.SetPageSize(10);
				FeaturedSearchFilter.SortBy(SortModsBy.Downloads);
				FeaturedSearchFilter.SetToAscending(isAscending: true);
			}
			if (BrowserRowSearchFilters == null)
			{
				BrowserRowSearchFilters = new SearchFilter[4];
				SearchFilter searchFilter = new SearchFilter();
				searchFilter.SetPageIndex(0);
				searchFilter.SetPageSize(20);
				searchFilter.SortBy(SortModsBy.DateSubmitted);
				searchFilter.SetToAscending(isAscending: false);
				BrowserRowSearchFilters[0] = searchFilter;
				searchFilter = new SearchFilter();
				searchFilter = new SearchFilter();
				searchFilter.SetPageIndex(0);
				searchFilter.SetPageSize(20);
				searchFilter.SortBy(SortModsBy.Subscribers);
				searchFilter.SetToAscending(isAscending: true);
				BrowserRowSearchFilters[1] = searchFilter;
				searchFilter = new SearchFilter();
				searchFilter = new SearchFilter();
				searchFilter.SetPageIndex(0);
				searchFilter.SetPageSize(20);
				searchFilter.SortBy(SortModsBy.Popular);
				searchFilter.SetToAscending(isAscending: false);
				BrowserRowSearchFilters[2] = searchFilter;
				searchFilter = new SearchFilter();
				searchFilter = new SearchFilter();
				searchFilter.SetPageIndex(0);
				searchFilter.SetPageSize(20);
				searchFilter.SortBy(SortModsBy.Rating);
				searchFilter.SetToAscending(isAscending: true);
				BrowserRowSearchFilters[3] = searchFilter;
			}
		}

		private static void OnInitialize(Result result)
		{
			if (result.Succeeded())
			{
				if (openOnInitialize)
				{
					IsInitialized();
				}
				Debug.Log("[mod.io Browser] Initialized ModIO Plugin");
			}
			else
			{
				Close();
				Debug.LogWarning("[mod.io Browser] Failed to Initialize ModIO Plugin. Make sure your config file is setup, located in Assets/Resources/mod.io\nAlso check you are using the correct server address ('https://api.mod.io/v1' for production or 'https://api.test.mod.io/v1' for the test server) and that you've supplied the API Key and game Id for your game.");
			}
		}

		private static async void IsInitialized()
		{
			openOnInitialize = false;
			if (MonoSingleton<Browser>.Instance == null)
			{
				Debug.LogWarning("[mod.io Browser] Could not open because the Browser.cs singleton hasn't been set yet. (Check the gameObject holding the Browser.cs component isn't set to inactive)");
				return;
			}
			MonoSingleton<Browser>.Instance.SingletonAwakener.AttemptInitilization();
			if (!MonoSingleton<Browser>.Instance.BrowserCanvas.activeSelf)
			{
				MonoSingleton<Browser>.Instance.BrowserCanvas.SetActive(value: true);
				IsOpen = true;
			}
			SelfInstancingMonoSingleton<Collection>.Instance.CacheLocalSubscribedModStatuses();
			SelfInstancingMonoSingleton<ModIOBrowser.Implementation.Avatar>.Instance.SetupUser();
			SelfInstancingMonoSingleton<Home>.Instance.Open();
			if ((await ModIOUnityAsync.IsAuthenticated()).Succeeded())
			{
				SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated = true;
				ModIOUnity.FetchUpdates(delegate
				{
				});
			}
			else
			{
				SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated = false;
			}
			SelfInstancingMonoSingleton<Home>.Instance.RefreshHomePanel();
			ModIOUnity.EnableModManagement(Mods.ModManagementEvent);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.gameObject.SetActive(value: true);
		}

		public void OpenMenuProfile()
		{
			Navigating.OpenMenuProfile();
		}

		[ExposeMethodInEditor]
		public void CheckForMissingReferencesInScene()
		{
			Debug.LogWarning("This function may give false positives, mostly in the case of text input fields and dropdowns");
			MonoBehaviour[] array = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
			foreach (MonoBehaviour monoBehaviour in array)
			{
				FieldInfo[] fields = monoBehaviour.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.FieldType == typeof(GameObject) && fieldInfo.GetValue(monoBehaviour) == null)
					{
						Debug.LogError("Missing reference at: " + monoBehaviour.transform.FullPath());
					}
				}
			}
		}
	}
}
