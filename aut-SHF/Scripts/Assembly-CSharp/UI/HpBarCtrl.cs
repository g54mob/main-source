using DG.Tweening;
using Libs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class HpBarCtrl : SingletonMonoBehaviour<HpBarCtrl>, IUIMouseOverValueGetter
	{
		public Image hpBar;

		public Image trailBar;

		public float trailwaitTime;

		public float trailDuration;

		public GameObject gameOver;

		public GameObject endlessFinish;

		public Image symbolPen;

		public Image symbolCircle;

		public RectTransform unmaskTarget;

		public CanvasGroup symbolGroup;

		[SerializeField]
		private TMP_Text debugHp;

		[SerializeField]
		private TMP_Text hpText;

		[SerializeField]
		private GameObject gameOverButton;

		[SerializeField]
		private GameObject endlessFinishButton;

		private Sequence _gateSequence;

		private float _prevFillAmount;

		private Tween _hpTrailTween;

		private bool IsInitialized;

		private void Update()
		{
		}

		public void Init()
		{
		}

		public string GetMouseOverValue()
		{
			return null;
		}

		public void UpdateUI()
		{
		}

		public void DamageEffect()
		{
		}

		public void GameOver()
		{
		}

		public void EndlessFinish()
		{
		}

		public void OnClickGameOver()
		{
		}

		public void SwitchGameOver(bool on)
		{
		}

		public void EnableHpText(bool on)
		{
		}

		public void SwitchEndlessFinish(bool on)
		{
		}

		private void TrailHp()
		{
		}
	}
}
