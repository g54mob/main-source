using UnityEngine;

namespace Data.Quests.Validators
{
	public abstract class AbstractSubQuestValidatorSO : ScriptableObject
	{
		[SerializeField]
		private bool _hasProgress;

		public bool HasProgress => _hasProgress;

		public virtual float GetProgress()
		{
			return 0f;
		}

		public virtual float GetProgressTarget()
		{
			return 1f;
		}

		public abstract bool IsValid();

		public abstract void Reset();
	}
}
