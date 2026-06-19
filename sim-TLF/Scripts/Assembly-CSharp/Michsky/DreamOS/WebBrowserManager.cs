using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Michsky.DreamOS
{
	public class WebBrowserManager : MonoBehaviour
	{
		[Serializable]
		public class TabItem
		{
			public string guid;

			public int pageIndex;

			public string pageUrl;

			public GameObject tabPage;

			public WebBrowserTabItem item;

			public List<WebBrowserLibrary.WebPage> tabHistory = new List<WebBrowserLibrary.WebPage>();
		}

		[Serializable]
		public class ActiveCoroutine
		{
			public string targetGuid;

			public Coroutine coroutine;
		}

		public Action<string> OnWebPageOpen;

		public NetworkManager networkManager;

		public WebBrowserLibrary webLibrary;

		[SerializeField]
		private GameObject tabPreset;

		[SerializeField]
		private Transform tabParent;

		[SerializeField]
		private Transform pageViewer;

		[SerializeField]
		private ButtonManager newTabButton;

		[SerializeField]
		private ButtonManager backButton;

		[SerializeField]
		private ButtonManager forwardButton;

		[SerializeField]
		private TMP_InputField urlField;

		[SerializeField]
		private ButtonManager favoriteButton;

		[SerializeField]
		private AnimatedIconHandler favoriteAnimator;

		[SerializeField]
		private GameObject favoritePreset;

		[SerializeField]
		private Transform favoritesParent;

		[SerializeField]
		private GameObject downloadPreset;

		[SerializeField]
		private Transform downloadsParent;

		[SerializeField]
		private PopupPanelManager downloadsPanel;

		[SerializeField]
		private MusicPlayerManager musicPlayerApp;

		[SerializeField]
		private VideoPlayerManager videoPlayerApp;

		[SerializeField]
		private NotepadManager notepadApp;

		[SerializeField]
		private PhotoGalleryManager photoGalleryApp;

		[SerializeField]
		private bool rememberTabsOnLaunch;

		[SerializeField]
		private bool openDownloadsPanel = true;

		[SerializeField]
		private bool useLocalization = true;

		[SerializeField]
		[Range(1f, 10f)]
		private int maxTabLimit = 4;

		[SerializeField]
		[Range(1f, 15f)]
		private float timeoutDuration = 4f;

		[SerializeField]
		[Range(0.1f, 100f)]
		private float defaultNetworkSpeed = 50f;

		private bool hasDynamicNetwork;

		private bool isUrlFieldActive;

		private int currentTabCount;

		private string currentTabGuid;

		private LocalizedObject localizedObject;

		public List<TabItem> currentTabs = new List<TabItem>();

		public List<WebBrowserFavoritesItem> favoritePages = new List<WebBrowserFavoritesItem>();

		public List<ActiveCoroutine> activeCoroutines = new List<ActiveCoroutine>();

		public List<WebBrowserDownloadItem> activeDownloads = new List<WebBrowserDownloadItem>();

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Network;

		[Inject]
		protected DiContainer _container;

		private void Awake()
		{
			if (networkManager == null)
			{
				networkManager = UnityEngine.Object.FindObjectsByType<NetworkManager>(FindObjectsSortMode.None)[0];
			}
			if (backButton != null)
			{
				backButton.onClick.AddListener(delegate
				{
					GoBack();
				});
			}
			if (forwardButton != null)
			{
				forwardButton.onClick.AddListener(delegate
				{
					GoForward();
				});
			}
			if (newTabButton != null)
			{
				newTabButton.onClick.AddListener(delegate
				{
					CreateNewTab();
				});
			}
			if (favoriteButton != null)
			{
				favoriteButton.onClick.AddListener(delegate
				{
					SetFavoriteState();
				});
			}
			if (localizedObject == null)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
			}
			foreach (Transform item in tabParent)
			{
				if (item != newTabButton.transform)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			Initialize();
		}

		private void Start()
		{
			ListFavorites();
			ListDownloads();
		}

		private void OnEnable()
		{
			int tabIndex = GetTabIndex(currentTabGuid);
			urlField.text = currentTabs[tabIndex].pageUrl;
		}

		private void OnDisable()
		{
			if (!rememberTabsOnLaunch)
			{
				CloseAllTabs();
			}
		}

		private void Update()
		{
			if (isUrlFieldActive && Keyboard.current.enterKey.wasPressedThisFrame)
			{
				urlField.interactable = false;
				urlField.interactable = true;
				ActivateURLField(value: false);
				OpenPage(urlField.text);
			}
			if (activeDownloads.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < activeDownloads.Count; i++)
			{
				if (!(activeDownloads[i] == null))
				{
					activeDownloads[i].ProcessItem();
				}
			}
		}

		public void Initialize()
		{
			if (networkManager == null)
			{
				hasDynamicNetwork = false;
			}
			else
			{
				hasDynamicNetwork = true;
			}
			backButton.Interactable(value: false);
			forwardButton.Interactable(value: false);
			CreateNewTab();
		}

		public WebBrowserTabItem CreateNewTab(string customUrl = null)
		{
			if (currentTabCount == maxTabLimit)
			{
				return null;
			}
			currentTabCount++;
			currentTabGuid = DreamOSInternalTools.GenerateUniqueGuid();
			string tempTabGuid = currentTabGuid;
			GameObject obj = UnityEngine.Object.Instantiate(tabPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
			obj.transform.SetParent(tabParent, worldPositionStays: false);
			obj.gameObject.name = tempTabGuid;
			WebBrowserTabItem component = obj.GetComponent<WebBrowserTabItem>();
			component.manager = this;
			component.guid = tempTabGuid;
			component.mainButton.onClick.AddListener(delegate
			{
				SwitchToTab(tempTabGuid);
			});
			component.closeButton.onClick.AddListener(delegate
			{
				CloseTab(tempTabGuid);
			});
			TabItem tabItem = new TabItem();
			tabItem.guid = currentTabGuid;
			tabItem.item = component;
			currentTabs.Add(tabItem);
			if (string.IsNullOrEmpty(customUrl))
			{
				OpenHomePage();
			}
			else
			{
				OpenPage(customUrl);
			}
			if (newTabButton != null && currentTabCount == maxTabLimit)
			{
				newTabButton.Interactable(value: false);
			}
			if (newTabButton != null)
			{
				newTabButton.transform.SetAsLastSibling();
			}
			SwitchToTab(tempTabGuid);
			return component;
		}

		public void CloseTab(string guid)
		{
			int tabIndex = GetTabIndex(guid);
			for (int i = 0; i < activeCoroutines.Count; i++)
			{
				if (activeCoroutines[i].targetGuid == currentTabGuid)
				{
					StopCoroutine(activeCoroutines[i].coroutine);
					activeCoroutines.RemoveAt(i);
				}
			}
			UnityEngine.Object.Destroy(currentTabs[tabIndex].tabPage);
			UnityEngine.Object.Destroy(currentTabs[tabIndex].item.gameObject);
			currentTabs.RemoveAt(tabIndex);
			currentTabCount--;
			if (currentTabCount == 0)
			{
				CreateNewTab();
			}
			else
			{
				SwitchToTab(currentTabs[currentTabs.Count - 1].guid);
			}
			if (newTabButton != null && currentTabCount < maxTabLimit)
			{
				newTabButton.Interactable(value: true);
			}
			UpdateButtonStates();
		}

		public void SwitchToTab(string guid)
		{
			int index = GetTabIndex(guid);
			currentTabGuid = guid;
			for (int i = 0; i < currentTabs.Count; i++)
			{
				if (!(currentTabs[i].tabPage == null))
				{
					if (currentTabGuid == currentTabs[i].guid)
					{
						currentTabs[i].item.SetIndicator(value: true);
						currentTabs[i].tabPage.SetActive(value: true);
						index = i;
					}
					else
					{
						currentTabs[i].item.SetIndicator(value: false);
						currentTabs[i].tabPage.SetActive(value: false);
					}
				}
			}
			GetFavoriteState(currentTabs[index].pageUrl);
			UpdateButtonStates();
			urlField.text = currentTabs[index].pageUrl;
		}

		public void CloseAllTabs()
		{
			for (int i = 0; i < currentTabs.Count; i++)
			{
				CloseTab(currentTabs[i].guid);
			}
		}

		public void OpenHomePage()
		{
			int tabIndex = GetTabIndex(currentTabGuid);
			string text = webLibrary.homePage.pageTitle;
			if (useLocalization && !string.IsNullOrEmpty(webLibrary.homePage.titleKey) && localizedObject != null && localizedObject.CheckLocalizationStatus())
			{
				text = localizedObject.GetKeyOutput(webLibrary.homePage.titleKey);
			}
			currentTabs[tabIndex].item.SetData(webLibrary.homePage.pageIcon, text);
			if (currentTabs[tabIndex].tabPage != null)
			{
				UnityEngine.Object.Destroy(currentTabs[tabIndex].tabPage);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(webLibrary.homePage.pageContent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.name = webLibrary.homePage.pageURL;
			gameObject.transform.SetParent(pageViewer, worldPositionStays: false);
			currentTabs[tabIndex].tabPage = gameObject;
			currentTabs[tabIndex].pageUrl = webLibrary.homePage.pageURL;
			if (currentTabs[tabIndex].tabHistory.Count == 0 || currentTabs[tabIndex].pageUrl != webLibrary.homePage.pageURL)
			{
				WebBrowserLibrary.WebPage webPage = new WebBrowserLibrary.WebPage();
				webPage.pageURL = webLibrary.homePage.pageURL;
				webPage.pageTitle = webLibrary.homePage.pageTitle;
				webPage.pageIcon = webLibrary.homePage.pageIcon;
				webPage.pageSize = webLibrary.homePage.pageSize;
				webPage.pageContent = webLibrary.homePage.pageContent;
				currentTabs[tabIndex].tabHistory.Add(webPage);
				currentTabs[tabIndex].pageIndex = currentTabs[tabIndex].tabHistory.Count - 1;
			}
			urlField.text = webLibrary.homePage.pageURL;
		}

		public void OpenNotFoundPage(string tabGuid = null, bool isEnabled = true)
		{
			if (string.IsNullOrEmpty(tabGuid))
			{
				tabGuid = currentTabGuid;
			}
			int tabIndex = GetTabIndex(tabGuid);
			string text = webLibrary.notFoundPage.pageTitle;
			if (useLocalization && !string.IsNullOrEmpty(webLibrary.notFoundPage.titleKey) && localizedObject != null && localizedObject.CheckLocalizationStatus())
			{
				text = localizedObject.GetKeyOutput(webLibrary.notFoundPage.titleKey);
			}
			currentTabs[tabIndex].item.SetData(webLibrary.notFoundPage.pageIcon, text);
			GameObject gameObject = UnityEngine.Object.Instantiate(webLibrary.notFoundPage.pageContent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.name = webLibrary.notFoundPage.pageURL;
			gameObject.transform.SetParent(pageViewer, worldPositionStays: false);
			if (!isEnabled)
			{
				gameObject.SetActive(value: false);
			}
			currentTabs[tabIndex].tabPage = gameObject;
		}

		public void OpenNoConnectionPage(string tabGuid = null, bool isEnabled = true)
		{
			if (string.IsNullOrEmpty(tabGuid))
			{
				tabGuid = currentTabGuid;
			}
			int tabIndex = GetTabIndex(tabGuid);
			string text = webLibrary.noConnectionPage.pageTitle;
			if (useLocalization && !string.IsNullOrEmpty(webLibrary.noConnectionPage.titleKey) && localizedObject != null && localizedObject.CheckLocalizationStatus())
			{
				text = localizedObject.GetKeyOutput(webLibrary.noConnectionPage.titleKey);
			}
			currentTabs[tabIndex].item.SetData(webLibrary.noConnectionPage.pageIcon, text);
			GameObject gameObject = UnityEngine.Object.Instantiate(webLibrary.noConnectionPage.pageContent, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.name = webLibrary.noConnectionPage.pageURL;
			gameObject.transform.SetParent(pageViewer, worldPositionStays: false);
			if (!isEnabled)
			{
				gameObject.SetActive(value: false);
			}
			currentTabs[tabIndex].tabPage = gameObject;
		}

		public void OpenPage(string targetUrl, bool addToHistory = true)
		{
			for (int i = 0; i < activeCoroutines.Count; i++)
			{
				if (activeCoroutines[i].targetGuid == currentTabGuid)
				{
					StopCoroutine(activeCoroutines[i].coroutine);
					activeCoroutines.RemoveAt(i);
					break;
				}
			}
			OnWebPageOpen?.Invoke(targetUrl);
			Coroutine coroutine = StartCoroutine(OpenPageHelper(targetUrl, addToHistory));
			ActiveCoroutine activeCoroutine = new ActiveCoroutine();
			activeCoroutine.coroutine = coroutine;
			activeCoroutine.targetGuid = currentTabGuid;
			activeCoroutines.Add(activeCoroutine);
		}

		private IEnumerator OpenPageHelper(string targetUrl, bool addToHistory)
		{
			int urlIndex = -1;
			int tabIndex = GetTabIndex(currentTabGuid);
			float seconds = 0f;
			bool createNoConnection = false;
			bool createDown = false;
			bool createNotFound = false;
			bool createHome = false;
			GameObject previousPage = null;
			GameObject newPage = null;
			urlField.text = targetUrl;
			for (int i = 0; i < webLibrary.webPages.Count; i++)
			{
				if (urlField.text.ToLower() == webLibrary.webPages[i].pageURL || urlField.text.ToLower() == "www." + webLibrary.webPages[i].pageURL)
				{
					urlIndex = i;
					break;
				}
			}
			if ((hasDynamicNetwork && !networkManager.isConnected) || urlField.text == webLibrary.homePage.pageURL)
			{
				seconds = 0f;
			}
			else if (urlIndex == -1)
			{
				seconds = timeoutDuration;
			}
			else if (hasDynamicNetwork && urlIndex != -1)
			{
				seconds = webLibrary.webPages[urlIndex].pageSize / networkManager.networkItems[networkManager.currentNetworkIndex].networkSpeed;
			}
			else if (!hasDynamicNetwork && urlIndex != -1)
			{
				seconds = webLibrary.webPages[urlIndex].pageSize / defaultNetworkSpeed;
			}
			currentTabs[tabIndex].item.EnableSpinner();
			if (addToHistory && urlIndex != -1)
			{
				WebBrowserLibrary.WebPage webPage = new WebBrowserLibrary.WebPage();
				webPage.pageURL = webLibrary.webPages[urlIndex].pageURL;
				webPage.pageTitle = webLibrary.webPages[urlIndex].pageTitle;
				webPage.pageIcon = webLibrary.webPages[urlIndex].pageIcon;
				webPage.pageSize = webLibrary.webPages[urlIndex].pageSize;
				webPage.pageContent = webLibrary.webPages[urlIndex].pageContent;
				currentTabs[tabIndex].tabHistory.Add(webPage);
				currentTabs[tabIndex].pageIndex = currentTabs[tabIndex].tabHistory.Count - 1;
			}
			else if (addToHistory && urlIndex == -1)
			{
				WebBrowserLibrary.WebPage webPage2 = new WebBrowserLibrary.WebPage();
				webPage2.pageURL = urlField.text;
				webPage2.pageTitle = webLibrary.notFoundPage.pageTitle;
				webPage2.pageIcon = webLibrary.notFoundPage.pageIcon;
				currentTabs[tabIndex].tabHistory.Add(webPage2);
				currentTabs[tabIndex].pageIndex = currentTabs[tabIndex].tabHistory.Count - 1;
			}
			if (currentTabs[tabIndex].tabPage != null)
			{
				previousPage = currentTabs[tabIndex].tabPage;
			}
			if (targetUrl == webLibrary.homePage.pageURL)
			{
				OpenHomePage();
				createHome = true;
				currentTabs[tabIndex].pageUrl = webLibrary.homePage.pageURL;
			}
			else if (hasDynamicNetwork && !networkManager.isConnected)
			{
				createNoConnection = true;
				currentTabs[tabIndex].pageUrl = urlField.text;
			}
			else if ((hasDynamicNetwork && networkManager.isConnected && urlIndex == -1) || (!hasDynamicNetwork && urlIndex == -1))
			{
				createNotFound = true;
				currentTabs[tabIndex].pageUrl = urlField.text;
			}
			else if (hasDynamicNetwork && networkManager.isConnected && !webLibrary.webPages[urlIndex].IsUp)
			{
				createDown = true;
				currentTabs[tabIndex].pageUrl = webLibrary.webPages[urlIndex].pageURL;
			}
			else
			{
				GameObject gameObject = _container.InstantiatePrefab(webLibrary.webPages[urlIndex].pageContent, pageViewer);
				gameObject.name = webLibrary.webPages[urlIndex].pageURL;
				gameObject.gameObject.SetActive(value: false);
				newPage = gameObject;
				currentTabs[tabIndex].pageUrl = webLibrary.webPages[urlIndex].pageURL;
			}
			GetFavoriteState(currentTabs[tabIndex].pageUrl);
			UpdateButtonStates();
			yield return new WaitForSeconds(seconds);
			if (urlIndex != -1)
			{
				string text = webLibrary.webPages[urlIndex].pageTitle;
				if (useLocalization && !string.IsNullOrEmpty(webLibrary.webPages[urlIndex].titleKey) && localizedObject != null && localizedObject.CheckLocalizationStatus())
				{
					text = localizedObject.GetKeyOutput(webLibrary.webPages[urlIndex].titleKey);
				}
				currentTabs[tabIndex].item.SetData(webLibrary.webPages[urlIndex].pageIcon, text);
			}
			currentTabs[tabIndex].item.DisableSpinner();
			if (previousPage != null)
			{
				UnityEngine.Object.Destroy(previousPage);
			}
			if (!createHome)
			{
				currentTabs[tabIndex].tabPage = newPage;
			}
			if (currentTabGuid == currentTabs[tabIndex].guid)
			{
				if (currentTabs[tabIndex].tabPage != null)
				{
					currentTabs[tabIndex].tabPage.SetActive(value: true);
				}
				if (urlIndex != -1)
				{
					urlField.text = currentTabs[tabIndex].pageUrl;
				}
				else if (urlIndex == -1)
				{
					urlField.text = currentTabs[tabIndex].tabHistory[currentTabs[tabIndex].pageIndex].pageURL;
				}
				if (createNoConnection)
				{
					OpenNoConnectionPage(currentTabs[tabIndex].guid);
				}
				else if (createDown)
				{
					OpenNoConnectionPage(currentTabs[tabIndex].guid);
				}
				else if (createNotFound)
				{
					OpenNotFoundPage(currentTabs[tabIndex].guid);
				}
			}
			else if (createNoConnection)
			{
				OpenNoConnectionPage(currentTabs[tabIndex].guid, isEnabled: false);
			}
			else if (createDown)
			{
				OpenNoConnectionPage(currentTabs[tabIndex].guid, isEnabled: false);
			}
			else if (createNotFound)
			{
				OpenNotFoundPage(currentTabs[tabIndex].guid, isEnabled: false);
			}
			for (int j = 0; j < activeCoroutines.Count; j++)
			{
				if (activeCoroutines[j].targetGuid == currentTabs[tabIndex].guid)
				{
					activeCoroutines.RemoveAt(j);
					break;
				}
			}
		}

		public void GoBack()
		{
			int tabIndex = GetTabIndex(currentTabGuid);
			if (currentTabs[tabIndex].tabHistory.Count > 0)
			{
				currentTabs[tabIndex].pageIndex--;
				OpenPage(currentTabs[tabIndex].tabHistory[currentTabs[tabIndex].pageIndex].pageURL, addToHistory: false);
			}
		}

		public void GoForward()
		{
			int tabIndex = GetTabIndex(currentTabGuid);
			if (currentTabs[tabIndex].tabHistory.Count > 0 && currentTabs[tabIndex].pageIndex < currentTabs[tabIndex].tabHistory.Count - 1)
			{
				currentTabs[tabIndex].pageIndex++;
				OpenPage(currentTabs[tabIndex].tabHistory[currentTabs[tabIndex].pageIndex].pageURL, addToHistory: false);
			}
		}

		public void Refresh()
		{
			OpenPage(currentTabs[GetTabIndex(currentTabGuid)].pageUrl, addToHistory: false);
		}

		public void DownloadFile(string fileName)
		{
			for (int i = 0; i < webLibrary.dlFiles.Count; i++)
			{
				string key = webLibrary.dlFiles[i].fileName + "_DownloadState";
				if (!(webLibrary.dlFiles[i].fileName == fileName))
				{
					continue;
				}
				if (DreamOSDataManager.ContainsJsonKey(dataCat, key) && DreamOSDataManager.ReadIntData(dataCat, key) != 0)
				{
					if (openDownloadsPanel && downloadsPanel != null)
					{
						downloadsPanel.OpenPanel();
					}
					return;
				}
				int index = i;
				DreamOSDataManager.WriteIntData(dataCat, fileName + "_DownloadState", 1);
				GameObject gameObject = UnityEngine.Object.Instantiate(downloadPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.name = webLibrary.dlFiles[i].fileName;
				gameObject.transform.SetParent(downloadsParent, worldPositionStays: false);
				WebBrowserDownloadItem dItem = gameObject.GetComponent<WebBrowserDownloadItem>();
				dItem.manager = this;
				dItem.fileIcon = webLibrary.dlFiles[i].fileIcon;
				dItem.fileName = webLibrary.dlFiles[i].fileName;
				dItem.fileSize = webLibrary.dlFiles[i].fileSize;
				dItem.ProcessDownload();
				activeDownloads.Add(dItem);
				if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Music && musicPlayerApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						musicPlayerApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						musicPlayerApp.PlayCustomClip(webLibrary.dlFiles[index].musicReference, dItem.fileIcon, dItem.fileName, "Downloads");
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Note && notepadApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						notepadApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						notepadApp.OpenCustomNote(dItem.fileName, webLibrary.dlFiles[index].noteReference);
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Photo && photoGalleryApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						photoGalleryApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						photoGalleryApp.OpenPhoto(webLibrary.dlFiles[index].photoReference, dItem.fileName, "Downloads");
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Video && videoPlayerApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						videoPlayerApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						videoPlayerApp.OpenVideo(webLibrary.dlFiles[index].videoReference, dItem.fileName);
					});
				}
				break;
			}
			if (openDownloadsPanel && downloadsPanel != null)
			{
				downloadsPanel.OpenPanel();
			}
		}

		public void DeleteDownloadedFile(string fileName)
		{
			for (int i = 0; i < webLibrary.dlFiles.Count; i++)
			{
				if (!(webLibrary.dlFiles[i].fileName == fileName))
				{
					continue;
				}
				DreamOSDataManager.WriteIntData(dataCat, fileName + "_DownloadState", 0);
				{
					foreach (Transform item in downloadsParent)
					{
						if (item.gameObject.name == fileName)
						{
							UnityEngine.Object.Destroy(item.gameObject);
						}
					}
					break;
				}
			}
		}

		public void UpdateButtonStates()
		{
			if (!(backButton == null) && !(forwardButton == null))
			{
				int tabIndex = GetTabIndex(currentTabGuid);
				if (currentTabs[tabIndex].tabHistory.Count > 1 && currentTabs[tabIndex].pageIndex == 0)
				{
					backButton.Interactable(value: false);
					forwardButton.Interactable(value: true);
				}
				else if (currentTabs[tabIndex].tabHistory.Count > 1 && currentTabs[tabIndex].pageIndex == currentTabs[tabIndex].tabHistory.Count - 1)
				{
					backButton.Interactable(value: true);
					forwardButton.Interactable(value: false);
				}
				else if (currentTabs[tabIndex].tabHistory.Count > 1 && currentTabs[tabIndex].pageIndex != 0 && currentTabs[tabIndex].pageIndex != currentTabs[tabIndex].tabHistory.Count - 1)
				{
					backButton.Interactable(value: true);
					forwardButton.Interactable(value: true);
				}
				else
				{
					backButton.Interactable(value: false);
					forwardButton.Interactable(value: false);
				}
			}
		}

		public void GetFavoriteState(string url)
		{
			if (!DreamOSDataManager.ContainsJsonKey(dataCat, url + "_IsFavorite"))
			{
				favoriteAnimator.PlayOut();
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCat, url + "_IsFavorite"))
			{
				favoriteAnimator.PlayIn();
			}
			else if (url == webLibrary.homePage.pageURL || url == webLibrary.noConnectionPage.pageURL || url == webLibrary.notFoundPage.pageURL)
			{
				favoriteAnimator.PlayOut();
			}
			else
			{
				favoriteAnimator.PlayOut();
			}
		}

		public void SetFavoriteState()
		{
			int tabIndex = GetTabIndex(currentTabGuid);
			string pageUrl = currentTabs[tabIndex].pageUrl;
			if (!(pageUrl == webLibrary.homePage.pageURL) && !(pageUrl == webLibrary.noConnectionPage.pageURL) && !(pageUrl == webLibrary.notFoundPage.pageURL))
			{
				bool value = !DreamOSDataManager.ContainsJsonKey(dataCat, pageUrl + "_IsFavorite") || !DreamOSDataManager.ReadBooleanData(dataCat, pageUrl + "_IsFavorite");
				SetFavoriteState(value, pageUrl);
			}
		}

		public void SetFavoriteState(bool value, string url, bool writeData = true)
		{
			bool flag = false;
			GetTabIndex(currentTabGuid);
			WebBrowserLibrary.WebPage webPage = GetWebPage(url);
			for (int i = 0; i < webLibrary.webPages.Count; i++)
			{
				if (url == webLibrary.webPages[i].pageURL)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			if (value)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(favoritePreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.name = url;
				gameObject.transform.SetParent(favoritesParent, worldPositionStays: false);
				WebBrowserFavoritesItem fItem = gameObject.GetComponent<WebBrowserFavoritesItem>();
				fItem.manager = this;
				fItem.url = url;
				fItem.iconObject.sprite = webPage.pageIcon;
				fItem.titleObject.text = webPage.pageTitle;
				fItem.urlObject.text = webPage.pageURL;
				fItem.button.onClick.AddListener(delegate
				{
					OpenPage(fItem.url);
				});
				favoritePages.Add(fItem);
				favoriteAnimator.PlayIn();
			}
			else
			{
				for (int num = 0; num < favoritePages.Count; num++)
				{
					if (favoritePages[num].url == url)
					{
						UnityEngine.Object.Destroy(favoritePages[num].gameObject);
						favoritePages.RemoveAt(num);
						break;
					}
				}
				favoriteAnimator.PlayOut();
			}
			if (writeData)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, url + "_IsFavorite", value);
			}
		}

		public void ListFavorites()
		{
			foreach (Transform item in favoritesParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < webLibrary.webPages.Count; i++)
			{
				if (DreamOSDataManager.ContainsJsonKey(dataCat, webLibrary.webPages[i].pageURL + "_IsFavorite"))
				{
					SetFavoriteState(DreamOSDataManager.ReadBooleanData(dataCat, webLibrary.webPages[i].pageURL + "_IsFavorite"), webLibrary.webPages[i].pageURL, writeData: false);
				}
			}
		}

		public void ListDownloads()
		{
			foreach (Transform item in downloadsParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < webLibrary.dlFiles.Count; i++)
			{
				if (!DreamOSDataManager.ContainsJsonKey(dataCat, webLibrary.dlFiles[i].fileName + "_DownloadState") || DreamOSDataManager.ReadIntData(dataCat, webLibrary.dlFiles[i].fileName + "_DownloadState") == 0)
				{
					continue;
				}
				int index = i;
				GameObject gameObject = UnityEngine.Object.Instantiate(downloadPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.name = webLibrary.dlFiles[i].fileName;
				gameObject.transform.SetParent(downloadsParent, worldPositionStays: false);
				WebBrowserDownloadItem dItem = gameObject.GetComponent<WebBrowserDownloadItem>();
				dItem.manager = this;
				dItem.fileIcon = webLibrary.dlFiles[i].fileIcon;
				dItem.fileName = webLibrary.dlFiles[i].fileName;
				dItem.fileSize = webLibrary.dlFiles[i].fileSize;
				if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Music && musicPlayerApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						musicPlayerApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						musicPlayerApp.PlayCustomClip(webLibrary.dlFiles[index].musicReference, dItem.fileIcon, dItem.fileName, "Downloads");
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Note && notepadApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						notepadApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						notepadApp.OpenCustomNote(dItem.fileName, webLibrary.dlFiles[index].noteReference);
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Photo && photoGalleryApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						photoGalleryApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						photoGalleryApp.OpenPhoto(webLibrary.dlFiles[index].photoReference, dItem.fileName, "Downloads");
					});
				}
				else if (webLibrary.dlFiles[i].fileType == WebBrowserLibrary.FileType.Video && videoPlayerApp != null)
				{
					dItem.buttonObject.onClick.AddListener(delegate
					{
						videoPlayerApp.gameObject.GetComponent<WindowManager>().OpenWindow();
						videoPlayerApp.OpenVideo(webLibrary.dlFiles[index].videoReference, dItem.fileName);
					});
				}
				if (DreamOSDataManager.ReadIntData(dataCat, webLibrary.dlFiles[i].fileName + "_DownloadState") == 1)
				{
					activeDownloads.Add(dItem);
					dItem.ProcessDownload();
				}
				else if (DreamOSDataManager.ReadIntData(dataCat, webLibrary.dlFiles[i].fileName + "_DownloadState") == 2)
				{
					dItem.ProcessComplete();
				}
			}
		}

		public void ActivateURLField(bool value)
		{
			isUrlFieldActive = value;
		}

		private int GetTabIndex(string guid)
		{
			int result = -1;
			for (int i = 0; i < currentTabs.Count; i++)
			{
				if (currentTabs[i].guid == guid)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		private WebBrowserLibrary.WebPage GetWebPage(string url)
		{
			WebBrowserLibrary.WebPage result = null;
			for (int i = 0; i < webLibrary.webPages.Count; i++)
			{
				if (webLibrary.webPages[i].pageURL == url)
				{
					result = webLibrary.webPages[i];
					break;
				}
			}
			return result;
		}
	}
}
