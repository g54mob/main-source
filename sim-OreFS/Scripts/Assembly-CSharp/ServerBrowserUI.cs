using System;
using System.Collections.Generic;
using Heathen.SteamworksIntegration;
using Kamgam.UGUIComponentsForSettings;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerBrowserUI : MonoBehaviour
{
	[Header("References")]
	public SteamLobbyManager lobbyManager;

	[Header("UI Elements")]
	public GameObject browserPanel;

	public Transform lobbyListContainer;

	public GameObject lobbyItemPrefab;

	[Header("Search")]
	public TMP_InputField searchInputField;

	public Button searchButton;

	[Header("Filters")]
	[Tooltip("Sadece public lobyleri göster toggle'ı")]
	public Toggle showOnlyPublicLobbiesToggle;

	[Tooltip("Mesafe filtresi (OptionsButton)")]
	public OptionsButtonUGUI distanceFilterButton;

	[Header("Buttons")]
	public Button refreshButton;

	[Header("Status")]
	public GameObject noLobbiesFoundText;

	[Header("Settings")]
	[Tooltip("Maksimum gösterilecek lobby sayısı")]
	public int maxResults = 50;

	private List<LobbyItemUI> lobbyItems = new List<LobbyItemUI>();

	private LobbyData[] cachedLobbies;

	private bool isRefreshing;

	private static readonly ELobbyDistanceFilter[] distanceFilterValues = new ELobbyDistanceFilter[4]
	{
		ELobbyDistanceFilter.k_ELobbyDistanceFilterClose,
		ELobbyDistanceFilter.k_ELobbyDistanceFilterDefault,
		ELobbyDistanceFilter.k_ELobbyDistanceFilterFar,
		ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide
	};

	public static ServerBrowserUI Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		SetupButtonListeners();
		SetupEventListeners();
		SetupDistanceFilterDropdown();
		if (browserPanel != null)
		{
			browserPanel.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		RemoveEventListeners();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void SetupButtonListeners()
	{
		if (refreshButton != null)
		{
			refreshButton.onClick.AddListener(RefreshLobbyList);
		}
		if (searchButton != null)
		{
			searchButton.onClick.AddListener(SearchLobbies);
		}
		if (showOnlyPublicLobbiesToggle != null)
		{
			showOnlyPublicLobbiesToggle.onValueChanged.AddListener(OnShowOnlyPublicToggleChanged);
		}
	}

	private void SetupDistanceFilterDropdown()
	{
		if (!(distanceFilterButton == null))
		{
			distanceFilterButton.SelectedIndex = 3;
			OptionsButtonUGUI optionsButtonUGUI = distanceFilterButton;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI.OnValueChanged, (OptionsButtonUGUI.OnValueChangedDelegate)delegate
			{
				RefreshLobbyList();
			});
		}
	}

	private void SetupEventListeners()
	{
		if (lobbyManager != null)
		{
			lobbyManager.OnLobbiesFoundEvent += OnLobbiesFound;
		}
	}

	private void RemoveEventListeners()
	{
		if (lobbyManager != null)
		{
			lobbyManager.OnLobbiesFoundEvent -= OnLobbiesFound;
		}
	}

	public void Show()
	{
		RefreshLobbyList();
	}

	public void Hide()
	{
		if (browserPanel != null)
		{
			browserPanel.SetActive(value: false);
		}
	}

	public void Toggle()
	{
		if (browserPanel != null)
		{
			if (browserPanel.activeSelf)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}
	}

	public void RefreshLobbyList()
	{
		if (!isRefreshing && !(lobbyManager == null))
		{
			isRefreshing = true;
			if (searchInputField != null)
			{
				searchInputField.text = "";
			}
			SetLoadingState(loading: true);
			ClearLobbyList();
			ELobbyDistanceFilter selectedDistanceFilter = GetSelectedDistanceFilter();
			lobbyManager.SearchLobbies(maxResults, selectedDistanceFilter);
		}
	}

	private void OnLobbiesFound(LobbyData[] lobbies)
	{
		isRefreshing = false;
		SetLoadingState(loading: false);
		cachedLobbies = lobbies;
		ApplyFilters();
	}

	public void SearchLobbies()
	{
		if (!isRefreshing && !(lobbyManager == null))
		{
			isRefreshing = true;
			SetLoadingState(loading: true);
			ClearLobbyList();
			lobbyManager.SearchLobbies(maxResults);
		}
	}

	private void ApplyFilters()
	{
		ClearLobbyList();
		if (cachedLobbies == null || cachedLobbies.Length == 0)
		{
			if (noLobbiesFoundText != null)
			{
				noLobbiesFoundText.SetActive(value: true);
			}
			return;
		}
		string value = ((searchInputField != null) ? searchInputField.text.Trim().ToLowerInvariant() : "");
		bool flag = !string.IsNullOrEmpty(value);
		bool flag2 = showOnlyPublicLobbiesToggle != null && showOnlyPublicLobbiesToggle.isOn;
		int num = 0;
		LobbyData[] array = cachedLobbies;
		foreach (LobbyData lobby in array)
		{
			LobbyInfo lobbyInfo = lobbyManager.GetLobbyInfo(lobby);
			if ((!flag2 || !lobbyInfo.isPrivate) && (!flag || lobbyInfo.GetDisplayName().ToLowerInvariant().Contains(value)))
			{
				CreateLobbyItem(lobby);
				num++;
			}
		}
		if (noLobbiesFoundText != null)
		{
			noLobbiesFoundText.SetActive(num == 0);
		}
	}

	private void CreateLobbyItem(LobbyData lobby)
	{
		if (!(lobbyItemPrefab == null) && !(lobbyListContainer == null))
		{
			LobbyItemUI component = UnityEngine.Object.Instantiate(lobbyItemPrefab, lobbyListContainer).GetComponent<LobbyItemUI>();
			if (component != null)
			{
				LobbyInfo lobbyInfo = lobbyManager.GetLobbyInfo(lobby);
				component.Setup(lobbyInfo, OnLobbyItemClicked);
				lobbyItems.Add(component);
			}
		}
	}

	private void ClearLobbyList()
	{
		foreach (LobbyItemUI lobbyItem in lobbyItems)
		{
			if (lobbyItem != null && lobbyItem.gameObject != null)
			{
				UnityEngine.Object.Destroy(lobbyItem.gameObject);
			}
		}
		lobbyItems.Clear();
	}

	private void SetLoadingState(bool loading)
	{
		if (refreshButton != null)
		{
			refreshButton.interactable = !loading;
		}
		if (noLobbiesFoundText != null && loading)
		{
			noLobbiesFoundText.SetActive(value: false);
		}
	}

	private ELobbyDistanceFilter GetSelectedDistanceFilter()
	{
		if (distanceFilterButton == null)
		{
			return ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide;
		}
		int selectedIndex = distanceFilterButton.SelectedIndex;
		if (selectedIndex >= 0 && selectedIndex < distanceFilterValues.Length)
		{
			return distanceFilterValues[selectedIndex];
		}
		return ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide;
	}

	private void OnLobbyItemClicked(LobbyInfo info)
	{
		Debug.Log("[ServerBrowserUI] Lobby seçildi: " + info.GetDisplayName());
		Hide();
		if (MainMenuManager.Instance != null)
		{
			MainMenuManager.Instance.JoinLobbyWithLoading(info.lobbyId);
		}
		else if (lobbyManager != null)
		{
			lobbyManager.JoinLobbyAndStartClient(info.lobbyId);
		}
	}

	private void OnShowOnlyPublicToggleChanged(bool isOn)
	{
		ApplyFilters();
	}
}
