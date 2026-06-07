using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class SelectMasterDialog : BaseDialog
	{
		[SerializeField]
		private GameObject titleObj;

		[SerializeField]
		private TMP_Text titleText;

		[SerializeField]
		private TMP_Text selectText;

		[SerializeField]
		private TMP_Text messageText;

		[SerializeField]
		private Transform contentsParent;

		[SerializeField]
		private SelectMasterItem itemPrefab;

		[SerializeField]
		private Transform difficultyParent;

		[SerializeField]
		private GameObject lvIconObj;

		[SerializeField]
		private ScoreTarget scoreTarget;

		private UnityAction<eWriterId> onSelectAction;

		private UnityAction onCancelAction;

		private MstChallengeDataEntities challengeData;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void InitTitle(MstChallengeDataEntities challengeData)
		{
		}

		private void InitItems(List<eWriterId> writers)
		{
		}

		private void InitText(List<eWriterId> writers)
		{
		}

		private void InitDifficulty(MstChallengeDataEntities challengeData)
		{
		}

		private void SetTargetScore(MstChallengeDataEntities challengeData)
		{
		}

		public void OnClickCancel()
		{
		}

		public void OnClickItem(eWriterId writer)
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}
	}
}
