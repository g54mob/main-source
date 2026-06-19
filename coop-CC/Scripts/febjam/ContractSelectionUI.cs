using System;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ContractSelectionUI : EntityBehaviourBase, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[FormerlySerializedAs("selectedContractSync")]
	public int selectedContractIndex;

	public float offsetDistance = 2048f;

	private float _currentOffset;

	public EasingFunction.Ease ease = EasingFunction.Ease.EaseOutBack;

	public float speed = 1f;

	public float hideSpeed = 1f;

	public Transform contractGroup;

	public bool hide;

	public bool selected;

	public bool hover;

	public List<ContractObject> _contracts = new List<ContractObject>();

	public GameObject contractUIPrefab;

	public GameObject randomContractUIPrefab;

	public StudioEventEmitter showSFX;

	public StudioEventEmitter hideSFX;

	public StudioEventEmitter failToChangePageSFX;

	public EventReference changeContractLeftSfx;

	public EventReference changeContractRightSfx;

	private bool _wasUp;

	public LobbyContractVisualManager lobbyContractVisualManager;

	public int detectedHostBellCount = -1;

	private int previousContractIndex;

	private ulong _saveVersion;

	public LobbyReadyUpUI lobbyReadyUpUI;

	public TextMeshProUGUI hostName;

	public Image hostIcon;

	public float highPos = -540f;

	public float lowPos = -890f;

	protected override void OnUpdatePresentationEarly()
	{
		hide = false;
	}

	protected override void OnUpdateSimulation()
	{
	}

	protected override void OnEntityStart()
	{
		previousContractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		CheckForRedraw();
	}

	private void CheckForRedraw()
	{
		if (NetworkAggroManagerBase<LobbyManager>.instance.hostTotalBells != detectedHostBellCount || (base.isServer && _saveVersion != SaveManager.data.GetVersion()))
		{
			detectedHostBellCount = NetworkAggroManagerBase<LobbyManager>.instance.hostTotalBells;
			SetUp();
			lobbyContractVisualManager.SetUp();
		}
	}

	private void SetUp()
	{
		_saveVersion = SaveManager.data.GetVersion();
		_contracts.Clear();
		GameManager.GetAllContracts(_contracts);
		foreach (Transform item in contractGroup)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		int num = 1;
		foreach (ContractObject contract in _contracts)
		{
			ContractUI component = UnityEngine.Object.Instantiate((contract.type == ContractType.Random) ? randomContractUIPrefab : contractUIPrefab, contractGroup).GetComponent<ContractUI>();
			if (!SaveManager.data.TryGetContractBellCount(contract, out var bells))
			{
				bells = 0;
			}
			if (!SaveManager.data.TryGetContractScore(contract, out var score))
			{
				score = ContractScore.D;
			}
			if (!SaveManager.data.TryGetContractTime(contract, out TimeSpan timeSpan))
			{
				timeSpan = TimeSpan.Zero;
			}
			bool locked = NetworkAggroManagerBase<LobbyManager>.instance.hostTotalBells < contract.bellsRequired;
			component.contractSelectionUI = this;
			component.SetUp(contract.title, bells, score, locked, contract.isDemoLocked, contract.bellsRequired, contract.unlocks, num, timeSpan);
			num++;
		}
		if (NetworkAggroManagerBase<NetworkPlayerManager>.instance.TryGetHostNameAndColor(out var text, out var colorIndex))
		{
			hostName.text = text;
			hostIcon.color = GlobalScriptableObject<AggroSettingsObject>.instance.playerUIColors[colorIndex];
		}
		else
		{
			hostName.text = "";
		}
	}

	public void Cycle(int direction)
	{
		int contractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		_ = _contracts[contractIndex];
		if (direction == -1)
		{
			NetworkAggroManagerBase<LobbyManager>.instance.RequestCycleLeft();
		}
		else
		{
			NetworkAggroManagerBase<LobbyManager>.instance.RequestCycleRight();
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (selected)
		{
			if (AggroInputManager.input.Lobby.ChooseLeft.WasPressedThisFrame())
			{
				Cycle(-1);
			}
			if (AggroInputManager.input.Lobby.ChooseRight.WasPressedThisFrame())
			{
				Cycle(1);
			}
		}
		int contractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		if (previousContractIndex < contractIndex && NetworkAggroManagerBase<LobbyManager>.instance.state != LobbyManager.LobbyState.Transitioning)
		{
			AudioManager.PlaySfx(changeContractLeftSfx);
		}
		if (previousContractIndex > contractIndex && NetworkAggroManagerBase<LobbyManager>.instance.state != LobbyManager.LobbyState.Transitioning)
		{
			AudioManager.PlaySfx(changeContractRightSfx);
		}
		previousContractIndex = contractIndex;
	}

	protected override void OnUpdatePresentationLate()
	{
		float b = (float)selectedContractIndex * offsetDistance;
		_currentOffset = Mathf.Lerp(_currentOffset, b, speed * Time.deltaTime);
		contractGroup.localPosition = new Vector3(0f - _currentOffset, 0f, 0f);
		selectedContractIndex = NetworkAggroManagerBase<LobbyManager>.instance.GetContractIndex();
		Vector2 vector = new Vector2(base.transform.localPosition.x, ((selected && NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue() <= 0f) || ((hover || lobbyReadyUpUI._hover) && NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue() <= 0f && AggroInputManager.mode == InputMode.KBM)) ? highPos : lowPos);
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, vector, hideSpeed * Time.deltaTime);
		float num = (highPos + lowPos) / 2f;
		if (base.transform.localPosition.y < num && _wasUp)
		{
			hideSFX.Play();
		}
		if (base.transform.localPosition.y > num && !_wasUp)
		{
			showSFX.Play();
		}
		_wasUp = base.transform.localPosition.y > num;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hover = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hover = false;
	}
}
