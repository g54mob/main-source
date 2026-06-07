using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Timed Validator", fileName = "Timed", order = 5)]
	public class TimedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private float _delayTime;

		private Sequence _timerSequence;

		private bool _timerCompleted;

		public override bool IsValid()
		{
			if (_timerSequence == null)
			{
				_timerCompleted = false;
				_timerSequence = DOTween.Sequence();
				_timerSequence.AppendInterval(_delayTime);
				_timerSequence.OnComplete(delegate
				{
					_timerCompleted = true;
				});
			}
			return _timerCompleted;
		}

		[Button(null, EButtonEnableMode.Always)]
		public override void Reset()
		{
			_timerSequence = null;
			_timerCompleted = false;
		}
	}
}
