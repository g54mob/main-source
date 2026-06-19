using System;
using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuotaReportUI : EntityBehaviourBase, IInputController
{
	[Serializable]
	public class DetailRow
	{
		public int moneyCount;

		public int itemCount;

		public string description = "";

		public TextMeshProUGUI moneyCountText;

		public TextMeshProUGUI itemCountText;

		public TextMeshProUGUI descriptionText;
	}

	public float stepTime = 0.5f;

	public List<GameObject> stepObjects = new List<GameObject>();

	private List<GameObject> finalStepObjects = new List<GameObject>();

	public int indexToInsertCrashoutCounts = 1;

	public RectTransform reportContainer;

	public EasingFunction.Ease easeIn;

	public EasingFunction.Ease easeOut;

	public float showReportTimeSec = 1f;

	public float hideYoffset = 1000f;

	private int stepIndex;

	[Header("QuotaReport References")]
	public TextMeshProUGUI reportTitle;

	public TextMeshProUGUI fulfillmentText;

	public GameObject[] allPlayerCrashoutCounts;

	public TextMeshProUGUI[] allPlayerCrashoutTexts;

	public Image[] allPlayerIconImages;

	public DetailRow[] detailRows;

	public TextMeshProUGUI payoutText;

	public Image quotaPassStamp;

	public Image quotaFailStamp;

	public Animator animator;

	[Header("player contineu")]
	public Image[] playerImages;

	public Sprite playerMissing;

	public Sprite playerHere;

	public Image proceedFilBar;

	public GameObject proceedParent;

	[Header("Sfx")]
	public EventReference passSfx;

	public EventReference failSfx;

	private bool _readyToProceed;

	private List<PlayerResult> _playerResults;

	private ShiftResult _shiftResult;

	protected override void OnEntityCreated()
	{
	}

	protected override void OnUpdatePresentation()
	{
		proceedParent.SetActive(_readyToProceed);
	}

	private void UpdatePlayerProceedUI(List<PlayerResult> playerResults)
	{
		Image[] array = playerImages;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		for (int j = 0; j < playerResults.Count; j++)
		{
			playerImages[j].gameObject.SetActive(value: true);
		}
		for (int k = 0; k < playerImages.Length; k++)
		{
			if (NetworkAggroManagerBase<PlayersManager>.instance.proceededLastTimer || k <= NetworkAggroManagerBase<PlayersManager>.instance.GetNumberPlayersProceeding() - 1)
			{
				playerImages[k].sprite = playerHere;
			}
			else
			{
				playerImages[k].sprite = playerMissing;
			}
		}
		proceedFilBar.fillAmount = NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue();
	}

	private void UpdateUIData(ShiftResult result, int moneyGained, int totalMoney, int trucksDeliveredThisShift, int trucksDelivered, List<PlayerResult> playerResults)
	{
		int num = trucksDelivered;
		NetworkAggroManagerBase<ShiftManager>.instance.GetOutboundsTotalThisShift();
		fulfillmentText.text = num.ToString();
		int count = playerResults.Count;
		for (int i = 0; i < allPlayerCrashoutCounts.Length; i++)
		{
			allPlayerCrashoutCounts[i].SetActive(value: false);
		}
		finalStepObjects = new List<GameObject>(stepObjects);
		for (int j = 0; j < count; j++)
		{
			finalStepObjects.Insert(indexToInsertCrashoutCounts, allPlayerCrashoutCounts[j]);
			allPlayerCrashoutTexts[j].text = playerResults[j].crashOuts.ToString();
		}
		detailRows[0].moneyCount = moneyGained;
		detailRows[0].itemCount = trucksDelivered;
		DetailRow[] array = detailRows;
		foreach (DetailRow detailRow in array)
		{
			detailRow.moneyCountText.text = "$" + detailRow.moneyCount;
			detailRow.itemCountText.text = detailRow.itemCount.ToString();
			detailRow.descriptionText.text = detailRow.description;
		}
		payoutText.text = "$" + moneyGained;
		quotaPassStamp.gameObject.SetActive(result == ShiftResult.QuotaWon);
		quotaFailStamp.gameObject.SetActive(result == ShiftResult.QuotaLost);
	}

	public void Show(ShiftResult result, int moneyGained, int totalMoney, int trucksDelivered, List<PlayerResult> playerResults)
	{
		AggroInputManager.PushController(this);
		_playerResults = new List<PlayerResult>(playerResults);
		_shiftResult = result;
		UpdatePlayerProceedUI(_playerResults);
		UpdateUIData(result, moneyGained, totalMoney, 0, trucksDelivered, playerResults);
		HideStepObjects();
		_readyToProceed = false;
		StopAllCoroutines();
		StartCoroutine(ShowReportCo());
	}

	public void TestShow()
	{
		StopAllCoroutines();
		StartCoroutine(QuotaReportSequenceCo());
	}

	public void Hide()
	{
		AggroInputManager.RemoveController(this);
		StopAllCoroutines();
		StartCoroutine(QuotaReportSequenceCo());
	}

	public void HideStepObjects()
	{
		stepIndex = 0;
		StopAllCoroutines();
		foreach (GameObject finalStepObject in finalStepObjects)
		{
			finalStepObject.SetActive(value: false);
		}
	}

	private IEnumerator ShowReportCo()
	{
		yield return QuotaReportSequenceCo();
		while (true)
		{
			_readyToProceed = true;
			if (AggroInputManager.input.QuotaReport.Continue.WasPressedThisFrame())
			{
				if (NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding())
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
				}
				else
				{
					NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
				}
			}
			yield return null;
		}
	}

	private IEnumerator QuotaReportSequenceCo()
	{
		yield return new WaitForSeconds(1f);
		while (stepIndex < finalStepObjects.Count)
		{
			if (stepIndex == finalStepObjects.Count - 1)
			{
				yield return new WaitForSeconds(2f);
				finalStepObjects[stepIndex].SetActive(value: true);
				stepIndex++;
				if (_shiftResult == ShiftResult.QuotaWon)
				{
					AudioManager.PlaySfx(passSfx);
				}
				else
				{
					AudioManager.PlaySfx(failSfx);
				}
			}
			else
			{
				finalStepObjects[stepIndex].SetActive(value: true);
				stepIndex++;
				yield return new WaitForSeconds(stepTime);
			}
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.QuotaReport.Enable();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.QuotaReport.Disable();
	}
}
