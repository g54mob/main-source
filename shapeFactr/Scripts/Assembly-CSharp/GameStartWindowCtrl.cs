using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStartWindowCtrl : MonoBehaviour
{
	[Serializable]
	public class MasterDetailInfo
	{
		public eWriterId id;

		public Sprite iconSprite;

		public Sprite penSprite;

		public List<eResearchCategory> researchCategories;

		public List<eLuggage> units;
	}

	[Serializable]
	public class RaceTabInfo
	{
		public eUnitRace race;

		public GameObject onObj;

		public GameObject offObj;
	}

	[Header("Item")]
	[SerializeField]
	private GameObject researchIconItem;

	[SerializeField]
	private RectTransform firstResearchIconGroup;

	[SerializeField]
	private GameObject fixedResearchContent;

	[SerializeField]
	private GameObject firstResearchContent;

	[SerializeField]
	private Image researchIconImage;

	[SerializeField]
	private Image unitIconItem;

	[SerializeField]
	private RectTransform layoutRoot;

	[Header("Master")]
	[SerializeField]
	private Image masterIcon;

	[SerializeField]
	private Image masterPenIcon;

	[SerializeField]
	private TMP_Text masterName;

	[SerializeField]
	private TMP_Text masterDesc;

	[SerializeField]
	private List<MasterDetailInfo> masterDetailInfoList;

	[SerializeField]
	private List<RaceTabInfo> raceTabInfoList;

	[Header("Ascension")]
	[SerializeField]
	private GameObject ascentionObj;

	[SerializeField]
	private TMP_Text ascensionText;

	[SerializeField]
	private TMP_Text ascensionDescText;

	[SerializeField]
	private TMP_Text manaText;

	[SerializeField]
	private TMP_Text manaTextChallenge;

	[Header("Challenge")]
	[SerializeField]
	private GameObject challengeObj;

	[SerializeField]
	private TMP_Text challengeDescText;

	[SerializeField]
	private GameObject titleObj;

	[SerializeField]
	private TMP_Text titleText;

	[SerializeField]
	private Transform difficultyParent;

	[SerializeField]
	private GameObject lvIconObj;

	[Header("Option")]
	[SerializeField]
	private GameObject freeModeOptionGroup;

	[SerializeField]
	private Toggle freeModeOption;

	[SerializeField]
	private GameObject freeModeInfoObj;

	private InputActionController input;

	private const string CurrentAscensionColor = "#FFCE22";

	public bool IsStartGame;

	public bool IsSetFreeControlMode => false;

	public bool IsOnFreeControlMode => false;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void InitTitle(MstChallengeDataEntities challengeData)
	{
	}

	private void InitDifficulty(MstChallengeDataEntities challengeData)
	{
	}

	public void SetLevelDesc(eStageId stage, int level)
	{
	}

	public void OnChangeFreeModeOption(bool value)
	{
	}

	private void OnDisable()
	{
	}

	public void OnClickBackButton()
	{
	}
}
