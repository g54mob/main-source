using System;
using System.Collections.Generic;
using Aggro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractUI : EntityBehaviourBase
{
	[Serializable]
	public struct ScoreBubble
	{
		public GameObject scoreBubble;

		public GameObject[] players;
	}

	private static readonly int Hide = Shader.PropertyToID("_hide");

	public LocalizedText localizedText;

	public GameObject lockedText;

	public GameObject[] bells;

	public ScoreBubble[] scoreBubbles;

	public GameObject contractBoxIconPrefab;

	public GameObject contractPlusTextPrefab;

	public ContractSelectionUI contractSelectionUI;

	public GameObject lockedContainer;

	public GameObject unlockedContainer;

	public GameObject demoLockedContainer;

	public GameObject bellsRequiredContainer;

	public TextMeshProUGUI bellsRequiredText;

	public EaseUI cycleLeftEaseUI;

	public EaseUI cycleRightEaseUI;

	public GameObject[] keyboardObjects;

	public GameObject[] gamepadObjects;

	[Header("Grade")]
	public Transform finalGradeContainer;

	public Image finalGradeImage;

	public Image finalGradeDillyImage;

	public Sprite[] gradeSprites;

	public Sprite[] gradeDillySprites;

	public TextMeshProUGUI rightGamePadHint;

	public Image rightMouseButton;

	public TextMeshProUGUI contractNumText;

	public Transform cosmeticUnlockContainer;

	public GameObject costumeUnlockPrefab;

	private List<CostumeUnlockUI> _costumeUnlockUIs = new List<CostumeUnlockUI>();

	private ContractObject.Unlock[] _unlocks;

	public Material cosutmeUnlockedUIMaterial;

	public Material cosutmeLockedUIMaterial;

	[Header("Best Time")]
	public TextMeshProUGUI bestTimeText;

	public void SetUp(string title, int highBellScore, ContractScore highContractScore, bool locked, bool isDemoLocked, int bellsRequired, ContractObject.Unlock[] unlocks, int contractNum, TimeSpan contractTime)
	{
		if (isDemoLocked)
		{
			locked = true;
		}
		lockedContainer.SetActive(locked);
		unlockedContainer.SetActive(!locked);
		demoLockedContainer.SetActive(isDemoLocked);
		bellsRequiredContainer.SetActive(!isDemoLocked);
		contractNumText.text = contractNum.ToString() ?? "";
		contractNumText.enabled = !locked;
		if (locked)
		{
			bellsRequiredText.text = bellsRequired.ToString();
			localizedText.gameObject.SetActive(value: false);
			lockedText.SetActive(value: true);
			return;
		}
		localizedText.SetIndex(title);
		localizedText.gameObject.SetActive(value: true);
		lockedText.SetActive(value: false);
		for (int i = 0; i < bells.Length; i++)
		{
			bells[i].SetActive(i < highBellScore);
		}
		for (int j = 0; j < scoreBubbles.Length; j++)
		{
			scoreBubbles[j].scoreBubble.SetActive(value: false);
		}
		_unlocks = unlocks;
		if (_unlocks != null)
		{
			ContractObject.Unlock[] unlocks2 = _unlocks;
			for (int k = 0; k < unlocks2.Length; k++)
			{
				_ = unlocks2[k];
				CostumeUnlockUI component = UnityEngine.Object.Instantiate(costumeUnlockPrefab, cosmeticUnlockContainer).GetComponent<CostumeUnlockUI>();
				_costumeUnlockUIs.Add(component);
			}
		}
		finalGradeContainer.gameObject.SetActive(highBellScore > 0);
		finalGradeImage.sprite = gradeSprites[(uint)((highBellScore == 5) ? (highContractScore + 1) : ContractScore.D)];
		finalGradeDillyImage.sprite = gradeDillySprites[(uint)((highBellScore == 5) ? (highContractScore + 1) : ContractScore.D)];
		finalGradeImage.color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[(uint)((highBellScore == 5) ? (highContractScore + 1) : ContractScore.D)];
		finalGradeDillyImage.color = GlobalScriptableObject<AggroSettingsObject>.instance.gradeColors[(uint)((highBellScore == 5) ? (highContractScore + 1) : ContractScore.D)];
		if (highBellScore >= 5 && contractTime != TimeSpan.Zero)
		{
			bestTimeText.text = contractTime.ToString("mm\\:ss\\:ff");
		}
		else
		{
			bestTimeText.text = "--:--:--";
		}
	}

	protected override void OnUpdatePresentationEarly()
	{
		GameObject[] array = keyboardObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(AggroInputManager.mode == InputMode.KBM);
		}
		array = gamepadObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(AggroInputManager.mode == InputMode.Gamepad);
		}
		GameUtil.TryGetLocalPlayer(out var _);
		cycleLeftEaseUI.show = contractSelectionUI.selected || (contractSelectionUI.hover && AggroInputManager.mode == InputMode.KBM);
		cycleRightEaseUI.show = contractSelectionUI.selected || (contractSelectionUI.hover && AggroInputManager.mode == InputMode.KBM);
	}

	protected override void OnUpdatePresentation()
	{
		for (int i = 0; i < _costumeUnlockUIs.Count; i++)
		{
			CostumeObject costume = _unlocks[i].costume;
			_costumeUnlockUIs[i].icon.sprite = costume.costumeTextures[SaveManager.data.GetColorIndex()];
			if (SaveManager.data.IsCostumeUnlocked(costume))
			{
				_costumeUnlockUIs[i].icon.material = cosutmeUnlockedUIMaterial;
				_costumeUnlockUIs[i].lockedContainer.SetActive(value: false);
			}
			else
			{
				_costumeUnlockUIs[i].icon.material = cosutmeLockedUIMaterial;
				_costumeUnlockUIs[i].lockedContainer.SetActive(value: true);
				_costumeUnlockUIs[i].bellsRequiredText.text = _unlocks[i].bellsRequired.ToString();
			}
		}
	}

	public void Cycle(int amount)
	{
		contractSelectionUI.Cycle(amount);
	}
}
