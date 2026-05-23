using System;
using System.Collections.Generic;
using DG.Tweening;
using InputControl;
using SaveData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScoreDetailPanel : MonoBehaviour
	{
		[SerializeField]
		private ScoreTarget scoreTarget;

		[SerializeField]
		private ScoreDetailItem detailItemPrefab;

		[SerializeField]
		private RectTransform detailItemArea;

		[SerializeField]
		private TMP_Text scoreText;

		[SerializeField]
		private Image rankImage;

		[SerializeField]
		private GameObject rankBackground;

		[SerializeField]
		private Image newRecordImage;

		[SerializeField]
		private float duration;

		[SerializeField]
		private float fadeinDelay;

		[SerializeField]
		private float rankIconDuration;

		[SerializeField]
		private GameObject closeButtonGroup;

		[SerializeField]
		private GameObject background;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[SerializeField]
		private CursorUIGroup dummyGroup;

		[SerializeField]
		private CursorUIGroup contentGroup;

		private List<ScoreDetailItem> _scoreDetailItems;

		private Sequence _sequence;

		private bool _isReference;

		private List<(eScoreRecord, ScoreDetailModel)> _scoreDetails;

		private int _score;

		public Action OnBackAction;

		public Sprite Init(bool isReference, eStageId stageId, int score, List<(eScoreRecord, ScoreDetailModel)> scoreDetails, bool isNewRecord = false)
		{
			return null;
		}

		private void ClearContents()
		{
		}

		public void OnClickBack()
		{
		}

		private void SetStartState()
		{
		}

		private void SetGoalState()
		{
		}

		public void Open()
		{
		}
	}
}
