using DG.Tweening;
using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScoreCtrl : SingletonMonoBehaviour<ScoreCtrl>
	{
		[SerializeField]
		private GameObject activeGroup;

		[SerializeField]
		private Image symbol;

		[SerializeField]
		private Image scoreBar;

		[SerializeField]
		private ChoiceMenuButton indicatorPrefab;

		[SerializeField]
		private RectTransform indicatorArea;

		[SerializeField]
		private TMP_Text plusText;

		[SerializeField]
		private TMP_Text scoreValue;

		[SerializeField]
		private float maxIncrease;

		[Header("アニメーション設定")]
		[SerializeField]
		private double animationInterval;

		[SerializeField]
		private Vector3 plusTextGoal;

		[SerializeField]
		private float duration;

		private double _nextRap;

		private float _maxDisplayBorder;

		private float _barX;

		private Vector3 _plusTextInitPos;

		private Sequence _sequence;

		public static bool IsEnable;

		public void Init()
		{
		}

		private bool CustomFilter(eStageId stageId)
		{
			return false;
		}

		public void GetPoint(int value, int nowScore)
		{
		}

		private void ResetAnimationElement()
		{
		}

		private void UpdateScoreBar(int nowScore)
		{
		}
	}
}
