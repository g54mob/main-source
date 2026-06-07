using System;
using System.Collections.Generic;
using SaveData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class SelectChallengeItem : MonoBehaviour
	{
		private enum eState
		{
			Hide = 0,
			ComingSoon = 1,
			OpenLock = 2,
			OpenUnlock = 3
		}

		[Serializable]
		public class ChallengeMasterIconData
		{
			public eWriterId writer;

			public Sprite icon;
		}

		[Serializable]
		public class ChallengeMasterIconBase
		{
			public GameObject obj;

			public Image icon;

			public Image check;

			public GameObject clearWaveObj;

			public TMP_Text clearWaveText;
		}

		[Header("Item")]
		public Image mainImage;

		public Image mainOnImage;

		public TMP_Text titleText;

		public GameObject mainPartsObj;

		public GameObject smallTitleObj;

		public Button mainButton;

		public GameObject comingsoonObj;

		[Header("Lock")]
		public GameObject releaseConditionObj;

		public TMP_Text releaseConditionText;

		[Header("Difficulty")]
		public Transform difficultyParent;

		public GameObject lvIconObj;

		[Header("MasterIcons")]
		public Transform availableMastersParent;

		public ChallengeMasterIconBase masterIconBase;

		public List<ChallengeMasterIconData> masterIconDatas;

		private MstChallengeDataEntities data;

		private UnityAction<MstChallengeDataEntities> onClickAction;

		private eState state;

		private bool isHide => false;

		private bool isComingSoon => false;

		private bool isOpen => false;

		private bool isOpenLock => false;

		private bool isOpenUnlock => false;

		public void Init(MstChallengeDataEntities data, UnityAction<MstChallengeDataEntities> onClickAction)
		{
		}

		private void SwitchState()
		{
		}

		private void SwitchVisible()
		{
		}

		private void SetDifficulty(int level)
		{
		}

		private void SetAvailableMasters(MstChallengeDataEntities data, ChallengeData playData)
		{
		}

		public void OnClickItem()
		{
		}

		public void OnPointerEnterItem()
		{
		}

		public void OnPointerExitItem()
		{
		}
	}
}
