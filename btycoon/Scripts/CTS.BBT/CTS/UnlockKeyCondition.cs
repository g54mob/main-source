using System;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Conditions/Unlock Key Condition")]
	public class UnlockKeyCondition : ScriptableCondition
	{
		[SerializeField]
		private EUnlockKey _unlockKey;

		public EUnlockKey Key => _unlockKey;

		public override event Action ConditionChanged;

		public override bool IsConditionValid()
		{
			return UnlockingManager.ContainKey(_unlockKey);
		}

		private void OnEnable()
		{
			UnlockingManager.OnNewKeyAdded -= OnNewKeyAdded;
			UnlockingManager.OnNewKeyAdded += OnNewKeyAdded;
		}

		private void OnDisable()
		{
			UnlockingManager.OnNewKeyAdded -= OnNewKeyAdded;
		}

		private void OnNewKeyAdded(EUnlockKey obj)
		{
			ConditionChanged?.Invoke();
		}
	}
}
