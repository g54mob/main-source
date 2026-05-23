using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainGameManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAutoSaveCoroutine_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainGameManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAutoSaveCoroutine_003Ed__82(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static MainGameManager instance;

	public int difficulty;

	public Camera playerCamera;

	public bool isGamePaused;

	public bool isPauseMenuDisallowed;

	public bool isPlayerCameraDisallowed;

	public bool isAllowedToSave;

	public bool loadingFirstTime;

	public string languageXMLPath;

	public SetIP setIP;

	[SerializeField]
	private GameObject canvasCustomerChoice;

	[SerializeField]
	private CustomerCard[] customerCards;

	public CustomerItem[] customerItems;

	[SerializeField]
	private Sprite[] appTypesLogos;

	public CustomerBase[] customerBases;

	private CustomerBaseDoor customerBaseDoor;

	private CustomerItem[] chosenCustomerItems;

	private List<int> availableCustomerIndices;

	public List<string> availableSubnets;

	public Sprite appTypesColorSprite1;

	public Sprite appTypesColorSprite2;

	public Sprite appTypesColorSprite3;

	public Sprite appTypesColorSprite4;

	public List<int> existingCustomerIDs;

	public List<Vector3> assignedAppsLogos;

	[SerializeField]
	private GameObject[] serverPrefabs;

	[SerializeField]
	private GameObject[] switchesPrefabs;

	public GameObject patchPanelPrefab;

	public GameObject rackPackedPrefab;

	public GameObject rackPrefab;

	public GameObject rackMounts;

	public GameObject[] cableSpinnerPrefab;

	public GameObject[] sfpPrefabs;

	public GameObject[] sfpsBoxedPrefab;

	public GameObject emptySfpBox;

	public GameObject walls;

	public Wall wallToBuy;

	public float wallPrice;

	[SerializeField]
	private GameObject canvasOpenWall;

	[SerializeField]
	private TextMeshProUGUI txtOpenWallPrice;

	public Transform parentUsableObjects;

	public int lastUsedRackPositionGlobalUID;

	public ComputerShop computerShop;

	public static PlayerManager.OnBuyingWall onBuyingWallEvent;

	public Material blinkingGreenLightMaterial;

	public Material blinkingRedLightMaterial;

	public Material redLightMaterial;

	public Material greenLightMaterial;

	public GameObject particleSystemBrokenDevice;

	public Transform placeToRespawnLostUsableObjects;

	public bool isIPHintHidden;

	public NetworkSwitchConfiguration networkSwitchConfiguration;

	[Header("AutoSave")]
	[SerializeField]
	private float autoSaveIntervalMinutes;

	[SerializeField]
	private bool autoSaveEnabled;

	private Coroutine autoSaveCoroutine;

	private Action<InputAction.CallbackContext> escapePerformed;

	private void Awake()
	{
	}

	public GameObject GetServerPrefab(int serverType)
	{
		return null;
	}

	public GameObject GetSwitchPrefab(int switchType)
	{
		return null;
	}

	public GameObject GetCableSpinnerPrefab(int prefabID)
	{
		return null;
	}

	public GameObject GetSfpPrefab(int prefabID)
	{
		return null;
	}

	public GameObject GetSfpBoxPrefab(int prefabID)
	{
		return null;
	}

	public CustomerItem GetCustomerItemByID(int customerID)
	{
		return null;
	}

	private void Start()
	{
	}

	private void ShuffleAvailableCustomers()
	{
	}

	private void ShuffleAvailableSubnets()
	{
	}

	public Sprite GetAppLogo(int customerID, int appID)
	{
		return null;
	}

	public Sprite GetCustomerLogo(int customerID)
	{
		return null;
	}

	public string GetFreeSubnet(float appRequirements)
	{
		return null;
	}

	public void ShowCustomerCardsCanvas(CustomerBaseDoor _door)
	{
	}

	public void ButtonCustomerChosen(int _cardID)
	{
	}

	public void ButtonCancelCustomerChoice()
	{
	}

	public void ShowBuyWallCanvas(Wall wall)
	{
	}

	public void ButtonBuyWall()
	{
	}

	public void ButtonCancelBuyWall()
	{
	}

	public void ShowNetworkConfigCanvas(NetworkSwitch networkSwitch)
	{
	}

	public void CloseNetworkConfigCanvas()
	{
	}

	private void OpenAnyCanvas()
	{
	}

	private void CloseAnyCanvas(bool isCustomerChoice = false)
	{
	}

	public void RemoveUsedSubnet(string subnet)
	{
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CAutoSaveCoroutine_003Ed__82))]
	private IEnumerator AutoSaveCoroutine()
	{
		return null;
	}

	public void SetAutoSaveInterval(float minutes)
	{
	}

	public void SetAutoSaveEnabled(bool enabled)
	{
	}

	private void RestartAutoSave()
	{
	}

	public string ReturnServerNameFromType(int type)
	{
		return null;
	}

	public string ReturnSwitchNameFromType(int type)
	{
		return null;
	}
}
