using DG.Tweening;
using Data.Quests.QuestViews;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show FactoryFloor Highlight", fileName = "ShowFactoryFloorHighlight", order = 15)]
	public class ShowFactoryFloorHighlightSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private Vector3 _position;

		[SerializeField]
		private OnboardingHighlightArrowView _highlightPrefab;

		[SerializeField]
		private Vector3 _areaMinPosition;

		[SerializeField]
		private Vector3 _areaMaxPosition;

		[SerializeField]
		private GameObject _highlightFactoryFloorVFX;

		private OnboardingHighlightArrowView _spawnedHighlight;

		private GameObject _spawnedFactoryFloorHighlight;

		public OnboardingHighlightArrowView SpawnedHighlight => _spawnedHighlight;

		public GameObject SpawnedFactoryFloorHighlight => _spawnedFactoryFloorHighlight;

		public override void Execute()
		{
			_spawnedHighlight = Object.Instantiate(_highlightPrefab, _position, Quaternion.identity);
			if (_highlightFactoryFloorVFX != null)
			{
				Vector3 position = (_areaMinPosition + _areaMaxPosition) / 2f + new Vector3(0.5f, 0f, 0.5f);
				Vector3 endValue = _areaMaxPosition - _areaMinPosition + new Vector3(1.5f, 3.5f, 1.5f);
				_spawnedFactoryFloorHighlight = Object.Instantiate(_highlightFactoryFloorVFX, position, Quaternion.identity);
				_spawnedFactoryFloorHighlight.transform.DOScale(endValue, 0.5f).SetEase(Ease.OutBack);
			}
		}
	}
}
