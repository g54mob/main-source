using System;
using FMODUnity;
using OUSystems.Basics.UI;
using UnityEngine;

public class UpgradeStation : MonoBehaviour
{
	[SerializeField]
	public ClickListener _clickable;

	[SerializeField]
	private UpgradeStationTrackingUI _trackingUI;

	[SerializeField]
	private PaymentCollector _paymentCollector;

	[SerializeField]
	private UpgradeAttempt _upgradeAttempt;

	[SerializeField]
	private EventReference _onUpgradeCompleteSound;

	public static Action<UpgradeStation, UpgradeAttempt> AnnounceUpgradeAttempt;

	public static Action<UpgradeStation> AnnounceUpgradeAttemptCleared;

	public bool Initiated;

	public static UpgradeStation Instance { get; private set; }

	public UpgradeInstance SelectedUpgrade => null;

	public bool TrackingUpgrade => false;

	private void Start()
	{
	}

	public void OnAllUpgradesCompleted()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnClick()
	{
	}

	public void SelectUpgrade(UpgradeInstance upgradeInstance)
	{
	}

	public void Fulfill()
	{
	}
}
