using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ResearchTreeCount : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private TMP_Text _text;

		[SerializeField]
		private float _updateDuration = 0.5f;

		private float _currentDisplayedCount;

		protected override void OnDisabled()
		{
			TechTreePoints.OnGainResearchPoints -= OnPointCountChanged;
			TechTreePoints.OnLooseResearchPoints -= OnPointCountChanged;
		}

		protected override void OnEnabled()
		{
			TechTreePoints.OnGainResearchPoints += OnPointCountChanged;
			TechTreePoints.OnLooseResearchPoints += OnPointCountChanged;
		}

		private void Update()
		{
			UpdateText();
		}

		private void UpdateText()
		{
			_text.text = Mathf.RoundToInt(_currentDisplayedCount).ToString();
		}

		private void OnPointCountChanged()
		{
			this.DOKill();
			DOTween.To(() => _currentDisplayedCount, delegate(float x)
			{
				_currentDisplayedCount = x;
			}, TechTreeManager.GetCurrentPoints, _updateDuration).SetEase(Ease.OutQuint).SetUpdate(isIndependentUpdate: true)
				.SetTarget(this);
		}
	}
}
