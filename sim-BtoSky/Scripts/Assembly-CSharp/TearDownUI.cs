using System;
using RainbowArt.CleanFlatUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TearDownUI : MonoBehaviour
{
	[SerializeField]
	private GameObject unScrewUI;

	[SerializeField]
	private GameObject teardownUI;

	[SerializeField]
	private GameObject desolderUI;

	[SerializeField]
	private GameObject removalUI;

	[SerializeField]
	private GameObject teardownDoneBtn;

	[SerializeField]
	private GameObject removeDoneBtn;

	[SerializeField]
	private GameObject completeUI;

	[SerializeField]
	private TextMeshProUGUI completeDescription;

	[SerializeField]
	private TextMeshProUGUI completeTitle;

	[SerializeField]
	private Image completeMainImage;

	[SerializeField]
	private ProgressBarSpecialPattern desolderGage;

	[SerializeField]
	private GameObject doneBtn;

	[SerializeField]
	private GameObject[] uis;

	public static event Action OnNextBtnPressed;

	public static event Action<ProgressBarSpecialPattern> OnInitTable;

	public static event Action OnDoneBtnPressed;

	private void Start()
	{
		TearDownController.OnTeardownComplete += TearDownController_OnTeardownComplete;
		TearDownController.OnUnscrewDone += TearDownController_OnUnscrewDone;
		TearDownTable.OnTeardownTableInteracted += TearDownTable_OnTeardownTableInteracted;
		TearDownController.OnDesolderStart += TearDownController_OnDesolderStart;
		TeardownBox.OnPcbInBox += TeardownBox_OnPcbInBox;
		TeardownBox.OnPcbNotInBox += TeardownBox_OnPcbNotInBox;
		TeardownBox.OnChipInBox += TeardownBox_OnChipInBox;
		TeardownBox.OnChipNotInBox += TeardownBox_OnChipNotInBox;
		HeatGun.OnDesolderDone += HeatGun_OnDesolderDone;
		base.gameObject.SetActive(value: false);
	}

	private void TearDownController_OnTeardownComplete(Chips obj)
	{
		completeMainImage.sprite = obj.mainImage;
		completeDescription.text = obj.description.GetLocalizedString();
		completeTitle.text = obj.chipName.GetLocalizedString();
		removalUI.SetActive(value: false);
		completeUI.SetActive(value: true);
		doneBtn.SetActive(value: false);
	}

	private void HeatGun_OnDesolderDone()
	{
		desolderUI.gameObject.SetActive(value: false);
		removalUI.gameObject.SetActive(value: true);
	}

	private void TeardownBox_OnChipNotInBox()
	{
		removeDoneBtn.gameObject.SetActive(value: false);
	}

	private void TeardownBox_OnChipInBox()
	{
		removeDoneBtn.gameObject.SetActive(value: true);
	}

	private void TearDownController_OnUnscrewDone()
	{
		unScrewUI.SetActive(value: false);
		teardownUI.SetActive(value: true);
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
		TearDownController.OnTeardownComplete -= TearDownController_OnTeardownComplete;
		TearDownController.OnUnscrewDone -= TearDownController_OnUnscrewDone;
		TearDownController.OnDesolderStart -= TearDownController_OnDesolderStart;
		TearDownTable.OnTeardownTableInteracted -= TearDownTable_OnTeardownTableInteracted;
		TeardownBox.OnPcbInBox -= TeardownBox_OnPcbInBox;
		TeardownBox.OnPcbNotInBox -= TeardownBox_OnPcbNotInBox;
		TeardownBox.OnChipInBox -= TeardownBox_OnChipInBox;
		TeardownBox.OnChipNotInBox -= TeardownBox_OnChipNotInBox;
		HeatGun.OnDesolderDone -= HeatGun_OnDesolderDone;
	}

	private void TearDownController_OnDesolderStart(GameObject obj)
	{
		teardownUI.SetActive(value: false);
		desolderUI.SetActive(value: true);
	}

	private void Update()
	{
	}

	private void TeardownBox_OnPcbNotInBox()
	{
		teardownDoneBtn.SetActive(value: false);
	}

	private void TeardownBox_OnPcbInBox()
	{
		teardownDoneBtn.SetActive(value: true);
	}

	private void TearDownTable_OnTeardownTableInteracted()
	{
		TearDownUI.OnInitTable?.Invoke(desolderGage);
		Debug.Log("TeardownUI");
		OnUI();
		GameManager.S.OffPlayerUI();
	}

	public void OnUI()
	{
		base.gameObject.SetActive(value: true);
		GameObject[] array = uis;
		foreach (GameObject gameObject in array)
		{
			if (gameObject == unScrewUI)
			{
				gameObject.SetActive(value: true);
			}
			else
			{
				gameObject.SetActive(value: false);
			}
		}
	}

	public void OffUI()
	{
	}

	public void NextBtn()
	{
		TearDownUI.OnNextBtnPressed?.Invoke();
	}

	public void DoneBtn()
	{
		TearDownUI.OnDoneBtnPressed?.Invoke();
		teardownDoneBtn.SetActive(value: false);
		removeDoneBtn.SetActive(value: false);
		doneBtn.SetActive(value: true);
		base.gameObject.SetActive(value: false);
	}
}
