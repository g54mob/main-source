using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour, ISaveLoad
{
	private int balance;

	public float coinMagnetRadius = 10f;

	public LayerMask coinLayer;

	public float interactionRadius = 3f;

	public LayerMask interactorLayer;

	private ManualAttack manualAttack;

	private ManualAttack autoAttack;

	private int networth;

	public PlayerCharacterAudio playerAudio;

	public GameObject coinSpendFX;

	public Transform coinSpendFXOrigin;

	private TagManager tagManager;

	private List<BuildingRangeIndicator> lastBuildingRangeIndicators = new List<BuildingRangeIndicator>();

	[HideInInspector]
	public UnityEvent<int> onBalanceGain = new UnityEvent<int>();

	[HideInInspector]
	public UnityEvent<int> onBalanceSpend = new UnityEvent<int>();

	[HideInInspector]
	public UnityEvent onFocusPaymentInteraction = new UnityEvent();

	[HideInInspector]
	public UnityEvent onUnfocusPaymentInteraction = new UnityEvent();

	public static PlayerInteraction instance;

	private InteractorBase focussedInteractor;

	private Player input;

	public int Networth => networth;

	public ManualAttack ManualAttack => manualAttack;

	public ManualAttack AutoAttack => autoAttack;

	public bool IsFreeToCallNight
	{
		get
		{
			if (!LocalGamestate.Instance.PlayerFrozen && focussedInteractor == null && tagManager.CountObjectsWithTag(TagManager.ETag.CastleCenter) > 0 && TutorialManager.AllowStartingTheNight && !EnemySpawner.instance.MatchOver)
			{
				return LocalGamestate.Instance.CurrentState == LocalGamestate.State.InMatch;
			}
			return false;
		}
	}

	public int Balance => balance;

	public int TrueBalance => balance + TagManager.instance.coins.Count + CoinSpawner.AllCoinsLeftToBeSpawned;

	public InteractorBase FocussedInteractor => focussedInteractor;

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		MatchSaveLoadHandler.TryLoadValue(guid, "balance", ref balance);
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "balance", TrueBalance);
	}

	private void Awake()
	{
		instance = this;
	}

	public void EquipWeapon(ManualAttack _manualAttack, ManualAttack _autoAttack)
	{
		manualAttack = _manualAttack;
		playerAudio.OnWeaponEquip(manualAttack);
		autoAttack = _autoAttack;
	}

	private void Start()
	{
		input = ReInput.players.GetPlayer(0);
		tagManager = TagManager.instance;
	}

	private void Update()
	{
		FetchCoins();
		FetchInteractors();
		RunInteraction();
	}

	private void RunInteraction()
	{
		if (LocalGamestate.Instance.PlayerFrozen)
		{
			return;
		}
		if (input.GetButtonDown("Interact"))
		{
			if ((bool)focussedInteractor)
			{
				focussedInteractor.InteractionBegin(this);
			}
			else if ((bool)manualAttack)
			{
				manualAttack.TryToAttack();
			}
		}
		if (input.GetButton("Interact") && (bool)focussedInteractor)
		{
			focussedInteractor.InteractionHold(this);
		}
		if (input.GetButtonUp("Interact") && (bool)focussedInteractor)
		{
			focussedInteractor.InteractionEnd(this);
		}
		if (input.GetButton("Preview Build Options"))
		{
			BuildingInteractor.displayAllBuildPreviews = true;
		}
		else
		{
			BuildingInteractor.displayAllBuildPreviews = false;
		}
	}

	private void FetchInteractors()
	{
		if (input.GetButton("Call Night") || input.GetButton("Interact") || ((bool)focussedInteractor && focussedInteractor is BuildingInteractor && (focussedInteractor as BuildingInteractor).IsWaitingForChoice))
		{
			return;
		}
		Collider[] array = Physics.OverlapSphere(base.transform.position, interactionRadius, interactorLayer);
		InteractorBase interactorBase = null;
		BuildingRangeIndicator buildingRangeIndicator = null;
		List<BuildingRangeIndicator> list = new List<BuildingRangeIndicator>();
		float num = float.PositiveInfinity;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			InteractorBase component = collider.GetComponent<InteractorBase>();
			buildingRangeIndicator = collider.GetComponent<BuildingRangeIndicator>();
			if ((bool)buildingRangeIndicator)
			{
				list.Add(buildingRangeIndicator);
			}
			if ((bool)component && component.CanBeInteractedWith)
			{
				float num2 = Vector3.Distance(base.transform.position, collider.ClosestPoint(base.transform.position));
				if (num2 < num)
				{
					interactorBase = component;
					num = num2;
				}
			}
		}
		if ((bool)focussedInteractor && focussedInteractor != interactorBase)
		{
			if (focussedInteractor is BuildingInteractor)
			{
				onUnfocusPaymentInteraction.Invoke();
			}
			focussedInteractor.Unfocus(this);
			focussedInteractor = null;
		}
		if ((bool)interactorBase && interactorBase != focussedInteractor)
		{
			if (interactorBase is BuildingInteractor)
			{
				onFocusPaymentInteraction.Invoke();
			}
			interactorBase.Focus(this);
			focussedInteractor = interactorBase;
		}
		foreach (BuildingRangeIndicator item in list)
		{
			if (!lastBuildingRangeIndicators.Contains(item))
			{
				item.Activate();
			}
		}
		foreach (BuildingRangeIndicator lastBuildingRangeIndicator in lastBuildingRangeIndicators)
		{
			if (!list.Contains(lastBuildingRangeIndicator))
			{
				lastBuildingRangeIndicator.Deactivate();
			}
		}
		lastBuildingRangeIndicators.Clear();
		lastBuildingRangeIndicators.AddRange(list);
	}

	private void FetchCoins()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, coinMagnetRadius, coinLayer);
		for (int i = 0; i < array.Length; i++)
		{
			Coin component = array[i].GetComponent<Coin>();
			if (component != null && component.IsFree)
			{
				component.SetTarget(this);
			}
		}
	}

	public void AddCoin(int amount = 1)
	{
		balance += amount;
		networth += amount;
		onBalanceGain.Invoke(amount);
	}

	public void SpendCoins(int amount)
	{
		balance -= amount;
		onBalanceSpend.Invoke(amount);
		Object.Instantiate(coinSpendFX, coinSpendFXOrigin.position, coinSpendFXOrigin.rotation, base.transform);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, interactionRadius);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, coinMagnetRadius);
	}
}
