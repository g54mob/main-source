using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class SelectMasterItem : MonoBehaviour
	{
		[Serializable]
		public class SelectMasterImageData
		{
			public eWriterId writer;

			public Sprite mainImage;

			public Sprite onImage;
		}

		[Header("Image")]
		public Image mainImage;

		public Image onImage;

		[Header("MasterImage")]
		public List<SelectMasterImageData> masterImageDatas;

		[Header("ChallengeInfo")]
		public Image checkImage;

		public GameObject scoreGroup;

		public TMP_Text bestScoreText;

		public Image scoreTierImage;

		private eWriterId writerId;

		private UnityAction<eWriterId> onClickAction;

		public void Init(eWriterId writer, UnityAction<eWriterId> onClickAction, eChallengeId challengeId = eChallengeId.None)
		{
		}

		private void SetMasterImage(eWriterId writer)
		{
		}

		private void SetMasterChallengeInfo(MstChallengeDataEntities challengeData)
		{
		}

		public void OnClickButton()
		{
		}
	}
}
